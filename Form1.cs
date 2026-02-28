using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Code : Kees van Engelen (keesvanengelen@gmail.com)
//
// Version : 18-x (feb 26)
// Name    : DEVEL101 Yaesu FTDX101D @ COMx


namespace DEVEL101
{
    public partial class MainForm : Form
    {
        #region CAT Command Constants
        private const string CMD_TEMP       = "RM9;";
        private const string CMD_RFSQL_R    = "EX030107;";
        private const string CMD_RFSQL_ON   = "EX0301071;";
        private const string CMD_RFSQL_OFF  = "EX0301070;";
        private const string CMD_DSPMOD_R   = "SS06;";
        private const string CMD_DSPSPAN_R  = "SS05;";
        private const string CMD_MODE_R     = "MD0;";
        private const string CMD_ANT_R      = "AN0;";
        private const string CMD_IPO_R      = "PA0;";
        private const string CMD_RX_R       = "FR;";
        private const string CMD_RFGAIN_R   = "RG0;";
        private const string CMD_VOL_R      = "AG0;";
        private const string CMD_PWR_R      = "PC;";
        private const string CMD_SUBRF_R    = "RG1;";
        private const string CMD_SUBVOL_R   = "AG1;";
        private const string CMD_FREQA_R    = "FA;";
        private const string CMD_FREQB_R    = "FB;";
        private const string CMD_TUNER_R    = "AC;";
        private const string CMD_SWAP       = "SV;";
        private const string CMD_CENTER     = "SS0650000;";
        private const string CMD_CURSOR     = "SS0680000;";
        private const string CMD_FIX        = "SS06B0000;";
        #endregion

        // --- Serial port ---
        private SerialPort serialPort;
        private readonly object serialLock = new object();

        // --- Poll loop ---
        private CancellationTokenSource cts;

        // --- Slider debounce (150 ms) ---
        private System.Windows.Forms.Timer sliderDebounceTimer;
        private readonly Dictionary<TrackBar, string> pendingSliderCommands = new();
        private bool isUpdatingFromRadio = false;

        // --- COM port controls (programmatic — can be moved to designer later) ---
        private ComboBox comPortComboBox;
        private Button ConnectButton;
        private Button DisconnectButton;

        // --- State ---
        private bool   rfSqlOn   = false;
        private string Bar       = "";
        private string savedMode = "";
        private string savedPstr = "";
        private string FColorB   = "Cyan";

        // =================================================================
        public MainForm()
        {
            InitializeComponent();

            // Restore window position (multi-monitor safe)
            if (Properties.Settings.Default.IsLocationSaved)
            {
                Point saved = Properties.Settings.Default.FormLocation;
                if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(saved)))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = saved;
                }
            }

            // Slider debounce timer
            sliderDebounceTimer = new System.Windows.Forms.Timer { Interval = 150 };
            sliderDebounceTimer.Tick += SliderDebounceTimer_Tick;

            // ExtTuneButton styling
            ExtTuneButton.FlatStyle = FlatStyle.Flat;
            ExtTuneButton.FlatAppearance.BorderSize  = 0;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.Paint += TuneButton_Paint;
            SetButtonActive(ExtTuneButton, false);
            ExtTuneButton.Enabled = false;

            // Create COM port controls row
            CreatePortControls();

            // Wire all events — not in designer
            InitializeTrackBarEvents();

            // Populate COM port list
            LoadAvailablePorts();

            this.Text = "DEVEL101 v18 - by Kees, ON9KVE - Disconnected";
            this.FormClosing += MainForm_FormClosing;
        }

        // =================================================================
        #region Serial Port Controls (programmatic)

        private void CreatePortControls()
        {
            // Expand form height for the new control row
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height + 33);

            var portLabel = new Label
            {
                Text      = "PORT:",
                ForeColor = Color.Yellow,
                BackColor = Color.Black,
                Font      = new Font("Verdana", 7F, FontStyle.Bold),
                AutoSize  = true,
                Location  = new Point(3, 135)
            };

            comPortComboBox = new ComboBox
            {
                Location      = new Point(46, 130),
                Size          = new Size(110, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DrawMode      = DrawMode.OwnerDrawFixed,
                BackColor     = Color.DarkGreen,
                ForeColor     = Color.Yellow,
                Font          = new Font("Verdana", 7F, FontStyle.Bold)
            };

            ConnectButton = new Button
            {
                Location                = new Point(162, 128),
                Size                    = new Size(78, 25),
                Text                    = "Connect",
                FlatStyle               = FlatStyle.Flat,
                Font                    = new Font("Verdana", 7F, FontStyle.Bold),
                ForeColor               = Color.Yellow,
                BackColor               = Color.DarkGreen,
                UseVisualStyleBackColor = false
            };
            ConnectButton.FlatAppearance.BorderColor = Color.White;

            DisconnectButton = new Button
            {
                Location                = new Point(244, 128),
                Size                    = new Size(90, 25),
                Text                    = "Disconnect",
                FlatStyle               = FlatStyle.Flat,
                Font                    = new Font("Verdana", 7F, FontStyle.Bold),
                ForeColor               = Color.Yellow,
                BackColor               = Color.DarkRed,
                UseVisualStyleBackColor = false
            };
            DisconnectButton.FlatAppearance.BorderColor = Color.White;

            this.Controls.Add(portLabel);
            this.Controls.Add(comPortComboBox);
            this.Controls.Add(ConnectButton);
            this.Controls.Add(DisconnectButton);
        }

        #endregion

        // =================================================================
        #region Serial Port Management

        private void LoadAvailablePorts()
        {
            comPortComboBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames()
                .Where(p => p.StartsWith("COM") &&
                            int.TryParse(p.Substring(3), out int n) && n >= 0 && n <= 20)
                .OrderBy(p => int.Parse(p.Substring(3)))
                .ToArray();
            comPortComboBox.Items.AddRange(ports);

            string last = Properties.Settings.Default.SerialPort;
            int    idx  = Array.IndexOf(ports, last);
            comPortComboBox.SelectedIndex = idx >= 0 ? idx : (ports.Length > 0 ? 0 : -1);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (comPortComboBox.SelectedItem == null) return;
            string portName = comPortComboBox.SelectedItem.ToString();
            try
            {
                serialPort = new SerialPort(portName, 38400, Parity.None, 8, StopBits.Two)
                {
                    Handshake    = Handshake.None,
                    RtsEnable    = true,
                    ReadTimeout  = 500,
                    WriteTimeout = 500
                };
                serialPort.Open();

                Properties.Settings.Default.SerialPort = portName;
                Properties.Settings.Default.Save();

                this.Text = $"DEVEL101 v18 - by Kees, ON9KVE - {portName}";
                ExtTuneButton.Enabled = true;

                cts = new CancellationTokenSource();
                Task.Run(async () =>
                {
                    await ReadRadioStatusAsync();
                    await DoThisLoopAsync();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open port: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e) => DisconnectSerialPort();

        private void DisconnectSerialPort()
        {
            cts?.Cancel();
            if (serialPort?.IsOpen == true) serialPort.Close();
            serialPort?.Dispose();
            serialPort = null;
            if (IsHandleCreated)
                BeginInvoke((Action)(() =>
                {
                    ExtTuneButton.Enabled = false;
                    this.Text = "DEVEL101 v18 - by Kees, ON9KVE - Disconnected";
                }));
        }

        #endregion

        // =================================================================
        #region Command Sending

        /// <summary>Atomic send + read under lock — use for all poll and interactive commands.</summary>
        private string SendReceive(string cmd)
        {
            if (serialPort == null || !serialPort.IsOpen) return "";
            lock (serialLock)
            {
                try
                {
                    serialPort.Write(cmd);
                    Thread.Sleep(6);
                    return serialPort.ReadTo(";");
                }
                catch { return ""; }
            }
        }

        /// <summary>Send only — no response expected (e.g. SET commands).</summary>
        private void SendCommand(string cmd)
        {
            if (serialPort == null || !serialPort.IsOpen) return;
            lock (serialLock)
            {
                try { serialPort.Write(cmd); Thread.Sleep(6); }
                catch { }
            }
        }

        #endregion

        // =================================================================
        #region Poll Loop

        private static readonly string[] PollCmds =
        {
            CMD_TEMP,     CMD_RFSQL_R,  CMD_DSPMOD_R, CMD_DSPSPAN_R,
            CMD_MODE_R,   CMD_ANT_R,    CMD_IPO_R,    CMD_RX_R,
            CMD_RFGAIN_R, CMD_VOL_R,    CMD_PWR_R,
            CMD_SUBRF_R,  CMD_SUBVOL_R,
            CMD_FREQA_R,  CMD_FREQB_R,  CMD_TUNER_R
        };

        private async Task ReadRadioStatusAsync()
        {
            foreach (string cmd in PollCmds)
            {
                if (cts.IsCancellationRequested) return;
                ProcessResponse(SendReceive(cmd));
                await Task.Delay(60);
            }
        }

        private async Task DoThisLoopAsync()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    lock (serialLock)
                    {
                        serialPort?.DiscardInBuffer();
                        serialPort?.DiscardOutBuffer();
                    }

                    foreach (string cmd in PollCmds)
                    {
                        if (cts.IsCancellationRequested) break;
                        ProcessResponse(SendReceive(cmd));
                    }

                    Bar = Bar == "¦" ? " " : "¦";
                    UpdateTextBox(BUSY_box, Bar);

                    await Task.Delay(100, cts.Token);
                }
                catch (OperationCanceledException) { break; }
                catch (Exception ex)
                {
                    try { File.AppendAllText(logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Loop error: {ex.Message}{Environment.NewLine}"); }
                    catch { }
                    await Task.Delay(100);
                }
            }
        }

        private void ProcessResponse(string resp)
        {
            if (string.IsNullOrEmpty(resp)) return;

            if (resp.StartsWith("RM9") && resp.Length >= 6)
            {
                decimal tempnum = Convert.ToDecimal(resp.Substring(3, 3));
                decimal TempD   = decimal.Floor((tempnum / 2.3M) - 6);
                FColorB = TempD > 40 ? "Red" : TempD > 33 ? "Orange" : "Cyan";
                if (TempD > 40) Console.Beep(3000, 1000);
                UpdateTextBox(TEMP_box, $"{TempD:00}°C", Color.FromName(FColorB));
            }
            else if (resp.StartsWith("EX030107") && resp.Length >= 9)
            {
                bool sq = resp[8] == '1';
                rfSqlOn = sq;
                UpdateTextBox(RFSQL_box, sq ? "Squelch" : "RF");
            }
            else if (resp.StartsWith("SS06") && resp.Length >= 5)
            {
                string d = resp[4] switch { '8' => "CURSOR", '5' => "CENTER", _ => "FIX" };
                UpdateTextBox(DSPMOD_box, d);
            }
            else if (resp.StartsWith("SS05") && resp.Length >= 5)
            {
                string d = resp[4] switch
                {
                    '9' => "1 M", '4' => "20k",  '5' => "50k",
                    '6' => "100k", '7' => "200k", '8' => "500k", _ => "*OTHER*"
                };
                UpdateTextBox(DSPSPAN_box, d);
            }
            else if (resp.StartsWith("MD0") && resp.Length >= 4)
            {
                string d = resp[3] switch
                {
                    '1' => "LSB", '2' => "USB", '3' => "CW",
                    '4' => "FM",  '5' => "AM",  'C' => "DIG-U", _ => "???"
                };
                UpdateTextBox(MODE_box, d);
            }
            else if (resp.StartsWith("AN0") && resp.Length >= 4)
            {
                string d = resp[3] switch { '1' => "ANT1", '2' => "ANT2", '3' => "ANT3/RX", _ => "???" };
                UpdateTextBox(ANT_box, d);
            }
            else if (resp.StartsWith("PA0") && resp.Length >= 4)
            {
                string d = resp[3] switch { '0' => "IPO", '1' => "AMP1", '2' => "AMP2", _ => "???" };
                UpdateTextBox(IPO_box, d);
            }
            else if (resp.StartsWith("FR") && resp.Length >= 4)
            {
                string d = resp switch
                {
                    "FR01" => "RX 1", "FR10" => "RX 2",
                    "FR00" => "RX 1 + 2", "FR11" => "RXs off", _ => "???"
                };
                UpdateTextBox(RX_box, d);
            }
            else if (resp.StartsWith("RG0") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(rfGainTrackBar, textBox1,
                        rfGainTrackBar.Maximum - v, (rfGainTrackBar.Maximum - v).ToString("D3"));
            }
            else if (resp.StartsWith("AG0") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(volumeGainTrackBar, textBox2, v, v.ToString("D3"));
            }
            else if (resp.StartsWith("PC") && resp.Length >= 5)
            {
                if (int.TryParse(resp.Substring(2, 3), out int v))
                    SafeUpdateSlider(pwrControlTrackBar, textBox3, v, v.ToString("D3"));
            }
            else if (resp.StartsWith("RG1") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(SubrfGainTrackBar, textBox5,
                        SubrfGainTrackBar.Maximum - v, (SubrfGainTrackBar.Maximum - v).ToString("D3"));
            }
            else if (resp.StartsWith("AG1") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(SubvolumeGainTrackBar, textBox6, v, v.ToString("D3"));
            }
            else if (resp.StartsWith("FA") && resp.Length >= 4)
            {
                string freqStr = resp.Substring(2, resp.Length - 3); // FTDX101D-specific offset
                if (long.TryParse(freqStr, out long freqHz))
                    UpdateTextBox(FreqM_box, $"MAIN:{freqHz / 100000.0,9:F3} MHz");
            }
            else if (resp.StartsWith("FB") && resp.Length >= 4)
            {
                string freqStr = resp.Substring(2, resp.Length - 3); // FTDX101D-specific offset
                if (long.TryParse(freqStr, out long freqHz))
                    UpdateTextBox(FreqS_box, $"SUB :{freqHz / 100000.0,9:F3} MHz");
            }
            else if (resp.StartsWith("AC") && resp.Length >= 5)
            {
                bool on = resp[4] == '1';
                UpdateTextBox(textBox4, on ? "TUNE ON" : "TUNE OFF", on ? Color.Red : Color.Cyan);
            }
        }

        #endregion

        // =================================================================
        #region UI Helpers

        private void SetButtonActive(Button btn, bool active)
        {
            btn.BackColor = active ? Color.DarkRed : Color.DarkGreen;
            btn.ForeColor = Color.Yellow;
        }

        private void UpdateTextBox(TextBox tb, string text, Color? foreColor = null)
        {
            if (tb.InvokeRequired)
            {
                tb.BeginInvoke(() => UpdateTextBox(tb, text, foreColor));
                return;
            }
            tb.Text = text;
            if (foreColor.HasValue) tb.ForeColor = foreColor.Value;
        }

        /// <summary>Update a slider + display textbox from the radio — guards against feedback loops.</summary>
        private void SafeUpdateSlider(TrackBar tb, TextBox display, int value, string displayStr)
        {
            if (tb.InvokeRequired)
            {
                tb.BeginInvoke(() => SafeUpdateSlider(tb, display, value, displayStr));
                return;
            }
            isUpdatingFromRadio = true;
            tb.Value = Math.Clamp(value, tb.Minimum, tb.Maximum);
            isUpdatingFromRadio = false;
            if (display != null) display.Text = displayStr;
        }

        #endregion

        // =================================================================
        #region Event Wiring — InitializeTrackBarEvents

        private void InitializeTrackBarEvents()
        {
            // Sliders
            rfGainTrackBar.ValueChanged        += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged    += VolumeGainTrackBar_ValueChanged;
            pwrControlTrackBar.ValueChanged    += PwrControlTrackBar_ValueChanged;
            SubrfGainTrackBar.ValueChanged     += SubrfGainTrackBar_ValueChanged;
            SubvolumeGainTrackBar.ValueChanged += SubvolumeGainTrackBar_ValueChanged;

            // External tuner button
            ExtTuneButton.MouseDown  += TuneButton_MouseDown;
            ExtTuneButton.MouseUp    += TuneButton_MouseUp;
            ExtTuneButton.MouseEnter += TuneButton_MouseEnter;
            ExtTuneButton.MouseLeave += TuneButton_MouseLeave;

            // COM port controls
            ConnectButton.Click      += ConnectButton_Click;
            DisconnectButton.Click   += DisconnectButton_Click;
            comPortComboBox.DrawItem += ComboBox_DrawItem;
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var cb   = (ComboBox)sender;
            bool sel = (e.State & DrawItemState.Selected) != 0;
            using var bg = new SolidBrush(sel ? Color.Green : Color.DarkGreen);
            e.Graphics.FillRectangle(bg, e.Bounds);
            using var fg = new SolidBrush(cb.ForeColor);
            e.Graphics.DrawString(cb.Items[e.Index].ToString(), e.Font, fg, e.Bounds);
        }

        #endregion

        // =================================================================
        #region Slider Debounce

        private void SliderDebounceTimer_Tick(object sender, EventArgs e)
        {
            sliderDebounceTimer.Stop();
            foreach (var (_, cmd) in pendingSliderCommands)
                SendCommand(cmd);
            pendingSliderCommands.Clear();
        }

        private void QueueSliderCommand(TrackBar tb, string cmd)
        {
            pendingSliderCommands[tb] = cmd; // last value wins
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        #endregion

        // =================================================================
        #region Slider Handlers

        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int val = rfGainTrackBar.Value;
            UpdateTextBox(textBox1, val.ToString("D3"));
            QueueSliderCommand(rfGainTrackBar, $"RG0{(rfGainTrackBar.Maximum - val):D3};");
        }

        private void VolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            string val = volumeGainTrackBar.Value.ToString("D3");
            QueueSliderCommand(volumeGainTrackBar, $"AG0{val};");
        }

        private void PwrControlTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            string val = pwrControlTrackBar.Value.ToString("D3");
            UpdateTextBox(textBox3, val);
            QueueSliderCommand(pwrControlTrackBar, $"PC{val};");
        }

        private void SubrfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int val = SubrfGainTrackBar.Value;
            UpdateTextBox(textBox5, val.ToString("D3"));
            QueueSliderCommand(SubrfGainTrackBar, $"RG1{(SubrfGainTrackBar.Maximum - val):D3};");
        }

        private void SubvolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            string val = SubvolumeGainTrackBar.Value.ToString("D3");
            UpdateTextBox(textBox6, val);
            QueueSliderCommand(SubvolumeGainTrackBar, $"AG1{val};");
        }

        #endregion

        // =================================================================
        #region Button Handlers

        private void RFB_click(object sender, MouseEventArgs e)
        {
            rfSqlOn = !rfSqlOn;
            SendCommand(rfSqlOn ? CMD_RFSQL_ON : CMD_RFSQL_OFF);
            UpdateTextBox(RFSQL_box, rfSqlOn ? "Squelch" : "RF");
        }

        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            savedMode = SendReceive(CMD_MODE_R);
            string resp = SendReceive(CMD_PWR_R);
            savedPstr = resp.Length >= 2 ? resp[2..] : "100";
            SendCommand("PC010;");
            SendCommand("MD05;");
            SendCommand("MX1;");
        }

        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            SendCommand("MX0;");
            if (!string.IsNullOrEmpty(savedMode)) SendCommand(savedMode + ";");
            SendCommand("PC" + savedPstr + ";");
        }

        private void Center_Click(object sender, MouseEventArgs e)  { SendCommand(CMD_CENTER); }
        private void Cursor_Click(object sender, MouseEventArgs e)  { SendCommand(CMD_CENTER); SendCommand(CMD_CURSOR); }
        private void Fix_Click(object sender, MouseEventArgs e)     { SendCommand(CMD_CENTER); SendCommand(CMD_FIX); }
        private void USB_click(object sender, MouseEventArgs e)     { SendCommand("MD02;"); }
        private void LSB_click(object sender, MouseEventArgs e)     { SendCommand("MD01;"); }
        private void CW_click(object sender, MouseEventArgs e)      { SendCommand("MD03;"); }
        private void FM_click(object sender, MouseEventArgs e)      { SendCommand("MD04;"); }
        private void AM_click(object sender, MouseEventArgs e)      { SendCommand("MD05;"); }
        private void DIG_click(object sender, MouseEventArgs e)     { SendCommand("MD0C;"); }
        private void ANT1B_click(object sender, MouseEventArgs e)   { SendCommand("AN01;"); }
        private void ANT2B_click(object sender, MouseEventArgs e)   { SendCommand("AN02;"); }
        private void ANT3RXB_click(object sender, MouseEventArgs e) { SendCommand("AN03;"); }
        private void IPOB_click(object sender, MouseEventArgs e)    { SendCommand("PA00;"); }
        private void AMP1B_click(object sender, MouseEventArgs e)   { SendCommand("PA01;"); }
        private void AMP2B_click(object sender, MouseEventArgs e)   { SendCommand("PA02;"); }
        private void RX1B_click(object sender, MouseEventArgs e)    { SendCommand("FR01;"); }
        private void RX2B_click(object sender, MouseEventArgs e)    { SendCommand("FR10;"); }
        private void RX12B_click(object sender, MouseEventArgs e)   { SendCommand("FR00;"); }
        private void RX12B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) SendCommand("FR11;");
        }
        private void RX12off_click(object sender, MouseEventArgs e) { SendCommand("FR11;"); }
        private void SSB1_click(object sender, EventArgs e) { SendCommand("SS0560000;"); }
        private void SSB2_click(object sender, EventArgs e) { SendCommand("SS0570000;"); }
        private void SSB3_click(object sender, EventArgs e) { SendCommand("SS0580000;"); }
        private void SSB4_click(object sender, EventArgs e) { SendCommand("SS0590000;"); }
        private void SSB5_click(object sender, EventArgs e) { SendCommand("SS0540000;"); }
        private void SSB6_click(object sender, EventArgs e) { SendCommand("SS0550000;"); }
        private void IntTune_Click(object sender, EventArgs e)  { SendCommand("AC001;"); SendCommand("AC002;"); }
        private void ItuneOn_Click(object sender, EventArgs e)  { SendCommand("AC001;"); }
        private void ItuneOff_Click(object sender, EventArgs e) { SendCommand("AC000;"); }
        private void SWAP_Click(object sender, EventArgs e)     { SendCommand(CMD_SWAP); }
        private void Button1_Click(object sender, EventArgs e)  { UpdateTextBox(TEMP_box, " "); }

        #endregion

        // =================================================================
        #region External Tuner Button Paint

        private void TuneButton_MouseEnter(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.Blue; }
        private void TuneButton_MouseLeave(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.DarkGreen; }

        private void TuneButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;
            const int thickness = 3;
            using var pen = new Pen(Color.White, thickness);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, btn.Width - thickness, btn.Height - thickness));
        }

        #endregion

        // =================================================================
        #region Form Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormLocation = this.WindowState == FormWindowState.Normal
                ? this.Location
                : this.RestoreBounds.Location;
            Properties.Settings.Default.IsLocationSaved = true;
            Properties.Settings.Default.Save();

            cts?.Cancel();
            if (serialPort?.IsOpen == true) serialPort.Close();
        }

        #endregion

        // --- Empty stubs kept for designer compatibility ---
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void RX_box_TextChanged(object sender, EventArgs e) { }
        private void FixB_Click(object sender, EventArgs e) { }
        private void rfGainTrackBar_Scroll(object sender, EventArgs e) { }
    }
}
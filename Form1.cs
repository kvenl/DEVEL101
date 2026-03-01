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
// Version : 18  (01 mrt 26)
// Name    : DEVEL101 Yaesu FTDX101D 


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

        // --- Poll timer (one command per tick — never a background thread timer) ---
        private System.Windows.Forms.Timer pollTimer;
        private int pollIndex = 0;

        // --- Slider debounce (150 ms) ---
        private System.Windows.Forms.Timer sliderDebounceTimer;
        private readonly Dictionary<TrackBar, string> pendingSliderCommands = new();
        private bool isUpdatingFromRadio = false;

        // --- State ---
        private bool   rfSqlOn   = false;
        private bool   iTuneOn   = false;
        private int    flashCount = 0;
        private System.Windows.Forms.Timer extTuneFlashTimer;
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

            // Poll timer
            pollTimer = new System.Windows.Forms.Timer { Interval = 50 };

            // Slider debounce timer
            sliderDebounceTimer = new System.Windows.Forms.Timer { Interval = 150 };
            sliderDebounceTimer.Tick += SliderDebounceTimer_Tick;

            // Flash timer for blocked ExtTuneButton
            extTuneFlashTimer = new System.Windows.Forms.Timer { Interval = 100 };
            extTuneFlashTimer.Tick += ExtTuneFlashTimer_Tick;

            // ExtTuneButton styling
            ExtTuneButton.FlatStyle = FlatStyle.Flat;
            ExtTuneButton.FlatAppearance.BorderSize  = 0;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.Paint += TuneButton_Paint;
            SetButtonActive(ExtTuneButton, false);
            ExtTuneButton.Enabled = false;

            // Wire all events — not in designer
            InitializeTrackBarEvents();

            // Populate COM port list
            LoadAvailablePorts();

            this.Text = "DEVEL101 v18 - by Kees, ON9KVE - Disconnected";
            this.FormClosing  += MainForm_FormClosing;
        }

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

        private void ConnectToggleButton_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
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
                    SetButtonActive(ConnectToggleButton, true);
                    ConnectToggleButton.Text = "Disconnect";

                    Task.Run(() =>
                    {
                        ReadRadioStatus();
                        BeginInvoke((Action)(() => { pollIndex = 0; pollTimer.Start(); }));
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open port: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DisconnectSerialPort();
            }
        }

        private void DisconnectSerialPort()
        {
            pollTimer.Stop();
            if (serialPort?.IsOpen == true) serialPort.Close();
            serialPort?.Dispose();
            serialPort = null;
            if (IsHandleCreated)
                BeginInvoke((Action)(() =>
                {
                    ExtTuneButton.Enabled = false;
                    SetButtonActive(ConnectToggleButton, false);
                    ConnectToggleButton.Text = "Connect";
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

        /// <summary>One-shot initial read of all parameters on connect (runs on background thread).</summary>
        private void ReadRadioStatus()
        {
            foreach (string cmd in PollCmds)
            {
                string resp = SendReceive(cmd);
                Invoke((Action)(() => ProcessResponse(resp)));
                Thread.Sleep(60);
            }
        }

        /// <summary>Fires on the UI thread — sends ONE command per tick, advances pollIndex.</summary>
        private async void PollTimer_Tick(object sender, EventArgs e)
        {
            pollTimer.Stop();

            if (pollIndex == 0)
            {
                lock (serialLock)
                {
                    serialPort?.DiscardInBuffer();
                    serialPort?.DiscardOutBuffer();
                }
            }

            string cmd  = PollCmds[pollIndex];
            pollIndex   = (pollIndex + 1) % PollCmds.Length;

            string resp = await Task.Run(() => SendReceive(cmd));
            ProcessResponse(resp);

            if (pollIndex == 0)
            {
                Bar = Bar == "█" ? " " : "█";
                BUSY_box.Text = Bar;
            }

            pollTimer.Start();
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
                SetButtonActive(RFTOGGLE, sq);
                RFTOGGLE.Text = sq ? "SQL" : "RF / SQL";
            }
            else if (resp.StartsWith("SS06") && resp.Length >= 5)
            {
                SetButtonActive(CursorB, resp[4] == '8');
                SetButtonActive(CenterB, resp[4] == '5');
                SetButtonActive(FixB,    resp[4] != '8' && resp[4] != '5');
            }
            else if (resp.StartsWith("SS05") && resp.Length >= 5)
            {
                SetButtonActive(SSB4, resp[4] == '9');
                SetButtonActive(SSB5, resp[4] == '4');
                SetButtonActive(SSB6, resp[4] == '5');
                SetButtonActive(SSB1, resp[4] == '6');
                SetButtonActive(SSB2, resp[4] == '7');
                SetButtonActive(SSB3, resp[4] == '8');
            }
            else if (resp.StartsWith("MD0") && resp.Length >= 4)
            {
                SetButtonActive(LSBB, resp[3] == '1');
                SetButtonActive(USBB, resp[3] == '2');
                SetButtonActive(CWB,  resp[3] == '3');
                SetButtonActive(FMB,  resp[3] == '4');
                SetButtonActive(AMB,  resp[3] == '5');
                SetButtonActive(DIGB, resp[3] == 'C');
            }
            else if (resp.StartsWith("AN0") && resp.Length >= 4)
            {
                SetButtonActive(ANT1B,   resp[3] == '1');
                SetButtonActive(ANT2B,   resp[3] == '2');
                SetButtonActive(ANT3RXB, resp[3] == '3');
            }
            else if (resp.StartsWith("PA0") && resp.Length >= 4)
            {
                SetButtonActive(IPOB,  resp[3] == '0');
                SetButtonActive(AMP1B, resp[3] == '1');
                SetButtonActive(AMP2B, resp[3] == '2');
            }
            else if (resp.StartsWith("FR") && resp.Length >= 4)
            {
                SetButtonActive(RX1B,    resp == "FR01");
                SetButtonActive(RX2,     resp == "FR10");
                SetButtonActive(RX12B,   resp == "FR00");
                SetButtonActive(RX12off, resp == "FR11");
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
                {
                    long hz = freqHz * 10;
                    UpdateTextBox(FreqM_box, $"{hz / 1000000,2}.{hz / 1000 % 1000:000}.{hz % 1000:000}");
                }
            }
            else if (resp.StartsWith("FB") && resp.Length >= 4)
            {
                string freqStr = resp.Substring(2, resp.Length - 3); // FTDX101D-specific offset
                if (long.TryParse(freqStr, out long freqHz))
                {
                    long hz = freqHz * 10;
                    UpdateTextBox(FreqS_box, $"{hz / 1000000,2}.{hz / 1000 % 1000:000}.{hz % 1000:000}");
                }
            }
            else if (resp.StartsWith("AC") && resp.Length >= 5)
            {
                bool on = resp[4] == '1';
                iTuneOn = on;
                SetButtonActive(ItuneOn,  on);
                SetButtonActive(ItuneOff, !on);
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

        private void UpdateTextBox(Control tb, string text, Color? foreColor = null)
        {
            tb.Text = text;
            if (foreColor.HasValue) tb.ForeColor = foreColor.Value;
        }

        /// <summary>Update a slider + display textbox from the radio — guards against feedback loops.</summary>
        private void SafeUpdateSlider(TrackBar tb, TextBox display, int value, string displayStr)
        {
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

            // Poll timer
            pollTimer.Tick += PollTimer_Tick;

            // COM port controls
            ConnectToggleButton.Click += ConnectToggleButton_Click;
            comPortComboBox.DrawItem  += ComboBox_DrawItem;
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
            // Send opposite of current state; ProcessResponse confirms and updates UI
            SendCommand(rfSqlOn ? CMD_RFSQL_OFF : CMD_RFSQL_ON);
        }

        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (iTuneOn)
            {
                ExtTuneButton.Text = "Blocked";
                flashCount = 0;
                extTuneFlashTimer.Start();
                return;
            }
            savedMode = SendReceive(CMD_MODE_R);
            string resp = SendReceive(CMD_PWR_R);
            savedPstr = resp.Length >= 2 ? resp[2..] : "100";
            SendCommand("PC010;");
            SendCommand("MD05;");
            SendCommand("MX1;");
        }

        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (iTuneOn) return;
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

        private void ExtTuneFlashTimer_Tick(object sender, EventArgs e)
        {
            flashCount++;
            ExtTuneButton.BackColor = (flashCount % 2 == 0) ? Color.DarkGreen : Color.DarkRed;
            if (flashCount >= 6)
            {
                extTuneFlashTimer.Stop();
                flashCount = 0;
                ExtTuneButton.BackColor = Color.DarkGreen;
                ExtTuneButton.Text = "Ext Tuner";
            }
        }

        private void TuneButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            // Fill background ourselves so BackColor is always respected (even when disabled)
            using var bg = new SolidBrush(btn.BackColor);
            e.Graphics.FillRectangle(bg, btn.ClientRectangle);

            // Draw text in yellow regardless of enabled state
            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle,
                Color.Yellow, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);

            // White border
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

            pollTimer.Stop();
            if (serialPort?.IsOpen == true) serialPort.Close();
        }

        #endregion

        // --- Empty stubs kept for designer compatibility ---
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void FixB_Click(object sender, EventArgs e) { }
        private void rfGainTrackBar_Scroll(object sender, EventArgs e) { }
    }
}
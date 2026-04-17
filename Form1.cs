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
// Version : 3.0 beta  (17 apr 26)
// Name    : DEVEL101 Yaesu FTDX101 


namespace DEVEL101
{
    public partial class MainForm : Form
    {
        private const string AppTitle = "The101Box v2.12 - by Kees, ON9KVE";

        #region CAT Command Constants
        private const string CMD_TEMP = "RM9;";
        private const string CMD_RFSQL_R = "EX030107;";
        private const string CMD_RFSQL_ON = "EX0301071;";
        private const string CMD_RFSQL_OFF = "EX0301070;";
        private const string CMD_DSPMOD_R = "SS06;";
        private const string CMD_DSPSPAN_R = "SS05;";
        private const string CMD_MODE_R = "MD0;";
        private const string CMD_ANT_R = "AN0;";
        private const string CMD_IPO_R = "PA0;";
        private const string CMD_DSPMOD_SUB_R = "SS16;";
        private const string CMD_DSPSPAN_SUB_R = "SS15;";
        private const string CMD_MODE_SUB_R = "MD1;";
        private const string CMD_ANT_SUB_R = "AN1;";
        private const string CMD_IPO_SUB_R = "PA1;";
        private const string CMD_RX_R = "FR;";
        private const string CMD_RFGAIN_R = "RG0;";
        private const string CMD_VOL_R = "AG0;";
        private const string CMD_PWR_R = "PC;";
        private const string CMD_SUBRF_R = "RG1;";
        private const string CMD_SUBVOL_R = "AG1;";
        private const string CMD_FREQA_R = "FA;";
        private const string CMD_FREQB_R = "FB;";
        private const string CMD_TUNER_R = "AC;";
        private const string CMD_VS_R = "VS;";
        private const string CMD_SWAP = "SV;";
        private const string CMD_CENTER = "SS0650000;";
        private const string CMD_CURSOR = "SS0680000;";
        private const string CMD_FIX = "SS06B0000;";
        private const string CMD_ATT_R = "RA0;";
        private const string CMD_ATT_SUB_R = "RA1;";
        private const string CMD_LEV_R = "SS04;";
        private const string CMD_LEV_SUB_R = "SS14;";
        private const string CMD_NR_R = "NR0;";
        private const string CMD_NR_SUB_R = "NR1;";
        private const string CMD_DNF_R = "BC0;";
        private const string CMD_DNF_SUB_R = "BC1;";
        private const string CMD_ID = "ID;";
        #endregion

        // --- Serial port ---
        private SerialPort serialPort;
        private readonly object serialLock = new object();

        // --- Poll timer (one command per tick — never a background thread timer) ---
        private System.Windows.Forms.Timer pollTimer;
        private int pollIndex = 0;

        // --- Slider debounce (150 ms) ---
        private System.Windows.Forms.Timer sliderDebounceTimer;
        private readonly Dictionary<CustomTrackBar, string> pendingSliderCommands = new();
        private bool isUpdatingFromRadio = false;

        // --- State ---
        private bool rfSqlOn = false;
        private bool iTuneOn = false;
        private bool isBothMuted = false;
        private int savedMainVol = 0;
        private int savedSubVol = 0;
        private bool rx1Active = false;
        private bool rx2Active = false;
        private bool mainFocused = true;
        private long mainFreqHz = 0;
        private long subFreqHz = 0;
        private bool suppressStepSave = false;
        private int flashCount = 0;
        private System.Windows.Forms.Timer extTuneFlashTimer;
        private string Bar = "";
        private string savedMode = "";
        private string savedPstr = "";
        private string FColorB = "Cyan";
        private double levelShift = 0.0;
        private bool nrOn = false;
        private bool dnfOn = false;
        private int maxPower = 100;
        private string radioModel = "FTDX101D";

        // --- Proportional resize ---
        private readonly SizeF _designClient = new SizeF(727, 241);
        private Dictionary<Control, RectangleF> _designBounds;
        private Dictionary<Control, Font>       _designFonts;
        private readonly Dictionary<Control, Font> _scaledFonts = new();
        private float _aspectRatio;

        // =================================================================
        public MainForm()
        {
            InitializeComponent();
            StoreDesignLayout();
            MinimumSize = this.Size;
            _aspectRatio = (float)this.Width / this.Height;

            // Restore window size and position
            if (Properties.Settings.Default.IsLocationSaved)
            {
                Size savedSize = Properties.Settings.Default.FormSize;
                if (savedSize.Width >= MinimumSize.Width && savedSize.Height >= MinimumSize.Height)
                    this.Size = savedSize;

                Point saved = Properties.Settings.Default.FormLocation;
                if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(saved)))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = saved;
                }
            }

            // Poll timer
            pollTimer = new System.Windows.Forms.Timer { Interval = 6 };

            // Slider debounce timer
            sliderDebounceTimer = new System.Windows.Forms.Timer { Interval = 100 };
            sliderDebounceTimer.Tick += SliderDebounceTimer_Tick;

            // Flash timer for blocked ExtTuneButton
            extTuneFlashTimer = new System.Windows.Forms.Timer { Interval = 100 };
            extTuneFlashTimer.Tick += ExtTuneFlashTimer_Tick;

            // ExtTuneButton styling
            ExtTuneButton.FlatStyle = FlatStyle.Flat;
            ExtTuneButton.FlatAppearance.BorderSize = 0;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.Paint += TuneButton_Paint;
            SetButtonActive(ExtTuneButton, false);
            ExtTuneButton.Enabled = false;

            // Wire all events — not in designer
            InitializeTrackBarEvents();

            // Build initial poll command list (MAIN focused by default)
            RebuildPollCommands();

            // Populate COM port list
            LoadAvailablePorts();

            this.Text = AppTitle + " - Disconnected";
            this.FormClosing += MainForm_FormClosing;
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
            int idx = Array.IndexOf(ports, last);
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
                        Handshake = Handshake.None,
                        RtsEnable = true,
                        ReadTimeout = 500,
                        WriteTimeout = 500
                    };
                    serialPort.Open();

                    Properties.Settings.Default.SerialPort = portName;
                    Properties.Settings.Default.Save();

                    this.Text = $"{AppTitle} - {portName}";
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
                    this.Text = AppTitle + " - Disconnected";
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

        private string[] pollCmds;

        private void RebuildPollCommands()
        {
            string dspMod = mainFocused ? CMD_DSPMOD_R : CMD_DSPMOD_SUB_R;
            string dspSpan = mainFocused ? CMD_DSPSPAN_R : CMD_DSPSPAN_SUB_R;
            string mode = mainFocused ? CMD_MODE_R : CMD_MODE_SUB_R;
            string ant = mainFocused ? CMD_ANT_R : CMD_ANT_SUB_R;
            string ipo = mainFocused ? CMD_IPO_R : CMD_IPO_SUB_R;
            string att = mainFocused ? CMD_ATT_R : CMD_ATT_SUB_R;
            string lev = mainFocused ? CMD_LEV_R : CMD_LEV_SUB_R;
            string nr = mainFocused ? CMD_NR_R : CMD_NR_SUB_R;
            string dnf = mainFocused ? CMD_DNF_R : CMD_DNF_SUB_R;

            pollCmds = new[]
            {
                CMD_FREQA_R, CMD_FREQB_R,
                CMD_TEMP,    CMD_RFSQL_R,
                CMD_FREQA_R, CMD_FREQB_R,
                dspMod,      dspSpan,      mode,         lev,
                CMD_FREQA_R, CMD_FREQB_R,
                ant,         ipo,          att,          nr,          dnf,         CMD_RX_R,
                CMD_FREQA_R, CMD_FREQB_R,
                CMD_RFGAIN_R, CMD_VOL_R,   CMD_PWR_R,
                CMD_FREQA_R, CMD_FREQB_R,
                CMD_SUBRF_R, CMD_SUBVOL_R, CMD_TUNER_R,  CMD_VS_R
            };
            pollIndex = 0;
        }

        /// <summary>One-shot initial read of all parameters on connect (runs on background thread).</summary>
        private void ReadRadioStatus()
        {
            // Detect radio model before anything else
            string idResp = SendReceive(CMD_ID);
            if (idResp.StartsWith("ID") && idResp.Length >= 6)
            {
                string id = idResp.Substring(2);
                radioModel = id == "0682" ? "FTDX101MP" : "FTDX101D";
                maxPower = id == "0682" ? 200 : 100;
            }
            else
            {
                radioModel = "FTDX101D";
                maxPower = 100;
            }
            string portName = serialPort.PortName;
            Invoke((Action)(() =>
            {
                pwrControlTrackBar.Maximum = maxPower;
                pwrControlTrackBar.TickFrequency = maxPower / 20;
                this.Text = $"{AppTitle} - {portName} [{radioModel}]";
            }));

            foreach (string cmd in pollCmds)
            {
                string resp = SendReceive(cmd);
                Invoke((Action)(() => ProcessResponse(resp)));
                Thread.Sleep(6);
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

            string cmd = pollCmds[pollIndex];
            pollIndex = (pollIndex + 1) % pollCmds.Length;

            string resp = await Task.Run(() => SendReceive(cmd));
            ProcessResponse(resp);


            pollTimer.Start();
        }

        private void ProcessResponse(string resp)
        {
            if (string.IsNullOrEmpty(resp)) return;

            if (resp.StartsWith("RM9") && resp.Length >= 6)
            {
                decimal tempnum = Convert.ToDecimal(resp.Substring(3, 3));
                decimal TempD = decimal.Floor((tempnum / 2.3M) - 6);
                FColorB = TempD > 40 ? "Red" : TempD > 33 ? "Orange" : "Cyan";
                if (TempD > 40) Console.Beep(3000, 1000);
                UpdateTextBox(TEMP_box, $"{TempD:00}°C", Color.FromName(FColorB));
            }
            else if (resp.StartsWith("EX030107") && resp.Length >= 9)
            {
                bool sq = resp[8] == '1';
                rfSqlOn = sq;
                SetButtonActive(RFTOGGLE, sq);
                RFTOGGLE.Text = sq ? "SQUELCH\r\nMAIN" : "RF/SQL\r\nMAIN";
            }
            else if ((resp.StartsWith("SS06") || resp.StartsWith("SS16")) && resp.Length >= 5)
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(CursorB, resp[4] == '8');
                    SetButtonActive(CenterB, resp[4] == '5');
                    SetButtonActive(FixB, resp[4] != '8' && resp[4] != '5');
                }
            }
            else if ((resp.StartsWith("SS05") || resp.StartsWith("SS15")) && resp.Length >= 5)
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(SSB4, resp[4] == '9');
                    SetButtonActive(SSB5, resp[4] == '4');
                    SetButtonActive(SSB6, resp[4] == '5');
                    SetButtonActive(SSB1, resp[4] == '6');
                    SetButtonActive(SSB2, resp[4] == '7');
                    SetButtonActive(SSB3, resp[4] == '8');
                }
            }
            else if ((resp.StartsWith("SS04") || resp.StartsWith("SS14")) && resp.Length >= 8)
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    if (double.TryParse(resp.Substring(4),
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double lv))
                    {
                        levelShift = lv;
                        UpdateTextBox(LEV_box, FormatLevel(lv) + " dB", LevColor(lv));
                    }
                }
            }
            else if (resp.StartsWith("MD") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(LSBB, resp[3] == '1');
                    SetButtonActive(USBB, resp[3] == '2');
                    SetButtonActive(CWB, resp[3] == '3');
                    SetButtonActive(FMB, resp[3] == '4');
                    SetButtonActive(AMB, resp[3] == '5');
                    SetButtonActive(DIGB, resp[3] == 'C');
                }
            }
            else if (resp.StartsWith("AN") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(ANT1B, resp[3] == '1');
                    SetButtonActive(ANT2B, resp[3] == '2');
                    SetButtonActive(ANT3RXB, resp[3] == '3');
                }
            }
            else if (resp.StartsWith("PA") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(IPOB, resp[3] == '0');
                    SetButtonActive(AMP1B, resp[3] == '1');
                    SetButtonActive(AMP2B, resp[3] == '2');
                }
            }
            else if (resp.StartsWith("RA") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    SetButtonActive(ATT0B, resp[3] == '0');
                    SetButtonActive(ATT6B, resp[3] == '1');
                    SetButtonActive(ATT12B, resp[3] == '2');
                    SetButtonActive(ATT18B, resp[3] == '3');
                }
            }
            else if (resp.StartsWith("NR") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    nrOn = resp[3] == '1';
                    SetButtonActive(DNRB, nrOn);
                }
            }
            else if (resp.StartsWith("BC") && resp.Length >= 4 && (resp[2] == '0' || resp[2] == '1'))
            {
                if ((resp[2] == '0') == mainFocused)
                {
                    dnfOn = resp[3] == '1';
                    SetButtonActive(DNFB, dnfOn);
                }
            }
            else if (resp.StartsWith("FR") && resp.Length >= 4)
            {
                rx1Active = resp == "FR00" || resp == "FR01";
                rx2Active = resp == "FR00" || resp == "FR10";
                SetButtonActive(RX1B, rx1Active);
                SetButtonActive(RX2B, rx2Active);
            }
            else if (resp.StartsWith("RG0") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(rfGainTrackBar, textBox1,
                        rfGainTrackBar.Maximum - v, ToDisplay(rfGainTrackBar.Maximum - v));
            }
            else if (resp.StartsWith("AG0") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(volumeGainTrackBar, textBox2, v, ToDisplay(v));
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
                        SubrfGainTrackBar.Maximum - v, ToDisplay(SubrfGainTrackBar.Maximum - v));
            }
            else if (resp.StartsWith("AG1") && resp.Length >= 6)
            {
                if (int.TryParse(resp.Substring(3, 3), out int v))
                    SafeUpdateSlider(SubvolumeGainTrackBar, textBox6, v, ToDisplay(v));
            }
            else if (resp.StartsWith("FA") && resp.Length >= 4)
            {
                string freqStr = resp.Substring(2, resp.Length - 3); // FTDX101D-specific offset
                if (long.TryParse(freqStr, out long freqHz))
                {
                    long hz = freqHz * 10;
                    if (hz == mainFreqHz) return;
                    mainFreqHz = hz;
                    UpdateTextBox(FreqM_box, $"{mainFreqHz / 1000000,2}.{mainFreqHz / 1000 % 1000:000}.{mainFreqHz % 1000:000}");
                    if (mainFocused) BANDB.Text = GetBandName(mainFreqHz);
                }
            }
            else if (resp.StartsWith("FB") && resp.Length >= 4)
            {
                string freqStr = resp.Substring(2, resp.Length - 3); // FTDX101D-specific offset
                if (long.TryParse(freqStr, out long freqHz))
                {
                    long hz = freqHz * 10;
                    if (hz == subFreqHz) return;
                    subFreqHz = hz;
                    UpdateTextBox(FreqS_box, $"{subFreqHz / 1000000,2}.{subFreqHz / 1000 % 1000:000}.{subFreqHz % 1000:000}");
                    if (!mainFocused) BANDB.Text = GetBandName(subFreqHz);
                }
            }
            else if (resp.StartsWith("AC") && resp.Length >= 5)
            {
                bool on = resp[4] == '1';
                iTuneOn = on;
                SetButtonActive(ItuneOn, on);
                SetButtonActive(ItuneOff, !on);
            }
            else if (resp.StartsWith("VS") && resp.Length >= 3)
            {
                SetReceiverFocus(resp[2] == '0');
            }
        }

        #endregion

        // =================================================================
        #region UI Helpers

        private void StoreDesignLayout()
        {
            _designBounds = new Dictionary<Control, RectangleF>();
            _designFonts  = new Dictionary<Control, Font>();
            foreach (Control c in Controls)
            {
                _designBounds[c] = new RectangleF(c.Left, c.Top, c.Width, c.Height);
                _designFonts[c]  = c.Font;
            }
        }

        // ---- Aspect-ratio lock during resize ----
        private const int WM_SIZING      = 0x0214;
        private const int WMSZ_LEFT      = 1, WMSZ_RIGHT  = 2, WMSZ_TOP    = 3;
        private const int WMSZ_TOPLEFT   = 4, WMSZ_TOPRIGHT = 5;
        private const int WMSZ_BOTTOM    = 6, WMSZ_BOTTOMLEFT = 7, WMSZ_BOTTOMRIGHT = 8;

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct RECT { public int Left, Top, Right, Bottom; }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SIZING && _aspectRatio > 0)
            {
                var rc = (RECT)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(RECT))!;
                int w    = rc.Right  - rc.Left;
                int h    = rc.Bottom - rc.Top;
                int edge = m.WParam.ToInt32();

                bool heightDriven = edge == WMSZ_TOP || edge == WMSZ_BOTTOM;
                if (heightDriven)
                    w = (int)Math.Round(h * _aspectRatio);
                else
                    h = (int)Math.Round(w / _aspectRatio);

                switch (edge)
                {
                    case WMSZ_RIGHT:
                    case WMSZ_BOTTOM:
                    case WMSZ_BOTTOMRIGHT: rc.Right = rc.Left + w; rc.Bottom = rc.Top  + h; break;
                    case WMSZ_LEFT:        rc.Left  = rc.Right - w; rc.Bottom = rc.Top  + h; break;
                    case WMSZ_TOP:         rc.Right = rc.Left  + w; rc.Top    = rc.Bottom - h; break;
                    case WMSZ_TOPLEFT:     rc.Left  = rc.Right - w; rc.Top    = rc.Bottom - h; break;
                    case WMSZ_TOPRIGHT:    rc.Right = rc.Left  + w; rc.Top    = rc.Bottom - h; break;
                    case WMSZ_BOTTOMLEFT:  rc.Left  = rc.Right - w; rc.Bottom = rc.Top   + h; break;
                }

                System.Runtime.InteropServices.Marshal.StructureToPtr(rc, m.LParam, false);
            }
            base.WndProc(ref m);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_designBounds == null || ClientSize.Width == 0 || ClientSize.Height == 0) return;

            float sx = ClientSize.Width  / _designClient.Width;
            float sy = ClientSize.Height / _designClient.Height;
            float sf = Math.Min(sx, sy);

            SuspendLayout();
            foreach (Control c in Controls)
            {
                if (!_designBounds.TryGetValue(c, out RectangleF orig)) continue;

                c.Bounds = Rectangle.Round(new RectangleF(
                    orig.X * sx, orig.Y * sy,
                    orig.Width * sx, orig.Height * sy));

                if (_designFonts.TryGetValue(c, out Font df))
                {
                    float newSize = Math.Max(1f, df.Size * sf);
                    if (Math.Abs(c.Font.Size - newSize) > 0.05f)
                    {
                        _scaledFonts.TryGetValue(c, out Font old);
                        Font scaled = new Font(df.FontFamily, newSize, df.Style, df.Unit);
                        _scaledFonts[c] = scaled;
                        c.Font = scaled;
                        old?.Dispose();
                    }
                }
            }
            ResumeLayout(false);
        }

        private void SetButtonActive(Button btn, bool active)
        {
            Color inactiveColor = btn == RX1B ? Color.Silver
                                : btn == RX2B ? Color.DarkBlue
                                : Color.DarkGreen;
            Color inactiveFore = btn == RX1B ? Color.DarkBlue
                                : btn == RX2B ? Color.Silver
                                : Color.Yellow;
            Color target = active ? Color.DarkRed : inactiveColor;
            Color targetFore = active ? Color.Yellow : inactiveFore;
            if (btn.BackColor == target) return;
            btn.BackColor = target;
            btn.ForeColor = targetFore;
        }

        private void UpdateTextBox(Control tb, string text, Color? foreColor = null)
        {
            if (tb.Text != text) tb.Text = text;
            if (foreColor.HasValue && tb.ForeColor != foreColor.Value) tb.ForeColor = foreColor.Value;
        }

        /// <summary>Update a slider + display textbox from the radio — guards against feedback loops.</summary>
        private void SafeUpdateSlider(CustomTrackBar tb, TextBox display, int value, string displayStr)
        {
            int clamped = Math.Clamp(value, tb.Minimum, tb.Maximum);
            if (tb.Value != clamped)
            {
                isUpdatingFromRadio = true;
                tb.Value = clamped;
                isUpdatingFromRadio = false;
            }
            if (display != null && display.Text != displayStr) display.Text = displayStr;
        }

        #endregion

        // =================================================================
        #region Event Wiring — InitializeTrackBarEvents

        private void InitializeTrackBarEvents()
        {
            // Sliders
            rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;
            pwrControlTrackBar.ValueChanged += PwrControlTrackBar_ValueChanged;
            SubrfGainTrackBar.ValueChanged += SubrfGainTrackBar_ValueChanged;
            SubvolumeGainTrackBar.ValueChanged += SubvolumeGainTrackBar_ValueChanged;

            // Frequency buttons (custom paint for reliable rendering)
            FreqM_box.Paint += FreqButton_Paint;
            FreqS_box.Paint += FreqButton_Paint;

            // External tuner button
            ExtTuneButton.MouseDown += TuneButton_MouseDown;
            ExtTuneButton.MouseUp += TuneButton_MouseUp;
            ExtTuneButton.MouseEnter += TuneButton_MouseEnter;
            ExtTuneButton.MouseLeave += TuneButton_MouseLeave;

            // Poll timer
            pollTimer.Tick += PollTimer_Tick;

            // COM port controls
            ConnectToggleButton.Click += ConnectToggleButton_Click;
            comPortComboBox.DrawItem += ComboBox_DrawItem;

            // Step size selector
            StepComboBox.Items.AddRange(new object[] { "100 Hz", "500 Hz", "1 kHz", "5 kHz", "9 kHz", "20 kHz", "50 kHz" });
            int stepIdx = StepComboBox.Items.IndexOf(Properties.Settings.Default.StepMain);
            StepComboBox.SelectedIndex = stepIdx >= 0 ? stepIdx : 1;
            StepComboBox.DrawItem += ComboBox_DrawItem;
            StepComboBox.SelectedIndexChanged += StepComboBox_SelectedIndexChanged;
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var cb = (ComboBox)sender;
            bool sel = (e.State & DrawItemState.Selected) != 0;
            using var bg = new SolidBrush(sel ? Color.Green : Color.DarkGreen);
            e.Graphics.FillRectangle(bg, e.Bounds);
            using var fg = new SolidBrush(cb.ForeColor);
            e.Graphics.DrawString(cb.Items[e.Index].ToString(), e.Font, fg, e.Bounds);
        }

        private void StepComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressStepSave) return;
            string step = StepComboBox.SelectedItem?.ToString() ?? "500 Hz";
            if (mainFocused) Properties.Settings.Default.StepMain = step;
            else Properties.Settings.Default.StepSub = step;
            Properties.Settings.Default.Save();
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

        private void QueueSliderCommand(CustomTrackBar tb, string cmd)
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
            UpdateTextBox(textBox1, ToDisplay(val));
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
            UpdateTextBox(textBox5, ToDisplay(val));
            QueueSliderCommand(SubrfGainTrackBar, $"RG1{(SubrfGainTrackBar.Maximum - val):D3};");
        }

        private void SubvolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int rawVal = SubvolumeGainTrackBar.Value;
            UpdateTextBox(textBox6, ToDisplay(rawVal));
            QueueSliderCommand(SubvolumeGainTrackBar, $"AG1{rawVal:D3};");
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

        private void Center_Click(object sender, MouseEventArgs e) { int v = mainFocused ? 0 : 1; SendCommand($"SS{v}650000;"); }
        private void Cursor_Click(object sender, MouseEventArgs e) { int v = mainFocused ? 0 : 1; SendCommand($"SS{v}650000;"); SendCommand($"SS{v}680000;"); }
        private void Fix_Click(object sender, MouseEventArgs e) { int v = mainFocused ? 0 : 1; SendCommand($"SS{v}650000;"); SendCommand($"SS{v}6B0000;"); }
        private void USB_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}2;"); }
        private void LSB_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}1;"); }
        private void CW_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}3;"); }
        private void FM_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}4;"); }
        private void AM_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}5;"); }
        private void DIG_click(object sender, MouseEventArgs e) { SendCommand($"MD{(mainFocused ? 0 : 1)}C;"); }
        private void ANT1B_click(object sender, MouseEventArgs e) { SendCommand($"AN{(mainFocused ? 0 : 1)}1;"); }
        private void ANT2B_click(object sender, MouseEventArgs e) { SendCommand($"AN{(mainFocused ? 0 : 1)}2;"); }
        private void ANT3RXB_click(object sender, MouseEventArgs e) { SendCommand($"AN{(mainFocused ? 0 : 1)}3;"); }
        private void IPOB_click(object sender, MouseEventArgs e) { SendCommand($"PA{(mainFocused ? 0 : 1)}0;"); }
        private void AMP1B_click(object sender, MouseEventArgs e) { SendCommand($"PA{(mainFocused ? 0 : 1)}1;"); }
        private void AMP2B_click(object sender, MouseEventArgs e) { SendCommand($"PA{(mainFocused ? 0 : 1)}2;"); }
        private void ATT0B_click(object sender, MouseEventArgs e) { SendCommand($"RA{(mainFocused ? 0 : 1)}0;"); }
        private void ATT6B_click(object sender, MouseEventArgs e) { SendCommand($"RA{(mainFocused ? 0 : 1)}1;"); }
        private void ATT12B_click(object sender, MouseEventArgs e) { SendCommand($"RA{(mainFocused ? 0 : 1)}2;"); }
        private void ATT18B_click(object sender, MouseEventArgs e) { SendCommand($"RA{(mainFocused ? 0 : 1)}3;"); }
        private void DNRB_click(object sender, MouseEventArgs e) { SendCommand($"NR{(mainFocused ? 0 : 1)}{(nrOn ? 0 : 1)};"); }
        private void DNFB_click(object sender, MouseEventArgs e) { SendCommand($"BC{(mainFocused ? 0 : 1)}{(dnfOn ? 0 : 1)};"); }
        private void BANDB_MouseDown(object sender, MouseEventArgs e)
        {
            int x = mainFocused ? 0 : 1;
            if (e.Button == MouseButtons.Left) SendCommand($"BU{x};");
            if (e.Button == MouseButtons.Right) SendCommand($"BD{x};");
        }
        private void PLUSB_Click(object sender, EventArgs e)
        {
            long newFreq = (mainFocused ? mainFreqHz : subFreqHz) + GetStepHz();
            ApplyFrequencyStep(newFreq);
        }
        private void MINB_Click(object sender, EventArgs e)
        {
            long newFreq = (mainFocused ? mainFreqHz : subFreqHz) - GetStepHz();
            if (newFreq < 0) newFreq = 0;
            ApplyFrequencyStep(newFreq);
        }
        private void ApplyFrequencyStep(long newFreq)
        {
            if (mainFocused)
            {
                mainFreqHz = newFreq;
                UpdateTextBox(FreqM_box, $"{mainFreqHz / 1000000,2}.{mainFreqHz / 1000 % 1000:000}.{mainFreqHz % 1000:000}");
                SendCommand($"FA{newFreq:D9};");
            }
            else
            {
                subFreqHz = newFreq;
                UpdateTextBox(FreqS_box, $"{subFreqHz / 1000000,2}.{subFreqHz / 1000 % 1000:000}.{subFreqHz % 1000:000}");
                SendCommand($"FB{newFreq:D9};");
            }
            BANDB.Text = GetBandName(newFreq);
        }
        private long GetStepHz() => StepComboBox.SelectedItem?.ToString() switch
        {
            "100 Hz" => 100,
            "500 Hz" => 500,
            "1 kHz" => 1_000,
            "5 kHz" => 5_000,
            "9 kHz" => 9_000,
            "20 kHz" => 20_000,
            "50 kHz" => 50_000,
            _ => 100
        };
        private static string GetBandName(long hz) => hz switch
        {
            >= 1_810_000 and < 1_900_000 => "160m",
            >= 3_500_000 and < 3_800_000 => "80m",
            >= 5_350_000 and < 5_367_000 => "60m",
            >= 7_000_000 and < 7_200_000 => "40m",
            >= 10_100_000 and < 10_150_000 => "30m",
            >= 14_000_000 and < 14_350_000 => "20m",
            >= 18_068_000 and < 18_168_000 => "17m",
            >= 21_000_000 and < 21_450_000 => "15m",
            >= 24_890_000 and < 24_990_000 => "12m",
            >= 28_000_000 and < 29_700_000 => "10m",
            >= 50_000_000 and < 52_000_000 => "6m",
            _ => "GEN"
        };
        private void FreqM_box_Click(object sender, EventArgs e) { SendCommand("VS0;"); }
        private void FreqS_box_Click(object sender, EventArgs e) { SendCommand("VS1;"); }
        private void SetReceiverFocus(bool focusMain)
        {
            // Save step for the VFO we're leaving
            string currentStep = StepComboBox.SelectedItem?.ToString() ?? "500 Hz";
            if (mainFocused) Properties.Settings.Default.StepMain = currentStep;
            else Properties.Settings.Default.StepSub = currentStep;

            mainFocused = focusMain;
            FreqM_box.BackColor = focusMain ? Color.Silver : Color.Black;
            FreqM_box.ForeColor = focusMain ? Color.Black : Color.Gold;
            FreqS_box.BackColor = focusMain ? Color.Black : Color.Blue;
            FreqS_box.ForeColor = focusMain ? Color.Gold : Color.White;
            FreqM_box.Invalidate();
            FreqS_box.Invalidate();
            BANDB.Text = GetBandName(focusMain ? mainFreqHz : subFreqHz);
            RebuildPollCommands();

            // Load step for the newly focused VFO
            suppressStepSave = true;
            string newStep = focusMain ? Properties.Settings.Default.StepMain : Properties.Settings.Default.StepSub;
            int idx = StepComboBox.Items.IndexOf(newStep);
            StepComboBox.SelectedIndex = idx >= 0 ? idx : 1;
            suppressStepSave = false;
        }
        private void RX1B_click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            bool newRx1 = !rx1Active;
            SendCommand((newRx1, rx2Active) switch
            {
                (true, true) => "FR00;",
                (true, false) => "FR01;",
                (false, true) => "FR10;",
                _ => "FR11;"
            });
        }
        private void RX2B_click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            bool newRx2 = !rx2Active;
            SendCommand((rx1Active, newRx2) switch
            {
                (true, true) => "FR00;",
                (true, false) => "FR01;",
                (false, true) => "FR10;",
                _ => "FR11;"
            });
        }
        private void RX1B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) ToggleBothMute();
        }
        private void RX2B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) ToggleBothMute();
        }
        private void ToggleBothMute()
        {
            if (!isBothMuted)
            {
                savedMainVol = volumeGainTrackBar.Value;
                savedSubVol = SubvolumeGainTrackBar.Value;
                SendCommand("AG0000;");
                SendCommand("AG1000;");
                isBothMuted = true;
            }
            else
            {
                SendCommand($"AG0{savedMainVol:D3};");
                SendCommand($"AG1{savedSubVol:D3};");
                SafeUpdateSlider(volumeGainTrackBar, textBox2, savedMainVol, savedMainVol.ToString("D3"));
                SafeUpdateSlider(SubvolumeGainTrackBar, textBox6, savedSubVol, savedSubVol.ToString("D3"));
                isBothMuted = false;
            }
        }
        private void SSB1_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}560000;"); }
        private void SSB2_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}570000;"); }
        private void SSB3_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}580000;"); }
        private void SSB4_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}590000;"); }
        private void SSB5_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}540000;"); }
        private void SSB6_click(object sender, EventArgs e) { SendCommand($"SS{(mainFocused ? 0 : 1)}550000;"); }
        private void IntTune_Click(object sender, EventArgs e) { SendCommand("AC001;"); SendCommand("AC002;"); }
        private void ItuneOn_Click(object sender, EventArgs e) { SendCommand("AC001;"); }
        private void ItuneOff_Click(object sender, EventArgs e) { SendCommand("AC000;"); }
        private void SWAP_Click(object sender, EventArgs e) { SendCommand(CMD_SWAP); }
        private void Button1_Click(object sender, EventArgs e) { UpdateTextBox(TEMP_box, " "); }

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

        private void FreqButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = (Button)sender;
            using var bg = new SolidBrush(btn.BackColor);
            e.Graphics.FillRectangle(bg, btn.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle,
                btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }

        private void TuneButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            // Fill background so BackColor is always respected (even when disabled)
            using var bg = new SolidBrush(btn.BackColor);
            e.Graphics.FillRectangle(bg, btn.ClientRectangle);

            // Draw text in yellow, word-wrapped
            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle,
                Color.Yellow,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

            // Symmetric 3px white border — 4 filled rectangles, no gaps
            const int t = 3;
            using var border = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(border, 0, 0, btn.Width, t);                    // top
            e.Graphics.FillRectangle(border, 0, btn.Height - t, btn.Width, t);       // bottom
            e.Graphics.FillRectangle(border, 0, 0, t, btn.Height);                   // left
            e.Graphics.FillRectangle(border, btn.Width - t, 0, t, btn.Height);       // right
        }

        #endregion

        // =================================================================
        #region Form Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool normal = this.WindowState == FormWindowState.Normal;
            Properties.Settings.Default.FormLocation = normal ? this.Location       : this.RestoreBounds.Location;
            Properties.Settings.Default.FormSize     = normal ? this.Size           : this.RestoreBounds.Size;
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

        private void LEVRESET_Click(object sender, EventArgs e)
        {
            levelShift = 0.0;
            SendCommand($"SS{(mainFocused ? 0 : 1)}4{FormatLevel(levelShift)};");
            UpdateTextBox(LEV_box, FormatLevel(levelShift) + " dB", LevColor(levelShift));
        }

        private void LevMIN_Click(object sender, EventArgs e)
        {
            levelShift = Math.Max(-30.0, levelShift - 1.0);
            SendCommand($"SS{(mainFocused ? 0 : 1)}4{FormatLevel(levelShift)};");
            UpdateTextBox(LEV_box, FormatLevel(levelShift) + " dB", LevColor(levelShift));
        }

        private void LevPLUS_Click(object sender, EventArgs e)
        {
            levelShift = Math.Min(+30.0, levelShift + 1.0);
            SendCommand($"SS{(mainFocused ? 0 : 1)}4{FormatLevel(levelShift)};");
            UpdateTextBox(LEV_box, FormatLevel(levelShift) + " dB", LevColor(levelShift));
        }

        private static string FormatLevel(double v) =>
            v.ToString("+00.0;-00.0", System.Globalization.CultureInfo.InvariantCulture);

        private static string ToDisplay(int v) =>
            ((int)Math.Round(v / 255.0 * 100)).ToString("D3");

        private static Color LevColor(double v) =>
            v < 0 ? Color.Red : Color.LimeGreen;

        private void pwrControlTrackBar_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 15-4 (05 feb 26); 
// Name    : The101Box Yaesu FTDX101 @ COM4


namespace The101Box
{
    public partial class MainForm : Form
    {
        public readonly SerialPort Serial_Port;
        public string temp, mode, Pstr, Ptemp, Pwr, PwrD, Rfsql, Dspmod, Dspspan, RfsqlD,
            DspmodD, DspspanD, FColorB, Mode, ModeD, Dspant, DspantD, Dspipo, DspipoD, DspRx, DspRxD, SButton, DScopspan, Bar = "";
        public decimal TempD, tempnum, Rfsqlnum, Dsppodnum, SecondNum;

        private CancellationTokenSource cts = new();
        private bool vcOn = false; // Add toggle state
        private bool rfSqlOn = false; // false for RF, true for Squelch

        public MainForm()
        {
            InitializeComponent();

            // Increase form width to accommodate sliders
            // this.ClientSize = new Size(950, 125);  // Removed: now set in designer to 934

            // Attach event handlers for sliders
            rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;

            // Ensure External Tuner button uses Flat style for color changes
            TuneButton.FlatStyle = FlatStyle.Flat;
            TuneButton.BackColor = Color.DarkGreen; // Set initial background color
            TuneButton.ForeColor = Color.Yellow; // Set text color to yellow
            TuneButton.FlatAppearance.BorderSize = 0; // We'll draw our own border
            TuneButton.FlatAppearance.MouseDownBackColor = Color.Red; // Set mouse down color
            TuneButton.FlatAppearance.MouseOverBackColor = Color.Blue; // Set mouse over color
            TuneButton.FlatAppearance.BorderColor = Color.White; // Set border color
            TuneButton.Paint += TuneButton_Paint;

            // Rechterknop RX1+RX2 uit op 
            RX12B.MouseDown += RX12B_MouseDown;
            VCTOGGLE.MouseClick += VCTOGGLE_click;
            RFTOGGLE.MouseClick += RFB_click;

            Serial_Port = new SerialPort("COM4", 38400, Parity.None, 8, StopBits.Two)
            {
                Handshake = Handshake.None,
                RtsEnable = true,
                ReadTimeout = 5000 
            };

            // Open the serial port on a background thread so UI initialization isn't blocked.
            // Enable UI controls only after the port is opened successfully.
            TuneButton.Enabled = false;

            Task.Run(async () =>
            {
                try
                {
                    Serial_Port.Open();

                    // enable UI controls on the UI thread after port opens
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() =>
                        {
                            TuneButton.Enabled = true;
                            TuneButton.ForeColor = Color.Yellow;
                        }));
                    }

                    // start the main loop after the port is open
                    await DoThisLoopAsync();
                }
                catch (Exception ex)
                {
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() => MessageBox.Show(this, "Failed to open serial port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }
                }
            });
        }

        private async Task DoThisLoopAsync()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    // Discard buffers at the start of each loop to prevent stale data
                    Serial_Port.DiscardInBuffer();
                    Serial_Port.DiscardOutBuffer();

                    IssueCmd("RM9;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 6)
                    {
                        Ptemp = temp.Substring(3, 3);
                        tempnum = Convert.ToDecimal(Ptemp);
                        TempD = Decimal.Floor((tempnum / 2.3M) - 6);
                    }
                    else
                    {
                        TempD = 0;
                    }

                    if (TempD > 40)
                    {
                        FColorB = "Red";
                        Console.Beep(3000, 1000);
                    }
                    else if (TempD > 33)
                    {
                        FColorB = "Orange";
                    }
                    else
                    {
                        FColorB = "Cyan";
                    }

                    IssueCmd("PC;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        Pwr = temp.Substring(2, 3);
                        PwrD = Pwr.TrimStart('0');
                    }
                    else
                    {
                        PwrD = "0";
                    }

                    IssueCmd("EX030107;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 9)
                    {
                        Rfsql = temp.Substring(8, 1);
                        RfsqlD = Rfsql == "0" ? "RF" : "Squelch";
                    }
                    else
                    {
                        RfsqlD = "RF";
                    }

                    // New VC read block: Poll and display VC state (mirrors RFSQL logic)
                    IssueCmd("VT0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 8)  // VT + 5 digits + ;
                    {
                        char statusChar = temp[3];  // Fourth character (index 3) is the status: 0=off, 1=on
                        string vcDisplay = statusChar == '1' ? "VC on" : "VC off";
                        vcOn = statusChar == '1';  // Sync the toggle state variable for consistency
                        UpdateTextBox(VC_box, vcDisplay);
                    }
                    else
                    {
                        UpdateTextBox(VC_box, "VC ???");
                    }

                    IssueCmd("SS06;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        Dspmod = temp.Substring(4, 1);
                        DspmodD = Dspmod switch
                        {
                            "8" => "CURSOR",
                            "5" => "CENTER",
                            _ => "FIX"
                        };
                    }
                    else
                    {
                        DspmodD = "FIX";
                    }

                    IssueCmd("SS05;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        Dspspan = temp.Substring(4, 1);
                        DspspanD = Dspspan switch
                        {
                            "6" => "100k",
                            "7" => "200k",
                            "8" => "500k",
                            _ => "*OTHER*"
                        };
                    }
                    else
                    {
                        DspspanD = "*OTHER*";
                    }

                    IssueCmd("MD0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Mode = temp.Substring(3, 1);
                        ModeD = Mode switch
                        {
                            "1" => "LSB",
                            "2" => "USB",
                            "3" => "CW",
                            _ => "???"
                        };
                    }
                    else
                    {
                        ModeD = "???";
                    }

                    IssueCmd("AN0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Dspant = temp.Substring(3, 1);
                        DspantD = Dspant switch
                        {
                            "1" => "ANT1",
                            "2" => "ANT2",
                            "3" => "ANT3/RX",
                            _ => "???"
                        };
                    }
                    else
                    {
                        DspantD = "???";
                    }

                    IssueCmd("PA0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Dspipo = temp.Substring(3, 1);
                        DspipoD = Dspipo switch
                        {
                            "0" => "IPO",
                            "1" => "AMP1",
                            "2" => "AMP2",
                            _ => "???"
                        };
                    }
                    else
                    {
                        DspipoD = "???";
                    }

                    IssueCmd("FR;");
                    temp = Serial_Port.ReadTo(";");
                    DspRx = temp;
                    DspRxD = DspRx switch
                    {
                        "FR01" => "RX 1",
                        "FR10" => "RX 2",
                        "FR00" => "RX 1 + 2",
                        "FR11" => "RXs off",
                        _ => "???"
                    };

                    // Update UI
                    UpdateTextBox(TEMP_box, $"{TempD:00}°C", Color.FromName(FColorB));
                    UpdateTextBox(RFSQL_box, RfsqlD);
                    UpdateTextBox(PWR_box, PwrD);
                    UpdateTextBox(DSPMOD_box, DspmodD);
                    UpdateTextBox(DSPSPAN_box, DspspanD);
                    UpdateTextBox(MODE_box, ModeD);
                    UpdateTextBox(ANT_box, DspantD);
                    UpdateTextBox(IPO_box, DspipoD);
                    UpdateTextBox(RX_box, DspRxD);

                    //--- Example of building a bar graph for RF gain (not currently used in UI)       leave it !            
                    //                  string Blokje = "■";
                    //                  Bar = Bar.Length < 7 ? Bar + Blokje : Blokje;
                    //                  UpdateTextBox(VC_box, Bar);

                    // Sync sliders with radio values
                    // Detach event handlers to prevent sending commands when setting values
                    rfGainTrackBar.ValueChanged -= RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged -= VolumeGainTrackBar_ValueChanged;

                    // Read and set RF gain slider (inverted)
                    IssueCmd("RG0;");
                    temp = Serial_Port.ReadTo(";");

                    // Read and set volume slider
                    IssueCmd("AG0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string agValueStr = temp.Substring(3, 3);
                        if (int.TryParse(agValueStr, out int agValue))
                        {
                            volumeGainTrackBar.Value = Math.Max(volumeGainTrackBar.Minimum, Math.Min(volumeGainTrackBar.Maximum, agValue));
                        }
                    }

                    // Reattach event handlers
                    rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;

                    IssueCmd("FA;");
                    temp = Serial_Port.ReadTo(";");
                    string mainFreq = "???";
                    if (temp.Length >= 4) // FA + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FA and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Divide by 1,000,000 for MHz
                            mainFreq = freqMHz.ToString("F3"); // Format to 3 decimal places
                        }
                    }

                    IssueCmd("FB;");
                    temp = Serial_Port.ReadTo(";");
                    string subFreq = "???";
                    if (temp.Length >= 4) // FB + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FB and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Divide by 1,000,000 for MHz
                            subFreq = freqMHz.ToString("F3"); // Format to 3 decimal places
                        }
                    }

                    UpdateTextBox(FreqM_box, $"M: {mainFreq} MHz");
                    UpdateTextBox(FreqS_box, $"S: {subFreq} MHz");

                    await Task.Delay(100, cts.Token);
                }
                catch (Exception ex)
                {
                    string errorMsg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Loop error: {ex.Message}";
                    try
                    {
                        File.AppendAllText(logFilePath, errorMsg + Environment.NewLine);
                    }
                    catch
                    {
                        // If logging fails, silently ignore to avoid cascading errors
                    }
                    await Task.Delay(100, cts.Token); // Reduced delay on error to retry faster
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateTextBox(TEMP_box, " ");
        }

        private void UpdateTextBox(TextBox tb, string text, Color? foreColor = null)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(() => UpdateTextBox(tb, text, foreColor));
            }
            else
            {
                tb.Text = text;
                if (foreColor.HasValue) tb.ForeColor = foreColor.Value;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }

        private void IssueCmd(string cmd)
        {
            Serial_Port.Write(cmd);
            Thread.Sleep(6); // Increased to 60 ms to match other working programs' timing
        }

        private void RFB_click(object sender, MouseEventArgs e)
        {
            rfSqlOn = !rfSqlOn;
            if (rfSqlOn)
            {
                IssueCmd("EX0301071;"); // Squelch
                RFSQL_box.Text = "Squelch";
            }
            else
            {
                IssueCmd("EX0301070;"); // RF
                RFSQL_box.Text = "RF";
            }
        }
        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            IssueCmd("MD0;");
            mode = Serial_Port.ReadTo(";");
            IssueCmd("PC;");
            string resp = Serial_Port.ReadTo(";");
            Pstr = resp[2..];
            IssueCmd("PC010;");
            IssueCmd("MD05;");
            IssueCmd("MX1;");
        }
        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            IssueCmd("MX0;");
            string cmd = mode + ";";
            IssueCmd(cmd);
            cmd = "PC" + Pstr + ";";
            IssueCmd(cmd);
        }
        private void Center_Click(object sender, MouseEventArgs e) { IssueCmd("SS0650000;"); }
        private void Cursor_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");
            IssueCmd("SS0680000;");
        }
        private void Fix_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");
            IssueCmd("SS06B0000;");
        }
        private void USB_click(object sender, MouseEventArgs e) { IssueCmd("MD02;"); }
        private void LSB_click(object sender, MouseEventArgs e) { IssueCmd("MD01;"); }
        private void CW_click(object sender, MouseEventArgs e) { IssueCmd("MD03;"); }
        private void P5WB_click(object sender, MouseEventArgs e) { IssueCmd("PC005;"); }
        private void P50W_click(object sender, MouseEventArgs e) { IssueCmd("PC050;"); }
        private void P100W_click(object sender, MouseEventArgs e) { IssueCmd("PC100;"); }
        private void ANT1B_click(object sender, MouseEventArgs e) { IssueCmd("AN01;"); }
        private void ANT2B_click(object sender, MouseEventArgs e) { IssueCmd("AN02;"); }
        private void ANT3RXB_click(object sender, MouseEventArgs e) { IssueCmd("AN03;"); }
        private void IPOB_click(object sender, MouseEventArgs e) { IssueCmd("PA00;"); }
        private void AMP1B_click(object sender, MouseEventArgs e) { IssueCmd("PA01;"); }
        private void AMP2B_click(object sender, MouseEventArgs e) { IssueCmd("PA02;"); }
        private void RX1B_click(object sender, MouseEventArgs e) { IssueCmd("FR01;"); }
        private void RX2B_click(object sender, MouseEventArgs e) { IssueCmd("FR10;"); }
        private void RX12B_click(object sender, MouseEventArgs e) { IssueCmd("FR00;"); }
        private void RX12B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) IssueCmd("FR11;");
        }
        private void SSB1_click(object sender, MouseEventArgs e) { IssueCmd("SS0560000;"); }
        private void SSB2_click(object sender, MouseEventArgs e) { IssueCmd("SS0570000;"); }
        private void SSB3_click(object sender, MouseEventArgs e) { IssueCmd("SS0580000;"); }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void RX_box_TextChanged(object sender, EventArgs e) { }
        private void FixB_Click(object sender, EventArgs e) { }

        // --- External Tuner color change handlers ---
        private void TuneButton_MouseEnter(object sender, EventArgs e) { TuneButton.BackColor = Color.Blue; }
        private void TuneButton_MouseLeave(object sender, EventArgs e) { TuneButton.BackColor = Color.DarkGreen; }
        private void TuneButton_MouseDown_Color(object sender, MouseEventArgs e) { TuneButton.BackColor = Color.Red; }
        private void TuneButton_MouseUp_Color(object sender, MouseEventArgs e)
        {
            if (TuneButton.ClientRectangle.Contains(TuneButton.PointToClient(Cursor.Position)))
                TuneButton.BackColor = Color.Blue;
            else
                TuneButton.BackColor = Color.DarkGreen;
        }
        private void TuneButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = sender as System.Windows.Forms.Button;
            if (btn == null) return;
            int thickness = 3;
            using (var pen = new Pen(Color.White, thickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, btn.Width - thickness, btn.Height - thickness));
            }
        }

        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int invertedValue = rfGainTrackBar.Maximum - rfGainTrackBar.Value;
            string value = invertedValue.ToString("D3");
            IssueCmd($"RG0{value};");
        }

        private void VolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            string value = ((TrackBar)sender).Value.ToString("D3");
            IssueCmd($"AG0{value};");
        }

        private void VCTOGGLE_click(object sender, MouseEventArgs e)
        {
            vcOn = !vcOn;
            if (vcOn)
            {
                IssueCmd("VT01;"); // VC on (main receiver)
                VC_box.Text = "VC on";
            }
            else
            {
                IssueCmd("VT00;"); // VC off (main receiver)
                VC_box.Text = "VC off";
            }
        }
    }
}
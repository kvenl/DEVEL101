using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;



// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 12-8 (05 feb 26); 
// Name    : The101Box Yaesu FTDX101 @ COM8
 

namespace The101Box

{
    public partial class MainForm : Form
    {
        public readonly SerialPort Serial_Port;
        public string temp, mode, Pstr, Ptemp, Pwr, PwrD, Rfsql, Dspmod, Dspspan, RfsqlD,
            DspmodD, DspspanD, FColorB, Mode, ModeD, Dspant, DspantD, Dspipo, DspipoD, DspRx, DspRxD, SButton, DScopspan, Bar = "";
        public decimal TempD, tempnum, Rfsqlnum, Dsppodnum, SecondNum;


        public MainForm()
        {
            InitializeComponent();

            // Ensure External Tuner button uses Flat style for color changes
            TuneButton.FlatStyle = FlatStyle.Flat;
            TuneButton.FlatAppearance.BorderSize = 0; // We'll draw our own border
            TuneButton.Paint += TuneButton_Paint;

            // Attach color-changing event handlers
            TuneButton.MouseEnter += TuneButton_MouseEnter;
            TuneButton.MouseLeave += TuneButton_MouseLeave;
            TuneButton.MouseDown += TuneButton_MouseDown_Color;
            TuneButton.MouseUp += TuneButton_MouseUp_Color;

            // Rechterknop RX1+RX2 uit op 
            RX12B.MouseDown += RX12B_MouseDown;

            Serial_Port = new SerialPort("COM8", 38400, Parity.None, 8, StopBits.Two)
            {
                Handshake = Handshake.None,
                RtsEnable = true,
                ReadTimeout = 5000
            };

            // Open the serial port on a background thread so UI initialization isn't blocked.
            // Enable UI controls only after the port is opened successfully.
            StartButton.Enabled = false;
            TuneButton.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    Serial_Port.Open();

                    // start the main loop after the port is open
                    SButton = "Loop";
                    Task.Run((Action)DoThisLoop);

                    // enable UI controls on the UI thread
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() =>
                        {
                            StartButton.Enabled = true;
                            TuneButton.Enabled = true;
                        }));
                    }
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


        private void DoThisLoop()                                       // loop na drukken start button
        {
            while (SButton != null)
            {

                IssueCmd("RM9;");                                       // Read temp

                temp = Serial_Port.ReadTo(";");                         // save return string van comport
                Ptemp = temp.Substring(3, 3);                           // haal vanaf 4e getal eruit (3 lang)

                tempnum = Convert.ToDecimal(Ptemp);                     // van string naar numeriek
                TempD = Decimal.Floor((tempnum / 2.3M) - 6);             // uitgelezen waarde naar graden celcius


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


                IssueCmd("PC;");                               // lees power PWR
                temp = Serial_Port.ReadTo(";");
                Pwr = temp.Substring(2, 3);
                PwrD = Pwr.TrimStart('0');


                IssueCmd("EX030107;");                         // lees stand RF/SQL 
                temp = Serial_Port.ReadTo(";");
                Rfsql = temp.Substring(8, 1);

                if (Rfsql == "0")
                {
                    RfsqlD = "RF";
                }
                else
                {
                    RfsqlD = "Squelch";
                }



                IssueCmd("SS06;");                               // lees Display mode
                temp = Serial_Port.ReadTo(";");
                Dspmod = temp.Substring(4, 1);

                if (Dspmod == "8")
                {
                    DspmodD = "CURSOR";
                }
                else if (Dspmod == "5")
                {
                    DspmodD = "CENTER";
                }
                else
                {
                    DspmodD = "FIX";
                }

                IssueCmd("SS05;");                               // lees spectrum span
                temp = Serial_Port.ReadTo(";");
                Dspspan = temp.Substring(4, 1);

                if (Dspspan == "6")
                {
                    DspspanD = "100k";
                }
                else if (Dspspan == "7")
                {
                    DspspanD = "200k";
                }
                else if (Dspspan == "8")
                {
                    DspspanD = "500k";
                }
                else
                {
                    DspspanD = "*OTHER*";
                }



                IssueCmd("MD0;");                               // lees mode (usb, lsb, cw, ....)
                temp = Serial_Port.ReadTo(";");
                Mode = temp.Substring(3, 1);

                if (Mode == "1")
                {
                    ModeD = "LSB";
                }
                else if (Mode == "2") { ModeD = "USB"; }
                else if (Mode == "3") { ModeD = "CW"; }
                else { ModeD = "???"; }

                IssueCmd("AN0;");
                temp = Serial_Port.ReadTo(";");
                Dspant = temp.Substring(3, 1);
                if (Dspant == "1")
                {
                    DspantD = "ANT1";
                }
                else if (Dspant == "2") { DspantD = "ANT2"; }
                else if (Dspant == "3") { DspantD = "ANT3/RX"; }
                else { DspantD = "???"; }

                IssueCmd("PA0;");
                temp = Serial_Port.ReadTo(";");
                Dspipo = temp.Substring(3, 1);
                if (Dspipo == "0")
                {
                    DspipoD = "IPO";
                }
                else if (Dspipo == "1") { DspipoD = "AMP1"; }
                else if (Dspipo == "2") { DspipoD = "AMP2"; }
                else { DspipoD = "???"; }

                IssueCmd("FR;");                         // lees RXs status 
                temp = Serial_Port.ReadTo(";");
                DspRx = temp;

                if (DspRx == "FR01")
                {
                    DspRxD = "RX 1";
                }
                else if (DspRx == "FR10") { DspRxD = "RX 2"; }
                else if (DspRx == "FR00") { DspRxD = "RX 1 + 2"; }
                else if (DspRx == "FR11") { DspRxD = "RXs OFF"; }
                else { DspRxD = "???"; }


                //               Tijdstip = DateTime.Now.ToString("HH:mm:ss"); vervangen door scan line


                // Display gegevens **************************************************************<<<<<<<<<<<<<<<<<<<<

                // TEMP_box 

                WriteTextSafeTEMP(TempD + " °C (" + Ptemp + ")");

                // RFSQL_box
                WriteTextSafeRFSQL(RfsqlD);

                // PWR_box
                WriteTextSafePWR(PwrD);

                // DSPMOD_box
                WriteTextSafeDSPMOD(DspmodD);

                // DSPSPAN_box
                WriteTextSafeDSPSPAN(DspspanD);


                // MODE_box
                WriteTextSafeMODE(ModeD);

                // Antenne box
                WriteTextSafeANT(DspantD);

                // IPO-box
                WriteTextSafeIPO(DspipoD);

                // RX-box
                WriteTextSafeRX(DspRxD);

                // TIJDSTIP_box -> vervangen door bewegende blokjes ofwel scan line  (=programma loopt nog !)
                string Blokje = "■";

                if (Bar.Length < 7)
                { Bar += Blokje; }
                else
                { Bar = Blokje; }

                WriteTextSafeTIJDSTIP(Bar);


                Thread.Sleep(100); // wait 0.1 sec
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            var threadParameters = new System.Threading.ThreadStart(delegate { WriteTextSafeTEMP(" "); });
            var thread2 = new System.Threading.Thread(threadParameters);
            thread2.Start();
        }



        // Functie Result veld -> temperatuur
        public void WriteTextSafeTEMP(string text)
        {
            if (TEMP_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteTEMP = delegate { WriteTextSafeTEMP($"{text}"); };
                TEMP_box.Invoke(safeWriteTEMP);

            }
            else
                TEMP_box.Text = text;
            TEMP_box.BackColor = TEMP_box.BackColor;
            TEMP_box.ForeColor = Color.FromName(FColorB);
        }

        //=================================================================================//

        // Display RF/SQL
        public void WriteTextSafeRFSQL(string text)
        {
            if (RFSQL_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteRFSQL = delegate { WriteTextSafeRFSQL($"{text}"); };
                RFSQL_box.Invoke(safeWriteRFSQL);
            }
            else
                RFSQL_box.Text = text;
        }

        //=================================================================================//

        // Display PWR
        public void WriteTextSafePWR(string text)
        {
            if (PWR_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWritePWR = delegate { WriteTextSafePWR($"{text}"); };
                PWR_box.Invoke(safeWritePWR);
            }
            else
                PWR_box.Text = text;
        }

        //=================================================================================//

        // Display DSPMOD = display mode van de display -> cursor, center of fix
        public void WriteTextSafeDSPMOD(string text)
        {
            if (DSPMOD_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteDSPMOD = delegate { WriteTextSafeDSPMOD($"{text}"); };
                DSPMOD_box.Invoke(safeWriteDSPMOD);
            }
            else
                DSPMOD_box.Text = text;
        }
        //=================================================================================//

        // Display DSPSPAN = SCOPE SPAN
        public void WriteTextSafeDSPSPAN(string text)
        {
            if (DSPSPAN_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteDSPSPAN = delegate { WriteTextSafeDSPSPAN($"{text}"); };
                DSPSPAN_box.Invoke(safeWriteDSPSPAN);
            }
            else
                DSPSPAN_box.Text = text;
        }


        //=================================================================================//

        // Display MODE
        public void WriteTextSafeMODE(string text)
        {
            if (MODE_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteMODE = delegate { WriteTextSafeMODE($"{text}"); };
                MODE_box.Invoke(safeWriteMODE);
            }
            else
                MODE_box.Text = text;
        }

        //=================================================================================//

        // Display ANT
        public void WriteTextSafeANT(string text)
        {
            if (ANT_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteANT = delegate { WriteTextSafeANT($"{text}"); };
                ANT_box.Invoke(safeWriteANT);
            }
            else
                ANT_box.Text = text;
        }

        //=================================================================================//

        // Display IPO
        public void WriteTextSafeIPO(string text)
        {
            if (IPO_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteIPO = delegate { WriteTextSafeIPO($"{text}"); };
                IPO_box.Invoke(safeWriteIPO);
            }
            else
                IPO_box.Text = text;
        }
        //=================================================================================//

        // Display RXs
        public void WriteTextSafeRX(string text)
        {
            if (RX_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteRX = delegate { WriteTextSafeRX($"{text}"); };
                RX_box.Invoke(safeWriteRX);
            }
            else
                RX_box.Text = text;
        }

        //=================================================================================//

        // Display TIJDSTIP
        public void WriteTextSafeTIJDSTIP(string text)
        {
            if (TIJDSTIP_box.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWriteTIJDSTIP = delegate { WriteTextSafeTIJDSTIP($"{text}"); };
                TIJDSTIP_box.Invoke(safeWriteTIJDSTIP);
            }
            else
                TIJDSTIP_box.Text = text;
        }

        //=================================================================================//




        private void StartButton_Click(object sender, MouseEventArgs e)
        {

            SButton = "Loop";
            Task.Run((Action)DoThisLoop);

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void IssueCmd(string cmd)
        {
            //          Serial_Port.DiscardInBuffer();
            //          Serial_Port.DiscardOutBuffer();
            //          temp = "";
            Serial_Port.Write(cmd);
            Thread.Sleep(60);
        }
        private void VN_on(object sender, MouseEventArgs e)
        {
            IssueCmd("VT0100;");                 //VC ON
        }

        private void VC_off(object sender, MouseEventArgs e)
        {
            IssueCmd("VT0000;");                // VC off
        }
        private void RF_click(object sender, MouseEventArgs e)
        {
            IssueCmd("EX0301070;");             // RF knop is RF
        }

        private void SQL_click(object sender, MouseEventArgs e)
        {
            IssueCmd("EX0301071;");             // RF knop is SQL
        }
        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            IssueCmd("MD0;");                   // read mode

            mode = Serial_Port.ReadTo(";");     // save mode
                                                //          Console.Out.WriteLine(mode);

            IssueCmd("PC;");                    // read power
            string resp;
            resp = Serial_Port.ReadTo(";");
            Pstr = resp[2..];                   // save power

            IssueCmd("PC010;");                 // set power to 10 WATT

            IssueCmd("MD05;");                  // set mode to AM

            IssueCmd("MX1;");                   // set MOX on (=TX)
        }

        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            IssueCmd("MX0;");                   // set MOX off (=TX off, RX)

            string cmd = mode + ";";
            IssueCmd(cmd);                      // set mode @ before tuning

            cmd = "PC" + Pstr + ";";
            IssueCmd(cmd);                      // set power ! before tuning 

        }
        private void Center_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");             // Centreer mode scope
        }

        private void Cursor_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");             // Centreren cursor
            IssueCmd("SS0680000;");             // Cursor mode scope
        }

        private void Fix_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");             // Centreren cursor
            IssueCmd("SS06B0000;");             // Fix mode scope
        }

        private void USB_click(object sender, MouseEventArgs e)
        {
            IssueCmd("MD02;");                  // mode USB
        }

        private void LSB_click(object sender, MouseEventArgs e)
        {
            IssueCmd("MD01;");                  // mode LSB
        }

        private void CW_click(object sender, MouseEventArgs e)
        {
            IssueCmd("MD03;");                  // Mode CW
        }

        private void P5WB_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PC005;");                  // power 5 watt
        }

        private void P50W_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PC050;");                 // power 50 watt
        }

        private void P100W_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PC100;");                  // power 100 watt
        }

        private void ANT1B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("AN01;");                  // antenne 1
        }

        private void ANT2B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("AN02;");                  // antenne 2
        }
        private void ANT3RXB_click(object sender, MouseEventArgs e)
        {
            IssueCmd("AN03;");                  // antenne 3 = RX antenna
        }

        private void IPOB_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PA00;");                  // IPO
        }

        private void AMP1B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PA01;");                  // AMP1
        }

        private void AMP2B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("PA02;");                  // AMP2
        }

        private void RX1B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("FR01;");                  // RX1 on, RX2 off
        }

        private void RX2B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("FR10;");                  // RX1 off, RX2 on
        }

        private void RX12B_click(object sender, MouseEventArgs e)
        {
            IssueCmd("FR00;");                  // RX1 on, RX2 on
        }
        private void RX12B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                IssueCmd("FR11;");              // RX1 and RX2 off (sort of mute)
            }
        }

        private void SSB1_click(object sender, MouseEventArgs e)
        {
  //          IssueCmd("SS0650000;");             // Centreren cursor
            IssueCmd("SS0560000;");                  // 100k span
        }

        private void SSB2_click(object sender, MouseEventArgs e)
        {
 //           IssueCmd("SS0650000;");             // Centreren cursor
            IssueCmd("SS0570000;");                  // 200k span
        }

        private void SSB3_click(object sender, MouseEventArgs e)
        {
 //           IssueCmd("SS0650000;");             // Centreren cursor
            IssueCmd("SS0580000;");                  // 500k span
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void RX_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void FixB_Click(object sender, EventArgs e)
        {

        }

        // --- External Tuner color change handlers ---
        private void TuneButton_MouseEnter(object sender, EventArgs e)
        {
            TuneButton.BackColor = Color.Blue;
        }

        private void TuneButton_MouseLeave(object sender, EventArgs e)
        {
            TuneButton.BackColor = Color.DarkGreen;
        }

        private void TuneButton_MouseDown_Color(object sender, MouseEventArgs e)
        {
            TuneButton.BackColor = Color.Red;
        }

        private void TuneButton_MouseUp_Color(object sender, MouseEventArgs e)
        {
            // Restore hover color if still hovered, else normal
            if (TuneButton.ClientRectangle.Contains(TuneButton.PointToClient(Cursor.Position)))
                TuneButton.BackColor = Color.Blue;
            else
                TuneButton.BackColor = Color.DarkGreen;
        }

        // Custom paint for TuneButton to draw a solid white border
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

       
    }
}


































































































































































































































































































































































































































































































































































































































































































































































































using System.Drawing;

namespace DEVEL101
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TEMP_box = new System.Windows.Forms.TextBox();
            ExtTuneButton = new System.Windows.Forms.Button();
            CursorB = new System.Windows.Forms.Button();
            CenterB = new System.Windows.Forms.Button();
            USBB = new System.Windows.Forms.Button();
            LSBB = new System.Windows.Forms.Button();
            CWB = new System.Windows.Forms.Button();
            RFTOGGLE = new System.Windows.Forms.Button();
            ANT1B = new System.Windows.Forms.Button();
            ANT2B = new System.Windows.Forms.Button();
            ANT3RXB = new System.Windows.Forms.Button();
            IPOB = new System.Windows.Forms.Button();
            AMP1B = new System.Windows.Forms.Button();
            AMP2B = new System.Windows.Forms.Button();
            RX1B = new System.Windows.Forms.Button();
            RX2B = new System.Windows.Forms.Button();
            SSB1 = new System.Windows.Forms.Button();
            SSB2 = new System.Windows.Forms.Button();
            SSB3 = new System.Windows.Forms.Button();
            FixB = new System.Windows.Forms.Button();
            rfGainTrackBar = new CustomTrackBar();
            volumeGainTrackBar = new CustomTrackBar();
            FreqM_box = new System.Windows.Forms.Button();
            FreqS_box = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            pwrControlTrackBar = new CustomTrackBar();
            textBox3 = new System.Windows.Forms.TextBox();
            AMB = new System.Windows.Forms.Button();
            FMB = new System.Windows.Forms.Button();
            DIGB = new System.Windows.Forms.Button();
            SSB4 = new System.Windows.Forms.Button();
            SSB5 = new System.Windows.Forms.Button();
            SSB6 = new System.Windows.Forms.Button();
            IntTune = new System.Windows.Forms.Button();
            ItuneOn = new System.Windows.Forms.Button();
            ItuneOff = new System.Windows.Forms.Button();
            SubrfGainTrackBar = new CustomTrackBar();
            SubvolumeGainTrackBar = new CustomTrackBar();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox6 = new System.Windows.Forms.TextBox();
            SWAP = new System.Windows.Forms.Button();
            rfGainLabel = new System.Windows.Forms.Label();
            volumeGainLabel = new System.Windows.Forms.Label();
            pwrControlLabel = new System.Windows.Forms.Label();
            SubrfGainLabel = new System.Windows.Forms.Label();
            SubvolumeGainLabel = new System.Windows.Forms.Label();
            comPortComboBox = new System.Windows.Forms.ComboBox();
            ConnectToggleButton = new System.Windows.Forms.Button();
            StepComboBox = new System.Windows.Forms.ComboBox();
            BANDB = new System.Windows.Forms.Button();
            MINB = new System.Windows.Forms.Button();
            PLUSB = new System.Windows.Forms.Button();
            LEVRESET = new System.Windows.Forms.Button();
            LevMIN = new System.Windows.Forms.Button();
            LevPLUS = new System.Windows.Forms.Button();
            ATT0B = new System.Windows.Forms.Button();
            ATT6B = new System.Windows.Forms.Button();
            ATT12B = new System.Windows.Forms.Button();
            ATT18B = new System.Windows.Forms.Button();
            DNFB = new System.Windows.Forms.Button();
            DNRB = new System.Windows.Forms.Button();
            LEV_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).BeginInit();
            SuspendLayout();
            // 
            // TEMP_box
            // 
            TEMP_box.BackColor = Color.Black;
            TEMP_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TEMP_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TEMP_box.ForeColor = Color.YellowGreen;
            TEMP_box.Location = new Point(552, 212);
            TEMP_box.Margin = new System.Windows.Forms.Padding(0);
            TEMP_box.Multiline = true;
            TEMP_box.Name = "TEMP_box";
            TEMP_box.Size = new Size(44, 20);
            TEMP_box.TabIndex = 5;
            TEMP_box.TabStop = false;
            TEMP_box.Text = "00°C";
            TEMP_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TEMP_box.WordWrap = false;
            // 
            // ExtTuneButton
            // 
            ExtTuneButton.BackColor = Color.DarkGreen;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.FlatAppearance.BorderSize = 3;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            ExtTuneButton.Font = new Font("Verdana", 8.25F, FontStyle.Bold);
            ExtTuneButton.ForeColor = Color.Yellow;
            ExtTuneButton.Location = new Point(551, 81);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new Size(86, 40);
            ExtTuneButton.TabIndex = 8;
            ExtTuneButton.Text = "External\r\nTuner";
            ExtTuneButton.UseVisualStyleBackColor = false;
            // 
            // CursorB
            // 
            CursorB.BackColor = Color.DarkGreen;
            CursorB.FlatAppearance.BorderColor = Color.White;
            CursorB.FlatAppearance.MouseDownBackColor = Color.Red;
            CursorB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CursorB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CursorB.ForeColor = Color.Yellow;
            CursorB.Location = new Point(373, 121);
            CursorB.Name = "CursorB";
            CursorB.Size = new Size(88, 40);
            CursorB.TabIndex = 9;
            CursorB.Text = "CURSOR";
            CursorB.UseVisualStyleBackColor = false;
            CursorB.MouseClick += Cursor_Click;
            // 
            // CenterB
            // 
            CenterB.BackColor = Color.DarkGreen;
            CenterB.FlatAppearance.BorderColor = Color.White;
            CenterB.FlatAppearance.MouseDownBackColor = Color.Red;
            CenterB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CenterB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CenterB.ForeColor = Color.Yellow;
            CenterB.Location = new Point(373, 161);
            CenterB.Name = "CenterB";
            CenterB.Size = new Size(88, 40);
            CenterB.TabIndex = 10;
            CenterB.Text = "CENTER";
            CenterB.UseVisualStyleBackColor = false;
            CenterB.MouseClick += Center_Click;
            // 
            // USBB
            // 
            USBB.BackColor = Color.DarkGreen;
            USBB.FlatAppearance.BorderColor = Color.White;
            USBB.FlatAppearance.MouseDownBackColor = Color.Red;
            USBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            USBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            USBB.ForeColor = Color.Yellow;
            USBB.Location = new Point(196, 121);
            USBB.Name = "USBB";
            USBB.Size = new Size(44, 40);
            USBB.TabIndex = 11;
            USBB.Text = "USB";
            USBB.UseVisualStyleBackColor = false;
            USBB.MouseClick += USB_click;
            // 
            // LSBB
            // 
            LSBB.BackColor = Color.DarkGreen;
            LSBB.FlatAppearance.BorderColor = Color.White;
            LSBB.FlatAppearance.MouseDownBackColor = Color.Red;
            LSBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            LSBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LSBB.ForeColor = Color.Yellow;
            LSBB.Location = new Point(239, 121);
            LSBB.Name = "LSBB";
            LSBB.Size = new Size(44, 40);
            LSBB.TabIndex = 12;
            LSBB.Text = "LSB";
            LSBB.UseVisualStyleBackColor = false;
            LSBB.MouseClick += LSB_click;
            // 
            // CWB
            // 
            CWB.BackColor = Color.DarkGreen;
            CWB.FlatAppearance.BorderColor = Color.White;
            CWB.FlatAppearance.MouseDownBackColor = Color.Red;
            CWB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CWB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CWB.ForeColor = Color.Yellow;
            CWB.Location = new Point(195, 201);
            CWB.Name = "CWB";
            CWB.Size = new Size(44, 40);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            CWB.MouseClick += CW_click;
            // 
            // RFTOGGLE
            // 
            RFTOGGLE.BackColor = Color.DarkGreen;
            RFTOGGLE.FlatAppearance.BorderColor = Color.White;
            RFTOGGLE.FlatAppearance.MouseDownBackColor = Color.Red;
            RFTOGGLE.FlatAppearance.MouseOverBackColor = Color.Blue;
            RFTOGGLE.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RFTOGGLE.ForeColor = Color.Yellow;
            RFTOGGLE.Location = new Point(284, 122);
            RFTOGGLE.Name = "RFTOGGLE";
            RFTOGGLE.Size = new Size(88, 40);
            RFTOGGLE.TabIndex = 20;
            RFTOGGLE.Text = "RF/SQL\r\nMAIN";
            RFTOGGLE.UseVisualStyleBackColor = false;
            RFTOGGLE.MouseClick += RFB_click;
            // 
            // ANT1B
            // 
            ANT1B.BackColor = Color.DarkGreen;
            ANT1B.FlatAppearance.BorderColor = Color.White;
            ANT1B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT1B.ForeColor = Color.Yellow;
            ANT1B.Location = new Point(284, 1);
            ANT1B.Name = "ANT1B";
            ANT1B.Size = new Size(88, 40);
            ANT1B.TabIndex = 25;
            ANT1B.Text = "ANT1";
            ANT1B.UseVisualStyleBackColor = false;
            ANT1B.MouseClick += ANT1B_click;
            // 
            // ANT2B
            // 
            ANT2B.BackColor = Color.DarkGreen;
            ANT2B.FlatAppearance.BorderColor = Color.White;
            ANT2B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT2B.ForeColor = Color.Yellow;
            ANT2B.Location = new Point(284, 41);
            ANT2B.Name = "ANT2B";
            ANT2B.Size = new Size(88, 40);
            ANT2B.TabIndex = 26;
            ANT2B.Text = "ANT2";
            ANT2B.UseVisualStyleBackColor = false;
            ANT2B.MouseClick += ANT2B_click;
            // 
            // ANT3RXB
            // 
            ANT3RXB.BackColor = Color.DarkGreen;
            ANT3RXB.FlatAppearance.BorderColor = Color.White;
            ANT3RXB.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT3RXB.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT3RXB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT3RXB.ForeColor = Color.Yellow;
            ANT3RXB.Location = new Point(284, 81);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new Size(88, 40);
            ANT3RXB.TabIndex = 27;
            ANT3RXB.Text = "ANT3/RX";
            ANT3RXB.UseVisualStyleBackColor = false;
            ANT3RXB.MouseClick += ANT3RXB_click;
            // 
            // IPOB
            // 
            IPOB.BackColor = Color.DarkGreen;
            IPOB.FlatAppearance.BorderColor = Color.White;
            IPOB.FlatAppearance.MouseDownBackColor = Color.Red;
            IPOB.FlatAppearance.MouseOverBackColor = Color.Blue;
            IPOB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IPOB.ForeColor = Color.Yellow;
            IPOB.Location = new Point(373, 1);
            IPOB.Name = "IPOB";
            IPOB.Size = new Size(88, 40);
            IPOB.TabIndex = 28;
            IPOB.Text = "IPO";
            IPOB.UseVisualStyleBackColor = false;
            IPOB.MouseClick += IPOB_click;
            // 
            // AMP1B
            // 
            AMP1B.BackColor = Color.DarkGreen;
            AMP1B.FlatAppearance.BorderColor = Color.White;
            AMP1B.FlatAppearance.MouseDownBackColor = Color.Red;
            AMP1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMP1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMP1B.ForeColor = Color.Yellow;
            AMP1B.Location = new Point(373, 41);
            AMP1B.Name = "AMP1B";
            AMP1B.Size = new Size(88, 40);
            AMP1B.TabIndex = 29;
            AMP1B.Text = "AMP1";
            AMP1B.UseVisualStyleBackColor = false;
            AMP1B.MouseClick += AMP1B_click;
            // 
            // AMP2B
            // 
            AMP2B.BackColor = Color.DarkGreen;
            AMP2B.FlatAppearance.BorderColor = Color.White;
            AMP2B.FlatAppearance.MouseDownBackColor = Color.Red;
            AMP2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMP2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMP2B.ForeColor = Color.Yellow;
            AMP2B.Location = new Point(373, 81);
            AMP2B.Name = "AMP2B";
            AMP2B.Size = new Size(88, 40);
            AMP2B.TabIndex = 30;
            AMP2B.Text = "AMP2";
            AMP2B.UseVisualStyleBackColor = false;
            AMP2B.MouseClick += AMP2B_click;
            // 
            // RX1B
            // 
            RX1B.BackColor = Color.Silver;
            RX1B.FlatAppearance.BorderColor = Color.White;
            RX1B.FlatAppearance.MouseDownBackColor = Color.Red;
            RX1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX1B.Font = new Font("Verdana", 6.75F, FontStyle.Bold);
            RX1B.ForeColor = Color.DarkBlue;
            RX1B.Location = new Point(284, 161);
            RX1B.Name = "RX1B";
            RX1B.Size = new Size(88, 40);
            RX1B.TabIndex = 33;
            RX1B.Text = "MAIN\r\nRX";
            RX1B.UseVisualStyleBackColor = false;
            RX1B.MouseClick += RX1B_click;
            RX1B.MouseDown += RX1B_MouseDown;
            // 
            // RX2B
            // 
            RX2B.BackColor = Color.DarkBlue;
            RX2B.FlatAppearance.BorderColor = Color.White;
            RX2B.FlatAppearance.MouseDownBackColor = Color.Red;
            RX2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX2B.Font = new Font("Verdana", 6.75F, FontStyle.Bold);
            RX2B.ForeColor = Color.Silver;
            RX2B.Location = new Point(284, 201);
            RX2B.Name = "RX2B";
            RX2B.Size = new Size(87, 40);
            RX2B.TabIndex = 34;
            RX2B.Text = "SUB\r\nRX";
            RX2B.UseVisualStyleBackColor = false;
            RX2B.MouseClick += RX2B_click;
            RX2B.MouseDown += RX2B_MouseDown;
            // 
            // SSB1
            // 
            SSB1.BackColor = Color.DarkGreen;
            SSB1.FlatAppearance.BorderColor = Color.White;
            SSB1.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB1.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB1.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB1.ForeColor = Color.Yellow;
            SSB1.Location = new Point(462, 161);
            SSB1.Name = "SSB1";
            SSB1.Size = new Size(44, 40);
            SSB1.TabIndex = 37;
            SSB1.Text = "100";
            SSB1.UseVisualStyleBackColor = false;
            SSB1.MouseClick += SSB1_click;
            // 
            // SSB2
            // 
            SSB2.BackColor = Color.DarkGreen;
            SSB2.FlatAppearance.BorderColor = Color.White;
            SSB2.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB2.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB2.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB2.ForeColor = Color.Yellow;
            SSB2.Location = new Point(505, 161);
            SSB2.Name = "SSB2";
            SSB2.Size = new Size(44, 40);
            SSB2.TabIndex = 38;
            SSB2.Text = "200";
            SSB2.UseVisualStyleBackColor = false;
            SSB2.MouseClick += SSB2_click;
            // 
            // SSB3
            // 
            SSB3.BackColor = Color.DarkGreen;
            SSB3.FlatAppearance.BorderColor = Color.White;
            SSB3.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB3.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB3.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB3.ForeColor = Color.Yellow;
            SSB3.Location = new Point(462, 201);
            SSB3.Name = "SSB3";
            SSB3.Size = new Size(44, 40);
            SSB3.TabIndex = 39;
            SSB3.Text = "500";
            SSB3.UseVisualStyleBackColor = false;
            SSB3.MouseClick += SSB3_click;
            // 
            // FixB
            // 
            FixB.BackColor = Color.DarkGreen;
            FixB.FlatAppearance.BorderColor = Color.White;
            FixB.FlatAppearance.MouseDownBackColor = Color.Red;
            FixB.FlatAppearance.MouseOverBackColor = Color.Blue;
            FixB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FixB.ForeColor = Color.Yellow;
            FixB.Location = new Point(373, 201);
            FixB.Name = "FixB";
            FixB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            FixB.Size = new Size(88, 40);
            FixB.TabIndex = 41;
            FixB.Text = "FIX";
            FixB.UseVisualStyleBackColor = false;
            FixB.Click += FixB_Click;
            FixB.MouseClick += Fix_Click;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.BackColor = Color.Silver;
            rfGainTrackBar.ChannelColor = Color.Gray;
            rfGainTrackBar.ForeColor = Color.DarkBlue;
            rfGainTrackBar.Location = new Point(1, 121);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            rfGainTrackBar.Size = new Size(45, 105);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickColor = Color.Black;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            rfGainTrackBar.Value = 10;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = Color.Silver;
            volumeGainTrackBar.ChannelColor = Color.Gray;
            volumeGainTrackBar.ForeColor = Color.DarkBlue;
            volumeGainTrackBar.Location = new Point(48, 121);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            volumeGainTrackBar.Size = new Size(45, 105);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickColor = Color.Black;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeGainTrackBar.Value = 10;
            // 
            // FreqM_box
            // 
            FreqM_box.BackColor = Color.Black;
            FreqM_box.FlatAppearance.BorderSize = 0;
            FreqM_box.FlatAppearance.MouseOverBackColor = Color.Silver;
            FreqM_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FreqM_box.Font = new Font("Courier New", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FreqM_box.ForeColor = Color.Gold;
            FreqM_box.Location = new Point(1, 2);
            FreqM_box.Name = "FreqM_box";
            FreqM_box.Size = new Size(189, 54);
            FreqM_box.TabIndex = 44;
            FreqM_box.Text = "MAIN";
            FreqM_box.UseVisualStyleBackColor = false;
            FreqM_box.Click += FreqM_box_Click;
            // 
            // FreqS_box
            // 
            FreqS_box.BackColor = Color.Black;
            FreqS_box.FlatAppearance.BorderSize = 0;
            FreqS_box.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            FreqS_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FreqS_box.Font = new Font("Courier New", 20F, FontStyle.Bold);
            FreqS_box.ForeColor = Color.Gold;
            FreqS_box.Location = new Point(1, 62);
            FreqS_box.Name = "FreqS_box";
            FreqS_box.Size = new Size(189, 46);
            FreqS_box.TabIndex = 45;
            FreqS_box.Text = "SUB";
            FreqS_box.UseVisualStyleBackColor = false;
            FreqS_box.Click += FreqS_box_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Gold;
            textBox1.Location = new Point(1, 227);
            textBox1.Margin = new System.Windows.Forms.Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(45, 16);
            textBox1.TabIndex = 46;
            textBox1.TabStop = false;
            textBox1.Text = "000";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.Gold;
            textBox2.Location = new Point(49, 227);
            textBox2.Margin = new System.Windows.Forms.Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(46, 18);
            textBox2.TabIndex = 47;
            textBox2.TabStop = false;
            textBox2.Text = "000";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox2.WordWrap = false;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // pwrControlTrackBar
            // 
            pwrControlTrackBar.BackColor = Color.Maroon;
            pwrControlTrackBar.ChannelColor = Color.Gray;
            pwrControlTrackBar.ForeColor = Color.Red;
            pwrControlTrackBar.Location = new Point(660, 15);
            pwrControlTrackBar.Maximum = 100;
            pwrControlTrackBar.Minimum = 5;
            pwrControlTrackBar.Name = "pwrControlTrackBar";
            pwrControlTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            pwrControlTrackBar.Size = new Size(45, 120);
            pwrControlTrackBar.TabIndex = 44;
            pwrControlTrackBar.TickColor = Color.White;
            pwrControlTrackBar.TickFrequency = 5;
            pwrControlTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            pwrControlTrackBar.Value = 50;
            pwrControlTrackBar.Click += pwrControlTrackBar_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Black;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.Gold;
            textBox3.Location = new Point(660, 134);
            textBox3.Margin = new System.Windows.Forms.Padding(0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(45, 16);
            textBox3.TabIndex = 45;
            textBox3.TabStop = false;
            textBox3.Text = "000";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox3.WordWrap = false;
            // 
            // AMB
            // 
            AMB.BackColor = Color.DarkGreen;
            AMB.FlatAppearance.BorderColor = Color.White;
            AMB.FlatAppearance.MouseDownBackColor = Color.Red;
            AMB.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMB.ForeColor = Color.Yellow;
            AMB.Location = new Point(195, 161);
            AMB.Name = "AMB";
            AMB.Size = new Size(44, 40);
            AMB.TabIndex = 49;
            AMB.Text = "AM";
            AMB.UseVisualStyleBackColor = false;
            AMB.MouseClick += AM_click;
            // 
            // FMB
            // 
            FMB.BackColor = Color.DarkGreen;
            FMB.FlatAppearance.BorderColor = Color.White;
            FMB.FlatAppearance.MouseDownBackColor = Color.Red;
            FMB.FlatAppearance.MouseOverBackColor = Color.Blue;
            FMB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FMB.ForeColor = Color.Yellow;
            FMB.Location = new Point(239, 161);
            FMB.Name = "FMB";
            FMB.Size = new Size(44, 40);
            FMB.TabIndex = 50;
            FMB.Text = "FM";
            FMB.UseVisualStyleBackColor = false;
            FMB.MouseClick += FM_click;
            // 
            // DIGB
            // 
            DIGB.BackColor = Color.DarkGreen;
            DIGB.FlatAppearance.BorderColor = Color.White;
            DIGB.FlatAppearance.MouseDownBackColor = Color.Red;
            DIGB.FlatAppearance.MouseOverBackColor = Color.Blue;
            DIGB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DIGB.ForeColor = Color.Yellow;
            DIGB.Location = new Point(239, 201);
            DIGB.Name = "DIGB";
            DIGB.Size = new Size(44, 40);
            DIGB.TabIndex = 51;
            DIGB.Text = "DIG";
            DIGB.UseVisualStyleBackColor = false;
            DIGB.MouseClick += DIG_click;
            // 
            // SSB4
            // 
            SSB4.BackColor = Color.DarkGreen;
            SSB4.FlatAppearance.BorderColor = Color.White;
            SSB4.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB4.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB4.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB4.ForeColor = Color.Yellow;
            SSB4.Location = new Point(505, 201);
            SSB4.Name = "SSB4";
            SSB4.Size = new Size(44, 40);
            SSB4.TabIndex = 52;
            SSB4.Text = "1 M";
            SSB4.UseVisualStyleBackColor = false;
            SSB4.MouseClick += SSB4_click;
            // 
            // SSB5
            // 
            SSB5.BackColor = Color.DarkGreen;
            SSB5.FlatAppearance.BorderColor = Color.White;
            SSB5.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB5.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB5.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB5.ForeColor = Color.Yellow;
            SSB5.Location = new Point(462, 121);
            SSB5.Name = "SSB5";
            SSB5.Size = new Size(44, 40);
            SSB5.TabIndex = 53;
            SSB5.Text = "20 k";
            SSB5.UseVisualStyleBackColor = false;
            SSB5.MouseClick += SSB5_click;
            // 
            // SSB6
            // 
            SSB6.BackColor = Color.DarkGreen;
            SSB6.FlatAppearance.BorderColor = Color.White;
            SSB6.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB6.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB6.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB6.ForeColor = Color.Yellow;
            SSB6.Location = new Point(505, 121);
            SSB6.Name = "SSB6";
            SSB6.Size = new Size(44, 40);
            SSB6.TabIndex = 54;
            SSB6.Text = "50 k";
            SSB6.UseVisualStyleBackColor = false;
            SSB6.MouseDown += SSB6_click;
            // 
            // IntTune
            // 
            IntTune.BackColor = Color.DarkGreen;
            IntTune.FlatAppearance.BorderColor = Color.White;
            IntTune.FlatAppearance.MouseDownBackColor = Color.Red;
            IntTune.FlatAppearance.MouseOverBackColor = Color.Blue;
            IntTune.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IntTune.ForeColor = Color.Yellow;
            IntTune.Location = new Point(550, 1);
            IntTune.Name = "IntTune";
            IntTune.Size = new Size(88, 40);
            IntTune.TabIndex = 55;
            IntTune.Text = "Int Tuner";
            IntTune.UseVisualStyleBackColor = false;
            IntTune.Click += IntTune_Click;
            // 
            // ItuneOn
            // 
            ItuneOn.BackColor = Color.DarkGreen;
            ItuneOn.FlatAppearance.BorderColor = Color.White;
            ItuneOn.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOn.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOn.ForeColor = Color.Yellow;
            ItuneOn.Location = new Point(550, 41);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new Size(44, 40);
            ItuneOn.TabIndex = 56;
            ItuneOn.Text = "On";
            ItuneOn.UseVisualStyleBackColor = false;
            ItuneOn.Click += ItuneOn_Click;
            // 
            // ItuneOff
            // 
            ItuneOff.BackColor = Color.DarkGreen;
            ItuneOff.FlatAppearance.BorderColor = Color.White;
            ItuneOff.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOff.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOff.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOff.ForeColor = Color.Yellow;
            ItuneOff.Location = new Point(594, 41);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new Size(44, 40);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            ItuneOff.Click += ItuneOff_Click;
            // 
            // SubrfGainTrackBar
            // 
            SubrfGainTrackBar.BackColor = Color.Silver;
            SubrfGainTrackBar.ChannelColor = Color.Gray;
            SubrfGainTrackBar.ForeColor = Color.DarkBlue;
            SubrfGainTrackBar.Location = new Point(98, 121);
            SubrfGainTrackBar.Maximum = 23;
            SubrfGainTrackBar.Minimum = 1;
            SubrfGainTrackBar.Name = "SubrfGainTrackBar";
            SubrfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubrfGainTrackBar.Size = new Size(45, 105);
            SubrfGainTrackBar.TabIndex = 59;
            SubrfGainTrackBar.TickColor = Color.DarkBlue;
            SubrfGainTrackBar.TickFrequency = 1;
            SubrfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubrfGainTrackBar.Value = 1;
            // 
            // SubvolumeGainTrackBar
            // 
            SubvolumeGainTrackBar.BackColor = Color.Silver;
            SubvolumeGainTrackBar.ChannelColor = Color.Gray;
            SubvolumeGainTrackBar.ForeColor = Color.DarkBlue;
            SubvolumeGainTrackBar.Location = new Point(145, 121);
            SubvolumeGainTrackBar.Minimum = -60;
            SubvolumeGainTrackBar.Maximum = 60;
            SubvolumeGainTrackBar.Name = "SubvolumeGainTrackBar";
            SubvolumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubvolumeGainTrackBar.Size = new Size(45, 105);
            SubvolumeGainTrackBar.TabIndex = 60;
            SubvolumeGainTrackBar.TickColor = Color.DarkBlue;
            SubvolumeGainTrackBar.TickFrequency = 10;
            SubvolumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubvolumeGainTrackBar.Value = 0;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.Black;
            textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBox5.ForeColor = Color.Gold;
            textBox5.Location = new Point(98, 227);
            textBox5.Margin = new System.Windows.Forms.Padding(0);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(45, 16);
            textBox5.TabIndex = 61;
            textBox5.TabStop = false;
            textBox5.Text = "000";
            textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox5.WordWrap = false;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.Black;
            textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBox6.ForeColor = Color.Gold;
            textBox6.Location = new Point(145, 227);
            textBox6.Margin = new System.Windows.Forms.Padding(0);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(45, 18);
            textBox6.TabIndex = 62;
            textBox6.TabStop = false;
            textBox6.Text = "000";
            textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox6.WordWrap = false;
            // 
            // SWAP
            // 
            SWAP.BackColor = Color.DarkGreen;
            SWAP.FlatAppearance.BorderColor = Color.White;
            SWAP.FlatAppearance.BorderSize = 3;
            SWAP.FlatAppearance.MouseDownBackColor = Color.Red;
            SWAP.FlatAppearance.MouseOverBackColor = Color.Blue;
            SWAP.Font = new Font("Verdana", 7F, FontStyle.Bold);
            SWAP.ForeColor = Color.Yellow;
            SWAP.Location = new Point(195, 81);
            SWAP.Name = "SWAP";
            SWAP.Size = new Size(88, 40);
            SWAP.TabIndex = 63;
            SWAP.Text = "< === >";
            SWAP.UseVisualStyleBackColor = false;
            SWAP.Click += SWAP_Click;
            // 
            // rfGainLabel
            // 
            rfGainLabel.BackColor = Color.Silver;
            rfGainLabel.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rfGainLabel.ForeColor = Color.Black;
            rfGainLabel.Location = new Point(1, 111);
            rfGainLabel.Name = "rfGainLabel";
            rfGainLabel.Size = new Size(45, 12);
            rfGainLabel.TabIndex = 0;
            rfGainLabel.Text = "RF";
            rfGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // volumeGainLabel
            // 
            volumeGainLabel.BackColor = Color.Silver;
            volumeGainLabel.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            volumeGainLabel.ForeColor = Color.Black;
            volumeGainLabel.Location = new Point(48, 111);
            volumeGainLabel.Name = "volumeGainLabel";
            volumeGainLabel.Size = new Size(45, 12);
            volumeGainLabel.TabIndex = 0;
            volumeGainLabel.Text = "VOL";
            volumeGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pwrControlLabel
            // 
            pwrControlLabel.BackColor = Color.Maroon;
            pwrControlLabel.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pwrControlLabel.ForeColor = Color.Yellow;
            pwrControlLabel.Location = new Point(660, 5);
            pwrControlLabel.Name = "pwrControlLabel";
            pwrControlLabel.Size = new Size(45, 12);
            pwrControlLabel.TabIndex = 0;
            pwrControlLabel.Text = "POWER";
            pwrControlLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubrfGainLabel
            // 
            SubrfGainLabel.BackColor = Color.Silver;
            SubrfGainLabel.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubrfGainLabel.ForeColor = Color.Black;
            SubrfGainLabel.Location = new Point(98, 111);
            SubrfGainLabel.Name = "SubrfGainLabel";
            SubrfGainLabel.Size = new Size(45, 12);
            SubrfGainLabel.TabIndex = 0;
            SubrfGainLabel.Text = "WIDTH";
            SubrfGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubvolumeGainLabel
            // 
            SubvolumeGainLabel.BackColor = Color.Silver;
            SubvolumeGainLabel.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubvolumeGainLabel.ForeColor = Color.Black;
            SubvolumeGainLabel.Location = new Point(145, 111);
            SubvolumeGainLabel.Name = "SubvolumeGainLabel";
            SubvolumeGainLabel.Size = new Size(45, 12);
            SubvolumeGainLabel.TabIndex = 0;
            SubvolumeGainLabel.Text = "SHIFT";
            SubvolumeGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comPortComboBox
            // 
            comPortComboBox.BackColor = Color.DarkGreen;
            comPortComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comPortComboBox.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comPortComboBox.ForeColor = Color.Yellow;
            comPortComboBox.ItemHeight = 16;
            comPortComboBox.Location = new Point(640, 189);
            comPortComboBox.Name = "comPortComboBox";
            comPortComboBox.Size = new Size(85, 22);
            comPortComboBox.TabIndex = 65;
            // 
            // ConnectToggleButton
            // 
            ConnectToggleButton.BackColor = Color.DarkGreen;
            ConnectToggleButton.FlatAppearance.BorderColor = Color.White;
            ConnectToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConnectToggleButton.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConnectToggleButton.ForeColor = Color.Yellow;
            ConnectToggleButton.Location = new Point(640, 218);
            ConnectToggleButton.Name = "ConnectToggleButton";
            ConnectToggleButton.Size = new Size(85, 22);
            ConnectToggleButton.TabIndex = 66;
            ConnectToggleButton.Text = "Connect";
            ConnectToggleButton.UseVisualStyleBackColor = false;
            // 
            // StepComboBox
            // 
            StepComboBox.BackColor = Color.DarkGreen;
            StepComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            StepComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            StepComboBox.Font = new Font("Arial", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StepComboBox.ForeColor = Color.Yellow;
            StepComboBox.ItemHeight = 16;
            StepComboBox.Location = new Point(640, 161);
            StepComboBox.Name = "StepComboBox";
            StepComboBox.Size = new Size(86, 22);
            StepComboBox.TabIndex = 67;
            // 
            // BANDB
            // 
            BANDB.BackColor = Color.DarkGreen;
            BANDB.FlatAppearance.BorderColor = Color.White;
            BANDB.FlatAppearance.MouseDownBackColor = Color.Red;
            BANDB.FlatAppearance.MouseOverBackColor = Color.Blue;
            BANDB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BANDB.ForeColor = Color.Yellow;
            BANDB.Location = new Point(195, 1);
            BANDB.Name = "BANDB";
            BANDB.Size = new Size(88, 40);
            BANDB.TabIndex = 68;
            BANDB.Text = "BAND";
            BANDB.UseVisualStyleBackColor = false;
            BANDB.MouseDown += BANDB_MouseDown;
            // 
            // MINB
            // 
            MINB.BackColor = Color.DarkGreen;
            MINB.FlatAppearance.BorderColor = Color.White;
            MINB.FlatAppearance.MouseDownBackColor = Color.Red;
            MINB.FlatAppearance.MouseOverBackColor = Color.Blue;
            MINB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MINB.ForeColor = Color.Yellow;
            MINB.Location = new Point(195, 41);
            MINB.Name = "MINB";
            MINB.Size = new Size(44, 40);
            MINB.TabIndex = 69;
            MINB.Text = "[-]";
            MINB.UseVisualStyleBackColor = false;
            MINB.Click += MINB_Click;
            // 
            // PLUSB
            // 
            PLUSB.BackColor = Color.DarkGreen;
            PLUSB.FlatAppearance.BorderColor = Color.White;
            PLUSB.FlatAppearance.MouseDownBackColor = Color.Red;
            PLUSB.FlatAppearance.MouseOverBackColor = Color.Blue;
            PLUSB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PLUSB.ForeColor = Color.Yellow;
            PLUSB.Location = new Point(239, 41);
            PLUSB.Name = "PLUSB";
            PLUSB.Size = new Size(44, 40);
            PLUSB.TabIndex = 70;
            PLUSB.Text = "[+]";
            PLUSB.UseVisualStyleBackColor = false;
            PLUSB.Click += PLUSB_Click;
            // 
            // LEVRESET
            // 
            LEVRESET.BackColor = Color.DarkGreen;
            LEVRESET.FlatAppearance.BorderColor = Color.White;
            LEVRESET.FlatAppearance.MouseDownBackColor = Color.Red;
            LEVRESET.FlatAppearance.MouseOverBackColor = Color.Blue;
            LEVRESET.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LEVRESET.ForeColor = Color.Yellow;
            LEVRESET.Location = new Point(550, 121);
            LEVRESET.Name = "LEVRESET";
            LEVRESET.Size = new Size(88, 40);
            LEVRESET.TabIndex = 73;
            LEVRESET.Text = "RESET LEVEL";
            LEVRESET.UseVisualStyleBackColor = false;
            LEVRESET.Click += LEVRESET_Click;
            // 
            // LevMIN
            // 
            LevMIN.BackColor = Color.DarkGreen;
            LevMIN.FlatAppearance.BorderColor = Color.White;
            LevMIN.FlatAppearance.MouseDownBackColor = Color.Red;
            LevMIN.FlatAppearance.MouseOverBackColor = Color.Blue;
            LevMIN.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LevMIN.ForeColor = Color.Yellow;
            LevMIN.Location = new Point(550, 161);
            LevMIN.Name = "LevMIN";
            LevMIN.Size = new Size(44, 40);
            LevMIN.TabIndex = 74;
            LevMIN.Text = "[-]";
            LevMIN.UseVisualStyleBackColor = false;
            LevMIN.Click += LevMIN_Click;
            // 
            // LevPLUS
            // 
            LevPLUS.BackColor = Color.DarkGreen;
            LevPLUS.FlatAppearance.BorderColor = Color.White;
            LevPLUS.FlatAppearance.MouseDownBackColor = Color.Red;
            LevPLUS.FlatAppearance.MouseOverBackColor = Color.Blue;
            LevPLUS.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LevPLUS.ForeColor = Color.Yellow;
            LevPLUS.Location = new Point(594, 161);
            LevPLUS.Name = "LevPLUS";
            LevPLUS.Size = new Size(44, 40);
            LevPLUS.TabIndex = 75;
            LevPLUS.Text = "[+]";
            LevPLUS.UseVisualStyleBackColor = false;
            LevPLUS.Click += LevPLUS_Click;
            // 
            // ATT0B
            // 
            ATT0B.BackColor = Color.DarkGreen;
            ATT0B.FlatAppearance.BorderColor = Color.White;
            ATT0B.FlatAppearance.MouseDownBackColor = Color.Red;
            ATT0B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ATT0B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ATT0B.ForeColor = Color.Yellow;
            ATT0B.Location = new Point(462, 1);
            ATT0B.Name = "ATT0B";
            ATT0B.Size = new Size(44, 40);
            ATT0B.TabIndex = 76;
            ATT0B.Text = "ATT\r\nOFF";
            ATT0B.UseVisualStyleBackColor = false;
            ATT0B.MouseClick += ATT0B_click;
            // 
            // ATT6B
            // 
            ATT6B.BackColor = Color.DarkGreen;
            ATT6B.FlatAppearance.BorderColor = Color.White;
            ATT6B.FlatAppearance.MouseDownBackColor = Color.Red;
            ATT6B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ATT6B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ATT6B.ForeColor = Color.Yellow;
            ATT6B.Location = new Point(505, 1);
            ATT6B.Name = "ATT6B";
            ATT6B.Size = new Size(44, 40);
            ATT6B.TabIndex = 77;
            ATT6B.Text = "-6\r\ndB\r\n";
            ATT6B.UseVisualStyleBackColor = false;
            ATT6B.MouseClick += ATT6B_click;
            // 
            // ATT12B
            // 
            ATT12B.BackColor = Color.DarkGreen;
            ATT12B.FlatAppearance.BorderColor = Color.White;
            ATT12B.FlatAppearance.MouseDownBackColor = Color.Red;
            ATT12B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ATT12B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ATT12B.ForeColor = Color.Yellow;
            ATT12B.Location = new Point(462, 41);
            ATT12B.Name = "ATT12B";
            ATT12B.Size = new Size(44, 40);
            ATT12B.TabIndex = 78;
            ATT12B.Text = "-12\r\ndB\r\n";
            ATT12B.UseVisualStyleBackColor = false;
            ATT12B.MouseClick += ATT12B_click;
            // 
            // ATT18B
            // 
            ATT18B.BackColor = Color.DarkGreen;
            ATT18B.FlatAppearance.BorderColor = Color.White;
            ATT18B.FlatAppearance.MouseDownBackColor = Color.Red;
            ATT18B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ATT18B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ATT18B.ForeColor = Color.Yellow;
            ATT18B.Location = new Point(505, 41);
            ATT18B.Name = "ATT18B";
            ATT18B.Size = new Size(44, 40);
            ATT18B.TabIndex = 79;
            ATT18B.Text = "-18\r\ndB\r\n";
            ATT18B.UseVisualStyleBackColor = false;
            ATT18B.MouseClick += ATT18B_click;
            // 
            // DNFB
            // 
            DNFB.BackColor = Color.DarkGreen;
            DNFB.FlatAppearance.BorderColor = Color.White;
            DNFB.FlatAppearance.MouseDownBackColor = Color.Red;
            DNFB.FlatAppearance.MouseOverBackColor = Color.Blue;
            DNFB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DNFB.ForeColor = Color.Yellow;
            DNFB.Location = new Point(505, 81);
            DNFB.Name = "DNFB";
            DNFB.Size = new Size(44, 40);
            DNFB.TabIndex = 80;
            DNFB.Text = "BC";
            DNFB.UseVisualStyleBackColor = false;
            DNFB.MouseClick += DNFB_click;
            // 
            // DNRB
            // 
            DNRB.BackColor = Color.DarkGreen;
            DNRB.FlatAppearance.BorderColor = Color.White;
            DNRB.FlatAppearance.MouseDownBackColor = Color.Red;
            DNRB.FlatAppearance.MouseOverBackColor = Color.Blue;
            DNRB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DNRB.ForeColor = Color.Yellow;
            DNRB.Location = new Point(462, 80);
            DNRB.Name = "DNRB";
            DNRB.Size = new Size(44, 40);
            DNRB.TabIndex = 81;
            DNRB.Text = "NR";
            DNRB.UseVisualStyleBackColor = false;
            DNRB.MouseClick += DNRB_click;
            // 
            // LEV_box
            // 
            LEV_box.BackColor = Color.Black;
            LEV_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            LEV_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LEV_box.ForeColor = Color.YellowGreen;
            LEV_box.Location = new Point(593, 204);
            LEV_box.Margin = new System.Windows.Forms.Padding(0);
            LEV_box.Multiline = true;
            LEV_box.Name = "LEV_box";
            LEV_box.Size = new Size(44, 39);
            LEV_box.TabIndex = 82;
            LEV_box.TabStop = false;
            LEV_box.Text = "+30\r\ndB";
            LEV_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            LEV_box.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(727, 241);
            Controls.Add(LEV_box);
            Controls.Add(DNRB);
            Controls.Add(DNFB);
            Controls.Add(ATT18B);
            Controls.Add(ATT12B);
            Controls.Add(ATT6B);
            Controls.Add(ATT0B);
            Controls.Add(LevPLUS);
            Controls.Add(LevMIN);
            Controls.Add(LEVRESET);
            Controls.Add(PLUSB);
            Controls.Add(MINB);
            Controls.Add(BANDB);
            Controls.Add(StepComboBox);
            Controls.Add(ConnectToggleButton);
            Controls.Add(comPortComboBox);
            Controls.Add(rfGainLabel);
            Controls.Add(volumeGainLabel);
            Controls.Add(pwrControlLabel);
            Controls.Add(SubrfGainLabel);
            Controls.Add(SubvolumeGainLabel);
            Controls.Add(SWAP);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(SubvolumeGainTrackBar);
            Controls.Add(SubrfGainTrackBar);
            Controls.Add(ItuneOff);
            Controls.Add(ItuneOn);
            Controls.Add(IntTune);
            Controls.Add(SSB6);
            Controls.Add(SSB5);
            Controls.Add(SSB4);
            Controls.Add(DIGB);
            Controls.Add(FMB);
            Controls.Add(AMB);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(FreqS_box);
            Controls.Add(FreqM_box);
            Controls.Add(volumeGainTrackBar);
            Controls.Add(rfGainTrackBar);
            Controls.Add(FixB);
            Controls.Add(SSB3);
            Controls.Add(SSB2);
            Controls.Add(SSB1);
            Controls.Add(RX2B);
            Controls.Add(RX1B);
            Controls.Add(AMP2B);
            Controls.Add(AMP1B);
            Controls.Add(IPOB);
            Controls.Add(ANT3RXB);
            Controls.Add(ANT2B);
            Controls.Add(ANT1B);
            Controls.Add(RFTOGGLE);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(CenterB);
            Controls.Add(CursorB);
            Controls.Add(ExtTuneButton);
            Controls.Add(TEMP_box);
            Controls.Add(pwrControlTrackBar);
            Controls.Add(textBox3);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            ImeMode = System.Windows.Forms.ImeMode.Disable;
            Location = new Point(1, 1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            TransparencyKey = Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox TEMP_box;
        private System.Windows.Forms.Button ExtTuneButton;
        private System.Windows.Forms.Button CursorB;
        private System.Windows.Forms.Button CenterB;
        private System.Windows.Forms.Button USBB;
        private System.Windows.Forms.Button LSBB;
        private System.Windows.Forms.Button CWB;
        private System.Windows.Forms.Button RFTOGGLE;
        private System.Windows.Forms.Button ANT1B;
        private System.Windows.Forms.Button ANT2B;
        private System.Windows.Forms.Button ANT3RXB;
        private System.Windows.Forms.Button IPOB;
        private System.Windows.Forms.Button AMP1B;
        private System.Windows.Forms.Button AMP2B;
        private System.Windows.Forms.Button RX1B;
        private System.Windows.Forms.Button RX2B;
        private System.Windows.Forms.Button SSB1;
        private System.Windows.Forms.Button SSB2;
        private System.Windows.Forms.Button SSB3;
        private System.Windows.Forms.Button FixB;
        private CustomTrackBar rfGainTrackBar;
        private CustomTrackBar volumeGainTrackBar;
        private CustomTrackBar pwrControlTrackBar;
        private System.Windows.Forms.Button FreqM_box;
        private System.Windows.Forms.Button FreqS_box;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button AMB;
        private System.Windows.Forms.Button FMB;
        private System.Windows.Forms.Button DIGB;
        private System.Windows.Forms.Button SSB4;
        private System.Windows.Forms.Button SSB5;
        private System.Windows.Forms.Button SSB6;
        private System.Windows.Forms.Button IntTune;
        private System.Windows.Forms.Button ItuneOn;
        private System.Windows.Forms.Button ItuneOff;
        private CustomTrackBar SubrfGainTrackBar;
        private CustomTrackBar SubvolumeGainTrackBar;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button SWAP;
        private System.Windows.Forms.Label rfGainLabel;
        private System.Windows.Forms.Label volumeGainLabel;
        private System.Windows.Forms.Label pwrControlLabel;
        private System.Windows.Forms.Label SubrfGainLabel;
        private System.Windows.Forms.Label SubvolumeGainLabel;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Button ConnectToggleButton;
        private System.Windows.Forms.ComboBox StepComboBox;
        private System.Windows.Forms.Button BANDB;
        private System.Windows.Forms.Button MINB;
        private System.Windows.Forms.Button PLUSB;
        private System.Windows.Forms.Button LEVRESET;
        private System.Windows.Forms.Button LevMIN;
        private System.Windows.Forms.Button LevPLUS;
        private System.Windows.Forms.Button ATT0B;
        private System.Windows.Forms.Button ATT6B;
        private System.Windows.Forms.Button ATT12B;
        private System.Windows.Forms.Button ATT18B;
        private System.Windows.Forms.Button DNFB;
        private System.Windows.Forms.Button DNRB;
        private System.Windows.Forms.TextBox LEV_box;
    }
}


namespace The101Box
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
            RFSQL_box = new System.Windows.Forms.TextBox();
            TEMP_box = new System.Windows.Forms.TextBox();
            StartButton = new System.Windows.Forms.Button();
            TuneButton = new System.Windows.Forms.Button();
            CursorB = new System.Windows.Forms.Button();
            CenterB = new System.Windows.Forms.Button();
            USBB = new System.Windows.Forms.Button();
            LSBB = new System.Windows.Forms.Button();
            CWB = new System.Windows.Forms.Button();
            VConB = new System.Windows.Forms.Button();
            P5WB = new System.Windows.Forms.Button();
            P50WB = new System.Windows.Forms.Button();
            P100WB = new System.Windows.Forms.Button();
            VCoffB = new System.Windows.Forms.Button();
            SQLB = new System.Windows.Forms.Button();
            RFB = new System.Windows.Forms.Button();
            PWR_box = new System.Windows.Forms.TextBox();
            DSPMOD_box = new System.Windows.Forms.TextBox();
            MODE_box = new System.Windows.Forms.TextBox();
            TIJDSTIP_box = new System.Windows.Forms.TextBox();
            ANT1B = new System.Windows.Forms.Button();
            ANT2B = new System.Windows.Forms.Button();
            ANT3RXB = new System.Windows.Forms.Button();
            IPOB = new System.Windows.Forms.Button();
            AMP1B = new System.Windows.Forms.Button();
            AMP2B = new System.Windows.Forms.Button();
            ANT_box = new System.Windows.Forms.TextBox();
            IPO_box = new System.Windows.Forms.TextBox();
            RX1B = new System.Windows.Forms.Button();
            RX2 = new System.Windows.Forms.Button();
            RX12B = new System.Windows.Forms.Button();
            RX_box = new System.Windows.Forms.TextBox();
            SSB1 = new System.Windows.Forms.Button();
            SSB2 = new System.Windows.Forms.Button();
            SSB3 = new System.Windows.Forms.Button();
            DSPSPAN_box = new System.Windows.Forms.TextBox();
            FixB = new System.Windows.Forms.Button();
            rfGainTrackBar = new System.Windows.Forms.TrackBar();
            volumeGainTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            SuspendLayout();
            // 
            // RFSQL_box
            // 
            RFSQL_box.BackColor = System.Drawing.Color.Black;
            RFSQL_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            RFSQL_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RFSQL_box.ForeColor = System.Drawing.Color.Cyan;
            RFSQL_box.Location = new System.Drawing.Point(84, 103);
            RFSQL_box.Margin = new System.Windows.Forms.Padding(0);
            RFSQL_box.Name = "RFSQL_box";
            RFSQL_box.Size = new System.Drawing.Size(84, 20);
            RFSQL_box.TabIndex = 4;
            RFSQL_box.TabStop = false;
            RFSQL_box.Text = "<RF/SQL>";
            RFSQL_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            RFSQL_box.TextChanged += TextBox2_TextChanged;
            // 
            // TEMP_box
            // 
            TEMP_box.BackColor = System.Drawing.Color.Black;
            TEMP_box.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            TEMP_box.ForeColor = System.Drawing.Color.Cyan;
            TEMP_box.Location = new System.Drawing.Point(1, 0);
            TEMP_box.Margin = new System.Windows.Forms.Padding(0);
            TEMP_box.Multiline = true;
            TEMP_box.Name = "TEMP_box";
            TEMP_box.Size = new System.Drawing.Size(112, 34);
            TEMP_box.TabIndex = 5;
            TEMP_box.TabStop = false;
            TEMP_box.Text = "00°C (000)";
            TEMP_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TEMP_box.WordWrap = false;
            // 
            // StartButton
            // 
            StartButton.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            StartButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            StartButton.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            StartButton.ForeColor = System.Drawing.Color.Yellow;
            StartButton.Location = new System.Drawing.Point(113, 0);
            StartButton.Name = "StartButton";
            StartButton.Size = new System.Drawing.Size(56, 35);
            StartButton.TabIndex = 6;
            StartButton.Text = "RESET";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.MouseClick += StartButton_Click;
            // 
            // TuneButton
            // 
            TuneButton.BackColor = System.Drawing.Color.DarkGreen;
            TuneButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            TuneButton.FlatAppearance.BorderSize = 3;
            TuneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            TuneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            TuneButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            TuneButton.ForeColor = System.Drawing.Color.Yellow;
            TuneButton.Location = new System.Drawing.Point(756, 1);
            TuneButton.Name = "TuneButton";
            TuneButton.Size = new System.Drawing.Size(85, 124);
            TuneButton.TabIndex = 8;
            TuneButton.Text = "External Tuner";
            TuneButton.UseVisualStyleBackColor = false;
            TuneButton.MouseDown += TuneButton_MouseDown;
            TuneButton.MouseUp += TuneButton_MouseUp;
            // 
            // CursorB
            // 
            CursorB.BackColor = System.Drawing.Color.DarkGreen;
            CursorB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            CursorB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            CursorB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            CursorB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CursorB.ForeColor = System.Drawing.Color.Yellow;
            CursorB.Location = new System.Drawing.Point(672, 0);
            CursorB.Name = "CursorB";
            CursorB.Size = new System.Drawing.Size(85, 35);
            CursorB.TabIndex = 9;
            CursorB.Text = "CURSOR";
            CursorB.UseVisualStyleBackColor = false;
            CursorB.MouseClick += Cursor_Click;
            // 
            // CenterB
            // 
            CenterB.BackColor = System.Drawing.Color.DarkGreen;
            CenterB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            CenterB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            CenterB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            CenterB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CenterB.ForeColor = System.Drawing.Color.Yellow;
            CenterB.Location = new System.Drawing.Point(672, 34);
            CenterB.Name = "CenterB";
            CenterB.Size = new System.Drawing.Size(85, 35);
            CenterB.TabIndex = 10;
            CenterB.Text = "CENTER";
            CenterB.UseVisualStyleBackColor = false;
            CenterB.MouseClick += Center_Click;
            // 
            // USBB
            // 
            USBB.BackColor = System.Drawing.Color.DarkGreen;
            USBB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            USBB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            USBB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            USBB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            USBB.ForeColor = System.Drawing.Color.Yellow;
            USBB.Location = new System.Drawing.Point(336, 0);
            USBB.Name = "USBB";
            USBB.Size = new System.Drawing.Size(85, 35);
            USBB.TabIndex = 11;
            USBB.Text = "USB";
            USBB.UseVisualStyleBackColor = false;
            USBB.MouseClick += USB_click;
            // 
            // LSBB
            // 
            LSBB.BackColor = System.Drawing.Color.DarkGreen;
            LSBB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            LSBB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            LSBB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            LSBB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LSBB.ForeColor = System.Drawing.Color.Yellow;
            LSBB.Location = new System.Drawing.Point(336, 34);
            LSBB.Name = "LSBB";
            LSBB.Size = new System.Drawing.Size(85, 35);
            LSBB.TabIndex = 12;
            LSBB.Text = "LSB";
            LSBB.UseVisualStyleBackColor = false;
            LSBB.MouseClick += LSB_click;
            // 
            // CWB
            // 
            CWB.BackColor = System.Drawing.Color.DarkGreen;
            CWB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            CWB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            CWB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            CWB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CWB.ForeColor = System.Drawing.Color.Yellow;
            CWB.Location = new System.Drawing.Point(336, 68);
            CWB.Name = "CWB";
            CWB.Size = new System.Drawing.Size(85, 35);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            CWB.MouseClick += CW_click;
            // 
            // VConB
            // 
            VConB.BackColor = System.Drawing.Color.DarkGreen;
            VConB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            VConB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            VConB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            VConB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            VConB.ForeColor = System.Drawing.Color.Yellow;
            VConB.Location = new System.Drawing.Point(0, 34);
            VConB.Name = "VConB";
            VConB.Size = new System.Drawing.Size(85, 35);
            VConB.TabIndex = 14;
            VConB.Text = "VC on";
            VConB.UseVisualStyleBackColor = false;
            VConB.MouseClick += VN_on;
            // 
            // P5WB
            // 
            P5WB.BackColor = System.Drawing.Color.DarkGreen;
            P5WB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            P5WB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            P5WB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            P5WB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            P5WB.ForeColor = System.Drawing.Color.Yellow;
            P5WB.Location = new System.Drawing.Point(252, 0);
            P5WB.Name = "P5WB";
            P5WB.Size = new System.Drawing.Size(85, 35);
            P5WB.TabIndex = 15;
            P5WB.Text = "5 WATT";
            P5WB.UseVisualStyleBackColor = false;
            P5WB.MouseClick += P5WB_click;
            // 
            // P50WB
            // 
            P50WB.BackColor = System.Drawing.Color.DarkGreen;
            P50WB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            P50WB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            P50WB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            P50WB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            P50WB.ForeColor = System.Drawing.Color.Yellow;
            P50WB.Location = new System.Drawing.Point(252, 34);
            P50WB.Name = "P50WB";
            P50WB.Size = new System.Drawing.Size(85, 35);
            P50WB.TabIndex = 16;
            P50WB.Text = "50 WATT";
            P50WB.UseVisualStyleBackColor = false;
            P50WB.MouseClick += P50W_click;
            // 
            // P100WB
            // 
            P100WB.BackColor = System.Drawing.Color.DarkGreen;
            P100WB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            P100WB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            P100WB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            P100WB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            P100WB.ForeColor = System.Drawing.Color.Yellow;
            P100WB.Location = new System.Drawing.Point(252, 68);
            P100WB.Name = "P100WB";
            P100WB.Size = new System.Drawing.Size(85, 35);
            P100WB.TabIndex = 17;
            P100WB.Text = "100 WATT";
            P100WB.UseVisualStyleBackColor = false;
            P100WB.MouseClick += P100W_click;
            // 
            // VCoffB
            // 
            VCoffB.BackColor = System.Drawing.Color.DarkGreen;
            VCoffB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            VCoffB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            VCoffB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            VCoffB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            VCoffB.ForeColor = System.Drawing.Color.Yellow;
            VCoffB.Location = new System.Drawing.Point(0, 68);
            VCoffB.Name = "VCoffB";
            VCoffB.Size = new System.Drawing.Size(85, 35);
            VCoffB.TabIndex = 18;
            VCoffB.Text = "VC off";
            VCoffB.UseVisualStyleBackColor = false;
            VCoffB.MouseClick += VC_off;
            // 
            // SQLB
            // 
            SQLB.BackColor = System.Drawing.Color.DarkGreen;
            SQLB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SQLB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SQLB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SQLB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SQLB.ForeColor = System.Drawing.Color.Yellow;
            SQLB.Location = new System.Drawing.Point(84, 34);
            SQLB.Name = "SQLB";
            SQLB.Size = new System.Drawing.Size(85, 35);
            SQLB.TabIndex = 19;
            SQLB.Text = "Squelch";
            SQLB.UseVisualStyleBackColor = false;
            SQLB.MouseClick += SQL_click;
            // 
            // RFB
            // 
            RFB.BackColor = System.Drawing.Color.DarkGreen;
            RFB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            RFB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            RFB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            RFB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RFB.ForeColor = System.Drawing.Color.Yellow;
            RFB.Location = new System.Drawing.Point(84, 68);
            RFB.Name = "RFB";
            RFB.Size = new System.Drawing.Size(85, 35);
            RFB.TabIndex = 20;
            RFB.Text = "RF";
            RFB.UseVisualStyleBackColor = false;
            RFB.MouseClick += RF_click;
            // 
            // PWR_box
            // 
            PWR_box.BackColor = System.Drawing.Color.Black;
            PWR_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PWR_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            PWR_box.ForeColor = System.Drawing.Color.Cyan;
            PWR_box.Location = new System.Drawing.Point(252, 103);
            PWR_box.Margin = new System.Windows.Forms.Padding(0);
            PWR_box.Name = "PWR_box";
            PWR_box.Size = new System.Drawing.Size(84, 20);
            PWR_box.TabIndex = 21;
            PWR_box.TabStop = false;
            PWR_box.Text = "<PWR>";
            PWR_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DSPMOD_box
            // 
            DSPMOD_box.BackColor = System.Drawing.Color.Black;
            DSPMOD_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DSPMOD_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DSPMOD_box.ForeColor = System.Drawing.Color.Cyan;
            DSPMOD_box.Location = new System.Drawing.Point(672, 103);
            DSPMOD_box.Margin = new System.Windows.Forms.Padding(0);
            DSPMOD_box.Name = "DSPMOD_box";
            DSPMOD_box.Size = new System.Drawing.Size(84, 20);
            DSPMOD_box.TabIndex = 22;
            DSPMOD_box.TabStop = false;
            DSPMOD_box.Text = "<DSPMOD>";
            DSPMOD_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MODE_box
            // 
            MODE_box.BackColor = System.Drawing.Color.Black;
            MODE_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MODE_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            MODE_box.ForeColor = System.Drawing.Color.Cyan;
            MODE_box.Location = new System.Drawing.Point(336, 103);
            MODE_box.Margin = new System.Windows.Forms.Padding(0);
            MODE_box.Name = "MODE_box";
            MODE_box.Size = new System.Drawing.Size(84, 20);
            MODE_box.TabIndex = 23;
            MODE_box.TabStop = false;
            MODE_box.Text = "<MODE>";
            MODE_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TIJDSTIP_box
            // 
            TIJDSTIP_box.BackColor = System.Drawing.Color.Black;
            TIJDSTIP_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TIJDSTIP_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            TIJDSTIP_box.ForeColor = System.Drawing.Color.Lime;
            TIJDSTIP_box.Location = new System.Drawing.Point(2, 103);
            TIJDSTIP_box.Margin = new System.Windows.Forms.Padding(0);
            TIJDSTIP_box.Name = "TIJDSTIP_box";
            TIJDSTIP_box.Size = new System.Drawing.Size(84, 20);
            TIJDSTIP_box.TabIndex = 24;
            TIJDSTIP_box.TabStop = false;
            TIJDSTIP_box.Text = "<TIME>";
            TIJDSTIP_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ANT1B
            // 
            ANT1B.BackColor = System.Drawing.Color.DarkGreen;
            ANT1B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ANT1B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ANT1B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ANT1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ANT1B.ForeColor = System.Drawing.Color.Yellow;
            ANT1B.Location = new System.Drawing.Point(420, 0);
            ANT1B.Name = "ANT1B";
            ANT1B.Size = new System.Drawing.Size(85, 35);
            ANT1B.TabIndex = 25;
            ANT1B.Text = "ANT1";
            ANT1B.UseVisualStyleBackColor = false;
            ANT1B.MouseClick += ANT1B_click;
            // 
            // ANT2B
            // 
            ANT2B.BackColor = System.Drawing.Color.DarkGreen;
            ANT2B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ANT2B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ANT2B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ANT2B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ANT2B.ForeColor = System.Drawing.Color.Yellow;
            ANT2B.Location = new System.Drawing.Point(420, 34);
            ANT2B.Name = "ANT2B";
            ANT2B.Size = new System.Drawing.Size(85, 35);
            ANT2B.TabIndex = 26;
            ANT2B.Text = "ANT2";
            ANT2B.UseVisualStyleBackColor = false;
            ANT2B.MouseClick += ANT2B_click;
            // 
            // ANT3RXB
            // 
            ANT3RXB.BackColor = System.Drawing.Color.DarkGreen;
            ANT3RXB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ANT3RXB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ANT3RXB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ANT3RXB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ANT3RXB.ForeColor = System.Drawing.Color.Yellow;
            ANT3RXB.Location = new System.Drawing.Point(420, 68);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new System.Drawing.Size(85, 35);
            ANT3RXB.TabIndex = 27;
            ANT3RXB.Text = "ANT3/RX";
            ANT3RXB.UseVisualStyleBackColor = false;
            ANT3RXB.MouseClick += ANT3RXB_click;
            // 
            // IPOB
            // 
            IPOB.BackColor = System.Drawing.Color.DarkGreen;
            IPOB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            IPOB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            IPOB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            IPOB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            IPOB.ForeColor = System.Drawing.Color.Yellow;
            IPOB.Location = new System.Drawing.Point(504, 0);
            IPOB.Name = "IPOB";
            IPOB.Size = new System.Drawing.Size(85, 35);
            IPOB.TabIndex = 28;
            IPOB.Text = "IPO";
            IPOB.UseVisualStyleBackColor = false;
            IPOB.MouseClick += IPOB_click;
            // 
            // AMP1B
            // 
            AMP1B.BackColor = System.Drawing.Color.DarkGreen;
            AMP1B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            AMP1B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            AMP1B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            AMP1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            AMP1B.ForeColor = System.Drawing.Color.Yellow;
            AMP1B.Location = new System.Drawing.Point(504, 34);
            AMP1B.Name = "AMP1B";
            AMP1B.Size = new System.Drawing.Size(85, 35);
            AMP1B.TabIndex = 29;
            AMP1B.Text = "AMP1";
            AMP1B.UseVisualStyleBackColor = false;
            AMP1B.MouseClick += AMP1B_click;
            // 
            // AMP2B
            // 
            AMP2B.BackColor = System.Drawing.Color.DarkGreen;
            AMP2B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            AMP2B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            AMP2B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            AMP2B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            AMP2B.ForeColor = System.Drawing.Color.Yellow;
            AMP2B.Location = new System.Drawing.Point(504, 68);
            AMP2B.Name = "AMP2B";
            AMP2B.Size = new System.Drawing.Size(85, 35);
            AMP2B.TabIndex = 30;
            AMP2B.Text = "AMP2";
            AMP2B.UseVisualStyleBackColor = false;
            AMP2B.MouseClick += AMP2B_click;
            // 
            // ANT_box
            // 
            ANT_box.BackColor = System.Drawing.Color.Black;
            ANT_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ANT_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ANT_box.ForeColor = System.Drawing.Color.Cyan;
            ANT_box.Location = new System.Drawing.Point(420, 103);
            ANT_box.Margin = new System.Windows.Forms.Padding(0);
            ANT_box.Name = "ANT_box";
            ANT_box.Size = new System.Drawing.Size(84, 20);
            ANT_box.TabIndex = 31;
            ANT_box.TabStop = false;
            ANT_box.Text = "<ANT>";
            ANT_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPO_box
            // 
            IPO_box.BackColor = System.Drawing.Color.Black;
            IPO_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            IPO_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            IPO_box.ForeColor = System.Drawing.Color.Cyan;
            IPO_box.Location = new System.Drawing.Point(504, 103);
            IPO_box.Margin = new System.Windows.Forms.Padding(0);
            IPO_box.Name = "IPO_box";
            IPO_box.Size = new System.Drawing.Size(84, 20);
            IPO_box.TabIndex = 32;
            IPO_box.TabStop = false;
            IPO_box.Text = "<IPO>";
            IPO_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RX1B
            // 
            RX1B.BackColor = System.Drawing.Color.DarkGreen;
            RX1B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            RX1B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            RX1B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            RX1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RX1B.ForeColor = System.Drawing.Color.Yellow;
            RX1B.Location = new System.Drawing.Point(168, 0);
            RX1B.Name = "RX1B";
            RX1B.Size = new System.Drawing.Size(85, 35);
            RX1B.TabIndex = 33;
            RX1B.Text = "RX 1";
            RX1B.UseVisualStyleBackColor = false;
            RX1B.MouseClick += RX1B_click;
            // 
            // RX2
            // 
            RX2.BackColor = System.Drawing.Color.DarkGreen;
            RX2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            RX2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            RX2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            RX2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RX2.ForeColor = System.Drawing.Color.Yellow;
            RX2.Location = new System.Drawing.Point(168, 34);
            RX2.Name = "RX2";
            RX2.Size = new System.Drawing.Size(85, 35);
            RX2.TabIndex = 34;
            RX2.Text = "RX 2";
            RX2.UseVisualStyleBackColor = false;
            RX2.MouseClick += RX2B_click;
            // 
            // RX12B
            // 
            RX12B.BackColor = System.Drawing.Color.DarkGreen;
            RX12B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            RX12B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            RX12B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            RX12B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RX12B.ForeColor = System.Drawing.Color.Yellow;
            RX12B.Location = new System.Drawing.Point(168, 68);
            RX12B.Name = "RX12B";
            RX12B.Size = new System.Drawing.Size(85, 35);
            RX12B.TabIndex = 35;
            RX12B.Text = "RX 1 + 2";
            RX12B.UseVisualStyleBackColor = false;
            RX12B.MouseClick += RX12B_click;
            // 
            // RX_box
            // 
            RX_box.BackColor = System.Drawing.Color.Black;
            RX_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            RX_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RX_box.ForeColor = System.Drawing.Color.Cyan;
            RX_box.Location = new System.Drawing.Point(168, 103);
            RX_box.Margin = new System.Windows.Forms.Padding(0);
            RX_box.Name = "RX_box";
            RX_box.Size = new System.Drawing.Size(84, 20);
            RX_box.TabIndex = 36;
            RX_box.TabStop = false;
            RX_box.Text = "<RX>";
            RX_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            RX_box.TextChanged += RX_box_TextChanged;
            // 
            // SSB1
            // 
            SSB1.BackColor = System.Drawing.Color.DarkGreen;
            SSB1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB1.ForeColor = System.Drawing.Color.Yellow;
            SSB1.Location = new System.Drawing.Point(588, 0);
            SSB1.Name = "SSB1";
            SSB1.Size = new System.Drawing.Size(85, 35);
            SSB1.TabIndex = 37;
            SSB1.Text = "100k";
            SSB1.UseVisualStyleBackColor = false;
            SSB1.MouseClick += SSB1_click;
            // 
            // SSB2
            // 
            SSB2.BackColor = System.Drawing.Color.DarkGreen;
            SSB2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB2.ForeColor = System.Drawing.Color.Yellow;
            SSB2.Location = new System.Drawing.Point(588, 34);
            SSB2.Name = "SSB2";
            SSB2.Size = new System.Drawing.Size(85, 35);
            SSB2.TabIndex = 38;
            SSB2.Text = "200k";
            SSB2.UseVisualStyleBackColor = false;
            SSB2.MouseClick += SSB2_click;
            // 
            // SSB3
            // 
            SSB3.BackColor = System.Drawing.Color.DarkGreen;
            SSB3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB3.ForeColor = System.Drawing.Color.Yellow;
            SSB3.Location = new System.Drawing.Point(588, 68);
            SSB3.Name = "SSB3";
            SSB3.Size = new System.Drawing.Size(85, 35);
            SSB3.TabIndex = 39;
            SSB3.Text = "500k";
            SSB3.UseVisualStyleBackColor = false;
            SSB3.MouseClick += SSB3_click;
            // 
            // DSPSPAN_box
            // 
            DSPSPAN_box.BackColor = System.Drawing.Color.Black;
            DSPSPAN_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DSPSPAN_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DSPSPAN_box.ForeColor = System.Drawing.Color.Cyan;
            DSPSPAN_box.Location = new System.Drawing.Point(588, 103);
            DSPSPAN_box.Margin = new System.Windows.Forms.Padding(0);
            DSPSPAN_box.Name = "DSPSPAN_box";
            DSPSPAN_box.Size = new System.Drawing.Size(84, 20);
            DSPSPAN_box.TabIndex = 40;
            DSPSPAN_box.TabStop = false;
            DSPSPAN_box.Text = "<SPAN>";
            DSPSPAN_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            DSPSPAN_box.TextChanged += textBox1_TextChanged_1;
            // 
            // FixB
            // 
            FixB.BackColor = System.Drawing.Color.DarkGreen;
            FixB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            FixB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            FixB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            FixB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FixB.ForeColor = System.Drawing.Color.Yellow;
            FixB.Location = new System.Drawing.Point(672, 68);
            FixB.Name = "FixB";
            FixB.Size = new System.Drawing.Size(85, 35);
            FixB.TabIndex = 41;
            FixB.Text = "FIX";
            FixB.UseVisualStyleBackColor = false;
            FixB.Click += FixB_Click;
            FixB.MouseClick += Fix_Click;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.BackColor = System.Drawing.Color.DarkGreen;
            rfGainTrackBar.Location = new System.Drawing.Point(842, 1);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            rfGainTrackBar.Size = new System.Drawing.Size(45, 122);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            rfGainTrackBar.Value = 255;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = System.Drawing.Color.DarkGreen;
            volumeGainTrackBar.Location = new System.Drawing.Point(889, 1);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            volumeGainTrackBar.Size = new System.Drawing.Size(45, 122);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeGainTrackBar.Value = 60;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(934, 125);
            Controls.Add(volumeGainTrackBar);
            Controls.Add(rfGainTrackBar);
            Controls.Add(FixB);
            Controls.Add(DSPSPAN_box);
            Controls.Add(SSB3);
            Controls.Add(SSB2);
            Controls.Add(SSB1);
            Controls.Add(RX_box);
            Controls.Add(RX12B);
            Controls.Add(RX2);
            Controls.Add(RX1B);
            Controls.Add(IPO_box);
            Controls.Add(ANT_box);
            Controls.Add(AMP2B);
            Controls.Add(AMP1B);
            Controls.Add(IPOB);
            Controls.Add(ANT3RXB);
            Controls.Add(ANT2B);
            Controls.Add(ANT1B);
            Controls.Add(TIJDSTIP_box);
            Controls.Add(MODE_box);
            Controls.Add(DSPMOD_box);
            Controls.Add(PWR_box);
            Controls.Add(RFB);
            Controls.Add(SQLB);
            Controls.Add(VCoffB);
            Controls.Add(P100WB);
            Controls.Add(P50WB);
            Controls.Add(P5WB);
            Controls.Add(VConB);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(CenterB);
            Controls.Add(CursorB);
            Controls.Add(TuneButton);
            Controls.Add(StartButton);
            Controls.Add(TEMP_box);
            Controls.Add(RFSQL_box);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.Yellow;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ImeMode = System.Windows.Forms.ImeMode.Disable;
            Location = new System.Drawing.Point(1, 1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "The101Box v 14 - by Kees, ON9KVE - COM8";
            TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox RFSQL_box;
        private System.Windows.Forms.TextBox TEMP_box;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button TuneButton;
        private System.Windows.Forms.Button CursorB;
        private System.Windows.Forms.Button CenterB;
        private System.Windows.Forms.Button USBB;
        private System.Windows.Forms.Button LSBB;
        private System.Windows.Forms.Button CWB;
        private System.Windows.Forms.Button VConB;
        private System.Windows.Forms.Button P5WB;
        private System.Windows.Forms.Button P50WB;
        private System.Windows.Forms.Button P100WB;
        private System.Windows.Forms.Button VCoffB;
        private System.Windows.Forms.Button SQLB;
        private System.Windows.Forms.Button RFB;
        private System.Windows.Forms.TextBox PWR_box;
        private System.Windows.Forms.TextBox DSPMOD_box;
        private System.Windows.Forms.TextBox MODE_box;
        private System.Windows.Forms.TextBox TIJDSTIP_box;
        private System.Windows.Forms.Button ANT1B;
        private System.Windows.Forms.Button ANT2B;
        private System.Windows.Forms.Button ANT3RXB;
        private System.Windows.Forms.Button IPOB;
        private System.Windows.Forms.Button AMP1B;
        private System.Windows.Forms.Button AMP2B;
        private System.Windows.Forms.TextBox ANT_box;
        private System.Windows.Forms.TextBox IPO_box;
        private System.Windows.Forms.Button RX1B;
        private System.Windows.Forms.Button RX2;
        private System.Windows.Forms.Button RX12B;
        private System.Windows.Forms.TextBox RX_box;
        private System.Windows.Forms.Button SSB1;
        private System.Windows.Forms.Button SSB2;
        private System.Windows.Forms.Button SSB3;
        private System.Windows.Forms.TextBox DSPSPAN_box;
        private System.Windows.Forms.Button FixB;
        private System.Windows.Forms.TrackBar rfGainTrackBar;
        private System.Windows.Forms.TrackBar volumeGainTrackBar;
    }
}


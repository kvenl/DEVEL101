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
            ExtTuneButton = new System.Windows.Forms.Button();
            CursorB = new System.Windows.Forms.Button();
            CenterB = new System.Windows.Forms.Button();
            USBB = new System.Windows.Forms.Button();
            LSBB = new System.Windows.Forms.Button();
            CWB = new System.Windows.Forms.Button();
            RFTOGGLE = new System.Windows.Forms.Button();
            DSPMOD_box = new System.Windows.Forms.TextBox();
            MODE_box = new System.Windows.Forms.TextBox();
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
            FreqM_box = new System.Windows.Forms.TextBox();
            FreqS_box = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            BUSY_box = new System.Windows.Forms.TextBox();
            pwrControlTrackBar = new System.Windows.Forms.TrackBar();
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
            textBox4 = new System.Windows.Forms.TextBox();
            SubrfGainTrackBar = new System.Windows.Forms.TrackBar();
            SubvolumeGainTrackBar = new System.Windows.Forms.TrackBar();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox6 = new System.Windows.Forms.TextBox();
            SWAP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).BeginInit();
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
            TEMP_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TEMP_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            TEMP_box.ForeColor = System.Drawing.Color.Cyan;
            TEMP_box.Location = new System.Drawing.Point(20, 103);
            TEMP_box.Margin = new System.Windows.Forms.Padding(0);
            TEMP_box.Multiline = true;
            TEMP_box.Name = "TEMP_box";
            TEMP_box.Size = new System.Drawing.Size(54, 20);
            TEMP_box.TabIndex = 5;
            TEMP_box.TabStop = false;
            TEMP_box.Text = "00°C";
            TEMP_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TEMP_box.WordWrap = false;
            // 
            // ExtTuneButton
            // 
            ExtTuneButton.BackColor = System.Drawing.Color.DarkGreen;
            ExtTuneButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ExtTuneButton.FlatAppearance.BorderSize = 3;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ExtTuneButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            ExtTuneButton.ForeColor = System.Drawing.Color.Yellow;
            ExtTuneButton.Location = new System.Drawing.Point(824, 70);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new System.Drawing.Size(86, 33);
            ExtTuneButton.TabIndex = 8;
            ExtTuneButton.Text = "Ext Tuner";
            ExtTuneButton.UseVisualStyleBackColor = false;
            ExtTuneButton.MouseDown += TuneButton_MouseDown;
            ExtTuneButton.MouseUp += TuneButton_MouseUp;
            // 
            // CursorB
            // 
            CursorB.BackColor = System.Drawing.Color.DarkGreen;
            CursorB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            CursorB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            CursorB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            CursorB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            CursorB.ForeColor = System.Drawing.Color.Yellow;
            CursorB.Location = new System.Drawing.Point(506, 0);
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
            CenterB.Location = new System.Drawing.Point(506, 34);
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
            USBB.Location = new System.Drawing.Point(421, 0);
            USBB.Name = "USBB";
            USBB.Size = new System.Drawing.Size(44, 35);
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
            LSBB.Location = new System.Drawing.Point(464, 0);
            LSBB.Name = "LSBB";
            LSBB.Size = new System.Drawing.Size(44, 35);
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
            CWB.Location = new System.Drawing.Point(421, 68);
            CWB.Name = "CWB";
            CWB.Size = new System.Drawing.Size(44, 35);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            CWB.MouseClick += CW_click;
            // 
            // RFTOGGLE
            // 
            RFTOGGLE.BackColor = System.Drawing.Color.DarkGreen;
            RFTOGGLE.FlatAppearance.BorderColor = System.Drawing.Color.White;
            RFTOGGLE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            RFTOGGLE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            RFTOGGLE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            RFTOGGLE.ForeColor = System.Drawing.Color.Yellow;
            RFTOGGLE.Location = new System.Drawing.Point(84, 68);
            RFTOGGLE.Name = "RFTOGGLE";
            RFTOGGLE.Size = new System.Drawing.Size(86, 35);
            RFTOGGLE.TabIndex = 20;
            RFTOGGLE.Text = "RF / SQL";
            RFTOGGLE.UseVisualStyleBackColor = false;
            RFTOGGLE.MouseClick += RFB_click;
            // 
            // DSPMOD_box
            // 
            DSPMOD_box.BackColor = System.Drawing.Color.Black;
            DSPMOD_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DSPMOD_box.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DSPMOD_box.ForeColor = System.Drawing.Color.Cyan;
            DSPMOD_box.Location = new System.Drawing.Point(506, 103);
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
            MODE_box.Location = new System.Drawing.Point(425, 103);
            MODE_box.Margin = new System.Windows.Forms.Padding(0);
            MODE_box.Name = "MODE_box";
            MODE_box.Size = new System.Drawing.Size(84, 20);
            MODE_box.TabIndex = 23;
            MODE_box.TabStop = false;
            MODE_box.Text = "<MODE>";
            MODE_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ANT1B
            // 
            ANT1B.BackColor = System.Drawing.Color.DarkGreen;
            ANT1B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ANT1B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ANT1B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ANT1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ANT1B.ForeColor = System.Drawing.Color.Yellow;
            ANT1B.Location = new System.Drawing.Point(253, 0);
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
            ANT2B.Location = new System.Drawing.Point(253, 34);
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
            ANT3RXB.Location = new System.Drawing.Point(253, 68);
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
            IPOB.Location = new System.Drawing.Point(337, 0);
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
            AMP1B.Location = new System.Drawing.Point(337, 34);
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
            AMP2B.Location = new System.Drawing.Point(337, 68);
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
            ANT_box.Location = new System.Drawing.Point(253, 103);
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
            IPO_box.Location = new System.Drawing.Point(337, 103);
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
            RX1B.Size = new System.Drawing.Size(44, 35);
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
            RX2.Location = new System.Drawing.Point(210, 0);
            RX2.Name = "RX2";
            RX2.Size = new System.Drawing.Size(44, 35);
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
            RX12B.Location = new System.Drawing.Point(168, 34);
            RX12B.Name = "RX12B";
            RX12B.Size = new System.Drawing.Size(86, 35);
            RX12B.TabIndex = 35;
            RX12B.Text = "RX 1 + 2";
            RX12B.UseVisualStyleBackColor = false;
            RX12B.MouseClick += RX12B_click;
            RX12B.MouseDown += RX12B_MouseDown;
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
            SSB1.Location = new System.Drawing.Point(589, 34);
            SSB1.Name = "SSB1";
            SSB1.Size = new System.Drawing.Size(44, 35);
            SSB1.TabIndex = 37;
            SSB1.Text = "100";
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
            SSB2.Location = new System.Drawing.Point(631, 34);
            SSB2.Name = "SSB2";
            SSB2.Size = new System.Drawing.Size(44, 35);
            SSB2.TabIndex = 38;
            SSB2.Text = "200";
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
            SSB3.Location = new System.Drawing.Point(589, 68);
            SSB3.Name = "SSB3";
            SSB3.Size = new System.Drawing.Size(44, 35);
            SSB3.TabIndex = 39;
            SSB3.Text = "500";
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
            FixB.Location = new System.Drawing.Point(506, 68);
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
            rfGainTrackBar.Location = new System.Drawing.Point(678, 1);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            rfGainTrackBar.Size = new System.Drawing.Size(45, 102);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            rfGainTrackBar.Value = 255;
            rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = System.Drawing.Color.DarkGreen;
            volumeGainTrackBar.Location = new System.Drawing.Point(727, 1);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            volumeGainTrackBar.Size = new System.Drawing.Size(45, 102);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeGainTrackBar.Value = 60;
            // 
            // FreqM_box
            // 
            FreqM_box.BackColor = System.Drawing.Color.DarkGreen;
            FreqM_box.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FreqM_box.ForeColor = System.Drawing.Color.Yellow;
            FreqM_box.Location = new System.Drawing.Point(2, 1);
            FreqM_box.Multiline = true;
            FreqM_box.Name = "FreqM_box";
            FreqM_box.Size = new System.Drawing.Size(166, 33);
            FreqM_box.TabIndex = 44;
            FreqM_box.TabStop = false;
            FreqM_box.Text = "MAIN";
            FreqM_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            FreqM_box.WordWrap = false;
            // 
            // FreqS_box
            // 
            FreqS_box.BackColor = System.Drawing.Color.DarkBlue;
            FreqS_box.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FreqS_box.ForeColor = System.Drawing.Color.Yellow;
            FreqS_box.Location = new System.Drawing.Point(2, 36);
            FreqS_box.Multiline = true;
            FreqS_box.Name = "FreqS_box";
            FreqS_box.Size = new System.Drawing.Size(166, 33);
            FreqS_box.TabIndex = 45;
            FreqS_box.TabStop = false;
            FreqS_box.Text = "SUB";
            FreqS_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            FreqS_box.WordWrap = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.Black;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            textBox1.ForeColor = System.Drawing.Color.Cyan;
            textBox1.Location = new System.Drawing.Point(679, 106);
            textBox1.Margin = new System.Windows.Forms.Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(40, 15);
            textBox1.TabIndex = 46;
            textBox1.TabStop = false;
            textBox1.Text = "00";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.Color.Black;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            textBox2.ForeColor = System.Drawing.Color.Cyan;
            textBox2.Location = new System.Drawing.Point(728, 106);
            textBox2.Margin = new System.Windows.Forms.Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(40, 15);
            textBox2.TabIndex = 47;
            textBox2.TabStop = false;
            textBox2.Text = "00";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox2.WordWrap = false;
            // 
            // BUSY_box
            // 
            BUSY_box.BackColor = System.Drawing.Color.Black;
            BUSY_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            BUSY_box.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            BUSY_box.Location = new System.Drawing.Point(80, 105);
            BUSY_box.Margin = new System.Windows.Forms.Padding(1);
            BUSY_box.Multiline = true;
            BUSY_box.Name = "BUSY_box";
            BUSY_box.Size = new System.Drawing.Size(8, 8);
            BUSY_box.TabIndex = 48;
            BUSY_box.Text = "█";
            BUSY_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            BUSY_box.WordWrap = false;
            // 
            // pwrControlTrackBar
            // 
            pwrControlTrackBar.BackColor = System.Drawing.Color.DarkGreen;
            pwrControlTrackBar.Location = new System.Drawing.Point(776, 1);
            pwrControlTrackBar.Maximum = 100;
            pwrControlTrackBar.Minimum = 5;
            pwrControlTrackBar.Name = "pwrControlTrackBar";
            pwrControlTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            pwrControlTrackBar.Size = new System.Drawing.Size(45, 102);
            pwrControlTrackBar.TabIndex = 44;
            pwrControlTrackBar.TickFrequency = 5;
            pwrControlTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            pwrControlTrackBar.Value = 100;
            // 
            // textBox3
            // 
            textBox3.BackColor = System.Drawing.Color.Black;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            textBox3.ForeColor = System.Drawing.Color.Cyan;
            textBox3.Location = new System.Drawing.Point(777, 106);
            textBox3.Margin = new System.Windows.Forms.Padding(0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(40, 15);
            textBox3.TabIndex = 45;
            textBox3.TabStop = false;
            textBox3.Text = "100";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox3.WordWrap = false;
            // 
            // AMB
            // 
            AMB.BackColor = System.Drawing.Color.DarkGreen;
            AMB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            AMB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            AMB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            AMB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            AMB.ForeColor = System.Drawing.Color.Yellow;
            AMB.Location = new System.Drawing.Point(421, 34);
            AMB.Name = "AMB";
            AMB.Size = new System.Drawing.Size(44, 35);
            AMB.TabIndex = 49;
            AMB.Text = "AM";
            AMB.UseVisualStyleBackColor = false;
            AMB.MouseClick += AM_click;
            // 
            // FMB
            // 
            FMB.BackColor = System.Drawing.Color.DarkGreen;
            FMB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            FMB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            FMB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            FMB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FMB.ForeColor = System.Drawing.Color.Yellow;
            FMB.Location = new System.Drawing.Point(464, 34);
            FMB.Name = "FMB";
            FMB.Size = new System.Drawing.Size(44, 35);
            FMB.TabIndex = 50;
            FMB.Text = "FM";
            FMB.UseVisualStyleBackColor = false;
            FMB.MouseClick += FM_click;
            // 
            // DIGB
            // 
            DIGB.BackColor = System.Drawing.Color.DarkGreen;
            DIGB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            DIGB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            DIGB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            DIGB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DIGB.ForeColor = System.Drawing.Color.Yellow;
            DIGB.Location = new System.Drawing.Point(464, 68);
            DIGB.Name = "DIGB";
            DIGB.Size = new System.Drawing.Size(44, 35);
            DIGB.TabIndex = 51;
            DIGB.Text = "DIG";
            DIGB.UseVisualStyleBackColor = false;
            DIGB.MouseClick += DIG_click;
            // 
            // SSB4
            // 
            SSB4.BackColor = System.Drawing.Color.DarkGreen;
            SSB4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB4.ForeColor = System.Drawing.Color.Yellow;
            SSB4.Location = new System.Drawing.Point(631, 68);
            SSB4.Name = "SSB4";
            SSB4.Size = new System.Drawing.Size(44, 35);
            SSB4.TabIndex = 52;
            SSB4.Text = "1 M";
            SSB4.UseVisualStyleBackColor = false;
            SSB4.MouseClick += SSB4_click;
            // 
            // SSB5
            // 
            SSB5.BackColor = System.Drawing.Color.DarkGreen;
            SSB5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB5.ForeColor = System.Drawing.Color.Yellow;
            SSB5.Location = new System.Drawing.Point(589, 0);
            SSB5.Name = "SSB5";
            SSB5.Size = new System.Drawing.Size(44, 35);
            SSB5.TabIndex = 53;
            SSB5.Text = "20 k";
            SSB5.UseVisualStyleBackColor = false;
            SSB5.MouseClick += SSB5_click;
            // 
            // SSB6
            // 
            SSB6.BackColor = System.Drawing.Color.DarkGreen;
            SSB6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SSB6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SSB6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SSB6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SSB6.ForeColor = System.Drawing.Color.Yellow;
            SSB6.Location = new System.Drawing.Point(631, 0);
            SSB6.Name = "SSB6";
            SSB6.Size = new System.Drawing.Size(44, 35);
            SSB6.TabIndex = 54;
            SSB6.Text = "50 k";
            SSB6.UseVisualStyleBackColor = false;
            SSB6.MouseDown += SSB6_click;
            // 
            // IntTune
            // 
            IntTune.BackColor = System.Drawing.Color.DarkGreen;
            IntTune.FlatAppearance.BorderColor = System.Drawing.Color.White;
            IntTune.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            IntTune.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            IntTune.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            IntTune.ForeColor = System.Drawing.Color.Yellow;
            IntTune.Location = new System.Drawing.Point(824, 1);
            IntTune.Name = "IntTune";
            IntTune.Size = new System.Drawing.Size(86, 35);
            IntTune.TabIndex = 55;
            IntTune.Text = "Int Tuner";
            IntTune.UseVisualStyleBackColor = false;
            IntTune.Click += IntTune_Click;
            // 
            // ItuneOn
            // 
            ItuneOn.BackColor = System.Drawing.Color.DarkGreen;
            ItuneOn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ItuneOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ItuneOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ItuneOn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ItuneOn.ForeColor = System.Drawing.Color.Yellow;
            ItuneOn.Location = new System.Drawing.Point(824, 36);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new System.Drawing.Size(44, 35);
            ItuneOn.TabIndex = 56;
            ItuneOn.Text = "On";
            ItuneOn.UseVisualStyleBackColor = false;
            ItuneOn.Click += ItuneOn_Click;
            // 
            // ItuneOff
            // 
            ItuneOff.BackColor = System.Drawing.Color.DarkGreen;
            ItuneOff.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ItuneOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            ItuneOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ItuneOff.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ItuneOff.ForeColor = System.Drawing.Color.Yellow;
            ItuneOff.Location = new System.Drawing.Point(866, 36);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new System.Drawing.Size(44, 35);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            ItuneOff.Click += ItuneOff_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = System.Drawing.Color.Black;
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox4.ForeColor = System.Drawing.Color.Cyan;
            textBox4.Location = new System.Drawing.Point(827, 103);
            textBox4.Margin = new System.Windows.Forms.Padding(0);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(84, 20);
            textBox4.TabIndex = 58;
            textBox4.TabStop = false;
            textBox4.Text = "<INT TUN>";
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SubrfGainTrackBar
            // 
            SubrfGainTrackBar.BackColor = System.Drawing.Color.DarkBlue;
            SubrfGainTrackBar.Location = new System.Drawing.Point(915, 1);
            SubrfGainTrackBar.Maximum = 255;
            SubrfGainTrackBar.Name = "SubrfGainTrackBar";
            SubrfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubrfGainTrackBar.Size = new System.Drawing.Size(45, 102);
            SubrfGainTrackBar.TabIndex = 59;
            SubrfGainTrackBar.TickFrequency = 16;
            SubrfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubrfGainTrackBar.Value = 255;
            SubrfGainTrackBar.ValueChanged += SubrfGainTrackBar_ValueChanged;
            // 
            // SubvolumeGainTrackBar
            // 
            SubvolumeGainTrackBar.BackColor = System.Drawing.Color.DarkBlue;
            SubvolumeGainTrackBar.Location = new System.Drawing.Point(964, 1);
            SubvolumeGainTrackBar.Maximum = 255;
            SubvolumeGainTrackBar.Name = "SubvolumeGainTrackBar";
            SubvolumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubvolumeGainTrackBar.Size = new System.Drawing.Size(45, 102);
            SubvolumeGainTrackBar.TabIndex = 60;
            SubvolumeGainTrackBar.TickFrequency = 16;
            SubvolumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubvolumeGainTrackBar.ValueChanged += SubvolumeGainTrackBar_ValueChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = System.Drawing.Color.Black;
            textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            textBox5.ForeColor = System.Drawing.Color.Cyan;
            textBox5.Location = new System.Drawing.Point(916, 106);
            textBox5.Margin = new System.Windows.Forms.Padding(0);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(40, 15);
            textBox5.TabIndex = 61;
            textBox5.TabStop = false;
            textBox5.Text = "00";
            textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox5.WordWrap = false;
            // 
            // textBox6
            // 
            textBox6.BackColor = System.Drawing.Color.Black;
            textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            textBox6.ForeColor = System.Drawing.Color.Cyan;
            textBox6.Location = new System.Drawing.Point(965, 106);
            textBox6.Margin = new System.Windows.Forms.Padding(0);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(40, 15);
            textBox6.TabIndex = 62;
            textBox6.TabStop = false;
            textBox6.Text = "00";
            textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox6.WordWrap = false;
            // 
            // SWAP
            // 
            SWAP.BackColor = System.Drawing.Color.DarkGreen;
            SWAP.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SWAP.FlatAppearance.BorderSize = 3;
            SWAP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            SWAP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            SWAP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SWAP.ForeColor = System.Drawing.Color.Yellow;
            SWAP.Location = new System.Drawing.Point(0, 68);
            SWAP.Name = "SWAP";
            SWAP.Size = new System.Drawing.Size(86, 35);
            SWAP.TabIndex = 63;
            SWAP.Text = "< === >";
            SWAP.UseVisualStyleBackColor = false;
            SWAP.Click += SWAP_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1013, 125);
            Controls.Add(SWAP);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(SubvolumeGainTrackBar);
            Controls.Add(SubrfGainTrackBar);
            Controls.Add(textBox4);
            Controls.Add(ItuneOff);
            Controls.Add(ItuneOn);
            Controls.Add(IntTune);
            Controls.Add(SSB6);
            Controls.Add(SSB5);
            Controls.Add(SSB4);
            Controls.Add(DIGB);
            Controls.Add(FMB);
            Controls.Add(AMB);
            Controls.Add(BUSY_box);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(FreqS_box);
            Controls.Add(FreqM_box);
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
            Controls.Add(MODE_box);
            Controls.Add(DSPMOD_box);
            Controls.Add(RFTOGGLE);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(CenterB);
            Controls.Add(CursorB);
            Controls.Add(ExtTuneButton);
            Controls.Add(TEMP_box);
            Controls.Add(RFSQL_box);
            Controls.Add(pwrControlTrackBar);
            Controls.Add(textBox3);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.Yellow;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ImeMode = System.Windows.Forms.ImeMode.Disable;
            Location = new System.Drawing.Point(1, 1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "The101Box v 16 - by Kees, ON9KVE - COM4";
            TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox RFSQL_box;
        private System.Windows.Forms.TextBox TEMP_box;
        private System.Windows.Forms.Button ExtTuneButton;
        private System.Windows.Forms.Button CursorB;
        private System.Windows.Forms.Button CenterB;
        private System.Windows.Forms.Button USBB;
        private System.Windows.Forms.Button LSBB;
        private System.Windows.Forms.Button CWB;
        private System.Windows.Forms.Button RFTOGGLE;
        private System.Windows.Forms.TextBox DSPMOD_box;
        private System.Windows.Forms.TextBox MODE_box;
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
        private System.Windows.Forms.TrackBar pwrControlTrackBar;
        private System.Windows.Forms.TextBox FreqM_box;
        private System.Windows.Forms.TextBox FreqS_box;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox BUSY_box;
        private System.Windows.Forms.Button AMB;
        private System.Windows.Forms.Button FMB;
        private System.Windows.Forms.Button DIGB;
        private System.Windows.Forms.Button SSB4;
        private System.Windows.Forms.Button SSB5;
        private System.Windows.Forms.Button SSB6;
        private System.Windows.Forms.Button IntTune;
        private System.Windows.Forms.Button ItuneOn;
        private System.Windows.Forms.Button ItuneOff;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TrackBar SubrfGainTrackBar;
        private System.Windows.Forms.TrackBar SubvolumeGainTrackBar;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button SWAP;
    }
}


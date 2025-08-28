namespace ioctlpus
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbRightPane = new System.Windows.Forms.GroupBox();
            this.hbOutput = new Be.Windows.Forms.HexBox();
            this.gbLeftPane = new System.Windows.Forms.GroupBox();
            this.hbInput = new Be.Windows.Forms.HexBox();
            this.pnlReqParams = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblOutputSize = new System.Windows.Forms.Label();
            this.nudOutputSize = new System.Windows.Forms.NumericUpDown();
            this.lblInputSize = new System.Windows.Forms.Label();
            this.lblIOCTLCode = new System.Windows.Forms.Label();
            this.tbIOCTL = new System.Windows.Forms.TextBox();
            this.lblDevPath = new System.Windows.Forms.Label();
            this.nudInputSize = new System.Windows.Forms.NumericUpDown();
            this.button8 = new System.Windows.Forms.Button();
            this.gbRequestHistory = new System.Windows.Forms.GroupBox();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.tbFilters = new System.Windows.Forms.TextBox();
            this.btnStarRequest = new System.Windows.Forms.Button();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.btnOpenDB = new System.Windows.Forms.Button();
            this.tlvRequestHistory = new BrightIdeasSoftware.TreeListView();
            this.olvColumnRequest = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnRetVal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnBytesReturned = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServiceName = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxHex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.gbRightPane.SuspendLayout();
            this.gbLeftPane.SuspendLayout();
            this.pnlReqParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputSize)).BeginInit();
            this.gbRequestHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvRequestHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRightPane
            // 
            this.gbRightPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRightPane.Controls.Add(this.hbOutput);
            this.gbRightPane.Location = new System.Drawing.Point(426, 216);
            this.gbRightPane.Name = "gbRightPane";
            this.gbRightPane.Size = new System.Drawing.Size(419, 386);
            this.gbRightPane.TabIndex = 1;
            this.gbRightPane.TabStop = false;
            this.gbRightPane.Text = "Output Buffer";
            // 
            // hbOutput
            // 
            this.hbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hbOutput.InfoForeColor = System.Drawing.Color.Empty;
            this.hbOutput.Location = new System.Drawing.Point(6, 19);
            this.hbOutput.Name = "hbOutput";
            this.hbOutput.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hbOutput.Size = new System.Drawing.Size(407, 361);
            this.hbOutput.TabIndex = 0;
            // 
            // gbLeftPane
            // 
            this.gbLeftPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLeftPane.Controls.Add(this.hbInput);
            this.gbLeftPane.Location = new System.Drawing.Point(18, 216);
            this.gbLeftPane.Name = "gbLeftPane";
            this.gbLeftPane.Size = new System.Drawing.Size(408, 386);
            this.gbLeftPane.TabIndex = 0;
            this.gbLeftPane.TabStop = false;
            this.gbLeftPane.Text = "Input Buffer";
            // 
            // hbInput
            // 
            this.hbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hbInput.InfoForeColor = System.Drawing.Color.Empty;
            this.hbInput.Location = new System.Drawing.Point(6, 19);
            this.hbInput.Name = "hbInput";
            this.hbInput.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hbInput.Size = new System.Drawing.Size(396, 361);
            this.hbInput.TabIndex = 0;
            // 
            // pnlReqParams
            // 
            this.pnlReqParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlReqParams.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlReqParams.Controls.Add(this.button9);
            this.pnlReqParams.Controls.Add(this.button5);
            this.pnlReqParams.Controls.Add(this.comboBox1);
            this.pnlReqParams.Controls.Add(this.button2);
            this.pnlReqParams.Controls.Add(this.button1);
            this.pnlReqParams.Controls.Add(this.btnSettings);
            this.pnlReqParams.Controls.Add(this.btnAbout);
            this.pnlReqParams.Controls.Add(this.btnSend);
            this.pnlReqParams.Controls.Add(this.lblOutputSize);
            this.pnlReqParams.Controls.Add(this.nudOutputSize);
            this.pnlReqParams.Controls.Add(this.lblInputSize);
            this.pnlReqParams.Controls.Add(this.lblIOCTLCode);
            this.pnlReqParams.Controls.Add(this.tbIOCTL);
            this.pnlReqParams.Controls.Add(this.lblDevPath);
            this.pnlReqParams.Controls.Add(this.nudInputSize);
            this.pnlReqParams.Location = new System.Drawing.Point(12, 115);
            this.pnlReqParams.Name = "pnlReqParams";
            this.pnlReqParams.Size = new System.Drawing.Size(840, 95);
            this.pnlReqParams.TabIndex = 0;
            // 
            // button9
            // 
            this.button9.Image = global::ioctlpus.Properties.Resources.arrow_rotate_anticlockwise;
            this.button9.Location = new System.Drawing.Point(372, 53);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 23;
            this.button9.Text = "Refresh";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(453, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 73);
            this.button5.TabIndex = 17;
            this.button5.Text = "Hook IOCTL (Kernel Mode)";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(74, 5);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::ioctlpus.Properties.Resources.application_view_list;
            this.button2.Location = new System.Drawing.Point(632, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 28);
            this.button2.TabIndex = 13;
            this.button2.Text = "Load config from Hook";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ioctlpus.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(632, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "Load data from Hook";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Enabled = false;
            this.btnSettings.Image = global::ioctlpus.Properties.Resources.cog;
            this.btnSettings.Location = new System.Drawing.Point(801, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(32, 32);
            this.btnSettings.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnSettings, "Options");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Image = global::ioctlpus.Properties.Resources.help;
            this.btnAbout.Location = new System.Drawing.Point(800, 46);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(32, 32);
            this.btnAbout.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnAbout, "About");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Image = global::ioctlpus.Properties.Resources.lightning;
            this.btnSend.Location = new System.Drawing.Point(287, 51);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 26);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "&Replay";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblOutputSize
            // 
            this.lblOutputSize.AutoSize = true;
            this.lblOutputSize.Location = new System.Drawing.Point(145, 56);
            this.lblOutputSize.Name = "lblOutputSize";
            this.lblOutputSize.Size = new System.Drawing.Size(65, 13);
            this.lblOutputSize.TabIndex = 10;
            this.lblOutputSize.Text = "Output Size:";
            this.lblOutputSize.Click += new System.EventHandler(this.lblOutputSize_Click);
            // 
            // nudOutputSize
            // 
            this.nudOutputSize.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOutputSize.Hexadecimal = true;
            this.nudOutputSize.Location = new System.Drawing.Point(216, 54);
            this.nudOutputSize.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.nudOutputSize.Name = "nudOutputSize";
            this.nudOutputSize.Size = new System.Drawing.Size(65, 20);
            this.nudOutputSize.TabIndex = 5;
            this.nudOutputSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudOutputSize.ValueChanged += new System.EventHandler(this.nudOutputSize_ValueChanged);
            // 
            // lblInputSize
            // 
            this.lblInputSize.AutoSize = true;
            this.lblInputSize.Location = new System.Drawing.Point(4, 55);
            this.lblInputSize.Name = "lblInputSize";
            this.lblInputSize.Size = new System.Drawing.Size(57, 13);
            this.lblInputSize.TabIndex = 6;
            this.lblInputSize.Text = "Input Size:";
            this.lblInputSize.Click += new System.EventHandler(this.lblInputSize_Click);
            // 
            // lblIOCTLCode
            // 
            this.lblIOCTLCode.AutoSize = true;
            this.lblIOCTLCode.Location = new System.Drawing.Point(4, 32);
            this.lblIOCTLCode.Name = "lblIOCTLCode";
            this.lblIOCTLCode.Size = new System.Drawing.Size(69, 13);
            this.lblIOCTLCode.TabIndex = 5;
            this.lblIOCTLCode.Text = "IOCTL Code:";
            // 
            // tbIOCTL
            // 
            this.tbIOCTL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIOCTL.Location = new System.Drawing.Point(74, 30);
            this.tbIOCTL.Name = "tbIOCTL";
            this.tbIOCTL.Size = new System.Drawing.Size(373, 20);
            this.tbIOCTL.TabIndex = 2;
            this.tbIOCTL.TextChanged += new System.EventHandler(this.tbIOCTL_TextChanged);
            // 
            // lblDevPath
            // 
            this.lblDevPath.AutoSize = true;
            this.lblDevPath.Location = new System.Drawing.Point(3, 11);
            this.lblDevPath.Name = "lblDevPath";
            this.lblDevPath.Size = new System.Drawing.Size(44, 13);
            this.lblDevPath.TabIndex = 2;
            this.lblDevPath.Text = "Device:";
            // 
            // nudInputSize
            // 
            this.nudInputSize.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudInputSize.Hexadecimal = true;
            this.nudInputSize.Location = new System.Drawing.Point(74, 54);
            this.nudInputSize.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.nudInputSize.Name = "nudInputSize";
            this.nudInputSize.Size = new System.Drawing.Size(57, 20);
            this.nudInputSize.TabIndex = 4;
            this.nudInputSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudInputSize.ValueChanged += new System.EventHandler(this.nudInputSize_ValueChanged);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(536, 6);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(89, 52);
            this.button8.TabIndex = 22;
            this.button8.Text = "Start Kernel Hook";
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // gbRequestHistory
            // 
            this.gbRequestHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRequestHistory.Controls.Add(this.btnSaveDB);
            this.gbRequestHistory.Controls.Add(this.tbFilters);
            this.gbRequestHistory.Controls.Add(this.btnStarRequest);
            this.gbRequestHistory.Controls.Add(this.btnDeleteRequest);
            this.gbRequestHistory.Controls.Add(this.btnOpenDB);
            this.gbRequestHistory.Controls.Add(this.tlvRequestHistory);
            this.gbRequestHistory.Location = new System.Drawing.Point(12, 609);
            this.gbRequestHistory.Name = "gbRequestHistory";
            this.gbRequestHistory.Size = new System.Drawing.Size(833, 202);
            this.gbRequestHistory.TabIndex = 3;
            this.gbRequestHistory.TabStop = false;
            this.gbRequestHistory.Text = "Request History";
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDB.Enabled = false;
            this.btnSaveDB.Image = global::ioctlpus.Properties.Resources.database_save;
            this.btnSaveDB.Location = new System.Drawing.Point(795, 57);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(32, 32);
            this.btnSaveDB.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnSaveDB, "Save Database");
            this.btnSaveDB.UseVisualStyleBackColor = true;
            // 
            // tbFilters
            // 
            this.tbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilters.Enabled = false;
            this.tbFilters.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilters.Location = new System.Drawing.Point(6, 173);
            this.tbFilters.Name = "tbFilters";
            this.tbFilters.Size = new System.Drawing.Size(783, 20);
            this.tbFilters.TabIndex = 1;
            this.tbFilters.TextChanged += new System.EventHandler(this.tbFilters_TextChanged);
            // 
            // btnStarRequest
            // 
            this.btnStarRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStarRequest.Image = global::ioctlpus.Properties.Resources.star;
            this.btnStarRequest.Location = new System.Drawing.Point(795, 95);
            this.btnStarRequest.Name = "btnStarRequest";
            this.btnStarRequest.Size = new System.Drawing.Size(32, 32);
            this.btnStarRequest.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnStarRequest, "Star Request");
            this.btnStarRequest.UseVisualStyleBackColor = true;
            this.btnStarRequest.Click += new System.EventHandler(this.btnStarRequest_Click);
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRequest.Enabled = false;
            this.btnDeleteRequest.Image = global::ioctlpus.Properties.Resources.delete;
            this.btnDeleteRequest.Location = new System.Drawing.Point(795, 133);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteRequest.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnDeleteRequest, "Remove Request");
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            // 
            // btnOpenDB
            // 
            this.btnOpenDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDB.Enabled = false;
            this.btnOpenDB.Image = global::ioctlpus.Properties.Resources.database_add;
            this.btnOpenDB.Location = new System.Drawing.Point(795, 19);
            this.btnOpenDB.Name = "btnOpenDB";
            this.btnOpenDB.Size = new System.Drawing.Size(32, 32);
            this.btnOpenDB.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnOpenDB, "Load Database");
            this.btnOpenDB.UseVisualStyleBackColor = true;
            this.btnOpenDB.Click += new System.EventHandler(this.btnOpenDB_Click);
            // 
            // tlvRequestHistory
            // 
            this.tlvRequestHistory.AllColumns.Add(this.olvColumnRequest);
            this.tlvRequestHistory.AllColumns.Add(this.olvColumnRetVal);
            this.tlvRequestHistory.AllColumns.Add(this.olvColumnBytesReturned);
            this.tlvRequestHistory.AllColumns.Add(this.olvColumnTime);
            this.tlvRequestHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlvRequestHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnRequest,
            this.olvColumnRetVal,
            this.olvColumnBytesReturned,
            this.olvColumnTime});
            this.tlvRequestHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvRequestHistory.HideSelection = false;
            this.tlvRequestHistory.Location = new System.Drawing.Point(6, 19);
            this.tlvRequestHistory.Name = "tlvRequestHistory";
            this.tlvRequestHistory.OwnerDraw = true;
            this.tlvRequestHistory.ShowGroups = false;
            this.tlvRequestHistory.Size = new System.Drawing.Size(783, 148);
            this.tlvRequestHistory.TabIndex = 0;
            this.tlvRequestHistory.UseCompatibleStateImageBehavior = false;
            this.tlvRequestHistory.View = System.Windows.Forms.View.Details;
            this.tlvRequestHistory.VirtualMode = true;
            // 
            // olvColumnRequest
            // 
            this.olvColumnRequest.AspectName = "RequestName";
            this.olvColumnRequest.CellPadding = null;
            this.olvColumnRequest.MinimumWidth = 230;
            this.olvColumnRequest.Text = "Request";
            this.olvColumnRequest.Width = 230;
            // 
            // olvColumnRetVal
            // 
            this.olvColumnRetVal.AspectName = "ReturnValueString";
            this.olvColumnRetVal.CellPadding = null;
            this.olvColumnRetVal.IsEditable = false;
            this.olvColumnRetVal.MinimumWidth = 260;
            this.olvColumnRetVal.Text = "Return Value";
            this.olvColumnRetVal.Width = 260;
            // 
            // olvColumnBytesReturned
            // 
            this.olvColumnBytesReturned.AspectName = "BytesReturned";
            this.olvColumnBytesReturned.CellPadding = null;
            this.olvColumnBytesReturned.IsEditable = false;
            this.olvColumnBytesReturned.MinimumWidth = 90;
            this.olvColumnBytesReturned.Text = "Bytes Returned";
            this.olvColumnBytesReturned.Width = 90;
            // 
            // olvColumnTime
            // 
            this.olvColumnTime.AspectName = "Timestamp";
            this.olvColumnTime.CellPadding = null;
            this.olvColumnTime.FillsFreeSpace = true;
            this.olvColumnTime.IsEditable = false;
            this.olvColumnTime.Text = "Time";
            this.olvColumnTime.Width = 80;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 250;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbServiceName);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBoxHex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDec);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 96);
            this.panel1.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(618, 67);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(217, 20);
            this.textBox4.TabIndex = 30;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(437, 67);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 20);
            this.textBox3.TabIndex = 29;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(256, 67);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 20);
            this.textBox2.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(572, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Method:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Access:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Function:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Load a driver:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Service name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbServiceName
            // 
            this.tbServiceName.Location = new System.Drawing.Point(709, 40);
            this.tbServiceName.Name = "tbServiceName";
            this.tbServiceName.Size = new System.Drawing.Size(126, 20);
            this.tbServiceName.TabIndex = 19;
            this.tbServiceName.Text = "IOCTLHook";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::ioctlpus.Properties.Resources.cog;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(709, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 26);
            this.button7.TabIndex = 18;
            this.button7.Text = "Target driver";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(426, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Convert to Hexa";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(426, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Convert to Dec";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxHex
            // 
            this.textBoxHex.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHex.Location = new System.Drawing.Point(72, 7);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.Size = new System.Drawing.Size(349, 20);
            this.textBoxHex.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DecToHex:";
            // 
            // textBoxDec
            // 
            this.textBoxDec.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDec.Location = new System.Drawing.Point(72, 37);
            this.textBoxDec.Name = "textBoxDec";
            this.textBoxDec.Size = new System.Drawing.Size(349, 20);
            this.textBoxDec.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "HexToDec:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(289, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(8, 8);
            this.button6.TabIndex = 4;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(857, 821);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.gbRequestHistory);
            this.Controls.Add(this.gbRightPane);
            this.Controls.Add(this.gbLeftPane);
            this.Controls.Add(this.pnlReqParams);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(818, 596);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "IOCTL++ by Juan Sacco <jsacco@exploitpack.com>";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbRightPane.ResumeLayout(false);
            this.gbLeftPane.ResumeLayout(false);
            this.pnlReqParams.ResumeLayout(false);
            this.pnlReqParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputSize)).EndInit();
            this.gbRequestHistory.ResumeLayout(false);
            this.gbRequestHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvRequestHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Be.Windows.Forms.HexBox hbInput;
        private Be.Windows.Forms.HexBox hbOutput;
        private System.Windows.Forms.Panel pnlReqParams;
        private System.Windows.Forms.Label lblIOCTLCode;
        private System.Windows.Forms.TextBox tbIOCTL;
        private System.Windows.Forms.Label lblDevPath;
        private System.Windows.Forms.NumericUpDown nudInputSize;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblInputSize;
        private System.Windows.Forms.Label lblOutputSize;
        private System.Windows.Forms.NumericUpDown nudOutputSize;
        private System.Windows.Forms.GroupBox gbLeftPane;
        private System.Windows.Forms.GroupBox gbRightPane;
        private System.Windows.Forms.GroupBox gbRequestHistory;
        private System.Windows.Forms.Button btnStarRequest;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.Button btnOpenDB;
        private BrightIdeasSoftware.TreeListView tlvRequestHistory;
        private BrightIdeasSoftware.OLVColumn olvColumnRequest;
        private BrightIdeasSoftware.OLVColumn olvColumnTime;
        private BrightIdeasSoftware.OLVColumn olvColumnRetVal;
        private BrightIdeasSoftware.OLVColumn olvColumnBytesReturned;
        private System.Windows.Forms.TextBox tbFilters;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox tbServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}


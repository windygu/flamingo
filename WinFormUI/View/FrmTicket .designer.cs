namespace WinFormUI
{
    partial class FrmTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicket));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.tmExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxH = new System.Windows.Forms.PictureBox();
            this.pictureBoxHH = new System.Windows.Forms.PictureBox();
            this.pictureBoxMM = new System.Windows.Forms.PictureBox();
            this.pictureBoxM = new System.Windows.Forms.PictureBox();
            this.bhDirectionBtPanel1 = new SeatMaDll.BHDirectionBtPanel();
            this.btnCloseThis = new System.Windows.Forms.Button();
            this.bt_Rotation = new System.Windows.Forms.Button();
            this.bt_ReFrush = new System.Windows.Forms.Button();
            this.btnValidateTicket = new System.Windows.Forms.Button();
            this.btnQuerySoldInfo = new System.Windows.Forms.Button();
            this.bt_Zoom = new System.Windows.Forms.Button();
            this.btnReservationQuery = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblShowSoledMsg = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.uC_LabelVPanel1 = new WinFormUI.UC_LabelVPanel();
            this.seatChartDispExt1 = new WinFormUI.SeatChartDispExt();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChooseShowPlan = new System.Windows.Forms.Button();
            this.btnOperations = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnSaleType = new System.Windows.Forms.Button();
            this.btnPayType = new System.Windows.Forms.Button();
            this._doubleClickTimer = new System.Windows.Forms.Timer(this.components);
            this.bgw_RefrushStatus = new System.ComponentModel.BackgroundWorker();
            this.timer_RefrushStatus = new System.Windows.Forms.Timer(this.components);
            this.toolTip_Seat = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.timer_DateTime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxM)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.BackgroundImage = global::WinFormUI.Properties.Resources.BgImage;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.seatChartDispExt1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 469);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::WinFormUI.Properties.Resources.titlebar;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.btnHelp);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnMin);
            this.panel3.Controls.Add(this.tmExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 68);
            this.panel3.TabIndex = 5;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackgroundImage = global::WinFormUI.Properties.Resources.Help;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.Location = new System.Drawing.Point(872, 20);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 32);
            this.btnHelp.TabIndex = 25;
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::WinFormUI.Properties.Resources.Close;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(834, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 24;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackgroundImage = global::WinFormUI.Properties.Resources.Min;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.Location = new System.Drawing.Point(796, 20);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 32);
            this.btnMin.TabIndex = 23;
            this.btnMin.UseVisualStyleBackColor = true;
            // 
            // tmExit
            // 
            this.tmExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tmExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tmExit.BackgroundImage = global::WinFormUI.Properties.Resources.Exit;
            this.tmExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tmExit.FlatAppearance.BorderSize = 0;
            this.tmExit.Location = new System.Drawing.Point(758, 20);
            this.tmExit.Name = "tmExit";
            this.tmExit.Size = new System.Drawing.Size(32, 32);
            this.tmExit.TabIndex = 22;
            this.tmExit.UseVisualStyleBackColor = false;
            this.tmExit.Click += new System.EventHandler(this.tmExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(218)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.bhDirectionBtPanel1);
            this.panel2.Controls.Add(this.btnCloseThis);
            this.panel2.Controls.Add(this.bt_Rotation);
            this.panel2.Controls.Add(this.bt_ReFrush);
            this.panel2.Controls.Add(this.btnValidateTicket);
            this.panel2.Controls.Add(this.btnQuerySoldInfo);
            this.panel2.Controls.Add(this.bt_Zoom);
            this.panel2.Controls.Add(this.btnReservationQuery);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 28);
            this.panel2.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.pictureBoxH);
            this.panel7.Controls.Add(this.pictureBoxHH);
            this.panel7.Controls.Add(this.pictureBoxMM);
            this.panel7.Controls.Add(this.pictureBoxM);
            this.panel7.Location = new System.Drawing.Point(799, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(87, 25);
            this.panel7.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WinFormUI.Properties.Resources.TM;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(38, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 21);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxH
            // 
            this.pictureBoxH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxH.Location = new System.Drawing.Point(0, 1);
            this.pictureBoxH.Name = "pictureBoxH";
            this.pictureBoxH.Size = new System.Drawing.Size(19, 23);
            this.pictureBoxH.TabIndex = 30;
            this.pictureBoxH.TabStop = false;
            // 
            // pictureBoxHH
            // 
            this.pictureBoxHH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHH.Location = new System.Drawing.Point(19, 1);
            this.pictureBoxHH.Name = "pictureBoxHH";
            this.pictureBoxHH.Size = new System.Drawing.Size(19, 23);
            this.pictureBoxHH.TabIndex = 30;
            this.pictureBoxHH.TabStop = false;
            // 
            // pictureBoxMM
            // 
            this.pictureBoxMM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxMM.Location = new System.Drawing.Point(67, 1);
            this.pictureBoxMM.Name = "pictureBoxMM";
            this.pictureBoxMM.Size = new System.Drawing.Size(19, 23);
            this.pictureBoxMM.TabIndex = 30;
            this.pictureBoxMM.TabStop = false;
            // 
            // pictureBoxM
            // 
            this.pictureBoxM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxM.Location = new System.Drawing.Point(48, 1);
            this.pictureBoxM.Name = "pictureBoxM";
            this.pictureBoxM.Size = new System.Drawing.Size(19, 23);
            this.pictureBoxM.TabIndex = 30;
            this.pictureBoxM.TabStop = false;
            // 
            // bhDirectionBtPanel1
            // 
            this.bhDirectionBtPanel1.Location = new System.Drawing.Point(518, 0);
            this.bhDirectionBtPanel1.Name = "bhDirectionBtPanel1";
            this.bhDirectionBtPanel1.Size = new System.Drawing.Size(67, 25);
            this.bhDirectionBtPanel1.TabIndex = 3;
            // 
            // btnCloseThis
            // 
            this.btnCloseThis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseThis.BackgroundImage")));
            this.btnCloseThis.Location = new System.Drawing.Point(436, 0);
            this.btnCloseThis.Name = "btnCloseThis";
            this.btnCloseThis.Size = new System.Drawing.Size(76, 25);
            this.btnCloseThis.TabIndex = 2;
            this.btnCloseThis.Text = "关闭";
            this.btnCloseThis.UseVisualStyleBackColor = true;
            this.btnCloseThis.Click += new System.EventHandler(this.btnCloseThis_Click);
            // 
            // bt_Rotation
            // 
            this.bt_Rotation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Rotation.BackgroundImage")));
            this.bt_Rotation.Location = new System.Drawing.Point(357, 0);
            this.bt_Rotation.Name = "bt_Rotation";
            this.bt_Rotation.Size = new System.Drawing.Size(73, 25);
            this.bt_Rotation.TabIndex = 2;
            this.bt_Rotation.Text = "翻转";
            this.bt_Rotation.UseVisualStyleBackColor = true;
            this.bt_Rotation.Click += new System.EventHandler(this.bt_Rotation_Click);
            // 
            // bt_ReFrush
            // 
            this.bt_ReFrush.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_ReFrush.BackgroundImage")));
            this.bt_ReFrush.Location = new System.Drawing.Point(278, 0);
            this.bt_ReFrush.Name = "bt_ReFrush";
            this.bt_ReFrush.Size = new System.Drawing.Size(73, 25);
            this.bt_ReFrush.TabIndex = 1;
            this.bt_ReFrush.Text = "恢复";
            this.bt_ReFrush.UseVisualStyleBackColor = true;
            this.bt_ReFrush.Click += new System.EventHandler(this.bt_ReFrush_Click);
            // 
            // btnValidateTicket
            // 
            this.btnValidateTicket.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidateTicket.BackgroundImage")));
            this.btnValidateTicket.Location = new System.Drawing.Point(127, 0);
            this.btnValidateTicket.Name = "btnValidateTicket";
            this.btnValidateTicket.Size = new System.Drawing.Size(53, 25);
            this.btnValidateTicket.TabIndex = 0;
            this.btnValidateTicket.Text = "验票";
            this.btnValidateTicket.UseVisualStyleBackColor = true;
            this.btnValidateTicket.Click += new System.EventHandler(this.btnValidateTicket_Click);
            // 
            // btnQuerySoldInfo
            // 
            this.btnQuerySoldInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuerySoldInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuerySoldInfo.BackgroundImage")));
            this.btnQuerySoldInfo.Location = new System.Drawing.Point(9, 0);
            this.btnQuerySoldInfo.Name = "btnQuerySoldInfo";
            this.btnQuerySoldInfo.Size = new System.Drawing.Size(53, 25);
            this.btnQuerySoldInfo.TabIndex = 0;
            this.btnQuerySoldInfo.Text = "查询";
            this.btnQuerySoldInfo.UseVisualStyleBackColor = false;
            this.btnQuerySoldInfo.Click += new System.EventHandler(this.btnQuerySoldInfo_Click);
            // 
            // bt_Zoom
            // 
            this.bt_Zoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Zoom.BackgroundImage")));
            this.bt_Zoom.Location = new System.Drawing.Point(68, 0);
            this.bt_Zoom.Name = "bt_Zoom";
            this.bt_Zoom.Size = new System.Drawing.Size(53, 25);
            this.bt_Zoom.TabIndex = 0;
            this.bt_Zoom.Text = "放大";
            this.bt_Zoom.UseVisualStyleBackColor = true;
            this.bt_Zoom.Click += new System.EventHandler(this.bt_Zoom_Click);
            // 
            // btnReservationQuery
            // 
            this.btnReservationQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReservationQuery.BackgroundImage")));
            this.btnReservationQuery.Location = new System.Drawing.Point(186, 0);
            this.btnReservationQuery.Name = "btnReservationQuery";
            this.btnReservationQuery.Size = new System.Drawing.Size(86, 25);
            this.btnReservationQuery.TabIndex = 0;
            this.btnReservationQuery.Text = "订票查询";
            this.btnReservationQuery.UseVisualStyleBackColor = true;
            this.btnReservationQuery.Click += new System.EventHandler(this.btnReservationQuery_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 4);
            this.panel4.Controls.Add(this.lblShowSoledMsg);
            this.panel4.Location = new System.Drawing.Point(3, 349);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(924, 31);
            this.panel4.TabIndex = 6;
            // 
            // lblShowSoledMsg
            // 
            this.lblShowSoledMsg.AutoSize = true;
            this.lblShowSoledMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowSoledMsg.Location = new System.Drawing.Point(0, 0);
            this.lblShowSoledMsg.Name = "lblShowSoledMsg";
            this.lblShowSoledMsg.Size = new System.Drawing.Size(23, 12);
            this.lblShowSoledMsg.TabIndex = 1;
            this.lblShowSoledMsg.Text = "...";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.uC_LabelVPanel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 102);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 200);
            this.panel6.TabIndex = 8;
            // 
            // uC_LabelVPanel1
            // 
            this.uC_LabelVPanel1.BackColor = System.Drawing.Color.Transparent;
            this.uC_LabelVPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_LabelVPanel1.Location = new System.Drawing.Point(0, 0);
            this.uC_LabelVPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_LabelVPanel1.Name = "uC_LabelVPanel1";
            this.uC_LabelVPanel1.Size = new System.Drawing.Size(200, 200);
            this.uC_LabelVPanel1.TabIndex = 0;
            // 
            // seatChartDispExt1
            // 
            this.seatChartDispExt1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.seatChartDispExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDispExt1.Location = new System.Drawing.Point(203, 105);
            this.seatChartDispExt1.Name = "seatChartDispExt1";
            this.seatChartDispExt1.Size = new System.Drawing.Size(594, 194);
            this.seatChartDispExt1.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.tableLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(200, 302);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 44);
            this.panel5.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(600, 44);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnChooseShowPlan);
            this.panel1.Controls.Add(this.btnOperations);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnSale);
            this.panel1.Controls.Add(this.btnSaleType);
            this.panel1.Controls.Add(this.btnPayType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(90, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnChooseShowPlan
            // 
            this.btnChooseShowPlan.BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            this.btnChooseShowPlan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChooseShowPlan.Location = new System.Drawing.Point(3, 3);
            this.btnChooseShowPlan.Name = "btnChooseShowPlan";
            this.btnChooseShowPlan.Size = new System.Drawing.Size(96, 37);
            this.btnChooseShowPlan.TabIndex = 0;
            this.btnChooseShowPlan.Text = "售票选择";
            this.btnChooseShowPlan.UseVisualStyleBackColor = true;
            this.btnChooseShowPlan.Click += new System.EventHandler(this.btnChooseShowPlan_Click);
            // 
            // btnOperations
            // 
            this.btnOperations.BackgroundImage = global::WinFormUI.Properties.Resources.More;
            this.btnOperations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOperations.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOperations.Location = new System.Drawing.Point(527, 3);
            this.btnOperations.Name = "btnOperations";
            this.btnOperations.Size = new System.Drawing.Size(32, 37);
            this.btnOperations.TabIndex = 2;
            this.btnOperations.UseVisualStyleBackColor = true;
            this.btnOperations.Click += new System.EventHandler(this.btnOperations_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSettings.Location = new System.Drawing.Point(111, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(94, 37);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "设置";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSale
            // 
            this.btnSale.BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            this.btnSale.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSale.Location = new System.Drawing.Point(426, 3);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(98, 37);
            this.btnSale.TabIndex = 0;
            this.btnSale.Text = "出售";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnSaleType
            // 
            this.btnSaleType.BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            this.btnSaleType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaleType.Location = new System.Drawing.Point(217, 3);
            this.btnSaleType.Name = "btnSaleType";
            this.btnSaleType.Size = new System.Drawing.Size(94, 37);
            this.btnSaleType.TabIndex = 0;
            this.btnSaleType.Text = "零售";
            this.btnSaleType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaleType.UseVisualStyleBackColor = true;
            this.btnSaleType.Click += new System.EventHandler(this.btnSaleType_Click);
            // 
            // btnPayType
            // 
            this.btnPayType.BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            this.btnPayType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPayType.Location = new System.Drawing.Point(321, 3);
            this.btnPayType.Name = "btnPayType";
            this.btnPayType.Size = new System.Drawing.Size(94, 37);
            this.btnPayType.TabIndex = 0;
            this.btnPayType.Text = "现金";
            this.btnPayType.UseVisualStyleBackColor = true;
            this.btnPayType.Click += new System.EventHandler(this.btnPayType_Click);
            // 
            // _doubleClickTimer
            // 
            this._doubleClickTimer.Tick += new System.EventHandler(this._doubleClickTimer_Tick);
            // 
            // bgw_RefrushStatus
            // 
            this.bgw_RefrushStatus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_RefrushStatus_DoWork);
            this.bgw_RefrushStatus.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RefrushStatus_RunWorkerCompleted);
            // 
            // timer_RefrushStatus
            // 
            this.timer_RefrushStatus.Interval = 5000;
            this.timer_RefrushStatus.Tick += new System.EventHandler(this.timer_RefrushStatus_Tick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WinFormUI.Properties.Resources.售票选择;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 51);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(111, 51);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // timer_DateTime
            // 
            this.timer_DateTime.Interval = 60000;
            this.timer_DateTime.Tick += new System.EventHandler(this.timer_DateTime_Tick);
            // 
            // FrmTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(930, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTicket_FormClosing);
            this.Load += new System.EventHandler(this.FrmTicket_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxM)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnReservationQuery;
        private System.Windows.Forms.Button btnValidateTicket;
        private System.Windows.Forms.Button bt_Zoom;
        private System.Windows.Forms.Button btnQuerySoldInfo;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnPayType;
        private System.Windows.Forms.Button btnSaleType;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnChooseShowPlan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer _doubleClickTimer;
        private System.Windows.Forms.Button btnOperations;
        private System.ComponentModel.BackgroundWorker bgw_RefrushStatus;
        private System.Windows.Forms.Timer timer_RefrushStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button tmExit;
        private System.Windows.Forms.Button bt_ReFrush;
        private System.Windows.Forms.Button bt_Rotation;
        private System.Windows.Forms.Panel panel6;
        private UC_LabelVPanel uC_LabelVPanel1;
        private System.Windows.Forms.ToolTip toolTip_Seat;
        private SeatChartDispExt seatChartDispExt1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblShowSoledMsg;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseThis;
        private SeatMaDll.BHDirectionBtPanel bhDirectionBtPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxH;
        private System.Windows.Forms.PictureBox pictureBoxHH;
        private System.Windows.Forms.PictureBox pictureBoxMM;
        private System.Windows.Forms.PictureBox pictureBoxM;
        private System.Windows.Forms.Timer timer_DateTime;


    }
}


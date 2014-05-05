namespace WinFormUI.SaleTicket
{
    partial class frmReservationOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReservationOut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPQ = new System.Windows.Forms.CheckBox();
            this.chkZP = new System.Windows.Forms.CheckBox();
            this.btnAddPQ = new System.Windows.Forms.Button();
            this.btnPQReset = new System.Windows.Forms.Button();
            this.btnZPReset = new System.Windows.Forms.Button();
            this.btnAddZP = new System.Windows.Forms.Button();
            this.btnSetGruopPrice = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnOutAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvTicketList = new System.Windows.Forms.DataGridView();
            this.ReservationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.票种 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.座位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支付方式 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HasSetVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblShowPlanTime = new System.Windows.Forms.Label();
            this.lblShowPlanDate = new System.Windows.Forms.Label();
            this.lblHallName = new System.Windows.Forms.Label();
            this.lblShowPlanName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.chkPQ);
            this.groupBox1.Controls.Add(this.chkZP);
            this.groupBox1.Controls.Add(this.btnAddPQ);
            this.groupBox1.Controls.Add(this.btnPQReset);
            this.groupBox1.Controls.Add(this.btnZPReset);
            this.groupBox1.Controls.Add(this.btnAddZP);
            this.groupBox1.Controls.Add(this.btnSetGruopPrice);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnCancelAll);
            this.groupBox1.Controls.Add(this.btnOutAll);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOut);
            this.groupBox1.Controls.Add(this.txtCardNum);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.dgvTicketList);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.lblShowPlanTime);
            this.groupBox1.Controls.Add(this.lblShowPlanDate);
            this.groupBox1.Controls.Add(this.lblHallName);
            this.groupBox1.Controls.Add(this.lblShowPlanName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkPQ
            // 
            this.chkPQ.AutoSize = true;
            this.chkPQ.Enabled = false;
            this.chkPQ.Location = new System.Drawing.Point(348, 223);
            this.chkPQ.Name = "chkPQ";
            this.chkPQ.Size = new System.Drawing.Size(15, 14);
            this.chkPQ.TabIndex = 122;
            this.chkPQ.UseVisualStyleBackColor = true;
            // 
            // chkZP
            // 
            this.chkZP.AutoSize = true;
            this.chkZP.Enabled = false;
            this.chkZP.Location = new System.Drawing.Point(348, 193);
            this.chkZP.Name = "chkZP";
            this.chkZP.Size = new System.Drawing.Size(15, 14);
            this.chkZP.TabIndex = 122;
            this.chkZP.UseVisualStyleBackColor = true;
            this.chkZP.CheckedChanged += new System.EventHandler(this.chkZP_CheckedChanged);
            // 
            // btnAddPQ
            // 
            this.btnAddPQ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPQ.BackgroundImage")));
            this.btnAddPQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddPQ.Enabled = false;
            this.btnAddPQ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPQ.Location = new System.Drawing.Point(364, 218);
            this.btnAddPQ.Name = "btnAddPQ";
            this.btnAddPQ.Size = new System.Drawing.Size(68, 23);
            this.btnAddPQ.TabIndex = 121;
            this.btnAddPQ.Text = "设置票券";
            this.btnAddPQ.UseVisualStyleBackColor = true;
            this.btnAddPQ.Click += new System.EventHandler(this.btnAddPQ_Click);
            // 
            // btnPQReset
            // 
            this.btnPQReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPQReset.BackgroundImage")));
            this.btnPQReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPQReset.Enabled = false;
            this.btnPQReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPQReset.Location = new System.Drawing.Point(438, 218);
            this.btnPQReset.Name = "btnPQReset";
            this.btnPQReset.Size = new System.Drawing.Size(44, 23);
            this.btnPQReset.TabIndex = 121;
            this.btnPQReset.Text = "重置";
            this.btnPQReset.UseVisualStyleBackColor = true;
            this.btnPQReset.Click += new System.EventHandler(this.btnZPReset_Click);
            // 
            // btnZPReset
            // 
            this.btnZPReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZPReset.BackgroundImage")));
            this.btnZPReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZPReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZPReset.Location = new System.Drawing.Point(438, 188);
            this.btnZPReset.Name = "btnZPReset";
            this.btnZPReset.Size = new System.Drawing.Size(44, 23);
            this.btnZPReset.TabIndex = 121;
            this.btnZPReset.Text = "重置";
            this.btnZPReset.UseVisualStyleBackColor = true;
            this.btnZPReset.Click += new System.EventHandler(this.btnZPReset_Click);
            // 
            // btnAddZP
            // 
            this.btnAddZP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddZP.BackgroundImage")));
            this.btnAddZP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddZP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddZP.Location = new System.Drawing.Point(364, 188);
            this.btnAddZP.Name = "btnAddZP";
            this.btnAddZP.Size = new System.Drawing.Size(68, 23);
            this.btnAddZP.TabIndex = 121;
            this.btnAddZP.Text = "填写支票";
            this.btnAddZP.UseVisualStyleBackColor = true;
            this.btnAddZP.Click += new System.EventHandler(this.btnAddZP_Click);
            // 
            // btnSetGruopPrice
            // 
            this.btnSetGruopPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetGruopPrice.BackgroundImage")));
            this.btnSetGruopPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetGruopPrice.Enabled = false;
            this.btnSetGruopPrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGruopPrice.Location = new System.Drawing.Point(364, 157);
            this.btnSetGruopPrice.Name = "btnSetGruopPrice";
            this.btnSetGruopPrice.Size = new System.Drawing.Size(68, 23);
            this.btnSetGruopPrice.TabIndex = 121;
            this.btnSetGruopPrice.Text = "设置团体价";
            this.btnSetGruopPrice.UseVisualStyleBackColor = true;
            this.btnSetGruopPrice.Click += new System.EventHandler(this.btnSetGruopPrice_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(357, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelAll.BackgroundImage")));
            this.btnCancelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelAll.Location = new System.Drawing.Point(270, 252);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAll.TabIndex = 4;
            this.btnCancelAll.Text = "全部取消";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // btnOutAll
            // 
            this.btnOutAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOutAll.BackgroundImage")));
            this.btnOutAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOutAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutAll.Location = new System.Drawing.Point(189, 252);
            this.btnOutAll.Name = "btnOutAll";
            this.btnOutAll.Size = new System.Drawing.Size(75, 23);
            this.btnOutAll.TabIndex = 3;
            this.btnOutAll.Text = "全部出票";
            this.btnOutAll.UseVisualStyleBackColor = true;
            this.btnOutAll.Click += new System.EventHandler(this.btnOutAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(107, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消预定";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOut
            // 
            this.btnOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOut.BackgroundImage")));
            this.btnOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOut.Location = new System.Drawing.Point(26, 252);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 1;
            this.btnOut.Text = "出票";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtCardNum
            // 
            this.txtCardNum.Enabled = false;
            this.txtCardNum.Location = new System.Drawing.Point(348, 130);
            this.txtCardNum.MaxLength = 18;
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(114, 21);
            this.txtCardNum.TabIndex = 118;
            this.txtCardNum.Text = "000000000000000000";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(348, 82);
            this.txtName.MaxLength = 16;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(60, 21);
            this.txtName.TabIndex = 108;
            // 
            // dgvTicketList
            // 
            this.dgvTicketList.AllowUserToAddRows = false;
            this.dgvTicketList.AllowUserToDeleteRows = false;
            this.dgvTicketList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTicketList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTicketList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReservationId,
            this.SeatStatusId,
            this.TicketType,
            this.票种,
            this.座位,
            this.价格,
            this.支付方式,
            this.HasSetVoucher});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTicketList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTicketList.Location = new System.Drawing.Point(15, 76);
            this.dgvTicketList.Name = "dgvTicketList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTicketList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTicketList.RowTemplate.Height = 23;
            this.dgvTicketList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTicketList.Size = new System.Drawing.Size(325, 165);
            this.dgvTicketList.TabIndex = 120;
            this.dgvTicketList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTicketList_CellMouseLeave);
            this.dgvTicketList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTicketList_CellValueChanged);
            // 
            // ReservationId
            // 
            this.ReservationId.DataPropertyName = "ReservationId";
            this.ReservationId.HeaderText = "ReservationId";
            this.ReservationId.Name = "ReservationId";
            this.ReservationId.Visible = false;
            this.ReservationId.Width = 108;
            // 
            // SeatStatusId
            // 
            this.SeatStatusId.DataPropertyName = "SeatStatusId";
            this.SeatStatusId.HeaderText = "SeatStatusId";
            this.SeatStatusId.Name = "SeatStatusId";
            this.SeatStatusId.Visible = false;
            this.SeatStatusId.Width = 102;
            // 
            // TicketType
            // 
            this.TicketType.DataPropertyName = "TicketType";
            this.TicketType.HeaderText = "TicketType";
            this.TicketType.Name = "TicketType";
            this.TicketType.Visible = false;
            this.TicketType.Width = 90;
            // 
            // 票种
            // 
            this.票种.DataPropertyName = "票种";
            this.票种.HeaderText = "票种";
            this.票种.Name = "票种";
            this.票种.ReadOnly = true;
            this.票种.Width = 54;
            // 
            // 座位
            // 
            this.座位.DataPropertyName = "SeatNumber";
            this.座位.HeaderText = "座位";
            this.座位.Name = "座位";
            this.座位.ReadOnly = true;
            this.座位.Width = 54;
            // 
            // 价格
            // 
            this.价格.DataPropertyName = "TicketPrice";
            this.价格.HeaderText = "价格";
            this.价格.Name = "价格";
            this.价格.ReadOnly = true;
            this.价格.Width = 54;
            // 
            // 支付方式
            // 
            this.支付方式.DataPropertyName = "支付方式";
            this.支付方式.HeaderText = "支付方式";
            this.支付方式.Items.AddRange(new object[] {
            "现金",
            "优惠券",
            "兑换券",
            "代用券",
            "会员卡",
            "支票",
            "会员卡支付",
            "积分",
            "赠票"});
            this.支付方式.Name = "支付方式";
            this.支付方式.Width = 59;
            // 
            // HasSetVoucher
            // 
            this.HasSetVoucher.DataPropertyName = "HasSetVoucher";
            this.HasSetVoucher.HeaderText = "HasSetVoucher";
            this.HasSetVoucher.Name = "HasSetVoucher";
            this.HasSetVoucher.Visible = false;
            this.HasSetVoucher.Width = 108;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Location = new System.Drawing.Point(402, 50);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(11, 12);
            this.lblCount.TabIndex = 111;
            this.lblCount.Text = "0";
            // 
            // lblShowPlanTime
            // 
            this.lblShowPlanTime.AutoSize = true;
            this.lblShowPlanTime.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanTime.Location = new System.Drawing.Point(258, 50);
            this.lblShowPlanTime.Name = "lblShowPlanTime";
            this.lblShowPlanTime.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanTime.TabIndex = 113;
            // 
            // lblShowPlanDate
            // 
            this.lblShowPlanDate.AutoSize = true;
            this.lblShowPlanDate.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanDate.Location = new System.Drawing.Point(258, 25);
            this.lblShowPlanDate.Name = "lblShowPlanDate";
            this.lblShowPlanDate.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanDate.TabIndex = 115;
            // 
            // lblHallName
            // 
            this.lblHallName.AutoSize = true;
            this.lblHallName.BackColor = System.Drawing.Color.Transparent;
            this.lblHallName.Location = new System.Drawing.Point(65, 50);
            this.lblHallName.Name = "lblHallName";
            this.lblHallName.Size = new System.Drawing.Size(0, 12);
            this.lblHallName.TabIndex = 114;
            // 
            // lblShowPlanName
            // 
            this.lblShowPlanName.AutoSize = true;
            this.lblShowPlanName.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanName.Location = new System.Drawing.Point(65, 25);
            this.lblShowPlanName.Name = "lblShowPlanName";
            this.lblShowPlanName.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanName.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 104;
            this.label2.Text = "厅号：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(346, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 102;
            this.label15.Text = "身份证号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(346, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 106;
            this.label11.Text = "姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(355, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 107;
            this.label5.Text = "数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(187, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 103;
            this.label4.Text = "场    次：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(187, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 105;
            this.label3.Text = "预定日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 119;
            this.label1.Text = "影片：";
            // 
            // frmReservationOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(521, 315);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmReservationOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "预定出票";
            this.Load += new System.EventHandler(this.frmReservationOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvTicketList;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblShowPlanTime;
        private System.Windows.Forms.Label lblShowPlanDate;
        private System.Windows.Forms.Label lblHallName;
        private System.Windows.Forms.Label lblShowPlanName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnOutAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnAddPQ;
        private System.Windows.Forms.Button btnSetGruopPrice;
        private System.Windows.Forms.Button btnAddZP;
        private System.Windows.Forms.CheckBox chkPQ;
        private System.Windows.Forms.CheckBox chkZP;
        private System.Windows.Forms.Button btnZPReset;
        private System.Windows.Forms.Button btnPQReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn 票种;
        private System.Windows.Forms.DataGridViewTextBoxColumn 座位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格;
        private System.Windows.Forms.DataGridViewComboBoxColumn 支付方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasSetVoucher;
    }
}
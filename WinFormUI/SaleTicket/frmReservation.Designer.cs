namespace WinFormUI.SaleTicket
{
    partial class frmReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReservation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtRPWD = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnVipRes = new System.Windows.Forms.Button();
            this.dgvTicketList = new System.Windows.Forms.DataGridView();
            this.座位状态ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.场次ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.票种 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.座位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.售票类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblShowPlanTime = new System.Windows.Forms.Label();
            this.lblShowPlanDate = new System.Windows.Forms.Label();
            this.lblHallName = new System.Windows.Forms.Label();
            this.lblShowPlanName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.txtCardNum);
            this.groupBox1.Controls.Add(this.txtTelephone);
            this.groupBox1.Controls.Add(this.txtRPWD);
            this.groupBox1.Controls.Add(this.txtPWD);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Controls.Add(this.btnVipRes);
            this.groupBox1.Controls.Add(this.dgvTicketList);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.lblShowPlanTime);
            this.groupBox1.Controls.Add(this.lblShowPlanDate);
            this.groupBox1.Controls.Add(this.lblHallName);
            this.groupBox1.Controls.Add(this.lblShowPlanName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 269);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtCardNum
            // 
            this.txtCardNum.Location = new System.Drawing.Point(327, 179);
            this.txtCardNum.MaxLength = 18;
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(120, 21);
            this.txtCardNum.TabIndex = 4;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(327, 156);
            this.txtTelephone.MaxLength = 11;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(87, 21);
            this.txtTelephone.TabIndex = 3;
            // 
            // txtRPWD
            // 
            this.txtRPWD.Location = new System.Drawing.Point(327, 133);
            this.txtRPWD.MaxLength = 16;
            this.txtRPWD.Name = "txtRPWD";
            this.txtRPWD.Size = new System.Drawing.Size(120, 21);
            this.txtRPWD.TabIndex = 2;
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(327, 110);
            this.txtPWD.MaxLength = 16;
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(120, 21);
            this.txtPWD.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(327, 86);
            this.txtName.MaxLength = 16;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(60, 21);
            this.txtName.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(363, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYes.BackgroundImage")));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Location = new System.Drawing.Point(282, 229);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 5;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnVipRes
            // 
            this.btnVipRes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVipRes.BackgroundImage")));
            this.btnVipRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVipRes.Enabled = false;
            this.btnVipRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVipRes.Location = new System.Drawing.Point(40, 229);
            this.btnVipRes.Name = "btnVipRes";
            this.btnVipRes.Size = new System.Drawing.Size(75, 23);
            this.btnVipRes.TabIndex = 99;
            this.btnVipRes.Text = "会员订票";
            this.btnVipRes.UseVisualStyleBackColor = true;
            // 
            // dgvTicketList
            // 
            this.dgvTicketList.AllowUserToAddRows = false;
            this.dgvTicketList.AllowUserToDeleteRows = false;
            this.dgvTicketList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTicketList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.座位状态ID,
            this.场次ID,
            this.票种,
            this.座位,
            this.价格,
            this.售票类型});
            this.dgvTicketList.Location = new System.Drawing.Point(7, 73);
            this.dgvTicketList.Name = "dgvTicketList";
            this.dgvTicketList.RowTemplate.Height = 23;
            this.dgvTicketList.Size = new System.Drawing.Size(257, 132);
            this.dgvTicketList.TabIndex = 99;
            this.dgvTicketList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTicketList_CellMouseLeave);
            this.dgvTicketList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTicketList_CellValueChanged);
            // 
            // 座位状态ID
            // 
            this.座位状态ID.DataPropertyName = "座位状态ID";
            this.座位状态ID.HeaderText = "座位状态ID";
            this.座位状态ID.Name = "座位状态ID";
            this.座位状态ID.Visible = false;
            // 
            // 场次ID
            // 
            this.场次ID.DataPropertyName = "场次ID";
            this.场次ID.HeaderText = "场次ID";
            this.场次ID.Name = "场次ID";
            this.场次ID.ReadOnly = true;
            this.场次ID.Visible = false;
            // 
            // 票种
            // 
            this.票种.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.票种.DataPropertyName = "票种";
            this.票种.HeaderText = "票种";
            this.票种.Items.AddRange(new object[] {
            "零售",
            "学生",
            "团体"});
            this.票种.Name = "票种";
            this.票种.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.票种.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 座位
            // 
            this.座位.DataPropertyName = "座位";
            this.座位.HeaderText = "座位";
            this.座位.Name = "座位";
            this.座位.ReadOnly = true;
            // 
            // 价格
            // 
            this.价格.DataPropertyName = "价格";
            this.价格.HeaderText = "价格";
            this.价格.Name = "价格";
            this.价格.ReadOnly = true;
            // 
            // 售票类型
            // 
            this.售票类型.DataPropertyName = "售票类型";
            this.售票类型.HeaderText = "售票类型";
            this.售票类型.Name = "售票类型";
            this.售票类型.Visible = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCount.Location = new System.Drawing.Point(394, 47);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(11, 12);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0";
            // 
            // lblShowPlanTime
            // 
            this.lblShowPlanTime.AutoSize = true;
            this.lblShowPlanTime.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanTime.Location = new System.Drawing.Point(250, 47);
            this.lblShowPlanTime.Name = "lblShowPlanTime";
            this.lblShowPlanTime.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanTime.TabIndex = 1;
            // 
            // lblShowPlanDate
            // 
            this.lblShowPlanDate.AutoSize = true;
            this.lblShowPlanDate.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanDate.Location = new System.Drawing.Point(250, 22);
            this.lblShowPlanDate.Name = "lblShowPlanDate";
            this.lblShowPlanDate.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanDate.TabIndex = 1;
            // 
            // lblHallName
            // 
            this.lblHallName.AutoSize = true;
            this.lblHallName.BackColor = System.Drawing.Color.Transparent;
            this.lblHallName.Location = new System.Drawing.Point(57, 47);
            this.lblHallName.Name = "lblHallName";
            this.lblHallName.Size = new System.Drawing.Size(0, 12);
            this.lblHallName.TabIndex = 1;
            // 
            // lblShowPlanName
            // 
            this.lblShowPlanName.AutoSize = true;
            this.lblShowPlanName.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanName.Location = new System.Drawing.Point(57, 22);
            this.lblShowPlanName.Name = "lblShowPlanName";
            this.lblShowPlanName.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "厅号：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Location = new System.Drawing.Point(267, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "身份证号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Location = new System.Drawing.Point(291, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "电话";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Location = new System.Drawing.Point(267, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "确认密码";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Location = new System.Drawing.Point(291, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "密码";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Location = new System.Drawing.Point(291, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(347, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(179, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "场    次：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(179, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "预定日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "影片：";
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(493, 294);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "预定";
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblShowPlanTime;
        private System.Windows.Forms.Label lblShowPlanDate;
        private System.Windows.Forms.Label lblHallName;
        private System.Windows.Forms.Label lblShowPlanName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnVipRes;
        private System.Windows.Forms.DataGridView dgvTicketList;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtRPWD;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 座位状态ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 场次ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn 票种;
        private System.Windows.Forms.DataGridViewTextBoxColumn 座位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 售票类型;
    }
}
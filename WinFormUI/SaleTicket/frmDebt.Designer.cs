namespace WinFormUI.SaleTicket
{
    partial class frmDebt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebt));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblShowPlanInfo = new System.Windows.Forms.Label();
            this.lblTicketInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combCustomerType = new System.Windows.Forms.ComboBox();
            this.btnSelCustomer = new System.Windows.Forms.Button();
            this.btnSetGroupPrice = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
            this.lblGroupPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBankBranch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDebtList = new System.Windows.Forms.DataGridView();
            this.日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.购票张数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开户银行 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支票号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收款员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Controls.Add(this.lblShowPlanInfo);
            this.groupBox1.Controls.Add(this.lblTicketInfo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dgvDebtList);
            this.groupBox1.Controls.Add(this.lblCustomerId);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 364);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(564, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYes.BackgroundImage")));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Location = new System.Drawing.Point(483, 330);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblShowPlanInfo
            // 
            this.lblShowPlanInfo.AutoSize = true;
            this.lblShowPlanInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPlanInfo.Location = new System.Drawing.Point(23, 330);
            this.lblShowPlanInfo.Name = "lblShowPlanInfo";
            this.lblShowPlanInfo.Size = new System.Drawing.Size(287, 12);
            this.lblShowPlanInfo.TabIndex = 2;
            this.lblShowPlanInfo.Text = "日期:2011-12-15 奥斯卡厅 场次:10:15 影片:巴别塔";
            // 
            // lblTicketInfo
            // 
            this.lblTicketInfo.AutoSize = true;
            this.lblTicketInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketInfo.Location = new System.Drawing.Point(23, 303);
            this.lblTicketInfo.Name = "lblTicketInfo";
            this.lblTicketInfo.Size = new System.Drawing.Size(245, 12);
            this.lblTicketInfo.TabIndex = 2;
            this.lblTicketInfo.Text = "票种:团体 张数:12 单价:10元 总金额:120元";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.combCustomerType);
            this.groupBox2.Controls.Add(this.btnSelCustomer);
            this.groupBox2.Controls.Add(this.btnSetGroupPrice);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtTelephone);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtChequeNumber);
            this.groupBox2.Controls.Add(this.lblGroupPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBankBranch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // combCustomerType
            // 
            this.combCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCustomerType.FormattingEnabled = true;
            this.combCustomerType.Location = new System.Drawing.Point(268, 51);
            this.combCustomerType.Name = "combCustomerType";
            this.combCustomerType.Size = new System.Drawing.Size(106, 20);
            this.combCustomerType.TabIndex = 4;
            // 
            // btnSelCustomer
            // 
            this.btnSelCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelCustomer.BackgroundImage")));
            this.btnSelCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelCustomer.Location = new System.Drawing.Point(248, 21);
            this.btnSelCustomer.Name = "btnSelCustomer";
            this.btnSelCustomer.Size = new System.Drawing.Size(55, 23);
            this.btnSelCustomer.TabIndex = 3;
            this.btnSelCustomer.Text = "查找";
            this.btnSelCustomer.UseVisualStyleBackColor = true;
            this.btnSelCustomer.Click += new System.EventHandler(this.btnSelCustomer_Click);
            // 
            // btnSetGroupPrice
            // 
            this.btnSetGroupPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetGroupPrice.BackgroundImage")));
            this.btnSetGroupPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetGroupPrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGroupPrice.Location = new System.Drawing.Point(527, 84);
            this.btnSetGroupPrice.Name = "btnSetGroupPrice";
            this.btnSetGroupPrice.Size = new System.Drawing.Size(75, 23);
            this.btnSetGroupPrice.TabIndex = 2;
            this.btnSetGroupPrice.Text = "设置团体价";
            this.btnSetGroupPrice.UseVisualStyleBackColor = true;
            this.btnSetGroupPrice.Click += new System.EventHandler(this.btnSetGroupPrice_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Location = new System.Drawing.Point(126, 84);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Location = new System.Drawing.Point(29, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(526, 19);
            this.txtTelephone.MaxLength = 20;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(118, 21);
            this.txtTelephone.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(363, 20);
            this.txtContact.MaxLength = 10;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(82, 21);
            this.txtContact.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "联系电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "客户类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "联系人";
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(436, 50);
            this.txtChequeNumber.MaxLength = 100;
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Size = new System.Drawing.Size(208, 21);
            this.txtChequeNumber.TabIndex = 1;
            // 
            // lblGroupPrice
            // 
            this.lblGroupPrice.AutoSize = true;
            this.lblGroupPrice.Location = new System.Drawing.Point(447, 89);
            this.lblGroupPrice.Name = "lblGroupPrice";
            this.lblGroupPrice.Size = new System.Drawing.Size(41, 12);
            this.lblGroupPrice.TabIndex = 0;
            this.lblGroupPrice.Text = "0.00元";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "团体价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "支票号";
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.Location = new System.Drawing.Point(74, 48);
            this.txtBankBranch.MaxLength = 20;
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Size = new System.Drawing.Size(127, 21);
            this.txtBankBranch.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "开户银行";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(74, 21);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(163, 21);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位名称";
            // 
            // dgvDebtList
            // 
            this.dgvDebtList.AllowUserToAddRows = false;
            this.dgvDebtList.AllowUserToDeleteRows = false;
            this.dgvDebtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDebtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebtList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.日期,
            this.单位名称,
            this.联系人,
            this.购票张数,
            this.金额,
            this.开户银行,
            this.支票号,
            this.联系电话,
            this.收款员});
            this.dgvDebtList.Location = new System.Drawing.Point(7, 21);
            this.dgvDebtList.Name = "dgvDebtList";
            this.dgvDebtList.RowTemplate.Height = 23;
            this.dgvDebtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebtList.Size = new System.Drawing.Size(658, 150);
            this.dgvDebtList.TabIndex = 0;
            // 
            // 日期
            // 
            this.日期.DataPropertyName = "日期";
            this.日期.HeaderText = "日期";
            this.日期.Name = "日期";
            this.日期.ReadOnly = true;
            this.日期.Width = 54;
            // 
            // 单位名称
            // 
            this.单位名称.DataPropertyName = "单位名称";
            this.单位名称.HeaderText = "单位名称";
            this.单位名称.Name = "单位名称";
            this.单位名称.ReadOnly = true;
            this.单位名称.Width = 78;
            // 
            // 联系人
            // 
            this.联系人.DataPropertyName = "联系人";
            this.联系人.HeaderText = "联系人";
            this.联系人.Name = "联系人";
            this.联系人.ReadOnly = true;
            this.联系人.Width = 66;
            // 
            // 购票张数
            // 
            this.购票张数.DataPropertyName = "购票张数";
            this.购票张数.HeaderText = "购票张数";
            this.购票张数.Name = "购票张数";
            this.购票张数.ReadOnly = true;
            this.购票张数.Width = 78;
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "金额";
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Width = 54;
            // 
            // 开户银行
            // 
            this.开户银行.DataPropertyName = "开户银行";
            this.开户银行.HeaderText = "开户银行";
            this.开户银行.Name = "开户银行";
            this.开户银行.ReadOnly = true;
            this.开户银行.Width = 78;
            // 
            // 支票号
            // 
            this.支票号.DataPropertyName = "支票号";
            this.支票号.HeaderText = "支票号";
            this.支票号.Name = "支票号";
            this.支票号.ReadOnly = true;
            this.支票号.Width = 66;
            // 
            // 联系电话
            // 
            this.联系电话.DataPropertyName = "联系电话";
            this.联系电话.HeaderText = "联系电话";
            this.联系电话.Name = "联系电话";
            this.联系电话.ReadOnly = true;
            this.联系电话.Width = 78;
            // 
            // 收款员
            // 
            this.收款员.DataPropertyName = "收款员";
            this.收款员.HeaderText = "收款员";
            this.收款员.Name = "收款员";
            this.收款员.ReadOnly = true;
            this.收款员.Width = 66;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(387, 341);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(0, 12);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Visible = false;
            // 
            // frmDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 382);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDebt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "支票支付";
            this.Load += new System.EventHandler(this.frmDebt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblShowPlanInfo;
        private System.Windows.Forms.Label lblTicketInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChequeNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBankBranch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDebtList;
        private System.Windows.Forms.Label lblGroupPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetGroupPrice;
        private System.Windows.Forms.Button btnSelCustomer;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 购票张数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开户银行;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支票号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收款员;
        private System.Windows.Forms.ComboBox combCustomerType;
        private System.Windows.Forms.Label label7;
    }
}
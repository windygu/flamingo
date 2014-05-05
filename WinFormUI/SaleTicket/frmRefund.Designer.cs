namespace WinFormUI.SaleTicket
{
    partial class frmRefund
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefund));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnDelBarCode = new System.Windows.Forms.Button();
            this.btnAddBarCode = new System.Windows.Forms.Button();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.条形码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.票类 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.座位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShowPlanStartTime = new System.Windows.Forms.Label();
            this.lblShowPlanHall = new System.Windows.Forms.Label();
            this.lblShowPlanDate = new System.Windows.Forms.Label();
            this.lblShowPlanName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtBarCode);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnRefund);
            this.groupBox1.Controls.Add(this.btnDelBarCode);
            this.groupBox1.Controls.Add(this.btnAddBarCode);
            this.groupBox1.Controls.Add(this.dgvTickets);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblShowPlanStartTime);
            this.groupBox1.Controls.Add(this.lblShowPlanHall);
            this.groupBox1.Controls.Add(this.lblShowPlanDate);
            this.groupBox1.Controls.Add(this.lblShowPlanName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(387, 123);
            this.txtBarCode.MaxLength = 20;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(140, 21);
            this.txtBarCode.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(292, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefund.BackgroundImage")));
            this.btnRefund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefund.Location = new System.Drawing.Point(183, 248);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(93, 36);
            this.btnRefund.TabIndex = 2;
            this.btnRefund.Text = "退票";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnDelBarCode
            // 
            this.btnDelBarCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelBarCode.BackgroundImage")));
            this.btnDelBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelBarCode.Location = new System.Drawing.Point(386, 179);
            this.btnDelBarCode.Name = "btnDelBarCode";
            this.btnDelBarCode.Size = new System.Drawing.Size(75, 23);
            this.btnDelBarCode.TabIndex = 2;
            this.btnDelBarCode.Text = "删除";
            this.btnDelBarCode.UseVisualStyleBackColor = true;
            this.btnDelBarCode.Click += new System.EventHandler(this.btnDelBarCode_Click);
            // 
            // btnAddBarCode
            // 
            this.btnAddBarCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBarCode.BackgroundImage")));
            this.btnAddBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBarCode.Location = new System.Drawing.Point(386, 150);
            this.btnAddBarCode.Name = "btnAddBarCode";
            this.btnAddBarCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddBarCode.TabIndex = 2;
            this.btnAddBarCode.Text = "添加";
            this.btnAddBarCode.UseVisualStyleBackColor = true;
            this.btnAddBarCode.Click += new System.EventHandler(this.btnAddBarCode_Click);
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.条形码,
            this.票类,
            this.座位,
            this.价格});
            this.dgvTickets.Location = new System.Drawing.Point(6, 43);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowTemplate.Height = 23;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(374, 183);
            this.dgvTickets.TabIndex = 1;
            // 
            // 条形码
            // 
            this.条形码.DataPropertyName = "条形码";
            this.条形码.HeaderText = "条形码";
            this.条形码.Name = "条形码";
            this.条形码.ReadOnly = true;
            this.条形码.Width = 66;
            // 
            // 票类
            // 
            this.票类.DataPropertyName = "票类";
            this.票类.HeaderText = "票类";
            this.票类.Name = "票类";
            this.票类.ReadOnly = true;
            this.票类.Width = 54;
            // 
            // 座位
            // 
            this.座位.DataPropertyName = "座位";
            this.座位.HeaderText = "座位";
            this.座位.Name = "座位";
            this.座位.ReadOnly = true;
            this.座位.Width = 54;
            // 
            // 价格
            // 
            this.价格.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.价格.DataPropertyName = "价格";
            this.价格.HeaderText = "价格";
            this.价格.Name = "价格";
            this.价格.ReadOnly = true;
            this.价格.Width = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(408, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "请输入票面条形码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(441, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "场次：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(312, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "厅号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(172, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "日期：";
            // 
            // lblShowPlanStartTime
            // 
            this.lblShowPlanStartTime.AutoSize = true;
            this.lblShowPlanStartTime.Location = new System.Drawing.Point(483, 18);
            this.lblShowPlanStartTime.Name = "lblShowPlanStartTime";
            this.lblShowPlanStartTime.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanStartTime.TabIndex = 0;
            // 
            // lblShowPlanHall
            // 
            this.lblShowPlanHall.AutoSize = true;
            this.lblShowPlanHall.Location = new System.Drawing.Point(354, 18);
            this.lblShowPlanHall.Name = "lblShowPlanHall";
            this.lblShowPlanHall.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanHall.TabIndex = 0;
            // 
            // lblShowPlanDate
            // 
            this.lblShowPlanDate.AutoSize = true;
            this.lblShowPlanDate.Location = new System.Drawing.Point(212, 18);
            this.lblShowPlanDate.Name = "lblShowPlanDate";
            this.lblShowPlanDate.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanDate.TabIndex = 0;
            // 
            // lblShowPlanName
            // 
            this.lblShowPlanName.AutoSize = true;
            this.lblShowPlanName.Location = new System.Drawing.Point(55, 17);
            this.lblShowPlanName.Name = "lblShowPlanName";
            this.lblShowPlanName.Size = new System.Drawing.Size(0, 12);
            this.lblShowPlanName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影片：";
            // 
            // frmRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 315);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退票";
            this.Load += new System.EventHandler(this.frmRefund_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblShowPlanStartTime;
        private System.Windows.Forms.Label lblShowPlanHall;
        private System.Windows.Forms.Label lblShowPlanDate;
        private System.Windows.Forms.Label lblShowPlanName;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnDelBarCode;
        private System.Windows.Forms.Button btnAddBarCode;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn 条形码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 票类;
        private System.Windows.Forms.DataGridViewTextBoxColumn 座位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格;
    }
}
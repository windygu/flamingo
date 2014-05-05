namespace WinFormUI.SaleTicket
{
    partial class frmVoucherTickets
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTicketList = new System.Windows.Forms.DataGridView();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblVoucherMsg = new System.Windows.Forms.Label();
            this.TicketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.票种 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.座位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.票券 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.面值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.补票面差额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合计 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblVoucherMsg);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Controls.Add(this.dgvTicketList);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvTicketList
            // 
            this.dgvTicketList.AllowUserToAddRows = false;
            this.dgvTicketList.AllowUserToDeleteRows = false;
            this.dgvTicketList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTicketList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketId,
            this.票种,
            this.座位,
            this.价格,
            this.票券,
            this.面值,
            this.补票面差额,
            this.合计,
            this.操作});
            this.dgvTicketList.Location = new System.Drawing.Point(7, 33);
            this.dgvTicketList.Name = "dgvTicketList";
            this.dgvTicketList.ReadOnly = true;
            this.dgvTicketList.RowTemplate.Height = 23;
            this.dgvTicketList.Size = new System.Drawing.Size(537, 178);
            this.dgvTicketList.TabIndex = 0;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(277, 258);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "票券换票";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(20, 218);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(71, 12);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "总金额:80元";
            // 
            // lblVoucherMsg
            // 
            this.lblVoucherMsg.AutoSize = true;
            this.lblVoucherMsg.Location = new System.Drawing.Point(20, 242);
            this.lblVoucherMsg.Name = "lblVoucherMsg";
            this.lblVoucherMsg.Size = new System.Drawing.Size(179, 12);
            this.lblVoucherMsg.TabIndex = 2;
            this.lblVoucherMsg.Text = "票券面值:60元 补票面金额:20元";
            // 
            // TicketId
            // 
            this.TicketId.DataPropertyName = "TicketId";
            this.TicketId.HeaderText = "TicketId";
            this.TicketId.Name = "TicketId";
            this.TicketId.ReadOnly = true;
            this.TicketId.Visible = false;
            this.TicketId.Width = 78;
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
            this.座位.DataPropertyName = "座位";
            this.座位.HeaderText = "座位";
            this.座位.Name = "座位";
            this.座位.ReadOnly = true;
            this.座位.Width = 54;
            // 
            // 价格
            // 
            this.价格.DataPropertyName = "价格";
            this.价格.HeaderText = "价格";
            this.价格.Name = "价格";
            this.价格.ReadOnly = true;
            this.价格.Width = 54;
            // 
            // 票券
            // 
            this.票券.DataPropertyName = "票券";
            this.票券.HeaderText = "票券";
            this.票券.Name = "票券";
            this.票券.ReadOnly = true;
            this.票券.Width = 54;
            // 
            // 面值
            // 
            this.面值.DataPropertyName = "面值";
            this.面值.HeaderText = "面值";
            this.面值.Name = "面值";
            this.面值.ReadOnly = true;
            this.面值.Width = 54;
            // 
            // 补票面差额
            // 
            this.补票面差额.DataPropertyName = "补票面差额";
            this.补票面差额.HeaderText = "补票面金额";
            this.补票面差额.Name = "补票面差额";
            this.补票面差额.ReadOnly = true;
            this.补票面差额.Width = 90;
            // 
            // 合计
            // 
            this.合计.DataPropertyName = "合计";
            this.合计.HeaderText = "合计";
            this.合计.Name = "合计";
            this.合计.ReadOnly = true;
            this.合计.Width = 54;
            // 
            // 操作
            // 
            this.操作.HeaderText = "操作";
            this.操作.Name = "操作";
            this.操作.ReadOnly = true;
            this.操作.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.操作.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.操作.Text = "添加票券";
            this.操作.ToolTipText = "添加票券";
            this.操作.UseColumnTextForButtonValue = true;
            this.操作.Width = 54;
            // 
            // frmVoucherTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 312);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVoucherTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "票券换票";
            this.Load += new System.EventHandler(this.frmVoucherTickets_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTicketList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVoucherMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketId;
        private System.Windows.Forms.DataGridViewTextBoxColumn 票种;
        private System.Windows.Forms.DataGridViewTextBoxColumn 座位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 票券;
        private System.Windows.Forms.DataGridViewTextBoxColumn 面值;
        private System.Windows.Forms.DataGridViewTextBoxColumn 补票面差额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合计;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
    }
}
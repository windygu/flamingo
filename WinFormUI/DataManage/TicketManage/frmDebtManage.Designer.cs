namespace Flamingo.TicketManage
{
    partial class frmDebtManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebtManage));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAccountant = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTickets = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBankBranch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCasher = new System.Windows.Forms.TextBox();
            this.dtBoughtDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtClearDate = new System.Windows.Forms.DateTimePicker();
            this.chbIsPayBack = new System.Windows.Forms.CheckBox();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(896, 50);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.txtKeyWord, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(843, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(787, 10);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(731, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(675, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(619, 10);
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(0, 299);
            this.panList.Size = new System.Drawing.Size(896, 155);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(894, 23);
            this.lblListTitle.Text = " 欠款信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(31, 78);
            this.panDetail.Size = new System.Drawing.Size(782, 129);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(780, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按客户查询:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(301, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(95, 16);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(200, 21);
            this.txtKeyWord.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel1.Controls.Add(this.txtAccountant, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTickets, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDebtId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBankBranch, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyer, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCasher, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtBoughtDate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAmount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBankAccount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtChequeNumber, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtClearDate, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.chbIsPayBack, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbCustomerName, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 104);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtAccountant
            // 
            this.txtAccountant.Location = new System.Drawing.Point(673, 30);
            this.txtAccountant.Name = "txtAccountant";
            this.txtAccountant.Size = new System.Drawing.Size(104, 21);
            this.txtAccountant.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(607, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "会    计:";
            // 
            // txtTickets
            // 
            this.txtTickets.Location = new System.Drawing.Point(673, 4);
            this.txtTickets.Name = "txtTickets";
            this.txtTickets.Size = new System.Drawing.Size(104, 21);
            this.txtTickets.TabIndex = 29;
            this.txtTickets.Validating += new System.ComponentModel.CancelEventHandler(this.txtTickets_Validating);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(607, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "购买票数:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "开户银行:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "欠款编号:";
            // 
            // txtDebtId
            // 
            this.txtDebtId.Location = new System.Drawing.Point(78, 4);
            this.txtDebtId.Name = "txtDebtId";
            this.txtDebtId.ReadOnly = true;
            this.txtDebtId.Size = new System.Drawing.Size(93, 21);
            this.txtDebtId.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "客户名称:";
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.Location = new System.Drawing.Point(78, 30);
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Size = new System.Drawing.Size(93, 21);
            this.txtBankBranch.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "欠 款 人:";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Location = new System.Drawing.Point(262, 30);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(117, 21);
            this.txtBuyer.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "购买日期:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "收 银 员:";
            // 
            // txtCasher
            // 
            this.txtCasher.Location = new System.Drawing.Point(471, 30);
            this.txtCasher.Name = "txtCasher";
            this.txtCasher.Size = new System.Drawing.Size(112, 21);
            this.txtCasher.TabIndex = 25;
            // 
            // dtBoughtDate
            // 
            this.dtBoughtDate.Location = new System.Drawing.Point(471, 4);
            this.dtBoughtDate.Name = "dtBoughtDate";
            this.dtBoughtDate.Size = new System.Drawing.Size(112, 21);
            this.dtBoughtDate.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "总 金 额:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(78, 56);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(93, 21);
            this.txtAmount.TabIndex = 31;
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "银行账号:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "支 票 号:";
            // 
            // txtBankAccount
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBankAccount, 5);
            this.txtBankAccount.Location = new System.Drawing.Point(78, 82);
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(503, 21);
            this.txtBankAccount.TabIndex = 26;
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(262, 56);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Size = new System.Drawing.Size(117, 21);
            this.txtChequeNumber.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(405, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 35;
            this.label14.Text = "到款日期:";
            // 
            // dtClearDate
            // 
            this.dtClearDate.Location = new System.Drawing.Point(471, 56);
            this.dtClearDate.Name = "dtClearDate";
            this.dtClearDate.Size = new System.Drawing.Size(112, 21);
            this.dtClearDate.TabIndex = 34;
            // 
            // chbIsPayBack
            // 
            this.chbIsPayBack.AutoSize = true;
            this.chbIsPayBack.Location = new System.Drawing.Point(590, 56);
            this.chbIsPayBack.Name = "chbIsPayBack";
            this.chbIsPayBack.Size = new System.Drawing.Size(72, 16);
            this.chbIsPayBack.TabIndex = 38;
            this.chbIsPayBack.Text = "是否到账";
            this.chbIsPayBack.UseVisualStyleBackColor = true;
            this.chbIsPayBack.CheckedChanged += new System.EventHandler(this.chbIsPayBack_CheckedChanged);
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(262, 4);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(117, 20);
            this.cbCustomerName.TabIndex = 39;
            // 
            // frmDebtManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(896, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDebtManage";
            this.Text = "欠款信息管理";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBankBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCasher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBankAccount;
        private System.Windows.Forms.TextBox txtAccountant;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTickets;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtBoughtDate;
        private System.Windows.Forms.TextBox txtChequeNumber;
        private System.Windows.Forms.DateTimePicker dtClearDate;
        private System.Windows.Forms.CheckBox chbIsPayBack;
        private System.Windows.Forms.ComboBox cbCustomerName;
    }
}

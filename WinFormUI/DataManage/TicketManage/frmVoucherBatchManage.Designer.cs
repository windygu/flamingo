namespace Flamingo.TicketManage
{
    partial class frmVoucherBatchManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherBatchManage));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVoucherSubTypeId = new System.Windows.Forms.ComboBox();
            this.cbIssuedBy = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVoucherBatchId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtVoucherName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSerialScope = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.dtExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbVoucherTypeId = new System.Windows.Forms.ComboBox();
            this.chbIsPrint = new System.Windows.Forms.CheckBox();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.label4);
            this.panTop.Controls.Add(this.cbSearchType);
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(910, 60);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.txtKeyWord, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            this.panTop.Controls.SetChildIndex(this.cbSearchType, 0);
            this.panTop.Controls.SetChildIndex(this.label4, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(860, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(805, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(749, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(693, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(637, 10);
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(12, 247);
            this.panList.Size = new System.Drawing.Size(910, 380);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(908, 23);
            this.lblListTitle.Text = " 票券批次信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(117, 66);
            this.panDetail.Size = new System.Drawing.Size(590, 156);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(588, 23);
            this.lblDetailTitle.Text = " 票券批次";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(300, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(151, 19);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(143, 21);
            this.txtKeyWord.TabIndex = 5;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtKeyWord_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbVoucherSubTypeId, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbIssuedBy, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtVoucherBatchId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtVoucherName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSerialScope, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUnitPrice, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtExpireDate, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalPrice, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtReleaseDate, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCustomerName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbVoucherTypeId, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chbIsPrint, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.chbIsActive, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 131);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "批次号:";
            // 
            // cbVoucherSubTypeId
            // 
            this.cbVoucherSubTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoucherSubTypeId.FormattingEnabled = true;
            this.cbVoucherSubTypeId.Location = new System.Drawing.Point(63, 82);
            this.cbVoucherSubTypeId.Name = "cbVoucherSubTypeId";
            this.cbVoucherSubTypeId.Size = new System.Drawing.Size(110, 20);
            this.cbVoucherSubTypeId.TabIndex = 74;
            // 
            // cbIssuedBy
            // 
            this.cbIssuedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIssuedBy.FormattingEnabled = true;
            this.cbIssuedBy.Location = new System.Drawing.Point(63, 108);
            this.cbIssuedBy.Name = "cbIssuedBy";
            this.cbIssuedBy.Size = new System.Drawing.Size(110, 20);
            this.cbIssuedBy.TabIndex = 55;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 68;
            this.label17.Text = "经办人:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "使用截止日期:";
            // 
            // txtVoucherBatchId
            // 
            this.txtVoucherBatchId.Location = new System.Drawing.Point(63, 4);
            this.txtVoucherBatchId.Name = "txtVoucherBatchId";
            this.txtVoucherBatchId.Size = new System.Drawing.Size(110, 21);
            this.txtVoucherBatchId.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "票券名称:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 70;
            this.label19.Text = "券  类:";
            // 
            // txtVoucherName
            // 
            this.txtVoucherName.Location = new System.Drawing.Point(260, 4);
            this.txtVoucherName.Name = "txtVoucherName";
            this.txtVoucherName.Size = new System.Drawing.Size(110, 21);
            this.txtVoucherName.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 65;
            this.label16.Text = "号  段:";
            // 
            // txtSerialScope
            // 
            this.txtSerialScope.Location = new System.Drawing.Point(63, 30);
            this.txtSerialScope.Name = "txtSerialScope";
            this.txtSerialScope.Size = new System.Drawing.Size(110, 21);
            this.txtSerialScope.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "面    值:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(260, 30);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(110, 21);
            this.txtUnitPrice.TabIndex = 42;
            this.txtUnitPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnitPrice_Validating);
            // 
            // dtExpireDate
            // 
            this.dtExpireDate.CustomFormat = "yyyy年MM月dd日";
            this.dtExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpireDate.Location = new System.Drawing.Point(478, 56);
            this.dtExpireDate.Name = "dtExpireDate";
            this.dtExpireDate.Size = new System.Drawing.Size(110, 21);
            this.dtExpireDate.TabIndex = 53;
            this.dtExpireDate.Value = new System.DateTime(2012, 1, 10, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "总    价:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(478, 30);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(110, 21);
            this.txtTotalPrice.TabIndex = 44;
            this.txtTotalPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtTotalPrice_Validating);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "数  量:";
            // 
            // dtReleaseDate
            // 
            this.dtReleaseDate.CustomFormat = "yyyy年MM月dd日";
            this.dtReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReleaseDate.Location = new System.Drawing.Point(260, 56);
            this.dtReleaseDate.Name = "dtReleaseDate";
            this.dtReleaseDate.Size = new System.Drawing.Size(110, 21);
            this.dtReleaseDate.TabIndex = 47;
            this.dtReleaseDate.Value = new System.DateTime(2012, 1, 10, 0, 0, 0, 0);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(63, 56);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 21);
            this.txtQuantity.TabIndex = 45;
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 63;
            this.label12.Text = "发行日期:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(412, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 66;
            this.label15.Text = "购卷单位:";
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(478, 4);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(110, 20);
            this.cbCustomerName.TabIndex = 71;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 67;
            this.label14.Text = "票券类型:";
            // 
            // cbVoucherTypeId
            // 
            this.cbVoucherTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoucherTypeId.FormattingEnabled = true;
            this.cbVoucherTypeId.Location = new System.Drawing.Point(260, 82);
            this.cbVoucherTypeId.Name = "cbVoucherTypeId";
            this.cbVoucherTypeId.Size = new System.Drawing.Size(110, 20);
            this.cbVoucherTypeId.TabIndex = 72;
            // 
            // chbIsPrint
            // 
            this.chbIsPrint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chbIsPrint.AutoSize = true;
            this.chbIsPrint.Location = new System.Drawing.Point(504, 83);
            this.chbIsPrint.Name = "chbIsPrint";
            this.chbIsPrint.Size = new System.Drawing.Size(84, 16);
            this.chbIsPrint.TabIndex = 75;
            this.chbIsPrint.Text = "是否已打印";
            this.chbIsPrint.UseVisualStyleBackColor = true;
            // 
            // chbIsActive
            // 
            this.chbIsActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Location = new System.Drawing.Point(399, 83);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(72, 16);
            this.chbIsActive.TabIndex = 76;
            this.chbIsActive.Text = "是否有效";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(194, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 58;
            this.label9.Text = "描    述:";
            // 
            // txtDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescription, 3);
            this.txtDescription.Location = new System.Drawing.Point(260, 108);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(318, 21);
            this.txtDescription.TabIndex = 60;
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "发行日期",
            "票券名称",
            "劵类型",
            "券子类型"});
            this.cbSearchType.Location = new System.Drawing.Point(27, 20);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(77, 20);
            this.cbSearchType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "查询:";
            // 
            // frmVoucherBatchManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(910, 651);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVoucherBatchManage";
            this.Text = "票劵批次管理";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbVoucherTypeId;
        private System.Windows.Forms.ComboBox cbVoucherSubTypeId;
        private System.Windows.Forms.ComboBox cbIssuedBy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbCustomerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVoucherBatchId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtVoucherName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSerialScope;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.DateTimePicker dtExpireDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtReleaseDate;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.CheckBox chbIsPrint;
    }
}

namespace Flamingo.TheaterManage
{
    partial class frmUploadSettingManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadSettingManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUploadId = new System.Windows.Forms.TextBox();
            this.txtEmailAddr = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUploadMethod = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUploadAddr = new System.Windows.Forms.TextBox();
            this.txtTargetN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUploadTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFileFormat = new System.Windows.Forms.ComboBox();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtTargetName);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(976, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtTargetName, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(923, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(867, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(811, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(755, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(699, 10);
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(0, 218);
            this.panList.Size = new System.Drawing.Size(976, 231);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(974, 23);
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(251, 56);
            this.panDetail.Size = new System.Drawing.Size(631, 134);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(629, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按上传目标名称查询:";
            // 
            // txtTargetName
            // 
            this.txtTargetName.Location = new System.Drawing.Point(129, 19);
            this.txtTargetName.Name = "txtTargetName";
            this.txtTargetName.Size = new System.Drawing.Size(162, 21);
            this.txtTargetName.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(297, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUploadId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEmailAddr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbUploadMethod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUploadAddr, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTargetN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUploadTime, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbFileFormat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chbIsActive, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 110);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "上报编号:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "上地报址:";
            // 
            // txtUploadId
            // 
            this.txtUploadId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUploadId.Location = new System.Drawing.Point(85, 4);
            this.txtUploadId.Name = "txtUploadId";
            this.txtUploadId.Size = new System.Drawing.Size(100, 21);
            this.txtUploadId.TabIndex = 29;
            // 
            // txtEmailAddr
            // 
            this.txtEmailAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtEmailAddr, 5);
            this.txtEmailAddr.Location = new System.Drawing.Point(85, 56);
            this.txtEmailAddr.Name = "txtEmailAddr";
            this.txtEmailAddr.Size = new System.Drawing.Size(521, 21);
            this.txtEmailAddr.TabIndex = 36;
            this.txtEmailAddr.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAddr_Validating);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 40;
            this.label14.Text = "Email地址:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "上报单位名称:";
            // 
            // cbUploadMethod
            // 
            this.cbUploadMethod.FormattingEnabled = true;
            this.cbUploadMethod.Location = new System.Drawing.Point(288, 30);
            this.cbUploadMethod.Name = "cbUploadMethod";
            this.cbUploadMethod.Size = new System.Drawing.Size(122, 20);
            this.cbUploadMethod.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(204, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 38;
            this.label16.Text = "上 报 方 式:";
            // 
            // txtUploadAddr
            // 
            this.txtUploadAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtUploadAddr, 5);
            this.txtUploadAddr.Location = new System.Drawing.Point(85, 83);
            this.txtUploadAddr.Name = "txtUploadAddr";
            this.txtUploadAddr.Size = new System.Drawing.Size(521, 21);
            this.txtUploadAddr.TabIndex = 34;
            // 
            // txtTargetN
            // 
            this.txtTargetN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTargetN.Location = new System.Drawing.Point(288, 4);
            this.txtTargetN.Name = "txtTargetN";
            this.txtTargetN.Size = new System.Drawing.Size(121, 21);
            this.txtTargetN.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "上报时间:";
            // 
            // txtUploadTime
            // 
            this.txtUploadTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUploadTime.Location = new System.Drawing.Point(498, 4);
            this.txtUploadTime.Name = "txtUploadTime";
            this.txtUploadTime.Size = new System.Drawing.Size(108, 21);
            this.txtUploadTime.TabIndex = 42;
            this.txtUploadTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtUploadTime_Validating);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "文件格式:";
            // 
            // cbFileFormat
            // 
            this.cbFileFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFileFormat.AutoCompleteCustomSource.AddRange(new string[] {
            "xml",
            "xml加密"});
            this.cbFileFormat.FormattingEnabled = true;
            this.cbFileFormat.Location = new System.Drawing.Point(85, 30);
            this.cbFileFormat.Name = "cbFileFormat";
            this.cbFileFormat.Size = new System.Drawing.Size(104, 20);
            this.cbFileFormat.TabIndex = 44;
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbIsActive, 2);
            this.chbIsActive.Location = new System.Drawing.Point(417, 30);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(72, 16);
            this.chbIsActive.TabIndex = 41;
            this.chbIsActive.Text = "是否上报";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // frmUploadSettingManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(976, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUploadSettingManage";
            this.Text = "数据上报管理";
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
        private System.Windows.Forms.TextBox txtTargetName;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUploadTime;
        private System.Windows.Forms.TextBox txtUploadId;
        private System.Windows.Forms.TextBox txtUploadAddr;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTargetN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.ComboBox cbUploadMethod;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmailAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFileFormat;
    }
}

namespace Flamingo.TheaterManage
{
    partial class frmTimeSettingManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeSettingManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepeatDay = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbStartMonth = new System.Windows.Forms.ComboBox();
            this.cbRefundDeadline = new System.Windows.Forms.ComboBox();
            this.cbMonthCount = new System.Windows.Forms.ComboBox();
            this.cbStartDate = new System.Windows.Forms.ComboBox();
            this.cbDailyCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOpenTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCloseTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBookingRelease = new System.Windows.Forms.ComboBox();
            this.txtTimeId = new System.Windows.Forms.TextBox();
            this.cbTicketDeadline = new System.Windows.Forms.ComboBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.txtRepeatDay);
            this.panTop.Size = new System.Drawing.Size(792, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.txtRepeatDay, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(739, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(683, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(571, 10);
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(627, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 10);
            this.btnAdd.Visible = false;
            // 
            // panList
            // 
            this.panList.Size = new System.Drawing.Size(792, 382);
            this.panList.Visible = false;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(790, 23);
            this.lblListTitle.Text = " 经营时间信息表";
            this.lblListTitle.Visible = false;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(104, 67);
            this.panDetail.Size = new System.Drawing.Size(598, 107);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(596, 23);
            this.lblDetailTitle.Text = " 经营时间信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按重复时间查询:";
            this.label1.Visible = false;
            // 
            // txtRepeatDay
            // 
            this.txtRepeatDay.Location = new System.Drawing.Point(113, 16);
            this.txtRepeatDay.Name = "txtRepeatDay";
            this.txtRepeatDay.Size = new System.Drawing.Size(182, 21);
            this.txtRepeatDay.TabIndex = 4;
            this.txtRepeatDay.Visible = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(312, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Visible = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Controls.Add(this.cbStartMonth, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbRefundDeadline, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMonthCount, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbStartDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbDailyCount, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOpenTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCloseTime, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbBookingRelease, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeId, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTicketDeadline, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 82);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // cbStartMonth
            // 
            this.cbStartMonth.FormattingEnabled = true;
            this.cbStartMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbStartMonth.Location = new System.Drawing.Point(491, 57);
            this.cbStartMonth.MaxDropDownItems = 32;
            this.cbStartMonth.Name = "cbStartMonth";
            this.cbStartMonth.Size = new System.Drawing.Size(100, 20);
            this.cbStartMonth.TabIndex = 41;
            // 
            // cbRefundDeadline
            // 
            this.cbRefundDeadline.FormattingEnabled = true;
            this.cbRefundDeadline.Items.AddRange(new object[] {
            "开场前",
            "开场后"});
            this.cbRefundDeadline.Location = new System.Drawing.Point(293, 30);
            this.cbRefundDeadline.Name = "cbRefundDeadline";
            this.cbRefundDeadline.Size = new System.Drawing.Size(100, 20);
            this.cbRefundDeadline.TabIndex = 37;
            this.cbRefundDeadline.SelectedIndexChanged += new System.EventHandler(this.cbRefundDeadline_SelectedIndexChanged);
            // 
            // cbMonthCount
            // 
            this.cbMonthCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonthCount.FormattingEnabled = true;
            this.cbMonthCount.Items.AddRange(new object[] {
            "从今年至明年",
            "从去年至今年"});
            this.cbMonthCount.Location = new System.Drawing.Point(293, 57);
            this.cbMonthCount.Name = "cbMonthCount";
            this.cbMonthCount.Size = new System.Drawing.Size(100, 20);
            this.cbMonthCount.TabIndex = 40;
            this.cbMonthCount.SelectedIndexChanged += new System.EventHandler(this.cbMonthCount_SelectedIndexChanged);
            // 
            // cbStartDate
            // 
            this.cbStartDate.FormattingEnabled = true;
            this.cbStartDate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbStartDate.Location = new System.Drawing.Point(95, 57);
            this.cbStartDate.MaxDropDownItems = 32;
            this.cbStartDate.Name = "cbStartDate";
            this.cbStartDate.Size = new System.Drawing.Size(100, 20);
            this.cbStartDate.TabIndex = 39;
            // 
            // cbDailyCount
            // 
            this.cbDailyCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDailyCount.FormattingEnabled = true;
            this.cbDailyCount.Items.AddRange(new object[] {
            "从本月至下月",
            "从上月至本月"});
            this.cbDailyCount.Location = new System.Drawing.Point(491, 30);
            this.cbDailyCount.Name = "cbDailyCount";
            this.cbDailyCount.Size = new System.Drawing.Size(100, 20);
            this.cbDailyCount.TabIndex = 38;
            this.cbDailyCount.SelectedIndexChanged += new System.EventHandler(this.cbDailyCount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "营业开始时间:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "起 始 日 期:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "起 始 月 份:";
            // 
            // txtOpenTime
            // 
            this.txtOpenTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOpenTime.Location = new System.Drawing.Point(95, 4);
            this.txtOpenTime.Name = "txtOpenTime";
            this.txtOpenTime.Size = new System.Drawing.Size(100, 21);
            this.txtOpenTime.TabIndex = 16;
            this.txtOpenTime.TextChanged += new System.EventHandler(this.txtOpenTime_TextChanged);
            this.txtOpenTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpenTime_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "营业截止时间:";
            // 
            // txtCloseTime
            // 
            this.txtCloseTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCloseTime.Location = new System.Drawing.Point(293, 4);
            this.txtCloseTime.Name = "txtCloseTime";
            this.txtCloseTime.Size = new System.Drawing.Size(100, 21);
            this.txtCloseTime.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "售票截止时间:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "日统计设定:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "预定解除时间:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "退票截止时间:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "月统计设定:";
            // 
            // cbBookingRelease
            // 
            this.cbBookingRelease.FormattingEnabled = true;
            this.cbBookingRelease.Items.AddRange(new object[] {
            "开场前",
            "开场后"});
            this.cbBookingRelease.Location = new System.Drawing.Point(95, 30);
            this.cbBookingRelease.Name = "cbBookingRelease";
            this.cbBookingRelease.Size = new System.Drawing.Size(100, 20);
            this.cbBookingRelease.TabIndex = 36;
            this.cbBookingRelease.SelectedIndexChanged += new System.EventHandler(this.cbBookingRelease_SelectedIndexChanged);
            // 
            // txtTimeId
            // 
            this.txtTimeId.Location = new System.Drawing.Point(600, 4);
            this.txtTimeId.Name = "txtTimeId";
            this.txtTimeId.Size = new System.Drawing.Size(0, 21);
            this.txtTimeId.TabIndex = 42;
            // 
            // cbTicketDeadline
            // 
            this.cbTicketDeadline.FormattingEnabled = true;
            this.cbTicketDeadline.Items.AddRange(new object[] {
            "开场前",
            "开场后"});
            this.cbTicketDeadline.Location = new System.Drawing.Point(491, 4);
            this.cbTicketDeadline.Name = "cbTicketDeadline";
            this.cbTicketDeadline.Size = new System.Drawing.Size(102, 20);
            this.cbTicketDeadline.TabIndex = 35;
            this.cbTicketDeadline.SelectedIndexChanged += new System.EventHandler(this.cbTicketDeadline_SelectedIndexChanged);
            // 
            // frmTimeSettingManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimeSettingManage";
            this.Text = "经营时间管理";
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
        private System.Windows.Forms.TextBox txtRepeatDay;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOpenTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCloseTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStartMonth;
        private System.Windows.Forms.ComboBox cbMonthCount;
        private System.Windows.Forms.ComboBox cbStartDate;
        private System.Windows.Forms.ComboBox cbDailyCount;
        private System.Windows.Forms.ComboBox cbRefundDeadline;
        private System.Windows.Forms.ComboBox cbTicketDeadline;
        private System.Windows.Forms.ComboBox cbBookingRelease;
        private System.Windows.Forms.TextBox txtTimeId;
    }
}

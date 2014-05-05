namespace Flamingo.TheaterManage
{
    partial class frmFareSettingManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFareSettingManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFare = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFareSettingId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGroupPrice = new System.Windows.Forms.TextBox();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemberPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFareSettingName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSinglePrice = new System.Windows.Forms.TextBox();
            this.txtDoublePrice = new System.Windows.Forms.TextBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(218)))), ((int)(((byte)(248)))));
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtFare);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(1064, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtFare, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(1011, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(955, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(843, 10);
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(899, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(787, 10);
            this.btnAdd.Visible = false;
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(0, 281);
            this.panList.Size = new System.Drawing.Size(1064, 223);
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblListTitle.Size = new System.Drawing.Size(1062, 23);
            this.lblListTitle.Text = " 票价设置信息表";
            // 
            // panDetail
            // 
            this.panDetail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(122, 67);
            this.panDetail.Size = new System.Drawing.Size(739, 77);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblDetailTitle.Size = new System.Drawing.Size(737, 23);
            this.lblDetailTitle.Text = " 票价设置信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按票价设置名称查询:";
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(130, 18);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(161, 21);
            this.txtFare.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(297, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFareSettingId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGroupPrice, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxPrice, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMemberPrice, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFareSettingName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStudentPrice, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSinglePrice, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDoublePrice, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 52);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "票价设置编号:";
            // 
            // txtFareSettingId
            // 
            this.txtFareSettingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFareSettingId.Location = new System.Drawing.Point(95, 4);
            this.txtFareSettingId.Name = "txtFareSettingId";
            this.txtFareSettingId.Size = new System.Drawing.Size(94, 21);
            this.txtFareSettingId.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "学生票价:";
            // 
            // txtGroupPrice
            // 
            this.txtGroupPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGroupPrice.Location = new System.Drawing.Point(643, 30);
            this.txtGroupPrice.Name = "txtGroupPrice";
            this.txtGroupPrice.Size = new System.Drawing.Size(93, 21);
            this.txtGroupPrice.TabIndex = 35;
            this.txtGroupPrice.Visible = false;
            this.txtGroupPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtGroupPrice_Validating);
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBoxPrice.Location = new System.Drawing.Point(272, 30);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(94, 21);
            this.txtBoxPrice.TabIndex = 29;
            this.txtBoxPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPrice_Validating);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(577, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "团体票价:";
            this.label9.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "包厢票价:";
            // 
            // txtMemberPrice
            // 
            this.txtMemberPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMemberPrice.Location = new System.Drawing.Point(643, 4);
            this.txtMemberPrice.Name = "txtMemberPrice";
            this.txtMemberPrice.Size = new System.Drawing.Size(93, 21);
            this.txtMemberPrice.TabIndex = 33;
            this.txtMemberPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtMemberPrice_Validating);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "会员定价:";
            // 
            // txtFareSettingName
            // 
            this.txtFareSettingName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFareSettingName.Location = new System.Drawing.Point(95, 30);
            this.txtFareSettingName.Name = "txtFareSettingName";
            this.txtFareSettingName.Size = new System.Drawing.Size(94, 21);
            this.txtFareSettingName.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "票价设置名称:";
            // 
            // txtStudentPrice
            // 
            this.txtStudentPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStudentPrice.Location = new System.Drawing.Point(272, 4);
            this.txtStudentPrice.Name = "txtStudentPrice";
            this.txtStudentPrice.Size = new System.Drawing.Size(94, 21);
            this.txtStudentPrice.TabIndex = 27;
            this.txtStudentPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtStudentPrice_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "单人零售票价:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "双人零售票价:";
            // 
            // txtSinglePrice
            // 
            this.txtSinglePrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSinglePrice.Location = new System.Drawing.Point(466, 4);
            this.txtSinglePrice.Name = "txtSinglePrice";
            this.txtSinglePrice.Size = new System.Drawing.Size(93, 21);
            this.txtSinglePrice.TabIndex = 25;
            this.txtSinglePrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtSinglePrice_Validating);
            // 
            // txtDoublePrice
            // 
            this.txtDoublePrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDoublePrice.Location = new System.Drawing.Point(466, 30);
            this.txtDoublePrice.Name = "txtDoublePrice";
            this.txtDoublePrice.Size = new System.Drawing.Size(93, 21);
            this.txtDoublePrice.TabIndex = 31;
            this.txtDoublePrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtDoublePrice_Validating);
            // 
            // frmFareSettingManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1064, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFareSettingManage";
            this.Text = "票价管理";
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
        private System.Windows.Forms.TextBox txtFare;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFareSettingId;
        private System.Windows.Forms.TextBox txtGroupPrice;
        private System.Windows.Forms.TextBox txtDoublePrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.TextBox txtStudentPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFareSettingName;
        private System.Windows.Forms.TextBox txtSinglePrice;
        private System.Windows.Forms.Label label3;
    }
}

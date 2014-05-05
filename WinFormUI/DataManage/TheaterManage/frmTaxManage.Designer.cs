namespace Flamingo.TheaterManage
{
    partial class frmTaxManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxManage));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtTaxType = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTheaterId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtaxType = new System.Windows.Forms.TextBox();
            this.cbChargeMethod = new System.Windows.Forms.ComboBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.CausesValidation = false;
            this.panTop.Controls.Add(this.txtTaxType);
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(792, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            this.panTop.Controls.SetChildIndex(this.txtTaxType, 0);
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
            this.btnDelete.Location = new System.Drawing.Point(627, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(571, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 10);
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(0, 153);
            this.panList.Size = new System.Drawing.Size(792, 401);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(790, 23);
            this.lblListTitle.Text = " 税费信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(24, 56);
            this.panDetail.Size = new System.Drawing.Size(339, 81);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(337, 23);
            this.lblDetailTitle.Text = " 税费信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按税费类型查询:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(291, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtTaxType
            // 
            this.txtTaxType.Location = new System.Drawing.Point(113, 19);
            this.txtTaxType.Name = "txtTaxType";
            this.txtTaxType.Size = new System.Drawing.Size(172, 21);
            this.txtTaxType.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTaxId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTheaterId, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtaxType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbChargeMethod, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 56);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "税费编号:";
            // 
            // txtTaxId
            // 
            this.txtTaxId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxId.Location = new System.Drawing.Point(70, 4);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(94, 21);
            this.txtTaxId.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "扣除方式:";
            // 
            // txtRate
            // 
            this.txtRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRate.Location = new System.Drawing.Point(70, 30);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(94, 21);
            this.txtRate.TabIndex = 8;
            this.txtRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtRate_Validating);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "税    率:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "影院ID:";
            this.label3.Visible = false;
            // 
            // txtTheaterId
            // 
            this.txtTheaterId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTheaterId.Location = new System.Drawing.Point(404, 30);
            this.txtTheaterId.Name = "txtTheaterId";
            this.txtTheaterId.Size = new System.Drawing.Size(94, 21);
            this.txtTheaterId.TabIndex = 4;
            this.txtTheaterId.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "税费类型:";
            // 
            // txtaxType
            // 
            this.txtaxType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtaxType.Location = new System.Drawing.Point(237, 4);
            this.txtaxType.Name = "txtaxType";
            this.txtaxType.Size = new System.Drawing.Size(94, 21);
            this.txtaxType.TabIndex = 6;
            // 
            // cbChargeMethod
            // 
            this.cbChargeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChargeMethod.FormattingEnabled = true;
            this.cbChargeMethod.Items.AddRange(new object[] {
            "按全额票款计算",
            "按税后票款计算"});
            this.cbChargeMethod.Location = new System.Drawing.Point(237, 30);
            this.cbChargeMethod.Name = "cbChargeMethod";
            this.cbChargeMethod.Size = new System.Drawing.Size(94, 20);
            this.cbChargeMethod.TabIndex = 10;
            // 
            // frmTaxManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaxManage";
            this.Text = "税费管理";
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
        private System.Windows.Forms.TextBox txtTaxType;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtTheaterId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtaxType;
        private System.Windows.Forms.ComboBox cbChargeMethod;
    }
}

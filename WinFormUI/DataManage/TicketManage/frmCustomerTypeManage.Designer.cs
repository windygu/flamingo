namespace Flamingo.TicketManage
{
    partial class frmCustomerTypeManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerTypeManage));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(218)))), ((int)(((byte)(248)))));
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(792, 50);
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
            this.btnReturn.Location = new System.Drawing.Point(739, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(683, 10);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.panList.Size = new System.Drawing.Size(792, 466);
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblListTitle.Size = new System.Drawing.Size(790, 23);
            this.lblListTitle.Text = " 客户类型信息表";
            // 
            // panDetail
            // 
            this.panDetail.Location = new System.Drawing.Point(408, 6);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按客户类型名称查询:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(334, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click_1);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(128, 16);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(200, 21);
            this.txtKeyWord.TabIndex = 12;
            // 
            // frmCustomerTypeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerTypeManage";
            this.Text = "客户类型管理";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtKeyWord;
    }
}

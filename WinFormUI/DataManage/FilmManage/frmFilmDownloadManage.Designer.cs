namespace Flamingo.FilmManage
{
    partial class frmFilmDownloadManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilmDownloadManage));
            this.label1 = new System.Windows.Forms.Label();
            this.cbStartYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(218)))), ((int)(((byte)(248)))));
            this.panTop.Controls.Add(this.btnImport);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.cbStartYear);
            this.panTop.Controls.Add(this.label2);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.btnDownload);
            this.panTop.Controls.Add(this.btnRefresh);
            this.panTop.Controls.Add(this.btnSelectAll);
            this.panTop.Controls.Add(this.btnReverse);
            this.panTop.Controls.SetChildIndex(this.btnReverse, 0);
            this.panTop.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.panTop.Controls.SetChildIndex(this.btnRefresh, 0);
            this.panTop.Controls.SetChildIndex(this.btnDownload, 0);
            this.panTop.Controls.SetChildIndex(this.txtKeyWord, 0);
            this.panTop.Controls.SetChildIndex(this.label2, 0);
            this.panTop.Controls.SetChildIndex(this.cbStartYear, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.btnImport, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(963, 72);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(907, 72);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(851, 72);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(795, 72);
            // 
            // panList
            // 
            this.panList.Size = new System.Drawing.Size(1016, 469);
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblListTitle.Size = new System.Drawing.Size(1014, 23);
            this.lblListTitle.Text = " 影片下载信息表";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "可用影片信息列表：";
            // 
            // cbStartYear
            // 
            this.cbStartYear.FormattingEnabled = true;
            this.cbStartYear.Location = new System.Drawing.Point(131, 16);
            this.cbStartYear.Name = "cbStartYear";
            this.cbStartYear.Size = new System.Drawing.Size(50, 20);
            this.cbStartYear.TabIndex = 6;
            this.cbStartYear.Text = "2011";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "并且 影片名包含";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(288, 16);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(150, 21);
            this.txtKeyWord.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WinFormUI.Properties.Resources.Query;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRefresh.Location = new System.Drawing.Point(444, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "  查询";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(768, 10);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 30);
            this.btnReverse.TabIndex = 10;
            this.btnReverse.Text = "反向选择";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(525, 10);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 30);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "影片下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(687, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "影片入库";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(606, 10);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 30);
            this.btnSelectAll.TabIndex = 13;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // frmFilmDownloadManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFilmDownloadManage";
            this.Text = "影片下载维护";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStartYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSelectAll;
    }
}

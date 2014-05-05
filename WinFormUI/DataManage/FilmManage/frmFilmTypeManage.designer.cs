namespace Flamingo.FilmManage
{
    partial class frmFilmTypeManage
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
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Size = new System.Drawing.Size(792, 50);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panList
            // 
            this.panList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panList.Location = new System.Drawing.Point(338, 225);
            this.panList.Size = new System.Drawing.Size(339, 318);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(337, 23);
            // 
            // panDetail
            // 
            this.panDetail.Location = new System.Drawing.Point(35, 137);
            // 
            // frmFilmTypeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "frmFilmTypeManage";
            this.Text = "影片类型管理";
            this.panTop.ResumeLayout(false);
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

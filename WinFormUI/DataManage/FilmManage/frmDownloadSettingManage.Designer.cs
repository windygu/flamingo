namespace Flamingo.FilmManage
{
    partial class frmDownloadSettingManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadSettingManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbDocument = new System.Windows.Forms.RadioButton();
            this.rbFtp = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownloadId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDownloadAddr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.rbHttp = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProxyServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSourceN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chbIsAnonymAllowed = new System.Windows.Forms.CheckBox();
            this.chbIsProxy = new System.Windows.Forms.CheckBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtSourceName);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtSourceName, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // panList
            // 
            this.panList.Size = new System.Drawing.Size(1016, 382);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(1014, 35);
            this.lblListTitle.Text = " 数据下载信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(12, 0);
            this.panDetail.Size = new System.Drawing.Size(880, 105);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(878, 23);
            this.lblDetailTitle.Text = " 数据下载信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "下载源名称:";
            // 
            // txtSourceName
            // 
            this.txtSourceName.Location = new System.Drawing.Point(90, 16);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(170, 21);
            this.txtSourceName.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(266, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.rbDocument, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbFtp, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDownloadId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDownloadAddr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProxyPort, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbHttp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProxyServer, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSourceN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbIsAnonymAllowed, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbIsProxy, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 80);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // rbDocument
            // 
            this.rbDocument.AutoSize = true;
            this.rbDocument.Location = new System.Drawing.Point(273, 30);
            this.rbDocument.Name = "rbDocument";
            this.rbDocument.Size = new System.Drawing.Size(71, 16);
            this.rbDocument.TabIndex = 33;
            this.rbDocument.Tag = "文件方式";
            this.rbDocument.Text = "文件方式";
            this.rbDocument.UseVisualStyleBackColor = true;
            this.rbDocument.CheckedChanged += new System.EventHandler(this.rbHttp_CheckedChanged);
            // 
            // rbFtp
            // 
            this.rbFtp.AutoSize = true;
            this.rbFtp.Location = new System.Drawing.Point(192, 30);
            this.rbFtp.Name = "rbFtp";
            this.rbFtp.Size = new System.Drawing.Size(41, 16);
            this.rbFtp.TabIndex = 32;
            this.rbFtp.Tag = "FTP";
            this.rbFtp.Text = "FTP";
            this.rbFtp.UseVisualStyleBackColor = true;
            this.rbFtp.CheckedChanged += new System.EventHandler(this.rbHttp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "下载编号:";
            // 
            // txtDownloadId
            // 
            this.txtDownloadId.Location = new System.Drawing.Point(85, 4);
            this.txtDownloadId.Name = "txtDownloadId";
            this.txtDownloadId.Size = new System.Drawing.Size(100, 21);
            this.txtDownloadId.TabIndex = 8;
            this.txtDownloadId.TextChanged += new System.EventHandler(this.txtDownloadId_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "下载方式:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "下载源地址";
            // 
            // txtDownloadAddr
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDownloadAddr, 3);
            this.txtDownloadAddr.Location = new System.Drawing.Point(85, 56);
            this.txtDownloadAddr.Name = "txtDownloadAddr";
            this.txtDownloadAddr.Size = new System.Drawing.Size(288, 21);
            this.txtDownloadAddr.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(401, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 24);
            this.label12.TabIndex = 29;
            this.label12.Text = "代理服务\r\n器端口:";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(461, 56);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(100, 21);
            this.txtProxyPort.TabIndex = 30;
            this.txtProxyPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtProxyPort_Validating);
            // 
            // rbHttp
            // 
            this.rbHttp.AutoSize = true;
            this.rbHttp.Checked = true;
            this.rbHttp.Location = new System.Drawing.Point(85, 30);
            this.rbHttp.Name = "rbHttp";
            this.rbHttp.Size = new System.Drawing.Size(47, 16);
            this.rbHttp.TabIndex = 31;
            this.rbHttp.TabStop = true;
            this.rbHttp.Tag = "HTTP";
            this.rbHttp.Text = "HTTP";
            this.rbHttp.UseVisualStyleBackColor = true;
            this.rbHttp.CheckedChanged += new System.EventHandler(this.rbHttp_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "端口号:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(461, 30);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 18;
            this.txtPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtPort_Validating);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(589, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 24);
            this.label11.TabIndex = 27;
            this.label11.Text = "代理服务\r\n器地址:";
            // 
            // txtProxyServer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtProxyServer, 3);
            this.txtProxyServer.Location = new System.Drawing.Point(649, 56);
            this.txtProxyServer.Name = "txtProxyServer";
            this.txtProxyServer.Size = new System.Drawing.Size(226, 21);
            this.txtProxyServer.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "下载源名称:";
            // 
            // txtSourceN
            // 
            this.txtSourceN.Location = new System.Drawing.Point(273, 4);
            this.txtSourceN.Name = "txtSourceN";
            this.txtSourceN.Size = new System.Drawing.Size(100, 21);
            this.txtSourceN.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(407, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "用户名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(461, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(589, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "密   码:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(649, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 22;
            // 
            // chbIsAnonymAllowed
            // 
            this.chbIsAnonymAllowed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbIsAnonymAllowed.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbIsAnonymAllowed, 2);
            this.chbIsAnonymAllowed.Location = new System.Drawing.Point(756, 5);
            this.chbIsAnonymAllowed.Name = "chbIsAnonymAllowed";
            this.chbIsAnonymAllowed.Size = new System.Drawing.Size(96, 16);
            this.chbIsAnonymAllowed.TabIndex = 25;
            this.chbIsAnonymAllowed.Text = "允许匿名访问";
            this.chbIsAnonymAllowed.UseVisualStyleBackColor = true;
            // 
            // chbIsProxy
            // 
            this.chbIsProxy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbIsProxy.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbIsProxy, 2);
            this.chbIsProxy.Location = new System.Drawing.Point(568, 31);
            this.chbIsProxy.Name = "chbIsProxy";
            this.chbIsProxy.Size = new System.Drawing.Size(108, 16);
            this.chbIsProxy.TabIndex = 26;
            this.chbIsProxy.Text = "使用代理服务器";
            this.chbIsProxy.UseVisualStyleBackColor = true;
            // 
            // frmDownloadSettingManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDownloadSettingManage";
            this.Text = "数据下载管理";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.panDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceName;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProxyServer;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDownloadAddr;
        private System.Windows.Forms.TextBox txtDownloadId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtSourceN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbIsAnonymAllowed;
        private System.Windows.Forms.CheckBox chbIsProxy;
        private System.Windows.Forms.RadioButton rbDocument;
        private System.Windows.Forms.RadioButton rbFtp;
        private System.Windows.Forms.RadioButton rbHttp;
    }
}

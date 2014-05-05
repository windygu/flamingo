namespace Flamingo.FilmManage
{
    partial class frmFilmInfoManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilmInfoManage));
            this.btnAllFilm = new System.Windows.Forms.Button();
            this.btnShowFilm = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilmName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPublishDate = new System.Windows.Forms.DateTimePicker();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProducer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCast = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBrief = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLowestPrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRatio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFilmLength = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbFilmArea = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbFilmCategory = new System.Windows.Forms.ComboBox();
            this.txtBorderColour = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFilmCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFilmId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.cblMode = new System.Windows.Forms.CheckedListBox();
            this.btnUploadPoster = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.cblType = new System.Windows.Forms.CheckedListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnAllFilm);
            this.panTop.Controls.Add(this.btnShowFilm);
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.label19);
            this.panTop.Controls.Add(this.txtBorderColour);
            this.panTop.Size = new System.Drawing.Size(1028, 50);
            this.panTop.Controls.SetChildIndex(this.txtBorderColour, 0);
            this.panTop.Controls.SetChildIndex(this.label19, 0);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtKeyWord, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            this.panTop.Controls.SetChildIndex(this.btnShowFilm, 0);
            this.panTop.Controls.SetChildIndex(this.btnAllFilm, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(975, 10);
            this.btnReturn.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(919, 10);
            this.btnSave.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(807, 10);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(863, 10);
            this.btnEdit.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(751, 10);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Visible = false;
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(12, 261);
            this.panList.Size = new System.Drawing.Size(1012, 321);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(1010, 23);
            this.lblListTitle.Text = " 影片信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(12, 56);
            this.panDetail.Size = new System.Drawing.Size(1013, 199);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(1011, 23);
            this.lblDetailTitle.Text = " 影片信息";
            // 
            // btnAllFilm
            // 
            this.btnAllFilm.Location = new System.Drawing.Point(456, 10);
            this.btnAllFilm.Name = "btnAllFilm";
            this.btnAllFilm.Size = new System.Drawing.Size(75, 30);
            this.btnAllFilm.TabIndex = 3;
            this.btnAllFilm.Text = "所有影片";
            this.btnAllFilm.UseVisualStyleBackColor = true;
            this.btnAllFilm.Click += new System.EventHandler(this.btnAllFilm_Click);
            // 
            // btnShowFilm
            // 
            this.btnShowFilm.Location = new System.Drawing.Point(375, 10);
            this.btnShowFilm.Name = "btnShowFilm";
            this.btnShowFilm.Size = new System.Drawing.Size(75, 30);
            this.btnShowFilm.TabIndex = 2;
            this.btnShowFilm.Text = "上映影片";
            this.btnShowFilm.UseVisualStyleBackColor = true;
            this.btnShowFilm.Click += new System.EventHandler(this.btnShowFilm_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(319, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(113, 16);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(200, 21);
            this.txtKeyWord.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "按影片名称查询:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "影片编码:";
            // 
            // txtFilmName
            // 
            this.txtFilmName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilmName.Location = new System.Drawing.Point(277, 4);
            this.txtFilmName.Name = "txtFilmName";
            this.txtFilmName.Size = new System.Drawing.Size(124, 21);
            this.txtFilmName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "影片名称:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "发布日期:";
            // 
            // dtPublishDate
            // 
            this.dtPublishDate.CustomFormat = "yyyy年MM月dd日";
            this.dtPublishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPublishDate.Location = new System.Drawing.Point(479, 60);
            this.dtPublishDate.Name = "dtPublishDate";
            this.dtPublishDate.Size = new System.Drawing.Size(124, 21);
            this.dtPublishDate.TabIndex = 3;
            this.dtPublishDate.Value = new System.DateTime(2012, 1, 10, 0, 0, 0, 0);
            // 
            // txtPublisher
            // 
            this.txtPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPublisher.Location = new System.Drawing.Point(479, 4);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(124, 21);
            this.txtPublisher.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "发 行 商:";
            // 
            // txtProducer
            // 
            this.txtProducer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProducer.Location = new System.Drawing.Point(479, 88);
            this.txtProducer.Name = "txtProducer";
            this.txtProducer.Size = new System.Drawing.Size(124, 21);
            this.txtProducer.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "制 片 人:";
            // 
            // txtDirector
            // 
            this.txtDirector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDirector.Location = new System.Drawing.Point(277, 88);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(124, 21);
            this.txtDirector.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "导    演:";
            // 
            // txtCast
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtCast, 5);
            this.txtCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCast.Location = new System.Drawing.Point(277, 116);
            this.txtCast.Name = "txtCast";
            this.txtCast.Size = new System.Drawing.Size(528, 21);
            this.txtCast.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "演职员\r\n列表:";
            // 
            // txtBrief
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBrief, 7);
            this.txtBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBrief.Location = new System.Drawing.Point(75, 149);
            this.txtBrief.Name = "txtBrief";
            this.txtBrief.Size = new System.Drawing.Size(730, 21);
            this.txtBrief.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "影片简介:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "影片海报:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "yyyy年MM月dd日";
            this.dtStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(681, 60);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(124, 21);
            this.dtStartDate.TabIndex = 7;
            this.dtStartDate.Value = new System.DateTime(2012, 1, 18, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(615, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "开映日期:";
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "yyyy年MM月dd日";
            this.dtEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(75, 88);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(124, 21);
            this.dtEndDate.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "收映日期:";
            // 
            // txtLowestPrice
            // 
            this.txtLowestPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLowestPrice.Location = new System.Drawing.Point(681, 88);
            this.txtLowestPrice.Name = "txtLowestPrice";
            this.txtLowestPrice.Size = new System.Drawing.Size(124, 21);
            this.txtLowestPrice.TabIndex = 10;
            this.txtLowestPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtLowestPrice_Validating);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "最低票价:";
            // 
            // txtRatio
            // 
            this.txtRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRatio.Location = new System.Drawing.Point(277, 32);
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(124, 21);
            this.txtRatio.TabIndex = 9;
            this.txtRatio.Validating += new System.ComponentModel.CancelEventHandler(this.txtRatio_Validating);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(223, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 24);
            this.label15.TabIndex = 26;
            this.label15.Text = "片方分\r\n账比例:";
            // 
            // txtFilmLength
            // 
            this.txtFilmLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilmLength.Location = new System.Drawing.Point(75, 32);
            this.txtFilmLength.Name = "txtFilmLength";
            this.txtFilmLength.Size = new System.Drawing.Size(124, 21);
            this.txtFilmLength.TabIndex = 8;
            this.txtFilmLength.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilmLength_Validating);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 24;
            this.label16.Text = "影片长度:";
            // 
            // cbFilmArea
            // 
            this.cbFilmArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFilmArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilmArea.FormattingEnabled = true;
            this.cbFilmArea.Location = new System.Drawing.Point(75, 60);
            this.cbFilmArea.Name = "cbFilmArea";
            this.cbFilmArea.Size = new System.Drawing.Size(124, 20);
            this.cbFilmArea.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "影片产地:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(211, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 34;
            this.label18.Text = "影片类别:";
            // 
            // cbFilmCategory
            // 
            this.cbFilmCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFilmCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilmCategory.FormattingEnabled = true;
            this.cbFilmCategory.Location = new System.Drawing.Point(277, 60);
            this.cbFilmCategory.Name = "cbFilmCategory";
            this.cbFilmCategory.Size = new System.Drawing.Size(124, 20);
            this.cbFilmCategory.TabIndex = 13;
            // 
            // txtBorderColour
            // 
            this.txtBorderColour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBorderColour.Enabled = false;
            this.txtBorderColour.Location = new System.Drawing.Point(610, 7);
            this.txtBorderColour.Name = "txtBorderColour";
            this.txtBorderColour.Size = new System.Drawing.Size(110, 21);
            this.txtBorderColour.TabIndex = 14;
            this.txtBorderColour.Visible = false;
            this.txtBorderColour.Click += new System.EventHandler(this.txtBorderColour_Click);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(545, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 12);
            this.label19.TabIndex = 35;
            this.label19.Text = "边框颜色:";
            this.label19.Visible = false;
            // 
            // txtFilmCode
            // 
            this.txtFilmCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilmCode.Location = new System.Drawing.Point(75, 4);
            this.txtFilmCode.Name = "txtFilmCode";
            this.txtFilmCode.Size = new System.Drawing.Size(124, 21);
            this.txtFilmCode.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.dtPublishDate, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbFilmCategory, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbFilmArea, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtStartDate, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFilmCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFilmName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPublisher, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFilmId, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFilmLength, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRatio, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLowestPrice, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDirector, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtEndDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMode, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProducer, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.cblMode, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUploadPoster, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCast, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtType, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cblType, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label20, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtBrief, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 174);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtFilmId
            // 
            this.txtFilmId.Location = new System.Drawing.Point(4, 177);
            this.txtFilmId.Name = "txtFilmId";
            this.txtFilmId.Size = new System.Drawing.Size(0, 21);
            this.txtFilmId.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "放映模式:";
            // 
            // txtMode
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMode, 2);
            this.txtMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMode.Location = new System.Drawing.Point(681, 4);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(225, 21);
            this.txtMode.TabIndex = 5;
            // 
            // cblMode
            // 
            this.cblMode.AllowDrop = true;
            this.cblMode.CheckOnClick = true;
            this.cblMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblMode.FormattingEnabled = true;
            this.cblMode.Location = new System.Drawing.Point(913, 4);
            this.cblMode.Name = "cblMode";
            this.tableLayoutPanel1.SetRowSpan(this.cblMode, 6);
            this.cblMode.Size = new System.Drawing.Size(94, 166);
            this.cblMode.TabIndex = 39;
            // 
            // btnUploadPoster
            // 
            this.btnUploadPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUploadPoster.Location = new System.Drawing.Point(75, 116);
            this.btnUploadPoster.Name = "btnUploadPoster";
            this.btnUploadPoster.Size = new System.Drawing.Size(124, 26);
            this.btnUploadPoster.TabIndex = 38;
            this.btnUploadPoster.Text = "上传海报";
            this.btnUploadPoster.UseVisualStyleBackColor = true;
            this.btnUploadPoster.Click += new System.EventHandler(this.btnUploadPoster_Click);
            // 
            // txtType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtType, 3);
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Location = new System.Drawing.Point(479, 32);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(326, 21);
            this.txtType.TabIndex = 5;
            // 
            // cblType
            // 
            this.cblType.AllowDrop = true;
            this.cblType.CheckOnClick = true;
            this.cblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblType.FormattingEnabled = true;
            this.cblType.Location = new System.Drawing.Point(812, 32);
            this.cblType.Name = "cblType";
            this.tableLayoutPanel1.SetRowSpan(this.cblType, 5);
            this.cblType.Size = new System.Drawing.Size(94, 138);
            this.cblType.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(413, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "影片类型:";
            // 
            // frmFilmInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1028, 588);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFilmInfoManage";
            this.Text = "影片管理";
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

        protected System.Windows.Forms.Button btnAllFilm;
        protected System.Windows.Forms.Button btnShowFilm;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPublishDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilmName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCast;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProducer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbFilmCategory;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbFilmArea;
        private System.Windows.Forms.TextBox txtLowestPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRatio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFilmLength;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBrief;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBorderColour;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFilmCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtFilmId;
        private System.Windows.Forms.Button btnUploadPoster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblMode;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckedListBox cblType;
    }
}

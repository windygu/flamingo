namespace Flamingo.TheaterManage
{
    partial class frmDiscountManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscount_TypeId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTheaterId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.cbPrice = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelDiscountPrice = new System.Windows.Forms.Button();
            this.btnAddDiscountPrice = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscountPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscountTypeName = new System.Windows.Forms.TextBox();
            this.btnDelDiscountTypeName = new System.Windows.Forms.Button();
            this.btnAddDiscountTypeName = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panDiscountPrice = new System.Windows.Forms.Panel();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
            this.lblPriceListTitle = new System.Windows.Forms.Label();
            this.btnAddDiscontInfo = new System.Windows.Forms.Button();
            this.btnDelDiscountInfo = new System.Windows.Forms.Button();
            this.btnDelPrice = new System.Windows.Forms.Button();
            this.btnAddPrice = new System.Windows.Forms.Button();
            this.btnDelDiscountType = new System.Windows.Forms.Button();
            this.btnAddDiscountType = new System.Windows.Forms.Button();
            this.lblTypeListTitle = new System.Windows.Forms.Label();
            this.panDiscountType = new System.Windows.Forms.Panel();
            this.dgvTypeList = new System.Windows.Forms.DataGridView();
            this.btnSavePrice = new System.Windows.Forms.Button();
            this.btnSaveDiscount_Type = new System.Windows.Forms.Button();
            this.btnSaveType = new System.Windows.Forms.Button();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panDiscountPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            this.panDiscountType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtDiscountName);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(792, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtDiscountName, 0);
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
            this.btnSave.Location = new System.Drawing.Point(622, 10);
            this.btnSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(510, 10);
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(686, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(566, 10);
            this.btnAdd.Visible = false;
            // 
            // panList
            // 
            this.panList.Location = new System.Drawing.Point(240, 185);
            this.panList.Size = new System.Drawing.Size(200, 214);
            this.panList.MouseLeave += new System.EventHandler(this.dgvList_MouseLeave);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(198, 22);
            this.lblListTitle.Text = " 特价信息表";
            // 
            // panDetail
            // 
            this.panDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(273, 56);
            this.panDetail.Size = new System.Drawing.Size(371, 82);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(371, 23);
            this.lblDetailTitle.Text = "特价关联信息";
            this.lblDetailTitle.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按特价类型名称查询:";
            this.label1.Visible = false;
            // 
            // txtDiscountName
            // 
            this.txtDiscountName.Location = new System.Drawing.Point(126, 19);
            this.txtDiscountName.Name = "txtDiscountName";
            this.txtDiscountName.Size = new System.Drawing.Size(173, 21);
            this.txtDiscountName.TabIndex = 4;
            this.txtDiscountName.Visible = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(305, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Visible = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "特价价格";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "特价类型名称";
            // 
            // txtDiscount_TypeId
            // 
            this.txtDiscount_TypeId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscount_TypeId.Enabled = false;
            this.txtDiscount_TypeId.Location = new System.Drawing.Point(95, 4);
            this.txtDiscount_TypeId.Name = "txtDiscount_TypeId";
            this.txtDiscount_TypeId.Size = new System.Drawing.Size(102, 21);
            this.txtDiscount_TypeId.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "特价类型编号";
            // 
            // txtTheaterId
            // 
            this.txtTheaterId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTheaterId.Location = new System.Drawing.Point(271, 30);
            this.txtTheaterId.Name = "txtTheaterId";
            this.txtTheaterId.Size = new System.Drawing.Size(94, 21);
            this.txtTheaterId.TabIndex = 28;
            this.txtTheaterId.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "影院Id";
            this.label5.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel1.Controls.Add(this.cbTypeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDiscount_TypeId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTheaterId, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbPrice, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 53);
            this.tableLayoutPanel1.TabIndex = 23;
            this.tableLayoutPanel1.Visible = false;
            // 
            // cbTypeName
            // 
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Location = new System.Drawing.Point(95, 30);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(102, 20);
            this.cbTypeName.TabIndex = 30;
            // 
            // cbPrice
            // 
            this.cbPrice.FormattingEnabled = true;
            this.cbPrice.Location = new System.Drawing.Point(271, 4);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(94, 20);
            this.cbPrice.TabIndex = 29;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 260);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDelDiscountPrice);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddDiscountPrice);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelDiscountTypeName);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddDiscountTypeName);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(785, 102);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnDelDiscountPrice
            // 
            this.btnDelDiscountPrice.Location = new System.Drawing.Point(316, 0);
            this.btnDelDiscountPrice.Name = "btnDelDiscountPrice";
            this.btnDelDiscountPrice.Size = new System.Drawing.Size(75, 23);
            this.btnDelDiscountPrice.TabIndex = 2;
            this.btnDelDiscountPrice.Text = "删除";
            this.btnDelDiscountPrice.UseVisualStyleBackColor = true;
            this.btnDelDiscountPrice.Click += new System.EventHandler(this.btnDelDiscountPrice_Click);
            // 
            // btnAddDiscountPrice
            // 
            this.btnAddDiscountPrice.Location = new System.Drawing.Point(235, 0);
            this.btnAddDiscountPrice.Name = "btnAddDiscountPrice";
            this.btnAddDiscountPrice.Size = new System.Drawing.Size(75, 23);
            this.btnAddDiscountPrice.TabIndex = 1;
            this.btnAddDiscountPrice.Text = "增加";
            this.btnAddDiscountPrice.UseVisualStyleBackColor = true;
            this.btnAddDiscountPrice.Click += new System.EventHandler(this.btnAddDiscountPrice_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.52174F));
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDiscountPrice, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 45);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "特价价格";
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscountPrice.Location = new System.Drawing.Point(93, 4);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Size = new System.Drawing.Size(110, 21);
            this.txtDiscountPrice.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "特价价格信息";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtDiscountTypeName, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(216, 45);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "特价类型";
            // 
            // txtDiscountTypeName
            // 
            this.txtDiscountTypeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscountTypeName.Location = new System.Drawing.Point(93, 4);
            this.txtDiscountTypeName.Name = "txtDiscountTypeName";
            this.txtDiscountTypeName.Size = new System.Drawing.Size(119, 21);
            this.txtDiscountTypeName.TabIndex = 32;
            // 
            // btnDelDiscountTypeName
            // 
            this.btnDelDiscountTypeName.Location = new System.Drawing.Point(306, 0);
            this.btnDelDiscountTypeName.Name = "btnDelDiscountTypeName";
            this.btnDelDiscountTypeName.Size = new System.Drawing.Size(75, 23);
            this.btnDelDiscountTypeName.TabIndex = 4;
            this.btnDelDiscountTypeName.Text = "删除";
            this.btnDelDiscountTypeName.UseVisualStyleBackColor = true;
            this.btnDelDiscountTypeName.Click += new System.EventHandler(this.btnDelDiscountTypeName_Click);
            // 
            // btnAddDiscountTypeName
            // 
            this.btnAddDiscountTypeName.Location = new System.Drawing.Point(225, 0);
            this.btnAddDiscountTypeName.Name = "btnAddDiscountTypeName";
            this.btnAddDiscountTypeName.Size = new System.Drawing.Size(75, 23);
            this.btnAddDiscountTypeName.TabIndex = 3;
            this.btnAddDiscountTypeName.Text = "增加";
            this.btnAddDiscountTypeName.UseVisualStyleBackColor = true;
            this.btnAddDiscountTypeName.Click += new System.EventHandler(this.btnAddDiscountTypeName_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(387, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "特价类型信息";
            // 
            // panDiscountPrice
            // 
            this.panDiscountPrice.BackColor = System.Drawing.Color.White;
            this.panDiscountPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDiscountPrice.Controls.Add(this.dgvPriceList);
            this.panDiscountPrice.Controls.Add(this.lblPriceListTitle);
            this.panDiscountPrice.Location = new System.Drawing.Point(32, 185);
            this.panDiscountPrice.Name = "panDiscountPrice";
            this.panDiscountPrice.Size = new System.Drawing.Size(200, 214);
            this.panDiscountPrice.TabIndex = 5;
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.AllowUserToAddRows = false;
            this.dgvPriceList.AllowUserToDeleteRows = false;
            this.dgvPriceList.AllowUserToResizeColumns = false;
            this.dgvPriceList.AllowUserToResizeRows = false;
            this.dgvPriceList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPriceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPriceList.EnableHeadersVisualStyles = false;
            this.dgvPriceList.Location = new System.Drawing.Point(0, 23);
            this.dgvPriceList.MultiSelect = false;
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPriceList.RowTemplate.Height = 23;
            this.dgvPriceList.Size = new System.Drawing.Size(198, 189);
            this.dgvPriceList.TabIndex = 1;
            this.dgvPriceList.TabStop = false;
            // 
            // lblPriceListTitle
            // 
            this.lblPriceListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblPriceListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPriceListTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriceListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPriceListTitle.Name = "lblPriceListTitle";
            this.lblPriceListTitle.Size = new System.Drawing.Size(198, 23);
            this.lblPriceListTitle.TabIndex = 0;
            this.lblPriceListTitle.Text = "特价价格表";
            this.lblPriceListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddDiscontInfo
            // 
            this.btnAddDiscontInfo.Location = new System.Drawing.Point(371, 156);
            this.btnAddDiscontInfo.Name = "btnAddDiscontInfo";
            this.btnAddDiscontInfo.Size = new System.Drawing.Size(43, 23);
            this.btnAddDiscontInfo.TabIndex = 6;
            this.btnAddDiscontInfo.Text = "新增";
            this.btnAddDiscontInfo.UseVisualStyleBackColor = true;
            this.btnAddDiscontInfo.Click += new System.EventHandler(this.btnAddDiscontInfo_Click);
            // 
            // btnDelDiscountInfo
            // 
            this.btnDelDiscountInfo.Location = new System.Drawing.Point(420, 156);
            this.btnDelDiscountInfo.Name = "btnDelDiscountInfo";
            this.btnDelDiscountInfo.Size = new System.Drawing.Size(43, 23);
            this.btnDelDiscountInfo.TabIndex = 7;
            this.btnDelDiscountInfo.Text = "删除";
            this.btnDelDiscountInfo.UseVisualStyleBackColor = true;
            this.btnDelDiscountInfo.Click += new System.EventHandler(this.btnDelDiscountInfo_Click);
            // 
            // btnDelPrice
            // 
            this.btnDelPrice.Location = new System.Drawing.Point(160, 156);
            this.btnDelPrice.Name = "btnDelPrice";
            this.btnDelPrice.Size = new System.Drawing.Size(43, 23);
            this.btnDelPrice.TabIndex = 9;
            this.btnDelPrice.Text = "删除";
            this.btnDelPrice.UseVisualStyleBackColor = true;
            this.btnDelPrice.Click += new System.EventHandler(this.btnDelDiscountPrice_Click);
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(111, 156);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(43, 23);
            this.btnAddPrice.TabIndex = 8;
            this.btnAddPrice.Text = "新增";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddDiscountPrice_Click);
            // 
            // btnDelDiscountType
            // 
            this.btnDelDiscountType.Location = new System.Drawing.Point(708, 156);
            this.btnDelDiscountType.Name = "btnDelDiscountType";
            this.btnDelDiscountType.Size = new System.Drawing.Size(43, 23);
            this.btnDelDiscountType.TabIndex = 11;
            this.btnDelDiscountType.Text = "删除";
            this.btnDelDiscountType.UseVisualStyleBackColor = true;
            this.btnDelDiscountType.Click += new System.EventHandler(this.btnDelDiscountTypeName_Click);
            // 
            // btnAddDiscountType
            // 
            this.btnAddDiscountType.Location = new System.Drawing.Point(661, 156);
            this.btnAddDiscountType.Name = "btnAddDiscountType";
            this.btnAddDiscountType.Size = new System.Drawing.Size(43, 23);
            this.btnAddDiscountType.TabIndex = 10;
            this.btnAddDiscountType.Text = "新增";
            this.btnAddDiscountType.UseVisualStyleBackColor = true;
            this.btnAddDiscountType.Click += new System.EventHandler(this.btnAddDiscountTypeName_Click);
            // 
            // lblTypeListTitle
            // 
            this.lblTypeListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.lblTypeListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTypeListTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTypeListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTypeListTitle.Name = "lblTypeListTitle";
            this.lblTypeListTitle.Size = new System.Drawing.Size(198, 22);
            this.lblTypeListTitle.TabIndex = 12;
            this.lblTypeListTitle.Text = " 特价类型表";
            this.lblTypeListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panDiscountType
            // 
            this.panDiscountType.BackColor = System.Drawing.Color.White;
            this.panDiscountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDiscountType.Controls.Add(this.dgvTypeList);
            this.panDiscountType.Controls.Add(this.lblTypeListTitle);
            this.panDiscountType.Location = new System.Drawing.Point(566, 185);
            this.panDiscountType.Name = "panDiscountType";
            this.panDiscountType.Size = new System.Drawing.Size(200, 214);
            this.panDiscountType.TabIndex = 13;
            // 
            // dgvTypeList
            // 
            this.dgvTypeList.AllowUserToAddRows = false;
            this.dgvTypeList.AllowUserToDeleteRows = false;
            this.dgvTypeList.AllowUserToResizeColumns = false;
            this.dgvTypeList.AllowUserToResizeRows = false;
            this.dgvTypeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTypeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTypeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTypeList.EnableHeadersVisualStyles = false;
            this.dgvTypeList.Location = new System.Drawing.Point(0, 22);
            this.dgvTypeList.Name = "dgvTypeList";
            this.dgvTypeList.RowHeadersVisible = false;
            this.dgvTypeList.RowTemplate.Height = 23;
            this.dgvTypeList.Size = new System.Drawing.Size(198, 190);
            this.dgvTypeList.TabIndex = 13;
            // 
            // btnSavePrice
            // 
            this.btnSavePrice.Location = new System.Drawing.Point(62, 156);
            this.btnSavePrice.Name = "btnSavePrice";
            this.btnSavePrice.Size = new System.Drawing.Size(43, 23);
            this.btnSavePrice.TabIndex = 14;
            this.btnSavePrice.Text = "保存";
            this.btnSavePrice.UseVisualStyleBackColor = true;
            this.btnSavePrice.Click += new System.EventHandler(this.btnSavePrice_Click);
            // 
            // btnSaveDiscount_Type
            // 
            this.btnSaveDiscount_Type.Location = new System.Drawing.Point(323, 156);
            this.btnSaveDiscount_Type.Name = "btnSaveDiscount_Type";
            this.btnSaveDiscount_Type.Size = new System.Drawing.Size(43, 23);
            this.btnSaveDiscount_Type.TabIndex = 15;
            this.btnSaveDiscount_Type.Text = "保存";
            this.btnSaveDiscount_Type.UseVisualStyleBackColor = true;
            this.btnSaveDiscount_Type.Click += new System.EventHandler(this.btnSavePrice_Click);
            // 
            // btnSaveType
            // 
            this.btnSaveType.Location = new System.Drawing.Point(612, 156);
            this.btnSaveType.Name = "btnSaveType";
            this.btnSaveType.Size = new System.Drawing.Size(43, 23);
            this.btnSaveType.TabIndex = 16;
            this.btnSaveType.Text = "保存";
            this.btnSaveType.UseVisualStyleBackColor = true;
            this.btnSaveType.Click += new System.EventHandler(this.btnSavePrice_Click);
            // 
            // frmDiscountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSaveType);
            this.Controls.Add(this.btnSaveDiscount_Type);
            this.Controls.Add(this.btnSavePrice);
            this.Controls.Add(this.btnDelDiscountType);
            this.Controls.Add(this.btnAddDiscountType);
            this.Controls.Add(this.btnDelDiscountInfo);
            this.Controls.Add(this.btnAddPrice);
            this.Controls.Add(this.btnAddDiscontInfo);
            this.Controls.Add(this.panDiscountType);
            this.Controls.Add(this.btnDelPrice);
            this.Controls.Add(this.panDiscountPrice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiscountManage";
            this.Text = "特价信息管理";
            this.Controls.SetChildIndex(this.panDiscountPrice, 0);
            this.Controls.SetChildIndex(this.btnDelPrice, 0);
            this.Controls.SetChildIndex(this.panList, 0);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.panTop, 0);
            this.Controls.SetChildIndex(this.panDiscountType, 0);
            this.Controls.SetChildIndex(this.btnAddDiscontInfo, 0);
            this.Controls.SetChildIndex(this.btnAddPrice, 0);
            this.Controls.SetChildIndex(this.btnDelDiscountInfo, 0);
            this.Controls.SetChildIndex(this.btnAddDiscountType, 0);
            this.Controls.SetChildIndex(this.btnDelDiscountType, 0);
            this.Controls.SetChildIndex(this.btnSavePrice, 0);
            this.Controls.SetChildIndex(this.btnSaveDiscount_Type, 0);
            this.Controls.SetChildIndex(this.btnSaveType, 0);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panDiscountPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            this.panDiscountType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscountName;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscount_TypeId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTheaterId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbPrice;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelDiscountPrice;
        private System.Windows.Forms.Button btnAddDiscountPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelDiscountTypeName;
        private System.Windows.Forms.Button btnAddDiscountTypeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.TextBox txtDiscountPrice;
        private System.Windows.Forms.TextBox txtDiscountTypeName;
        private System.Windows.Forms.Panel panDiscountPrice;
        private System.Windows.Forms.DataGridView dgvPriceList;
        private System.Windows.Forms.Label lblPriceListTitle;
        private System.Windows.Forms.Button btnAddDiscontInfo;
        private System.Windows.Forms.Button btnDelDiscountInfo;
        private System.Windows.Forms.Button btnDelPrice;
        private System.Windows.Forms.Button btnAddPrice;
        private System.Windows.Forms.Button btnDelDiscountType;
        private System.Windows.Forms.Button btnAddDiscountType;
        private System.Windows.Forms.Label lblTypeListTitle;
        private System.Windows.Forms.Panel panDiscountType;
        private System.Windows.Forms.DataGridView dgvTypeList;
        private System.Windows.Forms.Button btnSavePrice;
        private System.Windows.Forms.Button btnSaveDiscount_Type;
        private System.Windows.Forms.Button btnSaveType;
    }
}

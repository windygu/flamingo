namespace Flamingo.ShowPlanManage
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.tsPriceSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsTheterPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHallPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPeriodPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFilmPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowPlanPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBlockPriceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFilmSetting = new System.Windows.Forms.ToolStripButton();
            this.tmBasicQuery = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFilmBoxOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHallBoxOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDayBoxOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPeriodBoxOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQuickQuery = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFilmCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFilmName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRatio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTotal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCount_Ticket = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeats = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEmity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCount_Refund = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsCopy = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsPrint = new System.Windows.Forms.ToolStripButton();
            this.tsApproved = new System.Windows.Forms.ToolStripButton();
            this.tsSale = new System.Windows.Forms.ToolStripButton();
            this.scSplit = new System.Windows.Forms.SplitContainer();
            this.gbOperation = new System.Windows.Forms.GroupBox();
            this.lnkDeleteHallPlan = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteShow = new System.Windows.Forms.LinkLabel();
            this.lnkRecordPlan = new System.Windows.Forms.LinkLabel();
            this.gbFilm = new System.Windows.Forms.GroupBox();
            this.flPanFilm = new System.Windows.Forms.FlowLayoutPanel();
            this.panShowPlanContainer = new System.Windows.Forms.Panel();
            this.spPanShowPlan = new Flamingo.ShowPlanManage.ShowPlanPanel();
            this.panQuery = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDefultTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTodayPlan = new System.Windows.Forms.Button();
            this.dtDateTime = new System.Windows.Forms.DateTimePicker();
            this.txtTheter = new System.Windows.Forms.TextBox();
            this.panState = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblColorOfIsStopSale = new System.Windows.Forms.Label();
            this.lblColorOfIsUnSale = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblColorOfIsSale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIsSave = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.panTitle = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmExit = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.panFooter = new System.Windows.Forms.Panel();
            this.tsTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSplit)).BeginInit();
            this.scSplit.Panel1.SuspendLayout();
            this.scSplit.Panel2.SuspendLayout();
            this.scSplit.SuspendLayout();
            this.gbOperation.SuspendLayout();
            this.gbFilm.SuspendLayout();
            this.panShowPlanContainer.SuspendLayout();
            this.panQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefultTimeSpan)).BeginInit();
            this.panState.SuspendLayout();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTool
            // 
            this.tsTool.AutoSize = false;
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPriceSet,
            this.tsFilmSetting,
            this.tmBasicQuery,
            this.tsQuickQuery,
            this.tsSave,
            this.tsCopy,
            this.tsDelete,
            this.tsPrint,
            this.tsApproved,
            this.tsSale});
            this.tsTool.Location = new System.Drawing.Point(0, 69);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(1016, 30);
            this.tsTool.TabIndex = 1;
            this.tsTool.Text = "工具栏";
            // 
            // tsPriceSet
            // 
            this.tsPriceSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTheterPriceSet,
            this.tsHallPriceSet,
            this.tsPeriodPriceSet,
            this.tsFilmPriceSet,
            this.tsShowPlanPriceSet,
            this.tsBlockPriceSet});
            this.tsPriceSet.Font = new System.Drawing.Font("宋体", 9F);
            this.tsPriceSet.Image = global::WinFormUI.Properties.Resources.FareSetting;
            this.tsPriceSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPriceSet.ImageTransparentColor = System.Drawing.SystemColors.AppWorkspace;
            this.tsPriceSet.Name = "tsPriceSet";
            this.tsPriceSet.Size = new System.Drawing.Size(91, 27);
            this.tsPriceSet.Text = "票价设置";
            // 
            // tsTheterPriceSet
            // 
            this.tsTheterPriceSet.Name = "tsTheterPriceSet";
            this.tsTheterPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsTheterPriceSet.Text = "全场票价";
            this.tsTheterPriceSet.Click += new System.EventHandler(this.tsTheterPriceSet_Click);
            // 
            // tsHallPriceSet
            // 
            this.tsHallPriceSet.Name = "tsHallPriceSet";
            this.tsHallPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsHallPriceSet.Text = "分厅票价";
            this.tsHallPriceSet.Click += new System.EventHandler(this.tsHallPriceSet_Click);
            // 
            // tsPeriodPriceSet
            // 
            this.tsPeriodPriceSet.Name = "tsPeriodPriceSet";
            this.tsPeriodPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsPeriodPriceSet.Text = "时段票价";
            this.tsPeriodPriceSet.Click += new System.EventHandler(this.tsPeriodPriceSet_Click);
            // 
            // tsFilmPriceSet
            // 
            this.tsFilmPriceSet.Name = "tsFilmPriceSet";
            this.tsFilmPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsFilmPriceSet.Text = "分片票价";
            this.tsFilmPriceSet.Click += new System.EventHandler(this.tsFilmPriceSet_Click);
            // 
            // tsShowPlanPriceSet
            // 
            this.tsShowPlanPriceSet.Name = "tsShowPlanPriceSet";
            this.tsShowPlanPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsShowPlanPriceSet.Text = "分场票价";
            this.tsShowPlanPriceSet.Click += new System.EventHandler(this.tsShowPlanPriceSet_Click);
            // 
            // tsBlockPriceSet
            // 
            this.tsBlockPriceSet.Name = "tsBlockPriceSet";
            this.tsBlockPriceSet.Size = new System.Drawing.Size(118, 22);
            this.tsBlockPriceSet.Text = "区域票价";
            this.tsBlockPriceSet.Click += new System.EventHandler(this.tsBlockPriceSet_Click);
            // 
            // tsFilmSetting
            // 
            this.tsFilmSetting.Font = new System.Drawing.Font("宋体", 9F);
            this.tsFilmSetting.Image = global::WinFormUI.Properties.Resources.FilmSetting;
            this.tsFilmSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFilmSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFilmSetting.Name = "tsFilmSetting";
            this.tsFilmSetting.Size = new System.Drawing.Size(82, 27);
            this.tsFilmSetting.Text = "影片设置";
            this.tsFilmSetting.Click += new System.EventHandler(this.tsFilmSetting_Click);
            // 
            // tmBasicQuery
            // 
            this.tmBasicQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFilmBoxOffice,
            this.tsHallBoxOffice,
            this.tsDayBoxOffice,
            this.tsPeriodBoxOffice});
            this.tmBasicQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.tmBasicQuery.Image = global::WinFormUI.Properties.Resources.BasicQuery;
            this.tmBasicQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmBasicQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmBasicQuery.Name = "tmBasicQuery";
            this.tmBasicQuery.Size = new System.Drawing.Size(91, 27);
            this.tmBasicQuery.Text = "基础查询";
            // 
            // tsFilmBoxOffice
            // 
            this.tsFilmBoxOffice.Name = "tsFilmBoxOffice";
            this.tsFilmBoxOffice.Size = new System.Drawing.Size(142, 22);
            this.tsFilmBoxOffice.Text = "单片票房查询";
            this.tsFilmBoxOffice.Click += new System.EventHandler(this.tsFilmBoxOffice_Click);
            // 
            // tsHallBoxOffice
            // 
            this.tsHallBoxOffice.Name = "tsHallBoxOffice";
            this.tsHallBoxOffice.Size = new System.Drawing.Size(142, 22);
            this.tsHallBoxOffice.Text = "单厅票房查询";
            this.tsHallBoxOffice.Click += new System.EventHandler(this.tsHallBoxOffice_Click);
            // 
            // tsDayBoxOffice
            // 
            this.tsDayBoxOffice.Name = "tsDayBoxOffice";
            this.tsDayBoxOffice.Size = new System.Drawing.Size(142, 22);
            this.tsDayBoxOffice.Text = "单日票房查询";
            this.tsDayBoxOffice.Click += new System.EventHandler(this.tsDayBoxOffice_Click);
            // 
            // tsPeriodBoxOffice
            // 
            this.tsPeriodBoxOffice.Name = "tsPeriodBoxOffice";
            this.tsPeriodBoxOffice.Size = new System.Drawing.Size(142, 22);
            this.tsPeriodBoxOffice.Text = "时段票房查询";
            this.tsPeriodBoxOffice.Click += new System.EventHandler(this.tsPeriodBoxOffice_Click);
            // 
            // tsQuickQuery
            // 
            this.tsQuickQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFilmCode,
            this.tsFilmName,
            this.tsRatio,
            this.tsTotal,
            this.tsPrice,
            this.tsCount_Ticket,
            this.tsSeats,
            this.tsEmity,
            this.tsCount_Refund,
            this.tsRate});
            this.tsQuickQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.tsQuickQuery.Image = global::WinFormUI.Properties.Resources.QuickQuery;
            this.tsQuickQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsQuickQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQuickQuery.Name = "tsQuickQuery";
            this.tsQuickQuery.Size = new System.Drawing.Size(91, 27);
            this.tsQuickQuery.Text = "快速查询";
            // 
            // tsFilmCode
            // 
            this.tsFilmCode.Name = "tsFilmCode";
            this.tsFilmCode.Size = new System.Drawing.Size(190, 22);
            this.tsFilmCode.Text = "各场影片编码查询";
            this.tsFilmCode.Click += new System.EventHandler(this.tsFilmCode_Click);
            // 
            // tsFilmName
            // 
            this.tsFilmName.Name = "tsFilmName";
            this.tsFilmName.Size = new System.Drawing.Size(190, 22);
            this.tsFilmName.Text = "各场影片片名查询";
            this.tsFilmName.Click += new System.EventHandler(this.tsFilmName_Click);
            // 
            // tsRatio
            // 
            this.tsRatio.Name = "tsRatio";
            this.tsRatio.Size = new System.Drawing.Size(190, 22);
            this.tsRatio.Text = "各场影片分账比例查询";
            this.tsRatio.Click += new System.EventHandler(this.tsRatio_Click);
            // 
            // tsTotal
            // 
            this.tsTotal.Name = "tsTotal";
            this.tsTotal.Size = new System.Drawing.Size(190, 22);
            this.tsTotal.Text = "各场票房查询";
            this.tsTotal.Click += new System.EventHandler(this.tsTotal_Click);
            // 
            // tsPrice
            // 
            this.tsPrice.Name = "tsPrice";
            this.tsPrice.Size = new System.Drawing.Size(190, 22);
            this.tsPrice.Text = "各场票价查询";
            this.tsPrice.Click += new System.EventHandler(this.tsPrice_Click);
            // 
            // tsCount_Ticket
            // 
            this.tsCount_Ticket.Name = "tsCount_Ticket";
            this.tsCount_Ticket.Size = new System.Drawing.Size(190, 22);
            this.tsCount_Ticket.Text = "各场观众查询";
            this.tsCount_Ticket.Click += new System.EventHandler(this.tsCount_Ticket_Click);
            // 
            // tsSeats
            // 
            this.tsSeats.Name = "tsSeats";
            this.tsSeats.Size = new System.Drawing.Size(190, 22);
            this.tsSeats.Text = "各场座位查询";
            this.tsSeats.Click += new System.EventHandler(this.tsSeats_Click);
            // 
            // tsEmity
            // 
            this.tsEmity.Name = "tsEmity";
            this.tsEmity.Size = new System.Drawing.Size(190, 22);
            this.tsEmity.Text = "各场空座查询";
            this.tsEmity.Click += new System.EventHandler(this.tsEmity_Click);
            // 
            // tsCount_Refund
            // 
            this.tsCount_Refund.Name = "tsCount_Refund";
            this.tsCount_Refund.Size = new System.Drawing.Size(190, 22);
            this.tsCount_Refund.Text = "各场退票查询";
            this.tsCount_Refund.Click += new System.EventHandler(this.tsCount_Refund_Click);
            // 
            // tsRate
            // 
            this.tsRate.Name = "tsRate";
            this.tsRate.Size = new System.Drawing.Size(190, 22);
            this.tsRate.Text = "各场上座率查询";
            this.tsRate.Click += new System.EventHandler(this.tsRate_Click);
            // 
            // tsSave
            // 
            this.tsSave.Font = new System.Drawing.Font("宋体", 9F);
            this.tsSave.Image = global::WinFormUI.Properties.Resources.Save;
            this.tsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(82, 27);
            this.tsSave.Text = "保存计划";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsCopy
            // 
            this.tsCopy.Font = new System.Drawing.Font("宋体", 9F);
            this.tsCopy.Image = global::WinFormUI.Properties.Resources.Copy;
            this.tsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(82, 27);
            this.tsCopy.Text = "复制计划";
            this.tsCopy.Click += new System.EventHandler(this.tsCopy_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Font = new System.Drawing.Font("宋体", 9F);
            this.tsDelete.Image = global::WinFormUI.Properties.Resources.Delete;
            this.tsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(82, 27);
            this.tsDelete.Text = "删除计划";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsPrint
            // 
            this.tsPrint.Font = new System.Drawing.Font("宋体", 9F);
            this.tsPrint.Image = global::WinFormUI.Properties.Resources.Print;
            this.tsPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(58, 27);
            this.tsPrint.Text = "打印";
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // tsApproved
            // 
            this.tsApproved.Enabled = false;
            this.tsApproved.Font = new System.Drawing.Font("宋体", 9F);
            this.tsApproved.Image = global::WinFormUI.Properties.Resources.Print;
            this.tsApproved.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsApproved.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsApproved.Name = "tsApproved";
            this.tsApproved.Size = new System.Drawing.Size(82, 27);
            this.tsApproved.Text = "上报审核";
            this.tsApproved.Visible = false;
            this.tsApproved.Click += new System.EventHandler(this.tsApproved_Click);
            // 
            // tsSale
            // 
            this.tsSale.Enabled = false;
            this.tsSale.Font = new System.Drawing.Font("宋体", 9F);
            this.tsSale.Image = global::WinFormUI.Properties.Resources.Print;
            this.tsSale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSale.Name = "tsSale";
            this.tsSale.Size = new System.Drawing.Size(82, 27);
            this.tsSale.Text = "可售设置";
            this.tsSale.Click += new System.EventHandler(this.tsSale_Click);
            // 
            // scSplit
            // 
            this.scSplit.BackColor = System.Drawing.Color.White;
            this.scSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSplit.IsSplitterFixed = true;
            this.scSplit.Location = new System.Drawing.Point(0, 99);
            this.scSplit.Name = "scSplit";
            // 
            // scSplit.Panel1
            // 
            this.scSplit.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.scSplit.Panel1.Controls.Add(this.gbOperation);
            this.scSplit.Panel1.Controls.Add(this.gbFilm);
            // 
            // scSplit.Panel2
            // 
            this.scSplit.Panel2.Controls.Add(this.panShowPlanContainer);
            this.scSplit.Panel2.Controls.Add(this.panQuery);
            this.scSplit.Panel2.Controls.Add(this.panState);
            this.scSplit.Size = new System.Drawing.Size(1016, 616);
            this.scSplit.SplitterDistance = 168;
            this.scSplit.SplitterWidth = 1;
            this.scSplit.TabIndex = 2;
            // 
            // gbOperation
            // 
            this.gbOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOperation.Controls.Add(this.lnkDeleteHallPlan);
            this.gbOperation.Controls.Add(this.lnkDeleteShow);
            this.gbOperation.Controls.Add(this.lnkRecordPlan);
            this.gbOperation.ForeColor = System.Drawing.Color.Black;
            this.gbOperation.Location = new System.Drawing.Point(3, 493);
            this.gbOperation.Name = "gbOperation";
            this.gbOperation.Size = new System.Drawing.Size(162, 120);
            this.gbOperation.TabIndex = 1;
            this.gbOperation.TabStop = false;
            this.gbOperation.Text = "操作";
            // 
            // lnkDeleteHallPlan
            // 
            this.lnkDeleteHallPlan.Font = new System.Drawing.Font("宋体", 9F);
            this.lnkDeleteHallPlan.Image = global::WinFormUI.Properties.Resources.DeleteHallPlan;
            this.lnkDeleteHallPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkDeleteHallPlan.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkDeleteHallPlan.LinkColor = System.Drawing.Color.Black;
            this.lnkDeleteHallPlan.Location = new System.Drawing.Point(12, 90);
            this.lnkDeleteHallPlan.Name = "lnkDeleteHallPlan";
            this.lnkDeleteHallPlan.Size = new System.Drawing.Size(90, 23);
            this.lnkDeleteHallPlan.TabIndex = 3;
            this.lnkDeleteHallPlan.TabStop = true;
            this.lnkDeleteHallPlan.Text = "分厅删除";
            this.lnkDeleteHallPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkDeleteHallPlan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteHallPlan_LinkClicked);
            // 
            // lnkDeleteShow
            // 
            this.lnkDeleteShow.Font = new System.Drawing.Font("宋体", 9F);
            this.lnkDeleteShow.Image = global::WinFormUI.Properties.Resources.DeleteShow;
            this.lnkDeleteShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkDeleteShow.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkDeleteShow.LinkColor = System.Drawing.Color.Black;
            this.lnkDeleteShow.Location = new System.Drawing.Point(12, 60);
            this.lnkDeleteShow.Name = "lnkDeleteShow";
            this.lnkDeleteShow.Size = new System.Drawing.Size(90, 23);
            this.lnkDeleteShow.TabIndex = 2;
            this.lnkDeleteShow.TabStop = true;
            this.lnkDeleteShow.Text = "分场删除";
            this.lnkDeleteShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkDeleteShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteShow_LinkClicked);
            // 
            // lnkRecordPlan
            // 
            this.lnkRecordPlan.Font = new System.Drawing.Font("宋体", 9F);
            this.lnkRecordPlan.Image = global::WinFormUI.Properties.Resources.RecordPlan;
            this.lnkRecordPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkRecordPlan.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRecordPlan.LinkColor = System.Drawing.Color.Black;
            this.lnkRecordPlan.Location = new System.Drawing.Point(12, 30);
            this.lnkRecordPlan.Name = "lnkRecordPlan";
            this.lnkRecordPlan.Size = new System.Drawing.Size(90, 23);
            this.lnkRecordPlan.TabIndex = 1;
            this.lnkRecordPlan.TabStop = true;
            this.lnkRecordPlan.Text = "录入编制";
            this.lnkRecordPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkRecordPlan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRecordPlan_LinkClicked);
            // 
            // gbFilm
            // 
            this.gbFilm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilm.Controls.Add(this.flPanFilm);
            this.gbFilm.ForeColor = System.Drawing.Color.Black;
            this.gbFilm.Location = new System.Drawing.Point(3, 3);
            this.gbFilm.Name = "gbFilm";
            this.gbFilm.Size = new System.Drawing.Size(162, 491);
            this.gbFilm.TabIndex = 0;
            this.gbFilm.TabStop = false;
            this.gbFilm.Text = "上映影片";
            // 
            // flPanFilm
            // 
            this.flPanFilm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flPanFilm.AutoScroll = true;
            this.flPanFilm.Location = new System.Drawing.Point(3, 17);
            this.flPanFilm.Name = "flPanFilm";
            this.flPanFilm.Size = new System.Drawing.Size(156, 471);
            this.flPanFilm.TabIndex = 0;
            // 
            // panShowPlanContainer
            // 
            this.panShowPlanContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panShowPlanContainer.AutoScroll = true;
            this.panShowPlanContainer.Controls.Add(this.spPanShowPlan);
            this.panShowPlanContainer.Location = new System.Drawing.Point(0, 40);
            this.panShowPlanContainer.Name = "panShowPlanContainer";
            this.panShowPlanContainer.Size = new System.Drawing.Size(863, 536);
            this.panShowPlanContainer.TabIndex = 4;
            // 
            // spPanShowPlan
            // 
            this.spPanShowPlan.AllowDrop = true;
            this.spPanShowPlan.BackColor = System.Drawing.Color.White;
            this.spPanShowPlan.DataManager = null;
            this.spPanShowPlan.DataSource = null;
            this.spPanShowPlan.IsSave = false;
            this.spPanShowPlan.Location = new System.Drawing.Point(0, 0);
            this.spPanShowPlan.Name = "spPanShowPlan";
            this.spPanShowPlan.Size = new System.Drawing.Size(848, 536);
            this.spPanShowPlan.TabIndex = 3;
            // 
            // panQuery
            // 
            this.panQuery.BackColor = System.Drawing.Color.Silver;
            this.panQuery.Controls.Add(this.label3);
            this.panQuery.Controls.Add(this.nudDefultTimeSpan);
            this.panQuery.Controls.Add(this.label2);
            this.panQuery.Controls.Add(this.label1);
            this.panQuery.Controls.Add(this.btnTodayPlan);
            this.panQuery.Controls.Add(this.dtDateTime);
            this.panQuery.Controls.Add(this.txtTheter);
            this.panQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panQuery.Location = new System.Drawing.Point(0, 0);
            this.panQuery.Name = "panQuery";
            this.panQuery.Size = new System.Drawing.Size(847, 40);
            this.panQuery.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "分钟";
            // 
            // nudDefultTimeSpan
            // 
            this.nudDefultTimeSpan.Location = new System.Drawing.Point(601, 10);
            this.nudDefultTimeSpan.Name = "nudDefultTimeSpan";
            this.nudDefultTimeSpan.Size = new System.Drawing.Size(35, 21);
            this.nudDefultTimeSpan.TabIndex = 2;
            this.nudDefultTimeSpan.ValueChanged += new System.EventHandler(this.nudDefultTimeSpan_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "默认最小场间隔";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影院";
            // 
            // btnTodayPlan
            // 
            this.btnTodayPlan.Location = new System.Drawing.Point(395, 9);
            this.btnTodayPlan.Name = "btnTodayPlan";
            this.btnTodayPlan.Size = new System.Drawing.Size(90, 23);
            this.btnTodayPlan.TabIndex = 3;
            this.btnTodayPlan.Text = "当日计划列表";
            this.btnTodayPlan.UseVisualStyleBackColor = true;
            this.btnTodayPlan.Click += new System.EventHandler(this.btnTodayPlan_Click);
            // 
            // dtDateTime
            // 
            this.dtDateTime.Location = new System.Drawing.Point(256, 10);
            this.dtDateTime.Name = "dtDateTime";
            this.dtDateTime.Size = new System.Drawing.Size(110, 21);
            this.dtDateTime.TabIndex = 2;
            // 
            // txtTheter
            // 
            this.txtTheter.Location = new System.Drawing.Point(70, 10);
            this.txtTheter.Name = "txtTheter";
            this.txtTheter.ReadOnly = true;
            this.txtTheter.Size = new System.Drawing.Size(180, 21);
            this.txtTheter.TabIndex = 1;
            // 
            // panState
            // 
            this.panState.BackColor = System.Drawing.Color.White;
            this.panState.Controls.Add(this.lblPage);
            this.panState.Controls.Add(this.btnPageDown);
            this.panState.Controls.Add(this.btnPageUp);
            this.panState.Controls.Add(this.label8);
            this.panState.Controls.Add(this.lblColorOfIsStopSale);
            this.panState.Controls.Add(this.lblColorOfIsUnSale);
            this.panState.Controls.Add(this.label5);
            this.panState.Controls.Add(this.lblColorOfIsSale);
            this.panState.Controls.Add(this.label4);
            this.panState.Controls.Add(this.lblIsSave);
            this.panState.Controls.Add(this.lblDateTime);
            this.panState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panState.Location = new System.Drawing.Point(0, 576);
            this.panState.Name = "panState";
            this.panState.Size = new System.Drawing.Size(847, 40);
            this.panState.TabIndex = 2;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(332, 14);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(35, 12);
            this.lblPage.TabIndex = 9;
            this.lblPage.Text = "1 / 1";
            // 
            // btnPageDown
            // 
            this.btnPageDown.Location = new System.Drawing.Point(373, 9);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(23, 23);
            this.btnPageDown.TabIndex = 8;
            this.btnPageDown.Text = ">";
            this.btnPageDown.UseVisualStyleBackColor = true;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.Location = new System.Drawing.Point(303, 9);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(23, 23);
            this.btnPageUp.TabIndex = 7;
            this.btnPageUp.Text = "<";
            this.btnPageUp.UseVisualStyleBackColor = true;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(776, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = " ";
            // 
            // lblColorOfIsStopSale
            // 
            this.lblColorOfIsStopSale.AutoSize = true;
            this.lblColorOfIsStopSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(151)))));
            this.lblColorOfIsStopSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorOfIsStopSale.Location = new System.Drawing.Point(715, 11);
            this.lblColorOfIsStopSale.Name = "lblColorOfIsStopSale";
            this.lblColorOfIsStopSale.Size = new System.Drawing.Size(13, 14);
            this.lblColorOfIsStopSale.TabIndex = 5;
            this.lblColorOfIsStopSale.Text = " ";
            // 
            // lblColorOfIsUnSale
            // 
            this.lblColorOfIsUnSale.AutoSize = true;
            this.lblColorOfIsUnSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.lblColorOfIsUnSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorOfIsUnSale.Location = new System.Drawing.Point(596, 11);
            this.lblColorOfIsUnSale.Name = "lblColorOfIsUnSale";
            this.lblColorOfIsUnSale.Size = new System.Drawing.Size(13, 14);
            this.lblColorOfIsUnSale.TabIndex = 4;
            this.lblColorOfIsUnSale.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(536, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = " ";
            // 
            // lblColorOfIsSale
            // 
            this.lblColorOfIsSale.AutoSize = true;
            this.lblColorOfIsSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(248)))), ((int)(((byte)(126)))));
            this.lblColorOfIsSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorOfIsSale.Location = new System.Drawing.Point(656, 11);
            this.lblColorOfIsSale.Name = "lblColorOfIsSale";
            this.lblColorOfIsSale.Size = new System.Drawing.Size(13, 14);
            this.lblColorOfIsSale.TabIndex = 3;
            this.lblColorOfIsSale.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(401, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "场次状态图示：      开售      未售      已售      停售      被选中";
            // 
            // lblIsSave
            // 
            this.lblIsSave.AutoSize = true;
            this.lblIsSave.Location = new System.Drawing.Point(203, 12);
            this.lblIsSave.Name = "lblIsSave";
            this.lblIsSave.Size = new System.Drawing.Size(65, 12);
            this.lblIsSave.TabIndex = 1;
            this.lblIsSave.Text = "计划未保存";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(20, 12);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(143, 12);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "2007年04月25日 17:35:50";
            // 
            // panTitle
            // 
            this.panTitle.BackgroundImage = global::WinFormUI.Properties.Resources.Title;
            this.panTitle.Controls.Add(this.btnHelp);
            this.panTitle.Controls.Add(this.btnClose);
            this.panTitle.Controls.Add(this.tmExit);
            this.panTitle.Controls.Add(this.btnMin);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1016, 69);
            this.panTitle.TabIndex = 0;
            this.panTitle.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackgroundImage = global::WinFormUI.Properties.Resources.Help;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.Location = new System.Drawing.Point(896, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 32);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::WinFormUI.Properties.Resources.Close;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(972, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmExit
            // 
            this.tmExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tmExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tmExit.BackgroundImage = global::WinFormUI.Properties.Resources.Exit;
            this.tmExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tmExit.FlatAppearance.BorderSize = 0;
            this.tmExit.Location = new System.Drawing.Point(858, 12);
            this.tmExit.Name = "tmExit";
            this.tmExit.Size = new System.Drawing.Size(32, 32);
            this.tmExit.TabIndex = 1;
            this.tmExit.UseVisualStyleBackColor = false;
            this.tmExit.Visible = false;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackgroundImage = global::WinFormUI.Properties.Resources.Min;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.Location = new System.Drawing.Point(934, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 32);
            this.btnMin.TabIndex = 2;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // panFooter
            // 
            this.panFooter.BackgroundImage = global::WinFormUI.Properties.Resources.Footer;
            this.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFooter.Location = new System.Drawing.Point(0, 715);
            this.panFooter.Name = "panFooter";
            this.panFooter.Size = new System.Drawing.Size(1016, 19);
            this.panFooter.TabIndex = 3;
            this.panFooter.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.scSplit);
            this.Controls.Add(this.tsTool);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.panFooter);
            this.Name = "frmMain";
            this.Text = "放映计划管理";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.scSplit.Panel1.ResumeLayout(false);
            this.scSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSplit)).EndInit();
            this.scSplit.ResumeLayout(false);
            this.gbOperation.ResumeLayout(false);
            this.gbFilm.ResumeLayout(false);
            this.panShowPlanContainer.ResumeLayout(false);
            this.panQuery.ResumeLayout(false);
            this.panQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefultTimeSpan)).EndInit();
            this.panState.ResumeLayout(false);
            this.panState.PerformLayout();
            this.panTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Button tmExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripButton tsFilmSetting;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsCopy;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.SplitContainer scSplit;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.GroupBox gbFilm;
        private System.Windows.Forms.LinkLabel lnkDeleteHallPlan;
        private System.Windows.Forms.LinkLabel lnkDeleteShow;
        private System.Windows.Forms.LinkLabel lnkRecordPlan;
        private System.Windows.Forms.FlowLayoutPanel flPanFilm;
        private System.Windows.Forms.Panel panQuery;
        private System.Windows.Forms.Panel panState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTodayPlan;
        private System.Windows.Forms.DateTimePicker dtDateTime;
        private System.Windows.Forms.TextBox txtTheter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDefultTimeSpan;
        private System.Windows.Forms.Label label2;
        private ShowPlanPanel spPanShowPlan;
        private System.Windows.Forms.Panel panFooter;
        private System.Windows.Forms.Panel panShowPlanContainer;
        private System.Windows.Forms.Label lblIsSave;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblColorOfIsStopSale;
        private System.Windows.Forms.Label lblColorOfIsUnSale;
        private System.Windows.Forms.Label lblColorOfIsSale;
        private System.Windows.Forms.ToolStripButton tsApproved;
        private System.Windows.Forms.ToolStripButton tsSale;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.Button btnPageUp;
        private System.Windows.Forms.ToolStripDropDownButton tsPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsTheterPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsHallPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsPeriodPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsFilmPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsShowPlanPriceSet;
        private System.Windows.Forms.ToolStripMenuItem tsBlockPriceSet;
        private System.Windows.Forms.ToolStripDropDownButton tmBasicQuery;
        private System.Windows.Forms.ToolStripMenuItem tsFilmBoxOffice;
        private System.Windows.Forms.ToolStripMenuItem tsHallBoxOffice;
        private System.Windows.Forms.ToolStripMenuItem tsDayBoxOffice;
        private System.Windows.Forms.ToolStripMenuItem tsPeriodBoxOffice;
        private System.Windows.Forms.ToolStripDropDownButton tsQuickQuery;
        private System.Windows.Forms.ToolStripMenuItem tsFilmCode;
        private System.Windows.Forms.ToolStripMenuItem tsFilmName;
        private System.Windows.Forms.ToolStripMenuItem tsRatio;
        private System.Windows.Forms.ToolStripMenuItem tsTotal;
        private System.Windows.Forms.ToolStripMenuItem tsPrice;
        private System.Windows.Forms.ToolStripMenuItem tsCount_Ticket;
        private System.Windows.Forms.ToolStripMenuItem tsSeats;
        private System.Windows.Forms.ToolStripMenuItem tsEmity;
        private System.Windows.Forms.ToolStripMenuItem tsCount_Refund;
        private System.Windows.Forms.ToolStripMenuItem tsRate;
        private System.Windows.Forms.Label label5;
    }
}
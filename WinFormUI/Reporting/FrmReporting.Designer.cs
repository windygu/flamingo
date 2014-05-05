namespace WinFormUI.Reporting
{
    partial class FrmReporting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporting));
            this.flamingoDataSet = new WinFormUI.flamingoDataSet();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.个人日放映收入表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人日售票成绩表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院日放映收入表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院日售票成绩表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.影院放映日累计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院放映月累计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院放映月表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片放映情况财务报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.基础查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院放映计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院售票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院退票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.组合查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.影厅电影日报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片放映统计月表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.比较分析图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片票房比较图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影厅票房比较图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分布分析图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院各厅票房分布图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片各厅票房分布图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片票种票房分布图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.走势分析图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影院总票房时间走势图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影厅票房时间走势图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影片票房时间走势图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.flamingoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flamingoDataSet
            // 
            this.flamingoDataSet.DataSetName = "flamingoDataSet";
            this.flamingoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::WinFormUI.Properties.Resources.secondmenu;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(5, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(123, 705);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人日放映收入表ToolStripMenuItem,
            this.个人日售票成绩表ToolStripMenuItem,
            this.影院日放映收入表ToolStripMenuItem,
            this.影院日售票成绩表ToolStripMenuItem});
            this.toolStripButton1.Image = global::WinFormUI.Properties.Resources.statistics1;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.ShowDropDownArrow = false;
            this.toolStripButton1.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton1.Text = "统计报表";
            // 
            // 个人日放映收入表ToolStripMenuItem
            // 
            this.个人日放映收入表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.个人日放映收入表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.个人日放映收入表ToolStripMenuItem.Name = "个人日放映收入表ToolStripMenuItem";
            this.个人日放映收入表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.个人日放映收入表ToolStripMenuItem.Text = "个人日放映收入表";
            this.个人日放映收入表ToolStripMenuItem.Click += new System.EventHandler(this.个人日放映收入表ToolStripMenuItem_Click);
            // 
            // 个人日售票成绩表ToolStripMenuItem
            // 
            this.个人日售票成绩表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.个人日售票成绩表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.个人日售票成绩表ToolStripMenuItem.Name = "个人日售票成绩表ToolStripMenuItem";
            this.个人日售票成绩表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.个人日售票成绩表ToolStripMenuItem.Text = "个人日售票成绩表";
            this.个人日售票成绩表ToolStripMenuItem.Click += new System.EventHandler(this.个人日售票成绩表ToolStripMenuItem_Click);
            // 
            // 影院日放映收入表ToolStripMenuItem
            // 
            this.影院日放映收入表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院日放映收入表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院日放映收入表ToolStripMenuItem.Name = "影院日放映收入表ToolStripMenuItem";
            this.影院日放映收入表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.影院日放映收入表ToolStripMenuItem.Text = "影院日放映收入表";
            this.影院日放映收入表ToolStripMenuItem.Click += new System.EventHandler(this.影院日放映收入表ToolStripMenuItem_Click);
            // 
            // 影院日售票成绩表ToolStripMenuItem
            // 
            this.影院日售票成绩表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院日售票成绩表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院日售票成绩表ToolStripMenuItem.Name = "影院日售票成绩表ToolStripMenuItem";
            this.影院日售票成绩表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.影院日售票成绩表ToolStripMenuItem.Text = "影院日售票成绩表";
            this.影院日售票成绩表ToolStripMenuItem.Click += new System.EventHandler(this.影院日售票成绩表ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影院放映日累计分析ToolStripMenuItem,
            this.影院放映月累计分析ToolStripMenuItem,
            this.影院放映月表ToolStripMenuItem,
            this.影片放映情况财务报表ToolStripMenuItem});
            this.toolStripButton2.Image = global::WinFormUI.Properties.Resources.business1;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.ShowDropDownArrow = false;
            this.toolStripButton2.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton2.Text = "经营报表";
            // 
            // 影院放映日累计分析ToolStripMenuItem
            // 
            this.影院放映日累计分析ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院放映日累计分析ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院放映日累计分析ToolStripMenuItem.Name = "影院放映日累计分析ToolStripMenuItem";
            this.影院放映日累计分析ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影院放映日累计分析ToolStripMenuItem.Text = "影院放映日累计分析";
            this.影院放映日累计分析ToolStripMenuItem.Click += new System.EventHandler(this.影院放映日累计分析ToolStripMenuItem_Click);
            // 
            // 影院放映月累计分析ToolStripMenuItem
            // 
            this.影院放映月累计分析ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院放映月累计分析ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院放映月累计分析ToolStripMenuItem.Name = "影院放映月累计分析ToolStripMenuItem";
            this.影院放映月累计分析ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影院放映月累计分析ToolStripMenuItem.Text = "影院放映月累计分析";
            this.影院放映月累计分析ToolStripMenuItem.Click += new System.EventHandler(this.影院放映月累计分析ToolStripMenuItem_Click);
            // 
            // 影院放映月表ToolStripMenuItem
            // 
            this.影院放映月表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院放映月表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院放映月表ToolStripMenuItem.Name = "影院放映月表ToolStripMenuItem";
            this.影院放映月表ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影院放映月表ToolStripMenuItem.Text = "影院放映月表";
            this.影院放映月表ToolStripMenuItem.Click += new System.EventHandler(this.影院放映月表ToolStripMenuItem_Click);
            // 
            // 影片放映情况财务报表ToolStripMenuItem
            // 
            this.影片放映情况财务报表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片放映情况财务报表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片放映情况财务报表ToolStripMenuItem.Name = "影片放映情况财务报表ToolStripMenuItem";
            this.影片放映情况财务报表ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影片放映情况财务报表ToolStripMenuItem.Text = "影片放映情况财务报表";
            this.影片放映情况财务报表ToolStripMenuItem.Click += new System.EventHandler(this.影片放映情况财务报表ToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础查询ToolStripMenuItem,
            this.组合查询ToolStripMenuItem});
            this.toolStripButton3.Image = global::WinFormUI.Properties.Resources.query1;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.ShowDropDownArrow = false;
            this.toolStripButton3.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton3.Text = "查询报表";
            // 
            // 基础查询ToolStripMenuItem
            // 
            this.基础查询ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.基础查询ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.基础查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影院放映计划ToolStripMenuItem,
            this.影院售票ToolStripMenuItem,
            this.影院退票ToolStripMenuItem});
            this.基础查询ToolStripMenuItem.Name = "基础查询ToolStripMenuItem";
            this.基础查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.基础查询ToolStripMenuItem.Text = "基础查询";
            // 
            // 影院放映计划ToolStripMenuItem
            // 
            this.影院放映计划ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院放映计划ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院放映计划ToolStripMenuItem.Name = "影院放映计划ToolStripMenuItem";
            this.影院放映计划ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.影院放映计划ToolStripMenuItem.Text = "影院放映计划";
            this.影院放映计划ToolStripMenuItem.Click += new System.EventHandler(this.影院放映计划ToolStripMenuItem_Click);
            // 
            // 影院售票ToolStripMenuItem
            // 
            this.影院售票ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院售票ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院售票ToolStripMenuItem.Name = "影院售票ToolStripMenuItem";
            this.影院售票ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.影院售票ToolStripMenuItem.Text = "影院售票";
            this.影院售票ToolStripMenuItem.Click += new System.EventHandler(this.影院售票ToolStripMenuItem_Click);
            // 
            // 影院退票ToolStripMenuItem
            // 
            this.影院退票ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院退票ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院退票ToolStripMenuItem.Name = "影院退票ToolStripMenuItem";
            this.影院退票ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.影院退票ToolStripMenuItem.Text = "影院退票";
            this.影院退票ToolStripMenuItem.Click += new System.EventHandler(this.影院退票ToolStripMenuItem_Click);
            // 
            // 组合查询ToolStripMenuItem
            // 
            this.组合查询ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.组合查询ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.组合查询ToolStripMenuItem.Name = "组合查询ToolStripMenuItem";
            this.组合查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.组合查询ToolStripMenuItem.Text = "组合查询";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影厅电影日报表ToolStripMenuItem,
            this.影片放映统计月表ToolStripMenuItem});
            this.toolStripButton4.Image = global::WinFormUI.Properties.Resources.total1;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.ShowDropDownArrow = false;
            this.toolStripButton4.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton4.Text = "综合报表";
            // 
            // 影厅电影日报表ToolStripMenuItem
            // 
            this.影厅电影日报表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影厅电影日报表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影厅电影日报表ToolStripMenuItem.Name = "影厅电影日报表ToolStripMenuItem";
            this.影厅电影日报表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.影厅电影日报表ToolStripMenuItem.Text = "影厅电影日报表";
            this.影厅电影日报表ToolStripMenuItem.Click += new System.EventHandler(this.影厅电影日报表ToolStripMenuItem_Click);
            // 
            // 影片放映统计月表ToolStripMenuItem
            // 
            this.影片放映统计月表ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片放映统计月表ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片放映统计月表ToolStripMenuItem.Name = "影片放映统计月表ToolStripMenuItem";
            this.影片放映统计月表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.影片放映统计月表ToolStripMenuItem.Text = "影片放映统计月表";
            this.影片放映统计月表ToolStripMenuItem.Click += new System.EventHandler(this.影片放映统计月表ToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.比较分析图ToolStripMenuItem,
            this.分布分析图ToolStripMenuItem,
            this.走势分析图ToolStripMenuItem});
            this.toolStripButton5.Image = global::WinFormUI.Properties.Resources.graphic1;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.ShowDropDownArrow = false;
            this.toolStripButton5.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton5.Text = "图形分析";
            // 
            // 比较分析图ToolStripMenuItem
            // 
            this.比较分析图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.比较分析图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.比较分析图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影片票房比较图ToolStripMenuItem,
            this.影厅票房比较图ToolStripMenuItem});
            this.比较分析图ToolStripMenuItem.Name = "比较分析图ToolStripMenuItem";
            this.比较分析图ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.比较分析图ToolStripMenuItem.Text = "比较分析图";
            // 
            // 影片票房比较图ToolStripMenuItem
            // 
            this.影片票房比较图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片票房比较图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片票房比较图ToolStripMenuItem.Name = "影片票房比较图ToolStripMenuItem";
            this.影片票房比较图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.影片票房比较图ToolStripMenuItem.Text = "影片票房比较图";
            this.影片票房比较图ToolStripMenuItem.Click += new System.EventHandler(this.影片票房比较图ToolStripMenuItem_Click);
            // 
            // 影厅票房比较图ToolStripMenuItem
            // 
            this.影厅票房比较图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影厅票房比较图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影厅票房比较图ToolStripMenuItem.Name = "影厅票房比较图ToolStripMenuItem";
            this.影厅票房比较图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.影厅票房比较图ToolStripMenuItem.Text = "影厅票房比较图";
            this.影厅票房比较图ToolStripMenuItem.Click += new System.EventHandler(this.影厅票房比较图ToolStripMenuItem_Click);
            // 
            // 分布分析图ToolStripMenuItem
            // 
            this.分布分析图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.分布分析图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.分布分析图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影院各厅票房分布图ToolStripMenuItem,
            this.影片各厅票房分布图ToolStripMenuItem,
            this.影片票种票房分布图ToolStripMenuItem});
            this.分布分析图ToolStripMenuItem.Name = "分布分析图ToolStripMenuItem";
            this.分布分析图ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.分布分析图ToolStripMenuItem.Text = "分布分析图";
            // 
            // 影院各厅票房分布图ToolStripMenuItem
            // 
            this.影院各厅票房分布图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院各厅票房分布图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院各厅票房分布图ToolStripMenuItem.Name = "影院各厅票房分布图ToolStripMenuItem";
            this.影院各厅票房分布图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.影院各厅票房分布图ToolStripMenuItem.Text = "影院各厅票房分布图";
            this.影院各厅票房分布图ToolStripMenuItem.Click += new System.EventHandler(this.影院各厅票房分布图ToolStripMenuItem_Click);
            // 
            // 影片各厅票房分布图ToolStripMenuItem
            // 
            this.影片各厅票房分布图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片各厅票房分布图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片各厅票房分布图ToolStripMenuItem.Name = "影片各厅票房分布图ToolStripMenuItem";
            this.影片各厅票房分布图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.影片各厅票房分布图ToolStripMenuItem.Text = "影片各厅票房分布图";
            this.影片各厅票房分布图ToolStripMenuItem.Click += new System.EventHandler(this.影片各厅票房分布图ToolStripMenuItem_Click);
            // 
            // 影片票种票房分布图ToolStripMenuItem
            // 
            this.影片票种票房分布图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片票种票房分布图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片票种票房分布图ToolStripMenuItem.Name = "影片票种票房分布图ToolStripMenuItem";
            this.影片票种票房分布图ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.影片票种票房分布图ToolStripMenuItem.Text = "影片票种票房分布图";
            this.影片票种票房分布图ToolStripMenuItem.Click += new System.EventHandler(this.影片票种票房分布图ToolStripMenuItem_Click);
            // 
            // 走势分析图ToolStripMenuItem
            // 
            this.走势分析图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.走势分析图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.走势分析图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影院总票房时间走势图ToolStripMenuItem,
            this.影厅票房时间走势图ToolStripMenuItem,
            this.影片票房时间走势图ToolStripMenuItem});
            this.走势分析图ToolStripMenuItem.Name = "走势分析图ToolStripMenuItem";
            this.走势分析图ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.走势分析图ToolStripMenuItem.Text = "走势分析图";
            // 
            // 影院总票房时间走势图ToolStripMenuItem
            // 
            this.影院总票房时间走势图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影院总票房时间走势图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影院总票房时间走势图ToolStripMenuItem.Name = "影院总票房时间走势图ToolStripMenuItem";
            this.影院总票房时间走势图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影院总票房时间走势图ToolStripMenuItem.Text = "影院总票房时间走势图";
            this.影院总票房时间走势图ToolStripMenuItem.Click += new System.EventHandler(this.影院总票房时间走势图ToolStripMenuItem_Click);
            // 
            // 影厅票房时间走势图ToolStripMenuItem
            // 
            this.影厅票房时间走势图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影厅票房时间走势图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影厅票房时间走势图ToolStripMenuItem.Name = "影厅票房时间走势图ToolStripMenuItem";
            this.影厅票房时间走势图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影厅票房时间走势图ToolStripMenuItem.Text = "影厅票房时间走势图";
            this.影厅票房时间走势图ToolStripMenuItem.Click += new System.EventHandler(this.影厅票房时间走势图ToolStripMenuItem_Click);
            // 
            // 影片票房时间走势图ToolStripMenuItem
            // 
            this.影片票房时间走势图ToolStripMenuItem.BackgroundImage = global::WinFormUI.Properties.Resources.thirdmenu;
            this.影片票房时间走势图ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.影片票房时间走势图ToolStripMenuItem.Name = "影片票房时间走势图ToolStripMenuItem";
            this.影片票房时间走势图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.影片票房时间走势图ToolStripMenuItem.Text = "影片票房时间走势图";
            this.影片票房时间走势图ToolStripMenuItem.Click += new System.EventHandler(this.影片票房时间走势图ToolStripMenuItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::WinFormUI.Properties.Resources.ticket11;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(121, 34);
            this.toolStripButton6.Text = "中影专用报表";
            this.toolStripButton6.Click += new System.EventHandler(this.中影专用报表toolStripButton_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(128, 28);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(880, 705);
            this.reportViewer1.TabIndex = 24;
            this.reportViewer1.Drillthrough += new Microsoft.Reporting.WinForms.DrillthroughEventHandler(this.reportViewer1_Drillthrough);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 733);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(122, 21);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // FrmReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReporting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计分析";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flamingoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1;
        private flamingoDataSet flamingoDataSet;
        private System.Windows.Forms.BindingSource reportBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem 影院放映日累计分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院放映月累计分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院放映月表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片放映情况财务报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem 基础查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院放映计划ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院售票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院退票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 组合查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem 影厅电影日报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片放映统计月表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem 比较分析图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片票房比较图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影厅票房比较图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分布分析图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院各厅票房分布图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片各厅票房分布图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片票种票房分布图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 走势分析图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院总票房时间走势图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影厅票房时间走势图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影片票房时间走势图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 个人日放映收入表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人日售票成绩表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院日放映收入表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影院日售票成绩表ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}
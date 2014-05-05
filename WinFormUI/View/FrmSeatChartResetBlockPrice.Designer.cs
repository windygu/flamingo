namespace WinFormUI
{
    partial class FrmSeatChartResetBlockPrice
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
            this.tableLayoutPanel_All = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Update = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_ShowPlan = new System.Windows.Forms.Label();
            this.panel_block = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel_block = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Query = new System.Windows.Forms.Button();
            this.bt_Close = new System.Windows.Forms.Button();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.uC_HallInfoSeek1 = new WinFormUI.UC_HallInfoSeekAll();
            this.uC_SiteMenu1 = new WinFormUI.UC_SiteMenu();
            this.seatChartDispScreen1 = new WinFormUI.SeatChartDispScreen();
            this.uC_ImageButtonVPanel_Block = new WinFormUI.UC_LabelLPanel();
            this.tableLayoutPanel_All.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_block.SuspendLayout();
            this.tableLayoutPanel_block.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_All
            // 
            this.tableLayoutPanel_All.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel_All.ColumnCount = 3;
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_All.Controls.Add(this.panel_Top, 0, 1);
            this.tableLayoutPanel_All.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel_All.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel_All.Controls.Add(this.seatChartDispScreen1, 1, 4);
            this.tableLayoutPanel_All.Controls.Add(this.panel_block, 0, 5);
            this.tableLayoutPanel_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_All.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_All.Name = "tableLayoutPanel_All";
            this.tableLayoutPanel_All.RowCount = 6;
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_All.Size = new System.Drawing.Size(936, 468);
            this.tableLayoutPanel_All.TabIndex = 2;
            // 
            // bt_Update
            // 
            this.bt_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Update.Location = new System.Drawing.Point(3, 3);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.Size = new System.Drawing.Size(94, 156);
            this.bt_Update.TabIndex = 6;
            this.bt_Update.Text = "设置区域价格";
            this.bt_Update.UseVisualStyleBackColor = true;
            this.bt_Update.Click += new System.EventHandler(this.bt_Update_Click);
            // 
            // panel3
            // 
            this.tableLayoutPanel_All.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.uC_SiteMenu1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 25);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.tableLayoutPanel_All.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.lb_ShowPlan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(936, 25);
            this.panel4.TabIndex = 5;
            // 
            // lb_ShowPlan
            // 
            this.lb_ShowPlan.AutoSize = true;
            this.lb_ShowPlan.Location = new System.Drawing.Point(12, 6);
            this.lb_ShowPlan.Name = "lb_ShowPlan";
            this.lb_ShowPlan.Size = new System.Drawing.Size(71, 12);
            this.lb_ShowPlan.TabIndex = 3;
            this.lb_ShowPlan.Text = "lb_ShowPlan";
            // 
            // panel_block
            // 
            this.tableLayoutPanel_All.SetColumnSpan(this.panel_block, 3);
            this.panel_block.Controls.Add(this.tableLayoutPanel_block);
            this.panel_block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_block.Location = new System.Drawing.Point(0, 306);
            this.panel_block.Margin = new System.Windows.Forms.Padding(0);
            this.panel_block.Name = "panel_block";
            this.panel_block.Size = new System.Drawing.Size(936, 162);
            this.panel_block.TabIndex = 7;
            // 
            // tableLayoutPanel_block
            // 
            this.tableLayoutPanel_block.ColumnCount = 2;
            this.tableLayoutPanel_block.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_block.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_block.Controls.Add(this.uC_ImageButtonVPanel_Block, 1, 0);
            this.tableLayoutPanel_block.Controls.Add(this.bt_Update, 0, 0);
            this.tableLayoutPanel_block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_block.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_block.Name = "tableLayoutPanel_block";
            this.tableLayoutPanel_block.RowCount = 1;
            this.tableLayoutPanel_block.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_block.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel_block.Size = new System.Drawing.Size(936, 162);
            this.tableLayoutPanel_block.TabIndex = 0;
            // 
            // bt_Query
            // 
            this.bt_Query.Location = new System.Drawing.Point(776, 3);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.Size = new System.Drawing.Size(46, 19);
            this.bt_Query.TabIndex = 2;
            this.bt_Query.Text = "刷新";
            this.bt_Query.UseVisualStyleBackColor = true;
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // bt_Close
            // 
            this.bt_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Close.Location = new System.Drawing.Point(882, 3);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(40, 19);
            this.bt_Close.TabIndex = 20;
            this.bt_Close.Text = "关闭";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel_All.SetColumnSpan(this.panel_Top, 3);
            this.panel_Top.Controls.Add(this.bt_Close);
            this.panel_Top.Controls.Add(this.uC_HallInfoSeek1);
            this.panel_Top.Controls.Add(this.bt_Query);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Top.Location = new System.Drawing.Point(0, 28);
            this.panel_Top.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(936, 28);
            this.panel_Top.TabIndex = 0;
            // 
            // uC_HallInfoSeek1
            // 
            this.uC_HallInfoSeek1.Location = new System.Drawing.Point(2, 3);
            this.uC_HallInfoSeek1.Name = "uC_HallInfoSeek1";
            this.uC_HallInfoSeek1.Size = new System.Drawing.Size(768, 23);
            this.uC_HallInfoSeek1.TabIndex = 0;
            // 
            // uC_SiteMenu1
            // 
            this.uC_SiteMenu1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uC_SiteMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_SiteMenu1.Location = new System.Drawing.Point(0, 0);
            this.uC_SiteMenu1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_SiteMenu1.Name = "uC_SiteMenu1";
            this.uC_SiteMenu1.Size = new System.Drawing.Size(936, 25);
            this.uC_SiteMenu1.TabIndex = 0;
            // 
            // seatChartDispScreen1
            // 
            this.seatChartDispScreen1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.seatChartDispScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDispScreen1.Location = new System.Drawing.Point(371, 109);
            this.seatChartDispScreen1.Name = "seatChartDispScreen1";
            this.seatChartDispScreen1.Size = new System.Drawing.Size(194, 194);
            this.seatChartDispScreen1.TabIndex = 6;
            // 
            // uC_ImageButtonVPanel_Block
            // 
            this.uC_ImageButtonVPanel_Block.AutoScroll = true;
            this.uC_ImageButtonVPanel_Block.BackColor = System.Drawing.Color.Transparent;
            this.uC_ImageButtonVPanel_Block.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_ImageButtonVPanel_Block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ImageButtonVPanel_Block.Location = new System.Drawing.Point(100, 0);
            this.uC_ImageButtonVPanel_Block.Margin = new System.Windows.Forms.Padding(0);
            this.uC_ImageButtonVPanel_Block.Name = "uC_ImageButtonVPanel_Block";
            this.uC_ImageButtonVPanel_Block.Size = new System.Drawing.Size(836, 162);
            this.uC_ImageButtonVPanel_Block.TabIndex = 2;
            this.uC_ImageButtonVPanel_Block.ImageButtonItemClick += new System.EventHandler(this.uC_ImageButtonVPanel_Block_ImageButtonItemClick);
            // 
            // FrmSeatChartResetBlockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 468);
            this.Controls.Add(this.tableLayoutPanel_All);
            this.Name = "FrmSeatChartResetBlockPrice";
            this.Text = "设定座位区域价格";
            this.Load += new System.EventHandler(this.FrmSeatChartResetPrice_Load);
            this.tableLayoutPanel_All.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel_block.ResumeLayout(false);
            this.tableLayoutPanel_block.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_All;
        private System.Windows.Forms.Panel panel3;
        private UC_SiteMenu uC_SiteMenu1;
        private UC_LabelLPanel uC_ImageButtonVPanel_Block;
        private System.Windows.Forms.Button bt_Update;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lb_ShowPlan;
        private System.Windows.Forms.Panel panel4;
        private SeatChartDispScreen seatChartDispScreen1;
        private System.Windows.Forms.Panel panel_block;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_block;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button bt_Close;
        private UC_HallInfoSeekAll uC_HallInfoSeek1;
        private System.Windows.Forms.Button bt_Query;
    }
}
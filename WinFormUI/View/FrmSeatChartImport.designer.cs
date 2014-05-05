namespace WinFormUI
{
    partial class FrmSeatChartImport
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
            this.tableLayoutPanel_All = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.bt_Close = new System.Windows.Forms.Button();
            this.bt_Commit = new System.Windows.Forms.Button();
            this.bt_Import = new System.Windows.Forms.Button();
            this.uC_HallInfoSeek1 = new WinFormUI.UC_HallInfoSeekAll();
            this.bt_Query = new System.Windows.Forms.Button();
            this.uC_SiteMenu1 = new WinFormUI.UC_SiteMenu();
            this.seatChartDispScreen1 = new WinFormUI.SeatChartDispScreen();
            this.bgwSave = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel_All.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_All
            // 
            this.tableLayoutPanel_All.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel_All.ColumnCount = 4;
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel_All.Controls.Add(this.panel_Top, 0, 1);
            this.tableLayoutPanel_All.Controls.Add(this.uC_SiteMenu1, 2, 2);
            this.tableLayoutPanel_All.Controls.Add(this.seatChartDispScreen1, 2, 3);
            this.tableLayoutPanel_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_All.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_All.Name = "tableLayoutPanel_All";
            this.tableLayoutPanel_All.RowCount = 6;
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_All.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_All.Size = new System.Drawing.Size(997, 468);
            this.tableLayoutPanel_All.TabIndex = 2;
            // 
            // panel_Top
            // 
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel_All.SetColumnSpan(this.panel_Top, 4);
            this.panel_Top.Controls.Add(this.bt_Close);
            this.panel_Top.Controls.Add(this.bt_Commit);
            this.panel_Top.Controls.Add(this.bt_Import);
            this.panel_Top.Controls.Add(this.uC_HallInfoSeek1);
            this.panel_Top.Controls.Add(this.bt_Query);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Top.Location = new System.Drawing.Point(0, 28);
            this.panel_Top.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(997, 28);
            this.panel_Top.TabIndex = 0;
            // 
            // bt_Close
            // 
            this.bt_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Close.Location = new System.Drawing.Point(948, 3);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(40, 20);
            this.bt_Close.TabIndex = 19;
            this.bt_Close.Text = "关闭";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Commit
            // 
            this.bt_Commit.Location = new System.Drawing.Point(778, 3);
            this.bt_Commit.Name = "bt_Commit";
            this.bt_Commit.Size = new System.Drawing.Size(47, 20);
            this.bt_Commit.TabIndex = 18;
            this.bt_Commit.Text = "提交";
            this.bt_Commit.UseVisualStyleBackColor = true;
            this.bt_Commit.Click += new System.EventHandler(this.bt_Commit_Click);
            // 
            // bt_Import
            // 
            this.bt_Import.Location = new System.Drawing.Point(721, 3);
            this.bt_Import.Name = "bt_Import";
            this.bt_Import.Size = new System.Drawing.Size(47, 20);
            this.bt_Import.TabIndex = 0;
            this.bt_Import.Text = "导入";
            this.bt_Import.UseVisualStyleBackColor = true;
            this.bt_Import.Click += new System.EventHandler(this.bt_Import_Click);
            // 
            // uC_HallInfoSeek1
            // 
            this.uC_HallInfoSeek1.Location = new System.Drawing.Point(3, 1);
            this.uC_HallInfoSeek1.Name = "uC_HallInfoSeek1";
            this.uC_HallInfoSeek1.Size = new System.Drawing.Size(657, 23);
            this.uC_HallInfoSeek1.TabIndex = 0;
            // 
            // bt_Query
            // 
            this.bt_Query.Location = new System.Drawing.Point(666, 3);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.Size = new System.Drawing.Size(46, 20);
            this.bt_Query.TabIndex = 2;
            this.bt_Query.Text = "刷新";
            this.bt_Query.UseVisualStyleBackColor = true;
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // uC_SiteMenu1
            // 
            this.uC_SiteMenu1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uC_SiteMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_SiteMenu1.Location = new System.Drawing.Point(530, 56);
            this.uC_SiteMenu1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_SiteMenu1.Name = "uC_SiteMenu1";
            this.uC_SiteMenu1.Size = new System.Drawing.Size(200, 25);
            this.uC_SiteMenu1.TabIndex = 4;
            // 
            // seatChartDispScreen1
            // 
            this.seatChartDispScreen1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.seatChartDispScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDispScreen1.Location = new System.Drawing.Point(533, 84);
            this.seatChartDispScreen1.Name = "seatChartDispScreen1";
            this.seatChartDispScreen1.Size = new System.Drawing.Size(194, 194);
            this.seatChartDispScreen1.TabIndex = 5;
            // 
            // bgwSave
            // 
            this.bgwSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSave_DoWork);
            this.bgwSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSave_RunWorkerCompleted);
            // 
            // FrmSeatChartImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 468);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_All);
            this.Name = "FrmSeatChartImport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSeatChartImport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSeatChartImport_Load);
            this.tableLayoutPanel_All.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_All;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button bt_Query;
        private UC_HallInfoSeekAll uC_HallInfoSeek1;
        private System.Windows.Forms.Button bt_Import;
        private System.Windows.Forms.Button bt_Commit;
        private UC_SiteMenu uC_SiteMenu1;
        private System.ComponentModel.BackgroundWorker bgwSave;
        private System.Windows.Forms.Button bt_Close;
        private SeatChartDispScreen seatChartDispScreen1;
    }
}
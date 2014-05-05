namespace WinFormUI
{
    partial class FrmSeatChartResetType
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
            this.bt_Rotation = new System.Windows.Forms.Button();
            this.bt_Commit = new System.Windows.Forms.Button();
            this.uC_HallInfoSeek1 = new WinFormUI.UC_HallInfoSeekAll();
            this.bt_Query = new System.Windows.Forms.Button();
            this.panel_uidContainer = new System.Windows.Forms.Panel();
            this.uib_Button1Used = new WinFormUI.UC_ImageButton();
            this.uib_Special = new WinFormUI.UC_ImageButton();
            this.uib_Worker = new WinFormUI.UC_ImageButton();
            this.uib_NoUsed = new WinFormUI.UC_ImageButton();
            this.uib_NoVisit = new WinFormUI.UC_ImageButton();
            this.uib_DeformityOne = new WinFormUI.UC_ImageButton();
            this.uib_Deformity = new WinFormUI.UC_ImageButton();
            this.seatChartDispScreen1 = new WinFormUI.SeatChartDispScreen();
            this.bgwSave = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel_All.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.panel_uidContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_All
            // 
            this.tableLayoutPanel_All.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel_All.ColumnCount = 4;
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_All.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_All.Controls.Add(this.panel_Top, 0, 1);
            this.tableLayoutPanel_All.Controls.Add(this.panel_uidContainer, 1, 2);
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
            this.tableLayoutPanel_All.Size = new System.Drawing.Size(999, 468);
            this.tableLayoutPanel_All.TabIndex = 2;
            // 
            // panel_Top
            // 
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel_All.SetColumnSpan(this.panel_Top, 4);
            this.panel_Top.Controls.Add(this.bt_Close);
            this.panel_Top.Controls.Add(this.bt_Rotation);
            this.panel_Top.Controls.Add(this.bt_Commit);
            this.panel_Top.Controls.Add(this.uC_HallInfoSeek1);
            this.panel_Top.Controls.Add(this.bt_Query);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Top.Location = new System.Drawing.Point(0, 28);
            this.panel_Top.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(999, 28);
            this.panel_Top.TabIndex = 0;
            // 
            // bt_Close
            // 
            this.bt_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Close.Location = new System.Drawing.Point(952, 3);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(40, 19);
            this.bt_Close.TabIndex = 20;
            this.bt_Close.Text = "关闭";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Rotation
            // 
            this.bt_Rotation.Location = new System.Drawing.Point(930, 3);
            this.bt_Rotation.Name = "bt_Rotation";
            this.bt_Rotation.Size = new System.Drawing.Size(46, 19);
            this.bt_Rotation.TabIndex = 4;
            this.bt_Rotation.Text = "翻转";
            this.bt_Rotation.UseVisualStyleBackColor = true;
            this.bt_Rotation.Visible = false;
            this.bt_Rotation.Click += new System.EventHandler(this.bt_Rotation_Click);
            // 
            // bt_Commit
            // 
            this.bt_Commit.Location = new System.Drawing.Point(781, 3);
            this.bt_Commit.Name = "bt_Commit";
            this.bt_Commit.Size = new System.Drawing.Size(46, 19);
            this.bt_Commit.TabIndex = 3;
            this.bt_Commit.Text = "保存";
            this.bt_Commit.UseVisualStyleBackColor = true;
            this.bt_Commit.Click += new System.EventHandler(this.bt_Commit_Click);
            // 
            // uC_HallInfoSeek1
            // 
            this.uC_HallInfoSeek1.Location = new System.Drawing.Point(2, 2);
            this.uC_HallInfoSeek1.Name = "uC_HallInfoSeek1";
            this.uC_HallInfoSeek1.Size = new System.Drawing.Size(719, 20);
            this.uC_HallInfoSeek1.TabIndex = 0;
            // 
            // bt_Query
            // 
            this.bt_Query.Location = new System.Drawing.Point(724, 3);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.Size = new System.Drawing.Size(46, 19);
            this.bt_Query.TabIndex = 2;
            this.bt_Query.Text = "刷新";
            this.bt_Query.UseVisualStyleBackColor = true;
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // panel_uidContainer
            // 
            this.tableLayoutPanel_All.SetColumnSpan(this.panel_uidContainer, 3);
            this.panel_uidContainer.Controls.Add(this.uib_Button1Used);
            this.panel_uidContainer.Controls.Add(this.uib_Special);
            this.panel_uidContainer.Controls.Add(this.uib_Worker);
            this.panel_uidContainer.Controls.Add(this.uib_NoUsed);
            this.panel_uidContainer.Controls.Add(this.uib_NoVisit);
            this.panel_uidContainer.Controls.Add(this.uib_DeformityOne);
            this.panel_uidContainer.Controls.Add(this.uib_Deformity);
            this.panel_uidContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_uidContainer.Location = new System.Drawing.Point(266, 56);
            this.panel_uidContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panel_uidContainer.Name = "panel_uidContainer";
            this.panel_uidContainer.Size = new System.Drawing.Size(733, 25);
            this.panel_uidContainer.TabIndex = 4;
            // 
            // uib_Button1Used
            // 
            this.uib_Button1Used.DisplayText = "正常";
            this.uib_Button1Used.ImageFlag = global::WinFormUI.Properties.Resources.空位;
            this.uib_Button1Used.Location = new System.Drawing.Point(578, 2);
            this.uib_Button1Used.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Button1Used.Name = "uib_Button1Used";
            this.uib_Button1Used.Selected = true;
            this.uib_Button1Used.Size = new System.Drawing.Size(58, 19);
            this.uib_Button1Used.TabIndex = 6;
            this.uib_Button1Used.Tag = "0";
            this.uib_Button1Used.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_Special
            // 
            this.uib_Special.DisplayText = "特殊";
            this.uib_Special.ImageFlag = global::WinFormUI.Properties.Resources.特殊席;
            this.uib_Special.Location = new System.Drawing.Point(511, 2);
            this.uib_Special.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Special.Name = "uib_Special";
            this.uib_Special.Selected = false;
            this.uib_Special.Size = new System.Drawing.Size(58, 19);
            this.uib_Special.TabIndex = 5;
            this.uib_Special.Tag = "8";
            this.uib_Special.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_Worker
            // 
            this.uib_Worker.DisplayText = "工作席";
            this.uib_Worker.ImageFlag = global::WinFormUI.Properties.Resources.工作席;
            this.uib_Worker.Location = new System.Drawing.Point(430, 2);
            this.uib_Worker.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Worker.Name = "uib_Worker";
            this.uib_Worker.Selected = false;
            this.uib_Worker.Size = new System.Drawing.Size(71, 19);
            this.uib_Worker.TabIndex = 4;
            this.uib_Worker.Tag = "7";
            this.uib_Worker.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_NoUsed
            // 
            this.uib_NoUsed.DisplayText = "停用";
            this.uib_NoUsed.ImageFlag = global::WinFormUI.Properties.Resources.停用席;
            this.uib_NoUsed.Location = new System.Drawing.Point(356, 2);
            this.uib_NoUsed.Margin = new System.Windows.Forms.Padding(0);
            this.uib_NoUsed.Name = "uib_NoUsed";
            this.uib_NoUsed.Selected = false;
            this.uib_NoUsed.Size = new System.Drawing.Size(60, 19);
            this.uib_NoUsed.TabIndex = 3;
            this.uib_NoUsed.Tag = "6";
            this.uib_NoUsed.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_NoVisit
            // 
            this.uib_NoVisit.DisplayText = "不事宜观看";
            this.uib_NoVisit.ImageFlag = global::WinFormUI.Properties.Resources.不适宜;
            this.uib_NoVisit.Location = new System.Drawing.Point(246, 2);
            this.uib_NoVisit.Margin = new System.Windows.Forms.Padding(0);
            this.uib_NoVisit.Name = "uib_NoVisit";
            this.uib_NoVisit.Selected = false;
            this.uib_NoVisit.Size = new System.Drawing.Size(94, 19);
            this.uib_NoVisit.TabIndex = 2;
            this.uib_NoVisit.Tag = "5";
            this.uib_NoVisit.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_DeformityOne
            // 
            this.uib_DeformityOne.DisplayText = "残障护理";
            this.uib_DeformityOne.ImageFlag = global::WinFormUI.Properties.Resources.残障护理;
            this.uib_DeformityOne.Location = new System.Drawing.Point(144, 2);
            this.uib_DeformityOne.Margin = new System.Windows.Forms.Padding(0);
            this.uib_DeformityOne.Name = "uib_DeformityOne";
            this.uib_DeformityOne.Selected = false;
            this.uib_DeformityOne.Size = new System.Drawing.Size(83, 19);
            this.uib_DeformityOne.TabIndex = 1;
            this.uib_DeformityOne.Tag = "4";
            this.uib_DeformityOne.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_Deformity
            // 
            this.uib_Deformity.DisplayText = "残障";
            this.uib_Deformity.ImageFlag = global::WinFormUI.Properties.Resources.残障席;
            this.uib_Deformity.Location = new System.Drawing.Point(62, 2);
            this.uib_Deformity.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Deformity.Name = "uib_Deformity";
            this.uib_Deformity.Selected = false;
            this.uib_Deformity.Size = new System.Drawing.Size(58, 19);
            this.uib_Deformity.TabIndex = 0;
            this.uib_Deformity.Tag = "3";
            this.uib_Deformity.Click += new System.EventHandler(this.uib_Click);
            // 
            // seatChartDispScreen1
            // 
            this.seatChartDispScreen1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.seatChartDispScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDispScreen1.Location = new System.Drawing.Point(535, 84);
            this.seatChartDispScreen1.Name = "seatChartDispScreen1";
            this.seatChartDispScreen1.Size = new System.Drawing.Size(194, 194);
            this.seatChartDispScreen1.TabIndex = 5;
            // 
            // bgwSave
            // 
            this.bgwSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSave_DoWork);
            this.bgwSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSave_RunWorkerCompleted);
            // 
            // FrmSeatChartResetType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 468);
            this.Controls.Add(this.tableLayoutPanel_All);
            this.Name = "FrmSeatChartResetType";
            this.Text = "设定座位类型";
            this.Load += new System.EventHandler(this.FrmSeatChartReset_Load);
            this.tableLayoutPanel_All.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_uidContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_All;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button bt_Query;
        private UC_HallInfoSeekAll uC_HallInfoSeek1;
        private System.Windows.Forms.Panel panel_uidContainer;
        private UC_ImageButton uib_Deformity;
        private UC_ImageButton uib_DeformityOne;
        private UC_ImageButton uib_NoUsed;
        private UC_ImageButton uib_NoVisit;
        private UC_ImageButton uib_Worker;
        private UC_ImageButton uib_Special;
        private UC_ImageButton uib_Button1Used;
        private System.Windows.Forms.Button bt_Commit;
        private System.Windows.Forms.Button bt_Rotation;
        private System.ComponentModel.BackgroundWorker bgwSave;
        private System.Windows.Forms.Button bt_Close;
        private SeatChartDispScreen seatChartDispScreen1;
    }
}
namespace WinFormUI
{
    partial class DlgGroupControlSetType
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
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.bt_OK = new System.Windows.Forms.Button();
            this.panel_BhList = new System.Windows.Forms.Panel();
            this.seatChartDisp1 = new SeatMaDll.SeatChartDisp();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.panel_uidContainer = new System.Windows.Forms.Panel();
            this.uib_Button1Used = new WinFormUI.UC_ImageButton();
            this.uib_Special = new WinFormUI.UC_ImageButton();
            this.uib_Worker = new WinFormUI.UC_ImageButton();
            this.uib_NoUsed = new WinFormUI.UC_ImageButton();
            this.uib_NoVisit = new WinFormUI.UC_ImageButton();
            this.uib_DeformityOne = new WinFormUI.UC_ImageButton();
            this.uib_Deformity = new WinFormUI.UC_ImageButton();
            this._seatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.panel_BhList.SuspendLayout();
            this.panel_uidContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._seatNumber,
            this._seatRow,
            this._seatColumn,
            this._seatFlag,
            this._seatId});
            this.dgv_List.Location = new System.Drawing.Point(368, 12);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.Size = new System.Drawing.Size(405, 361);
            this.dgv_List.TabIndex = 1;
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(614, 393);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 2;
            this.bt_OK.Text = "确定";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // panel_BhList
            // 
            this.panel_BhList.AutoScroll = true;
            this.panel_BhList.Controls.Add(this.seatChartDisp1);
            this.panel_BhList.Location = new System.Drawing.Point(1, 12);
            this.panel_BhList.Name = "panel_BhList";
            this.panel_BhList.Size = new System.Drawing.Size(346, 361);
            this.panel_BhList.TabIndex = 6;
            // 
            // seatChartDisp1
            // 
            this.seatChartDisp1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.seatChartDisp1.BoxBorderColor = System.Drawing.Color.White;
            this.seatChartDisp1.Column_Space = 5;
            this.seatChartDisp1.CurrentMouseCursorStatus = SeatMaDll.UC_SeatChartPanel.MouseCursorStatus.Empty;
            this.seatChartDisp1.DispImageMode = true;
            this.seatChartDisp1.DisplayRowNumber = false;
            this.seatChartDisp1.DispMoveRuler = true;
            this.seatChartDisp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDisp1.LeftSpace = 30;
            this.seatChartDisp1.Location = new System.Drawing.Point(0, 0);
            this.seatChartDisp1.MatrixColumnCount = 10;
            this.seatChartDisp1.MatrixRectangeType = SeatMaDll.UC_SeatChartPanel.MatrixRectType.Fix;
            this.seatChartDisp1.MatrixRowCount = 10;
            this.seatChartDisp1.MatrixUnitHeight = 30;
            this.seatChartDisp1.MatrixUnitWidth = 40;
            this.seatChartDisp1.Name = "seatChartDisp1";
            this.seatChartDisp1.Rotation = 0;
            this.seatChartDisp1.Row_Space = 8;
            this.seatChartDisp1.Size = new System.Drawing.Size(346, 361);
            this.seatChartDisp1.TabIndex = 0;
            this.seatChartDisp1.ZoomSize = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seatChartDisp1._LeftOneClick += new SeatMaDll.SelectOneSeatEventHandler(this.seatChartDisp1__LeftOneClick);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(698, 393);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 10;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // panel_uidContainer
            // 
            this.panel_uidContainer.Controls.Add(this.uib_Button1Used);
            this.panel_uidContainer.Controls.Add(this.uib_Special);
            this.panel_uidContainer.Controls.Add(this.uib_Worker);
            this.panel_uidContainer.Controls.Add(this.uib_NoUsed);
            this.panel_uidContainer.Controls.Add(this.uib_NoVisit);
            this.panel_uidContainer.Controls.Add(this.uib_DeformityOne);
            this.panel_uidContainer.Controls.Add(this.uib_Deformity);
            this.panel_uidContainer.Location = new System.Drawing.Point(1, 391);
            this.panel_uidContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panel_uidContainer.Name = "panel_uidContainer";
            this.panel_uidContainer.Size = new System.Drawing.Size(604, 25);
            this.panel_uidContainer.TabIndex = 17;
            // 
            // uib_Button1Used
            // 
            this.uib_Button1Used.DisplayText = "正常";
            this.uib_Button1Used.ImageFlag = global::WinFormUI.Properties.Resources.空位;
            this.uib_Button1Used.Location = new System.Drawing.Point(539, 2);
            this.uib_Button1Used.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Button1Used.Name = "uib_Button1Used";
            this.uib_Button1Used.Selected = false;
            this.uib_Button1Used.Size = new System.Drawing.Size(58, 19);
            this.uib_Button1Used.TabIndex = 6;
            this.uib_Button1Used.Tag = "0";
            this.uib_Button1Used.Click += new System.EventHandler(this.uib_Click);
            // 
            // uib_Special
            // 
            this.uib_Special.DisplayText = "特殊";
            this.uib_Special.ImageFlag = global::WinFormUI.Properties.Resources.特殊席;
            this.uib_Special.Location = new System.Drawing.Point(472, 2);
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
            this.uib_Worker.Location = new System.Drawing.Point(391, 2);
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
            this.uib_NoUsed.Location = new System.Drawing.Point(317, 2);
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
            this.uib_NoVisit.Location = new System.Drawing.Point(207, 2);
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
            this.uib_DeformityOne.Location = new System.Drawing.Point(105, 2);
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
            this.uib_Deformity.Location = new System.Drawing.Point(23, 2);
            this.uib_Deformity.Margin = new System.Windows.Forms.Padding(0);
            this.uib_Deformity.Name = "uib_Deformity";
            this.uib_Deformity.Selected = false;
            this.uib_Deformity.Size = new System.Drawing.Size(58, 19);
            this.uib_Deformity.TabIndex = 0;
            this.uib_Deformity.Tag = "3";
            this.uib_Deformity.Click += new System.EventHandler(this.uib_Click);
            // 
            // _seatNumber
            // 
            this._seatNumber.HeaderText = "座位号";
            this._seatNumber.Name = "_seatNumber";
            // 
            // _seatRow
            // 
            this._seatRow.HeaderText = "排";
            this._seatRow.Name = "_seatRow";
            this._seatRow.Width = 60;
            // 
            // _seatColumn
            // 
            this._seatColumn.HeaderText = "座";
            this._seatColumn.Name = "_seatColumn";
            this._seatColumn.Width = 60;
            // 
            // _seatFlag
            // 
            this._seatFlag.HeaderText = "类型";
            this._seatFlag.Name = "_seatFlag";
            this._seatFlag.Width = 60;
            // 
            // _seatId
            // 
            this._seatId.HeaderText = "SeatId";
            this._seatId.Name = "_seatId";
            this._seatId.Visible = false;
            this._seatId.Width = 60;
            // 
            // DlgGroupControlSetType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(795, 425);
            this.Controls.Add(this.panel_uidContainer);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.panel_BhList);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.dgv_List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgGroupControlSetType";
            this.Text = "设定座位类型";
            this.Load += new System.EventHandler(this.DlgMultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.panel_BhList.ResumeLayout(false);
            this.panel_uidContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Panel panel_BhList;
        private SeatMaDll.SeatChartDisp seatChartDisp1;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Panel panel_uidContainer;
        private UC_ImageButton uib_Button1Used;
        private UC_ImageButton uib_Special;
        private UC_ImageButton uib_Worker;
        private UC_ImageButton uib_NoUsed;
        private UC_ImageButton uib_NoVisit;
        private UC_ImageButton uib_DeformityOne;
        private UC_ImageButton uib_Deformity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatId;
    }
}
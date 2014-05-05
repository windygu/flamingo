namespace WinFormUI
{
    partial class DlgGroupControlSelect
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
            this.bt_Lock = new System.Windows.Forms.Button();
            this.bt_UnLocked = new System.Windows.Forms.Button();
            this.panel_BhList = new System.Windows.Forms.Panel();
            this.seatChartDisp1 = new SeatMaDll.SeatChartDisp();
            this.bt_PrSuccess = new System.Windows.Forms.Button();
            this.bt_Success = new System.Windows.Forms.Button();
            this.bt_SpecialLock = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this._seatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.panel_BhList.SuspendLayout();
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
            this._seatId});
            this.dgv_List.Location = new System.Drawing.Point(368, 12);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.Size = new System.Drawing.Size(287, 145);
            this.dgv_List.TabIndex = 1;
            this.dgv_List.Visible = false;
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(245, 393);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 2;
            this.bt_OK.Text = "确定";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // bt_Lock
            // 
            this.bt_Lock.Location = new System.Drawing.Point(368, 217);
            this.bt_Lock.Name = "bt_Lock";
            this.bt_Lock.Size = new System.Drawing.Size(75, 23);
            this.bt_Lock.TabIndex = 3;
            this.bt_Lock.Text = "锁定";
            this.bt_Lock.UseVisualStyleBackColor = true;
            this.bt_Lock.Visible = false;
            this.bt_Lock.Click += new System.EventHandler(this.bt_Lock_Click);
            // 
            // bt_UnLocked
            // 
            this.bt_UnLocked.Location = new System.Drawing.Point(368, 188);
            this.bt_UnLocked.Name = "bt_UnLocked";
            this.bt_UnLocked.Size = new System.Drawing.Size(75, 23);
            this.bt_UnLocked.TabIndex = 4;
            this.bt_UnLocked.Text = "空位";
            this.bt_UnLocked.UseVisualStyleBackColor = true;
            this.bt_UnLocked.Visible = false;
            this.bt_UnLocked.Click += new System.EventHandler(this.bt_UnLocked_Click);
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
            this.seatChartDisp1.Column_Space = 5;
            this.seatChartDisp1.CurrentMouseCursorStatus = SeatMaDll.UC_SeatChartPanel.MouseCursorStatus.Empty;
            this.seatChartDisp1.DispImageMode = true;
            this.seatChartDisp1.DisplayRowNumber = false;
            this.seatChartDisp1.DispMoveRuler = true;
            this.seatChartDisp1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.seatChartDisp1._RightOneClick += new SeatMaDll.RMSelectOneSeatEventHandler(this.seatChartDisp1__RightOneClick);
            // 
            // bt_PrSuccess
            // 
            this.bt_PrSuccess.Location = new System.Drawing.Point(368, 275);
            this.bt_PrSuccess.Name = "bt_PrSuccess";
            this.bt_PrSuccess.Size = new System.Drawing.Size(75, 23);
            this.bt_PrSuccess.TabIndex = 7;
            this.bt_PrSuccess.Text = "预定";
            this.bt_PrSuccess.UseVisualStyleBackColor = true;
            this.bt_PrSuccess.Visible = false;
            this.bt_PrSuccess.Click += new System.EventHandler(this.bt_PrSuccess_Click);
            // 
            // bt_Success
            // 
            this.bt_Success.Location = new System.Drawing.Point(368, 304);
            this.bt_Success.Name = "bt_Success";
            this.bt_Success.Size = new System.Drawing.Size(75, 23);
            this.bt_Success.TabIndex = 8;
            this.bt_Success.Text = "售出";
            this.bt_Success.UseVisualStyleBackColor = true;
            this.bt_Success.Visible = false;
            this.bt_Success.Click += new System.EventHandler(this.bt_Success_Click);
            // 
            // bt_SpecialLock
            // 
            this.bt_SpecialLock.Location = new System.Drawing.Point(368, 246);
            this.bt_SpecialLock.Name = "bt_SpecialLock";
            this.bt_SpecialLock.Size = new System.Drawing.Size(75, 23);
            this.bt_SpecialLock.TabIndex = 9;
            this.bt_SpecialLock.Text = "特殊锁定";
            this.bt_SpecialLock.UseVisualStyleBackColor = true;
            this.bt_SpecialLock.Visible = false;
            this.bt_SpecialLock.Click += new System.EventHandler(this.bt_SpecialLock_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(368, 333);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 10;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Visible = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
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
            // _seatId
            // 
            this._seatId.HeaderText = "SeatId";
            this._seatId.Name = "_seatId";
            this._seatId.Visible = false;
            this._seatId.Width = 60;
            // 
            // DlgGroupControlSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 433);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_SpecialLock);
            this.Controls.Add(this.bt_Success);
            this.Controls.Add(this.bt_PrSuccess);
            this.Controls.Add(this.panel_BhList);
            this.Controls.Add(this.bt_UnLocked);
            this.Controls.Add(this.bt_Lock);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.dgv_List);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgGroupControlSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgMultiSelect";
            this.Load += new System.EventHandler(this.DlgMultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.panel_BhList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button bt_Lock;
        private System.Windows.Forms.Button bt_UnLocked;
        private System.Windows.Forms.Panel panel_BhList;
        private SeatMaDll.SeatChartDisp seatChartDisp1;
        private System.Windows.Forms.Button bt_PrSuccess;
        private System.Windows.Forms.Button bt_Success;
        private System.Windows.Forms.Button bt_SpecialLock;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatId;
    }
}
namespace WinFormUI
{
    partial class DlgGroupControlSetBlock
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
            this._seatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatBlockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_OK = new System.Windows.Forms.Button();
            this.panel_BhList = new System.Windows.Forms.Panel();
            this.seatChartDisp1 = new SeatMaDll.SeatChartDisp();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.uC_ImageButtonPanel1 = new WinFormUI.UC_LabelVPanel();
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
            this._seatBlockId,
            this._seatId});
            this.dgv_List.Location = new System.Drawing.Point(178, 273);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.Size = new System.Drawing.Size(342, 187);
            this.dgv_List.TabIndex = 1;
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
            // _seatBlockId
            // 
            this._seatBlockId.HeaderText = "区域";
            this._seatBlockId.Name = "_seatBlockId";
            this._seatBlockId.Width = 60;
            // 
            // _seatId
            // 
            this._seatId.HeaderText = "SeatId";
            this._seatId.Name = "_seatId";
            this._seatId.Visible = false;
            this._seatId.Width = 60;
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(9, 428);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(55, 23);
            this.bt_OK.TabIndex = 2;
            this.bt_OK.Text = "确定";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // panel_BhList
            // 
            this.panel_BhList.AutoScroll = true;
            this.panel_BhList.Controls.Add(this.seatChartDisp1);
            this.panel_BhList.Location = new System.Drawing.Point(175, 9);
            this.panel_BhList.Name = "panel_BhList";
            this.panel_BhList.Size = new System.Drawing.Size(346, 259);
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
            this.seatChartDisp1.LeftSpace = 30;
            this.seatChartDisp1.Location = new System.Drawing.Point(4, 3);
            this.seatChartDisp1.MatrixColumnCount = 10;
            this.seatChartDisp1.MatrixRectangeType = SeatMaDll.UC_SeatChartPanel.MatrixRectType.Fix;
            this.seatChartDisp1.MatrixRowCount = 10;
            this.seatChartDisp1.MatrixUnitHeight = 30;
            this.seatChartDisp1.MatrixUnitWidth = 40;
            this.seatChartDisp1.Name = "seatChartDisp1";
            this.seatChartDisp1.Rotation = 0;
            this.seatChartDisp1.Row_Space = 8;
            this.seatChartDisp1.Size = new System.Drawing.Size(337, 252);
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
            this.bt_Cancel.Location = new System.Drawing.Point(85, 428);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(55, 23);
            this.bt_Cancel.TabIndex = 10;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // uC_ImageButtonPanel1
            // 
            this.uC_ImageButtonPanel1.AutoScroll = true;
            this.uC_ImageButtonPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uC_ImageButtonPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_ImageButtonPanel1.Location = new System.Drawing.Point(9, 9);
            this.uC_ImageButtonPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_ImageButtonPanel1.Name = "uC_ImageButtonPanel1";
            this.uC_ImageButtonPanel1.Size = new System.Drawing.Size(157, 401);
            this.uC_ImageButtonPanel1.TabIndex = 18;
            this.uC_ImageButtonPanel1.ImageButtonItemClick += new System.EventHandler(this.uC_ImageButtonPanel1_ImageButtonItemClick);
            // 
            // DlgGroupControlSetBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(530, 463);
            this.Controls.Add(this.uC_ImageButtonPanel1);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.panel_BhList);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.dgv_List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgGroupControlSetBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设定座位区域";
            this.Load += new System.EventHandler(this.DlgMultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.panel_BhList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Panel panel_BhList;
        private SeatMaDll.SeatChartDisp seatChartDisp1;
        private System.Windows.Forms.Button bt_Cancel;
        private UC_LabelVPanel uC_ImageButtonPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatBlockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatId;
    }
}
namespace WinFormUI
{
    partial class DlgMultiSelect
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
            this._seatRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._seatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_List
            // 
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._seatRow,
            this._seatColumn,
            this.Column3});
            this.dgv_List.Location = new System.Drawing.Point(23, 12);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.Size = new System.Drawing.Size(514, 277);
            this.dgv_List.TabIndex = 1;
            // 
            // _seatRow
            // 
            this._seatRow.HeaderText = "排";
            this._seatRow.Name = "_seatRow";
            // 
            // _seatColumn
            // 
            this._seatColumn.HeaderText = "座";
            this._seatColumn.Name = "_seatColumn";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // DlgMultiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 321);
            this.Controls.Add(this.dgv_List);
            this.Name = "DlgMultiSelect";
            this.Text = "DlgMultiSelect";
            this.Load += new System.EventHandler(this.DlgMultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _seatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
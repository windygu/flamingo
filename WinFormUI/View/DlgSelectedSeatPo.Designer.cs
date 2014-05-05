namespace WinFormUI
{
    partial class DlgSelectedSeatPo
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
            this.SeatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xaxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yaxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_List
            // 
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeatId,
            this.RowNumber,
            this.ColumnNumber,
            this.SeatNumber,
            this.Xaxis,
            this.Yaxis});
            this.dgv_List.Location = new System.Drawing.Point(23, 12);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.Size = new System.Drawing.Size(648, 277);
            this.dgv_List.TabIndex = 1;
            // 
            // SeatId
            // 
            this.SeatId.HeaderText = "SeatId";
            this.SeatId.Name = "SeatId";
            // 
            // RowNumber
            // 
            this.RowNumber.HeaderText = "RowNumber";
            this.RowNumber.Name = "RowNumber";
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "ColumnNumber";
            this.ColumnNumber.Name = "ColumnNumber";
            // 
            // SeatNumber
            // 
            this.SeatNumber.HeaderText = "SeatNumber";
            this.SeatNumber.Name = "SeatNumber";
            // 
            // Xaxis
            // 
            this.Xaxis.HeaderText = "Xaxis";
            this.Xaxis.Name = "Xaxis";
            // 
            // Yaxis
            // 
            this.Yaxis.HeaderText = "Yaxis";
            this.Yaxis.Name = "Yaxis";
            // 
            // DlgSelectedSeatPo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 321);
            this.Controls.Add(this.dgv_List);
            this.Name = "DlgSelectedSeatPo";
            this.Text = "DlgMultiSelect";
            this.Load += new System.EventHandler(this.DlgMultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xaxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yaxis;
    }
}
namespace WinFormUI
{
    partial class DlgCreateBlock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSeatInfoCancel = new System.Windows.Forms.Button();
            this.btnSeatInfoSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_BlockName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Seats = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_BgColor = new System.Windows.Forms.Label();
            this.bt_BgColor = new System.Windows.Forms.Button();
            this.tb_SeatingChartName = new System.Windows.Forms.TextBox();
            this.dgv_Block = new System.Windows.Forms.DataGridView();
            this.BlockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BgColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasBlockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatingChartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Block)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeatInfoCancel
            // 
            this.btnSeatInfoCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSeatInfoCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSeatInfoCancel.FlatAppearance.BorderSize = 0;
            this.btnSeatInfoCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatInfoCancel.Location = new System.Drawing.Point(628, 209);
            this.btnSeatInfoCancel.Name = "btnSeatInfoCancel";
            this.btnSeatInfoCancel.Size = new System.Drawing.Size(50, 26);
            this.btnSeatInfoCancel.TabIndex = 17;
            this.btnSeatInfoCancel.Text = "退出";
            this.btnSeatInfoCancel.UseVisualStyleBackColor = false;
            this.btnSeatInfoCancel.Click += new System.EventHandler(this.btnSeatInfoCancel_Click);
            // 
            // btnSeatInfoSubmit
            // 
            this.btnSeatInfoSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSeatInfoSubmit.FlatAppearance.BorderSize = 0;
            this.btnSeatInfoSubmit.Location = new System.Drawing.Point(202, 209);
            this.btnSeatInfoSubmit.Name = "btnSeatInfoSubmit";
            this.btnSeatInfoSubmit.Size = new System.Drawing.Size(66, 26);
            this.btnSeatInfoSubmit.TabIndex = 9;
            this.btnSeatInfoSubmit.Text = "保存";
            this.btnSeatInfoSubmit.UseVisualStyleBackColor = false;
            this.btnSeatInfoSubmit.Click += new System.EventHandler(this.btnSeatInfoSubmit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 372F));
            this.tableLayoutPanel1.Controls.Add(this.tb_BlockName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tb_Seats, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_BgColor, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.bt_BgColor, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.tb_SeatingChartName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_Block, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 192);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tb_BlockName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_BlockName, 2);
            this.tb_BlockName.Location = new System.Drawing.Point(77, 63);
            this.tb_BlockName.Name = "tb_BlockName";
            this.tb_BlockName.Size = new System.Drawing.Size(235, 21);
            this.tb_BlockName.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "座位图";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(3, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 30);
            this.label8.TabIndex = 24;
            this.label8.Text = "区域名称";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "座位数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // tb_Seats
            // 
            this.tb_Seats.Location = new System.Drawing.Point(77, 93);
            this.tb_Seats.Name = "tb_Seats";
            this.tb_Seats.Size = new System.Drawing.Size(162, 21);
            this.tb_Seats.TabIndex = 21;
            this.tb_Seats.Text = "0";
            this.tb_Seats.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "颜色";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_BgColor
            // 
            this.lb_BgColor.BackColor = System.Drawing.Color.Transparent;
            this.lb_BgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_BgColor.Location = new System.Drawing.Point(77, 120);
            this.lb_BgColor.Name = "lb_BgColor";
            this.lb_BgColor.Size = new System.Drawing.Size(162, 33);
            this.lb_BgColor.TabIndex = 31;
            this.lb_BgColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_BgColor
            // 
            this.bt_BgColor.Location = new System.Drawing.Point(245, 123);
            this.bt_BgColor.Name = "bt_BgColor";
            this.bt_BgColor.Size = new System.Drawing.Size(63, 30);
            this.bt_BgColor.TabIndex = 32;
            this.bt_BgColor.Text = "设置颜色";
            this.bt_BgColor.UseVisualStyleBackColor = true;
            this.bt_BgColor.Click += new System.EventHandler(this.bt_BgColor_Click);
            // 
            // tb_SeatingChartName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_SeatingChartName, 2);
            this.tb_SeatingChartName.Enabled = false;
            this.tb_SeatingChartName.Location = new System.Drawing.Point(77, 3);
            this.tb_SeatingChartName.Name = "tb_SeatingChartName";
            this.tb_SeatingChartName.Size = new System.Drawing.Size(235, 21);
            this.tb_SeatingChartName.TabIndex = 33;
            // 
            // dgv_Block
            // 
            this.dgv_Block.AllowUserToAddRows = false;
            this.dgv_Block.AllowUserToDeleteRows = false;
            this.dgv_Block.AllowUserToResizeRows = false;
            this.dgv_Block.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Block.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BlockId,
            this.BlockName,
            this.BgColour,
            this.Seats,
            this.HasBlockPrice,
            this.SeatingChartId});
            this.dgv_Block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Block.Location = new System.Drawing.Point(322, 3);
            this.dgv_Block.MultiSelect = false;
            this.dgv_Block.Name = "dgv_Block";
            this.dgv_Block.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgv_Block, 5);
            this.dgv_Block.RowTemplate.Height = 23;
            this.dgv_Block.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Block.Size = new System.Drawing.Size(366, 186);
            this.dgv_Block.TabIndex = 34;
            // 
            // BlockId
            // 
            this.BlockId.HeaderText = "BlockId";
            this.BlockId.Name = "BlockId";
            this.BlockId.ReadOnly = true;
            this.BlockId.Visible = false;
            // 
            // BlockName
            // 
            this.BlockName.HeaderText = "区域名称";
            this.BlockName.Name = "BlockName";
            this.BlockName.ReadOnly = true;
            // 
            // BgColour
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.BgColour.DefaultCellStyle = dataGridViewCellStyle2;
            this.BgColour.HeaderText = "背景色";
            this.BgColour.Name = "BgColour";
            this.BgColour.ReadOnly = true;
            // 
            // Seats
            // 
            this.Seats.HeaderText = "座位数量";
            this.Seats.Name = "Seats";
            this.Seats.ReadOnly = true;
            // 
            // HasBlockPrice
            // 
            this.HasBlockPrice.HeaderText = "HasBlockPrice";
            this.HasBlockPrice.Name = "HasBlockPrice";
            this.HasBlockPrice.ReadOnly = true;
            this.HasBlockPrice.Visible = false;
            // 
            // SeatingChartId
            // 
            this.SeatingChartId.HeaderText = "SeatingChartId";
            this.SeatingChartId.Name = "SeatingChartId";
            this.SeatingChartId.ReadOnly = true;
            this.SeatingChartId.Visible = false;
            // 
            // bt_Delete
            // 
            this.bt_Delete.BackColor = System.Drawing.Color.Transparent;
            this.bt_Delete.FlatAppearance.BorderSize = 0;
            this.bt_Delete.Location = new System.Drawing.Point(302, 209);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(66, 26);
            this.bt_Delete.TabIndex = 20;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = false;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // DlgCreateBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 245);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSeatInfoCancel);
            this.Controls.Add(this.btnSeatInfoSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgCreateBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建区域";
            this.Load += new System.EventHandler(this.DlgCreateBlock_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Block)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSeatInfoCancel;
        private System.Windows.Forms.Button btnSeatInfoSubmit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_BlockName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Seats;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_BgColor;
        private System.Windows.Forms.Button bt_BgColor;
        private System.Windows.Forms.TextBox tb_SeatingChartName;
        private System.Windows.Forms.DataGridView dgv_Block;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BgColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seats;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasBlockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatingChartId;
        private System.Windows.Forms.Button bt_Delete;
    }
}
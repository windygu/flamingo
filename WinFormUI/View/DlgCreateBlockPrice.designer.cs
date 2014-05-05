namespace WinFormUI
{
    partial class DlgCreateBlockPrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSeatInfoCancel = new System.Windows.Forms.Button();
            this.btnSeatInfoSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_SeatingChartName = new System.Windows.Forms.TextBox();
            this.lb_ShowPlan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Block = new System.Windows.Forms.DataGridView();
            this.BlockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BgColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SinglePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoublePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasBlockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatingChartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_BlockName = new System.Windows.Forms.TextBox();
            this.lb_BgColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_StudentPrice = new System.Windows.Forms.TextBox();
            this.tb_BoxPrice = new System.Windows.Forms.TextBox();
            this.tb_DoublePrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_SinglePrice = new System.Windows.Forms.TextBox();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Block)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeatInfoCancel
            // 
            this.btnSeatInfoCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSeatInfoCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSeatInfoCancel.FlatAppearance.BorderSize = 0;
            this.btnSeatInfoCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatInfoCancel.Location = new System.Drawing.Point(613, 340);
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
            this.btnSeatInfoSubmit.Location = new System.Drawing.Point(213, 340);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 456F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_SeatingChartName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_ShowPlan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 209);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "座位图";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_SeatingChartName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_SeatingChartName, 3);
            this.tb_SeatingChartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SeatingChartName.Enabled = false;
            this.tb_SeatingChartName.Location = new System.Drawing.Point(77, 33);
            this.tb_SeatingChartName.Name = "tb_SeatingChartName";
            this.tb_SeatingChartName.Size = new System.Drawing.Size(626, 21);
            this.tb_SeatingChartName.TabIndex = 33;
            // 
            // lb_ShowPlan
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lb_ShowPlan, 4);
            this.lb_ShowPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ShowPlan.Location = new System.Drawing.Point(3, 0);
            this.lb_ShowPlan.Name = "lb_ShowPlan";
            this.lb_ShowPlan.Size = new System.Drawing.Size(700, 30);
            this.lb_ShowPlan.TabIndex = 20;
            this.lb_ShowPlan.Text = "放映计划";
            this.lb_ShowPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.dgv_Block);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 63);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(700, 143);
            this.panel1.TabIndex = 34;
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
            this.SinglePrice,
            this.DoublePrice,
            this.BoxPrice,
            this.StudentPrice,
            this.HasBlockPrice,
            this.SeatingChartId});
            this.dgv_Block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Block.Location = new System.Drawing.Point(0, 0);
            this.dgv_Block.MultiSelect = false;
            this.dgv_Block.Name = "dgv_Block";
            this.dgv_Block.ReadOnly = true;
            this.dgv_Block.RowTemplate.Height = 23;
            this.dgv_Block.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Block.ShowEditingIcon = false;
            this.dgv_Block.Size = new System.Drawing.Size(700, 143);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.BgColour.DefaultCellStyle = dataGridViewCellStyle1;
            this.BgColour.HeaderText = "背景色";
            this.BgColour.Name = "BgColour";
            this.BgColour.ReadOnly = true;
            // 
            // Seats
            // 
            this.Seats.HeaderText = "座位数量";
            this.Seats.Name = "Seats";
            this.Seats.ReadOnly = true;
            this.Seats.Visible = false;
            // 
            // SinglePrice
            // 
            this.SinglePrice.HeaderText = "单人零售票价";
            this.SinglePrice.Name = "SinglePrice";
            this.SinglePrice.ReadOnly = true;
            this.SinglePrice.Width = 120;
            // 
            // DoublePrice
            // 
            this.DoublePrice.HeaderText = "双座票价";
            this.DoublePrice.Name = "DoublePrice";
            this.DoublePrice.ReadOnly = true;
            // 
            // BoxPrice
            // 
            this.BoxPrice.HeaderText = "包厢票价";
            this.BoxPrice.Name = "BoxPrice";
            this.BoxPrice.ReadOnly = true;
            // 
            // StudentPrice
            // 
            this.StudentPrice.HeaderText = "学生票价";
            this.StudentPrice.Name = "StudentPrice";
            this.StudentPrice.ReadOnly = true;
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
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 24;
            this.label8.Text = "区域名称";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_BlockName
            // 
            this.tb_BlockName.Location = new System.Drawing.Point(76, 236);
            this.tb_BlockName.Name = "tb_BlockName";
            this.tb_BlockName.Size = new System.Drawing.Size(247, 21);
            this.tb_BlockName.TabIndex = 19;
            // 
            // lb_BgColor
            // 
            this.lb_BgColor.BackColor = System.Drawing.Color.Transparent;
            this.lb_BgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_BgColor.Location = new System.Drawing.Point(410, 235);
            this.lb_BgColor.Name = "lb_BgColor";
            this.lb_BgColor.Size = new System.Drawing.Size(71, 23);
            this.lb_BgColor.TabIndex = 31;
            this.lb_BgColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(348, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 21);
            this.label7.TabIndex = 30;
            this.label7.Text = "颜色";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 25;
            this.label1.Text = "单人零售票价";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(203, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "双座零售票价";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(383, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 30);
            this.label4.TabIndex = 27;
            this.label4.Text = "包厢票价";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(523, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 30);
            this.label9.TabIndex = 29;
            this.label9.Text = "学生票价";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_StudentPrice);
            this.groupBox1.Controls.Add(this.tb_BoxPrice);
            this.groupBox1.Controls.Add(this.tb_DoublePrice);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_SinglePrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 59);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "价格";
            // 
            // tb_StudentPrice
            // 
            this.tb_StudentPrice.Location = new System.Drawing.Point(595, 22);
            this.tb_StudentPrice.MaxLength = 5;
            this.tb_StudentPrice.Name = "tb_StudentPrice";
            this.tb_StudentPrice.Size = new System.Drawing.Size(51, 21);
            this.tb_StudentPrice.TabIndex = 37;
            this.tb_StudentPrice.Text = "0";
            // 
            // tb_BoxPrice
            // 
            this.tb_BoxPrice.Location = new System.Drawing.Point(449, 22);
            this.tb_BoxPrice.MaxLength = 5;
            this.tb_BoxPrice.Name = "tb_BoxPrice";
            this.tb_BoxPrice.Size = new System.Drawing.Size(51, 21);
            this.tb_BoxPrice.TabIndex = 36;
            this.tb_BoxPrice.Text = "0";
            // 
            // tb_DoublePrice
            // 
            this.tb_DoublePrice.Location = new System.Drawing.Point(289, 22);
            this.tb_DoublePrice.MaxLength = 5;
            this.tb_DoublePrice.Name = "tb_DoublePrice";
            this.tb_DoublePrice.Size = new System.Drawing.Size(51, 21);
            this.tb_DoublePrice.TabIndex = 35;
            this.tb_DoublePrice.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(648, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 30);
            this.label12.TabIndex = 34;
            this.label12.Text = "元";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(499, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 30);
            this.label11.TabIndex = 33;
            this.label11.Text = "元";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(345, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 30);
            this.label10.TabIndex = 32;
            this.label10.Text = "元";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(157, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 30);
            this.label6.TabIndex = 31;
            this.label6.Text = "元";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_SinglePrice
            // 
            this.tb_SinglePrice.Location = new System.Drawing.Point(101, 22);
            this.tb_SinglePrice.MaxLength = 5;
            this.tb_SinglePrice.Name = "tb_SinglePrice";
            this.tb_SinglePrice.Size = new System.Drawing.Size(51, 21);
            this.tb_SinglePrice.TabIndex = 30;
            this.tb_SinglePrice.Text = "0";
            // 
            // bt_Delete
            // 
            this.bt_Delete.BackColor = System.Drawing.Color.Transparent;
            this.bt_Delete.FlatAppearance.BorderSize = 0;
            this.bt_Delete.Location = new System.Drawing.Point(298, 340);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(66, 26);
            this.bt_Delete.TabIndex = 33;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = false;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // DlgCreateBlockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 372);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_BgColor);
            this.Controls.Add(this.tb_BlockName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSeatInfoCancel);
            this.Controls.Add(this.btnSeatInfoSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgCreateBlockPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设定区域价格";
            this.Load += new System.EventHandler(this.DlgCreateBlockPrice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Block)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeatInfoCancel;
        private System.Windows.Forms.Button btnSeatInfoSubmit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_BlockName;
        private System.Windows.Forms.Label lb_ShowPlan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_BgColor;
        private System.Windows.Forms.TextBox tb_SeatingChartName;
        private System.Windows.Forms.DataGridView dgv_Block;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_StudentPrice;
        private System.Windows.Forms.TextBox tb_BoxPrice;
        private System.Windows.Forms.TextBox tb_DoublePrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_SinglePrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BgColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seats;
        private System.Windows.Forms.DataGridViewTextBoxColumn SinglePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoublePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasBlockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatingChartId;
        private System.Windows.Forms.Button bt_Delete;
    }
}
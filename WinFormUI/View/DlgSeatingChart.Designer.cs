namespace WinFormUI
{
    partial class DlgSeatingChart
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
            this.btnSeatInfoCancel = new System.Windows.Forms.Button();
            this.btnSeatInfoSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_Hall = new System.Windows.Forms.ComboBox();
            this.cbb_Theater = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_Level = new System.Windows.Forms.ComboBox();
            this.tb_seatingchartName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Seats = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Rows = new System.Windows.Forms.TextBox();
            this.tb_Columns = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeatInfoCancel
            // 
            this.btnSeatInfoCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSeatInfoCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSeatInfoCancel.FlatAppearance.BorderSize = 0;
            this.btnSeatInfoCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatInfoCancel.Location = new System.Drawing.Point(330, 138);
            this.btnSeatInfoCancel.Name = "btnSeatInfoCancel";
            this.btnSeatInfoCancel.Size = new System.Drawing.Size(66, 26);
            this.btnSeatInfoCancel.TabIndex = 17;
            this.btnSeatInfoCancel.Text = "取消";
            this.btnSeatInfoCancel.UseVisualStyleBackColor = false;
            this.btnSeatInfoCancel.Click += new System.EventHandler(this.btnSeatInfoCancel_Click);
            // 
            // btnSeatInfoSubmit
            // 
            this.btnSeatInfoSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSeatInfoSubmit.FlatAppearance.BorderSize = 0;
            this.btnSeatInfoSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeatInfoSubmit.Location = new System.Drawing.Point(223, 138);
            this.btnSeatInfoSubmit.Name = "btnSeatInfoSubmit";
            this.btnSeatInfoSubmit.Size = new System.Drawing.Size(66, 26);
            this.btnSeatInfoSubmit.TabIndex = 9;
            this.btnSeatInfoSubmit.Text = "确定";
            this.btnSeatInfoSubmit.UseVisualStyleBackColor = false;
            this.btnSeatInfoSubmit.Click += new System.EventHandler(this.btnSeatInfoSubmit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.Controls.Add(this.tb_Columns, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_Rows, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbb_Hall, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbb_Theater, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbb_Level, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_seatingchartName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_Seats, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 100);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(501, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "楼层";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "影院";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(274, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "影厅";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbb_Hall
            // 
            this.cbb_Hall.FormattingEnabled = true;
            this.cbb_Hall.Location = new System.Drawing.Point(318, 3);
            this.cbb_Hall.Name = "cbb_Hall";
            this.cbb_Hall.Size = new System.Drawing.Size(177, 20);
            this.cbb_Hall.TabIndex = 16;
            // 
            // cbb_Theater
            // 
            this.cbb_Theater.FormattingEnabled = true;
            this.cbb_Theater.Location = new System.Drawing.Point(77, 3);
            this.cbb_Theater.Name = "cbb_Theater";
            this.cbb_Theater.Size = new System.Drawing.Size(184, 20);
            this.cbb_Theater.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "座位图名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbb_Level
            // 
            this.cbb_Level.FormattingEnabled = true;
            this.cbb_Level.Location = new System.Drawing.Point(547, 3);
            this.cbb_Level.Name = "cbb_Level";
            this.cbb_Level.Size = new System.Drawing.Size(55, 20);
            this.cbb_Level.TabIndex = 17;
            // 
            // tb_seatingchartName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_seatingchartName, 3);
            this.tb_seatingchartName.Location = new System.Drawing.Point(77, 33);
            this.tb_seatingchartName.Name = "tb_seatingchartName";
            this.tb_seatingchartName.Size = new System.Drawing.Size(418, 21);
            this.tb_seatingchartName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "座位数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Seats
            // 
            this.tb_Seats.Location = new System.Drawing.Point(77, 63);
            this.tb_Seats.Name = "tb_Seats";
            this.tb_Seats.Size = new System.Drawing.Size(184, 21);
            this.tb_Seats.TabIndex = 21;
            this.tb_Seats.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(274, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "排数";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(501, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 23;
            this.label7.Text = "列数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Rows
            // 
            this.tb_Rows.Location = new System.Drawing.Point(318, 63);
            this.tb_Rows.Name = "tb_Rows";
            this.tb_Rows.Size = new System.Drawing.Size(152, 21);
            this.tb_Rows.TabIndex = 22;
            this.tb_Rows.Text = "0";
            // 
            // tb_Columns
            // 
            this.tb_Columns.Location = new System.Drawing.Point(547, 63);
            this.tb_Columns.Name = "tb_Columns";
            this.tb_Columns.Size = new System.Drawing.Size(96, 21);
            this.tb_Columns.TabIndex = 23;
            this.tb_Columns.Text = "0";
            // 
            // DlgSeatingChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 183);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSeatInfoCancel);
            this.Controls.Add(this.btnSeatInfoSubmit);
            this.Name = "DlgSeatingChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建座位图";
            this.Load += new System.EventHandler(this.DlgSeatingChart_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSeatInfoCancel;
        private System.Windows.Forms.Button btnSeatInfoSubmit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbb_Hall;
        public System.Windows.Forms.ComboBox cbb_Theater;
        public System.Windows.Forms.ComboBox cbb_Level;
        private System.Windows.Forms.TextBox tb_seatingchartName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Seats;
        private System.Windows.Forms.TextBox tb_Rows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Columns;
    }
}
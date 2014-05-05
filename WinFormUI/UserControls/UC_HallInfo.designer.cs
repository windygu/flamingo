namespace WinFormUI
{
    partial class UC_HallInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb_Hall = new System.Windows.Forms.ComboBox();
            this.cbb_Theater = new System.Windows.Forms.ComboBox();
            this.cbb_Rule = new System.Windows.Forms.ComboBox();
            this.cbb_Shape = new System.Windows.Forms.ComboBox();
            this.tb_Block = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbb_Level = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb_Level);
            this.panel1.Controls.Add(this.cbb_Hall);
            this.panel1.Controls.Add(this.cbb_Theater);
            this.panel1.Controls.Add(this.cbb_Rule);
            this.panel1.Controls.Add(this.cbb_Shape);
            this.panel1.Controls.Add(this.tb_Block);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 28);
            this.panel1.TabIndex = 0;
            // 
            // cbb_Hall
            // 
            this.cbb_Hall.FormattingEnabled = true;
            this.cbb_Hall.Location = new System.Drawing.Point(294, 4);
            this.cbb_Hall.Name = "cbb_Hall";
            this.cbb_Hall.Size = new System.Drawing.Size(117, 20);
            this.cbb_Hall.TabIndex = 13;
            // 
            // cbb_Theater
            // 
            this.cbb_Theater.FormattingEnabled = true;
            this.cbb_Theater.Location = new System.Drawing.Point(51, 4);
            this.cbb_Theater.Name = "cbb_Theater";
            this.cbb_Theater.Size = new System.Drawing.Size(216, 20);
            this.cbb_Theater.TabIndex = 12;
            // 
            // cbb_Rule
            // 
            this.cbb_Rule.FormattingEnabled = true;
            this.cbb_Rule.Location = new System.Drawing.Point(779, 3);
            this.cbb_Rule.Name = "cbb_Rule";
            this.cbb_Rule.Size = new System.Drawing.Size(145, 20);
            this.cbb_Rule.TabIndex = 11;
            // 
            // cbb_Shape
            // 
            this.cbb_Shape.FormattingEnabled = true;
            this.cbb_Shape.Location = new System.Drawing.Point(640, 3);
            this.cbb_Shape.Name = "cbb_Shape";
            this.cbb_Shape.Size = new System.Drawing.Size(67, 20);
            this.cbb_Shape.TabIndex = 10;
            // 
            // tb_Block
            // 
            this.tb_Block.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Block.Enabled = false;
            this.tb_Block.Location = new System.Drawing.Point(551, 3);
            this.tb_Block.Name = "tb_Block";
            this.tb_Block.Size = new System.Drawing.Size(46, 21);
            this.tb_Block.TabIndex = 9;
            this.tb_Block.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(720, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "排座规则";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(606, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "对齐";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "区域";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "楼层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "厅";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影院名";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 36);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cbb_Level
            // 
            this.cbb_Level.FormattingEnabled = true;
            this.cbb_Level.Location = new System.Drawing.Point(447, 3);
            this.cbb_Level.Name = "cbb_Level";
            this.cbb_Level.Size = new System.Drawing.Size(55, 20);
            this.cbb_Level.TabIndex = 14;
            // 
            // UC_HallInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_HallInfo";
            this.Size = new System.Drawing.Size(950, 40);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cbb_Hall;
        public System.Windows.Forms.ComboBox cbb_Theater;
        private System.Windows.Forms.ComboBox cbb_Rule;
        private System.Windows.Forms.ComboBox cbb_Shape;
        private System.Windows.Forms.TextBox tb_Block;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox cbb_Level;
    }
}

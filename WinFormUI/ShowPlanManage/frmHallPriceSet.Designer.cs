namespace Flamingo.ShowPlanManage
{
    partial class frmHallPriceSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHallPriceSet));
            this.txtMemberPrice = new System.Windows.Forms.TextBox();
            this.txtGroupPrice = new System.Windows.Forms.TextBox();
            this.txtStudentPrice = new System.Windows.Forms.TextBox();
            this.txtDoublePrice = new System.Windows.Forms.TextBox();
            this.txtSinglePrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHall = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtMemberPrice
            // 
            this.txtMemberPrice.Location = new System.Drawing.Point(110, 110);
            this.txtMemberPrice.Name = "txtMemberPrice";
            this.txtMemberPrice.Size = new System.Drawing.Size(85, 21);
            this.txtMemberPrice.TabIndex = 6;
            this.txtMemberPrice.Text = "0.00";
            this.txtMemberPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGroupPrice
            // 
            this.txtGroupPrice.Location = new System.Drawing.Point(321, 108);
            this.txtGroupPrice.Name = "txtGroupPrice";
            this.txtGroupPrice.Size = new System.Drawing.Size(85, 21);
            this.txtGroupPrice.TabIndex = 5;
            this.txtGroupPrice.Text = "0.00";
            this.txtGroupPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGroupPrice.Visible = false;
            // 
            // txtStudentPrice
            // 
            this.txtStudentPrice.Location = new System.Drawing.Point(110, 77);
            this.txtStudentPrice.Name = "txtStudentPrice";
            this.txtStudentPrice.Size = new System.Drawing.Size(85, 21);
            this.txtStudentPrice.TabIndex = 4;
            this.txtStudentPrice.Text = "0.00";
            this.txtStudentPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDoublePrice
            // 
            this.txtDoublePrice.Location = new System.Drawing.Point(321, 45);
            this.txtDoublePrice.Name = "txtDoublePrice";
            this.txtDoublePrice.Size = new System.Drawing.Size(85, 21);
            this.txtDoublePrice.TabIndex = 3;
            this.txtDoublePrice.Text = "0.00";
            this.txtDoublePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSinglePrice
            // 
            this.txtSinglePrice.Location = new System.Drawing.Point(110, 45);
            this.txtSinglePrice.Name = "txtSinglePrice";
            this.txtSinglePrice.Size = new System.Drawing.Size(85, 21);
            this.txtSinglePrice.TabIndex = 2;
            this.txtSinglePrice.Text = "0.00";
            this.txtSinglePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "团体票价：";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "双座零售票价：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "会员定价：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "学生票价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "单人零售票价：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(110, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "元";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "元";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "元";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(410, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "元";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "元";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(405, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "元";
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Location = new System.Drawing.Point(319, 76);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(85, 21);
            this.txtBoxPrice.TabIndex = 7;
            this.txtBoxPrice.Text = "0.00";
            this.txtBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(238, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "包厢票价：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "厅：";
            // 
            // cbHall
            // 
            this.cbHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHall.FormattingEnabled = true;
            this.cbHall.Location = new System.Drawing.Point(57, 12);
            this.cbHall.Name = "cbHall";
            this.cbHall.Size = new System.Drawing.Size(132, 20);
            this.cbHall.TabIndex = 1;
            this.cbHall.SelectedIndexChanged += new System.EventHandler(this.cbHall_SelectedIndexChanged);
            // 
            // frmHallPriceSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 214);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBoxPrice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbHall);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMemberPrice);
            this.Controls.Add(this.txtGroupPrice);
            this.Controls.Add(this.txtStudentPrice);
            this.Controls.Add(this.txtDoublePrice);
            this.Controls.Add(this.txtSinglePrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 246);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 246);
            this.Name = "frmHallPriceSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置分厅票价";
            this.Load += new System.EventHandler(this.frmHallPriceSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMemberPrice;
        private System.Windows.Forms.TextBox txtGroupPrice;
        private System.Windows.Forms.TextBox txtStudentPrice;
        private System.Windows.Forms.TextBox txtDoublePrice;
        private System.Windows.Forms.TextBox txtSinglePrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHall;
    }
}
namespace Flamingo.ShowPlanManage
{
    partial class frmCopyShowPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyShowPlan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboldHall = new System.Windows.Forms.ComboBox();
            this.lblTheter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpoldDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNewHall = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影院：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "影厅：";
            // 
            // cboldHall
            // 
            this.cboldHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboldHall.FormattingEnabled = true;
            this.cboldHall.Location = new System.Drawing.Point(443, 26);
            this.cboldHall.Name = "cboldHall";
            this.cboldHall.Size = new System.Drawing.Size(162, 20);
            this.cboldHall.TabIndex = 2;
            this.cboldHall.SelectedIndexChanged += new System.EventHandler(this.cboldHall_SelectedIndexChanged);
            // 
            // lblTheter
            // 
            this.lblTheter.Location = new System.Drawing.Point(58, 24);
            this.lblTheter.Name = "lblTheter";
            this.lblTheter.Size = new System.Drawing.Size(124, 20);
            this.lblTheter.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "日期：";
            // 
            // dtpoldDate
            // 
            this.dtpoldDate.Location = new System.Drawing.Point(227, 23);
            this.dtpoldDate.Name = "dtpoldDate";
            this.dtpoldDate.Size = new System.Drawing.Size(147, 21);
            this.dtpoldDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "复制到：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "影厅：";
            // 
            // cbNewHall
            // 
            this.cbNewHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewHall.FormattingEnabled = true;
            this.cbNewHall.Location = new System.Drawing.Point(443, 72);
            this.cbNewHall.Name = "cbNewHall";
            this.cbNewHall.Size = new System.Drawing.Size(162, 20);
            this.cbNewHall.TabIndex = 2;
            this.cbNewHall.SelectedIndexChanged += new System.EventHandler(this.cbNewHall_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "日期：";
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.Location = new System.Drawing.Point(227, 69);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(147, 21);
            this.dtpNewDate.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(244, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 25);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(388, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCopyShowPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 184);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNewDate);
            this.Controls.Add(this.dtpoldDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNewHall);
            this.Controls.Add(this.lblTheter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboldHall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCopyShowPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复制放映计划";
            this.Load += new System.EventHandler(this.frmCopyShowPlan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboldHall;
        private System.Windows.Forms.Label lblTheter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpoldDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNewHall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
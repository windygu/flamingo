namespace Flamingo.ShowPlanManage
{
    partial class frmManualWeave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualWeave));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbHall = new System.Windows.Forms.ComboBox();
            this.nuShowPlanNumber = new System.Windows.Forms.NumericUpDown();
            this.cbFilmName = new System.Windows.Forms.ComboBox();
            this.nuTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nuShowPlanNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeSpan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影厅：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "影片：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "首场开始时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "场间隔时间（分钟）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "预排场次数量：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(151, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbHall
            // 
            this.cbHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHall.FormattingEnabled = true;
            this.cbHall.Location = new System.Drawing.Point(71, 30);
            this.cbHall.Name = "cbHall";
            this.cbHall.Size = new System.Drawing.Size(193, 20);
            this.cbHall.TabIndex = 1;
            // 
            // nuShowPlanNumber
            // 
            this.nuShowPlanNumber.Location = new System.Drawing.Point(116, 108);
            this.nuShowPlanNumber.Name = "nuShowPlanNumber";
            this.nuShowPlanNumber.Size = new System.Drawing.Size(148, 21);
            this.nuShowPlanNumber.TabIndex = 5;
            // 
            // cbFilmName
            // 
            this.cbFilmName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilmName.FormattingEnabled = true;
            this.cbFilmName.Location = new System.Drawing.Point(71, 69);
            this.cbFilmName.Name = "cbFilmName";
            this.cbFilmName.Size = new System.Drawing.Size(193, 20);
            this.cbFilmName.TabIndex = 3;
            // 
            // nuTimeSpan
            // 
            this.nuTimeSpan.Location = new System.Drawing.Point(411, 69);
            this.nuTimeSpan.Name = "nuTimeSpan";
            this.nuTimeSpan.Size = new System.Drawing.Size(131, 21);
            this.nuTimeSpan.TabIndex = 4;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(411, 35);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(131, 21);
            this.dtpStartTime.TabIndex = 2;
            // 
            // frmManualWeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 220);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.nuTimeSpan);
            this.Controls.Add(this.nuShowPlanNumber);
            this.Controls.Add(this.cbFilmName);
            this.Controls.Add(this.cbHall);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(580, 252);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(580, 252);
            this.Name = "frmManualWeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入编制";
            this.Load += new System.EventHandler(this.frmManualWeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuShowPlanNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeSpan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbHall;
        private System.Windows.Forms.NumericUpDown nuShowPlanNumber;
        private System.Windows.Forms.ComboBox cbFilmName;
        private System.Windows.Forms.NumericUpDown nuTimeSpan;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
    }
}
namespace Flamingo.ShowPlanManage
{
    partial class frmDayilyShowPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayilyShowPlan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTheter = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.cbHall = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btncolse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影院：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "影厅：";
            // 
            // txtTheter
            // 
            this.txtTheter.Location = new System.Drawing.Point(59, 19);
            this.txtTheter.Name = "txtTheter";
            this.txtTheter.ReadOnly = true;
            this.txtTheter.Size = new System.Drawing.Size(188, 21);
            this.txtTheter.TabIndex = 3;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(308, 20);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(150, 21);
            this.txtDate.TabIndex = 4;
            // 
            // cbHall
            // 
            this.cbHall.FormattingEnabled = true;
            this.cbHall.Location = new System.Drawing.Point(525, 21);
            this.cbHall.Name = "cbHall";
            this.cbHall.Size = new System.Drawing.Size(146, 20);
            this.cbHall.TabIndex = 5;
            // 
            // dgvList
            // 
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(14, 49);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(837, 488);
            this.dgvList.TabIndex = 6;
            // 
            // btncolse
            // 
            this.btncolse.Location = new System.Drawing.Point(457, 547);
            this.btncolse.Name = "btncolse";
            this.btncolse.Size = new System.Drawing.Size(75, 23);
            this.btncolse.TabIndex = 7;
            this.btncolse.Text = "关闭";
            this.btncolse.UseVisualStyleBackColor = true;
            this.btncolse.Click += new System.EventHandler(this.btncolse_Click);
            // 
            // frmDayilyShowPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 582);
            this.Controls.Add(this.btncolse);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.cbHall);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTheter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDayilyShowPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "当日影院计划放映列表";
            this.Load += new System.EventHandler(this.frmDayilyShowPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTheter;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.ComboBox cbHall;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btncolse;
    }
}
namespace WinFormUI
{
    partial class UC_ImageButtonV
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
            this.tableLayoutPanel_R = new System.Windows.Forms.TableLayoutPanel();
            this.lb_displayText = new System.Windows.Forms.Label();
            this.pb_imageFlag = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel_R.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imageFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_R
            // 
            this.tableLayoutPanel_R.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel_R.ColumnCount = 2;
            this.tableLayoutPanel_R.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_R.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_R.Controls.Add(this.lb_displayText, 0, 1);
            this.tableLayoutPanel_R.Controls.Add(this.pb_imageFlag, 0, 0);
            this.tableLayoutPanel_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_R.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_R.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_R.Name = "tableLayoutPanel_R";
            this.tableLayoutPanel_R.RowCount = 2;
            this.tableLayoutPanel_R.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_R.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_R.Size = new System.Drawing.Size(92, 108);
            this.tableLayoutPanel_R.TabIndex = 0;
            this.tableLayoutPanel_R.Click += new System.EventHandler(this.tableLayoutPanel_R_Click);
            // 
            // lb_displayText
            // 
            this.lb_displayText.AutoSize = true;
            this.tableLayoutPanel_R.SetColumnSpan(this.lb_displayText, 2);
            this.lb_displayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_displayText.Location = new System.Drawing.Point(3, 40);
            this.lb_displayText.Name = "lb_displayText";
            this.lb_displayText.Size = new System.Drawing.Size(86, 68);
            this.lb_displayText.TabIndex = 1;
            this.lb_displayText.Text = "lb_displayText";
            this.lb_displayText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_displayText.Click += new System.EventHandler(this.lb_displayText_Click);
            // 
            // pb_imageFlag
            // 
            this.pb_imageFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_imageFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_imageFlag.Location = new System.Drawing.Point(0, 0);
            this.pb_imageFlag.Margin = new System.Windows.Forms.Padding(0);
            this.pb_imageFlag.Name = "pb_imageFlag";
            this.pb_imageFlag.Size = new System.Drawing.Size(40, 40);
            this.pb_imageFlag.TabIndex = 0;
            this.pb_imageFlag.TabStop = false;
            this.pb_imageFlag.Click += new System.EventHandler(this.pb_imageFlag_Click);
            // 
            // UC_ImageButtonV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_R);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_ImageButtonV";
            this.Size = new System.Drawing.Size(92, 108);
            this.tableLayoutPanel_R.ResumeLayout(false);
            this.tableLayoutPanel_R.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imageFlag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_R;
        public System.Windows.Forms.Label lb_displayText;
        public System.Windows.Forms.PictureBox pb_imageFlag;

    }
}

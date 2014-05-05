namespace WinFormUI.SaleTicket
{
    partial class frmDiscountT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountT));
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.combDiscount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiscountTypeName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYes.BackgroundImage")));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Location = new System.Drawing.Point(53, 96);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(134, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Location = new System.Drawing.Point(30, 56);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(65, 12);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "特价选择：";
            // 
            // combDiscount
            // 
            this.combDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combDiscount.FormattingEnabled = true;
            this.combDiscount.Location = new System.Drawing.Point(100, 52);
            this.combDiscount.Name = "combDiscount";
            this.combDiscount.Size = new System.Drawing.Size(97, 20);
            this.combDiscount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "特价类型：";
            // 
            // lblDiscountTypeName
            // 
            this.lblDiscountTypeName.AutoSize = true;
            this.lblDiscountTypeName.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountTypeName.Location = new System.Drawing.Point(98, 21);
            this.lblDiscountTypeName.Name = "lblDiscountTypeName";
            this.lblDiscountTypeName.Size = new System.Drawing.Size(53, 12);
            this.lblDiscountTypeName.TabIndex = 1;
            this.lblDiscountTypeName.Text = "特价类型";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combDiscount);
            this.panel1.Controls.Add(this.btnYes);
            this.panel1.Controls.Add(this.lblDiscountTypeName);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lblDiscount);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 136);
            this.panel1.TabIndex = 3;
            // 
            // frmDiscountT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(266, 157);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiscountT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "特价选择";
            this.Load += new System.EventHandler(this.frmDiscountT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.ComboBox combDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiscountTypeName;
        private System.Windows.Forms.Panel panel1;
    }
}
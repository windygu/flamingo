namespace Flamingo.ShowPlanManage
{
    partial class frmFilmBoxOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilmBoxOffice));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cbSelectValue = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStatGraphic = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 23);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(459, 339);
            this.dgvList.TabIndex = 0;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(529, 23);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(89, 12);
            this.lblSelect.TabIndex = 1;
            this.lblSelect.Text = "选择查询影片：";
            // 
            // cbSelectValue
            // 
            this.cbSelectValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectValue.FormattingEnabled = true;
            this.cbSelectValue.Location = new System.Drawing.Point(493, 50);
            this.cbSelectValue.Name = "cbSelectValue";
            this.cbSelectValue.Size = new System.Drawing.Size(163, 20);
            this.cbSelectValue.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(531, 166);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(167, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStatGraphic
            // 
            this.btnStatGraphic.Location = new System.Drawing.Point(328, 430);
            this.btnStatGraphic.Name = "btnStatGraphic";
            this.btnStatGraphic.Size = new System.Drawing.Size(75, 23);
            this.btnStatGraphic.TabIndex = 5;
            this.btnStatGraphic.Text = "生成统计图形";
            this.btnStatGraphic.UseVisualStyleBackColor = true;
            this.btnStatGraphic.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(10, 383);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 12);
            this.lblTotal.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(493, 49);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(163, 21);
            this.dtpDate.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(491, 87);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(17, 12);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "到";
            this.lblTime.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(493, 113);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(163, 21);
            this.dtpEndTime.TabIndex = 7;
            this.dtpEndTime.Visible = false;
            // 
            // frmFilmBoxOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 467);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnStatGraphic);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cbSelectValue);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.dgvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(693, 499);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(693, 499);
            this.Name = "frmFilmBoxOffice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基础查询  单片票房查询";
            this.Load += new System.EventHandler(this.frmFilmBoxOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cbSelectValue;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStatGraphic;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
    }
}
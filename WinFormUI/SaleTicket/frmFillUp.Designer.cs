namespace WinFormUI.SaleTicket
{
    partial class frmFillUp
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTheaterName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerShowPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combHall = new System.Windows.Forms.ComboBox();
            this.combShowPlan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPirce = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.combTicketType = new System.Windows.Forms.ComboBox();
            this.dgvFillUpTickets = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFillUpTickets)).BeginInit();
            this.panTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "影院：";
            // 
            // lblTheaterName
            // 
            this.lblTheaterName.AutoSize = true;
            this.lblTheaterName.Location = new System.Drawing.Point(90, 21);
            this.lblTheaterName.Name = "lblTheaterName";
            this.lblTheaterName.Size = new System.Drawing.Size(53, 12);
            this.lblTheaterName.TabIndex = 2;
            this.lblTheaterName.Text = "影院名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "日期：";
            // 
            // dateTimePickerShowPlanDate
            // 
            this.dateTimePickerShowPlanDate.Location = new System.Drawing.Point(245, 18);
            this.dateTimePickerShowPlanDate.Name = "dateTimePickerShowPlanDate";
            this.dateTimePickerShowPlanDate.Size = new System.Drawing.Size(122, 21);
            this.dateTimePickerShowPlanDate.TabIndex = 0;
            this.dateTimePickerShowPlanDate.ValueChanged += new System.EventHandler(this.dateTimePickerShowPlanDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "影厅：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "场次：";
            // 
            // combHall
            // 
            this.combHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combHall.FormattingEnabled = true;
            this.combHall.Location = new System.Drawing.Point(420, 19);
            this.combHall.Name = "combHall";
            this.combHall.Size = new System.Drawing.Size(88, 20);
            this.combHall.TabIndex = 1;
            this.combHall.SelectedIndexChanged += new System.EventHandler(this.combHall_SelectedIndexChanged);
            // 
            // combShowPlan
            // 
            this.combShowPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combShowPlan.FormattingEnabled = true;
            this.combShowPlan.Location = new System.Drawing.Point(562, 18);
            this.combShowPlan.Name = "combShowPlan";
            this.combShowPlan.Size = new System.Drawing.Size(203, 20);
            this.combShowPlan.TabIndex = 2;
            this.combShowPlan.SelectedIndexChanged += new System.EventHandler(this.combShowPlan_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "票类：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "单价：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "张数：";
            // 
            // txtPirce
            // 
            this.txtPirce.Location = new System.Drawing.Point(361, 61);
            this.txtPirce.MaxLength = 6;
            this.txtPirce.Name = "txtPirce";
            this.txtPirce.Size = new System.Drawing.Size(56, 21);
            this.txtPirce.TabIndex = 4;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(483, 61);
            this.txtNumber.MaxLength = 4;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(56, 21);
            this.txtNumber.TabIndex = 5;
            // 
            // combTicketType
            // 
            this.combTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combTicketType.FormattingEnabled = true;
            this.combTicketType.Location = new System.Drawing.Point(245, 61);
            this.combTicketType.Name = "combTicketType";
            this.combTicketType.Size = new System.Drawing.Size(69, 20);
            this.combTicketType.TabIndex = 3;
            // 
            // dgvFillUpTickets
            // 
            this.dgvFillUpTickets.AllowUserToAddRows = false;
            this.dgvFillUpTickets.AllowUserToDeleteRows = false;
            this.dgvFillUpTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFillUpTickets.Location = new System.Drawing.Point(10, 216);
            this.dgvFillUpTickets.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dgvFillUpTickets.Name = "dgvFillUpTickets";
            this.dgvFillUpTickets.ReadOnly = true;
            this.dgvFillUpTickets.RowTemplate.Height = 23;
            this.dgvFillUpTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFillUpTickets.Size = new System.Drawing.Size(941, 224);
            this.dgvFillUpTickets.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(808, 49);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 27);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(870, 49);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 27);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.LightGray;
            this.panTop.Controls.Add(this.btnBack);
            this.panTop.Controls.Add(this.btnAdd);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(10, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(941, 90);
            this.panTop.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.combTicketType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNumber);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPirce);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.combShowPlan);
            this.panel1.Controls.Add(this.lblTheaterName);
            this.panel1.Controls.Add(this.combHall);
            this.panel1.Controls.Add(this.dateTimePickerShowPlanDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 100);
            this.panel1.TabIndex = 11;
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.Color.LightGray;
            this.lblListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListTitle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblListTitle.Location = new System.Drawing.Point(10, 190);
            this.lblListTitle.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(941, 23);
            this.lblListTitle.TabIndex = 12;
            this.lblListTitle.Text = "手工售票补登一览";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFillUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 452);
            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.dgvFillUpTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFillUp";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "影票补登";
            this.Load += new System.EventHandler(this.frmFillUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFillUpTickets)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTheaterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerShowPlanDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combHall;
        private System.Windows.Forms.ComboBox combShowPlan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPirce;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ComboBox combTicketType;
        private System.Windows.Forms.DataGridView dgvFillUpTickets;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        protected System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label lblListTitle;
    }
}
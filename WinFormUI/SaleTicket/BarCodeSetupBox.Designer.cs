namespace WinFormUI.SaleTicket
{
    partial class BarCodeSetupBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barcodeControl2 = new Cobainsoft.Windows.Forms.BarcodeControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cheCode39 = new System.Windows.Forms.CheckBox();
            this.comType = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtSubData = new System.Windows.Forms.TextBox();
            this.vistaButton1 = new System.Windows.Forms.Button();
            this.vistaButton2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comDataShow = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.vistaButton3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "条形码类型：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.barcodeControl2);
            this.panel1.Location = new System.Drawing.Point(244, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 242);
            this.panel1.TabIndex = 2;
            // 
            // barcodeControl2
            // 
            this.barcodeControl2.AddOnCaption = null;
            this.barcodeControl2.AddOnData = null;
            this.barcodeControl2.BackColor = System.Drawing.Color.White;
            this.barcodeControl2.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.CODE39;
            this.barcodeControl2.Data = "000000";
            this.barcodeControl2.Font = new System.Drawing.Font("Arial", 9F);
            this.barcodeControl2.ForeColor = System.Drawing.Color.Black;
            this.barcodeControl2.HorizontalAlignment = Cobainsoft.Windows.Forms.BarcodeHorizontalAlignment.Center;
            this.barcodeControl2.InvalidDataAction = Cobainsoft.Windows.Forms.InvalidDataAction.DisplayInvalid;
            this.barcodeControl2.Location = new System.Drawing.Point(3, 3);
            this.barcodeControl2.LowerTopTextBy = 0F;
            this.barcodeControl2.Name = "barcodeControl2";
            this.barcodeControl2.RaiseBottomTextBy = 0F;
            this.barcodeControl2.Size = new System.Drawing.Size(218, 69);
            this.barcodeControl2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "标题：";
            // 
            // cheCode39
            // 
            this.cheCode39.AutoSize = true;
            this.cheCode39.BackColor = System.Drawing.Color.Transparent;
            this.cheCode39.Checked = true;
            this.cheCode39.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cheCode39.Location = new System.Drawing.Point(14, 79);
            this.cheCode39.Name = "cheCode39";
            this.cheCode39.Size = new System.Drawing.Size(204, 16);
            this.cheCode39.TabIndex = 3;
            this.cheCode39.Text = "在类39码的数据边缘是否打印星号";
            this.cheCode39.UseVisualStyleBackColor = false;
            this.cheCode39.CheckedChanged += new System.EventHandler(this.cheCode39_CheckedChanged);
            // 
            // comType
            // 
            this.comType.FormattingEnabled = true;
            this.comType.Items.AddRange(new object[] {
            "EAN13",
            "EAN8",
            "UPCA",
            "CODE39CHECK",
            "CODABAR",
            "CODE39",
            "C20F5",
            "INTERLEAVED2OF5",
            "UPCE",
            "EAN13_2",
            "EAN13_5",
            "EAN8_2",
            "EAN8_5",
            "UPCA_2",
            "UPCA_5",
            "UPCE_2",
            "UPCE_5",
            "EAN128A",
            "EAN128B",
            "EAN128C",
            "CODE93",
            "POSTNET",
            "CODE128A",
            "CODE128B",
            "CODE128C",
            "MSIPLESSEYCHECK10",
            "MSIPLESSEYCHECK1010",
            "MSIPLESSEYCHECK11",
            "MSIPLESSEYCHECK1110",
            "ROYALMAIL",
            "PLANET",
            "MSIPLESSEY"});
            this.comType.Location = new System.Drawing.Point(90, 16);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(121, 20);
            this.comType.TabIndex = 4;
            this.comType.SelectedIndexChanged += new System.EventHandler(this.comType_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(90, 47);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(121, 21);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.Text = "Cobainsoft";
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "数据：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "附加数据：";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(90, 133);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(121, 21);
            this.txtData.TabIndex = 5;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // txtSubData
            // 
            this.txtSubData.Location = new System.Drawing.Point(90, 165);
            this.txtSubData.Name = "txtSubData";
            this.txtSubData.Size = new System.Drawing.Size(121, 21);
            this.txtSubData.TabIndex = 5;
            this.txtSubData.TextChanged += new System.EventHandler(this.txtSubData_TextChanged);
            // 
            // vistaButton1
            // 
            this.vistaButton1.Location = new System.Drawing.Point(12, 228);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(75, 23);
            this.vistaButton1.TabIndex = 1;
            this.vistaButton1.Text = "打印(&P)";
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.vistaButton2.Location = new System.Drawing.Point(162, 228);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(75, 23);
            this.vistaButton2.TabIndex = 1;
            this.vistaButton2.Text = "关闭(&C)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "数据显示：";
            // 
            // comDataShow
            // 
            this.comDataShow.FormattingEnabled = true;
            this.comDataShow.Items.AddRange(new object[] {
            "底部",
            "顶部",
            "不显示"});
            this.comDataShow.Location = new System.Drawing.Point(90, 197);
            this.comDataShow.Name = "comDataShow";
            this.comDataShow.Size = new System.Drawing.Size(121, 20);
            this.comDataShow.TabIndex = 4;
            this.comDataShow.SelectedIndexChanged += new System.EventHandler(this.comDataShow_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 106);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "是否拉伸数据对齐边缘";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // vistaButton3
            // 
            this.vistaButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.vistaButton3.Location = new System.Drawing.Point(87, 228);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(75, 23);
            this.vistaButton3.TabIndex = 1;
            this.vistaButton3.Text = "保存(&S)";
            this.vistaButton3.Click += new System.EventHandler(this.vistaButton3_Click);
            // 
            // BarCodeSetupBox
            // 
            this.AcceptButton = this.vistaButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.vistaButton2;
            this.ClientSize = new System.Drawing.Size(556, 266);
            this.Controls.Add(this.vistaButton3);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubData);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.comDataShow);
            this.Controls.Add(this.comType);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cheCode39);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarCodeSetupBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条形码设置对话框";
            this.Load += new System.EventHandler(this.BarCodeSetupBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cheCode39;
        private System.Windows.Forms.ComboBox comType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtSubData;
        private System.Windows.Forms.Button vistaButton1;
        private System.Windows.Forms.Button vistaButton2;
        public Cobainsoft.Windows.Forms.BarcodeControl barcodeControl2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comDataShow;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button vistaButton3;
    }
}
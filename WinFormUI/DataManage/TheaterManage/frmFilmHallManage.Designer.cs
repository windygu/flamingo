namespace Flamingo.TheaterManage
{
    partial class frmFilmHallManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilmHallManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panHall = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHallId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPlayMode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFilmName = new System.Windows.Forms.TextBox();
            this.txtSoundSystem = new System.Windows.Forms.TextBox();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtHallName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CbTheaterName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProjector = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLevels = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtScreen = new System.Windows.Forms.TextBox();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.txtKeyWord);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Size = new System.Drawing.Size(792, 50);
            this.panTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panTop.Controls.SetChildIndex(this.btnEdit, 0);
            this.panTop.Controls.SetChildIndex(this.label1, 0);
            this.panTop.Controls.SetChildIndex(this.txtKeyWord, 0);
            this.panTop.Controls.SetChildIndex(this.btnReturn, 0);
            this.panTop.Controls.SetChildIndex(this.btnSave, 0);
            this.panTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panTop.Controls.SetChildIndex(this.btnQuery, 0);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(739, 10);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(683, 10);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(571, 10);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(627, 10);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(515, 10);
            // 
            // panList
            // 
            this.panList.Size = new System.Drawing.Size(792, 382);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Size = new System.Drawing.Size(790, 23);
            this.lblListTitle.Text = " 影厅信息表";
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Location = new System.Drawing.Point(6, 6);
            this.panDetail.Size = new System.Drawing.Size(763, 106);
            this.panDetail.Controls.SetChildIndex(this.lblDetailTitle, 0);
            this.panDetail.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Size = new System.Drawing.Size(761, 23);
            this.lblDetailTitle.Text = " 影厅信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "按影厅名称查询:";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(105, 16);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(208, 21);
            this.txtKeyWord.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(319, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 30);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panHall
            // 
            this.panHall.AutoSize = true;
            this.panHall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panHall.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHall.Location = new System.Drawing.Point(0, 0);
            this.panHall.Name = "panHall";
            this.panHall.Size = new System.Drawing.Size(792, 0);
            this.panHall.TabIndex = 57;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHallId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPlayMode, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFilmName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSoundSystem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSeats, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHallName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.CbTheaterName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProjector, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLevels, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtScreen, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 81);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "影厅编号:";
            // 
            // txtHallId
            // 
            this.txtHallId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHallId.Location = new System.Drawing.Point(94, 4);
            this.txtHallId.Name = "txtHallId";
            this.txtHallId.Size = new System.Drawing.Size(89, 21);
            this.txtHallId.TabIndex = 29;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescription, 5);
            this.txtDescription.Location = new System.Drawing.Point(264, 56);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(484, 21);
            this.txtDescription.TabIndex = 43;
            // 
            // txtPlayMode
            // 
            this.txtPlayMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPlayMode.Location = new System.Drawing.Point(648, 30);
            this.txtPlayMode.Name = "txtPlayMode";
            this.txtPlayMode.Size = new System.Drawing.Size(100, 21);
            this.txtPlayMode.TabIndex = 55;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 51;
            this.label15.Text = "说    明:";
            // 
            // txtFilmName
            // 
            this.txtFilmName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilmName.Location = new System.Drawing.Point(264, 4);
            this.txtFilmName.Name = "txtFilmName";
            this.txtFilmName.Size = new System.Drawing.Size(98, 21);
            this.txtFilmName.TabIndex = 32;
            // 
            // txtSoundSystem
            // 
            this.txtSoundSystem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSoundSystem.Location = new System.Drawing.Point(94, 56);
            this.txtSoundSystem.Name = "txtSoundSystem";
            this.txtSoundSystem.Size = new System.Drawing.Size(89, 21);
            this.txtSoundSystem.TabIndex = 42;
            // 
            // txtSeats
            // 
            this.txtSeats.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSeats.Location = new System.Drawing.Point(648, 4);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(100, 21);
            this.txtSeats.TabIndex = 54;
            this.txtSeats.Validating += new System.ComponentModel.CancelEventHandler(this.txtSeats_Validating);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 50;
            this.label16.Text = "声音模式:";
            // 
            // txtHallName
            // 
            this.txtHallName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtHallName.AutoSize = true;
            this.txtHallName.Location = new System.Drawing.Point(198, 7);
            this.txtHallName.Name = "txtHallName";
            this.txtHallName.Size = new System.Drawing.Size(59, 12);
            this.txtHallName.TabIndex = 35;
            this.txtHallName.Text = "影厅名称:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "影院名称:";
            // 
            // CbTheaterName
            // 
            this.CbTheaterName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbTheaterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTheaterName.FormattingEnabled = true;
            this.CbTheaterName.Location = new System.Drawing.Point(457, 4);
            this.CbTheaterName.Name = "CbTheaterName";
            this.CbTheaterName.Size = new System.Drawing.Size(95, 20);
            this.CbTheaterName.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(582, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "放映模式:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(582, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "座位数量:";
            // 
            // txtProjector
            // 
            this.txtProjector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProjector.Location = new System.Drawing.Point(457, 30);
            this.txtProjector.Name = "txtProjector";
            this.txtProjector.Size = new System.Drawing.Size(95, 21);
            this.txtProjector.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "楼层数量:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(391, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 47;
            this.label8.Text = "放 映 机:";
            // 
            // txtLevels
            // 
            this.txtLevels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLevels.Location = new System.Drawing.Point(94, 30);
            this.txtLevels.Name = "txtLevels";
            this.txtLevels.Size = new System.Drawing.Size(89, 21);
            this.txtLevels.TabIndex = 36;
            this.txtLevels.Validating += new System.ComponentModel.CancelEventHandler(this.txtLevels_Validating);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "银    幕:";
            // 
            // txtScreen
            // 
            this.txtScreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtScreen.Location = new System.Drawing.Point(264, 30);
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.Size = new System.Drawing.Size(98, 21);
            this.txtScreen.TabIndex = 37;
            // 
            // frmFilmHallManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFilmHallManage";
            this.Text = "影厅管理";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.panDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panHall;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHallId;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFilmName;
        private System.Windows.Forms.TextBox txtSoundSystem;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label txtHallName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbTheaterName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProjector;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLevels;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtScreen;
        private System.Windows.Forms.TextBox txtPlayMode;

    }
}

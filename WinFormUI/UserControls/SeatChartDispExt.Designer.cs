﻿namespace WinFormUI
{
    partial class SeatChartDispExt
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_TopRight = new System.Windows.Forms.Label();
            this.lb_TopCenter = new System.Windows.Forms.Label();
            this.lb_TopLeft = new System.Windows.Forms.Label();
            this.seatChartDisp1 = new SeatMaDll.SeatChartDisp();
            this.pb_Screen = new System.Windows.Forms.PictureBox();
            this.lb_Screen = new System.Windows.Forms.Label();
            this.lb_BottomRight = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Screen)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lb_TopRight, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_TopCenter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_TopLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.seatChartDisp1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pb_Screen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_Screen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_BottomRight, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_TopRight
            // 
            this.lb_TopRight.AutoSize = true;
            this.lb_TopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_TopRight.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_TopRight.Location = new System.Drawing.Point(355, 0);
            this.lb_TopRight.Name = "lb_TopRight";
            this.lb_TopRight.Size = new System.Drawing.Size(172, 24);
            this.lb_TopRight.TabIndex = 2;
            this.lb_TopRight.Text = "lb_TopRight";
            this.lb_TopRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_TopCenter
            // 
            this.lb_TopCenter.AutoSize = true;
            this.lb_TopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_TopCenter.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_TopCenter.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_TopCenter.Location = new System.Drawing.Point(179, 0);
            this.lb_TopCenter.Name = "lb_TopCenter";
            this.lb_TopCenter.Size = new System.Drawing.Size(170, 24);
            this.lb_TopCenter.TabIndex = 1;
            this.lb_TopCenter.Text = "lb_TopCenter";
            this.lb_TopCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_TopLeft
            // 
            this.lb_TopLeft.AutoSize = true;
            this.lb_TopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_TopLeft.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_TopLeft.Location = new System.Drawing.Point(3, 0);
            this.lb_TopLeft.Name = "lb_TopLeft";
            this.lb_TopLeft.Size = new System.Drawing.Size(170, 24);
            this.lb_TopLeft.TabIndex = 0;
            this.lb_TopLeft.Text = "lb_TopLeft";
            this.lb_TopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seatChartDisp1
            // 
            this.seatChartDisp1.AutoScroll = true;
            this.seatChartDisp1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.seatChartDisp1.BoxBorderColor = System.Drawing.Color.White;
            this.seatChartDisp1.Column_Space = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.seatChartDisp1, 3);
            this.seatChartDisp1.CurrentMouseCursorStatus = SeatMaDll.UC_SeatChartPanel.MouseCursorStatus.Empty;
            this.seatChartDisp1.DispImageMode = true;
            this.seatChartDisp1.DisplayRowNumber = false;
            this.seatChartDisp1.DispMoveRuler = true;
            this.seatChartDisp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatChartDisp1.LeftSpace = 30;
            this.seatChartDisp1.Location = new System.Drawing.Point(3, 57);
            this.seatChartDisp1.MatrixColumnCount = 10;
            this.seatChartDisp1.MatrixRectangeType = SeatMaDll.UC_SeatChartPanel.MatrixRectType.Fix;
            this.seatChartDisp1.MatrixRowCount = 10;
            this.seatChartDisp1.MatrixUnitHeight = 30;
            this.seatChartDisp1.MatrixUnitWidth = 40;
            this.seatChartDisp1.Name = "seatChartDisp1";
            this.seatChartDisp1.Rotation = 0;
            this.seatChartDisp1.Row_Space = 8;
            this.seatChartDisp1.Size = new System.Drawing.Size(524, 44);
            this.seatChartDisp1.TabIndex = 3;
            this.seatChartDisp1.ZoomSize = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pb_Screen
            // 
            this.pb_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Screen.Image = global::WinFormUI.Properties.Resources.screen;
            this.pb_Screen.Location = new System.Drawing.Point(179, 27);
            this.pb_Screen.Name = "pb_Screen";
            this.pb_Screen.Size = new System.Drawing.Size(170, 4);
            this.pb_Screen.TabIndex = 4;
            this.pb_Screen.TabStop = false;
            // 
            // lb_Screen
            // 
            this.lb_Screen.AutoSize = true;
            this.lb_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Screen.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_Screen.Location = new System.Drawing.Point(179, 34);
            this.lb_Screen.Name = "lb_Screen";
            this.lb_Screen.Size = new System.Drawing.Size(170, 20);
            this.lb_Screen.TabIndex = 5;
            this.lb_Screen.Text = "银幕";
            this.lb_Screen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_BottomRight
            // 
            this.lb_BottomRight.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_BottomRight, 2);
            this.lb_BottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_BottomRight.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_BottomRight.Location = new System.Drawing.Point(179, 134);
            this.lb_BottomRight.Name = "lb_BottomRight";
            this.lb_BottomRight.Size = new System.Drawing.Size(348, 46);
            this.lb_BottomRight.TabIndex = 6;
            this.lb_BottomRight.Text = "lb_BottomRight";
            this.lb_BottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeatChartDispExt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SeatChartDispExt";
            this.Size = new System.Drawing.Size(530, 180);
            this.Load += new System.EventHandler(this.SeatChartDispExt_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Screen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_TopRight;
        private System.Windows.Forms.Label lb_TopCenter;
        private System.Windows.Forms.Label lb_TopLeft;
        public SeatMaDll.SeatChartDisp seatChartDisp1;
        public System.Windows.Forms.PictureBox pb_Screen;
        public System.Windows.Forms.Label lb_Screen;
        private System.Windows.Forms.Label lb_BottomRight;
    }
}

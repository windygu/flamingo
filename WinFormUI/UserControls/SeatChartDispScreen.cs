using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinFormUI
{
    public partial class SeatChartDispScreen : UserControl
    {
        public SeatChartDispScreen()
        {
            InitializeComponent();
            this.tableLayoutPanel1.RowStyles[4].Height = 0F;
            this.tableLayoutPanel1.RowStyles[3].Height = 0F;
            this.tableLayoutPanel1.RowStyles[2].Height = 520F;
        }
        public void SetSeatingChartHeight(int nHeight)
        {
            this.tableLayoutPanel1.RowStyles[2].Height = nHeight;
        }
        public void SetBgColor(Color bgColor)
        {
            tableLayoutPanel1.BackColor = bgColor;
            seatChartDisp1.BackColor = bgColor;

        }

        public void SetBottomDisplay_Right(string szText)
        {
            lb_BottomRight.Text = szText;
        }

        
        public void InitRotation(int nRotation)
        {
            if (nRotation == 180)
            {
                this.tableLayoutPanel1.RowStyles[4].Height = 10F;
                this.tableLayoutPanel1.RowStyles[3].Height = 20F;

                this.tableLayoutPanel1.Controls.Remove(this.pb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.pb_Screen, 1, 4);
                this.tableLayoutPanel1.Controls.Remove(this.lb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.lb_Screen, 1, 3);

                this.tableLayoutPanel1.RowStyles[1].Height = 0F;
                this.tableLayoutPanel1.RowStyles[2].Height = 0F;
            }
            else
            {
                this.tableLayoutPanel1.RowStyles[0].Height = 10F;
                this.tableLayoutPanel1.RowStyles[1].Height = 20F;

                this.tableLayoutPanel1.Controls.Remove(this.pb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.pb_Screen, 1, 0);
                this.tableLayoutPanel1.Controls.Remove(this.lb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.lb_Screen, 1, 1);

                this.tableLayoutPanel1.RowStyles[4].Height = 0F;
                this.tableLayoutPanel1.RowStyles[3].Height = 0F;
            }
        }
        public void Rotation()
        {
            if (seatChartDisp1.Rotation == 0)
                seatChartDisp1.Rotation = 180;
            else
                seatChartDisp1.Rotation = 0;

            if (seatChartDisp1.Rotation == 180)
            {
                this.tableLayoutPanel1.RowStyles[4].Height = 10F;
                this.tableLayoutPanel1.RowStyles[3].Height = 20F;

                this.tableLayoutPanel1.Controls.Remove(this.pb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.pb_Screen, 1, 4);
                this.tableLayoutPanel1.Controls.Remove(this.lb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.lb_Screen, 1, 3);

                this.tableLayoutPanel1.RowStyles[0].Height = 0F;
                this.tableLayoutPanel1.RowStyles[1].Height = 0F;
            }
            else
            {
                this.tableLayoutPanel1.RowStyles[0].Height = 10F;
                this.tableLayoutPanel1.RowStyles[1].Height = 20F;

                this.tableLayoutPanel1.Controls.Remove(this.pb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.pb_Screen, 1, 0);
                this.tableLayoutPanel1.Controls.Remove(this.lb_Screen);
                this.tableLayoutPanel1.Controls.Add(this.lb_Screen, 1, 1);

                this.tableLayoutPanel1.RowStyles[4].Height = 0F;
                this.tableLayoutPanel1.RowStyles[3].Height = 0F;
            }
        }

        private void SeatChartDispExt_Load(object sender, EventArgs e)
        {
            
        }
    }
}


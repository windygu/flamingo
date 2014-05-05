using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormUI.BI;

namespace WinFormUI
{
    public partial class UC_SiteMenu : UserControl
    {
        private SeatMaDll.EditSeatInfo m_EditSiteInfo = new SeatMaDll.EditSeatInfo();
        public UC_SiteMenu()
        {
            InitializeComponent();
        }

        public void SetBgColor(Color bgColor)
        {
            tableLayoutPanel1.BackColor = bgColor;
            this.BackColor = bgColor;
        }

        private void tableLayoutPanel1_BackColorChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.BackColor = this.BackColor;
            }
        }

        private void UC_SiteMenu_BackColorChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.BackColor = this.BackColor;
            }
        }
    }
}
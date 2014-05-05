using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.FilmManage;
using Flamingo.TheaterManage;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmTheater : Form
    {
        private ToolTip toolTip;

        public frmTheater()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;
            this.SizeChanged += new EventHandler(frmFilmManage_SizeChanged);

            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(btnMin, "最小化");
            toolTip.SetToolTip(btnClose, "关闭");
        }

        private void frmFilmManage_SizeChanged(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Bounds = GetClientRec();
            }
        }

        private void ShowChildForm(Form childForm)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == childForm.GetType() && form.IsDisposed != true)
                {
                    childForm = form;
                    break;
                }
            }

            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.TopMost = false;
            childForm.Bounds = GetClientRec();
            childForm.MdiParent = this;
            childForm.Show();
            childForm.Focus();
        }

        private Rectangle GetClientRec()
        {
            Rectangle mdiClientArea = Rectangle.Empty;
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    mdiClientArea = c.ClientRectangle;
            }

            return mdiClientArea;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTheaterInfoManage frm = new frmTheaterInfoManage();
            ShowChildForm(frm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmFilmHallManage frm = new frmFilmHallManage();
            ShowChildForm(frm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmTaxManage frm = new frmTaxManage();
            ShowChildForm(frm);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmUploadSettingManage frm = new frmUploadSettingManage();
            ShowChildForm(frm);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmTimeSettingManage frm = new frmTimeSettingManage();
            ShowChildForm(frm);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmFareSettingManage frm = new frmFareSettingManage();
            ShowChildForm(frm);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmShowTypeManage frm = new frmShowTypeManage();
            ShowChildForm(frm);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmDiscountManage frm = new frmDiscountManage();
            ShowChildForm(frm);
        }

        private void tmExit_Click(object sender, EventArgs e)
        {

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmDownloadSettingManage frm = new frmDownloadSettingManage();
            ShowChildForm(frm);
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            ShowChildForm(frm);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            frmAnthorization frm = new frmAnthorization();
            ShowChildForm(frm);
        }
    }
}

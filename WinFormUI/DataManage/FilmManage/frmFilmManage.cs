using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.TheaterManage;

namespace Flamingo.FilmManage
{
    //2011/12/20,Qiu
    public partial class frmFilmManage : Form
    {
        private ToolTip toolTip;

        public frmFilmManage()
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
            frmFilmCategoryManage frm = new frmFilmCategoryManage();
            ShowChildForm(frm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmFilmAreaManage frm = new frmFilmAreaManage();
            ShowChildForm(frm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmFilmModeManage frm = new frmFilmModeManage();
            ShowChildForm(frm);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmFilmInfoManage frm = new frmFilmInfoManage();
            ShowChildForm(frm);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmFilmDownloadManage frm = new frmFilmDownloadManage();
            ShowChildForm(frm);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmFilmDownloadSetting frm = new frmFilmDownloadSetting();
            ShowChildForm(frm);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmDownloadSettingManage frm = new frmDownloadSettingManage();
            ShowChildForm(frm);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmFilmTypeManage frm = new frmFilmTypeManage();
            ShowChildForm(frm);
        }
    }
}

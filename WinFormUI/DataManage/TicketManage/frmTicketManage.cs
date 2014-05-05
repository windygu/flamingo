using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TicketManage
{
    public partial class frmTicketManage : Form
    {
        private ToolTip toolTip;

        public frmTicketManage()
        {
            InitializeComponent();

            this.SizeChanged += new EventHandler(frmFilmManage_SizeChanged);
            toolStripButton4.Visible = false;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmCustomerTypeManage frm = new frmCustomerTypeManage();
            ShowChildForm(frm);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmCustomerManage frm = new frmCustomerManage();
            ShowChildForm(frm);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmDebtManage frm = new frmDebtManage();
            ShowChildForm(frm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmVoucherManage frm = new frmVoucherManage();
            ShowChildForm(frm);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmVoucherTypeManage frm = new frmVoucherTypeManage();
            ShowChildForm(frm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmVoucherSubType frm = new frmVoucherSubType();
            ShowChildForm(frm);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmVoucherBatchManage frm = new frmVoucherBatchManage();
            ShowChildForm(frm);
        }

        private void 影城票券使用情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBestowCircsStatManage frm = new frmBestowCircsStatManage();
            ShowChildForm(frm);
        }

        private void 影城票券销售统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTicketSaleStatistic frm = new frmTicketSaleStatistic();
            ShowChildForm(frm);
        }

        private void toolStripButton5_ButtonClick(object sender, EventArgs e)
        {

        }

        private void 单用户兑换券使用情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeManage frm = new frmChangeManage();
            ShowChildForm(frm);
        }

        private void 影城单批次兑换券使用情况统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSingleVoucherBatch frm = new frmSingleVoucherBatch();
            ShowChildForm(frm);
        }
    }
}

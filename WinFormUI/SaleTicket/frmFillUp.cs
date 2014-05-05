using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.Right;

namespace WinFormUI.SaleTicket
{
    public partial class frmFillUp : Form
    {

        public frmFillUp()
        {
            InitializeComponent();
        }

        private string theaterid;
        private string theatername;

        private void frmFillUp_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            GetTheater();
            GetHall();
            GetTicketType();
            GetShowPlan();

            if (!FrmMain.curUser.HavePermission(Permissions.FillupTicketSelling))
                btnAdd.Enabled = false;
        }

        private void GetTheater()
        {
            string[] theaterinfo = Flamingo.BLL.User.GetTheater();
            theaterid = theaterinfo[0];
            theatername = theaterinfo[1];
            lblTheaterName.Text = theatername;
        }

        private void GetHall()
        {
            DataTable dt = Flamingo.BLL.User.GetHall(theaterid);
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = null;
            dt.Rows.Add(dr);
            combHall.DataSource = dt;
            combHall.ValueMember = "HallId";
            combHall.DisplayMember = "HallName";
            combHall.SelectedIndex = dt.Rows.Count - 1;
        }

        private void GetTicketType()
        {
            DataTable dt = Flamingo.BLL.Ticket.GetTicketType();
            combTicketType.DataSource = dt;
            combTicketType.ValueMember = "TicketTypeId";
            combTicketType.DisplayMember = "TicketTypeName";
        }

        private void GetShowPlan()
        {
            string dailyplanid = DateTime.Parse(dateTimePickerShowPlanDate.Text).ToString("yyyyMMdd");
            string hallid = null;
            if (combHall.SelectedValue.ToString().Length == 2)
                hallid = combHall.SelectedValue.ToString();
            DataTable dt = Flamingo.BLL.ShowPlan.GetShowPlanInfo(dailyplanid, hallid);
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = null;
            dt.Rows.Add(dr);
            combShowPlan.DataSource = dt;
            combShowPlan.ValueMember = "ShowPlanId";
            combShowPlan.DisplayMember = "ShowPlanInfo";
            combShowPlan.SelectedIndex = dt.Rows.Count - 1;
        }

        private void dateTimePickerShowPlanDate_ValueChanged(object sender, EventArgs e)
        {
            GetShowPlan();
            GetList();
        }

        private void combHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetShowPlan();
            GetList();
        }

        private void GetList()
        {
            string dailyplanid = DateTime.Parse(dateTimePickerShowPlanDate.Text).ToString("yyyyMMdd");
            string hallid = null;
            if (combHall.SelectedValue.ToString().Length == 2)
                hallid = combHall.SelectedValue.ToString();
            string showplanid = null;
            if (combShowPlan.SelectedValue.ToString().Length == 12)
                showplanid = combShowPlan.SelectedValue.ToString();
            DataTable dt = Flamingo.BLL.Ticket.GetFillUp(dailyplanid, hallid, showplanid);
            dgvFillUpTickets.DataSource = dt;
        }

        private void combShowPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string showplanid = null;
            if (combShowPlan.SelectedValue.ToString().Length == 12)
                showplanid = combShowPlan.SelectedValue.ToString();
            if (showplanid == null)
            {
                MessageBox.Show("请选择一个场次", "提示", MessageBoxButtons.OK);
                return;
            }
            float price = 0;
            if (!Flamingo.Common.StringHelper.IsFloat(txtPirce.Text.Trim()))
            {
                MessageBox.Show("请输入有效票价");
                return;
            }
            price = float.Parse(txtPirce.Text.Trim());
            int count = 0;
            if (!Flamingo.Common.StringHelper.IsInt32(txtNumber.Text.Trim()))
            {
                MessageBox.Show("请输入有效数量");
                return;
            }
            count = Int32.Parse(txtNumber.Text.Trim());
            string msg = string.Format("确定补登影票到\r\n    日期:{0}\r\n    影厅:{1}\r\n    场次:{2}\r\n    票类:{3}\r\n    单价:{4}\r\n    数量:{5}",
                dateTimePickerShowPlanDate.Text, combHall.Text, combShowPlan.Text, combTicketType.Text,
                txtPirce.Text, txtNumber.Text);
            DialogResult dr = MessageBox.Show(msg,"确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            dr = MessageBox.Show(msg, "再次确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            bool tf = false;
            int tickettypeid = Int32.Parse(combTicketType.SelectedValue.ToString());
            string ticketids = Flamingo.Common.StringHelper.NewGuids(count);
            tf = Flamingo.BLL.Ticket.AddFillUp(ticketids, price, FrmMain.curUser.UserId, tickettypeid, showplanid);
            if (tf == false)
            {
                MessageBox.Show("补登失败");
            }
            else
            {
                GetList();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    public partial class frmCopyShowPlan : Form
    {
        private DailyShowPlanManage dataManager;

        private string[] Str;

        private List<Hall> oldHallList;
        private List<Hall> newHallList;

        public frmCopyShowPlan(DailyShowPlanManage datamanager, string Theter)
        {
            InitializeComponent();
            this.dataManager = datamanager;
            lblTheter.Text = Theter;
            oldHallList = new List<Hall>();
            newHallList = new List<Hall>();
        }

        private void frmCopyShowPlan_Load(object sender, EventArgs e)
        {
            dtpoldDate.Value = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value;
            dtpNewDate.Value = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value;
            Hall hall = new Hall();
            hall.HallName = "全部影厅";
            hall.HallId = null;
            oldHallList.Add(hall);
            oldHallList.AddRange(this.dataManager.DailyShowPlan.HallList);
            newHallList.AddRange(oldHallList);
            BainDate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (dtpNewDate.Value < DateTime.Now.Date)
            {
                MessageBox.Show("不能复制到不可用的日期", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //数组保存顺序：
            //（0）被复制信息的日期
            //（1）被复制信息的影厅（null表示复制全部影厅）
            //（2）目标日期
            //（3）目标影厅（null表示复制全部影厅）
            Str = new string[4];

            Str[0] = dtpoldDate.Value.ToShortDateString();
            try
            {
                Str[1] = cboldHall.SelectedValue.ToString();
                Str[3] = cbNewHall.SelectedValue.ToString();
            }
            catch
            {
                Str[1] = null;
                Str[3] = null;
            }

            Str[2] = dtpNewDate.Value.ToShortDateString();


            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BainDate()
        {
            cboldHall.ValueMember = "HallId";
            cboldHall.DisplayMember = "HallName";
            cboldHall.DataSource = oldHallList;

            cbNewHall.ValueMember = "HallId";
            cbNewHall.DisplayMember = "HallName";
            cbNewHall.DataSource = newHallList;
        }

        public String[] GetStr
        {
            get { return this.Str; }
        }

        private void cboldHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboldHall.SelectedValue == null)
            {
                if (cbNewHall.DataSource != null)
                    cbNewHall.SelectedIndex = 0;
                cbNewHall.Enabled = false;
            }
            else
            {
                cbNewHall.Enabled = true;
                cbNewHall.SelectedIndex = 1;
            }
        }

        private void cbNewHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNewHall.SelectedValue == null)
                if (cboldHall.DataSource != null)
                    cboldHall.SelectedIndex = 0;
        }
    }
}

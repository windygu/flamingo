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
    public partial class frmShowPlanPriceSet : Form
    {
        private DailyShowPlanManage dataManager;
        private List<ShowPlanInfo> showPlanInfoList;
        private List<Hall> hallList;
        private ShowPlanInfo showplaninfo;

        public frmShowPlanPriceSet(DailyShowPlanManage datamager)
        {
            InitializeComponent();
            this.dataManager = datamager;
            this.showPlanInfoList = this.dataManager.GetShowPlanInfoList();
            this.hallList = dataManager.DailyShowPlan.HallList;
        }

        private void frmShowPlanPriceSet_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void SetPrice()
        {
            try
            {
                txtSinglePrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.SinglePrice), 1).ToString("0.00");
                txtDoublePrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.DoublePrice), 1).ToString("0.00");
                txtStudentPrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.StudentPrice), 1).ToString("0.00");
                txtGroupPrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.GroupPrice), 1).ToString("0.00");
                txtMemberPrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.MemberPrice), 1).ToString("0.00");
                txtBoxPrice.Text = decimal.Round(Convert.ToDecimal(this.showplaninfo.BoxPrice), 1).ToString("0.00");
            }
            catch { }
        }


        private void cbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbShowPlan.ValueMember = "ShowPlanId";
                cbShowPlan.DisplayMember = "ShowPlanName";
                var list = showPlanInfoList.Where(p => p.HallId == cbHall.SelectedValue.ToString().Trim()).OrderBy(P => P.ShowPlanId).ToList();
                if (list.Count <= 0)
                {
                    UnBindData();
                    SetEneableFalse();
                    cbShowPlan.Enabled = false;
                }
                else
                    cbShowPlan.Enabled = true;
                cbShowPlan.DataSource = list;
            }
            catch { }
        }

        private void cbShowPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnBindData();
            showplaninfo = this.showPlanInfoList.Where(p => p.ShowPlanId == cbShowPlan.SelectedValue.ToString()).FirstOrDefault();
            if (showplaninfo != null)
            {
                if (showplaninfo.FareSettingId != dataManager.FareSettingShowPlanPriceId)
                {
                      var tmp=dataManager.GetFareSettingList.Where(p=>p.FareSettingId==dataManager.FareSettingShowPlanPriceId).FirstOrDefault();
                      showplaninfo.SinglePrice = tmp.SinglePrice;
                      showplaninfo.DoublePrice = tmp.DoublePrice;
                      showplaninfo.StudentPrice = tmp.StudentPrice;
                      showplaninfo.GroupPrice = tmp.GroupPrice;
                      showplaninfo.MemberPrice = tmp.MemberPrice;
                      showplaninfo.BoxPrice = tmp.BoxPrice;
                }

                BindData();
                SetPrice();
            }
        }
        //填充ComboBox
        private void FillData()
        {
            cbHall.ValueMember = "HallId";
            cbHall.DisplayMember = "HallName";
            cbHall.DataSource = hallList;

            cbShowPlan.ValueMember = "ShowPlanId";
            cbShowPlan.DisplayMember = "ShowPlanName";
        }
        // <summary>
        /// TextBox控件绑定到货币类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_Currency_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((float)e.Value).ToString("0.00");
                }
                catch
                {
                }
            }
        }

        // 绑定控件的值
        private void BindData()
        {
            txtSinglePrice.DataBindings.Add("Text", showplaninfo, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtDoublePrice.DataBindings.Add("Text", showplaninfo, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtStudentPrice.DataBindings.Add("Text", showplaninfo, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtGroupPrice.DataBindings.Add("Text", showplaninfo, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtBoxPrice.DataBindings.Add("Text", showplaninfo, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtMemberPrice.DataBindings.Add("Text", showplaninfo, "MemberPrice", true);
            txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            try
            {
                if (( showplaninfo.FareSettingId!=null&&showplaninfo.FareSettingId > dataManager.FareSettingShowPlanPriceId) || showplaninfo.IsLocked == true)
                {
                    SetEneableFalse();
                    MessageBox.Show("该场次已经已锁定或已开售，不能设置分场票价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SetEnableTrue();
                }
            }
            catch { }
        }

        private void SetEnableTrue()
        {
            txtSinglePrice.Enabled = true;
            txtDoublePrice.Enabled = true;
            txtStudentPrice.Enabled = true;
            txtGroupPrice.Enabled = true;
            txtBoxPrice.Enabled = true;
            txtMemberPrice.Enabled = true;
        }

        private void SetEneableFalse()
        {
            txtSinglePrice.Enabled = false;
            txtDoublePrice.Enabled = false;
            txtStudentPrice.Enabled = false;
            txtGroupPrice.Enabled = false;
            txtBoxPrice.Enabled = false;
            txtMemberPrice.Enabled = false;
        }

        // 清除绑定控件的值
        private void UnBindData()
        {
            txtSinglePrice.DataBindings.Clear();
            txtDoublePrice.DataBindings.Clear();
            txtStudentPrice.DataBindings.Clear();
            txtGroupPrice.DataBindings.Clear();
            txtBoxPrice.DataBindings.Clear();
            txtMemberPrice.DataBindings.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbShowPlan.Enabled == false)
            {
                MessageBox.Show("没选择场次，不能设置分场票价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (showplaninfo.FareSettingId>dataManager.FareSettingShowPlanPriceId||showplaninfo.IsLocked==true)
            {
                MessageBox.Show("该场次已经设置了区域票价或锁定，不能设置分场票价！" , "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                dataManager.SetShowPlanPrice(showplaninfo);
                if (MessageBox.Show("设置分场票价成功，现在是否关闭窗口？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

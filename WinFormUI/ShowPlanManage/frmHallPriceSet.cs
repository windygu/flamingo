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
    public partial class frmHallPriceSet : Form
    {
        #region 窗体变量

        private HallPriceSet hallPriceSet;
        private DailyShowPlanManage dataManager;
        private HallPrices hallPrice;
        private List<HallPrices> hallPriceList;

        #endregion

        #region 启动处理
        public frmHallPriceSet(DailyShowPlanManage dataManager)
        {
            this.dataManager = dataManager;
            InitializeComponent();
            hallPriceSet = new HallPriceSet();
        }

        private void frmHallPriceSet_Load(object sender, EventArgs e)
        {
            hallPriceList = dataManager.GetHallPriceList();
          
            //填充下拉框控件的值
            FillData();
            cbHall.SelectedIndex = 0;
            SetPrice();
        }

        #endregion


        #region 窗体事件
        private void SetPrice()
        {
            try
            {
                txtSinglePrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.SinglePrice), 1).ToString("0.00");
                txtDoublePrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.DoublePrice), 1).ToString("0.00");
                txtStudentPrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.StudentPrice), 1).ToString("0.00");
                txtGroupPrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.GroupPrice), 1).ToString("0.00");
                txtMemberPrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.MemberPrice), 1).ToString("0.00");
                txtBoxPrice.Text = decimal.Round(Convert.ToDecimal(this.hallPrice.BoxPrice), 1).ToString("0.00");
            }
            catch { }
        }

        /// <summary>
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            //更新设置分厅票价所在厅的放映计划的票价
            try
            {
                dataManager.SetHallPrice(hallPrice);

                this.Hide();
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

        private void cbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //取消下拉框以外控件的绑定
                UnBindData();

                //获取下拉框选择的值
                string HallId = cbHall.SelectedValue.ToString();

                //获取当前日期中下拉框选择的影厅对应的影厅票价的记录信息

                hallPrice = hallPriceList.Where(p => p.HallId == HallId).FirstOrDefault();
                if (hallPrice == null)
                {
                    hallPrice = new HallPrices();

                    var tmp = dataManager.GetFareSettingList.Where(p => p.FareSettingId == dataManager.FareSettingHallPriceId).FirstOrDefault();
                    hallPrice.DailyPlanId = this.dataManager.DailyShowPlan.DailyPlan.DailyPlanId;
                    hallPrice.HallId = HallId;
                    hallPrice.SinglePrice = tmp.SinglePrice;
                    hallPrice.DoublePrice = tmp.DoublePrice;
                    hallPrice.StudentPrice = tmp.StudentPrice;
                    hallPrice.GroupPrice = tmp.GroupPrice;
                    hallPrice.MemberPrice = tmp.MemberPrice;
                    hallPrice.BoxPrice = tmp.BoxPrice;
                }

                //绑定除下拉框以外的控件
                BindData();
            }
            catch { }
        }

        #endregion

        #region 窗体函数

        //填充ComboBox
        private void FillData()
        {
            var list = hallPriceSet.GetHall();

            cbHall.ValueMember = "HallId";

            cbHall.DisplayMember = "HallName";

            cbHall.DataSource = list;
        }

        // 绑定控件的值
        private void BindData()
        {
            txtSinglePrice.DataBindings.Add("Text", hallPrice, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtDoublePrice.DataBindings.Add("Text", hallPrice, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtStudentPrice.DataBindings.Add("Text", hallPrice, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtGroupPrice.DataBindings.Add("Text", hallPrice, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtBoxPrice.DataBindings.Add("Text", hallPrice, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtMemberPrice.DataBindings.Add("Text", hallPrice, "MemberPrice", true);
            txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

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
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;
using System.Data.Entity;

namespace Flamingo.ShowPlanManage
{
    public partial class frmTheterPriceSet : Form
    {
        #region 窗体变量

        private DailyShowPlanManage dataManager;

        private TheaterPrices theaterPrice;

        #endregion

        #region 启动处理

        public frmTheterPriceSet(DailyShowPlanManage dataManager)
        {
            InitializeComponent();

            this.dataManager = dataManager;
        }

        private void frmTheterPriceSet_Load(object sender, EventArgs e)
        {
            theaterPrice = dataManager.GetTheaterPrice();
            if (theaterPrice == null)
            {
                theaterPrice = new TheaterPrices();

                var tmp = dataManager.GetFareSettingList.Where(p => p.FareSettingId==dataManager.FareSettingTheaterPriceId).FirstOrDefault() ;
                this.theaterPrice.DailyPlanId = this.dataManager.DailyShowPlan.DailyPlan.DailyPlanId;
                this.theaterPrice.SinglePrice = tmp.SinglePrice;
                this.theaterPrice.DoublePrice = tmp.DoublePrice;
                this.theaterPrice.StudentPrice = tmp.StudentPrice;
                this.theaterPrice.GroupPrice = tmp.GroupPrice;
                this.theaterPrice.MemberPrice = tmp.MemberPrice;
                this.theaterPrice.BoxPrice = tmp.BoxPrice;
            }

            // 绑定控件数据
            BindData();
            SetPrice();
        }
        #endregion

        #region 窗体事件

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
        private void SetPrice()
        {
            try
            {
                txtSinglePrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.SinglePrice), 1).ToString("0.00");
                txtDoublePrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.DoublePrice), 1).ToString("0.00");
                txtStudentPrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.StudentPrice), 1).ToString("0.00");
                txtGroupPrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.GroupPrice), 1).ToString("0.00");
                txtMemberPrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.MemberPrice), 1).ToString("0.00");
                txtBoxPrice.Text = decimal.Round(Convert.ToDecimal(this.theaterPrice.BoxPrice), 1).ToString("0.00");
            }
            catch { }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //检查并设置票价
                dataManager.CheckTheaterPriceLowest(theaterPrice);

                MessageBox.Show("修改全场票价成功！", "信息提示");

                this.Hide();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region 窗体函数

        // 绑定控件的值
        private void BindData()
        {
            txtSinglePrice.DataBindings.Add("Text", theaterPrice, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtDoublePrice.DataBindings.Add("Text", theaterPrice, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtStudentPrice.DataBindings.Add("Text", theaterPrice, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtGroupPrice.DataBindings.Add("Text", theaterPrice, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtMemberPrice.DataBindings.Add("Text", theaterPrice, "MemberPrice", true);
            txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtBoxPrice.DataBindings.Add("Text", theaterPrice, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
        }

        #endregion
    }
}

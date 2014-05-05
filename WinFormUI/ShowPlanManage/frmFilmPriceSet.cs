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
    public partial class frmFilmPriceSet : Form
    {

        private DailyShowPlanManage dataManager;
        private List<FilmPrices> filmPriceList;
        private FilmPrices filmPrice;
        public frmFilmPriceSet(DailyShowPlanManage DataManager)
        {
            InitializeComponent();
            this.dataManager = DataManager;
        }

        private void frmFilmPriceSet_Load(object sender, EventArgs e)
        {
             filmPriceList = dataManager.GetFilmPriceList();
            FillData();
            SetPrice();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                dataManager.SetFilmPrice(filmPrice);

                this.Hide();
                DialogResult = DialogResult.OK;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetPrice()
        {
            try
            {
                txtSinglePrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.SinglePrice), 1).ToString("0.00");
                txtDoublePrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.DoublePrice), 1).ToString("0.00");
                txtStudentPrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.StudentPrice), 1).ToString("0.00");
                txtGroupPrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.GroupPrice), 1).ToString("0.00");
                txtMemberPrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.MemberPrice), 1).ToString("0.00");
                txtBoxPrice.Text = decimal.Round(Convert.ToDecimal(filmPrice.BoxPrice), 1).ToString("0.00");
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

        private void cbFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //取消下拉框以外控件的绑定
                UnBindData();

                //获取下拉框选择的值
                string filmId = cbFilmName.SelectedValue.ToString();

                //获取当前日期中下拉框选择的影厅对应的影厅票价的记录信息
                filmPrice = filmPriceList.Where(p =>p.FilmId == filmId).FirstOrDefault();
                if (filmPrice == null)
                {
                    var tmp=dataManager.GetFareSettingList.Where(p=>p.FareSettingId==dataManager.FareSettingFilmPriceId).FirstOrDefault();
                    filmPrice = new FilmPrices();
                    filmPrice.FilmId = filmId;
                    filmPrice.SinglePrice = tmp.SinglePrice;
                    filmPrice.DoublePrice = tmp.DoublePrice;
                    filmPrice.StudentPrice = tmp.StudentPrice;
                    filmPrice.GroupPrice = tmp.GroupPrice;
                    filmPrice.MemberPrice = tmp.MemberPrice;
                    filmPrice.BoxPrice = tmp.BoxPrice;
                    filmPriceList.Add(filmPrice);
                }
                //绑定除下拉框以外的控件
                BindData();
            }
            catch { }
        }

        //填充ComboBox
        private void FillData()
        {
            var list = dataManager.Filmlist;

            cbFilmName.ValueMember = "FilmId";

            cbFilmName.DisplayMember = "FilmName";

            cbFilmName.DataSource = list;
        }

        // 绑定控件的值
        private void BindData()
        {
            txtSinglePrice.DataBindings.Add("Text", filmPrice, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtDoublePrice.DataBindings.Add("Text", filmPrice, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtStudentPrice.DataBindings.Add("Text", filmPrice, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtGroupPrice.DataBindings.Add("Text", filmPrice, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtBoxPrice.DataBindings.Add("Text", filmPrice, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;

            txtMemberPrice.DataBindings.Add("Text", filmPrice, "MemberPrice", true);
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




    }
}

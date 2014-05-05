using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;
using System.Data.Objects;

namespace Flamingo.ShowPlanManage
{
    public partial class frmPeriodPriceSet : Form
    {
        #region 窗体变量

        private BindingSource bsList = new BindingSource();

        private DailyShowPlanManage dataManager;

        private List<PeriodPrices> periodPriceList;

        #endregion

        #region 启动处理
        public frmPeriodPriceSet(DailyShowPlanManage dataManager)
        {
            InitializeComponent();

            this.dataManager = dataManager;

            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            dgvList.DataError += new DataGridViewDataErrorEventHandler(dgvList_DataError);
            dgvList.CellParsing += new DataGridViewCellParsingEventHandler(dgvList_CellParsing);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            dgvList.CellEndEdit += new DataGridViewCellEventHandler(dgvList_CellEndEdit);
        }


        private void frmPeriodPriceSet_Load(object sender, EventArgs e)
        {
            periodPriceList = dataManager.GetPeriodPriceList();

            bsList.DataSource = periodPriceList;

            //重新绑定dgvList数据
            BindList();
        }

        #endregion

        #region 窗体事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.periodPriceList = bsList.DataSource as List<PeriodPrices>;

                dataManager.SetPeriodPrice(this.periodPriceList);

                this.Hide();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //删除时段票价
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvList.Rows.Remove(dgvList.CurrentRow);
            }
            catch
            {
                MessageBox.Show("请选择要删除的行！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 点击数据明细表单元格时，立刻进入编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.CurrentCell != null && e.ColumnIndex != -1)
                    dgv.BeginEdit(true);
            }
            catch { }
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    if (dgvList[e.ColumnIndex, e.RowIndex].Value.ToString().Contains(".") == true)
                    {
                        dgvList[e.ColumnIndex, e.RowIndex].Value = dgvList[e.ColumnIndex, e.RowIndex].Value.ToString().Split('.')[0] + ":00";
                    }
            }
            catch { }
        }

        /// <summary>
        /// 数据明细表中输入值验证发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string ss = dgvList[e.ColumnIndex, e.RowIndex].Value.ToString();

            this.dgvList.CancelEdit();
            MessageBox.Show("输入数据格式不正确！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 数据明细表数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;

            if (columnName.EndsWith("Price"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 1).ToString("0.00");
                    e.FormattingApplied = true;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 数据明细表的数据填充处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.Value == null)
                return;

            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;

            if (columnName == "StartTime")
            {
                SetPrice();
            }
            if (columnName.EndsWith("Price"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 1).ToString("0.00");
                    e.ParsingApplied = true;
                }
                catch
                {
                }
            }
        }

        #endregion

        #region 窗体函数

        public List<PeriodPrices> GetPeriodPricesList()
        {
            this.periodPriceList = bsList.DataSource as List<PeriodPrices>;
            while (this.periodPriceList.Remove(this.periodPriceList.Where(p => p.PeriodPriceId == 0).FirstOrDefault())) ;
            return this.periodPriceList;
        }
        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected void FormatDataList()
        {

            dgvList.AutoGenerateColumns = false;
            dgvList.Columns["PeriodPriceId"].Visible = false;
            dgvList.Columns["DailyPlanId"].Visible = false;
            dgvList.Columns["GroupPrice"].Visible = false;
            dgvList.Columns["DiscountPrice"].Visible = false;
            
            dgvList.Columns["StartTime"].HeaderText = "开始时间";
            dgvList.Columns["EndTime"].HeaderText = "结束时间";
            dgvList.Columns["SinglePrice"].HeaderText = "单人零售票价";
            dgvList.Columns["DoublePrice"].HeaderText = "双座零售票价";
            dgvList.Columns["StudentPrice"].HeaderText = "学生票价";
            dgvList.Columns["GroupPrice"].HeaderText = "团体票价";
            dgvList.Columns["BoxPrice"].HeaderText = "包厢票价";
            dgvList.Columns["MemberPrice"].HeaderText = "会员定价";

            dgvList.Columns["PeriodPriceId"].DisplayIndex = 0;
            dgvList.Columns["DailyPlanId"].DisplayIndex = 1;
            dgvList.Columns["StartTime"].DisplayIndex = 2;
            dgvList.Columns["EndTime"].DisplayIndex = 3;
            dgvList.Columns["SinglePrice"].DisplayIndex = 4;
            dgvList.Columns["DoublePrice"].DisplayIndex = 5;
            dgvList.Columns["StudentPrice"].DisplayIndex = 6;
            dgvList.Columns["GroupPrice"].DisplayIndex = 7;
            dgvList.Columns["BoxPrice"].DisplayIndex = 8;
            dgvList.Columns["MemberPrice"].DisplayIndex = 9;
        }

        /// <summary>
        /// 设置默认票价
        /// </summary>
        private void SetPrice()
        {
            var tmp = dataManager.GetFareSettingList.Where(p => p.FareSettingId == dataManager.FareSettingPeriodPriceId).FirstOrDefault();


            this.dgvList.CurrentRow.Cells["SinglePrice"].Value = tmp.SinglePrice;
            this.dgvList.CurrentRow.Cells["DoublePrice"].Value = tmp.DoublePrice;
            this.dgvList.CurrentRow.Cells["StudentPrice"].Value = tmp.StudentPrice;
            this.dgvList.CurrentRow.Cells["GroupPrice"].Value = tmp.GroupPrice;
            this.dgvList.CurrentRow.Cells["MemberPrice"].Value = tmp.MemberPrice;
            this.dgvList.CurrentRow.Cells["BoxPrice"].Value = tmp.BoxPrice;
        }

        //绑定dgvList的数据
        private void BindList()
        {
            dgvList.DataSource = null;
            dgvList.DataSource = bsList;
            FormatDataList();
        }

        #endregion
    }
}

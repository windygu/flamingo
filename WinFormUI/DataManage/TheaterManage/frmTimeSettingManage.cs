using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmTimeSettingManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量
        private TimeSettingManage dataManager;
        List<TimeSetting> list = new List<TimeSetting>();

        #endregion

        #region 启动处理
        public frmTimeSettingManage()
        {
            InitializeComponent();



            dataManager = new TimeSettingManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            this.Load += new EventHandler(frmTimeSettingManage_Load);
            this.dgvList.Visible = false;
        }

        private void frmTimeSettingManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            BindData();
            FillList();
            txtRepeatDay.Select();
            // ReSetListLocate();
        }

        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtRepeatDay.Text == "")
            {
                MessageBox.Show("请输入重复时间!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtRepeatDay.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("Repeat", txtRepeatDay.Text.Trim());
            }
        }
        #endregion

        #region 窗体函数

        #region 继承父窗体函数

        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((TimeSetting)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        protected override void ApplyReadonlyConfig()
        {
            txtCloseTime.Enabled = false;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            try
            {
                this.dataManager.Save();

                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        #endregion

        #region 其它函数

        /// <summary>
        ///填充所有下拉框 
        /// </summary>
        private void FillList()
        {
            FillRefundDeadlineList();
            FillBookingReleaseTimeList();
            FillTicketDeadlineList();
            FillDailyCount();
            FillMonthCount();
        }
        /// <summary>
        /// 刷新所有数据
        /// </summary>
        private void RefreshDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSource.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dataBindingSource.DataSource = dataManager.GetDataList();
            bvNavigator.BindingSource = dataBindingSource;
            dgvList.DataSource = dataBindingSource;
            //
            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                FormatDataList();

            ReSetDataArea();
        }

        /// <summary>
        /// 填充退票截止时间
        /// </summary>
        private void FillRefundDeadlineList()
        {
            if (txtTimeId.Text == "")
                cbRefundDeadline.SelectedText = "开场前";
            else
            {
                list = dataBindingSource.DataSource as List<TimeSetting>;
                int id = list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).RefundDeadline;
                if (id > 0)
                {
                    cbRefundDeadline.SelectedText = "开场后";
                }
                else
                {
                    cbRefundDeadline.SelectedText = "开场前";
                }
            }
        }
        private void FillBookingReleaseTimeList()
        {
            if (txtTimeId.Text == "")
                cbBookingRelease.SelectedText = "开场前";
            else
            {
                list = dataBindingSource.DataSource as List<TimeSetting>;
                int id = list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).BookingReleaseTime;
                if (id > 0)
                {
                    cbBookingRelease.SelectedText = "开场后";
                }
                else
                {
                    cbBookingRelease.SelectedText = "开场前";
                }
            }
        }
        private void FillTicketDeadlineList()
        {
            if (txtTimeId.Text == "")
                cbTicketDeadline.SelectedText = "开场前";
            else
            {
                list = dataBindingSource.DataSource as List<TimeSetting>;
                int id = list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).TicketingDeadline;
                if (id > 0)
                {
                    cbTicketDeadline.SelectedText = "开场后";
                }
                else
                {
                    cbTicketDeadline.SelectedText = "开场前";
                }
            }
        }

        private void FillDailyCount()
        {
            if (txtTimeId.Text == "")
                cbDailyCount.SelectedItem = "从上月至本月";
            else
            {
                list = dataBindingSource.DataSource as List<TimeSetting>;
                int? id = list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).DailyCount;
                if (id > 0)
                {
                    cbDailyCount.SelectedItem = "从本月至下月";
                }
                else
                {
                    cbDailyCount.SelectedItem = "从上月至本月";
                }
            }
        }

        private void FillMonthCount()
        {
            if (txtTimeId.Text == "")
                cbMonthCount.SelectedItem = "从去年至今年";
            else
            {
                list = dataBindingSource.DataSource as List<TimeSetting>;
                int? id = list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).MonthlyCount;
                if (id > 0)
                {
                    cbMonthCount.SelectedItem = "从今年至明年";
                }
                else
                {
                    cbMonthCount.SelectedItem = "从去年至今年";
                }
            }
        }
        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtTimeId.DataBindings.Clear();
            txtOpenTime.DataBindings.Clear();
            txtCloseTime.DataBindings.Clear();
            cbStartDate.DataBindings.Clear();
            cbStartMonth.DataBindings.Clear();
            cbMonthCount.DataBindings.Clear();
            cbDailyCount.DataBindings.Clear();

            txtTimeId.DataBindings.Add("Text", dataBindingSource, "TimeSettingId", true);
            txtCloseTime.DataBindings.Add("Text", dataBindingSource, "CloseTime", true);
            txtOpenTime.DataBindings.Add("Text", dataBindingSource, "OpenTime", true);
            cbStartMonth.DataBindings.Add("Text", dataBindingSource, "StartMonth", true);
            cbStartDate.DataBindings.Add("Text", dataBindingSource, "StartDate", true);
            cbMonthCount.DataBindings.Add("Text", dataBindingSource, "MonthlyCount", true);
            cbDailyCount.DataBindings.Add("Text", dataBindingSource, "DailyCount", true);
        }

        #endregion

        private void txtOpenTime_Validating(object sender, CancelEventArgs e)
        {
            if (txtOpenTime.Text != "" || txtOpenTime.Text != string.Empty)
            {
                string s1 = @"^((([0-1][0-9])|(2[0-3])):[0-5]\d:[0-5]\d)$";
                if (Regex.IsMatch(txtOpenTime.Text, s1))
                {
                    DateTime dt = Convert.ToDateTime(txtOpenTime.Text);
                    TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second-1);
                    TimeSpan openTime = new TimeSpan(dt.Hour, dt.Minute,dt.Second);
                    list = dataBindingSource.DataSource as List<TimeSetting>;
                    list.Find(p => p.TimeSettingId == Convert.ToInt32(txtTimeId.Text.Trim())).CloseTime = ts;
                    list.Find(p => p.TimeSettingId == Convert.ToInt32(txtTimeId.Text.Trim())).OpenTime = openTime;
                }
                else
                {
                    MessageBox.Show("请输入正确的时间格式:小时+分钟+秒！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOpenTime.Select();
                    return;
                }
            }
        }

        #endregion

        private void txtOpenTime_TextChanged(object sender, EventArgs e)
        {
            //if (txtOpenTime.Text != "" || txtOpenTime.Text != string.Empty)
            //{
            //    DateTime dt = Convert.ToDateTime(txtOpenTime.Text);
            //    TimeSpan ts = new TimeSpan(dt.Hour, 0, -1);
            //    txtCloseTime.Text = ts.ToString();
            //}
        }

        private void cbRefundDeadline_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = dataBindingSource.DataSource as List<TimeSetting>;
            if (cbRefundDeadline.SelectedItem == "开场前")
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).RefundDeadline = -1;
            }
            else
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).RefundDeadline = 1;
            }
        }

        private void cbTicketDeadline_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = dataBindingSource.DataSource as List<TimeSetting>;
            if (cbTicketDeadline.SelectedItem == "开场前")
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).TicketingDeadline = -1;
            }
            else
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).TicketingDeadline = 1;
            }
        }

        private void cbBookingRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = dataBindingSource.DataSource as List<TimeSetting>;
            if (cbBookingRelease.SelectedItem == "开场前")
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).BookingReleaseTime = -1;
            }
            else
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).BookingReleaseTime = 1;
            }
        }
        //更新月统计设定
        private void cbMonthCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = dataBindingSource.DataSource as List<TimeSetting>;
            if (cbMonthCount.SelectedItem == "从去年至今年")
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).MonthlyCount = -1;
            }
            else
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).MonthlyCount = 1;
            }
        }
        //更新日统计设定
        private void cbDailyCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = dataBindingSource.DataSource as List<TimeSetting>;
            if (cbDailyCount.SelectedItem == "从上月至本月")
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).DailyCount = -1;
            }
            else
            {
                list.Find(p => p.TimeSettingId == Convert.ToInt32((txtTimeId.Text.Trim()))).DailyCount = 1;
            }
        }
    }
}

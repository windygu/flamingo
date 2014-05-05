using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TicketManage
{
    //2011/12/22,Qiu
    public partial class frmVoucherManage : Flamingo.BaseForm.frmManageBase
    {

        #region 窗体变量

        private VoucherManage dataManager;

        #endregion


        #region    启动处理
        public frmVoucherManage()
        {
            InitializeComponent();

            dataManager = new VoucherManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            this.Load += new EventHandler(frmVoucherManage_Load);
        }

        private void frmVoucherManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();

            BindData();

            FillList();

            txtKeyWord.Select();
            // ReSetListLocate();
        }

        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetSearchList("Price", txtKeyWord.Text.Trim());
        }

        /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name.Contains("Price"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                    e.Value = decimal.Round(Convert.ToDecimal(0), 2).ToString("0.00") + "元";
                }
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

                txtVoucherId.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData() { }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Voucher)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
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

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                FormatDataList();

            ReSetDataArea();
        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtVoucherId.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtBarCode.DataBindings.Clear();

            cbTicketId.DataBindings.Clear();
            cbVoucherBatchId.DataBindings.Clear();


            txtVoucherId.DataBindings.Add("Text", dataBindingSource, "VoucherId", true);
            txtPrice.DataBindings.Add("Text", dataBindingSource, "Price", true);
            txtBarCode.DataBindings.Add("Text", dataBindingSource, "BarCode", true);

            // cbTemplateId.DataBindings.Add("SelectedValue", dataBindingSource, "TemplateId", true);
            cbTicketId.DataBindings.Add("SelectedValue", dataBindingSource, "VoucherBatchId", true);
            cbVoucherBatchId.DataBindings.Add("SelectedValue", dataBindingSource, "VoucherBatchId", true);

        }

        /// <summary>
        /// 填充所有 ComboBox 控件数据
        /// </summary>
        private void FillList()
        {
            //FillTemplateIdByList();
            FillVoucherBatchByList();
            FillVoucherByList();

        }

        /// <summary>
        /// 填充下拉框：经手人
        ///// </summary>
        //private void FillTemplateIdByList()
        //{
        //    cbTemplateId.DisplayMember = "UserName";
        //    cbTemplateId.ValueMember = "UserId";

        //    cbTemplateId.DataSource = VoucherManage.DirectGetTemplate();
        //}

        /// <summary>
        /// 填充下拉框：票版
        /// </summary>
        private void FillVoucherBatchByList()
        {
            cbTicketId.DisplayMember = "TicketName";
            cbTicketId.ValueMember = "TicketId";

            cbTicketId.DataSource = VoucherManage.DirectGetTicket();
        }


        /// <summary>
        /// 填充下拉框：票券类型
        /// </summary>
        private void FillVoucherByList()
        {
            cbVoucherBatchId.DisplayMember = "VoucherName";
            cbVoucherBatchId.ValueMember = "VoucherBatchId";

            cbVoucherBatchId.DataSource = VoucherManage.DirectGetVoucherBatch();
        }
        #endregion

        #endregion
    }
}

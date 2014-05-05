using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RCLibrary;

namespace Flamingo.TicketManage
{
    //2011,12,24,Qiu
    public partial class frmBestowCircsStatManage : Form
    {
        BestowCircsStatManage dataManage;
        List<DataGridViewColumnInfo> dataGridViewColumnInfo;

        public frmBestowCircsStatManage()
        {
            InitializeComponent();
            dataManage = new BestowCircsStatManage();
            dateTimeTo.Value = DateTime.Now;
            dateTimeFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dataGridViewColumnInfo = dataManage.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            FillVoucherTypeByList();
            FormatDataList();
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cbVoucherTypeId.SelectedValue.ToString() == "10000"||cbVoucherTypeId.SelectedValue==null)
            {
                dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value);
            }
            else
            {
                dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value, Convert.ToInt32(cbVoucherTypeId.SelectedValue));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //格式化明细表
        private void FormatDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dgvList.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value, Convert.ToInt32(cbVoucherTypeId.SelectedValue));

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                if (this.dataGridViewColumnInfo != null && dgvList != null && dgvList.DataSource != null)
                    dgvList.FormatColumns(this.dataGridViewColumnInfo);
        }

        /// <summary>
        /// 填充下拉框：票券类型
        /// </summary>
        private void FillVoucherTypeByList()
        {
            List<VoucherType> voucherTypeList = new List<VoucherType>();
            cbVoucherTypeId.DisplayMember = "VoucherTypeName";
            cbVoucherTypeId.ValueMember = "VoucherTypeId";

            voucherTypeList = VoucherBatchManage.DirectGetVoucherType();
            if (voucherTypeList != null || voucherTypeList.Count <= 0)
            {
                VoucherType vt = new VoucherType();
                vt.VoucherTypeName = "全部";
                vt.VoucherTypeId = 10000;
                voucherTypeList.Add(vt);
            }
            cbVoucherTypeId.DataSource = voucherTypeList;
        }

        public void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "Price" || dgvList.Columns[e.ColumnIndex].Name == "jine")
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "DeposeSum" || dgvList.Columns[e.ColumnIndex].Name == "NotChange" || dgvList.Columns[e.ColumnIndex].Name == "AlreadyChange" || dgvList.Columns[e.ColumnIndex].Name == "Quantity")
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value)).ToString() + "张";
                }
                catch
                {
                }
            }
        }
    }
}

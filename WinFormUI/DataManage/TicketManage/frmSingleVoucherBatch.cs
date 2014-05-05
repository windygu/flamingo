using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TicketManage
{
    //2011.12.24 LIN
    public partial class frmSingleVoucherBatch : Form
    {
        SingleVoucherBatch dataManage;
        public frmSingleVoucherBatch()
        {
            InitializeComponent();
            dataManage = new SingleVoucherBatch();
            FillcbVoucherId();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbVoucherId.SelectedValue == null)
            {
                MessageBox.Show("没有可查询的批次号!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvList.DataSource = dataManage.dgvSearch(cbVoucherId.SelectedValue.ToString());
                FormatDataList();
                dgvList.CellFormatting+=new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            }
        }

        //格式化明细表
        private void FormatDataList()
        {
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns["VocherTypeNo"].HeaderText = "批次号";            
            dgvList.Columns["CustomerName"].HeaderText = "购卷单位";
            dgvList.Columns["Price"].HeaderText = "单价";
            dgvList.Columns["Quantity"].HeaderText = "数量";
            dgvList.Columns["Amount"].HeaderText = "金额";
            dgvList.Columns["ExpireDate"].HeaderText = "截止时间";
            dgvList.Columns["VoucherNotQuantity"].HeaderText = "未兑数量";
            dgvList.Columns["VoucherQuantity"].HeaderText = "已兑数量";
            dgvList.Columns["PassVoucher"].HeaderText = "废卷数量";

            dgvList.Columns["VocherTypeNo"].DisplayIndex = 0;
            dgvList.Columns["CustomerName"].DisplayIndex = 1;
            dgvList.Columns["Price"].DisplayIndex = 2;
            dgvList.Columns["Quantity"].DisplayIndex = 3;
            dgvList.Columns["Amount"].DisplayIndex = 8;
            dgvList.Columns["VoucherQuantity"].DisplayIndex = 4;
            dgvList.Columns["ExpireDate"].DisplayIndex = 5;
            dgvList.Columns["VoucherNotQuantity"].DisplayIndex = 6;
            dgvList.Columns["PassVoucher"].DisplayIndex = 7;
            

            dgvList.Columns["VocherTypeNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "Price" || dgvList.Columns[e.ColumnIndex].Name == "Amount")
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "VoucherQuantity" || dgvList.Columns[e.ColumnIndex].Name == "VoucherNotQuantity" || dgvList.Columns[e.ColumnIndex].Name == "PassVoucher" || dgvList.Columns[e.ColumnIndex].Name == "Quantity")
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

        /// <summary>
        /// 填充下拉框cbVoucherId
        /// </summary>
        public void FillcbVoucherId()
        {
            cbVoucherId.DisplayMember = "VoucherBatchId";
            cbVoucherId.ValueMember = "VoucherBatchId";
            cbVoucherId.DataSource = dataManage.GetVoucherId();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

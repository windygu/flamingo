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
    public partial class frmChangeManage : Form
    {
        ChangMange dataManage;
        public frmChangeManage()
        {
            InitializeComponent();
            dataManage = new ChangMange();

            FillIssuedByList();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cbIssuedBy.SelectedValue != null)
            {
                dgvList.DataSource = dataManage.dgvSearch(Convert.ToInt32(cbIssuedBy.SelectedValue));
                FormatDataList();
                dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            }
            else
            {
                MessageBox.Show("没有您要查询的数据!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //格式化明细表
        private void FormatDataList()
        {
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns["VocherTypeNo"].HeaderText = "批次号";
            dgvList.Columns["Price"].HeaderText = "单价";
            dgvList.Columns["Quantity"].HeaderText = "数量";
            dgvList.Columns["CustomerName"].HeaderText = "购卷单位";
            dgvList.Columns["Alreadychange"].HeaderText = "已兑数量";

            dgvList.Columns["ReleaseDate"].HeaderText = "截止时间";
            dgvList.Columns["Notchange"].HeaderText = "未兑数量";
            dgvList.Columns["DeposeSum"].HeaderText = "废券数量";
            dgvList.Columns["jine"].HeaderText = "余额";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 填充下拉框：经手人
        /// </summary>
        private void FillIssuedByList()
        {
            cbIssuedBy.DisplayMember = "UserName";
            cbIssuedBy.ValueMember = "UserId";

            cbIssuedBy.DataSource = VoucherBatchManage.DirectGetIssued();
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
            if (dgvList.Columns[e.ColumnIndex].Name == "DeposeSum" || dgvList.Columns[e.ColumnIndex].Name == "Notchange" || dgvList.Columns[e.ColumnIndex].Name == "Alreadychange" || dgvList.Columns[e.ColumnIndex].Name == "Quantity")
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

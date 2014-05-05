using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI.SaleTicket
{
    public partial class frmVoucherSubstitute : Form
    {
        public frmVoucherSubstitute()
        {
            InitializeComponent();
        }

        private void frmVoucherSubstitute_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            DataTable dt = Flamingo.BLL.Voucher.GetVoucherSubstituteVoucherName();
            combVoucherName1.DataSource = dt;
            combVoucherName1.ValueMember = "VoucherBatchId";
            combVoucherName1.DisplayMember = "VoucherName";
            combVoucherName2.DataSource = dt;
            combVoucherName2.ValueMember = "VoucherBatchId";
            combVoucherName2.DisplayMember = "VoucherName";
            combVoucherName3.DataSource = dt;
            combVoucherName3.ValueMember = "VoucherBatchId";
            combVoucherName3.DisplayMember = "VoucherName";
            combVoucherName4.DataSource = dt;
            combVoucherName4.ValueMember = "VoucherBatchId";
            combVoucherName4.DisplayMember = "VoucherName";
            combVoucherName5.DataSource = dt;
            combVoucherName5.ValueMember = "VoucherBatchId";
            combVoucherName5.DisplayMember = "VoucherName";
            combVoucherName6.DataSource = dt;
            combVoucherName6.ValueMember = "VoucherBatchId";
            combVoucherName6.DisplayMember = "VoucherName";
            combVoucherName7.DataSource = dt;
            combVoucherName7.ValueMember = "VoucherBatchId";
            combVoucherName7.DisplayMember = "VoucherName";
            combVoucherName8.DataSource = dt;
            combVoucherName8.ValueMember = "VoucherBatchId";
            combVoucherName8.DisplayMember = "VoucherName";
            combVoucherName9.DataSource = dt;
            combVoucherName9.ValueMember = "VoucherBatchId";
            combVoucherName9.DisplayMember = "VoucherName";
            combVoucherName10.DataSource = dt;
            combVoucherName10.ValueMember = "VoucherBatchId";
            combVoucherName10.DisplayMember = "VoucherName";
        }
    }
}

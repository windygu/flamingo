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
    public partial class frmCustomer : Form
    {

        public frmCustomer()
        {
            InitializeComponent();
        }

        private TextBox _txtTelephone;
        private TextBox _txtContact;
        private TextBox _txtBankBranch;
        private TextBox _txtCustomerName;
        private Label _lblCustomerId;
        private ComboBox _combCustomerType;
        public frmCustomer(string customername, TextBox txtTelephone, TextBox txtContact, TextBox txtBankBranch, TextBox txtCustomerName, Label lblCustomerId, ComboBox combCustomerType)
        {
            InitializeComponent();

            txtCustomerName.Text = customername;
            SelCustomer();
            _txtTelephone = txtTelephone;
            _txtContact = txtContact;
            _txtBankBranch = txtBankBranch;
            _txtCustomerName = txtCustomerName;
            _lblCustomerId = lblCustomerId;
            _combCustomerType = combCustomerType;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _lblCustomerId.Text = "";
            this.Close();
        }

        DataTable dt;
        private void btnSel_Click(object sender, EventArgs e)
        {
            SelCustomer();
        }

        private void SelCustomer()
        {
            dt = Flamingo.BLL.Customer.GetCustomer(txtCustomerName.Text.Trim());
            dgvCustomer.DataSource = dt;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            dgvCustomer.AutoGenerateColumns = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                DataGridViewRow dgvr = dgvCustomer.SelectedRows[0];
                _txtCustomerName.Text = dgvr.Cells["CustomerName"].Value.ToString().Trim();
                _txtContact.Text = dgvr.Cells["Contact"].Value.ToString().Trim();
                _txtTelephone.Text = dgvr.Cells["Telephone"].Value.ToString().Trim();
                _txtBankBranch.Text = dgvr.Cells["BankBranch"].Value.ToString().Trim();

                _lblCustomerId.Text = dgvr.Cells["CustomerId"].Value.ToString().Trim();
                _combCustomerType.SelectedValue = dgvr.Cells["CustomerTypeId"].Value.ToString().Trim();

                _txtCustomerName.ReadOnly = true;
                _combCustomerType.Enabled = false;
                // _txtContact.ReadOnly = true;
                // _txtTelephone.ReadOnly = true;
                //_txtBankBranch.ReadOnly = true;
            }
            else
            {
                _lblCustomerId.Text = "";
            }
            this.Close();
        }
    }
}

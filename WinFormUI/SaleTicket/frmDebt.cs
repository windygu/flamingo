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
    public partial class frmDebt : Form
    {
        #region 场次信息
        private string _showPlanDate;
        /// <summary>
        /// 场次日期
        /// </summary>
        public string ShowPlanDate
        {
            set { _showPlanDate = value; }
            get { return _showPlanDate; }
        }

        private string _hallName;
        /// <summary>
        /// 影厅名称
        /// </summary>
        public string HallName
        {
            get { return _hallName; }
            set { _hallName = value; }
        }

        private string _startTime;
        /// <summary>
        /// 场次(开始时间)
        /// </summary>
        public string StartTime
        {
            set { _startTime = value; }
            get { return _startTime; }
        }

        private string _filmName;
        /// <summary>
        /// 影票名称
        /// </summary>
        public string FilmName
        {
            get { return _filmName; }
            set { _filmName = value; }
        }

        private string _showplanid;
        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowPlanId
        {
            get { return _showplanid; }
            set { _showplanid = value; }
        }

        #endregion

        #region 影票信息
        private string _ticketType;
        /// <summary>
        /// 票种
        /// </summary>
        public string TicketType
        {
            set { _ticketType = value; }
            get { return _ticketType; }
        }

        private int _ticketCount;
        /// <summary>
        /// 张数
        /// </summary>
        public int TicketCount
        {
            set { _ticketCount = value; }
            get { return _ticketCount; }
        }

        private float _price;
        /// <summary>
        /// 单价
        /// </summary>
        public float Price
        {
            set { _price = value; }
            get { return _price; }
        }

        private float _total;
        /// <summary>
        /// 总金额
        /// </summary>
        public float Total
        {
            set { _total = value; }
            get { return _total; }
        }
        #endregion

        #region 预定出票用参数
        private bool _IsOut;
        /// <summary>
        /// 是否是预定出票(如果是预定出票则隐藏[设置团体价]功能)
        /// </summary>
        public bool IsOut
        {
            set { _IsOut = value; }
            get { return _IsOut; }
        }
        private string _DeptId;
        /// <summary>
        /// 添加成功后的支票ID
        /// </summary>
        public string DebtId
        {
            get { return _DeptId; }
        }
        #endregion

        public frmDebt()
        {
            InitializeComponent();
        }
        private Label _lbl;
        public frmDebt(Label lbl)
        {
            InitializeComponent();
            _lbl = lbl;
        }

        private void frmDebt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            lblTicketInfo.Text = string.Format("票种:{0} 张数:{1} 单价:{2}元 总金额:{3}元", TicketType, TicketCount, Price, Total);
            lblShowPlanInfo.Text = string.Format("日期:{0} {1} 场次:{2} 影片:{3}", ShowPlanDate, HallName, StartTime, FilmName);
            lblGroupPrice.Text = Price.ToString("0.00") + "元";

            dt = new DataTable();
            dt.Columns.Add("CustomerId");
            dt.Columns.Add("日期");
            dt.Columns.Add("单位名称");
            dt.Columns.Add("联系人");
            dt.Columns.Add("购票张数");
            dt.Columns.Add("金额");
            dt.Columns.Add("开户银行");
            dt.Columns.Add("支票号");
            dt.Columns.Add("联系电话");
            dt.Columns.Add("收款员");

            dgvDebtList.AutoGenerateColumns = false;

            DataTable dtCustomerType = Flamingo.BLL.Customer.GetCustomerType();

            combCustomerType.DataSource = dtCustomerType.DefaultView;
            combCustomerType.DisplayMember = "CustomerTypename";
            combCustomerType.ValueMember = "CustomerTypeId";
            //cbDirection.DisplayMember = "Name";
            //cbDirection.ValueMember = "Type"; 

            if (_IsOut == true)
                btnSetGroupPrice.Visible = false;

        }

        private void btnSetGroupPrice_Click(object sender, EventArgs e)
        {
            SaleTicket.frmGroup frm = new SaleTicket.frmGroup(_showplanid);
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                Price = frm.Price;
                if (Price > 0)
                {
                    float current_total = TicketCount * Price;
                    Total = current_total;
                    lblTicketInfo.Text = string.Format("票种:{0} 张数:{1} 单价:{2}元 总金额:{3}元", TicketType, TicketCount, Price, current_total.ToString("0.00"));
                    lblGroupPrice.Text = _price.ToString("0.00") + "元";
                    if (_lbl != null)
                    {
                        _lbl.Text = string.Format(_lbl.Text.Substring(0, _lbl.Text.IndexOf("总金额：")) +
                            "总金额：{0}" + _lbl.Text.Substring(_lbl.Text.IndexOf("元")),
                             current_total.ToString("0.00"));
                    }
                }
            }
        }

        private DataTable dt;

        bool isAllowNext = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
            {
                MessageBox.Show("请填写客户名称");
            }
            else if (string.IsNullOrEmpty(txtBankBranch.Text.Trim()))
            {
                MessageBox.Show("请填写开户银行");
            }
            else if (string.IsNullOrEmpty(txtChequeNumber.Text.Trim()))
            {
                MessageBox.Show("请填写支票号");
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    DialogResult dialogR = MessageBox.Show("已存在一张支票,确定覆盖吗?", "提示", MessageBoxButtons.YesNo);
                    if (dialogR == DialogResult.Yes)
                    {
                        dt.Rows.Clear();
                        DataRow dr = dt.NewRow();
                        dr["CustomerId"] = lblCustomerId.Text;
                        dr["日期"] = ShowPlanDate;
                        dr["单位名称"] = txtCustomerName.Text.Trim();
                        dr["联系人"] = txtContact.Text.Trim();
                        dr["购票张数"] = TicketCount.ToString();
                        dr["金额"] = (TicketCount * Price).ToString();
                        dr["开户银行"] = txtBankBranch.Text.Trim();
                        dr["支票号"] = txtChequeNumber.Text.Trim();
                        dr["联系电话"] = txtTelephone.Text.Trim();
                        dr["收款员"] = FrmMain.curUser.UserId; //user lzz
                        dt.Rows.Add(dr);
                        dgvDebtList.DataSource = dt;
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerId"] = lblCustomerId.Text;
                    dr["日期"] = ShowPlanDate;
                    dr["单位名称"] = txtCustomerName.Text.Trim();
                    dr["联系人"] = txtContact.Text.Trim();
                    dr["购票张数"] = TicketCount.ToString();
                    dr["金额"] = (TicketCount * Price).ToString();
                    dr["开户银行"] = txtBankBranch.Text.Trim();
                    dr["支票号"] = txtChequeNumber.Text.Trim();
                    dr["联系电话"] = txtTelephone.Text.Trim();
                    dr["收款员"] = FrmMain.curUser.UserId; //user
                    dt.Rows.Add(dr);
                    dgvDebtList.DataSource = dt;
                }
                isAllowNext = true;
            }
        }

        private void btnSelCustomer_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            SaleTicket.frmCustomer frm = new frmCustomer(txtCustomerName.Text.Trim(), txtTelephone, txtContact, txtBankBranch, txtCustomerName, lblCustomerId, combCustomerType);
            frm.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtContact.Text = "";
            txtTelephone.Text = "";
            txtBankBranch.Text = "";
            lblCustomerId.Text = "";
            txtChequeNumber.Text = "";

            txtCustomerName.ReadOnly = false;
            combCustomerType.Enabled = true;

            isAllowNext = false;

            //txtContact.ReadOnly = false;
            //txtTelephone.ReadOnly = false;
            //txtBankBranch.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (isAllowNext == true)
            {
                Flamingo.Entity.Customer customer = new Flamingo.Entity.Customer();
                customer.CustomerId = lblCustomerId.Text == "" ? -1 : Int32.Parse(lblCustomerId.Text);
                customer.CustomerTypeId = (Int32)combCustomerType.SelectedValue;
                customer.BankBranch = txtBankBranch.Text.Trim();
                customer.CustomerName = txtCustomerName.Text.Trim();
                customer.Telephone = txtTelephone.Text.Trim();
                customer.Contact = txtContact.Text.Trim();

                Flamingo.Entity.Debt debt = new Flamingo.Entity.Debt();
                debt.Buyer = txtContact.Text.Trim();
                debt.Tickets = TicketCount;
                debt.Amount = Total;
                debt.ChequeNumber = txtChequeNumber.Text.Trim();
                debt.Casher = FrmMain.curUser.UserId;//user lzz

                bool tf = Flamingo.BLL.Ticket.AddCheque(customer, debt, out _DeptId);
                if (tf == true)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加支票失败");
                }
            }
            else
            {
                MessageBox.Show("请添加支票信息");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WinFormUI.SaleTicket
{
    public partial class frmReservation : Form
    {
        private string _showPlanId;
        /// <summary>
        /// 场计划ID
        /// </summary>
        public string ShowPlanId
        {
            get { return _showPlanId; }
            set { _showPlanId = value; }
        }
        /// <summary>
        /// 场计划名称
        /// </summary>
        public string ShowPlanName
        {
            get { return lblShowPlanName.Text; }
            set { lblShowPlanName.Text = value; }
        }
        /// <summary>
        /// 计划日期
        /// </summary>
        public string ShowPlanDate
        {
            get { return lblShowPlanDate.Text; }
            set { lblShowPlanDate.Text = value; }
        }
        /// <summary>
        /// 影厅
        /// </summary>
        public string ShowPlanHall
        {
            get { return lblHallName.Text; }
            set { lblHallName.Text = value; }
        }
        /// <summary>
        /// 开场时间
        /// </summary>
        public string ShowPlanStartTime
        {
            get { return lblShowPlanTime.Text; }
            set { lblShowPlanTime.Text = value; }
        }

        private List<SeatMaDll.SeatStatusSim> _seatsList;
        /// <summary>
        /// 选中座位的集合
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatsList
        {
            set { _seatsList = value; }
            get { return _seatsList; }
        }

        private Hashtable _ticketPirce;
        /// <summary>
        /// 座位价格
        /// </summary>
        public Hashtable TicketPrice
        {
            set { _ticketPirce = value; }
            get { return _ticketPirce; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        private string TicketCount
        {
            get { return _seatsList.Count.ToString(); }
        }

        private Flamingo.BLL.Ticket.TicketType _ticketType;
        /// <summary>
        /// 票种
        /// </summary>
        public Flamingo.BLL.Ticket.TicketType TicketType
        {
            set { _ticketType = value; }
            get { return _ticketType; }
        }

        private bool _isShowGroup;
        /// <summary>
        /// 是否连场
        /// </summary>
        public bool IsShowGroup
        {
            get { return _isShowGroup; }
            set { _isShowGroup = value; }
        }

        private string _showGroupShowPlanIds;
        /// <summary>
        /// 连场IDs
        /// </summary>
        public string ShowGroupShowPlanIds
        {
            get { return _showGroupShowPlanIds; }
            set { _showGroupShowPlanIds = value; }
        }

        public frmReservation()
        {
            InitializeComponent();
        }

        private DataTable dt;
        private void frmReservation_Load(object sender, EventArgs e)
        {
            lblCount.Text = TicketCount;
            this.FormBorderStyle = FormBorderStyle.None;
            this.dgvTicketList.AutoGenerateColumns = false;
            this.txtName.Focus();
            dt = new DataTable();
            dt.Columns.Add("场次ID");   //构造预定表ID用 及查询用
            dt.Columns.Add("座位状态ID");
            dt.Columns.Add("票种");
            dt.Columns.Add("座位");
            dt.Columns.Add("价格");
            dt.Columns.Add("售票类型");
            BindList();
        }

        private StringBuilder sb_seatstatusids;
        private StringBuilder sb_tickettypes;
        private StringBuilder sb_seatnumbers;
        private StringBuilder sb_ticketprices;
        private StringBuilder sb_seatids;
        private Hashtable ht_prices;
        private void BindList()
        {
            sb_seatstatusids = new StringBuilder();
            sb_tickettypes = new StringBuilder();
            sb_seatnumbers = new StringBuilder();
            sb_ticketprices = new StringBuilder();
            sb_seatids = new StringBuilder();
            DataRow dr;
            foreach (SeatMaDll.SeatStatusSim sss in _seatsList)
            {
                dr = dt.NewRow();
                dr["场次ID"] = _showPlanId;
                dr["座位状态ID"] = _showPlanId + sss._seatId;
                dr["票种"] = _ticketType;
                dr["座位"] = sss._seatNumber;
                dr["价格"] = TicketPrice[sss._seatId];
                dt.Rows.Add(dr);

                sb_seatstatusids.Append(_showPlanId);
                sb_seatstatusids.Append(sss._seatId);
                sb_seatstatusids.Append("|");

                if (_ticketType == Flamingo.BLL.Ticket.TicketType.零售)
                {
                    if (sss._seatType == "0")//SeatMaDll.BHSeatControl.BHSeatType.One
                    {
                        sb_tickettypes.Append("1");
                        dr["售票类型"] = "1";
                    }
                    else if (sss._seatType == "1")
                    {
                        sb_tickettypes.Append("2");
                        dr["售票类型"] = "2";
                    }
                    else if (sss._seatType == "2")
                    {
                        sb_tickettypes.Append("3");
                        dr["售票类型"] = "3";
                    }
                }
                else
                {
                    sb_tickettypes.Append(Flamingo.BLL.Ticket.ToTicketType(_ticketType).ToString());
                    dr["售票类型"] = Flamingo.BLL.Ticket.ToTicketType(_ticketType).ToString();
                }
                sb_tickettypes.Append("|");

                sb_seatnumbers.Append(sss._seatNumber);
                sb_seatnumbers.Append("|");

                sb_ticketprices.Append(TicketPrice[sss._seatId]);
                sb_ticketprices.Append("|");

                sb_seatids.Append(sss._seatId);
                sb_seatids.Append("|");

            }
            if (sb_seatstatusids.Length > 0)
            {
                sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                sb_tickettypes.Remove(sb_tickettypes.Length - 1, 1);
                sb_seatnumbers.Remove(sb_seatnumbers.Length - 1, 1);
                sb_ticketprices.Remove(sb_ticketprices.Length - 1, 1);
                sb_seatids.Remove(sb_seatids.Length - 1, 1);
            }
            ht_prices = Flamingo.BLL.Ticket.GetPriceList(_showPlanId, sb_seatids.ToString());
            dgvTicketList.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请填写姓名");
            }
            else if (string.IsNullOrEmpty(txtPWD.Text.Trim()))
            {
                MessageBox.Show("请填写密码");
            }
            else if (string.IsNullOrEmpty(txtRPWD.Text.Trim()))
            {
                MessageBox.Show("请填写确认密码");
            }
            else if (txtPWD.Text.Trim() != txtRPWD.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致");
            }
            else if (string.IsNullOrEmpty(txtTelephone.Text.Trim()))
            {
                MessageBox.Show("请填写电话");
            }
            else if (string.IsNullOrEmpty(txtCardNum.Text.Trim()))
            {
                MessageBox.Show("请填写身份证号");
            }
            else
            {
                //重新组合 售票类型和票价
                sb_tickettypes.Clear();
                sb_ticketprices.Clear();
                foreach (DataGridViewRow row in dgvTicketList.Rows)
                {
                    if (row.Cells["票种"].Value.ToString() == "零售")
                        sb_tickettypes.Append(row.Cells["售票类型"].Value.ToString());
                    else if (row.Cells["票种"].Value.ToString() == "学生")
                        sb_tickettypes.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.学生).ToString());
                    else if (row.Cells["票种"].Value.ToString() == "团体")
                        sb_tickettypes.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体).ToString());
                    else if (row.Cells["票种"].Value.ToString() == "特价")
                        sb_tickettypes.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.特价).ToString());

                    sb_tickettypes.Append("|");
                    sb_ticketprices.Append(row.Cells["价格"].Value.ToString());
                    sb_ticketprices.Append("|");
                }
                sb_tickettypes.Remove(sb_tickettypes.Length - 1, 1);
                sb_ticketprices.Remove(sb_ticketprices.Length - 1, 1);

                Flamingo.Entity.Para_ReservationTicket pReservationTicket = new Flamingo.Entity.Para_ReservationTicket();
                pReservationTicket.Count = Int32.Parse(TicketCount);
                pReservationTicket.CustomerCode = txtPWD.Text.Trim();
                pReservationTicket.CustomerMobile = txtTelephone.Text.Trim();
                pReservationTicket.CustomerName = txtName.Text.Trim();
                pReservationTicket.Identity = txtCardNum.Text.Trim();
                pReservationTicket.IssuedBy = FrmMain.curUser.UserId; //user lzz
                pReservationTicket.SeatStatusIds = sb_seatstatusids.ToString();
                pReservationTicket.TicketTypes = sb_tickettypes.ToString();
                pReservationTicket.SeatNumbers = sb_seatnumbers.ToString();
                pReservationTicket.TicketPrices = sb_ticketprices.ToString();
                pReservationTicket.ShowPlanId = ShowPlanId;

                bool tf = Flamingo.BLL.Ticket.ReservationTicket(pReservationTicket);
                if (tf == true)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加预定信息失败");
                }
            }
        }

        private void dgvTicketList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string price = string.Empty;
                string type = dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (_isShowGroup)
                {
                    price = Flamingo.BLL.Ticket.GetPriceTotal(_showPlanId, dgvTicketList.Rows[e.RowIndex].Cells["座位状态ID"].Value.ToString().Substring(12),
                        type, out ht_prices, true, _showGroupShowPlanIds).ToString("0"); ;
                }
                else
                {
                    Flamingo.Entity.Para_SeatPrices model = (Flamingo.Entity.Para_SeatPrices)ht_prices[dgvTicketList.Rows[e.RowIndex].Cells["座位状态ID"].Value];

                    switch (type)
                    {
                        case "零售":
                            price = model.RetailPrice.ToString("0");
                            break;
                        case "学生":
                            price = model.StudentPrice.ToString("0");
                            break;
                        case "团体":
                            price = model.GroupPrice.ToString("0");
                            break;
                        case "会员":
                            price = model.MemberPrice.ToString("0");
                            break;
                    }
                }
                dgvTicketList.Rows[e.RowIndex].Cells["价格"].Value = price;

            }
        }

        private void dgvTicketList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                this.dgvTicketList.EndEdit();
            }
        }
    }
}

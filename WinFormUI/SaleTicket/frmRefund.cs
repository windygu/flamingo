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
    public partial class frmRefund : Form
    {
        private string showPlanId;
        /// <summary>
        /// 场计划ID
        /// </summary>
        public string ShowPlanId
        {
            get { return showPlanId; }
            set { showPlanId = value; }
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
            get { return lblShowPlanHall.Text; }
            set { lblShowPlanHall.Text = value; }
        }
        /// <summary>
        /// 开场时间
        /// </summary>
        public string ShowPlanStartTime
        {
            get { return lblShowPlanStartTime.Text; }
            set { lblShowPlanStartTime.Text = value; }
        }
        private List<SeatMaDll.SeatStatusSim> seatlist = new List<SeatMaDll.SeatStatusSim>();
        /// <summary>
        /// 座位ID集合
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatList
        {
            get { return seatlist; }
        }

        private bool isShowGroup;
        /// <summary>
        /// 是否是连场
        /// </summary>
        public bool IsShowGroup
        {
            set { isShowGroup = value; }
        }

        private string showGroupShowPlanIds;
        /// <summary>
        /// 连场场次ID集合 ,分割
        /// </summary>
        public string ShowGroupShowPlanIds
        {
            get { return showGroupShowPlanIds; }
            set { showGroupShowPlanIds = value; }
        }

        public frmRefund()
        {
            InitializeComponent();
            lblShowPlanDate.Text = ShowPlanDate;
            lblShowPlanHall.Text = ShowPlanHall;
            lblShowPlanName.Text = ShowPlanName;
            lblShowPlanStartTime.Text = ShowPlanStartTime;

            dt.Columns.Add("条形码");
            dt.Columns.Add("票类");
            dt.Columns.Add("座位");
            dt.Columns.Add("价格");
            dt.Columns.Add("TicketId");
            dt.Columns.Add("SeatStatusId");

            dtGroup.Columns.Add("条形码");
            dtGroup.Columns.Add("票类");
            dtGroup.Columns.Add("座位");
            dtGroup.Columns.Add("价格");
            dtGroup.Columns.Add("TicketId");
            dtGroup.Columns.Add("SeatStatusId");
            dtGroup.Columns.Add("SeatId");
            dgvTickets.AutoGenerateColumns = false;
            this.DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable dt = new DataTable();
        DataTable dtGroup = new DataTable();
        private void btnAddBarCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text.Trim()))
            {
                bool isExist = false;
                foreach (DataRow d in dt.Rows)
                {
                    if (d[0].ToString().Trim() == txtBarCode.Text.Trim())
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    #region 非连场
                    if (isShowGroup == false)
                    {
                        DataTable dtr = Flamingo.BLL.Ticket.GetTicket(this.txtBarCode.Text.Trim());
                        if (dtr.Rows.Count == 0)
                        {
                            MessageBox.Show("未查询到该票");
                        }
                        else if (dtr.Rows.Count == 1)
                        {
                            string ticket_showplanid = dtr.Rows[0]["SeatStatusId"].ToString().Substring(0, 12);
                            if (showPlanId == ticket_showplanid)
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = dtr.Rows[0]["BarCode"].ToString();
                                dr[1] = Flamingo.BLL.Ticket.ToTicketType(dtr.Rows[0]["TicketType"].ToString().Trim()).ToString();
                                //SeatType
                                switch (dtr.Rows[0]["SeatType"].ToString().Trim())
                                {
                                    #region
                                    case "0":
                                        dr[1] = dr[1].ToString() + "单座";
                                        break;
                                    case "1":
                                        dr[1] = dr[1].ToString() + "双座";
                                        break;
                                    case "2":
                                        dr[1] = dr[1].ToString() + "包厢";
                                        break;
                                    case "3":
                                        dr[1] = dr[1].ToString() + "残障";
                                        break;
                                    case "4":
                                        dr[1] = dr[1].ToString() + "残护";
                                        break;
                                    case "5":
                                        dr[1] = dr[1].ToString() + "不适宜";
                                        break;
                                    case "6":
                                        dr[1] = dr[1].ToString() + "停售";
                                        break;
                                    case "7":
                                        dr[1] = dr[1].ToString() + "工作席";
                                        break;
                                    case "8":
                                        dr[1] = dr[1].ToString() + "特殊";
                                        break;
                                    #endregion
                                }
                                dr[2] = dtr.Rows[0]["SeatNumber"].ToString();
                                dr[3] = dtr.Rows[0]["TicketPrice"].ToString();
                                dr[4] = dtr.Rows[0]["TicketId"].ToString();
                                dr[5] = dtr.Rows[0]["SeatStatusId"].ToString();
                                dt.Rows.Add(dr);
                                dgvTickets.DataSource = dt;
                            }
                            else
                                MessageBox.Show("该票不是本场影票");
                        }
                    }
                    #endregion
                    #region 连场
                    else
                    {
                        StringBuilder sb_seatstatusids = new StringBuilder();
                        string barcode = this.txtBarCode.Text.Trim();
                        if (barcode.Length < 20) return;
                        string seatid = barcode.Substring(12);
                        string[] showgroupspids = showGroupShowPlanIds.Split(',');
                        foreach (string spid in showgroupspids)
                        {
                            sb_seatstatusids.Append(spid);
                            sb_seatstatusids.Append(seatid);
                            sb_seatstatusids.Append(",");
                        }
                        sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                        DataTable dtr = Flamingo.BLL.Ticket.GetTicket(sb_seatstatusids.ToString());
                        if (dtr.Rows.Count == 0)
                        {
                            MessageBox.Show("未查询到该票");
                        }
                        else if (dtr.Rows.Count > 0)
                        {
                            string ticket_showplanid = dtr.Rows[0]["SeatStatusId"].ToString().Substring(0, 12);

                            DataRow dr = dt.NewRow();
                            dr[0] = dtr.Rows[0]["BarCode"].ToString();
                            dr[1] = Flamingo.BLL.Ticket.ToTicketType(dtr.Rows[0]["TicketType"].ToString().Trim()).ToString();
                            //SeatType
                            switch (dtr.Rows[0]["SeatType"].ToString().Trim())
                            {
                                #region
                                case "0":
                                    dr[1] = dr[1].ToString() + "单座";
                                    break;
                                case "1":
                                    dr[1] = dr[1].ToString() + "双座";
                                    break;
                                case "2":
                                    dr[1] = dr[1].ToString() + "包厢";
                                    break;
                                case "3":
                                    dr[1] = dr[1].ToString() + "残障";
                                    break;
                                case "4":
                                    dr[1] = dr[1].ToString() + "残护";
                                    break;
                                case "5":
                                    dr[1] = dr[1].ToString() + "不适宜";
                                    break;
                                case "6":
                                    dr[1] = dr[1].ToString() + "停售";
                                    break;
                                case "7":
                                    dr[1] = dr[1].ToString() + "工作席";
                                    break;
                                case "8":
                                    dr[1] = dr[1].ToString() + "特殊";
                                    break;
                                #endregion
                            }
                            dr[2] = dtr.Rows[0]["SeatNumber"].ToString();
                            dr[3] = dtr.Rows[0]["TicketPrice"].ToString();
                            dr[4] = dtr.Rows[0]["TicketId"].ToString();
                            dr[5] = dtr.Rows[0]["SeatStatusId"].ToString();
                            dt.Rows.Add(dr);
                            dgvTickets.DataSource = dt;
                        }
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("该票已存在列表中");
                }
            }
        }

        private void btnDelBarCode_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                int index = dgvTickets.SelectedRows[0].Index;
                dt.Rows.RemoveAt(index);
                dgvTickets.DataSource = dt;
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb_ticketids = new StringBuilder();
                StringBuilder sb_seatstatusids = new StringBuilder();
                SeatMaDll.SeatStatusSim sss;
                //sb.Append("确定退以下影票吗");
                //sb.Append("\r\n");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(dr["座位"].ToString());
                    sb.Append(" ");
                    sb.Append(dr["价格"].ToString());
                    sb.Append("元\r\n");

                    //变量赋值
                    sb_ticketids.Append(dr["TicketId"].ToString());
                    sb_ticketids.Append("|");
                    sb_seatstatusids.Append(dr["SeatStatusId"].ToString());
                    sb_seatstatusids.Append("|");

                    sss = new SeatMaDll.SeatStatusSim();
                    sss._seatId = dr["SeatStatusId"].ToString().Substring(12);
                    sss._seatStatusFlag = "0";
                    seatlist.Add(sss);
                }
                sb_ticketids.Remove(sb_ticketids.Length - 1, 1);
                sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                DialogResult dialogR = MessageBox.Show(sb.ToString(), "退票提示", MessageBoxButtons.YesNo);
                if (dialogR == DialogResult.Yes)
                {
                    if (isShowGroup == false)
                    {

                        bool tf = Flamingo.BLL.Ticket.RefundTicket(sb_ticketids.ToString(), sb_seatstatusids.ToString(), FrmMain.curUser.UserId);
                        if (tf == true)
                        {
                            this.DialogResult = DialogResult.Yes;
                            MessageBox.Show("退票成功");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("退票失败");
                        }

                    }
                    else if (isShowGroup == true)
                    {
                        sb_seatstatusids.Clear();
                        string[] showgroupspids = ShowGroupShowPlanIds.Split(',');
                        string seatid;
                        foreach (DataRow dr in dt.Rows)
                        {
                            seatid = dr["SeatStatusId"].ToString().Substring(12);
                            foreach (string spid in showgroupspids)
                            {
                                sb_seatstatusids.Append(spid);
                                sb_seatstatusids.Append(seatid);
                                sb_seatstatusids.Append(",");
                            }

                            sss = new SeatMaDll.SeatStatusSim();
                            sss._seatId = seatid;
                            sss._seatStatusFlag = "0";
                            seatlist.Add(sss);
                        }
                        string ticketids = Flamingo.BLL.Ticket.RefundGetTicketIds(sb_seatstatusids.ToString());
                        bool tf = Flamingo.BLL.Ticket.RefundTicket(ticketids, sb_seatstatusids.ToString(), FrmMain.curUser.UserId);
                        if (tf)
                        {
                            MessageBox.Show("退票成功");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("退票失败");
                        }
                    }
                }
            }
        }

        private void frmRefund_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            if (!FrmMain.curUser.HavePermission(Flamingo.Right.Permissions.RefundTicketSelling))
                btnRefund.Enabled = false;
        }
    }
}

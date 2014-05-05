using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Flamingo.Right;

namespace WinFormUI.SaleTicket
{
    public partial class frmReservationOut : Form
    {
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
        private string _TheaterName;
        /// <summary>
        /// 影院名称
        /// </summary>
        public string TheaterName
        {
            get { return _TheaterName; }
            set { _TheaterName = value; }
        }
        private string _CheckingType;
        /// <summary>
        /// 是否对号入座
        /// </summary>
        public string CheckingType
        {
            get { return _CheckingType; }
            set { _CheckingType = value; }
        }
        private string _HallId;
        /// <summary>
        /// 影厅ID
        /// </summary>
        public string HallId
        {
            get { return _HallId; }
            set { _HallId = value; }
        }
        private Flamingo.Entity.Para_ReservationTicket _model;
        /// <summary>
        /// 订票信息
        /// </summary>
        public Flamingo.Entity.Para_ReservationTicket Model
        {
            set { _model = value; }
            get { return _model; }
        }
        private string _FilmId;
        /// <summary>
        /// 影片ID
        /// </summary>
        public string FilmId
        {
            set { _FilmId = value; }
            get { return _FilmId; }
        }
        private string showplanid;
        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowPlanId
        {
            set { showplanid = value; }
            get { return showplanid; }
        }
        /// <summary>
        /// 添加成功的支票ID
        /// </summary>
        private string _DebtId;
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_Cancel = new List<SeatMaDll.SeatStatusSim>();
        /// <summary>
        /// 取消预定的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_Cancel
        {
            get { return _SeatStatusSimList_Cancel; }
        }
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_Sold = new List<SeatMaDll.SeatStatusSim>();
        /// <summary>
        /// 预定出票的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_Sold
        {
            get { return _SeatStatusSimList_Sold; }
        }
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_SoldByVoucher = new List<SeatMaDll.SeatStatusSim>();
        /// <summary>
        /// 预定出票(票券)的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_SoldByVoucher
        {
            get { return _SeatStatusSimList_SoldByVoucher; }
        }
        private bool _isShowGroup;
        /// <summary>
        /// 是否是连场
        /// </summary>
        public bool IsShowGroup
        {
            get { return _isShowGroup; }
            set { _isShowGroup = value; }
        }
        private string _showGroupShowPlanIds;
        /// <summary>
        /// 连场场次IDs
        /// </summary>
        public string ShowGroupShowPlanIds
        {
            get { return _showGroupShowPlanIds; }
            set { _showGroupShowPlanIds = value; }
        }
        private string _showGroupFilmIds;
        /// <summary>
        /// 连场影片集合
        /// </summary>
        public string ShowGroupFilmIds
        {
            get { return _showGroupFilmIds; }
            set { _showGroupFilmIds = value; }
        }
        private string _showGroupShowPlanNames;
        /// <summary>
        /// 连场影片名称
        /// </summary>
        public string ShowGroupShowPlanNames
        {
            get { return _showGroupShowPlanNames; }
            set { _showGroupShowPlanNames = value; }
        }
        /// <summary>
        /// 场次序号
        /// </summary>
        private string _showPlanPosition;
        public string ShowPlanPosition
        {
            get { return _showPlanPosition; }
            set { _showPlanPosition = value; }
        }
        //是否含有团体支票支付
        private bool _HasGroupDebt = false;

        public frmReservationOut()
        {
            InitializeComponent();
        }

        private void frmReservationOut_Load(object sender, EventArgs e)
        {
            lblCount.Text = _model.Count.ToString();
            this.FormBorderStyle = FormBorderStyle.None;
            this.dgvTicketList.AutoGenerateColumns = false;

            txtName.Text = _model.CustomerName;
            txtCardNum.Text = _model.Identity;

            _model.DT.Columns.Add("票种");
            _model.DT.Columns.Add("支付方式");
            _model.DT.Columns.Add("HasSetVoucher");

            Flamingo.BLL.Ticket.TicketType tp;

            int hasGroupCount = 0;
            foreach (DataRow dr in _model.DT.Rows)
            {
                tp = Flamingo.BLL.Ticket.ToTicketType(dr["TicketType"].ToString());
                if (tp == Flamingo.BLL.Ticket.TicketType.单人 || tp == Flamingo.BLL.Ticket.TicketType.双人 || tp == Flamingo.BLL.Ticket.TicketType.包厢)
                {
                    dr["票种"] = Flamingo.BLL.Ticket.TicketType.零售;
                }
                else
                {
                    if (tp == Flamingo.BLL.Ticket.TicketType.团体)
                    {
                        hasGroupCount++;
                    }
                    dr["票种"] = tp;
                }
                dr["支付方式"] = "现金";
                dr["HasSetVoucher"] = "0";
            }
            if (hasGroupCount > 0)
            {
                btnSetGruopPrice.Enabled = true;
            }
            btnAddZP.Enabled = false;
            btnZPReset.Enabled = false;
            btnAddPQ.Visible = false;
            btnPQReset.Visible = false;
            chkPQ.Visible = false;

            dgvTicketList.DataSource = _model.DT;

            if (!FrmMain.curUser.HavePermission(Permissions.BookSaleTicketSelling))
            {
                btnOut.Enabled = false;
                btnOutAll.Enabled = false;
            }
            if (!FrmMain.curUser.HavePermission(Permissions.BookReleaseTicketSelling))
            {
                btnCancel.Enabled = false;
                btnCancelAll.Enabled = false;
            }
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            if (dgvTicketList.Rows.Count > 0)
            {
                StringBuilder sb_rids = new StringBuilder();

                SeatMaDll.SeatStatusSim sss;
                foreach (DataGridViewRow row in dgvTicketList.Rows)
                {
                    sss = new SeatMaDll.SeatStatusSim();
                    sss._seatId = row.Cells["SeatStatusId"].Value.ToString().Substring(12);
                    sss._seatStatusFlag = "0";
                    _SeatStatusSimList_Cancel.Add(sss);

                    sb_rids.Append(row.Cells["ReservationId"].Value.ToString());
                    sb_rids.Append("|");
                }
                sb_rids.Remove(sb_rids.Length - 1, 1);
                bool tf = Flamingo.BLL.Ticket.ReservationCancel(sb_rids.ToString());
                if (tf == true)
                {
                    MessageBox.Show("全部取消成功");
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    _SeatStatusSimList_Cancel = null;
                    MessageBox.Show("全部取消失败");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StringBuilder sb_rids = new StringBuilder();
            DataGridViewSelectedRowCollection rowCollection = dgvTicketList.SelectedRows;
            if (rowCollection.Count > 0)
            {
                foreach (DataGridViewRow row in rowCollection)
                {
                    sb_rids.Append(row.Cells["ReservationId"].Value.ToString());
                    sb_rids.Append("|");
                }
                sb_rids.Remove(sb_rids.Length - 1, 1);
                bool tf = Flamingo.BLL.Ticket.ReservationCancel(sb_rids.ToString());
                if (tf == true)
                {
                    if (dgvTicketList.Rows.Count == 0)
                    {
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    SeatMaDll.SeatStatusSim sss;
                    foreach (DataGridViewRow row in rowCollection)
                    {
                        sss = new SeatMaDll.SeatStatusSim();
                        sss._seatId = row.Cells["SeatStatusId"].Value.ToString().Substring(12);
                        sss._seatStatusFlag = "0";
                        _SeatStatusSimList_Cancel.Add(sss);
                        dgvTicketList.Rows.Remove(row);
                    }
                    MessageBox.Show("取消成功");
                    lblCount.Text = dgvTicketList.Rows.Count.ToString();
                    if (dgvTicketList.Rows.Count == 0)
                    {
                        this.Close();
                    }
                }
                else
                {
                    _SeatStatusSimList_Cancel = null;
                    MessageBox.Show("取消失败");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            OutTicket(true);
        }

        private void btnOutAll_Click(object sender, EventArgs e)
        {
            OutTicket(false);
        }

        private void OutTicket(bool isOnlyOutSelected)
        {
            if (dgvTicketList.Rows.Count > 0)
            {
                StringBuilder sb_rids = new StringBuilder();
                StringBuilder sb_ticketid = new StringBuilder();
                StringBuilder sb_seatids = new StringBuilder();
                int paymentmethoedid = 1;
                float totalprice = 0;
                StringBuilder sb_tickettype = new StringBuilder();
                StringBuilder sb_ticketprice = new StringBuilder();
                StringBuilder sb_barcode = new StringBuilder();
                string userid = FrmMain.curUser.UserId.ToString();
                int templateid = FrmMain.template == null ? 1 : FrmMain.template.TemplateId;

                StringBuilder sb_showplanids = new StringBuilder();
                StringBuilder sb_filmids = new StringBuilder();
                StringBuilder sb_seatstatusids = new StringBuilder();

                int count = 0;

                //获得选中支付方式
                string ptStr;
                if (dgvTicketList.SelectedRows.Count == 0)
                    ptStr = dgvTicketList.Rows[0].Cells["支付方式"].Value.ToString();
                else
                    ptStr = dgvTicketList.SelectedRows[0].Cells["支付方式"].Value.ToString();
                Flamingo.BLL.Type.PayType.Paytype paytype = Flamingo.BLL.Type.PayType.ToPayType(ptStr);

                paymentmethoedid = Flamingo.BLL.Type.PayType.ToPayType(paytype);

                StringBuilder sb_paytypes = new StringBuilder();

                //打印信息Flamingo.TemplateCore.TemplatePrintModel 
                List<Flamingo.TemplateCore.TemplatePrintModel> PrintModels = new List<Flamingo.TemplateCore.TemplatePrintModel>();
                Flamingo.TemplateCore.TemplatePrintModel PrintModel;
                #region 连场
                if (_isShowGroup == true)
                {
                    Hashtable ht;
                    string[] spids = ShowGroupShowPlanIds.Split(',');
                    string[] fids = ShowGroupFilmIds.Split(',');
                    foreach (DataGridViewRow row in dgvTicketList.Rows)
                    {
                        if (isOnlyOutSelected == true)
                        {
                            if (row.Selected == false && row.Cells["支付方式"].Value.ToString() != "支票")
                                continue;
                        }
                        if (float.Parse(row.Cells["价格"].Value.ToString()) <= 0)
                            continue;

                        #region  打印信息
                        PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
                        //影票ID
                        PrintModel.TicketId = Guid.NewGuid().ToString();
                        //售票类型
                        PrintModel.TicketType = row.Cells["票种"].Value.ToString();
                        //票价
                        PrintModel.TicketPrice = float.Parse(row.Cells["价格"].Value.ToString()).ToString("0.00");
                        //条形码
                        PrintModel.BarCodeStr = row.Cells["SeatStatusId"].Value.ToString();
                        PrintModel.SeatNumberStr = row.Cells["座位"].Value.ToString();
                        string rc = PrintModel.SeatNumberStr.Replace("行", ",").Replace("排", ",").Replace("座", ",").Replace("号", ",").Replace("列", ",");
                        PrintModel.RowNumber = rc.Split(',')[0];
                        PrintModel.SeatNumber = rc.Split(',')[1];
                        PrintModel.PayType = row.Cells["支付方式"].Value.ToString();
                        //票版其他信息
                        if (IsShowGroup == true)
                            PrintModel.FilmName = ShowGroupShowPlanNames.Replace(',', '+');
                        else
                            PrintModel.FilmName = ShowPlanName;
                        PrintModel.CheckingType = _CheckingType;
                        PrintModel.HallFieldCode = _HallId;
                        PrintModel.HallName = ShowPlanHall;
                        PrintModel.SellTime = DateTime.Now.ToString("yyyyMMddHHmm"); ;
                        PrintModel.StaffNumber = FrmMain.curUser.EmployeeId;
                        PrintModel.TheaterName = _TheaterName;
                        PrintModel.TicketDate = ShowPlanDate;
                        PrintModel.TicketTime = ShowPlanStartTime; 
                        PrintModel.Position = ShowPlanPosition;

                        PrintModels.Add(PrintModel);
                        #endregion

                        #region 票信息
                        sb_rids.Append(row.Cells["ReservationId"].Value.ToString());
                        sb_rids.Append("|");
                        for (int i = 0; i < spids.Length; i++)
                        {
                            sb_showplanids.Append(spids[i]);
                            sb_showplanids.Append("|");

                            sb_filmids.Append(fids[i]);
                            sb_filmids.Append("|");

                            sb_seatstatusids.Append(row.Cells["SeatStatusId"].Value.ToString());
                            sb_seatstatusids.Append("|");

                            sb_ticketid.Append(Guid.NewGuid().ToString());
                            sb_ticketid.Append("|");

                            sb_seatids.Append(row.Cells["SeatStatusId"].Value.ToString().Substring(12));
                            sb_seatids.Append("|");


                            float tp = Flamingo.BLL.Ticket.GetPriceTotal(spids[i], row.Cells["SeatStatusId"].Value.ToString().Substring(12),
                                 row.Cells["票种"].Value.ToString(), out ht, true, ShowGroupShowPlanIds);
                            if (float.Parse(row.Cells["价格"].Value.ToString()) == tp)
                                sb_ticketprice.Append(ht[spids[i] + row.Cells["SeatStatusId"].Value.ToString().Substring(12)].ToString());
                            else
                                sb_ticketprice.Append(float.Parse(row.Cells["价格"].Value.ToString()) / spids.Length);
                            sb_ticketprice.Append("|");

                            sb_tickettype.Append(row.Cells["TicketType"].Value.ToString());
                            sb_tickettype.Append("|");

                            sb_paytypes.Append(Flamingo.BLL.Type.PayType.ToPayType(Flamingo.BLL.Type.PayType.ToPayType(row.Cells["支付方式"].Value.ToString())));
                            sb_paytypes.Append("|");

                            count++;
                        }
                        #endregion

                    }
                    if (sb_seatids.Length > 0)
                    {
                        sb_rids.Remove(sb_rids.Length - 1, 1);
                        sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                        sb_showplanids.Remove(sb_showplanids.Length - 1, 1);
                        sb_filmids.Remove(sb_filmids.Length - 1, 1);
                        sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                        sb_seatids.Remove(sb_seatids.Length - 1, 1);
                        sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                        sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                        sb_paytypes.Remove(sb_paytypes.Length - 1, 1);
                    }
                }
                #endregion 连场
                #region 非连场
                else
                {
                    foreach (DataGridViewRow row in dgvTicketList.Rows)
                    {
                        if (isOnlyOutSelected == true)
                        {
                            if (row.Selected == false && row.Cells["支付方式"].Value.ToString() != "支票")
                                continue;
                        }

                        #region  打印信息
                        PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
                        //影票ID
                        PrintModel.TicketId = Guid.NewGuid().ToString();
                        //售票类型
                        PrintModel.TicketType = row.Cells["票种"].Value.ToString();
                        //票价
                        PrintModel.TicketPrice = float.Parse(row.Cells["价格"].Value.ToString()).ToString("0.00");
                        //条形码
                        PrintModel.BarCodeStr = row.Cells["SeatStatusId"].Value.ToString();
                        PrintModel.SeatNumberStr = row.Cells["座位"].Value.ToString();
                        string rc = PrintModel.SeatNumberStr.Replace("行", ",").Replace("排", ",").Replace("座", ",").Replace("号", ",").Replace("列", ",");
                        PrintModel.RowNumber = rc.Split(',')[0];
                        PrintModel.SeatNumber = rc.Split(',')[1];
                        //票版其他信息
                        PrintModel.FilmName = ShowPlanName;
                        PrintModel.CheckingType = _CheckingType;
                        PrintModel.HallFieldCode = _HallId;
                        PrintModel.HallName = ShowPlanHall;
                        PrintModel.SellTime = DateTime.Now.ToString("yyyyMMddHHmm"); ;
                        PrintModel.StaffNumber = FrmMain.curUser.EmployeeId;
                        PrintModel.TheaterName = _TheaterName;
                        PrintModel.TicketDate = ShowPlanDate;
                        PrintModel.TicketTime = ShowPlanStartTime;
                        PrintModel.Position = ShowPlanPosition;

                        PrintModels.Add(PrintModel);
                        #endregion

                        #region 票信息
                        sb_rids.Append(row.Cells["ReservationId"].Value.ToString());
                        sb_rids.Append("|");

                        sb_ticketid.Append(PrintModel.TicketId);
                        sb_ticketid.Append("|");

                        sb_seatids.Append(row.Cells["SeatStatusId"].Value.ToString().Substring(12));
                        sb_seatids.Append("|");

                        totalprice += float.Parse(row.Cells["价格"].Value.ToString());

                        sb_tickettype.Append(row.Cells["TicketType"].Value.ToString());
                        sb_tickettype.Append("|");

                        sb_ticketprice.Append(row.Cells["价格"].Value.ToString());
                        sb_ticketprice.Append("|");

                        sb_barcode.Append(row.Cells["SeatStatusId"].Value.ToString());
                        sb_barcode.Append("|");

                        PrintModel.PayType = row.Cells["支付方式"].Value.ToString();
                        sb_paytypes.Append(row.Cells["支付方式"].Value.ToString());
                        #endregion
                    }

                    sb_rids.Remove(sb_rids.Length - 1, 1);
                    sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                    sb_seatids.Remove(sb_seatids.Length - 1, 1);
                    sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                    sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                    sb_barcode.Remove(sb_barcode.Length - 1, 1);
                }
                #endregion

                if (sb_paytypes.ToString().IndexOf("支票") >= 0 && chkZP.Checked == false)
                {
                    MessageBox.Show("预定出票包含支票支付\r\n请先填写支票信息");
                    return;
                }
                bool tf = false;
                if (_isShowGroup == true)
                {
                    tf = Flamingo.BLL.Ticket.ReservationOutTicketGroup(sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                        sb_tickettype.ToString(), sb_paytypes.ToString(), templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count, sb_rids.ToString());
                }
                else
                {
                    tf = Flamingo.BLL.Ticket.ReservationOutTicket(sb_rids.ToString(), sb_ticketid.ToString(), _model.ShowPlanId, sb_seatids.ToString(), paymentmethoedid,
                                totalprice, sb_tickettype.ToString(), sb_ticketprice.ToString(), sb_barcode.ToString(), userid, templateid, _FilmId);
                }
                if (tf == true)
                {
                    if (paytype == Flamingo.BLL.Type.PayType.Paytype.支票)
                        _DebtId = "-1";
                    if (isOnlyOutSelected == true)
                    {
                        SeatMaDll.SeatStatusSim sss;
                        List<DataGridViewRow> removerowslist = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dgvTicketList.Rows)
                        {
                            if (isOnlyOutSelected == true)
                            {
                                if (row.Selected == false && row.Cells["支付方式"].Value.ToString() != "支票")
                                    continue;
                            }
                            sss = new SeatMaDll.SeatStatusSim();
                            sss._seatId = row.Cells["SeatStatusId"].Value.ToString().Substring(12);
                            sss._seatStatusFlag = "4";
                            _SeatStatusSimList_Sold.Add(sss);

                            removerowslist.Add(row);
                        }
                        int i = 0;
                        StringBuilder sb_failedticketids = new StringBuilder();
                        foreach (DataGridViewRow row in removerowslist)
                        {
                            try
                            {
                                WinFormUI.SaleTicket.Print.PrintTicket(PrintModels[i]);
                            }
                            catch
                            {
                                sb_failedticketids.Append(PrintModels[i].TicketId);
                                sb_failedticketids.Append(",");
                            }
                            finally
                            {
                                this.Activate();
                            }
                            i++;
                            dgvTicketList.Rows.Remove(row);
                        }
                        if (sb_failedticketids.Length > 0)
                        {
                            sb_failedticketids.Remove(sb_failedticketids.Length - 1, 1);
                            Flamingo.BLL.Ticket.SetPrintStatus(sb_failedticketids, 0);
                        }
                        lblCount.Text = dgvTicketList.Rows.Count.ToString();
                    }
                    else
                    {
                        int i = 0;
                        SeatMaDll.SeatStatusSim sss;
                        StringBuilder sb_failedticketids = new StringBuilder();
                        foreach (DataGridViewRow row in dgvTicketList.Rows)
                        {
                            sss = new SeatMaDll.SeatStatusSim();
                            sss._seatId = row.Cells["SeatStatusId"].Value.ToString().Substring(12);
                            sss._seatStatusFlag = "4";
                            _SeatStatusSimList_Sold.Add(sss);
                            try
                            {
                                WinFormUI.SaleTicket.Print.PrintTicket(PrintModels[i]);
                            }
                            catch
                            {
                                sb_failedticketids.Append(PrintModels[i].TicketId);
                                sb_failedticketids.Append(",");
                            }
                            finally
                            {
                                this.Activate();
                            }
                        }
                        if (sb_failedticketids.Length > 0)
                        {
                            sb_failedticketids.Remove(sb_failedticketids.Length - 1, 1);
                            Flamingo.BLL.Ticket.SetPrintStatus(sb_failedticketids, 0);
                        }
                        dgvTicketList.DataSource = null;
                        lblCount.Text = "0";
                    }
                }
                else
                {
                    _SeatStatusSimList_Cancel = null;
                    MessageBox.Show("预定出票失败");
                }
            }
        }

        private void dgvTicketList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                string paytype = dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string tickettype = dgvTicketList.Rows[e.RowIndex].Cells[3].Value.ToString();
                Permission p = (Permission)Flamingo.BLL.Type.PayType.ListPermissions[Flamingo.BLL.Type.PayType.ToPayType(paytype)];
                if (!FrmMain.curUser.HavePermission(p))
                {
                    MessageBox.Show("您没有" + paytype + "权限", "提示");
                    return;
                }

                if (paytype == "会员卡" || paytype == "优惠券" || paytype == "兑换券" || paytype == "代用券" ||
                    paytype == "积分" || paytype == "赠票")
                {
                    if (tickettype != "零售")
                    {
                        MessageBox.Show(string.Format("{0}票不能使用{1}支付", tickettype, paytype));
                        dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "现金";
                    }
                    else
                    {
                        if (paytype == "优惠券" || paytype == "兑换券" || paytype == "代用券")
                        {
                            #region 优惠券
                            float price = float.Parse(dgvTicketList.Rows[e.RowIndex].Cells["价格"].Value.ToString());
                            frmVoucher frm = new frmVoucher(price, Flamingo.BLL.Type.PayType.ToPayType(paytype));
                            if (frm.ShowDialog() == DialogResult.Yes)
                            {
                                Flamingo.Entity.Para_VoucherAdd model = new Flamingo.Entity.Para_VoucherAdd(frm.Voucherlist);
                                model.BarCode = dgvTicketList.Rows[e.RowIndex].Cells["SeatStatusId"].Value.ToString();
                                model.FilmId = _FilmId;
                                model.PaymentMethodId = Flamingo.BLL.Type.PayType.ToPayType(frm.VoucherType);
                                model.SeatId = dgvTicketList.Rows[e.RowIndex].Cells["SeatStatusId"].Value.ToString().Substring(12);
                                model.ShowPlanId = _model.ShowPlanId;
                                model.SoldBy = FrmMain.curUser.UserId;
                                model.TemplateId = FrmMain.template == null ? 1 : FrmMain.template.TemplateId;
                                model.TicketPrice = price;//frm.OutTicketPrice;
                                model.TicketType = Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体);
                                model.TicketId = Guid.NewGuid().ToString();
                                model.VoucherTypeId = Flamingo.BLL.Type.PayType.ToPayType(frm.VoucherType);
                                bool tf = false;
                                if (_isShowGroup == true)
                                {
                                    StringBuilder sb_showplanids = new StringBuilder();
                                    StringBuilder sb_filmids = new StringBuilder();
                                    StringBuilder sb_seatstatusids = new StringBuilder();
                                    StringBuilder sb_ticketid = new StringBuilder();
                                    StringBuilder sb_seatids = new StringBuilder();
                                    StringBuilder sb_tickettype = new StringBuilder();
                                    StringBuilder sb_ticketprice = new StringBuilder();
                                    StringBuilder sb_barcode = new StringBuilder();

                                    string[] spids = ShowGroupShowPlanIds.Split(',');
                                    string[] fids = ShowGroupFilmIds.Split(',');
                                    int count = spids.Length;
                                    Hashtable ht = null;
                                    int templateid = FrmMain.template == null ? 1 : FrmMain.template.TemplateId;
                                    for (int i = 0; i < spids.Length; i++)
                                    {
                                        sb_showplanids.Append(spids[i]);
                                        sb_showplanids.Append("|");

                                        sb_filmids.Append(fids[i]);
                                        sb_filmids.Append("|");

                                        sb_seatstatusids.Append(spids[i] + model.SeatId);
                                        sb_seatstatusids.Append("|");

                                        //票ID
                                        sb_ticketid.Append(Guid.NewGuid().ToString());
                                        sb_ticketid.Append("|");

                                        //座位ID
                                        sb_seatids.Append(model.SeatId);
                                        sb_seatids.Append("|");

                                        //售票类型
                                        sb_tickettype.Append("6");
                                        sb_tickettype.Append("|");

                                        //票价
                                        Flamingo.BLL.Ticket.GetPriceTotal(spids[i], dgvTicketList.Rows[e.RowIndex].Cells["SeatStatusId"].Value.ToString().Substring(12),
                                            dgvTicketList.Rows[e.RowIndex].Cells["票种"].Value.ToString(), out ht, true, ShowGroupShowPlanIds);
                                        sb_ticketprice.Append(ht[spids[i] + model.SeatId].ToString());
                                        sb_ticketprice.Append("|");
                                    }

                                    if (sb_seatids.Length > 0)
                                    {
                                        sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                                        sb_showplanids.Remove(sb_showplanids.Length - 1, 1);
                                        sb_filmids.Remove(sb_filmids.Length - 1, 1);
                                        sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                                        sb_seatids.Remove(sb_seatids.Length - 1, 1);
                                        sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                                        sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                                    }
                                    if (paytype == "代用券")
                                    {
                                        tf = Flamingo.BLL.Ticket.VoucherSubstituteSaleGroup(model.VoucherBatchIds,
                                             sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                                            sb_tickettype.ToString(), 5, templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count);
                                    }
                                    else
                                    {
                                        int pid = 4;
                                        if (paytype == "优惠券")
                                            pid = 6;
                                        tf = Flamingo.BLL.Ticket.VoucherSaleGroup(model.VoucherIds, model.Prices, model.BarCodes, model.VoucherTypeId,
                                            model.VoucherBatchIds,
                                            sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                                            sb_tickettype.ToString(), pid, templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count);
                                    }
                                }
                                else
                                {
                                    if (paytype == "代用券")
                                        tf = Flamingo.BLL.Ticket.VoucherSubstituteSale(model);
                                    else
                                        tf = Flamingo.BLL.Ticket.VoucherSale(model);
                                }
                                if (tf == true)
                                {
                                    Flamingo.BLL.Ticket.ReservationDel(dgvTicketList.Rows[e.RowIndex].Cells["ReservationId"].Value.ToString());

                                    SeatMaDll.SeatStatusSim sss = new SeatMaDll.SeatStatusSim();
                                    sss._seatId = model.SeatId;
                                    sss._seatStatusFlag = "4";
                                    _SeatStatusSimList_SoldByVoucher.Add(sss);
                                    Flamingo.TemplateCore.TemplatePrintModel PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
                                    PrintModel.BarCodeStr = model.BarCode;
                                    PrintModel.CheckingType = _CheckingType;
                                    PrintModel.FilmName = ShowPlanName;
                                    PrintModel.HallFieldCode = _HallId;
                                    PrintModel.HallName = ShowPlanHall;
                                    PrintModel.PayType = paytype;
                                    PrintModel.SeatNumberStr = dgvTicketList.Rows[e.RowIndex].Cells["座位"].Value.ToString();
                                    string rc = PrintModel.SeatNumberStr.Replace("行", ",").Replace("排", ",").Replace("座", ",").Replace("号", ",").Replace("列", ",");
                                    PrintModel.RowNumber = rc.Split(',')[0];
                                    PrintModel.SeatNumber = rc.Split(',')[1];
                                    PrintModel.SellTime = DateTime.Now.ToString("yyyyMMddHHmm");
                                    PrintModel.StaffNumber = FrmMain.curUser.EmployeeId;
                                    PrintModel.TheaterName = _TheaterName;
                                    PrintModel.TicketDate = ShowPlanDate;
                                    PrintModel.TicketId = model.TicketId;
                                    PrintModel.TicketPrice = model.TicketPrice.ToString("0.00");
                                    PrintModel.TicketTime = ShowPlanStartTime;
                                    PrintModel.TicketType = dgvTicketList.Rows[e.RowIndex].Cells["票种"].Value.ToString();
                                    PrintModel.Position = ShowPlanPosition;
                                    if (IsShowGroup == true)
                                        PrintModel.FilmName = ShowGroupShowPlanNames.Replace(',', '+');
                                    else
                                        PrintModel.FilmName = ShowPlanName;

                                    dgvTicketList.Rows.RemoveAt(e.RowIndex);
                                    try
                                    {
                                        WinFormUI.SaleTicket.Print.PrintTicket(PrintModel);
                                    }
                                    catch
                                    {
                                        Flamingo.BLL.Ticket.SetPrintStatus(PrintModel.TicketId, 0);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("票券出票失败");
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show(string.Format("暂不支持会员功能"));
                            dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "现金";
                        }
                    }
                }
                else if (paytype == "支票")
                {
                    if (tickettype != "团体")
                    {
                        MessageBox.Show(string.Format("{0}票不能使用{1}支付", tickettype, paytype));
                        dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "现金";
                    }
                    else if (chkZP.Checked == true)
                    {
                        MessageBox.Show(string.Format("支票已填写完毕\r\n如需将该票添加到支票\r\n请重置支票并重新填写支票信息", tickettype, paytype));
                        dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "现金";
                    }
                }
                else if (paytype == "会员卡支付卡")
                {
                    if (tickettype != "零售" || tickettype != "学生")
                    {
                        MessageBox.Show(string.Format("{0}票不能使用{1}支付", tickettype, paytype));
                        dgvTicketList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "现金";
                    }
                }
                _HasGroupDebt = SetHasGroupDept();
                btnAddZP.Enabled = _HasGroupDebt;
            }
        }

        private bool SetHasGroupDept()
        {
            bool tf = false;
            foreach (DataGridViewRow row in dgvTicketList.Rows)
            {
                if (row.Cells["票种"].Value.ToString() == "团体" && row.Cells["支付方式"].Value.ToString() == "支票")
                {
                    tf = true;
                    break;
                }
            }
            return tf;
        }

        private void dgvTicketList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                dgvTicketList.EndEdit();
        }

        private void btnSetGruopPrice_Click(object sender, EventArgs e)
        {
            frmGroup frm = new frmGroup(showplanid);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvTicketList.Rows)
                {
                    if (row.Cells["票种"].Value.ToString() == "团体")
                    {
                        row.Cells["价格"].Value = frm.Price.ToString("0");
                    }
                }
            }
        }

        private void btnAddZP_Click(object sender, EventArgs e)
        {
            frmDebt frm = new frmDebt();
            frm.ShowPlanDate = lblShowPlanName.Text;
            frm.HallName = lblHallName.Text;
            frm.StartTime = lblShowPlanTime.Text;
            frm.TicketType = Flamingo.BLL.Ticket.TicketType.团体.ToString();
            frm.FilmName = lblShowPlanName.Text;

            int count = 0;
            float total = 0;
            float price = 0;
            foreach (DataGridViewRow row in dgvTicketList.Rows)
            {
                if (row.Cells["票种"].Value.ToString() == "团体" && row.Cells["支付方式"].Value.ToString() == "支票")
                {
                    count++;
                    total += float.Parse(row.Cells["价格"].Value.ToString());
                    if (price == 0)
                        price = float.Parse(row.Cells["价格"].Value.ToString());
                }
            }
            frm.TicketCount = count;
            frm.Total = total;
            frm.Price = price;
            frm.IsOut = true;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                _DebtId = frm.DebtId;
                btnAddZP.Enabled = false;
                chkZP.Checked = true;
                btnZPReset.Enabled = true;
                foreach (DataGridViewRow row in dgvTicketList.Rows)
                {
                    if (row.Cells["票种"].Value.ToString() == "团体" && row.Cells["支付方式"].Value.ToString() == "支票")
                    {
                        row.Cells["支付方式"].ReadOnly = true;
                    }
                }
            }
        }

        private void btnZPReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_DebtId))
            {
                MessageBox.Show("支票丢失,请重新添加");
            }
            else if (_DebtId == "-1")
            {
                MessageBox.Show("已有支票支付的影票出票,无法重置");
            }
            else
            {
                DialogResult dr = MessageBox.Show("重置后,需要重新填写支票\r\n确定重置吗?", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    bool tf = Flamingo.BLL.Ticket.DelCheque(_DebtId);
                    if (tf == true)
                    {
                        _DebtId = string.Empty;
                        btnAddZP.Enabled = true;
                        chkZP.Checked = false;
                        foreach (DataGridViewRow row in dgvTicketList.Rows)
                        {
                            if (row.Cells["票种"].Value.ToString() == "团体" && row.Cells["支付方式"].Value.ToString() == "支票")
                            {
                                row.Cells["支付方式"].ReadOnly = false;
                            }
                        }
                    }
                }
            }
        }

        private void chkZP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZP.Checked == true)
                btnSetGruopPrice.Enabled = false;
            else
                btnSetGruopPrice.Enabled = true;
        }

        private void btnAddPQ_Click(object sender, EventArgs e)
        {
        }

    }
}

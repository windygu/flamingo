using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormUI.TemplateUI;
using Flamingo.Right;

namespace WinFormUI
{
    public partial class DlgGroupControlSelect : Form
    {
        private SeatMaDll.BHSeatControl _bhSeat = null;
        private string _SeatStatusFlag = "0";

        public DlgGroupControlSelect()
        {
            InitializeComponent();
        }
        public DlgGroupControlSelect(SeatMaDll.BHSeatControl bhSeat)
        {
            InitializeComponent();
            _bhSeat = bhSeat;
            SeatMaDll.Seat st = (SeatMaDll.Seat)_bhSeat.Tag;
            List<SeatMaDll.Seat> list = new List<SeatMaDll.Seat>();
            if (st._brotherList.Count <= 0)
            {
                SeatMaDll.Seat stNew = new SeatMaDll.Seat();
                stNew._seatFlag = st._seatFlag;
                stNew._seatStatusFlag = st._seatStatusFlag;
                stNew._seatRowNumber = st._seatRowNumber;
                stNew._seatId = st._seatId;
                stNew._seatColumn = st._seatColumn;
                stNew._seatNumber = st._seatNumber;
                stNew._seatDisplay = st._seatDisplay;
                stNew._seatColumnCount = st._seatColumnCount;
                stNew._seatPosX = (panel_BhList.Width - st._seatWidth) / 2;
                stNew._seatPosY = (panel_BhList.Height - st._seatHeight) / 2;
                stNew._seatWidth = st._seatWidth;
                stNew._seatHeight = st._seatHeight;
                stNew._seatSeatingChartId = st._seatSeatingChartId;
                stNew._seatBlockId = st._seatBlockId;
                list.Add(stNew);
            }
            else
            {
                int nLeft = st._brotherList[0]._seatPosX;
                int nTop = st._brotherList[0]._seatPosY;
                int nRight = st._brotherList[0]._seatPosX + st._brotherList[0]._seatWidth;
                int nBottom = st._brotherList[0]._seatPosY + st._brotherList[0]._seatHeight;
                GetFourMargin(st._brotherList, ref nLeft, ref nTop, ref nRight, ref nBottom);
                foreach (SeatMaDll.Seat stB in st._brotherList)
                {
                    SeatMaDll.Seat stNew = new SeatMaDll.Seat();

                    stNew._seatFlag = stB._seatFlag;
                    stNew._seatStatusFlag = stB._seatStatusFlag;
                    stNew._seatRowNumber = stB._seatRowNumber;
                    stNew._seatId = stB._seatId;
                    stNew._seatColumn = stB._seatColumn;
                    stNew._seatNumber = stB._seatNumber;
                    stNew._seatDisplay = stB._seatDisplay;
                    stNew._seatColumnCount = stB._seatColumnCount;
                    stNew._seatPosX = stB._seatPosX - nLeft;
                    stNew._seatPosY = stB._seatPosY - nTop;
                    stNew._seatWidth = stB._seatWidth;
                    stNew._seatHeight = stB._seatHeight;
                    stNew._seatSeatingChartId = stB._seatSeatingChartId;
                    stNew._seatBlockId = stB._seatBlockId;
                    list.Add(stNew);
                }
            }
            seatChartDisp1.ImportSeatList(list);
        }
        private void GetFourMargin(List<SeatMaDll.Seat> list, ref int nLeft, ref int nTop,
            ref int nRight, ref int nBottom)
        {
            if (this.Controls.Count < 1) return;
            nLeft = list[1]._seatPosX;
            nTop = list[1]._seatPosY;
            nRight = list[1]._seatPosX + list[1]._seatWidth;
            nBottom = list[1]._seatPosY + list[1]._seatHeight;
            bool bR = true;
            foreach (SeatMaDll.Seat st in list)
            {
                if (st._seatPosX < nLeft) nLeft = st._seatPosX;
                if (st._seatPosY < nTop) nTop = st._seatPosY;
                if ((st._seatPosX + st._seatWidth) > nRight) nRight = st._seatPosX + st._seatWidth;
                if ((st._seatPosY + st._seatHeight) > nBottom) nBottom = st._seatPosY + st._seatHeight;

            }
        }
        //public void SetListData(SeatMaDll.BHSeatControl bhSeat)
        //{
        //    _bhSeat = bhSeat;
        //}

        private void DlgMultiSelect_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            if (_bhSeat == null) return;
            SeatMaDll.Seat st = (SeatMaDll.Seat)_bhSeat.Tag;
            int nR = 0;
            if (st._brotherList.Count <= 0)
            {
                string szColumns = st._seatColumn;//GetColumnsNum(st._seatColumnList);//st._seatColumn[0];
                nR = this.dgv_List.Rows.Add(new object[] { 
                                            st._seatNumber,
                                            st._seatRowNumber,
                                            szColumns,
                                            st._seatStatusFlag,
                                            st._seatId});

                dgv_List.Rows[nR].Tag = st;
            }
            else
            {
                foreach (SeatMaDll.Seat stB in st._brotherList)
                {
                    string szColumns = stB._seatColumn;
                    nR = this.dgv_List.Rows.Add(new object[] { 
                                                stB._seatNumber,
                                                stB._seatRowNumber,
                                                szColumns,
                                                stB._seatStatusFlag,
                                                stB._seatId});
                    dgv_List.Rows[nR].Tag = stB;
                }
            }
            dgv_List.ClearSelection();

        }
        private string GetColumnsNum(List<string> listColumns)
        {
            string szR = "";
            if (listColumns == null) return szR;
            foreach (string s in listColumns)
            {
                szR += s + ",";
            }
            szR = szR.Substring(0, szR.Length - 1);
            return szR;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            SetAllItemStatus();
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            //this.Dispose();
        }
        private void bt_UnLocked_Click(object sender, EventArgs e)
        {
            _SeatStatusFlag = "0";
        }
        private void bt_Lock_Click(object sender, EventArgs e)
        {
            _SeatStatusFlag = "5";
        }
        private void bt_SpecialLock_Click(object sender, EventArgs e)
        {
            _SeatStatusFlag = "2";
        }
        private void bt_PrSuccess_Click(object sender, EventArgs e)
        {
            _SeatStatusFlag = "3";
        }

        private void bt_Success_Click(object sender, EventArgs e)
        {
            _SeatStatusFlag = "4";
        }
        private void SetAllItemStatus()
        {
            List<SeatMaDll.BHSeatControl> list = new List<SeatMaDll.BHSeatControl>();
            list = seatChartDisp1.RetrieveAllItems();//.RetrieveAllItems_BySeatStatus(szSeatStatusFlag);
            foreach (SeatMaDll.BHSeatControl bh in list)
            {
                SeatMaDll.Seat st = (SeatMaDll.Seat)bh.Tag;
                string szSeatStatusFlag = st._seatStatusFlag;
                bool bR = SetStatus(st._seatId, szSeatStatusFlag);
            }
        }

        private void SetAllItemStatus(string szSeatStatusFlag)
        {
            List<SeatMaDll.BHSeatControl> list = new List<SeatMaDll.BHSeatControl>();
            list = seatChartDisp1.RetrieveAllItems_BySeatStatus(szSeatStatusFlag);
            foreach (SeatMaDll.BHSeatControl bh in list)
            {
                SeatMaDll.Seat st = (SeatMaDll.Seat)bh.Tag;
                //szSeatStatusFlag = st._seatStatusFlag;
                bool bR = SetStatus(st._seatId, szSeatStatusFlag);
            }
        }
        private bool SetStatus(string szSeatId, string szSeatStatusFlag)
        {
            if (_bhSeat == null) return false;
            if (_bhSeat.Tag == null) return false;
            SeatMaDll.Seat st = (SeatMaDll.Seat)_bhSeat.Tag;
            if (st._brotherList.Count <= 0)
            {
                if (st._seatId == szSeatId)
                {
                    st._seatStatusFlag = szSeatStatusFlag;
                    _bhSeat.SeatStatus = SeatMaDll.EditSeatItem.GetControlStatus_ByFlag(szSeatStatusFlag);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                foreach (SeatMaDll.Seat stB in st._brotherList)
                {
                    if (stB._seatId == szSeatId)
                    {
                        stB._seatStatusFlag = szSeatStatusFlag;
                        return true;
                    }
                }
            }
            return false;
        }
        private void MouseClickSetStatus(SeatMaDll.BHSeatControl seat, string szSeatStatusFlag)
        {
            seat.SeatStatus = SeatMaDll.EditSeatItem.GetControlStatus_ByFlag(szSeatStatusFlag);// SeatMaDll.BHSeatControl.BHSeatStatus.Selected;
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            st._seatStatusFlag = szSeatStatusFlag;
        }

        #region 售票相关
        private string _szShowplanId;
        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowplanId
        {
            set { _szShowplanId = value; }
        }
        private string _szCheckingType;
        /// <summary>
        /// 是否对号入座
        /// </summary>
        public string CheckingType
        {
            get { return _szCheckingType; }
            set { _szCheckingType = value; }
        }
        private string _szShowplanName;
        /// <summary>
        /// 计划名称
        /// </summary>
        public string ShowplanName
        {
            get { return _szShowplanName; }
            set { _szShowplanName = value; }
        }
        private string _szHallId;
        /// <summary>
        /// 厅ID
        /// </summary>
        public string HallId
        {
            get { return _szHallId; }
            set { _szHallId = value; }
        }
        private string _HallName;
        /// <summary>
        /// 厅名称
        /// </summary>
        public string HallName
        {
            get { return _HallName; }
            set { _HallName = value; }
        }
        private string _szTheaterName;
        /// <summary>
        /// 影院名称
        /// </summary>
        public string TheaterName
        {
            get { return _szTheaterName; }
            set { _szTheaterName = value; }
        }
        private string _szShowPlanDate;
        /// <summary>
        /// 放映日期
        /// </summary>
        public string ShowPlanDate
        {
            get { return _szShowPlanDate; }
            set { _szShowPlanDate = value; }
        }
        private string _szShowPlanStartTime;
        /// <summary>
        /// 场次
        /// </summary>
        public string ShowPlanStartTime
        {
            get { return _szShowPlanStartTime; }
            set { _szShowPlanStartTime = value; }
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

        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            List<DataObject.PO.SeatPo> list = SeatAction.SplitDBObj(st);

            string AlowLeftClickSeatType = "0,1,2,3";

            //判断座位类型是否允许选中
            if (!AlowLeftClickSeatType.Contains(list[0].SEATTYPE))
                return;
            if (st._seatStatusFlag == "0")
            {
                int statusNum = Flamingo.BLL.SeatStatus.Lock(_szShowplanId, list[0].SEATID, FrmMain.curUser.UserId);
                MouseClickSetStatus(seat, statusNum.ToString());
            }
        }
        private void seatChartDisp1__RightOneClick(object sender, SeatMaDll.RMSelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            ContextMenuStrip cms = CreateMouseRightMenu(seat);
            Point p = new Point(MousePosition.X + 5, MousePosition.Y + 5);
            cms.Show(p);
        }

        /// <summary>
        /// 创建右键Menu项
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateMouseRightMenu(SeatMaDll.BHSeatControl seat)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            List<ToolStripItem> list = new List<ToolStripItem>();
            ContextMenuStrip cms = new ContextMenuStrip();

            if (st._seatStatusFlag == "5")
            {
                list.Add(cms.Items.Add("取消选择", null, this.Menu_Click));
                list[list.Count - 1].Name = "Cancel";
                list[list.Count - 1].Tag = seat;

                list.Add(cms.Items.Add("锁定", null, this.Menu_Click));
                list[list.Count - 1].Name = "SpecialLock";
                list[list.Count - 1].Tag = seat;
                if (!FrmMain.curUser.HavePermission(Permissions.LockTicketSelling))
                    cms.Items[cms.Items.Count - 1].Enabled = false;

                #region 取消多个选中座位
                List<SeatMaDll.SeatStatusSim> seatlist = seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                if (seatlist.Count > 1)
                {
                    list.Add(cms.Items.Add("取消所有选择", null, this.Menu_Click));
                    list[list.Count - 1].Name = "CancelAll";
                    list[list.Count - 1].Tag = seatlist;
                }
                #endregion
            }
            else if (st._seatStatusFlag == "2")
            {
                list.Add(cms.Items.Add("解锁", null, this.Menu_Click));
                list[list.Count - 1].Name = "CancelSpecialLock";
                list[list.Count - 1].Tag = seat;
                if (!FrmMain.curUser.HavePermission(Permissions.UnLockTicketSelling))
                    cms.Items[cms.Items.Count - 1].Enabled = false;

            }
            else if (st._seatStatusFlag == "4")
            {
                list.Add(cms.Items.Add("座位信息", null, this.Menu_Click));
                list[list.Count - 1].Name = "SeatInfo";
                list[list.Count - 1].Tag = seat;

                string ticketid = string.Empty;
                bool tf = Flamingo.BLL.Ticket.IsAllowPrintAgain(_szShowplanId + st._seatId, out ticketid);
                if (tf)
                {
                    Flamingo.TemplateCore.TemplatePrintModel PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
                    Flamingo.Entity.Para_TicketPrintInfo model = Flamingo.BLL.Ticket.GetTicketPrintInfo(ticketid);
                    if (model != null)
                    {
                        PrintModel.BarCodeStr = model.BarCode;
                        PrintModel.CheckingType = _szCheckingType;
                        PrintModel.FilmName = _szShowplanName;
                        PrintModel.HallFieldCode = _szHallId;
                        PrintModel.HallName = _HallName;
                        PrintModel.PayType = model.Payment;
                        PrintModel.RowNumber = st._seatRowNumber;
                        PrintModel.SeatNumber = st._seatColumn;
                        PrintModel.SeatNumberStr = st._seatNumber;
                        PrintModel.SellTime = model.SoldTime.ToString("yyyyMMddHHmm");
                        PrintModel.StaffNumber = model.SoldBy;
                        PrintModel.TheaterName = _szTheaterName;
                        PrintModel.TicketDate = _szShowPlanDate;
                        PrintModel.TicketId = model.TicketId;
                        PrintModel.TicketPrice = model.TicketPrice.ToString("0.00");
                        PrintModel.TicketTime = _szShowPlanStartTime;
                        PrintModel.TicketType = model.TicketType;
                        PrintModel.Position = _showPlanPosition;

                        list.Add(cms.Items.Add("补打", null, this.Menu_Click));
                        list[list.Count - 1].Name = "PrintAgain";
                        list[list.Count - 1].Tag = PrintModel;
                        if (!FrmMain.curUser.HavePermission(Permissions.RePrintTicketSelling))
                            cms.Items[cms.Items.Count - 1].Enabled = false;
                    }

                }
            }
            return cms;
        }

        /// <summary>
        /// 设置Menu项点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            switch (item.Name)
            {
                case "Cancel":
                    CancelSelecedSeat((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "SpecialLock":
                    SpecialLock((SeatMaDll.BHSeatControl)item.Tag, 2);
                    break;
                case "CancelSpecialLock":
                    SpecialLock((SeatMaDll.BHSeatControl)item.Tag, 0);
                    break;
                case "CancelAll":
                    CancelSelectedSeatAll((List<SeatMaDll.SeatStatusSim>)item.Tag);
                    break;
                case "SeatInfo":
                    ShowSeatInfo((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "PrintAgain":
                    PrintAgain((Flamingo.TemplateCore.TemplatePrintModel)item.Tag);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        /// <param name="st"></param>
        private void CancelSelecedSeat(SeatMaDll.BHSeatControl seat)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            //取消锁定座位
            int statusNum = Flamingo.BLL.SeatStatus.CancelLock(_szShowplanId, st._seatId, FrmMain.curUser.UserId);
            MouseClickSetStatus(seat, statusNum.ToString());
        }

        /// <summary>
        /// 特殊锁定一个座位
        /// </summary>
        /// <param name="seatstatusid"></param>
        private void SpecialLock(SeatMaDll.BHSeatControl seat, int status)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            bool tf = Flamingo.BLL.Ticket.SpecialLock(_szShowplanId + st._seatId, status, FrmMain.curUser.UserId);
            if (tf == true)
            {
                MouseClickSetStatus(seat, status.ToString());
            }
        }

        /// <summary>
        /// 取消多个选择
        /// </summary>
        /// <param name="seat"></param>
        private void CancelSelectedSeatAll(List<SeatMaDll.SeatStatusSim> seatlist)
        {
            StringBuilder sb_seatstatusids = new StringBuilder();
            foreach (SeatMaDll.SeatStatusSim sss in seatlist)
            {
                sb_seatstatusids.Append(_szShowplanId);
                sb_seatstatusids.Append(sss._seatId);
                sb_seatstatusids.Append("|");
                sss._seatStatusFlag = "0";
            }
            if (sb_seatstatusids.Length > 0)
            {
                sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                bool tf = Flamingo.BLL.SeatStatus.CancelLock(sb_seatstatusids.ToString(), FrmMain.curUser.UserId.ToString());
                if (tf == true)
                {
                    seatChartDisp1.SetSeatsStatus(seatlist);
                }
            }
        }

        /// <summary>
        /// 现实座位信息
        /// </summary>
        /// <param name="seat"></param>
        private void ShowSeatInfo(SeatMaDll.BHSeatControl seat)
        {
            //排号 价格 类型
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            List<DataObject.PO.SeatPo> list = SeatAction.SplitDBObj(st);
            StringBuilder sb = new StringBuilder();
            string seattype = string.Empty;
            switch (list[0].SEATTYPE)
            {
                #region
                case "0":
                    seattype = "单座";
                    break;
                case "1":
                    seattype = "双座";
                    break;
                case "2":
                    seattype = "包厢";
                    break;
                case "3":
                    seattype = "残障";
                    break;
                case "4":
                    seattype = "残护";
                    break;
                case "5":
                    seattype = "不适宜";
                    break;
                case "6":
                    seattype = "停售";
                    break;
                case "7":
                    seattype = "工作席";
                    break;
                case "8":
                    seattype = "特殊";
                    break;
                #endregion
            }
            //string seattype = Flamingo.BLL.Ticket.ToTicketType(list[0].SEATTYPE).ToString();
            string ticketid = _szShowplanId + list[0].SEATID;
            sb.Append(string.Format(Flamingo.BLL.Ticket.GetShowSoldSeatInfo(ticketid), list[0].SEATNUMBER, seattype));
            MessageBox.Show(sb.ToString(), "座位信息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// 补打
        /// </summary>
        /// <param name="seat"></param>
        private void PrintAgain(Flamingo.TemplateCore.TemplatePrintModel PrintModel)
        {
            WinFormUI.SaleTicket.Print.PrintTicket(PrintModel);
            Flamingo.BLL.Ticket.SetPrintStatus(PrintModel.TicketId, 1);
        }

        #endregion

    }
}

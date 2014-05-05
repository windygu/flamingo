using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class DlgGroupControlSetType : Form
    {
        private SeatMaDll.BHSeatControl _bhSeat = null;
        private string _SeatTypeFlag = "0";

        public DlgGroupControlSetType()
        {
            InitializeComponent();
        }
        public DlgGroupControlSetType(SeatMaDll.BHSeatControl bhSeat, string szSeatTypeFlag)
        {
            InitializeComponent();
            _bhSeat = bhSeat;
            _SeatTypeFlag = szSeatTypeFlag;
            
        }

        public void SetListData(SeatMaDll.BHSeatControl bhSeat)
        {
            _bhSeat = bhSeat;
            ReloadBHSeatControl();
        }

        private void DlgMultiSelect_Load(object sender, EventArgs e)
        {
            InitAlluibControlSelected();
            ReloadBHSeatControl();
        }
        private void ReloadBHSeatControl()
        {
            dgv_List.Rows.Clear();
            seatChartDisp1.ClearItems();
            if (_bhSeat == null) return;
            if (_bhSeat.Tag == null) return;
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
                GridFillData(st);
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
                    GridFillData(stB);
                }
            }
            seatChartDisp1.ImportSeatList(list);
            dgv_List.ClearSelection();
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

        private void GridFillData(SeatMaDll.Seat st)
        {
            int nR = this.dgv_List.Rows.Add(new object[] { 
                                            st._seatNumber,
                                            st._seatRowNumber,
                                            st._seatColumn,
                                            st._seatFlag,
                                            st._seatId});

            dgv_List.Rows[nR].Tag = st;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            SetAllItemType();
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }
        private void SetAllItemType()
        {
            List<SeatMaDll.BHSeatControl> list = new List<SeatMaDll.BHSeatControl>();
            list = seatChartDisp1.RetrieveAllItems();//.RetrieveAllItems_BySeatStatus(szSeatStatusFlag);
            foreach (SeatMaDll.BHSeatControl bh in list)
            {
                SeatMaDll.Seat st = (SeatMaDll.Seat)bh.Tag;

                string szSeatTypeFlag = st._seatFlag;
                bool bR = SetType(st._seatId, szSeatTypeFlag);
            }
        }

        
        private bool SetType(string szSeatId, string szSeatTypeFlag)
        {
            if (_bhSeat == null) return false;
            if (_bhSeat.Tag == null) return false;
            SeatMaDll.Seat st = (SeatMaDll.Seat)_bhSeat.Tag;
            if (st._brotherList.Count <= 0)
            {
                if (st._seatId == szSeatId)
                {
                    st._seatFlag = szSeatTypeFlag;
                    _bhSeat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(szSeatTypeFlag);
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
                        if (szSeatTypeFlag == "0")
                            stB._seatFlag = st._seatFlag;
                        else
                            stB._seatFlag = szSeatTypeFlag;
                        return true;
                    }
                }
            }
            return false;
        }

        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            MouseClickSetType(seat, _SeatTypeFlag);
        }
        private void MouseClickSetType(SeatMaDll.BHSeatControl seat, string szSeatTypeFlag)
        {
            seat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(szSeatTypeFlag);
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            st._seatFlag = szSeatTypeFlag;
        }
        private void InitAlluibControlSelected()
        {
            foreach (Control ctl in panel_uidContainer.Controls)
            {
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    UC_ImageButton uib = (UC_ImageButton)ctl;
                    if (uib.Tag == null) continue;
                    if (uib.Tag.ToString() == _SeatTypeFlag)
                    {
                        uib.Selected = true;
                        return;
                    }
                }
            }
        }

        private void ClearAlluibControlSelected()
        {
            foreach (Control ctl in panel_uidContainer.Controls)
            {
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    UC_ImageButton uib = (UC_ImageButton)ctl;
                    uib.Selected = false;
                }
            }
        }

        private void uib_Click(object sender, EventArgs e)
        {
            UC_ImageButton uib = (UC_ImageButton)sender;
            ClearAlluibControlSelected();
            uib.Selected = true;    //!uib.Selected;
            this._SeatTypeFlag = uib.Tag.ToString();

            if (seatChartDisp1._seatCharItemsSelect._listControlSelect.Count > 0)
            {
                bool bHaveGroupItem = false;
                foreach (Control ctl in seatChartDisp1._seatCharItemsSelect._listControlSelect)
                {
                    if (ctl.GetType() == typeof(SeatMaDll.BHSeatControl))
                    {
                        SeatMaDll.BHSeatControl seat = (SeatMaDll.BHSeatControl)ctl;
                        SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;

                        if (st._brotherList.Count <= 0)
                        {
                            st._seatFlag = this._SeatTypeFlag;
                            seat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(this._SeatTypeFlag);
                        }
                        else
                        {
                            bHaveGroupItem = true;
                        }
                    }
                }
                if (bHaveGroupItem)
                    MessageBox.Show("选项中有双座或包厢座，请点击该包厢进行设定！", "系统提示");
            }
        }
    }
}

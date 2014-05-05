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
    public partial class DlgGroupControlSetBlock : Form
    {
        private SeatMaDll.BHSeatControl _bhSeat = null;
        private string _SeatingChartId = "";
        private SimBlock _SimBlockObj = null;
        

        public DlgGroupControlSetBlock()
        {
            InitializeComponent();
        }
        public DlgGroupControlSetBlock(SeatMaDll.BHSeatControl bhSeat, SimBlock simBlockObj)
        {
            InitializeComponent();
            _bhSeat = bhSeat;
            _SimBlockObj = simBlockObj;

            _SeatingChartId = ((SeatMaDll.Seat)bhSeat.Tag)._seatSeatingChartId;
        }

        public void SetListData(SeatMaDll.BHSeatControl bhSeat)
        {
            _bhSeat = bhSeat;
            ReloadBHSeatControl();
        }

        private void DlgMultiSelect_Load(object sender, EventArgs e)
        {
            InitBlock();
            InitAlluibControlSelected();
            ReloadBHSeatControl();
        }

        private void InitBlock()
        {
            List<SimBlock> list = SimBlock.RetrieveItems(_SeatingChartId);
            if (list == null || list.Count <= 0) return;
            uC_ImageButtonPanel1.Clear();
            
            List<ImageButtonItem> listImgButton = new List<ImageButtonItem>();
            foreach (SimBlock sb in list)
            {
                ImageButtonItem ibi = new ImageButtonItem();
                ibi._Img = global::WinFormUI.Properties.Resources.SeatChartFlag;
                ibi._DisplayText = sb._BlockName;
                ibi._BackColor = sb._BgColour;
                ibi._objFlag = sb;
                listImgButton.Add(ibi);
            }
            uC_ImageButtonPanel1.CreateControl(listImgButton);
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
                stNew._IsUsedBackColor = st._IsUsedBackColor;
                stNew._BackColor = st._BackColor;
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
                    stNew._IsUsedBackColor = stB._IsUsedBackColor;
                    stNew._BackColor = stB._BackColor;
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
                                            st._seatBlockId,
                                            st._seatId});

            DataGridViewRow row = this.dgv_List.Rows[nR];
            if (st._BackColor != 0)
                row.DefaultCellStyle.BackColor = Color.FromArgb(st._BackColor & 0x0000ff, (st._BackColor & 0x00ff00) >> 8, (st._BackColor & 0xff0000) >> 16);
            dgv_List.Rows[nR].Tag = st;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            SetAllItemBlock();
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
        private void SetAllItemBlock()
        {
            List<SeatMaDll.BHSeatControl> list = new List<SeatMaDll.BHSeatControl>();
            list = seatChartDisp1.RetrieveAllItems();//.RetrieveAllItems_BySeatStatus(szSeatStatusFlag);
            foreach (SeatMaDll.BHSeatControl bh in list)
            {
                SeatMaDll.Seat st = (SeatMaDll.Seat)bh.Tag;
                string szSeatBlockId = st._seatBlockId;
                int nBgColour = st._BackColor;
                bool bR = SetBlock(st._seatId, szSeatBlockId, nBgColour);
            }
        }

        private bool SetBlock(string szSeatId, string szSeatBlockId, int nBgColour)
        {
            if (_bhSeat == null) return false;
            if (_bhSeat.Tag == null) return false;
            SeatMaDll.Seat st = (SeatMaDll.Seat)_bhSeat.Tag;
            if (st._brotherList.Count <= 0)
            {
                if (st._seatId == szSeatId)
                {
                    st._seatBlockId = szSeatBlockId;
                    st._BackColor = nBgColour;
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
                        stB._seatBlockId = szSeatBlockId;
                        stB._BackColor = nBgColour;
                        return true;
                    }
                }
            }
            return false;
        }

        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            MouseClickSetType(seat, _SimBlockObj);
        }
        private void MouseClickSetType(SeatMaDll.BHSeatControl seat, SimBlock simBlockObj)
        {
            //seat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(szSeatBlockFlag);
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            st._seatBlockId = simBlockObj._BlockId;
            st._BackColor = simBlockObj._BgColour;
            //seat.IsUsedBackColor = true;
        }
        private void InitAlluibControlSelected()
        {
            foreach (Control ctl in uC_ImageButtonPanel1.Controls)
            {
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    UC_ImageButton uib = (UC_ImageButton)ctl;
                    if (uib.Tag == null) continue;
 
                    SimBlock sb = (SimBlock)uib.Tag;

                    if (sb._BlockId == _SimBlockObj._BlockId)
                    {
                        uib.Selected = true;
                        return;
                    }
                }
            }
        }

        private void uC_ImageButtonPanel1_ImageButtonItemClick(object sender, EventArgs e)
        {
            Label ib = (Label)sender;
            SimBlock sb = (SimBlock)ib.Tag;
            _SimBlockObj = sb;
            uC_ImageButtonPanel1.ClearAlluibControlSelected();
            ib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            if (seatChartDisp1._seatCharItemsSelect._listControlSelect.Count > 0)
            {
                foreach (Control ctl in seatChartDisp1._seatCharItemsSelect._listControlSelect)
                {
                    if (ctl.GetType() == typeof(SeatMaDll.BHSeatControl))
                    {
                        SeatMaDll.BHSeatControl seat = (SeatMaDll.BHSeatControl)ctl;
                        MouseClickSetType(seat, _SimBlockObj);
                    }
                }
            }
        }
    }
}

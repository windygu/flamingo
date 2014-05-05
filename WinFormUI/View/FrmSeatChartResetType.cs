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
    public partial class FrmSeatChartResetType : Form
    {
        const int _nSCPanelWidth = 900;
        const int _nSCPanelContainerHeight = 560;
        const int _nSCPanelHeight = 520;

        private SeatMaDll.EditSeatInfo _editSeatInfo = null;
        private SeatMaDll.SeatingChart _seatingChart = null;
        private string _seatTypeFlag = "0";
        public FrmSeatChartResetType()
        {
            InitializeComponent();
            ReSetSeatPanelAttribute();
            SetFormsBgColor(System.Drawing.Color.Gainsboro);
        }
        private void ReSetSeatPanelAttribute()
        {
            tableLayoutPanel_All.Dock = DockStyle.Fill;
            tableLayoutPanel_All.ColumnStyles[2].Width = Screen.PrimaryScreen.Bounds.Width > 1024 ? (_nSCPanelWidth + Screen.PrimaryScreen.Bounds.Width - 1024) : _nSCPanelWidth;
            tableLayoutPanel_All.RowStyles[3].Height = Screen.PrimaryScreen.Bounds.Height > 768 ? (_nSCPanelContainerHeight + Screen.PrimaryScreen.Bounds.Height - 768) : _nSCPanelContainerHeight;
            int nHeight = Screen.PrimaryScreen.Bounds.Height > 768 ? (_nSCPanelHeight + Screen.PrimaryScreen.Bounds.Height - 768) : _nSCPanelHeight;
            seatChartDispScreen1.SetSeatingChartHeight(nHeight);
        }
        private void SetSeatResource()
        {
            SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Red0;
            SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
            SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Red1;
            SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Red2;
            SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Red5;
            SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Red7;
            SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Red6;

            SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Red3;
            SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Red4;
            SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Red8;
            SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
        }

        private void SetSeatResource(string szShape)
        {

            if (szShape == "Red")
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Red0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Red1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Red2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Red5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Red7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Red6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Red3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Red4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Red8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
            else if (szShape == "Blue")
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Blue0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Blue1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Blue2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Blue5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Blue7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Blue6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Blue3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Blue4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Blue8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
            else if (szShape == "Pink")
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Pink0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Pink1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Pink2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Pink5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Pink7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Pink6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Pink3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Pink4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Pink8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
            else if (szShape == "Green")
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Green0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Green1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Green2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Green5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Green7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Green6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Green3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Green4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Green8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
            else if (szShape == "Yellow")
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Yellow0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Yellow1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Yellow2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Yellow5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Yellow7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Yellow6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Yellow3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Yellow4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Yellow8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
            else
            {
                SeatMaDll.SeatResource.ImgEmpty = global::WinFormUI.Properties.Resources.Red0;
                SeatMaDll.SeatResource.ImgDeformity = global::WinFormUI.Properties.Resources.残障席;
                SeatMaDll.SeatResource.ImgDeformityOne = global::WinFormUI.Properties.Resources.Red1;
                SeatMaDll.SeatResource.ImgNotFit = global::WinFormUI.Properties.Resources.Red2;
                SeatMaDll.SeatResource.ImgStoped = global::WinFormUI.Properties.Resources.Red5;
                SeatMaDll.SeatResource.ImgWorked = global::WinFormUI.Properties.Resources.Red7;
                SeatMaDll.SeatResource.ImgSpecial = global::WinFormUI.Properties.Resources.Red6;

                SeatMaDll.SeatResource.ImgLocked = global::WinFormUI.Properties.Resources.Red3;
                SeatMaDll.SeatResource.ImgSpecialLocked = global::WinFormUI.Properties.Resources.Red4;
                SeatMaDll.SeatResource.ImgPrSuccess = global::WinFormUI.Properties.Resources.Red8;
                SeatMaDll.SeatResource.ImgSuccess = null;//global::WinFormUI.Properties.Resources.空位;
            }
        }

        private void FrmSeatChartReset_Load(object sender, EventArgs e)
        {
            seatChartDispScreen1.seatChartDisp1.DisplayRowNumber = true;
            seatChartDispScreen1.SetBottomDisplay_Right("");

            seatChartDispScreen1.seatChartDisp1._LeftOneClick += new SeatMaDll.SelectOneSeatEventHandler(seatChartDisp1__LeftOneClick);

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            SetSeatResource();
            uC_HallInfoSeek1.InitTheaterInfo();
            uC_HallInfoSeek1.cbb_Theater.SelectedIndexChanged += new EventHandler(cbb_Theater_SelectedIndexChanged);
            uC_HallInfoSeek1.cbb_Hall.SelectedIndexChanged += new EventHandler(cbb_Hall_SelectedIndexChanged);
            uC_HallInfoSeek1.cbb_Level.SelectedIndexChanged += new EventHandler(cbb_Level_SelectedIndexChanged);
            if (uC_HallInfoSeek1.cbb_Theater.Items.Count > 0) uC_HallInfoSeek1.cbb_Theater.SelectedIndex = 0;
            InitAlluibControlSelected();
        }

        private void SetFormsBgColor(Color bgColor)
        {
            tableLayoutPanel_All.BackColor = bgColor;
            panel_Top.BackColor = bgColor;
            panel_uidContainer.BackColor = bgColor;
            foreach (Control ctl in panel_uidContainer.Controls)
            {
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    ((UC_ImageButton)ctl).SetBgColor(bgColor);
                }
            }
            //uC_SiteMenu1.SetBgColor(bgColor);
            uC_HallInfoSeek1.SetBgColor(bgColor);

        }

        void cbb_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uC_HallInfoSeek1.cbb_Theater.SelectedItem == null) return;
            if (uC_HallInfoSeek1.cbb_Hall.SelectedItem == null) return;
            if (uC_HallInfoSeek1.cbb_Level.SelectedItem == null) return;

            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;

            SimHall sh = (SimHall)uC_HallInfoSeek1.cbb_Hall.SelectedItem;
            string szHallId = sh._HallId;

            SimHallLevel shl = (SimHallLevel)uC_HallInfoSeek1.cbb_Level.SelectedItem;
            string szLevel = shl._LevelId;

            _editSeatInfo = new SeatMaDll.EditSeatInfo();
            _editSeatInfo._szTheaterName = sti._TheaterName;
            _editSeatInfo._szHallName = sh._HallName;
            _editSeatInfo._szLevelName = shl._LevelId;

            uC_HallInfoSeek1.InitSeatingChart(sh._HallId, Convert.ToInt32(shl._LevelId));

            QueryData();

        }
        void cbb_Hall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (uC_HallInfoSeek1.cbb_Theater.SelectedItem == null) return;
            if (uC_HallInfoSeek1.cbb_Hall.SelectedItem == null) return;
            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            SimHall sh = (SimHall)uC_HallInfoSeek1.cbb_Hall.SelectedItem;

            string szHallId = sh._HallId;
            uC_HallInfoSeek1.InitHallLevel(szTheaterId, szHallId);

        }

        void cbb_Theater_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            uC_HallInfoSeek1.InitHall(szTheaterId);
        }
       
        private void bt_Query_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        public void QueryData()
        {
            seatChartDispScreen1.seatChartDisp1.ClearItems();
            seatChartDispScreen1.seatChartDisp1.Invalidate();
            seatChartDispScreen1.SetBottomDisplay_Right("");

            if (uC_HallInfoSeek1.cbb_SeatingChart.SelectedItem == null) return;
            _seatingChart = (SeatMaDll.SeatingChart)uC_HallInfoSeek1.cbb_SeatingChart.SelectedItem;
            SetSeatResource(_seatingChart.BgColour);

            int nLeftPad = (int)((tableLayoutPanel_All.ColumnStyles[2].Width - _nSCPanelWidth) / 2);
            int nTopPad = (int)((tableLayoutPanel_All.RowStyles[3].Height - _nSCPanelContainerHeight) / 2);

            seatChartDispScreen1.seatChartDisp1.ImportSeatChartWithPad(_seatingChart, nLeftPad, nTopPad);

            int nSeatCount = seatChartDispScreen1.seatChartDisp1.GetAllSeatCount();
            seatChartDispScreen1.SetBottomDisplay_Right("座位数量:" + nSeatCount.ToString());
        }
        
        private void bt_Commit_Click(object sender, EventArgs e)
        {
            SaveData();
        }
       
        private void InitAlluibControlSelected()
        { 
            foreach (Control ctl in panel_uidContainer.Controls)
            {
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    UC_ImageButton uib = (UC_ImageButton)ctl;
                    if (uib.Tag == null) continue;
                    if (uib.Tag.ToString() == _seatTypeFlag)
                    {
                        uib.Selected = true;
                        return;
                    }
                }
            }
        }
        private void uib_Click(object sender, EventArgs e)
        {
            UC_ImageButton uib = (UC_ImageButton)sender;
            ClearAlluibControlSelected();
            uib.Selected = true;    //!uib.Selected;
            this._seatTypeFlag = uib.Tag.ToString();


            if (seatChartDispScreen1.seatChartDisp1._seatCharItemsSelect._listControlSelect.Count > 0)
            {
                bool bHaveGroupItem = false;
                foreach (Control ctl in seatChartDispScreen1.seatChartDisp1._seatCharItemsSelect._listControlSelect)
                {
                    if (ctl.GetType() == typeof(SeatMaDll.BHSeatControl))
                    {
                        SeatMaDll.BHSeatControl seat = (SeatMaDll.BHSeatControl)ctl;
                        SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;

                        if (st._brotherList.Count <= 0)
                        {
                            st._seatFlag = this._seatTypeFlag;
                            seat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(this._seatTypeFlag);
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

        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            if (seat == null) return;
            if (seat.Tag == null) return;
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            if (st == null) return;
            if (st._brotherList.Count <= 0)
            {
                st._seatFlag = this._seatTypeFlag;
                seat.SeatType = SeatMaDll.EditSeatItem.GetControl_ByFlag(this._seatTypeFlag);
            }
            else
            {
                DlgGroupControlSetType dlgMultiSelect = new DlgGroupControlSetType(seat, this._seatTypeFlag);
                dlgMultiSelect.ShowDialog();
                if (dlgMultiSelect.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    seat.Invalidate();
                }
            }
        }

        private void bt_Rotation_Click(object sender, EventArgs e)
        {
            if (seatChartDispScreen1.seatChartDisp1.Rotation == 0)
                seatChartDispScreen1.seatChartDisp1.Rotation = 180;
            else
                seatChartDispScreen1.seatChartDisp1.Rotation = 0;
        }

        private void SaveData()
        {
            if (this.bgwSave.IsBusy) throw new ApplicationException("系统正在执行数据提交操作，请稍后...");
            if (_editSeatInfo == null)
            {
                MessageBox.Show("必须选择一个座位图!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_seatingChart == null)
            {
                MessageBox.Show("必须选择一个座位图!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (uC_HallInfoSeek1.cbb_Theater.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个影院!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (uC_HallInfoSeek1.cbb_Hall.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个影厅!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (uC_HallInfoSeek1.cbb_Level.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个座位图!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            SimHall sh = (SimHall)uC_HallInfoSeek1.cbb_Hall.SelectedItem;
            SimHallLevel shl = (SimHallLevel)uC_HallInfoSeek1.cbb_Level.SelectedItem;

            if (seatChartDispScreen1.seatChartDisp1.Controls.Count <= 0)
            {
                MessageBox.Show("座位图中没有座位，不能导入保存!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Cursor = Cursors.AppStarting;
            this.bgwSave.RunWorkerAsync();
        }
        private void bgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SeatAction.UpdateTypeData(seatChartDispScreen1.seatChartDisp1);
        }

        private void bgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            bool bSaveData = (bool)e.Result;
            string szMsg = "提交数据成功!";
            if (!bSaveData) szMsg = "提交数据失败!";

            MessageBox.Show(szMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}

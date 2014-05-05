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
    public partial class FrmSeatChartResetBlockPrice : Form
    {
        const int _nSCPanelWidth = 900;
        const int _nSCPanelContainerHeight = 560;
        const int _nSCPanelHeight = 520;

        public string _ShowPlanId = "";
        public string _HallId = "";
        public ShowPlanRich _ShowPlanRich = null;
        private SeatMaDll.EditSeatInfo _editSeatInfo = null;
        public SeatMaDll.SeatingChart _seatingChart = null;
        public BlockPriceRich _SimBlockObj = null;
        public FrmSeatChartResetBlockPrice(string szShowPlanId, string szHallId)
        {
            _HallId = szHallId;
            _ShowPlanId = szShowPlanId;
            _ShowPlanRich = ShowPlanRich.RetrieveObj(szShowPlanId);

            InitializeComponent();
            ReSetSeatPanelAttribute();

        }
        private void ReSetSeatPanelAttribute()
        {
            tableLayoutPanel_All.Dock = DockStyle.Fill;
            tableLayoutPanel_All.ColumnStyles[1].Width = Screen.PrimaryScreen.Bounds.Width > 1024 ? (_nSCPanelWidth + Screen.PrimaryScreen.Bounds.Width - 1024) : _nSCPanelWidth;
            tableLayoutPanel_All.RowStyles[4].Height = Screen.PrimaryScreen.Bounds.Height > 768 ? (_nSCPanelContainerHeight + Screen.PrimaryScreen.Bounds.Height - 768) : _nSCPanelContainerHeight;
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

        private void FrmSeatChartResetPrice_Load(object sender, EventArgs e)
        {
            seatChartDispScreen1.seatChartDisp1.DisplayRowNumber = true;
            seatChartDispScreen1.SetBottomDisplay_Right("");
            seatChartDispScreen1.seatChartDisp1._LeftOneClick += new SeatMaDll.SelectOneSeatEventHandler(seatChartDisp1__LeftOneClick);

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            lb_ShowPlan.Text = "";
            if (_ShowPlanRich != null)
            {
                lb_ShowPlan.Text = "放映计划:" + _ShowPlanRich._ObjShowPlan.ShowPlanName + "  " +
                    "影厅:" + _ShowPlanRich._HallName + "  " +
                   "影片:" + _ShowPlanRich._FilmName + "  " +
                   "时间:" + _ShowPlanRich._ObjShowPlan.StartTime.ToString("yyyy-MM-dd hh:mm") + "---" + _ShowPlanRich._ObjShowPlan.EndTime.ToString("yyyy-MM-dd hh:mm");
            }
            SetSeatResource();
            uC_HallInfoSeek1.InitTheaterInfo();
            uC_HallInfoSeek1.cbb_Theater.SelectedIndexChanged += new EventHandler(cbb_Theater_SelectedIndexChanged);
            uC_HallInfoSeek1.cbb_Hall.SelectedIndexChanged += new EventHandler(cbb_Hall_SelectedIndexChanged);
            uC_HallInfoSeek1.cbb_Level.SelectedIndexChanged += new EventHandler(cbb_Level_SelectedIndexChanged);
            if (uC_HallInfoSeek1.cbb_Theater.Items.Count > 0) uC_HallInfoSeek1.cbb_Theater.SelectedIndex = 0;
        }
        private void SetFormsBgColor(Color bgColor)
        {
            tableLayoutPanel_All.BackColor = bgColor;
            panel_Top.BackColor = bgColor;
            panel_block.BackColor = bgColor;
            tableLayoutPanel_block.BackColor = bgColor;
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

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjListWithBlock(sh._HallId, Convert.ToInt32(shl._LevelId));
            uC_HallInfoSeek1.InitSeatingChart(scList);

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
            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            uC_HallInfoSeek1.InitHallWithHallId(szTheaterId, _HallId);
            uC_HallInfoSeek1.cbb_Theater.Enabled = false;
            uC_HallInfoSeek1.cbb_Hall.Enabled = false;
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
            int nTopPad = (int)((tableLayoutPanel_All.RowStyles[4].Height - _nSCPanelContainerHeight) / 2);
            seatChartDispScreen1.seatChartDisp1.ImportSeatChartWithBlockAndPad(_seatingChart, nLeftPad, nTopPad);

            int nSeatCount = seatChartDispScreen1.seatChartDisp1.GetAllSeatCount();
            seatChartDispScreen1.SetBottomDisplay_Right("座位数量:" + nSeatCount.ToString());

            FillBlockPriceControls();
        }
        private void FillBlockPriceControls()
        {
            _SimBlockObj = null;

            uC_ImageButtonVPanel_Block.Clear();
            _SimBlockObj = null;

            if (_seatingChart == null) return;
            List<BlockPriceRich> list = BlockPriceRich.RetrieveObjList(_seatingChart.SeatingChartId, _ShowPlanId);
            if (list == null || list.Count <= 0) return;
            uC_ImageButtonVPanel_Block.Clear();
            List<ImageButtonItem> listImgButton = new List<ImageButtonItem>();
            foreach (BlockPriceRich bpr in list)
            {
                ImageButtonItem ibi = new ImageButtonItem();
                ibi._Img = global::WinFormUI.Properties.Resources.SeatChartFlag;
                string szSinglePrice = bpr._blockPrice.SinglePrice == 0 ? "无" : bpr._blockPrice.SinglePrice.ToString();
                ibi._DisplayText = bpr._block.BlockName + "\r\n价格:" + szSinglePrice;
                ibi._BackColor = bpr._block.Bgcolour;
                ibi._objFlag = bpr;
                listImgButton.Add(ibi);
            }
            uC_ImageButtonVPanel_Block.CreateControl(listImgButton);
        }
        public void ReQueryDataBy(int nIndex)
        {
            _SimBlockObj = null;
            uC_ImageButtonVPanel_Block.Clear();
            _SimBlockObj = null;

            if (_seatingChart == null) return;
            
            List<BlockPriceRich> list = BlockPriceRich.RetrieveObjList(_seatingChart.SeatingChartId, _ShowPlanId);
            if (list == null || list.Count <= 0) return;
            uC_ImageButtonVPanel_Block.Clear();
            List<ImageButtonItem> listImgButton = new List<ImageButtonItem>();
            foreach (BlockPriceRich bpr in list)
            {
                ImageButtonItem ibi = new ImageButtonItem();
                ibi._Img = global::WinFormUI.Properties.Resources.SeatChartFlag;
                string szSinglePrice = bpr._blockPrice.SinglePrice == 0 ? "无" : bpr._blockPrice.SinglePrice.ToString();
                ibi._DisplayText = bpr._block.BlockName + "\r\n价格:" + szSinglePrice;
                ibi._BackColor = bpr._block.Bgcolour;
                ibi._objFlag = bpr;
                listImgButton.Add(ibi);
            }
            uC_ImageButtonVPanel_Block.CreateControl(listImgButton);
        }
        public void ClearItems()
        {
            uC_ImageButtonVPanel_Block.Clear();
            seatChartDispScreen1.seatChartDisp1.ClearItems();
            _SimBlockObj = null;
        }
        
       
        private void uC_ImageButtonVPanel_Block_ImageButtonItemClick(object sender, EventArgs e)
        {
            Label ib = (Label)sender;
            BlockPriceRich sb = (BlockPriceRich)ib.Tag;
            _SimBlockObj = sb;

            DlgCreateBlockPrice dlgCreateBlock = new DlgCreateBlockPrice(this);
            dlgCreateBlock.Text = "设置区域价格";
            dlgCreateBlock.ShowDialog();
            if (dlgCreateBlock.DialogResult == DialogResult.OK)
            {
                if (dlgCreateBlock._bChange)
                {
                    int nIndex = uC_HallInfoSeek1.cbb_SeatingChart.SelectedIndex;
                    cbb_Level_SelectedIndexChanged(null, null);
                    //QueryData();
                    ReQueryDataBy(nIndex);
                }
            }
            else
            {
                if (dlgCreateBlock._bChange)
                {
                    int nIndex = uC_HallInfoSeek1.cbb_SeatingChart.SelectedIndex;
                    cbb_Level_SelectedIndexChanged(null, null);
                    //QueryData();
                    ReQueryDataBy(nIndex);
                }
            }
            
        }

        private void bt_Update_Click(object sender, EventArgs e)
        {
            DlgCreateBlockPrice dlgCreateBlock = new DlgCreateBlockPrice(this);
            dlgCreateBlock.Text = "设置区域价格";
            dlgCreateBlock.ShowDialog();
            if (dlgCreateBlock.DialogResult == DialogResult.OK)
            {
                if (dlgCreateBlock._bChange)
                {
                    int nIndex = uC_HallInfoSeek1.cbb_SeatingChart.SelectedIndex;
                    cbb_Level_SelectedIndexChanged(null, null);
                    //QueryData();
                    ReQueryDataBy(nIndex);
                }
            }
            else
            {
                if (dlgCreateBlock._bChange)
                {
                    int nIndex = uC_HallInfoSeek1.cbb_SeatingChart.SelectedIndex;
                    cbb_Level_SelectedIndexChanged(null, null);
                    //QueryData();
                    ReQueryDataBy(nIndex);
                }
            }
        }

        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
       
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using WinFormUI.TemplateUI;
using Flamingo.Right;
using WinFormUI.SaleTicket;

namespace WinFormUI
{
    public partial class FrmTicket : Form
    {

        const int _nSCPanelWidth = 900;
        const int _nSCPanelContainerHeight = 600;
        const int _nSCPanelHeight = 520;

        private SeatMaDll.SeatingChart _seatingChart = null;
        string _szHallId = string.Empty;
        string _szTheaterId = string.Empty;
        string _szTheaterName = string.Empty;
        string _szCheckingType = string.Empty;
        string _szShowplanId = string.Empty;
        string _szShowPlanDate = string.Empty;
        string _szShowPlanStartTime = string.Empty;
        int _nLevel = 1;

        public SeatBgColorSetup _seatBgColorSetup = null;

        private string filmid;
        private string hallname;
        private string showplanname;
        /// <summary>
        /// 总票价
        /// </summary>
        private float totalprice = 0;
        /// <summary>
        /// 选中的座位 key:ID  value:price
        /// </summary>
        Hashtable htSelectedSeats;
        private bool isShowGroup;
        private string ShowGroupShowPlanIds;
        private string ShowGroupFilmIds;
        private string ShowGroupShowPlanNames;
        private float LowestPrice;
        private string ShowPlanPosition;

        public float GroupPrice = 0;
        public string ShowplanId
        {
            get { return _szShowplanId; }
        }
        
        public FrmTicket(string szShowplanId, string szShowPlanDate, string startTime)
        {
            InitializeComponent();

            ReSetSeatPanelAttribute();
            //_szHallId = szHallId;
            _szShowplanId = szShowplanId;

            _szShowPlanDate = szShowPlanDate;
            _szShowPlanStartTime = startTime;

            BuildSeatBgColorSetup();
            seatChartDispExt1.BackColor = Color.FromArgb(_seatBgColorSetup._BgColor & 0x0000ff, (_seatBgColorSetup._BgColor & 0x00ff00) >> 8, (_seatBgColorSetup._BgColor & 0xff0000) >> 16);
            seatChartDispExt1.SetBgColor(seatChartDispExt1.BackColor);
        }
        private void BuildSeatBgColorSetup()
        {
            string exePath = Environment.CurrentDirectory;
            //System.IO.Path.Combine(Environment.CurrentDirectory, "SystemData");
            string szSystemSetupFileName = System.IO.Path.Combine(exePath, "SeatBgColorSetup.XML");
            if (!File.Exists(szSystemSetupFileName))
            {
                _seatBgColorSetup = new SeatBgColorSetup();
                _seatBgColorSetup.ExportObj(szSystemSetupFileName);

            }
            else
            {
                _seatBgColorSetup = SeatBgColorSetup.ImportObj(szSystemSetupFileName);
            }
        }
        private void ReSetSeatPanelAttribute()
        {
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnStyles[2].Width = Screen.PrimaryScreen.Bounds.Width > 1024 ? (_nSCPanelWidth + Screen.PrimaryScreen.Bounds.Width - 1024) : _nSCPanelWidth;
            tableLayoutPanel1.RowStyles[2].Height = Screen.PrimaryScreen.Bounds.Height > 768 ? (_nSCPanelContainerHeight + Screen.PrimaryScreen.Bounds.Height - 768) : _nSCPanelContainerHeight;
            int nHeight = Screen.PrimaryScreen.Bounds.Height > 768 ? (_nSCPanelHeight + Screen.PrimaryScreen.Bounds.Height - 768) : _nSCPanelHeight;
            seatChartDispExt1.SetSeatingChartHeight(nHeight);
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

        private void FrmTicket_Load(object sender, EventArgs e)
        {
            seatChartDispExt1.seatChartDisp1.DisplayRowNumber = true;
            //seatChartDispExt1.BackColor = Color.Black;
            //seatChartDispExt1.SetBgColor(seatChartDispExt1.BackColor);
            seatChartDispExt1.seatChartDisp1._DoubleClick += new SeatMaDll.SelectOneSeatEventHandler(seatChartDisp1__DoubleClick);
            seatChartDispExt1.seatChartDisp1._LeftOneClick += new SeatMaDll.SelectOneSeatEventHandler(seatChartDisp1__LeftOneClick);
            seatChartDispExt1.seatChartDisp1._RightOneClick += new SeatMaDll.RMSelectOneSeatEventHandler(seatChartDisp1__RightOneClick);
            seatChartDispExt1.seatChartDisp1.MultSelect += new SeatMaDll.SelectMultSeatEventHandler(seatChartDisp1_MultSelect);
            seatChartDispExt1.seatChartDisp1._OnMouseEnter += new SeatMaDll.SelectOneSeatEventHandler(seatChartDisp1__OnMouseEnter);

            bhDirectionBtPanel1.bhDirectionButton_L.Click += new EventHandler(bhDirectionButton_L_Click);
            bhDirectionBtPanel1.bhDirectionButton_R.Click += new EventHandler(bhDirectionButton_R_Click);

            GetShowPlanInfo();
            SetSeatResource();
            SearchData();
            //获得ShowPlanName及影片ID
            ShowSoledMsg();

            seatChartDispExt1.SetTopDisplay_Left(" 操作员:" + FrmMain.curUser.UserName);
            seatChartDispExt1.SetTopDisplay_Center(showplanname);
            seatChartDispExt1.SetTopDisplay_Right(hallname + "    场次:" + _szShowPlanStartTime);


            seatChartDispExt1.SetBottomDisplay_Right(ShowPrice());

            timer_RefrushStatus.Enabled = true;
            
            timer_DateTime.Enabled = true;
            timer_DateTime.Start();

            string timeNumber = DateTime.Now.ToString("HH:mm:ss").Replace(":", "");
            pictureBoxH.Image = Print.Turn(timeNumber.Substring(0, 1));
            pictureBoxHH.Image = Print.Turn(timeNumber.Substring(1, 1));
            pictureBoxM.Image = Print.Turn(timeNumber.Substring(2, 1));
            pictureBoxMM.Image = Print.Turn(timeNumber.Substring(3, 1));

            if (!FrmMain.curUser.HavePermission(Permissions.SaleTicketSelling))
                btnSale.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.MagnifyTicketSelling))
                bt_Zoom.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.RestoreTicketSelling))
                bt_ReFrush.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.RotationSettingTicketSelling))
                bt_Rotation.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.ValidationTicketSelling))
                btnValidateTicket.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.SearchTicketSelling))
                btnQuerySoldInfo.Enabled = false;
            if (!FrmMain.curUser.HavePermission(Permissions.BookSearchTicketSelling))
                btnReservationQuery.Enabled = false;

        }

        void bhDirectionButton_L_Click(object sender, EventArgs e)
        {
            if (_seatingChart == null) return;
            SeatMaDll.SeatingChart seatingChartCurrent = bhDirectionBtPanel1.PreSeatingChart();
            if (seatingChartCurrent == null) return;
            if (seatingChartCurrent.SeatingChartId == _seatingChart.SeatingChartId) return;
            SearchDataBySeatingChart(seatingChartCurrent);
        }
        void bhDirectionButton_R_Click(object sender, EventArgs e)
        {
            if (_seatingChart == null) return;
            SeatMaDll.SeatingChart seatingChartCurrent = bhDirectionBtPanel1.NextSeatingChart();
            if (seatingChartCurrent == null) return;
            if (seatingChartCurrent.SeatingChartId == _seatingChart.SeatingChartId) return;
            SearchDataBySeatingChart(seatingChartCurrent);
        }

        public void ReSetParam(string szShowplanId, string szShowPlanDate, string startTime)
        {
            //_szHallId = szHallId;
            _szShowplanId = szShowplanId;
            _szShowPlanDate = szShowPlanDate;
            _szShowPlanStartTime = startTime;

            GetShowPlanInfo();
            SetSeatResource();
            SearchData();
            //获得ShowPlanName及影片ID
            ShowSoledMsg();

            seatChartDispExt1.SetTopDisplay_Left(" 操作员:" + FrmMain.curUser.UserName);
            seatChartDispExt1.SetTopDisplay_Center(showplanname);
            seatChartDispExt1.SetTopDisplay_Right(hallname + "    场次:" + _szShowPlanStartTime);


            seatChartDispExt1.SetBottomDisplay_Right(ShowPrice());

            timer_RefrushStatus.Enabled = true;
        }
        private void SearchDataBySeatingChart(SeatMaDll.SeatingChart seatingChartTemp)
        {
            if (seatingChartTemp == null) return;

            int nLeftPad = (int)((tableLayoutPanel1.ColumnStyles[2].Width - _nSCPanelWidth) / 2);
            int nTopPad = (int)((tableLayoutPanel1.RowStyles[2].Height - _nSCPanelContainerHeight) / 2);

            _seatingChart = seatingChartTemp;
            SetSeatResource(_seatingChart.BgColour);

            List<SeatMaDll.Seat> list = Seatstatus.RetrieveObjWithSeatingchartAndBlock(_szShowplanId, seatingChartTemp, FrmMain.curUser.UserId, nLeftPad, nTopPad, ref _seatingChart);
            //List<SeatMaDll.Seat> list = Seatstatus.RetrieveObjWithSeatingchartAndBlock(_szShowplanId, _szHallId, _nLevel, FrmMain.curUser.UserId, ref _seatingChart);
            bool bHaveBlockPrice = false;
            FillBlockPriceControls(ref bHaveBlockPrice);

            if (bHaveBlockPrice)
                seatChartDispExt1.seatChartDisp1.ImportSeatListWithTitleAndBlock(list, 0, 0);
            else
                seatChartDispExt1.seatChartDisp1.ImportSeatListWithTitle(list, 0, 0);

            seatChartDispExt1.InitRotation(_seatingChart.Rotation);
        }
        private void SearchData()
        {
            int nLeftPad = (int)((tableLayoutPanel1.ColumnStyles[2].Width - _nSCPanelWidth) / 2);
            int nTopPad = (int)((tableLayoutPanel1.RowStyles[2].Height - _nSCPanelContainerHeight) / 2);

            _seatingChart = new SeatMaDll.SeatingChart();

            List<SeatMaDll.SeatingChart> scList = Seatstatus.RetrieveSeatingChartList(_szHallId, _nLevel);
            SeatMaDll.SeatingChart currentSeatingChart = null;
            if (scList.Count > 0) currentSeatingChart = scList[0];
            bhDirectionBtPanel1.InitData(currentSeatingChart, scList);

            SearchDataBySeatingChart(currentSeatingChart);

        }

        private void FillBlockPriceControls(ref bool bHaveBlockPrice)
        {
            uC_LabelVPanel1.Clear();

            if (_seatingChart == null) return;
            List<BlockPriceRich> listblock = BlockPriceRich.RetrieveObjList(_seatingChart.SeatingChartId, _szShowplanId);
            if (listblock == null || listblock.Count <= 0) return;
            uC_LabelVPanel1.Clear();
            List<ImageButtonItem> listImgButton = new List<ImageButtonItem>();
            foreach (BlockPriceRich bpr in listblock)
            {
                ImageButtonItem ibi = new ImageButtonItem();
                ibi._Img = global::WinFormUI.Properties.Resources.SeatChartFlag;
                string szSinglePrice = bpr._blockPrice.SinglePrice == 0 ? "无" : bpr._blockPrice.SinglePrice.ToString() + "元";
                if (szSinglePrice != "无") bHaveBlockPrice = true;
                ibi._DisplayText = bpr._block.BlockName + "\r\n价格:" + szSinglePrice;
                ibi._BackColor = bpr._block.Bgcolour;
                ibi._objFlag = bpr;
                listImgButton.Add(ibi);
            }
            if (bHaveBlockPrice)
                uC_LabelVPanel1.CreateControl(listImgButton);
        }

        /// <summary>
        /// 获得计划名称 影片ID 厅名称 厅ID 影院ID 影院名称 是否对号入座
        /// </summary>
        private void GetShowPlanInfo()
        {
            string[] info = Flamingo.BLL.ShowPlan.GetShowPlanName(_szShowplanId);
            showplanname = info[0];
            filmid = info[1];
            hallname = info[2];
            _szHallId = info[3];
            _szTheaterId = info[4];
            _szTheaterName = info[5];
            _szCheckingType = info[6];
            isShowGroup = bool.Parse(info[7]);
            ShowGroupShowPlanIds = info[8];
            ShowGroupFilmIds = info[9];
            ShowGroupShowPlanNames = info[10];
            LowestPrice = float.Parse(info[11]);
            ShowPlanPosition = info[12];
            _szShowPlanDate = info[13];
        }

        private string ShowPrice()
        {
            string szShowPrice = string.Empty;
            float[] prices;
            if (isShowGroup)
            {
                prices = Flamingo.BLL.Ticket.GetPriceSubstitute(_szShowplanId, _szTheaterId);
            }
            else
            {
                prices = Flamingo.BLL.Ticket.GetPrice(_szShowplanId);
            }
            szShowPrice = string.Format(@"单座票价：{0}元  双座票价：{1}元  学生票价：{2}元",
                prices[0].ToString("0.00"), prices[1].ToString("0.00"), prices[2].ToString("0.00"));
            return szShowPrice;
        }

        #region 单击 双击判断
        private bool _isFirstClick = true;
        private bool _isDoubleClick = false;
        private int _milliseconds = 0;
        private Rectangle _doubleRec;

        void _doubleClickTimer_Tick(object sender, EventArgs e)
        {
            _milliseconds += 100;
            if (_milliseconds >= SystemInformation.DoubleClickTime)
            {
                _doubleClickTimer.Stop();
                if (_isDoubleClick)
                {
                    //MessageBox.Show("Double Click");
                }
                else
                {
                    // MessageBox.Show("Single Click");
                }
                _isDoubleClick = false;
                _isFirstClick = true;
                _milliseconds = 0;
            }
        }

        void uC_SeatChartPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_isFirstClick)
                {
                    _doubleRec = new Rectangle(e.X - SystemInformation.DoubleClickSize.Width / 2,
                        e.Y - SystemInformation.DoubleClickSize.Height / 2,
                        SystemInformation.DoubleClickSize.Width,
                        SystemInformation.DoubleClickSize.Height);
                    _isFirstClick = false;
                    _doubleClickTimer.Start();
                }
                else
                {
                    if (_doubleRec.Contains(e.Location))
                    {
                        _isDoubleClick = true;
                    }
                }
            }
        }
        #endregion

        //判断座位类型是否允许选中相关
        //One = 0,Two = 1,Box = 2,Deformity = 3,DeformityOne = 4,NotFit = 5,Stoped = 6,Worked = 7,Special = 8,
        //允许选中的座位集合
        string AlowLeftClickSeatType = "0,1,2,3";
        void seatChartDisp1__DoubleClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
        }
        private void seatChartDisp1__LeftOneClick(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            if (st._brotherList.Count <= 0)
            {
                #region 非双座或包厢选中
                List<DataObject.PO.SeatPo> list = SeatAction.SplitDBObj(st);
                //判断座位类型是否允许选中
                if (!AlowLeftClickSeatType.Contains(list[0].SEATTYPE))
                    return;
                if (st._seatStatusFlag == "0")
                {
                    //锁定座位
                    int statusNum = Flamingo.BLL.SeatStatus.Lock(_szShowplanId, list[0].SEATID, FrmMain.curUser.UserId);
                    SeatMaDll.BHSeatControl.BHSeatStatus status = SeatMaDll.BHSeatControl.BHSeatStatus.Empty;

                    switch (statusNum)
                    {
                        case 1:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.Lock;
                            break;
                        case 2:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.PrSuccess;
                            break;
                        case 3:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.SpecialLock;
                            break;
                        case 4:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.Success;
                            break;
                        case 5:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.Selected;
                            break;
                        default:
                            status = SeatMaDll.BHSeatControl.BHSeatStatus.Empty;
                            break;
                    }
                    if (statusNum != -1)
                    {
                        if (statusNum == 5)
                            seatChartDispExt1.seatChartDisp1.IncludeItem(seat);
                        else
                            seatChartDispExt1.seatChartDisp1.ExcludeItem(seat);
                        seatChartDispExt1.seatChartDisp1.SetItemsStatus(seat, status);

                        ShowSoledMsg();
                    }
                }
                #endregion
            }
            else
            {
                #region 双座 包厢
                //if (st._seatFlag != "1")
                //    return;
                bool hasAllSelected = false;
                StringBuilder sb_seatstatusids = new StringBuilder();
                foreach (SeatMaDll.Seat s in st._brotherList)
                {
                    if (s._seatStatusFlag != "0")
                    {
                        hasAllSelected = true;
                        break;
                    }
                    sb_seatstatusids.Append(_szShowplanId);
                    sb_seatstatusids.Append(s._seatId);
                    sb_seatstatusids.Append("|");
                }
                if (hasAllSelected == true)
                    return;
                sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.Lock(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);

                ShowSoledMsg();

                #endregion
            }

        }
        private void seatChartDisp1__RightOneClick(object sender, SeatMaDll.RMSelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;

            string szSeatType = SeatMaDll.SeatChartDisp.GetItemStyle(seat);

            bool bStatusExist0 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "0");
            bool bStatusExist1 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "1");
            bool bStatusExist2 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "2");
            bool bStatusExist3 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "3");
            bool bStatusExist4 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "4");
            bool bStatusExist5 = SeatMaDll.SeatChartDisp.ChechItemStatusExist(seat, "5");

            int n0 = bStatusExist0 ? 1 : 0;
            int n1 = bStatusExist1 ? 1 : 0;
            int n2 = bStatusExist2 ? 1 : 0;
            int n3 = bStatusExist3 ? 1 : 0;
            int n4 = bStatusExist4 ? 1 : 0;
            int n5 = bStatusExist5 ? 1 : 0;
            string szStatusMark = n0.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString() + n5.ToString();
            if ((n0 + n1 + n2 + n3 + n4 + n5) == 1)
            {
                ContextMenuStrip cms = CreateMouseRightMenu(seat, szStatusMark, szSeatType);
                Point p = new Point(MousePosition.X + 5, MousePosition.Y + 5);

                if (szSeatType == "1")
                {
                    cms.Items.Add("展开", null, this.Menu_Click);
                    cms.Items[cms.Items.Count - 1].Name = "双座选择";
                    cms.Items[cms.Items.Count - 1].Tag = seat;
                }
                else if (szSeatType == "2")
                {
                    cms.Items.Add("展开", null, this.Menu_Click);
                    cms.Items[cms.Items.Count - 1].Name = "包厢选择";
                    cms.Items[cms.Items.Count - 1].Tag = seat;
                }
                cms.Show(p);
            }
            else
            {
                string text = "多座选择";
                if (szSeatType == "1")
                    text = "双座选择";
                else if (szSeatType == "2")
                    text = "包厢选择";
                OpenDlgGroupControlSelect(text, seat);
            }
        }
        private void seatChartDisp1_MultSelect(object sender, SeatMaDll.SelectMultSeat_Events e)
        {
            if (e.m_bhSeatList.Count <= 0) return;
            List<DataObject.PO.SeatPo> list = new List<DataObject.PO.SeatPo>();
            List<DataObject.PO.SeatPo> listCurrent = new List<DataObject.PO.SeatPo>();

            StringBuilder sb_seatstatusids = new StringBuilder();
            foreach (SeatMaDll.BHSeatControl bhs in e.m_bhSeatList)
            {
                listCurrent.Clear();
                SeatMaDll.BHSeatControl seat = bhs;
                SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
                listCurrent = SeatAction.SplitDBObj(st);
                if (bhs.SeatStatus == SeatMaDll.BHSeatControl.BHSeatStatus.Empty)
                {
                    foreach (DataObject.PO.SeatPo po in listCurrent)
                    {
                        if (!AlowLeftClickSeatType.Contains(po.SEATTYPE))
                            break;
                        if (po.SEATTYPE == "5")
                            continue;
                        list.Add(po);
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(po.SEATID);
                        sb_seatstatusids.Append("|");
                    }
                }

            }

            //锁定座位
            if (list.Count == 0) return;
            sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);

            List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.Lock(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);

            seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);

            ShowSoledMsg();
        }
        private void OpenDlgGroupControlSelect(string text, SeatMaDll.BHSeatControl seat)
        {
            DlgGroupControlSelect frm = new DlgGroupControlSelect(seat);
            frm.ShowplanId = _szShowplanId;
            frm.Text = text;
            frm.HallId = _szHallId;
            frm.HallName = hallname;
            frm.ShowPlanDate = _szShowPlanDate;
            frm.ShowplanId = _szShowplanId;
            frm.ShowplanName = showplanname;
            frm.ShowPlanStartTime = _szShowPlanStartTime;
            frm.TheaterName = _szTheaterName;
            frm.CheckingType = _szCheckingType;
            frm.ShowPlanPosition = ShowPlanPosition;
            frm.ShowDialog();
            seat.Invalidate();
            ShowSoledMsg();
        }

        private void ResetItemsStatus(SeatMaDll.BHSeatControl seat, SeatMaDll.BHSeatControl.BHSeatStatus seatStatus)
        {
            seat.SeatStatus = seatStatus;

            //if (seat.SeatStatus == SeatMaDll.BHSeatControl.BHSeatStatus.Empty)
            //{
            //    //检查座位状态
            //    MessageBox.Show("检查座位状态");
            //    return seatChartDispExt1.seatChartDisp1.SetItemsStatus(seat, SeatMaDll.BHSeatControl.BHSeatStatus.Lock);
            //}
            //else if (seat.SeatStatus == SeatMaDll.BHSeatControl.BHSeatStatus.Lock)
            //    return seatChartDispExt1.seatChartDisp1.SetItemsStatus(seat, SeatMaDll.BHSeatControl.BHSeatStatus.Success);
            ////else if (seat.SeatStatus == SeatMaDll.BHSeatControl.BHSeatStatus.Success) return false;
            //return false;
        }

        #region 右键 Menu
        /// <summary>
        /// 创建右键Menu项
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateMouseRightMenu(SeatMaDll.BHSeatControl seat, string szStatusMark, string szSeatType)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            List<ToolStripItem> list = new List<ToolStripItem>();
            ContextMenuStrip cms = new ContextMenuStrip();

            int nIndex = szStatusMark.IndexOf("1");
            if (nIndex == -1) return cms;


            if (nIndex == 5)
            {
                list.Add(cms.Items.Add("取消选择", null, this.Menu_Click));
                list[list.Count - 1].Name = "Cancel";
                if (st._seatFlag == "1")
                    list[list.Count - 1].Name = "CancelDouble";
                list[list.Count - 1].Tag = seat;

                list.Add(cms.Items.Add("售出", null, this.btnSale_Click));
                list[list.Count - 1].Name = "Soled";
                list[list.Count - 1].Visible = false;
                if (!FrmMain.curUser.HavePermission(Permissions.SaleTicketSelling))
                    cms.Items[cms.Items.Count - 1].Enabled = false;

                list.Add(cms.Items.Add("锁定", null, this.Menu_Click));
                if (szSeatType == "0")
                {
                    list[list.Count - 1].Name = "SpecialLock";
                    list[list.Count - 1].Tag = st._seatId;
                }
                else
                {
                    list[list.Count - 1].Name = "SpecialLockBox";
                    list[list.Count - 1].Tag = seat;
                }
                if (!FrmMain.curUser.HavePermission(Permissions.LockTicketSelling))
                    cms.Items[cms.Items.Count - 1].Enabled = false;

                List<SeatMaDll.BHSeatControl> listMy = seatChartDispExt1.seatChartDisp1.RetrieveAllItems_BySeatStatus("5");
                if (listMy.Count > 1)
                {
                    list.Add(cms.Items.Add("取消所有选择", null, this.Menu_Click));
                    list[list.Count - 1].Name = "CancelAll";
                    list[list.Count - 1].Tag = listMy;
                }
            }
            else if (nIndex == 2)
            {
                list.Add(cms.Items.Add("解锁", null, this.Menu_Click));
                if (szSeatType == "0")
                {
                    list[list.Count - 1].Name = "CancelSpecialLock";
                    list[list.Count - 1].Tag = st._seatId;
                }
                else
                {
                    list[list.Count - 1].Name = "CancelSpecialLockBox";
                    list[list.Count - 1].Tag = seat;
                }
                if (!FrmMain.curUser.HavePermission(Permissions.UnLockTicketSelling))
                    cms.Items[cms.Items.Count - 1].Enabled = false;
            }
            else if (nIndex == 4)
            {
                if (st._brotherList.Count == 0)
                {
                    list.Add(cms.Items.Add("座位信息", null, this.Menu_Click));
                    list[list.Count - 1].Name = "SeatInfo";
                    list[list.Count - 1].Tag = seat;

                    #region 补打
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
                            PrintModel.FilmName = showplanname;
                            PrintModel.HallFieldCode = _szHallId;
                            PrintModel.HallName = hallname;
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
                            PrintModel.Position = ShowPlanPosition;

                            list.Add(cms.Items.Add("补打", null, this.Menu_Click));
                            list[list.Count - 1].Name = "PrintAgain";
                            list[list.Count - 1].Tag = PrintModel;
                            if (!FrmMain.curUser.HavePermission(Permissions.RePrintTicketSelling))
                                cms.Items[cms.Items.Count - 1].Enabled = false;
                        }

                    }
                    #endregion
                }
                #region 退票
                List<SeatMaDll.Seat> listMultSelected = seatChartDispExt1.seatChartDisp1.RetrieveMultSelectedSeats();

                if (listMultSelected.Count > 0)
                {
                    bool isincludethis = false;
                    foreach (SeatMaDll.Seat s in listMultSelected)
                    {
                        if (s._seatId == st._seatId)
                        {
                            isincludethis = true;
                            break;
                        }
                    }
                    if (isincludethis)
                    {
                        bool isAllowRefund = true;
                        StringBuilder sb_seatstatusids = new StringBuilder();
                        List<SeatMaDll.SeatStatusSim> seatstatuslist = new List<SeatMaDll.SeatStatusSim>();
                        SeatMaDll.SeatStatusSim sss;
                        string[] showgroupspids = ShowGroupShowPlanIds.Split(',');
                        foreach (SeatMaDll.Seat s in listMultSelected)
                        {
                            if (s._seatStatusFlag != "4")
                            {
                                isAllowRefund = false;
                                break;
                            }
                            if (isShowGroup == true)
                            {
                                foreach (string spid in showgroupspids)
                                {
                                    sb_seatstatusids.Append(spid);
                                    sb_seatstatusids.Append(s._seatId);
                                    sb_seatstatusids.Append(",");
                                }
                            }
                            else
                            {
                                sb_seatstatusids.Append(_szShowplanId);
                                sb_seatstatusids.Append(s._seatId);
                                sb_seatstatusids.Append(",");
                            }
                            sss = new SeatMaDll.SeatStatusSim();
                            sss._seatId = s._seatId;
                            sss._seatStatusFlag = "0";
                            seatstatuslist.Add(sss);
                        }

                        if (isAllowRefund)
                        {
                            sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                            list.Add(cms.Items.Add("退票", null, this.Menu_Click));
                            list[list.Count - 1].Name = "Refund";
                            list[list.Count - 1].Tag = new object[] { listMultSelected, sb_seatstatusids.ToString(), seatstatuslist };
                            if (!FrmMain.curUser.HavePermission(Permissions.BatchRefundTicketSelling))
                                cms.Items[cms.Items.Count - 1].Enabled = false;
                        }
                    }
                }
                #endregion

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
                case "Soled":
                    Sale();
                    break;
                case "Cancel":
                    CancelSelecedSeat((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "CancelDouble":
                    CancelSelecedSeat((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "SeatInfo":
                    ShowSeatInfo((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "SoledBy":
                    ShowSoldBy();
                    break;
                case "SoledShow":
                    ShowSoldShow();
                    break;
                case "Consecutive":
                    ShowConsecutive();
                    break;
                case "CancelAll":
                    CancelSelecedSeat();
                    break;
                case "Refund":
                    Refund((object[])item.Tag);
                    break;
                case "SpecialLock":
                    SpecialLock(item.Tag.ToString(), 2);
                    break;
                case "CancelSpecialLock":
                    SpecialLock(item.Tag.ToString(), 0);
                    break;
                case "SpecialLockBox":
                    SpecialLockBox((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "CancelSpecialLockBox":
                    CancelSpecialLockBox((SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "双座选择":
                    OpenDlgGroupControlSelect("双座选择", (SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "包厢选择":
                    OpenDlgGroupControlSelect("包厢选择", (SeatMaDll.BHSeatControl)item.Tag);
                    break;
                case "PrintAgain":
                    PrintAgain((Flamingo.TemplateCore.TemplatePrintModel)item.Tag);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 特殊锁定一个座位
        /// </summary>
        /// <param name="seatstatusid"></param>
        private void SpecialLock(string seatid, int status)
        {
            bool tf = Flamingo.BLL.Ticket.SpecialLock(_szShowplanId + seatid, status, FrmMain.curUser.UserId);
            if (tf == true)
            {
                SeatMaDll.SeatStatusSim sss = new SeatMaDll.SeatStatusSim();
                sss._seatId = seatid;
                sss._seatStatusFlag = status.ToString();
                List<SeatMaDll.SeatStatusSim> list = new List<SeatMaDll.SeatStatusSim>();
                list.Add(sss);
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(list);
            }
            ShowSoledMsg();
        }

        /// <summary>
        /// 锁定双座或包厢
        /// </summary>
        /// <param name="seat"></param>
        private void SpecialLockBox(SeatMaDll.BHSeatControl seat)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            StringBuilder sb_seatstatusids = new StringBuilder();
            foreach (SeatMaDll.Seat s in st._brotherList)
            {
                sb_seatstatusids.Append(_szShowplanId);
                sb_seatstatusids.Append(s._seatId);
                sb_seatstatusids.Append("|");
            }
            sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
            List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.SpecialLockAlot(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);
            seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);
            seat.Invalidate();
            ShowSoledMsg();
        }

        /// <summary>
        /// 解除锁定双座或包厢
        /// </summary>
        /// <param name="seat"></param>
        private void CancelSpecialLockBox(SeatMaDll.BHSeatControl seat)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            StringBuilder sb_seatstatusids = new StringBuilder();
            foreach (SeatMaDll.Seat s in st._brotherList)
            {
                sb_seatstatusids.Append(_szShowplanId);
                sb_seatstatusids.Append(s._seatId);
                sb_seatstatusids.Append("|");
            }
            sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
            List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.CancelSpecialLockAlot(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);
            seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);
            seat.Invalidate();
            ShowSoledMsg();
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        /// <param name="st"></param>
        private void CancelSelecedSeat(SeatMaDll.BHSeatControl seat)
        {
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            if (st._brotherList.Count <= 0)
            {
                List<DataObject.PO.SeatPo> list = SeatAction.SplitDBObj(st);
                //取消锁定座位
                int statusNum = Flamingo.BLL.SeatStatus.CancelLock(_szShowplanId, list[0].SEATID, FrmMain.curUser.UserId);
                SeatMaDll.BHSeatControl.BHSeatStatus status = SeatMaDll.BHSeatControl.BHSeatStatus.Empty;
                seatChartDispExt1.seatChartDisp1.SetItemsStatus(seat, status);
                seatChartDispExt1.seatChartDisp1.ExcludeItem(seat);
            }
            else //if (st._seatFlag == "1")
            {
                if (st._brotherList.Count > 0)
                {
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    List<SeatMaDll.SeatStatusSim> list = new List<SeatMaDll.SeatStatusSim>();
                    SeatMaDll.SeatStatusSim sss;
                    for (int i = 0; i < st._brotherList.Count; i++)
                    {
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(st._brotherList[i]._seatId);
                        sb_seatstatusids.Append("|");
                        sss = new SeatMaDll.SeatStatusSim();
                        sss._seatId = st._brotherList[i]._seatId;
                        sss._seatStatusFlag = "0";
                        list.Add(sss);
                    }
                    //seat.Invalidate();
                    sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                    bool tf = Flamingo.BLL.SeatStatus.CancelLock(sb_seatstatusids.ToString(), FrmMain.curUser.UserId.ToString());
                    if (tf == true)
                    {
                        seatChartDispExt1.seatChartDisp1.SetSeatsStatus(list);
                        seat.Invalidate();
                    }
                }
            }
            ShowSoledMsg();
        }

        /// <summary>
        /// 取消所有选择
        /// </summary>
        /// <param name="st"></param>
        private void CancelSelecedSeat()
        {
            try
            {
                List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                if (listMy.Count > 0)
                {
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    {
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(sss._seatId);
                        sb_seatstatusids.Append("|");
                        sss._seatStatusFlag = "0";
                    }
                    sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                    Flamingo.BLL.SeatStatus.CancelLock(sb_seatstatusids.ToString(), FrmMain.curUser.UserId.ToString());

                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(listMy);
                    ShowSoledMsg();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 显示座位信息
        /// </summary>
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
            string seatstatusids;
            if (isShowGroup == true)
                seatstatusids = ShowGroupShowPlanIds.Replace(",", list[0].SEATID + ",") + list[0].SEATID;
            else
                seatstatusids = _szShowplanId + list[0].SEATID;
            sb.Append(string.Format(Flamingo.BLL.Ticket.GetShowSoldSeatInfo(seatstatusids), list[0].SEATNUMBER, seattype));
            MessageBox.Show(sb.ToString(), "座位信息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// 补打
        /// </summary>
        /// <param name="seat"></param>
        private void PrintAgain(Flamingo.TemplateCore.TemplatePrintModel PrintModel)
        {
            try
            {
                WinFormUI.SaleTicket.Print.PrintTicket(PrintModel);
                Flamingo.BLL.Ticket.SetPrintStatus(PrintModel.TicketId, 1);
            }
            catch
            {
                Flamingo.BLL.Ticket.SetPrintStatus(PrintModel.TicketId, 0);
            }
            finally
            {
                this.Activate();
            }
        }

        /// <summary>
        /// 显示卖出着
        /// </summary>
        private void ShowSoldBy()
        {
            //座位号 售出者
        }

        /// <summary>
        /// 显示售出场次
        /// </summary>
        private void ShowSoldShow()
        {
            //座位号 售出场次
        }

        /// <summary>
        /// 显示连场信息
        /// </summary>
        private void ShowConsecutive()
        {
            //连场 循环场
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="seat"></param>
        private void Refund(object[] obj)
        {
            List<SeatMaDll.Seat> seatlist = (List<SeatMaDll.Seat>)obj[0];
            string seatstatusids = (string)obj[1];
            List<SeatMaDll.SeatStatusSim> seatstatuslist = (List<SeatMaDll.SeatStatusSim>)obj[2];
            bool RefundIsAllow = false;
            string msg = string.Empty;
            RefundIsAllow = Flamingo.BLL.Ticket.RefundIsAllow(_szTheaterId, _szShowplanId, out msg);
            if (RefundIsAllow == false)
            {
                MessageBox.Show(msg);
                return;
            }
            DialogResult dr = MessageBox.Show("确定要退票吗?", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;
            string ticketids = Flamingo.BLL.Ticket.RefundGetTicketIds(seatstatusids);
            bool tf = Flamingo.BLL.Ticket.RefundTicket(ticketids, seatstatusids, FrmMain.curUser.UserId);
            if (tf)
            {
                MessageBox.Show("退票成功");
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatuslist);
            }
            else
            {
                MessageBox.Show("退票失败");
            }
        }

        #endregion

        #region 设置
        private void btnSettings_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = new ContextMenuStrip();

            cms.ShowImageMargin = false;
            Button btn = ((Button)sender);

            cms.Items.Add("打印测试", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "TestPrint";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;

            cms.Items.Add("切票数", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "CutTicketSelling";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.CutTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("旋转", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "RotationSettingTicketSelling";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.RotationSettingTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("背景色设置", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "BgColorSettingTicketSelling";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.BgColorSettingTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("默认设置", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "AutoSetting";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;

            //cms.Items.Add("单击售票", null, Settings_Menu_Click);
            //cms.Items[cms.Items.Count - 1].Name = "SaleWay";
            //cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            //cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;


            cms.Items.Add("重新登录", null, Settings_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "ReLogin";
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;


            Point p = new Point();
            p.X = btn.Location.X + btn.Width;
            p.Y = btn.Location.Y;
            cms.Show(btn.Parent, p, ToolStripDropDownDirection.AboveLeft);
        }
        private void Settings_Menu_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            switch (item.Name)
            {
                case "TestPrint":
                    try
                    {
                        SaleTicket.Print.PrintTest();
                    }
                    catch
                    { }
                    break;
                case "CutTicketSelling":
                    break;
                case "RotationSettingTicketSelling":
                    seatChartDispExt1.Rotation();
                    break;
                case "BgColorSettingTicketSelling":
                     ColorDialog colorDialogBg = new ColorDialog();
                        colorDialogBg.AllowFullOpen = true;
                        colorDialogBg.ShowHelp = true;
                        colorDialogBg.Color = Color.FromArgb(_seatBgColorSetup._BgColor & 0x0000ff, (_seatBgColorSetup._BgColor & 0x00ff00) >> 8, (_seatBgColorSetup._BgColor & 0xff0000) >> 16);
                        if (colorDialogBg.ShowDialog() == DialogResult.OK)
                        {
                            _seatBgColorSetup._BgColor = ColorTranslator.ToWin32(colorDialogBg.Color);
                            string exePath = Environment.CurrentDirectory;
                            //System.IO.Path.Combine(Environment.CurrentDirectory, "SystemData");
                            string szSystemSetupFileName = System.IO.Path.Combine(exePath, "SeatBgColorSetup.XML");                            
                            _seatBgColorSetup.ExportObj(szSystemSetupFileName);
                            seatChartDispExt1.BackColor = Color.FromArgb(_seatBgColorSetup._BgColor & 0x0000ff, (_seatBgColorSetup._BgColor & 0x00ff00) >> 8, (_seatBgColorSetup._BgColor & 0xff0000) >> 16);
                            seatChartDispExt1.SetBgColor(seatChartDispExt1.BackColor);
                            //seatChartDispExt1.Invalidate();
                        }
                                
                    break;
                case "AutoSetting":
                    break;
                case "ReLogin":
                    break;
            }

        }
        #endregion

        #region 售票类型选择 Tag=string
        private void btnSaleType_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = new ContextMenuStrip();

            cms.ShowImageMargin = false;
            //cms.Margin

            Button btn = ((Button)sender);

            cms.Items.Add("零售", null, SaleType_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "RetailPrice";
            cms.Items[cms.Items.Count - 1].Tag = Flamingo.BLL.Ticket.TicketType.零售;
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.RetailTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("学生", null, SaleType_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "StudentPrice";
            cms.Items[cms.Items.Count - 1].Tag = Flamingo.BLL.Ticket.TicketType.学生;
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.StudentsTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("团体", null, SaleType_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "GroupPrice";
            cms.Items[cms.Items.Count - 1].Tag = Flamingo.BLL.Ticket.TicketType.团体;
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.GroupTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("特价", null, SaleType_Menu_Click);
            cms.Items[cms.Items.Count - 1].Name = "DiscountPrice";
            cms.Items[cms.Items.Count - 1].Tag = Flamingo.BLL.Ticket.TicketType.特价;
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.DiscountTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;


            Point p = new Point();
            p.X = btn.Location.X + btn.Width;
            p.Y = btn.Location.Y;
            cms.Show(btn.Parent, p, ToolStripDropDownDirection.AboveLeft);
        }

        private void SaleType_Menu_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            //if ((Flamingo.BLL.Ticket.TicketType)item.Tag == Flamingo.BLL.Ticket.TicketType.团体)
            //{
            //    SaleTicket.frmGroup frm = new SaleTicket.frmGroup();
            //    frm.ShowDialog();
            //    GroupPrice = frm.Price;
            //    if (GroupPrice > 0)
            //    {
            //        btnSaleType.Text = item.Text;
            //        btnSaleType.Tag = item.Tag;
            //        ShowSoledMsg();
            //        SaleTypeToPayType(item);
            //    }
            //}
            if ((Flamingo.BLL.Ticket.TicketType)item.Tag == Flamingo.BLL.Ticket.TicketType.特价)
            {
                SaleTicket.frmDiscountT frm = new SaleTicket.frmDiscountT();
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    GroupPrice = frm.DiscountPrice;
                    btnSaleType.Text = item.Text;
                    btnSaleType.Tag = item.Tag;
                    SaleTypeToPayType(item);
                    ShowSoledMsg();
                }
            }
            else
            {
                btnSaleType.Text = item.Text;
                btnSaleType.Tag = item.Tag;
                SaleTypeToPayType(item);
                ShowSoledMsg();
            }
        }

        /// <summary>
        /// 选择售票类型检索支付方式是否可用
        /// </summary>
        /// <param name="item"></param>
        private void SaleTypeToPayType(ToolStripItem item)
        {
            if (item.Text == "零售")
            {
                if (btnPayType.Text == "支票")
                {
                    btnPayType.Text = "现金";
                    btnPayType.Tag = Flamingo.BLL.Type.PayType.List[Flamingo.BLL.Type.PayType.Paytype.现金].ToString();
                }
            }
            else if (item.Text == "学生")
            {
                if (btnPayType.Text == "支票" || btnPayType.Text == "票券" || btnPayType.Text == "会员卡"
                    || btnPayType.Text == "积分" || btnPayType.Text == "赠票")
                {
                    btnPayType.Text = "现金";
                    btnPayType.Tag = Flamingo.BLL.Type.PayType.List[Flamingo.BLL.Type.PayType.Paytype.现金].ToString();
                }
            }
            else if (item.Text == "团体")
            {
                if (btnPayType.Text == "票券" || btnPayType.Text == "会员卡" || btnPayType.Text == "会员卡支付卡" || btnPayType.Text == "积分"
                    || btnPayType.Text == "赠票")
                {
                    btnPayType.Text = "支票";
                    btnPayType.Tag = Flamingo.BLL.Type.PayType.List[Flamingo.BLL.Type.PayType.Paytype.支票].ToString();
                }
            }
            else if (item.Text == "特价")
            {
                if (btnPayType.Text != "现金")
                {
                    btnPayType.Text = "现金";
                    btnPayType.Tag = Flamingo.BLL.Type.PayType.List[Flamingo.BLL.Type.PayType.Paytype.现金].ToString();
                }
            }
        }

        #endregion

        #region 支付方式选择 Tag=int
        private void btnPayType_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.ShowImageMargin = false;
            Button btn = ((Button)sender);

            foreach (Flamingo.BLL.Type.PayType.Paytype key in Flamingo.BLL.Type.PayType.List.Keys)
            {
                cms.Items.Add(key.ToString(), null, btnPayType_Menu_Click);
                cms.Items[cms.Items.Count - 1].Name = Flamingo.BLL.Type.PayType.List[key].ToString();
                cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
                cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;

                if (!FrmMain.curUser.HavePermission((Permission)Flamingo.BLL.Type.PayType.ListPermissions[key]))
                    cms.Items[cms.Items.Count - 1].Enabled = false;
            }
            Point p = new Point();
            p.X = btn.Location.X + btn.Width;
            p.Y = btn.Location.Y;
            cms.Show(btn.Parent, p, ToolStripDropDownDirection.AboveLeft);
        }

        private void btnPayType_Menu_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            PayTypeToSaleType(item);
            ShowSoledMsg();
        }

        private void PayTypeToSaleType(ToolStripItem item)
        {
            if (item.Text == "支票")
            {
                btnSaleType.Text = "团体";
                btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.团体;
                btnPayType.Text = item.Text;
                btnPayType.Tag = item.Name;
            }
            else if (item.Text.Trim() == "优惠券" || item.Text.Trim() == "兑换券" || item.Text.Trim() == "代用券")
            {
                btnPayType.Text = item.Text;
                btnPayType.Tag = item.Name;
                if (btnSaleType.Text != "零售")
                {
                    btnSaleType.Text = "零售";
                    btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.零售;
                }
            }
            else if (item.Text.Trim() == "会员卡" || item.Text.Trim() == "积分" || item.Text.Trim() == "赠票")
            {
                MessageBox.Show("暂不支持会员功能");
                //btnPayType.Text = item.Text;
                //btnPayType.Tag = item.Name;
                //if (btnSaleType.Text != "零售")
                //{
                //    btnSaleType.Text = "零售";
                //    btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.零售;
                //}
            }
            else if (item.Text.Trim() == "会员卡支付卡")
            {
                MessageBox.Show("暂不支持会员功能");
                //btnPayType.Text = item.Text;
                //btnPayType.Tag = item.Name;
                //if (btnSaleType.Text != "零售" || btnSaleType.Text != "学生")
                //{
                //    btnSaleType.Text = "零售";
                //    btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.零售;
                //}
            }
            else
            {
                btnPayType.Text = item.Text;
                btnPayType.Tag = item.Name;

            }
        }

        #endregion

        #region 其他操作选择

        private void btnOperations_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            Button btn = ((Button)sender);
            cms.ShowImageMargin = false;
            cms.Items.Add("售票", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.SaleTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            //cms.Items.Add("加入购物筐", null, Operatons_Menu_Click);
            //cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            //cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            //if (!FrmMain.curUser.HavePermission(Permissions.))
            //    cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("订票", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.BookTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("订票出票", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.RefundTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("退票", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.RefundTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("锁定", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.LockTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            cms.Items.Add("解锁", null, Operatons_Menu_Click);
            cms.Items[cms.Items.Count - 1].BackgroundImage = global::WinFormUI.Properties.Resources.TicketSale_btnbkimg;
            cms.Items[cms.Items.Count - 1].BackgroundImageLayout = ImageLayout.Stretch;
            if (!FrmMain.curUser.HavePermission(Permissions.UnLockTicketSelling))
                cms.Items[cms.Items.Count - 1].Enabled = false;

            Point p = new Point(btn.Location.X, btn.Location.Y);
            cms.Show(btn.Parent, p, ToolStripDropDownDirection.AboveRight);
        }

        private void Operatons_Menu_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            if (item.Text == "售票")
            {
                Sale();
            }
            else if (item.Text == "退票")
            {
                bool RefundIsAllow = false;
                string msg = string.Empty;
                RefundIsAllow = Flamingo.BLL.Ticket.RefundIsAllow(_szTheaterId, _szShowplanId, out msg);
                if (RefundIsAllow == false)
                {
                    MessageBox.Show(msg);
                    return;
                }
                SaleTicket.frmRefund frm = new SaleTicket.frmRefund();
                frm.ShowPlanName = showplanname;
                frm.ShowPlanHall = hallname;
                frm.ShowPlanDate = _szShowPlanDate;
                frm.ShowPlanStartTime = _szShowPlanStartTime;
                frm.ShowPlanId = _szShowplanId;
                frm.IsShowGroup = isShowGroup;
                frm.ShowGroupShowPlanIds = ShowGroupShowPlanIds;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(frm.SeatList);
                }
            }
            else if (item.Text == "订票")
            {
                #region 订票
                bool isAllow = false;
                string msg = string.Empty;
                isAllow = Flamingo.BLL.Ticket.ReservationIsAllow(_szTheaterId, _szShowplanId, out msg);
                if (isAllow == false)
                {
                    MessageBox.Show(msg);
                    return;
                }
                List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                if (listMy.Count > 0)
                {
                    SaleTicket.frmReservation frm = new SaleTicket.frmReservation();
                    frm.ShowPlanId = _szShowplanId;
                    frm.ShowPlanName = showplanname;
                    frm.ShowPlanHall = hallname;
                    frm.ShowPlanDate = _szShowPlanDate;
                    frm.ShowPlanStartTime = _szShowPlanStartTime;
                    frm.SeatsList = listMy;
                    frm.TicketPrice = htSelectedSeats;
                    frm.TicketType = (Flamingo.BLL.Ticket.TicketType)btnSaleType.Tag;
                    frm.IsShowGroup = isShowGroup;
                    frm.ShowGroupShowPlanIds = ShowGroupShowPlanIds;
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        foreach (SeatMaDll.SeatStatusSim sss in listMy)
                        {
                            sss._seatStatusFlag = "3";
                        }
                        seatChartDispExt1.seatChartDisp1.SetSeatsStatus(listMy);
                        ShowSoledMsg();
                    }
                }
                else
                {
                    MessageBox.Show("请先选择座位");
                }
                #endregion
            }
            else if (item.Text == "锁定")
            {
                #region 锁定
                List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                if (listMy.Count > 0)
                {
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    {
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(sss._seatId);
                        sb_seatstatusids.Append("|");
                    }
                    List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.SpecialLockAlot(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);
                }
                #endregion
            }

            else if (item.Text == "解锁")
            {
                #region 解锁
                //List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                List<SeatMaDll.Seat> listMultSelected = seatChartDispExt1.seatChartDisp1.RetrieveMultSelectedSeats();
                if (listMultSelected.Count > 0)
                {
                    bool isAllowCancelLock = true;
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    foreach (SeatMaDll.Seat s in listMultSelected)
                    {
                        if (s._seatStatusFlag != "2")
                        {
                            isAllowCancelLock = false;
                            break;
                        }
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(s._seatId);
                        sb_seatstatusids.Append("|");
                    }
                    if (!isAllowCancelLock) return;
                    List<SeatMaDll.SeatStatusSim> alllist = Flamingo.BLL.SeatStatus.CancelSpecialLockAlot(sb_seatstatusids, _szShowplanId, FrmMain.curUser.UserId);
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(alllist);
                }
                #endregion
            }
            else if (item.Text == "订票出票")
            {
                #region 订票出票
                SaleTicket.frmReservationValidate frm = new SaleTicket.frmReservationValidate();
                frm.ShowPlanId = _szShowplanId;
                frm.ShowPlanDate = _szShowPlanDate;
                frm.ShowPlanHall = hallname;
                frm.ShowPlanName = showplanname;
                frm.ShowPlanStartTime = _szShowPlanStartTime;
                frm.FilmId = filmid;
                frm.TheaterName = _szTheaterName;
                frm.HallId = _szHallId;
                frm.CheckingType = _szCheckingType;
                frm.ShowGroupFilmIds = ShowGroupFilmIds;
                frm.IsShowGroup = isShowGroup;
                frm.ShowGroupShowPlanIds = ShowGroupShowPlanIds;
                frm.ShowGroupShowPlanNames = ShowGroupShowPlanNames;
                frm.ShowPlanPosition = ShowPlanPosition;
                frm.ShowDialog();
                List<SeatMaDll.SeatStatusSim> seatstatussimlist_cancel = frm.SeatStatusSimList_Cancel;
                List<SeatMaDll.SeatStatusSim> seatstatussimlist_sold = frm.SeatStatusSimList_Sold;
                List<SeatMaDll.SeatStatusSim> seatstatussimlist_soldByvoucher = frm.SeatStatusSimList_SoldByVoucher;

                if (seatstatussimlist_cancel != null)
                {
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_cancel);
                }
                if (seatstatussimlist_sold != null)
                {
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_sold);
                }
                if (seatstatussimlist_soldByvoucher != null)
                {
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_soldByvoucher);
                }
                #endregion
            }
        }

        #endregion

        /// <summary>
        /// 售票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_Click(object sender, EventArgs e)
        {
            Sale();
        }

        private void Sale()
        {
            btnSale.Enabled = false;
            bool isAllowSale = false;
            string ErrorMsg = string.Empty;
            isAllowSale = Flamingo.BLL.Ticket.SaleIsAllow(_szTheaterId, _szShowplanId, out ErrorMsg);
            if (isAllowSale == false)
            {
                MessageBox.Show(ErrorMsg);
                btnSale.Enabled = true;
                return;
            }
            List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
            if (listMy.Count > 3 && btnPayType.Text == "会员卡")
            {
                MessageBox.Show("会员卡只能支付3张影票");
                btnSale.Enabled = true;
                return;
            }
            if (listMy.Count > 0)// && totalprice > 0
            {
                #region 获得共同数据
                //确定售票类型
                string tickettype = "0";
                Flamingo.BLL.Ticket.TicketType ticketType = Flamingo.BLL.Ticket.TicketType.零售;
                if (btnSaleType.Tag != null)
                {
                    tickettype = Flamingo.BLL.Ticket.ToTicketType(((Flamingo.BLL.Ticket.TicketType)btnSaleType.Tag)).ToString();
                    ticketType = ((Flamingo.BLL.Ticket.TicketType)btnSaleType.Tag);
                }
                //支付方式
                int pmid = Int32.Parse(btnPayType.Tag == null ? "1" : btnPayType.Tag.ToString());
                //总金额
                //float tp = totalprice;
                //用户
                string userid = FrmMain.curUser.UserId.ToString();
                //模版
                int templateid = FrmMain.template == null ? 1 : FrmMain.template.TemplateId;
                #endregion

                #region 支票支付
                bool isContinue = false;
                if (btnSaleType.Text == "团体")
                {
                    #region 支票支付
                    if (pmid == 3)
                    {
                        SaleTicket.frmDebt frm = new SaleTicket.frmDebt(lblShowSoledMsg);
                        frm.FilmName = showplanname;
                        frm.HallName = hallname;
                        frm.ShowPlanDate = _szShowPlanDate;
                        frm.StartTime = _szShowPlanStartTime;
                        frm.ShowPlanId = _szShowplanId;

                        frm.TicketCount = listMy.Count;
                        frm.TicketType = ticketType.ToString();
                        frm.Price = GroupPrice;
                        frm.Total = totalprice;
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            GroupPrice = frm.Price;
                            totalprice = GroupPrice * listMy.Count;
                            isContinue = true;
                            if (GroupPrice <= 0)
                                isContinue = false;
                        }
                    }
                    else
                    {
                        SaleTicket.frmGroup frm = new SaleTicket.frmGroup(_szShowplanId);
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            GroupPrice = frm.Price;
                            totalprice = GroupPrice * listMy.Count;
                            isContinue = true;
                            if (GroupPrice <= 0)
                                isContinue = false;
                        }
                        else
                        {
                            //MessageBox.Show("未设置团体票票价 售票退出");
                        }
                    }
                    #endregion
                }
                else
                {
                    isContinue = true;
                }
                if (isContinue == false)
                {
                    btnSale.Enabled = true;
                    return;
                }
                #endregion

                #region 获得每张票数据
                //影票ID  GUID
                StringBuilder sb_ticketid = new StringBuilder();
                StringBuilder sb_seatids = new StringBuilder();
                StringBuilder sb_tickettype = new StringBuilder();
                StringBuilder sb_ticketprice = new StringBuilder();
                StringBuilder sb_barcode = new StringBuilder();
                //票券用参数
                StringBuilder sb_seatnumber = new StringBuilder();
                //打印信息Flamingo.TemplateCore.TemplatePrintModel 
                List<Flamingo.TemplateCore.TemplatePrintModel> PrintModels = new List<Flamingo.TemplateCore.TemplatePrintModel>();
                Flamingo.TemplateCore.TemplatePrintModel PrintModel;
                bool vouchercontinue = true;

                List<object> voucherObj = new List<object>();
                List<Flamingo.Entity.Para_Voucher> allVoucher = new List<Flamingo.Entity.Para_Voucher>();
                totalprice = 0;
                foreach (SeatMaDll.SeatStatusSim sss in listMy)
                {
                    PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
                    sb_seatnumber.Append(sss._seatNumber);
                    sb_seatnumber.Append("|");
                    PrintModel.SeatNumberStr = sss._seatNumber;

                    PrintModel.SeatNumber = sss._seatColumn;
                    PrintModel.RowNumber = sss._seatRowNumber;

                    //票ID
                    PrintModel.TicketId = Guid.NewGuid().ToString();
                    sb_ticketid.Append(PrintModel.TicketId);
                    sb_ticketid.Append("|");

                    //座位ID
                    sb_seatids.Append(sss._seatId.Trim());
                    sb_seatids.Append("|");

                    //条形码 barcode
                    PrintModel.BarCodeStr = _szShowplanId + sss._seatId; //Flamingo.BLL.Ticket.CreateBarCode(11);
                    sb_barcode.Append(PrintModel.BarCodeStr);
                    sb_barcode.Append("|");


                    //售票类型
                    if (ticketType == Flamingo.BLL.Ticket.TicketType.零售)
                    {
                        if (sss._seatType == "0")
                            sb_tickettype.Append("1");
                        else if (sss._seatType == "1")
                            sb_tickettype.Append("2");
                        else if (sss._seatType == "2")
                            sb_tickettype.Append("3");
                    }
                    else if (ticketType == Flamingo.BLL.Ticket.TicketType.团体)
                    {
                        sb_tickettype.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体).ToString());
                        htSelectedSeats = new Hashtable();
                        htSelectedSeats.Add(sss._seatId.Trim(), GroupPrice.ToString());
                    }
                    else if (ticketType == Flamingo.BLL.Ticket.TicketType.特价)
                    {
                        sb_tickettype.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体).ToString());
                        htSelectedSeats = new Hashtable();
                        htSelectedSeats.Add(sss._seatId.Trim(), GroupPrice.ToString());
                    }
                    else
                    {
                        sb_tickettype.Append(tickettype);
                    }
                    sb_tickettype.Append("|");
                    //-
                    PrintModel.TicketType = btnSaleType.Text;
                    PrintModel.PayType = btnPayType.Text;
                    PrintModel.Position = ShowPlanPosition;

                    //票价
                    sb_ticketprice.Append(htSelectedSeats[sss._seatId.Trim()]);
                    sb_ticketprice.Append("|");

                    PrintModel.TicketPrice = float.Parse(htSelectedSeats[sss._seatId.Trim()].ToString()).ToString("0.00") + "元";
                    totalprice += float.Parse(htSelectedSeats[sss._seatId.Trim()].ToString());
                    //票版其他信息
                    if (isShowGroup == true)
                        PrintModel.FilmName = ShowGroupShowPlanNames.Replace(',', '+');
                    else
                        PrintModel.FilmName = showplanname;
                    PrintModel.CheckingType = _szCheckingType;
                    PrintModel.HallFieldCode = _szHallId;
                    PrintModel.HallName = hallname;
                    PrintModel.SellTime = DateTime.Now.ToString("yyyyMMddHHmm"); ;
                    PrintModel.StaffNumber = FrmMain.curUser.EmployeeId;
                    PrintModel.TheaterName = _szTheaterName;
                    PrintModel.TicketDate = _szShowPlanDate;
                    PrintModel.TicketTime = _szShowPlanStartTime;

                    PrintModels.Add(PrintModel);

                    #region 票券售票
                    if (btnPayType.Text == "优惠券" || btnPayType.Text == "兑换券" || btnPayType.Text == "代用券")
                    {
                        SaleTicket.frmVoucher frm = new SaleTicket.frmVoucher(float.Parse(htSelectedSeats[sss._seatId.Trim()].ToString()), Flamingo.BLL.Type.PayType.ToPayType(btnPayType.Text));
                        frm.AllVoucher = allVoucher;
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            Flamingo.Entity.Para_VoucherAdd model = new Flamingo.Entity.Para_VoucherAdd(frm.Voucherlist);
                            if (btnPayType.Text == "优惠券")
                                model.VoucherTypeId = 3;
                            else if (btnPayType.Text == "兑换券")
                                model.VoucherTypeId = 1;
                            else if (btnPayType.Text == "代用券")
                                model.VoucherTypeId = 2;
                            #region 票券连场
                            if (isShowGroup == true)
                            {
                                StringBuilder sb_showplanids = new StringBuilder();
                                StringBuilder sb_filmids = new StringBuilder();
                                StringBuilder sb_seatstatusids = new StringBuilder();
                                sb_seatnumber.Clear();
                                sb_ticketid.Clear();
                                sb_seatids.Clear();
                                sb_tickettype.Clear();
                                sb_ticketprice.Clear();

                                string[] spids = ShowGroupShowPlanIds.Split(',');
                                string[] fids = ShowGroupFilmIds.Split(',');
                                int count = listMy.Count * spids.Length;


                                for (int i = 0; i < spids.Length; i++)
                                {
                                    sb_showplanids.Append(spids[i]);
                                    sb_showplanids.Append("|");

                                    sb_filmids.Append(fids[i]);
                                    sb_filmids.Append("|");

                                    sb_seatstatusids.Append(spids[i] + sss._seatId);
                                    sb_seatstatusids.Append("|");

                                    sb_seatnumber.Append(sss._seatNumber);
                                    sb_seatnumber.Append("|");

                                    //票ID
                                    sb_ticketid.Append(Guid.NewGuid().ToString());
                                    sb_ticketid.Append("|");

                                    //座位ID
                                    sb_seatids.Append(sss._seatId.Trim());
                                    sb_seatids.Append("|");

                                    //售票类型
                                    sb_tickettype.Append("6");
                                    sb_tickettype.Append("|");

                                    //票价
                                    sb_ticketprice.Append(htSelectedSeats[spids[i] + sss._seatId.Trim()]);
                                    sb_ticketprice.Append("|");
                                }
                                if (sb_seatids.Length > 0)
                                {
                                    sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                                    sb_showplanids.Remove(sb_showplanids.Length - 1, 1);
                                    sb_filmids.Remove(sb_filmids.Length - 1, 1);
                                    sb_seatnumber.Remove(sb_seatnumber.Length - 1, 1);
                                    sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                                    sb_seatids.Remove(sb_seatids.Length - 1, 1);
                                    sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                                    sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                                }

                                model.GroupCount = count;
                                model.GroupFilmId = sb_filmids.ToString();
                                model.GroupSeatStatusId = sb_seatstatusids.ToString();
                                model.GroupShowPlanId = sb_showplanids.ToString();
                                model.GroupTicketId = sb_ticketid.ToString();
                                model.GroupTicketPrice = sb_ticketprice.ToString();
                                model.GroupTicketType = sb_tickettype.ToString();
                                voucherObj.Add(model);

                            }
                            #endregion 票券连场
                            #region 票券非连场
                            else
                            {
                                model.BarCode = PrintModel.BarCodeStr;
                                model.FilmId = filmid;
                                model.PaymentMethodId = Flamingo.BLL.Type.PayType.ToPayType(frm.VoucherType);
                                model.SeatId = sss._seatId;
                                model.ShowPlanId = _szShowplanId;
                                model.SoldBy = FrmMain.curUser.UserId; //user lzz
                                model.TemplateId = templateid;
                                model.TicketPrice = float.Parse(htSelectedSeats[sss._seatId].ToString());//frm.OutTicketPrice;
                                model.TicketType = Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体);
                                model.TicketId = PrintModel.TicketId;

                                voucherObj.Add(model);
                            }
                            #endregion 票券非连场
                        }
                        else
                        {
                            voucherObj.Clear();
                            vouchercontinue = false;
                            break;
                        }
                    }
                    #endregion 票券售票
                }
                if (vouchercontinue == false)
                {
                    btnSale.Enabled = true;
                    return;
                }
                if (sb_seatids.Length > 0)
                {
                    sb_seatnumber.Remove(sb_seatnumber.Length - 1, 1);
                    sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                    sb_seatids.Remove(sb_seatids.Length - 1, 1);
                    sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                    sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                    sb_barcode.Remove(sb_barcode.Length - 1, 1);
                }
                #endregion

                #region 售票

                #region 票券售票
                bool soldResult = false;
                if (btnPayType.Text == "优惠券" || btnPayType.Text == "兑换券" || btnPayType.Text == "代用券")
                {
                    #region 多个...
                    if (isShowGroup == true)
                    {
                        if (btnPayType.Text == "代用券")
                        {
                            foreach (Flamingo.Entity.Para_VoucherAdd o in voucherObj)
                            {
                                soldResult = Flamingo.BLL.Ticket.VoucherSubstituteSaleGroup(o.VoucherBatchIds,
                                        o.GroupTicketId, o.GroupTicketPrice, FrmMain.curUser.UserId, o.GroupSeatStatusId,
                                       o.GroupTicketType, pmid, templateid, o.GroupShowPlanId, o.FilmId, o.GroupCount);
                            }
                        }
                        else
                        {
                            foreach (Flamingo.Entity.Para_VoucherAdd o in voucherObj)
                            {
                                soldResult = Flamingo.BLL.Ticket.VoucherSaleGroup(o.VoucherIds, o.Prices, o.BarCodes, o.VoucherTypeId,
                                    o.VoucherBatchIds,
                                        o.GroupTicketId, o.GroupTicketPrice, FrmMain.curUser.UserId, o.GroupSeatStatusId,
                                       o.GroupTicketType, pmid, templateid, o.GroupShowPlanId, o.FilmId, o.GroupCount);
                            }
                        }
                    }
                    else
                    {
                        if (btnPayType.Text == "代用券")
                        {
                            foreach (object o in voucherObj)
                            {
                                soldResult = Flamingo.BLL.Ticket.VoucherSubstituteSale((Flamingo.Entity.Para_VoucherAdd)o);
                            }
                        }
                        else
                        {
                            foreach (object o in voucherObj)
                            {
                                soldResult = Flamingo.BLL.Ticket.VoucherSale((Flamingo.Entity.Para_VoucherAdd)o);
                            }
                        }
                    }
                    #endregion
                    #region 单个
                    //if (listMy.Count > 1)
                    //{
                    //    MessageBox.Show(string.Format("使用{0}支付,只能请选择一个座位", btnPayType.Text));
                    //    btnSale.Enabled = true;
                    //    return;
                    //}

                    //SaleTicket.frmVoucher frm = new SaleTicket.frmVoucher(float.Parse(htSelectedSeats[sb_seatids.ToString()].ToString()), Flamingo.BLL.Type.PayType.ToPayType(btnPayType.Text));
                    //if (frm.ShowDialog() == DialogResult.Yes)
                    //{
                    //    Flamingo.Entity.Para_VoucherAdd model = new Flamingo.Entity.Para_VoucherAdd(frm.Voucherlist);
                    //    if (btnPayType.Text == "优惠券")
                    //        model.VoucherTypeId = 3;
                    //    else if (btnPayType.Text == "兑换券")
                    //        model.VoucherTypeId = 1;
                    //    else if (btnPayType.Text == "代用券")
                    //        model.VoucherTypeId = 2;
                    //    if (isShowGroup == true)
                    //    {
                    //        StringBuilder sb_showplanids = new StringBuilder();
                    //        StringBuilder sb_filmids = new StringBuilder();
                    //        StringBuilder sb_seatstatusids = new StringBuilder();
                    //        sb_seatnumber.Clear();
                    //        sb_ticketid.Clear();
                    //        sb_seatids.Clear();
                    //        sb_tickettype.Clear();
                    //        sb_ticketprice.Clear();

                    //        string[] spids = ShowGroupShowPlanIds.Split(',');
                    //        string[] fids = ShowGroupFilmIds.Split(',');
                    //        int count = listMy.Count * spids.Length;

                    //        foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    //        {
                    //            for (int i = 0; i < spids.Length; i++)
                    //            {
                    //                sb_showplanids.Append(spids[i]);
                    //                sb_showplanids.Append("|");

                    //                sb_filmids.Append(fids[i]);
                    //                sb_filmids.Append("|");

                    //                sb_seatstatusids.Append(spids[i] + sss._seatId);
                    //                sb_seatstatusids.Append("|");

                    //                sb_seatnumber.Append(sss._seatNumber);
                    //                sb_seatnumber.Append("|");

                    //                //票ID
                    //                sb_ticketid.Append(Guid.NewGuid().ToString());
                    //                sb_ticketid.Append("|");

                    //                //座位ID
                    //                sb_seatids.Append(sss._seatId.Trim());
                    //                sb_seatids.Append("|");

                    //                //售票类型
                    //                sb_tickettype.Append("6");
                    //                sb_tickettype.Append("|");

                    //                //票价
                    //                sb_ticketprice.Append(htSelectedSeats[spids[i] + sss._seatId.Trim()]);
                    //                sb_ticketprice.Append("|");
                    //            }
                    //        }
                    //        if (sb_seatids.Length > 0)
                    //        {
                    //            sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                    //            sb_showplanids.Remove(sb_showplanids.Length - 1, 1);
                    //            sb_filmids.Remove(sb_filmids.Length - 1, 1);
                    //            sb_seatnumber.Remove(sb_seatnumber.Length - 1, 1);
                    //            sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                    //            sb_seatids.Remove(sb_seatids.Length - 1, 1);
                    //            sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                    //            sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                    //        }
                    //        if (btnPayType.Text == "代用券")
                    //        {
                    //            soldResult = Flamingo.BLL.Ticket.VoucherSubstituteSaleGroup(model.VoucherBatchIds,
                    //                 sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                    //                sb_tickettype.ToString(), pmid, templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count);
                    //        }
                    //        else
                    //        {
                    //            soldResult = Flamingo.BLL.Ticket.VoucherSaleGroup(model.VoucherIds, model.Prices, model.BarCodes, model.VoucherTypeId,
                    //                model.VoucherBatchIds,
                    //                sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                    //                sb_tickettype.ToString(), pmid, templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        model.BarCode = sb_barcode.ToString();
                    //        model.FilmId = filmid;
                    //        model.PaymentMethodId = Flamingo.BLL.Type.PayType.ToPayType(frm.VoucherType);
                    //        model.SeatId = sb_seatids.ToString();
                    //        model.ShowPlanId = _szShowplanId;
                    //        model.SoldBy = FrmMain.curUser.UserId; //user lzz
                    //        model.TemplateId = templateid;
                    //        model.TicketPrice = float.Parse(htSelectedSeats[sb_seatids.ToString()].ToString());//frm.OutTicketPrice;
                    //        model.TicketType = Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体);
                    //        model.TicketId = sb_ticketid.ToString();
                    //        model.VoucherTypeId = Flamingo.BLL.Type.PayType.ToPayType(frm.VoucherType);

                    //        if (btnPayType.Text == "代用券")
                    //        {
                    //            soldResult = Flamingo.BLL.Ticket.VoucherSubstituteSale(model);
                    //        }
                    //        else
                    //        {
                    //            soldResult = Flamingo.BLL.Ticket.VoucherSale(model);

                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    btnSale.Enabled = true;
                    //    return;
                    //}
                    #endregion 单个
                }
                #endregion
                #region 连场售票
                else if (isShowGroup == true)
                {
                    StringBuilder sb_showplanids = new StringBuilder();
                    StringBuilder sb_filmids = new StringBuilder();
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    sb_seatnumber.Clear();
                    sb_ticketid.Clear();
                    sb_seatids.Clear();
                    sb_tickettype.Clear();
                    sb_ticketprice.Clear();

                    string[] spids = ShowGroupShowPlanIds.Split(',');
                    string[] fids = ShowGroupFilmIds.Split(',');
                    int count = listMy.Count * spids.Length;
                    if (ticketType == Flamingo.BLL.Ticket.TicketType.团体 || ticketType == Flamingo.BLL.Ticket.TicketType.特价)
                    {
                        GroupPrice = GroupPrice / spids.Length;
                    }
                    totalprice = 0;
                    foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    {
                        for (int i = 0; i < spids.Length; i++)
                        {
                            sb_showplanids.Append(spids[i]);
                            sb_showplanids.Append("|");

                            sb_filmids.Append(fids[i]);
                            sb_filmids.Append("|");

                            sb_seatstatusids.Append(spids[i] + sss._seatId);
                            sb_seatstatusids.Append("|");

                            sb_seatnumber.Append(sss._seatNumber);
                            sb_seatnumber.Append("|");

                            //票ID
                            sb_ticketid.Append(Guid.NewGuid().ToString());
                            sb_ticketid.Append("|");

                            //座位ID
                            sb_seatids.Append(sss._seatId.Trim());
                            sb_seatids.Append("|");

                            //售票类型
                            if (ticketType == Flamingo.BLL.Ticket.TicketType.零售)
                            {
                                if (sss._seatType == "0")
                                    sb_tickettype.Append("1");
                                else if (sss._seatType == "1")
                                    sb_tickettype.Append("2");
                                else if (sss._seatType == "2")
                                    sb_tickettype.Append("3");
                            }
                            else if (ticketType == Flamingo.BLL.Ticket.TicketType.团体)
                            {
                                sb_tickettype.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体).ToString());
                                htSelectedSeats = new Hashtable();
                                htSelectedSeats.Add(spids[i] + sss._seatId.Trim(), GroupPrice.ToString());
                            }
                            else if (ticketType == Flamingo.BLL.Ticket.TicketType.特价)
                            {
                                sb_tickettype.Append(Flamingo.BLL.Ticket.ToTicketType(Flamingo.BLL.Ticket.TicketType.团体).ToString());
                                htSelectedSeats = new Hashtable();
                                htSelectedSeats.Add(spids[i] + sss._seatId.Trim(), GroupPrice.ToString());
                            }
                            else
                            {
                                sb_tickettype.Append(tickettype);
                            }
                            sb_tickettype.Append("|");

                            //票价
                            sb_ticketprice.Append(htSelectedSeats[spids[i] + sss._seatId.Trim()]);
                            sb_ticketprice.Append("|");
                            totalprice += float.Parse(htSelectedSeats[spids[i] + sss._seatId.Trim()].ToString());
                        }
                    }
                    if (sb_seatids.Length > 0)
                    {
                        sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                        sb_showplanids.Remove(sb_showplanids.Length - 1, 1);
                        sb_filmids.Remove(sb_filmids.Length - 1, 1);
                        sb_seatnumber.Remove(sb_seatnumber.Length - 1, 1);
                        sb_ticketid.Remove(sb_ticketid.Length - 1, 1);
                        sb_seatids.Remove(sb_seatids.Length - 1, 1);
                        sb_tickettype.Remove(sb_tickettype.Length - 1, 1);
                        sb_ticketprice.Remove(sb_ticketprice.Length - 1, 1);
                    }
                    if (totalprice > 0)
                    {
                        soldResult = Flamingo.BLL.Ticket.SaleSubstitute(sb_ticketid.ToString(), sb_ticketprice.ToString(), FrmMain.curUser.UserId, sb_seatstatusids.ToString(),
                            sb_tickettype.ToString(), pmid, templateid, sb_showplanids.ToString(), sb_filmids.ToString(), count);
                    }
                    else
                    {
                        MessageBox.Show("票价不能为0元");
                    }
                }
                #endregion
                #region 非连场售票
                else
                {
                    if (LowestPrice * sb_ticketid.ToString().Split('|').Length < totalprice)
                    {
                        soldResult = Flamingo.BLL.Ticket.Sale(sb_ticketid.ToString(), _szShowplanId, sb_seatids.ToString(), pmid,
                        totalprice, sb_tickettype.ToString(), sb_ticketprice.ToString(), sb_barcode.ToString(), userid, templateid, filmid);
                    }
                    else if (totalprice == 0)
                    {
                        MessageBox.Show("票价不能低于0元");
                    }
                    else
                    {
                        MessageBox.Show("票价不能低于最低票价" + LowestPrice.ToString("0.00"));
                    }
                }
                #endregion
                #region 售票结束
                if (soldResult == true)
                {
                    int i = 0;
                    StringBuilder sb_failedticketids = new StringBuilder();
                    foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    {
                        #region 改变座位状态
                        sss._seatStatusFlag = "4";
                        #endregion
                        #region 打印影票
                        try
                        {
                            WinFormUI.SaleTicket.Print.PrintTicket(PrintModels[i]);
                        }
                        catch
                        {
                            //记录出票失败
                            //Flamingo.BLL.Ticket.SetPrintStatus(PrintModels[i].TicketId, 0);
                            sb_failedticketids.Append(PrintModels[i].TicketId);
                            sb_failedticketids.Append(",");
                        }
                        finally
                        {
                            this.Activate();
                        }
                        i++;
                        #endregion
                    }
                    if (sb_failedticketids.Length > 0)
                    {
                        sb_failedticketids.Remove(sb_failedticketids.Length - 1, 1);
                        Flamingo.BLL.Ticket.SetPrintStatus(sb_failedticketids, 0);
                    }
                    seatChartDispExt1.seatChartDisp1.SetSeatsStatus(listMy);
                    //售票成功 清空相关信息(票价信息,售票类型按钮,支付方式按钮)
                    lblShowSoledMsg.Text = "票种：零售  数量：0张  总金额：0元  支付方式：现金  切票数：1  ";
                    btnPayType.Text = "现金";
                    btnPayType.Tag = Flamingo.BLL.Type.PayType.List[Flamingo.BLL.Type.PayType.Paytype.现金].ToString();

                    btnSaleType.Text = "零售";
                    btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.零售;
                }
                else
                {
                    MessageBox.Show("售出失败");
                }
                #endregion

                #endregion
            }
            btnSale.Enabled = true;
        }

        /// <summary>
        /// 显示售票提示信息
        /// </summary>
        private void ShowSoledMsg()
        {
            if (btnSaleType.Tag == null)
            {
                btnSaleType.Tag = Flamingo.BLL.Ticket.TicketType.零售;
            }
            string saletype = btnSaleType.Tag.ToString();

            string p0 = string.Empty, p1 = string.Empty, p2 = "0", p3 = string.Empty, p4 = string.Empty, p5 = string.Empty;
            p0 = btnSaleType.Text;
            List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
            p1 = listMy.Count.ToString();

            if (listMy.Count > 0)
            {
                StringBuilder sb_seatids = new StringBuilder();

                foreach (SeatMaDll.SeatStatusSim sc in listMy)
                {
                    sb_seatids.Append(sc._seatId);
                    sb_seatids.Append("|");
                }

                if (sb_seatids.Length > 0)
                {
                    sb_seatids.Remove(sb_seatids.Length - 1, 1);
                }

                #region 根据售票类型 计算单价及总价
                if (((Flamingo.BLL.Ticket.TicketType)btnSaleType.Tag) == Flamingo.BLL.Ticket.TicketType.团体)
                {
                    if (GroupPrice > 0)
                    {
                        totalprice = listMy.Count * GroupPrice;
                        p2 = totalprice.ToString("0.00");
                    }
                    else
                    {
                        totalprice = Flamingo.BLL.Ticket.GetPriceTotal(_szShowplanId, sb_seatids.ToString(), saletype, out htSelectedSeats, isShowGroup, ShowGroupShowPlanIds);
                        GroupPrice = totalprice / listMy.Count;
                        p2 = totalprice.ToString("0.00");
                    }
                }
                else if (((Flamingo.BLL.Ticket.TicketType)btnSaleType.Tag) == Flamingo.BLL.Ticket.TicketType.特价)
                {
                    if (GroupPrice > 0)
                    {
                        totalprice = listMy.Count * GroupPrice;
                        p2 = totalprice.ToString("0.00");
                    }
                    else
                    {
                        totalprice = Flamingo.BLL.Ticket.GetPriceTotal(_szShowplanId, sb_seatids.ToString(), saletype, out htSelectedSeats, isShowGroup, ShowGroupShowPlanIds);
                        GroupPrice = totalprice / listMy.Count;
                        p2 = totalprice.ToString("0.00");
                    }
                }
                else
                {
                    if (btnPayType.Text == "会员卡")
                        saletype = "会员";
                    float tp = Flamingo.BLL.Ticket.GetPriceTotal(_szShowplanId, sb_seatids.ToString(), saletype, out htSelectedSeats, isShowGroup, ShowGroupShowPlanIds);
                    totalprice = tp;
                    p2 = tp < 0 ? "No" : tp.ToString("0.00");
                }
                #endregion
            }
            p3 = btnPayType.Text;
            p4 = "1";
            p5 = "";
            lblShowSoledMsg.Text = string.Format("票种：{0}  数量：{1}张  总金额：{2}元  支付方式：{3}  切票数：{4}  ",
                p0, p1, p2, p3, p4, p5);

        }

        private void btnChooseShowPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        #region Refrush SeatStatus
        private void timer_RefrushStatus_Tick(object sender, EventArgs e)
        {
            RefrushStatusData();
        }
        private void RefrushStatusData()
        {
            if (this.bgw_RefrushStatus.IsBusy) throw new ApplicationException("系统正在执行数据查询操作，请稍后...");
            string szShowplanId = _szShowplanId;
            string szHallId = _szHallId;
            int nLevel = _nLevel;
            timer_RefrushStatus.Enabled = false;
            this.bgw_RefrushStatus.RunWorkerAsync(new object[] { szShowplanId, szHallId, nLevel });
        }

        private void bgw_RefrushStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            string szShowplanId = (string)args[0];
            string szHallId = (string)args[1];
            int nLevel = (int)args[2];
            List<SeatMaDll.Seat> list = Seatstatus.RetrieveStatusObjs(szShowplanId, szHallId, nLevel, FrmMain.curUser.UserId);
            seatChartDispExt1.seatChartDisp1.ReSetSeatStatus(list);
            e.Result = "";
        }

        private void bgw_RefrushStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string szDirPath = (string)e.Result;
            timer_RefrushStatus.Enabled = true;
        }
        #endregion

        private void btnQuerySoldInfo_Click(object sender, EventArgs e)
        {
            SaleTicket.frmQuery frm = new SaleTicket.frmQuery(_szShowplanId);
            frm.ShowDialog();
        }

        private void btnValidateTicket_Click(object sender, EventArgs e)
        {
            SaleTicket.frmValidateTicket frm = new SaleTicket.frmValidateTicket();
            frm.ShowDialog();
        }

        private void btnReservationQuery_Click(object sender, EventArgs e)
        {
            ReserVationQueryOutTicket();
        }

        private void ReserVationQueryOutTicket()
        {
            SaleTicket.frmReservationQuery frmQ = new SaleTicket.frmReservationQuery(_szShowplanId);
            frmQ.ShowDialog();
            if (frmQ.UserName == string.Empty)
                return;
            #region 订票出票
            SaleTicket.frmReservationValidate frm = new SaleTicket.frmReservationValidate(frmQ.UserName);
            frm.ShowPlanId = _szShowplanId;
            frm.ShowPlanDate = _szShowPlanDate;
            frm.ShowPlanHall = hallname;
            frm.ShowPlanName = showplanname;
            frm.ShowPlanStartTime = _szShowPlanStartTime;
            frm.FilmId = filmid;
            frm.TheaterName = _szTheaterName;
            frm.HallId = _szHallId;
            frm.CheckingType = _szCheckingType;
            frm.ShowGroupFilmIds = ShowGroupFilmIds;
            frm.IsShowGroup = isShowGroup;
            frm.ShowGroupShowPlanIds = ShowGroupShowPlanIds;
            frm.ShowGroupShowPlanNames = ShowGroupShowPlanNames;
            frm.ShowPlanPosition = ShowPlanPosition;
            frm.ShowDialog();
            List<SeatMaDll.SeatStatusSim> seatstatussimlist_cancel = frm.SeatStatusSimList_Cancel;
            List<SeatMaDll.SeatStatusSim> seatstatussimlist_sold = frm.SeatStatusSimList_Sold;
            List<SeatMaDll.SeatStatusSim> seatstatussimlist_soldByvoucher = frm.SeatStatusSimList_SoldByVoucher;

            if (seatstatussimlist_cancel != null)
            {
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_cancel);
            }
            if (seatstatussimlist_sold != null)
            {
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_sold);
            }
            if (seatstatussimlist_soldByvoucher != null)
            {
                seatChartDispExt1.seatChartDisp1.SetSeatsStatus(seatstatussimlist_soldByvoucher);
            }
            ReserVationQueryOutTicket();
            #endregion
        }

        private void tmExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void bt_Zoom_Click(object sender, EventArgs e)
        {
            seatChartDispExt1.seatChartDisp1.ZoomSize = 1.1M;
        }

        private void bt_ReFrush_Click(object sender, EventArgs e)
        {
            SearchDataBySeatingChart(_seatingChart);
            //SearchData();
        }

        private void bt_Rotation_Click(object sender, EventArgs e)
        {
            seatChartDispExt1.Rotation();
        }

        void seatChartDisp1__OnMouseEnter(object sender, SeatMaDll.SelectOneSeat_Events e)
        {
            SeatMaDll.BHSeatControl seat = e.m_bhSeat;
            SeatMaDll.Seat st = (SeatMaDll.Seat)seat.Tag;
            string szDisp = st._seatNumber;
            //szDisp += "\r\n" + st._seatPosX.ToString() + "," + st._seatPosY.ToString();
            this.toolTip_Seat.SetToolTip(seat, szDisp);
        }

        private void btnCloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                List<SeatMaDll.SeatStatusSim> listMy = seatChartDispExt1.seatChartDisp1.RetrieveSeatStatusSimList_BySeatStatus("5");
                if (listMy.Count > 0)
                {
                    MessageBox.Show("已选定的座位将被取消", "提示");
                    StringBuilder sb_seatstatusids = new StringBuilder();
                    foreach (SeatMaDll.SeatStatusSim sss in listMy)
                    {
                        sb_seatstatusids.Append(_szShowplanId);
                        sb_seatstatusids.Append(sss._seatId);
                        sb_seatstatusids.Append("|");
                        sss._seatStatusFlag = "0";
                    }
                    sb_seatstatusids.Remove(sb_seatstatusids.Length - 1, 1);
                    Flamingo.BLL.SeatStatus.CancelLock(sb_seatstatusids.ToString(), FrmMain.curUser.UserId.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            string timeNumber = DateTime.Now.ToString("HH:mm:ss").Replace(":", "");
            pictureBoxH.Image = Print.Turn(timeNumber.Substring(0, 1));
            pictureBoxHH.Image = Print.Turn(timeNumber.Substring(1, 1));
            pictureBoxM.Image = Print.Turn(timeNumber.Substring(2, 1));
            pictureBoxMM.Image = Print.Turn(timeNumber.Substring(3, 1));
        }

    }
}

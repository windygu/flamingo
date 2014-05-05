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
    public partial class FrmSeatChartImport : Form
    {
        const int _nSCPanelWidth = 900;
        const int _nSCPanelContainerHeight = 560;
        const int _nSCPanelHeight = 520;

        private SeatMaDll.EditSeatInfo _editSeatInfo = null;
        private SeatMaDll.SeatingChart _seatingChart = null;
        public FrmSeatChartImport()
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

        private void FrmSeatChartImport_Load(object sender, EventArgs e)
        {
            seatChartDispScreen1.seatChartDisp1.DisplayRowNumber = true;
            seatChartDispScreen1.SetBottomDisplay_Right("");

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

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
            uC_SiteMenu1.SetBgColor(bgColor);
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

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(sh._HallId, Convert.ToInt32(shl._LevelId));
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
            //throw new NotImplementedException();
            SimTheaterInfo sti = (SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            uC_HallInfoSeek1.InitHall(szTheaterId);
        }
        
        public void QueryData()
        {
            seatChartDispScreen1.seatChartDisp1.ClearItems();
            seatChartDispScreen1.seatChartDisp1.Invalidate();
            seatChartDispScreen1.SetBottomDisplay_Right("");

            if (uC_HallInfoSeek1.cbb_SeatingChart.SelectedItem == null) return;
            _seatingChart = (SeatMaDll.SeatingChart)uC_HallInfoSeek1.cbb_SeatingChart.SelectedItem;

            SetSeatResource(_seatingChart.BgColour);

            seatChartDispScreen1.seatChartDisp1.ImportSeatChart(_seatingChart);

            int nSeatCount = seatChartDispScreen1.seatChartDisp1.GetAllSeatCount();
            seatChartDispScreen1.SetBottomDisplay_Right("座位数量:" + nSeatCount.ToString());
        }
        private void bt_Query_Click(object sender, EventArgs e)
        {
            QueryData();

        }
        
        private void bt_Import_Click(object sender, EventArgs e)
        {
            string szMsg = "";
            bool bImport = ImportData(ref szMsg);   //seatChartDisp1.ImportItems(szFileName_Full, ref _editSeatInfo);
            if (szMsg.Trim().Length <= 0)
            {
                szMsg = "导入成功!";
                if (!bImport) szMsg = "导入失败!";
            }
            MessageBox.Show(szMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool ImportData(ref string szMsg)
        {
            if (uC_HallInfoSeek1.cbb_Theater.SelectedItem == null)
            {
                szMsg = "必须选择一个影院!";
                return false;
            }
            if (uC_HallInfoSeek1.cbb_Hall.SelectedItem == null)
            {
                szMsg = "必须选择一个影厅!";
                return false;
            }
            if (uC_HallInfoSeek1.cbb_Level.SelectedItem == null)
            {
                szMsg = "必须选择一个楼层!";
                return false;
            }

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

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择包含数据的座位图文件";
            dialog.Filter = "座位图文件|*.dat";
            string szFileName_Full = "";                 //@"c:\Firsite.dat";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                szFileName_Full = dialog.FileName;
                if (szFileName_Full.Trim().Length <= 0)
                {
                    //MessageBox.Show("文件名称不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    szMsg = "文件名称不能为空!";
                    return false;
                }
            }
            if (szFileName_Full.Trim().Length <= 0) return false;

            //bool bImport = seatChartDispScreen1.seatChartDisp1.ImportItems(szFileName_Full, ref _editSeatInfo, ref szMsg);
            bool bImport = seatChartDispScreen1.seatChartDisp1.PreImportItems(szFileName_Full, ref _editSeatInfo, ref szMsg);
            if (!bImport) return false;

            SetSeatResource(_editSeatInfo._ObjSeatingChart.BgColour);
            seatChartDispScreen1.seatChartDisp1.ImportSeatChartNew(_editSeatInfo._ObjSeatingChart);

            _seatingChart = _editSeatInfo._ObjSeatingChart;
            _seatingChart.SeatingChartName = _editSeatInfo._szSeatingChartName;

            seatChartDispScreen1.seatChartDisp1.Invalidate();

            bool bInUsed = SeatingChartAction.SeatingChartExistWillUsed(_seatingChart.SeatingChartName, DateTime.Now);
            if (bInUsed)
                MessageBox.Show("座位图正在买票中使用，不能导入保存!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return bImport;
        }

        private void bt_Commit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private SeatMaDll.SeatingChart BuildSeatingChart(string szSeatingChartName)
        {
            if (uC_HallInfoSeek1.cbb_Theater.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个影院!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (uC_HallInfoSeek1.cbb_Hall.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个影厅!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (uC_HallInfoSeek1.cbb_Level.SelectedItem == null)
            {
                MessageBox.Show("必须选择一个楼层!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (szSeatingChartName.Trim().Length <= 0)
            {
                MessageBox.Show("座位图名称不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            string szTheaterId = ((SimTheaterInfo)uC_HallInfoSeek1.cbb_Theater.SelectedItem)._TheaterId;
            string szHallId = ((SimHall)uC_HallInfoSeek1.cbb_Hall.SelectedItem)._HallId;
            try
            {
                int nLevel = Convert.ToInt32(uC_HallInfoSeek1.cbb_Level.Text.Trim());
                //Convert.ToInt32(((SimHallLevel)cbb_Level.SelectedItem)._LevelId);
                string szSeatingchartId = SeatingChartAction.BuildSeatingchartId(szHallId, nLevel);

                SeatMaDll.SeatingChart stchTemp = new SeatMaDll.SeatingChart();
                stchTemp.SeatingChartId = szSeatingchartId;
                stchTemp.SeatingChartName = szSeatingChartName;
                stchTemp.Level = nLevel;
                stchTemp.Seats = 0;
                stchTemp.Rows = 0;
                stchTemp.Columns = 0;
                stchTemp.RowSpace = 5;
                stchTemp.ColumnSpace = 4;
                stchTemp.HallId = szHallId;
                stchTemp.TheaterId = szTheaterId;

                if (SeatingChartAction.Update(stchTemp)) return stchTemp;
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void SaveData()
        {
            if (this.bgwSave.IsBusy) throw new ApplicationException("系统正在执行数据提交操作，请稍后...");
            if (_editSeatInfo == null)
            {
                MessageBox.Show("必须选择一个座位图!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
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

            if (_editSeatInfo._szTheaterName != sti._TheaterName)
            {
                MessageBox.Show("导入的影院名称与座位图的影院名称不一致!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
            }
            if (_editSeatInfo._szHallName != sh._HallName)
            {
                MessageBox.Show("导入的影厅名称与座位图的影厅名称不一致!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_editSeatInfo._szLevelName != shl._LevelId)
            {
                MessageBox.Show("导入的座位图楼层与座位图的楼层不一致!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (seatChartDispScreen1.seatChartDisp1.Controls.Count <= 0)
            {
                MessageBox.Show("座位图中没有座位，不能导入保存!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SeatMaDll.SeatingChart stchTemp = SeatingChartAction.GetSeatingChart(_seatingChart.SeatingChartName);
            if (stchTemp == null)
            {
                stchTemp = BuildSeatingChart(_seatingChart.SeatingChartName);
                stchTemp.BgColour = _seatingChart.BgColour;
                stchTemp.Shape = _seatingChart.Shape;
                _seatingChart = stchTemp;
            }
            else
            {
                stchTemp.BgColour = _seatingChart.BgColour;
                stchTemp.Shape = _seatingChart.Shape;
                _seatingChart = stchTemp;
                bool bWillUsed = SeatingChartAction.SeatingChartExistWillUsed(_seatingChart.SeatingChartName, DateTime.Now);
                if (bWillUsed)
                {
                    MessageBox.Show("座位图正在买票中使用，不能导入保存!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("座位图已经存在，是否重新导入?", "系统提示", buttons);
                if (result == System.Windows.Forms.DialogResult.No) return ;

                bool bHaveUsed = SeatingChartAction.SeatingChartExistHaveUsed(_seatingChart.SeatingChartId);
                if (bHaveUsed)
                {
                    SeatingChartAction.UpdateActiveFlag(_seatingChart.SeatingChartId, 0);
                    stchTemp = BuildSeatingChart(_seatingChart.SeatingChartName);
                    stchTemp.BgColour = _seatingChart.BgColour;
                    stchTemp.Shape = _seatingChart.Shape;
                    _seatingChart = stchTemp;
                }
                else
                {
                    SeatAction.DeleteBySeatingChartId(_seatingChart.SeatingChartId);
                }

            }

            this.Cursor = Cursors.AppStarting;
            this.bgwSave.RunWorkerAsync();
        }
        private void bgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SeatAction.CommitData(seatChartDispScreen1.seatChartDisp1, ref _seatingChart, ref _editSeatInfo);
        }

        private void bgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            bool bSaveData = (bool)e.Result;
            string szMsg = "提交座位图成功!";
            if (!bSaveData) szMsg = "提交座位图失败!";
           
            MessageBox.Show(szMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (bSaveData)
            {
                cbb_Level_SelectedIndexChanged(null, null);
                QueryData();
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}

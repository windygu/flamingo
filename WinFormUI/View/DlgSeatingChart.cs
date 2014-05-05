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
    public partial class DlgSeatingChart : Form
    {
        public DlgSeatingChart()
        {
            InitializeComponent();
        }
        public DlgSeatingChart(SeatMaDll.BHSeatControl sbSeatControl, List<SeatMaDll.BHSeatControl> list)
        {

            InitializeComponent();
        }

        private void DlgSeatingChart_Load(object sender, EventArgs e)
        {
            InitTheaterInfo();
            cbb_Theater.SelectedIndexChanged += new EventHandler(cbb_Theater_SelectedIndexChanged);
            cbb_Hall.SelectedIndexChanged += new EventHandler(cbb_Hall_SelectedIndexChanged);
        }

        void cbb_Hall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cbb_Theater.SelectedItem == null) return;
            if (cbb_Hall.SelectedItem == null) return;
            SimTheaterInfo sti = (SimTheaterInfo)cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            SimHall sh = (SimHall)cbb_Hall.SelectedItem;

            string szHallId = sh._HallId;
            InitHallLevel(szTheaterId, szHallId);
        }

        void cbb_Theater_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SimTheaterInfo sti = (SimTheaterInfo)cbb_Theater.SelectedItem;
            string szTheaterId = sti._TheaterId;
            InitHall(szTheaterId);
        }

        public void InitTheaterInfo()
        {
            cbb_Theater.DataSource = SimTheaterInfo.RetrieveItems();
            cbb_Theater.SelectedItem = null;
        }
        public void InitHall(string szTheaterId)
        {
            cbb_Hall.ResetText();
            cbb_Hall.DataSource = SimHall.RetrieveItems(szTheaterId);
            cbb_Hall.SelectedItem = null;
        }
        public void InitHallLevel(string szTheaterId, string szHallId)
        {
            cbb_Level.ResetText();
            cbb_Level.DataSource = SimHallLevel.RetrieveLevelItems(szTheaterId, szHallId);
            cbb_Level.SelectedItem = null;
        }

        private void btnSeatInfoSubmit_Click(object sender, EventArgs e)
        {
            if (cbb_Theater.SelectedItem == null)
            { return; }
            if (cbb_Hall.SelectedItem == null)
            { return; }
            if (cbb_Level.Text.Trim().Length <= 0)
            { return; }

            string szTheaterId = ((SimTheaterInfo)cbb_Theater.SelectedItem)._TheaterId;
            string szHallId = ((SimHall)cbb_Hall.SelectedItem)._HallId;

            string szSeats = tb_Seats.Text.Trim();
            if (szSeats.Length <= 0) szSeats = "0";

            string szRows = tb_Rows.Text.Trim();
            if (szRows.Length <= 0) szRows = "0";

            string szColumns = tb_Columns.Text.Trim();
            if (szColumns.Length <= 0) szColumns = "0";

            try
            {
                int nLevel = Convert.ToInt32(cbb_Level.Text.Trim());
                //Convert.ToInt32(((SimHallLevel)cbb_Level.SelectedItem)._LevelId);
                string szSeatingchartId = SeatingChartAction.BuildSeatingchartId(szHallId, nLevel);
                SeatMaDll.SeatingChart _seatingChart = new SeatMaDll.SeatingChart();
                _seatingChart.SeatingChartId = szSeatingchartId;
                _seatingChart.SeatingChartName = tb_seatingchartName.Text;
                _seatingChart.Level = nLevel;
                _seatingChart.Seats = int.Parse(szSeats);
                _seatingChart.Rows = int.Parse(szRows);
                _seatingChart.Columns = int.Parse(szColumns);
                _seatingChart.RowSpace = 5;
                _seatingChart.ColumnSpace = 4;
                _seatingChart.HallId = szHallId;
                _seatingChart.TheaterId = szTheaterId;

                if (SeatingChartAction.Update(_seatingChart))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("创建座位图成功!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSeatInfoCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}

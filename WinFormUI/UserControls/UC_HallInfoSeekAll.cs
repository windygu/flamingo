using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class UC_HallInfoSeekAll : UserControl
    {
        public UC_HallInfoSeekAll()
        {
            InitializeComponent();
        }
        public void SetBgColor(Color bgColor)
        {
            tableLayoutPanel2.BackColor = bgColor;
            this.BackColor = bgColor;
        }
        public void InitTheaterInfo()
        {
            List<SimTheaterInfo> list = SimTheaterInfo.RetrieveItems();
            cbb_Theater.DataSource = list;
            //if (list.Count > 0)
            //    cbb_Theater.SelectedItem = list[0];
            //else
            cbb_Theater.SelectedItem = null;
        }
        public void InitHall(string szTheaterId)
        {
            cbb_Hall.ResetText();
            List<SimHall> list = SimHall.RetrieveItems(szTheaterId);
            cbb_Hall.DataSource = list;
            if (list.Count > 0)
                cbb_Hall.SelectedItem = list[0];
            else
                cbb_Hall.SelectedItem = null;
        }
        public void InitHallWithHallId(string szTheaterId, string szHallId)
        {
            cbb_Hall.ResetText();
            List<SimHall> list = SimHall.RetrieveItems(szTheaterId);
            cbb_Hall.DataSource = list;
            cbb_Hall.SelectedItem = FindHallByHallId(list, szHallId);
        }
        public SimHall FindHallByHallId(List<SimHall> list, string szHallId)
        {
            if (list == null || list.Count <= 0) return null;
            foreach (SimHall sh in list)
            {
                if (sh._HallId == szHallId) return sh;
            }
            return null;
        }
        public void InitHallLevel(string szTheaterId, string szHallId)
        {
            cbb_Level.ResetText();
            List<SimHallLevel> list = SimHallLevel.RetrieveLevelItemsByTH(szTheaterId, szHallId);
            cbb_Level.DataSource = list;
            if (list.Count > 0)
                cbb_Level.SelectedItem = list[0];
            else
                cbb_Level.SelectedItem = null; 
        }
        public void InitSeatingChart(string szHallId, int nLevel)
        {
            cbb_SeatingChart.ResetText();
            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            cbb_SeatingChart.DataSource = scList;
            if(scList.Count > 0)
                cbb_SeatingChart.SelectedItem = scList[0];
            else 
                cbb_SeatingChart.SelectedItem = null;
        }
        public void InitSeatingChart(List<SeatMaDll.SeatingChart> scList)
        {
            cbb_SeatingChart.ResetText();
            cbb_SeatingChart.DataSource = scList;
            if (scList.Count > 0)
                cbb_SeatingChart.SelectedItem = scList[0];
            else
                cbb_SeatingChart.SelectedItem = null;
        }
    }
}

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
    public partial class UC_HallInfo : UserControl
    {
        public UC_HallInfo()
        {
            InitializeComponent();
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
    }
}

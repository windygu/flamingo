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
    public partial class DlgMultiSelect : Form
    {
        private List<SeatMaDll.BHSeatControl> _bhSeatlist = null;
        public DlgMultiSelect()
        {
            InitializeComponent();
        }
        public DlgMultiSelect(List<SeatMaDll.BHSeatControl> bhSeatlist)
        {
            InitializeComponent();
            _bhSeatlist = bhSeatlist;
        }

        public void SetListData(List<SeatMaDll.BHSeatControl> bhSeatlist)
        {
            _bhSeatlist = bhSeatlist;
        }

        private void DlgMultiSelect_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            if (_bhSeatlist == null) return;
            foreach (SeatMaDll.BHSeatControl bhs in _bhSeatlist)
            {
                SeatMaDll.Seat st = (SeatMaDll.Seat)bhs.Tag;
                string szColumns = st._seatColumn;//GetColumnsNum(st._seatColumnList);//st._seatColumn[0];
                int nR = this.dgv_List.Rows.Add(new object[] { 
                    st._seatRowNumber,
                    szColumns,
                    ""
                });
                dgv_List.Rows[nR].Tag = bhs;
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

        private void btnSizeConfigSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
            this.Dispose();
        }
    }
}

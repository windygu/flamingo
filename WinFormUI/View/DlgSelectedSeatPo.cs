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
    public partial class DlgSelectedSeatPo : Form
    {
        private List<DataObject.PO.SeatPo> _bhSeatlist = null;
        public DlgSelectedSeatPo()
        {
            InitializeComponent();
        }
        public DlgSelectedSeatPo(List<DataObject.PO.SeatPo> bhSeatlist)
        {
            InitializeComponent();
            _bhSeatlist = bhSeatlist;
        }

        public void SetListData(List<DataObject.PO.SeatPo> bhSeatlist)
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
            foreach (DataObject.PO.SeatPo bhs in _bhSeatlist)
            {
                int nR = this.dgv_List.Rows.Add(new object[] { 
                    bhs.SEATID,
                    bhs.ROWNUMBER,
                    bhs.COLUMNNUMBER,
                    bhs.SEATNUMBER,
                    bhs.XAXIS,
                    bhs.YAXIS
                });
                dgv_List.Rows[nR].Tag = bhs;
            }
            dgv_List.ClearSelection();

        }
        private void btnSizeConfigSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
            this.Dispose();
        }
    }
}

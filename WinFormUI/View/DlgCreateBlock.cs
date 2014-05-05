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
    public partial class DlgCreateBlock : Form
    {
        FrmSeatChartResetBlock _frmContainer = null;
        bool _bCreate = true;
        public bool _bChange = false;

        public DlgCreateBlock()
        {
            InitializeComponent();
        }
        public DlgCreateBlock(FrmSeatChartResetBlock frmContainer, bool bCreate)
        {
            InitializeComponent();
            _frmContainer = frmContainer;
            _bCreate = bCreate;
        }

        private void DlgCreateBlock_Load(object sender, EventArgs e)
        {
            InitSeatingChart();
            dgv_Block.SelectionChanged += new EventHandler(dgv_Block_SelectionChanged);
        }
        private void InitSeatingChart()
        {
            if (_frmContainer == null) return;
            if (_frmContainer._seatingChart == null) return;
            tb_SeatingChartName.Text = _frmContainer._seatingChart.SeatingChartName;
            FillData();
            //dgv_Block
        }
        private void FillData()
        {
            dgv_Block.Rows.Clear();
            List<Block> list = Block.RetrieveObjList(_frmContainer._seatingChart.SeatingChartId);

            foreach (Block sb in list)
            {
                int nR = this.dgv_Block.Rows.Add(new object[] { 
                    sb.BlockId,
                    sb.BlockName,
                    sb.Bgcolour,
                    sb.Seats,
                    sb.HasBlockPrice,
                    sb.SeatingChartId
                });
                dgv_Block.Rows[nR].Tag = sb;
                DataGridViewRow row = this.dgv_Block.Rows[nR];
                //row.Cells["Bgcolour"]
                if (sb.Bgcolour != 0)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(sb.Bgcolour & 0x0000ff, (sb.Bgcolour & 0x00ff00) >> 8, (sb.Bgcolour & 0xff0000) >> 16);
            }
            dgv_Block.ClearSelection();

        }
        private Block BuildBlock()
        {
            if (_frmContainer == null) return null;
            if (_frmContainer._seatingChart == null) return null;
            if (_frmContainer._seatingChart.SeatingChartId.Trim().Length <= 0)
            {
                MessageBox.Show("必须选择一个座位图！", "系统提示");
                return null;
            }
            if (tb_BlockName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("区域名称不能为空！", "系统提示");
                return null;
            }
            if (!_bCreate && tb_BlockName.Tag == null)
            {
                MessageBox.Show("只能编辑区域，若要创建新的区域请进入创建窗口！", "系统提示");
                return null;
            }
            try
            {
                int nSeats = Int32.Parse(tb_Seats.Text);
                Block blk = new Block();
                blk.BlockName = tb_BlockName.Text;
                blk.SeatingChartId = _frmContainer._seatingChart.SeatingChartId;

                if (tb_BlockName.Tag != null)
                {
                    blk.BlockId = ((Block)tb_BlockName.Tag).BlockId;
                    blk.HasBlockPrice = ((Block)tb_BlockName.Tag).HasBlockPrice;
                    blk.Seats = ((Block)tb_BlockName.Tag).Seats;
                }
                else
                {
                    blk.BlockId = "";
                    blk.HasBlockPrice = 0;
                    blk.Seats = nSeats;
                }
                int nBackColor = 0;
                if (lb_BgColor.BackColor != System.Drawing.Color.Transparent)
                    nBackColor = ColorTranslator.ToWin32(lb_BgColor.BackColor);
                blk.Bgcolour = nBackColor; 

                return blk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnSeatInfoSubmit_Click(object sender, EventArgs e)
        {
            Block blk = BuildBlock();
            if (blk == null) return;
            bool bR = true;
            if(_bCreate)
                bR = Block.CreateObj(blk);
            else
                bR = Block.UpdateObj(blk);

            if (bR)
            {
                _bChange = true;
                MessageBox.Show("提交数据成功!");
            }
            else
            {
                MessageBox.Show("提交数据失败!");
            }

            FillData();
        }

        private void btnSeatInfoCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bt_BgColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialogBg = new ColorDialog();
            colorDialogBg.AllowFullOpen = true;
            colorDialogBg.ShowHelp = true;
            colorDialogBg.Color = lb_BgColor.BackColor;
            if (colorDialogBg.ShowDialog() == DialogResult.OK)
                lb_BgColor.BackColor = colorDialogBg.Color;
        }

        private void dgv_Block_SelectionChanged(object sender, EventArgs e)
        {
            if (_bCreate) return;
            if (dgv_Block.SelectedRows == null) return;
            if (dgv_Block.SelectedRows.Count <= 0) return;
            if (dgv_Block.SelectedRows[0].Tag == null) return;
            Block bk = (Block)dgv_Block.SelectedRows[0].Tag;
            tb_BlockName.Text = bk.BlockName;
            tb_BlockName.Tag = bk;
            tb_Seats.Text = bk.Seats.ToString();
            if (bk.Bgcolour != 0)
                lb_BgColor.BackColor = Color.FromArgb(bk.Bgcolour & 0x0000ff, (bk.Bgcolour & 0x00ff00) >> 8, (bk.Bgcolour & 0xff0000) >> 16);
            else
                lb_BgColor.BackColor = System.Drawing.Color.Transparent;
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (_bCreate) return;
            if (dgv_Block.SelectedRows == null) return;
            if (dgv_Block.SelectedRows.Count <= 0) return;
            if (dgv_Block.SelectedRows[0].Tag == null) return;
            Block bk = (Block)dgv_Block.SelectedRows[0].Tag;
            if (bk.BlockName == "默认")
            {
                MessageBox.Show("默认区域不能删除!");
                return;
            }
            if (bk != null && bk.BlockId.Trim().Length > 0)
            {
                string szBlockId_Default = Block.GetDefaultBlock(bk.SeatingChartId);
                if (szBlockId_Default.Trim().Length <= 0) return;
                bool bR = Block.DeleteObj(bk, szBlockId_Default);
                if (bR)
                {
                    _bChange = true;
                    tb_BlockName.ResetText();
                    tb_BlockName.Tag = null;
                    lb_BgColor.BackColor = Color.Transparent;
                    FillData();
                }
            }
        }

    }
}

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
    public partial class DlgCreateBlockPrice : Form
    {
        FrmSeatChartResetBlockPrice _frmContainer = null;
        public bool _bChange = false;

        public DlgCreateBlockPrice()
        {
            InitializeComponent();
        }
        public DlgCreateBlockPrice(FrmSeatChartResetBlockPrice frmContainer)
        {
            InitializeComponent();
            _frmContainer = frmContainer;
        }

        private void DlgCreateBlockPrice_Load(object sender, EventArgs e)
        {
            if (_frmContainer._ShowPlanRich != null)
            {
                lb_ShowPlan.Text = "放映计划:" + _frmContainer._ShowPlanRich._ObjShowPlan.ShowPlanName + "  " +
                    "影厅:" + _frmContainer._ShowPlanRich._HallName + "  " +
                   "影片:" + _frmContainer._ShowPlanRich._FilmName + "  " +
                   "时间:" + _frmContainer._ShowPlanRich._ObjShowPlan.StartTime.ToString("yyyy-MM-dd hh:mm") + "---" + _frmContainer._ShowPlanRich._ObjShowPlan.EndTime.ToString("yyyy-MM-dd hh:mm");
            }
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
            List<BlockPriceRich> list = BlockPriceRich.RetrieveObjList(_frmContainer._seatingChart.SeatingChartId, _frmContainer._ShowPlanId);

            foreach (BlockPriceRich sb in list)
            {
                int nR = this.dgv_Block.Rows.Add(new object[] { 
                    sb._block.BlockId,
                    sb._block.BlockName,
                    sb._block.Bgcolour,
                    sb._block.Seats,
                    sb._blockPrice.SinglePrice,
                    sb._blockPrice.DoublePrice,
                    sb._blockPrice.BoxPrice,
                    sb._blockPrice.StudentPrice,
                    sb._block.HasBlockPrice,
                    sb._block.SeatingChartId
                });
                dgv_Block.Rows[nR].Tag = sb;
                DataGridViewRow row = this.dgv_Block.Rows[nR];
                //row.Cells["Bgcolour"]
                if (sb._block.Bgcolour != 0)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(sb._block.Bgcolour & 0x0000ff, (sb._block.Bgcolour & 0x00ff00) >> 8, (sb._block.Bgcolour & 0xff0000) >> 16);
                if (_frmContainer._SimBlockObj != null)
                {
                    if (_frmContainer._SimBlockObj._block.BlockId == sb._block.BlockId)
                    {
                        row.Selected = true;
                        ResetDataToPriceControls(sb);
                    }
                }
                //dgv_Block.sel
            }
            if (_frmContainer._SimBlockObj == null)
                dgv_Block.ClearSelection();
            
        }
        private BlockPrice BuildBlock()
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
            if (tb_BlockName.Tag == null)
            {
                MessageBox.Show("必须选定一个区域进行设置！", "系统提示");
                return null;
            }

            try
            {
                decimal deciSinglePrice = decimal.Parse(tb_SinglePrice.Text);
                decimal deciDoublePrice = decimal.Parse(tb_DoublePrice.Text);
                decimal deciBoxPrice = decimal.Parse(tb_BoxPrice.Text);
                decimal deciStudentPrice = decimal.Parse(tb_StudentPrice.Text);

                BlockPrice blk = new BlockPrice();
                blk.ShowPlanId = _frmContainer._ShowPlanId;
                blk.BlockId = ((BlockPriceRich)tb_BlockName.Tag)._block.BlockId;
                blk.BlockPriceId = ((BlockPriceRich)tb_BlockName.Tag)._blockPrice.BlockPriceId;
                blk.SinglePrice = deciSinglePrice;
                blk.DoublePrice = deciDoublePrice;
                blk.BoxPrice = deciBoxPrice;
                blk.StudentPrice = deciStudentPrice;
                
                return blk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Block.SelectedRows == null) return;
            if (dgv_Block.SelectedRows.Count <= 0) return;
            if (dgv_Block.SelectedRows[0].Tag == null) return;
            BlockPriceRich bk = (BlockPriceRich)dgv_Block.SelectedRows[0].Tag;
            if (bk._blockPrice != null && bk._blockPrice.BlockPriceId.Trim().Length > 0)
            {
                bool bR = BlockPrice.DeleteObj(bk._blockPrice);
                if (bR)
                {
                    _bChange = true;
                    FillData();
                }
            }
        }
        private void btnSeatInfoSubmit_Click(object sender, EventArgs e)
        {
            BlockPrice blk = BuildBlock();
            if (blk == null) return;
            bool bR = true;
            if (blk.BlockPriceId.Trim().Length <= 0)
                bR = BlockPrice.CreateObj(blk);
            else
                bR = BlockPrice.UpdateObj(blk);

            if (bR)
            {
                //if (_frmContainer._SimBlockObj != null) 
                //    _frmContainer._SimBlockObj._blockPrice = blk;
                _bChange = true;
                FillData();
                MessageBox.Show("提交数据成功!");
            }
            else
            {
                MessageBox.Show("提交数据失败!");
            }
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
            if (dgv_Block.SelectedRows == null) return;
            if (dgv_Block.SelectedRows.Count <= 0) return;
            if (dgv_Block.SelectedRows[0].Tag == null) return;
            BlockPriceRich bk = (BlockPriceRich)dgv_Block.SelectedRows[0].Tag;
            ResetDataToPriceControls(bk);
            
        }
        private void ResetDataToPriceControls(BlockPriceRich bk)
        {
            tb_BlockName.Text = bk._block.BlockName;
            tb_BlockName.Tag = bk;
            if (bk._block.Bgcolour != 0)
                lb_BgColor.BackColor = Color.FromArgb(bk._block.Bgcolour & 0x0000ff, (bk._block.Bgcolour & 0x00ff00) >> 8, (bk._block.Bgcolour & 0xff0000) >> 16);
            else
                lb_BgColor.BackColor = System.Drawing.Color.Transparent;

            tb_SinglePrice.Text = bk._blockPrice.SinglePrice.ToString();
            tb_DoublePrice.Text = bk._blockPrice.DoublePrice.ToString();
            tb_BoxPrice.Text = bk._blockPrice.BoxPrice.ToString();
            tb_StudentPrice.Text = bk._blockPrice.StudentPrice.ToString();
        }

    }
}

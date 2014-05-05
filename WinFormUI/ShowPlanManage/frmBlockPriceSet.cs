using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    public partial class frmBlockPriceSet : Form
    {
        private BindingSource bsList = new BindingSource();

        private DailyShowPlanManage dataManager;

        private List<BlockPrice> blockPriceList;

        private List<Block> blockList;

        private List<ShowPlanInfo> showPlanInfoList;

        private BlockPriceSet blockPriceSet;

        private Button btnBlock;

        private List<Hall> hallList;

        private List<SeatingChart> seatingChartList;

        public frmBlockPriceSet(DailyShowPlanManage datamager)
        {
            InitializeComponent();

            //生成辅助按钮
            BuildBlockButton();

            blockPriceSet = new BlockPriceSet();

            this.dataManager = datamager;

            //获取影厅信息
            hallList = blockPriceSet.GetHallList();

            //获取放映场次计划信息
            showPlanInfoList = blockPriceSet.GetShowPlanInfoList(dataManager);

            //
            seatingChartList = new List<SeatingChart>();
            seatingChartList = blockPriceSet.GetSeatingChartList();

            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            dgvList.DataError += new DataGridViewDataErrorEventHandler(dgvList_DataError);
            dgvList.CellParsing += new DataGridViewCellParsingEventHandler(dgvList_CellParsing);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            dgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvList_EditingControlShowing);

        }
        private void frmBlockPriceSet_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            FillData();

            blockList = blockPriceSet.GetBlock();

            ////重新绑定dgvList数据
            //bsList.DataSource = blockPriceList;
            //BindList();



        }
        #region 窗体事件

        /// <summary>
        /// 点击数据明细表单元格时，某些列需要弹出辅助按钮的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgvList.CurrentCell == null)
                return;

            foreach (Control con in e.Control.Parent.Controls)
            {
                if (con == btnBlock)
                    e.Control.Parent.Controls.Remove(con);
            }

            if (this.dgvList.CurrentCell.OwningColumn.Name == "BlockId")
            {
                e.Control.Parent.Controls.Add(btnBlock);
                btnBlock.BringToFront();
            }
        }
        /// <summary>
        /// 点击数据明细表单元格时，立刻进入编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell != null && e.ColumnIndex != -1)
                dgv.BeginEdit(true);
        }

        /// <summary>
        /// 数据明细表中输入值验证发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.dgvList.CancelEdit();
            MessageBox.Show("输入数据格式不正确！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 数据明细表数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;

            if (e.Value == null || e.Value.ToString() == "")
                return;

            if (columnName == "BlockId")
            {
                try
                {
                    var tmp = blockList.Where(p => p.BlockId == e.Value.ToString()).FirstOrDefault();
                    if (tmp == null)
                    {
                        e.Value = "";
                        dgvList["BlockName", e.RowIndex].Value = "";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        dgvList["BlockName", e.RowIndex].Value = tmp.BlockName;
                        e.FormattingApplied = true;
                    }
                }
                catch
                {
                }
            }
            else if (columnName.EndsWith("Price"))
            {

                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 1).ToString("0.00");
                    e.FormattingApplied = true;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 数据明细表的数据填充处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;
            if (e.Value == null || e.Value.ToString() == "")
                return;
            if (columnName.EndsWith("Price"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 1).ToString("0.00");
                    e.ParsingApplied = true;
                }
                catch
                {
                }
            }
            if (columnName == "BlockId")
            {
                try
                {
                    var tmp = blockList.Where(p => p.BlockId == e.Value.ToString()).FirstOrDefault();
                    if (tmp == null)
                    {
                        e.Value = "";
                        dgvList["BlockName", e.RowIndex].Value = "";
                        e.ParsingApplied = true;
                    }
                    else
                    {
                        blockPriceList = bsList.DataSource as List<BlockPrice>;

                        dgvList["BlockName", e.RowIndex].Value = tmp.BlockName;

                        SetPrice();

                        e.ParsingApplied = true;

                        foreach (var row in blockPriceList)
                        {
                            //  判断是否已经设置了这个区域的票价

                            if (row.BlockId != null && row.BlockId.Trim() == e.Value.ToString())
                            {
                                MessageBox.Show("列表中已存在相同的区域！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Value = "";
                                dgvList["BlockName", e.RowIndex].Value = "";
                                e.ParsingApplied = true;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 单击辅助按钮，选择分区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlock_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmSelectBlock frm = new frmSelectBlock(this.blockList, this.seatingChartList, cbHall.SelectedValue.ToString());
            this.Cursor = Cursors.Default;

            if (frm.ShowDialog() == DialogResult.OK)
            {

                if (this.dgvList.CurrentRow.IsNewRow == true)
                {
                    blockPriceList = bsList.DataSource as List<BlockPrice>;

                    foreach (var row in blockPriceList)
                    {
                        //  判断是否已经设置了这个区域的票价
                        if (row.BlockId != null && row.BlockId.Trim() == frm.blockId)
                        {
                            MessageBox.Show("列表中已存在相同的区域！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                    }
                    bsList.CancelEdit();
                    bsList.AddNew();
                }

                this.dgvList.CurrentRow.Cells["BlockId"].Value = frm.blockId;
                this.dgvList.CurrentRow.Cells["BlockName"].Value = blockList.Where(p => p.BlockId == this.dgvList.CurrentRow.Cells["BlockId"].Value.ToString().Trim()).FirstOrDefault().BlockName;

                SetPrice();
            }
        }

        /// <summary>
        /// 设置默认票价
        /// </summary>
        private void SetPrice()
        {
            var tmp = dataManager.GetFareSettingList.Where(p => p.FareSettingId == blockPriceSet.GetBlockfareSettingPriceId()).FirstOrDefault();


            this.dgvList.CurrentRow.Cells["SinglePrice"].Value = tmp.SinglePrice;
            this.dgvList.CurrentRow.Cells["DoublePrice"].Value = tmp.DoublePrice;
            this.dgvList.CurrentRow.Cells["StudentPrice"].Value = tmp.StudentPrice;
            this.dgvList.CurrentRow.Cells["GroupPrice"].Value = tmp.GroupPrice;
            this.dgvList.CurrentRow.Cells["MemberPrice"].Value = tmp.MemberPrice;
            this.dgvList.CurrentRow.Cells["BoxPrice"].Value = tmp.BoxPrice;
            this.dgvList.CurrentRow.Cells["DiscountPrice"].Value = tmp.DiscountPrice;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbShowPlan.Enabled == true)
                {
                    blockPriceList = bsList.DataSource as List<BlockPrice>;

                    if (blockPriceSet.SetBlockPrice(this.blockPriceList) == true)
                    {
                        //从新获取正确的区域票价信息记录，防止在列表格式化数据时出错
                        blockPriceList = blockPriceSet.GetBlockList;
                        bsList.DataSource = blockPriceList;
                        BindList();

                        if (MessageBox.Show("添加区域票价成功，是否现在关闭窗体？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("没选择任何场次，不能添加区域票价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除分区票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvList.Rows.Remove(dgvList.CurrentRow);
            }
            catch
            {
                MessageBox.Show("请选择要删除的行！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 影厅选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                cbShowPlan.ValueMember = "ShowPlanId";
                cbShowPlan.DisplayMember = "ShowPlanName";
                var list = showPlanInfoList.Where(p => p.HallId == cbHall.SelectedValue.ToString().Trim()).ToList();
                if (list.Count <= 0)
                    cbShowPlan.Enabled = false;
                else
                    cbShowPlan.Enabled = true;
                cbShowPlan.DataSource = list;
            }
            catch { }
        }

        /// <summary>
        /// 场次选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbShowPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            blockPriceList = blockPriceSet.GetBlockPriceList(cbShowPlan.SelectedValue.ToString().Trim());
            bsList.DataSource = blockPriceList;
            BindList();
            dgvList.Enabled = true;
            if (showPlanInfoList.Where(p => p.ShowPlanId == cbShowPlan.SelectedValue.ToString().Trim()).FirstOrDefault().IsLocked == true)
            {
                dgvList.Enabled = false;
                MessageBox.Show("该场次已进行了锁定，不能设置区域票价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region 窗体函数


        public List<BlockPrice> GetBlockPriceList()
        {
            this.blockPriceList = bsList.DataSource as List<BlockPrice>;
            return this.blockPriceList;
        }
        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected void FormatDataList()
        {
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns["BlockPriceId"].Visible = false;
            dgvList.Columns["Created"].Visible = false;
            dgvList.Columns["Updated"].Visible = false;
            dgvList.Columns["ActiveFlag"].Visible = false;
            dgvList.Columns["ShowPlanId"].Visible = false;
            dgvList.Columns["ShowPlan"].Visible = false;
            dgvList.Columns["Block"].Visible = false;
            dgvList.Columns["GroupPrice"].Visible = false;

            dgvList.Columns["BlockId"].HeaderText = "分区编号";
            dgvList.Columns["SinglePrice"].HeaderText = "单人零售票价";
            dgvList.Columns["DoublePrice"].HeaderText = "双座零售票价";
            dgvList.Columns["StudentPrice"].HeaderText = "学生票价";
            dgvList.Columns["GroupPrice"].HeaderText = "团体票价";
            dgvList.Columns["BoxPrice"].HeaderText = "包厢票价";
            dgvList.Columns["MemberPrice"].HeaderText = "会员定价";
            dgvList.Columns["DiscountPrice"].HeaderText = "特价";

            //判断如果已经存在则不添加
            Boolean isExit = false;
            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                if (column.Name == "BlockName")
                    isExit = true;
            }
            if (isExit == false)
                dgvList.Columns.Add("BlockName", "分区名称");

            dgvList.Columns["BlockId"].DisplayIndex = 1;
            dgvList.Columns["BlockName"].DisplayIndex = 2;
            dgvList.Columns["SinglePrice"].DisplayIndex = 3;
            dgvList.Columns["DoublePrice"].DisplayIndex = 4;
            dgvList.Columns["StudentPrice"].DisplayIndex = 5;
            dgvList.Columns["GroupPrice"].DisplayIndex = 6;
            dgvList.Columns["BoxPrice"].DisplayIndex = 7;
            dgvList.Columns["MemberPrice"].DisplayIndex = 8;
            dgvList.Columns["DiscountPrice"].DisplayIndex = 9;
            dgvList.Columns["BlockName"].ReadOnly = true;
        }

        //绑定dgvList的数据
        private void BindList()
        {
            dgvList.DataSource = null;
            dgvList.DataSource = bsList;
            if (dgvList.DataSource != null)
                FormatDataList();
        }

        /// <summary>
        /// 生成辅助按钮：商品编号
        /// </summary>
        private void BuildBlockButton()
        {
            btnBlock = new Button();
            btnBlock.Width = 25;
            btnBlock.FlatStyle = FlatStyle.System;
            btnBlock.BackColor = Color.WhiteSmoke;
            btnBlock.Text = "…";
            btnBlock.TextAlign = ContentAlignment.MiddleRight;

            btnBlock.Dock = DockStyle.Right;

            btnBlock.Click += new EventHandler(btnBlock_Click);
        }

        //填充ComboBox
        private void FillData()
        {
            cbHall.ValueMember = "HallId";
            cbHall.DisplayMember = "HallName";
            cbHall.DataSource = hallList;

            cbShowPlan.ValueMember = "ShowPlanId";
            cbShowPlan.DisplayMember = "ShowPlanName";
        }

        #endregion

    }
}

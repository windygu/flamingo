using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RCLibrary;


namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmDiscountManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量
        private DiscountManage dataManager;
        private ComboBox cbDiscountPrice;
        BindingSource dataBindingSourceOfPrice;
        BindingSource dataBindingSourceOfType;

        private ComboBox cbDiscountTypeName;
        List<DataGridViewColumnInfo> dataGridViewColumnInfoPriceList;
        List<DataGridViewColumnInfo> dataGridViewColumnInfoTypeList;



        #endregion

        #region 启动处理
        public frmDiscountManage()
        {
            InitializeComponent();

            lblListTitle.Text = "特价信息表";

            dataManager = new DiscountManage();
            dataBindingSource = new BindingSource();
            dataBindingSourceOfPrice = new BindingSource();
            dataBindingSourceOfType = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            dataGridViewColumnInfoPriceList = dataManager.ColumnInfoPriceList;
            dataGridViewColumnInfoTypeList = dataManager.ColumnInfoTypeList;
           
            dataBindingSourceOfPrice.ListChanged += new ListChangedEventHandler(dataBindingSourceOfPrice_ListChanged);
            dataBindingSourceOfType.ListChanged += new ListChangedEventHandler(dataBindingSourceOfType_ListChanged);
            this.dgvList.CellMouseMove += new DataGridViewCellMouseEventHandler(dgvList_CellMouseMove);
            this.dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            panList.Visible = true;
            dgvList.MouseLeave += new EventHandler(dgvList_MouseLeave);
            dgvList.MouseEnter += new EventHandler(dgvList_MouseEnter);
            this.Load += new EventHandler(frmDiscountManage_Load);
        }

        void dataBindingSourceOfType_ListChanged(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void dataBindingSourceOfPrice_ListChanged(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void dgvList_MouseEnter(object sender, EventArgs e)
        {
            cbDiscountPrice.Visible = true;
            cbDiscountTypeName.Visible = true;
        }

        private void dgvList_MouseLeave(object sender, EventArgs e)
        {
            //cbDiscountPrice.Visible = false;
            //cbDiscountTypeName.Visible = false;
        }
        private void frmDiscountManage_Load(object sender, EventArgs e)
        {
            BuildComboBoxOfDicountPrice();
            BuildComboBoxOfDicountTypeName();
            RefreshDataList();
            RefreshDataListOfPrice();
            RefreshDataListOfType();
            BindData();
            FillDiscountPrice();
            FillDiscountTypeName();
            txtDiscountName.Select();
            //ReSetListLocate();
            this.panDetail.Visible = false;
            ReadonlyConfig();
        }

        #endregion

        #region 窗体事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtDiscountName.Text == "")
            {
                MessageBox.Show("请输入特价名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDiscountName.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("Discount_TypeName", txtDiscountName.Text.Trim());
            }
        }

        private void dgvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Discount discountId = (Discount)dgvList.Rows[e.RowIndex].Cells["DiscountId"].Value;
                int discountColIndex = dgvList.Columns["DiscountId"].Index;
                Rectangle discountRect = dgvList.GetCellDisplayRectangle(discountColIndex, e.RowIndex, true);
                if (dgvList["DiscountId", e.RowIndex].Value != null)
                {
                    cbDiscountPrice.SelectedValue = dgvList["DiscountId", e.RowIndex].Value;
                }
                else
                {
                    cbDiscountPrice.SelectedValue = 1;
                }
                cbDiscountPrice.Left = discountRect.Left;
                cbDiscountPrice.Top = discountRect.Top;
                cbDiscountPrice.Height = discountRect.Height;
                cbDiscountPrice.Width = discountRect.Width;
                cbDiscountPrice.Tag = e.RowIndex;
                cbDiscountPrice.Visible = true;


                //下面是特价类型名称的处理
                int discountTypeNameColIndex = dgvList.Columns["DiscountTypeId"].Index;
                Rectangle discountTypeNameRect = dgvList.GetCellDisplayRectangle(discountTypeNameColIndex, e.RowIndex, true);
                if (dgvList["DiscountTypeId", e.RowIndex].Value != null)
                {
                    cbDiscountTypeName.SelectedValue = dgvList["DiscountTypeId", e.RowIndex].Value;
                }
                else
                {
                    cbDiscountTypeName.SelectedValue = 1;
                }
                cbDiscountTypeName.Left = discountTypeNameRect.Left;
                cbDiscountTypeName.Top = discountTypeNameRect.Top;
                cbDiscountTypeName.Height = discountTypeNameRect.Height;
                cbDiscountTypeName.Width = discountTypeNameRect.Width;
                cbDiscountTypeName.Tag = e.RowIndex;
                cbDiscountTypeName.Visible = true;
            }
        }
        private void dgvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void cbDiscountPrice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            try
            {
                int rowIndex = Convert.ToInt32(cb.Tag);

                if (rowIndex >= 0 && cb.Tag != null && cb.SelectedValue != null)
                {
                    //Discount_Type data = (Discount_Type)dgvList.Rows[rowIndex].DataBoundItem;

                    // dataManager.ChangeMessageSendChannel(data.DiscountId.Value, (Discount_Type)cb.SelectedValue);

                    dgvList.Rows[rowIndex].Cells["DiscountId"].Value = cbDiscountPrice.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDiscountTypeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            try
            {
                int rowIndex = Convert.ToInt32(cb.Tag);

                if (rowIndex >= 0 && cb.Tag != null && cb.SelectedValue != null)
                {
                    //Discount_Type data = (Discount_Type)dgvList.Rows[rowIndex].DataBoundItem;

                    // dataManager.ChangeMessageSendChannel(data.DiscountId.Value, (Discount_Type)cb.SelectedValue);

                    dgvList.Rows[rowIndex].Cells["DiscountTypeId"].Value = cbDiscountTypeName.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 窗体函数

        #region 继承父窗体函数

        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            btnAddPrice.Enabled = true;
            btnDelPrice.Enabled = true;
            btnAddDiscontInfo.Enabled = true;
            btnDelDiscountInfo.Enabled = true;
            btnAddDiscountType.Enabled = true;
            btnDelDiscountType.Enabled = true;
            btnSaveDiscount_Type.Enabled = true;
            btnSavePrice.Enabled = true;
            btnSaveType.Enabled = true;

            dgvPriceList.Enabled = true;
            dgvTypeList.Enabled = true;
            dgvList.Enabled = true;
            panList.Enabled = true;
        }

        private void ReadonlyConfig()
        {
            btnAddPrice.Enabled = false;
            btnDelPrice.Enabled = false;
            btnAddDiscontInfo.Enabled = false;
            btnDelDiscountInfo.Enabled = false;
            btnAddDiscountType.Enabled = false;
            btnDelDiscountType.Enabled = false;
            btnSaveDiscount_Type.Enabled = false;
            btnSavePrice.Enabled = false;
            btnSaveType.Enabled = false;

            dgvPriceList.Enabled = false;
            dgvTypeList.Enabled = false;
            dgvList.Enabled = false;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Discount_Type)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            //    txtDiscountPrice.Enabled = false;
            //    txtDiscountTypeName.Enabled = false;
            try
            {
                this.dataManager.Save();
                ReadonlyConfig();
                cbDiscountPrice.DataSource = dataManager.DirectGetDiscountPrice();
                cbDiscountTypeName.DataSource = dataManager.DirectGetDiscountTypeName();
              
                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        #endregion

        #region 其它函数

        private void BuildComboBoxOfDicountPrice()
        {
            cbDiscountPrice = new ComboBox();

            cbDiscountPrice.DropDownStyle = ComboBoxStyle.DropDownList;

            cbDiscountPrice.ValueMember = "DiscountId";
            cbDiscountPrice.DisplayMember = "DiscountPrice";
            cbDiscountPrice.DataSource = dataManager.DirectGetDiscountPrice();
            cbDiscountPrice.SelectionChangeCommitted += new EventHandler(cbDiscountPrice_SelectionChangeCommitted);
            dgvList.Controls.Add(cbDiscountPrice);

            cbDiscountPrice.Visible = false;
        }

        private void BuildComboBoxOfDicountTypeName()
        {
            cbDiscountTypeName = new ComboBox();

            cbDiscountTypeName.DropDownStyle = ComboBoxStyle.DropDownList;

            cbDiscountTypeName.ValueMember = "DiscountTypeId";
            cbDiscountTypeName.DisplayMember = "DiscountTypeName";
            cbDiscountTypeName.DataSource = dataManager.DirectGetDiscountTypeName();
            cbDiscountTypeName.SelectionChangeCommitted += new EventHandler(cbDiscountTypeName_SelectionChangeCommitted);
            dgvList.Controls.Add(cbDiscountTypeName);

            cbDiscountTypeName.Visible = false;
        }

        /// <summary>
        /// 刷新所有数据
        /// </summary>
        private void RefreshDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSource.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dataBindingSource.DataSource = dataManager.GetDataList();
            bvNavigator.BindingSource = dataBindingSource;
            dgvList.DataSource = dataBindingSource;

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                FormatDataList();
        

            //ReSetDataArea();
            SetDataSize();
            SetDataLocate();
        }

        /// <summary>
        /// 刷新所有价格数据
        /// </summary>
        private void RefreshDataListOfPrice()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSourceOfPrice.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dataBindingSourceOfPrice.DataSource = dataManager.DirectGetDiscountPrice();
            dgvPriceList.DataSource = dataBindingSourceOfPrice;

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
            {
                if (this.dataGridViewColumnInfoPriceList != null && dgvPriceList != null && dgvPriceList.DataSource != null)
                {
                    dgvPriceList.FormatColumns(this.dataGridViewColumnInfoPriceList);
                    SetPriceDataLocate();
                }
            }
            //ReSetDataArea();
            SetPriceDataSize();
           
        }

        /// <summary>
        /// 刷新所有特价类型数据
        /// </summary>
        private void RefreshDataListOfType()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSourceOfType.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dataBindingSourceOfType.DataSource = dataManager.DirectGetDiscountTypeName();
            dgvTypeList.DataSource = dataBindingSourceOfType;

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
            {
                if (this.dataGridViewColumnInfoTypeList != null && dgvTypeList != null && dgvTypeList.DataSource != null)
                {
                    dgvTypeList.FormatColumns(this.dataGridViewColumnInfoTypeList);
                    SetTypeDataLocate();
                }
            }
            //ReSetDataArea();

            SetTypeDataSize();
           
        }

        private void SetDataSize()
        {
            if (dataBindingSource != null && dataBindingSource.DataSource != null && dgvList.DataSource != null)
            {
                int listWidth = 0;
                int listHeight = 0;
                // 设置列表大小
                if (dataBindingSource.Count <= 12)
                {
                    listWidth = dgvList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5;
                    listHeight = lblListTitle.Height + bvNavigator.Height + dgvList.ColumnHeadersHeight + dgvList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 2;
                }
                else
                {
                    listWidth = dgvList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5 + 15;
                    listHeight = lblListTitle.Height + bvNavigator.Height + dgvList.ColumnHeadersHeight + dgvList.Rows[0].Height * 12 + 2;
                }
                panList.Width = listWidth;
                panList.Height = listHeight;
            }
        }

        private void SetPriceDataSize()
        {
            if (dataBindingSourceOfPrice != null && dataBindingSourceOfPrice.DataSource != null && dgvPriceList.DataSource != null)
            {
                int listWidth = 0;
                int listHeight = 0;
                // 设置列表大小
                if (dataBindingSourceOfPrice.Count < 12)
                {
                    listWidth = dgvPriceList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5;
                    listHeight = lblPriceListTitle.Height + bvNavigator.Height + dgvPriceList.ColumnHeadersHeight + dgvPriceList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 2;
                }
                else
                {
                    listWidth = dgvPriceList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5 + 15;
                    listHeight = lblPriceListTitle.Height + bvNavigator.Height + dgvPriceList.ColumnHeadersHeight + dgvPriceList.Rows[0].Height * 12 + 2;
                }
                panDiscountPrice.Width = listWidth;
                panDiscountPrice.Height = listHeight;
            }
        }

        private void SetTypeDataSize()
        {
            if (dataBindingSourceOfType != null && dataBindingSourceOfType.DataSource != null && dgvTypeList.DataSource != null)
            {
                int listWidth = 0;
                int listHeight = 0;
                // 设置列表大小
                if (dataBindingSourceOfType.Count <= 11)
                {
                    listWidth = dgvTypeList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5;
                    listHeight = lblTypeListTitle.Height + bvNavigator.Height + dgvTypeList.ColumnHeadersHeight + dgvTypeList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 2;
                }
                else
                {
                    listWidth = dgvTypeList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 5 + 15;
                    listHeight = lblTypeListTitle.Height + bvNavigator.Height + dgvTypeList.ColumnHeadersHeight + dgvTypeList.Rows[0].Height * 12 + 2;
                }
                panDiscountType.Width = listWidth;
                panDiscountType.Height = listHeight;
            }
        }

        private void SetDataLocate()
        {
            if (dataBindingSource != null && dataBindingSource.DataSource != null && dgvList.DataSource != null)
            {
                panList.Location = new Point((this.Width - 8 - panList.Width) / 2, (this.Height - panTop.Height - panList.Height) / 2);
                btnAddDiscontInfo.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width - btnAddDiscontInfo.Width - btnDelDiscountInfo.Width, (this.Height - panTop.Height - panList.Height) / 2);
                btnDelDiscountInfo.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width - btnDelDiscountInfo.Width, (this.Height - panTop.Height - panList.Height) / 2);
                btnSaveDiscount_Type.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width - 3 * btnDelDiscountInfo.Width, (this.Height - panTop.Height - panList.Height) / 2);
            }
        }

        private void SetPriceDataLocate()
        {
            if (dataBindingSourceOfPrice != null && dataBindingSourceOfPrice.DataSource != null && dgvPriceList.DataSource != null)
            {
                panDiscountPrice.Location = new Point((this.Width - 8 - panList.Width) / 2 - panDiscountPrice.Width-25, (this.Height - panTop.Height - panList.Height) / 2);
                btnAddPrice.Location = new Point((this.Width - 8 - panList.Width) / 2 - panDiscountPrice.Width + panDiscountPrice.Width - (2 * btnAddPrice.Width), (this.Height - panTop.Height - panList.Height) / 2);
                btnDelPrice.Location = new Point((this.Width - 8 - panList.Width) / 2 - panDiscountPrice.Width + panDiscountPrice.Width - btnAddPrice.Width, (this.Height - panTop.Height - panList.Height) / 2);
                btnSavePrice.Location = new Point((this.Width - 8 - panList.Width) / 2 - panDiscountPrice.Width + panDiscountPrice.Width - 3*btnAddPrice.Width, (this.Height - panTop.Height - panList.Height) / 2);
            }
        }

        private void SetTypeDataLocate()
        {
            if (dataBindingSourceOfType != null && dataBindingSourceOfType.DataSource != null && dgvTypeList.DataSource != null)
            {
                panDiscountType.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width + 1, (this.Height - panTop.Height - panList.Height) / 2);
                btnAddDiscountType.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width + 1 + panDiscountType.Width - 2 * btnAddDiscountType.Width, (this.Height - panTop.Height - panList.Height) / 2);
                btnDelDiscountType.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width + 1 + panDiscountType.Width - btnAddDiscountType.Width, (this.Height - panTop.Height - panList.Height) / 2);
                btnSaveType.Location = new Point((this.Width - 8 - panList.Width) / 2 + panList.Width + 1 + panDiscountType.Width - 3 * btnAddDiscountType.Width, (this.Height - panTop.Height - panList.Height) / 2);
            }
        }
        /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //int? id=Convert.ToInt32(txtDiscount_TypeId.Text);
            if (dgv.Columns[e.ColumnIndex].Name.Contains("DiscountTypeId"))
            {
                try
                {
                    int? id = Convert.ToInt32(e.Value);
                    e.Value = dataManager.GetDiscountTypeName(id);
                }
                catch
                {
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Contains("DiscountId"))
            {
                try
                {
                    int? id = Convert.ToInt32(e.Value);
                    e.Value = dataManager.GetDiscountPrice(id);
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }

        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtDiscount_TypeId.DataBindings.Clear();
            cbTypeName.DataBindings.Clear();
            cbPrice.DataBindings.Clear();

            cbPrice.DataBindings.Add("SelectedValue", dataBindingSource, "DiscountId", true);
            cbTypeName.DataBindings.Add("SelectedValue", dataBindingSource, "DiscountTypeId", true);
            txtDiscount_TypeId.DataBindings.Add("Text", dataBindingSource, "Discount_TypeId", true);
        }

        /// <summary>
        /// 绑定下拉框:特价价格
        /// </summary>
        private void FillDiscountPrice()
        {
            cbPrice.DisplayMember = "DiscountPrice";
            cbPrice.ValueMember = "DiscountId";
            cbPrice.DataSource = dataManager.DirectGetDiscountPrice();
        }

        private void FillDiscountTypeName()
        {
            cbTypeName.DisplayMember = "DiscountTypeName";
            cbTypeName.ValueMember = "DiscountTypeId";
            cbTypeName.DataSource = dataManager.DirectGetDiscountTypeName();
        }
        #endregion
        #endregion

        private void btnAddDiscountPrice_Click(object sender, EventArgs e)
        {
            try
            {
                dataBindingSourceOfPrice.Add(dataManager.NewDataOfDiscountPrice());
                dataBindingSourceOfPrice.MoveLast();
                RefreshDataListOfPrice();
            }
            catch { }
        }

        private void btnDelDiscountPrice_Click(object sender, EventArgs e)
        {
            if (dataBindingSourceOfPrice.Current != null)
            {
                dataManager.DeleteDiscountPrice((Discount)dataBindingSourceOfPrice.Current);
                dataBindingSourceOfPrice.RemoveCurrent();
            }
        }

        private void btnAddDiscountTypeName_Click(object sender, EventArgs e)
        {
            try
            {
                dataBindingSourceOfType.Add(dataManager.NewDataOfTypeName());
                dataBindingSourceOfType.MoveLast();
                RefreshDataListOfType();
            }
            catch { }
        }

        private void btnDelDiscountTypeName_Click(object sender, EventArgs e)
        {
            if (dataBindingSourceOfType.Current != null)
            {
                dataManager.DeleteDiscountTypeName((DiscountType)dataBindingSourceOfType.Current);
                dataBindingSourceOfType.RemoveCurrent();
            }
        }
        public bool IsHave()
        {

            if (dataBindingSourceOfPrice.Count <= 0 || dataBindingSourceOfType.Count <= 0)

                return false;
            else
                return true;
        }

        private void btnAddDiscontInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsHave())
                {
                    dataBindingSource.Add(dataManager.NewData());
                    dataBindingSource.MoveLast();
                }
                else
                {
                    MessageBox.Show("请查看是否没有增加特价类型和特价价格的值\n", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //txtSpecialOfferName.Select();
            }
            catch { }
        }

        private void btnDelDiscountInfo_Click(object sender, EventArgs e)
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Discount_Type)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        private void btnSavePrice_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Enabled = false;
                this.btnEdit.Enabled = true;
                this.dataManager.Save();
                cbDiscountPrice.DataSource = dataManager.DirectGetDiscountPrice();
                cbDiscountTypeName.DataSource = dataManager.DirectGetDiscountTypeName();
                //cbDiscountPrice.Visible = false;
                //cbDiscountTypeName.Visible = false;
                    
                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

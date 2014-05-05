using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Flamingo.TicketManage
{
    //2011/12/23,Qiu
    public partial class frmVoucherBatchManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量

        private VoucherBatchManage dataManager;

        #endregion


        #region    启动处理
        public frmVoucherBatchManage()
        {
            InitializeComponent();

            dataManager = new VoucherBatchManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            this.Load += new EventHandler(frmFilmInfoManage_Load);
        }

        private void frmFilmInfoManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();

            BindData();

            FillList();

            txtKeyWord.Select();
        }
        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                List<VoucherBatch> voucherBatchList = new List<VoucherBatch>();
                string type;
                if (cbSearchType.SelectedItem.ToString() == "券类型")
                {
                    string[] list = dataManager.GetVoucherIdList("VoucherTypeName", txtKeyWord.Text.Trim());

                    foreach (string str in list)
                    {
                        if (str == null || str == string.Empty)
                            continue;
                        int id = Convert.ToInt32(str);
                        var tmp = dataManager.GetDataList().FindAll(p => p.VoucherTypeId == id);
                        if (tmp == null || tmp.Count <= 0)
                            continue;
                        foreach (var tmpobj in tmp)
                        {
                            var obj = dataManager.GetSearchList("VoucherBatchId", tmpobj.VoucherBatchId);
                            if (obj != null && obj.Count > 0)
                                voucherBatchList.AddRange(obj);
                        }
                    }
                    dataBindingSource.DataSource = voucherBatchList;
                }
                else
                    if (cbSearchType.SelectedItem.ToString() == "票券名称")
                    {
                        type = "VoucherName";
                        dataBindingSource.DataSource = dataManager.GetSearchList(type, txtKeyWord.Text.Trim());
                    }
                    else if (cbSearchType.SelectedItem.ToString() == "发行日期")
                    {
                        dataBindingSource.DataSource = dataManager.GetSearchList("ReleaseDate", txtKeyWord.Text.Trim());
                    }
                    else
                    {
                        string[] list = dataManager.GetVoucherSubTypeIdList("VoucherSubTypeName", txtKeyWord.Text.Trim());

                        foreach (string str in list)
                        {
                            if (str == null || str == string.Empty)
                                continue;
                            int id = Convert.ToInt32(str);
                            var tmp = dataManager.GetDataList().FindAll(p => p.VoucherSubTypeId == id);
                            if (tmp == null || tmp.Count <= 0)
                                continue;
                            foreach (var tmpobj in tmp)
                            {
                                var obj = dataManager.GetSearchList("VoucherBatchId", tmpobj.VoucherBatchId);
                                if (obj != null && obj.Count > 0)
                                    voucherBatchList.AddRange(obj);
                            }
                        }
                        dataBindingSource.DataSource = voucherBatchList;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有您要查询的数据!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name.Contains("Quantity"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value)).ToString() + "张";
                }
                catch
                {
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Contains("Price"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name == "VoucherTypeId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetVoucherTypeName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgv.Columns[e.ColumnIndex].Name == "VoucherSubTypeId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetVoucherSubTypeName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "CustomerId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetCustomerName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "IssuedBy")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetSueName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "PrintStatus")
            {
                int id =Convert.ToInt32(e.Value);
                if (id > 0)
                    e.Value = "是";
                else
                    e.Value = "否";
            
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

                txtVoucherName.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData() { }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((VoucherBatch)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            try
            {
                this.dataManager.Save();

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

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (Convert.ToInt32(((string)e.Value).Replace("张", string.Empty)));
            }
            catch
            {
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((int)e.Value).ToString() + "张";
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Parse1(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("元", string.Empty)));
            }
            catch
            {
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Format1(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((float)e.Value).ToString("0.00") + "元";
                }
                catch
                {

                }
            }
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

            ReSetDataArea();
        }


        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtVoucherBatchId.DataBindings.Clear();
            txtVoucherName.DataBindings.Clear();
            // txtVoucherPrice.DataBindings.Clear();
            txtUnitPrice.DataBindings.Clear();
            txtTotalPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            dtReleaseDate.DataBindings.Clear();
            txtSerialScope.DataBindings.Clear();
            dtExpireDate.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            cbIssuedBy.DataBindings.Clear();
            // cbTemplateId.DataBindings.Clear();
            cbVoucherSubTypeId.DataBindings.Clear();
            cbVoucherTypeId.DataBindings.Clear();
            cbCustomerName.DataBindings.Clear();
            chbIsActive.DataBindings.Clear();
            chbIsPrint.DataBindings.Clear();

            txtVoucherBatchId.DataBindings.Add("Text", dataBindingSource, "VoucherBatchId", true);
            txtVoucherName.DataBindings.Add("Text", dataBindingSource, "VoucherName", true);
            //  txtVoucherPrice.DataBindings.Add("Text", dataBindingSource, "VoucherPrice", true);
            txtUnitPrice.DataBindings.Add("Text", dataBindingSource, "UnitPrice", true);
            txtUnitPrice.DataBindings["Text"].Format += TextBox_Currency_Format1;
            txtUnitPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse1;

            txtTotalPrice.DataBindings.Add("Text", dataBindingSource, "TotalPrice", true);
            txtTotalPrice.DataBindings["Text"].Format += TextBox_Currency_Format1;
            txtTotalPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse1;

            txtQuantity.DataBindings.Add("Text", dataBindingSource, "Quantity", true);
            txtQuantity.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtQuantity.DataBindings["Text"].Parse += TextBox_Currency_Parse;

            dtReleaseDate.DataBindings.Add("Value", dataBindingSource, "ReleaseDate", true);
            txtSerialScope.DataBindings.Add("Text", dataBindingSource, "SerialScope", true);
            txtDescription.DataBindings.Add("Text", dataBindingSource, "Description", true);
            dtExpireDate.DataBindings.Add("Value", dataBindingSource, "ExpireDate", true);

            cbIssuedBy.DataBindings.Add("SelectedValue", dataBindingSource, "IssuedBy", true);
            //cbTemplateId.DataBindings.Add("SelectedValue", dataBindingSource, "TemplateId", true);
            cbVoucherSubTypeId.DataBindings.Add("SelectedValue", dataBindingSource, "VoucherSubTypeId", true);
            cbVoucherTypeId.DataBindings.Add("SelectedValue", dataBindingSource, "VoucherTypeId", true);
            cbCustomerName.DataBindings.Add("SelectedValue", dataBindingSource, "CustomerId", true);
            chbIsActive.DataBindings.Add("Checked", dataBindingSource, "ActiveFlag", true);
            chbIsPrint.DataBindings.Add("Checked", dataBindingSource, "PrintStatus", true);
        }

        /// <summary>
        /// 填充所有 ComboBox 控件数据
        /// </summary>
        private void FillList()
        {
            FillIssuedByList();
            // FillTemplateByList();
            FillVoucherSubTypeByList();
            FillVoucherTypeByList();
            FillCustomerList();
        }

        /// <summary>
        /// 填充下拉框：经手人
        /// </summary>
        private void FillIssuedByList()
        {
            cbIssuedBy.DisplayMember = "UserName";
            cbIssuedBy.ValueMember = "UserId";

            cbIssuedBy.DataSource = VoucherBatchManage.DirectGetIssued();
        }

        ///// <summary>
        ///// 填充下拉框：票版
        ///// </summary>
        //private void FillTemplateByList()
        //{
        //    cbTemplateId.DisplayMember = "TemplateName";
        //    cbTemplateId.ValueMember = "TemplateId";

        //    cbTemplateId.DataSource = VoucherBatchManage.DirectGetTemplate();
        //}

        /// <summary>
        /// 填充下拉框：票券子类型
        /// </summary>
        private void FillVoucherSubTypeByList()
        {
            cbVoucherSubTypeId.DisplayMember = "VoucherSubTypeName";
            cbVoucherSubTypeId.ValueMember = "VoucherSubTypeId";

            cbVoucherSubTypeId.DataSource = VoucherBatchManage.DirectGetVoucherSubType();
        }
        /// <summary>
        /// 填充下拉框：票券类型
        /// </summary>
        private void FillVoucherTypeByList()
        {
            cbVoucherTypeId.DisplayMember = "VoucherTypeName";
            cbVoucherTypeId.ValueMember = "VoucherTypeId";

            cbVoucherTypeId.DataSource = VoucherBatchManage.DirectGetVoucherType();
        }
        /// <summary>
        /// 填充下拉框：客户
        /// </summary>
        private void FillCustomerList()
        {
            cbCustomerName.DisplayMember = "CustomerName";
            cbCustomerName.ValueMember = "CustomerId";

            cbCustomerName.DataSource = VoucherBatchManage.DirectGetCustomer();
        }
        #endregion

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtUnitPrice.Text != "")
            {
                txtUnitPrice.Text = txtUnitPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtUnitPrice.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUnitPrice.DataBindings.Clear();
                    txtUnitPrice.DataBindings.Add("Text", dataBindingSource, "UnitPrice", true);
                    txtTotalPrice.DataBindings["Text"].Format += TextBox_Currency_Format1;
                    txtTotalPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse1;
                    txtUnitPrice.Clear();
                    txtUnitPrice.Focus();
                    return;
                }
            }
            else
            {
                txtUnitPrice.Text = "0";
            }
        }



        #endregion

        private void txtTotalPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtTotalPrice.Text != "")
            {
                txtTotalPrice.Text = txtTotalPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtTotalPrice.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalPrice.DataBindings.Clear();
                    txtTotalPrice.DataBindings.Add("Text", dataBindingSource, "TotalPrice", true);
                    txtTotalPrice.DataBindings["Text"].Format += TextBox_Currency_Format1;
                    txtTotalPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse1;
                    txtTotalPrice.Clear();
                    txtTotalPrice.Focus();
                    return;
                }
            }
            else
            {
                txtTotalPrice.Text = "0";
            }
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                txtQuantity.Text = (txtQuantity.Text).Replace("张", string.Empty);
                if (VoucherBatchManage.IsIntegerNumber(txtQuantity.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.DataBindings.Clear();
                    txtQuantity.DataBindings.Add("Text", dataBindingSource, "Quantity", true);
                    txtQuantity.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtQuantity.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtQuantity.Clear();
                    txtQuantity.Focus();
                    return;
                }

            }
            else
            {
                txtQuantity.Text = "0";
            }
        }
    }
}

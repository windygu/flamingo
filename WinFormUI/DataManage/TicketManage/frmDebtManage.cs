using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TicketManage
{
    //2011/12/22,Qiu
    //2011/12/23,Qiu
    public partial class frmDebtManage : Flamingo.BaseForm.frmManageBase
    {
        private DebtManage dataManager;


        #region    启动处理
        public frmDebtManage()
        {
            InitializeComponent();

            dataManager = new DebtManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            dataBindingSource.ListChanged += new ListChangedEventHandler(dataBindingSource_ListChanged);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            this.Load += new EventHandler(frmDebtManage_Load);
        }
        private void frmDebtManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            BindData();
            // 
            FillCustomerNameList();
            txtKeyWord.Select();
            // ReSetListLocate();
        }

        #endregion

        #region   窗体事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataManager.Save();

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name.Contains("Tickets"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value)).ToString() + "张";
                }
                catch
                {
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Contains("Amount"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("DebtStatus") && e.Value != null)
            {
                if (e.Value.ToString().ToLower() == "true")
                {
                    e.Value = "是";
                }
                else if (e.Value.ToString().ToLower() == "false")
                {
                    e.Value = "否";
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("CustomerId") && e.Value != null)
            {
                int id = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = dataManager.GetCustomerName(id);

                }
                catch { }
            }
        }

        /// <summary>
        /// 列表数据变化时，重置列表大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dataBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (panContainer.Dock != DockStyle.Fill)
            //{
            //    // ReSetListSize();
            //}
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //dataBindingSource.DataSource = dataManager.GetSearchList("CustomerName", txtKeyWord.Text.Trim());
            List<Debt> debtList = new List<Debt>();

            string[] list = dataManager.GetCustomerIdList("CustomerName", txtKeyWord.Text.Trim());

            foreach (string str in list)
            {
                if (str == null || str == string.Empty)
                    continue;
                int id = Convert.ToInt32(str);
                var tmp = dataManager.GetDataList().FindAll(p => p.CustomerId == id);
                if (tmp == null||tmp.Count<=0)
                    continue;
                foreach (var tmpobj in tmp)
                {
                    var obj = dataManager.GetSearchList("DebtId", tmpobj.DebtId);
                if (obj != null && obj.Count > 0)
                    debtList.AddRange(obj); 
                }
            }
            dataBindingSource.DataSource = debtList;

        }
        #endregion


        #region   窗体函数

        #region   继承父窗体函数
        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();

                this.dgvList["Buyer", dgvList.CurrentRow.Index].Selected = true;
                this.dgvList.BeginEdit(false);
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            if (this.dgvList.Rows.Count > 0)
            {
                this.dgvList["Buyer", 0].Selected = true;

                this.dgvList.BeginEdit(false);
            } 
            if (chbIsPayBack.Checked)
            {
                dtClearDate.Enabled = true;
            }
            else
                dtClearDate.Enabled = false;

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Debt)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            if (!chbIsPayBack.Checked&&txtDebtId.Text!=string.Empty)
            {
                List<Debt> list = new List<Debt>();
                list = dataBindingSource.DataSource as List<Debt>;
                list.Find(p => p.DebtId == txtDebtId.Text).ClearDate = null;
            }
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


        #region  其它函数

        public void RefreshDataList()
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

        private void FillCustomerNameList()
        {
            cbCustomerName.DisplayMember = "CustomerName";
            cbCustomerName.ValueMember = "CustomerId";
            cbCustomerName.DataSource = dataManager.GetCustomerNameList();
        }
        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {

            txtDebtId.DataBindings.Clear();
            // txtCustomerName.DataBindings.Clear();
            txtBuyer.DataBindings.Clear();
            //txtDownloadMethod.DataBindings.Clear();
            txtBankAccount.DataBindings.Clear();
            txtBankBranch.DataBindings.Clear();
            txtCasher.DataBindings.Clear();
            txtTickets.DataBindings.Clear();
            txtChequeNumber.DataBindings.Clear();
            txtAmount.DataBindings.Clear();
            dtBoughtDate.DataBindings.Clear();
            dtClearDate.DataBindings.Clear();
            chbIsPayBack.DataBindings.Clear();
            cbCustomerName.DataBindings.Clear();

            txtDebtId.DataBindings.Add("Text", dataBindingSource, "DebtId", true);
            txtBuyer.DataBindings.Add("Text", dataBindingSource, "Buyer", true);
            txtBankAccount.DataBindings.Add("Text", dataBindingSource, "BankAccount", true);
            txtBankBranch.DataBindings.Add("Text", dataBindingSource, "BankBranch", true);
            txtCasher.DataBindings.Add("Text", dataBindingSource, "Casher", true);
            txtTickets.DataBindings.Add("Text", dataBindingSource, "Tickets", true);
            txtTickets.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtTickets.DataBindings["Text"].Parse += TextBox_Currency_Parse;

            txtChequeNumber.DataBindings.Add("Text", dataBindingSource, "ChequeNumber", true);
            txtAmount.DataBindings.Add("Text", dataBindingSource, "Amount", true);
            txtAmount.DataBindings["Text"].Format += TextBox_Currency_Format1;
            txtAmount.DataBindings["Text"].Parse += TextBox_Currency_Parse1;

            dtClearDate.DataBindings.Add("Value", dataBindingSource, "ClearDate", true);
            dtBoughtDate.DataBindings.Add("Value", dataBindingSource, "BoughtDate", true);
            chbIsPayBack.DataBindings.Add("Checked", dataBindingSource, "DebtStatus", true);
            cbCustomerName.DataBindings.Add("SelectedValue", dataBindingSource, "CustomerId", true);
        }

        private void txtTickets_Validating(object sender, CancelEventArgs e)
        {
            if (txtTickets.Text != "")
            {
                txtTickets.Text = txtTickets.Text.Replace("张", string.Empty);
                if (VoucherBatchManage.IsIntegerNumber(txtTickets.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    txtTickets.DataBindings.Clear();
                    txtTickets.DataBindings.Add("Text", dataBindingSource, "Tickets", true);
                    txtTickets.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtTickets.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtTickets.Clear();
                    txtTickets.Focus();
                    return;
                }

            }
            else
            {
                txtTickets.Text = "0";
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

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (txtAmount.Text != "")
            {
                txtAmount.Text = txtAmount.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtAmount.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    txtAmount.DataBindings.Clear();
                    txtAmount.DataBindings.Add("Text", dataBindingSource, "Amount", true);
                    txtAmount.DataBindings["Text"].Format += TextBox_Currency_Format1;
                    txtAmount.DataBindings["Text"].Parse += TextBox_Currency_Parse1;
                    txtAmount.Clear();
                    txtAmount.Focus();
                    return;
                }

            }
            else
            {
                txtAmount.Text = "0";
            }
        }

        private void chbIsPayBack_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsPayBack.Checked)
            {
                dtClearDate.Enabled = true;
            }
            else
                dtClearDate.Enabled = false;
        }

        ///// <summary>
        ///// 重置列表大小
        ///// </summary>
        //protected void ReSetListSize()
        //{
        //    if (dataBindingSource.Count <= 12)
        //    {
        //        panContainer.Width = 1310;
        //        panContainer.Height = dataBindingSource.Count * 24 + 60;
        //    }
        //    else
        //    {
        //        panContainer.Width = 1327;
        //        panContainer.Height = 12 * 24 + 60;
        //    }
        //}
        #endregion


        #endregion





    }
}

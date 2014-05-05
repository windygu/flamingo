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
    //2011/12/21,Qiu
    //2011/12/23,Qiu
    public partial class frmCustomerManage : Flamingo.BaseForm.frmManageBase
    {
        private CustomerManage dataManager;


        #region    启动处理
        public frmCustomerManage()
        {

            InitializeComponent();

            dataManager = new CustomerManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            dataBindingSource.ListChanged += new ListChangedEventHandler(dataBindingSource_ListChanged);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            this.Load += new EventHandler(frmCustomerManage_Load);
        }
        private void frmCustomerManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            BindData();
            CustomerTypeNameList();
            txtKeyWord.Select();
            // ReSetListLocate();
        }

        #endregion


        #region  窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetSearchList("CustomerName", txtKeyWord.Text.Trim());
        }

        /// <summary>
        /// 判断电话号码的格式是否正确
        /// </summary>2012.1.9 LIN
        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (txtTelephone.Text != string.Empty)
            {
                string tel = txtTelephone.Text;
                //string s1 = @"(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,5}))?";
                //if (!Regex.IsMatch(tel, s1))
                //{
                //    MessageBox.Show("电话号码格式不正确", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtTelephone.Select();
                //}
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

        #endregion


        #region    窗体函数
        #region    继承父窗体函数
        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();

                // this.dgvList["CustomerName", dgvList.CurrentRow.Index].Selected = true;
                //this.dgvList.BeginEdit(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            //if (this.dgvList.Rows.Count > 0)
            //{
            //    this.dgvList["CustomerName", 0].Selected = true;

            //    this.dgvList.BeginEdit(false);
            //}
        }

        protected override void ApplyReadonlyConfig()
        {
            txtCustomerId.Enabled = false;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Customer)dataBindingSource.Current);
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



        #region    其他函数




        /// <summary>
        /// 填充下拉框:客户类型名称
        /// </summary>
        public void CustomerTypeNameList()
        {
            cbCustomerTypeName.DisplayMember = "CustomerTypeName";
            cbCustomerTypeName.ValueMember = "CustomerTypeId";
            cbCustomerTypeName.DataSource = dataManager.GetCustomerTypeNameList();
        }

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

        /// <summary>
        /// 格式化GridView明细:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "CustomerTypeId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = CustomerManage.GetCustomerTypeName(Convert.ToInt32(nId));
                }
                catch { }
            }
        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {

            txtCustomerId.DataBindings.Clear();
            txtCustomerName.DataBindings.Clear();
            txtBankAccount.DataBindings.Clear();
            txtBankBranch.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtContact.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtTelephone.DataBindings.Clear();
            cbCustomerTypeName.DataBindings.Clear();

            txtCustomerId.DataBindings.Add("Text", dataBindingSource, "CustomerId", true);
            txtCustomerName.DataBindings.Add("Text", dataBindingSource, "CustomerName", true);
            txtBankAccount.DataBindings.Add("Text", dataBindingSource, "BankAccount", true);
            txtBankBranch.DataBindings.Add("Text", dataBindingSource, "BankBranch", true);
            txtEmail.DataBindings.Add("Text", dataBindingSource, "Email", true);
            txtContact.DataBindings.Add("Text", dataBindingSource, "Contact", true);
            txtAddress.DataBindings.Add("Text", dataBindingSource, "Address", true);
            txtTelephone.DataBindings.Add("Text", dataBindingSource, "Telephone", true);
            cbCustomerTypeName.DataBindings.Add("SelectedValue", dataBindingSource, "CustomerTypeId", true);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (txtEmail.Text != "")
            {
                string s1 = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Match m = Regex.Match(txtEmail.Text, s1);
                if (!m.Success)
                {
                    MessageBox.Show("请输入正确的Email地址", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Clear();
                    txtEmail.DataBindings.Clear();
                    txtEmail.DataBindings.Add("Text", dataBindingSource, "Email", true);
                    txtEmail.Focus();
                    return;
                }
            }

        }
        ///// <summary>
        ///// 重置列表大小
        ///// </summary>
        //protected void ReSetListSize()
        //{
        //    if (dataBindingSource.Count <= 12)
        //    {
        //        panContainer.Width = 930;
        //        panContainer.Height = dataBindingSource.Count * 24 + 60;
        //    }
        //    else
        //    {
        //        panContainer.Width = 930;
        //        panContainer.Height = 12 * 24 + 60;
        //    }
        //}

        #endregion

        #endregion

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    dataManager.Save();

        //    this.DialogResult = DialogResult.OK;
        //}



    }
}

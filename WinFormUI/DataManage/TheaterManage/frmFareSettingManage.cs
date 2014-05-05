using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Flamingo.TicketManage;


namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmFareSettingManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体 变量
        private FareSettingManage dataManager;

        #endregion

        #region 启动处理
        public frmFareSettingManage()
        {
            InitializeComponent();


            dataManager = new FareSettingManage();
            dataBindingSource = new BindingSource();



            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            this.dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            this.Load += new EventHandler(frmFareSettingManage_Load);

        }

        private void frmFareSettingManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            BindData();
            txtFare.Select();
            // ReSetListLocate();
        }

        #endregion

        #region 窗体事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtFare.Text == "")
            {
                MessageBox.Show("请输入票价设置名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFare.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("FareSettingName", txtFare.Text.Trim());
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_Currency_Parse(object sender, ConvertEventArgs e)
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
        public void TextBox_Currency_Format(object sender, ConvertEventArgs e)
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

                txtFareSettingName.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void ApplyReadonlyConfig()
        {
            txtFareSettingId.Enabled = false;
            txtFareSettingName.Enabled = false;
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            txtFareSettingName.Select();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((FareSetting)dataBindingSource.Current);
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
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

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
        }

        //private void textBoxFormat()
        //{
        //    txtBoxPrice.Text = String.Format("{0} {1}", txtBoxPrice.Text, "元");
        //}

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
            txtFareSettingId.DataBindings.Clear();
            txtFareSettingName.DataBindings.Clear();
            txtSinglePrice.DataBindings.Clear();
            txtDoublePrice.DataBindings.Clear();
            txtGroupPrice.DataBindings.Clear();
            txtMemberPrice.DataBindings.Clear();
            txtBoxPrice.DataBindings.Clear();
            txtStudentPrice.DataBindings.Clear();

            txtFareSettingId.DataBindings.Add("Text", dataBindingSource, "FareSettingId", true);
            txtFareSettingName.DataBindings.Add("Text", dataBindingSource, "FareSettingName", true);
            txtSinglePrice.DataBindings.Add("Text", dataBindingSource, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtSinglePrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;

            txtDoublePrice.DataBindings.Add("Text", dataBindingSource, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtDoublePrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
            
            txtGroupPrice.DataBindings.Add("Text", dataBindingSource, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtGroupPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
            
            txtMemberPrice.DataBindings.Add("Text", dataBindingSource, "MemberPrice", true);
            txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtMemberPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
            
            txtBoxPrice.DataBindings.Add("Text", dataBindingSource, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtBoxPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;

            txtStudentPrice.DataBindings.Add("Text", dataBindingSource, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtStudentPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
        }


        #endregion

        private void txtStudentPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtStudentPrice.Text != "")
            {
                txtStudentPrice.Text = txtStudentPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtStudentPrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    txtStudentPrice.DataBindings.Clear();
                    txtStudentPrice.DataBindings.Add("Text", dataBindingSource, "StudentPrice", true);
                    txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtStudentPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtStudentPrice.Clear();
                    txtStudentPrice.Focus();
                    return;
                }

            }
            else
            {
                txtStudentPrice.Text = "0";
            }
        }

        #endregion

        private void txtSinglePrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtSinglePrice.Text != "")
            {
                txtSinglePrice.Text = txtSinglePrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtSinglePrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    txtSinglePrice.DataBindings.Clear();
                    txtSinglePrice.DataBindings.Add("Text", dataBindingSource, "SinglePrice", true);
                    txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtSinglePrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtSinglePrice.Clear();
                    txtSinglePrice.Focus();
                    return;
                }

            }
            else
            {
                txtSinglePrice.Text = "0";
            }
        }

        private void txtMemberPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtMemberPrice.Text != "")
            {
                txtMemberPrice.Text = txtMemberPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtMemberPrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                    txtMemberPrice.DataBindings.Clear();
                    txtMemberPrice.DataBindings.Add("Text", dataBindingSource, "MemberPrice", true);
                    txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtMemberPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtMemberPrice.Clear();
                    txtMemberPrice.Focus();
                    return;
                }

            }
            else
            {
                txtMemberPrice.Text = "0";
            }
        }

        private void txtBoxPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtBoxPrice.Text != "")
            {
                txtBoxPrice.Text = txtBoxPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtBoxPrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBoxPrice.Clear();
                    txtBoxPrice.DataBindings.Clear();
                    txtBoxPrice.DataBindings.Add("Text", dataBindingSource, "BoxPrice", true);
                    txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtBoxPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtBoxPrice.Focus();
                    return;
                }

            }
            else
            {
                txtBoxPrice.Text = "0";
            }
        }

        private void txtDoublePrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtDoublePrice.Text != "")
            {
                txtDoublePrice.Text = txtDoublePrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtDoublePrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDoublePrice.Clear();
                    txtDoublePrice.DataBindings.Clear();
                    txtDoublePrice.DataBindings.Add("Text", dataBindingSource, "DoublePrice", true);
                    txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtDoublePrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtDoublePrice.Clear();
                    txtDoublePrice.Focus();
                    return;
                }

            }
            else
            {
                txtBoxPrice.Text = "0";
            }
        }

        private void txtGroupPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtGroupPrice.Text != "")
            {
                txtGroupPrice.Text = txtGroupPrice.Text.Replace("元", string.Empty);
                if (VoucherBatchManage.IsNumber(txtGroupPrice.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    txtGroupPrice.DataBindings.Clear();
                    txtGroupPrice.DataBindings.Add("Text", dataBindingSource, "GroupPrice", true);
                    txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtGroupPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtGroupPrice.Clear();
                    txtGroupPrice.Focus();
                    return;
                }

            }
            else
            {
                txtGroupPrice.Text = "0";
            }
        }
    }
}

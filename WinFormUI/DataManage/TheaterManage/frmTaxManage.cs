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
    //2011.12.23 LIN
    public partial class frmTaxManage : Flamingo.BaseForm.frmManageBase
    { 
        #region 窗体变量

        private TaxManage dataManager;

        #endregion

        #region 启动处理
        public frmTaxManage()
        {
            InitializeComponent();

            //2011.12.24 LiN
            txtTaxId.ReadOnly = true;
            txtTheaterId.ReadOnly = true;

            dataManager = new TaxManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);

         
            this.Load += new EventHandler(frmTaxManage_Load);
        }

        private void frmTaxManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            
            BindData();
           
            txtTaxType.Select();
            // ReSetListLocate();
        }

        #endregion


        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            
            if (txtTaxType.Text == "")
            {
                MessageBox.Show("请输入税费类型名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTaxType.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("TaxType", txtTaxType.Text.Trim());
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

            if (dgv.Columns[e.ColumnIndex].Name.Contains("TaxRate"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value)*100).ToString() + "%";
                }
                catch
                {
                }
            }
        }


        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Percent_Format(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value =((float)e.Value * 100).ToString() + "%";
            }
            catch
            {
            }
        }

        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void TextBox_Percent_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("%", string.Empty)) / 100);
            }
            catch{
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
              
                txtaxType.Select();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            txtaxType.Select();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Tax)dataBindingSource.Current);
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
            txtTaxId.DataBindings.Clear();
            txtTheaterId.DataBindings.Clear();
            txtaxType.DataBindings.Clear();
            txtRate.DataBindings.Clear();
            //txtChargeMethod.DataBindings.Clear();
            cbChargeMethod.DataBindings.Clear();

            txtTaxId.DataBindings.Add("Text", dataBindingSource, "TaxId", true);
            txtTheaterId.DataBindings.Add("Text", dataBindingSource, "TheaterId", true);
            txtaxType.DataBindings.Add("Text", dataBindingSource, "TaxType", true);
            txtRate.DataBindings.Add("Text", dataBindingSource, "TaxRate",true);
            txtRate.DataBindings["Text"].Format += TextBox_Percent_Format;
            txtRate.DataBindings["Text"].Parse += TextBox_Percent_Parse;
            //txtChargeMethod.DataBindings.Add("Text", dataBindingSource, "ChargeMethod", true);
            cbChargeMethod.DataBindings.Add("Text",dataBindingSource, "ChargeMethod", true);
        }

    
        #endregion

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            if (txtRate.Text != "")
            {
                if (VoucherBatchManage.IsNumber(txtRate.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRate.Clear();
                    txtRate.DataBindings.Clear();
                    txtRate.DataBindings.Add("Text", dataBindingSource, "TaxRate", true);
                    txtRate.Focus();
                    return;
                }

            }
            else
            {
                txtRate.Text = "0";
            }
        }

        #endregion        
    }
}

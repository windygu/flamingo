using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TicketManage
{
    //2011.12.23 Qiu 
    public partial class frmVoucherTypeManage : BaseForm.frmManageBase
    {

        private VoucherTypeManage dataManager;


        #region    启动处理
        public frmVoucherTypeManage()
        {

            InitializeComponent();

            dataManager = new VoucherTypeManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            dataBindingSource.ListChanged += new ListChangedEventHandler(dataBindingSource_ListChanged);

            this.Load += new EventHandler(frmVoucherTypeManage_Load);
        }
        private void frmVoucherTypeManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            
            txtKeyWord.Select();
            // ReSetListLocate();
        }


        #endregion

        #region    窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetSearchList("VoucherTypeName", txtKeyWord.Text.Trim());

        }

        /// <summary>
        /// 列表数据变化时，重置列表大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dataBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (panList.Dock != DockStyle.Fill)
            {
                // ReSetListSize();
            }
        }

        #endregion

        #region   窗体函数

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

                this.dgvList["VoucherTypeName", dgvList.CurrentRow.Index].Selected = true;
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
                this.dgvList["VoucherTypeName", 0].Selected = true;

                this.dgvList.BeginEdit(false);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((VoucherType)dataBindingSource.Current);
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

        #region   其它函数

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
        /// 重置列表大小
        /// </summary>
        protected void ReSetListSize()
        {
            if (dataBindingSource.Count <= 12)
            {
                panList.Width = 215;
                panList.Height = dataBindingSource.Count * 24 + 60;
            }
            else
            {
                panList.Width = 230;
                panList.Height = 12 * 24 + 60;
            }
        }     
        #endregion
        #endregion



    }
}

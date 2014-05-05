using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmShowTypeManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量
        private ShowTypeManage dataManager;

        #endregion

        #region 启动处理
        public frmShowTypeManage()
        {
            InitializeComponent();

            dataManager = new ShowTypeManage();
            dataBindingSource = new BindingSource();

            txtShowTypeId.ReadOnly = true;

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            //dataBindingSource.ListChanged += new ListChangedEventHandler(dataBindingSource_ListChanged);
           
            this.Load += new EventHandler(frmShowTypeManage_Load);
        }

        private void frmShowTypeManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            BindData();
            txtShowTypeName.Select();
            // ReSetListLocate();

        }

        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtShowTypeName.Text == "")
            {
                MessageBox.Show("请输入场次类型名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtShowTypeName.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("ShowTypeName", txtShowTypeName.Text.Trim());
            }
        }

        ///// <summary>
        ///// 列表数据变化时，重置列表大小
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void dataBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    if (panContainer.Dock != DockStyle.Fill)
        //    {
        //        // ReSetListSize();
        //    }
        //}

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
                 
                txtShowTypeN.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {          
            txtShowTypeN.Select();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((ShowType)dataBindingSource.Current);
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
            txtShowTypeId.DataBindings.Clear();
            txtShowTypeN.DataBindings.Clear();

            txtShowTypeN.DataBindings.Add("Text", dataBindingSource, "ShowTypeName", true);
            txtShowTypeId.DataBindings.Add("Text", dataBindingSource, "ShowTypeId", true);
        }

        ///// <summary>
        ///// 重置列表大小
        ///// </summary>
        //protected void ReSetListSize()
        //{
        //    if (dataBindingSource.Count <= 12)
        //    {
        //        panContainer.Width = 290;
        //        panContainer.Height = dataBindingSource.Count * 24 + 60;
        //    }
        //    else
        //    {
        //        panContainer.Width = 240;
        //        panContainer.Height = 12 * 24 + 60;
        //    }
        //}    

        #endregion

        #endregion        
    }
}

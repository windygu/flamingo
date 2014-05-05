using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.FilmManage
{
    // 2011.12.20, Qiu
    // 2011.12.22, Jiang
    public partial class frmFilmCategoryManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量

        private FilmCategoryManage dataManager;

        #endregion

        #region 启动处理

        public frmFilmCategoryManage()
        {
            InitializeComponent();

            lblListTitle.Text = "影片类型信息";

            dataManager = new FilmCategoryManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            this.Load += new EventHandler(frmFilmCategoryManage_Load);
        }

        private void frmFilmCategoryManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();

            txtKeyWord.Select();

            // ReSetListLocate();
        }

        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetSearchList("FilmCategoryName", txtKeyWord.Text.Trim());
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

                this.dgvList["FilmCategoryName", dgvList.CurrentRow.Index].Selected = true;
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
                this.dgvList["FilmCategoryName", 0].Selected = true;

                this.dgvList.BeginEdit(false);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            dataManager.DeleteData((FilmCategory)dataBindingSource.Current);
            dataBindingSource.RemoveCurrent();
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

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RCLibrary;

namespace Flamingo.BaseForm
{
    public partial class frmManageBase : Form
    {
        #region 窗体变量

        /// <summary>
        /// 数据源，需要在构造函数中实例化
        /// </summary>
        protected BindingSource dataBindingSource;

        /// <summary>
        /// 信息明细的列信息表
        /// </summary>
        protected List<DataGridViewColumnInfo> dataGridViewColumnInfoList;

        #endregion

        #region 启动处理

        public frmManageBase()
        {
            InitializeComponent();

            this.btnSave.Enabled = false;

            this.Load += new EventHandler(frmManageBase_Load);

            this.dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);

            panDetail.Location = new Point(0, 0);
            panList.Location = new Point(0, panDetail.Height + 2);
        }

        /// <summary>
        /// 窗体第一次加载的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmManageBase_Load(object sender, EventArgs e)
        {
            EndEdit();

            if (this.dataBindingSource != null)
                this.dataBindingSource.ListChanged += new ListChangedEventHandler(dataBindingSource_Base_ListChanged);

            dgvList.Select();

            ReSetDataSize();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 如果列表数量为0，则删除按钮不可点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataBindingSource_Base_ListChanged(object sender, EventArgs e)
        {
            if (dataBindingSource != null && dataBindingSource.DataSource != null)
            {
                if (dataBindingSource.Count > 0)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }

                ReSetDataSize();
            }
        }

        /// <summary>
        /// 点击数据表单元格时，立刻进入编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.CurrentCell != null && e.ColumnIndex != -1)
            {
                this.dgvList.BeginEdit(false);

            }
        }

        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected virtual void FormatDataList()
        {
            // 如果有明细数据控件，则不能在表单中直接修改，且自动计算表单高度
            bool hasDetail = false;
            foreach (Control con in panDetail.Controls)
            {
                if (con != lblDetailTitle)
                {
                    hasDetail = true;
                    break;
                }
            }

            panDetail.Visible = hasDetail;
            dgvList.ReadOnly = hasDetail;

            if (this.dataGridViewColumnInfoList != null && dgvList != null && dgvList.DataSource != null)
                dgvList.FormatColumns(this.dataGridViewColumnInfoList);
        }

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BeginEdit();
            ApplyReadonlyConfig();
            AddData();
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            BeginEdit();
            ApplyReadonlyConfig();
            EditData();

            if (dataBindingSource != null && dataBindingSource.DataSource != null)
            {
                if (dataBindingSource.Count > 0)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            BeginEdit();
            ApplyReadonlyConfig();
            DelData();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save() == true)
                EndEdit();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            // 如果数据未保存，弹出窗口提示
            if (this.btnSave.Enabled == true)
            {
                if (MessageBox.Show("数据未保存，请确定是否返回?", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;
            }

            this.Close();
        }

        #endregion

        #region 窗体函数

        #region 其它函数

        /// <summary>
        /// 设置数据区域的位置及大小
        /// </summary>
        protected void ReSetDataArea()
        {
            ReSetDataSize();
            ReSetDataLocate();
        }

        /// <summary>
        /// 设置数据区域的大小
        /// </summary>
        protected void ReSetDataSize()
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

                if (listWidth > (this.Width - 8 - 12))
                {
                    listWidth = this.Width - 8 - 12;
                    listHeight += 15 + 2;
                }

                panList.Width = listWidth;
                panList.Height = listHeight;

                dgvList.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// 设置数据区域的位置
        /// </summary>
        protected void ReSetDataLocate()
        {
            if (dataBindingSource != null && dataBindingSource.DataSource != null && dgvList.DataSource != null)
            {
                int xFix = 0;
                int yFix = 0;

                if (dataBindingSource.Count < 12)
                {
                    //xFix = 15;
                    yFix = (12 - dataBindingSource.Count) * dgvList.RowTemplate.Height;
                }

                // 设置表单位置
                if (panDetail.Visible == true)
                    panDetail.Location = new Point((this.Width - 8 - panDetail.Width) / 2, (this.Height - panTop.Height - panDetail.Height - panList.Height - yFix) / 2);

                if (panDetail.Visible == true && panDetail.Location.Y < panTop.Height + 10)
                {
                    yFix = panTop.Height + 10 - panDetail.Location.Y;

                    panDetail.Location = new Point(panDetail.Location.X, panDetail.Location.Y + yFix);
                }

                // 设置列表位置
                if (panDetail.Visible == true)
                {
                    panList.Location = new Point((this.Width - 8 - panList.Width - xFix) / 2, panDetail.Location.Y + panDetail.Height + 10);
                }
                else
                {
                    panList.Location = new Point((this.Width - 8 - panList.Width - xFix) / 2, (this.Height - panTop.Height - panList.Height - yFix) / 2);
                }
            }
        }

        /// <summary>
        /// 开始编辑，将明细数据控件置为可编辑
        /// </summary>
        private void BeginEdit()
        {
            foreach (Control con in panDetail.Controls)
            {
                if (con.GetType() == typeof(Label))
                    continue;

                con.Enabled = true;
            }

            // 如果没有明细控件，允许直接改表单
            if (panDetail.Visible == true)
                this.dgvList.ReadOnly = true;
            else
                this.dgvList.ReadOnly = false;

            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;
        }

        /// <summary>
        /// 结束编辑，将明细数据控件置为不可编辑
        /// </summary>
        private void EndEdit()
        {
            foreach (Control con in panDetail.Controls)
            {
                if (con.GetType() == typeof(Label))
                    continue;

                con.Enabled = false;
            }

            this.dgvList.ReadOnly = true;

            this.btnEdit.Enabled = true;
            this.btnSave.Enabled = false;
        }

        #endregion

        #region 所有继承的窗体，必须重写的函数

        /// <summary>
        /// 新增数据
        /// </summary>
        protected virtual void AddData() { }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected virtual void EditData() { }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected virtual void DelData() { }

        /// <summary>
        /// 应用只读配置
        /// </summary>
        protected virtual void ApplyReadonlyConfig() { }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual bool Save() { return true; }

        #endregion

        #endregion
    }
}

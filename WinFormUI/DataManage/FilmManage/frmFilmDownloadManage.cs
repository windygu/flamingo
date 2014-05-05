using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.FilmManage
{
    // 2012.12.24, Jiang
    public partial class frmFilmDownloadManage : Flamingo.BaseForm.frmManageBase
    {

        #region 窗体变量

        public  delegate void DelegateRefresh();
        public event DelegateRefresh EventRefresh;
        public event EventHandler FilmInfoChanged;

        private FilmDownloadManage dataManager;

        #endregion

        #region 启动处理

        public frmFilmDownloadManage()
        {
            InitializeComponent();

            lblListTitle.Text = "影片下载信息";

            dataManager = new FilmDownloadManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            this.Load += new EventHandler(frmFilmDownloadManage_Load);
        }

        public void frmFilmDownloadManage_Load(object sender, EventArgs e)
        {


            RefreshDataList();

            LoadParameter();

            this.dgvList.ReadOnly = false;
        }

        #endregion

        #region 窗体事件

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = null;
            dataBindingSource.DataSource = dataManager.GetSearchList(this.txtKeyWord.Text);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            if (dataBindingSource.DataSource != null)
            {
                foreach (FilmDownloadInfo data in (List<FilmDownloadInfo>)dataBindingSource.DataSource)
                {
                    data.Check = !data.Check;
                }

                dgvList.Refresh();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataBindingSource.DataSource != null)
            {
                foreach (FilmDownloadInfo data in (List<FilmDownloadInfo>)dataBindingSource.DataSource)
                {
                    data.Check = true;
                }

                dgvList.Refresh();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                dataManager.Import();

                //刷新影片维护窗体信息
                RefreshfrmFilmInfoManage();

                if (FilmInfoChanged != null)
                    FilmInfoChanged(this, EventArgs.Empty);

                MessageBox.Show("导入成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 窗体函数

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
        /// 重置列表大小
        /// </summary>
        protected void ReSetListSize()
        {
            if (dataBindingSource.Count <= 12)
            {
                panList.Width = 930;
                panList.Height = dataBindingSource.Count * 24 + 60;
            }
            else
            {
                panList.Width = 1340;
                panList.Height = 12 * 24 + 60;
            }
        }    
        private void Download()
        {
            try
            {
                dataManager.Download(cbStartYear.Text);

                dataBindingSource.DataSource = null;

                if (this.txtKeyWord.Text.Trim() == string.Empty)
                {
                    dataBindingSource.DataSource = dataManager.GetDataList();
                }
                else
                {
                    dataBindingSource.DataSource = dataManager.GetSearchList(this.txtKeyWord.Text);
                }

                MessageBox.Show("下载成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("下载失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 刷新影片维护窗体信息
        /// </summary>
        private void RefreshfrmFilmInfoManage()
        {
            if (this.EventRefresh == null)
            {
                foreach (Form objfrom in this.MdiParent.MdiChildren)
                {
                    if (objfrom is frmFilmInfoManage)
                    {
                        frmFilmInfoManage frm = (frmFilmInfoManage)objfrom;
                        this.EventRefresh += new DelegateRefresh(frm.RefreshDataList);
                        break;
                    }
                }
            }
            if (this.EventRefresh != null)
                this.EventRefresh();

        }

        private void LoadParameter()
        {
            try
            {
                cbStartYear.Items.Clear();

                int startYear = Convert.ToInt32(Property.Setting.StartYear);

                for (int year = startYear; year <= DateTime.Now.Year; year++)
                {
                    cbStartYear.Items.Add(year);
                }

                cbStartYear.SelectedIndex = cbStartYear.Items.Count - 1;
            }
            catch
            {
                cbStartYear.Text = DateTime.Now.Year.ToString();
            }
        }

        #endregion

        #endregion
    }
}

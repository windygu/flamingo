using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Flamingo.TicketManage;

namespace Flamingo.FilmManage
{
    //2011/12/22,Qiu
    public partial class frmDownloadSettingManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量
        private DownloadSettingManage dataManager;

        #endregion

        #region 启动处理

        public frmDownloadSettingManage()
        {
            InitializeComponent();

            lblListTitle.Text = "数据下载信息表";

            //2011.12.24 LIN
            txtDownloadId.ReadOnly = true;
            // txtTheaterId.ReadOnly = true;

            dataManager = new DownloadSettingManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);

            this.Load += new EventHandler(frmDownloadSettingManage_Load);
        }
        private void frmDownloadSettingManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();

            BindData();

            txtSourceName.Select();
            // ReSetListLocate();
        }

        #endregion

        #region 窗体事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtSourceName.Text == "")
            {
                MessageBox.Show("请输入下载源名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSourceName.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("SourceName", txtSourceName.Text.Trim());
            }
        }

        /// <summary>
        /// 下载id变更时重新绑定radiobutton
        /// </summary>2012.1.9 LIN
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDownloadId_TextChanged(object sender, EventArgs e)
        {
            FillRadilButton();
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

                txtSourceN.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            this.txtSourceN.Select();
        }

        protected override void ApplyReadonlyConfig()
        {
            txtDownloadId.Enabled = false;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((DownloadSetting)dataBindingSource.Current);
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

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("Is") && e.Value != null)
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
        }
        //2012.1.9 LIN 
        private void FillRadilButton()
        {
            string method = dataManager.GetDownloadMethod(txtDownloadId.Text);
            if (method == "HTTP")
            {
                rbHttp.Checked = true;
            }
            else if (method == "FTP")
            {
                rbFtp.Checked = true;
            }
            else
            {
                rbDocument.Checked = true;
            }
        }
        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtDownloadId.DataBindings.Clear();
            // txtTheaterId.DataBindings.Clear();
            txtSourceN.DataBindings.Clear();
            //txtDownloadMethod.DataBindings.Clear();
            txtDownloadAddr.DataBindings.Clear();
            txtPort.DataBindings.Clear();
            txtUserName.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtProxyPort.DataBindings.Clear();
            txtProxyServer.DataBindings.Clear();
            chbIsAnonymAllowed.DataBindings.Clear();
            chbIsProxy.DataBindings.Clear();

            txtDownloadId.DataBindings.Add("Text", dataBindingSource, "DownloadId", true);
            //  txtTheaterId.DataBindings.Add("Text", dataBindingSource, "TheaterId", true);
            txtSourceN.DataBindings.Add("Text", dataBindingSource, "SourceName", true);
            // txtDownloadMethod.DataBindings.Add("Text", dataBindingSource, "DownloadMethod", true);
            txtDownloadAddr.DataBindings.Add("Text", dataBindingSource, "DownloadAddr", true);
            txtPort.DataBindings.Add("Text", dataBindingSource, "Port", true);
            txtUserName.DataBindings.Add("Text", dataBindingSource, "UserName", true);
            txtPassword.DataBindings.Add("Text", dataBindingSource, "Password", true);
            txtProxyPort.DataBindings.Add("Text", dataBindingSource, "ProxyPort", true);
            txtProxyServer.DataBindings.Add("Text", dataBindingSource, "ProxyServer", true);
            chbIsAnonymAllowed.DataBindings.Add("Checked", dataBindingSource, "IsAnonymAllowed", true);
            chbIsProxy.DataBindings.Add("Checked", dataBindingSource, "IsProxy", true);
        }

        #endregion

        #endregion

        private void rbHttp_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                List<DownloadSetting> list = new List<DownloadSetting>();
                list = dataBindingSource.DataSource as List<DownloadSetting>;
                list.Find(p => p.DownloadId == Convert.ToInt32(txtDownloadId.Text.Trim())).DownloadMethod = ((RadioButton)sender).Tag.ToString();
            }
        }

        private void txtProxyPort_Validating(object sender, CancelEventArgs e)
        {
            if (txtProxyPort.Text != "")
            {
                if (VoucherBatchManage.IsIntegerNumber(txtProxyPort.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProxyPort.Clear();
                    txtProxyPort.DataBindings.Clear();
                    txtProxyPort.DataBindings.Add("Text", dataBindingSource, "ProxyPort", true);
                    txtProxyPort.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProxyPort.Focus();
                return;
            }
        }

        private void txtPort_Validating(object sender, CancelEventArgs e)
        {
            if (txtPort.Text != "")
            {
                if (VoucherBatchManage.IsIntegerNumber(txtPort.Text) == false)
                {
                    MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPort.Clear();
                    txtPort.DataBindings.Clear();
                    txtPort.DataBindings.Add("Text", dataBindingSource, "Port", true);
                    txtPort.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
                return;
            }
        }



    }
}

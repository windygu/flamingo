using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmUploadSettingManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量
        private UploadSettingManage dataManager;

        #endregion

        #region 启动处理
        public frmUploadSettingManage()
        {
            InitializeComponent();

            dataManager = new UploadSettingManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            //2011.12.24 LIN 
            txtUploadId.ReadOnly = true;
            // txtTheaterId.ReadOnly = true;

            this.Load += new EventHandler(frmUploadSettingManage_Load);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);

        }

        private void frmUploadSettingManage_Load(object sender, EventArgs e)
        {
            RefreshDataList();
            FillUploadMethodList();
            FillUploadUintName();
            FillUploadFileFormat();
            BindData();
            txtTargetName.Select();
            // ReSetListLocate();
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("IsActive") && e.Value != null)
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
            if (dgvList.Columns[e.ColumnIndex].Name == "TheaterId")
            {
                string nId;
                nId = e.Value.ToString();
                try
                {
                    e.Value = dataManager.GetTheaterName(nId);

                }
                catch { }
            }

        }
        #endregion

        #region 窗体事件

        private void btnQuery_Click(object sender, EventArgs e)
        {

            if (txtTargetName.Text == "")
            {
                MessageBox.Show("请输入上传目标名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTargetName.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("TargetName", txtTargetName.Text.Trim());
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

                txtTargetN.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            txtUploadId.ReadOnly = true;
            //txtTheaterId.ReadOnly = true;
            txtTargetN.Select();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((UploadSetting)dataBindingSource.Current);
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
        /// 填充下拉框
        /// </summary>
        private void FillUploadMethodList()
        {
            cbUploadMethod.DisplayMember = "UploadMethod";
            //bUploadMethod.ValueMember = "TheaterId"   

            cbUploadMethod.DataSource = dataManager.GetUploadSettingList();
        }

        private void FillUploadFileFormat()
        {
            cbFileFormat.DisplayMember = "FileFormat";
            cbFileFormat.DataSource = dataManager.GetFileFormat();
        }
        private void FillUploadUintName()
        {
            //cbName.DisplayMember = "TheaterName";
            //cbName.ValueMember = "TheaterId";

            //cbName.DataSource = TheaterInfoManage.DirectGetAllList();
        }
        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtUploadId.DataBindings.Clear();
            //txtTheaterId.DataBindings.Clear();
            txtTargetN.DataBindings.Clear();
            txtEmailAddr.DataBindings.Clear();
            txtUploadAddr.DataBindings.Clear();
            // txtUploadMethod.DataBindings.Clear();
            cbUploadMethod.DataBindings.Clear();
            chbIsActive.DataBindings.Clear();
            txtUploadTime.DataBindings.Clear();
            cbFileFormat.DataBindings.Clear();
            // cbName.DataBindings.Clear();

            txtUploadId.DataBindings.Add("Text", dataBindingSource, "UploadId", true);
            //txtTheaterId.DataBindings.Add("Text", dataBindingSource, "TheaterId", true);
            txtTargetN.DataBindings.Add("Text", dataBindingSource, "TargetName", true);
            txtEmailAddr.DataBindings.Add("Text", dataBindingSource, "EmailAddr", true);
            txtUploadAddr.DataBindings.Add("Text", dataBindingSource, "UploadAddr", true);
            //txtUploadMethod.DataBindings.Add("Text", dataBindingSource, "UploadMethod", true);
            cbUploadMethod.DataBindings.Add("Text", dataBindingSource, "UploadMethod", true);
            chbIsActive.DataBindings.Add("Checked", dataBindingSource, "IsActive", true);
            txtUploadTime.DataBindings.Add("Text", dataBindingSource, "UploadTime", true);
            cbFileFormat.DataBindings.Add("Text", dataBindingSource, "FileFormat", true);
            // cbName.DataBindings.Add("SelectedValue", dataBindingSource, "TheaterId", true);
        }


        #endregion

        private void txtUploadTime_Validating(object sender, CancelEventArgs e)
        {
            if (txtUploadTime.Text.Trim() != string.Empty)
            {
                string s1 = @"^((([0-1][0-9])|(2[0-3])):[0-5]\d:[0-5]\d)$";
                if (!Regex.IsMatch(txtUploadTime.Text, s1))
                {
                    MessageBox.Show("请输入正确的时间格式:小时+分钟+秒！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUploadTime.DataBindings.Clear();
                    txtUploadTime.DataBindings.Add("Text", dataBindingSource, "UploadTime", true);
                    txtUploadTime.Clear();
                    txtUploadTime.Select();
                    return;
                }
            }
            else
            {
                txtUploadTime.Text = "00:00:00";
            }
        }

        #endregion

        private void txtEmailAddr_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmailAddr.Text != "")
            {
                string s1 = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Match m = Regex.Match(txtEmailAddr.Text, s1);
                if (!m.Success)
                {
                    MessageBox.Show("请输入正确的Email地址", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmailAddr.DataBindings.Clear();
                    txtEmailAddr.DataBindings.Add("Text", dataBindingSource, "EmailAddr", true);
                    txtEmailAddr.Clear();
                    txtEmailAddr.Focus();
                    return;
                }
            }
        }
    }
}


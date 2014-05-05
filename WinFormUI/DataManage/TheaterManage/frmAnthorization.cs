using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.DataManageLib.TheaterManage;
using RCLibrary;

namespace Flamingo.TheaterManage
{
    public partial class frmAnthorization :Form
    {
        Anthorization dataManager;
        List<DataGridViewColumnInfo> dataGridViewColumnInfo;
        public frmAnthorization()
        {
            InitializeComponent();
            dataManager = new Anthorization();
            dataGridViewColumnInfo = dataManager.ColumnInfoList;
            FormatDataList();            
        }

        //格式化明细表
        private void FormatDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dgvList.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dgvList.DataSource = dataManager.GetDataList();

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                if (this.dataGridViewColumnInfo != null && dgvList != null && dgvList.DataSource != null)
                    dgvList.FormatColumns(this.dataGridViewColumnInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

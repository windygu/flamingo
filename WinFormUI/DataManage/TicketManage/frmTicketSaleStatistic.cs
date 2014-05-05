using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.TicketManage;
using RCLibrary;
using System.Text.RegularExpressions;

namespace Flamingo.TicketManage
{
    //2011.12.24 LIN 
    public partial class frmTicketSaleStatistic : Form
    {
        TicketSaleStatistic dataManage;
        private DateTimePicker dateTimePicker;
        List<DataGridViewColumnInfo> dataGridViewColumnInfo;
        public frmTicketSaleStatistic()
        {
            InitializeComponent();
            dataManage = new TicketSaleStatistic();
            dateTimeTo.Value = DateTime.Now;
            dateTimeFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dataGridViewColumnInfo = dataManage.ColumnInfoList;
            dgvList.CellFormatting+=new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            FormatDataList();
            FillVoucherTypeByList();
            FillcbVoucherId();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                List<VoucherBatch> voucherBatchList = new List<VoucherBatch>();
                VoucherBatchManage voucherBatchDataManager = new VoucherBatchManage();

                if (chbSearchByNo.Checked && cbVoucherId.SelectedValue != null)
                {
                    if (cbVoucherId.SelectedValue.ToString() == "全部")
                    {
                        //var obj = voucherBatchDataManager.GetDataList();
                        var tmp = voucherBatchDataManager.GetDataList();
                        if (tmp != null || tmp.Count > 0)
                        {
                            foreach (var tmpobj in tmp)
                            {
                                var objList = voucherBatchDataManager.GetSearchList("VoucherBatchId", tmpobj.VoucherBatchId);

                                VoucherBatch obj;

                                if (dataManage.IsSale(tmpobj.VoucherBatchId.ToString()))
                                {
                                    obj = objList.Find(p => p.VoucherBatchId == tmpobj.VoucherBatchId);
                                    if (obj != null)
                                        obj.Description = "是";
                                }
                                else
                                {
                                    obj = objList.Find(p => p.VoucherBatchId == tmpobj.VoucherBatchId);

                                    if (obj != null)
                                        obj.Description = "否";
                                }

                                if (objList != null && objList.Count > 0)
                                    voucherBatchList.AddRange(objList);
                            }
                            dgvList.DataSource = voucherBatchList;
                        }
                    }
                    else
                    {
                        var objList = voucherBatchDataManager.GetSearchList("VoucherBatchId", cbVoucherId.SelectedValue.ToString());
                        if (objList != null && objList.Count > 0)
                        {
                            VoucherBatch obj;

                            if (dataManage.IsSale(cbVoucherId.SelectedValue.ToString()))
                            {
                                obj = objList.Find(p => p.VoucherBatchId == cbVoucherId.SelectedValue.ToString());
                                if (obj != null)
                                    obj.Description = "是";
                            }
                            else
                            {
                                obj = objList.Find(p => p.VoucherBatchId == cbVoucherId.SelectedValue.ToString());
                                if (obj != null)
                                    obj.Description = "否";
                            }
                        }
                        if (objList != null && objList.Count > 0)
                            voucherBatchList.AddRange(objList);
                        dgvList.DataSource = voucherBatchList;
                    }
                }
                else
                {
                    if (cbVoucherTypeId.SelectedValue.ToString() == "10000")
                        dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value);
                    else
                        dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value, Convert.ToInt32(cbVoucherTypeId.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有您要查询的数据!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //格式化明细表
        private void FormatDataList()
        { // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dgvList.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dgvList.DataSource = dataManage.dgvSearch(dateTimeFrom.Value, dateTimeTo.Value);

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                if (this.dataGridViewColumnInfo != null && dgvList != null && dgvList.DataSource != null)
                    dgvList.FormatColumns(this.dataGridViewColumnInfo);
        }
           /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name.Contains("Quantity"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value)).ToString() + "张";
                }
                catch
                {
                }
            }
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
            if (dgv.Columns[e.ColumnIndex].Name == "VoucherTypeId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetVoucherTypeName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "CustomerId")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetCustomerName(Convert.ToInt32(nId));
                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "IssuedBy")
            {
                int? nId;
                nId = Convert.ToInt32(e.Value);
                try
                {
                    e.Value = VoucherBatchManage.GetSueName(Convert.ToInt32(nId));
                }
                catch { }
            }
        }

        private void BuildDateTimePicker()
        {
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Now;
            panel1.Controls.Add(dateTimePicker);
            dateTimePicker.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTicketSaleStatistic_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 填充下拉框cbVoucherId
        /// </summary>
        public void FillcbVoucherId()
        {
            List<VoucherBatch> voucherBatchList = new List<VoucherBatch>();
            cbVoucherId.DisplayMember = "VoucherBatchId";
            cbVoucherId.ValueMember = "VoucherBatchId";

            VoucherBatchManage dataManager = new VoucherBatchManage();
            voucherBatchList = dataManager.GetDataList();
            if (voucherBatchList.Count > 0 || voucherBatchList != null)
            {
                VoucherBatch vBatch= new VoucherBatch();
                vBatch.VoucherName = "全部";
                vBatch.VoucherBatchId = "全部";
                voucherBatchList.Add(vBatch);
                cbVoucherId.DataSource = voucherBatchList;
            }

        }

        /// <summary>
        /// 填充下拉框：票券类型
        /// </summary>
        private void FillVoucherTypeByList()
        {
            List<VoucherType> voucherTypeList = new List<VoucherType>();
            cbVoucherTypeId.DisplayMember = "VoucherTypeName";
            cbVoucherTypeId.ValueMember = "VoucherTypeId";

            voucherTypeList = VoucherBatchManage.DirectGetVoucherType();
            if (voucherTypeList != null || voucherTypeList.Count <= 0)
            {
                VoucherType vt = new VoucherType();
                vt.VoucherTypeName = "全部";
                vt.VoucherTypeId = 10000;
                voucherTypeList.Add(vt);
                cbVoucherTypeId.DataSource = voucherTypeList;
            }
          
        }
       
    }
}

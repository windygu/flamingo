using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    public partial class frmFilmBoxOffice : Form
    {
        private string name;
        private BaseQuery baseQuery;
        private DateTime dailyPlanDate;

        private List<Ticket_BaseQuery> list;

        public frmFilmBoxOffice(string Name)
        {
            InitializeComponent();

            baseQuery = new BaseQuery();
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            this.name = Name;
        }

        public frmFilmBoxOffice(string Name, DateTime dt)
        {
            InitializeComponent();

            baseQuery = new BaseQuery();
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            this.name = Name;
            this.dailyPlanDate = dt;
        }

        private void frmFilmBoxOffice_Load(object sender, EventArgs e)
        {
            BindCombox();
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;

            if (e.Value == null || e.Value.ToString() == "")
            {
                e.Value ="0.00";
                e.FormattingApplied = true;
                return;
            }
            if (columnName.EndsWith("Total"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 1).ToString("0.00");
                    e.FormattingApplied = true;
                }
                catch
                {
                }
            }
        }
        private void BindCombox()
        {
            switch (this.name)
            {
                case "Film":
                    cbSelectValue.Visible = true;
                    dtpDate.Visible = false;

                    this.Text = "基础查询  单片票房查询";
                    lblSelect.Text = "选择查询影片：";
                    cbSelectValue.ValueMember = "FilmId";
                    cbSelectValue.DisplayMember = "FilmName";
                    cbSelectValue.DataSource = baseQuery.GetFilmAndFilmModeList(this.dailyPlanDate);
                    break;

                case "Hall":
                    cbSelectValue.Visible = true;
                    dtpDate.Visible = false;

                    this.Text = "基础查询  单厅票房查询";
                    lblSelect.Text = "选择查询影厅：";
                    cbSelectValue.ValueMember = "HallId";
                    cbSelectValue.DisplayMember = "HallName";
                    cbSelectValue.DataSource = baseQuery.GethallList();
                    break;

                case "Day":
                    cbSelectValue.Visible = false;
                    dtpDate.Visible = true;
                    this.Text = "基础查询  单日票房查询";
                    lblSelect.Text = "选择查询日期：";
                    break;

                case "Period":
                    lblTime.Visible = true;
                    dtpEndTime.Visible = true;
                    dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
                    dtpDate.ShowUpDown = true;
                    cbSelectValue.Visible = false;
                    this.Text = "基础查询  时段票房查询";
                    lblSelect.Text = "选择查询时段：";
                    break;
            }
        }

        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected void FormatDataList()
        {
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns["ShowPlanId"].Visible = false;

            dgvList.Columns["Date"].HeaderText = "日期";
            dgvList.Columns["Hall"].HeaderText = "影厅";
            dgvList.Columns["Total"].HeaderText = "票房";

            dgvList.Columns["Date"].DisplayIndex = 1;
            dgvList.Columns["Hall"].DisplayIndex = 2;
            dgvList.Columns["Total"].DisplayIndex = 3;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = null;
            switch (this.name)
            {
                case "Film":
                    list = baseQuery.GetFilmTicket_BaseQuery(cbSelectValue.SelectedValue.ToString(), this.dailyPlanDate);
                    break;

                case "Hall":
                    list = baseQuery.GetHallTicket_BaseQuery(cbSelectValue.SelectedValue.ToString(), this.dailyPlanDate);
                    break;

                case "Day":
                    list = baseQuery.GetDayTicket_BaseQuery(dtpDate.Value);
                    break;

                case "Period":
                    list = baseQuery.GetPeriodTicket_BaseQuery(dtpDate.Value, dtpEndTime.Value, this.dailyPlanDate);
                    break;
            }
            if (list.Count > 0)
            {
                dgvList.DataSource = list;
                FormatDataList();
            }
            Double total=Convert.ToDouble( list.Sum(p => p.Total));
            lblTotal.Text = string.Format("  总共放映{0}场，票房{1}元",list.Count, total.ToString("0.00"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

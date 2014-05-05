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
    public partial class frmDayilyShowPlan : Form
    {
        private DailyShowPlanManage dataManager;
        private List<Hall> oldHallList;
        private List<ShowPlan> showPlanList;

        public frmDayilyShowPlan(string theter, string Date, DailyShowPlanManage datamanager)
        {
            InitializeComponent();
            this.dataManager = datamanager;
            txtDate.Text = Date;
            txtTheter.Text = theter;
            oldHallList = new List<Hall>();
            showPlanList = new List<ShowPlan>();
        }

        private void frmDayilyShowPlan_Load(object sender, EventArgs e)
        {
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            showPlanList = this.dataManager.DailyShowPlan.ShowPlanList;

            Hall hall = new Hall();
            hall.HallName = "全部影厅";
            hall.HallId = null;
            oldHallList.Add(hall);
            oldHallList.AddRange(this.dataManager.DailyShowPlan.HallList);

            cbHall.ValueMember = "HallId";
            cbHall.DisplayMember = "HallName";
            cbHall.DataSource = oldHallList;
            cbHall.SelectedIndexChanged += new EventHandler(cbHall_SelectedIndexChanged);
            dgvList.DataSource = showPlanList;
            FormatDataList();
        }
        private void cbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvList.DataSource = null;
            if (cbHall.SelectedValue == null)
            {
                dgvList.DataSource = showPlanList;
            }
            else
            {
                dgvList.DataSource = showPlanList.Where(p => p.HallId == cbHall.SelectedValue.ToString()).ToList();
            }
            FormatDataList();
        }

        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected void FormatDataList()
        {
            ShowPlan ss = new ShowPlan();
            dgvList.AutoGenerateColumns = false;
            dgvList.Columns["Stagehand"].Visible = false;
            dgvList.Columns["Projectionist"].Visible = false;
            dgvList.Columns["IsTicketChecking"].Visible = false;
            dgvList.Columns["IsSalable"].Visible = false;
            dgvList.Columns["IsOnlineTicketing"].Visible = false;
            dgvList.Columns["IsApproved"].Visible = false;
            dgvList.Columns["IsCheckingNumber"].Visible = false;
            dgvList.Columns["IsDiscounted"].Visible = false;
            dgvList.Columns["IsLocked"].Visible = false;
            dgvList.Columns["ShowPlanId"].Visible = false;
            dgvList.Columns["Created"].Visible = false;
            dgvList.Columns["Updated"].Visible = false;
            dgvList.Columns["ActiveFlag"].Visible = false;
            dgvList.Columns["DailyPlanId"].Visible = false;
            dgvList.Columns["GroupPrice"].Visible = false;
            dgvList.Columns["Film"].Visible = false;
            dgvList.Columns["FareSetting"].Visible = false;
            dgvList.Columns["FareSettingId"].Visible = false;
            dgvList.Columns["ActiveFlag"].Visible = false;
            dgvList.Columns["DailyPlan"].Visible = false;
            dgvList.Columns["Ticket"].Visible = false;
            dgvList.Columns["Film_FilmModeId"].Visible = false;
            dgvList.Columns["FilmId"].Visible = false;
            dgvList.Columns["DailyPlan"].Visible = false;
            dgvList.Columns["Ticket"].Visible = false;
            dgvList.Columns["Film_FilmModeId"].Visible = false;
            dgvList.Columns["FilmId"].Visible = false;

            dgvList.Columns["Hall"].Visible = false;
            dgvList.Columns["ShowGroup"].Visible = false;
            dgvList.Columns["ShowTypeId"].Visible = false;
            dgvList.Columns["Film_FilmModeId"].Visible = false;
            dgvList.Columns["ShowType"].Visible = false;
            dgvList.Columns["SeatStatus"].Visible = false;
            dgvList.Columns["BlockPrice"].Visible = false;;
            dgvList.Columns["ShowStatus"].Visible = false;
            dgvList.Columns["MemberPrice"].Visible = false;
            dgvList.Columns["FilmLength"].Visible = false;
            dgvList.Columns["GroupPrice"].Visible = false;
            dgvList.Columns["BoxPrice"].Visible = false;
            dgvList.Columns["MemberPrice"].Visible = false;
            dgvList.Columns["DiscountPrice"].Visible = false;
            dgvList.Columns["LowestPrice"].Visible = false;
            dgvList.Columns["Timespan"].Visible = false;
            dgvList.Columns["HallId"].Visible = false;
            dgvList.Columns["EndTime"].Visible = false;
       
            //判断如果已经存在则不添加
            Boolean isExit = false;
            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                if (column.Name == "HallName")
                    isExit = true;
            }
            if (isExit == false)
                dgvList.Columns.Add("HallName", "影厅名称");

            dgvList.Columns["ShowPlanName"].HeaderText = "影片名称";
            dgvList.Columns["StartTime"].HeaderText = "开始时间";
            dgvList.Columns["Position"].HeaderText = "场次";
            dgvList.Columns["SinglePrice"].HeaderText = "单人零售票价";
            dgvList.Columns["DoublePrice"].HeaderText = "双座零售票价";
            dgvList.Columns["StudentPrice"].HeaderText = "学生票价";
            dgvList.Columns["Ratio"].HeaderText = "片方分账比例";


            dgvList.Columns["HallName"].DisplayIndex = 1;
            dgvList.Columns["ShowPlanName"].DisplayIndex = 2;
            dgvList.Columns["StartTime"].DisplayIndex = 3;
            dgvList.Columns["Position"].DisplayIndex = 4;
            dgvList.Columns["SinglePrice"].DisplayIndex = 5;
            dgvList.Columns["DoublePrice"].DisplayIndex = 6;
            dgvList.Columns["StudentPrice"].DisplayIndex = 7;
            dgvList.Columns["Ratio"].DisplayIndex = 8;

        }

          /// <summary>
        /// 数据明细表数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = ((DataGridView)sender).Columns[e.ColumnIndex].Name;

            if (columnName == "HallName")
            {
                dgvList["HallName", e.RowIndex].Value = oldHallList.Where(p => p.HallId == dgvList["HallId", e.RowIndex].Value.ToString()).First().HallName;
            }
            if (columnName == "StartTime")
            {
                try
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("hh:mm:ss");
                }
                catch
                { }

                //dgvList["StartTime", e.RowIndex].Value = string.Format(dgvList["StartTime", e.RowIndex].Value.ToString(), "hh:mm:ss");
            }
        }

        private void btncolse_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}

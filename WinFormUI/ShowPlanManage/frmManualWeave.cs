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
    public partial class frmManualWeave : Form
    {

        #region 窗体变量

        private List<Hall> HallList;

        private List<FilmAndFilmMode> filmAndFilmModeList;

        private ManualWeave manualWeave;

        private DailyShowPlanManage dataMager;

        private int dailyPlanTimeSpan;

        #endregion


        #region 启动处理
        public frmManualWeave(DailyShowPlanManage datemager, int timeSpan)
        {
            this.dataMager = datemager;
            InitializeComponent();
            manualWeave = new ManualWeave(this.dataMager);
            this.dailyPlanTimeSpan = timeSpan;
            nuTimeSpan.Value = timeSpan;
        }

        private void frmManualWeave_Load(object sender, EventArgs e)
        {
            nuShowPlanNumber.Value = 1;

            HallList = manualWeave.GetHall();

            filmAndFilmModeList = manualWeave.GetFilmModeList;

            //绑定下拉框数据
            FillData();
        }

        #endregion



        #region 窗体事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string hallID = cbHall.SelectedValue.ToString().Trim();
            string filmId = cbFilmName.SelectedValue.ToString().Trim();
            DateTime startTime = dtpStartTime.Value;
            int timeSpan = (int)nuTimeSpan.Value;
            int showPlanNumber = (int)nuShowPlanNumber.Value;
            if (this.dailyPlanTimeSpan > timeSpan)
            {
                MessageBox.Show("最小时间间隔不能小于日计划的间隔！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (manualWeave.BuildShowPlan(hallID, filmId, startTime, timeSpan, showPlanNumber) == true)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "信息提示");
            }
        }

        #endregion

        #region 窗体函数



        //绑定下拉框数据
        private void FillData()
        {
            //绑定影厅信息
            FillHall();

            //绑定影片信息
            FillFilm();

        }

        //绑定影厅信息
        private void FillHall()
        {
            cbHall.ValueMember = "HallId";

            cbHall.DisplayMember = "HallName";

            cbHall.DataSource = this.HallList;
        }

        //绑定影片信息
        private void FillFilm()
        {
            cbFilmName.ValueMember = "FilmId";
            cbFilmName.DisplayMember = "FilmName";
            cbFilmName.DataSource = this.filmAndFilmModeList;
        }

        #endregion


    }
}

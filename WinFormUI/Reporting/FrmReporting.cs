using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.EntityClient;
using System.Data.Objects;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Flamingo.Right;
using System.Net;
using System.IO;
using Flamingo.Common;
namespace WinFormUI.Reporting
{
    public partial class FrmReporting : Form
    {
        private DateTime startDate = System.DateTime.Today;
        private DateTime endDate = System.DateTime.Today;
        private String halls = null;
        private String films = null;
        private String users = null;
        private string filepath = null;
        private string m_szTitle = "";

        public FrmReporting()
        {
            InitializeComponent();
        }

        private void FrmReporting_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            this.reportViewer1.RefreshReport();
            if (!WinFormUI.FrmMain.curUser.HavePermission(Permissions.StatisticsReport)) toolStripButton1.Enabled = false;
            if (!WinFormUI.FrmMain.curUser.HavePermission(Permissions.BusinessReport)) toolStripButton2.Enabled = false;
            if (!(WinFormUI.FrmMain.curUser.HavePermission(Permissions.BasicQueryReport) && WinFormUI.FrmMain.curUser.HavePermission(Permissions.CombinedQueryReport))) toolStripButton3.Enabled = false;
            if (!WinFormUI.FrmMain.curUser.HavePermission(Permissions.TotalReport)) toolStripButton4.Enabled = false;
            if (!WinFormUI.FrmMain.curUser.HavePermission(Permissions.GraphicReport)) toolStripButton5.Enabled = false;
            if (!WinFormUI.FrmMain.curUser.HavePermission(Permissions.TicketReport)) toolStripButton6.Enabled = false;
        }

        private void ClearCheckState()
        {
            toolStripButton1.Image = WinFormUI.Properties.Resources.statistics1;
            toolStripButton2.Image = WinFormUI.Properties.Resources.business1;
            toolStripButton3.Image = WinFormUI.Properties.Resources.query1;
            toolStripButton4.Image = WinFormUI.Properties.Resources.graphic1;
            toolStripButton5.Image = WinFormUI.Properties.Resources.total1;
            toolStripButton6.Image = WinFormUI.Properties.Resources.ticket11;
        }

        //获得报表参数
        private void GetParameter()
        {
            FrmParameter fp = new FrmParameter();
            fp.StartPosition = FormStartPosition.CenterScreen;
            fp.ControlBox = false;
            if (DialogResult.OK == fp.ShowDialog())
            {
                startDate = fp.GetStartDate();
                endDate = fp.GetEndDate();
                halls = fp.GetHalls();
                films = fp.GetFilms();
                users = fp.GetUsers();
            }
        }

        //根据不同的报表类型刷新报表
        private void RefleshReportViewer(String BindingSourceName, String DataSourceName, String ReportSource)
        {
            reportBindingSource.DataMember = BindingSourceName;
            reportBindingSource.DataSource = this.flamingoDataSet;
            this.reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = DataSourceName;
            reportDataSource1.Value = reportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = ReportSource;
            ReportParameter sdate = new ReportParameter("sdate", startDate.ToString("yyyy年MM月dd日"));
            ReportParameter edate = new ReportParameter("edate", endDate.ToString("yyyy年MM月dd日"));
            flamingoDataSetTableAdapters.theaterTableAdapter theaterTableAdapter = new flamingoDataSetTableAdapters.theaterTableAdapter();
            theaterTableAdapter.Fill(this.flamingoDataSet.theater);
            ReportParameter theater = new ReportParameter("theater", flamingoDataSet.theater.Rows[0][2].ToString());
            ReportParameter user = new ReportParameter("user", WinFormUI.FrmMain.curUser.EmpName);
            ReportParameter title = new ReportParameter("title", m_szTitle);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { sdate, edate, theater, user });
            this.reportViewer1.RefreshReport();

        }

        //根据不同的报表类型刷新报表
        private void RefleshReportViewer(String BindingSourceName, String DataSourceName, String ReportSource, LocalReport lp)
        {
            reportBindingSource.DataMember = BindingSourceName;
            reportBindingSource.DataSource = this.flamingoDataSet;
            this.reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = DataSourceName;
            reportDataSource1.Value = reportBindingSource;
            lp.DataSources.Add(reportDataSource1);
            lp.ReportEmbeddedResource = ReportSource;
            ReportParameter sdate = new ReportParameter("sdate", startDate.ToString("yyyy年MM月dd日"));
            ReportParameter edate = new ReportParameter("edate", endDate.ToString("yyyy年MM月dd日"));
            flamingoDataSetTableAdapters.theaterTableAdapter theaterTableAdapter = new flamingoDataSetTableAdapters.theaterTableAdapter();
            theaterTableAdapter.Fill(this.flamingoDataSet.theater);
            ReportParameter theater = new ReportParameter("theater", flamingoDataSet.theater.Rows[0][2].ToString());
            ReportParameter user = new ReportParameter("user", WinFormUI.FrmMain.curUser.EmpName);
            ReportParameter title = new ReportParameter("title", m_szTitle);
            lp.SetParameters(new ReportParameter[] { sdate, edate, theater, user, title });
            //lp.Refresh();
        }

        #region 统计报表

        private void 个人日放映收入表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton1.Image = WinFormUI.Properties.Resources.statistics2;
            GetParameter();
            RefleshReportViewer("dailydata", "DailyData", "WinFormUI.Reporting.Reports.PersonalDailyIncome.rdlc");
            flamingoDataSetTableAdapters.dailydataTableAdapter dailydataTableAdapter = new flamingoDataSetTableAdapters.dailydataTableAdapter();
            //dailydataTableAdapter.FillByDate(this.flamingoDataSet.dailydata, startDate, endDate);
            dailydataTableAdapter.FillByPara(this.flamingoDataSet.dailydata, startDate, endDate, halls, films, users);
            dailydataTableAdapter.ClearBeforeFill = true;
            this.reportViewer1.RefreshReport();
        }

        private void 影院日放映收入表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton1.Image = WinFormUI.Properties.Resources.statistics2;
            GetParameter();
            RefleshReportViewer("dailydata", "DailyData", "WinFormUI.Reporting.Reports.TheaterDailyIncome.rdlc");
            flamingoDataSetTableAdapters.dailydataTableAdapter dailydataTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.dailydataTableAdapter();
            dailydataTableAdapter.ClearBeforeFill = true;
            dailydataTableAdapter.FillTheaterDailyIncome(this.flamingoDataSet.dailydata, startDate, endDate, halls, films);
            this.reportViewer1.RefreshReport();
        }

        private void 个人日售票成绩表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton1.Image = WinFormUI.Properties.Resources.statistics2;
            GetParameter();
            RefleshReportViewer("dailydata", "DailyData", "WinFormUI.Reporting.Reports.PersonalDailySales.rdlc");
            flamingoDataSetTableAdapters.dailydataTableAdapter dailydataTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.dailydataTableAdapter();
            dailydataTableAdapter.ClearBeforeFill = true;
            dailydataTableAdapter.FillByPersonalDailySales(this.flamingoDataSet.dailydata, startDate, endDate, halls, films, users);
            this.reportViewer1.RefreshReport();
        }

        private void 影院日售票成绩表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton1.Image = WinFormUI.Properties.Resources.statistics2;
            GetParameter();
            RefleshReportViewer("dailydata", "DailyData", "WinFormUI.Reporting.Reports.TheaterDailySales.rdlc");
            flamingoDataSetTableAdapters.dailydataTableAdapter dailydataTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.dailydataTableAdapter();
            dailydataTableAdapter.ClearBeforeFill = true;
            dailydataTableAdapter.FillTheaterDailySales(this.flamingoDataSet.dailydata, startDate, endDate, halls, films);
            this.reportViewer1.RefreshReport();
        }

        #endregion

        #region 经营报表

        private void 影院放映日累计分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton2.Image = WinFormUI.Properties.Resources.business2;
            GetParameter();
            RefleshReportViewer("dailyanalysis", "DailyAnalysis", "WinFormUI.Reporting.Reports.DailyAnalysisRpt.rdlc");
            flamingoDataSetTableAdapters.dailyanalysisTableAdapter dailyanalysisTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.dailyanalysisTableAdapter();
            dailyanalysisTableAdapter.ClearBeforeFill = true;
            //dailyanalysisTableAdapter.Fill(this.flamingoDataSet.dailyanalysis);
            dailyanalysisTableAdapter.FillDailyAnalysis(this.flamingoDataSet.dailyanalysis, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影院放映月累计分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton2.Image = WinFormUI.Properties.Resources.business2;
            GetParameter();
            RefleshReportViewer("monthlyanalysis", "MonthlyAnalysis", "WinFormUI.Reporting.Reports.MonthlyAnalysisRpt.rdlc");
            flamingoDataSetTableAdapters.monthlyanalysisTableAdapter monthlyanalysisTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.monthlyanalysisTableAdapter();
            monthlyanalysisTableAdapter.ClearBeforeFill = true;
            //monthlyanalysisTableAdapter.Fill(this.flamingoDataSet.monthlyanalysis);
            monthlyanalysisTableAdapter.FillMonthAnalysis(this.flamingoDataSet.monthlyanalysis, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影院放映月表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton2.Image = WinFormUI.Properties.Resources.business2;
            GetParameter();
            RefleshReportViewer("monthlyshowrpt", "MonthlyShowRpt", "WinFormUI.Reporting.Reports.MonthlyShowRpt.rdlc");
            flamingoDataSetTableAdapters.monthlyshowrptTableAdapter monthlyshowrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.monthlyshowrptTableAdapter();
            monthlyshowrptTableAdapter.ClearBeforeFill = true;
            //monthlyshowrptTableAdapter.Fill(this.flamingoDataSet.monthlyshowrpt);
            monthlyshowrptTableAdapter.FillMonthShowRpt(this.flamingoDataSet.monthlyshowrpt, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影片放映情况财务报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton2.Image = WinFormUI.Properties.Resources.business2;
            GetParameter();
            RefleshReportViewer("filmrpt", "FilmRpt", "WinFormUI.Reporting.Reports.FilmRpt.rdlc");
            flamingoDataSetTableAdapters.filmrptTableAdapter filmrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.filmrptTableAdapter();
            filmrptTableAdapter.ClearBeforeFill = true;
            //filmrptTableAdapter.Fill(this.flamingoDataSet.filmrpt);
            filmrptTableAdapter.FillFilmRpt(this.flamingoDataSet.filmrpt, startDate, endDate, films);
            this.reportViewer1.RefreshReport();
        }

        #endregion

        #region 查询报表

        private void 影院放映计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton3.Image = WinFormUI.Properties.Resources.query2;
            GetParameter();
            RefleshReportViewer("showplanrpt", "ShowPlanRpt", "WinFormUI.Reporting.Reports.ShowPlanRpt.rdlc");
            flamingoDataSetTableAdapters.showplanrptTableAdapter showplanrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.showplanrptTableAdapter();
            showplanrptTableAdapter.ClearBeforeFill = true;
            //showplanrptTableAdapter.Fill(this.flamingoDataSet.showplanrpt);
            showplanrptTableAdapter.FillShowPlanRpt(this.flamingoDataSet.showplanrpt, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影院售票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton3.Image = WinFormUI.Properties.Resources.query2;
            GetParameter();
            RefleshReportViewer("ticketrpt", "TicketRpt", "WinFormUI.Reporting.Reports.TicketRpt.rdlc");
            flamingoDataSetTableAdapters.ticketrptTableAdapter ticketrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.ticketrptTableAdapter();
            ticketrptTableAdapter.ClearBeforeFill = true;
            //ticketrptTableAdapter.Fill(this.flamingoDataSet.ticketrpt);
            ticketrptTableAdapter.FillTicketRpt(this.flamingoDataSet.ticketrpt, startDate, endDate, halls, films, users);
            this.reportViewer1.RefreshReport();
        }

        private void 影院退票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton3.Image = WinFormUI.Properties.Resources.query2;
            GetParameter();
            RefleshReportViewer("refundrpt", "RefundRpt", "WinFormUI.Reporting.Reports.RefundRpt.rdlc");
            flamingoDataSetTableAdapters.refundrptTableAdapter refundrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.refundrptTableAdapter();
            refundrptTableAdapter.ClearBeforeFill = true;
            //refundrptTableAdapter.Fill(this.flamingoDataSet.refundrpt);
            refundrptTableAdapter.FillRefundRpt(this.flamingoDataSet.refundrpt, startDate, endDate, halls, films, users);
            this.reportViewer1.RefreshReport();
        }

        private void 组合查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton3.Image = WinFormUI.Properties.Resources.query2;
        }

        #endregion

        #region 综合报表

        private void 影厅电影日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton4.Image = WinFormUI.Properties.Resources.total2;
            GetParameter();
            RefleshReportViewer("dailyfilmrpt", "DailyFilmRpt", "WinFormUI.Reporting.Reports.DailyFilmRpt.rdlc");
            flamingoDataSetTableAdapters.dailyfilmrptTableAdapter dailyfilmrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.dailyfilmrptTableAdapter();
            dailyfilmrptTableAdapter.ClearBeforeFill = true;
            //dailyfilmrptTableAdapter.Fill(this.flamingoDataSet.dailyfilmrpt);
            dailyfilmrptTableAdapter.FillDailyFilmRpt(this.flamingoDataSet.dailyfilmrpt, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影片放映统计月表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton4.Image = WinFormUI.Properties.Resources.total2;
            GetParameter();
            RefleshReportViewer("monthlyfilmrpt", "MonthlyFilmRpt", "WinFormUI.Reporting.Reports.MonthlyFilmRpt.rdlc");
            flamingoDataSetTableAdapters.monthlyfilmrptTableAdapter monthlyfilmrptTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.monthlyfilmrptTableAdapter();
            monthlyfilmrptTableAdapter.ClearBeforeFill = true;
            //monthlyfilmrptTableAdapter.Fill(this.flamingoDataSet.monthlyfilmrpt);
            monthlyfilmrptTableAdapter.FillMonthlyFilmRpt(this.flamingoDataSet.monthlyfilmrpt, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        #endregion

        #region 图形报表

        private void 影片票房比较图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("barfilmincome", "BarFilmIncome", "WinFormUI.Reporting.Reports.BarFilmIncome.rdlc");
            flamingoDataSetTableAdapters.barfilmincomeTableAdapter barfilmincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.barfilmincomeTableAdapter();
            barfilmincomeTableAdapter.ClearBeforeFill = true;
            //barfilmincomeTableAdapter.Fill(this.flamingoDataSet.barfilmincome);
            barfilmincomeTableAdapter.FillBarFilminCome(this.flamingoDataSet.barfilmincome, startDate, endDate, films);
            this.reportViewer1.RefreshReport();
        }

        private void 影厅票房比较图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("barhallincome", "BarHallIncome", "WinFormUI.Reporting.Reports.BarHallIncome.rdlc");
            flamingoDataSetTableAdapters.barhallincomeTableAdapter barhallincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.barhallincomeTableAdapter();
            barhallincomeTableAdapter.ClearBeforeFill = true;
            //barhallincomeTableAdapter.Fill(this.flamingoDataSet.barhallincome);
            barhallincomeTableAdapter.FillBarHallIncome(this.flamingoDataSet.barhallincome, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影院各厅票房分布图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("piefilmincome", "PieFilmIncome", "WinFormUI.Reporting.Reports.PieFilmIncome.rdlc");
            flamingoDataSetTableAdapters.piefilmincomeTableAdapter piefilmincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.piefilmincomeTableAdapter();
            piefilmincomeTableAdapter.ClearBeforeFill = true;
            //piefilmincomeTableAdapter.Fill(this.flamingoDataSet.piefilmincome);
            piefilmincomeTableAdapter.FillPieFilMinCome(this.flamingoDataSet.piefilmincome, startDate, endDate);
            this.reportViewer1.RefreshReport();
        }

        private void 影片各厅票房分布图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("piehallincome", "PieHallIncome", "WinFormUI.Reporting.Reports.PieHallIncome.rdlc");
            flamingoDataSetTableAdapters.piehallincomeTableAdapter piehallincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.piehallincomeTableAdapter();
            piehallincomeTableAdapter.ClearBeforeFill = true;
            //piehallincomeTableAdapter.Fill(this.flamingoDataSet.piehallincome);
            piehallincomeTableAdapter.FillPieHallIncome(this.flamingoDataSet.piehallincome, startDate, endDate, films);
            this.reportViewer1.RefreshReport();
        }

        private void 影片票种票房分布图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("pietickettype", "PieTicketType", "WinFormUI.Reporting.Reports.PieTicketType.rdlc");
            flamingoDataSetTableAdapters.pietickettypeTableAdapter pietickettypeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.pietickettypeTableAdapter();
            pietickettypeTableAdapter.ClearBeforeFill = true;
            //pietickettypeTableAdapter.Fill(this.flamingoDataSet.pietickettype);
            pietickettypeTableAdapter.FillPieTicketType(this.flamingoDataSet.pietickettype, startDate, endDate, films);
            this.reportViewer1.RefreshReport();
        }

        private void 影院总票房时间走势图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("lineincome", "LineIncome", "WinFormUI.Reporting.Reports.LineIncome.rdlc");
            flamingoDataSetTableAdapters.lineincomeTableAdapter lineincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.lineincomeTableAdapter();
            lineincomeTableAdapter.ClearBeforeFill = true;
            //lineincomeTableAdapter.Fill(this.flamingoDataSet.lineincome);
            lineincomeTableAdapter.FillByDate(this.flamingoDataSet.lineincome, startDate, endDate);
            this.reportViewer1.RefreshReport();
        }

        private void 影厅票房时间走势图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("linehallincome", "LineHallIncome", "WinFormUI.Reporting.Reports.LineHallIncome.rdlc");
            flamingoDataSetTableAdapters.linehallincomeTableAdapter linehallincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.linehallincomeTableAdapter();
            linehallincomeTableAdapter.ClearBeforeFill = true;
            //linehallincomeTableAdapter.Fill(this.flamingoDataSet.linehallincome);
            linehallincomeTableAdapter.FillLineHallIncome(this.flamingoDataSet.linehallincome, startDate, endDate, halls);
            this.reportViewer1.RefreshReport();
        }

        private void 影片票房时间走势图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Image = WinFormUI.Properties.Resources.graphic2;
            GetParameter();
            RefleshReportViewer("linefilmincome", "LineFilmIncome", "WinFormUI.Reporting.Reports.LineFilmIncome.rdlc");
            flamingoDataSetTableAdapters.linefilmincomeTableAdapter linefilmincomeTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.linefilmincomeTableAdapter();
            linefilmincomeTableAdapter.ClearBeforeFill = true;
            //linefilmincomeTableAdapter.Fill(this.flamingoDataSet.linefilmincome);
            linefilmincomeTableAdapter.FillLineFilmIncome(this.flamingoDataSet.linefilmincome, startDate, endDate, films);
            this.reportViewer1.RefreshReport();
        }

        #endregion

        #region 中影专用

        private void 中影专用报表toolStripButton_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton6.Image = WinFormUI.Properties.Resources.ticket21;
            GetParameter();
            RefleshReportViewer("ticketreport", "TicketReport", "WinFormUI.Reporting.Reports.TicketReport.rdlc");
            flamingoDataSetTableAdapters.ticketreportTableAdapter ticketreportTableAdapter = new WinFormUI.flamingoDataSetTableAdapters.ticketreportTableAdapter();
            ticketreportTableAdapter.ClearBeforeFill = true;
            //monthlyfilmrptTableAdapter.Fill(this.flamingoDataSet.monthlyfilmrpt);
            ticketreportTableAdapter.FillByBusinessDate(this.flamingoDataSet.ticketreport, startDate);
            this.reportViewer1.RefreshReport();
        }

        #endregion

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            LocalReport lp = (LocalReport)e.Report;

            m_szTitle = lp.OriginalParametersToDrillthrough[0].Values[0].ToString();

            if (m_szTitle == "个人日放映收入表")
            {
                lp.DataSources.Clear();
                RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.GroupClassTicketSale.rdlc", lp);
                flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
                TableAdapter.FillPersonalDailyIncome(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films, users);
                TableAdapter.ClearBeforeFill = true;
                this.reportViewer1.RefreshReport();
            }
            else if (m_szTitle == "个人日售票成绩表")
            {
                lp.DataSources.Clear();
                RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.GroupClassTicketSale.rdlc", lp);
                flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
                TableAdapter.FillPersonalDailySale(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films, users);
                TableAdapter.ClearBeforeFill = true;
                this.reportViewer1.RefreshReport();
            }
            else if (m_szTitle == "影院日放映收入表")
            {
                lp.DataSources.Clear();
                RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.GroupClassTicketSale.rdlc", lp);
                flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
                TableAdapter.FillTheaterDailyIncome(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films);
                TableAdapter.ClearBeforeFill = true;
                this.reportViewer1.RefreshReport();
            }
            else if (m_szTitle == "影院日售票成绩表")
            {
                lp.DataSources.Clear();
                RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.GroupClassTicketSale.rdlc", lp);
                flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
                TableAdapter.FillTheaterDailySale(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films);
                TableAdapter.ClearBeforeFill = true;
                this.reportViewer1.RefreshReport();
            }
            

            //if (lp.ReportEmbeddedResource == "PersonalDailyIncomeGroup.rdlc")
            //{
            //    lp.DataSources.Clear();
            //    RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.PersonalDailyIncomeGroup.rdlc", lp);
            //    flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
            //    TableAdapter.FillPersonalDailyIncome(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films, users);
            //    TableAdapter.ClearBeforeFill = true;
            //    this.reportViewer1.RefreshReport();
            //}
            //else if (lp.ReportEmbeddedResource == "PersonalDailySalesGroup.rdlc")
            //{
            //    lp.DataSources.Clear();
            //    RefleshReportViewer("dailydatagroup", "DailyDataGroup", "WinFormUI.Reporting.Reports.PersonalDailySalesGroup.rdlc", lp);
            //    flamingoDataSetTableAdapters.dailydatagroupTableAdapter TableAdapter = new flamingoDataSetTableAdapters.dailydatagroupTableAdapter();
            //    TableAdapter.FillPersonalDailySale(this.flamingoDataSet.dailydatagroup, startDate, endDate, halls, films, users);
            //    TableAdapter.ClearBeforeFill = true;
            //    this.reportViewer1.RefreshReport();
            //}

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection(ConfigHelper.GetConnectionString("ConnectionString"));
            con.Open();
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables["UploadSetting"];
            foreach(DataRow row in dt.Rows)
            {
                System.Console.WriteLine(row.ToString());
            }
            //dt.Select("SELECT TheaterId, UploadAddr, UploadTime FROM UploadSetting");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Flamingo.ShowPlanManage
{
    public partial class frmReport : Form
    {
        public LocalReport LocalReport
        {
            get
            {
                return this.rvReportViewer.LocalReport;
            }
        }

        public frmReport()
        {
            InitializeComponent();    
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            this.rvReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.rvReportViewer.ZoomMode = ZoomMode.Percent;
            this.rvReportViewer.ZoomPercent = 100;
          
            this.rvReportViewer.RefreshReport();
        }

        /// <summary>
        /// 处理键盘功能键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

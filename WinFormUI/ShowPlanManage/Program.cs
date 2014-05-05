using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.LoadDatabaseConfig();

            DailyShowPlanManage.DelPrice();

            Application.Run(new frmMain());
        }
    }
}

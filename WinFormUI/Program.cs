using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Flamingo;
using Flamingo.ShowPlanManageLib;

namespace WinFormUI
{
    static class Program
    {
        public static Form _Main = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.LoadDatabaseConfig();

            DailyShowPlanManage.DelPrice();

            //Catch Exception---------------------------------------------------------------
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //------------------------------------------------------------------------------

            string szSalesConn = Flamingo.Common.ConfigHelper.GetConnectionString("ConnectionString"); //加密
            //DataObject.App_UTIL.DBOHelper.connString = "server=localhost;User Id=root;password=p@ssw0rd;Persist Security Info=True;database=flamingo;Default Command Timeout=90;Connect Timeout=900";
            DataObject.App_UTIL.DBOHelper.connString = szSalesConn;
            _Main = new FrmMain();
            Application.Run(_Main);
            //Application.Run(new WinFormUI.SaleTicket.frmSaleChoose());

            //Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            OnException(e.Exception);
        }


        static void OnException(Exception ex)
        {
            if (ex.GetType() == typeof(ApplicationException) || ex.GetType().IsSubclassOf(typeof(ApplicationException)))
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ex.GetType() == typeof(MySqlException) && ((MySqlException)ex).Number == 547)
            {
                MessageBox.Show("已经被使用，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ex.GetType() == typeof(MySqlException) && ((MySqlException)ex).Number == 53)
            {
                MessageBox.Show("无法连接到服务器，请检查网络连接状态是否正常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ex.GetType() == typeof(NotImplementedException))
            {
                MessageBox.Show("当前版本暂不支持此功能！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ex.GetType() == typeof(System.Net.WebException))
            {
                MessageBox.Show(ex.InnerException.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ex.GetType() == typeof(SystemException) || ex.GetType().IsSubclassOf(typeof(SystemException)))
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string message = ex.Message;
                message += "\r\n" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    message += "\r\n\r\n" + ex.InnerException.Message;
                    message += "\r\n" + ex.InnerException.StackTrace;
                }
                MessageBox.Show(message, "内部错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WinFormUI.SaleTicket
{
    public partial class frmQuery : Form
    {
        private string _showplanid;
        public frmQuery(string showplanid)
        {
            _showplanid = showplanid;
            InitializeComponent();
        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Query();
        }

        private void Query()
        {
            Flamingo.Entity.Para_UserSoldInfo model = Flamingo.BLL.Ticket.Query(_showplanid, FrmMain.curUser.UserId);
            string msg = string.Format("[{0}]\r\n本场共售出{1}张票,其中您售出{2}张票;\r\n今天您售出{2}张票,退票{3}张;\r\n本人退本售{4}张,本人退他售{5}张;\r\n应收票款为{6}元;",
                FrmMain.curUser.UserName, model.TicketCount, model.MyTicketCount, model.MyRefundCount,
                model.MyRefundMyCount, model.MyRefundAtherCount, model.MyTotalCash.ToString("0.00"));
            lblMessage.Text = msg;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int sub = 0;

        private void printText(string text, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //取得Graphics实例
            Graphics g = e.Graphics;

            //获得相关点坐标、长度、宽度
            int x = 0;
            int y = 0;
            int width = 300;
            int height = 100;

            //设置字体
            Font font = new Font("宋体", 9);

            //这个方法后面讲

            int charnum, line;
            g.MeasureString(text.Substring(sub), font, new SizeF(width, height - 10), new StringFormat(), out charnum, out line);

            //打印string         
            g.DrawString(text.Substring(sub), font, Brushes.Black, new RectangleF(x, y, width, height), new StringFormat());

            //设置截取位置
            sub += charnum;

            //设置HasMorePage属性
            if (sub < text.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;

                sub = 0;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("comaond", 433, 219);
            printText(lblMessage.Text, e);
        }

    }
}

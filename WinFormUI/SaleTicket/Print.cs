using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormUI.TemplateUI;
using System.Drawing;

namespace WinFormUI.SaleTicket
{
    public class Print
    {
        /// <summary>
        /// 打印影票
        /// </summary>
        /// <param name="seat"></param>
        public static void PrintTicket(Flamingo.TemplateCore.TemplatePrintModel PrintModel)
        {
            Cobainsoft.Windows.Forms.BarcodeControl BarcodeControl = new Cobainsoft.Windows.Forms.BarcodeControl();
            BarcodeControl.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.CODE128C;
            BarcodeControl.CopyRight = "";
            BarcodeControl.ShowCode39StartStop = true;
            BarcodeControl.StretchText = true;
            BarcodeControl.TextPosition = Cobainsoft.Windows.Forms.BarcodeTextPosition.Below;
            TemplatePrintCore core = new TemplatePrintCore(FrmMain.template, PrintModel);
            BarcodeControl.Data = PrintModel.BarCodeStr;
            core.BarCode = BarcodeControl;
            //core.ShowPrintDialog = true;
            core.Print();
        }

        /// <summary>
        /// 打印影票
        /// </summary>
        /// <param name="seat"></param>
        public static void PrintTest()
        {
            Flamingo.TemplateCore.TemplatePrintModel PrintModel = new Flamingo.TemplateCore.TemplatePrintModel();
            PrintModel.BarCodeStr = "12345678901234567890";
            PrintModel.FilmName = "打印测试";
            PrintModel.HallFieldCode = "00";
            PrintModel.HallName = "影厅名称";
            PrintModel.RowNumber = "0";
            PrintModel.SeatNumber = "0";
            PrintModel.SellTime = DateTime.Now.ToString("yyyyMMddHHmm");
            PrintModel.StaffNumber = "000110011";
            PrintModel.TheaterName = "影院名称";
            PrintModel.TicketDate = DateTime.Now.ToShortDateString();
            PrintModel.TicketPrice = "100.00元";
            PrintModel.TicketTime = DateTime.Now.ToShortTimeString();
            PrintModel.TicketType = "电影票";
            PrintModel.PayType = "现金";
            PrintModel.SeatNumberStr = "0排0座";
            PrintModel.CheckingType = "对号入座";
            PrintModel.Position = "01";

            Cobainsoft.Windows.Forms.BarcodeControl BarcodeControl = new Cobainsoft.Windows.Forms.BarcodeControl();
            BarcodeControl.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.CODE128C;
            BarcodeControl.CopyRight = "";
            BarcodeControl.ShowCode39StartStop = true;
            BarcodeControl.StretchText = true;
            BarcodeControl.TextPosition = Cobainsoft.Windows.Forms.BarcodeTextPosition.Below;
            TemplatePrintCore core = new TemplatePrintCore(FrmMain.template, PrintModel);
            BarcodeControl.Data = PrintModel.BarCodeStr;
            core.BarCode = BarcodeControl;
            //core.ShowPrintDialog = true;
            core.Print();
        }
        

        /// <summary>
        /// 数字转图片
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Bitmap Turn(string number)
        {
            Bitmap bt = null;
            switch (number)
            {
                case "0":
                    bt = global::WinFormUI.Properties.Resources.T0; break;
                case "1":
                    bt = global::WinFormUI.Properties.Resources.T1; break;
                case "2":
                    bt = global::WinFormUI.Properties.Resources.T2; break;
                case "3":
                    bt = global::WinFormUI.Properties.Resources.T3; break;
                case "4":
                    bt = global::WinFormUI.Properties.Resources.T4; break;
                case "5":
                    bt = global::WinFormUI.Properties.Resources.T5; break;
                case "6":
                    bt = global::WinFormUI.Properties.Resources.T6; break;
                case "7":
                    bt = global::WinFormUI.Properties.Resources.T7; break;
                case "8":
                    bt = global::WinFormUI.Properties.Resources.T8; break;
                case "9":
                    bt = global::WinFormUI.Properties.Resources.T9; break;
            }
            return bt;
        }
    }
}

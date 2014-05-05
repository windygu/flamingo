using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flamingo.TemplateCore;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace WinFormUI.TemplateUI
{
    public class TemplatePrintCore
    {
        Template template;

        TemplatePrintModel model;
        int x = 0;
        int y = 0;
        public TemplatePrintCore(Template template, TemplatePrintModel templatePrintModel)
        {
            try
            {
                this.template = template;
                this.model = templatePrintModel;
                printDialog1 = new System.Windows.Forms.PrintDialog();
                printDocument1 = new System.Drawing.Printing.PrintDocument();
                printDocument1.PrinterSettings.PrinterName = template.PrintSetting.PrintModule;
                //printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("123", (int)(template.Background.ImageWidth / 2.54), (int)(template.Background.ImageHeight / 2.54));
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("comaond", 433, 219);
                x = GetX(printDocument1.DefaultPageSettings.HardMarginX);
                y = GetY(printDocument1.DefaultPageSettings.HardMarginY);

                printDocument1.DefaultPageSettings.Margins.Left = 0;
                //printDocument1.DefaultPageSettings.Margins.Left -=(int) printDocument1.DefaultPageSettings.HardMarginX;
                //printDocument1.DefaultPageSettings.Margins.Right -= (int)printDocument1.DefaultPageSettings.HardMarginY;
                //printDocument1.DefaultPageSettings.Margins.Top = 0;
                //printDocument1.DefaultPageSettings.HardMarginX
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool showPrintDialog = false;

        public bool ShowPrintDialog
        {
            get { return showPrintDialog; }
            set { showPrintDialog = value; }
        }

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;

        public void Print()
        {
            printDialog1.Document = printDocument1;
            if (showPrintDialog)
            {
                printDialog1.ShowDialog();
            }
            printDocument1.Print();
        }

        bool showbg = false;

        private Cobainsoft.Windows.Forms.BarcodeControl _BarCode;
        public Cobainsoft.Windows.Forms.BarcodeControl BarCode
        {
            set { _BarCode = value; }
            get { return _BarCode; }
        }
        private Rectangle _BarCodeRectangle;
        public Rectangle BarCodeRectangle
        {
            set { _BarCodeRectangle = value; }
            get { return _BarCodeRectangle; }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (showbg)
            {
                e.Graphics.DrawImage(template.Background.BgImage, new Rectangle(new Point(0, 0), new Size((int)MillimetersToPixelsWidthX(template.Background.ImageWidth, e.Graphics), (int)MillimetersToPixelsWidthY(template.Background.ImageHeight, e.Graphics))));
            }
            for (int i = 0; i < template.Face.Items.Count; i++)
            {
                TemplateFaceItem item = template.Face.Items[i];
                object o = GetFromType(item.Itemtype);
                if (o.GetType() == typeof(Image))
                {
                    Image image = o as Image;
                    e.Graphics.DrawImage(image, new Rectangle(new Point(0, 0), new Size(image.Size.Width, image.Size.Height)));
                }
                else
                {
                    if (item.Itemtype != "条码")
                    {
                        Brush b = new SolidBrush(item.ItemColor);
                        e.Graphics.DrawString(o.ToString(), item.ItemFont, b, new PointF((int)MillimetersToPixelsWidthX(item.XAxis, e.Graphics) - x, (int)MillimetersToPixelsWidthY(item.YAxis, e.Graphics) - y));
                    }
                    else
                    {
                        if (_BarCode != null)
                        {
                            _BarCodeRectangle = new Rectangle((int)MillimetersToPixelsWidthX(item.XAxis, e.Graphics) - x, (int)MillimetersToPixelsWidthY(item.YAxis, e.Graphics) - y, 200, 60);
                            _BarCode.Draw(e.Graphics, _BarCodeRectangle, GraphicsUnit.Inch, 0.01f, 0, null);
                        }
                    }
                }
            }
        }

        private object GetFromType(string p)
        {
            if (p == "影片名称")
            {
                return model.FilmName;
            }
            else if (p == "排号")
            {
                return model.RowNumber;
            }
            else if (p == "影厅名称")
            {
                return model.HallName;
            }
            else if (p == "座号")
            {
                return model.SeatNumber;
            }
            else if (p == "排号座号")
                return model.SeatNumberStr;
            else if (p == "售票员工号")
            {
                return model.StaffNumber;
            }
            else if (p == "影院名称")
            {
                return model.TheaterName;
            }
            else if (p == "日期")
            {
                return model.TicketDate;
            }
            else if (p == "票价")
            {
                return model.TicketPrice;
            }
            else if (p == "时间")
            {
                return model.TicketTime;
            }
            else if (p == "票种")
            {
                return model.TicketType;
            }
            else if (p == "支付方式")
            {
                return model.PayType;
            }
            else if (p == "出票时间")
            {
                return model.SellTime;
            }
            else if (p == "条码")
            {
                return model.BarCodeStr;
            }
            else if (p == "图标")
            {
                return model.Icon;
            }
            else if (p == "厅场码")
            {
                return model.HallFieldCode;
            }
            else if (p == "入座方式")
            {
                return model.CheckingType;
            }
            else if (p == "售票时间和工号")
            {
                return model.SellTime + model.StaffNumber;
            }
            else if (p == "场次序号")
            {
                return model.Position;
            }
            else if (p == "厅号和场次")
            {
                return model.HallFieldCode + model.Position;
            }
            return p;
        }

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);

        private int GetX(float p1)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 88);     // HORZRES 
            g.ReleaseHdc(hdc);
            return (int)(p1 * 254 / width);
        }

        private int GetY(float p1)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 90);     // HORZRES 
            g.ReleaseHdc(hdc);
            return (int)(p1 * 254 / width);
        }

        public static double MillimetersToPixelsWidthX(double length, Graphics g1)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 88);     // HORZRES 
            //int pixels = GetDeviceCaps(hdc, 88);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            //return (((double)pixels / (double)width) * (double)length) / 25.4;
            return width * length / 254;
        }

        public static double MillimetersToPixelsWidthY(double length, Graphics g1)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);

            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 90);     // HORZRES 
            //int pixels = GetDeviceCaps(hdc, 88);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            //return (((double)pixels / (double)width) * (double)length) / 25.4;
            return width * length / 254;
        }
    }
}

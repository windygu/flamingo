using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using Flamingo.TemplateCore;
using System.Drawing.Printing;

namespace WinFormUI.TemplateUI
{
    public class VoucherPrintCore
    {
        Template template;

        TemplatePrintModelVoucher voucherModel;

        int x = 0;
        int y = 0;
        int PageNum = 0;
        string startNum = "";
        string endNum = "";
        public VoucherPrintCore(Template template, TemplatePrintModelVoucher templatePrintModel)
        {
            try
            {
                this.template = template;
                this.voucherModel = templatePrintModel;
                printDialog1 = new System.Windows.Forms.PrintDialog();
                printDocument1 = new System.Drawing.Printing.PrintDocument();
                printDocument1.PrinterSettings.PrinterName = template.PrintSetting.PrintModule;
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("comaond", (int)(template.Background.ImageWidth / 2.54), (int)(template.Background.ImageHeight / 2.54));
                x = GetX(printDocument1.DefaultPageSettings.HardMarginX);
                y = GetY(printDocument1.DefaultPageSettings.HardMarginY);
                printDocument1.DefaultPageSettings.Margins.Left = 0;
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                if (templatePrintModel.SerialNumber != "")
                {
                    startNum = templatePrintModel.SerialNumber.Substring(0, 16);
                    endNum = templatePrintModel.SerialNumber.Substring(17);
                    PageNum = Convert.ToInt32(endNum.Substring(10)) - Convert.ToInt32(startNum.Substring(10)) + 1;
                }
                //printDialog1.AllowSomePages = true;
                printDocument1.PrinterSettings.Collate = true;
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

        int currentPageNum = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            currentPageNum++;

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
            e.Graphics.DrawString(GetNum(currentPageNum),new Font(new FontFamily("宋体"),8,FontStyle.Bold) ,new SolidBrush(Color.Black),new PointF(10,10));
            if (currentPageNum < PageNum)
            {
                e.HasMorePages = true;
            }
            else
            {
                currentPageNum = 0;
                e.HasMorePages = false;
            }
        }

        private string GetNum(int currentPageNum)
        {
            int num = Convert.ToInt32(startNum.Substring(10)) + currentPageNum-1;
            return startNum.Substring(0, 10) + string.Format("{0:000000}", num);
        }

        private object GetFromType(string p)
        {
            if (p == "票券名称")
            {
                return voucherModel.VoucherName;
            }
            else if (p == "票券面值")
            {
                return voucherModel.VoucherPrice;
            }
            else if (p == "影院名称")
            {
                TemplateCore core = new TemplateCore();
                return core.GetTheaterName();
            }
            else if (p == "发行日期")
            {
                return voucherModel.ReleaseDate;
            }
            else if (p == "使用截至日期")
            {
                return voucherModel.ExpireDate;
            }
            else if (p == "类型")
            {
                return voucherModel.VoucherType;
            }
            else if (p == "券类")
            {
                return voucherModel.VoucherSubType;
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

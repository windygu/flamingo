using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.TemplateCore;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace WinFormUI.TemplateUI
{
    public partial class TemplatePrint : Form
    {
        public TemplatePrint()
        {
            InitializeComponent();
            IList<string> printModel = GetPrintModels();
            PrintModelComboBox.DataSource = printModel;
        }

        public TemplatePrint(bool voucher)
        {
            this.voucher = voucher;
            InitializeComponent();
            IList<string> printModel = GetPrintModels();
            PrintModelComboBox.DataSource = printModel;
            if (voucher)
            {
                if (voucherModel == null)
                {
                    voucherModel = CreateDemoTemplatePrintModelVoucher();
                }
            }
        }

        bool voucher = false;

        public bool Voucher
        {
            get { return voucher; }
            set { voucher = value; }
        }

        private IList<string> GetPrintModels()
        {
            IList<string> models = new List<string>();
            foreach (string printName in PrinterSettings.InstalledPrinters)
            {
                models.Add(printName);
            }
            return models;
        }

        TemplatePrintModel model = null;

        TemplatePrintModelVoucher voucherModel = null;

        public TemplatePrintModel PrintModel
        {
            get { return model; }
            set { model = value; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemplateNameComboBox.Items.Clear();
            string model = PrintModelComboBox.Text.Trim();
            TemplateCore core = new TemplateCore();
            IList<Template> templates = core.GetAllTemplate();
            foreach (Template temp in templates)
            {
                if (temp.PrintSetting != null && temp.PrintSetting.PrintModule == model && (voucher == (temp.Template_Type == TemplateType.Vouch)))
                {

                    TemplateObj obj = new TemplateObj(temp);
                    TemplateNameComboBox.Items.Add(obj);
                }
            }
            if (TemplateNameComboBox.Items.Count != 0)
            {
                TemplateNameComboBox.SelectedIndex = 0;
            }
        }

        class TemplateObj
        {
            Template template;

            public Template Template
            {
                get { return template; }
                set { template = value; }
            }

            public TemplateObj(Template temp)
            {
                template = temp;
            }

            public override string ToString()
            {
                if (template == null || template.Name == null)
                {
                    return "";
                }
                return template.Name;
                //return base.ToString();
            }
        }

        Template template = null;

        public Template Template1
        {
            get { return template; }
            set { template = value; }
        }

        Cobainsoft.Windows.Forms.BarcodeControl BarcodeControl = null;

        private void TemplateNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemplateObj templateObj = TemplateNameComboBox.SelectedItem as TemplateObj;
            template = templateObj.Template;
            //printPreviewControl1.Width = (int)MillimetersToPixelsWidth(template.Background.ImageWidth);
            //printPreviewControl1.Height = (int)MillimetersToPixelsWidth(template.Background.ImageHeight);

            printPreviewControl1.Document = printDocument1;
            // printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("123", (int)(template.Background.ImageWidth/2.54), (int)(template.Background.ImageHeight/2.54));
            if (!voucher)
            {
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("comaond", 433, 219);
            }
            else 
            {
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("comaond", (int)(template.Background.ImageWidth / 2.54), (int)(template.Background.ImageHeight / 2.54));
            }
            this.model = CreateDemoTemplatePrintModel();
            //printDocument1.Print();
            printDocument1.PrinterSettings.PrinterName = template.PrintSetting.PrintModule;
            printPreviewControl1.InvalidatePreview();
        }

        TemplatePrintModelVoucher CreateDemoTemplatePrintModelVoucher()
        {
            TemplatePrintModelVoucher voucher = new TemplatePrintModelVoucher();
            voucher.Desciption = "";
            voucher.ExpireDate = DateTime.Now.ToShortDateString();
            voucher.ReleaseDate = DateTime.Now.ToShortDateString();
            voucher.VoucherName = "票券名称";
            voucher.VoucherPrice = "60.00";
            voucher.VoucherSubType = "券类";
            voucher.VoucherType = "类型";
            voucher.VoucheTheaterName = "";
            voucher.SerialNumber = "2011121401000001-2011121401000003";
            return voucher;
        }

        TemplatePrintModel CreateDemoTemplatePrintModel()
        {
            //Graphics gs = new Graphics();
            TemplatePrintModel model1 = new TemplatePrintModel();
            model1.BarCodeStr = "11111111111";
            model1.FilmName = "电影名称";
            model1.HallFieldCode = "00";
            model1.HallName = "影厅名称";
            model1.RowNumber = "0";
            model1.SeatNumber = "0";
            model1.SellTime = DateTime.Now.ToString();
            model1.StaffNumber = "000110011";
            model1.TheaterName = "影院名称";
            model1.TicketDate = DateTime.Now.ToShortDateString();
            model1.TicketPrice = "80.00元";
            model1.TicketTime = DateTime.Now.ToShortTimeString();
            model1.TicketType = "电影票";
            model1.PayType = "现金";
            model1.SeatNumberStr = "0排0座";
            model1.CheckingType = "对号入座";

            BarcodeControl = new Cobainsoft.Windows.Forms.BarcodeControl();
            BarcodeControl.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.CODE128C;
            BarcodeControl.CopyRight = "";
            BarcodeControl.ShowCode39StartStop = true;
            BarcodeControl.StretchText = true;
            BarcodeControl.TextPosition = Cobainsoft.Windows.Forms.BarcodeTextPosition.Below;
            return model1;
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
                TemplateCore core = new TemplateCore();
                return core.GetTheaterName();
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
            else if (p == "票券名称")
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

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            if (true)
            {
                e.Graphics.DrawImage(template.Background.BgImage, new Rectangle(new Point(0, 0), new Size((int)MillimetersToPixelsWidthX(template.Background.ImageWidth, g), (int)MillimetersToPixelsWidthY(template.Background.ImageHeight, g))));
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
                        e.Graphics.DrawString(o.ToString(), item.ItemFont, b, new PointF((int)MillimetersToPixelsWidthX(item.XAxis, e.Graphics), (int)MillimetersToPixelsWidthY(item.YAxis, e.Graphics)));
                    }
                    else
                    {
                        if (BarcodeControl != null)
                        {
                            Rectangle _BarCodeRectangle = new Rectangle((int)MillimetersToPixelsWidthX(item.XAxis, e.Graphics), (int)MillimetersToPixelsWidthY(item.YAxis, e.Graphics), 200, 60);
                            BarcodeControl.Draw(e.Graphics, _BarCodeRectangle, GraphicsUnit.Inch, 0.01f, 0, null);
                        }
                    }
                }
            }
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (voucher)
                {
                    VoucherPrintCore core = new VoucherPrintCore(template, voucherModel);
                    core.Print();
                }
                else
                {
                    TemplatePrintCore core = new TemplatePrintCore(template, model);
                    this.DialogResult = DialogResult.OK;
                    ////core.ShowPrintDialog = true;
                    //core.Print();
                }
            }
            catch
            {
                this.DialogResult = DialogResult.No;
            }
        }

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);

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
        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using Cobainsoft.Windows.Forms;

namespace WinFormUI.SaleTicket
{
    public partial class BarCodeSetupBox : Form
    {
        private int _BarcodeType = 0;
        private string _Data;
        public BarCodeSetupBox(int BarcodeType, string Data)
        {
            _BarcodeType = BarcodeType;
            _Data = Data;
            InitializeComponent();
        }
        public BarCodeSetupBox()
        {
            InitializeComponent();
        }

        private void BarCodeSetupBox_Load(object sender, EventArgs e)
        {
            comType.SelectedIndex = _BarcodeType;
            comDataShow.SelectedIndex = 0;
            txtData.Text = _Data;
            Invalidate();
        }

        private void comType_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcodeControl2.BarcodeType = GetBarcodeType(comType.Text);
            Invalidate();
        }

        BarcodeType GetBarcodeType(string cType)
        {
            BarcodeType bt = BarcodeType.CODE128A;
            switch (cType.ToUpper())
            {
                case "CODE128A":
                    bt = BarcodeType.CODE128A;
                    break;
                case "C2OF5":
                    bt = BarcodeType.C2OF5;
                    break;
                case "CODABAR":
                    bt = BarcodeType.CODABAR;
                    break;
                case "CODE128B":
                    bt = BarcodeType.CODE128B;
                    break;
                case "CODE128C":
                    bt = BarcodeType.CODE128C;
                    break;
                case "CODE39":
                    bt = BarcodeType.CODE39;
                    break;
                case "CODE39CHECK":
                    bt = BarcodeType.CODE39CHECK;
                    break;
                case "CODE93":
                    bt = BarcodeType.CODE93;
                    break;
                case "EAN128A":
                    bt = BarcodeType.EAN128A;
                    break;
                case "EAN128B":
                    bt = BarcodeType.EAN128B;
                    break;
                case "EAN128C":
                    bt = BarcodeType.EAN128C;
                    break;
                case "EAN13":
                    bt = BarcodeType.EAN13;
                    break;
                case "EAN13_2":
                    bt = BarcodeType.EAN13_2;
                    break;
                case "EAN13_5":
                    bt = BarcodeType.EAN13_5;
                    break;
                case "EAN8":
                    bt = BarcodeType.EAN8;
                    break;
                case "EAN8_2":
                    bt = BarcodeType.EAN8_2;
                    break;
                case "EAN8_5":
                    bt = BarcodeType.EAN8_5;
                    break;
                case "INTERLEAVED2OF5":
                    bt = BarcodeType.INTERLEAVED2OF5;
                    break;
                case "MSIPLESSEY":
                    bt = BarcodeType.MSIPLESSEY;
                    break;
                case "MSIPLESSEYCHECK10":
                    bt = BarcodeType.MSIPLESSEYCHECK10;
                    break;
                case "MSIPLESSEYCHECK1010":
                    bt = BarcodeType.MSIPLESSEYCHECK1010;
                    break;
                case "MSIPLESSEYCHECK11":
                    bt = BarcodeType.MSIPLESSEYCHECK11;
                    break;
                case "MSIPLESSEYCHECK1110":
                    bt = BarcodeType.MSIPLESSEYCHECK1110;
                    break;
                case "PLANET":
                    bt = BarcodeType.PLANET;
                    break;
                case "POSTNET":
                    bt = BarcodeType.POSTNET;
                    break;
                case "ROYALMAIL":
                    bt = BarcodeType.ROYALMAIL;
                    break;
                case "UPCA":
                    bt = BarcodeType.UPCA;//Rectangle(90, 5, 150, 50)
                    break;
                case "UPCA_2":
                    bt = BarcodeType.UPCA_2;
                    break;
                case "UPCA_5":
                    bt = BarcodeType.UPCA_5;
                    break;
                case "UPCE":
                    bt = BarcodeType.UPCE;
                    break;
                case "UPCE_2":
                    bt = BarcodeType.UPCE_2;
                    break;
                case "UPCE_5":
                    bt = BarcodeType.UPCE_5;
                    break;
            }
            return bt;
        }

        private void cheCode39_CheckedChanged(object sender, EventArgs e)
        {
            barcodeControl2.ShowCode39StartStop = cheCode39.Checked;
            Invalidate();
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            barcodeControl2.Data = txtData.Text;
            Invalidate();
        }

        private void txtSubData_TextChanged(object sender, EventArgs e)
        {
            barcodeControl2.AddOnData = txtSubData.Text;
            Invalidate();
        }

        private void comDataShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcodeControl2.TextPosition = GetTextPosition(comDataShow.Text);
            Invalidate();
        }

        BarcodeTextPosition GetTextPosition(string str)
        {
            switch (str)
            {
                case "顶部":
                    return BarcodeTextPosition.Above;
                case "不显示":
                    return BarcodeTextPosition.NotShown;
                case "底部":
                default:
                    return BarcodeTextPosition.Below;
            }
        }
        
        private void vistaButton1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            //CommonPrintDialog cpd = new CommonPrintDialog();
            //cpd.PrintSetupType = PrintSetupType.None;
            //cpd.Document = pd;
            //if (cpd.ShowDialog() == DialogResult.OK)
            //{
            //    pd.Print();
            //}
            PrintPreviewDialog cppd = new PrintPreviewDialog();
            cppd.Document = pd;
            cppd.ShowDialog();
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            barcodeControl2.Draw(g, barcodeControl2.ClientRectangle, GraphicsUnit.Inch, 0.01f, 0, null);

            g.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            barcodeControl2.StretchText = checkBox1.Checked;
        }

        void txtTitle_TextChanged(object sender, System.EventArgs e)
        {
            barcodeControl2.CopyRight = txtTitle.Text;
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "GIF files (*.gif)|*.gif|PNG files (*.png)|*.png|JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP files (*.bmp;*.dib)|*.bmp;*.dib|TIFF files (*.tif)|*.tif";
            fileDialog.FilterIndex = 1;
            fileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            fileDialog.RestoreDirectory = false;
            ImageFormat[] afmt = { ImageFormat.Gif, ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Bmp, ImageFormat.Tiff };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = fileDialog.OpenFile()) != null)
                {
                    int barcodeWidth = 1;
                    int barcodeHeight = 50;
                    barcodeControl2.MakeImage(afmt[fileDialog.FilterIndex - 1], barcodeWidth, barcodeHeight, true, false, null, myStream);
                    //Image img = Image.FromStream(myStream);
                    Icon icon = Icon.FromHandle(new Bitmap(myStream).GetHicon());
                    myStream.Close();
                }
            }
        }

        public Icon GetIcon()
        {
            System.IO.MemoryStream myStream = new System.IO.MemoryStream();///创建内存流
            int barcodeWidth = 1;
            int barcodeHeight = 50;
            barcodeControl2.MakeImage(ImageFormat.Gif, barcodeWidth, barcodeHeight, true, false, null, myStream);
            //Image img = Image.FromStream(myStream);
            Icon icon = Icon.FromHandle(new Bitmap(myStream).GetHicon());
            myStream.Close();
            return icon;
        }
    }
}
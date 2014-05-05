using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace Flamingo.Common
{
    /// <summary>
    /// 图片处理
    /// </summary>
    public class Draw
    {
        /// <summary>
        /// 在图片上输入文字
        /// </summary>
        /// <param name="name">输入文字</param>
        /// <param name="savefilePath">保存路径</param>
        /// <param name="backgroundImg">底板图片地址</param>
        public Image CreateImage(string name, string savefilePath, string backgroundImg)
        {
            int wid = 76;
            //int high = 42;

            int x = 5;
            int y = 12;

            Font font = new Font("Arial", 9, FontStyle.Bold);
            //字的颜色 
            SolidBrush brush = new SolidBrush(Color.Black);

            //Bitmap image = new Bitmap(wid, high);
            Bitmap image = new Bitmap(backgroundImg);


            Graphics g = Graphics.FromImage(image);
            //g.Clear(ColorTranslator.FromHtml("#f0f0f0"));

            SizeF sizText = g.MeasureString(name, font);
            if (!string.IsNullOrEmpty(name))
            {
                x = (wid - ((Int32)sizText.Width)) / 2;
            }

            RectangleF rect = new RectangleF(x, y, sizText.Width, sizText.Height);

            //绘制图片 
            g.DrawString(name, font, brush, rect);
            //保存 
            image.Save(savefilePath, ImageFormat.Jpeg);
            //释放对象 
            g.Dispose();
            image.Dispose();

            return null;
        }
    }
}

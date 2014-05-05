using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.TemplateCore
{
    public class TemplateBackground:IDisposable
    {
        Image bgImage = null;

        public Image BgImage
        {
            get { return bgImage; }
            set { bgImage = value; }
        }

        int imageHeight;

        public int ImageHeight
        {
            get { return imageHeight; }
            set { imageHeight = value; }
        }

        int imageWidth;

        public int ImageWidth
        {
            get { return imageWidth; }
            set { imageWidth = value; }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (bgImage != null) 
            {
                bgImage.Dispose();
            }
        }

        #endregion
    }
}

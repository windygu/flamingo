using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public class TemplateFace
    {
        public TemplateFace() { }

        TemplateFaceItemCollection items = new TemplateFaceItemCollection();

        public TemplateFaceItemCollection Items
        {
            get { return items; }
            set { items = value; }
        }

        int faceWidth;

        public int FaceWidth
        {
            get { return faceWidth; }
            set { faceWidth = value; }
        }

        int faceHeight;

        public int FaceHeight
        {
            get { return faceHeight; }
            set { faceHeight = value; }
        }
    }
}

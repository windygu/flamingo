using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormUI.BI
{
    public class MapEditorShape
    {
        private String m_shapeCode;
        private String m_shapeText;

        public String ShapeText
        {
            get { return m_shapeText; }
            set { m_shapeText = value; }
        }

        public String ShapeCode
        {
            get { return m_shapeCode; }
            set { m_shapeCode = value; }
        }

        public MapEditorShape()
        {
        }

        public MapEditorShape(String shapeCode, String shapeText)
        {
            this.ShapeCode = shapeCode;
            this.ShapeText = shapeText;
        }
    }
}

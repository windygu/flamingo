using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.TemplateCore
{
    public class TemplateFaceItem
    {
        public TemplateFaceItem()
        {
            templateItemId = -1;
            status = TemplateItemStatus.New;
        }

        int templateItemId;

        public int TemplateItemId
        {
            get { return templateItemId; }
            internal set { templateItemId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int xAxis;

        public int XAxis
        {
            get { return xAxis; }
            set { xAxis = value; }
        }

        int yAxis;

        public int YAxis
        {
            get { return yAxis; }
            set { yAxis = value; }
        }

        Font itemFont;

        public Font ItemFont
        {
            get { return itemFont; }
            set { itemFont = value; }
        }

        Color itemColor;

        public Color ItemColor
        {
            get { return itemColor; }
            set { itemColor = value; }
        }

        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        TemplateItemStatus status;

        public TemplateItemStatus Status
        {
            get { return status; }
            internal set { status = value; }
        }

        string itemtype;

        public string Itemtype
        {
            get { return itemtype; }
            set { itemtype = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public class Template
    {
        public Template(int id)
        {
            templateId = id;
            face = new TemplateFace();
            background = new TemplateBackground();
        }

        int templateId;

        public int TemplateId
        {
            get { return templateId; }
            internal set { templateId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        TemplateType type;

        public TemplateType Template_Type
        {
            get { return type; }
            set { type = value; }
        }

        TemplateFace face;

        public TemplateFace Face
        {
            get { return face; }
            set { face = value; }
        }

        TemplateBackground background;

        public TemplateBackground Background
        {
            get { return background; }
            set { background = value; }
        }

        PrintSetting printSetting;

        public PrintSetting PrintSetting
        {
            get { return printSetting; }
            set { printSetting = value; }
        }

        IList<string> customItems;

        public IList<string> CustomItems
        {
            get { return customItems; }
            //set { customItems = value; }
        }

        //public void SaveCustomItems()
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteCustomItem(int templateId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

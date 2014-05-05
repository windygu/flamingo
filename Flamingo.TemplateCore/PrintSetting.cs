using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public class PrintSetting
    {
        public PrintSetting() 
        {
            printSettingId = -1;
        }

        private int printSettingId;

        public int PrintSettingId
        {
            get { return printSettingId; }
            internal set { printSettingId = value; }
        }

        private string printModule;

        public string PrintModule
        {
            get { return printModule; }
            set { printModule = value; }
        }

        private string settingFile;

        public string SettingFile
        {
            get { return settingFile; }
            set { settingFile = value; }
        }
    }
}

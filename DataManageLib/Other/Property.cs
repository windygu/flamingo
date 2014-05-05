using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo
{
    public static class Property
    {
        //public static System.Configuration.SettingsPropertyValueCollection Setting
        //{
        //    get { return Flamingo.Properties.Settings.Default.PropertyValues; }
        //}

        public static Flamingo.DataManageLib.Properties.Settings Setting
        {
            get { return Flamingo.DataManageLib.Properties.Settings.Default; }
        }

        public static void Save()
        {
            Flamingo.DataManageLib.Properties.Settings.Default.Save();
        }
    }
}

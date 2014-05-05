using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public enum TemplateType
    {
        File,
        Vouch
    }

    public class TemplateTypeHelp
    {
        public static string GetTemplateString(TemplateType type)
        {
            switch (type)
            {
                case TemplateType.File: return "电影票";
                case TemplateType.Vouch: return "优惠券";
            }
            return "电影票";
        }

        public static TemplateType GetTemplateString(string type)
        {
            switch (type)
            {
                case "电影票": return TemplateType.File;
                case "优惠券": return TemplateType.Vouch;
            }
            return TemplateType.File;
        }
        //public static string GetTemplateString(TemplateType type)
        //{
        //    switch (type)
        //    {
        //        case TemplateType.File: return "aaa";
        //        case TemplateType.Vouch: return "bbb";
        //    }
        //    return "aaa";
        //}

        //public static TemplateType GetTemplateString(string type)
        //{
        //    switch (type)
        //    {
        //        case "aaa": return TemplateType.File;
        //        case "bbb": return TemplateType.Vouch;
        //    }
        //    return TemplateType.File;
        //}
    }
}

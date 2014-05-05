using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Flamingo.TemplateCore
{
    public class TemplateFileReader
    {
        static readonly string localTemplateFolder = "LocalTemplate";

        public string[] GetTemplateFileName(string folderUrl)
        {
            if (Directory.Exists(folderUrl))
            {
                return Directory.GetFiles(folderUrl);
            }
            return null;
        }

        public Template ReaderFile(string fileUrl)
        {
            Template template = new Template(-1);
            if (!File.Exists(fileUrl))
            {
                return null;
            }
            using (FileStream fs = File.Open(fileUrl, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string text = "";
                    while (text == reader.ReadLine())
                    {
                        if (text.StartsWith("[") && text.EndsWith("]"))
                        {
                            if (text == "[Template]")
                            {
                                text = ReaderTemplate(reader, ref template);
                            }
                            if (text == "[TemplateFace]")
                            {
                                text = ReaderTemplate(reader, ref template);
                            }
                            if (text == "[Item]")
                            {
                                text = ReaderTemplate(reader, ref template);
                            }
                            if (text == "[TemplateBackground]")
                            {
                                text = ReaderTemplate(reader, ref template);
                            }
                            if (text == "[PrintSetting]")
                            {
                                text = ReaderTemplate(reader, ref template);
                            }
                        }
                    }
                }
            }
            return template;
        }

        private string ReaderTemplate(StreamReader reader, ref Template template)
        {
            string text = "";
            while ((text = reader.ReadLine()) != null)
            {
                if (text.StartsWith("templateId="))
                {
                    template.TemplateId = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("name="))
                {
                    template.Name = GetValue(text);
                }
                if (text.StartsWith("type="))
                {
                    template.Template_Type = TemplateTypeHelp.GetTemplateString(GetValue(text));
                }
                if (text.StartsWith("[") && text.EndsWith("]"))
                {
                    return text;
                }
            }
            return null;
        }

        private string ReadTemplateFace(StreamReader reader, ref Template template)
        {
            string text = "";
            while ((text = reader.ReadLine()) != null)
            {
                if (text.StartsWith("FaceWidth="))
                {
                    template.Face.FaceWidth = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("FaceHeight="))
                {
                    template.Face.FaceHeight = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("[") && text.EndsWith("]"))
                {
                    return text;
                }
            }
            return null;
        }

        private string ReadTemplateFaceItem(StreamReader reader, ref Template template)
        {
            string text = "";
            TemplateFaceItem item = new TemplateFaceItem();
            while ((text = reader.ReadLine()) != null)
            {

                if (text.StartsWith("TemplateItemId="))
                {
                    item.TemplateItemId = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("Name="))
                {
                    item.Name = GetValue(text);
                }
                if (text.StartsWith("XAxis="))
                {
                    item.XAxis = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("YAxis="))
                {
                    item.YAxis = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("ItemFont="))
                {
                    item.ItemFont = new System.Drawing.Font(GetValue(text), 8);
                }
                if (text.StartsWith("ItemFontSize="))
                {
                    item.ItemFont = new System.Drawing.Font(item.ItemFont.FontFamily.Name, Convert.ToInt32(GetValue(text)));
                }
                if (text.StartsWith("ItemColor="))
                {
                    string rgb = GetValue(text);
                    string[] rgbs = rgb.Split(new char[] { ' ' });
                    item.ItemColor = Color.FromArgb(Convert.ToInt32(rgbs[0]), Convert.ToInt32(rgbs[1]), Convert.ToInt32(rgbs[2]));
                }
                if (text.StartsWith("Description="))
                {
                    item.Description = GetValue(text);
                }
                if (text.StartsWith("Itemtype="))
                {
                    item.Itemtype = GetValue(text);
                }
                if (text.StartsWith("[") && text.EndsWith("]"))
                {
                    template.Face.Items.AddNormalItem(item);
                    return text;
                }
            }
            return "";
        }

        private string ReaderTemplateBg(StreamReader reader, ref Template template)
        {
            string text = "";
            while ((text = reader.ReadLine()) != null)
            {
                if (text.StartsWith("BgImage="))
                {
                    string imgUrl = GetValue(text);
                    template.Background.BgImage = new Bitmap(imgUrl);
                }
                if (text.StartsWith("ImageHeight="))
                {
                    template.Background.ImageHeight = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("ImageWidth="))
                {
                    template.Background.ImageWidth = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("[") && text.EndsWith("]"))
                {
                    return text;
                }
            }
            return null;
        }

        private string ReaderPrintSetting(StreamReader reader, ref Template template)
        {
            string text = "";
            PrintSetting prs = new PrintSetting();
            while ((text = reader.ReadLine()) != null)
            {
                if (text.StartsWith("PrintSettingId="))
                {
                    prs.PrintSettingId = Convert.ToInt32(GetValue(text));
                }
                if (text.StartsWith("PrintModule="))
                {
                    prs.PrintModule = GetValue(text);
                }
                if (text.StartsWith("SettingFile="))
                {
                    prs.SettingFile = GetValue(text);
                }
                if (text.StartsWith("[") && text.EndsWith("]"))
                {
                    template.PrintSetting = prs;
                    return text;
                }
            }
            template.PrintSetting = prs;
            return null;
        }

        private string GetValue(string text)
        {
            return text.Substring(text.LastIndexOf("="));
        }

        public void SaveTemplate(Template template) 
        {
        
        }
    }
}

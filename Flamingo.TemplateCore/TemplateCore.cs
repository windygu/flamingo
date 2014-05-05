using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DataManager;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Flamingo.TemplateCore
{
    public class TemplateCore
    {
        TemplateManager dataManager = new TemplateManager();

        public IList<Template> GetAllTemplate()
        {
            IList<Template> templates = new List<Template>();
            DataTable dt = dataManager.GetAllCommonTemplate();
            foreach (DataRow row in dt.Rows)
            {
                Template tempTemplate = new Template(-1);
                tempTemplate.Name = row["TemplateName"].ToString();
                tempTemplate.TemplateId = Convert.ToInt32(row["TemplateId"]);
                //byte[] imageString = (byte[])row["BgImage"];
                byte[] imageByte = dataManager.GetImageBytesById(tempTemplate.TemplateId);
                if (imageByte != null)
                {
                    MemoryStream ms = new MemoryStream(imageByte);
                    tempTemplate.Background.BgImage = Image.FromStream(ms, true);
                    if (row["bgWidth"] == null)
                    {
                        tempTemplate.Background.ImageWidth = tempTemplate.Background.BgImage.Width;
                    }
                    else
                    {
                        tempTemplate.Background.ImageWidth = Convert.ToInt32(row["bgWidth"]);
                    }
                    if (row["bgHeight"] == null)
                    {
                        tempTemplate.Background.ImageHeight = tempTemplate.Background.BgImage.Height;
                    }
                    else
                    {
                        tempTemplate.Background.ImageHeight = Convert.ToInt32(row["bgHeight"]);
                    }
                    DataTable dt2 = dataManager.GetTemplateItemById(tempTemplate.TemplateId);
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        TemplateFaceItem item = new TemplateFaceItem();
                        item.TemplateItemId = Convert.ToInt32(row2["TemplateItemId"]);
                        item.Name = row2["TemplateItemName"].ToString();
                        item.XAxis = Convert.ToInt32(row2["xAxis"]);
                        item.YAxis = Convert.ToInt32(row2["yAxis"]);
                        item.Description = row2["description"].ToString();
                        item.Itemtype = row2["dataItem"].ToString();
                        string rgb = row2["fontcolour"].ToString();
                        string[] rgbs = rgb.Split(new char[] { ' ' });
                        item.ItemColor = Color.FromArgb(Convert.ToInt32(rgbs[0]), Convert.ToInt32(rgbs[1]), Convert.ToInt32(rgbs[2]));
                        item.ItemFont = new Font(row2["font"].ToString(), Convert.ToInt32(row2["fontSize"]));
                        tempTemplate.Face.Items.AddNormalItem(item);
                    }
                    if (row["printSettingId"] != DBNull.Value)
                    {
                        int printSettingId = Convert.ToInt32(row["printSettingId"]);
                        DataTable pdt = dataManager.GetPrintSettingById(printSettingId);
                        if (pdt.Rows.Count != 0)
                        {
                            DataRow row1 = pdt.Rows[0];
                            PrintSetting ps = new PrintSetting();
                            ps.PrintSettingId = Convert.ToInt32(row1["printSettingId"]);
                            ps.PrintModule = row1["printModel"] == null ? "" : row1["printModel"].ToString();
                            ps.SettingFile = row1["settingfile"] == null ? "" : row1["settingfile"].ToString();
                            tempTemplate.PrintSetting = ps;
                        }
                    }
                    tempTemplate.Template_Type = TemplateTypeHelp.GetTemplateString(row["TemplateType"].ToString());
                }
                templates.Add(tempTemplate);
            }

            return templates;
        }

        public IList<Template> GetAllTemplateLocal()
        {
            return null;
        }

        public Template CreateNewTemplate()
        {
            Template temp = new Template(-1);
            return temp;
        }

        public int SaveTemplate(Template template)
        {
            int printsettingId = -1;
            if (template.PrintSetting != null)
            {
                printsettingId = dataManager.UpDatePrintSetting(template.PrintSetting.PrintSettingId, template.PrintSetting.PrintModule, template.PrintSetting.SettingFile);
            }
            template.TemplateId = dataManager.UpdateTemplate(template.Name, template.TemplateId, TemplateTypeHelp.GetTemplateString(template.Template_Type), ConvertImage(template.Background.BgImage), template.Background.ImageHeight, template.Background.ImageWidth, printsettingId);
            for (int i = 0; i < template.Face.Items.Count; i++)
            {
                TemplateFaceItem item = template.Face.Items[i];
                if (item.Status == TemplateItemStatus.New)
                {
                    dataManager.InsertTemplateItem(item.TemplateItemId, item.Name, item.Description, item.ItemFont, item.ItemColor,
                        item.XAxis, item.YAxis, item.Itemtype, template.TemplateId);
                }
                else if (item.Status == TemplateItemStatus.Edit)
                {
                    dataManager.UpdateTemplateItem(item.TemplateItemId, item.Name, item.Description, item.ItemFont, item.ItemColor,
                            item.XAxis, item.YAxis, item.Itemtype, template.TemplateId);
                }
                else if (item.Status == TemplateItemStatus.Delete)
                {
                    dataManager.DeleteTemplateItem(item.TemplateItemId);
                }
            }
            return template.TemplateId;
        }

        public void SaveTemplateLocal(Template template)
        {
            return;
        }

        public byte[] ConvertImage(Image image)
        {
            System.IO.MemoryStream Ms = new MemoryStream();
            image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] img = new byte[Ms.Length];
            Ms.Position = 0;
            Ms.Read(img, 0, Convert.ToInt32(Ms.Length));
            Ms.Close();
            return img;
        }

        public void DeleteTemplate(Template template)
        {
            dataManager.DeleteTemplate(template.TemplateId);
        }

        public void SaveCustomItems(string type, string name)
        {
            dataManager.SaveCustomItem(type, name);
        }

        public void DeleteCustomItem(string  type )
        {
            dataManager.DeleteCustomItemByTemplateId(type);
        }

        public IList<string> GetAllTemplateItemExt(string  type)
        {
            return dataManager.GetAllTemplateItemExt(type);
        }

        public string GetTheaterName() 
        {
            return dataManager.GetTheaterName();
        }
    }
}

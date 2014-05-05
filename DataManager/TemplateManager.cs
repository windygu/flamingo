using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace DataManager
{
    public class TemplateManager
    {
        string connectionString = "";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public DataTable GetAllCommonTemplate()
        {
            string newConnectionString = CommandString.ConnectionString;
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetAllCommonTemplate;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public byte[] GetImageBytesById(int templateId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                connection.Open();
                string commandString = CommandString.GetImageBytesById.Replace("(1)", templateId.ToString());
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                        {
                            return null;
                        }
                        return (byte[])dr[0];
                    }
                }
            }
            return null;
        }

        public int UpdateTemplate(string name, int templateId, string templatetype, byte[] image, int imageHeight, int imageWidth, int printSettingId)
        {
            string newConnectionString = CommandString.ConnectionString;
            if (templateId == -1)
            {
                templateId = GetNewTemplateId();
                InsertTemplate(name, templateId, templatetype, image, imageHeight, imageWidth, printSettingId);
            }
            else
            {
                EditTemplate(name, templateId, templatetype, image, imageHeight, imageWidth, printSettingId);
            }
            return templateId;
        }

        private void EditTemplate(string name, int templateId, string templatetype, byte[] image, int imageHeight, int imageWidth, int printSettingId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.EditTemplate;
                MySqlParameter templateIdParameter = new MySqlParameter("?TemplateId", MySqlDbType.Int32);
                templateIdParameter.Value = templateId;
                MySqlParameter nameParameter = new MySqlParameter("?TemplateName", MySqlDbType.VarChar);
                nameParameter.Value = name;
                MySqlParameter bgImageParameter = new MySqlParameter("?BgImage", MySqlDbType.MediumBlob);
                bgImageParameter.Value = image;
                MySqlParameter bgWidthParameter = new MySqlParameter("?bgWidth", MySqlDbType.Int32);
                bgWidthParameter.Value = imageWidth;
                MySqlParameter bgHeightParameter = new MySqlParameter("?bgHeight", MySqlDbType.Int32);
                bgHeightParameter.Value = imageHeight;
                //MySqlParameter createdParameter = new MySqlParameter("?Created", MySqlDbType.DateTime);
                //createdParameter.Value = DateTime.Now;
                MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                updatedParameter.Value = DateTime.Now;

                MySqlParameter printSettingIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.UInt32);
                if (printSettingId != -1)
                {
                    printSettingIdParameter.Value = printSettingId;
                }
                else
                {
                    printSettingIdParameter.Value = null;
                }
                MySqlParameter templateTypeParameter = new MySqlParameter("?templateType", MySqlDbType.VarChar);
                templateTypeParameter.Value = templatetype;

                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add(templateIdParameter);
                    cmd.Parameters.Add(nameParameter);
                    cmd.Parameters.Add(bgImageParameter);
                    cmd.Parameters.Add(bgWidthParameter);
                    cmd.Parameters.Add(bgHeightParameter);
                    //cmd.Parameters.Add(createdParameter);
                    cmd.Parameters.Add(updatedParameter);
                    cmd.Parameters.Add(printSettingIdParameter);
                    cmd.Parameters.Add(templateTypeParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertTemplate(string name, int templateId, string templatetype, byte[] image, int imageHeight, int imageWidth, int printSettingId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertTemplate;
                MySqlParameter templateIdParameter = new MySqlParameter("?TemplateId", MySqlDbType.Int32);
                templateIdParameter.Value = templateId;
                MySqlParameter nameParameter = new MySqlParameter("?TemplateName", MySqlDbType.VarChar);
                nameParameter.Value = name;
                MySqlParameter bgImageParameter = new MySqlParameter("?BgImage", MySqlDbType.MediumBlob);
                bgImageParameter.Value = image;
                MySqlParameter bgWidthParameter = new MySqlParameter("?bgWidth", MySqlDbType.Int32);
                bgWidthParameter.Value = imageWidth;
                MySqlParameter bgHeightParameter = new MySqlParameter("?bgHeight", MySqlDbType.Int32);
                bgHeightParameter.Value = imageHeight;
                MySqlParameter createdParameter = new MySqlParameter("?Created", MySqlDbType.DateTime);
                createdParameter.Value = DateTime.Now;
                MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                updatedParameter.Value = DateTime.Now;

                MySqlParameter printSettingIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.UInt32);
                if (printSettingId != -1)
                {
                    printSettingIdParameter.Value = printSettingId;
                }
                else
                {
                    printSettingIdParameter.Value = null;
                }
                MySqlParameter templateTypeParameter = new MySqlParameter("?templateType", MySqlDbType.VarChar);
                templateTypeParameter.Value = templatetype;

                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add(templateIdParameter);
                    cmd.Parameters.Add(nameParameter);
                    cmd.Parameters.Add(bgImageParameter);
                    cmd.Parameters.Add(bgWidthParameter);
                    cmd.Parameters.Add(bgHeightParameter);
                    cmd.Parameters.Add(createdParameter);
                    cmd.Parameters.Add(updatedParameter);
                    cmd.Parameters.Add(printSettingIdParameter);
                    cmd.Parameters.Add(templateTypeParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetNewTemplateId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetNewTemplateId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            return Convert.ToInt32(dr[0]) + 1;
                        }
                        catch
                        {
                            return 1;
                        }
                    }
                }
            }
            return 1;
        }

        public void InsertTemplateItem(int templateItemId, string name, string description, Font itemFont, Color itemColor, int xAxis, int yAxis,
            string itemtype, int templateId)
        {
            templateItemId = GetNextItemId();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertTemplateItem;
                MySqlParameter templateItemIdParameter = new MySqlParameter("?TemplateItemId", MySqlDbType.Int32);
                templateItemIdParameter.Value = templateItemId;
                MySqlParameter nameParameter = new MySqlParameter("?TemplateItemName", MySqlDbType.VarChar);
                nameParameter.Value = name;
                MySqlParameter xAxisParameter = new MySqlParameter("?xAxis", MySqlDbType.Int32);
                xAxisParameter.Value = xAxis;
                MySqlParameter yAxisParameter = new MySqlParameter("?yAxis", MySqlDbType.UInt32);
                yAxisParameter.Value = yAxis;
                MySqlParameter fontParameter = new MySqlParameter("?font", MySqlDbType.VarChar);
                fontParameter.Value = itemFont.FontFamily.Name.ToString();
                MySqlParameter fontSizeParameter = new MySqlParameter("?fontSize", MySqlDbType.Int32);
                fontSizeParameter.Value = itemFont.Size;
                MySqlParameter fontcolourParameter = new MySqlParameter("?fontcolour", MySqlDbType.VarChar);
                fontcolourParameter.Value = itemColor.R + " " + itemColor.G + " " + itemColor.B;
                MySqlParameter descriptionParameter = new MySqlParameter("?description", MySqlDbType.VarChar);
                descriptionParameter.Value = description;
                MySqlParameter dataItemParameter = new MySqlParameter("?dataItem", MySqlDbType.VarChar);
                dataItemParameter.Value = itemtype;
                MySqlParameter templateIdParameter = new MySqlParameter("?templateId", MySqlDbType.Int32);
                templateIdParameter.Value = templateId;
                MySqlParameter createdParameter = new MySqlParameter("?created", MySqlDbType.DateTime);
                createdParameter.Value = DateTime.Now;
                MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                updatedParameter.Value = DateTime.Now;


                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add(templateItemIdParameter);
                    cmd.Parameters.Add(nameParameter);
                    cmd.Parameters.Add(xAxisParameter);
                    cmd.Parameters.Add(yAxisParameter);
                    cmd.Parameters.Add(fontParameter);
                    cmd.Parameters.Add(fontSizeParameter);
                    cmd.Parameters.Add(fontcolourParameter);
                    cmd.Parameters.Add(descriptionParameter);
                    cmd.Parameters.Add(dataItemParameter);
                    cmd.Parameters.Add(templateIdParameter);
                    cmd.Parameters.Add(updatedParameter);
                    cmd.Parameters.Add(createdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetNextItemId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetNextItemId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            return Convert.ToInt32(dr[0]) + 1;
                        }
                        catch
                        {
                            return 1;
                        }
                    }
                }
            }
            return 1;
        }

        public void UpdateTemplateItem(int templateItemId, string name, string description, Font itemFont, Color itemColor, int xAxis, int yAxis, string itemtype, int templateId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.UpdateTemplateItem;
                MySqlParameter templateItemIdParameter = new MySqlParameter("?TemplateItemId", MySqlDbType.Int32);
                templateItemIdParameter.Value = templateItemId;
                MySqlParameter nameParameter = new MySqlParameter("?TemplateItemName", MySqlDbType.VarChar);
                nameParameter.Value = name;
                MySqlParameter xAxisParameter = new MySqlParameter("?xAxis", MySqlDbType.Int32);
                xAxisParameter.Value = xAxis;
                MySqlParameter yAxisParameter = new MySqlParameter("?yAxis", MySqlDbType.UInt32);
                yAxisParameter.Value = yAxis;
                MySqlParameter fontParameter = new MySqlParameter("?font", MySqlDbType.VarChar);
                fontParameter.Value = itemFont.FontFamily.Name.ToString();
                MySqlParameter fontSizeParameter = new MySqlParameter("?fontSize", MySqlDbType.UInt32);
                fontSizeParameter.Value = itemFont.Size;
                MySqlParameter fontcolourParameter = new MySqlParameter("?fontcolour", MySqlDbType.VarChar);
                fontcolourParameter.Value = itemColor.R + " " + itemColor.G + " " + itemColor.B;
                MySqlParameter descriptionParameter = new MySqlParameter("?description", MySqlDbType.VarChar);
                descriptionParameter.Value = description;
                MySqlParameter dataItemParameter = new MySqlParameter("?dataItem", MySqlDbType.VarChar);
                dataItemParameter.Value = itemtype;
                MySqlParameter templateIdParameter = new MySqlParameter("?templateId", MySqlDbType.UInt32);
                templateIdParameter.Value = templateId;
                //MySqlParameter createdParameter = new MySqlParameter("?created", MySqlDbType.DateTime);
                //createdParameter.Value = DateTime.Now;
                MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                updatedParameter.Value = DateTime.Now;
                MySqlParameter printSettingIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.UInt32);
                //if (printSettingId != -1)
                //{
                //    printSettingIdParameter.Value = templateId;
                //}
                //else 
                //{
                //    printSettingIdParameter.Value = null;
                //}
                //MySqlParameter templateTypeParameter = new MySqlParameter("?templateType", MySqlDbType.UInt32);
                //templateTypeParameter.Value = templateType;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add(templateItemIdParameter);
                    cmd.Parameters.Add(nameParameter);
                    cmd.Parameters.Add(xAxisParameter);
                    cmd.Parameters.Add(yAxisParameter);
                    cmd.Parameters.Add(fontParameter);
                    cmd.Parameters.Add(fontSizeParameter);
                    cmd.Parameters.Add(fontcolourParameter);
                    cmd.Parameters.Add(descriptionParameter);
                    cmd.Parameters.Add(dataItemParameter);
                    cmd.Parameters.Add(templateIdParameter);
                    cmd.Parameters.Add(updatedParameter);
                    //cmd.Parameters.Add(createdParameter);
                    //cmd.Parameters.Add(printSettingIdParameter);
                    //cmd.Parameters.Add(templateTypeParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTemplateItem(int templateItemId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteTemplateItem;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    MySqlParameter templateIdParameter = new MySqlParameter("?templateItemId", MySqlDbType.Int32);
                    templateIdParameter.Value = templateItemId;
                    cmd.Parameters.Add(templateIdParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetTemplateItemById(int templateId)
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetTemplateItemById;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    MySqlParameter templateIdParameter = new MySqlParameter("?templateId", MySqlDbType.Int32);
                    templateIdParameter.Value = templateId;
                    cmd.Parameters.Add(templateIdParameter);
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
            }
            return dt;
        }

        public void DeleteTemplate(int templateId)
        {
            DeleteTemplateItemByTemplateId(templateId);
            DeleteTemplateOnly(templateId);
        }

        private void DeleteTemplateItemByTemplateId(int templateId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteTemplateItemByTemplateId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    MySqlParameter templateIdParameter = new MySqlParameter("?TemplateId", MySqlDbType.Int32);
                    templateIdParameter.Value = templateId;
                    cmd.Parameters.Add(templateIdParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DeleteTemplateOnly(int templateId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteTemplateOnly;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    MySqlParameter templateIdParameter = new MySqlParameter("?TemplateId", MySqlDbType.Int32);
                    templateIdParameter.Value = templateId;
                    cmd.Parameters.Add(templateIdParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetPrintSettingById(int printSettingId)
        {
            string newConnectionString = CommandString.ConnectionString;
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                connection.Open();
                string commandString = CommandString.GetPrintSettingById;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    MySqlParameter printSettingIdIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.Int32);
                    printSettingIdIdParameter.Value = printSettingId;
                    cmd.Parameters.Add(printSettingIdIdParameter);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public int UpDatePrintSetting(int printId, string printModele, string settingfile)
        {
            if (printId == -1)
            {
                printId = GetNextPrintId();
                InsertPrintSetting(printId, printModele, settingfile);
            }
            else
            {
                EditPrintSetting(printId, printModele, settingfile);
            }
            return printId;
        }

        private void EditPrintSetting(int printId, string printModele, string settingfile)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.EditPrintSetting;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter printSettingIdIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.Int32);
                    printSettingIdIdParameter.Value = printId;
                    cmd.Parameters.Add(printSettingIdIdParameter);
                    MySqlParameter printModuleIdParameter = new MySqlParameter("?printModel", MySqlDbType.VarChar);
                    printModuleIdParameter.Value = printModele;
                    cmd.Parameters.Add(printModuleIdParameter);
                    MySqlParameter settingfileParameter = new MySqlParameter("?settingfile", MySqlDbType.Text);
                    settingfileParameter.Value = settingfile;
                    cmd.Parameters.Add(settingfileParameter);
                    //MySqlParameter createdParameter = new MySqlParameter("?created", MySqlDbType.DateTime);
                    //createdParameter.Value = DateTime.Now;
                    //cmd.Parameters.Add(createdParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertPrintSetting(int printId, string printModule, string settingfile)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertPrintSetting;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter printSettingIdIdParameter = new MySqlParameter("?printSettingId", MySqlDbType.Int32);
                    printSettingIdIdParameter.Value = printId;
                    cmd.Parameters.Add(printSettingIdIdParameter);
                    MySqlParameter printModuleIdParameter = new MySqlParameter("?printModel", MySqlDbType.VarChar);
                    printModuleIdParameter.Value = printModule;
                    cmd.Parameters.Add(printModuleIdParameter);
                    MySqlParameter settingfileParameter = new MySqlParameter("?settingfile", MySqlDbType.Text);
                    settingfileParameter.Value = settingfile;
                    cmd.Parameters.Add(settingfileParameter);
                    MySqlParameter createdParameter = new MySqlParameter("?created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetNextPrintId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetNextPrintId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            return Convert.ToInt32(dr[0]) + 1;
                        }
                        catch
                        {
                            return 1;
                        }
                    }
                }
            }
            return 1;
        }

        public void DeleteCustomItemByTemplateId(string type)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteCustomItemByTemplateId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter templateTypeParameter = new MySqlParameter("templateType", MySqlDbType.VarChar);
                    templateTypeParameter.Value = type;
                    cmd.Parameters.Add(templateTypeParameter);
                    //MySqlParameter commonItemNameParameter = new MySqlParameter("commonItemName", MySqlDbType.VarChar);
                    //commonItemNameParameter.Value = name;
                    //cmd.Parameters.Add(commonItemNameParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveCustomItem(string type, string name)
        {
            if (!ExsitTemplateExtItem(type, name))
            {
                InsertCustomItem(type, name);
            }
        }

        private void InsertCustomItem(string type, string name)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertCustomItem;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter templateTypeParameter = new MySqlParameter("templateType", MySqlDbType.VarChar);
                    templateTypeParameter.Value = type;
                    cmd.Parameters.Add(templateTypeParameter);
                    MySqlParameter commonItemNameParameter = new MySqlParameter("commonItemName", MySqlDbType.VarChar);
                    commonItemNameParameter.Value = name;
                    cmd.Parameters.Add(commonItemNameParameter);
                    MySqlParameter createdParameter = new MySqlParameter("?created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("?Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        bool ExsitTemplateExtItem(string type, string name)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.ExsitTemplateExtItem;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter templateTypeParameter = new MySqlParameter("templateType", MySqlDbType.VarChar);
                    templateTypeParameter.Value = type;
                    cmd.Parameters.Add(templateTypeParameter);
                    MySqlParameter commonItemNameParameter = new MySqlParameter("commonItemName", MySqlDbType.VarChar);
                    commonItemNameParameter.Value = name;
                    cmd.Parameters.Add(commonItemNameParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public IList<string> GetAllTemplateItemExt(string  type)
        {
            IList<string> names = new List<string>();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetAllTemplateItemExt;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter templateTypeParameter = new MySqlParameter("templateType", MySqlDbType.VarChar);
                    templateTypeParameter.Value = type;
                    cmd.Parameters.Add(templateTypeParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        names.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
            }
            return names;
        }

        public string GetTheaterName()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetTheaterName;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    object reader = cmd.ExecuteScalar();
                    return reader.ToString();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.TemplateCore;

namespace WinFormUI.TemplateUI
{
    public partial class TemplateItemSetting : Form
    {
        string itemtype = "";
        public TemplateItemSetting(TemplateSettingType type, TemplateFaceItem item)
        {
            InitializeComponent();
            this.type = type;

            font = fontTextBox.Font;
            color = fontTextBox.ForeColor;

            if (type == TemplateSettingType.View)
            {
                button1.Enabled = false;
                NameTextBox.Enabled = false;
                XTextBox.Enabled = false;
                YTextBox.Enabled = false;
                SettingButton.Enabled = false;
                SelectButton.Enabled = false;
                if (item != null)
                {
                    if (item.ItemFont != null)
                    {
                        this.font = item.ItemFont;
                    }
                    this.color = item.ItemColor;
                }
            }
            if (type == TemplateSettingType.Edit)
            {
                if (item != null)
                {
                    if (item.ItemFont != null)
                    {
                        this.font = item.ItemFont;
                    }
                    this.color = item.ItemColor;
                }
            }


            if (item != null)
            {
                //button1.Enabled = false;
                NameTextBox.Text = item.Name;
                DescTextBox.Text = item.Description;
                XTextBox.Text = item.XAxis.ToString();
                YTextBox.Text = item.YAxis.ToString();
            }
            fontTextBox.Text = font.Name + " " + font.Size;
            ColorTextBox.Text = color.ToString();
            fontLabel.Font = font;
            fontLabel.ForeColor = color;
            itemtype = item.Itemtype;
        }

        Font font = null;

        Color color;

        TemplateSettingType type;

        TemplateFaceItem item = null;

        public TemplateFaceItem Item
        {
            get { return item; }
            set { item = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fontDialog1.ShowDialog())
            {
                font = fontDialog1.Font;
                fontTextBox.Text = font.Name + " " + font.Size;
                fontLabel.Font = font;
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                color = colorDialog1.Color;
                ColorTextBox.Text = color.ToString();
                fontLabel.ForeColor = color;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("请输入票面项名称");
                return;
            }
            int x = 0;
            try
            {
                if (XTextBox.Text.Trim() != "")
                {
                    x = Convert.ToInt32(XTextBox.Text.Trim());
                }
            }
            catch
            {
                MessageBox.Show("横坐标填写不正确。");
            }
            int y = 0;
            try
            {
                if (YTextBox.Text.Trim() != "")
                {
                    y = Convert.ToInt32(YTextBox.Text.Trim());
                }
            }
            catch
            {
                MessageBox.Show("纵坐标填写不正确。");
            }
            if (item == null)
            {
                item = new TemplateFaceItem();
                item.Name = NameTextBox.Text.Trim();
                item.XAxis = x;
                item.YAxis = y;
                item.ItemFont = this.font;
                item.ItemColor = this.color;
                item.Description = this.DescTextBox.Text.Trim();
                item.Itemtype = itemtype;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}

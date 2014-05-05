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
    public partial class TemplateListForm : Form
    {
        TemplateCore temp = new Flamingo.TemplateCore.TemplateCore();

        public TemplateListForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            IList<Template> list = temp.GetAllTemplate();
            BindTemplateList(list);
        }

        private void BindTemplateList(IList<Template> list)
        {
            TemplateListView.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Template template = list[i];
                ListViewItem item = new ListViewItem(template.TemplateId.ToString());
                item.SubItems.Add(template.Name.ToString());
                item.SubItems.Add(TemplateTypeHelp.GetTemplateString(template.Template_Type));
                item.Tag = template;
                TemplateListView.Items.Add(item);
            }
        }

        private void TemplateListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem xy = TemplateListView.GetItemAt(e.X, e.Y);
                if (xy != null)
                {
                    NewToolStripMenuItem.Enabled = true;
                    EditToolStripMenuItem.Enabled = true;
                    DeleteToolStripMenuItem.Enabled = true;
                    ViewToolStripMenuItem1.Enabled = true;
                    Point point = this.PointToClient(TemplateListView.PointToScreen(new Point(e.X, e.Y)));
                    this.contextMenuStrip1.Show(this, point);
                }
                else 
                {
                    NewToolStripMenuItem.Enabled = true;
                    EditToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = false;
                    ViewToolStripMenuItem1.Enabled = false;
                    Point point = this.PointToClient(TemplateListView.PointToScreen(new Point(e.X, e.Y)));
                    this.contextMenuStrip1.Show(this, point);
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.New);
            form.ShowDialog();
            TemplateListView.Items.Clear();
            BindTemplateList(temp.GetAllTemplate());
        }

        private void ViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.View);
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                if (template != null)
                {
                    form.Template = template;
                    form.InitTemplate();
                }
                form.ShowDialog();
            }
            
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.Edit);
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                if (template != null)
                {
                    form.Template = template;
                    form.InitTemplate();
                }
                form.ShowDialog();
                TemplateListView.Items.Clear();
                BindTemplateList(temp.GetAllTemplate());
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                TemplateCore core = new TemplateCore();
                core.DeleteTemplate(template);
            }
            BindTemplateList(temp.GetAllTemplate());
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.View);
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                if (template != null)
                {
                    form.Template = template;
                    form.InitTemplate();
                }
                form.ShowDialog();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.New);
            form.ShowDialog();
            TemplateListView.Items.Clear();
            BindTemplateList(temp.GetAllTemplate());
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            TemplateSettingForm form = new TemplateSettingForm(TemplateSettingType.Edit);
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                if (template != null)
                {
                    form.Template = template;
                    form.InitTemplate();
                }
                form.ShowDialog();
                TemplateListView.Items.Clear();
                BindTemplateList(temp.GetAllTemplate());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (TemplateListView.SelectedItems.Count != 0)
            {
                Template template = TemplateListView.SelectedItems[0].Tag as Template;
                TemplateCore core = new TemplateCore();
                core.DeleteTemplate(template);
            }
            BindTemplateList(temp.GetAllTemplate());
        }

        private void TemplateListForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

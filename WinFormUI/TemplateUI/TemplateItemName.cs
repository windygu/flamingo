using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI.TemplateUI
{
    public partial class TemplateItemName : Form
    {
        public TemplateItemName()
        {
            InitializeComponent();
        }

        string name = "";

        public string Name1
        {
            get { return name; }
            set { name = value; }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            name = nameTb.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("请填写列表项名称。");
                return;
            }
            DialogResult = DialogResult.OK;
            Hide();
        }

        internal void InitFormName()
        {
            nameTb.Text = name;
        }
    }
}

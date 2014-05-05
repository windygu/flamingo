using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.Right;

namespace WinFormUI.RightUI
{
    public partial class RoleName : Form
    {
        public RoleName()
        {
            InitializeComponent();
        }

        string roleName = "";

        public string Role_Name
        {
            get { return roleName; }
            set { roleName = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") 
            {
                MessageBox.Show("请输入角色名称.。");
                return;
            }
            if (textBox1.Text.Trim() == "全部用户") 
            {
                MessageBox.Show("不允许添加全部用户权限");
                return;
            }
            roleName = textBox1.Text.Trim();
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}

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
    public partial class UserName : Form
    {
        public UserName()
        {
            InitializeComponent();
        }

        string roleName = "";

        public string User_Name
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
            roleName = textBox1.Text.Trim();
            if (Users.DefaultUsers.UserNameExsit(roleName))
            {
                MessageBox.Show("用户名已经存在，请重新输入。");
                return;
            }
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

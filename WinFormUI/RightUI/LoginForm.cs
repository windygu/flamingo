using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.Right;
using System.Security.Cryptography;

namespace WinFormUI.RightUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空。");
                return;
            }
            int i = Users.DefaultUsers.Valid(textBox1.Text.Trim(), GetMD5_32(textBox2.Text.Trim()));
            if (i == -1)
            {
                MessageBox.Show("用户名或密码错误.");
                return;
            }
            user = Users.DefaultUsers.GetUserbyUserId(i);
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        User user = null;

        public User User
        {
            get { return user; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        public string GetMD5_32(string s)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] t = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(s));

            StringBuilder sb = new StringBuilder(32);

            for (int i = 0; i < t.Length; i++)
            {

                sb.Append(t[i].ToString("x").PadLeft(2, '0'));

            }

            return sb.ToString();

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("用户名不能为空。");
                    return;
                }
                int i = Users.DefaultUsers.Valid(textBox1.Text.Trim(), GetMD5_32(textBox2.Text.Trim()));
                if (i == -1)
                {
                    MessageBox.Show("用户名或密码错误.");
                    return;
                }
                user = Users.DefaultUsers.GetUserbyUserId(i);
                DialogResult = DialogResult.OK;
                this.Hide();                
            }
        }

    }
}

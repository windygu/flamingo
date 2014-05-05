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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string userName = UserTextBox.Text.Trim();
            IList<User> users = Users.DefaultUsers.GetUsersByName(userName);
            if (users.Count == 0)
            {
                MessageBox.Show("未能按条件查找到记录.");
                return;
            }
            UserListView.Items.Clear();
            foreach (User user in users)
            {
                ListViewItem item = new ListViewItem(user.UserId.ToString());
                item.Tag = user;
                item.SubItems.Add(user.UserName);
                item.SubItems.Add(user.EmployeeId);
                item.SubItems.Add(user.Mobile);
                item.SubItems.Add(user.IsActive ? "否" : "是");
                UserListView.Items.Add(item);
            }
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserListView.SelectedItems.Count != 0) 
            {
                if (this.role != null) 
                {
                    User user = UserListView.SelectedItems[0].Tag as User;
                    if (user.HaveRole(role)) 
                    {
                        MessageBox.Show("角色中已经包含该角色");
                        return;
                    }
                    addedUser = user;
                    DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }
        }

        Role role = null;

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        User addedUser;

        public User AddedUser
        {
            get { return addedUser; }
           // set { user = value; }
        }
    }
}

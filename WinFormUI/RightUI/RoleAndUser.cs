using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo;
using Flamingo.Right;

namespace WinFormUI.RightUI
{
    public partial class RoleAndUser : Form
    {
        public RoleAndUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roleName = roleNameTextbox.Text.Trim();
            IList<Flamingo.Right.Role> roles = Roles.DefaultRoles.GetRoleByName(roleName, false);
            InitRoleListBox(roles);
        }

        private void InitRoleListBox(IList<Flamingo.Right.Role> roles)
        {
            RoleListBox.Items.Clear();
            foreach (Flamingo.Right.Role role in roles)
            {
                RoleListBox.Items.Add(new RoleObject(role));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IList<Flamingo.Right.Role> roles = Roles.DefaultRoles.GetAllRoles();
            InitRoleListBox(roles);
        }

        private void RoleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoleListBox.SelectedIndex != -1)
            {
                RoleObject o = RoleListBox.SelectedItem as RoleObject;
                //InitRight(o.Role, false);
                InitButton(o.Role);
            }
        }

        private void InitButton(Flamingo.Right.Role role)
        {
            IList<Flamingo.Right.User> users = Users.DefaultUsers.GetUsersByRoleId(role.RoleId);
            UserListView.Items.Clear();
            foreach (Flamingo.Right.User user in users)
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

        private void AddUser_Click(object sender, EventArgs e)
        {
            if (RoleListBox.SelectedIndex == -1) 
            {
                MessageBox.Show("请先选择一个角色！");
                return;
            }
            AddUser addUser = new AddUser();
            RoleObject o = RoleListBox.SelectedItem as RoleObject;
            addUser.Role = o.Role;
            if (DialogResult.OK == addUser.ShowDialog()) 
            {
                addUser.AddedUser.AddRole(o.Role);
                addUser.AddedUser.AddPermissionByAddRole(o.Role);
                Users.DefaultUsers.SaveUser(addUser.AddedUser, true, true);
                InitButton(o.Role);
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (UserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的用户！");
            }
            else
            {
                Flamingo.Right.User user = UserListView.SelectedItems[0].Tag as Flamingo.Right.User;
                RoleObject o = RoleListBox.SelectedItem as RoleObject;
                user.DeleteRole(o.Role);
                Users.DefaultUsers.SaveUser(user, false, true);
                Users.DefaultUsers.DeleteUserPermissionByRole(user,o.Role.RoleId);
                InitButton(o.Role);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class RoleObject
    {
        Flamingo.Right.Role role;

        public Flamingo.Right.Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public override string ToString()
        {
            //return base.ToString();
            return role.RoleName;
        }

        public RoleObject(Flamingo.Right.Role role)
        {
            this.role = role;
        }
    }
}

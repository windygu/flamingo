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
    public partial class UserRightSetting : Form
    {
        public UserRightSetting()
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
            RoleListBox.Items.Clear();
            panel3.Controls.Clear();
        }

        private void UserListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserListView.SelectedIndices.Count != 0)
            {
                User user = UserListView.SelectedItems[0].Tag as User;
                UserNameTextBox.Text = user.UserName;
                PhoneTextBox.Text = user.Mobile;
                EmpNoTextBox.Text = user.EmployeeId;
                EmpNameTextBox.Text = user.EmpName;
                checkBox1.Checked = user.IsActive;
                RoleListBox.Items.Clear();
                for (int i = 0; i < user.UserRoleCount; i++)
                {
                    RoleListBox.Items.Add(new RoleObj(user[i, "notUser"]));
                }

                #region added

                Role tempRole = user.GetAllPermissionAsTempRole();

                IList < Module > modules = tempRole.GetModule();

                int height1 = 15;

                panel3.Controls.Clear();

                foreach (Module module in modules)
                {
                    int height = 15;
                    int width = 15;
                    GroupBox gb = new GroupBox();
                    gb.Location = new Point(width, height1);
                    gb.Width = panel3.Width - 50;
                    gb.Name = module.Name;
                    IList<Permission> permissions = user.GetPermissionByModule(module, tempRole);
                    IList<Permission> permissions1 = tempRole.GetPermissionByModule(module);
                    foreach (Permission permission in permissions1)
                    {
                        CheckBox cb = new CheckBox();
                        cb.Text = permission.PermissionName;
                        cb.Tag = permission;
                        if (user.HavePermission(permission))
                        {
                            cb.Checked = true;
                            if (permissions.Contains(permission))
                            {
                                cb.Enabled = true;
                            }
                            else
                            {
                                cb.Enabled = false;
                            }
                        }

                        if (width + 110 < panel3.Width)
                        {
                            cb.Location = new Point(width, height);
                            width += 110;
                        }
                        else
                        {
                            height += 20;
                            width = 15;
                            cb.Location = new Point(width, height);
                            width += 110;
                        }
                        gb.Controls.Add(cb);
                    }
                    gb.Height = height + 30;
                    height1 = gb.Location.Y + gb.Height;
                    panel3.Controls.Add(gb);
                }

                #endregion
            }

        }

        private void AllUserBtn_Click(object sender, EventArgs e)
        {
            IList<User> users = Users.DefaultUsers.GetAllUser();
            if (users.Count == 0)
            {
                MessageBox.Show("未能查找到记录.");
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
            RoleListBox.Items.Clear();
            panel3.Controls.Clear();
        }

        class RoleObj
        {
            public RoleObj(Role role)
            {
                this.role = role;
            }

            Role role;

            public Role Role
            {
                get { return role; }
                set { role = value; }
            }

            public override string ToString()
            {
                if (role == null || role.RoleName == null)
                {
                    return "";
                }
                return role.RoleName;
                //return base.ToString();
            }
        }

        private void RoleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserListView.SelectedItems.Count == 0)
            {
                return;
            }
            User user = UserListView.SelectedItems[0].Tag as User;

            if (RoleListBox.SelectedIndex == -1)
            {
                return;
            }
            RoleObj roleObj = RoleListBox.SelectedItem as RoleObj;

            Role role = roleObj.Role;

            IList<Module> modules = role.GetModule();

            int height1 = 15;

            panel3.Controls.Clear();

            foreach (Module module in modules)
            {
                int height = 15;
                int width = 15;
                GroupBox gb = new GroupBox();
                gb.Location = new Point(width, height1);
                gb.Width = panel3.Width - 50;
                gb.Name = module.Name;
                IList<Permission> permissions = user.GetPermissionByModule(module, role);
                IList<Permission> permissions1 = role.GetPermissionByModule(module);
                foreach (Permission permission in permissions1)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = permission.PermissionName;
                    cb.Tag = permission;
                    if (user.HavePermission(permission))
                    {
                        cb.Checked = true;
                        if (permissions.Contains(permission))
                        {
                            cb.Enabled = true;
                        }
                        else
                        {
                            cb.Enabled = false;
                        }
                    }

                    if (width + 110 < panel3.Width)
                    {
                        cb.Location = new Point(width, height);
                        width += 110;
                    }
                    else
                    {
                        height += 20;
                        width = 15;
                        cb.Location = new Point(width, height);
                        width += 110;
                    }
                    gb.Controls.Add(cb);
                }
                gb.Height = height + 30;
                height1 = gb.Location.Y + gb.Height;
                panel3.Controls.Add(gb);
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if (UserListView.SelectedIndices.Count != 0)
            {
                User user = UserListView.SelectedItems[0].Tag as User;
                UserRoleSetting roleSetting = new UserRoleSetting(user);
                if (DialogResult.OK == roleSetting.ShowDialog())
                {
                    User user1 = roleSetting.User;
                    if (UserListView.SelectedIndices.Count != 0)
                    {
                        UserListView.SelectedItems[0].Tag = user1;
                        UserNameTextBox.Text = user1.UserName;
                        PhoneTextBox.Text = user1.Mobile;
                        EmpNoTextBox.Text = user1.EmployeeId;
                        checkBox1.Checked = user1.IsActive;
                        RoleListBox.Items.Clear();
                        for (int i = 0; i < user1.UserRoleCount; i++)
                        {
                            RoleListBox.Items.Add(new RoleObj(user1[i, "notUser"]));
                        }
                    }
                }
            }
        }

        private void SavePermissionBtn_Click(object sender, EventArgs e)
        {
            if (UserListView.SelectedItems.Count == 0)
            {
                return;
            }
            User user = UserListView.SelectedItems[0].Tag as User;

            if (RoleListBox.SelectedIndex == -1)
            {
                return;
            }
            RoleObj roleObj = RoleListBox.SelectedItem as RoleObj;

            Role role = roleObj.Role;

            foreach (Control control1 in panel3.Controls)
            {
                GroupBox group = control1 as GroupBox;
                foreach (Control control in group.Controls)
                {
                    CheckBox cb = control as CheckBox;
                    if (cb != null)
                    {
                        if (cb.Checked)
                        {
                            Permission permission = cb.Tag as Permission;
                            if (!user.HaveRolePermission(role, permission))
                            {
                                user.AddPermission(permission, role);
                            }
                        }
                        else 
                        {
                            Permission permission = cb.Tag as Permission;
                            if (user.HaveRolePermission(role, permission)) 
                            {
                                user.DeletePermission(permission);
                            }
                        }
                    }
                }
            }
            Users.DefaultUsers.SaveUser(user, true, true);
            MessageBox.Show("保存权限成功");
        }

        private void UserRightSetting_Load(object sender, EventArgs e)
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

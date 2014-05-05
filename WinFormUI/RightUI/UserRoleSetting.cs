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
    public partial class UserRoleSetting : Form
    {
        public UserRoleSetting(User User1)
        {
            InitializeComponent();
            this.user = User1;
            UserNameTextBox.Text = user.UserName;
            PhoneTextBox.Text = user.Mobile;
            EmpNoTextBox.Text = user.EmployeeId;
            checkBox1.Checked = user.IsActive;
            InitRoles();
        }

        User user = null;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public void InitRoles()
        {
            if (null == user)
            {
                return;
            }
            IList<Role> roles = Roles.DefaultRoles.GetAllRoles();
            int currentWidth = 25;
            int currentHeight = 0;
            foreach (Role role in roles)
            {
                CheckBox cb = new CheckBox();

                cb.Text = role.RoleName;
                cb.Tag = role;
                if (currentWidth + 110 < panel2.Width)
                {
                    cb.Location = new Point(currentWidth, currentHeight);
                    currentWidth += 110;
                }
                else
                {
                    currentHeight += 20;
                    currentWidth = 25;
                    cb.Location = new Point(currentWidth, currentHeight);
                    currentWidth += 110;
                }

                if (HaveRoleinList(role, user.GetAllRoles()))
                {
                    cb.Checked = true;
                }
                if (role.RoleName == "全部用户")
                {
                    cb.Checked = true;
                    cb.Enabled = false;
                }
                panel2.Controls.Add(cb);
            }
        }

        private bool HaveRoleinList(Role role, IList<Role> roles)
        {
            if (roles == null)
            {
                return false;
            }
            foreach (Role role1 in roles)
            {
                if (role1.Equals(role))
                {
                    return true;
                }
            }
            return false;
        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //IList<Role> roles = Roles.DefaultRoles.GetAllRoles();
            foreach (Control control in panel2.Controls)
            {
                CheckBox cb = control as CheckBox;
                if (cb != null)
                {
                    Role role = cb.Tag as Role;
                    if (cb.Checked == false )
                    {
                        for (int i = 0; i < user.UserRolePermissionCount; i++)
                        {
                            UserRolePermission rolePermission = new UserRolePermission();
                            rolePermission.Role = Roles.DefaultRoles.AllPermission;
                            rolePermission.Permission = user[i].Permission;
                            user[i] = rolePermission;
                            //rolePermission.Role = Roles.DefaultRoles.AllPermission;
                            user.DeleteRole(role);
                        }
                    }
                    else 
                    {
                        if (cb.Checked == true)
                        {
                            if (!user.HaveRole(role))
                            {
                                user.AddRole(role);
                            }
                        }
                    }
                }
            }
            Users.DefaultUsers.SaveUser(user, true, true);
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}

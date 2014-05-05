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
    public partial class RoleSetting : Form
    {
        public RoleSetting()
        {
            InitializeComponent();
            //ModulePermissions modulepermission = new ModulePermissions(Modules.Schedules, this.groupBox2.Width - 30,15);
            InitLeft();
            InitRight(Roles.DefaultRoles.AllPermission, false);
        }

        public void InitLeft()
        {
            //left
            listBox1.Items.Clear();
            IList<Role> roles = Roles.DefaultRoles.GetAllRoles();
            foreach (Role role in roles)
            {
                listBox1.Items.Add(new RoleObject(role));
            }
            //right

        }

        void InitRight(Role role1, bool eable)
        {
            panel1.Controls.Clear();
            int height = 15;
            //Role role1 = Roles.DefaultRoles.AllPermission;

            foreach (Module module in Modules.GetAllModules())
            {
                IList<Permission> permissions = new List<Permission>();
                for (int i = 0; i < role1.Permissions.Count; i++)
                {
                    permissions.Add(role1.Permissions[i]);
                }
                ModulePermissions modulepermission = new ModulePermissions(module, this.panel1.Width - 30, height, eable, permissions);
                height += modulepermission.Height + 15;
                panel1.Controls.Add(modulepermission);
            }
            Label templabel = new Label();
            templabel.Location = new Point(15, height);
            panel1.Controls.Add(templabel);
        }


        class RoleObject
        {
            Role role;

            public Role Role
            {
                get { return role; }
                set { role = value; }
            }

            public RoleObject(Role role)
            {
                this.role = role;
            }

            public override string ToString()
            {
                //return base.ToString();
                return role.RoleName;
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int listBoxItemToTalHeight = listBox1.Items.Count * listBox1.ItemHeight;
                int currentIndex = e.Y / 12;
                if (e.Y <= listBoxItemToTalHeight)
                {
                    DeleteToolStripMenuItem.Enabled = true;
                    if (listBox1.SelectedItem != null && currentIndex != listBox1.SelectedIndex)
                    {
                        this.listBox1.SetSelected(listBox1.SelectedIndex, false);            
                    }
                    this.listBox1.SetSelected(currentIndex, true);
                    RoleObject roleObj = listBox1.SelectedItem as RoleObject;
                    if (roleObj != null && roleObj.Role.RoleName == "全体员工")
                    {
                        DeleteToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    DeleteToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Role role = Roles.DefaultRoles.CreateNewRole("新角色");
            RoleName roleName = new RoleName();
            if (DialogResult.OK == roleName.ShowDialog())
            {
                Role role = Roles.DefaultRoles.CreateNewRole(roleName.Role_Name);
                Roles.DefaultRoles.SaveRole(role, false);
                InitLeft();
                RoleObject role1 = listBox1.Items[listBox1.Items.Count - 1] as RoleObject;
                Role role2 = null;
                if (role1 != null)
                {
                    role2 = role1.Role;
                }

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                InitRight(role2, true);
                OkBtn.Enabled = true;
                CancelBtn.Enabled = false;
            }
        }

        int selectId = -1;
        bool bianji = false;
        bool reset = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bianji)
            {
                if (listBox1.SelectedIndex == -1)
                {
                    return;
                }
                selectId = listBox1.SelectedIndex;

               

                RoleObject role1 = listBox1.Items[selectId] as RoleObject;
                Role role2 = null;
                DeleteBtn.Enabled = true;
                if (role1 != null)
                {
                    role2 = role1.Role;
                }
                if (reset)
                {
                    InitRight(role2, true);
                }
                else 
                {
                    InitRight(role2, false);
                }
                if (role2.RoleName == "全体员工")
                {
                    OkBtn.Enabled = false;
                    CancelBtn.Enabled = false;
                    DeleteBtn.Enabled = false;
                }
                if (reset)
                {
                    reset = false;
                }
                else
                {
                    CancelBtn.Enabled = true;
                    OkBtn.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("正处于编辑状态，请先保存。");
                bianji = false;
                reset = true;
                listBox1.SelectedIndex = selectId;
                bianji = true;

                return;
            }

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            RoleObject role1 = listBox1.Items[selectId] as RoleObject;
            Role role2 = null;
            if (role1 != null)
            {
                role2 = role1.Role;
            }
            role2.Permissions.Clear();
            GetAllPermission(role2);
            Roles.DefaultRoles.SaveRole(role2, true);

            InitRight(role2, false);
            bianji = false;
            CancelBtn.Enabled = true;
            OkBtn.Enabled = false;
        }

        private void GetAllPermission(Role role2)
        {
            foreach (Control control in panel1.Controls)
            {
                ModulePermissions setting = control as ModulePermissions;
                if (setting == null)
                {
                    continue;
                }
                IList<Permission> permissions = setting.GetAllPermissions();
                foreach (Permission per in permissions)
                {
                    role2.Permissions.AddPermission(per);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            bianji = true;
            CancelBtn.Enabled = false;
            OkBtn.Enabled = true;
            RoleObject role1 = listBox1.Items[selectId] as RoleObject;
            Role role2 = null;
            if (role1 != null)
            {
                role2 = role1.Role;
            }

            //listBox1.SelectedIndex = listBox1.Items.Count - 1;
            InitRight(role2, true);
        }

        private void DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            selectId = -1;
            //listBox1.SelectedIndex = -1;
            bianji = false;
            RoleObject role1 = listBox1.Items[listBox1.SelectedIndex] as RoleObject;
            Role role2 = null;
            if (role1 != null)
            {
                role2 = role1.Role;
            }
            Roles.DefaultRoles.DeleteRole(role2);
            InitLeft();
            CancelBtn.Enabled = false;
            OkBtn.Enabled = false;
        }

        private void RoleSetting_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Newbtn_Click(object sender, EventArgs e)
        {
            RoleName roleName = new RoleName();
            if (DialogResult.OK == roleName.ShowDialog())
            {
                Role role = Roles.DefaultRoles.CreateNewRole(roleName.Role_Name);
                Roles.DefaultRoles.SaveRole(role, false);
                InitLeft();
                RoleObject role1 = listBox1.Items[listBox1.Items.Count - 1] as RoleObject;
                Role role2 = null;
                if (role1 != null)
                {
                    role2 = role1.Role;
                }

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                InitRight(role2, true);
                OkBtn.Enabled = true;
                CancelBtn.Enabled = false;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            selectId = -1;
            //listBox1.SelectedIndex = -1;
            bianji = false;
            RoleObject role1 = listBox1.Items[listBox1.SelectedIndex] as RoleObject;
            Role role2 = null;
            if (role1 != null)
            {
                role2 = role1.Role;
            }
            Roles.DefaultRoles.DeleteRole(role2);
            InitLeft();
            CancelBtn.Enabled = false;
            OkBtn.Enabled = false;
        }
    }
}

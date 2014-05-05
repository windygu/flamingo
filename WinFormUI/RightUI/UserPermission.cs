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
    public partial class UserPermission : Form
    {
        bool forPersonal = false;

        public UserPermission()
        {
            InitializeComponent();
            InitListBox();
            InitBasciInfo(null, false);
            //InitBasicPermission(null, false);

            //InitPermissionTop(false, null, true);
            //InitPermissionBottum(false, null);
            //InitPermissionRight(false, null, null);
        }

        private void InitListBox()
        {
            IList<User> users = new List<User>();
            if (FrmMain.curUser.HavePermission(Permissions.BasicInformation))
            {
                users = Users.DefaultUsers.GetAllUser();
            }
            else 
            {
                users.Add(FrmMain.curUser);
                forPersonal = true;
            }
            foreach (User user in users)
            {
                UserObject userObj = new UserObject();
                userObj.User = user;
                listBox1.Items.Add(userObj);
            }
        }

        private void InitBasciInfo(User user, bool enable)
        {
            if (user == null)
            {
                UserTextBox.Enabled = false;
                EmpName.Enabled = false;
                OlderTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                PswTextBox.Enabled = false;
                //EmpTextBox.Enabled = false;
                SaveButton.Enabled = false;
                MobileTextBox.Enabled = false;
                EditButton.Enabled = false;
                checkBox1.Enabled = false;
                CancelBtn.Enabled = false;
            }
            else
            {
                UserTextBox.Enabled = enable;
                EmpName.Enabled = enable;
                PasswordTextBox.Enabled = enable;
                PswTextBox.Enabled = enable;
                //EmpTextBox.Enabled = enable;
                SaveButton.Enabled = enable;
                MobileTextBox.Enabled = enable;
                checkBox1.Enabled = enable;
                EditButton.Enabled = !enable;
                CancelBtn.Enabled = enable;
                if (user.UserName != "")
                {
                    UserTextBox.Text = user.UserName;
                }
                EmpName.Text = user.EmpName;
                //PasswordTextBox.Text = user.Password;
                //PswTextBox.Text = user.Password;
                EmpTextBox.Text = user.EmployeeId;
                MobileTextBox.Text = user.Mobile;
                checkBox1.Checked = user.IsActive;

            }
        }

        private void InitBasicPermission(User user, bool eable)
        {
            panel1.Controls.Clear();
            int height = 15;
            //Role role1 = Roles.DefaultRoles.AllPermission;

            foreach (Module module in Modules.GetAllModules())
            {
                IList<Permission> permissions = new List<Permission>();
                if (user != null)
                {
                    permissions = user.GetPermissionByModule(module);
                }
                ModulePermissions modulepermission = new ModulePermissions(module, this.panel1.Width - 30, height, eable, permissions);
                height += modulepermission.Height + 15;
                panel1.Controls.Add(modulepermission);
            }
            Label templabel = new Label();
            templabel.Location = new Point(15, height);
            panel1.Controls.Add(templabel);
        }

        private void InitPermissionTop(bool enable, IList<Role> ros, bool init)
        {
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
                cb.Enabled = enable;
                cb.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
                if (enable)
                {
                    EditRolePerButton.Enabled = false;
                    SaveRolePerButton.Enabled = true;
                }
                else
                {
                    EditRolePerButton.Enabled = true;
                    SaveRolePerButton.Enabled = false;
                }
                if (init)
                {
                    EditRolePerButton.Enabled = false;
                    SaveRolePerButton.Enabled = false;
                }
                if (HaveRoleinList(role, ros))
                {
                    cb.Checked = true;
                }

                panel2.Controls.Add(cb);
            }
        }

        private void InitPermissionBottum(bool enable, IList<Role> ros)
        {
            listBox2.Enabled = enable;
            if (ros == null)
            {
                return;
            }
            foreach (Role role in ros)
            {
                RoleObject roleObj = new RoleObject();
                roleObj.Role = role;
                listBox2.Items.Add(roleObj);
            }
        }

        private void InitPermissionRight(bool enable, Role role, User user)
        {
            if (user == null || role == null)
            {
                listBox2.Enabled = false;
                EditRoleButton.Enabled = false;
                SaveRoleButton.Enabled = false;
                return;
            }
            IList<Module> modules = role.GetModule();

            int height1 = 15;

            foreach (Module module in modules)
            {
                int height = 15;
                int width = 15;
                GroupBox gb = new GroupBox();
                gb.Location = new Point(width, height1);
                gb.Width = panel3.Width - 30;
                gb.Name = module.Name;
                IList<Permission> permissions = user.GetPermissionByModule(module, role);
                IList<Permission> permissions1 = role.GetPermissionByModule(module);
                foreach (Permission permission in permissions1)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = permission.PermissionName;
                    cb.Tag = permission;
                    if (permissions.Contains(permission))
                    {
                        cb.Checked = true;
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
                }
                else
                {
                    DeleteToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserName userName = new UserName();
            if (listBox1.SelectedIndex != -1)
            {
                UserObject user = listBox1.SelectedItem as UserObject;
                if (!user.Saved)
                {
                    MessageBox.Show("请先保存信息.");
                    return;
                }
            }
            if (userName.ShowDialog() == DialogResult.OK)
            {
                tabControl1.SelectedTab = tabPage3;
                User user = Users.DefaultUsers.CreateUser(userName.User_Name);
                UserObject userObj = new UserObject();
                userObj.User = user;
                userObj.Added = true;
                listBox1.Items.Add(userObj);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                InitBasciInfo(user, true);
                userObj.BBasic = false;
                //listBox1.Items[listBox1.Items.Count - 1] = userObj;
                IList<Role> ros = user.GetAllRoles();
                panel2.Controls.Clear();
                InitPermissionTop(true, ros, false);
                listBox2.Items.Clear();
                InitPermissionBottum(true, ros);
            }
        }

        class UserObject
        {
            User user;

            public User User
            {
                get { return user; }
                set { user = value; }
            }
            bool added = false;

            bool bBasic = true;

            public bool BBasic
            {
                get { return bBasic; }
                set { bBasic = value; }
            }

            bool bRole = true;

            public bool BRole
            {
                get { return bRole; }
                set { bRole = value; }
            }

            bool bPermission = true;

            public bool BPermission
            {
                get { return bPermission; }
                set { bPermission = value; }
            }

            public bool Added
            {
                get { return added; }
                set { added = value; }
            }

            public bool Saved
            {
                get
                {
                    return BBasic && BRole && BPermission;
                }
            }

            public override string ToString()
            {
                return user == null ? "" : (user.UserName == null ? "New" : user.UserName);
            }
        }

        class RoleObject
        {
            Role role;

            public Role Role
            {
                get { return role; }
                set { role = value; }
            }

            bool bPermission = true;

            public bool BPermission
            {
                get { return bPermission; }
                set { bPermission = value; }
            }

            public override string ToString()
            {
                //return base.ToString();
                if (role == null && role.RoleName == null)
                {
                    return "No Name.";
                }
                return role.RoleName;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UserObject userObj = listBox1.SelectedItem as UserObject;
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                Role role = cb.Tag as Role;
                RoleObject roleObj = new RoleObject();
                roleObj.Role = role;
                listBox2.Items.Add(roleObj);
                userObj.User.AddRole(role);
            }
            else
            {
                Role role = cb.Tag as Role;
                userObj.User.DeleteRole(role);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    RoleObject roleObj = listBox2.Items[i] as RoleObject;
                    if (roleObj.Role.Equals(role))
                    {
                        listBox2.Items.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        int selectId2 = -1;
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1 || listBox2.SelectedIndex == selectId2)
            {
                listBox2.SelectedIndex = selectId2;
                return;
            }
            if (selectId2 != -1)
            {
                RoleObject userObj1 = listBox2.Items[selectId2] as RoleObject;
                if (userObj1.BPermission == false)
                {
                    MessageBox.Show("请先保存信息。");
                    listBox2.SelectedIndex = selectId2;
                    return;
                }
            }
            if (listBox2.SelectedIndex != -1)
            {
                panel3.Controls.Clear();
                RoleObject roleObj = listBox2.SelectedItem as RoleObject;
                if (roleObj != null)
                {
                    Role role = roleObj.Role;
                    UserObject userObj = listBox1.SelectedItem as UserObject;
                    User user = userObj == null ? null : userObj.User;
                    InitPermissionRight(true, role, user);
                }
                EditRoleButton.Enabled = true;
                CheckBoxEnable(false);
                selectId2 = listBox2.SelectedIndex;
            }
        }

        int selectId = -1;
        //bool changing = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 || listBox1.SelectedIndex == selectId)
            {
                listBox1.SelectedIndex = selectId;
                return;
            }
            else
            {
                if (selectId != -1)
                {
                    UserObject userObj1 = listBox1.Items[selectId] as UserObject;
                    if (userObj1.Saved == false)
                    {
                        MessageBox.Show("请先保存信息。");
                        listBox1.SelectedIndex = selectId;
                        return;
                    }
                }
                if (OlderPassword.Visible == false)
                {
                    OlderPassword.Visible = true;
                    OlderTextBox.Visible = true;
                    MoveControls(false);
                }
                UserObject userObj = listBox1.SelectedItem as UserObject;

                selectId = listBox1.SelectedIndex;
                listBox2.Items.Clear();
                panel2.Controls.Clear();
                InitBasciInfo(userObj.User, !userObj.Saved);
                InitBasicPermission(userObj.User, false);
                InitPermissionTop(false, userObj.User.GetAllRoles(), false);
                listBox2.Enabled = true;
                EditRoleButton.Enabled = false;
                SaveRoleButton.Enabled = false;
                selectId2 = -1;
                listBox2.SelectedIndex = -1;

                if (userObj.User.IsAdmin == true)
                {
                    EditButton.Enabled = false;
                }
                if (forPersonal == true) 
                {
                    AddToolStripMenuItem.Enabled = false;
                    NewBtn.Enabled = false;
                    checkBox1.Enabled = false;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            User user = null;
            if (UserTextBox.Text.Trim() == "")
            {
                MessageBox.Show("输入的用户名错误，请重新输入。");
                return;
            }
            if (PswTextBox.Text.Trim() != PasswordTextBox.Text.Trim())
            {
                MessageBox.Show("输入的密码和确认密码不同，请重新输入。");
                return;
            }
            if (OlderTextBox.Visible == false)
            {
                if (Users.DefaultUsers.UserNameExsit(UserTextBox.Text.Trim()))
                {
                    MessageBox.Show("用户名已经存在，不能创建！");
                    return;
                }

                user = Users.DefaultUsers.CreateUser(UserTextBox.Text.Trim());
                user.UserName = UserTextBox.Text.Trim();
                user.EmpName = EmpName.Text.Trim();
                user.Password = GetMD5_32(PswTextBox.Text.Trim());
                user.Mobile = MobileTextBox.Text.Trim();
                user.IsActive = checkBox1.Checked;
                user.EmployeeId = EmpTextBox.Text.Trim();
            }
            else
            {
                UserObject userObj = listBox1.Items[listBox1.SelectedIndex] as UserObject;
                user = userObj.User;
                if (Users.DefaultUsers.HaveExsitUserName(UserTextBox.Text.Trim(), user.UserId))
                {
                    MessageBox.Show("用户名已经存在，不能修改！");
                    return;
                }
                if (!Users.DefaultUsers.ExistRightPassword(user.UserId, GetMD5_32(OlderTextBox.Text.Trim())))
                {
                    MessageBox.Show("旧密码不正确！");
                    return;
                }

                user.UserName = UserTextBox.Text.Trim();
                user.EmpName = EmpName.Text.Trim();
                user.Password = GetMD5_32(PswTextBox.Text.Trim());
                user.Mobile = MobileTextBox.Text.Trim();
                user.IsActive = checkBox1.Checked;
                user.EmployeeId = EmpTextBox.Text.Trim();
                userObj.BBasic = true;
            }
            Users.DefaultUsers.SaveUser(user, false, false);
            SaveButton.Enabled = false;
            EditButton.Enabled = false;
            CancelBtn.Enabled = false;
            UserTextBox.Enabled = false;
            EmpName.Enabled = false;
            OlderTextBox.Enabled = false;
            PasswordTextBox.Enabled = false;
            PswTextBox.Enabled = false;
            //EmpTextBox.Enabled = false;
            MobileTextBox.Enabled = false;
            checkBox1.Enabled = false;
            listBox1.Items.Clear();
            InitListBox();
            if (forPersonal == true)
            {
                AddToolStripMenuItem.Enabled = false;
                NewBtn.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UserObject userObj = listBox1.Items[listBox1.SelectedIndex] as UserObject;
            userObj.BBasic = false;
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            UserTextBox.Enabled = true;
            OlderTextBox.Enabled = true;
            EmpName.Enabled = true;
            PasswordTextBox.Enabled = true;
            PswTextBox.Enabled = true;
            //EmpTextBox.Enabled = true;
            MobileTextBox.Enabled = true;
            checkBox1.Enabled = true;
            CancelBtn.Enabled = true;
            if (forPersonal == true)
            {
                AddToolStripMenuItem.Enabled = false;
                NewBtn.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void EditRolePerButton_Click(object sender, EventArgs e)
        {
            UserObject userObj = listBox1.SelectedItem as UserObject;
            foreach (Control control in panel2.Controls)
            {
                control.Enabled = true;
            }
            EditRolePerButton.Enabled = false;
            SaveRolePerButton.Enabled = true;
            userObj.BRole = false;
        }

        private void SaveRolePerButton_Click(object sender, EventArgs e)
        {
            UserObject userObj = listBox1.SelectedItem as UserObject;
            foreach (Control control in panel2.Controls)
            {
                control.Enabled = false;
            }
            EditRolePerButton.Enabled = true;
            SaveRolePerButton.Enabled = false;
            userObj.BRole = true;
            Users.DefaultUsers.SaveUser(userObj.User, false, true);
        }

        private void EditRoleButton_Click(object sender, EventArgs e)
        {
            //listBox2.Enabled = true;
            CheckBoxEnable(true);
            EditRoleButton.Enabled = false;
            SaveRoleButton.Enabled = true;
            UserObject userObj = listBox1.SelectedItem as UserObject;
            userObj.BPermission = false;
            RoleObject roleObj = listBox2.SelectedItem as RoleObject;
            roleObj.BPermission = false;
        }

        private void CheckBoxEnable(bool p)
        {
            foreach (Control control in panel3.Controls)
            {
                GroupBox lb = control as GroupBox;
                if (lb != null)
                {
                    foreach (Control co in lb.Controls)
                    {
                        co.Enabled = p;
                    }
                }
            }

        }

        private void SaveRoleButton_Click(object sender, EventArgs e)
        {
            //listBox2.Enabled = false;
            CheckBoxEnable(false);
            EditRoleButton.Enabled = true;
            SaveRoleButton.Enabled = false;
            UserObject userObj = listBox1.SelectedItem as UserObject;
            userObj.BPermission = true;
            RoleObject roleObj = listBox2.SelectedItem as RoleObject;
            roleObj.BPermission = true;
            SavePermissions();
            //UserObject userObj = listBox1.SelectedItem as UserObject;
            Users.DefaultUsers.SaveUser(userObj.User, true, false);
            InitBasicPermission(userObj.User, false);
        }

        private void SavePermissions()
        {

            UserObject userObj = listBox1.SelectedItem as UserObject;

            RoleObject roleObj = listBox2.SelectedItem as RoleObject;
            userObj.User.DeletePermissionByRole(roleObj.Role);
            foreach (Control control in panel3.Controls)
            {
                GroupBox lb = control as GroupBox;
                if (lb != null)
                {
                    foreach (Control co in lb.Controls)
                    {
                        CheckBox cb = co as CheckBox;
                        if (cb != null && cb.Checked)
                        {
                            Permission per = cb.Tag as Permission;
                            userObj.User.AddPermission(per, roleObj.Role);
                        }
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectId = -1;
            UserObject userObj = listBox1.SelectedItem as UserObject;
            Users.DefaultUsers.DeleteUser(userObj.User);
            listBox1.Items.Clear();
            InitListBox();
            InitBasciInfo(null, false);
        }

        private void UserPermission_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            //userObj.BBasic = false;
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            NewBtn.Enabled = false;
            CancelBtn.Enabled = true;
            OlderTextBox.Visible = false;
            OlderPassword.Visible = false;

            UserTextBox.Enabled = true;
            UserTextBox.Text = "";
            EmpName.Enabled = true;
            EmpName.Text = "";
            PasswordTextBox.Enabled = true;
            PasswordTextBox.Text = "";
            PswTextBox.Enabled = true;
            PswTextBox.Text = "";
            //EmpTextBox.Enabled = true;
            EmpTextBox.Text = "";
            MobileTextBox.Enabled = true;
            MobileTextBox.Text = "";
            checkBox1.Enabled = true;
            PasswordTextBox.Text = "123456";
            PswTextBox.Text = "123456";
            string text = Users.DefaultUsers.GetEmpId();
            int textInt = Convert.ToInt32(text);
            textInt++;
            text = textInt.ToString();
            if (text.Length == 1)
            {
                text = "000" + textInt;
            }
            if (text.Length == 2)
            {
                text = "00" + textInt;
            }
            if (text.Length == 3)
            {
                text = "0" + textInt;
            }
            EmpTextBox.Text = text;
            MoveControls(true);
        }

        void MoveControls(bool up)
        {
            if (up)
            {
                MoveControl(label2, -35);
                MoveControl(label3, -35);
                MoveControl(label4, -35);
                MoveControl(label5, -35);
                MoveControl(label6, -35);
                MoveControl(label7, -35);
                MoveControl(PasswordTextBox, -35);
                MoveControl(PswTextBox, -35);
                MoveControl(EmpName, -35);
                MoveControl(EmpTextBox, -35);
                MoveControl(MobileTextBox, -35);
                MoveControl(checkBox1, -35);
            }
            else
            {
                MoveControl(label2, 35);
                MoveControl(label3, 35);
                MoveControl(label4, 35);
                MoveControl(label5, 35);
                MoveControl(label6, 35);
                MoveControl(label7, 35);
                MoveControl(PasswordTextBox, 35);
                MoveControl(PswTextBox, 35);
                MoveControl(EmpName, 35);
                MoveControl(EmpTextBox, 35);
                MoveControl(MobileTextBox, 35);
                MoveControl(checkBox1, 35);
            }
        }

        void MoveControl(Control control, int i)
        {
            control.Location = new Point(control.Location.X, control.Location.Y + i);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            InitBasciInfo(null, false);
            if (selectId != -1)
            {
                UserObject userObj1 = listBox1.Items[selectId] as UserObject;
                if (userObj1 != null)
                {
                    InitBasciInfo(userObj1.User, false);
                    userObj1.BBasic = true;
                    EmpTextBox.Text = userObj1.User.EmployeeId;
                }
            }
            if (OlderTextBox.Visible == false)
            {
                OlderPassword.Visible = true;
                OlderTextBox.Visible = true;
                MoveControls(false);
            }
            PasswordTextBox.Text = "";
            PswTextBox.Text = "";

            NewBtn.Enabled = true;
            if (forPersonal == true)
            {
                AddToolStripMenuItem.Enabled = false;
                NewBtn.Enabled = false;
                checkBox1.Enabled = false;
            }
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
    }
}

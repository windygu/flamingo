using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.Right;

namespace WinFormUI.RightUI
{
    public partial class ModulePermissions : UserControl
    {
        public ModulePermissions(Module module, int groupWidth, int height, bool eable, IList<Permission> checkd)
        {
            InitializeComponent();
            InitForm(module, groupWidth, height, eable, checkd);
        }

        private void InitForm(Module module, int groupWidth, int height, bool eable, IList<Permission> checkd)
        {
            this.Location = new Point(15, height);
            this.Width = groupWidth;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            int currentWidth = 15;
            int currentHeight = 25;
            groupBox1.Text = module.Name;

            CheckBox cbAll = new CheckBox();
            cbAll.Enabled = eable;
            cbAll.CheckedChanged += checkBox1_CheckedChanged;
            if (currentWidth + 150 < groupWidth)
            {
                cbAll.Location = new Point(currentWidth, currentHeight);
                currentWidth += 150;
            }
            else
            {
                currentHeight += 25;
                currentWidth = 15;
                cbAll.Location = new Point(currentWidth, currentHeight);
                currentWidth += 150;
            }
            cbAll.Text = "全选";
            cbAll.Tag = Permissions.Null;

            groupBox1.Controls.Add(cbAll);

            bool bSelectAll = true;
            foreach (Permission permission in (Permissions.GetPermissionByModules(module)))
            {
                CheckBox cb = new CheckBox();
                cb.Enabled = eable;
                if (currentWidth + 150 < groupWidth)
                {
                    cb.Location = new Point(currentWidth, currentHeight);
                    currentWidth += 150;
                }
                else
                {
                    currentHeight += 25;
                    currentWidth = 15;
                    cb.Location = new Point(currentWidth, currentHeight);
                    currentWidth += 150;
                }
                cb.Text = permission.PermissionName;
                cb.Tag = permission;
                if (IsinChecked(permission, checkd))
                {
                    cb.Checked = true;
                    if (cb.Enabled == false)
                    {
                        cb.BackColor = Color.White;
                    }
                }
                else 
                {
                    bSelectAll = false;
                }
                cb.CheckedChanged += checkBox1_CheckedChanged;
                groupBox1.Controls.Add(cb);
            }
            cbAll.Checked = bSelectAll;
            this.Height = currentHeight + 30;
        }

        private bool IsinChecked(Permission permission, IList<Permission> checkd)
        {
            if (checkd == null)
            {
                return false;
            }
            foreach (Permission p in checkd)
            {
                if (p.Equals(permission))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null)
            {
                return;
            }
            Permission p = cb.Tag as Permission;
            if (p.PermissionId == -1)
            {
                foreach (Control control in groupBox1.Controls)
                {
                    Permission p2 = control.Tag as Permission;
                    CheckBox cb2 = control as CheckBox;
                    cb2.CheckedChanged -= checkBox1_CheckedChanged;
                    cb2.Checked = cb.Checked;
                    cb2.CheckedChanged += checkBox1_CheckedChanged;
                }
                return;
            }

            if (cb.Checked)
            {
                if (p.ParentPermissionId == -1)
                {
                    return;
                }
                foreach (Control control in groupBox1.Controls)
                {
                    Permission p2 = control.Tag as Permission;
                    if (p.ParentPermissionId == p2.PermissionId)
                    {
                        CheckBox cb2 = control as CheckBox;
                        cb2.Checked = true;
                    }
                }
               
            }
            else
            {
                foreach (Control control in groupBox1.Controls)
                {
                    Permission p2 = control.Tag as Permission;
                    if (p.PermissionId == p2.ParentPermissionId)
                    {
                        CheckBox cb2 = control as CheckBox;
                        cb2.Checked = false;
                    }
                }
            }
            CheckBox control3 = null;
            bool bSelectAll = true;
            foreach (Control control in groupBox1.Controls)
            {
                Permission p3 = control.Tag as Permission;
                if (p3.PermissionId == -1)
                {
                    control3= control as CheckBox;
                }
                CheckBox cb2 = control as CheckBox;
                if (cb2.Checked == false&&p3.PermissionId!=-1) 
                {
                    bSelectAll = false;
                    break;
                }
            }
            control3.CheckedChanged -= checkBox1_CheckedChanged;
            control3.Checked = bSelectAll;
            control3.CheckedChanged += checkBox1_CheckedChanged;
        }

        public IList<Permission> GetAllPermissions()
        {
            IList<Permission> permissions = new List<Permission>();
            foreach (Control control in groupBox1.Controls)
            {
                Permission p2 = control.Tag as Permission;
                CheckBox cb2 = control as CheckBox;
                if (p2.PermissionId != -1)
                {
                    if (cb2.Checked)
                    {
                        permissions.Add(p2);
                    }
                }
            }
            return permissions;
        }
    }
}

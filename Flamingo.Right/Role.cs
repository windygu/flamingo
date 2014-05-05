using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class Role
    {
        int roleId;

        public int RoleId
        {
            get { return roleId; }
            internal set { roleId = value; }
        }

        string roleName;

        public string RoleName
        {
            get { return roleName; }
            internal set { roleName = value; }
        }

        private bool defaultRole = false;

        public bool DefaultRole
        {
            get { return defaultRole; }
            internal set { defaultRole = value; }
        }

        RolePermissionCollection permissions = new RolePermissionCollection();

        public RolePermissionCollection Permissions
        {
            get { return permissions; }
        }

        public override bool Equals(object obj)
        {
            Role role = obj as Role;
            if (role.RoleId == RoleId && role.RoleName == RoleName)
            {
                return true;
            }
            return false;
        }

        public IList<Permission> GetPermissionByModule(Module module)
        {
            IList<Permission> pers = new List<Permission>();
            for (int i = 0; i < permissions.Count; i++) 
            {
                if (permissions[i].Module.Equals(module)) 
                {
                    pers.Add(permissions[i]);
                }
            }
            return pers;
        }

        public IList<Module> GetModule() 
        {
            IList<Module> modules = new List<Module>();
            for (int i = 0; i < permissions.Count; i++) 
            {
                Permission per = permissions[i];
                if (!modules.Contains(per.Module)) 
                {
                    modules.Add(per.Module);
                }
            }
            return modules;
        }
    }
}

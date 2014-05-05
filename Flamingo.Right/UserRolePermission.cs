using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class UserRolePermission
    {
        Permission permission;

        public Permission Permission
        {
            get { return permission; }
            set { permission = value; }
        }
        Role role;

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}

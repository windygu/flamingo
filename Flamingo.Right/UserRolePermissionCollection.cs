using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class UserRolePermissionCollection
    {
        IList<UserRolePermission> permissions = new List<UserRolePermission>();

        public bool HavePermission(Permission permission)
        {
            foreach (UserRolePermission rolePermission in permissions)
            {
                if (rolePermission.Permission.Equals(permission))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HavePermission(UserRolePermission permission)
        {
            return HavePermission(permission.Permission);
        }

        public void AddRolePermission(UserRolePermission permission)
        {
            if (HavePermission(permission))
            {
                return;
            }
            permissions.Add(permission);
        }

        public void AddPermission(Permission permission)
        {
            UserRolePermission rolePermission = new UserRolePermission();
            rolePermission.Permission = permission;
            rolePermission.Role = Roles.DefaultRoles.AllPermission;
            AddRolePermission(rolePermission);
        }

        public void DeletePermission(Permission permission)
        {
            for (int i = 0; i < permissions.Count; i++)
            {
                if (permissions[i].Permission.Equals(permission))
                {
                    permissions.RemoveAt(i);
                    return;
                }
            }
        }

        public int Count
        {
            get { return permissions.Count; }
        }

        public UserRolePermission this[int i]
        {
            get
            {
                return permissions[i];
            }
            internal set
            {
                permissions[i] = value;
            }
        }

        public RolePermissionCollection GetPermissionsByRole(Role role)
        {
            RolePermissionCollection rolePermissions = new RolePermissionCollection();
            for (int i = 0; i < permissions.Count; i++)
            {
                UserRolePermission rolePermission = permissions[i];
                if (rolePermission.Role.Equals(role))
                {
                    rolePermissions.AddPermission(rolePermission.Permission);
                }
            }
            return rolePermissions;
        }

        public void DeleteByRole(Role role)
        {
            for (int i = 0; i < permissions.Count; )
            {
                UserRolePermission userRolePermission = permissions[i];
                if (userRolePermission.Role.Equals(role))
                {
                    permissions.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        internal bool HaveRolePermission(Role role)
        {
            foreach (UserRolePermission rolePermission in permissions)
            {
                if (rolePermission.Role.Equals(role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManager;
using System.Data;

namespace Flamingo.Right
{
    public class Roles
    {
        public static Roles DefaultRoles
        {
            get { return new Roles(); }
        }

        RightManager manager = new RightManager();

        public Role GetRoleByRoleId(int roleId)
        {
            Role role = new Role();
            string roleName = this.manager.GetRoleName(roleId);
            role.RoleId = roleId;
            if (roleName != null)
            {
                role.RoleName = roleName;
            }
            IList<int> permissionIds = manager.GetPermissionIdsByRoleId(roleId);
            foreach (int id in permissionIds)
            {
                Permission permission = Permissions.GetPermissionById(id);
                if (permission != Permissions.Null)
                {
                    role.Permissions.AddPermission(permission);
                }
            }
            if (roleId == RoleIds.AllPermissionId) 
            {
                role.DefaultRole = true;
            }
            return role;
        }

        public void SaveRole(Role role, bool savePermission)
        {
            int roleId=manager.SaveRole(role.RoleId, role.RoleName);
            if (savePermission == true)
            {
                manager.DeleteRolePermissionByRoleId(role.RoleId);
                for (int i = 0; i < role.Permissions.Count; i++)
                {
                    manager.SaveRolePermission(roleId, role.Permissions[i].PermissionId);
                }
            }
        }

        public void DeleteRole(Role role)
        {
            manager.DeleteRole(role.RoleId);
        }

        public Role CreateNewRole(string roleName)
        {
            Role role = new Role();
            role.RoleId = -1;
            role.RoleName = roleName;
            return role;
        }

        public Role AllPermission
        {
            get
            {
                Role role = GetRoleByRoleId(RoleIds.AllPermissionId);
                return role;
            }
        }

        public IList<Role> GetAllRoles() 
        {
            IList<int> roleIds = manager.GetRoleIds();
            IList<Role> roles = new List<Role>();
            foreach (int i in roleIds) 
            {
                Role role = GetRoleByRoleId(i);
                roles.Add(role);
            }
            return roles;
        }

        public IList<Role> GetRoleByName(string roleName, bool match)
        {
            IList<int> roleIds = manager.GetRoleIds(roleName,match);
            IList<Role> roles = new List<Role>();
            foreach (int i in roleIds)
            {
                Role role = GetRoleByRoleId(i);
                roles.Add(role);
            }
            return roles;
        }
    }

    public class RoleIds 
    {
        public const int AllPermissionId = 1;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class User
    {
        int userId;

        public int UserId
        {
            get { return userId; }
            internal set { userId = value; }
        }

        string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        string empName;

        public string EmpName 
        {
            get { return empName; }
            set { empName = value; }   
        }

        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        string emploteeId;

        public string EmployeeId
        {
            get { return emploteeId; }
            set { emploteeId = value; }
        }

        string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        bool isActive = true;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        bool isAdmin = false;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        UserRolePermissionCollection userRolePermissions = new UserRolePermissionCollection();

        UserRoleCollection userRoles = new UserRoleCollection();

        public void AddPermissionByAddRole(Role role)
        {
            if (!userRoles.HaveRole(role))
            {
                userRoles.AddRole(role);
            }
            for (int i = 0; i < role.Permissions.Count; i++)
            {
                Permission permission = role.Permissions[i];
                if (!userRolePermissions.HavePermission(permission))
                {
                    UserRolePermission rolePermission = new UserRolePermission();
                    rolePermission.Role = role;
                    rolePermission.Permission = permission;
                    userRolePermissions.AddRolePermission(rolePermission);
                }
            }
        }

        public void AddPermission(Permission permission, Role role)
        {
            if (role.Permissions.HavePermission(permission))
            {
                UserRolePermission userRolePermission = new UserRolePermission();
                userRolePermission.Permission = permission;
                userRolePermission.Role = role;
                //if (!userRoles.HaveRole(role))
                //{
                //    userRoles.AddRole(role);
                //}
                userRolePermissions.AddRolePermission(userRolePermission);
            }
        }

        public void AddPermission(Permission permission)
        {
            AddPermission(permission, Roles.DefaultRoles.AllPermission);
        }

        public RolePermissionCollection GetUnHavePermissionByRole(Role role)
        {
            RolePermissionCollection hadRolePermissions = userRolePermissions.GetPermissionsByRole(role);
            RolePermissionCollection unHadRolePermissions = new RolePermissionCollection();
            for (int i = 0; i < role.Permissions.Count; i++)
            {
                Permission permission = role.Permissions[i];
                if (!hadRolePermissions.HavePermission(permission))
                {
                    unHadRolePermissions.AddPermission(permission);
                }
            }
            return unHadRolePermissions;
        }

        public RolePermissionCollection GetHavePermissionByRole(Role role)
        {
            return userRolePermissions.GetPermissionsByRole(role);
        }

        public IList<Permission> GetPermissionByModule(Module module)
        {
            IList<Permission> permissions = new List<Permission>();
            for (int i = 0; i < userRolePermissions.Count; i++)
            {
                if (userRolePermissions[i].Permission.Module.Equals(module))
                {
                    permissions.Add(userRolePermissions[i].Permission);
                }
            }
            return permissions;
        }

        public IList<Role> GetAllRoles()
        {
            IList<Role> roles = new List<Role>();
            for (int i = 0; i < userRoles.Count; i++)
            {
                Role role = userRoles[i];
                roles.Add(role);
            }
            return roles;
        }

        public void DeleteRole(Role role)
        {
            userRoles.DeleteRole(role);
            userRolePermissions.DeleteByRole(role);
        }

        public void DeletePermission(Permission permission)
        {
            userRolePermissions.DeletePermission(permission);
        }

        public void AddRole(Role role)
        {
            userRoles.AddRole(role);
        }

        public int UserRolePermissionCount
        {
            get
            {
                return userRolePermissions.Count;
            }
        }

        public int UserRoleCount
        {
            get
            {
                return userRoles.Count;
            }
        }

        public UserRolePermission this[int i]
        {
            get
            {
                return userRolePermissions[i];
            }
            set
            {
                userRolePermissions[i] = value;
            }
        }

        public Role this[int i, string notUse]
        {
            get
            {
                return userRoles[i];
            }
        }

        public IList<Module> GetModules(Role role)
        {
            IList<Module> modules = new List<Module>();
            for (int i = 0; i < userRolePermissions.Count; i++)
            {
                UserRolePermission rolePermission = userRolePermissions[i];
                if (rolePermission.Role.Equals(role))
                {
                    if (!modules.Contains(rolePermission.Permission.Module))
                    {
                        modules.Add(rolePermission.Permission.Module);
                    }
                }
            }
            return modules;
        }

        public IList<Permission> GetPermissionByModule(Module module, Role role)
        {
            IList<Permission> permissions = new List<Permission>();
            for (int i = 0; i < userRolePermissions.Count; i++)
            {
                if (userRolePermissions[i].Permission.Module.Equals(module) && userRolePermissions[i].Role.Equals(role))
                {
                    permissions.Add(userRolePermissions[i].Permission);
                }
            }
            return permissions;
        }

        public void DeletePermissionByRole(Role role)
        {
            userRolePermissions.DeleteByRole(role);
        }

        public bool HavePermission(Permission permission)
        {
            return userRolePermissions.HavePermission(permission);
        }

        public bool HaveRolePermission(Role role)
        {
            return userRolePermissions.HaveRolePermission(role);
        }

        public bool HaveRole(Role role)
        {
            return userRoles.HaveRole(role);
        }

        public bool HaveRolePermission(Role role, Permission permission)
        {
            UserRolePermission rolePermission = new UserRolePermission();
            rolePermission.Permission = permission;
            rolePermission.Role = role;
            return userRolePermissions.HavePermission(rolePermission);
        }

        public Role GetAllPermissionAsTempRole()
        {
            Role tempRole = new Role();
            for (int i = 0; i < UserRolePermissionCount; i++) 
            {
                tempRole.Permissions.AddPermission(userRolePermissions[i].Permission);
            }
            return tempRole;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManager;
using System.Data;

namespace Flamingo.Right
{
    public class Users
    {
        RightManager manager = new RightManager();
        int UserAdminId = 1;
        public User CreateUser(string userName)
        {
            User user = new User();
            user.UserId = -1;
            user.UserName = userName;
            user.Password = "";
            user.Mobile = "";
            user.EmployeeId = "";
            return user;
        }


        public IList<User> GetAllUserBasicInfo()
        {
            IList<User> users = new List<User>();
            DataTable userTable = manager.GetAllUserBasicInfo();
            foreach (DataRow row in userTable.Rows)
            {
                DateTime dt1 = DateTime.Now;
                User user = new User();
                user.UserId = Convert.ToInt32(row["UserId"]);
                user.UserName = row["UserName"] == null ? "" : row["UserName"].ToString();
                user.EmpName = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
                user.Password = row["Password"] == null ? "" : row["Password"].ToString();
                user.Mobile = row["Mobile"] == null ? "" : row["Mobile"].ToString();
                user.EmployeeId = row["EmployeeId"] == null ? "" : row["EmployeeId"].ToString();
                if (user.UserId == UserAdminId)
                {
                    user.IsAdmin = true;
                }
                //user.IsAdmin = row["IsAdmin"] == null ? false : (row["IsAdmin"].ToString() == "1" ? true : false);
                user.IsActive = row["IsActive"] == null ? false : (row["IsActive"].ToString() == "0" ? false : true);
                IList<int> roleIds = manager.GetAllRolesIdByUserID(user.UserId);
                users.Add(user);
            }
            return users;
        }

        public IList<User> GetAllUser()
        {
            IList<User> users = new List<User>();
            DataTable userTable = manager.GetAllUserBasicInfo();
            foreach (DataRow row in userTable.Rows)
            {
                User user = new User();
                user.UserId = Convert.ToInt32(row["UserId"]);
                user.UserName = row["UserName"] == null ? "" : row["UserName"].ToString();
                user.EmpName = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
                user.Password = row["Password"] == null ? "" : row["Password"].ToString();
                user.Mobile = row["Mobile"] == null ? "" : row["Mobile"].ToString();
                user.EmployeeId = row["EmployeeId"] == null ? "" : row["EmployeeId"].ToString();
                if (user.UserId == UserAdminId)
                {
                    user.IsAdmin = true;
                }
                //user.IsAdmin = row["IsAdmin"] == null ? false : (row["IsAdmin"].ToString() == "1" ? true : false);
                user.IsActive = row["IsActive"] == null ? false : (row["IsActive"].ToString() == "0" ? false : true);
                IList<int> roleIds = manager.GetAllRolesIdByUserID(user.UserId);

                foreach (int roleID in roleIds)
                {
                    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleID);
                    user.AddRole(role);
                }
                DataTable userRolePermissions = manager.GetAllRolePermissionsByUserId(user.UserId);
                foreach (DataRow row1 in userRolePermissions.Rows)
                {
                    int roleId = Convert.ToInt32(row1["roleId"]);
                    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleId);
                    int permissionId = Convert.ToInt32(row1["permissionId"]);
                    Permission permission = Permissions.GetPermissionById(permissionId);
                    user.AddPermission(permission, role);
                }
                users.Add(user);
            }
            return users;
        }

        public User SaveUser(User user, bool rolePermission, bool bRole)
        {
            int userId = manager.SaveUserBasicInfo(user.UserId, user.UserName, user.EmpName, user.Password, user.Mobile, user.EmployeeId, user.IsActive);
            user.UserId = userId;
            if (bRole)
            {
                manager.DeleteUserRoleByRoleId(userId);
                for (int i = 0; i < user.UserRoleCount; i++)
                {
                    Role role = user[i, "notUse"];
                    manager.SaveUserRole(userId, role.RoleId);
                }
            }
            if (rolePermission)
            {
                for (int i = 0; i < user.UserRoleCount; i++)
                {
                    Role userRolePermission = user[i, "notUser"];
                    manager.DeleteUserRolePermissionByUserRoleId(userId, userRolePermission.RoleId);
                }

                for (int i = 0; i < user.UserRolePermissionCount; i++)
                {
                    UserRolePermission userRolePermission = user[i];

                    manager.SaveUserRolePermission(user.UserId, userRolePermission.Permission.PermissionId,
                            userRolePermission.Role.RoleId);
                }
            }
            return user;
        }

        public void DeleteUser(User user)
        {
            manager.DeleteUserRoleByUserId(user.UserId);
            manager.DeleteUserPermissionByUserId(user.UserId);
            manager.DeleteUserByUserId(user.UserId);
        }

        public bool UserNameExsit(string userName)
        {
            return manager.UserNameExsit(userName);
        }

        public static Users DefaultUsers
        {
            get
            {
                return new Users();
            }
        }

        public int Valid(string userName, string password)
        {
            return manager.Valid(userName, password);
        }

        public User GetUserbyUserId(int i)
        {
            DataTable userTable = manager.UserBasicInfoByUserId(i);
            if (userTable.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = userTable.Rows[0];
            User user = new User();
            user.UserId = Convert.ToInt32(row["UserId"]);
            user.UserName = row["UserName"] == null ? "" : row["UserName"].ToString();
            user.EmpName = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
            user.Password = row["Password"] == null ? "" : row["Password"].ToString();
            user.Mobile = row["Mobile"] == null ? "" : row["Mobile"].ToString();
            user.EmployeeId = row["EmployeeId"] == null ? "" : row["EmployeeId"].ToString();
            if (user.UserId == UserAdminId)
            {
                user.IsAdmin = true;
            }
            user.IsActive = row["IsActive"] == null ? false : (row["IsActive"].ToString() == "0" ? false : true);
            IList<int> roleIds = manager.GetAllRolesIdByUserID(user.UserId);
            foreach (int roleID in roleIds)
            {
                Role role = Roles.DefaultRoles.GetRoleByRoleId(roleID);
                user.AddRole(role);
            }
            DataTable userRolePermissions = manager.GetAllRolePermissionsByUserId(user.UserId);
            foreach (DataRow row1 in userRolePermissions.Rows)
            {
                int roleId = Convert.ToInt32(row1["roleId"]);
                Role role = Roles.DefaultRoles.GetRoleByRoleId(roleId);
                int permissionId = Convert.ToInt32(row1["permissionId"]);
                Permission permission = Permissions.GetPermissionById(permissionId);
                user.AddPermission(permission, role);
            }
            return user;
        }

        public IList<User> GetUsersByName(string userName)
        {
            List<User> users = new List<User>();
            DataTable userTable = manager.GetUsersByName(userName);
            foreach (DataRow row in userTable.Rows)
            {
                User user = new User();
                user.UserId = Convert.ToInt32(row["UserId"]);
                user.UserName = row["UserName"] == null ? "" : row["UserName"].ToString();
                user.EmpName = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
                user.Password = row["Password"] == null ? "" : row["Password"].ToString();
                user.Mobile = row["Mobile"] == null ? "" : row["Mobile"].ToString();
                user.EmployeeId = row["EmployeeId"] == null ? "" : row["EmployeeId"].ToString();
                if (user.UserId == UserAdminId)
                {
                    user.IsAdmin = true;
                }
                user.IsActive = row["IsActive"] == null ? false : (row["IsActive"].ToString() == "0" ? false : true);
                //IList<int> roleIds = manager.GetAllRolesIdByUserID(user.UserId);
                //foreach (int roleID in roleIds)
                //{
                //    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleID);
                //    user.AddRole(role);
                //}
                //DataTable userRolePermissions = manager.GetAllRolePermissionsByUserId(user.UserId);
                //foreach (DataRow row1 in userRolePermissions.Rows)
                //{
                //    int roleId = Convert.ToInt32(row1["roleId"]);
                //    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleId);
                //    int permissionId = Convert.ToInt32(row1["permissionId"]);
                //    Permission permission = Permissions.GetPermissionById(permissionId);
                //    user.AddPermission(permission, role);
                //}
                users.Add(user);
            }
            return users;
        }

        public bool HaveExsitUserName(string userName, int userId)
        {
            return manager.HaveExsitUserName(userId, userName);
        }

        public bool ExistRightPassword(int userId, string password)
        {
            return manager.ExistRightPassword(userId, password);
        }

        public IList<User> GetUsersByRoleId(int roleId)
        {
            List<User> users = new List<User>();
            DataTable userTable = manager.GetUsersByRoleId(roleId);
            foreach (DataRow row in userTable.Rows)
            {
                User user = new User();
                user.UserId = Convert.ToInt32(row["UserId"]);
                user.UserName = row["UserName"] == null ? "" : row["UserName"].ToString();
                user.EmpName = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
                user.Password = row["Password"] == null ? "" : row["Password"].ToString();
                user.Mobile = row["Mobile"] == null ? "" : row["Mobile"].ToString();
                user.EmployeeId = row["EmployeeId"] == null ? "" : row["EmployeeId"].ToString();
                if (user.UserId == UserAdminId)
                {
                    user.IsAdmin = true;
                }
                user.IsActive = row["IsActive"] == null ? false : (row["IsActive"].ToString() == "0" ? false : true);
                //IList<int> roleIds = manager.GetAllRolesIdByUserID(user.UserId);
                //foreach (int roleID in roleIds)
                //{
                //    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleID);
                //    user.AddRole(role);
                //}
                //DataTable userRolePermissions = manager.GetAllRolePermissionsByUserId(user.UserId);
                //foreach (DataRow row1 in userRolePermissions.Rows)
                //{
                //    int roleId1 = Convert.ToInt32(row1["roleId"]);
                //    Role role = Roles.DefaultRoles.GetRoleByRoleId(roleId1);
                //    int permissionId = Convert.ToInt32(row1["permissionId"]);
                //    Permission permission = Permissions.GetPermissionById(permissionId);
                //    user.AddPermission(permission, role);
                //}
                users.Add(user);
            }
            return users;
        }

        public void DeleteUserPermissionByRole(User user, int roleId)
        {
            manager.DeleteUserPermissionByRole(user.UserId, roleId);
        }

        public string GetEmpId()
        {
            return manager.GetEmpId();
        }
    }
}

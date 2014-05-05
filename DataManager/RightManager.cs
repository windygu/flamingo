using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataManager
{
    public class RightManager
    {
        public IList<int> GetPermissionIdsByRoleId(int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            IList<int> ids = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetPermissionIdsByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                        {
                            if (reader[0].ToString() != "")
                            {
                                int i = Convert.ToInt32(reader[0]);
                                ids.Add(i);
                            }
                        }
                    }
                    reader.Close();
                }
            }
            return ids;
        }

        public string GetRoleName(int roleId)
        {
            string roleName = "";
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = "set names utf8;" + CommandString.GetRoleNameByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                        {
                            roleName = reader[0].ToString();
                        }
                    }
                    reader.Close();
                }
            }
            return roleName;
        }

        public int SaveRole(int roleID, string roleName)
        {
            if (roleID == -1)
            {
                roleID = GetNewRoleId();
                InsertRole(roleID, roleName);
            }
            else
            {
                UpdateRole(roleID, roleName);
            }
            return roleID;
        }

        private void InsertRole(int roleID, string roleName)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertRole;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleID;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter roleNameParameter = new MySqlParameter("roleName", MySqlDbType.VarChar);
                    roleNameParameter.Value = roleName;
                    cmd.Parameters.Add(roleNameParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter createdParameter = new MySqlParameter("Created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetNewRoleId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetNewRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            return Convert.ToInt32(dr[0]) + 1;
                        }
                        catch
                        {
                            return 1;
                        }
                    }
                }
            }
            return 1;
        }

        private void UpdateRole(int roleID, string roleName)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.UpdateRole;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleID;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter roleNameParameter = new MySqlParameter("roleName", MySqlDbType.VarChar);
                    roleNameParameter.Value = roleName;
                    cmd.Parameters.Add(roleNameParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveRolePermission(int roleId, int perminssionId)
        {
            if (!HaveRolePermission(roleId, perminssionId))
            {
                InsertRolePermission(roleId, perminssionId);
            }
        }

        private void InsertRolePermission(int roleId, int perminssionId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertRolePermission;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter permissionParameter = new MySqlParameter("permissionId", MySqlDbType.Int32);
                    permissionParameter.Value = perminssionId;
                    cmd.Parameters.Add(permissionParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter createdParameter = new MySqlParameter("Created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool HaveRolePermission(int roleId, int perminssionId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.HaveRolePermission;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter permissionParameter = new MySqlParameter("permissionId", MySqlDbType.Int32);
                    permissionParameter.Value = perminssionId;
                    cmd.Parameters.Add(permissionParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public void DeleteRole(int roleId)
        {
            DeleteRoleByRoleId(roleId);
            DeleteRolePermissionByRoleId(roleId);
        }

        public void DeleteRolePermissionByRoleId(int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteRolePermissionByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoleByRoleId(int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteRoleByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public System.Data.DataTable GetAllUserBasicInfo()
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetAllUserBasicInfo;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public IList<int> GetAllRolesIdByUserID(int userId)
        {
            IList<int> userIds = new List<int>();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetAllRolesIdByUserID;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    roleIdParameter.Value = userId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0]);
                        userIds.Add(id);
                    }
                    reader.Close();
                }
            }
            return userIds;
        }

        public System.Data.DataTable GetAllRolePermissionsByUserId(int userId)
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetAllRolePermissionsByUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("userId", MySqlDbType.VarString);
                    roleIdParameter.Value = userId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public int SaveUserBasicInfo(int userId, string name, string employeeName, string password, string mobile, string employeeId, bool isActive)
        {
            if (userId == -1)
            {
                userId = GetUserId();
                if (userId == -1)
                {
                    userId = 1;
                }
                userId = Convert.ToInt32(userId) + 1;

                InsertUserBasicInfo(userId, name, employeeName, password, mobile, employeeId, isActive);
            }
            else
            {
                UpdateUserBasicInfo(userId, name, employeeName, password, mobile, employeeId, isActive);
            }
            return userId;
        }

        private void UpdateUserBasicInfo(int userId, string name, string employeeName, string password, string mobile, string employeeId, bool isActive)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.UpdateUserBasicInfo;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter userNameParameter = new MySqlParameter("userName", MySqlDbType.VarChar);
                    userNameParameter.Value = name;
                    cmd.Parameters.Add(userNameParameter);
                    MySqlParameter employeeNameParameter = new MySqlParameter("employeeName", MySqlDbType.VarChar);
                    employeeNameParameter.Value = employeeName;
                    cmd.Parameters.Add(employeeNameParameter);
                    MySqlParameter passwordParameter = new MySqlParameter("password", MySqlDbType.VarChar);
                    passwordParameter.Value = password;
                    cmd.Parameters.Add(passwordParameter);
                    MySqlParameter employeeIdParameter = new MySqlParameter("employeeId", MySqlDbType.VarChar);
                    employeeIdParameter.Value = employeeId;
                    cmd.Parameters.Add(employeeIdParameter);
                    MySqlParameter mobileParameter = new MySqlParameter("mobile", MySqlDbType.VarChar);
                    mobileParameter.Value = mobile;
                    cmd.Parameters.Add(mobileParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter isActiveParameter = new MySqlParameter("isActive", MySqlDbType.VarChar);
                    if (isActive)
                    {
                        isActiveParameter.Value = '1';
                    }
                    else
                    {
                        isActiveParameter.Value = '0';
                    }
                    cmd.Parameters.Add(isActiveParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertUserBasicInfo(int userId, string name, string employeeName, string password, string mobile, string employeeId, bool isActive)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertUserBasicInfo;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter userNameParameter = new MySqlParameter("userName", MySqlDbType.VarChar);
                    userNameParameter.Value = name;
                    cmd.Parameters.Add(userNameParameter);
                    MySqlParameter employeeNameParameter = new MySqlParameter("employeeName", MySqlDbType.VarChar);
                    employeeNameParameter.Value = employeeName;
                    cmd.Parameters.Add(employeeNameParameter);
                    MySqlParameter passwordParameter = new MySqlParameter("password", MySqlDbType.VarChar);
                    passwordParameter.Value = password;
                    cmd.Parameters.Add(passwordParameter);
                    MySqlParameter employeeIdParameter = new MySqlParameter("employeeId", MySqlDbType.VarChar);
                    employeeIdParameter.Value = employeeId;
                    cmd.Parameters.Add(employeeIdParameter);
                    MySqlParameter mobileParameter = new MySqlParameter("mobile", MySqlDbType.VarChar);
                    mobileParameter.Value = mobile;
                    cmd.Parameters.Add(mobileParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter createdParameter = new MySqlParameter("Created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    MySqlParameter isActiveParameter = new MySqlParameter("isActive", MySqlDbType.VarChar);
                    if (isActive)
                    {
                        isActiveParameter.Value = '1';
                    }
                    else
                    {
                        isActiveParameter.Value = '0';
                    }
                    cmd.Parameters.Add(isActiveParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetUserId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            return Convert.ToInt32(dr[0]);
                        }
                        catch
                        {
                            return -1;
                        }
                    }
                }
            }
            return -1;
        }

        public void SaveUserRolePermission(int userId, int permissionId, int roleId)
        {
            if (!HaveUserRolePermission(userId, permissionId, roleId))
            {
                InsertUserRolePermission(userId, permissionId, roleId);
            }
        }

        private void InsertUserRolePermission(int userId, int permissionId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertUserRolePermission;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter permissionIdParameter = new MySqlParameter("permissionId", MySqlDbType.Int32);
                    permissionIdParameter.Value = permissionId;
                    cmd.Parameters.Add(permissionIdParameter);
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter createdParameter = new MySqlParameter("Created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool HaveUserRolePermission(int userId, int permissionId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.HaveUserRolePermission;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter permissionIdParameter = new MySqlParameter("permissionId", MySqlDbType.Int32);
                    permissionIdParameter.Value = permissionId;
                    cmd.Parameters.Add(permissionIdParameter);
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public IList<int> GetRoleIds()
        {
            string newConnectionString = CommandString.ConnectionString;
            IList<int> ids = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetRoleIds;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                        {
                            if (reader[0].ToString() != "")
                            {
                                int i = Convert.ToInt32(reader[0]);
                                ids.Add(i);
                            }
                        }
                    }
                    reader.Close();
                }
            }
            return ids;
        }

        public void SaveUserRole(int userId, int roleId)
        {
            if (!HaveUserRole(userId, roleId))
            {
                InsertUserRole(userId, roleId);
            }
        }

        private void InsertUserRole(int userId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.InsertUserRole;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter updatedParameter = new MySqlParameter("Updated", MySqlDbType.DateTime);
                    updatedParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(updatedParameter);
                    MySqlParameter createdParameter = new MySqlParameter("Created", MySqlDbType.DateTime);
                    createdParameter.Value = DateTime.Now;
                    cmd.Parameters.Add(createdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool HaveUserRole(int userId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.HaveUserRole;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public void DeleteUserRoleByRoleId(int userId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserRoleByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUserRolePermissionByUserRoleId(int userId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserRolePermissionByUserRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool UserNameExsit(string userName)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.UserNameExsit;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userNameParameter = new MySqlParameter("userName", MySqlDbType.VarChar);
                    userNameParameter.Value = userName;
                    cmd.Parameters.Add(userNameParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public int Valid(string userName, string password)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.Valid;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userNameParameter = new MySqlParameter("userName", MySqlDbType.VarChar);
                    userNameParameter.Value = userName;
                    cmd.Parameters.Add(userNameParameter);
                    MySqlParameter passwordParameter = new MySqlParameter("password", MySqlDbType.VarChar);
                    passwordParameter.Value = password;
                    cmd.Parameters.Add(passwordParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int i = Convert.ToInt32(reader[0]);
                        reader.Close();
                        return i;
                    }
                    reader.Close();
                }
            }
            return -1;
        }

        public DataTable UserBasicInfoByUserId(int i)
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.UserBasicInfoByUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = i;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetUsersByName(string userName)
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetUsersByName.Replace("(1)", "%" + userName + "%");
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public void DeleteUserByUserId(int userId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserByUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUserRoleByUserId(int userId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserRoleByUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUserPermissionByUserId(int userId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserPermissionByUserId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool HaveExsitUserName(int userId, string password)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.HaveExsitUserName;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter userNameParameter = new MySqlParameter("userName", MySqlDbType.VarChar);
                    userNameParameter.Value = password;
                    cmd.Parameters.Add(userNameParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public bool ExistRightPassword(int userId, string password)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.ExistRightPassword;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter passwordParameter = new MySqlParameter("password", MySqlDbType.VarChar);
                    passwordParameter.Value = password;
                    cmd.Parameters.Add(passwordParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        public IList<int> GetRoleIds(string roleName, bool match)
        {
            IList<int> ids = new List<int>();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = "";
                if (match)
                {
                    commandString = CommandString.GetRoleIdsMatchTrue;
                }
                else 
                {
                    commandString = CommandString.GetRoleIdsMatchFalse;
                }
                commandString=commandString.Replace("?roleName", roleName);
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    //MySqlParameter roleNameParameter = new MySqlParameter("roleName", MySqlDbType.Int32);
                    //roleNameParameter.Value = roleName;
                    //cmd.Parameters.Add(roleNameParameter);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ids.Add(Convert.ToInt32(reader[0]));
                    }
                    reader.Close();
                }
            }
            return ids;
        }

        public DataTable GetUsersByRoleId(int roleId)
        {
            DataTable dt = new DataTable();
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetUsersByRoleId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public void DeleteUserPermissionByRole(int userId, int roleId)
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.DeleteUserPermissionByRole;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlParameter userIdParameter = new MySqlParameter("userId", MySqlDbType.Int32);
                    userIdParameter.Value = userId;
                    cmd.Parameters.Add(userIdParameter);
                    MySqlParameter roleIdParameter = new MySqlParameter("roleId", MySqlDbType.Int32);
                    roleIdParameter.Value = roleId;
                    cmd.Parameters.Add(roleIdParameter);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetEmpId()
        {
            string newConnectionString = CommandString.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(newConnectionString))
            {
                string commandString = CommandString.GetEmpId;
                using (MySqlCommand cmd = new MySqlCommand(commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader[0].ToString();
                    }
                }
            }
            return "0001";
        }
    }
}

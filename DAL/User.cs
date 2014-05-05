using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    /// <summary>
    /// 数据访问类:User 用户表
    /// </summary>
    public partial class User
    {
        public User()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user");
            strSql.Append(" where UserId=@UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserId", MySqlDbType.VarChar,16)};
            parameters[0].Value = UserId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user limit 0,100 ");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("@UserId", MySqlDbType.VarChar,16)};
            //parameters[0].Value = UserId;

            //return DbHelperMySQL.Query(strSql.ToString()).Tables[0];

            return DbHelperMySQL.RunProcedure("proc_User_GetList", null, "User_GetList").Tables[0];
        }

        /// <summary>
        /// 获得影院信息
        /// </summary>
        /// <returns></returns>
        public static string GetTheater()
        {
            return DbHelperMySQL.RunProcedure("proc_theater_sel", null, "theater_sel").Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 获得影厅
        /// </summary>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static DataTable GetHall(string theaterid)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8)};
            parameters[0].Value = theaterid;
            return DbHelperMySQL.RunProcedure("proc_hall_sel", parameters, "hall_sel").Tables[0];
        }
        
        #endregion  Method
    }
}

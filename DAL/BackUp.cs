using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    public class BackUp
    {
        /// <summary>
        /// 获得备份设置信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBackUpSetting()
        {
            DataTable dt = DbHelperMySQL.RunProcedure("proc_backupsetting_sel", null, "backupsetting_sel").Tables[0];
            return dt;
        }

        /// <summary>
        /// 编辑备份设置信息
        /// </summary>
        /// <param name="BackupSettingId"></param>
        /// <param name="BackupTime"></param>
        /// <param name="RepeatDay"></param>
        /// <param name="DatabasePath"></param>
        /// <param name="BackupPath"></param>
        public static void EditBackUpSetting(int BackupSettingId,string BackupTime,int RepeatDay,string DatabasePath,string BackupPath)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_BackupSettingId", MySqlDbType.Int32,4),
					new MySqlParameter("@_BackupTime", MySqlDbType.VarChar,8),
					new MySqlParameter("@_RepeatDay", MySqlDbType.Int32,4),
					new MySqlParameter("@_DatabasePath", MySqlDbType.VarChar,255),
					new MySqlParameter("@_BackupPath", MySqlDbType.VarChar,255)};
            parameters[0].Value = BackupSettingId;
            parameters[1].Value = BackupTime;
            parameters[2].Value = RepeatDay;
            parameters[3].Value = DatabasePath;
            parameters[4].Value = BackupPath;
            DbHelperMySQL.RunProcedure("proc_backupsetting_edit", parameters, "backupsetting_edit");
        }

        /// <summary>
        /// 添加立即备份动作
        /// </summary>
        /// <param name="userid"></param>
        public static int AddServerDirection(int userid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_UserId", MySqlDbType.Int32,4),
                     new MySqlParameter("@_ServerDirectionId",MySqlDbType.Int32,4)};
            parameters[0].Value = userid;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_serverdirection_add", parameters, "serverdirection_add");
            return Int32.Parse(parameters[1].Value.ToString());
        }

        /// <summary>
        /// 获得服务器动作结果
        /// </summary>
        /// <param name="serverdirectionid"></param>
        /// <returns></returns>
        public static int GetServerDirectionResult(int serverdirectionid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ServerDirectionId", MySqlDbType.Int32,4),
                     new MySqlParameter("@_Result",MySqlDbType.Int32,4)};
            parameters[0].Value = serverdirectionid;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_serverdirection_selResult", parameters, "serverdirection_selResult");
            return int.Parse(parameters[1].Value.ToString());
        }

        /// <summary>
        /// 添加备份日志
        /// </summary>
        /// <param name="_ServerDirectionId"></param>
        /// <param name="_BackupDate"></param>
        /// <param name="_Result"></param>
        public static void AddBackUpLog(int _ServerDirectionId, DateTime _BackupDate, int _Result)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ServerDirectionId", MySqlDbType.Int32,4),
					new MySqlParameter("@_BackupDate", MySqlDbType.DateTime),
					new MySqlParameter("@_Result", MySqlDbType.Int32,4)};
            parameters[0].Value = _ServerDirectionId;
            parameters[1].Value = _BackupDate;
            parameters[2].Value = _Result;
            int outint;
            DbHelperMySQL.RunProcedure("server_backuplog_add", parameters,out outint);
        }
    }
}

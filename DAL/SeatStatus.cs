using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Flamingo.DAL
{
    /// <summary>
    /// 作为状态数据库访问 by lzz 2011-12-05
    /// </summary>
    public class SeatStatus
    {
        /// <summary>
        /// 锁定一个座位状态
        /// </summary>
        /// <param name="showplanid">场计划ID</param>
        /// <param name="seatid">座位ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态</returns>
        public static int Lock(string showplanid, string seatid, int lockedby)
        {
            int status = 0;
            MySqlParameter[] parameters = {
					new MySqlParameter("@slid", MySqlDbType.VarChar,12),
					new MySqlParameter("@stid", MySqlDbType.VarChar,8),
					new MySqlParameter("@lkid", MySqlDbType.Int32,4),
					new MySqlParameter("@revalue", MySqlDbType.Int32,4)};
            parameters[0].Value = showplanid;
            parameters[1].Value = seatid;
            parameters[2].Value = lockedby;
            parameters[3].Direction = ParameterDirection.Output;
            DataSet ds= DbHelperMySQL.RunProcedure("proc_seatstatus_lock", parameters, "lock");
            status = Int32.Parse(parameters[3].Value.ToString());
            return status;
        }

        /// <summary>
        /// 锁定多个座位状态
        /// </summary>
        /// <param name="seatids">座位状态ID集合 |</param>
        /// <param name="showplanid">场次ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态集合</returns>
        public static DataTable Lock(StringBuilder seatstatusids, string showplanid,int lockedby )
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@seatstatusids", MySqlDbType.Text),
					new MySqlParameter("@slid", MySqlDbType.VarChar,12),
					new MySqlParameter("@lkid", MySqlDbType.Int32,4)};
            parameters[0].Value = seatstatusids.ToString();
            parameters[1].Value = showplanid;
            parameters[2].Value = lockedby;
            DataSet ds= DbHelperMySQL.RunProcedure("proc_seatstatus_lockALot", parameters, "lockALot");

            return ds.Tables[ds.Tables.Count - 1];
        }

        /// <summary>
        /// 取消一个座位的锁定状态
        /// </summary>
        /// <param name="showplanid">场计划ID</param>
        /// <param name="seatid">座位ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态</returns>
        public static int CancelLock(string showplanid, string seatid, int lockedby)
        {
            int status = 0;
            MySqlParameter[] parameters = {
					new MySqlParameter("@slid", MySqlDbType.VarChar,8),
					new MySqlParameter("@stid", MySqlDbType.VarChar,12),
					new MySqlParameter("@lkid", MySqlDbType.Int32,4),
					new MySqlParameter("@revalue", MySqlDbType.Int32,4)};
            parameters[0].Value = showplanid;
            parameters[1].Value = seatid;
            parameters[2].Value = lockedby;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_seatstatus_cancelLock", parameters, "lock");
            status = Int32.Parse(parameters[3].Value.ToString());
            return status;
        }

        /// <summary>
        /// 取消多个座位的锁定状态
        /// </summary>
        /// <param name="seatstatusids">座位状态ID集合 |</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns></returns>
        public static bool CancelLock(string seatstatusids,string lockedby)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@seatstatusids", MySqlDbType.Text),
					new MySqlParameter("@lkid", MySqlDbType.VarChar,16),
                    new MySqlParameter("@_isTrue",MySqlDbType.Int16)};
            parameters[0].Value = seatstatusids;
            parameters[1].Value = lockedby;
            parameters[2].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_seatstatus_cancelLockALot", parameters, "cancelLockALot");
            tf = parameters[2].Value.ToString() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 锁定多个座位
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <param name="showplanid"></param>
        /// <param name="lockedby"></param>
        /// <returns></returns>
        public static DataTable SpecialLockAlot(StringBuilder sb_seatstatusids, string showplanid, int lockedby)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@seatstatusids", MySqlDbType.Text),
					new MySqlParameter("@slid", MySqlDbType.VarChar,12),
					new MySqlParameter("@lkid", MySqlDbType.Int32,4)};
            parameters[0].Value = sb_seatstatusids.ToString();
            parameters[1].Value = showplanid;
            parameters[2].Value = lockedby;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_seatstatus_specialLockAlot", parameters, "specialLockAlot");

            return ds.Tables[ds.Tables.Count - 1];
        }
        
        /// <summary>
        /// 锁定多个座位
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <param name="showplanid"></param>
        /// <param name="lockedby"></param>
        /// <returns></returns>
        public static DataTable CancelSpecialLockAlot(StringBuilder sb_seatstatusids, string showplanid, int lockedby)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@seatstatusids", MySqlDbType.Text),
					new MySqlParameter("@slid", MySqlDbType.VarChar,12),
					new MySqlParameter("@lkid", MySqlDbType.Int32,4)};
            parameters[0].Value = sb_seatstatusids.ToString();
            parameters[1].Value = showplanid;
            parameters[2].Value = lockedby;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_seatstatus_cancelSpecialLockAlot", parameters, "CancelSpecialLockAlot");

            return ds.Tables[ds.Tables.Count - 1];
        }
    }
}

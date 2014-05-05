using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    /// <summary>
    /// 场次数据库访问 by lzz 2011-11-28
    /// </summary>
    public class ShowPlan
    {
        /// <summary>
        /// 获得日计划中的影厅信息
        /// </summary>
        /// <param name="dailyplanid">日计划ID</param>
        /// <param name="showplanname">放映计划名称</param>
        /// <returns></returns>
        public static DataSet GetHallByDailyPlan(string dailyplanid, string showplanname, int pageindex, int pagecount, out int totalpage)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_DailyPlanId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_ShowPlanName", MySqlDbType.VarChar,12),
                    new MySqlParameter("pageindex",MySqlDbType.Int32,4),
                    new MySqlParameter("pagecount",MySqlDbType.Int32,4),
                    new MySqlParameter("totalpage",MySqlDbType.Int32,4)
                                          };
            parameters[0].Value = dailyplanid;
            parameters[1].Value = showplanname;
            parameters[2].Value = pageindex;
            parameters[3].Value = pagecount;
            parameters[4].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getHall", parameters, "GetHall");

            totalpage = Int32.Parse(parameters[4].Value.ToString());
            return ds;
        }

        /// <summary>
        /// 获得场次
        /// </summary>
        /// <param name="dailyplanid">日计划ID</param>
        /// <param name="filmid">影片ID</param>
        /// <param name="hallid">影厅ID</param>
        /// <returns></returns>
        public static DataSet GetShowPlan(string dailyplanid, string filmid, string hallid, int pageindex, int pagecount, out int totalpage)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@dpid", MySqlDbType.VarChar,8),
					new MySqlParameter("@fid", MySqlDbType.VarChar,255),
					new MySqlParameter("@hid", MySqlDbType.VarChar,2),
                    new MySqlParameter("pageindex",MySqlDbType.Int32,4),
                    new MySqlParameter("pagecount",MySqlDbType.Int32,4),
                    new MySqlParameter("totalpage",MySqlDbType.Int32,4)};
            parameters[0].Value = dailyplanid;
            parameters[1].Value = filmid;
            parameters[2].Value = hallid;
            parameters[3].Value = pageindex;
            parameters[4].Value = pagecount;
            parameters[5].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getShowPlan", parameters, "GetShowPlan");
            totalpage = Int32.Parse(parameters[5].Value.ToString());
            return ds;
        }

        /// <summary>
        /// 获得场次计划名称和影片ID 影厅ID 影厅名称 影院ID 影院名称 是否对号入座
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static string[] GetShowPlanName(string showplanid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_showplanid", MySqlDbType.VarChar,12)};
            parameters[0].Value = showplanid;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getShowPlanName", parameters, "getShowPlanName");
            string[] strs = new string[ds.Tables[ds.Tables.Count - 1].Columns.Count];
            if (ds != null)
            {
                DataTable dt = ds.Tables[ds.Tables.Count - 1];
                if (dt != null)
                {
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count == 1)
                    {
                        strs[0] = dt.Rows[0]["ShowPlanName"].ToString();
                        strs[1] = dt.Rows[0]["FilmId"].ToString();
                        strs[2] = dt.Rows[0]["HallName"].ToString();
                        strs[3] = dt.Rows[0]["HallId"].ToString();
                        strs[4] = dt.Rows[0]["TheaterId"].ToString();
                        strs[5] = dt.Rows[0]["TheaterName"].ToString();
                        strs[6] = (bool)dt.Rows[0]["IsCheckingNumber"] == true ? "对号入座" : "非对号入座";
                        strs[7] = dt.Rows[0]["ShowGroup"].ToString() == "" ? "false" : "true";
                        strs[8] = dt.Rows[0]["ShowPlanIds"].ToString();
                        strs[9] = dt.Rows[0]["FilmIds"].ToString();
                        strs[10] = dt.Rows[0]["ShowGroupShowPlanNames"].ToString();
                        strs[11] = dt.Rows[0]["LowestPrice"].ToString();
                        strs[12] = dt.Rows[0]["Position"].ToString();
                        strs[13] = dt.Rows[0]["StartTime"].ToString();
                    }
                }
            }
            return strs;
        }

        /// <summary>
        /// 获得场次信息-补登Combox
        /// </summary>
        /// <param name="dailyplanid"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        public static DataTable GetShowPlanInfo(string dailyplanid, string hallid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_DailyPlanId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_HallId", MySqlDbType.VarChar,2)};
            parameters[0].Value = dailyplanid;
            parameters[1].Value = hallid;
            return DbHelperMySQL.RunProcedure("proc_showplan_selFillUp", parameters, "showplan_selFillUp").Tables[0];

        }
    }
}

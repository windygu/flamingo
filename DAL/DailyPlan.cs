using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    /// <summary>
    /// 日计划表 数据库访问 by lzz 2011-11-25
    /// </summary>
    public class DailyPlan
    {
        /// <summary>
        /// 获取可用日计划的ID和日期
        /// </summary>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagecount">每页数量</param>
        /// <param name="totalpage">总页数</param>
        /// <returns></returns>
        public static DataSet GetDateChoose(int pageindex, int pagecount, out int totalpage)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@pageindex", MySqlDbType.Int32,4),
					new MySqlParameter("@pagecount", MySqlDbType.Int32,4),
					new MySqlParameter("@totalpage", MySqlDbType.Int32,4)};
            parameters[0].Value = pageindex;
            parameters[1].Value = pagecount;
            parameters[2].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_dailyplan_getDateChoose", parameters, "getDateChoose");

            totalpage = Int32.Parse(parameters[2].Value.ToString());
            return ds;
        }
    }
}

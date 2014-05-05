using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    /// <summary>
    /// 影片信息数据库访问 by lzz 2011-11-25
    /// </summary>
    public class Film
    {
        /// <summary>
        /// 获得在日计划中的影片ID和影片名称
        /// </summary>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagecount">每页数量</param>
        /// <param name="totalpage">总页数(output)</param>
        /// <param name="dailyplanid">日计划ID</param>
        /// <returns></returns>
        public static DataSet GetFilmChoose(int pageindex, int pagecount, out int totalpage, string dailyplanid, string theaterid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@pageindex", MySqlDbType.Int32,4),
					new MySqlParameter("@pagecount", MySqlDbType.Int32,4),
					new MySqlParameter("@totalpage", MySqlDbType.Int32,4),
					new MySqlParameter("@dpid", MySqlDbType.VarChar,8),
					new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8)};
            parameters[0].Value = pageindex;
            parameters[1].Value = pagecount;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Value = dailyplanid;
            parameters[4].Value = theaterid;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_film_getFilmChoose", parameters, "getFilmChoose");

            totalpage = Int32.Parse(parameters[2].Value.ToString());
            return ds;
        }
    }
}

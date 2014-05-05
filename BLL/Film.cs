using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 影片信息业务逻辑 by lzz 2011-11-28
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
            return DAL.Film.GetFilmChoose(pageindex, pagecount, out totalpage, dailyplanid, theaterid);
        }
    }
}

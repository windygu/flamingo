using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 场次业务逻辑 by lzz 2011-11-28
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
            return DAL.ShowPlan.GetHallByDailyPlan(dailyplanid, showplanname, pageindex, pagecount, out totalpage);
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
            return DAL.ShowPlan.GetShowPlan(dailyplanid, filmid, hallid, pageindex, pagecount, out totalpage);
        }

        /// <summary>
        /// 获得场次计划名称和影片ID
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static string[] GetShowPlanName(string showplanid)
        {
            return DAL.ShowPlan.GetShowPlanName(showplanid);
        }

        /// <summary>
        /// 获得场次信息-补登Combox
        /// </summary>
        /// <param name="dailyplanid"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        public static DataTable GetShowPlanInfo(string dailyplanid, string hallid)
        {
            return DAL.ShowPlan.GetShowPlanInfo(dailyplanid, hallid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;

namespace Flamingo.ShowPlanManageLib
{
    public class HallPriceSet
    {
        private FlamingoEntities de;

        public HallPriceSet()
        {
            // 获取新的数据实体
            de = Database.GetNewDataEntity();
        }
        /// <summary>
        /// 获取影厅信息
        /// </summary>
        /// <returns></returns>
        public  List<Hall> GetHall()
        {
            var list = de.Hall.ToList();
            return list;
        }

        public List<FareSetting> GetFareSetting()
        {
            return de.FareSetting.OrderBy(P=>P.FareSettingId).ToList();
        }
    }
}

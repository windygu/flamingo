using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.ShowPlanManageLib
{
    public class BlockPriceSet
    {
        private FlamingoEntities de;
        private string showPlamId;
        private List<BlockPrice> blockPriceList;
        public BlockPriceSet()
        {
            // 获取新的数据实体
            de = Database.GetNewDataEntity();
            blockPriceList = new List<BlockPrice>();
        }

        /// <summary>
        /// 获取分区票价的等级编号
        /// </summary>
        /// <returns></returns>
        public int GetBlockfareSettingPriceId()
        {
            return de.FareSetting.Where(p => p.FareSettingName == "区域票价").FirstOrDefault().FareSettingId;
        }
        /// <summary>
        /// 获取影厅信息
        /// </summary>
        /// <returns></returns>
        public List<Hall> GetHallList()
        {
            return de.Hall.ToList();
        }

        /// <summary>
        /// 获取分区信息
        /// </summary>
        /// <returns></returns>
        public List<Block> GetBlock()
        {
            return de.Block.ToList();
        }


        /// <summary>
        /// 获取分区信息
        /// </summary>
        /// <returns></returns>
        public List<SeatingChart> GetSeatingChartList()
        {
            return de.SeatingChart.ToList();
        }

        /// <summary>
        /// 获取某一场次的分区票价
        /// </summary>
        /// <param name="showplanId"></param>
        /// <returns></returns>
        public List<BlockPrice> GetBlockPriceList(string showplanId)
        {
            this.showPlamId = showplanId;
            return de.BlockPrice.Where(p => p.ShowPlanId == showplanId).ToList();
        }

        /// <summary>
        /// 获取某天的放映场次信息
        /// </summary>
        /// <param name="datamager"></param>
        /// <returns></returns>
        public List<ShowPlanInfo> GetShowPlanInfoList(DailyShowPlanManage datamager)
        {
            List<ShowPlanInfo> list = new List<ShowPlanInfo>();

            //  var tmpList = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == datamager.DailyShowPlan.DailyPlan.PlanDate);
            var tmpList = datamager.DailyShowPlan.ShowPlanList;
            foreach (var tmp in tmpList)
            {
                ShowPlanInfo showplaninfo = new ShowPlanInfo();

                showplaninfo.ShowPlanName = tmp.Position + "--" + tmp.ShowPlanName;
                showplaninfo.ShowPlanId = tmp.ShowPlanId;
                showplaninfo.HallId = tmp.HallId;
                showplaninfo.IsLocked = tmp.IsLocked;
                list.Add(showplaninfo);
            }
            return list;
        }

        /// <summary>
        /// 获取现在数据库中最大的编号
        /// </summary>
        /// <returns></returns>
        private int GetMaxBlockId()
        {
            var tmp = de.BlockPrice.OrderByDescending(p => p.BlockPriceId).FirstOrDefault();
            if (tmp == null)
                return 1;
            else
                return Convert.ToInt32( tmp.BlockPriceId) + 1;

        }

        public List<BlockPrice> GetBlockList
        {
            get
            {
                return this.blockPriceList;
            }
        }

        /// <summary>
        /// 保存区域票价，并更新ShowPlan的价格等级
        /// </summary>
        /// <param name="blocklist"></param>
        /// <returns></returns>
        public bool SetBlockPrice(List<BlockPrice> blocklist)
        {
            if (this.showPlamId == null)
                return false;

            var tmp = de.ShowPlan.Where(p => p.ShowPlanId == this.showPlamId).FirstOrDefault();

            var film = de.Film.Where(p => p.FilmId == tmp.FilmId).FirstOrDefault();

            var tmplist = de.BlockPrice.Where(p => p.ShowPlanId == this.showPlamId).ToList();
            if (tmp == null)
                return false;

            int MaxId = GetMaxBlockId();
            try
            {
                while (blocklist.Remove(blocklist.Where(p => p.BlockId == null || p.BlockId == string.Empty).FirstOrDefault()) == true) ;

                foreach (var obj in blocklist)
                {
                    if (film.LowestPrice > obj.SinglePrice
                   || film.LowestPrice > obj.DoublePrice
                   || film.LowestPrice > obj.StudentPrice
                   || film.LowestPrice > obj.GroupPrice
                   || film.LowestPrice > obj.MemberPrice
                   || film.LowestPrice > obj.BoxPrice)
                        throw new NotImplementedException("最低票价不能小于影片的最低价！");
                }

                foreach (var list in blocklist)
                {
                    if (list.BlockPriceId ==string.Empty)
                        continue;
                    list.BlockPriceId = MaxId.ToString();
                    list.ShowPlanId = this.showPlamId;
                    list.Created = DateTime.Now;
                    list.ActiveFlag = true;
                    MaxId++;
                    de.BlockPrice.AddObject(list);

                    de.Block.Where(p => p.BlockId == list.BlockId).FirstOrDefault().HasBlockPrice = true;
                }


                //删除已删除的区域票价
                foreach (var list in tmplist)
                {
                    var obj = de.BlockPrice.Where(p => p.BlockId == list.BlockId).FirstOrDefault();
                    if (obj == null)
                        de.Block.Where(p => p.BlockId == list.BlockId).FirstOrDefault().HasBlockPrice = false;

                    if (blocklist.Where(p => p.BlockPriceId == list.BlockPriceId).FirstOrDefault() == null)
                        de.BlockPrice.DeleteObject(list);

                   
                }

                tmp.FareSettingId = GetBlockfareSettingPriceId();
                de.SaveChanges();
                List<BlockPrice> newlist = de.BlockPrice.Where(p => p.ShowPlanId == this.showPlamId).ToList();
                this.blockPriceList = newlist;
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

    }
}

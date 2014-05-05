using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.ShowPlanManageLib
{
    public class BaseQuery
    {
        private FlamingoEntities de;
        private List<Ticket_BaseQuery> Ticket_BaseQueryList;
        private string sql;

        public BaseQuery()
        {
            de = Database.GetNewDataEntity();
            Ticket_BaseQueryList = new List<Ticket_BaseQuery>();
        }
        public List<Hall> GethallList()
        {
            return de.Hall.ToList();
        }

        /// <summary>
        /// 获取影片信息
        /// </summary>
        /// <returns></returns>
        public List<FilmAndFilmMode> GetFilmAndFilmModeList(DateTime dt)
        {
            List<FilmAndFilmMode> tmpDelList = new List<FilmAndFilmMode>();
            List<FilmAndFilmMode> filmModeList = new List<FilmAndFilmMode>();

            var tmp = from f in de.Film
                      join m in de.Film_FilmMode on f.FilmId equals m.FilmId
                      into newffm
                      from ffm in newffm.DefaultIfEmpty()
                      join o in de.FilmMode on (int)ffm.FilmModeId equals (int)o.FilmModeId
                      into newfm
                      from fm in newfm.DefaultIfEmpty()
                      select new FilmAndFilmMode
                      {
                          FilmId = f.FilmId,
                          FilmCode = f.FilmCode,
                          FilmName = f.FilmName,
                          PublishDate = (DateTime)f.PublishDate,
                          Publisher = f.Publisher,
                          Producer = f.Producer,
                          Director = f.Director,
                          Cast = f.Cast,
                          Brief = f.Brief,
                          // Poster = f.Poster,
                          StartDate = (DateTime)f.StartDate,
                          EndDate = (DateTime)f.EndDate,
                          FilmLength = (int)f.FilmLength,
                          Rent = (float)f.Rent,
                          Ratio = (float)f.Ratio,
                          LowestPrice = (float)f.LowestPrice,
                          FilmAreaId = f.FilmAreaId,
                          FilmCategoryId = f.FilmCategoryId,
                          HasMode = (bool)f.HasMode,
                          Created = f.Created,
                          Updated = f.Updated,
                          ActiveFlag = f.ActiveFlag,
                          ColorCode = f.BorderColour,

                          Film_FilmModeId = ffm.Film_FilmModeId,
                          Film_FilmModeColorCode = ffm.BorderColour,

                          FilmModeId = fm.FilmModeId,
                          FilmModeName = fm.FilmModeName,
                      };

            filmModeList.AddRange(tmp);
            string oldFilmId = "";

            var tmplist = filmModeList.Where(p => p.HasMode == true && p.FilmModeId != null).OrderBy(p => p.FilmId).ToList();

            foreach (var obj in tmplist)
            {
                if (obj.FilmId == oldFilmId)
                    continue;

                FilmAndFilmMode tmpobj = new FilmAndFilmMode();
                tmpobj.FilmId = obj.FilmId;
                tmpobj.FilmCode = obj.FilmCode;
                tmpobj.FilmName = obj.FilmName;
                tmpobj.PublishDate = obj.PublishDate;
                tmpobj.Publisher = obj.Publisher;
                tmpobj.Producer = obj.Producer;
                tmpobj.Director = obj.Director;
                tmpobj.Cast = obj.Cast;
                tmpobj.Brief = obj.Brief;
                //  Poster =  tmoobj..Poster;
                tmpobj.StartDate = obj.StartDate;
                tmpobj.EndDate = obj.EndDate;
                tmpobj.FilmLength = obj.FilmLength;
                tmpobj.Rent = obj.Rent;
                tmpobj.Ratio = obj.Ratio;
                tmpobj.LowestPrice = obj.LowestPrice;
                tmpobj.FilmAreaId = obj.FilmAreaId;
                tmpobj.FilmCategoryId = obj.FilmCategoryId;
                tmpobj.HasMode = false;
                tmpobj.Created = obj.Created;
                tmpobj.Updated = obj.Updated;
                tmpobj.ActiveFlag = obj.ActiveFlag;
                tmpobj.ColorCode = obj.Film_FilmModeColorCode;

                tmpobj.Film_FilmModeId = null;
                tmpobj.Film_FilmModeColorCode = string.Empty;

                tmpobj.FilmModeId = null;
                tmpobj.FilmModeName = string.Empty;

                filmModeList.Add(tmpobj);
            }

            foreach (var list in filmModeList)
            {
                if (list.HasMode == true && list.Film_FilmModeId != null && list.FilmModeId != null)
                {
                    list.FilmId += ";" + list.Film_FilmModeId;
                    list.FilmName += "(" + list.FilmModeName + ")";
                }
                if (list.HasMode == false && list.FilmId == oldFilmId)
                {
                    tmpDelList.Add(list);
                }
                oldFilmId = list.FilmId;
            }
            if (tmpDelList.Count > 0)
            {
                foreach (var del in tmpDelList)
                {
                    filmModeList.Remove(del);
                }
            }

            while (filmModeList.Remove(filmModeList.Where(p => p.StartDate == null || p.EndDate == null).FirstOrDefault())) ;

            return filmModeList.Where(p => p.StartDate.Value.Date <= dt.Date && p.EndDate >= dt.Date).ToList();
        }

        /// <summary>
        /// 获取影片的基础查询信息
        /// </summary>
        /// <param name="FilmId"></param>
        /// <returns></returns>
        public List<Ticket_BaseQuery> GetFilmTicket_BaseQuery(string FilmId,DateTime dt)
        {
            Ticket_BaseQueryList.Clear();

            if (FilmId.Contains(";") == true)
                sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(select ShowPlanId from ShowPlan where FilmId='{0}' and Film_FilmModeId={1} and DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{2}')) group by ShowPlanId", FilmId.Split(';')[0].ToString(), Convert.ToInt32(FilmId.Split(';')[1]), dt.Date);
            else
                sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(select ShowPlanId from ShowPlan where FilmId='{0}' and DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{1}')) group by ShowPlanId", FilmId, dt.Date);
          
            var dataList = de.ExecuteStoreQuery<Ticket_BaseQuery>(sql).ToList();

            Ticket_BaseQueryList.AddRange(dataList);

            FillOther();

            return Ticket_BaseQueryList;
        }

        /// <summary>
        /// 获取影厅的基础查询信息
        /// </summary>
        /// <param name="hallId"></param>
        /// <returns></returns>
        public List<Ticket_BaseQuery> GetHallTicket_BaseQuery(string hallId,DateTime dt)
        {
            Ticket_BaseQueryList.Clear();
            sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(select ShowPlanId from ShowPlan where HallId='{0}' and DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{1}')) group by ShowPlanId", hallId, dt.Date);
            
            var dataList = de.ExecuteStoreQuery<Ticket_BaseQuery>(sql).ToList();

            Ticket_BaseQueryList.AddRange(dataList);

            FillOther();

            return Ticket_BaseQueryList;
        }


        /// <summary>
        /// 获取单日的基础查询信息
        /// </summary>
        /// <param name="hallId"></param>
        /// <returns></returns>
        public List<Ticket_BaseQuery> GetDayTicket_BaseQuery(DateTime date)
        {
            Ticket_BaseQueryList.Clear();
            sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(
               select ShowPlanId from ShowPlan where DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{0}')  ) group by ShowPlanId", date.Date);
          
            var dataList = de.ExecuteStoreQuery<Ticket_BaseQuery>(sql).ToList();

            Ticket_BaseQueryList.AddRange(dataList);

            FillOther();

            return Ticket_BaseQueryList;
        }

        /// <summary>
        /// 获取时间段的基础查询信息
        /// </summary>
        /// <param name="hallId"></param>
        /// <returns></returns>
        public List<Ticket_BaseQuery> GetPeriodTicket_BaseQuery(DateTime date, DateTime endDate,DateTime dt)
        {
            Ticket_BaseQueryList.Clear();

            if (endDate.TimeOfDay < date.TimeOfDay)
                sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(
                    select ShowPlanId from ShowPlan where ( DATE_FORMAT(StartTime, '%H:%i:%s')>='{0}' or DATE_FORMAT(StartTime, '%H:%i:%s')<= '{1}') and DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{2}')
                    ) group by ShowPlanId", date.TimeOfDay, endDate.TimeOfDay,dt.Date);
            else
                sql = string.Format(@"SELECT ShowPlanId, SUM(Ticketprice) as Total from Ticket where TicketStatus=0 and ShowPlanId in(
                    select ShowPlanId from ShowPlan where( DATE_FORMAT(StartTime, '%H:%i:%s')>='{0}' and DATE_FORMAT(StartTime, '%H:%i:%s')<= '{1}') and DailyPlanId=(select DailyPlanId from DailyPlan where PlanDate='{2}')
                    ) group by ShowPlanId", date.TimeOfDay, endDate.TimeOfDay, dt.Date);

            var dataList = de.ExecuteStoreQuery<Ticket_BaseQuery>(sql).ToList();

            Ticket_BaseQueryList.AddRange(dataList);

            FillOther();

            return Ticket_BaseQueryList;
        }

        /// <summary>
        /// 获取基础查询的其他信息
        /// </summary>
        private void FillOther()
        {
            foreach (var tmp in Ticket_BaseQueryList)
            {
                var obj = de.ShowPlan.Where(p => p.ShowPlanId == tmp.ShowPlanId).FirstOrDefault();
                tmp.Hall = obj.Hall.HallName;
                tmp.Date = obj.DailyPlan.PlanDate;
            }
        }


    }
}

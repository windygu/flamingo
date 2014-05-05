using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Data.Objects.SqlClient;
using System.Reflection;
using System.Collections;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Flamingo.ShowPlanManageLib
{
    /// <summary>
    /// 放映计划管理模块
    /// </summary>
    public class DailyShowPlanManage
    {
        /// <summary>
        /// 计划保存状态改变后引发事件
        /// </summary>
        public event EventHandler IsSaleChanged;

        private FlamingoEntities de;
        private DailyShowPlans dailyShowPlan;
        private List<Film> filmList;
        private List<Film_FilmMode> film_FilmModeList;

        private List<FareSetting> fareSettingList;

        private int fareSettingTheaterPriceId;
        private int fareSettingHallPriceId;
        private int fareSettingPeriodPriceId;
        private int fareSettingFilmPriceId;
        private int fareSettingShowPlanPriceId;

        private TheaterPrices theaterPrice;
        private List<HallPrices> hallPriceList;
        private List<PeriodPrices> periodPriceList;
        private List<FilmPrices> filmPriceList;
        private List<FilmAndFilmMode> filmAndFilmModeList;
        private List<Ticket_Refund> ticket_RefundList;
        private List<FilmMode> filmModeList;
        private TimeSetting timeSetting;

        private string[] defineColor;

        /// <summary>
        /// 保存移动的左右键
        /// </summary>
        private int Key;

        public DailyShowPlanManage()
        {
            // 获取新的数据实体
            de = Database.GetNewDataEntity();

            SetColor();
            filmAndFilmModeList = new List<FilmAndFilmMode>();

            filmModeList = new List<FilmMode>();
            filmModeList = de.FilmMode.ToList();

            //获取全场票价的等级编号
            fareSettingTheaterPriceId = GetFareSettingId("全场票价");

            //获取分厅票价的等级编号
            fareSettingHallPriceId = GetFareSettingId("分厅票价");

            //获取时段票价的等级编号
            fareSettingPeriodPriceId = GetFareSettingId("时段票价");

            //获取分片票价的等级编号
            fareSettingFilmPriceId = GetFareSettingId("分片票价");

            //获取分场票价的等级编号
            fareSettingShowPlanPriceId = GetFareSettingId("分场票价");
        }

        public int PreviewKey
        {
            get { return this.Key; }
            set { this.Key = value; }
        }

        /// <summary>
        /// 获取预定义的颜色
        /// </summary>
        public string[] GetColor
        {
            get { return this.defineColor; }
        }

        public List<Ticket_Refund> Ticket_RefundList
        {
            get { return this.ticket_RefundList; }
        }

        public List<FareSetting> GetFareSettingList
        {
            get { return this.fareSettingList; }
        }

        /// <summary>
        /// 获取日放映计划
        /// </summary>
        public DailyShowPlans DailyShowPlan
        {
            get { return this.dailyShowPlan; }
        }

        /// <summary>
        /// 获取全场票价等级编号
        /// </summary>
        public int FareSettingTheaterPriceId
        {
            get { return this.fareSettingTheaterPriceId; }
        }

        /// <summary>
        /// 获取分场票价等级编号
        /// </summary>
        public int FareSettingShowPlanPriceId
        {
            get { return this.fareSettingShowPlanPriceId; }
        }

        /// <summary>
        /// 获取分片票价等级编号
        /// </summary>
        public int FareSettingFilmPriceId
        {
            get { return this.fareSettingFilmPriceId; }
        }

        /// <summary>
        /// 获取分厅票价等级编号
        /// </summary>
        public int FareSettingHallPriceId
        {
            get { return this.fareSettingHallPriceId; }
        }
        /// <summary>
        /// 获取时段票价等级编号
        /// </summary>
        public int FareSettingPeriodPriceId
        {
            get { return this.fareSettingPeriodPriceId; }
        }

        /// <summary>
        /// 根据价格名称获取价格设置等级
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetFareSettingId(string name)
        {
            return de.FareSetting.Where(p => p.FareSettingName == name).FirstOrDefault().FareSettingId;
        }

        /// <summary>
        /// 获取可选择的电影列表
        /// </summary>
        public List<Film> Filmlist
        {
            get { return this.filmList; }
        }

        public List<FilmAndFilmMode> RefreshfilmAndFilmModeList
        {
            get { return this.filmAndFilmModeList.OrderBy(p => p.FilmId).ToList() ; }
        }

        /// <summary>
        /// 根据放映模式关系变化，获取记录
        /// </summary>
        /// <param name="film_FilmModeId"></param>
        /// <returns></returns>
        public Film_FilmMode Getfilm_FilmMode(int film_FilmModeId)
        {
            return this.film_FilmModeList.Where(p => p.Film_FilmModeId == film_FilmModeId).FirstOrDefault();
        }

        /// <summary>
        /// 获取票房信息
        /// </summary>
        private void GetTicket_RefundList()
        {
            this.ticket_RefundList = new List<Ticket_Refund>();

            var TicketList = from f in de.Ticket
                             where f.TicketStatus == 0
                             group f by f.ShowPlanId into g
                             select new Ticket_Refund
                             {
                                 ShowPlanId = g.FirstOrDefault().ShowPlanId,
                                 // TicketStatus = 1,
                                 Ticket = g.Count(),
                                 Total = g.Sum(f => f.TicketPrice),
                             };
            this.ticket_RefundList.AddRange(TicketList);

            var ReTicketList = from f in de.Ticket
                               where f.TicketStatus == 1
                               group f by f.ShowPlanId into g
                               select new Ticket_Refund
                               {
                                   ShowPlanId = g.FirstOrDefault().ShowPlanId,
                                   // TicketStatus = 0,
                                   Refund = g.Count(),
                                   Total = g.Sum(f => f.TicketPrice),
                               };

            foreach (var tmp in this.dailyShowPlan.ShowPlanList)
            {
                var obj = this.ticket_RefundList.Where(p => p.ShowPlanId == tmp.ShowPlanId).FirstOrDefault();

                if (obj == null)
                {
                    Ticket_Refund ticket_Refund = new Ticket_Refund();
                    ticket_Refund.ShowPlanId = tmp.ShowPlanId;
                    ticket_Refund.Ticket = 0;
                    ticket_Refund.Refund = 0;
                    ticket_Refund.Total = 0;
                    ticket_Refund.Rate = 0;
                    ticket_Refund.Emity = tmp.Hall.Seats;

                    this.ticket_RefundList.Add(ticket_Refund);
                }
                else
                {
                    var reobj = ReTicketList.Where(p => p.ShowPlanId == obj.ShowPlanId).FirstOrDefault();
                    if (reobj != null)
                    {
                        obj.Refund = reobj.Refund;
                        // obj.Total = 0;
                        obj.Rate = (float)obj.Ticket / tmp.Hall.Seats;
                        obj.Emity = tmp.Hall.Seats - obj.Ticket;
                    }
                    else
                    {
                        obj.Refund = 0;
                        // obj.Total = 0;
                        obj.Rate = (float)obj.Ticket / tmp.Hall.Seats;
                        obj.Emity = tmp.Hall.Seats - obj.Ticket;
                    }
                }
            }
        }

        /// <summary>
        /// 从数据库更新
        /// </summary>
        private void LoadfilmAndFilmModeList()
        {
            //先清空list数据，全部将重新获取
            this.filmAndFilmModeList.Clear();

            //获取数据，并按影片编号排序
            var tmp = from f in de.Film
                      join m in de.Film_FilmMode on f.FilmId equals m.FilmId
                      into newffm
                      from ffm in newffm.DefaultIfEmpty()
                      join o in de.FilmMode on (int)ffm.FilmModeId equals (int)o.FilmModeId
                      into newfm
                      from fm in newfm.DefaultIfEmpty()
                      where (this.dailyShowPlan.DailyPlan.PlanDate >= f.StartDate
                             && this.dailyShowPlan.DailyPlan.PlanDate <= f.EndDate)
                      orderby (f.FilmId)
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
                          //  Poster = f.Poster,
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

            this.filmAndFilmModeList.AddRange(tmp);
            var list = this.filmAndFilmModeList.Where(p => p.HasMode == true && p.FilmModeId != null).OrderBy(p => p.FilmId).ToList();
            string oldFilmID = string.Empty;
            foreach (var obj in list)
            {
                if (obj.FilmId == oldFilmID
                    || this.filmAndFilmModeList.Where(p=>p.FilmId==obj.FilmId&&p.HasMode==false).FirstOrDefault()!=null)
                    continue;

                FilmAndFilmMode tmpobj = new FilmAndFilmMode();
                oldFilmID = obj.FilmId;
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
                tmpobj.HasMode = false ;
                tmpobj.Created = obj.Created;
                tmpobj.Updated = obj.Updated;
                tmpobj.ActiveFlag = obj.ActiveFlag;
                tmpobj.ColorCode = obj.Film_FilmModeColorCode;

                tmpobj.Film_FilmModeId = null;
                tmpobj.Film_FilmModeColorCode = string.Empty;

                tmpobj.FilmModeId = null;
                tmpobj.FilmModeName = string.Empty;

                this.filmAndFilmModeList.Add(tmpobj);
            }
            GetfilmAndFilmModeList();
        }

        /// <summary>
        /// 获取影片信息以及放映类型信息
        /// </summary>
        /// <returns></returns>
        public void GetfilmAndFilmModeList()
        {
            //将要排除的数据（原因是因为影片信息表没有设置放映模式，而在放映模式关系记录中又存在此影片的记录）
            List<FilmAndFilmMode> tmpDelList = new List<FilmAndFilmMode>();

            //定义保存前一个记录的影片编号，主要是用来判断是否要移除记录
            string oldFilmId = "";
            foreach (var list in this.filmAndFilmModeList)
            {
                //如果改记录的没有设置放映模式并且该影片编号与前一个影片编号一样的将要移除
                if (list.HasMode == false && list.FilmId == oldFilmId )
                {
                    tmpDelList.Add(list);
                    oldFilmId = list.FilmId;
                }
                
            }

            if (tmpDelList.Count > 0)
            {
                //移除记录
                foreach (var del in tmpDelList)
                {
                    this.filmAndFilmModeList.Remove(del);
                }
            }

        }

        /// <summary>
        /// 获取可选择的电影列表（含影片放映模式）
        /// </summary>
        public List<FilmAndFilmMode> GetFilmAndMode()
        {
            LoadfilmAndFilmModeList();

            string color;
            int i = 0;
            foreach (var list in this.filmAndFilmModeList)
            {
                color = "";
                if (list.HasMode == true && list.Film_FilmModeId != null && list.Film_FilmModeId.Value.ToString() != "" && list.FilmModeId.Value.ToString() != "")
                {
                    //如果有放映模式，检查颜色
                    if (list.Film_FilmModeColorCode == null)
                    {
                        //如果颜色为空，则随机生成不重复的颜色
                        CheckModeColor(color, ref i, list);
                    }
                    else
                    {
                        //如果已存在颜色，则判断颜色是否正确，不正确则现在重新生成
                        if (list.Film_FilmModeColorCode.Contains(";") != true)
                            CheckModeColor(color, ref i, list);
                        else
                        {
                            try
                            {
                                string[] Array = list.Film_FilmModeColorCode.Split(';');
                                Color colorText = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                            }
                            catch
                            {
                                CheckModeColor(color, ref i, list);
                            }
                        }
                    }
                }
                else
                {
                    //没有设置放映模式的，检查颜色
                    if (list.ColorCode == null)
                    {
                        //如果颜色为空，则现在生成
                        CheckFilmColor(color, ref i, list);
                    }
                    else
                    {
                        //已存在，则检查颜色的正确性
                        if (list.ColorCode.Contains(";") != true)
                            CheckFilmColor(color, ref i, list);
                        else
                        {
                            try
                            {
                                string[] Array = list.ColorCode.Split(';');
                                Color colorText = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));

                            }
                            catch
                            {
                                CheckFilmColor(color, ref i, list);
                            }
                        }
                    }
                }
            }

            RefreshFilmList();
            return this.filmAndFilmModeList;
        }

        /// <summary>
        /// 检查并给影片颜色赋值
        /// </summary>
        /// <param name="color"></param>
        /// <param name="i"></param>
        /// <param name="list"></param>
        private void CheckFilmColor(string color, ref int i, FilmAndFilmMode list)
        {
            do
            {
                //查找预定义的颜色数组，并判断还没被使用的颜色
                if (i > 31)
                    break;
                color = defineColor[i];
                i++;
            }
            while (filmAndFilmModeList.Where(p => p.ColorCode == color || p.Film_FilmModeColorCode == color).FirstOrDefault() != null);

            if (color != "")
            {
                //保存颜色，并保存进数据库
                if (this.filmList.Where(p => p.FilmId == list.FilmId).FirstOrDefault() != null)
                {
                    this.filmList.Where(p => p.FilmId == list.FilmId).FirstOrDefault().BorderColour = color;
                    Save();
                }
            }
        }


        /// <summary>
        /// 检查并给放映模式颜色赋值
        /// </summary>
        /// <param name="color"></param>
        /// <param name="i"></param>
        /// <param name="list"></param>
        private void CheckModeColor(string color, ref int i, FilmAndFilmMode list)
        {
            do
            {
                //查找预定义的颜色数组，并判断还没被使用的颜色
                if (i > 31)
                    break;
                color = defineColor[i];
                i++;
            }
            while (filmAndFilmModeList.Where(p => p.ColorCode == color || p.Film_FilmModeColorCode == color).FirstOrDefault() != null);
            if (color != "")
            {
                //保存颜色，并保存进数据库
                if (this.film_FilmModeList.Where(p => p.Film_FilmModeId == list.Film_FilmModeId).FirstOrDefault() != null)
                {
                    this.film_FilmModeList.Where(p => p.Film_FilmModeId == list.Film_FilmModeId).FirstOrDefault().BorderColour = color;
                    Save();
                }
            }
        }

        /// <summary>
        /// 场次计划信息修改，从新设置ShowPlan和日计划的信息
        /// </summary>
        /// <param name="showPlan"></param>
        public void ReSetShowPlan_DailyShowPlan(ShowPlan showPlan)
        {
            //修改场次信息
            showPlan.ShowStatus = 0;
            showPlan.IsApproved = false;
            showPlan.IsSalable = false;
            showPlan.IsLocked = false;

            //修改日计划信息
            this.DailyShowPlan.DailyPlan.IsApproved = false;
            this.DailyShowPlan.DailyPlan.IsSalable = false;
            this.dailyShowPlan.DailyPlan.IsLocked = false;


            SaleAbleChanged();
        }

        /// <summary>
        /// 可售状态更改
        /// </summary>
        private void SaleAbleChanged()
        {
            if (IsSaleChanged != null)
                IsSaleChanged(this, EventArgs.Empty);
        }

        public void CheckTheaterPriceLowest(TheaterPrices theaterPrice)
        {
            foreach (var tmp in this.dailyShowPlan.ShowPlanList)
            {
                if (tmp.Film.LowestPrice > theaterPrice.SinglePrice
                    || tmp.Film.LowestPrice > theaterPrice.DoublePrice
                    || tmp.Film.LowestPrice > theaterPrice.StudentPrice
                    //|| tmp.Film.LowestPrice > theaterPrice.GroupPrice
                    || tmp.Film.LowestPrice > theaterPrice.MemberPrice
                    || tmp.Film.LowestPrice > theaterPrice.BoxPrice)
                    throw new NotImplementedException("最低票价不能小于影片的最低价！");
            }

            SetTheaterPrice(theaterPrice);
        }


        /// <summary>
        /// 设置全场价格对象
        /// </summary>
        /// <param name="theaterPrice"></param>
        public void SetTheaterPrice(TheaterPrices theaterPrice)
        {
            if (theaterPrice == null || this.dailyShowPlan.ShowPlanList == null)
                return;

            if (de.TheaterPrices.Where(p => p.TheaterPriceId == theaterPrice.TheaterPriceId).FirstOrDefault() == null)
            {
                // if(theaterPrice.SinglePrice<

                //如果数据库还不存在的，要现在进行保存
                theaterPrice.TheaterPriceId = this.dailyShowPlan.DailyPlan.DailyPlanId;
                this.theaterPrice = theaterPrice;

                de.TheaterPrices.AddObject(this.theaterPrice);
            }

            foreach (ShowPlan showPlan in this.dailyShowPlan.ShowPlanList)
            {
                //刷新现在的放映计划的票价信息

                //判断票价优先级和是否锁定，并设定修改后的票价等级
                if (showPlan.FareSettingId <= fareSettingTheaterPriceId && showPlan.IsLocked != true)
                {
                    showPlan.FareSettingId = fareSettingTheaterPriceId;  //设为全场票价等级

                    showPlan.SinglePrice = theaterPrice.SinglePrice;
                    showPlan.DoublePrice = theaterPrice.DoublePrice;
                    showPlan.StudentPrice = theaterPrice.StudentPrice;
                    showPlan.GroupPrice = theaterPrice.GroupPrice;
                    showPlan.MemberPrice = theaterPrice.MemberPrice;
                    showPlan.BoxPrice = theaterPrice.BoxPrice;

                    ReSetShowPlan_DailyShowPlan(showPlan);
                }
            }

        }

        /// <summary>
        /// 设置分场票价
        /// </summary>
        /// <param name="ShowPlan"></param>
        public void SetShowPlanPrice(ShowPlanInfo showplaninfo)
        {


            ShowPlan showPlan = this.DailyShowPlan.ShowPlanList.Where(p => p.ShowPlanId == showplaninfo.ShowPlanId).FirstOrDefault();


            var tmp = de.Film.Where(p => p.FilmId == showPlan.FilmId).FirstOrDefault();

            if (tmp.LowestPrice > theaterPrice.SinglePrice
                    || tmp.LowestPrice > showplaninfo.DoublePrice
                    || tmp.LowestPrice > showplaninfo.StudentPrice
                //   || tmp.LowestPrice > showplaninfo.GroupPrice
                    || tmp.LowestPrice > showplaninfo.MemberPrice
                    || tmp.LowestPrice > showplaninfo.BoxPrice)
                throw new NotImplementedException("最低票价不能小于影片的最低价！");

            if (showPlan != null && showPlan.FareSettingId <= FareSettingShowPlanPriceId && showPlan.IsLocked != true)
            {
                showPlan.FareSettingId = FareSettingShowPlanPriceId;  //设为分场票价等级
                showPlan.SinglePrice = showplaninfo.SinglePrice;
                showPlan.DoublePrice = showplaninfo.DoublePrice;
                showPlan.StudentPrice = showplaninfo.StudentPrice;
                showPlan.GroupPrice = showplaninfo.GroupPrice;
                showPlan.MemberPrice = showplaninfo.MemberPrice;
                showPlan.BoxPrice = showplaninfo.BoxPrice;

                ReSetShowPlan_DailyShowPlan(showPlan);

            }

        }

        /// <summary>
        /// 设置影片价格对象
        /// </summary>
        /// <param name="filmPrice"></param>
        public void SetFilmPrice(FilmPrices filmPrice)
        {
            if (filmPrice == null || this.dailyShowPlan.ShowPlanList == null)
                return;

            var tmp = de.Film.Where(p => p.FilmId == filmPrice.FilmId).FirstOrDefault();

            if (tmp.LowestPrice > filmPrice.SinglePrice
                    || tmp.LowestPrice > filmPrice.DoublePrice
                    || tmp.LowestPrice > filmPrice.StudentPrice
                //|| tmp.LowestPrice > filmPrice.GroupPrice
                    || tmp.LowestPrice > filmPrice.MemberPrice
                    || tmp.LowestPrice > filmPrice.BoxPrice)
                throw new NotImplementedException("最低票价不能小于影片的最低价！");

            if (filmPrice.FilmPriceId == 0)
            {
                filmPrice.FilmPriceId = GetMaxFilmPriceId();
                filmPrice.DailyPlanId = this.dailyShowPlan.DailyPlan.DailyPlanId;
                filmPriceList.Add(filmPrice);
                de.FilmPrices.AddObject(filmPrice);
            }

            foreach (ShowPlan showPlan in this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == filmPrice.FilmId).ToList())
            {
                //判断票价优先级和是否锁定，并设定修改后的票价等级
                if (showPlan.FareSettingId <= fareSettingFilmPriceId && showPlan.IsLocked != true)
                {
                    showPlan.FareSettingId = fareSettingFilmPriceId;  //设为分片票价等级

                    showPlan.SinglePrice = filmPrice.SinglePrice;
                    showPlan.DoublePrice = filmPrice.DoublePrice;
                    showPlan.StudentPrice = filmPrice.StudentPrice;
                    showPlan.GroupPrice = filmPrice.GroupPrice;
                    showPlan.MemberPrice = filmPrice.MemberPrice;
                    showPlan.BoxPrice = filmPrice.BoxPrice;

                    ReSetShowPlan_DailyShowPlan(showPlan);
                }
            }

        }

        /// <summary>
        /// 设置分厅价格对象
        /// </summary>
        /// <param name="hallPrice"></param>
        public void SetHallPrice(HallPrices hallPrice)
        {
            if (hallPrice == null || this.dailyShowPlan.ShowPlanList == null)
                return;

            foreach (var tmp in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == hallPrice.HallId).ToList())
            {
                if (tmp.Film.LowestPrice > hallPrice.SinglePrice
                    || tmp.Film.LowestPrice > hallPrice.DoublePrice
                    || tmp.Film.LowestPrice > hallPrice.StudentPrice
                    //  || tmp.Film.LowestPrice > hallPrice.GroupPrice
                    || tmp.Film.LowestPrice > hallPrice.MemberPrice
                    || tmp.Film.LowestPrice > hallPrice.BoxPrice)
                    throw new NotImplementedException("最低票价不能小于影片的最低价！");
            }

            if (hallPrice.HallPriceId == 0)
            {
                //数据库中还不存在的记录，要现在进行保存
                hallPrice.HallPriceId = GetMaxHallPriceId();

                this.hallPriceList.Add(hallPrice);

                de.HallPrices.AddObject(hallPrice);
            }

            foreach (ShowPlan showPlan in this.dailyShowPlan.ShowPlanList)
            {
                //判断票价优先级，并设定修改后的票价等级

                if (showPlan.HallId == hallPrice.HallId && showPlan.FareSettingId <= fareSettingHallPriceId && showPlan.IsLocked != true)
                {
                    showPlan.FareSettingId = fareSettingHallPriceId;  //设为分厅票价等级

                    showPlan.SinglePrice = hallPrice.SinglePrice;
                    showPlan.DoublePrice = hallPrice.DoublePrice;
                    showPlan.StudentPrice = hallPrice.StudentPrice;
                    showPlan.GroupPrice = hallPrice.GroupPrice;
                    showPlan.MemberPrice = hallPrice.MemberPrice;
                    showPlan.BoxPrice = hallPrice.BoxPrice;

                    ReSetShowPlan_DailyShowPlan(showPlan);
                }

            }
        }
        public void RefreshPeriodPrice(List<PeriodPrices> objPeriodPriceList)
        {
            de.Refresh(RefreshMode.StoreWins, objPeriodPriceList);
        }

        public void RefreshBlockPrice(List<BlockPrice> objBlockPriceList)
        {
            de.Refresh(RefreshMode.StoreWins, objBlockPriceList);
        }
        /// <summary>
        /// 设置时段价格对象
        /// </summary>
        /// <param name="hallPrice"></param>
        public void SetPeriodPrice(List<PeriodPrices> objPeriodPriceList)
        {

            //去掉开始时间或结束时间无效的时段票价
            while (objPeriodPriceList.Remove(objPeriodPriceList.Where(p => p.EndTime == null || p.StartTime == null).FirstOrDefault()) == true) ;

            this.periodPriceList = objPeriodPriceList;

            foreach (var tmp in this.periodPriceList)
            {
                foreach (ShowPlan showPlan in this.dailyShowPlan.ShowPlanList)
                {

                    //判断票价优先级，并设定修改后的票价等级
                    if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= tmp.StartTime.Value.TotalMinutes
                        && showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute <= tmp.EndTime.Value.TotalMinutes
                        && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                    {
                        var film = de.Film.Where(p => p.FilmId == showPlan.FilmId).FirstOrDefault();
                        if (film.LowestPrice > tmp.SinglePrice
                  || film.LowestPrice > tmp.DoublePrice
                  || film.LowestPrice > tmp.StudentPrice
                            // || film.LowestPrice > tmp.GroupPrice
                  || film.LowestPrice > tmp.MemberPrice
                  || film.LowestPrice > tmp.BoxPrice)
                            throw new NotImplementedException("最低票价不能小于影片的最低价！");
                    }
                }
            }

            //更新放映计划的票价
            if (this.periodPriceList.Count > 0 && this.dailyShowPlan.ShowPlanList != null)
            {
                int i = 0;
                int MaxID = GetMaxPeriodPriceId();
                foreach (var list in this.periodPriceList)
                {

                    if (list.PeriodPriceId == 0)
                    {
                        //如果时段票价编号为空，则说明是新增的，所以要设置编号和日计划编号
                        list.PeriodPriceId = MaxID + i;
                        list.DailyPlanId = this.dailyShowPlan.DailyPlan.DailyPlanId;
                        de.PeriodPrices.AddObject(list);
                        i++;
                    }

                    foreach (ShowPlan showPlan in this.dailyShowPlan.ShowPlanList)
                    {
                        if (list.StartTime.Value.Hours > list.EndTime.Value.Hours)
                        {
                            //表明这个时段票价时跨天的，

                            //判断票价优先级，并设定修改后的票价等级
                            if (showPlan.StartTime.Value.Hour < this.dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                            {
                                //这样表明此放映计划是在第二天
                                //时段票价的结束也是在第二天，所以只需判断票价的结束时间大于场次的开始时间
                                if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute <= list.EndTime.Value.TotalMinutes
                                   && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                    UpdatePeriodPrice(list, showPlan);
                            }

                            else if (showPlan.StartTime.Value.Hour > showPlan.EndTime.Value.Hour)
                            {
                                //这样表明此放映计划是在跨两天的边界
                                if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
                                    && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                {
                                    UpdatePeriodPrice(list, showPlan);
                                }
                            }
                            else
                            {
                                // 正常结束时间大于开始时间
                                //一种场次是在当天的，这时场次开始时间大于等于时段的开始时间即可
                                if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
                                    && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                {
                                    UpdatePeriodPrice(list, showPlan);
                                }
                            }
                        }
                        else
                        {
                            //时段票价是正常的结束时间大于开始时间的
                            if (list.StartTime.Value.Hours >= this.dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                            {
                                // 时段票价是设在第一天的

                                if (showPlan.StartTime.Value.Hour < this.dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                                {
                                    continue;
                                    //这样表明此放映计划是在第二天  
                                }

                                else if (showPlan.StartTime.Value.Hour > showPlan.EndTime.Value.Hour)
                                {
                                    //这样表明此放映计划是在跨两天的边界,判断场次开始时间大于等于时票价的开始时间即可
                                    if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
                                        && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                    {
                                        UpdatePeriodPrice(list, showPlan);
                                    }
                                }
                                else
                                {
                                    // 正常结束时间大于开始时间

                                    //这里有两种情况，一种场次是在当天的，这时场次开始时间大于等于时段的开始时间，并且场次开始时间小于时段票价的结束时间即可
                                    if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
                                       && showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute <= list.EndTime.Value.TotalMinutes
                                        && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                    {
                                        UpdatePeriodPrice(list, showPlan);
                                    }
                                }
                            }
                            else
                            {

                                // 时段票价是设在第二天的

                                if (showPlan.StartTime.Value.Hour < this.dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                                {
                                    //这样表明此放映计划是在第二天  

                                    if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
                                       && showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute <= list.EndTime.Value.TotalMinutes
                                        && showPlan.FareSettingId <= fareSettingPeriodPriceId && showPlan.IsLocked != true)
                                    {
                                        UpdatePeriodPrice(list, showPlan);
                                    }
                                }
                            }


                        }


                    }
                }
            }

            //将已不存在的时段票价从数据库中删除
            var tmpList = de.PeriodPrices.Where(p => p.DailyPlanId == this.dailyShowPlan.DailyPlan.DailyPlanId).ToList();
            foreach (var tmp in tmpList)
            {
                if (this.periodPriceList.Where(p => p.PeriodPriceId == tmp.PeriodPriceId).FirstOrDefault() == null)
                    de.PeriodPrices.DeleteObject(tmp);
            }
        }

        private void UpdatePeriodPrice(PeriodPrices list, ShowPlan showPlan)
        {
            showPlan.FareSettingId = fareSettingPeriodPriceId;  //设为时段票价等级
            showPlan.SinglePrice = list.SinglePrice;
            showPlan.DoublePrice = list.DoublePrice;
            showPlan.StudentPrice = list.StudentPrice;
            showPlan.GroupPrice = list.GroupPrice;
            showPlan.MemberPrice = list.MemberPrice;
            showPlan.BoxPrice = list.BoxPrice;

            ReSetShowPlan_DailyShowPlan(showPlan);
        }

        /// <summary>
        /// 获取全场价格对象
        /// </summary>
        public TheaterPrices GetTheaterPrice()
        {
            return this.theaterPrice;
        }

        /// <summary>
        /// 获取分厅价格对象
        /// </summary>
        public List<HallPrices> GetHallPriceList()
        {
            return this.hallPriceList; ;
        }

        /// <summary>
        /// 获取时段价格对象
        /// </summary>
        public List<PeriodPrices> GetPeriodPriceList()
        {
            return this.periodPriceList; ;
        }

        /// <summary>
        /// 获取分片价格对象
        /// </summary>
        public List<FilmPrices> GetFilmPriceList()
        {
            return this.filmPriceList;
        }

        /// <summary>
        /// 修改影片信息后，更新放映计划的影片信息
        /// </summary>
        /// <param name="film"></param>
        public void SetFilm(Film film)
        {
            foreach (var list in this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == film.FilmId).ToList())
            {
                list.FilmLength = film.FilmLength;
                // list.Ratio = film.Ratio;
            }

            Save();
        }

        public void CopyShowPlan(string[] str)
        {
            List<ShowPlan> showPlanList = new List<ShowPlan>();
            DateTime oldDate = Convert.ToDateTime(str[0]).Date;
            DateTime newDate = Convert.ToDateTime(str[2]).Date;
            string oldHall;
            string newHall;
            //数组保存顺序：
            //（0）被复制信息的日期
            //（1）被复制信息的影厅（null表示复制全部影厅）
            //（2）目标日期
            //（3）目标影厅（null表示复制全部影厅）
            try
            {
                if (str[0] == str[2])
                {
                    //str[0] == str[2]则，被复制日期和目标日期是一样的，可能存在还没保存的计划，所以不能从数据库找放映计划

                    //由于相同日期复制全部的是不允许的，所以在此只会是复制某厅的
                    //复制某厅的
                    oldHall = str[1].ToString();
                    newHall = str[3].ToString();
                    showPlanList = this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == oldHall).ToList();

                    //先删除原来厅已经有的计划
                    foreach (var obj in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == newHall).ToList())
                    {
                        var tmp = de.ShowPlan.Where(p => p.ShowPlanId == obj.ShowPlanId).FirstOrDefault();
                        if (tmp != null)
                            de.ShowPlan.DeleteObject(tmp);
                    }

                    while (this.dailyShowPlan.ShowPlanList.Remove(this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == newHall).FirstOrDefault())) ;

                }
                else
                {
                    //str[0] ！= str[2]则，被复制日期和目标日期是不样的，所以要从数据库找放映计划
                    if (str[1] == null || str[3] == null)
                    {
                        showPlanList = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == oldDate).ToList();


                        //先删除原来厅已经有的计划
                        var list = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == newDate).ToList();
                        foreach (var tmp in list)
                        {
                            de.ShowPlan.DeleteObject(tmp);
                        }
                    }
                    else
                    {
                        oldHall = str[1].ToString();
                        newHall = str[3].ToString();
                        showPlanList = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == oldDate && p.HallId == oldHall).ToList();


                        //先删除原来厅已经有的计划
                        var list = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == newDate && p.HallId == newHall).ToList();
                        foreach (var tmp in list)
                        {
                            de.ShowPlan.DeleteObject(tmp);
                        }
                    }
                }

                TimeSetting timeSetting = GetTimeSetting(newDate);

                foreach (var tmp in showPlanList)
                {
                    if (Convert.ToInt32(tmp.HallId) > this.dailyShowPlan.DailyPlan.Halls)
                        continue;

                    ShowPlan ShowPlan = new ShowPlan();

                    //如果目标日期的时间轴的开始时间大于放映计划的开始时间，说明此放映计划在第二天的了
                    if (timeSetting.OpenTime.TotalMinutes > tmp.StartTime.Value.Hour * 60 + tmp.StartTime.Value.Minute)
                        ShowPlan.StartTime = new DateTime(newDate.Year, newDate.Month, newDate.Day + 1, tmp.StartTime.Value.Hour, tmp.StartTime.Value.Minute, 0);
                    else
                        ShowPlan.StartTime = new DateTime(newDate.Year, newDate.Month, newDate.Day, tmp.StartTime.Value.Hour, tmp.StartTime.Value.Minute, 0);


                    //如果目标日期为跨天的，并且目标日期的时间轴的结束时间大于放映计划的结束时间，说明此放映计划在第二天的了
                    if (timeSetting.OpenTime >= timeSetting.CloseTime && timeSetting.CloseTime.TotalMinutes > tmp.EndTime.Value.Hour * 60 + tmp.EndTime.Value.Minute)
                        ShowPlan.EndTime = new DateTime(newDate.Year, newDate.Month, newDate.Day + 1, tmp.EndTime.Value.Hour, tmp.EndTime.Value.Minute, 0);
                    else
                        ShowPlan.EndTime = new DateTime(newDate.Year, newDate.Month, newDate.Day, tmp.EndTime.Value.Hour, tmp.EndTime.Value.Minute, 0);

                    ShowPlan.DailyPlanId = DailyShowPlan.DailyPlan.DailyPlanId;
                    ShowPlan.ActiveFlag = tmp.ActiveFlag;
                    ShowPlan.BoxPrice = tmp.BoxPrice;
                    ShowPlan.Created = DateTime.Now;
                    ShowPlan.DoublePrice = tmp.DoublePrice;
                    ShowPlan.FareSettingId = tmp.FareSettingId;
                    ShowPlan.Film_FilmModeId = tmp.Film_FilmModeId;
                    ShowPlan.FilmId = tmp.FilmId;
                    ShowPlan.Film = tmp.Film;
                    ShowPlan.FilmLength = tmp.FilmLength;
                    ShowPlan.GroupPrice = tmp.GroupPrice;
                    ShowPlan.HallId = tmp.HallId;
                    ShowPlan.IsApproved = false;
                    ShowPlan.IsCheckingNumber = true;
                    ShowPlan.IsLocked = false;
                    ShowPlan.IsOnlineTicketing = true;
                    ShowPlan.IsSalable = false;
                    ShowPlan.IsTicketChecking = true;
                    ShowPlan.MemberPrice = tmp.MemberPrice;
                    ShowPlan.Position = tmp.Position;
                    ShowPlan.Ratio = tmp.Ratio;
                    ShowPlan.ShowPlanName = tmp.ShowPlanName;
                    ShowPlan.ShowStatus = 0;
                    ShowPlan.ShowTypeId = tmp.ShowTypeId;
                    ShowPlan.SinglePrice = tmp.SinglePrice;
                    // ShowPlan.DiscountId = tmp.DiscountId;
                    ShowPlan.IsDiscounted = false;
                    ShowPlan.StudentPrice = tmp.StudentPrice;
                    ShowPlan.Timespan = tmp.Timespan;
                    ShowPlan.Updated = DateTime.Now;

                    //设置最低价格
                    ShowPlan.LowestPrice = tmp.Film.LowestPrice;

                    ShowPlan.ShowPlanId = null;

                    //由于可能存在从同一日复制到不同的影厅，所以如果日期相同要变影厅，其他不变
                    if (str[0] == str[2] || str[1] != null || str[3] != null)
                        ShowPlan.HallId = str[3];

                    Add(ShowPlan);
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public void CheckCopy(string[] str)
        {
            //数组保存顺序：
            //（0）被复制信息的日期
            //（1）被复制信息的影厅（null表示复制全部影厅）
            //（2）目标日期
            //（3）目标影厅（null表示复制全部影厅）
            string hall;
            DateTime oldDate = Convert.ToDateTime(str[0]);
            DateTime newDate = Convert.ToDateTime(str[2]);
            try
            {
                if ((str[0] == str[2]) && (str[1] == null || str[3] == null))
                    throw new NotImplementedException("目标日期与被复制日期一样不能复制全天的放映计划!");


                if (str[0] == str[2])
                {
                    //日期一样不用检查时间轴的问题
                    hall = str[3].ToString();
                    if (this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == hall).FirstOrDefault() != null)
                        throw new NotImplementedException("目标影厅已存在放映计划，是否要将其覆盖?");
                }

                if (str[0] != str[2])
                {


                    List<ShowPlan> oldShowPlanList = new List<ShowPlan>();
                    if (str[1] == null || str[3] == null)
                    {
                        //全天复制要检查被复制当日所有的放映计划
                        oldShowPlanList = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == oldDate).ToList();

                        //检查时间轴
                        //CheckTimelines(newDate, oldShowPlanList);

                        //不同日期，要检查影片的档期问题
                        CheckFilmDate(oldDate, newDate, oldShowPlanList);

                        if (de.ShowPlan.Where(p => p.DailyPlan.PlanDate == newDate).FirstOrDefault() != null)
                            throw new NotImplementedException("目标日期已存在放映计划，是否要将其覆盖?");
                    }
                    else
                    {
                        hall = str[3].ToString();
                        string oldHallId = str[1].ToString();

                        //复制某厅的，检查被复制厅的放映计划
                        oldShowPlanList = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == oldDate && p.HallId == oldHallId).ToList();

                        //检查时间轴
                        //CheckTimelines(newDate, oldShowPlanList);


                        //不同日期，要检查影片的档期问题
                        CheckFilmDate(oldDate, newDate, oldShowPlanList);

                        if (de.ShowPlan.Where(p => p.DailyPlan.PlanDate == newDate && p.HallId == hall).FirstOrDefault() != null)
                            throw new NotImplementedException("目标影厅已存在放映计划，是否要将其覆盖?");
                    }
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        /*private void CheckTimelines(DateTime newDate, List<ShowPlan> oldShowPlanList)
        {
            //首先检查两个日期的时间轴是否可复制

            //遍历获取被复制的防御计划的最小开始时间和最大的结束时间，如果目标日期的时间轴不包含这个时间段将不能执行复制操作


            if (oldShowPlanList.Count <= 0)
                return;

            var obj = oldShowPlanList.FirstOrDefault();
            DateTime MinTime = new DateTime(newDate.Year, newDate.Month, newDate.Day, obj.StartTime.Value.Hour, obj.StartTime.Value.Minute, 0);
            DateTime MaxTime = MinTime.AddMinutes((int)obj.FilmLength);

            DateTime startdate = new DateTime();
            DateTime enddate = new DateTime();
            foreach (var tmp in oldShowPlanList)
            {
                if (tmp.StartTime.Value.Hour < dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                {
                    startdate = newDate.Date.AddDays(1).AddHours(tmp.StartTime.Value.Hour).AddMinutes(tmp.StartTime.Value.Minute);
                    if (startdate < MinTime)
                        MinTime = startdate;
                }
                else
                {
                    startdate = newDate.Date.AddHours(tmp.StartTime.Value.Hour).AddMinutes(tmp.StartTime.Value.Minute);
                    if (startdate < MinTime)
                        MinTime = startdate;
                }


                if (tmp.EndTime.Value.Hour < dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                {
                    enddate = newDate.Date.AddDays(1).AddHours(tmp.EndTime.Value.Hour).AddMinutes(tmp.EndTime.Value.Minute);
                    if (enddate > MaxTime)
                        MaxTime = enddate;
                }
                else
                {
                    enddate = newDate.Date.AddHours(tmp.EndTime.Value.Hour).AddMinutes(tmp.EndTime.Value.Minute);
                    if (newDate.Date.AddHours(tmp.EndTime.Value.Hour).AddMinutes(tmp.EndTime.Value.Minute) > MaxTime)
                        MaxTime = enddate;
                }
            }

            TimeSetting newDateTime = GetTimeSetting(newDate);

            if (MinTime > MaxTime)
            {
                //这样说明被复制的放映计划是跨天的

                //如果目标日期是没有跨天的，或者开始时间大于被复制计划的最小时间，或者结束时间小于被复制计划的最大时间，都不能执行复制操作
                if (newDateTime.OpenTime < newDateTime.CloseTime
                    || newDateTime.OpenTime.TotalMinutes > MinTime.Hour * 60 + MinTime.Minute
                    || newDateTime.CloseTime.TotalMinutes < MaxTime.Hour * 60 + MaxTime.Minute)
                    throw new NotImplementedException("被复制的放映计划的放映时间段在目标日期不存在，不能执行复制操作!");
            }
            else
            {
                if (newDateTime.OpenTime >= newDateTime.CloseTime)
                {
                    if (newDateTime.CloseTime.TotalMinutes < MaxTime.Hour * 60 + MaxTime.Minute)
                        throw new NotImplementedException("被复制的放映计划的放映时间段在目标日期不存在，不能执行复制操作!");
                }
                else
                {
                    if (newDateTime.OpenTime.TotalMinutes > MinTime.Hour * 60 + MinTime.Minute
                      || newDateTime.CloseTime.TotalMinutes < MaxTime.Hour * 60 + MaxTime.Minute)
                        throw new NotImplementedException("被复制的放映计划的放映时间段在目标日期不存在，不能执行复制操作!");
                }
            }
        }*/

        /// <summary>
        /// 检查影片的档期
        /// </summary>
        /// <param name="oldDate"></param>
        /// <param name="newDate"></param>
        private void CheckFilmDate(DateTime oldDate, DateTime newDate, List<ShowPlan> oldShowPlanList)
        {
            var newFilmList = de.Film.Where(p => p.StartDate <= newDate && p.EndDate >= newDate).ToList();

            foreach (var tmp in oldShowPlanList)
            {
                if (newFilmList.Where(p => p.FilmId == tmp.FilmId).FirstOrDefault() == null)
                    throw new NotImplementedException(" 要复制的影片在目标影厅不在档期，不能复制！");
            }
        }

        public List<EmployeeInfo> GetEmployeeInfoList()
        {
            // string sql = "SELECT User.UserId as UserId, User.UserName AS UserName, User_Role.RoleID, User_Role.User_RoleId as User_RoleId, Role.RoleName as RoleName FROM User INNER JOIN  User_Role ON User.UserId = User_Role.UserId INNER JOIN Role ON User_Role.RoleID = Role.RoleID";
            // var list=de.ExecuteStoreQuery<EmployeeInfo>(sql).ToList();
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            var tmp = from u in de.User
                      join ur in de.User_Role on u.UserId equals ur.UserId
                      into newffm
                      from ffm in newffm.DefaultIfEmpty()
                      join r in de.Role on (int)ffm.RoleID equals (int)r.RoleID
                      into newfm
                      from fm in newfm.DefaultIfEmpty()
                      select new EmployeeInfo
                      {
                          UserId = u.UserId,
                          UserNmae = u.UserName,
                          RoleID = fm.RoleID,
                          User_RoleId = ffm.User_RoleId,
                          RoleName = fm.RoleName,


                      };
            list.AddRange(tmp);
            return list;
        }
        public static void DelPrice()
        {
            try
            {
                bool isSave = false;
                FlamingoEntities delDe = Database.GetNewDataEntity();
                DateTime date = DateTime.Now.AddDays(-7);
                //删除7天前的全场票价
                var TheaterPriceList = (from t in delDe.TheaterPrices
                                        join d in delDe.DailyPlan on t.DailyPlanId equals d.DailyPlanId
                                        into newffm
                                        from ffm in newffm.DefaultIfEmpty()
                                        where ffm.PlanDate.Value < date
                                        select t).ToList();

                foreach (TheaterPrices tmp in TheaterPriceList)
                {
                    var obj = delDe.TheaterPrices.Where(p => p.TheaterPriceId == tmp.TheaterPriceId).FirstOrDefault();
                    if (obj != null)
                    {
                        delDe.TheaterPrices.DeleteObject(tmp);
                        isSave = true;
                    }
                }

                //删除7天前的分厅票价
                var HallPriceList = (from t in delDe.HallPrices
                                     join d in delDe.DailyPlan on t.DailyPlanId equals d.DailyPlanId
                                     into newffm
                                     from ffm in newffm.DefaultIfEmpty()
                                     where ffm.PlanDate.Value < date
                                     select t).ToList();


                foreach (var tmp in HallPriceList)
                {
                    var obj = delDe.HallPrices.Where(p => p.HallPriceId == tmp.HallPriceId).FirstOrDefault();
                    if (obj != null)
                    {
                        delDe.HallPrices.DeleteObject(tmp);
                        isSave = true;
                    }
                }

                //删除7天前的时段票价
                var PeriodPriceList = (from t in delDe.PeriodPrices
                                       join d in delDe.DailyPlan on t.DailyPlanId equals d.DailyPlanId
                                       into newffm
                                       from ffm in newffm.DefaultIfEmpty()
                                       where ffm.PlanDate.Value < date
                                       select t).ToList();

                foreach (var tmp in PeriodPriceList)
                {
                    var obj = delDe.PeriodPrices.Where(p => p.PeriodPriceId == tmp.PeriodPriceId).FirstOrDefault();
                    if (obj != null)
                    {
                        delDe.PeriodPrices.DeleteObject(tmp);
                        isSave = true;
                    }
                }


                //删除7前的区域票价
                var BlockPriceList = (from t in delDe.BlockPrice
                                      join s in delDe.ShowPlan on t.ShowPlanId equals s.ShowPlanId
                                       into newffm
                                      from ffm in newffm.DefaultIfEmpty()
                                      join d in delDe.DailyPlan on ffm.DailyPlanId equals d.DailyPlanId
                                      into newffm2
                                      from ffm2 in newffm2.DefaultIfEmpty()
                                      where ffm2.PlanDate.Value < date

                                      select t).ToList();

                foreach (var tmp in BlockPriceList)
                {
                    var obj = delDe.BlockPrice.Where(p => p.BlockPriceId == tmp.BlockPriceId).FirstOrDefault();
                    if (obj != null)
                    {
                        delDe.BlockPrice.DeleteObject(obj);
                        isSave = true;
                    }
                }

                //删除7前的分片票价
                var FilmPriceList = (from t in delDe.FilmPrices
                                     join d in delDe.DailyPlan on t.DailyPlanId equals d.DailyPlanId
                                     into newffm
                                     from ffm in newffm.DefaultIfEmpty()
                                     where ffm.PlanDate.Value < date
                                     select t).ToList();

                foreach (var tmp in FilmPriceList)
                {
                    var obj = delDe.FilmPrices.Where(p => p.FilmPriceId == tmp.FilmPriceId).FirstOrDefault();
                    if (obj != null)
                    {
                        delDe.FilmPrices.DeleteObject(obj);
                        isSave = true;
                    }
                }
                if (isSave == true)
                {
                    try
                    {
                        delDe.SaveChanges();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置日期
        /// </summary>
        /// <param name="date">日期</param>
        public void SetDate(DateTime date)
        {
            if (dailyShowPlan != null && dailyShowPlan.DailyPlan.PlanDate.Value.Date == date.Date)
                return;

            if (this.dailyShowPlan != null)
                de.DailyPlan.DeleteObject(this.dailyShowPlan.DailyPlan);

            //if (this.theaterPrice != null)
            //   de.TheaterPrices.DeleteObject(this.theaterPrice);

            de = Database.GetNewDataEntity();


            //判断场次是否停售
            SetShowStatus();

            DailyPlan dailyPlan = GetDailyPlan(date.Date);

            List<ShowPlan> showPlanList = de.ShowPlan.Where(p => p.DailyPlanId == dailyPlan.DailyPlanId).ToList();
            foreach (var tmp in showPlanList)
            {
                try
                {
                    if (tmp.FilmLength == null || tmp.FilmLength == 0)
                        tmp.FilmLength = 0;
                }
                catch { tmp.FilmLength = 0; }
            }
            List<Hall> hallList = GetHallList(dailyPlan);

            this.dailyShowPlan = new DailyShowPlans();
            this.dailyShowPlan.DailyPlan = dailyPlan;
            this.dailyShowPlan.ShowPlanList = showPlanList;
            this.dailyShowPlan.HallList = hallList;

            this.fareSettingList = new List<FareSetting>();
            this.fareSettingList = de.FareSetting.ToList();

            this.timeSetting = new TimeSetting();

            SaleAbleChanged();

            LoadfilmAndFilmModeList();
            // GetfilmAndFilmModeList();

            this.filmList = de.Film.Where(p => this.dailyShowPlan.DailyPlan.PlanDate >= p.StartDate
                && this.dailyShowPlan.DailyPlan.PlanDate <= p.EndDate).ToList();

            this.film_FilmModeList = new List<Film_FilmMode>();

            if (this.film_FilmModeList.Count > 0 && this.film_FilmModeList != null)
                this.film_FilmModeList.Clear();
            foreach (var list in this.filmList)
            {
                var tmpFilmMode = de.Film_FilmMode.Where(p => p.FilmId == list.FilmId).ToList();
                if (tmpFilmMode != null)
                    this.film_FilmModeList.AddRange(tmpFilmMode);
            }

            // GetfilmAndFilmModeList();
            LoadfilmAndFilmModeList();

            //获取全场票价记录
            GetNewTheaterPrice();

            //获取分厅票价记录
            GetNewHallPrice(hallList);

            //获取时段票价记录
            GetNewPeriodPrice();

            //获取分片票价记录
            GetNewFilmPrice();

            GetTicket_RefundList();

        }

        /// <summary>
        /// 从数据库获取分厅票价信息，如果没有则创建
        /// </summary>
        /// <param name="hallList"></param>
        private void GetNewHallPrice(List<Hall> hallList)
        {
            this.hallPriceList = de.HallPrices.Where(p => p.DailyPlanId == this.dailyShowPlan.DailyPlan.DailyPlanId).ToList();
        }

        /// <summary>
        /// 从数据库获取全场票价信息，如果没有则创建
        /// </summary>
        private void GetNewTheaterPrice()
        {
            this.theaterPrice = de.TheaterPrices.Where(p => p.DailyPlanId == this.dailyShowPlan.DailyPlan.DailyPlanId).FirstOrDefault();
            if (this.theaterPrice == null)
            {
                this.theaterPrice = new TheaterPrices();
                var tmp = GetFareSettingList.Where(p => p.FareSettingId == FareSettingTheaterPriceId).FirstOrDefault();

                this.theaterPrice.TheaterPriceId = this.dailyShowPlan.DailyPlan.DailyPlanId;
                this.theaterPrice.DailyPlanId = this.dailyShowPlan.DailyPlan.DailyPlanId;

                this.theaterPrice.SinglePrice = tmp.SinglePrice;
                this.theaterPrice.DoublePrice = tmp.DoublePrice;
                this.theaterPrice.StudentPrice = tmp.StudentPrice;
                this.theaterPrice.GroupPrice = tmp.GroupPrice;
                this.theaterPrice.MemberPrice = tmp.MemberPrice;
                this.theaterPrice.BoxPrice = tmp.BoxPrice;
            }
        }

        /// <summary>
        /// 从数据库获取时段票价信息，如果没有则创建
        /// </summary>
        private void GetNewPeriodPrice()
        {
            this.periodPriceList = de.PeriodPrices.Where(p => p.DailyPlanId == this.dailyShowPlan.DailyPlan.DailyPlanId).ToList();
        }

        /// <summary>
        /// 获取分片票价记录
        /// </summary>
        private void GetNewFilmPrice()
        {
            this.filmPriceList = de.FilmPrices.Where(p => p.DailyPlanId == this.dailyShowPlan.DailyPlan.DailyPlanId).ToList();
        }


        /// <summary>
        /// 获取指定日期的影厅列表
        /// </summary>
        /// <param name="dailyPlan"></param>
        /// <returns></returns>
        private List<Hall> GetHallList(DailyPlan dailyPlan)
        {
            // 获取电影院的影厅数
            int maxHall = dailyPlan.Theater.Halls.Value;
            List<Hall> hallList = new List<Hall>();

            // 获取实际影厅总数
            int factHall = de.Hall.Count<Hall>();

            // 如果实际影厅数不超过电影院设置的影厅数，则获取按实际影厅数量获取，否则按电影院设置的数量获取
            if (factHall <= maxHall)
            {
                hallList = de.Hall.OrderBy(p => p.HallId).ToList();
            }
            else
            {
                hallList = de.Hall.OrderBy(p => p.HallId).Take<Hall>(maxHall).ToList();
            }
            int i = 0;
            string color = null;
            foreach (var tmp in hallList)
            {
                if (tmp.BarColour == null)
                {
                    SetHallColor(hallList, ref i, color, tmp);
                }
                else
                {
                    try
                    {
                        string[] Array = tmp.BarColour.Split(';');
                        Color colorText = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));

                    }
                    catch
                    {
                        SetHallColor(hallList, ref i, color, tmp);
                    }
                }
            }
            return hallList;
        }

        /// <summary>
        /// 检查并设置影厅的时间轴的颜色
        /// </summary>
        /// <param name="hallList"></param>
        /// <param name="i"></param>
        /// <param name="color"></param>
        /// <param name="tmp"></param>
        private void SetHallColor(List<Hall> hallList, ref int i, string color, Hall tmp)
        {
            color = null;
            do
            {
                if (i > 31)
                    break;
                color = defineColor[i];
                i++;
            }
            while (hallList.Where(p => p.BarColour == color).FirstOrDefault() != null);
            if (color != "")
            {
                tmp.BarColour = color;
            }
            else
                tmp.BarColour = defineColor[0];
        }


        /// <summary>
        /// 获取最小可用的分厅票价编号
        /// </summary>
        /// <returns></returns>
        private int GetMaxHallPriceId()
        {
            var list = de.HallPrices.OrderByDescending(p => p.HallPriceId).FirstOrDefault();

            if (list != null)
                try
                {
                    return Convert.ToInt32(list.HallPriceId) + 1;
                }
                catch
                {
                    return 1;
                }
            else
                return 1;
        }

        /// <summary>
        /// 获取最小可用的时段票价编号
        /// </summary>
        /// <returns></returns>
        private int GetMaxPeriodPriceId()
        {
            var list = de.PeriodPrices.OrderByDescending(p => p.PeriodPriceId).FirstOrDefault();

            if (list != null)
                try
                {
                    return list.PeriodPriceId + 1;
                }
                catch
                {
                    return 1;
                }
            else
                return 1;
        }

        /// <summary>
        /// 获取最小可用的时段票价编号
        /// </summary>
        /// <returns></returns>
        private int GetMaxFilmPriceId()
        {
            var list = de.FilmPrices.OrderByDescending(p => p.FilmPriceId).FirstOrDefault();

            if (list != null)
                try
                {
                    return Convert.ToInt32(list.FilmPriceId) + 1;
                }
                catch
                {
                    return 1;
                }
            else
                return 1;
        }

        /// <summary>
        /// 获取日计划，如果日计划不存在，则新建一个
        /// </summary>
        /// <param name="date">待获取的日期</param>
        private DailyPlan GetDailyPlan(DateTime date)
        {
            DailyPlan dailyPlan = de.DailyPlan.Where(p => p.PlanDate == date).FirstOrDefault();

            if (dailyPlan == null)
            {
                this.timeSetting = GetTimeSetting(date);
                Theater theater = GetTheater();

                dailyPlan = new DailyPlan();
                dailyPlan.PlanDate = date;
                dailyPlan.DailyPlanId = date.ToString("yyyyMMdd");
                dailyPlan.StartTime = this.timeSetting.OpenTime;
                dailyPlan.EndTime = this.timeSetting.CloseTime;
                dailyPlan.Timespan = this.timeSetting.Timespan;
                dailyPlan.Halls = theater.Halls;
                dailyPlan.IsApproved = true;
                dailyPlan.IsSalable = true;
                dailyPlan.IsLocked = false;
                dailyPlan.TheaterId = theater.TheaterId;
                dailyPlan.Created = DateTime.Now;

                dailyPlan.ActiveFlag = false;

                // 2011.12.11 该方法已弃用
                de.DailyPlan.AddObject(dailyPlan);
                // Save();
            }

            return dailyPlan;
        }

        /// <summary>
        /// 获取指定日期的时间设置
        /// </summary>
        /// <param name="dateTime">待获取的日期</param>
        public TimeSetting GetTimeSetting(DateTime date)
        {
            string dateString = date.ToString("yyyyMMdd");

            // 判断是否设置了具体某一天的时间设置
            TimeSetting timeSetting = de.TimeSetting.Where(p => p.RepeatDay.Trim() == dateString).FirstOrDefault();

            // 判断是否双休日或工作日
            if (timeSetting == null)
            {
                switch (date.DayOfWeek)
                {
                    // 判断双休日
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        timeSetting = de.TimeSetting.Where(p => p.RepeatDay.Trim() == "双休日").FirstOrDefault();
                        break;

                    // 判断工作日
                    default:
                        timeSetting = de.TimeSetting.Where(p => p.RepeatDay.Trim() == "工作日").FirstOrDefault();
                        break;
                }
            }

            // 如果没有设置双休日或工作日，则采用“每天”的设置
            if (timeSetting == null)
            {
                timeSetting = de.TimeSetting.Where(p => p.RepeatDay.Trim() == "每天").FirstOrDefault();
            }

            // 如果连“每天”都没有设置，则抛出异常
            if (timeSetting == null)
            {
                throw new Exception("请至少设置一个时间设置");
            }

            return timeSetting;
        }

        /// <summary>
        /// 获取影院信息
        /// </summary>
        /// <returns></returns>
        private Theater GetTheater()
        {
            Theater theater = de.Theater.OrderBy(p => p.TheaterId).FirstOrDefault();

            if (theater != null)
            {
                return theater;
            }
            else
            {
                throw new Exception("请设定最少一个影院信息");
            }
        }

        /// <summary>
        /// 添加电影，指定影厅和开始时间，并且返回为放映场次信息
        /// </summary>
        /// <param name="showPlan">待放映计划</param>
        /// <param name="hall">所在的厅序号，厅序号从0开始，对应该日计划中厅列表的顺序</param>
        /// <param name="startTime">开始放映时间与日计划中开始时间的偏移量，即与该日计划中起始时间的时间间隔，单位：分钟</param>
        public void Add(ShowPlan showPlan)
        {
            // 计算最后一个流水号
            string pfx = dailyShowPlan.DailyPlan.DailyPlanId + showPlan.HallId;

            int lastNo = 1;

            string lastNoString;

            do
            {
                lastNoString = pfx + lastNo.ToString("00");

                lastNo += 1;
            }
            while (dailyShowPlan.ShowPlanList.Where(p => p.ShowPlanId == lastNoString).FirstOrDefault() != null);
            showPlan.ShowPlanId = lastNoString;

            this.dailyShowPlan.ShowPlanList.Add(showPlan);
        }

        /// <summary>
        /// 删除放映场次
        /// </summary>
        /// <param name="showPlan"></param>
        public void Remove(ShowPlan showPlan)
        {
            this.dailyShowPlan.ShowPlanList.Remove(showPlan);

            ShowPlan oldShowPlan = de.ShowPlan.Where(p => p.ShowPlanId == showPlan.ShowPlanId).FirstOrDefault();

            if (oldShowPlan != null)
                de.ShowPlan.DeleteObject(oldShowPlan);
        }

        /// <summary>
        /// 删除临时放映场次（还未加入场次列表的成员）
        /// </summary>
        /// <param name="showPlan"></param>
        public void RemoveTempData(ShowPlan showPlan)
        {
            de.ShowPlan.DeleteObject(showPlan);
        }

        public Film GetFilm(string filmId)
        {
            return de.Film.Where(p => p.FilmId == filmId).FirstOrDefault();
        }

        /// <summary>
        /// 检查更改场次计划时判断时间设置是否超出时间轴的界限
        /// </summary>
        /// <param name="ShowPlan"></param>
        /// <returns></returns>
        public bool CkeckTime(ShowPlan ShowPlan)
        {
            if (this.dailyShowPlan.DailyPlan == null)
                throw new NotImplementedException("日计划不存在！");

            if (this.dailyShowPlan.DailyPlan.EndTime.Value <= this.dailyShowPlan.DailyPlan.StartTime.Value)
            {
                //如果日计划的开始时间的小时大于或等于日计划的结束时间的小时数，则说明此日计划是跨天的。

                //判断影片是否会在时间轴外
                if ((((int)this.dailyShowPlan.DailyPlan.EndTime.Value.TotalMinutes + 24 * 60) < (int)ShowPlan.FilmLength + (ShowPlan.StartTime.Value.Day - this.dailyShowPlan.DailyPlan.PlanDate.Value.Day) * 24 * 60 + ShowPlan.StartTime.Value.Hour * 60 + ShowPlan.StartTime.Value.Minute)
                   || ((int)this.dailyShowPlan.DailyPlan.StartTime.Value.TotalMinutes > (ShowPlan.StartTime.Value.Day - this.dailyShowPlan.DailyPlan.PlanDate.Value.Day) * 24 * 60 + ShowPlan.StartTime.Value.Hour * 60 + ShowPlan.StartTime.Value.Minute))
                    throw new NotImplementedException("场次计划安排时间超出时间轴界限！");
            }
            else
            {
                //判断影片是否会在时间轴外

                if (((int)this.dailyShowPlan.DailyPlan.EndTime.Value.TotalMinutes < (int)ShowPlan.FilmLength + ShowPlan.StartTime.Value.Hour * 60 + ShowPlan.StartTime.Value.Minute)
                     || ((int)this.dailyShowPlan.DailyPlan.StartTime.Value.TotalMinutes > ShowPlan.StartTime.Value.Hour * 60 + ShowPlan.StartTime.Value.Minute))
                    throw new NotImplementedException("场次计划安排时间超出时间轴界限！");
            }
            return true;
        }


        ////检查时间轴，影片间的间隔问题
        public bool CheckShowPlan(ShowPlan ShowPlan)
        {
            try
            {
                //2011.12.17,江
                //这里无论如何跨天，他的总时间长度不会超过24小时，所以这里不需要做增加开始时间处理，也不能在这里改开始时间
                //if (this.dailyShowPlan.DailyPlan.EndTime.Value <= this.dailyShowPlan.DailyPlan.StartTime.Value && ShowPlan.StartTime.Value.Hour <= this.dailyShowPlan.DailyPlan.StartTime.Value.Hours)
                //    ShowPlan.StartTime = dailyShowPlan.DailyPlan.PlanDate.Value.AddDays(1).AddHours(ShowPlan.StartTime.Value.Hour).AddMinutes(ShowPlan.StartTime.Value.Minute);
                //else
                //    ShowPlan.StartTime = dailyShowPlan.DailyPlan.PlanDate.Value.AddHours(ShowPlan.StartTime.Value.Hour).AddMinutes(ShowPlan.StartTime.Value.Minute);

                //ShowPlan.EndTime = ShowPlan.StartTime.Value.AddMinutes((int)ShowPlan.FilmLength);
                //ShowPlan.Updated = DateTime.Now;

                CkeckTime(ShowPlan);

                //检查与原有的其他场次的冲突
                foreach (var list in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == ShowPlan.HallId && p.ShowPlanId != ShowPlan.ShowPlanId))
                {

                    if ((ShowPlan.StartTime >= list.StartTime && ShowPlan.StartTime < list.EndTime.Value.AddMinutes((int)-list.Timespan)) || (ShowPlan.EndTime > list.StartTime && ShowPlan.EndTime <= list.EndTime))
                        throw new NotImplementedException("安排的场次计划与原有的场次计划时间有冲突！");
                }
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        /// <summary>
        /// 根据电影信息，获取一个新的影片放映计划
        /// </summary>
        /// <param name="film"></param>
        public ShowPlan GetNewShowPlan(FilmAndFilmMode film)
        {
            if (film.FilmLength == null || film.FilmLength == 0)
                return null;

            ShowPlan newData = new ShowPlan();

            if (film.HasMode == true && film.Film_FilmModeId != null && film.Film_FilmModeId.Value.ToString().Trim() != string.Empty)
            {
                newData.ShowPlanName = film.FilmName + "(" + film.FilmModeName + ")";
                newData.Film_FilmModeId = film.Film_FilmModeId.Value;
            }
            else
                newData.ShowPlanName = film.FilmName;
            newData.Film = GetFilm(film.FilmId);
            newData.Position = 0;
            newData.StartTime = this.dailyShowPlan.DailyPlan.PlanDate.Value.Add(this.dailyShowPlan.DailyPlan.StartTime.Value);
            try
            {
                newData.EndTime = newData.StartTime.Value.AddMinutes((int)film.FilmLength);
            }
            catch { newData.EndTime = newData.StartTime; }
            newData.FilmLength = film.FilmLength;
            newData.Hall = null;
            newData.DailyPlan = this.dailyShowPlan.DailyPlan;
            newData.Timespan = this.dailyShowPlan.DailyPlan.Timespan;
            newData.Ratio = film.Ratio;
            //newData.DiscountId = 0;
            newData.IsDiscounted = false;
            newData.FareSettingId = 1;

            if (this.theaterPrice != null)
            {
                newData.SinglePrice = this.theaterPrice.SinglePrice;
                newData.DoublePrice = this.theaterPrice.DoublePrice;
                newData.StudentPrice = this.theaterPrice.StudentPrice;
                newData.GroupPrice = this.theaterPrice.GroupPrice;
                newData.MemberPrice = this.theaterPrice.MemberPrice;
                newData.BoxPrice = this.theaterPrice.BoxPrice;
            }
            else
            {
                newData.SinglePrice = 0;
                newData.DoublePrice = 0;
                newData.StudentPrice = 0;
                newData.GroupPrice = 0;
                newData.MemberPrice = 0;
                newData.BoxPrice = 0;
            }

            newData.ShowStatus = 0;
            newData.ShowTypeId = 1;
            newData.IsCheckingNumber = true;
            newData.IsTicketChecking = true;
            newData.IsOnlineTicketing = true;
            newData.IsApproved = false;
            newData.IsSalable = false;
            newData.IsLocked = false;
            newData.ActiveFlag = true;
            newData.Created = DateTime.Now;
            newData.Updated = DateTime.Now;

            newData.LowestPrice = film.LowestPrice;

            return newData;
        }

        /// <summary>
        /// 重新计算并更新所有场次位置
        /// </summary>
        private void RefreshAllPosition()
        {
            var hallIdList = (from h in this.dailyShowPlan.ShowPlanList
                              group h by new { h.HallId } into g
                              select new { g.Key.HallId }).ToList();

            foreach (var hall in hallIdList)
            {
                List<ShowPlan> showPlanList = this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == hall.HallId).OrderBy(p => p.StartTime).ToList();

                int position = 1;

                foreach (ShowPlan s in showPlanList)
                {
                    s.Position = position;

                    position += 1;
                }
            }
        }
        public void isCheckRatio()
        {
            foreach (ShowPlan s in this.DailyShowPlan.ShowPlanList)
            {
                if (s.Ratio == null || s.Ratio == 0)
                    throw new NotImplementedException("请先将  第" + s.HallId + "厅" + "  第" + s.Position + "场次  " + s.ShowPlanName + "  设置片方分账比例");
                if (s.SinglePrice == null || s.SinglePrice == 0)
                    throw new NotImplementedException("请先将  第" + s.HallId + "厅" + "  第" + s.Position + "场次  " + s.ShowPlanName + "  设置票价");
            }
        }
        private void Del()
        {
            try
            {
                var list = de.ShowPlan.Where(p => p.DailyPlanId == this.DailyShowPlan.DailyPlan.DailyPlanId).ToList();
                foreach (var tmp in list)
                {
                    if (this.DailyShowPlan.ShowPlanList.Where(p => p.ShowPlanId == tmp.ShowPlanId).FirstOrDefault() == null)
                        de.ShowPlan.DeleteObject(tmp);
                }
                de.SaveChanges();
            }
            catch { }
        }


        /// <summary>
        /// 保存日放映计划
        /// </summary>
        public void Save()
        {
            // 设置事务参数
            TransactionOptions transactionOption = new TransactionOptions();

            // 设置事务隔离级别 
            transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            // 设置事务超时时间为60秒 
            transactionOption.Timeout = new TimeSpan(0, 60, 0);

            // 更新所有场次信息
            //RefreshAllPosition();

            // 写入数据库
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, transactionOption))
            {
                // 保存到数据库，如果遇到开放式冲突，则以本地数据为准
                try
                {
                    if (this.DailyShowPlan != null && this.DailyShowPlan.DailyPlan != null)
                        this.DailyShowPlan.DailyPlan.ActiveFlag = true;
                    de.SaveChanges();

                }
                catch (OptimisticConcurrencyException)
                {
                    de.Refresh(RefreshMode.ClientWins, de.ShowPlan);

                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    //throw ex;
                }

                ts.Complete();
            }

            Del();
        }

        /// <summary>
        /// 根据计划日期，刷新可选择的电影列表
        /// </summary>
        public void RefreshFilmList()
        {
            // 强制从数据库刷新电影信息，因为有可能已经改了字段值
            //de.Refresh(RefreshMode.StoreWins, de.Film);

            //de.Refresh(RefreshMode.StoreWins, de.Film_FilmMode);

            this.filmList = de.Film.Where(p => this.dailyShowPlan.DailyPlan.PlanDate >= p.StartDate && this.dailyShowPlan.DailyPlan.PlanDate <= p.EndDate).ToList();

            // GetfilmAndFilmModeList();
            LoadfilmAndFilmModeList();

            if (this.film_FilmModeList.Count > 0 && this.film_FilmModeList != null)
                this.film_FilmModeList.Clear();
            foreach (var list in this.filmList)
            {
                var tmpFilmMode = de.Film_FilmMode.Where(p => p.FilmId == list.FilmId).ToList();
                if (tmpFilmMode != null)
                    this.film_FilmModeList.AddRange(tmpFilmMode);
            }
        }
        /// <summary>
        /// 获取有效的开始时间（用于新增场次时，发生重叠后，重新计算开始时间）
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public bool GetIsActivePosition(ShowPlan showPlan, DateTime startTime, int hall)
        {
            return GetIsActivePosition(showPlan, startTime, hall, false, true);
        }

        /// <summary>
        /// 获取有效的开始时间（用于新增场次时，发生重叠后，重新计算开始时间）
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public bool GetIsActivePosition(ShowPlan showPlan, DateTime startTime, int hall, bool UseMove, bool isMove)
        {
            showPlan.HallId = dailyShowPlan.HallList[hall].HallId;
            bool rst = true;

            // 结束时间加上默认场间隔
            DateTime endTime = startTime.AddMinutes(showPlan.FilmLength.Value);

            var hallList = this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == dailyShowPlan.HallList[hall].HallId && p.ShowPlanId != showPlan.ShowPlanId).OrderBy(p => p.StartTime).ToList();

            // 需跳过判断自身的位置
            foreach (ShowPlan s in hallList)
            {
                DateTime tStartTime = s.StartTime.Value;

                DateTime tEndTime = s.StartTime.Value.AddMinutes(s.FilmLength.Value + s.Timespan.Value);

                if (startTime >= tStartTime && startTime < tEndTime
                    || endTime.AddMinutes((int)showPlan.Timespan) > tStartTime && endTime <= tEndTime)
                {
                    if (UseMove == false && isMove == false)
                    {
                        startTime = tEndTime;
                        showPlan.StartTime = startTime;
                        rst = GetIsActivePositionUsedMove(showPlan, startTime, hall);
                    }
                    else
                    {
                        rst = false;
                        break;
                    }
                }
            }
            return rst;
        }

        /// <summary>
        /// 获取有效的开始时间（用于新增场次时，发生重叠后，重新计算开始时间）
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public bool GetIsActivePositionUsedMove(ShowPlan showPlan, DateTime startTime, int hall)
        {
            showPlan.HallId = dailyShowPlan.HallList[hall].HallId;
            bool rst = true;

            // 结束时间加上默认场间隔
            DateTime endTime = startTime.AddMinutes(showPlan.FilmLength.Value);

            var hallList = this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == dailyShowPlan.HallList[hall].HallId && p.ShowPlanId != showPlan.ShowPlanId).OrderBy(p => p.StartTime).ToList();

            // 需跳过判断自身的位置
            foreach (ShowPlan s in hallList)
            {
                DateTime tStartTime = s.StartTime.Value;

                DateTime tEndTime = s.StartTime.Value.AddMinutes(s.FilmLength.Value + s.Timespan.Value);

                if (startTime >= tStartTime && startTime < tEndTime
                    || endTime.AddMinutes((int)showPlan.Timespan) > tStartTime && endTime <= tEndTime)
                {
                    rst = false;
                    break;
                }
            }
            try
            {
                CkeckTime(showPlan);
            }
            catch { rst = false; }
            return rst;
        }


        /// <summary>
        /// 修改默认场间隔
        /// </summary>
        /// <param name="timeSpan"></param>
        public void SetTimeSpan(int timeSpan)
        {
            this.dailyShowPlan.DailyPlan.Timespan = timeSpan;
        }

        /// <summary>
        /// 根据影厅序号，更新场次序号
        /// </summary>
        /// <param name="showPlan"></param>
        public void RefreshPosition(ShowPlan showPlan)
        {
            RefreshPosition(showPlan, null);
        }

        /// <summary>
        /// 删除当日所有的计划
        /// </summary>
        public void DelAllShowPlan()
        {
            foreach (var tmp in this.dailyShowPlan.ShowPlanList)
            {
                if (tmp.IsLocked == true || tmp.ShowStatus != 0)
                    throw new NotImplementedException("放映计划已锁定或已开售，不能进行删除！");
            }

            foreach (var tmp in this.dailyShowPlan.ShowPlanList)
            {
                //查找场次计划的区域票价记录
                var list = de.BlockPrice.Where(p => p.ShowPlanId == tmp.ShowPlanId).ToList();

                //如果存在，则删除
                foreach (var deltmp in list)
                {
                    de.BlockPrice.DeleteObject(deltmp);
                }

                //删除场次计划
                de.ShowPlan.DeleteObject(tmp);
            }
            this.dailyShowPlan.ShowPlanList.Clear();
        }

        /// <summary>
        /// 删除厅计划
        /// </summary>
        /// <param name="hallId"></param>
        public void DelCurrentHallShowPlan(string hallId)
        {
            if (hallId != string.Empty || hallId != null)
            {
                //找出该厅且没锁定的场次计划
                var tmp = this.dailyShowPlan.ShowPlanList.Where(p => p.IsLocked != true && p.HallId == hallId && p.ShowStatus == 0).ToList();

                foreach (var list in tmp)
                {
                    //从缓存中删除
                    this.dailyShowPlan.ShowPlanList.Remove(list);

                    //从数据库删除
                    de.ShowPlan.DeleteObject(list);
                }
            }
        }

        /// <summary>
        /// 根据影编号，更新场次编号
        /// </summary>
        /// <param name="hallId"></param>
        public void RefreshPosition(string hallId)
        {
            int lastNo;

            // 如果从其它厅移过来，则更新放映场次原来所在厅
            if (hallId != null)
            {
                lastNo = 1;
                foreach (ShowPlan s in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == hallId).OrderBy(p => p.StartTime))
                {
                    s.Position = lastNo;

                    lastNo += 1;
                }
            }
        }

        /// <summary>
        /// 根据影厅序号，更新场次序号，并且更新场次原来所在厅的场次ID序列
        /// </summary>
        /// <param name="showPlan"></param>
        /// <param name="oldHallId"></param>
        public void RefreshPosition(ShowPlan showPlan, string oldHallId)
        {
            int lastNo;

            // 如果从其它厅移过来，则更新放映场次原来所在厅
            if (oldHallId != null)
            {
                lastNo = 1;
                foreach (ShowPlan s in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == oldHallId && p.ShowPlanId != showPlan.ShowPlanId).OrderBy(p => p.StartTime))
                {
                    s.Position = lastNo;

                    lastNo += 1;
                }
            }

            // 更新放映场次现来所在厅

            lastNo = 1;
            foreach (ShowPlan s in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == showPlan.HallId).OrderBy(p => p.StartTime))
            {
                s.Position = lastNo;

                lastNo += 1;
            }
        }

        /// <summary>
        /// 获取影片放映模式关系记录
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        public List<Film_FilmMode> GetFilmMode(string filmId)
        {
            return de.Film_FilmMode.Where(p => p.FilmId == filmId).OrderBy(p => p.FilmModeId).ToList();
        }

        /// <summary>
        /// 修改影片信息，要检查时间的间隔，是否超出时间轴
        /// </summary>
        /// <param name="film"></param>
        public void CheckShowPlanTime(Film film, Film_FilmMode film_FilmMode)
        {
            try
            {
                CheckShowPlanTime(film);

                //如果符合设置，则更新颜色
                this.film_FilmModeList.Where(p => p.Film_FilmModeId == film_FilmMode.Film_FilmModeId).FirstOrDefault().BorderColour = film_FilmMode.BorderColour;

                foreach (var tmp in this.filmAndFilmModeList.Where(p => p.FilmModeId == film_FilmMode.FilmModeId).ToList())
                {
                    tmp.ColorCode = film_FilmMode.BorderColour;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        /// <summary>
        /// 检查影片是否使用过
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        public bool CheckFilmUsed(Film film)
        {
            if (de.ShowPlan.Where(p => p.FilmId == film.FilmId).FirstOrDefault() != null
                || this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == film.FilmId).FirstOrDefault() != null)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 修改影片信息，要检查时间的间隔，是否超出时间轴
        /// </summary>
        /// <param name="film"></param>
        public void CheckShowPlanTime(Film film)
        {

            /* 2011 12 18 yi 修改影片信息后不更新放映计划的片场 。只更新ShowPlan的颜色 和影片信息列表的分账比例
            //保存原来的片长，如果不符合要求则恢复原来的片长
            int length = 0;
            var obj = this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == film.FilmId).FirstOrDefault();
            if (obj != null)
                length = (int)obj.FilmLength;

            //2011.12.17,江
            //这里，已开售和停售的场次不能修改
            //增加条件 p.ShowStatus.Trim() == "0"
            foreach (var tmp in this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == film.FilmId && p.ShowStatus.Trim() == "0"))
            {
                tmp.FilmLength = film.FilmLength;
            }

            Filmlist.Where(p => p.FilmId == film.FilmId).FirstOrDefault().FilmLength = film.FilmLength;

            if (this.filmAndFilmModeList != null && this.filmAndFilmModeList.Count > 0)
                this.filmAndFilmModeList.Where(p => p.FilmId == film.FilmId).FirstOrDefault().FilmLength = film.FilmLength;

            try
            {
                foreach (var tmp in this.dailyShowPlan.ShowPlanList)
                {
                    //检查当日的是否没有冲突
                    CheckShowPlan(tmp);
                }

                //检查当前日之后的放映计划
                DateTime dt = DateTime.Now.Date;

                var dailyList = de.DailyPlan.Where(p => p.PlanDate >= dt).ToList();
                foreach (var date in dailyList)
                {
                    var showPlanlist = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == date.PlanDate).ToList();

                    //放映计划的片长更新
                    //2011.12.17,江
                    //这里，已开售和停售的场次不能修改
                    //增加条件 p.ShowStatus.Trim() == "0"
                    foreach (var tmp in showPlanlist.Where(p => p.FilmId == film.FilmId && p.ShowStatus.Trim() == "0").ToList())
                    {
                        tmp.FilmLength = film.FilmLength;
                    }

                    foreach (var tmp in showPlanlist)
                    {
                        //检查当日之后的放映计划
                        CheckFutureShowPlan(date, showPlanlist, tmp);
                    }
                }
            */

            //如果符合设置，则更新颜色和分账比例
            var objtmp = this.filmList.Where(p => p.FilmId == film.FilmId).FirstOrDefault();
            if (objtmp != null)
            {
                objtmp.FilmLength = film.FilmLength;
                objtmp.BorderColour = film.BorderColour;
                objtmp.Ratio = film.Ratio;
            }

            //更新显示
            foreach (var tmp in this.filmAndFilmModeList.Where(p => p.FilmId == film.FilmId && p.HasMode != true).ToList())
            {
                tmp.FilmLength = film.FilmLength;
                tmp.ColorCode = film.BorderColour;
                tmp.Ratio = film.Ratio;
            }

            /*   }
      
             catch (Exception e)
             {
                 //如果不符合设置要求，则设回原来的片长
                 //2011.12.17,江
                 //这里，已开售和停售的场次不能修改
                 //增加条件 p.ShowStatus.Trim() == "0"
                 foreach (var tmp in this.dailyShowPlan.ShowPlanList.Where(p => p.FilmId == film.FilmId && p.ShowStatus.Trim() == "0"))
                 {
                     tmp.FilmLength = length;
                 }

                 Filmlist.Where(p => p.FilmId == film.FilmId).FirstOrDefault().FilmLength = length;


                 if (this.filmAndFilmModeList != null && this.filmAndFilmModeList.Count > 0)
                     this.filmAndFilmModeList.Where(p => p.FilmId == film.FilmId).FirstOrDefault().FilmLength = length;

                 //把当日之后的所有ShowPlan的片长设回原来的
                 DateTime dt = DateTime.Now.Date;
                 var dailyList = de.DailyPlan.Where(p => p.PlanDate >= dt).ToList();
                 foreach (var date in dailyList)
                 {
                     var showPlanlist = de.ShowPlan.Where(p => p.DailyPlan.PlanDate == date.PlanDate).ToList();

                     //把当日的放映计划的片长更新
                     //2011.12.17,江
                     //这里，已开售和停售的场次不能修改
                     //增加条件 p.ShowStatus.Trim() == "0"
                     foreach (var tmp in showPlanlist.Where(p => p.FilmId == film.FilmId && p.ShowStatus.Trim() == "0").ToList())
                     {
                         tmp.FilmLength = length;
                     }
                 }
                 throw new NotImplementedException(e.Message);
             
          }*/
        }

        /// <summary>
        /// 在设置影片信息的时候，不仅要检查当日的放映计划是否符合，还要检查当日之后的放映计划
        /// </summary>
        /// <param name="date"></param>
        /// <param name="showPlanlist"></param>
        /// <param name="tmp"></param>
        private static void CheckFutureShowPlan(DailyPlan date, List<ShowPlan> showPlanlist, ShowPlan tmp)
        {
            if (tmp.HallId == null)
                return;

            tmp.EndTime = tmp.StartTime.Value.AddMinutes((int)tmp.FilmLength);

            tmp.Updated = DateTime.Now;

            if (date.EndTime.Value <= date.StartTime.Value)
            {
                //如果日计划的开始时间的小时大于或等于日计划的结束时间的小时数，则说明此日计划是跨天的。

                //判断影片是否会在时间轴外
                if ((((int)date.EndTime.Value.TotalMinutes + 24 * 60) < (int)tmp.FilmLength + (tmp.StartTime.Value.Day - date.PlanDate.Value.Day) * 24 * 60 + tmp.StartTime.Value.Hour * 60 + tmp.StartTime.Value.Minute)
                   || ((int)date.StartTime.Value.TotalMinutes > (tmp.StartTime.Value.Day - date.PlanDate.Value.Day) * 24 * 60 + tmp.StartTime.Value.Hour * 60 + tmp.StartTime.Value.Minute))
                    throw new NotImplementedException("此日期后存在场次计划安排时间超出时间轴界限！");
            }
            else
            {
                //判断影片是否会在时间轴外

                if (((int)date.EndTime.Value.TotalMinutes < (int)tmp.FilmLength + tmp.StartTime.Value.Hour * 60 + tmp.StartTime.Value.Minute)
                     || ((int)date.StartTime.Value.TotalMinutes > tmp.StartTime.Value.Hour * 60 + tmp.StartTime.Value.Minute))
                    throw new NotImplementedException("此日期后存在场次计划安排时间超出时间轴界限！");
            }

            //检查与原有的其他场次的冲突
            foreach (var list in showPlanlist.Where(p => p.HallId == tmp.HallId && p.ShowPlanId != tmp.ShowPlanId))
            {

                if ((tmp.StartTime >= list.StartTime && tmp.StartTime <= list.EndTime.Value.AddMinutes((int)-list.Timespan)) || (tmp.EndTime >= list.StartTime && tmp.EndTime <= list.EndTime))
                    throw new NotImplementedException("此日期后存在安排的场次计划与原有的场次计划时间有冲突！");
            }
        }

        /// <summary>
        /// 获取某天的放映场次信息
        /// </summary>
        /// <param name="datamager"></param>
        /// <returns></returns>
        public List<ShowPlanInfo> GetShowPlanInfoList()
        {
            List<ShowPlanInfo> list = new List<ShowPlanInfo>();

            var tmpList = this.dailyShowPlan.ShowPlanList;
            foreach (var tmp in tmpList)
            {
                ShowPlanInfo showplaninfo = new ShowPlanInfo();

                showplaninfo.ShowPlanName = tmp.Position + "--" + tmp.ShowPlanName;
                showplaninfo.ShowPlanId = tmp.ShowPlanId;
                showplaninfo.HallId = tmp.HallId;
                showplaninfo.FareSettingId = tmp.FareSettingId;
                showplaninfo.IsLocked = tmp.IsLocked;
                if (showplaninfo.FareSettingId == FareSettingShowPlanPriceId)
                {
                    showplaninfo.SinglePrice = tmp.SinglePrice;
                    showplaninfo.DoublePrice = tmp.DoublePrice;
                    showplaninfo.StudentPrice = tmp.StudentPrice;
                    showplaninfo.GroupPrice = tmp.GroupPrice;
                    showplaninfo.BoxPrice = tmp.BoxPrice;
                    showplaninfo.MemberPrice = tmp.MemberPrice;
                    showplaninfo.ShowStatus = tmp.ShowStatus;
                }
                list.Add(showplaninfo);
            }
            return list;
        }

        /// <summary>
        /// 保存XML文档
        /// </summary>
        private void SaveXML()
        {
            DataSet ds = new DataSet();

            DataTable dtDailyPlan = new DataTable("DailyPlan");

            //由于下面的方法只支持List，所以在此先定义一个中间变量
            List<DailyPlan> dailyPlanList = new List<DailyPlan>();
            dailyPlanList.Add(this.dailyShowPlan.DailyPlan);

            if (dailyPlanList.Count > 0)
            {
                PropertyInfo[] propertys = dailyPlanList[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取DailyPlan表的标题名称
                    dtDailyPlan.Columns.Add(pi.Name);//, pi.PropertyType
                }

                for (int i = 0; i < dailyPlanList.Count; i++)
                {
                    //获取数据
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(dailyPlanList[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dtDailyPlan.LoadDataRow(array, true);
                }
            }

            DataTable dtShowPlanList = new DataTable("ShowPlan");
            if (dailyShowPlan.ShowPlanList.Count > 0)
            {
                PropertyInfo[] propertys = dailyShowPlan.ShowPlanList[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    //获取ShowPlan表的标题名称

                    dtShowPlanList.Columns.Add(pi.Name);//, pi.PropertyType
                }

                for (int i = 0; i < dailyShowPlan.ShowPlanList.Count; i++)
                {
                    //获取数据

                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(dailyShowPlan.ShowPlanList[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dtShowPlanList.LoadDataRow(array, true);
                }
            }

            //将日计划信息加入到dataset中
            ds.Tables.Add(dtDailyPlan);

            //将放映计划信息信息加入到dataset中
            ds.Tables.Add(dtShowPlanList);

            //设置文件的保存路径
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + @"XML\" + dailyShowPlan.DailyPlan.PlanDate.Value.Date.ToString("yyyy-MM-dd") + ".XML";


            //如果保存目录不存在，则新建一个
            if (Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"XML") != true)
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"XML");

            //导出XML文件
            ds.WriteXml(Path);
        }

        /// <summary>
        /// 上报审核
        /// </summary>
        /// <returns></returns>
        public bool SetApproved()
        {
            foreach (var tmp in this.dailyShowPlan.ShowPlanList.Where(p => p.ShowStatus == 0).ToList())
            {
                tmp.IsApproved = true;
                tmp.ShowStatus = 0;
                tmp.IsLocked = false;
                tmp.IsSalable = true;
            }
            DailyShowPlan.DailyPlan.IsApproved = true;
            DailyShowPlan.DailyPlan.IsLocked = false;
            DailyShowPlan.DailyPlan.IsSalable = true;

            //保存大数据库
            Save();

            //保存XML文档
            SaveXML();

            //更新可售状态
            SaleAbleChanged();

            return true;
        }

        /// <summary>
        /// 可售设置
        /// </summary>
        /// <returns></returns>
        public bool SetSale(bool isSale)
        {
            foreach (var tmp in this.dailyShowPlan.ShowPlanList.Where(p => p.ShowStatus != 2).ToList())
            {
                tmp.IsSalable = isSale;
            }
            DailyShowPlan.DailyPlan.IsSalable = isSale;

            //保存大数据库
            Save();

            //更新可售状态
            SaleAbleChanged();
            return true;
        }


        /// <summary>
        /// 判断批量增加放映计划场次的信息是否正确可用
        /// </summary>
        /// <param name="showPlanList"></param>
        /// <returns></returns>
        public bool CheckShowPlan(List<ShowPlan> showPlanList)
        {
            string hallId = showPlanList.FirstOrDefault().HallId;
            try
            {
                foreach (var tmp in showPlanList)
                {
                    //检查是否超出时间轴
                    CkeckTime(tmp);

                    //检查与原来的场次的冲突
                    foreach (var list in this.dailyShowPlan.ShowPlanList.Where(p => p.HallId == hallId))
                    {
                        if ((tmp.StartTime >= list.StartTime && tmp.StartTime <= list.EndTime) || (tmp.EndTime >= list.StartTime && tmp.EndTime <= list.EndTime))
                            throw new NotImplementedException("安排的场次计划与原有的场次计划时间有冲突！");
                    }
                }

                //添加进缓存
                foreach (var list in showPlanList)
                {
                    Add(list);
                }

                RefreshAllPosition();
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        /// <summary>
        /// 检查放映计划是否停售
        /// </summary>
        public void SetShowStatus()
        {
            //遍历所有日计划
            foreach (var date in de.DailyPlan.ToList())
            {
                //获取日计划的TimeSetting
                var tmp = GetTimeSetting(date.PlanDate.Value);

                //遍历所有当日的放映计划
                foreach (var showPlan in de.ShowPlan.Where(p => p.DailyPlanId == date.DailyPlanId).ToList())
                {
                    //检查时间是否超出停售时间
                    if (showPlan.StartTime.Value.AddMinutes((int)tmp.TicketingDeadline) <= DateTime.Now)
                        showPlan.ShowStatus = 2;
                }
            }
            //保存最新数据
            Save();
        }
        public void PrintPic(Bitmap bmp)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + dailyShowPlan.DailyPlan.DailyPlanId + "jpg";
            bmp.Save(path);

            LocalReport localReport = new LocalReport();
            localReport.EnableExternalImages = true;
            localReport.ReportPath = System.AppDomain.CurrentDomain.BaseDirectory + "Print.rdlc";
            ReportParameter rp = new ReportParameter("ImagePath", @"file://" + path);
            localReport.SetParameters(rp);
            localReport.Refresh();

            //  PrintDocument printDoc = new PrintDocument();



        }

        /// <summary>
        /// 设置预定义的颜色
        /// </summary>
        private void SetColor()
        {
            defineColor = new string[32];

            defineColor[0] = "255;255;128;128";
            defineColor[1] = "255;255;255;128";
            defineColor[2] = "255;128;255;128";
            defineColor[3] = "255;255;128;64";
            defineColor[4] = "255;128;255;255";
            defineColor[5] = "255;255;128;255";
            defineColor[6] = "100;64;60;125";
            defineColor[7] = "255;255;255;0";
            defineColor[8] = "255;255;0;0";
            defineColor[9] = "80;128;0;255";
            defineColor[10] = "100;0;50;0";
            defineColor[11] = "255;0;255;128";
            defineColor[12] = "255;255;128;192";
            defineColor[13] = "55;110;200;192";
            defineColor[14] = "125;200;64;123";
            defineColor[15] = "255;0;255;0";
            defineColor[16] = "25;64;0;128";
            defineColor[17] = "255;255;0;128";
            defineColor[18] = "80;28;28;192";
            defineColor[19] = "80;128;0;50";
            defineColor[20] = "255;64;128;128";
            defineColor[21] = "255;128;128;64";
            defineColor[22] = "255;128;0;128";
            defineColor[23] = "255;0;0;160";
            defineColor[24] = "255;0;0;255";
            defineColor[25] = "255;0;128;0";
            defineColor[26] = "255;255;128;0";
            defineColor[27] = "255;64;0;64";
            defineColor[28] = "255;0;255;64";
            defineColor[29] = "255;0;128;128";
            defineColor[30] = "255;128;0;64";
            defineColor[31] = "255;0;128;255";
        }



    }
}

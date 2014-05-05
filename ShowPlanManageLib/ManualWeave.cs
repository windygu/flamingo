using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.ShowPlanManageLib
{
    public class ManualWeave
    {
        private FlamingoEntities de;
        private DailyShowPlanManage dataMager;
        private string[] defineColor;
        private List<FilmAndFilmMode> filmAndFilmModeList;
        private List<Film> filmList;
        private List<Film_FilmMode> film_FilmModeList;
        private List<ShowPlan> showPlanList;

        public ManualWeave(DailyShowPlanManage datemager)
        {
            showPlanList = new List<ShowPlan>();
            this.dataMager = datemager;
            // 获取新的数据实体
            de = Database.GetNewDataEntity();
            this.filmList = de.Film.ToList();
            this.film_FilmModeList = de.Film_FilmMode.ToList();
            this.defineColor = this.dataMager.GetColor;
            GetFilmAndFilmModeList();
        }

        /// <summary>
        /// 获取影片信息
        /// </summary>
        /// <returns></returns>
        public List<FilmAndFilmMode> GetFilmAndFilmModeList()
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
                      where (f.StartDate <= this.dataMager.DailyShowPlan.DailyPlan.PlanDate && f.EndDate >= this.dataMager.DailyShowPlan.DailyPlan.PlanDate)
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
                          //   Poster = f.Poster,
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
                if (obj.FilmId == oldFilmId
                     || filmModeList.Where(p => p.FilmId == obj.FilmId && p.HasMode == false).FirstOrDefault() != null)
                    continue;

                FilmAndFilmMode tmpobj = new FilmAndFilmMode();
                oldFilmId = obj.FilmId;
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
                if (list.HasMode == false && list.FilmId == oldFilmId )
                {
                    tmpDelList.Add(list);
                    oldFilmId = list.FilmId;
                }
            
            }
            if (tmpDelList.Count > 0)
            {
                foreach (var del in tmpDelList)
                {
                    filmModeList.Remove(del);
                }
            }
            this.filmAndFilmModeList = filmModeList;
            this.filmAndFilmModeList = CheckColor(filmModeList);
            de.SaveChanges();
            return this.filmAndFilmModeList;
        }

        private List<FilmAndFilmMode> CheckColor(List<FilmAndFilmMode> filmAndMode)
        {
            string color;
            int i = 0;
            foreach (var list in filmAndMode)
            {
                color = "";
                if (list.HasMode == true && list.Film_FilmModeId.Value.ToString() != "" && list.FilmModeId.Value.ToString() != "")
                {
                    //如果有放映模式，检查颜色
                    if (list.Film_FilmModeColorCode == null)
                    {
                        //如果颜色为空，则随机生成不重复的颜色
                        CheckModeColor(color, ref i, list);
                    }
                    else
                    {

                        //查看是否存在保存颜色的特定字符
                        if (list.Film_FilmModeColorCode.Contains(";") != true)
                            CheckModeColor(color, ref i, list);
                        else
                        {
                            try
                            {
                                //如果已存在颜色，则判断颜色是否正确，不正确则现在重新生成
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
                        //查看是否存在保存颜色的特定字符
                        if (list.ColorCode.Contains(";") != true)
                            CheckFilmColor(color, ref i, list);
                        else
                        {
                            //已存在，则检查颜色的正确性
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
            return filmAndMode;
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
                //如果超出预定义的颜色数组范围，不进行查找
                if (i > 31)
                    break;
                color = defineColor[i];
                i++;
            }
            while (filmAndFilmModeList.Where(p => p.ColorCode == color || p.Film_FilmModeColorCode == color).FirstOrDefault() != null);
            if (color != "")
            {
                if (this.filmList.Where(p => p.FilmId == list.FilmId).FirstOrDefault() != null)
                    this.filmList.Where(p => p.FilmId == list.FilmId).FirstOrDefault().BorderColour = color;
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
                if (i > 31)
                    break;
                color = defineColor[i];
                i++;
            }
            while (filmAndFilmModeList.Where(p => p.ColorCode == color || p.Film_FilmModeColorCode == color).FirstOrDefault() != null);
            if (color != "")
            {
                if (this.film_FilmModeList.Where(p => p.Film_FilmModeId == list.Film_FilmModeId).FirstOrDefault() != null)
                    this.film_FilmModeList.Where(p => p.Film_FilmModeId == list.Film_FilmModeId).FirstOrDefault().BorderColour = color;
            }
        }

        /// <summary>
        /// 获取影片信息
        /// </summary>
        /// <returns></returns>
        public List<FilmAndFilmMode> GetFilmModeList
        {
            get { return this.filmAndFilmModeList.OrderBy(p => p.FilmId).ToList(); }
        }


        /// <summary>
        /// 获取影厅信息
        /// </summary>
        /// <returns></returns>
        public List<Hall> GetHall()
        {
            var list = de.Hall.ToList();
            return list;
        }

        /// <summary>
        /// 根据编号，获取影片信息
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        private Film GetFilm(string filmId)
        {
            return de.Film.Where(p => p.FilmId == filmId).FirstOrDefault();
        }

        /// <summary>
        /// 根据编号，获取放映模式关系信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Film_FilmMode GetFilm_FilmMode(int id)
        {
            return de.Film_FilmMode.Where(p => p.Film_FilmModeId == id).FirstOrDefault();
        }

        /// <summary>
        /// 批量生成放映计划信息
        /// </summary>
        /// <param name="hallId"></param>
        /// <param name="filmId"></param>
        /// <param name="StartTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="showPlanNumber"></param>
        /// <returns></returns>
        public bool BuildShowPlan(string hallId, string filmId, DateTime StartTime, int timeSpan, int showPlanNumber)
        {
            bool IsHashMode = false;

            if (showPlanNumber < 1)
                throw new NotImplementedException("安排场次不能为0");

            //清空缓存中的场次计划
            showPlanList.Clear();

            Film_FilmMode film_FilmMode = new Film_FilmMode();
            string[] Id;
            int? film_FilmModeId = null;

            if (filmId.Contains(";") == true)
            {
                // 有 ";"号好的，则说明此条数据有放映模式的
                Id = filmId.Split(';');

                filmId = Id[0];

                try
                {
                    film_FilmModeId = Convert.ToInt32(Id[1]);

                    //获取放映模式数据
                    film_FilmMode = GetFilm_FilmMode((int)film_FilmModeId);

                    IsHashMode = true;
                }
                catch { return false; }
            }
            //获取影片信息
            Film tmpFilm = GetFilm(filmId);

            if (tmpFilm == null)
                return false;
            //如果日计划的开始时间的小时大于或等于日计划的结束时间的小时数，则说明此日计划是跨天的。并且ShowPlan的开始时间小于日计划的开始时间的小时，则是第二天的

            //因为选择的时候没有更改选择时间的日期。所以要从新构造以当前日计划一致的时间
            if ((dataMager.DailyShowPlan.DailyPlan.EndTime.Value <= dataMager.DailyShowPlan.DailyPlan.StartTime.Value) && StartTime.Hour < dataMager.DailyShowPlan.DailyPlan.StartTime.Value.Hours)
                StartTime = new DateTime(dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Year, dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Month, dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Day + 1, StartTime.Hour, StartTime.Minute, 0);
            else
                StartTime = new DateTime(dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Year, dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Month, dataMager.DailyShowPlan.DailyPlan.PlanDate.Value.Day, StartTime.Hour, StartTime.Minute, 0);


            while (showPlanNumber > 0)
            {
                showPlanNumber--;

                ShowPlan newData = new ShowPlan();

                if (IsHashMode == true && tmpFilm.HasMode == true && film_FilmMode.Film_FilmModeId.ToString().Trim() != string.Empty)
                {
                    //如果影片信息的放映模式为真且放映模式的编号不为空

                    //设置放映计划名称 影片名称+放映模式名称
                    newData.ShowPlanName = tmpFilm.FilmName + "(" + film_FilmMode.FilmMode.FilmModeName + ")";

                    //设置放映模式编号
                    newData.Film_FilmModeId = film_FilmModeId;

                }
                else
                    newData.ShowPlanName = tmpFilm.FilmName;

                newData.Film = dataMager.GetFilm(tmpFilm.FilmId);

                newData.Position = 0;
                newData.StartTime = StartTime;
                newData.EndTime = newData.StartTime.Value.AddMinutes((int)tmpFilm.FilmLength);
                newData.HallId = hallId;

                //设置下一场的开始时间
                StartTime = newData.EndTime.Value.AddMinutes((int)timeSpan);

                newData.FilmLength = tmpFilm.FilmLength;
                newData.DailyPlan = dataMager.DailyShowPlan.DailyPlan;
                newData.Timespan = timeSpan;
                newData.Ratio = tmpFilm.Ratio;
                //    newData.DiscountId = 0;
                newData.IsDiscounted = false;
                newData.FareSettingId = 1;

                var tmp = dataMager.GetTheaterPrice();
                if (tmp != null)
                {
                    newData.SinglePrice = tmp.SinglePrice;
                    newData.DoublePrice = tmp.DoublePrice;
                    newData.StudentPrice = tmp.StudentPrice;
                    newData.GroupPrice = tmp.GroupPrice;
                    newData.MemberPrice = tmp.MemberPrice;
                    newData.BoxPrice = tmp.BoxPrice;
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

                //设置最低价格
                newData.LowestPrice = dataMager.GetFilm(tmpFilm.FilmId).LowestPrice;

                showPlanList.Add(newData);
            }
            try
            {
                if (dataMager.CheckShowPlan(this.showPlanList) == true)
                    return true;
                else
                    return false;
            }
            catch (Exception EX)
            {
                throw new NotImplementedException(EX.Message);
            }

        }
    }
}

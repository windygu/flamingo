using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.ShowPlanManageLib
{
    public class FilmSet
    {
        private FlamingoEntities de;
        private List<Film> filmList;
        private List<Film_FilmMode> film_FilmModeList;
        private DailyShowPlanManage dataMager;
        private string[] defineColor;
        private List<FilmAndFilmMode> filmAndFilmModeList;

        public FilmSet()
        {
            this.dataMager = new DailyShowPlanManage ();
            // 获取新的数据实体
            de = Database.GetNewDataEntity();
            this.filmList = de.Film.ToList();
            this.film_FilmModeList = de.Film_FilmMode.ToList();
            this.defineColor = dataMager.GetColor;
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
            filmModeList.AddRange(tmp);
            string oldFilmId = "";
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
        /// 根据影片编号获取影片信息
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        public Film GetFilm(string filmId)
        {
            return de.Film.Where(p => p.FilmId == filmId).FirstOrDefault();
        }

        /// <summary>
        /// 根据影片放映模式关系编号，获取模式关系记录
        /// </summary>
        /// <param name="film_FilmModeId"></param>
        /// <returns></returns>
        public Film_FilmMode GetFilm_FilmMode(string filmId, int  filmModeId)
        {
           // return de.Film_FilmMode.Where(p => p.Film_FilmModeId == film_FilmModeId).FirstOrDefault();
            return de.Film_FilmMode.Where(p =>p.FilmId==filmId&&p.FilmModeId==filmModeId).FirstOrDefault();
        }

        /// <summary>
        /// 修改影片信息
        /// </summary>
        /// <param name="objdata"></param>
        /// <returns>修改成功则返回True，反之则返回False</returns>
        public bool Save()
        {
            try
            {
                de.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取影片产地记录
        /// </summary>
        /// <returns></returns>
        public List<FilmArea> GetFilmAreaList()
        {
            return de.FilmArea.ToList();
        }

        /// <summary>
        /// 获取影片放映模式记录
        /// </summary>
        /// <returns></returns>
        public List<FilmCategory> GetFilmCategoryList()
        {
            return de.FilmCategory.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;
using System.Windows.Forms;

namespace Flamingo
{
    public class FilmInfoManage
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        private List<Film_FilmMode> tmpList;

        private List<Film_FilmType> tmpFilm_FilmTypeList;

        private List<Film> delListCheck;

        public FilmInfoManage()
        {
            de = Database.GetNewDataEntity();
            tmpList = new List<Film_FilmMode>();
            tmpFilm_FilmTypeList = new List<Film_FilmType>();
            delListCheck = new List<Film>();
        }

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        #region IDataManage<Film>成员

        /// <summary>
        /// 获取列信息表
        /// </summary>
        public List<DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmId", "影片Id"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmCode", "影片编码"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmName", "影片名称", 220));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmAreaId", "影片产地名称", 110, true));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmCategoryId", "影片类别名称", 110, true));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("PublishDate", "发布日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Publisher", "发行商"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Producer", "制片人"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("StartDate", "开映日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("EndDate", "收映日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmLength", "影片长度"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Ratio", "片方分账比例", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("LowestPrice", "最低票价"));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置调整列宽的方式
                        //colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        // 设置单元格冻结
                        //if (colInfo.ColumnName == "")
                        //    colInfo.IsFrozen = true;

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FilmName":
                            case "FilmCode":
                            case "PublishDate":
                            case "Publisher":
                            case "Producer":
                            case "StartDate":
                            case "EndDate":
                            case "FilmLength":
                            case "Ratio":
                            case "LowestPrice":
                            case "FilmAreaName":
                            case "FilmCategoryName":
                                colInfo.IsReadOnly = true;
                                break;




                        }

                        // 保存属性设置
                        this.columnInfoList[i] = colInfo;
                    }
                }

                return this.columnInfoList;
            }
        }

        //public object GetDetailList()
        //{
        //    var ds = (from f in de.Film
        //              join fa in de.FilmArea on f.FilmAreaId equals fa.FilmAreaId
        //              join fc in de.FilmCategory on f.FilmCategoryId equals fc.FilmCategoryId
        //              select new
        //              {
        //                  FilmId=f.FilmId,
        //                  FilmCode = f.FilmCode,
        //                  FilmName = f.FilmName,
        //                  PublishDate = f.PublishDate,
        //                  Publisher = f.Publisher,
        //                  Producer = f.Producer,
        //                  StartDate = f.StartDate,
        //                  EndDate = f.EndDate,
        //                  LowestPrice = f.LowestPrice,
        //                  FilmLength = f.FilmLength,
        //                  Ratio = f.Ratio,
        //                  FilmAreaName = fa.FilmAreaName,
        //                  FilmCategoryName = fc.FilmCategoryName,
        //                  Director= f.Director,
        //                 BorderColour= f.BorderColour,
        //                  HasMode=f.HasMode,
        //                  FilmAreaId=f.FilmAreaId,
        //                  FilmCategoryId=f.FilmCategoryId,
        //                  Cast=f.Cast,
        //                  Brief=f.Brief,
        //                 Poster= f.Poster
        //              }).ToList();
        //    return ds;
        //}
        /// <summary>
        /// </summary>
        public List<Film> GetDataList()
        {
            return de.Film.ToList();
        }

        /// <summary>
        /// 获取影片放映模式
        /// </summary>
        /// <returns></returns>
        public List<FilmMode> GetFilmModeList()
        {
            return de.FilmMode.ToList();
        }
        public List<FilmType> GetFilmTypeList()
        {
            return de.FilmType.ToList();
        }

        public List<Film_FilmMode> GetFilm_FilmModeList(string filmId)
        {
            List<Film_FilmMode> list = new List<Film_FilmMode>();
            list.AddRange(de.Film_FilmMode.Where(p => p.FilmId == filmId).ToList());

            foreach (var tmp in tmpList.Where(p => p.FilmId == filmId).ToList())
            {
                if (list.Where(p => p.FilmModeId == tmp.FilmModeId).FirstOrDefault() == null)
                    list.Add(tmp);
            }

            return list;
        }
        public List<Film_FilmType> GetFilm_FilmTypeList(string filmId)
        {
            List<Film_FilmType> list = new List<Film_FilmType>();
            list.AddRange(de.Film_FilmType.Where(p => p.FilmId == filmId).ToList());

            foreach (var tmp in tmpFilm_FilmTypeList.Where(p => p.FilmId == filmId).ToList())
            {
                if (list.Where(p => p.FilmTypeId == tmp.FilmTypeId).FirstOrDefault() == null)
                    list.Add(tmp);
            }

            return list;
        }
        public object GetFilmAreaName(string nId)
        {
            var name = (from f in de.FilmArea
                        where f.FilmAreaId == nId
                        select f.FilmAreaName).FirstOrDefault();
            return name;
        }


        public object GetFilmCategoryName(string nId)
        {
            var name = (from f in de.FilmCategory
                        where f.FilmCategoryId == nId
                        select f.FilmCategoryName).FirstOrDefault();
            return name;
        }
        private int MaxId()
        {
            var tmp = de.Film_FilmMode.OrderByDescending(p => p.Film_FilmModeId).FirstOrDefault();
            if (tmp == null)
                return 1;
            else
                return tmp.Film_FilmModeId + 1;
        }

        private int MaxTypeId()
        {
            var tmp = de.Film_FilmType.OrderByDescending(p => p.Film_FilmTypeId).FirstOrDefault();
            if (tmp == null)
                return 1;
            else
                return tmp.Film_FilmTypeId + 1;
        }

        public void SaveType(string filmId, string mode)
        {
            if (filmId == string.Empty)
                return;
            //放映模式下拉框所选择的模式内容
            Array Array = mode.Replace(" ", "").Split(',');

            foreach (string str in Array)
            {
                if (str == string.Empty)
                    continue;
                //查找对应的模式记录
                FilmType filmType = de.FilmType.Where(p => p.FilmTypeName == str).FirstOrDefault();

                if (filmType != null)
                {

                    Film_FilmType film_FilmType = de.Film_FilmType.Where(p => p.FilmId == filmId && p.FilmTypeId == filmType.FilmTypeId).FirstOrDefault();

                    //如果不存在，则进行新增操作
                    if (film_FilmType == null)
                    {
                        if (tmpFilm_FilmTypeList.Where(p => p.FilmId == filmId && p.FilmTypeId == filmType.FilmTypeId).FirstOrDefault() == null
                            && de.Film_FilmType.Where(p => p.FilmId == filmId && p.FilmTypeId == filmType.FilmTypeId).FirstOrDefault() == null)
                        {
                            film_FilmType = new Film_FilmType();
                            film_FilmType.FilmTypeId = filmType.FilmTypeId;
                            film_FilmType.FilmId = filmId;
                            film_FilmType.Created = DateTime.Now;
                            film_FilmType.Updated = DateTime.Now;
                            film_FilmType.ActiveFlag = true;
                            film_FilmType.Film_FilmTypeId = MaxTypeId();
                            //  de.Film_FilmMode.AddObject(film_FilmMode);
                            tmpFilm_FilmTypeList.Add(film_FilmType);
                        }
                    }
                }
            }

            //找出该影片的所有模式关系记录
            var list = de.Film_FilmType.Where(p => p.FilmId == filmId).ToList();

            list.AddRange(tmpFilm_FilmTypeList);

            //所有的放映模式
            var filmFilmTypeList = de.FilmType.ToList();

            foreach (var tmp in list)
            {
                //是否删除标志
                bool del = true;

                var obj = filmFilmTypeList.Find(p => p.FilmTypeId == tmp.FilmTypeId);
                if (obj != null)
                {
                    foreach (string str in Array)
                    {
                        if (obj.FilmTypeName == str)
                        {
                            del = false;
                            break;
                        }
                    }

                    if (del == true)
                    {
                        var deltmp = de.Film_FilmType.Where(p => p.Film_FilmTypeId == tmp.Film_FilmTypeId).FirstOrDefault();
                        if (deltmp != null)
                        {
                            de.Film_FilmType.DeleteObject(deltmp);
                        }
                    }
                }
            }
        }
        public void SaveMode(string filmId, string mode)
        {
            if (filmId == string.Empty)
                return;

            //放映模式下拉框所选择的模式内容
            Array Array = mode.Replace(" ", "").Split(',');

            foreach (string str in Array)
            {
                if (str == string.Empty)
                    continue;
                //查找对应的模式记录
                FilmMode filmMode = de.FilmMode.Where(p => p.FilmModeName == str).FirstOrDefault();

                if (filmMode != null)
                {
                    //查找影片的模式关系记录
                    Film_FilmMode film_FilmMode = de.Film_FilmMode.Where(p => p.FilmId == filmId && p.FilmModeId == filmMode.FilmModeId).FirstOrDefault();

                    //如果不存在，则进行新增操作
                    if (film_FilmMode == null)
                    {
                        if (tmpList.Where(p => p.FilmId == filmId && p.FilmModeId == filmMode.FilmModeId).FirstOrDefault() == null)
                        {
                            film_FilmMode = new Film_FilmMode();
                            film_FilmMode.FilmModeId = filmMode.FilmModeId;
                            film_FilmMode.FilmId = filmId;
                            film_FilmMode.Created = DateTime.Now;
                            film_FilmMode.Updated = DateTime.Now;
                            film_FilmMode.ActiveFlag = true;
                            film_FilmMode.Film_FilmModeId = MaxId();
                            //  de.Film_FilmMode.AddObject(film_FilmMode);
                            tmpList.Add(film_FilmMode);
                        }


                    }
                }
            }

            //找出该影片的所有模式关系记录
            var list = de.Film_FilmMode.Where(p => p.FilmId == filmId).ToList();

            list.AddRange(tmpList);

            //所有的放映模式
            var filmModeList = de.FilmMode.ToList();

            foreach (var tmp in list)
            {
                //是否删除标志
                bool del = true;

                //放映模式
                var obj = filmModeList.Find(p => p.FilmModeId == tmp.FilmModeId);
                if (obj != null)
                {
                    foreach (string str in Array)
                    {
                        if (obj.FilmModeName == str)
                        {
                            del = false;
                            break;
                        }
                    }

                    if (del == true)
                    {
                        var deltmp = de.Film_FilmMode.Where(p => p.Film_FilmModeId == tmp.Film_FilmModeId).FirstOrDefault();
                        if (deltmp != null)
                        {
                            if (delListCheck.Where(p => p.FilmId == deltmp.FilmId).FirstOrDefault() == null)
                                delListCheck.Add(de.Film.Where(p => p.FilmId == deltmp.FilmId).FirstOrDefault());

                            de.Film_FilmMode.DeleteObject(deltmp);
                        }
                    }
                }
            }

        }

        private void DelNULL()
        {
            DelModeNULL();

            DelTypeNULL();
        }

        private void DelModeNULL()
        {
            var list = de.Film_FilmMode.Where(p => p.FilmModeId == null || p.FilmId == null || p.Film_FilmModeId == null).ToList();

            if (list.Count > 0)
            {
                if (delListCheck.Where(p => p.FilmId == list.FirstOrDefault().FilmId).FirstOrDefault() == null)
                    delListCheck.Add(de.Film.Where(p => p.FilmId == list.FirstOrDefault().FilmId).FirstOrDefault());

            }
            foreach (var tmp in list)
            {
                de.Film_FilmMode.DeleteObject(tmp);
            }

            var filmList = de.Film.ToList();
            var film_Mode = de.FilmMode.ToList();
            foreach (var tmp in filmList)
            {
                foreach (var obj in film_Mode)
                {

                    var dellist = de.Film_FilmMode.Where(p => p.FilmId == tmp.FilmId && p.FilmModeId == obj.FilmModeId).ToList();
                    int i = dellist.Count;

                    if (i > 0)
                    {
                        if (delListCheck.Where(p => p.FilmId == dellist.FirstOrDefault().FilmId).FirstOrDefault() == null)
                            delListCheck.Add(de.Film.Where(p => p.FilmId == dellist.FirstOrDefault().FilmId).FirstOrDefault());

                    }
                    foreach (var deltmp in dellist)
                    {
                        if (i > 1)
                            i--;
                        de.Film_FilmMode.DeleteObject(deltmp);
                    }

                }
            }
        }
        private void DelTypeNULL()
        {
            var list = de.Film_FilmType.Where(p => p.FilmId == null || p.FilmTypeId == null || p.Film_FilmTypeId == null).ToList();
            foreach (var tmp in list)
                de.Film_FilmType.DeleteObject(tmp);

            var filmList = de.Film.ToList();
            var film_Type = de.FilmType.ToList();
            foreach (var tmp in filmList)
            {
                foreach (var obj in film_Type)
                {
                    var dellist = de.Film_FilmType.Where(p => p.FilmId == tmp.FilmId && p.FilmTypeId == obj.FilmTypeId).ToList();
                    int i = dellist.Count;

                    foreach (var deltmp in dellist)
                    {
                        if (i > 1)
                            i--;
                        de.Film_FilmType.DeleteObject(deltmp);

                    }

                }
            }
        }
        private void Addtmp()
        {
            foreach (var tmp in tmpList)
            {
                de.Film_FilmMode.AddObject(tmp);
                var tmpobj = de.Film.Where(p => p.FilmId == tmp.FilmId).FirstOrDefault();
                tmpobj.HasMode = true;
            }

            foreach (var tmp in tmpFilm_FilmTypeList)
                de.Film_FilmType.AddObject(tmp);

        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Film> GetSearchList(string columnName, string value)
        {
            return de.Film.Where(p => p.FilmName.Contains(value) == true).ToList();
          //  return de.ExecuteStoreQuery<Film>(string.Format(@"SELECT * FROM Film WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        /// 判断是否存在filmId的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Film IsCreated(string filmId)
        {
            return de.Film.Where(p => p.FilmId == filmId).FirstOrDefault();
        }

        public Film NewData()
        {
            // 获取新Id（将数据表里的Id最大值+1）
            string lastId;

            Film lastData = de.ExecuteStoreQuery<Film>(@"SELECT * FROM Film ORDER BY FilmId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FilmId;
            }
            else
            {
                lastId = "0";
            }

            string newId;
            // 生成新的Id（这里长度是12位）
            try
            {
                newId = string.Format("{0:D12}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D12}", 1);
            }

            Film data = new Film();
            data.FilmId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 更新非String类型的值，优化速度
            data.PublishDate = DateTime.Now;
            data.FilmLength = 0;
            data.Ratio = 0;
            data.LowestPrice = 0;
            data.HasMode = false;

            de.Film.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(Film data)
        {
            de.Film.DeleteObject(data);
        }

        /// <summary>
        /// 更新关联表:Film_FIlmMode
        /// </summary>
        private void UpdateFilm_FIlmMode()
        {
            List<Film> filmList = de.Film.Where(p => p.HasMode == true).ToList();

            foreach (Film film in filmList)
            {
                Film_FilmMode mode = de.Film_FilmMode.Where(p => p.FilmId == film.FilmId).FirstOrDefault();

                if (mode == null)
                {
                    Film_FilmMode lastData = de.Film_FilmMode.OrderByDescending(p => p.Film_FilmModeId).FirstOrDefault();

                    int lastId;

                    if (lastData != null)
                        lastId = lastData.Film_FilmModeId;
                    else
                        lastId = 0;

                    // 生成原声的Film_FilmMode
                    mode = new Film_FilmMode();
                    mode.Film_FilmModeId = lastId + 1;
                    mode.FilmId = film.FilmId;
                    mode.FilmModeId = 1;
                    mode.Film = film;
                    mode.Created = DateTime.Now;
                    mode.Updated = mode.Created;
                    mode.ActiveFlag = true;

                    de.Film_FilmMode.AddObject(mode);

                    lastId += 1;

                    // 生成中文的Film_FilmMode
                    mode = new Film_FilmMode();
                    mode.Film_FilmModeId = lastId + 1;
                    mode.FilmId = film.FilmId;
                    mode.FilmModeId = 2;

                    mode.Created = DateTime.Now;
                    mode.Updated = mode.Created;
                    mode.ActiveFlag = true;

                    de.Film_FilmMode.AddObject(mode);
                }
            }

            de.SaveChanges();
        }

        public void ReClickHasMode()
        {
            //所有的放映模式
            var filmModeList = de.FilmMode.ToList();

            var list = de.Film.ToList();

            foreach (var tmp in list)
            {
                var tmpList = de.Film_FilmMode.Where(p => p.FilmId == tmp.FilmId).ToList();

                if (tmpList.Count <= 0)
                    tmp.HasMode = false;
                else
                {
                    tmp.HasMode = true;

                    foreach (var obj in filmModeList)
                    {
                        int i = tmpList.Where(p => p.FilmModeId == obj.FilmModeId).ToList().Count;
                        while (i > 1)
                        {
                            i--;
                            de.Film_FilmMode.DeleteObject(tmpList.Where(p => p.FilmModeId == obj.FilmModeId).FirstOrDefault());
                        }

                    }

                }
            }

            var tmpLists = de.Film_FilmMode.ToList();
            while (tmpLists.Remove(tmpLists.Where(P => P.FilmModeId == 0 || P.FilmId == null).FirstOrDefault())) ;
        }

        private void CheckHashMode()
        {
            foreach (var film in delListCheck)
            {
                if (film.FilmId != null && film.FilmId != string.Empty)
                    film.HasMode = de.Film_FilmMode.Where(p => p.FilmId == film.FilmId).FirstOrDefault() != null ? true : false;
            }
        }

        public void Save()
        {
            // 设置事务参数
            TransactionOptions transactionOption = new TransactionOptions();

            // 设置事务隔离级别 
            transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            // 设置事务超时时间为60秒 
            transactionOption.Timeout = new TimeSpan(0, 60, 0);

            // 写入数据库
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, transactionOption))
            {
                // 保存到数据库，如果遇到开放式冲突，则以本地数据为准
                try
                {
                    Addtmp();
                    // DelNULL();

                    de.SaveChanges();
                    CheckHashMode();
                    de.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    de.Refresh(RefreshMode.ClientWins, de.Film);

                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //   UpdateFilm_FIlmMode();

                ts.Complete();
            }
        }

        #endregion

        /// <summary>
        /// 查询所有上映影片
        /// </summary>
        public List<Film> GetShowList()
        {
            return de.Film.ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Data.Objects;

namespace Flamingo.FilmManage
{
    public class FilmDownloadManage : IDataManage<FilmDownloadInfo>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        private List<FilmDownloadInfo> downloadList;

        private string year;

        public FilmDownloadManage()
        {
            de = Database.GetNewDataEntity();

            downloadList = new List<FilmDownloadInfo>();
        }

        public List<DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("Check", "选中"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ID", "影片编码"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Name", "影片名称", 220));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("PublishDate", "发布日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Publisher", "发行商"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Producer", "制片人"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Director", "导演"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Cast", "演职员列表"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Brief", "影片简介"));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "ID":
                            case "Name":
                            case "PublishDate":
                            case "Publisher":
                            case "Producer":
                            case "Director":
                            case "Cast":
                            case "Brief":
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

        #region 无用的方法

        public List<FilmDownloadInfo> GetSearchList(string columnName, string value) { throw new NotImplementedException(); }

        public FilmDownloadInfo NewData() { throw new NotImplementedException(); }

        public void DeleteData(FilmDownloadInfo data) { throw new NotImplementedException(); }

        public void Save() { throw new NotImplementedException(); }

        #endregion

        public List<FilmDownloadInfo> GetDataList()
        {
            return this.downloadList;
        }

        public List<FilmDownloadInfo> GetSearchList(string value)
        {
            for (int i = 0; i < this.downloadList.Count; i++)
                downloadList[i].Check = false;

            return this.downloadList.Where(p => p.Name.Contains(value.Trim())).ToList();
        }

        public void Import()
        {
            List<FilmDownloadInfo> importList = this.downloadList.Where(p => p.Check == true).ToList();

            List<Film> filmList = de.Film.ToList();
            List<FilmCategory> filmCategoryList = de.FilmCategory.ToList();
            List<FilmArea> filmAreaList = de.FilmArea.ToList();

            foreach (FilmDownloadInfo filmDown in importList)
            {
                Film film = filmList.Where(p => p.FilmCode.Trim() == filmDown.ID).FirstOrDefault();

                if (film == null)
                {
                    film = new Film();

                    // 生成新的Id（这里长度是12位）
                    // 2011.12.30, Jiang, 生成规则：影片编号+年份
                    film.FilmId = filmDown.ID + year;

                    de.Film.AddObject(film);

                    try
                    {
                        film.FilmCode = filmDown.ID;
                    }
                    catch { }

                    try
                    {
                        film.FilmName = filmDown.Name;
                    }
                    catch { }

                    try
                    {
                        film.FilmAreaId = filmDown.ID.Substring(0, 3);
                    }
                    catch { }

                    if (filmAreaList.Where(p => p.FilmAreaId == film.FilmAreaId).FirstOrDefault() == null)
                        throw new Exception(string.Format("导入影片 \"{0}:{1}\" 失败，原因为：影片产地 \"{2}\" 不存在!", film.FilmId, film.FilmName, film.FilmAreaId));

                    try
                    {
                        film.FilmCategoryId = filmDown.ID.Substring(3, 1);
                    }
                    catch { }

                    if (filmCategoryList.Where(p => p.FilmCategoryId == film.FilmCategoryId).FirstOrDefault() == null)
                        throw new Exception(string.Format("导入影片 \"{0}:{1}\" 失败，原因为：影片分类 \"{2}\" 不存在!", film.FilmId, film.FilmName, film.FilmCategoryId));

                    // 添加默认值
                    film.HasMode = false;
                    film.FilmLength = 0;

                    //2011.12.30, Jiang, 这里现在不需要赋值，赋上空值，优化速度
                    film.Publisher = string.Empty;
                    film.Producer = string.Empty;
                    film.Director = string.Empty;
                    film.Cast = string.Empty;
                    film.Brief = string.Empty;

                    try
                    {
                        if (string.IsNullOrWhiteSpace(filmDown.PublishDate) != true)
                            film.PublishDate = Convert.ToDateTime(filmDown.PublishDate);
                    }
                    catch { }
                }
            }

            try
            {
                de.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                de.Refresh(RefreshMode.ClientWins, de.Film);

                de.SaveChanges();
            }
        }

        public void Download(string year)
        {
            this.downloadList.Clear();

            WebClient webClient = new WebClient();
            byte[] data = webClient.DownloadData(GetDownloadUrl(year));
            MemoryStream stream = new MemoryStream(data);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            this.downloadList = GetDataFromXML(xmlDoc);

            this.year = year;
        }

        private List<FilmDownloadInfo> GetDataFromXML(XmlDocument xmlDoc)
        {
            List<FilmDownloadInfo> list = new List<FilmDownloadInfo>();

            XmlNodeList xmlFilmList = xmlDoc.DocumentElement.ChildNodes;

            foreach (XmlElement listNode in xmlFilmList)
            {
                FilmDownloadInfo filmInfo = new FilmDownloadInfo();
                filmInfo.Check = false;

                XmlNodeList xmlFilmInfo = listNode.ChildNodes;

                foreach (XmlElement node in xmlFilmInfo)
                {
                    if (node.Name == "ID") filmInfo.ID = node.InnerText;
                    if (node.Name == "Name") filmInfo.Name = node.InnerText;
                    if (node.Name == "PublishDate") filmInfo.PublishDate = node.InnerText;
                    if (node.Name == "Publisher") filmInfo.Publisher = node.InnerText;
                    if (node.Name == "Producer") filmInfo.Producer = node.InnerText;
                    if (node.Name == "Director") filmInfo.Director = node.InnerText;
                    if (node.Name == "Cast") filmInfo.Cast = node.InnerText;
                    if (node.Name == "Brief") filmInfo.Brief = node.InnerText;
                }

                list.Add(filmInfo);
            }

            return list;
        }

        private string GetDownloadUrl(string year)
        {
            string url;

            DownloadSetting downSet;

            switch (Property.Setting.DownloadMethod.Trim())
            {
                case "HTTP":
                    downSet = de.DownloadSetting.Where(p => p.DownloadMethod.Trim() == "HTTP").FirstOrDefault();
                    break;

                case "FTP":
                    downSet = de.DownloadSetting.Where(p => p.DownloadMethod.Trim() == "FTP").FirstOrDefault();
                    break;

                case "FILE":
                    downSet = de.DownloadSetting.Where(p => p.DownloadMethod.Trim() == "文件方式").FirstOrDefault();
                    break;

                default:
                    downSet = de.DownloadSetting.Where(p => p.DownloadMethod.Trim() == "HTTP").FirstOrDefault();
                    break;
            }

            if (downSet == null)
                throw new Exception("生成下载地址失败，请检查下载设置！");

            url = downSet.DownloadAddr;

            string yearPara = Property.Setting.YearPara;

            url = url.Replace(yearPara, year);

            return url;
        }
    }
}

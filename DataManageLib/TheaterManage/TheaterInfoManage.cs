using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public class TheaterInfoManage : IDataManage<Theater>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;



        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public TheaterInfoManage()
        {
            de = Database.GetNewDataEntity();
        }


        /// <summary>
        /// 静态变量，直接获取所有影片产地数据
        /// </summary>
        /// <returns></returns>
        public static List<Theater> DirectGetAllList()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            ////List<Theater> list = de.Theater.ToList();
            //List<Theater> list = de.Theater.ToList();
            return de.Theater.ToList();
        }

        #region     IDataManage<Theater>成员

        /// <summary>
        /// 获取列信息表
        /// </summary>
        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    //    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterTypeId", "影院类型"));

                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterType", "影院名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Corporation", "法人代表"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Telephone", "联系电话"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ContactPeople", "联系人"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Halls", "影厅数量"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Seats", "总座位数"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Province", "省"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("City", "市"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("District", "区"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("PostCode", "邮编"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Address", "地址"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterCode", "影院编码"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CineChainId", "所属院线公司"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SerialNumber", "影院使用的软件序列号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Ratio", "片方分账比例"));



                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];


                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "TheaterId":
                            case "TheaterType":
                            case "Corporation":
                            case "Telephone":
                            case "TheaterName":
                            case "ContactPeople":
                            case "Halls":
                            case "Seats":
                            case "Province":
                            case "City":
                            case "District":
                            case "PostCode":
                            case "Address":
                            case "TheaterCode":
                            case "CineChainId":
                            case "SerialNumber":
                            case "Ratio":
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

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<Theater> GetDataList()
        {

            return de.Theater.ToList();

        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Theater> GetSearchList(string columnName, string value)
        {

            return de.Theater.ToList();

        }

        public List<Module> GetmoduleList()
        {
            return de.Module.ToList();
        }

        public Theater NewData()
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Theater data)
        {
            throw new NotImplementedException();
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

                ts.Complete();
            }
        }

        #endregion



        public void SetInfo(DataSet ds)
        {
            DateTime starttime;
            DateTime endTime;

            try
            {
                starttime = Convert.ToDateTime(ds.Tables["dtTime"].Rows[0]["StartTime"].ToString());
                endTime = Convert.ToDateTime(ds.Tables["dtTime"].Rows[0]["EndTime"].ToString());
            }
            catch
            {
                throw new NotImplementedException("授权文件起始时间和截止时间设置不正确，无法将该文件导进！");
            }

            if ((starttime > DateTime.Now)
                || (endTime < DateTime.Now))
                throw new NotImplementedException("不在授权文件的有效期内，无法将该文件导进！");


            try
            {
                List<Module> moduleList = GetmoduleList();
                foreach (DataRow dr in ds.Tables["dtModule"].Rows)
                {
                    var tmp = moduleList.Find(p => p.ModuleName == dr["Name"].ToString());
                    tmp.ActiveFlag = dr["Value"].ToString() == "1" ? true : false;
                }
            }
            catch { }

            Theater theater = de.Theater.FirstOrDefault();
            List<Hall> hallList = new List<Hall>();
            if (theater == null)
            {
                theater = new Theater();
                try
                {
                    theater.TheaterId = ds.Tables["TheaterInformation"].Rows[0]["TheaterId"].ToString();
                }
                catch { }
                de.Theater.AddObject(theater);
            }


            try
            {
                theater.TheaterName = ds.Tables["TheaterInformation"].Rows[0]["TheaterName"].ToString();
            }
            catch { }

            try
            {
                theater.TheaterType = ds.Tables["TheaterInformation"].Rows[0]["TheaterType"].ToString();
            }
            catch { }

            try
            {
                theater.Corporation = ds.Tables["TheaterInformation"].Rows[0]["Corporation"].ToString();
            }
            catch { }

            try
            {
                theater.Telephone = ds.Tables["TheaterInformation"].Rows[0]["Telephone"].ToString();
            }
            catch { }

            try
            {
                theater.Manager = ds.Tables["TheaterInformation"].Rows[0]["Manager"].ToString();
            }
            catch { }
            try
            {
                theater.Halls = Convert.ToInt32(ds.Tables["TheaterInformation"].Rows[0]["Halls"].ToString());
            }
            catch { }

            try
            {
                theater.Seats = Convert.ToInt32(ds.Tables["TheaterInformation"].Rows[0]["Seats"].ToString());
            }
            catch { }
            try
            {
                theater.Province = ds.Tables["TheaterInformation"].Rows[0]["Province"].ToString();
            }
            catch { }
            try
            {
                theater.City = ds.Tables["TheaterInformation"].Rows[0]["City"].ToString();
            }
            catch { }
            try
            {
                theater.District = ds.Tables["TheaterInformation"].Rows[0]["District"].ToString();
            }
            catch { }
            try
            {
                theater.PostCode = ds.Tables["TheaterInformation"].Rows[0]["PostCode"].ToString();
            }
            catch { }
            try
            {
                theater.Address = ds.Tables["TheaterInformation"].Rows[0]["Address"].ToString();
            }
            catch { }
            try
            {
                theater.TheaterCode = ds.Tables["TheaterInformation"].Rows[0]["TheaterCode"].ToString();
            }
            catch { }
            try
            {
                theater.CineChainId = ds.Tables["TheaterInformation"].Rows[0]["CineChainId"].ToString();
            }
            catch { }
            try
            {
                theater.SerialNumber = ds.Tables["TheaterInformation"].Rows[0]["SerialNumber"].ToString();
            }
            catch { }
            try
            {
                theater.Rating = ds.Tables["TheaterInformation"].Rows[0]["Rating"].ToString();
            }
            catch { }
            try
            {
                theater.Fax = ds.Tables["TheaterInformation"].Rows[0]["Fax"].ToString();
            }
            catch { }
            try
            {
                theater.Mobile = ds.Tables["TheaterInformation"].Rows[0]["Mobile"].ToString();
            }
            catch { }
            try
            {
                theater.Version = ds.Tables["TheaterInformation"].Rows[0]["Version"].ToString();
            }
            catch { }

            try
            {
                theater.Created = Convert.ToDateTime(ds.Tables["TheaterInformation"].Rows[0]["Created"].ToString());
            }
            catch { }
            try
            {
                theater.Updated = Convert.ToDateTime(ds.Tables["TheaterInformation"].Rows[0]["Updated"].ToString());
            }
            catch { }
            try
            {
                theater.ServerModle = ds.Tables["TheaterInformation"].Rows[0]["ServerModle"].ToString();
            }
            catch { }
            try
            {
                theater.ServerCPU = ds.Tables["TheaterInformation"].Rows[0]["ServerCPU"].ToString();
            }
            catch { }
            try
            {
                theater.ServerMemory = ds.Tables["TheaterInformation"].Rows[0]["ServerMemory"].ToString();
            }
            catch { }
            try
            {
                theater.ServerHardDriver = ds.Tables["TheaterInformation"].Rows[0]["ServerHardDriver"].ToString();
            }
            catch { }
            try
            {
                theater.Clients =Convert.ToInt32(ds.Tables["TheaterInformation"].Rows[0]["Clients"].ToString());
            }
            catch { }

            Hall hallInfo = new Hall();
            foreach (DataRow tmp in ds.Tables["HallInformation"].Rows)
            {
                string id = tmp["HallId"].ToString();
                hallInfo = de.Hall.Where(p => p.HallId == id).FirstOrDefault();

                if (hallInfo == null)
                {
                    hallInfo = new Hall();
                    try
                    {
                        hallInfo.HallId = tmp["HallId"].ToString();
                    }
                    catch { }
                    de.Hall.AddObject(hallInfo);
                }

                try
                {
                    hallInfo.TheaterId = tmp["TheaterId"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.HallName = tmp["HallName"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Seats = Convert.ToInt32(tmp["Seats"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Levels = Convert.ToInt32(tmp["Levels"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Screen = tmp["Screen"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Projector = tmp["Projector"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.PlayMode = tmp["PlayMode"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.SoundSystem = tmp["SoundSystem"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Description = tmp["Description"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Created = Convert.ToDateTime(tmp["Created"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Updated = Convert.ToDateTime(tmp["Updated"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.ActiveFlag = Convert.ToBoolean(tmp["ActiveFlag"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.BarColour = tmp["BarColour"].ToString();
                }
                catch { }
            }

            try
            {
                de.SaveChanges();
            }
            catch (Exception ex) { throw new NotImplementedException(ex.Message); }

        }
    }
}

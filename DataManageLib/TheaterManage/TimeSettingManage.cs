using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;
using System.Windows.Forms;


namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public class TimeSettingManage : IDataManage<TimeSetting>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        //private List<TimeSettingAndTheater> timeSettingAndTheater = new List<TimeSettingAndTheater>();

        public TimeSettingManage()
        {
            de = Database.GetNewDataEntity();
        }



        #region   IDataManage<TimeSetting> 成员
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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("TimeSettingId", "时间设定ID"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterName", "影院编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("RepeatDay", "重复时间"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("OpenTime", "经营起始时间", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CloseTime", "经营截止时间", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("RefundDeadline", "退票截止时间", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BookingReleaseTime", "售票截止时间", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TicketingDeadline", "预订释放时间", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Timespan", "默认场次间隔", 110));




                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        //colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;             
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "TimeSettingId":
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
        public List<TimeSetting> GetDataList()
        {
            return de.TimeSetting.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<TimeSetting> GetSearchList(string columnName, string value)
        {
            return de.TimeSetting.Where(p => p.RepeatDay.Contains(value) == true).ToList();
            // return de.ExecuteStoreQuery<TimeSetting>(string.Format(@"SELECT * FROM TimeSetting WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public TimeSetting IsCreated(int id)
        {
            return de.TimeSetting.Where(p => p.TimeSettingId == id).FirstOrDefault();
        }

        public TimeSetting NewData()
        {
            // 使用创建时间先后来获取最后ID
            int lastId;
            TimeSetting lastData = de.ExecuteStoreQuery<TimeSetting>(@"SELECT * FROM TimeSetting ORDER BY TimeSettingId*1 DESC LIMIT 1").FirstOrDefault();
            Theater theater = de.Theater.FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.TimeSettingId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            TimeSetting data = new TimeSetting();
            data.TimeSettingId = Convert.ToInt32(newId);

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;
            //
            data.TheaterId = theater.TheaterId;

            data.RefundDeadline = -1;
            data.TicketingDeadline = -1;
            data.Timespan = 0;
            data.BookingReleaseTime = -1;
            data.RepeatDay = "";
            //

            data.OpenTime = new TimeSpan(9, 0, 0);
            data.CloseTime = new TimeSpan(8, 59, 59);
            //data.OpenTime = new TimeSpan(9, 0, 0);
            //data.CloseTime = data.Created - data.Updated; 

            de.TimeSetting.AddObject(data);
            de.SaveChanges();

            return data;
        }

        public void DeleteData(TimeSetting data)
        {
            if (data != null)
                de.TimeSetting.DeleteObject(data);
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
    }
}

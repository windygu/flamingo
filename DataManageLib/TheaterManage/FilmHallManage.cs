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
    public class FilmHallManage : IDataManage<Hall>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        public FilmHallManage()
        {
            de = Database.GetNewDataEntity();
        }


     
        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

      

        #region IDataManage<Hall>成员
        
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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("HallId", "影厅编号"));
                   // this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));

             //       this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterName", "影院名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("HallName", "影厅名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Seats", "座位数量"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Levels", "楼层数量"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Screen", "银幕"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Projector", "放映机"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("PlayMode", "放映模式"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SoundSystem", "声音模式"));




                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "HallId":
                            case "TheaterId":
                            case "TheaterName":
                            case "Seats":
                            case "Levels":
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
        public List<Hall> GetDataList()
        {
            return de.Hall.ToList();
        }


        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Hall> GetSearchList(string columnName, string value)
        {
          //  return de.ExecuteStoreQuery<Hall>(string.Format(@"SELECT * FROM Hall WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
            return de.Hall .Where(p => p.HallName .Contains(value) == true).ToList();
        }

        public Hall NewData()
        {
            // 使用创建时间先后来获取最后ID
            string lastId;
            Hall lastData = de.ExecuteStoreQuery<Hall>(@"SELECT * FROM Hall ORDER BY HallId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.HallId;
            }
            else
            {
                lastId = "0";
            }

            string newId;
            // 生成新的Id（这里长度是2位）
            try
            {
                newId = string.Format("{0:D2}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D2}", 1);
            }

            Hall data = new Hall();
            data.HallId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            de.Hall.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(Hall data)
        {
             de.Hall.DeleteObject(data);
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

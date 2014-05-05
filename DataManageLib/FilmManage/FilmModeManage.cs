using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;

namespace Flamingo.FilmManage
{
    //2011/12/20,Qiu
    public class FilmModeManage : IDataManage<FilmMode>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public FilmModeManage()
        {

            de = Database.GetNewDataEntity();

        }



        #region   IDataManage<FilmMode>成员
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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmModeId", "放映模式编号", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmModeName", "放映模式名称"));



                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FilmModeId":
                                //       case "FilmModeName":
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
        public List<FilmMode> GetDataList()
        {
            return de.FilmMode.ToList();
        }

        /// <summary>
        ///根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<FilmMode> GetSearchList(string columnName, string value)
        {
            return de.FilmMode .Where(p => p.FilmModeName.Contains(value) == true).ToList();
          //  return de.ExecuteStoreQuery<FilmMode>(string.Format(@"SELECT * FROM FilmMode WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public FilmMode NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            int lastId;
            FilmMode lastData = de.ExecuteStoreQuery<FilmMode>(@"SELECT * FROM FilmMode ORDER BY FilmModeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FilmModeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            FilmMode data = new FilmMode();
            data.FilmModeId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度
            data.FilmModeName = string.Empty;
            de.FilmMode.AddObject(data);

            de.SaveChanges();

            return data;

        }

        public void DeleteData(FilmMode data)
        {
            de.FilmMode.DeleteObject(data);
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

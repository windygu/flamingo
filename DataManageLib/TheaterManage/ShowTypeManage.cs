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
    public  class ShowTypeManage:IDataManage<ShowType>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;


        public ShowTypeManage() {
            de = Database.GetNewDataEntity();
        }

        #region   IDataManage<ShowType>成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("ShowTypeId", "场次类型编号",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ShowTypeName", "场次类型名称",110));
                  


                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        //colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;       
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "ShowTypeId":
                     //       case "ShowTypeName":
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
        public List<ShowType> GetDataList()
        {
            return de.ShowType.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<ShowType> GetSearchList(string columnName, string value)
        {
            return de.ShowType .Where(p => p.ShowTypeName .Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<ShowType>(string.Format(@"SELECT * FROM ShowType WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public ShowType IsCreated(int id)
        {
            return de.ShowType.Where(p => p.ShowTypeId == id).FirstOrDefault();
        }

        public ShowType NewData()
        {
            int lastId;
            ShowType lastData = de.ExecuteStoreQuery<ShowType>(@"SELECT * FROM ShowType ORDER BY ShowTypeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.ShowTypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            ShowType data = new ShowType();
            data.ShowTypeId =newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            de.ShowType.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(ShowType data)
        {
            if(data!=null)
             de.ShowType.DeleteObject(data);
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

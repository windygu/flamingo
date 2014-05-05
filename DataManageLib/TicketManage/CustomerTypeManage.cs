using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;

namespace Flamingo.TicketManage
{
    //2011/12/21,Qiu
    public class CustomerTypeManage : IDataManage<CustomerType>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public CustomerTypeManage()
        {
            de = Database.GetNewDataEntity();
        }


        #region  IDataManage<CustomerType>成员
        //获取列信息表
        public List<DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerTypeId", "客户类型编号",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerTypeName", "客户类型名称"));

                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "CustomerId":
                                colInfo.IsReadOnly = true;
                                break;
                        }
                        //保存属性设置
                        this.columnInfoList[i] = colInfo;
                    }
                }
                return this.columnInfoList;
            }
        }

        public List<CustomerType> GetDataList()
        {
            return de.CustomerType.ToList();
        }

        public List<CustomerType> GetSearchList(string columnName, string value)
        {
            return de.CustomerType .Where(p => p.CustomerTypeName .Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<CustomerType>(string.Format(@"SELECT * FROM CustomerType WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public CustomerType NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            int lastId;
            CustomerType lastData = de.ExecuteStoreQuery<CustomerType>(@"SELECT * FROM CustomerType ORDER BY CustomerTypeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.CustomerTypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            CustomerType data = new CustomerType();
            data.CustomerTypeId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度

            de.CustomerType.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(CustomerType data)
        {
            de.CustomerType.DeleteObject(data);
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

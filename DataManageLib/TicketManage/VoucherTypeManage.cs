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
    //2011.12.22 LIN
    public class VoucherTypeManage : IDataManage<VoucherType>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public VoucherTypeManage()
        {
            de = Database.GetNewDataEntity();
        }

        #region IDataManage<CustomerType>成员
        //获取列信息表
        public List<DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherTypeId", "票卷类型编号", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherTypeName", "票卷类型名称"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("Created", "票卷创建日期"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("Updated", "票卷更新日期"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("ActiveFlag", "状态"));

                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "VoucherTypeId":
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



        public List<VoucherType> GetDataList()
        {
            return de.VoucherType.ToList();
        }

        public VoucherType NewData()
        {
            // 获取新Id
            int lastId;
            VoucherType lastData = de.ExecuteStoreQuery<VoucherType>(@"SELECT * FROM VoucherType ORDER BY VoucherTypeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.VoucherTypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            VoucherType data = new VoucherType();
            data.VoucherTypeId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度

            de.VoucherType.AddObject(data);

            de.SaveChanges();

            return data;

        }

        /// <summary>
        /// 获取模糊查询的值
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<VoucherType> GetSearchList(string columnName, string value)
        {
          //  return de.VoucherType.Where(p => p.VoucherTypeName.Contains(value)).ToList();
            return de.VoucherType .Where(p => p.VoucherTypeName .Contains(value) == true).ToList();
        }

        public void DeleteData(VoucherType data)
        {
            de.VoucherType.DeleteObject(data);
        }

        #endregion
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




    }
}

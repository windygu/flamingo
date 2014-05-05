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
    //2011.12.21 LIN
    //2011.12.23,Qiu
    public class VoucherTypeSubManage : IDataManage<VoucherSubType>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;


        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public VoucherTypeSubManage()
        {
            de = Database.GetNewDataEntity();
            
        }

        #region    IDataManage<VoucherSubType>成员

        public List<DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherSubTypeId", "票卷类型编号",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherSubTypeName", "票卷类型名称"));

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
                            case "VoucherSubTypeId":
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

        //获取票卷子类的明细数据
        public List<VoucherSubType> GetDataList()
        {
            return de.VoucherSubType.ToList();
        }

        /// <summary>
        /// 获取模糊查询的值
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<VoucherSubType> GetSearchList(string columnName, string value)
        {
            return de.VoucherSubType .Where(p => p.VoucherSubTypeName .Contains(value) == true).ToList();
            //return de.VoucherSubType.Where(p => p.VoucherSubTypeName.Contains(value)).ToList();
        }

        public VoucherSubType NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            int lastId;
            VoucherSubType lastData = de.ExecuteStoreQuery<VoucherSubType>(@"SELECT * FROM VoucherSubType ORDER BY VoucherSubTypeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.VoucherSubTypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            VoucherSubType data = new VoucherSubType();
            data.VoucherSubTypeId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度

            de.VoucherSubType.AddObject(data);

            de.SaveChanges();

            return data;
        }


        public void DeleteData(VoucherSubType data)
        {
            de.VoucherSubType.DeleteObject(data);
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

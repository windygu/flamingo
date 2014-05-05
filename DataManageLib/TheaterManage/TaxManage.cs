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
    public class TaxManage : IDataManage<Tax>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        //private List<TaxAndTheater> taxAndTheater = new List<TaxAndTheater>();

        public TaxManage()
        {
            de = Database.GetNewDataEntity();
        }


        #region IDataManage<Tax> 成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("TaxId", "税费编号"));
                    // this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    //   this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterName", "影院名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TaxType", "税费类型"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TaxRate", "税率"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ChargeMethod", "扣除方式"));



                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        // colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "TaxId":
                                colInfo.IsReadOnly = true;
                                //case "TheaterName":
                                // colInfo.IsReadOnly = true;
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
        public List<Tax> GetDataList()
        {
            return de.Tax.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Tax> GetSearchList(string columnName, string value)
        {
            return de.Tax .Where(p => p.TaxType.Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<Tax>(string.Format(@"SELECT * FROM Tax WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();

        }

        /// <summary>
        /// 判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tax IsCreated(int id)
        {
            return de.Tax.Where(p => p.TaxId == id).FirstOrDefault();
        }

        public Tax NewData()
        {
            int lastId;
            string threaId;
            Tax lastData = de.ExecuteStoreQuery<Tax>(@"SELECT * FROM Tax ORDER BY TaxId*1 DESC LIMIT 1").FirstOrDefault();
            threaId = de.Theater.Select(p => p.TheaterId).FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.TaxId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            Tax data = new Tax();
            data.TaxId = newId;

            // 更新数据基础值
            data.TheaterId = threaId;
            data.TaxRate = 0;

            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            de.Tax.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(Tax data)
        {
            if (data != null)
                de.Tax.DeleteObject(data);
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

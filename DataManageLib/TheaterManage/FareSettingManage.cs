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
    public class FareSettingManage:IDataManage<FareSetting>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public FareSettingManage() {
            de = Database.GetNewDataEntity();
        }


        #region  IDataManage<FareSetting>成员

        /// <summary>
        ///获取列信息表 
        /// </summary>
        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FareSettingId", "票价设置编号",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FareSettingName", "票价设置名称",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SinglePrice", "单人零售票价",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DoublePrice", "双人零售票价",110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("StudentPrice", "学生票价"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("GroupPrice", "团体票价"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("MemberPrice", "会员定价"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BoxPrice", "包厢票价"));




                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FareSettingId":
                        //    case "FareSettingName":
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
        public List<FareSetting> GetDataList()
        {
            return de.FareSetting.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<FareSetting> GetSearchList(string columnName, string value)
        {
            return de.FareSetting .Where(p => p.FareSettingName.Contains(value) == true).ToList();
            //return de.ExecuteStoreQuery<FareSetting>(string.Format(@"SELECT * FROM FareSetting WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public FareSetting IsCreated(int id)
        {
            return de.FareSetting.Where(p => p.FareSettingId == id).FirstOrDefault();            
        }

        public FareSetting NewData()
        {
            // 获取新Id（将数据表里的Id最大值+1）
            int lastId;

            FareSetting lastData = de.ExecuteStoreQuery<FareSetting>(@"SELECT * FROM FareSetting ORDER BY FareSettingId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FareSettingId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            FareSetting data = new FareSetting();
            data.FareSettingId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            data.SinglePrice = 0;
            data.DoublePrice = 0;
            data.BoxPrice = 0;
            data.StudentPrice = 0;
            data.GroupPrice = 0;
            data.MemberPrice = 0;          

            de.FareSetting.AddObject(data);
            de.SaveChanges();

            return data;
        }

        public void DeleteData(FareSetting data)
        {
            if(data!=null)
            de.FareSetting.DeleteObject(data);   
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

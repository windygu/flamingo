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
    // 2011.12.20, Qiu
    // 2011.12.22, Jiang
    public class FilmTypeManage : IDataManage<FilmType>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public FilmTypeManage()
        {
            de = Database.GetNewDataEntity();
        }

        #region IDataManage<FilmType>成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmTypeId", "影片类型编编号", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmTypeName", "影片类型名称", 110));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FilmTypeId":
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
        public List<FilmType> GetDataList()
        {
            return de.FilmType.ToList();
        }

        ///// <summary>
        ///// 根据条件查询
        ///// </summary>
        ///// <param name="columnName"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        public List<FilmType> GetSearchList(string columnName, string value)
        {
            return de.FilmType .Where(p => p.FilmTypeName .Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<FilmCategory>(string.Format(@"SELECT * FROM FilmCategory WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public FilmType NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            int  lastId;

            FilmType lastData = de.ExecuteStoreQuery<FilmType>(@"SELECT * FROM FilmType ORDER BY FilmTypeId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FilmTypeId;
            }
            else
            {
                lastId = 0;
            }

            string newId;

            // 生成新的Id（这里长度是1位）
            try
            {
                newId = string.Format("{0:D1}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D1}", 1);
            }

            FilmType data = new FilmType();
            data.FilmTypeId =Convert.ToInt32( newId);
            
            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度
            data.FilmTypeName = string.Empty;
            de.FilmType.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(FilmType data)
        {
            de.FilmType.DeleteObject(data);
        }
        private void DeleNull()
        {
            var list = de.FilmType.Where(p =>p.FilmTypeName==null|| p.FilmTypeName == string.Empty || p.FilmTypeName == "").ToList();
            foreach (var tmp in list)
                de.FilmType.DeleteObject(tmp);
            de.SaveChanges();
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
                    DeleNull();
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

        /// <summary>
        /// 静态变量，直接获取所有影片类型数据
        /// </summary>
        /// <returns></returns>
        public static List<FilmType> DirectGetAllList()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<FilmType> list = de.FilmType.ToList();

            return list;
        }
    }
}

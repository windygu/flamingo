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
    public class FilmCategoryManage : IDataManage<FilmCategory>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public FilmCategoryManage()
        {
            de = Database.GetNewDataEntity();
        }

        #region IDataManage<FilmCategory>成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmCategoryId", "影片类型编码", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmCategoryName", "影片类型名称", 110));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FilmCategoryId":
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
        public List<FilmCategory> GetDataList()
        {
            return de.FilmCategory.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<FilmCategory> GetSearchList(string columnName, string value)
        {
            return de.FilmCategory.Where(p => p.FilmCategoryName.Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<FilmCategory>(string.Format(@"SELECT * FROM FilmCategory WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public FilmCategory NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            string lastId;

            FilmCategory lastData = de.ExecuteStoreQuery<FilmCategory>(@"SELECT * FROM FilmCategory ORDER BY FilmCategoryId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FilmCategoryId;
            }
            else
            {
                lastId = "0";
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

            FilmCategory data = new FilmCategory();
            data.FilmCategoryId = newId;
            
            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度
            data.FilmCategoryName = string.Empty;
            de.FilmCategory.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(FilmCategory data)
        {
            de.FilmCategory.DeleteObject(data);
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

        /// <summary>
        /// 静态变量，直接获取所有影片类型数据
        /// </summary>
        /// <returns></returns>
        public static List<FilmCategory> DirectGetAllList()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<FilmCategory> list = de.FilmCategory.ToList();

            return list;
        }
    }
}

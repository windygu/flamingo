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
    public class FilmAreaManage : IDataManage<FilmArea>
    {


        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public FilmAreaManage()
        {

            de = Database.GetNewDataEntity();

        }

        /// <summary>
        /// 静态变量，直接获取所有影片产地数据
        /// </summary>
        /// <returns></returns>
        public static List<FilmArea> DirectGetAllList()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<FilmArea> list = de.FilmArea.ToList();

            return list;
        }


        #region  IDataManage<FilmArea>成员
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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmAreaId", "国别地区编码", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FilmAreaName", "国别地区名称", 110));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "FilmAreaId":
                                //  case "FilmAreaName":
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
        public List<FilmArea> GetDataList()
        {
            return de.FilmArea.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<FilmArea> GetSearchList(string columnName, string value)
        {
            return de.FilmArea.Where(p => p.FilmAreaName.Contains(value) == true).ToList();
          //  return de.ExecuteStoreQuery<FilmArea>(string.Format(@"SELECT * FROM FilmArea WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public FilmArea NewData()
        {
            // 获取新Id（将数据表里的Id最大值+1）
            string lastId;

            FilmArea lastData = de.ExecuteStoreQuery<FilmArea>(@"SELECT * FROM FilmArea ORDER BY FilmAreaId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.FilmAreaId;
            }
            else
            {
                lastId = "0";
            }

            string newId;

            // 生成新的Id（这里长度是3位）
            try
            {
                newId = string.Format("{0:D3}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D3}", 1);
            }

            FilmArea data = new FilmArea();
            data.FilmAreaId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 如果有非String类型的值，则赋予默认值，优化速度

            de.FilmArea.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(FilmArea data)
        {
            de.FilmArea.DeleteObject(data);
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

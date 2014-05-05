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
    public class DownloadSettingManage : IDataManage<DownloadSetting>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        //private List<DownloadSettingInfo> list = new List<DownloadSettingInfo>();

        public DownloadSettingManage() {
            de = Database.GetNewDataEntity();
        }



        #region   IDataManage<DownloadSettingInfo>成员

        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("DownloadId", "下载编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterName", "影院名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SourceName", "下载源名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DownloadMethod", "下载方式"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DownloadAddr", "下载源地址"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Port", "端口号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UserName", "用户名"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Password", "密码"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("IsAnonymAllowed", "是否允许匿名访问"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("IsProxy", "是否使用代理服务器"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ProxyServer", "代理服务器地址"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ProxyPort", "代理服务器端口"));




                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "DownloadId":
                            case "TheaterName":
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
        public List<DownloadSetting> GetDataList()
        {
            return de.DownloadSetting.ToList();
        }

        public List<DownloadSetting> GetSearchList(string columnName, string value)
        {
            return de.ExecuteStoreQuery<DownloadSetting>(string.Format(@"SELECT * FROM DownloadSetting WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public DownloadSetting IsCreated(int id)
        {
            return de.DownloadSetting.Where(p => p.DownloadId == id).FirstOrDefault();
        }

        public DownloadSetting NewData()
        {
            int  lastId;
           
            DownloadSetting lastData = de.DownloadSetting.OrderByDescending(p => p.Created).FirstOrDefault();
            Theater threater = de.Theater.FirstOrDefault();
            // 不能两条记录的创建时间一样，避免主键重复
            if (lastData != null && lastData.Created == DateTime.Now)
                throw new Exception();

            if (lastData != null)
            {
                lastId = lastData.DownloadId;
            }
            else
            {
                lastId = 0;
            }

            string  newId;
            // 生成新的Id（这里长度是12位）
            try
            {
                newId = string.Format("{0:D12}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D12}", 1);
            }

            DownloadSetting data = new DownloadSetting();
            data.DownloadId = Convert.ToInt32(newId);
            //2011.12.24 LIN 判断是否存在id这一条数据
            int id = data.DownloadId;
            while (IsCreated(id) != null)
            {
                id += 1;
                IsCreated(id);
            }
            data.DownloadId = id;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 更新非String类型的值，优化速度
            data.TheaterId = threater.TheaterId;     
            data.ProxyPort = 0;
            data.Port = 0;
            data.IsProxy = false;
            data.IsAnonymAllowed = false;

            de.DownloadSetting.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(DownloadSetting data)
        {
            if(data!=null)
            de.DownloadSetting.DeleteObject(data);
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

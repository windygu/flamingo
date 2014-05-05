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
    public class UploadSettingManage:IDataManage<UploadSetting>
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        //private List<UploadSettingAndTheater> uploadSettingAndTheater=new List<UploadSettingAndTheater>();

        public UploadSettingManage() {
            de = Database.GetNewDataEntity();
        }

        public List<UploadSetting> GetUploadSettingList()
        {
            List<UploadSetting> uploadSettingList = new List<UploadSetting>();
            UploadSetting uploadSetting1 = new UploadSetting();
            UploadSetting uploadSetting2 = new UploadSetting();
            UploadSetting uploadSetting3 = new UploadSetting();
            uploadSetting1.UploadMethod = "https";
            uploadSetting1.UploadId = 1;
            uploadSettingList.Add(uploadSetting1);
            uploadSetting2.UploadMethod = "http";
            uploadSetting2.UploadId = 2;
            uploadSettingList.Add(uploadSetting2);
            uploadSetting3.UploadMethod = "email";
            uploadSetting3.UploadId = 3;
            uploadSettingList.Add(uploadSetting3);
            return uploadSettingList;
        }

        public List<UploadSetting> GetFileFormat()
        {
            List<UploadSetting> List = new List<UploadSetting>();
            UploadSetting uploadSetting1 = new UploadSetting();
            UploadSetting uploadSetting2 = new UploadSetting();
            uploadSetting1.FileFormat = "xml";
            uploadSetting1.UploadId = 1;
           List.Add(uploadSetting1);
            uploadSetting2.FileFormat = "xml加密";
            uploadSetting2.UploadId = 2;
           List.Add(uploadSetting2);
            return List;
        }

        #region IDataManage<UploadSetting> 成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("UploadId", "上报编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TargetName", "上报单位名称", 110));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterName", "影院编号"));
                    //this.columnInfoList.Add(new DataGridViewColumnInfo("", "目标名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UploadMethod", "上报方式"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("IsActive", "是否上传"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FileFormat", "文件格式"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UploadAddr", "上报地址"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UploadTime", "上报时间"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("EmailAddr", "Email地址"));
                


                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        bool x=false;
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                       

                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "UploadId":
                            case "TargetName":                           
                            case "IsActive":
                               
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
        public List<UploadSetting> GetDataList()
        {
            return de.UploadSetting.ToList();    
        }

        public object  GetTheaterName(string  id)
        {
            var name = (from t in de.Theater
                        where t.TheaterId == id
                        select t.TheaterName).FirstOrDefault();
            return name;
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<UploadSetting> GetSearchList(string columnName, string value)
        {
            return de.UploadSetting .Where(p => p.TargetName .Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<UploadSetting>(string.Format(@"SELECT * FROM UploadSetting WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public UploadSetting IsCreated(int id)
        {
            return de.UploadSetting.Where(p => p.UploadId == id).FirstOrDefault();
        }

        public UploadSetting NewData()
        {
            int lastId;
            UploadSetting lastData = de.ExecuteStoreQuery<UploadSetting>(@"SELECT * FROM UploadSetting ORDER BY UploadId*1 DESC LIMIT 1").FirstOrDefault();
            Theater theater = de.Theater.FirstOrDefault();
       
            if (lastData != null)
            {
                lastId = lastData.UploadId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            UploadSetting data = new UploadSetting();
            data.UploadId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;
            data.TheaterId = theater.TheaterId;
            data.UploadTime = new TimeSpan(6, 0, 0);
            data.FileFormat = "xml";
            data.IsActive = false;          
           
            de.UploadSetting.AddObject(data);
            de.SaveChanges();

            return data;
        }

        public void DeleteData(UploadSetting data)
        {
            if (data != null)
            de.UploadSetting.DeleteObject(data);
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

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
    //2011/12/22,Qiu
    public class VoucherManage
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;




        public VoucherManage()
        {
            de = Database.GetNewDataEntity();
        }

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;



        #region IDataManage<VoucherBatchInfo>成员

        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherId", "票券编号", 150));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Price", "票券价格"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BarCode", "条形码"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherBatchId", "票券批次编号", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TicketId", "票编号"));



                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "VoucherId":
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

        public List<Voucher> GetDataList()
        {
            return de.Voucher.ToList();
        }

        public List<Voucher> GetSearchList(string columnName, string value)
        {
            return de.ExecuteStoreQuery<Voucher>(string.Format(@"SELECT * FROM Voucher WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }


        /// <summary>
        /// 判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Voucher IsCreated(int id)
        {
            string nId = id.ToString();
            return de.Voucher.Where(p => p.VoucherId == nId).FirstOrDefault();
        }

        public void RefreshId(Voucher data)
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            string lastId;
            Voucher lastData = de.ExecuteStoreQuery<Voucher>(string.Format(@"SELECT * FROM Voucher WHERE VoucherId LIKE '{0}%' ORDER BY VoucherId*1 DESC LIMIT 1", data.VoucherBatchId)).FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.VoucherId.Substring(10, 6);
            }
            else
            {
                lastId = "0";
            }

            string newId;
            // 生成新的Id（这里长度是6位）
            try
            {
                newId = string.Format("{0:D6}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D6}", 1);
            }

            data.VoucherId = lastData.VoucherBatchId + newId;
        }

        public Voucher NewData()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            VoucherBatch lastBatch = de.ExecuteStoreQuery<VoucherBatch>(string.Format(@"SELECT * FROM VoucherBatch WHERE VoucherBatchId LIKE '{0}{1}{2}%' ORDER BY VoucherBatchId*1 DESC LIMIT 1", year, month, day)).FirstOrDefault();

            if (lastBatch == null)
            {
                throw new Exception("请先添加票券批次!");
            }

            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            string lastId;
            Voucher lastData = de.ExecuteStoreQuery<Voucher>(string.Format(@"SELECT * FROM Voucher WHERE VoucherId LIKE '{0}%' ORDER BY VoucherId*1 DESC LIMIT 1", lastBatch.VoucherBatchId)).FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.VoucherId.Substring(10, 6);
            }
            else
            {
                lastId = "0";
            }

            string newId;
            // 生成新的Id（这里长度是6位）
            try
            {
                newId = string.Format("{0:D6}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D6}", 1);
            }

            Voucher data = new Voucher();
            data.VoucherId = lastBatch.VoucherBatchId + newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 更新非String类型的值，优化速度

            de.Voucher.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(Voucher data)
        {
            de.Voucher.DeleteObject(data);
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

        #region   绑定下拉框
        /// <summary>
        /// 静态变量， 票标
        /// </summary>
        /// <returns></returns>
        public static List<Template> DirectGetTemplate()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<Template> list = de.Template.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量
        /// </summary>
        /// <returns></returns>
        public static List<Ticket> DirectGetTicket()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<Ticket> list = de.Ticket.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量， 票券批次
        /// </summary>
        /// <returns></returns>
        public static List<VoucherBatch> DirectGetVoucherBatch()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<VoucherBatch> list = de.VoucherBatch.ToList();

            return list;
        }

        #endregion
    }
}

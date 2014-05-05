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
    //2011/12/21,Qiu
    public class DebtManage
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;




        public DebtManage()
        {
            de = Database.GetNewDataEntity();
        }

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;



        #region  IDataManage<DebtInfo>成员

        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("DebtId", "欠款编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerId", "客户编号"));
                    //        this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerName", "客户名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Buyer", "欠款人"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BoughtDate", "购买日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Tickets", "购买票数"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Amount", "金额"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BankBranch", "开户银行"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BankAccount", "银行账户"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ChequeNumber", "支票号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DebtStatus", "是否到账"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ClearDate", "到款日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Casher", "收银员"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Accountant", "会计"));

                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "DebtId":
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

        public List<Debt> GetDataList()
        {
            return de.Debt.ToList();
        }

        public List<Debt> GetSearchList(string columnName, string value)
        {
            return de.Debt.Where(p => p.DebtId.Contains(value) == true).ToList();
           // return de.ExecuteStoreQuery<Debt>(string.Format(@"SELECT * FROM Debt WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public List<Customer> GetCustomerNameList()
        {
            return de.Customer.ToList();
        }
        /// <summary>
        /// 根据输入的内容模糊查CustomerId
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string[] GetCustomerIdList(string columnName, string value)
        {

            string sql = string.Format(@"SELECT *  FROM Customer WHERE {0} LIKE '%{1}%'", columnName, value);
            var list = de.ExecuteStoreQuery<Customer>(sql).ToList();
            string[] ayyay = new string[list.Count];
            int i = 0;
            foreach (var var in list)
            {
                ayyay[i] = var.CustomerId.ToString();
                i++;
            }
            return ayyay;
        }

        public object GetCustomerName(int Id)
        {
            var name = (from c in de.Customer
                        where c.CustomerId == Id
                        select c.CustomerName).FirstOrDefault();
            return name;
        }

        /// <summary>
        /// 判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Debt IsCreated(int id)
        {
            string nId = id.ToString();
            return de.Debt.Where(p => p.DebtId == nId).FirstOrDefault();
        }

        public Debt NewData()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            // 获取最后ID
            string lastId;
            Debt lastData = de.ExecuteStoreQuery<Debt>(string.Format(@"SELECT * FROM Debt WHERE DebtId LIKE '{0}{1}{2}%' ORDER BY DebtId*1 DESC LIMIT 1", year, month, day)).FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.DebtId.Substring(8, 2);
            }
            else
            {
                lastId = "0";
            }

            string newId;
            // 生成新的Id（这里长度是2位）
            try
            {
                newId = string.Format("{0:D2}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D2}", 1);
            }

            Debt data = new Debt();
            data.DebtId = year + month + day + newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 更新非String类型的值，优化速度
            data.DebtStatus = false;
            data.BoughtDate = DateTime.Now;
            data.ClearDate = DateTime.Now;
            de.Debt.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public void DeleteData(Debt data)
        {
            de.Debt.DeleteObject(data);
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

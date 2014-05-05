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
    public class CustomerManage
    {

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;



        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public CustomerManage()
        {
            de = Database.GetNewDataEntity();
        }

        #region    IDataManage<Customer>成员

        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerId", "客户编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerTypeId", "客户类型名称",110,true));
                    //  this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerTypeName", "客户类型名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerName", "客户名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BankBranch", "开户银行"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("BankAccount", "银行账户"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Telephone", "电话"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Contact", "联系人"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Email", "Email"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Address", "地址"));

                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];

                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "CustomerId":
                            case "BankBranch":
                            case "BankAccount":
                            case "Telephone":
                            case "Contact":
                            case "Email":
                            case "Address":
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

        //public object GetDetailList()
        //{
        //    var detail = (from c in de.Customer
        //                  join cd in de.CustomerType on c.CustomerTypeId equals cd.CustomerTypeId into g
        //                  from cd in g.DefaultIfEmpty()
        //                  select new
        //                  {
        //                      CustomerId = c.CustomerId,
        //                      CustomerTypeId=c.CustomerTypeId,
        //                      CustomerTypeName = cd.CustomerTypeName,
        //                      CustomerName = c.CustomerName,
        //                      BankAccount = c.BankAccount,
        //                      BankBranch = c.BankBranch,
        //                      Address = c.Address,
        //                      Telephone = c.Telephone,
        //                      Contact = c.Contact,
        //                      Email = c.Email,

        //                  }).ToList();
        //    return detail;
        //}

        public List<Customer> GetDataList()
        {
            return de.Customer.ToList();
        }

        public List<CustomerType>GetCustomerTypeNameList()
        {
            return de.CustomerType.ToList();
        }

        public static object GetCustomerTypeName(int id)
        {
            FlamingoEntities de = Database.GetNewDataEntity();
            
            var name = (from c in de.CustomerType
                        where c.CustomerTypeId == id
                        select c.CustomerTypeName).FirstOrDefault();
            return name;
        }

        public List<Customer> GetSearchList(string columnName, string value)
        {
            return de.Customer .Where(p => p.CustomerName .Contains(value) == true).ToList();
          //  return de.ExecuteStoreQuery<Customer>(string.Format(@"SELECT * FROM Customer WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        public Customer NewData()
        {
            // 获取新Id（将数据表里的FilmId最大值+1）
            // 使用创建时间先后来获取最后ID
            int lastId;
            Customer lastData = de.ExecuteStoreQuery<Customer>(@"SELECT * FROM Customer ORDER BY CustomerId*1 DESC LIMIT 1").FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.CustomerId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            Customer data = new Customer();
            data.CustomerId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;
            // 如果有非String类型的值，则赋予默认值，优化速度

            de.Customer.AddObject(data);

            de.SaveChanges();

            return data;
        }


        public void DeleteData(Customer data)
        {
            if (data != null)
                de.Customer.DeleteObject(data);
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

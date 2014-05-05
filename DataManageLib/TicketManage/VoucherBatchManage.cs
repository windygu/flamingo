using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Transactions;
using System.Data;
using System.Data.Objects;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Flamingo.TicketManage
{
    //2011/12/22,Qiu
    //2011/12/23,Qiu
    public class VoucherBatchManage : IDataManage<VoucherBatch>
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;




        public VoucherBatchManage()
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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherBatchId", "批次号", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SerialScope", "号段"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherTypeId", "类型"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherSubTypeId", "券类", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherName", "票券名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerId", "购卷单位"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UnitPrice", "面值"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Quantity", "数量"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TotalPrice", "总金额"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ReleaseDate", "发行日期"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ExpireDate", "有效截止日期", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("IssuedBy", "经办人"));//经办人
                    //    this.columnInfoList.Add(new DataGridViewColumnInfo("TemplateId", "票版名称"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("PrintStatus", "是否已打印"));    //是否已打印                                                                                                                                           
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ActiveFlag", "是否有效"));  //是否有效


                    //设置其他属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        //colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        //设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "VoucherBatchId":
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

        public string[] GetVoucherIdList(string columnName, string value)
        {
            string sql = string.Format(@"SELECT *  FROM VoucherType WHERE {0} LIKE '%{1}%'", columnName, value);
            var list = de.ExecuteStoreQuery<VoucherType>(sql).ToList();
            string[] array = new string[list.Count];
            int i = 0;
            foreach (var var in list)
            {
                array[i] = var.VoucherTypeId.ToString();
                i++;
            }
            return array;
        }

        public string[] GetVoucherSubTypeIdList(string columnName, string value)
        {
            string sql = string.Format(@"SELECT *  FROM VoucherSubType WHERE {0} LIKE '%{1}%'", columnName, value);
            var list = de.ExecuteStoreQuery<VoucherSubType>(sql).ToList();
            string[] array = new string[list.Count];
            int i = 0;
            foreach (var var in list)
            {
                array[i] = var.VoucherSubTypeId.ToString();
                i++;
            }
            return array;
        }
        public List<VoucherBatch> GetDataList()
        {
            return de.VoucherBatch.ToList();
        }

        public List<VoucherBatch> GetSearchList(string columnName, string value)
        {
            return de.VoucherBatch.Where(p => p.VoucherBatchId.Contains(value) == true).ToList();
         //   return de.ExecuteStoreQuery<VoucherBatch>(string.Format(@"SELECT * FROM VoucherBatch WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        /// 判断是否存在nId的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VoucherBatch IsCreated(string nId)
        {
            return de.VoucherBatch.Where(p => p.VoucherBatchId == nId).FirstOrDefault();
        }

        public VoucherBatch NewData()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            // 获取最后ID
            string lastId;
            VoucherBatch lastData = de.ExecuteStoreQuery<VoucherBatch>(string.Format(@"SELECT * FROM VoucherBatch WHERE VoucherBatchId LIKE '{0}{1}{2}%' ORDER BY VoucherBatchId*1 DESC LIMIT 1", year, month, day)).FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.VoucherBatchId.Substring(8, 2);
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

            VoucherBatch data = new VoucherBatch();
            data.VoucherBatchId = year + month + day + newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            // 更新非String类型的值，优化速度
            data.PrintStatus = 1;
            data.Quantity = 0;
            data.UnitPrice = 0;
            data.TotalPrice = 0;
            data.ExpireDate = DateTime.Now;
            data.ReleaseDate = DateTime.Now;

            de.VoucherBatch.AddObject(data);

            de.SaveChanges();

            return data;
        }

        public static bool IsNumber(string text)
        {
            string s1 = @"^[0-9]+(.[0-9]{2})?|[0-9]+(.[0-9]{1})?$";
            Match m = Regex.Match(text, s1);
            {
                if (!m.Success)
                    return false;
                else
                    return true;
            }

        }

        public static bool IsIntegerNumber(string text)
        {
            string s1 = @"^\+?[0-9][0-9]*$";
            Match m = Regex.Match(text, s1);
            {
                if (!m.Success)
                    return false;
                else
                    return true;
            }
        }

        public void DeleteData(VoucherBatch data)
        {
            de.VoucherBatch.DeleteObject(data);
        }

        public static string GetVoucherTypeName(int nId)
        {
            FlamingoEntities de = Database.GetNewDataEntity();
            var name = (from v in de.VoucherType
                        where v.VoucherTypeId == nId
                        select v.VoucherTypeName).FirstOrDefault();
            return name;
        }

        public static string GetVoucherSubTypeName(int nId)
        {
            FlamingoEntities de = Database.GetNewDataEntity();
            var name = (from v in de.VoucherSubType
                        where v.VoucherSubTypeId == nId
                        select v.VoucherSubTypeName).FirstOrDefault();
            return name;
        }
        public static string GetSueName(int nId)
        {
            FlamingoEntities de = Database.GetNewDataEntity();
            var name = (from v in de.User
                        where v.UserId == nId
                        select v.UserName).FirstOrDefault();
            return name;
        }
        public static string GetCustomerName(int nId)
        {
            FlamingoEntities de = Database.GetNewDataEntity();
            var name = (from v in de.Customer
                        where v.CustomerId == nId
                        select v.CustomerName).FirstOrDefault();
            return name;
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


        #region  下拉框
        /// <summary>
        /// 静态变量， 经手人
        /// </summary>
        /// <returns></returns>
        public static List<User> DirectGetIssued()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<User> list = de.User.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量， 票版
        /// </summary>
        /// <returns></returns>
        public static List<Template> DirectGetTemplate()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<Template> list = de.Template.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量， 票券子类型
        /// </summary>
        /// <returns></returns>
        public static List<VoucherSubType> DirectGetVoucherSubType()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<VoucherSubType> list = de.VoucherSubType.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量， 票券类型
        /// </summary>
        /// <returns></returns>
        public static List<VoucherType> DirectGetVoucherType()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<VoucherType> list = de.VoucherType.ToList();

            return list;
        }

        /// <summary>
        /// 静态变量， 客户
        /// </summary>
        /// <returns></returns>
        public static List<Customer> DirectGetCustomer()
        {
            FlamingoEntities de = Database.GetNewDataEntity();

            List<Customer> list = de.Customer.ToList();

            return list;
        }



        #endregion
    }
}

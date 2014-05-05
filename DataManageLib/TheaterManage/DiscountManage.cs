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
    public class DiscountManage
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        private List<Discount> list = new List<Discount>();

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;
        private List<DataGridViewColumnInfo> columnInfoPriceList;
        private List<DataGridViewColumnInfo> columnInfoTypeList;

        public DiscountManage()
        {
            de = Database.GetNewDataEntity();
        }


        #region  IDataManage<Discount>成员

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("Discount_TypeId", "特价类型编号", 110));
                    // this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DiscountTypeId", "特价类型名称", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("DiscountId", "特价价格"));
                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "Discount_TypeId":
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
        /// 获取价格列信息表
        /// </summary>
        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoPriceList
        {
            get
            {
                if (this.columnInfoPriceList == null)
                {
                    this.columnInfoPriceList = new List<DataGridViewColumnInfo>();                   
                    this.columnInfoPriceList.Add(new DataGridViewColumnInfo("DiscountId", "特价价格编号", 110));
                    this.columnInfoPriceList.Add(new DataGridViewColumnInfo("DiscountPrice", "特价价格", 110));
                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoPriceList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoPriceList[i];
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "DiscountId":
                                colInfo.IsReadOnly = true;
                                break;
                        }
                        // 保存属性设置
                        this.columnInfoPriceList[i] = colInfo;
                    }
                }
                return this.columnInfoPriceList;

            }
        }

         /// <summary>
        /// 获取特价类型列信息表
        /// </summary>
        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoTypeList
        {
            get
            {
                if (this.columnInfoTypeList == null)
                {
                    this.columnInfoTypeList = new List<DataGridViewColumnInfo>();
                    this.columnInfoTypeList.Add(new DataGridViewColumnInfo("DiscountTypeId", "特价类型编号", 110));
                    this.columnInfoTypeList.Add(new DataGridViewColumnInfo("DiscountTypeName", "特价类型名称", 110));
                    
                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoPriceList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoTypeList[i];
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "DiscountTypeId":
                                colInfo.IsReadOnly = true;
                                break;
                        }
                        // 保存属性设置
                        this.columnInfoTypeList[i] = colInfo;
                    }
                }
                return this.columnInfoTypeList;

            }
        }
        
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<Discount_Type> GetDataList()
        {
            List<Discount_Type> list = new List<Discount_Type>();
            list = de.Discount_Type.ToList();
            return list;
        }

        /// <summary>
        /// 获取所有的特价价格
        /// </summary>
        /// <returns></returns>
        public List<Discount> DirectGetDiscountPrice()
        {
            return de.Discount.ToList();
        }

        /// <summary>
        /// 获取所有的特价类型名称
        /// </summary>
        /// <returns></returns>
        public List<DiscountType> DirectGetDiscountTypeName()
        {
            return de.DiscountType.ToList();
        }

        /// <summary>
        /// 根据特价类型id查特价类型名称
        /// </summary>
        /// <param name="nId"></param>
        /// <returns></returns>
        public object GetDiscountTypeName(int? nId)
        {
            var name = (from d in de.DiscountType
                        where d.DiscountTypeId == nId
                        select d.DiscountTypeName).FirstOrDefault();
            return name;
        }

        public object GetDiscountPrice(int? nId)
        {
            var price = (from d in de.Discount
                         where d.DiscountId == nId
                         select d.DiscountPrice).FirstOrDefault();
            return price;
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Discount_Type> GetSearchList(string columnName, string value)
        {
            return de.Discount_Type.Where(p => p.DiscountType.DiscountTypeName .Contains(value) == true).ToList();

         //   return de.ExecuteStoreQuery<Discount_Type>(string.Format(@"SELECT * FROM Discount_Type WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }

        /// <summary>
        ///  判断是否存在id这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>2011.12.23 LIN
        public Discount_Type IsCreated(int id)
        {
            return de.Discount_Type.Where(p => p.Discount_TypeId == id).FirstOrDefault();
        }
        public Discount IsCreatedPriceId(int id)
        {
            return de.Discount.Where(p => p.DiscountId == id).FirstOrDefault();
        }
        public DiscountType IsCreatedDiscoutTypeId(int id)
        {
            return de.DiscountType.Where(p => p.DiscountTypeId == id).FirstOrDefault();
        }
        public Discount_Type NewData()
        {
            // 获取最后ID
            int lastId;
            Discount_Type lastData = de.ExecuteStoreQuery<Discount_Type>(@"SELECT * FROM Discount_Type ORDER BY Discount_TypeId*1 DESC LIMIT 1").FirstOrDefault();
            //Theater theater = de.Theater.FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.Discount_TypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            Discount_Type data = new Discount_Type();
            data.Discount_TypeId = newId;

            //  data.TheaterId = theater.TheaterId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;


            //data.Discount_TypeId = 1;
            //data.DiscountId = 2;

            de.Discount_Type.AddObject(data);

            de.SaveChanges();

            return data;
        }

        /// <summary>
        /// 添加的价格是否已存在
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        //public bool IsPriceExist(double price)
        //{
        //    Discount data = de.Discount.Where(p => p.DiscountPrice == price).FirstOrDefault();
        //    if (data == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 添加的特价类型名称是否已存在
        /// </summary>
        /// <param name="price"></param>
        ///// <returns></returns>
        //public bool IsTypeNameExist(string name)
        //{
        //    DiscountType data = de.DiscountType.Where(p => p.DiscountTypeName == name).FirstOrDefault();
        //    if (data == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 添加特价价格
        /// </summary>
        public Discount NewDataOfDiscountPrice()
        {
            // 使用创建时间先后来获取最后ID
            int lastId;
            Discount lastData = de.ExecuteStoreQuery<Discount>(@"SELECT * FROM Discount ORDER BY DiscountId*1 DESC LIMIT 1").FirstOrDefault();
            //Theater theater = de.Theater.FirstOrDefault();

            if (lastData != null)
            {
                lastId = lastData.DiscountId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            Discount data = new Discount();
            data.DiscountId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            data.DiscountPrice = 0;
            de.Discount.AddObject(data);           
            de.SaveChanges();
            return data;
        }

        /// <summary>
        /// 增加特价类型名称
        /// </summary>
        /// <param name="name"></param>
        public DiscountType NewDataOfTypeName()
        {
            // 使用创建时间先后来获取最后ID
            int lastId;
            DiscountType lastData = de.ExecuteStoreQuery<DiscountType>(@"SELECT * FROM DiscountType ORDER BY DiscountTypeId*1 DESC LIMIT 1").FirstOrDefault();
            //Theater theater = de.Theater.FirstOrDefault();

            // 不能两条记录的创建时间一样，避免主键重复
            if (lastData != null && lastData.Created == DateTime.Now)
                throw new Exception();

            if (lastData != null)
            {
                lastId = lastData.DiscountTypeId;
            }
            else
            {
                lastId = 0;
            }

            int newId = lastId + 1;

            DiscountType data = new DiscountType();
            data.DiscountTypeId = newId;
            
            //  data.TheaterId = theater.TheaterId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;

            data.DiscountTypeName = string.Empty;
            de.DiscountType.AddObject(data);
            de.SaveChanges();
            return data;
        }
        /// <summary>
        /// 删除特价价格
        /// </summary>
        /// <param name="price"></param>
        public void DeleteDiscountPrice(Discount data)
        {
            if (data != null)
                de.Discount.DeleteObject(data);
        }

        public void DeleteDiscountTypeName(DiscountType data)
        {
            if (data != null)
                de.DiscountType.DeleteObject(data);
        }
        public void DeleteData(Discount_Type data)
        {
            if (data != null)
                de.Discount_Type.DeleteObject(data);
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

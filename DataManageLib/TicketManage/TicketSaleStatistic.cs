using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;

namespace Flamingo.TicketManage
{
    public class TicketSaleStatistic
    {

        public class Head
        {
            public string VoucherBatchId { get; set; }
            public string SerialScope { get; set; }
            public string CustomerId { get; set; }
            public float? UnitPrice { get; set; }
            public int? Quantity { get; set; }
            public float? TotalPrice { get; set; }
            public string VoucherTypeId { get; set; }
            public DateTime ExpireDate { get; set; }
            public int? IssuedBy { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;
        private List<DataGridViewColumnInfo> columnInfoList;
        public TicketSaleStatistic()
        {
            de = Database.GetNewDataEntity();
        }

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

                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherBatchId", "批次号", 110));
                    //  this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherName", "票劵名称", 110));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("SerialScope", "号段"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("CustomerId", "购卷单位"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("UnitPrice", "单价"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Quantity", "数量"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TotalPrice", "金额"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ExpireDate", "截止时间"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("VoucherTypeId", "卷类"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("Description", "销售状态"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("IssuedBy", "经办人"));

                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        // 保存属性设置
                        this.columnInfoList[i] = colInfo;
                    }
                }
                return this.columnInfoList;

            }
        }


        /// <summary>
        /// gridview的数据源
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>
        public object dgvSearch(DateTime dtFrom, DateTime dtTo, int nId)
        {
            var ds = (from v in de.VoucherBatch
                      where v.Created >= dtFrom && v.Created < dtTo && v.VoucherTypeId == nId
                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher//
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          SerialScopeNo = v.SerialScope,
                          CustomerId = v.CustomerId,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ExpireDateYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ExpireDateMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ExpireDateDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          VoucherTypeId = v.VoucherTypeId,
                          UseId = us.UserId == null ? 1 : us.UserId,
                          SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ExpireDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VoucherBatchId == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;

                Head head = new Head();
                head.VoucherBatchId = d.VocherTypeNo;
                head.SerialScope = d.SerialScopeNo;
                head.CustomerId = d.CustomerId.ToString();
                head.UnitPrice = d.Price;
                head.Quantity = d.Quantity;
                head.TotalPrice = d.TotalPrice;
                head.ExpireDate = new DateTime(d.ExpireDateYear, d.ExpireDateMonth, d.ExpireDateDay);
                head.VoucherTypeId = d.VoucherTypeId.ToString();
                head.IssuedBy = d.UseId;
                head.Description = d.SaleStatistic;

                headList.Add(head);
            }

            return headList;
        }

        /// <summary>
        /// gridview的数据源
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>
        public object dgvSearch(DateTime dtFrom, DateTime dtTo)
        {
            var ds = (from v in de.VoucherBatch
                      where v.Created >= dtFrom && v.Created < dtTo
                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher//
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          SerialScopeNo = v.SerialScope,
                          CustomerId = v.CustomerId,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ExpireDateYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ExpireDateMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ExpireDateDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          VoucherTypeId = v.VoucherTypeId,
                          UseId = us.UserId == null ? 1 : us.UserId,
                          SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ExpireDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VoucherBatchId == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;

                Head head = new Head();
                head.VoucherBatchId = d.VocherTypeNo;
                head.SerialScope = d.SerialScopeNo;
                head.CustomerId = d.CustomerId.ToString();
                head.UnitPrice = d.Price;
                head.Quantity = d.Quantity;
                head.TotalPrice = d.TotalPrice;
                head.ExpireDate = new DateTime(d.ExpireDateYear, d.ExpireDateMonth, d.ExpireDateDay);
                head.VoucherTypeId = d.VoucherTypeId.ToString();
                head.IssuedBy = d.UseId;
                head.Description = d.SaleStatistic;

                headList.Add(head);
            }

            return headList;
        }
        public object SearchOfVoucherName(string name)
        {
            var ds = (from v in de.VoucherBatch
                      where v.VoucherName.Contains(name)
                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher//
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          SerialScopeNo = v.SerialScope,
                          CustomerId = v.CustomerId,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ExpireDateYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ExpireDateMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ExpireDateDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          VoucherTypeId = v.VoucherTypeId,
                          UseId = us.UserId == null ? 1 : us.UserId,
                          SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ExpireDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VoucherBatchId == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;

                Head head = new Head();
                head.VoucherBatchId = d.VocherTypeNo;
                head.SerialScope = d.SerialScopeNo;
                head.CustomerId = d.CustomerId.ToString();
                head.UnitPrice = d.Price;
                head.Quantity = d.Quantity;
                head.TotalPrice = d.TotalPrice;
                head.ExpireDate = new DateTime(d.ExpireDateYear, d.ExpireDateMonth, d.ExpireDateDay);
                head.VoucherTypeId = d.VoucherTypeId.ToString();
                head.IssuedBy = d.UseId;
                head.Description = d.SaleStatistic;

                headList.Add(head);
            }
            return headList;
        }

        public object SearchOfDate(DateTime date)
        {
            var ds = (from v in de.VoucherBatch
                      where v.ReleaseDate == date
                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher//
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          SerialScopeNo = v.SerialScope,
                          CustomerId = v.CustomerId,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ExpireDateYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ExpireDateMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ExpireDateDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          VoucherTypeId = v.VoucherTypeId,
                          UseId = us.UserId == null ? 1 : us.UserId,
                          SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ExpireDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VoucherBatchId == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;

                Head head = new Head();
                head.VoucherBatchId = d.VocherTypeNo;
                head.SerialScope = d.SerialScopeNo;
                head.CustomerId = d.CustomerId.ToString();
                head.UnitPrice = d.Price;
                head.Quantity = d.Quantity;
                head.TotalPrice = d.TotalPrice;
                head.ExpireDate = new DateTime(d.ExpireDateYear, d.ExpireDateMonth, d.ExpireDateDay);
                head.VoucherTypeId = d.VoucherTypeId.ToString();
                head.IssuedBy = d.UseId;
                head.Description = d.SaleStatistic;

                headList.Add(head);
            }
            return headList;
        }

        public bool IsSale(string nId)
        {
            string str = (from v in de.Voucher
                          where v.VoucherBatchId == nId
                          select v.VoucherId).FirstOrDefault();
            if (str != null)
                return true;
            else
                return false;
        }
        public string[] GetCustomerIdList(string columnName, string value)
        {
            string sql = string.Format(@"SELECT *  FROM Customer WHERE {0} LIKE '%{1}%'", columnName, value);
            var list = de.ExecuteStoreQuery<Customer>(sql).ToList();
            string[] array = new string[list.Count];
            int i = 0;
            foreach (var var in list)
            {
                array[i] = var.CustomerId.ToString();
                i++;
            }
            return array;
        }

        public string[] GetUseIdList(string columnName, string value)
        {
            string sql = string.Format(@"SELECT *  FROM User WHERE {0} LIKE '%{1}%'", columnName, value);
            var list = de.ExecuteStoreQuery<User>(sql).ToList();
            string[] array = new string[list.Count];
            int i = 0;
            foreach (var var in list)
            {
                array[i] = var.UserId.ToString();
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
            return de.VoucherBatch .Where(p => p.VoucherName .Contains(value) == true).ToList();
          //  return de.ExecuteStoreQuery<VoucherBatch>(string.Format(@"SELECT * FROM VoucherBatch WHERE {0} LIKE '%{1}%'", columnName, value)).ToList();
        }
    }
}

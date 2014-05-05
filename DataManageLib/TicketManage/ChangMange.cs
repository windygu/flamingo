using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TicketManage
{
    public class ChangMange
    {
        public class Head
        {
            public string VocherTypeNo { get; set; }
            //       public string SerialScopeNo { get; set; }
            public string CustomerName { get; set; }
            public float? Price { get; set; }
            public int? Quantity { get; set; }
            //       public float? TotalPrice { get; set; }
            public DateTime ReleaseDate { get; set; }
            //     public string VoucherTypeName { get; set; }
            //    public string EmployeeId { get; set; }
            //     public string SaleStatistic { get; set; }
            public int? Alreadychange { get; set; }
            public int? Notchange { get; set; }
            public int? DeposeSum { get; set; }
            public float? jine { get; set; }

        }

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        public ChangMange()
        {
            de = Database.GetNewDataEntity();
        }

        public object dgvSearch(int userNameId)
        {
            var ds = (from v in de.VoucherBatch
                      where v.IssuedBy==userNameId
                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          //  SerialScopeNo = v.SerialScope,
                          CustomerName = cu.CustomerName,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ReleaseYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ReleaseMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ReleaseDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          //  VoucherTypeName = vtp.VoucherTypeName,
                          //   EmployeeId = us.EmployeeId,
                          //  SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ReleaseDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VocherTypeNo == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;
                Head head = new Head();
                head.VocherTypeNo = d.VocherTypeNo;
                //      head.SerialScopeNo = d.SerialScopeNo;
                head.CustomerName = d.CustomerName;
                head.Price = d.Price;
                head.Quantity = d.Quantity;
                //     head.TotalPrice = d.TotalPrice;
                head.ReleaseDate = new DateTime(d.ReleaseYear, d.ReleaseMonth, d.ReleaseDay);
                //head.VoucherTypeName = d.VoucherTypeName;
                //head.EmployeeId = d.EmployeeId;
                //head.SaleStatistic = d.SaleStatistic;
                head.Alreadychange = Alreadychange(d.VocherTypeNo);
                head.Notchange = d.Quantity - Alreadychange(d.VocherTypeNo);
                head.DeposeSum = DeposeSum(d.Quantity, d.VocherTypeNo);
                head.jine = TotalPrice(d.VocherTypeNo);
               // head.jine = head.Alreadychange * head.Price;

                headList.Add(head);
            }

            return headList;
        }
        /// <summary>
        /// 统计某批次的金额
        /// </summary>
        /// <param name="VoucherBatchId"></param>
        /// <returns></returns>
        public float TotalPrice(string VoucherBatchId)
        {
            var tmp = de.Voucher.Where(p => p.VoucherBatchId == VoucherBatchId).ToList().Sum(p => p.Price);
            if (tmp != null)
                return (float)tmp;
            else
                return 0;
        }

        public object dgvSearch()
        {
            var ds = (from v in de.VoucherBatch

                      join c in de.Customer on v.CustomerId equals c.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()

                      join u in de.User on v.IssuedBy equals u.UserId into user
                      from us in user.DefaultIfEmpty()
                      join vt in de.VoucherType on v.VoucherTypeId equals vt.VoucherTypeId into vocherType
                      from vtp in vocherType.DefaultIfEmpty()
                      join vo in de.Voucher on v.VoucherBatchId equals vo.VoucherBatchId into voucher
                      from vou in voucher.DefaultIfEmpty()
                      select new
                      {
                          VocherTypeNo = v.VoucherBatchId,
                          //  SerialScopeNo = v.SerialScope,
                          CustomerName = cu.CustomerName,
                          Price = v.UnitPrice ?? 0,
                          Quantity = v.Quantity ?? 0,
                          TotalPrice = v.TotalPrice ?? 0,
                          ReleaseYear = v.ExpireDate.Value.Year == 0 ? 1900 : v.ExpireDate.Value.Year,
                          ReleaseMonth = v.ExpireDate.Value.Month == 0 ? 1 : v.ExpireDate.Value.Month,
                          ReleaseDay = v.ExpireDate.Value.Day == 0 ? 1 : v.ExpireDate.Value.Day,
                          //  VoucherTypeName = vtp.VoucherTypeName,
                          //   EmployeeId = us.EmployeeId,
                          //  SaleStatistic = vou.VoucherId == null ? "否" : "是",
                      }).ToList();
            //ds.ReleaseDate = new DateTime(ds.ReleaseYear, ds.ReleaseMonth, ds.ReleaseDay);

            //将上面查到的值赋给head
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VocherTypeNo == d.VocherTypeNo).FirstOrDefault() != null)
                    continue;
                Head head = new Head();
                head.VocherTypeNo = d.VocherTypeNo;
                //      head.SerialScopeNo = d.SerialScopeNo;
                head.CustomerName = d.CustomerName;
                head.Price = d.Price;
                head.Quantity = d.Quantity;
                //     head.TotalPrice = d.TotalPrice;
                head.ReleaseDate = new DateTime(d.ReleaseYear, d.ReleaseMonth, d.ReleaseDay);
                //head.VoucherTypeName = d.VoucherTypeName;
                //head.EmployeeId = d.EmployeeId;
                //head.SaleStatistic = d.SaleStatistic;
                head.Alreadychange = Alreadychange(d.VocherTypeNo);
                head.Notchange = d.Quantity - Alreadychange(d.VocherTypeNo);
                head.DeposeSum = DeposeSum(d.Quantity, d.VocherTypeNo);
                head.jine = TotalPrice(d.VocherTypeNo);


                headList.Add(head);
            }

            return headList;
        }

        /// <summary>
        /// 已兑数量
        /// </summary>
        public int Alreadychange(string VoucherBatchId)
        {
            var tmp = (from v in de.Voucher where v.VoucherBatchId == VoucherBatchId select v.VoucherBatchId).Count();
            return tmp;
        }

        /// <summary>
        /// 费券数量
        /// </summary>
        public int DeposeSum(int Quantity, string VoucherBatchId)
        {
            var tmp = (from v in de.Voucher where v.VoucherBatchId == VoucherBatchId select v.VoucherBatchId).Count();

            int Depose = (from v in de.VoucherBatch where v.ExpireDate < DateTime.Now && v.VoucherBatchId == VoucherBatchId select v.VoucherBatchId).Count();

            if (Depose > 0)
                return Quantity - tmp;
            else
                return 0;
        }

    }
}

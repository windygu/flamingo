using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TicketManage
{
    public class SingleVoucherBatch
    {
        public class Head
        {
            public string VocherTypeNo { get; set; }
            public string CustomerName { get; set; }
            public float? Price { get; set; }
            public int? Quantity { get; set; }
            public DateTime ExpireDate { get; set; }
            public int? VoucherQuantity { get; set; }
            public int? VoucherNotQuantity { get; set; }
            public int? PassVoucher { get; set; }
            public float? Amount { get; set; }
        }

        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        public SingleVoucherBatch()
        {
            de = Database.GetNewDataEntity();
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
        /// 废卷数量
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

        /// <summary>
        /// gridview的数据源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object dgvSearch(string id)
        {
            var ds = (from c in de.Customer
                      join v in de.VoucherBatch on c.CustomerId equals v.CustomerId into customer
                      from cu in customer.DefaultIfEmpty()
                      join vo in de.Voucher on cu.VoucherBatchId equals vo.VoucherBatchId into voucher
                      from vou in voucher.DefaultIfEmpty()
                      where cu.VoucherBatchId == id
                      select new
                      {
                          VocherTypeNo = cu.VoucherBatchId,
                          SerialScopeNo = cu.SerialScope,
                          CustomerName = c.CustomerName,
                          Price = cu.UnitPrice ?? 0,
                          Quantity = cu.Quantity ?? 0,
                          ExpireYear = cu.ExpireDate.Value.Year == 0 ? 1900 : cu.ExpireDate.Value.Year,
                          ExpireMonth = cu.ExpireDate.Value.Month == 0 ? 1 : cu.ExpireDate.Value.Month,
                          ExpireDay = cu.ExpireDate.Value.Day == 0 ? 1 : cu.ExpireDate.Value.Day,

                      }).ToList();

            var tmpList = new List<Head>();
            List<Head> headList = new List<Head>();
            foreach (var d in ds)
            {
                if (headList.Where(p => p.VocherTypeNo == (d.VocherTypeNo + d.SerialScopeNo)).FirstOrDefault() != null)
                    continue;
                Head head = new Head();
                head.VocherTypeNo = d.VocherTypeNo + d.SerialScopeNo;
                head.CustomerName = d.CustomerName;
                head.Price = d.Price;
                head.Quantity = d.Quantity;
                head.ExpireDate = new DateTime(d.ExpireYear, d.ExpireMonth, d.ExpireDay);
                head.VoucherQuantity = Alreadychange(id);
                head.VoucherNotQuantity = head.Quantity - head.VoucherQuantity;
                head.PassVoucher = DeposeSum(d.Quantity, d.VocherTypeNo);
               // head.Amount = head.VoucherNotQuantity * head.PassVoucher;
                head.Amount = TotalPrice(d.VocherTypeNo);
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
            var tmp = de.Voucher.Where(P => P.VoucherBatchId == VoucherBatchId).ToList().Sum(P => P.Price);
            if (tmp != null)
                return (float)tmp;
            else
                return 0;
        }

        public object GetVoucherId()
        {
            var cbds = (from v in de.VoucherBatch
                        select v.VoucherBatchId).ToList();
            return cbds;
        }
    }
}

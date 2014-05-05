using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.Entity
{
    public class Para_UserSoldInfo
    {
        public Para_UserSoldInfo(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {
                _TicketCount = Int32.Parse(dt.Rows[0]["TicketCount"].ToString());
                _MyTicketCount = Int32.Parse(dt.Rows[0]["MyTicketCount"].ToString());
                _MyRefundCount = Int32.Parse(dt.Rows[0]["MyRefundCount"].ToString());
                _MyRefundMyCount = Int32.Parse(dt.Rows[0]["MyRefundMyCount"].ToString());
                _MyRefundAtherCount = Int32.Parse(dt.Rows[0]["MyRefundAtherCount"].ToString());
                _MyTotalCash = float.Parse(dt.Rows[0]["MyTotalCash"].ToString() == "" ? "0" : dt.Rows[0]["MyTotalCash"].ToString());
            }
        }
        private int _TicketCount;
        /// <summary>
        /// 总售票数
        /// </summary>
        public int TicketCount
        {
            get { return _TicketCount; }
        }
        private int _MyTicketCount;
        /// <summary>
        /// 本人售
        /// </summary>
        public int MyTicketCount
        {
            get { return _MyTicketCount; }
        }
        private int _MyRefundCount;
        /// <summary>
        /// 本人退
        /// </summary>
        public int MyRefundCount
        {
            get { return _MyRefundCount; }
        }
        private int _MyRefundMyCount;
        /// <summary>
        /// 本人退本售
        /// </summary>
        public int MyRefundMyCount
        {
            get { return _MyRefundMyCount; }
        }
        private int _MyRefundAtherCount;
        /// <summary>
        /// 本人退他售
        /// </summary>
        public int MyRefundAtherCount
        {
            get { return _MyRefundAtherCount; }
        }
        private float _MyTotalCash;
        /// <summary>
        /// 应收票款
        /// </summary>
        public float MyTotalCash
        {
            get { return _MyTotalCash; }
        }
    }
}

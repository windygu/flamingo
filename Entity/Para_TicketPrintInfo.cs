using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Entity
{
    /// <summary>
    /// 影票补打实体
    /// </summary>
    public class Para_TicketPrintInfo
    {
        private string _TicketId;

        /// <summary>
        /// 影票ID
        /// </summary>
        public string TicketId
        {
            get { return _TicketId; }
            set { _TicketId = value; }
        }

        private float _TicketPrice;

        /// <summary>
        /// 票价
        /// </summary>
        public float TicketPrice
        {
            get { return _TicketPrice; }
            set { _TicketPrice = value; }
        }

        private string _BarCode;

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }

        private DateTime _SoldTime;

        /// <summary>
        /// 售出时间
        /// </summary>
        public DateTime SoldTime
        {
            get { return _SoldTime; }
            set { _SoldTime = value; }
        }

        private string _SoldBy;

        public string SoldBy
        {
            get { return _SoldBy; }
            set { _SoldBy = value; }
        }

        private string _TicketType;

        /// <summary>
        /// 售票类型
        /// </summary>
        public string TicketType
        {
            get { return _TicketType; }
            set { _TicketType = value; }
        }

        private string _Payment;

        /// <summary>
        /// 支付类型
        /// </summary>
        public string Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }

        private int _TemplateId;

        /// <summary>
        /// 票版ID
        /// </summary>
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.Entity
{
    /// <summary>
    /// 影票预定参数实体
    /// </summary>
    public class Para_ReservationTicket
    {
        private string _ShowPlanId;
        private string _customername;
        private string _customermobile;
        private string _customercode;
        private string _identity;
        private string _seatstatusids;
        private string _ticketTypes;
        private int? _issuedby;
        private int _Count;

        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowPlanId
        {
            get { return _ShowPlanId; }
            set { _ShowPlanId = value; }
        }
        /// <summary>
        /// 订票人姓名
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 预定人电话
        /// </summary>
        public string CustomerMobile
        {
            set { _customermobile = value; }
            get { return _customermobile; }
        }
        /// <summary>
        /// 预定人密码
        /// </summary>
        public string CustomerCode
        {
            set { _customercode = value; }
            get { return _customercode; }
        }
        /// <summary>
        /// 预定人身份证号
        /// </summary>
        public string Identity
        {
            set { _identity = value; }
            get { return _identity; }
        }
        /// <summary>
        /// 座位状态ID集合 |
        /// </summary>
        public string SeatStatusIds
        {
            set { _seatstatusids = value; }
            get { return _seatstatusids; }
        }
        /// <summary>
        /// 售票类型集合 |
        /// </summary>
        public string TicketTypes
        {
            set { _ticketTypes = value; }
            get { return _ticketTypes; }
        }
        private string _seatnumbers;
        /// <summary>
        /// 座位号集合 |
        /// </summary>
        public string SeatNumbers
        {
            set { _seatnumbers = value; }
            get { return _seatnumbers; }
        }
        private string _ticketprices;
        /// <summary>
        /// 票价结合 |
        /// </summary>
        public string TicketPrices
        {
            set { _ticketprices = value; }
            get { return _ticketprices; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public int? IssuedBy
        {
            set { _issuedby = value; }
            get { return _issuedby; }
        }

        /// <summary>
        /// 预定票数
        /// </summary>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        #region 作为返回值时用到的参数
        private string _ErrorMsg;
        /// <summary>
        /// 错误提示信息 空或null:验证成功;
        /// </summary>
        public string ErrorMsg
        {
            get { return _ErrorMsg; }
            set { _ErrorMsg = value; }
        }
        private DataTable _DT;
        /// <summary>
        /// 预订票集合
        /// </summary>
        public DataTable DT
        {
            get { return _DT; }
            set { _DT = value; }
        }
        #endregion
    }
}

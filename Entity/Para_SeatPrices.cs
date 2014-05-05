using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Entity
{
    /// <summary>
    /// 座位对应的价格(零售,学生,团体,特价)
    /// </summary>
    public class Para_SeatPrices
    {
        private string _SeatStatusId;
        /// <summary>
        /// 座位状态ID
        /// </summary>
        public string SeatStatusId
        {
            get { return _SeatStatusId; }
            set { _SeatStatusId = value; }
        }
        private float _RetailPrice;
        /// <summary>
        /// 零售价格
        /// </summary>
        public float RetailPrice
        {
            get { return _RetailPrice; }
            set { _RetailPrice = value; }
        }
        private float _StudentPrice;
        /// <summary>
        /// 学生价
        /// </summary>
        public float StudentPrice
        {
            get { return _StudentPrice; }
            set{_StudentPrice=value;}
        }
        private float _GroupPrice;
        /// <summary>
        /// 团体价
        /// </summary>
        public float GroupPrice
        {
            get { return _GroupPrice; }
            set { _GroupPrice = value; }
        }
        private float _MemberPrice;
        /// <summary>
        /// 会员价
        /// </summary>
        public float MemberPrice
        {
            set { _MemberPrice = value; }
            get { return _MemberPrice; }
        }
    }
}

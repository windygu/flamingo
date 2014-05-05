using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Entity
{
    /// <summary>
    /// 票券批次参数实体
    /// </summary>
    public class Para_Voucher
    {
        #region Model
        private string _VoucherId;
        /// <summary>
        /// 票券ID
        /// </summary>
        public string VoucherId
        {
            set { _VoucherId = value; }
            get { return _VoucherId; }
        }
        private float _VoucherPrice;
        /// <summary>
        /// 单价
        /// </summary>
        public float VoucherPrice
        {
            set { _VoucherPrice = value; }
            get { return _VoucherPrice; }
        }
        private float _Price;
        /// <summary>
        /// 票面价值
        /// </summary>
        public float Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        private int? _VoucherTypeId;
        /// <summary>
        /// 票券类型ID
        /// </summary>
        public int? VoucherTypeId
        {
            set { _VoucherTypeId = value; }
            get { return _VoucherTypeId; }
        }
        private string _VoucherType;
        /// <summary>
        /// 票券类型
        /// </summary>
        public string VoucherType
        {
            set { _VoucherType = value; }
            get { return _VoucherType; }
        }
        private int _VoucherSubTypeId;
        /// <summary>
        /// 票券类别 (小类)
        /// </summary>
        public int VoucherSubTypeId
        {
            set { _VoucherSubTypeId = value; }
            get { return _VoucherSubTypeId; } 
        }
        private string _VoucherSubType;
        /// <summary>
        /// 票券小类名称
        /// </summary>
        public string VoucherSubType
        {
            set { _VoucherSubType = value; }
            get { return _VoucherSubType; }  
        }
        private string _VoucherBatchId;
        /// <summary>
        /// 批次ID
        /// </summary>
        public string VoucherBatchId
        {
            set { _VoucherBatchId = value; }
            get { return _VoucherBatchId; }
        }
        private int? _TemplateId;
        /// <summary>
        /// 模版ID
        /// </summary>
        public int? TemplateId
        {
            set { _TemplateId = value; }
            get { return _TemplateId; }
        }
        private DateTime _BeginDate;
        /// <summary>
        /// 有效起始时间
        /// </summary>
        public DateTime BeginDate
        {
            set { _BeginDate = value; }
            get { return _BeginDate; }
        }
        private DateTime _EndDate;
        /// <summary>
        /// 有效结束时间
        /// </summary>
        public DateTime EndDate
        {
            set { _EndDate = value; }
            get { return _EndDate; }
        }
        private bool _AllowUse = false;
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool AllowUse
        {
            set { _AllowUse = value; }
            get { return _AllowUse; }
        }
        private string _ErrorMsg = "票券不存在";
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg
        {
            set { _ErrorMsg = value; }
            get { return _ErrorMsg; }
        }
        private string _VoucherName;
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string VoucherName
        {
            set { _VoucherName = value; }
            get { return _VoucherName; }
        }
        private string _SerialScope;
        /// <summary>
        /// 票券号段
        /// </summary>
        public string SerialScope
        {
            set { _SerialScope = value; }
            get { return _SerialScope; }
        }
        /// <summary>
        /// 票段起始号码
        /// </summary>
        public Int64 SerialScopeBegin
        {
            get
            {
                string[] split = _SerialScope.Split('-');
                return Int64.Parse(split[0]);
            }
        }
        /// <summary>
        /// 票段结束号码
        /// </summary>
        public Int64 SerialScopeEnd
        {
            get
            {
                string[] split = _SerialScope.Split('-');
                return Int64.Parse(split[1]);
            }
        }
        private int count;
        /// <summary>
        /// 代用券可用数量
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        #endregion Model
    }
}

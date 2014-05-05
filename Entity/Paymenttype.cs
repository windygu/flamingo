using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Paymenttype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PaymentMethod
	{
        public PaymentMethod()
		{}
		#region Model
		private string _paymentmethodid;
        private string _paymentmethodname;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
        public string PaymentMethodId
		{
            set { _paymentmethodid = value; }
            get { return _paymentmethodid; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string PaymentMethodName
		{
            set { _paymentmethodname = value; }
            get { return _paymentmethodname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Updated
		{
			set{ _updated=value;}
			get{return _updated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActiveFlag
		{
			set{ _activeflag=value;}
			get{return _activeflag;}
		}
		#endregion Model

	}
}


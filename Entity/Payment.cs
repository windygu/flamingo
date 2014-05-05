using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Payment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Payment
	{
		public Payment()
		{}
		#region Model
		private string _paymentid;
		private string _paymenttypeid;
		private decimal? _totalprice;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string PaymentId
		{
			set{ _paymentid=value;}
			get{return _paymentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PaymentTypeId
		{
			set{ _paymenttypeid=value;}
			get{return _paymenttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
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


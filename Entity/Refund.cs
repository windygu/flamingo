using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Refund:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Refund
	{
		public Refund()
		{}
		#region Model
		private string _refundid;
		private int? _issuedby;
		private DateTime? _refundtime;
		private string _ticketid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string RefundId
		{
			set{ _refundid=value;}
			get{return _refundid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IssuedBy
		{
			set{ _issuedby=value;}
			get{return _issuedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RefundTime
		{
			set{ _refundtime=value;}
			get{return _refundtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TicketId
		{
			set{ _ticketid=value;}
			get{return _ticketid;}
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


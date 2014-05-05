using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Ticket:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ticket
	{
		public Ticket()
		{}
		#region Model
		private string _ticketid;
		private decimal? _ticketprice;
		private string _barcode;
		private DateTime? _soldtime;
		private int? _soldby;
		private string _seatstatusid;
		private string _paymentid;
		private string _showplanid;
		private int? _templateid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public decimal? TicketPrice
		{
			set{ _ticketprice=value;}
			get{return _ticketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BarCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SoldTime
		{
			set{ _soldtime=value;}
			get{return _soldtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SoldBy
		{
			set{ _soldby=value;}
			get{return _soldby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeatStatusId
		{
			set{ _seatstatusid=value;}
			get{return _seatstatusid;}
		}
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
		public string ShowPlanId
		{
			set{ _showplanid=value;}
			get{return _showplanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TemplateId
		{
			set{ _templateid=value;}
			get{return _templateid;}
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


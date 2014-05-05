using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Reservation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Reservation
	{
		public Reservation()
		{}
		#region Model
		private string _reservationid;
		private string _customername;
		private string _customermobile;
		private string _customercode;
		private string _identity;
		private string _seatstatusid;
		private int? _issuedby;
		private DateTime? _bookedtime;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string ReservationId
		{
			set{ _reservationid=value;}
			get{return _reservationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerMobile
		{
			set{ _customermobile=value;}
			get{return _customermobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerCode
		{
			set{ _customercode=value;}
			get{return _customercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Identity
		{
			set{ _identity=value;}
			get{return _identity;}
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
		public int? IssuedBy
		{
			set{ _issuedby=value;}
			get{return _issuedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BookedTime
		{
			set{ _bookedtime=value;}
			get{return _bookedtime;}
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


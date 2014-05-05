using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Timesetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Timesetting
	{
		public Timesetting()
		{}
		#region Model
		private int _timesettingid;
		private string _theaterid;
		private DateTime? _opentime;
		private DateTime? _closetime;
		private int? _refunddeadline;
		private int? _ticketingdeadline;
		private int? _bookingreleasetime;
		private int? _timespan;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int TimeSettingId
		{
			set{ _timesettingid=value;}
			get{return _timesettingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheaterId
		{
			set{ _theaterid=value;}
			get{return _theaterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OpenTime
		{
			set{ _opentime=value;}
			get{return _opentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CloseTime
		{
			set{ _closetime=value;}
			get{return _closetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RefundDeadline
		{
			set{ _refunddeadline=value;}
			get{return _refunddeadline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TicketingDeadline
		{
			set{ _ticketingdeadline=value;}
			get{return _ticketingdeadline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BookingReleaseTime
		{
			set{ _bookingreleasetime=value;}
			get{return _bookingreleasetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Timespan
		{
			set{ _timespan=value;}
			get{return _timespan;}
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


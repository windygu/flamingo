using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Seatstatus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Seatstatus
	{
		public Seatstatus()
		{}
		#region Model
		private string _seatstatusid;
		private string _seatid;
		private string _showplanid;
		private string _ticketingstate;
		private int? _lockedby;
		private int? _soldby;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string SeatId
		{
			set{ _seatid=value;}
			get{return _seatid;}
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
		public string TicketingState
		{
			set{ _ticketingstate=value;}
			get{return _ticketingstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LockedBy
		{
			set{ _lockedby=value;}
			get{return _lockedby;}
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


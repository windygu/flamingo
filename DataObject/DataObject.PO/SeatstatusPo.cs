using System;
namespace DataObject.PO
{
	public class SeatstatusPo
	{
		private string _SeatStatusId;
		private string _SeatId;
		private string _ShowPlanId;
		private string _TicketingState;
		private int _LockedBy;
		private int _SoldBy;
		private DateTime _Created = DateTime.Now;
		private DateTime _Updated = DateTime.Now;
		private int _ActiveFlag = 1;
		public string SEATSTATUSID
		{
			get
			{
				return this._SeatStatusId;
			}
			set
			{
				this._SeatStatusId = value;
			}
		}
		public string SEATID
		{
			get
			{
				return this._SeatId;
			}
			set
			{
				this._SeatId = value;
			}
		}
		public string SHOWPLANID
		{
			get
			{
				return this._ShowPlanId;
			}
			set
			{
				this._ShowPlanId = value;
			}
		}
		public string TICKETINGSTATE
		{
			get
			{
				return this._TicketingState;
			}
			set
			{
				this._TicketingState = value;
			}
		}
		public int LOCKEDBY
		{
			get
			{
				return this._LockedBy;
			}
			set
			{
				this._LockedBy = value;
			}
		}
		public int SOLDBY
		{
			get
			{
				return this._SoldBy;
			}
			set
			{
				this._SoldBy = value;
			}
		}
		public DateTime CREATED
		{
			get
			{
				return this._Created;
			}
			set
			{
				this._Created = value;
			}
		}
		public DateTime UPDATED
		{
			get
			{
				return this._Updated;
			}
			set
			{
				this._Updated = value;
			}
		}
		public int ACTIVEFLAG
		{
			get
			{
				return this._ActiveFlag;
			}
			set
			{
				this._ActiveFlag = value;
			}
		}
		public SeatstatusPo()
		{
		}
		public SeatstatusPo(string _SeatStatusId, string _SeatId, string _ShowPlanId, string _TicketingState, int _LockedBy, int _SoldBy, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._SeatStatusId = _SeatStatusId;
			this._SeatId = _SeatId;
			this._ShowPlanId = _ShowPlanId;
			this._TicketingState = _TicketingState;
			this._LockedBy = _LockedBy;
			this._SoldBy = _SoldBy;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

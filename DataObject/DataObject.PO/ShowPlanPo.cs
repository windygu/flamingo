using System;
namespace DataObject.PO
{
	public class ShowPlanPo
	{
		private string _ShowPlanId;
		private string _ShowPlanName;
		private string _FilmId;
		private int _Film_FilmModeId;
		private int _Position;
		private DateTime _StartTime = DateTime.Now;
		private DateTime _EndTime = DateTime.Now;
		private int _FilmLength = 0;
		private string _HallId;
		private string _DailyPlanId;
		private int _Timespan;
		private decimal _Ratio;
		private decimal _LowestPrice;
		private int _FareSettingId;
		private decimal _SinglePrice;
		private decimal _DoublePrice;
		private decimal _BoxPrice;
		private decimal _StudentPrice;
		private decimal _GroupPrice;
		private decimal _MemberPrice;
		private decimal _DiscountPrice;
		private int _ShowStatus;
		private int _ShowTypeId;
		private int _ShowGroup;
		private int _IsDiscounted;
		private int _IsCheckingNumber;
		private int _IsTicketChecking;
		private int _IsOnlineTicketing;
		private int _IsApproved;
		private int _IsSalable;
		private int _IsLocked;
		private int _Stagehand;
		private int _Projectionist;
		private DateTime _Created = DateTime.Now;
		private DateTime _Updated = DateTime.Now;
		private int _ActiveFlag = 1;
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
		public string SHOWPLANNAME
		{
			get
			{
				return this._ShowPlanName;
			}
			set
			{
				this._ShowPlanName = value;
			}
		}
		public string FILMID
		{
			get
			{
				return this._FilmId;
			}
			set
			{
				this._FilmId = value;
			}
		}
		public int FILM_FILMMODEID
		{
			get
			{
				return this._Film_FilmModeId;
			}
			set
			{
				this._Film_FilmModeId = value;
			}
		}
		public int POSITION
		{
			get
			{
				return this._Position;
			}
			set
			{
				this._Position = value;
			}
		}
		public DateTime STARTTIME
		{
			get
			{
				return this._StartTime;
			}
			set
			{
				this._StartTime = value;
			}
		}
		public DateTime ENDTTIME
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				this._EndTime = value;
			}
		}
		public int FILMLENGTH
		{
			get
			{
				return this._FilmLength;
			}
			set
			{
				this._FilmLength = value;
			}
		}
		public string HALLID
		{
			get
			{
				return this._HallId;
			}
			set
			{
				this._HallId = value;
			}
		}
		public string DAILYPLANID
		{
			get
			{
				return this._DailyPlanId;
			}
			set
			{
				this._DailyPlanId = value;
			}
		}
		public int TIMESPAN
		{
			get
			{
				return this._Timespan;
			}
			set
			{
				this._Timespan = value;
			}
		}
		public decimal RATIO
		{
			get
			{
				return this._Ratio;
			}
			set
			{
				this._Ratio = value;
			}
		}
		public decimal LOWESTPRICE
		{
			get
			{
				return this._LowestPrice;
			}
			set
			{
				this._LowestPrice = value;
			}
		}
		public int FARESETTINGID
		{
			get
			{
				return this._FareSettingId;
			}
			set
			{
				this._FareSettingId = value;
			}
		}
		public decimal SINGLEPRICE
		{
			get
			{
				return this._SinglePrice;
			}
			set
			{
				this._SinglePrice = value;
			}
		}
		public decimal DOUBLEPRICE
		{
			get
			{
				return this._DoublePrice;
			}
			set
			{
				this._DoublePrice = value;
			}
		}
		public decimal BOXPRICE
		{
			get
			{
				return this._BoxPrice;
			}
			set
			{
				this._BoxPrice = value;
			}
		}
		public decimal STUDENTPRICE
		{
			get
			{
				return this._StudentPrice;
			}
			set
			{
				this._StudentPrice = value;
			}
		}
		public decimal GROUPPRICE
		{
			get
			{
				return this._GroupPrice;
			}
			set
			{
				this._GroupPrice = value;
			}
		}
		public decimal MEMBERPRICE
		{
			get
			{
				return this._MemberPrice;
			}
			set
			{
				this._MemberPrice = value;
			}
		}
		public decimal DISCOUNTPRICE
		{
			get
			{
				return this._DiscountPrice;
			}
			set
			{
				this._DiscountPrice = value;
			}
		}
		public int SHOWSTATUS
		{
			get
			{
				return this._ShowStatus;
			}
			set
			{
				this._ShowStatus = value;
			}
		}
		public int SHOWTYPEID
		{
			get
			{
				return this._ShowTypeId;
			}
			set
			{
				this._ShowTypeId = value;
			}
		}
		public int SHOWGROUP
		{
			get
			{
				return this._ShowGroup;
			}
			set
			{
				this._ShowGroup = value;
			}
		}
		public int ISDISCOUNTED
		{
			get
			{
				return this._IsDiscounted;
			}
			set
			{
				this._IsDiscounted = value;
			}
		}
		public int ISCHECKINGNUMBER
		{
			get
			{
				return this._IsCheckingNumber;
			}
			set
			{
				this._IsCheckingNumber = value;
			}
		}
		public int ISTICKETCHECKING
		{
			get
			{
				return this._IsTicketChecking;
			}
			set
			{
				this._IsTicketChecking = value;
			}
		}
		public int ISONLINETICKETING
		{
			get
			{
				return this._IsOnlineTicketing;
			}
			set
			{
				this._IsOnlineTicketing = value;
			}
		}
		public int ISAPPROVED
		{
			get
			{
				return this._IsApproved;
			}
			set
			{
				this._IsApproved = value;
			}
		}
		public int ISSALABLE
		{
			get
			{
				return this._IsSalable;
			}
			set
			{
				this._IsSalable = value;
			}
		}
		public int ISLOCKED
		{
			get
			{
				return this._IsLocked;
			}
			set
			{
				this._IsLocked = value;
			}
		}
		public int STAGEHAND
		{
			get
			{
				return this._Stagehand;
			}
			set
			{
				this._Stagehand = value;
			}
		}
		public int PROJECTIONIST
		{
			get
			{
				return this._Projectionist;
			}
			set
			{
				this._Projectionist = value;
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
		public ShowPlanPo()
		{
		}
		public ShowPlanPo(string _ShowPlanId, string _ShowPlanName, string _FilmId, int _Film_FilmModeId, int _Position, DateTime _StartTime, DateTime _EndTime, string _HallId, string _DailyPlanId, int _Timespan, decimal _Ratio, decimal _LowestPrice, int _FareSettingId, decimal _SinglePrice, decimal _DoublePrice, decimal _BoxPrice, decimal _StudentPrice, decimal _GroupPrice, decimal _MemberPrice, decimal _DiscountPrice, int _ShowStatus, int _ShowTypeId, int _ShowGroup, int _IsDiscounted, int _IsCheckingNumber, int _IsTicketChecking, int _IsOnlineTicketing, int _IsApproved, int _IsSalable, int _IsLocked, int _Stagehand, int _Projectionist, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._ShowPlanId = _ShowPlanId;
			this._ShowPlanName = _ShowPlanName;
			this._FilmId = _FilmId;
			this._Film_FilmModeId = _Film_FilmModeId;
			this._Position = _Position;
			this._StartTime = _StartTime;
			this._EndTime = _EndTime;
			this._HallId = _HallId;
			this._DailyPlanId = _DailyPlanId;
			this._Timespan = _Timespan;
			this._Ratio = _Ratio;
			this._LowestPrice = _LowestPrice;
			this._FareSettingId = _FareSettingId;
			this._SinglePrice = _SinglePrice;
			this._DoublePrice = _DoublePrice;
			this._BoxPrice = _BoxPrice;
			this._StudentPrice = _StudentPrice;
			this._GroupPrice = _GroupPrice;
			this._MemberPrice = _MemberPrice;
			this._DiscountPrice = _DiscountPrice;
			this._ShowStatus = _ShowStatus;
			this._ShowTypeId = _ShowTypeId;
			this._ShowGroup = _ShowGroup;
			this._IsDiscounted = _IsDiscounted;
			this._IsCheckingNumber = _IsCheckingNumber;
			this._IsTicketChecking = _IsTicketChecking;
			this._IsOnlineTicketing = _IsOnlineTicketing;
			this._IsApproved = _IsApproved;
			this._IsSalable = _IsSalable;
			this._IsLocked = _IsLocked;
			this._Stagehand = _Stagehand;
			this._Projectionist = _Projectionist;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

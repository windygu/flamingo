using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Showplan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Showplan
	{
		public Showplan()
		{}
		#region Model
		private string _showplanid;
		private string _showplanname;
		private string _filmid;
		private string _position;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _filmlength;
		private string _hallid;
		private string _dailyplanid;
		private int? _timespan;
		private decimal? _ratio;
		private int? _specialofferid;
		private int? _faresettingid;
		private decimal? _singleprice;
		private decimal? _doubleprice;
		private decimal? _studentprice;
		private decimal? _groupprice;
		private decimal? _memberprice;
		private int? _showstatus;
		private int? _showtypeid;
		private int? _ischeckingnumber;
		private int? _isticketchecking;
		private int? _isonlineticketing;
		private int? _isapproved;
		private int? _issalable;
		private int? _islocked;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string ShowPlanName
		{
			set{ _showplanname=value;}
			get{return _showplanname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmId
		{
			set{ _filmid=value;}
			get{return _filmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FilmLength
		{
			set{ _filmlength=value;}
			get{return _filmlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HallId
		{
			set{ _hallid=value;}
			get{return _hallid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DailyPlanId
		{
			set{ _dailyplanid=value;}
			get{return _dailyplanid;}
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
		public decimal? Ratio
		{
			set{ _ratio=value;}
			get{return _ratio;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecialOfferId
		{
			set{ _specialofferid=value;}
			get{return _specialofferid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FareSettingId
		{
			set{ _faresettingid=value;}
			get{return _faresettingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SinglePrice
		{
			set{ _singleprice=value;}
			get{return _singleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DoublePrice
		{
			set{ _doubleprice=value;}
			get{return _doubleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StudentPrice
		{
			set{ _studentprice=value;}
			get{return _studentprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? GroupPrice
		{
			set{ _groupprice=value;}
			get{return _groupprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShowStatus
		{
			set{ _showstatus=value;}
			get{return _showstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShowTypeId
		{
			set{ _showtypeid=value;}
			get{return _showtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsCheckingNumber
		{
			set{ _ischeckingnumber=value;}
			get{return _ischeckingnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsTicketChecking
		{
			set{ _isticketchecking=value;}
			get{return _isticketchecking;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsOnlineTicketing
		{
			set{ _isonlineticketing=value;}
			get{return _isonlineticketing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsApproved
		{
			set{ _isapproved=value;}
			get{return _isapproved;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsSalable
		{
			set{ _issalable=value;}
			get{return _issalable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsLocked
		{
			set{ _islocked=value;}
			get{return _islocked;}
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


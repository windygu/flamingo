using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Dailyplan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dailyplan
	{
		public Dailyplan()
		{}
		#region Model
		private string _dailyplanid;
		private DateTime? _plandate;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _timespan;
		private int? _halls;
		private decimal? _ratio;
		private int? _isapproved;
		private int? _issalable;
		private int? _islocked;
		private string _theaterid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public DateTime? PlanDate
		{
			set{ _plandate=value;}
			get{return _plandate;}
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
		public int? Timespan
		{
			set{ _timespan=value;}
			get{return _timespan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Halls
		{
			set{ _halls=value;}
			get{return _halls;}
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
		public string TheaterId
		{
			set{ _theaterid=value;}
			get{return _theaterid;}
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


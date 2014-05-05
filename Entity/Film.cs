using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Film:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Film
	{
		public Film()
		{}
		#region Model
		private string _filmid;
		private string _filmcode;
		private string _filmname;
		private DateTime? _publishdate;
		private string _publisher;
		private string _producer;
		private string _director;
		private string _cast;
		private string _brief;
		private string _poster;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private int? _filmlength;
		private decimal? _ratio;
		private decimal? _lowestprice;
		private string _filmareaid;
		private string _filmcategoryid;
		private int? _hasmode;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string FilmCode
		{
			set{ _filmcode=value;}
			get{return _filmcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmName
		{
			set{ _filmname=value;}
			get{return _filmname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PublishDate
		{
			set{ _publishdate=value;}
			get{return _publishdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Publisher
		{
			set{ _publisher=value;}
			get{return _publisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Producer
		{
			set{ _producer=value;}
			get{return _producer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Director
		{
			set{ _director=value;}
			get{return _director;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cast
		{
			set{ _cast=value;}
			get{return _cast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Poster
		{
			set{ _poster=value;}
			get{return _poster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
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
		public decimal? Ratio
		{
			set{ _ratio=value;}
			get{return _ratio;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LowestPrice
		{
			set{ _lowestprice=value;}
			get{return _lowestprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmAreaId
		{
			set{ _filmareaid=value;}
			get{return _filmareaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmCategoryId
		{
			set{ _filmcategoryid=value;}
			get{return _filmcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HasMode
		{
			set{ _hasmode=value;}
			get{return _hasmode;}
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


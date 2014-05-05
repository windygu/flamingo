using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Seat:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Seat
	{
		public Seat()
		{}
		#region Model
		private string _seatid;
		private string _seatnumber;
		private int? _abscissa;
		private int? _ordinate;
		private int? _height;
		private int? _width;
		private string _property;
		private int? _seatingchartid;
		private string _blockid;
		private int? _seattypeid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string SeatNumber
		{
			set{ _seatnumber=value;}
			get{return _seatnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Abscissa
		{
			set{ _abscissa=value;}
			get{return _abscissa;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Ordinate
		{
			set{ _ordinate=value;}
			get{return _ordinate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Property
		{
			set{ _property=value;}
			get{return _property;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SeatingChartId
		{
			set{ _seatingchartid=value;}
			get{return _seatingchartid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BlockId
		{
			set{ _blockid=value;}
			get{return _blockid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SeatTypeId
		{
			set{ _seattypeid=value;}
			get{return _seattypeid;}
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


using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Seatingchart:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Seatingchart
	{
		public Seatingchart()
		{}
		#region Model
		private string _seatingchartid;
		private string _seatingchartname;
		private int? _level;
		private int? _seats;
		private int? _rows;
		private int? _columns;
		private int? _rowspace;
		private int? _columnspace;
		private string _shape;
		private string _bgcolour;
		private string _hallid;
		private int? _rotation;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string SeatingChartId
		{
			set{ _seatingchartid=value;}
			get{return _seatingchartid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeatingChartName
		{
			set{ _seatingchartname=value;}
			get{return _seatingchartname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Seats
		{
			set{ _seats=value;}
			get{return _seats;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Rows
		{
			set{ _rows=value;}
			get{return _rows;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Columns
		{
			set{ _columns=value;}
			get{return _columns;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RowSpace
		{
			set{ _rowspace=value;}
			get{return _rowspace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ColumnSpace
		{
			set{ _columnspace=value;}
			get{return _columnspace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Shape
		{
			set{ _shape=value;}
			get{return _shape;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BgColour
		{
			set{ _bgcolour=value;}
			get{return _bgcolour;}
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
		public int? Rotation
		{
			set{ _rotation=value;}
			get{return _rotation;}
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


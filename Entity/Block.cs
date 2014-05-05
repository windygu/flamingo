using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Block:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Block
	{
		public Block()
		{}
		#region Model
		private string _blockid;
		private string _blockname;
		private string _bgcolour;
		private int? _seats;
		private int? _hasblockprice;
		private string _seatingchartid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string BlockName
		{
			set{ _blockname=value;}
			get{return _blockname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bgcolour
		{
			set{ _bgcolour=value;}
			get{return _bgcolour;}
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
		public int? HasBlockPrice
		{
			set{ _hasblockprice=value;}
			get{return _hasblockprice;}
		}
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


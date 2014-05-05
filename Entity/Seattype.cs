using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Seattype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Seattype
	{
		public Seattype()
		{}
		#region Model
		private int _seattypeid;
		private string _seattypename;
		private int? _capacity;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int SeatTypeId
		{
			set{ _seattypeid=value;}
			get{return _seattypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeatTypeName
		{
			set{ _seattypename=value;}
			get{return _seattypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Capacity
		{
			set{ _capacity=value;}
			get{return _capacity;}
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


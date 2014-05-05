using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Faresetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Faresetting
	{
		public Faresetting()
		{}
		#region Model
		private int _faresettingid;
		private string _faresettingname;
		private decimal? _singleprice;
		private decimal? _doubleprice;
		private decimal? _studentprice;
		private decimal? _groupprice;
		private decimal? _memberprice;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int FareSettingId
		{
			set{ _faresettingid=value;}
			get{return _faresettingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FareSettingName
		{
			set{ _faresettingname=value;}
			get{return _faresettingname;}
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


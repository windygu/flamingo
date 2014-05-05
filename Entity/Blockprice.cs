using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Blockprice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Blockprice
	{
		public Blockprice()
		{}
		#region Model
		private int _blockpriceid;
		private string _blockid;
		private string _showplanid;
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
		public int BlockPriceId
		{
			set{ _blockpriceid=value;}
			get{return _blockpriceid;}
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
		public string ShowPlanId
		{
			set{ _showplanid=value;}
			get{return _showplanid;}
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


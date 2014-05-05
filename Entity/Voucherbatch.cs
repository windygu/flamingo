using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Voucherbatch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Voucherbatch
	{
		public Voucherbatch()
		{}
		#region Model
		private string _voucherbatchid;
		private string _vouchername;
		private decimal? _unitprice;
		private decimal? _totalprice;
		private int? _quantity;
		private string _serialscope;
		private DateTime? _releasedate;
		private DateTime? _expiredate;
		private string _description;
		private int? _customerid;
		private int? _vouchertypeid;
		private int? _templateid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string VoucherBatchId
		{
			set{ _voucherbatchid=value;}
			get{return _voucherbatchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoucherName
		{
			set{ _vouchername=value;}
			get{return _vouchername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SerialScope
		{
			set{ _serialscope=value;}
			get{return _serialscope;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReleaseDate
		{
			set{ _releasedate=value;}
			get{return _releasedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpireDate
		{
			set{ _expiredate=value;}
			get{return _expiredate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VoucherTypeId
		{
			set{ _vouchertypeid=value;}
			get{return _vouchertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TemplateId
		{
			set{ _templateid=value;}
			get{return _templateid;}
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


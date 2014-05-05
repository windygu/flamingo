using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Voucher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Voucher
	{
		public Voucher()
		{}
		#region Model
		private string _voucherid;
		private decimal? _price;
		private int? _vouchertypeid;
		private string _voucherbatchid;
		private int? _templateid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string VoucherId
		{
			set{ _voucherid=value;}
			get{return _voucherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
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
		public string VoucherBatchId
		{
			set{ _voucherbatchid=value;}
			get{return _voucherbatchid;}
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


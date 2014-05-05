using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Tax:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tax
	{
		public Tax()
		{}
		#region Model
		private int _taxid;
		private string _theaterid;
		private string _taxtype;
		private decimal? _taxrate;
		private string _chargemethod;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int TaxId
		{
			set{ _taxid=value;}
			get{return _taxid;}
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
		public string TaxType
		{
			set{ _taxtype=value;}
			get{return _taxtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TaxRate
		{
			set{ _taxrate=value;}
			get{return _taxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChargeMethod
		{
			set{ _chargemethod=value;}
			get{return _chargemethod;}
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


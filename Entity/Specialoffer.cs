using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Specialoffer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Specialoffer
	{
		public Specialoffer()
		{}
		#region Model
		private int _specialofferid;
		private string _specialoffername;
		private decimal? _specialofferprice;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int SpecialOfferId
		{
			set{ _specialofferid=value;}
			get{return _specialofferid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecialOfferName
		{
			set{ _specialoffername=value;}
			get{return _specialoffername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpecialOfferPrice
		{
			set{ _specialofferprice=value;}
			get{return _specialofferprice;}
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


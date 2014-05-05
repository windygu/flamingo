using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Theater:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Theater
	{
		public Theater()
		{}
		#region Model
		private string _theaterid;
		private string _theatertypeid;
		private string _theatername;
		private string _corporation;
		private string _telephone;
		private string _contactpeople;
		private int? _halls;
		private int? _seats;
		private string _province;
		private string _city;
		private string _district;
		private string _postcode;
		private string _address;
		private string _theatercode;
		private string _cinechainid;
		private string _serialnumber;
		private decimal? _ratio;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
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
		public string TheaterTypeId
		{
			set{ _theatertypeid=value;}
			get{return _theatertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheaterName
		{
			set{ _theatername=value;}
			get{return _theatername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Corporation
		{
			set{ _corporation=value;}
			get{return _corporation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactPeople
		{
			set{ _contactpeople=value;}
			get{return _contactpeople;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Halls
		{
			set{ _halls=value;}
			get{return _halls;}
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
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string District
		{
			set{ _district=value;}
			get{return _district;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheaterCode
		{
			set{ _theatercode=value;}
			get{return _theatercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CineChainId
		{
			set{ _cinechainid=value;}
			get{return _cinechainid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Ratio
		{
			set{ _ratio=value;}
			get{return _ratio;}
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


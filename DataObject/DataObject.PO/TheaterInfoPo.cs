using System;
namespace DataObject.PO
{
	public class TheaterInfoPo
	{
		private string _TheaterId;
		private string _AuthorizationId;
		private string _TheaterTypeId;
		private string _TheaterName;
		private string _Corporation;
		private string _Telephone;
		private string _ContactPeople;
		private int _Halls;
		private int _Seats;
		private string _Province;
		private string _City;
		private string _District;
		private string _PostCode;
		private string _Address;
		private string _TheaterCode;
		private string _CineChainId;
		private string _SerialNumber;
		private float _Ratio;
		public string THEATERID
		{
			get
			{
				return this._TheaterId;
			}
			set
			{
				this._TheaterId = value;
			}
		}
		public string AUTHORIZATIONID
		{
			get
			{
				return this._AuthorizationId;
			}
			set
			{
				this._AuthorizationId = value;
			}
		}
		public string THEATERTYPEID
		{
			get
			{
				return this._TheaterTypeId;
			}
			set
			{
				this._TheaterTypeId = value;
			}
		}
		public string THEATERNAME
		{
			get
			{
				return this._TheaterName;
			}
			set
			{
				this._TheaterName = value;
			}
		}
		public string CORPORATION
		{
			get
			{
				return this._Corporation;
			}
			set
			{
				this._Corporation = value;
			}
		}
		public string TELEPHONE
		{
			get
			{
				return this._Telephone;
			}
			set
			{
				this._Telephone = value;
			}
		}
		public string CONTACTPEOPLE
		{
			get
			{
				return this._ContactPeople;
			}
			set
			{
				this._ContactPeople = value;
			}
		}
		public int HALLS
		{
			get
			{
				return this._Halls;
			}
			set
			{
				this._Halls = value;
			}
		}
		public int SEATS
		{
			get
			{
				return this._Seats;
			}
			set
			{
				this._Seats = value;
			}
		}
		public string PROVINCE
		{
			get
			{
				return this._Province;
			}
			set
			{
				this._Province = value;
			}
		}
		public string CITY
		{
			get
			{
				return this._City;
			}
			set
			{
				this._City = value;
			}
		}
		public string DISTRICT
		{
			get
			{
				return this._District;
			}
			set
			{
				this._District = value;
			}
		}
		public string POSTCODE
		{
			get
			{
				return this._PostCode;
			}
			set
			{
				this._PostCode = value;
			}
		}
		public string ADDRESS
		{
			get
			{
				return this._Address;
			}
			set
			{
				this._Address = value;
			}
		}
		public string THEATERCODE
		{
			get
			{
				return this._TheaterCode;
			}
			set
			{
				this._TheaterCode = value;
			}
		}
		public string CINECHAINID
		{
			get
			{
				return this._CineChainId;
			}
			set
			{
				this._CineChainId = value;
			}
		}
		public string SERIALNUMER
		{
			get
			{
				return this._SerialNumber;
			}
			set
			{
				this._SerialNumber = value;
			}
		}
		public float RATIO
		{
			get
			{
				return this._Ratio;
			}
			set
			{
				this._Ratio = value;
			}
		}
		public TheaterInfoPo()
		{
		}
		public TheaterInfoPo(string _TheaterId, string _AuthorizationId, string _TheaterTypeId, string _TheaterName, string _Corporation, string _Telephone, string _ContactPeople, int _Halls, int _Seats, string _Province, string _City, string _District, string _PostCode, string _Address, string _TheaterCode, string _CineChainId, string _SerialNumber, float _Ratio)
		{
			this._TheaterId = _TheaterId;
			this._AuthorizationId = _AuthorizationId;
			this._TheaterTypeId = _TheaterTypeId;
			this._TheaterName = _TheaterName;
			this._Corporation = _Corporation;
			this._Telephone = _Telephone;
			this._ContactPeople = _ContactPeople;
			this._Halls = _Halls;
			this._Seats = _Seats;
			this._Province = _Province;
			this._City = _City;
			this._District = _District;
			this._PostCode = _PostCode;
			this._Address = _Address;
			this._TheaterCode = _TheaterCode;
			this._CineChainId = _CineChainId;
			this._SerialNumber = _SerialNumber;
			this._Ratio = _Ratio;
		}
	}
}

using System;
namespace DataObject.PO
{
	public class BlockPricePo
	{
		private string _BlockPriceId = "";
		private string _BlockId;
		private string _ShowPlanId;
		private decimal _SinglePrice;
		private decimal _DoublePrice;
		private decimal _BoxPrice;
		private decimal _StudentPrice;
		private decimal _GroupPrice;
		private decimal _MemberPrice;
		private decimal _DiscountPrice;
		private DateTime _Created = DateTime.Now;
		private DateTime _Updated = DateTime.Now;
		private int _ActiveFlag = 1;
		public string BLOCKPRICEID
		{
			get
			{
				return this._BlockPriceId;
			}
			set
			{
				this._BlockPriceId = value;
			}
		}
		public string BLOCKID
		{
			get
			{
				return this._BlockId;
			}
			set
			{
				this._BlockId = value;
			}
		}
		public string SHOWPLANID
		{
			get
			{
				return this._ShowPlanId;
			}
			set
			{
				this._ShowPlanId = value;
			}
		}
		public decimal SINGLEPRICE
		{
			get
			{
				return this._SinglePrice;
			}
			set
			{
				this._SinglePrice = value;
			}
		}
		public decimal DOUBLEPRICE
		{
			get
			{
				return this._DoublePrice;
			}
			set
			{
				this._DoublePrice = value;
			}
		}
		public decimal BOXPRICE
		{
			get
			{
				return this._BoxPrice;
			}
			set
			{
				this._BoxPrice = value;
			}
		}
		public decimal STUDENTPRICE
		{
			get
			{
				return this._StudentPrice;
			}
			set
			{
				this._StudentPrice = value;
			}
		}
		public decimal GROUPPRICE
		{
			get
			{
				return this._GroupPrice;
			}
			set
			{
				this._GroupPrice = value;
			}
		}
		public decimal MEMBERPRICE
		{
			get
			{
				return this._MemberPrice;
			}
			set
			{
				this._MemberPrice = value;
			}
		}
		public decimal DISCOUNTPRICE
		{
			get
			{
				return this._DiscountPrice;
			}
			set
			{
				this._DiscountPrice = value;
			}
		}
		public DateTime CREATED
		{
			get
			{
				return this._Created;
			}
			set
			{
				this._Created = value;
			}
		}
		public DateTime UPDATED
		{
			get
			{
				return this._Updated;
			}
			set
			{
				this._Updated = value;
			}
		}
		public int ACTIVEFLAG
		{
			get
			{
				return this._ActiveFlag;
			}
			set
			{
				this._ActiveFlag = value;
			}
		}
		public BlockPricePo()
		{
		}
		public BlockPricePo(string _BlockPriceId, string _BlockId, string _ShowPlanId, decimal _SinglePrice, decimal _DoublePrice, decimal _BoxPrice, decimal _StudentPrice, decimal _GroupPrice, decimal _MemberPrice, decimal _DiscountPrice, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._BlockPriceId = _BlockPriceId;
			this._BlockId = _BlockId;
			this._ShowPlanId = _ShowPlanId;
			this._SinglePrice = _SinglePrice;
			this._DoublePrice = _DoublePrice;
			this._BoxPrice = _BoxPrice;
			this._StudentPrice = _StudentPrice;
			this._GroupPrice = _GroupPrice;
			this._MemberPrice = _MemberPrice;
			this._DiscountPrice = _DiscountPrice;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

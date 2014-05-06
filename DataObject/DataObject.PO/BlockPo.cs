using System;
namespace DataObject.PO
{
	public class BlockPo
	{
		private string _BlockId;
		private string _BlockName;
		private int _Bgcolour;
		private int _Seats;
		private string _SeatingChartId;
		private int _HasBlockPrice = 1;
		private DateTime _Created = DateTime.Now;
		private DateTime _Updated = DateTime.Now;
		private int _ActiveFlag = 1;
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
		public string BLOCKNAME
		{
			get
			{
				return this._BlockName;
			}
			set
			{
				this._BlockName = value;
			}
		}
		public int BGCOLOUR
		{
			get
			{
				return this._Bgcolour;
			}
			set
			{
				this._Bgcolour = value;
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
		public string SEATINGCHARTID
		{
			get
			{
				return this._SeatingChartId;
			}
			set
			{
				this._SeatingChartId = value;
			}
		}
		public int HASBLOCKPRICE
		{
			get
			{
				return this._HasBlockPrice;
			}
			set
			{
				this._HasBlockPrice = value;
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
		public BlockPo()
		{
		}
		public BlockPo(string _BlockId, string _BlockName, int _Bgcolour, int _Seats, string _SeatingChartId, int _HasBlockPrice, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._BlockId = _BlockId;
			this._BlockName = _BlockName;
			this._Bgcolour = _Bgcolour;
			this._Seats = _Seats;
			this._SeatingChartId = _SeatingChartId;
			this._HasBlockPrice = _HasBlockPrice;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

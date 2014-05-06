using System;
namespace DataObject.PO
{
	public class SeatPo
	{
		private string _SeatId;
		private string _RowNumber;
		private string _ColumnNumber;
		private string _SeatNumber;
		private int _Xaxis;
		private int _Yaxis;
		private int _Height;
		private int _Width;
		private string _Property;
		private string _SeatGroup;
		private int _Capacity = 1;
		private string _SeatingChartId;
		private string _BlockId;
		private string _SeatType;
		private DateTime _Created;
		private DateTime _Updated;
		private int _ActiveFlag;
		public string SEATID
		{
			get
			{
				return this._SeatId;
			}
			set
			{
				this._SeatId = value;
			}
		}
		public string ROWNUMBER
		{
			get
			{
				return this._RowNumber;
			}
			set
			{
				this._RowNumber = value;
			}
		}
		public string COLUMNNUMBER
		{
			get
			{
				return this._ColumnNumber;
			}
			set
			{
				this._ColumnNumber = value;
			}
		}
		public string SEATNUMBER
		{
			get
			{
				return this._SeatNumber;
			}
			set
			{
				this._SeatNumber = value;
			}
		}
		public int XAXIS
		{
			get
			{
				return this._Xaxis;
			}
			set
			{
				this._Xaxis = value;
			}
		}
		public int YAXIS
		{
			get
			{
				return this._Yaxis;
			}
			set
			{
				this._Yaxis = value;
			}
		}
		public int HEIGHT
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
			}
		}
		public int WIDTH
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
			}
		}
		public string PROPERTY
		{
			get
			{
				return this._Property;
			}
			set
			{
				this._Property = value;
			}
		}
		public string SEATGROUP
		{
			get
			{
				return this._SeatGroup;
			}
			set
			{
				this._SeatGroup = value;
			}
		}
		public int CAPACITY
		{
			get
			{
				return this._Capacity;
			}
			set
			{
				this._Capacity = value;
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
		public string SEATTYPE
		{
			get
			{
				return this._SeatType;
			}
			set
			{
				this._SeatType = value;
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
		public SeatPo()
		{
		}
		public SeatPo(string _SeatId, string _RowNumber, string _ColumnNumber, string _SeatNumber, int _Xaxis, int _Yaxis, int _Height, int _Width, string _Property, string _SeatGroup, int _Capacity, string _SeatingChartId, string _BlockId, string _SeatType, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._SeatId = _SeatId;
			this._RowNumber = _RowNumber;
			this._ColumnNumber = _ColumnNumber;
			this._SeatNumber = _SeatNumber;
			this._Xaxis = _Xaxis;
			this._Yaxis = _Yaxis;
			this._Height = _Height;
			this._Width = _Width;
			this._Property = _Property;
			this._Capacity = _Capacity;
			this._SeatingChartId = _SeatingChartId;
			this._BlockId = _BlockId;
			this._SeatType = _SeatType;
			this._SeatGroup = _SeatGroup;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

using System;
namespace DataObject.PO
{
	public class SeatingchartPo
	{
		private string _SeatingChartId;
		private string _SeatingChartName;
		private int _Level;
		private int _Seats;
		private int _Rows;
		private int _Columns;
		private int _RowSpace;
		private int _ColumnSpace;
		private string _Shape;
		private string _BgColour;
		private string _HallId;
		private string _TheaterId;
		private int _Rotation;
		private DateTime _Created = DateTime.Now;
		private DateTime _Updated = DateTime.Now;
		private int _ActiveFlag = 1;
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
		public string SEATINGCHARTNAME
		{
			get
			{
				return this._SeatingChartName;
			}
			set
			{
				this._SeatingChartName = value;
			}
		}
		public int LEVEL
		{
			get
			{
				return this._Level;
			}
			set
			{
				this._Level = value;
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
		public int ROWS
		{
			get
			{
				return this._Rows;
			}
			set
			{
				this._Rows = value;
			}
		}
		public int COLUMNS
		{
			get
			{
				return this._Columns;
			}
			set
			{
				this._Columns = value;
			}
		}
		public int ROWSPACE
		{
			get
			{
				return this._RowSpace;
			}
			set
			{
				this._RowSpace = value;
			}
		}
		public int COLUMNSPACE
		{
			get
			{
				return this._ColumnSpace;
			}
			set
			{
				this._ColumnSpace = value;
			}
		}
		public string SHAPE
		{
			get
			{
				return this._Shape;
			}
			set
			{
				this._Shape = value;
			}
		}
		public string BGCOLOUR
		{
			get
			{
				return this._BgColour;
			}
			set
			{
				this._BgColour = value;
			}
		}
		public string HALLID
		{
			get
			{
				return this._HallId;
			}
			set
			{
				this._HallId = value;
			}
		}
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
		public int ROTATION
		{
			get
			{
				return this._Rotation;
			}
			set
			{
				this._Rotation = value;
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
		public SeatingchartPo()
		{
		}
		public SeatingchartPo(string _SeatingChartId, string _SeatingChartName, int _Level, int _Seats, int _Rows, int _Columns, int _RowSpace, int _ColumnSpace, string _Shape, string _BgColour, string _HallId, string _TheaterId, int _Rotation, DateTime _Created, DateTime _Updated, int _ActiveFlag)
		{
			this._SeatingChartId = _SeatingChartId;
			this._SeatingChartName = _SeatingChartName;
			this._Level = _Level;
			this._Seats = _Seats;
			this._Rows = _Rows;
			this._Columns = _Columns;
			this._RowSpace = _RowSpace;
			this._ColumnSpace = _ColumnSpace;
			this._Shape = _Shape;
			this._BgColour = _BgColour;
			this._HallId = _HallId;
			this._TheaterId = _TheaterId;
			this._Rotation = _Rotation;
			this._Created = _Created;
			this._Updated = _Updated;
			this._ActiveFlag = _ActiveFlag;
		}
	}
}

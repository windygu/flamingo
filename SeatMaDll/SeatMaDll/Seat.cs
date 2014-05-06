using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class Seat
	{
		public string _seatFlag = "1";
		public string _seatStatusFlag = "0";
		public string _seatRowNumber = "1";
		public string _seatRowNumberDisplay = "1";
		public string _seatColumn = "0";
		public string _seatNumber = "0排0号";
		public string _seatId = "0";
		public string _seatDisplay = "0";
		public int _seatColumnCount = 1;
		public int _seatPosX = 0;
		public int _seatPosY = 0;
		public int _seatWidth = 40;
		public int _seatHeight = 30;
		public string _seatProperty = "";
		public string _seatBlockId = "1";
		public string _seatSeatingChartId = "";
		public string _seatSeatGroup = "";
		public bool _IsUsedBackColor = false;
		public int _BackColor = 0;
		public List<Seat> _brotherList = new List<Seat>();
		public Seat()
		{
		}
		public Seat(string seatFlag, string seatStatusFlag, string seatRowNumber, string seatRowNumberDisplay, string seatId, string seatColumn, string seatNumber, string seatDisplay, int seatColumnCount, int seatPosX, int seatPosY, int seatWidth, int seatHeight, string seatSeatingChartId, string seatBlockId)
		{
			this._seatFlag = seatFlag;
			this._seatStatusFlag = seatStatusFlag;
			this._seatRowNumber = seatRowNumber;
			this._seatRowNumberDisplay = seatRowNumberDisplay;
			this._seatId = seatId;
			this._seatColumn = seatColumn;
			this._seatNumber = seatNumber;
			this._seatDisplay = seatDisplay;
			this._seatColumnCount = seatColumnCount;
			this._seatPosX = seatPosX;
			this._seatPosY = seatPosY;
			this._seatWidth = seatWidth;
			this._seatHeight = seatHeight;
			this._seatSeatingChartId = seatSeatingChartId;
			this._seatBlockId = seatBlockId;
		}
	}
}

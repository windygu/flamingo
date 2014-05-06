using System;
namespace SeatMaDll
{
	public class SeatStatusSim
	{
		public string _seatId = "0";
		public string _seatType = "0";
		public string _seatStatusFlag = "0";
		public string _seatRowNumber = "1";
		public string _seatColumn = "0";
		public string _seatNumber = "0排0号";
		public SeatStatusSim()
		{
		}
		public SeatStatusSim(string seatId, string seatType, string seatStatusFlag, string seatRowNumber, string seatColumn, string seatNumber)
		{
			this._seatId = seatId;
			this._seatType = seatType;
			this._seatStatusFlag = seatStatusFlag;
			this._seatRowNumber = seatRowNumber;
			this._seatColumn = seatColumn;
			this._seatNumber = seatNumber;
		}
	}
}

using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class SeatRows
	{
		public string _seatRowNumber = "1";
		public List<Seat> _listSiteItem = new List<Seat>();
		public SeatRows(string seatRowNumber)
		{
			this._seatRowNumber = seatRowNumber;
		}
	}
}

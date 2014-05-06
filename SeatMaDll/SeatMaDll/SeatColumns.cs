using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class SeatColumns
	{
		public string _seatColumn = "1";
		public List<Seat> _listSiteItem = new List<Seat>();
		public SeatColumns(string seatColumn)
		{
			this._seatColumn = seatColumn;
		}
	}
}

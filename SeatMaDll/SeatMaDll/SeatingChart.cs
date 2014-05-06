using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class SeatingChart
	{
		public string SeatingChartId = string.Empty;
		public string SeatingChartName = string.Empty;
		public int Level = 1;
		public int Seats = 0;
		public int Rows = 0;
		public int Columns = 0;
		public int RowSpace = 0;
		public int ColumnSpace = 0;
		public string Shape = "";
		public string BgColour = "";
		public string HallId = string.Empty;
		public string TheaterId = string.Empty;
		public int Rotation = 0;
		public string DefaultBlockId = string.Empty;
		public List<Seat> _listSiteItem = new List<Seat>();
		public override string ToString()
		{
			return this.SeatingChartName;
		}
	}
}

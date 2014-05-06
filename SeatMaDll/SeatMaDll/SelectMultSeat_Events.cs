using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class SelectMultSeat_Events : EventArgs
	{
		public List<BHSeatControl> m_bhSeatList = null;
		public SelectMultSeat_Events()
		{
		}
		public SelectMultSeat_Events(List<BHSeatControl> bhSeatList)
		{
			this.m_bhSeatList = bhSeatList;
		}
	}
}

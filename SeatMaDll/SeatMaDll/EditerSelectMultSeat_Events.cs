using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class EditerSelectMultSeat_Events : EventArgs
	{
		public List<BHSeatControlEditer> m_bhSeatList = null;
		public EditerSelectMultSeat_Events()
		{
		}
		public EditerSelectMultSeat_Events(List<BHSeatControlEditer> bhSeatList)
		{
			this.m_bhSeatList = bhSeatList;
		}
	}
}

using System;
namespace SeatMaDll
{
	public class SelectOneSeat_Events : EventArgs
	{
		public BHSeatControl m_bhSeat = null;
		public SelectOneSeat_Events()
		{
		}
		public SelectOneSeat_Events(BHSeatControl bhSeat)
		{
			this.m_bhSeat = bhSeat;
		}
	}
}

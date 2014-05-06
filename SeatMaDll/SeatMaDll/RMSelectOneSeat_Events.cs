using System;
namespace SeatMaDll
{
	public class RMSelectOneSeat_Events : EventArgs
	{
		public BHSeatControl m_bhSeat = null;
		public int m_nX = 0;
		public int m_nY = 0;
		public RMSelectOneSeat_Events()
		{
		}
		public RMSelectOneSeat_Events(BHSeatControl bhSeat, int _nX, int _nY)
		{
			this.m_bhSeat = bhSeat;
			this.m_nX = _nX;
			this.m_nY = _nY;
		}
	}
}

using System;
namespace SeatMaDll
{
	public class EditerRMSelectOneSeat_Events : EventArgs
	{
		public BHSeatControlEditer m_bhSeat = null;
		public int m_nX = 0;
		public int m_nY = 0;
		public EditerRMSelectOneSeat_Events()
		{
		}
		public EditerRMSelectOneSeat_Events(BHSeatControlEditer bhSeat, int _nX, int _nY)
		{
			this.m_bhSeat = bhSeat;
			this.m_nX = _nX;
			this.m_nY = _nY;
		}
	}
}

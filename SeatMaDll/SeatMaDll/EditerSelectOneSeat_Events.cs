using System;
namespace SeatMaDll
{
	public class EditerSelectOneSeat_Events : EventArgs
	{
		public BHSeatControlEditer m_bhSeat = null;
		public EditerSelectOneSeat_Events()
		{
		}
		public EditerSelectOneSeat_Events(BHSeatControlEditer bhSeat)
		{
			this.m_bhSeat = bhSeat;
		}
	}
}

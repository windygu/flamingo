using System;
using System.Collections.Generic;
namespace SeatMaDll
{
	public class SeatType
	{
		public string _seatTypeCode = "0";
		public string _seatTypeName = "单座";
		public SeatType()
		{
		}
		public SeatType(string seatTypeCode, string seatTypeName)
		{
			this._seatTypeCode = seatTypeCode;
			this._seatTypeName = seatTypeName;
		}
		public override string ToString()
		{
			return string.IsNullOrEmpty(this._seatTypeCode) ? "0" : (this._seatTypeCode + "|" + this._seatTypeName);
		}
		public override bool Equals(object obj)
		{
			bool result;
			if (null == obj)
			{
				result = false;
			}
			else
			{
				if (obj.GetType() != typeof(SeatType) && !obj.GetType().IsSubclassOf(typeof(SeatType)))
				{
					result = false;
				}
				else
				{
					SeatType seatType = (SeatType)obj;
					result = (this._seatTypeCode == seatType._seatTypeCode);
				}
			}
			return result;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public static List<SeatType> SeatTypeCollection()
		{
			List<SeatType> list = new List<SeatType>();
			SeatType item = new SeatType("0", "单座");
			list.Add(item);
			item = new SeatType("3", "残障座");
			list.Add(item);
			item = new SeatType("4", "残障护理");
			list.Add(item);
			item = new SeatType("5", "不事宜观看");
			list.Add(item);
			item = new SeatType("6", "停用");
			list.Add(item);
			item = new SeatType("7", "工作席");
			list.Add(item);
			item = new SeatType("8", "特殊");
			list.Add(item);
			return list;
		}
	}
}

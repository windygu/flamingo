using System;
namespace SeatMaDll
{
	public class CUtil
	{
		public static bool fucCheckNUM(ref string NUM)
		{
			bool result;
			if (NUM.Trim() == "-")
			{
				result = false;
			}
			else
			{
				int num = 0;
				bool flag = false;
				string text = "0123456789.-";
				if (NUM.Trim().Length <= 0)
				{
					NUM = "0";
					result = true;
				}
				else
				{
					if (NUM.Trim() == "-" || NUM.Trim() == ".")
					{
						NUM = "0";
						result = true;
					}
					else
					{
						for (int i = 0; i < NUM.Length; i++)
						{
							for (int j = 0; j < 11; j++)
							{
								if (NUM[i].Equals(text[j]))
								{
									if (j == 10)
									{
										num++;
									}
									flag = true;
									break;
								}
								flag = false;
							}
							if (!flag)
							{
								break;
							}
						}
						result = (num <= 1 && flag);
					}
				}
			}
			return result;
		}
		public static bool IsNumber(string sz)
		{
			string text = "-0123456789";
			char[] array = sz.ToCharArray();
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				if (!text.Contains(array[i].ToString()))
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		public static bool IsNumber2(string sz)
		{
			string text = "0123456789";
			char[] array = sz.ToCharArray();
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				if (!text.Contains(array[i].ToString()))
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		public static bool IsDecimal(string sz)
		{
			string text = "-0123456789.";
			char[] array = sz.ToCharArray();
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				if (!text.Contains(array[i].ToString()))
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		public static int GetDecimalLenth(string sz)
		{
			int num = sz.IndexOf(".");
			int length;
			if (num >= 0)
			{
				length = sz.Substring(0, num).Length;
			}
			else
			{
				length = sz.Length;
			}
			return length;
		}
	}
}

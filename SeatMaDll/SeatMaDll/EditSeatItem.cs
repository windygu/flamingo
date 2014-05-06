using System;
using System.Drawing;
using System.Text;
namespace SeatMaDll
{
	public class EditSeatItem
	{
		private static string[] ChineseNumber = new string[]
		{
			"零",
			"一",
			"二",
			"三",
			"四",
			"五",
			"六",
			"七",
			"八",
			"九"
		};
		private static string[] ChineseNumberDigit = new string[]
		{
			"",
			"十",
			"百",
			"千",
			"万"
		};
		public static string ConvertToCN(int nValue)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = nValue.ToString();
			int length = text.Length;
			if (length > 5)
			{
				throw new Exception("数值不能大于万级!");
			}
			for (int i = 0; i < length; i++)
			{
				int num = length - 1 - i;
				int num2 = int.Parse(text.Substring(i, 1));
				if (length == 2)
				{
					if (i == 0)
					{
						if (num2 != 1)
						{
							stringBuilder.Append(EditSeatItem.ChineseNumber[num2]);
						}
					}
					else
					{
						if (num2 != 0)
						{
							stringBuilder.Append(EditSeatItem.ChineseNumber[num2]);
						}
					}
				}
				else
				{
					stringBuilder.Append(EditSeatItem.ChineseNumber[num2]);
				}
				if (length != 2 || num != 0)
				{
					stringBuilder.Append(EditSeatItem.ChineseNumberDigit[num]);
				}
			}
			return stringBuilder.ToString();
		}
		public static string GetString_ByControlFlag(BHSeatControl.BHSeatType BHsiteFlag)
		{
			string result;
			if (BHsiteFlag == BHSeatControl.BHSeatType.One)
			{
				result = "0";
			}
			else
			{
				if (BHsiteFlag == BHSeatControl.BHSeatType.Two)
				{
					result = "1";
				}
				else
				{
					if (BHsiteFlag == BHSeatControl.BHSeatType.Box)
					{
						result = "2";
					}
					else
					{
						if (BHsiteFlag == BHSeatControl.BHSeatType.Deformity)
						{
							result = "3";
						}
						else
						{
							if (BHsiteFlag == BHSeatControl.BHSeatType.DeformityOne)
							{
								result = "4";
							}
							else
							{
								if (BHsiteFlag == BHSeatControl.BHSeatType.NotFit)
								{
									result = "5";
								}
								else
								{
									if (BHsiteFlag == BHSeatControl.BHSeatType.Stoped)
									{
										result = "6";
									}
									else
									{
										if (BHsiteFlag == BHSeatControl.BHSeatType.Worked)
										{
											result = "7";
										}
										else
										{
											if (BHsiteFlag == BHSeatControl.BHSeatType.Special)
											{
												result = "8";
											}
											else
											{
												result = "0";
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static string GetControlStatus_ByFlag(BHSeatControl.BHSeatStatus BHSeatStatusFlag)
		{
			string result;
			if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.Empty)
			{
				result = "0";
			}
			else
			{
				if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.Lock)
				{
					result = "1";
				}
				else
				{
					if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.SpecialLock)
					{
						result = "2";
					}
					else
					{
						if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.PrSuccess)
						{
							result = "3";
						}
						else
						{
							if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.Success)
							{
								result = "4";
							}
							else
							{
								if (BHSeatStatusFlag == BHSeatControl.BHSeatStatus.Selected)
								{
									result = "5";
								}
								else
								{
									result = "0";
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static BHSeatControl.BHSeatType GetControl_ByFlag(string szSiteFlag)
		{
			BHSeatControl.BHSeatType result;
			if (szSiteFlag == "0")
			{
				result = BHSeatControl.BHSeatType.One;
			}
			else
			{
				if (szSiteFlag == "1")
				{
					result = BHSeatControl.BHSeatType.Two;
				}
				else
				{
					if (szSiteFlag == "2")
					{
						result = BHSeatControl.BHSeatType.Box;
					}
					else
					{
						if (szSiteFlag == "3")
						{
							result = BHSeatControl.BHSeatType.Deformity;
						}
						else
						{
							if (szSiteFlag == "4")
							{
								result = BHSeatControl.BHSeatType.DeformityOne;
							}
							else
							{
								if (szSiteFlag == "5")
								{
									result = BHSeatControl.BHSeatType.NotFit;
								}
								else
								{
									if (szSiteFlag == "6")
									{
										result = BHSeatControl.BHSeatType.Stoped;
									}
									else
									{
										if (szSiteFlag == "7")
										{
											result = BHSeatControl.BHSeatType.Worked;
										}
										else
										{
											if (szSiteFlag == "8")
											{
												result = BHSeatControl.BHSeatType.Special;
											}
											else
											{
												result = BHSeatControl.BHSeatType.One;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static BHSeatControl.BHSeatStatus GetControlStatus_ByFlag(string szSiteStatusFlag)
		{
			BHSeatControl.BHSeatStatus result;
			if (szSiteStatusFlag == "0")
			{
				result = BHSeatControl.BHSeatStatus.Empty;
			}
			else
			{
				if (szSiteStatusFlag == "1")
				{
					result = BHSeatControl.BHSeatStatus.Lock;
				}
				else
				{
					if (szSiteStatusFlag == "2")
					{
						result = BHSeatControl.BHSeatStatus.SpecialLock;
					}
					else
					{
						if (szSiteStatusFlag == "3")
						{
							result = BHSeatControl.BHSeatStatus.PrSuccess;
						}
						else
						{
							if (szSiteStatusFlag == "4")
							{
								result = BHSeatControl.BHSeatStatus.Success;
							}
							else
							{
								if (szSiteStatusFlag == "5")
								{
									result = BHSeatControl.BHSeatStatus.Selected;
								}
								else
								{
									result = BHSeatControl.BHSeatStatus.Empty;
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static Image GetControlImg(string szSeatFlag)
		{
			Image result;
			if (szSeatFlag == "0")
			{
				result = SeatResource.ImgEmpty;
			}
			else
			{
				if (szSeatFlag == "1")
				{
					result = SeatResource.ImgEmpty;
				}
				else
				{
					if (szSeatFlag == "2")
					{
						result = SeatResource.ImgEmpty;
					}
					else
					{
						if (szSeatFlag == "3")
						{
							result = SeatResource.ImgDeformity;
						}
						else
						{
							if (szSeatFlag == "4")
							{
								result = SeatResource.ImgDeformityOne;
							}
							else
							{
								if (szSeatFlag == "5")
								{
									result = SeatResource.ImgNotFit;
								}
								else
								{
									if (szSeatFlag == "6")
									{
										result = SeatResource.ImgStoped;
									}
									else
									{
										if (szSeatFlag == "7")
										{
											result = SeatResource.ImgWorked;
										}
										else
										{
											if (szSeatFlag == "8")
											{
												result = SeatResource.ImgSpecial;
											}
											else
											{
												result = SeatResource.ImgEmpty;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static Image GetControlExtendImg(string szSeatStatusFlag)
		{
			Image result;
			if (szSeatStatusFlag == "0")
			{
				result = null;
			}
			else
			{
				if (szSeatStatusFlag == "1")
				{
					result = SeatResource.ImgLocked;
				}
				else
				{
					if (szSeatStatusFlag == "2")
					{
						result = SeatResource.ImgSpecialLocked;
					}
					else
					{
						if (szSeatStatusFlag == "3")
						{
							result = SeatResource.ImgPrSuccess;
						}
						else
						{
							if (szSeatStatusFlag == "4")
							{
								result = SeatResource.ImgSuccess;
							}
							else
							{
								result = null;
							}
						}
					}
				}
			}
			return result;
		}
	}
}

using System;
namespace SeatMaDll
{
	public class EditSeatInfo
	{
		public string _szTheaterName = "";
		public string _szHallName = "1";
		public string _szLevelName = "1";
		public string _szBlockName = "1";
		public string _szShapeCode = "0";
		public string _szShapeName = "左上";
		public string _nRuleCode = "0";
		public string _nRuleName = "从左顺序编号";
		public int _nFirRowColumnCount = 10;
		public int _nRows = 10;
		public int _nIncreaseNumber = 1;
		public int _nFirstRowNum = 1;
		public string _szFirsrRowText = "";
		public string _szRowNumType = "int";
		public int _nUnitWidth = 40;
		public int _nUnitHeight = 30;
		public int _nRowSpace = 8;
		public int _nColumnSpace = 5;
		public int _nRotation = 0;
		public string _szRowNumberDispMode = "数字";
		public string _szSeatingChartName = "";
		public SeatingChart _ObjSeatingChart = new SeatingChart();
		public static bool ValidatszFirsrRowInput(string szFirsrRowText)
		{
			return CUtil.IsNumber2(szFirsrRowText.Trim()) || szFirsrRowText.Trim().Length <= 2;
		}
		public static bool CheckFirstRowNum(EditSeatInfo esi, ref string szMsg)
		{
			bool result;
			if (esi._szFirsrRowText != null && !esi._szFirsrRowText.Equals(""))
			{
				try
				{
					esi._nFirstRowNum = Convert.ToInt32(esi._szFirsrRowText);
					esi._szRowNumType = "int";
					result = true;
					return result;
				}
				catch
				{
					if (esi._szFirsrRowText.Length > 2)
					{
						szMsg = "排号为字母的时候，不能超过2个字符！";
						result = false;
						return result;
					}
					if (esi._szFirsrRowText.Length == 1)
					{
						int num = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[0]);
						if (num < 73 && num - 65 + esi._nRows - 1 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
						if (num > 73 && num < 79 && num - 65 + esi._nRows - 2 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
						if (num > 79 && num < 90 && num - 65 + esi._nRows - 3 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
						if (num >= 97 && num < 105 && num - 97 + esi._nRows - 1 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
						if (num > 105 && num < 111 && num - 97 + esi._nRows - 2 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
						if (num > 111 && num - 97 + esi._nRows - 3 > 600)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ！";
							result = false;
							return result;
						}
					}
					else
					{
						int num2 = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[0]);
						int num3 = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[1]);
						if ((num2 < 97 && num3 >= 97) || (num2 >= 97 && num3 < 97))
						{
							szMsg = "排号为字母的时候，不允许使用类似Aa或aA的排号！";
							result = false;
							return result;
						}
						if (num2 < 73)
						{
							num2 = num2 - 65 + 1 - 2;
						}
						else
						{
							if (num2 > 73 && num2 < 79)
							{
								num2 = num2 - 65 + 1 - 1;
							}
							else
							{
								if (num2 > 79 && num2 < 90)
								{
									num2 = num2 - 65 + 1;
								}
								else
								{
									if (num2 >= 97 && num2 < 105)
									{
										num2 = num2 - 97 + 1 - 2;
									}
									else
									{
										if (num2 > 105 && num2 < 111)
										{
											num2 = num2 - 97 + 1 - 1;
										}
										else
										{
											if (num2 > 111)
											{
												num2 = num2 - 97 + 1;
											}
										}
									}
								}
							}
						}
						if (num3 < 73)
						{
							num3 = num2 - 65 + 1 - 2;
						}
						else
						{
							if (num3 > 73 && num3 < 79)
							{
								num3 = num2 - 65 + 1 - 1;
							}
							else
							{
								if (num3 > 79 && num3 < 90)
								{
									num3 = num3 - 65 + 1;
								}
								else
								{
									if (num3 >= 97 && num3 < 105)
									{
										num3 = num3 - 97 + 1 - 2;
									}
									else
									{
										if (num3 > 105 && num3 < 111)
										{
											num3 = num3 - 97 + 1 - 1;
										}
										else
										{
											if (num3 > 111)
											{
												num3 = num3 - 97 + 1;
											}
										}
									}
								}
							}
						}
						if (num2 * num3 + esi._nRows > 576)
						{
							szMsg = "排号为字母的时候，最大排号不能超过ZZ或zz！";
							result = false;
							return result;
						}
					}
					esi._szRowNumType = "char";
					esi._nFirstRowNum = 1;
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public static string GetRowNum_Int(EditSeatInfo esi, int nRow)
		{
			string result = "";
			if (esi._szRowNumType.Equals("int"))
			{
				result = (nRow + Convert.ToInt32(esi._szFirsrRowText)).ToString();
			}
			return result;
		}
		public static void GetFirstData_Char(EditSeatInfo esi, ref int iStep, ref int iFirstStep, ref int iLastStep, ref int firstNum, ref int lastNum)
		{
			iStep = 0;
			iFirstStep = 1;
			iLastStep = 1;
			firstNum = 0;
			lastNum = 0;
			if (esi._szFirsrRowText.Length == 2)
			{
				firstNum = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[0]);
				lastNum = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[1]);
				if (firstNum >= 97)
				{
					iFirstStep = firstNum - 96;
				}
				else
				{
					iFirstStep = firstNum - 64;
				}
				if (lastNum >= 97)
				{
					iLastStep = lastNum - 96;
				}
				else
				{
					iLastStep = lastNum - 64;
				}
			}
			else
			{
				if (esi._szFirsrRowText.Length == 1)
				{
					lastNum = Convert.ToInt32(esi._szFirsrRowText.ToCharArray()[0]);
					if (lastNum >= 97)
					{
						iLastStep = lastNum - 96;
					}
					else
					{
						iLastStep = lastNum - 64;
					}
					iFirstStep = 1;
					firstNum = 97;
				}
			}
		}
		public static string GetRowNum_Char(EditSeatInfo esi, ref int iStep, ref int iFirstStep, ref int iLastStep, ref int firstNum, ref int lastNum)
		{
			if (iLastStep + iStep > 26)
			{
				firstNum++;
				iFirstStep++;
				lastNum = ((lastNum >= 97) ? 97 : 65);
				iLastStep = 1;
			}
			else
			{
				lastNum += iStep;
				iLastStep += iStep;
			}
			string result;
			if (esi._szFirsrRowText.Length == 1 && iFirstStep == 1)
			{
				result = Convert.ToChar(lastNum).ToString();
			}
			else
			{
				result = Convert.ToChar(firstNum).ToString() + Convert.ToChar(lastNum).ToString();
			}
			return result;
		}
		public static string GetRowNum_Char0(EditSeatInfo esi, ref int iStep, ref int iFirstStep, ref int iLastStep, ref int firstNum, ref int lastNum)
		{
			string text = "";
			if (!esi._szRowNumType.Equals("int"))
			{
				if (iLastStep < 9)
				{
					iStep = 0;
				}
				else
				{
					if (iLastStep >= 9 && iLastStep < 14)
					{
						iStep = 1;
					}
					else
					{
						iStep = 2;
					}
				}
				if (iLastStep + iStep > 26)
				{
					iLastStep = 1;
					iFirstStep++;
				}
				if (iFirstStep < 9)
				{
					iStep = 0;
				}
				else
				{
					if (iFirstStep >= 9 && iFirstStep < 14)
					{
						iStep = 1;
					}
					else
					{
						iStep = 2;
					}
				}
				if (esi._szFirsrRowText.Length != 1 || iFirstStep != 1)
				{
					text += Convert.ToChar(iFirstStep - 2 + firstNum + iStep).ToString();
				}
				if (iLastStep < 9)
				{
					iStep = 0;
				}
				else
				{
					if (iLastStep >= 9 && iLastStep < 14)
					{
						iStep = 1;
					}
					else
					{
						iStep = 2;
					}
				}
				text += Convert.ToChar(iLastStep - 1 + lastNum + iStep).ToString();
				iLastStep++;
			}
			return text;
		}
		public static string GetColumnNum(EditSeatInfo esi, int nRow, int nColumn)
		{
			string result = "";
			string nRuleCode = esi._nRuleCode;
			if (nRuleCode != null)
			{
				if (!(nRuleCode == "0"))
				{
					if (!(nRuleCode == "1"))
					{
						if (!(nRuleCode == "2"))
						{
							if (!(nRuleCode == "3"))
							{
								if (!(nRuleCode == "4"))
								{
									if (nRuleCode == "5")
									{
										if (nRow % 2 != 0)
										{
											if (nColumn < nRow / 2 + 1)
											{
												if (nColumn * 2 + 1 < 10)
												{
													result = string.Concat(nColumn * 2 + 1);
												}
												else
												{
													result = string.Concat(nColumn * 2 + 1);
												}
											}
											else
											{
												if (nRow * 2 - nColumn * 2 < 10)
												{
													result = string.Concat(nRow * 2 - nColumn * 2);
												}
												else
												{
													result = string.Concat(nRow * 2 - nColumn * 2);
												}
											}
										}
										else
										{
											if (nColumn < nRow / 2)
											{
												if (nColumn * 2 + 1 < 10)
												{
													result = string.Concat(nColumn * 2 + 1);
												}
												else
												{
													result = string.Concat(nColumn * 2 + 1);
												}
											}
											else
											{
												if (nRow * 2 - nColumn * 2 < 10)
												{
													result = string.Concat(nRow * 2 - nColumn * 2);
												}
												else
												{
													result = string.Concat(nRow * 2 - nColumn * 2);
												}
											}
										}
									}
								}
								else
								{
									if (nRow % 2 != 0)
									{
										if (nColumn <= nRow / 2)
										{
											if (nRow - nColumn * 2 < 10)
											{
												result = string.Concat(nRow - nColumn * 2);
											}
											else
											{
												result = string.Concat(nRow - nColumn * 2);
											}
										}
										else
										{
											if (nColumn * 2 - nRow + 1 < 10)
											{
												result = string.Concat(nColumn * 2 - nRow + 1);
											}
											else
											{
												result = string.Concat(nColumn * 2 - nRow + 1);
											}
										}
									}
									else
									{
										if (nColumn < nRow / 2)
										{
											if (nRow - 1 - nColumn * 2 < 10)
											{
												result = string.Concat(nRow - 1 - nColumn * 2);
											}
											else
											{
												result = string.Concat(nRow - 1 - nColumn * 2);
											}
										}
										else
										{
											if ((nColumn + 1) * 2 - nRow < 10)
											{
												result = string.Concat((nColumn + 1) * 2 - nRow);
											}
											else
											{
												result = string.Concat((nColumn + 1) * 2 - nRow);
											}
										}
									}
								}
							}
							else
							{
								if (nColumn + 1 <= nRow / 2)
								{
									if ((nColumn + 1) * 2 < 10)
									{
										result = "0" + (nColumn + 1) * 2;
									}
									else
									{
										result = string.Concat((nColumn + 1) * 2);
									}
								}
								else
								{
									if ((nRow - nColumn) * 2 - 1 < 10)
									{
										result = string.Concat((nRow - nColumn) * 2 - 1);
									}
									else
									{
										result = string.Concat((nRow - nColumn) * 2 - 1);
									}
								}
							}
						}
						else
						{
							if (nColumn < nRow / 2)
							{
								if (nRow / 2 * 2 - nColumn * 2 < 10)
								{
									result = string.Concat(nRow / 2 * 2 - nColumn * 2);
								}
								else
								{
									result = string.Concat(nRow / 2 * 2 - nColumn * 2);
								}
							}
							else
							{
								if (nRow / 2 * -2 + 1 + nColumn * 2 < 10)
								{
									result = string.Concat(nRow / 2 * -2 + 1 + nColumn * 2);
								}
								else
								{
									result = string.Concat(nRow / 2 * -2 + 1 + nColumn * 2);
								}
							}
						}
					}
					else
					{
						if (nRow - nColumn < 10)
						{
							result = string.Concat(nRow - nColumn);
						}
						else
						{
							result = string.Concat(nRow - nColumn);
						}
					}
				}
				else
				{
					if (nColumn + 1 < 10)
					{
						result = string.Concat(nColumn + 1);
					}
					else
					{
						result = string.Concat(nColumn + 1);
					}
				}
			}
			return result;
		}
		public static int MaxColumnCount(EditSeatInfo esi)
		{
			int result;
			if (esi._nIncreaseNumber > 0)
			{
				result = esi._nFirRowColumnCount + esi._nIncreaseNumber * esi._nRows;
			}
			else
			{
				result = esi._nFirRowColumnCount;
			}
			return result;
		}
		public static int GetLeftSpaceNum(int nMaxColumnCount, int nCurrentColumns, string szShapeCode)
		{
			int result = 0;
			switch (szShapeCode)
			{
			case "00":
				result = 0;
				break;
			case "10":
				result = (nMaxColumnCount - nCurrentColumns) / 2;
				break;
			case "20":
				result = nMaxColumnCount - nCurrentColumns;
				break;
			case "01":
				result = 0;
				break;
			case "11":
				result = (nMaxColumnCount - nCurrentColumns) / 2;
				break;
			case "21":
				result = nMaxColumnCount - nCurrentColumns;
				break;
			case "02":
				result = 0;
				break;
			case "12":
				result = (nMaxColumnCount - nCurrentColumns) / 2;
				break;
			case "22":
				result = nMaxColumnCount - nCurrentColumns;
				break;
			}
			return result;
		}
		public static int GetStartTopSpace(int nContainnerMaxHeight, int nMaxHeight, string szShapeCode)
		{
			int num = 0;
			int result;
			if (nMaxHeight >= nContainnerMaxHeight)
			{
				result = num;
			}
			else
			{
				switch (szShapeCode)
				{
				case "00":
					num = 0;
					break;
				case "10":
					num = 0;
					break;
				case "20":
					num = 0;
					break;
				case "01":
					num = (nContainnerMaxHeight - nMaxHeight) / 2;
					break;
				case "11":
					num = (nContainnerMaxHeight - nMaxHeight) / 2;
					break;
				case "21":
					num = (nContainnerMaxHeight - nMaxHeight) / 2;
					break;
				case "02":
					num = nContainnerMaxHeight - nMaxHeight;
					break;
				case "12":
					num = nContainnerMaxHeight - nMaxHeight;
					break;
				case "22":
					num = nContainnerMaxHeight - nMaxHeight;
					break;
				}
				result = num;
			}
			return result;
		}
		public static int GetStartLeftSpace(int nContainnerMaxWidth, int nMaxWidth, string szShapeCode)
		{
			int num = 0;
			int result;
			if (nMaxWidth >= nContainnerMaxWidth)
			{
				result = num;
			}
			else
			{
				switch (szShapeCode)
				{
				case "00":
					num = 0;
					break;
				case "10":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "20":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				case "01":
					num = 0;
					break;
				case "11":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "21":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				case "02":
					num = 0;
					break;
				case "12":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "22":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				}
				result = num;
			}
			return result;
		}
		public static int GetStartLeftSpaceOneRow(int nContainnerMaxWidth, int nMaxWidth, string szShapeCode)
		{
			int num = 0;
			int result;
			if (nMaxWidth >= nContainnerMaxWidth)
			{
				result = num;
			}
			else
			{
				switch (szShapeCode)
				{
				case "00":
					num = 0;
					break;
				case "10":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "20":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				case "01":
					num = 0;
					break;
				case "11":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "21":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				case "02":
					num = 0;
					break;
				case "12":
					num = (nContainnerMaxWidth - nMaxWidth) / 2;
					break;
				case "22":
					num = nContainnerMaxWidth - nMaxWidth;
					break;
				}
				result = num;
			}
			return result;
		}
	}
}

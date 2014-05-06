using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
namespace SeatMaDll
{
	public class SeatChartDisp : UserControl, InterfaceSetSeatResource
	{
		private UC_SeatChartPanel.MatrixRectType _matrixRectangleType = UC_SeatChartPanel.MatrixRectType.Fix;
		private UC_SeatChartPanel.MouseCursorStatus _CurrentMouseCursorStatus = UC_SeatChartPanel.MouseCursorStatus.Empty;
		private string _rowNumType = "int";
		private bool _dispImageMode = true;
		private bool _dispMoveRuler = true;
		private bool _dispRowNumber = false;
		public bool _bCreate = true;
		private static int _KeyMoveStep = 2;
		private int _matrixRowCount = 10;
		private int _matrixColumnCount = 10;
		private int _matrixUnitWidth = 40;
		private int _matrixUnitHeight = 30;
		private int _rectangelXSpace = 8;
		private int _rectangelYSpace = 5;
		private decimal _ZoomSize = 1m;
		private int _Rotation = 0;
		private Color _BoxBorderColor = Color.White;
		private int _LeftSpace = 30;
		private bool MouseIsDown = false;
		private Rectangle MouseRect = Rectangle.Empty;
		public SeatChartItemSelectDisp _seatCharItemsSelect = new SeatChartItemSelectDisp();
		private Image _backImage = null;
		private static readonly object _MultSelect = new object();
		private IContainer components = null;
		public event SelectOneSeatEventHandler _DoubleClick;
		public event SelectOneSeatEventHandler _LeftOneClick;
		public event RMSelectOneSeatEventHandler _RightOneClick;
		public event SelectOneSeatEventHandler _OnMouseEnter;
		public event SelectOneSeatEventHandler _OnMouseLeave;
		public event SelectOneSeatEventHandler _OnCtrlOrShiftMouseClick;
		public event SelectMultSeatEventHandler MultSelect
		{
			add
			{
				base.Events.AddHandler(SeatChartDisp._MultSelect, value);
			}
			remove
			{
				base.Events.RemoveHandler(SeatChartDisp._MultSelect, value);
			}
		}
		public UC_SeatChartPanel.MouseCursorStatus CurrentMouseCursorStatus
		{
			get
			{
				return this._CurrentMouseCursorStatus;
			}
			set
			{
				UC_SeatChartPanel.MouseCursorStatus currentMouseCursorStatus = this._CurrentMouseCursorStatus;
				if (this._CurrentMouseCursorStatus != value)
				{
					this._CurrentMouseCursorStatus = value;
					if (currentMouseCursorStatus == UC_SeatChartPanel.MouseCursorStatus.Empty && UC_SeatChartPanel.MouseCursorStatus.Insert == value)
					{
						this._seatCharItemsSelect.ResetControlList();
						this._CurrentMouseCursorStatus = UC_SeatChartPanel.MouseCursorStatus.Empty;
					}
				}
			}
		}
		[Category("网格矩阵"), Description("Specifies the MatrixRowCount.")]
		public int MatrixRowCount
		{
			get
			{
				int matrixRowCount = this._matrixRowCount;
				return (matrixRowCount <= 0) ? 1 : matrixRowCount;
			}
			set
			{
				this._matrixRowCount = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the MatrixColumn.")]
		public int MatrixColumnCount
		{
			get
			{
				int matrixColumnCount = this._matrixColumnCount;
				return (matrixColumnCount <= 0) ? 1 : matrixColumnCount;
			}
			set
			{
				this._matrixColumnCount = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the MatrixControlWidth.")]
		public int MatrixUnitWidth
		{
			get
			{
				int matrixUnitWidth = this._matrixUnitWidth;
				return (matrixUnitWidth <= 0) ? 40 : matrixUnitWidth;
			}
			set
			{
				this._matrixUnitWidth = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the MatrixUnitHeight.")]
		public int MatrixUnitHeight
		{
			get
			{
				int matrixUnitHeight = this._matrixUnitHeight;
				return (matrixUnitHeight <= 0) ? 30 : matrixUnitHeight;
			}
			set
			{
				this._matrixUnitHeight = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the Matrix Row Space.")]
		public int Row_Space
		{
			get
			{
				int rectangelXSpace = this._rectangelXSpace;
				return (rectangelXSpace <= 0) ? 5 : rectangelXSpace;
			}
			set
			{
				this._rectangelXSpace = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the Matrix Column Space.")]
		public int Column_Space
		{
			get
			{
				int rectangelYSpace = this._rectangelYSpace;
				return (rectangelYSpace <= 0) ? 5 : rectangelYSpace;
			}
			set
			{
				this._rectangelYSpace = value;
			}
		}
		[Category("网格矩阵"), Description("Specifies the MatrixRectangleType.")]
		public UC_SeatChartPanel.MatrixRectType MatrixRectangeType
		{
			get
			{
				object obj = this._matrixRectangleType;
				return (obj == null) ? UC_SeatChartPanel.MatrixRectType.Auto : ((UC_SeatChartPanel.MatrixRectType)obj);
			}
			set
			{
				this._matrixRectangleType = value;
			}
		}
		public bool DispImageMode
		{
			get
			{
				return this._dispImageMode;
			}
			set
			{
				if (this._dispImageMode != value)
				{
					this._dispImageMode = value;
					base.Invalidate();
				}
			}
		}
		public bool DispMoveRuler
		{
			get
			{
				return this._dispMoveRuler;
			}
			set
			{
				if (this._dispMoveRuler != value)
				{
					this._dispMoveRuler = value;
					if (this._dispMoveRuler)
					{
						this._backImage = this.CreateImg();
						this.BackgroundImage = this._backImage;
					}
					else
					{
						this._backImage = null;
						this.BackgroundImage = this._backImage;
					}
					base.Invalidate();
				}
			}
		}
		public bool DisplayRowNumber
		{
			get
			{
				return this._dispRowNumber;
			}
			set
			{
				if (this._dispRowNumber != value)
				{
					this._dispRowNumber = value;
					base.Invalidate();
				}
			}
		}
		public decimal ZoomSize
		{
			get
			{
				return this._ZoomSize;
			}
			set
			{
				if (value > 0m)
				{
					this._ZoomSize = value;
					if (this._ZoomSize != 1m)
					{
						this.ZoomItems(this._ZoomSize);
						base.Invalidate();
					}
				}
			}
		}
		public int Rotation
		{
			get
			{
				return this._Rotation;
			}
			set
			{
				if (this._Rotation != value)
				{
					this._Rotation = value;
					this.RotationItems(this._Rotation);
					base.Invalidate();
				}
			}
		}
		public Color BoxBorderColor
		{
			get
			{
				return this._BoxBorderColor;
			}
			set
			{
				if (this._BoxBorderColor != value)
				{
					this._BoxBorderColor = value;
					this.UpdateBoxBorder();
				}
			}
		}
		public int LeftSpace
		{
			get
			{
				return this._LeftSpace;
			}
			set
			{
				int num = value;
				if (num < 30)
				{
					num = 30;
				}
				if (this._LeftSpace != num)
				{
					this._LeftSpace = num;
					base.Invalidate();
				}
			}
		}
		protected virtual void On_MultSelect(SelectMultSeat_Events e)
		{
			SelectMultSeatEventHandler selectMultSeatEventHandler = (SelectMultSeatEventHandler)base.Events[SeatChartDisp._MultSelect];
			if (selectMultSeatEventHandler != null)
			{
				selectMultSeatEventHandler(this, e);
			}
		}
		public SeatChartDisp()
		{
			this._seatCharItemsSelect._moveFlag = false;
			this._seatCharItemsSelect._container = this;
			this.InitializeComponent();
		}
		public virtual void SetSeatResource()
		{
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			this.DrawLeftRowNum(e);
		}
		private void DrawBaseLine(PaintEventArgs e)
		{
			int num = 0;
			int right = base.Right;
			int bottom = base.Bottom;
			Pen pen = new Pen(Color.Gray, 0.1f);
			pen.DashStyle = DashStyle.Dot;
			Point pt = new Point(num + this._LeftSpace, 0);
			Point pt2 = new Point(num + this._LeftSpace, base.Bottom);
			e.Graphics.DrawLine(pen, pt, pt2);
			pen.Dispose();
		}
		private void DrawLeftRowNum(PaintEventArgs e)
		{
			if (this._dispRowNumber)
			{
				BHSeatControl firstSeatControl = this.GetFirstSeatControl();
				if (firstSeatControl != null)
				{
					Seat seat = (Seat)firstSeatControl.Tag;
					Seat seat2 = (Seat)firstSeatControl.Tag;
					Seat seat3 = (Seat)firstSeatControl.Tag;
					Seat seat4 = (Seat)firstSeatControl.Tag;
					List<Seat> list = new List<Seat>();
					List<Seat> list2 = new List<Seat>();
					foreach (Control control in base.Controls)
					{
						if (control.GetType() == typeof(BHSeatControl))
						{
							BHSeatControl bHSeatControl = (BHSeatControl)control;
							Seat seat5 = (Seat)bHSeatControl.Tag;
							if (seat5._brotherList.Count <= 0)
							{
								if (!this.LeftseatExist(list, seat5))
								{
									list.Add(seat5);
								}
								if (!this.RightseatExist(list2, seat5))
								{
									list2.Add(seat5);
								}
							}
							else
							{
								foreach (Seat current in seat5._brotherList)
								{
									if (!this.LeftseatExist(list, current))
									{
										list.Add(current);
									}
									if (!this.RightseatExist(list2, current))
									{
										list2.Add(current);
									}
								}
							}
						}
					}
					Font font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Pixel);
					SolidBrush solidBrush = new SolidBrush(Color.Yellow);
					StringFormat stringFormat = new StringFormat();
					stringFormat.Alignment = StringAlignment.Center;
					int x = base.AutoScrollPosition.X;
					int y = base.AutoScrollPosition.Y;
					foreach (Seat seat5 in list)
					{
						int num = 5 + x;
						int num2 = seat5._seatPosY + y;
						if (seat5._seatPosX - this._LeftSpace > num)
						{
							num = seat5._seatPosX - this._LeftSpace;
						}
						Point p = new Point(num, seat5._seatPosY + y);
						int num3 = base.Width - this._LeftSpace + x;
						Seat seat6 = this.FindSeatByRowNumber(list2, seat5._seatRowNumber);
						if (seat6 != null)
						{
							if (num3 > seat6._seatPosX + seat6._seatWidth + 5)
							{
								num3 = seat6._seatPosX + seat6._seatWidth + 5;
							}
						}
						Point p2 = new Point(num3, seat5._seatPosY + y);
						e.Graphics.DrawString(seat5._seatRowNumberDisplay, font, solidBrush, p, stringFormat);
						e.Graphics.DrawString(seat5._seatRowNumberDisplay, font, solidBrush, p2, stringFormat);
					}
					stringFormat.Dispose();
					font.Dispose();
					solidBrush.Dispose();
				}
			}
		}
		private bool LeftseatExist(List<Seat> listLeftSeat, Seat stOpt)
		{
			bool result;
			if (listLeftSeat.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in listLeftSeat)
				{
					if (current._seatRowNumber == stOpt._seatRowNumber)
					{
						if (stOpt._seatPosX < current._seatPosX)
						{
							listLeftSeat.Remove(current);
							listLeftSeat.Add(stOpt);
						}
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		private bool RightseatExist(List<Seat> listRightSeat, Seat stOpt)
		{
			bool result;
			if (listRightSeat.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in listRightSeat)
				{
					if (current._seatRowNumber == stOpt._seatRowNumber)
					{
						if (stOpt._seatPosX > current._seatPosX)
						{
							listRightSeat.Remove(current);
							listRightSeat.Add(stOpt);
						}
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		private Seat FindSeatByRowNumber(List<Seat> listRightSeat, string szseatRowNumber)
		{
			Seat result;
			foreach (Seat current in listRightSeat)
			{
				if (current._seatRowNumber == szseatRowNumber)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
		private void DrawBackLine(PaintEventArgs e)
		{
			int i = 0;
			int num = 0;
			int right = base.Right;
			int bottom = base.Bottom;
			i += SeatChartDisp._KeyMoveStep;
			num += SeatChartDisp._KeyMoveStep;
			Pen pen = new Pen(Color.White, 0.1f);
			while (i <= right)
			{
				Point pt = new Point(i, base.Top);
				Point pt2 = new Point(i, base.Bottom);
				e.Graphics.DrawLine(pen, pt, pt2);
				i += SeatChartDisp._KeyMoveStep * 4;
			}
			pen.Dispose();
		}
		private Image CreateImg()
		{
			Pen pen = new Pen(Color.Silver, 0.1f);
			Pen pen2 = new Pen(Color.White, 2f);
			Bitmap bitmap = new Bitmap(20, 20);
			Graphics graphics = Graphics.FromImage(bitmap);
			for (int i = 0; i <= 5; i++)
			{
				Point pt = new Point(0, i * 4);
				Point pt2 = new Point(20, i * 4);
				if (i == 0)
				{
					graphics.DrawLine(pen2, pt, pt2);
				}
				else
				{
					graphics.DrawLine(pen, pt, pt2);
				}
			}
			for (int i = 0; i <= 5; i++)
			{
				Point pt = new Point(i * 4, 0);
				Point pt2 = new Point(i * 4, 20);
				if (i == 0)
				{
					graphics.DrawLine(pen2, pt, pt2);
				}
				else
				{
					graphics.DrawLine(pen, pt, pt2);
				}
			}
			pen.Dispose();
			pen2.Dispose();
			return bitmap;
		}
		private void DisplayText(bool _dispRowNumber)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					BHSeatControl bHSeatControl = (BHSeatControl)control;
					Seat seat = (Seat)bHSeatControl.Tag;
					bHSeatControl.Text = (_dispRowNumber ? seat._seatRowNumber : seat._seatColumn);
				}
			}
		}
		private void ZoomItems(decimal deciZoon)
		{
			if (!(deciZoon <= 0m))
			{
				if (!(deciZoon == 1m))
				{
					this._matrixUnitWidth = (int)(this._matrixUnitWidth * deciZoon);
					this._matrixUnitHeight = (int)(this._matrixUnitHeight * deciZoon);
					this._rectangelXSpace = (int)(this._rectangelXSpace * deciZoon);
					this._rectangelYSpace = (int)(this._rectangelYSpace * deciZoon);
					int num = 1000;
					int num2 = 1000;
					this.MinLeftOrTopControlValue(ref num, ref num2);
					foreach (Control control in base.Controls)
					{
						if (control.GetType() == typeof(BHSeatControl))
						{
							BHSeatControl bHSeatControl = (BHSeatControl)control;
							Seat seat = (Seat)bHSeatControl.Tag;
							int num3 = num + (int)((bHSeatControl.Location.X - num) * deciZoon);
							int num4 = num2 + (int)((bHSeatControl.Location.Y - num2) * deciZoon);
							int num5 = (int)(bHSeatControl.Width * deciZoon);
							int num6 = (int)(bHSeatControl.Height * deciZoon);
							Point location = new Point(num3, num4);
							bHSeatControl.Location = location;
							bHSeatControl.Width = num5;
							bHSeatControl.Height = num6;
							seat._seatPosX = num3;
							seat._seatPosY = num4;
							seat._seatWidth = num5;
							seat._seatHeight = num6;
							if (seat._brotherList != null && seat._brotherList.Count > 0)
							{
								foreach (Seat current in seat._brotherList)
								{
									current._seatPosX = num + (int)((current._seatPosX - num) * deciZoon);
									current._seatPosY = num2 + (int)((current._seatPosY - num2) * deciZoon);
									current._seatWidth = (int)(current._seatWidth * deciZoon);
									current._seatHeight = (int)(current._seatHeight * deciZoon);
								}
							}
						}
					}
				}
			}
		}
		public void MinLeftOrTopControlValue(ref int nLeft, ref int nTop)
		{
			nLeft = 10000;
			nTop = 10000;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					BHSeatControl bHSeatControl = (BHSeatControl)control;
					if (bHSeatControl.Location.X < nLeft)
					{
						nLeft = bHSeatControl.Location.X;
					}
					if (bHSeatControl.Location.Y < nTop)
					{
						nTop = bHSeatControl.Location.Y;
					}
				}
			}
		}
		private void UpdateBoxBorder()
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					if (seat._brotherList != null && seat._brotherList.Count > 0)
					{
						bHSeatControlEditer.BoxBorderColor = this._BoxBorderColor;
						bHSeatControlEditer.Invalidate();
					}
				}
			}
		}
		private void UC_SeatChartPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._CurrentMouseCursorStatus == UC_SeatChartPanel.MouseCursorStatus.Empty)
			{
				this._seatCharItemsSelect.ResetControlList();
				this.MouseIsDown = true;
				this.DrawStart(e.Location);
			}
		}
		private void UC_SeatChartPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.MouseIsDown)
			{
				this.ResizeToRectangle(e.Location);
			}
		}
		private void UC_SeatChartPanel_MouseUp(object sender, MouseEventArgs e)
		{
			base.Capture = false;
			Cursor.Clip = Rectangle.Empty;
			this.MouseIsDown = false;
			this.DrawRectangle();
			this.BuildSelectedControl();
			this.MouseRect = Rectangle.Empty;
		}
		private void ResizeToRectangle(Point p)
		{
			this.DrawRectangle();
			this.MouseRect.Width = p.X - this.MouseRect.Left;
			this.MouseRect.Height = p.Y - this.MouseRect.Top;
			this.DrawRectangle();
		}
		private void DrawRectangle()
		{
			Rectangle rectangle = base.RectangleToScreen(this.MouseRect);
			ControlPaint.DrawReversibleFrame(rectangle, Color.White, FrameStyle.Dashed);
		}
		private Rectangle ReCalRectangle(Rectangle rect)
		{
			int num = rect.X;
			int num2 = rect.Y;
			int num3 = rect.Width;
			int num4 = rect.Height;
			Rectangle result;
			if (num3 >= 0 && num4 >= 0)
			{
				result = rect;
			}
			else
			{
				if (num3 < 0)
				{
					num3 *= -1;
					num -= num3;
				}
				if (num4 < 0)
				{
					num4 *= -1;
					num2 -= num4;
				}
				Rectangle rectangle = new Rectangle(num, num2, num3, num4);
				result = rectangle;
			}
			return result;
		}
		private void BuildSelectedControl()
		{
			Rectangle rect = this.ReCalRectangle(this.MouseRect);
			this._seatCharItemsSelect.ResetControlList();
			foreach (Control control in base.Controls)
			{
				if (control.Bounds.IntersectsWith(rect))
				{
					if (control.GetType() == typeof(BHSeatControl))
					{
						this._seatCharItemsSelect.BuildSelectedControl(control);
					}
				}
			}
			if (SeatChartDisp._MultSelect != null)
			{
				if (this._seatCharItemsSelect._listControlSelect.Count > 0)
				{
					List<BHSeatControl> list = new List<BHSeatControl>();
					foreach (Control control in this._seatCharItemsSelect._listControlSelect)
					{
						list.Add((BHSeatControl)control);
					}
					SelectMultSeat_Events e = new SelectMultSeat_Events(list);
					this.On_MultSelect(e);
				}
			}
		}
		private void DrawStart(Point StartPoint)
		{
			base.Capture = true;
			Cursor.Clip = base.RectangleToScreen(new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height));
			this.MouseRect = new Rectangle(StartPoint.X, StartPoint.Y, 0, 0);
		}
		public void KeyMoveItems(int nMoveFlag)
		{
			this._seatCharItemsSelect.KeyMoveItems(nMoveFlag, SeatChartDisp._KeyMoveStep);
		}
		public void ClearItems()
		{
			this._seatCharItemsSelect.ClearData();
			base.Controls.Clear();
		}
		public static string GetItemStyle(BHSeatControl bsc)
		{
			string result;
			if (bsc == null)
			{
				result = "";
			}
			else
			{
				if (bsc.Tag == null)
				{
					result = "";
				}
				else
				{
					Seat seat = (Seat)bsc.Tag;
					string seatFlag;
					if (seat._brotherList.Count <= 0)
					{
						seatFlag = seat._seatFlag;
					}
					else
					{
						seatFlag = seat._brotherList[0]._seatFlag;
					}
					result = seatFlag;
				}
			}
			return result;
		}
		public static bool ChechItemStatusExist(BHSeatControl bsc, string bhSeatStatus)
		{
			bool result;
			if (bsc == null)
			{
				result = false;
			}
			else
			{
				if (bsc.Tag == null)
				{
					result = false;
				}
				else
				{
					Seat seat = (Seat)bsc.Tag;
					if (seat._brotherList.Count <= 0)
					{
						result = (seat._seatStatusFlag == bhSeatStatus);
					}
					else
					{
						foreach (Seat current in seat._brotherList)
						{
							if (current._seatStatusFlag == bhSeatStatus)
							{
								result = true;
								return result;
							}
						}
						result = false;
					}
				}
			}
			return result;
		}
		public void ClearMultiSelectControlList()
		{
			this._seatCharItemsSelect.ResetControlList();
		}
		public List<SeatStatusSim> RetrieveSeatStatusSimList_BySeatStatus(string bhSeatStatus)
		{
			List<SeatStatusSim> list = new List<SeatStatusSim>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					Seat seat = (Seat)control.Tag;
					if (seat._brotherList.Count <= 0)
					{
						if (seat._seatStatusFlag == bhSeatStatus)
						{
							SeatStatusSim item = new SeatStatusSim(seat._seatId, seat._seatFlag, seat._seatStatusFlag, seat._seatRowNumber, seat._seatColumn, seat._seatNumber);
							list.Add(item);
						}
					}
					else
					{
						foreach (Seat current in seat._brotherList)
						{
							if (current._seatStatusFlag == bhSeatStatus)
							{
								SeatStatusSim item = new SeatStatusSim(current._seatId, current._seatFlag, current._seatStatusFlag, current._seatRowNumber, current._seatColumn, current._seatNumber);
								list.Add(item);
							}
						}
					}
				}
			}
			return list;
		}
		public int GetAllSeatCount()
		{
			int num = 0;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					Seat seat = (Seat)control.Tag;
					if (seat._brotherList.Count <= 0)
					{
						num++;
					}
					else
					{
						num += seat._brotherList.Count;
					}
				}
			}
			return num;
		}
		public List<BHSeatControl> RetrieveAllItems()
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					list.Add((BHSeatControl)control);
				}
			}
			return list;
		}
		public List<BHSeatControl> RetrieveAllItems_BySeatStatus(string bhSeatStatus)
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					Seat seat = (Seat)control.Tag;
					if (!(seat._seatStatusFlag != bhSeatStatus))
					{
						list.Add((BHSeatControl)control);
					}
				}
			}
			return list;
		}
		public List<BHSeatControl> RetrieveAllItems_BySeatType(string bhSeatType)
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					Seat seat = (Seat)control.Tag;
					if (!(seat._seatFlag != bhSeatType))
					{
						list.Add((BHSeatControl)control);
					}
				}
			}
			return list;
		}
		public List<Seat> RetrieveMultSelectedSeats()
		{
			List<Seat> list = new List<Seat>();
			List<Seat> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControl))
					{
						if (current.Tag != null)
						{
							Seat seat = (Seat)current.Tag;
							if (seat._brotherList.Count <= 0)
							{
								list.Add(seat);
							}
							else
							{
								foreach (Seat current2 in seat._brotherList)
								{
									list.Add(current2);
								}
							}
						}
					}
				}
				result = list;
			}
			return result;
		}
		public List<BHSeatControl> RetrieveSelectedItems()
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			List<BHSeatControl> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControl))
					{
						list.Add((BHSeatControl)current);
					}
				}
				result = list;
			}
			return result;
		}
		public List<BHSeatControl> RetrieveSelectedItems_BySeatStatus(string bhSeatStatus)
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			List<BHSeatControl> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControl))
					{
						Seat seat = (Seat)current.Tag;
						if (!(seat._seatStatusFlag != bhSeatStatus))
						{
							list.Add((BHSeatControl)current);
						}
					}
				}
				result = list;
			}
			return result;
		}
		public List<BHSeatControl> RetrieveSelectedItems_BySeatType(string bhSeatType)
		{
			List<BHSeatControl> list = new List<BHSeatControl>();
			List<BHSeatControl> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControl))
					{
						Seat seat = (Seat)current.Tag;
						if (!(seat._seatFlag != bhSeatType))
						{
							list.Add((BHSeatControl)current);
						}
					}
				}
				result = list;
			}
			return result;
		}
		private void RemoveLabelControl()
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(Label))
				{
					base.Controls.Remove(control);
					control.Dispose();
				}
			}
		}
		public BHSeatControl GetFirstSeatControl()
		{
			BHSeatControl result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					result = (BHSeatControl)control;
					return result;
				}
			}
			result = null;
			return result;
		}
		private void RotationItems(int nRotation)
		{
			if (nRotation == 0 || nRotation == 180)
			{
				if (base.Controls.Count >= 2)
				{
					BHSeatControl firstSeatControl = this.GetFirstSeatControl();
					if (firstSeatControl != null)
					{
						int x = firstSeatControl.Location.X;
						int y = firstSeatControl.Location.Y;
						int right = firstSeatControl.Right;
						int bottom = firstSeatControl.Bottom;
						this.GetFourMargin(ref x, ref y, ref right, ref bottom);
						int num = x + (right - x) / 2;
						int num2 = y + (bottom - y) / 2;
						List<Label> list = new List<Label>();
						foreach (Control control in base.Controls)
						{
							if (control.GetType() == typeof(BHSeatControl))
							{
								BHSeatControl bHSeatControl = (BHSeatControl)control;
								Seat seat = (Seat)bHSeatControl.Tag;
								bHSeatControl.Rotation = nRotation;
								seat._seatPosX = 2 * num - seat._seatPosX - seat._seatWidth;
								seat._seatPosY = 2 * num2 - seat._seatPosY - seat._seatHeight;
								bHSeatControl.Location = new Point(seat._seatPosX, seat._seatPosY);
								if (seat._brotherList.Count > 0)
								{
									foreach (Seat current in seat._brotherList)
									{
										current._seatPosX = 2 * num - current._seatPosX - current._seatWidth;
										current._seatPosY = 2 * num2 - current._seatPosY - current._seatHeight;
										if (this._dispRowNumber)
										{
											Label label = this.FindLabelInControls(current._seatRowNumber);
											if (label != null)
											{
												label.Top = current._seatPosY;
											}
										}
									}
								}
								else
								{
									if (this._dispRowNumber)
									{
										Label label = this.FindLabelInControls(seat._seatRowNumber);
										if (label != null)
										{
											label.Top = seat._seatPosY;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private Label FindLabelInControls(string szTitle)
		{
			Label result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(Label))
				{
					if (control.Name == "RowNum" + szTitle)
					{
						result = (Label)control;
						return result;
					}
				}
			}
			result = null;
			return result;
		}
		public void GetFourMargin(ref int nLeft, ref int nTop, ref int nRight, ref int nBottom)
		{
			if (base.Controls.Count >= 2)
			{
				BHSeatControl firstSeatControl = this.GetFirstSeatControl();
				nLeft = firstSeatControl.Left;
				nTop = firstSeatControl.Top;
				nRight = firstSeatControl.Right;
				nBottom = firstSeatControl.Bottom;
				foreach (Control control in base.Controls)
				{
					if (control.GetType() == typeof(BHSeatControl))
					{
						BHSeatControl bHSeatControl = (BHSeatControl)control;
						if (bHSeatControl.Tag != null)
						{
							Seat seat = (Seat)bHSeatControl.Tag;
							if (seat._brotherList.Count <= 0)
							{
								if (seat._seatPosX < nLeft)
								{
									nLeft = seat._seatPosX;
								}
								if (seat._seatPosY < nTop)
								{
									nTop = seat._seatPosY;
								}
								if (seat._seatPosX + seat._seatWidth > nRight)
								{
									nRight = seat._seatPosX + seat._seatWidth;
								}
								if (seat._seatPosY + seat._seatHeight > nBottom)
								{
									nBottom = seat._seatPosY + seat._seatHeight;
								}
							}
							else
							{
								foreach (Seat current in seat._brotherList)
								{
									if (current._seatPosX < nLeft)
									{
										nLeft = current._seatPosX;
									}
									if (current._seatPosY < nTop)
									{
										nTop = current._seatPosY;
									}
									if (current._seatPosX + current._seatWidth > nRight)
									{
										nRight = current._seatPosX + current._seatWidth;
									}
									if (current._seatPosY + current._seatHeight > nBottom)
									{
										nBottom = current._seatPosY + current._seatHeight;
									}
								}
							}
						}
					}
				}
			}
		}
		public bool SetItemsType(BHSeatControl bh, BHSeatControl.BHSeatType bhSeatType)
		{
			bool result;
			foreach (Control control in base.Controls)
			{
				if (bh.Name == control.Name)
				{
					((BHSeatControl)control).SeatType = bhSeatType;
					Seat seat = (Seat)control.Tag;
					seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
					control.Tag = seat;
					((BHSeatControl)control).Image = (((BHSeatControl)control).DispImageMode ? EditSeatItem.GetControlImg(seat._seatFlag) : null);
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public bool SetItemsStatus(BHSeatControl bh, BHSeatControl.BHSeatStatus bhSeatStatus)
		{
			bool result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					if (bh.Name == control.Name)
					{
						((BHSeatControl)control).SeatStatus = bhSeatStatus;
						Seat seat = (Seat)control.Tag;
						seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
						control.Tag = seat;
						((BHSeatControl)control).ExtendImage = (((BHSeatControl)control).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
		public void SetSeatsStatus(List<SeatStatusSim> listSeatStatus)
		{
			if (listSeatStatus != null && listSeatStatus.Count > 0)
			{
				foreach (SeatStatusSim current in listSeatStatus)
				{
					foreach (Control control in base.Controls)
					{
						if (control.GetType() == typeof(BHSeatControl))
						{
							BHSeatControl bHSeatControl = (BHSeatControl)control;
							Seat seat = (Seat)bHSeatControl.Tag;
							if (seat._brotherList.Count <= 0)
							{
								if (current._seatId == seat._seatId)
								{
									seat._seatStatusFlag = current._seatStatusFlag;
									bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
								}
							}
							else
							{
								foreach (Seat current2 in seat._brotherList)
								{
									if (current._seatId == current2._seatId)
									{
										current2._seatStatusFlag = current._seatStatusFlag;
										bHSeatControl.Invalidate();
									}
								}
							}
						}
					}
				}
			}
		}
		public void ReSetSeatStatus(List<Seat> list)
		{
			foreach (Seat current in list)
			{
				foreach (Control control in base.Controls)
				{
					if (control.GetType() == typeof(BHSeatControl))
					{
						BHSeatControl bHSeatControl = (BHSeatControl)control;
						Seat seat = (Seat)bHSeatControl.Tag;
						if (seat._brotherList.Count <= 0)
						{
							if (!(current._seatId != seat._seatId))
							{
								if (!(seat._seatStatusFlag == current._seatStatusFlag))
								{
									seat._seatStatusFlag = current._seatStatusFlag;
									bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
								}
							}
						}
						else
						{
							bool flag = false;
							foreach (Seat current2 in seat._brotherList)
							{
								if (!(current._seatId != current2._seatId))
								{
									if (!(current2._seatStatusFlag == current._seatStatusFlag))
									{
										current2._seatStatusFlag = current._seatStatusFlag;
										flag = true;
									}
								}
							}
							if (flag)
							{
								bHSeatControl.Invalidate();
							}
						}
					}
				}
			}
		}
		public void IncludeItem(BHSeatControl bh)
		{
			this._seatCharItemsSelect.IncludeItem(bh);
		}
		public void ExcludeItem(BHSeatControl bh)
		{
			this._seatCharItemsSelect.ExcludeItem(bh);
		}
		public void DeleteItems()
		{
			this._seatCharItemsSelect.DeleteItems();
		}
		public bool ImportItems(string szFile)
		{
			byte[] array = this.ReadFile(szFile);
			bool result;
			if (array == null)
			{
				result = false;
			}
			else
			{
				string @string = Encoding.UTF8.GetString(array);
				EditSeatInfo editSeatInfo = new EditSeatInfo();
				StringReader textReader = new StringReader(@string);
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(editSeatInfo.GetType());
					editSeatInfo = (EditSeatInfo)xmlSerializer.Deserialize(textReader);
					result = this.ImportSeatChart(editSeatInfo._ObjSeatingChart);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}
		public bool PreImportItems(string szFile, ref EditSeatInfo editSeatInfoInput, ref string szMsg)
		{
			byte[] array = this.ReadFile(szFile);
			bool result;
			if (array == null)
			{
				result = false;
			}
			else
			{
				string @string = Encoding.UTF8.GetString(array);
				EditSeatInfo editSeatInfo = new EditSeatInfo();
				StringReader textReader = new StringReader(@string);
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(editSeatInfo.GetType());
					editSeatInfo = (EditSeatInfo)xmlSerializer.Deserialize(textReader);
					if (editSeatInfoInput != null)
					{
						if (editSeatInfo._szTheaterName != editSeatInfoInput._szTheaterName)
						{
							szMsg = "导入的影院名称与座位图的影院名称不一致!";
							result = false;
							return result;
						}
						if (editSeatInfo._szHallName != editSeatInfoInput._szHallName)
						{
							szMsg = "导入的影厅名称与座位图的影厅名称不一致!";
							result = false;
							return result;
						}
						if (editSeatInfo._szLevelName != editSeatInfoInput._szLevelName)
						{
							szMsg = "导入的座位图楼层与座位图的楼层不一致!";
							result = false;
							return result;
						}
					}
					editSeatInfoInput = editSeatInfo;
					result = (editSeatInfo._ObjSeatingChart != null);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}
		public bool ImportItems(string szFile, ref EditSeatInfo editSeatInfoInput, ref string szMsg)
		{
			byte[] array = this.ReadFile(szFile);
			bool result;
			if (array == null)
			{
				result = false;
			}
			else
			{
				string @string = Encoding.UTF8.GetString(array);
				EditSeatInfo editSeatInfo = new EditSeatInfo();
				StringReader textReader = new StringReader(@string);
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(editSeatInfo.GetType());
					editSeatInfo = (EditSeatInfo)xmlSerializer.Deserialize(textReader);
					if (editSeatInfoInput != null)
					{
						if (editSeatInfo._szTheaterName != editSeatInfoInput._szTheaterName)
						{
							szMsg = "导入的影院名称与座位图的影院名称不一致!";
							result = false;
							return result;
						}
						if (editSeatInfo._szHallName != editSeatInfoInput._szHallName)
						{
							szMsg = "导入的影厅名称与座位图的影厅名称不一致!";
							result = false;
							return result;
						}
						if (editSeatInfo._szLevelName != editSeatInfoInput._szLevelName)
						{
							szMsg = "导入的座位图楼层与座位图的楼层不一致!";
							result = false;
							return result;
						}
					}
					editSeatInfoInput = editSeatInfo;
					result = this.ImportSeatChartNew(editSeatInfo._ObjSeatingChart);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}
		private byte[] ReadFile(string szFile)
		{
			byte[] result;
			if (szFile.Trim().Length <= 0)
			{
				result = null;
			}
			else
			{
				byte[] array = null;
				using (FileStream fileStream = new FileStream(szFile, FileMode.Open))
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
				}
				result = array;
			}
			return result;
		}
		public bool ImportSeatChartNew(SeatingChart sl)
		{
			base.Controls.Clear();
			bool result;
			if (sl == null || sl._listSiteItem == null || sl._listSiteItem.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl._listSiteItem)
				{
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.Rotation = sl.Rotation;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				result = true;
			}
			return result;
		}
		public bool ImportSeatChart(SeatingChart sl)
		{
			base.Controls.Clear();
			bool result;
			if (sl == null || sl._listSiteItem == null || sl._listSiteItem.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl._listSiteItem)
				{
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.Rotation = sl.Rotation;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatChartWithPad(SeatingChart sl, int nLeft, int nTop)
		{
			base.Controls.Clear();
			bool result;
			if (sl == null || sl._listSiteItem == null || sl._listSiteItem.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl._listSiteItem)
				{
					if (nLeft != 0 && nTop != 0)
					{
						current._seatPosX = nLeft + current._seatPosX;
						current._seatPosY = nTop + current._seatPosY;
						if (current._brotherList.Count > 0)
						{
							foreach (Seat current2 in current._brotherList)
							{
								current2._seatPosX = nLeft + current2._seatPosX;
								current2._seatPosY = nTop + current2._seatPosY;
							}
						}
					}
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.Rotation = sl.Rotation;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatChartWithBlock(SeatingChart sl)
		{
			base.Controls.Clear();
			bool result;
			if (sl == null || sl._listSiteItem == null || sl._listSiteItem.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl._listSiteItem)
				{
					current._IsUsedBackColor = true;
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.Rotation = sl.Rotation;
					bHSeatControl.IsUsedBackColor = true;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatChartWithBlockAndPad(SeatingChart sl, int nLeft, int nTop)
		{
			base.Controls.Clear();
			bool result;
			if (sl == null || sl._listSiteItem == null || sl._listSiteItem.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl._listSiteItem)
				{
					if (nLeft != 0 && nTop != 0)
					{
						current._seatPosX = nLeft + current._seatPosX;
						current._seatPosY = nTop + current._seatPosY;
						if (current._brotherList.Count > 0)
						{
							foreach (Seat current2 in current._brotherList)
							{
								current2._seatPosX = nLeft + current2._seatPosX;
								current2._seatPosY = nTop + current2._seatPosY;
							}
						}
					}
					current._IsUsedBackColor = true;
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.Rotation = sl.Rotation;
					bHSeatControl.IsUsedBackColor = true;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatList(List<Seat> sl)
		{
			base.Controls.Clear();
			this._seatCharItemsSelect._listControlSelect.Clear();
			bool result;
			if (sl == null || sl.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl)
				{
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatList(List<Seat> sl, string szStatusFlag)
		{
			base.Controls.Clear();
			this._seatCharItemsSelect._listControlSelect.Clear();
			bool result;
			if (sl == null || sl.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Seat current in sl)
				{
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
					if (current._seatStatusFlag == szStatusFlag)
					{
						if (!this._seatCharItemsSelect.ExistControlInList(bHSeatControl))
						{
							this._seatCharItemsSelect._listControlSelect.Add(bHSeatControl);
						}
					}
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatListWithTitle(List<Seat> sl, int nLeft, int nTop)
		{
			base.Controls.Clear();
			this._seatCharItemsSelect._listControlSelect.Clear();
			bool result;
			if (sl == null || sl.Count <= 0)
			{
				result = false;
			}
			else
			{
				List<Label> list = new List<Label>();
				foreach (Seat current in sl)
				{
					current._IsUsedBackColor = false;
					if (nLeft != 0 && nTop != 0)
					{
						current._seatPosX = nLeft + current._seatPosX;
						current._seatPosY = nTop + current._seatPosY;
						if (current._brotherList.Count > 0)
						{
							foreach (Seat current2 in current._brotherList)
							{
								current2._seatPosX = nLeft + current2._seatPosX;
								current2._seatPosY = nTop + current2._seatPosY;
							}
						}
					}
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		public bool ImportSeatListWithTitleAndBlock(List<Seat> sl, int nLeft, int nTop)
		{
			base.Controls.Clear();
			this._seatCharItemsSelect._listControlSelect.Clear();
			bool result;
			if (sl == null || sl.Count <= 0)
			{
				result = false;
			}
			else
			{
				List<Label> list = new List<Label>();
				foreach (Seat current in sl)
				{
					if (nLeft != 0 && nTop != 0)
					{
						current._seatPosX = nLeft + current._seatPosX;
						current._seatPosY = nTop + current._seatPosY;
						if (current._brotherList.Count > 0)
						{
							foreach (Seat current2 in current._brotherList)
							{
								current2._seatPosX = nLeft + current2._seatPosX;
								current2._seatPosY = nTop + current2._seatPosY;
							}
						}
					}
					current._IsUsedBackColor = true;
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControl bHSeatControl = new BHSeatControl();
					bHSeatControl.Name = current._seatId;
					bHSeatControl.Text = current._seatColumn;
					bHSeatControl.Location = location;
					bHSeatControl.Width = current._seatWidth;
					bHSeatControl.Height = current._seatHeight;
					bHSeatControl.CursorSelectedIt = false;
					bHSeatControl.DisplayText = true;
					bHSeatControl.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControl.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControl.DispImageMode = this._dispImageMode;
					bHSeatControl.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControl.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.IsUsedBackColor = true;
					bHSeatControl.BoxBorderColor = this._BoxBorderColor;
					bHSeatControl.Tag = current;
					base.Controls.Add(bHSeatControl);
					this._seatCharItemsSelect.WireControl(bHSeatControl, this._LeftOneClick, this._RightOneClick, this._DoubleClick, this._OnMouseEnter, this._OnMouseLeave, this._OnCtrlOrShiftMouseClick);
				}
				base.Invalidate();
				result = true;
			}
			return result;
		}
		private Label CreateLb(int nX, int nY, string szTitle)
		{
			return new Label
			{
				ForeColor = Color.Yellow,
				Name = "RowNum" + szTitle,
				Text = szTitle,
				Width = 20,
				Height = 20,
				Location = new Point(nX, nY)
			};
		}
		private bool TitleLabelExist(List<Label> listTitleLb, string szTitle)
		{
			bool result;
			if (listTitleLb.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Label current in listTitleLb)
				{
					if (szTitle == current.Name)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		private Label CreateTopLabel(int nX, int nY, string szName)
		{
			return new Label
			{
				ForeColor = Color.Yellow,
				Name = "Extend" + szName,
				Text = szName,
				Width = 160,
				Height = 20,
				Location = new Point(nX, nY)
			};
		}
		public void SetTopDisplay_Left(string szText)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(Label))
				{
					if (control.Name == "ExtendTopLeft")
					{
						control.Text = szText;
						break;
					}
				}
			}
		}
		public void SetTopDisplay_Center(string szText)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(Label))
				{
					if (control.Name == "ExtendTopCenter")
					{
						control.Text = szText;
						break;
					}
				}
			}
		}
		public void SetTopDisplay_Right(string szText)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(Label))
				{
					if (control.Name == "ExtendTopRight")
					{
						control.Text = szText;
						break;
					}
				}
			}
		}
		public bool ExportItems(string szFile, SeatingChart siList)
		{
			string text = this.ExportItemsToString(siList);
			bool result;
			if (text.Trim().Length <= 0)
			{
				result = false;
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				result = this.WriteFile(szFile, bytes);
			}
			return result;
		}
		private string ExportItemsToString(SeatingChart siList)
		{
			string result;
			if (base.Controls.Count <= 0)
			{
				result = "";
			}
			else
			{
				siList.HallId = "1";
				foreach (Control control in base.Controls)
				{
					Seat item = (Seat)control.Tag;
					siList._listSiteItem.Add(item);
				}
				siList.Seats = base.Controls.Count;
				StringBuilder sb = new StringBuilder();
				StringWriter stringWriter = new StringWriter(sb);
				XmlSerializer xmlSerializer = new XmlSerializer(siList.GetType());
				xmlSerializer.Serialize(stringWriter, siList);
				result = stringWriter.ToString();
			}
			return result;
		}
		private bool WriteFileXML(string szFile, string szItems)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(szItems);
			xmlDocument.Save(szFile);
			return true;
		}
		private bool WriteFile(string szFile, byte[] arrFile)
		{
			bool result;
			if (arrFile == null)
			{
				result = false;
			}
			else
			{
				using (FileStream fileStream = new FileStream(szFile, FileMode.Create))
				{
					fileStream.Write(arrFile, 0, arrFile.Length);
				}
				result = true;
			}
			return result;
		}
		private void SeatChartDisp_Scroll(object sender, ScrollEventArgs e)
		{
			base.Invalidate();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ControlDarkDark;
			base.Name = "SeatChartDisp";
			base.Size = new Size(878, 300);
			base.Scroll += new ScrollEventHandler(this.SeatChartDisp_Scroll);
			base.MouseDown += new MouseEventHandler(this.UC_SeatChartPanel_MouseDown);
			base.MouseMove += new MouseEventHandler(this.UC_SeatChartPanel_MouseMove);
			base.MouseUp += new MouseEventHandler(this.UC_SeatChartPanel_MouseUp);
			base.ResumeLayout(false);
		}
	}
}

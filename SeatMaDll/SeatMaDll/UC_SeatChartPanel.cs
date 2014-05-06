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
	public class UC_SeatChartPanel : UserControl, InterfaceSetSeatResource
	{
		public enum MatrixRectType : byte
		{
			Auto,
			Fix
		}
		public enum MouseCursorStatus : byte
		{
			Empty,
			Insert
		}
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
		private string _RowNumberDispMode = "数字";
		private bool MouseIsDown = false;
		private Rectangle MouseRect = Rectangle.Empty;
		public SeatChartItemSelect _seatCharItemsSelect = new SeatChartItemSelect();
		private Image _backImage = null;
		private static readonly object _MultSelect = new object();
		private static readonly object _InsertOne = new object();
		private static readonly object _RightMouseClick = new object();
		private static readonly object _LeftAndRightKeyMove = new object();
		private IContainer components = null;
		public event EditerSelectMultSeatEventHandler MultSelect
		{
			add
			{
				base.Events.AddHandler(UC_SeatChartPanel._MultSelect, value);
			}
			remove
			{
				base.Events.RemoveHandler(UC_SeatChartPanel._MultSelect, value);
			}
		}
		public event EditerSelectOneSeatEventHandler InsertOne
		{
			add
			{
				base.Events.AddHandler(UC_SeatChartPanel._InsertOne, value);
			}
			remove
			{
				base.Events.RemoveHandler(UC_SeatChartPanel._InsertOne, value);
			}
		}
		public event EditerRMSelectOneSeatEventHandler RightMouseClick
		{
			add
			{
				base.Events.AddHandler(UC_SeatChartPanel._RightMouseClick, value);
			}
			remove
			{
				base.Events.RemoveHandler(UC_SeatChartPanel._RightMouseClick, value);
			}
		}
		public event EventHandler LeftAndRightKeyMove
		{
			add
			{
				base.Events.AddHandler(UC_SeatChartPanel._LeftAndRightKeyMove, value);
			}
			remove
			{
				base.Events.RemoveHandler(UC_SeatChartPanel._LeftAndRightKeyMove, value);
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
		protected virtual void On_MultSelect(EditerSelectMultSeat_Events e)
		{
			EditerSelectMultSeatEventHandler editerSelectMultSeatEventHandler = (EditerSelectMultSeatEventHandler)base.Events[UC_SeatChartPanel._MultSelect];
			if (editerSelectMultSeatEventHandler != null)
			{
				editerSelectMultSeatEventHandler(this, e);
			}
		}
		protected virtual void On_InsertOne(EditerSelectOneSeat_Events e)
		{
			EditerSelectOneSeatEventHandler editerSelectOneSeatEventHandler = (EditerSelectOneSeatEventHandler)base.Events[UC_SeatChartPanel._InsertOne];
			if (editerSelectOneSeatEventHandler != null)
			{
				editerSelectOneSeatEventHandler(this, e);
			}
		}
		protected virtual void On_RightMouseClick(EditerRMSelectOneSeat_Events e)
		{
			EditerRMSelectOneSeatEventHandler editerRMSelectOneSeatEventHandler = (EditerRMSelectOneSeatEventHandler)base.Events[UC_SeatChartPanel._RightMouseClick];
			if (editerRMSelectOneSeatEventHandler != null)
			{
				editerRMSelectOneSeatEventHandler(this, e);
			}
		}
		protected virtual void On_LeftAndRightKeyMove(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[UC_SeatChartPanel._LeftAndRightKeyMove];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}
		public UC_SeatChartPanel()
		{
			this._seatCharItemsSelect._container = this;
			this._seatCharItemsSelect._DoubleClick += new EditerSelectOneSeatEventHandler(this._seatCharItemsSelect__DoubleClick);
			this._seatCharItemsSelect._RightMouseClick += new EditerRMSelectOneSeatEventHandler(this._seatCharItemsSelect__RightMouseClick);
			this.InitializeComponent();
		}
		private void _seatCharItemsSelect__RightMouseClick(object sender, EditerRMSelectOneSeat_Events e)
		{
			this.On_RightMouseClick(e);
		}
		public virtual void SetSeatResource()
		{
		}
		private void _seatCharItemsSelect__DoubleClick(object sender, EditerSelectOneSeat_Events e)
		{
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.DrawBackLine(e);
			this.DrawLeftRowNum(e);
		}
		private void DrawBaseLine(PaintEventArgs e)
		{
			if (!this._dispMoveRuler)
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
		}
		private void DrawLeftRowNum(PaintEventArgs e)
		{
			if (this._dispRowNumber)
			{
				BHSeatControlEditer firstSeatControl = this.GetFirstSeatControl();
				if (firstSeatControl != null)
				{
					Seat seat = (Seat)firstSeatControl.Tag;
					Seat seat2 = (Seat)firstSeatControl.Tag;
					Seat seat3 = (Seat)firstSeatControl.Tag;
					Seat seat4 = (Seat)firstSeatControl.Tag;
					List<Seat> list = new List<Seat>();
					foreach (Control control in base.Controls)
					{
						if (control.GetType() == typeof(BHSeatControlEditer))
						{
							BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
							Seat seat5 = (Seat)bHSeatControlEditer.Tag;
							if (seat5._brotherList.Count <= 0)
							{
								if (!this.LeftseatExist(list, seat5))
								{
									list.Add(seat5);
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
						e.Graphics.DrawString(seat5._seatRowNumberDisplay, font, solidBrush, p, stringFormat);
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
		private void DrawBackLine(PaintEventArgs e)
		{
			if (this._dispMoveRuler)
			{
				int i = this._LeftSpace;
				int j = 0;
				int right = base.Right;
				int bottom = base.Bottom;
				Pen pen = new Pen(Color.White, 0.1f);
				pen.DashStyle = DashStyle.Dot;
				Pen pen2 = new Pen(Color.White, 0.2f);
				int num = 0;
				while (i <= right)
				{
					Point pt = new Point(i, 0);
					Point pt2 = new Point(i, base.Bottom);
					if (num % 5 == 0)
					{
						e.Graphics.DrawLine(pen2, pt, pt2);
					}
					else
					{
						e.Graphics.DrawLine(pen, pt, pt2);
					}
					i += UC_SeatChartPanel._KeyMoveStep * 4;
					num++;
				}
				num = 0;
				while (j <= bottom)
				{
					Point pt = new Point(this._LeftSpace, j);
					Point pt2 = new Point(base.Right, j);
					if (num % 5 == 0)
					{
						e.Graphics.DrawLine(pen2, pt, pt2);
					}
					else
					{
						e.Graphics.DrawLine(pen, pt, pt2);
					}
					j += UC_SeatChartPanel._KeyMoveStep * 4;
					num++;
				}
				pen.Dispose();
				pen2.Dispose();
			}
		}
		private Image CreateImg()
		{
			Pen pen = new Pen(Color.Silver, 0.1f);
			pen.DashStyle = DashStyle.Dot;
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
		private BHSeatControlEditer GetFirstSeatControl()
		{
			BHSeatControlEditer result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					result = (BHSeatControlEditer)control;
					return result;
				}
			}
			result = null;
			return result;
		}
		private void GetFourMarginSeat(ref Seat LeftSeat, ref Seat TopSeat, ref Seat RightSeat, ref Seat BottomSeat)
		{
			BHSeatControlEditer firstSeatControl = this.GetFirstSeatControl();
			if (firstSeatControl != null)
			{
				LeftSeat = (Seat)firstSeatControl.Tag;
				TopSeat = (Seat)firstSeatControl.Tag;
				RightSeat = (Seat)firstSeatControl.Tag;
				BottomSeat = (Seat)firstSeatControl.Tag;
				foreach (Control control in base.Controls)
				{
					if (control.GetType() == typeof(BHSeatControlEditer))
					{
						BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
						Seat seat = (Seat)bHSeatControlEditer.Tag;
						if (seat._brotherList.Count <= 0)
						{
							if (seat._seatPosX < LeftSeat._seatPosX)
							{
								LeftSeat = seat;
							}
							if (seat._seatPosY < TopSeat._seatPosY)
							{
								TopSeat = seat;
							}
							if (seat._seatPosX + seat._seatWidth > RightSeat._seatPosX + RightSeat._seatWidth)
							{
								RightSeat = seat;
							}
							if (seat._seatPosY + seat._seatHeight > BottomSeat._seatPosY + BottomSeat._seatHeight)
							{
								BottomSeat = seat;
							}
						}
						else
						{
							foreach (Seat current in seat._brotherList)
							{
								if (current._seatPosX < LeftSeat._seatPosX)
								{
									LeftSeat = current;
								}
								if (current._seatPosY < TopSeat._seatPosY)
								{
									TopSeat = current;
								}
								if (current._seatPosX + current._seatWidth > RightSeat._seatPosX + RightSeat._seatWidth)
								{
									RightSeat = current;
								}
								if (current._seatPosY + current._seatHeight > BottomSeat._seatPosY + BottomSeat._seatHeight)
								{
									BottomSeat = current;
								}
							}
						}
					}
				}
			}
		}
		private void RowNumDisp(bool _dispRowNumber)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					bHSeatControlEditer.Text = (_dispRowNumber ? seat._seatRowNumber : seat._seatColumn);
					seat._seatDisplay = bHSeatControlEditer.Text;
					if (seat._brotherList != null && seat._brotherList.Count > 0)
					{
						foreach (Seat current in seat._brotherList)
						{
							current._seatDisplay = (_dispRowNumber ? current._seatRowNumber : current._seatColumn);
						}
					}
				}
			}
		}
		private void DisplayText(bool _dispRowNumber)
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					bHSeatControlEditer.Text = (_dispRowNumber ? seat._seatRowNumber : seat._seatColumn);
					seat._seatDisplay = bHSeatControlEditer.Text;
					if (seat._brotherList != null && seat._brotherList.Count > 0)
					{
						foreach (Seat current in seat._brotherList)
						{
							current._seatDisplay = (_dispRowNumber ? current._seatRowNumber : current._seatColumn);
						}
					}
				}
			}
		}
		private void InsertControls(Point pt)
		{
			int matrixUnitWidth = this._matrixUnitWidth;
			int matrixUnitHeight = this._matrixUnitHeight;
			BHSeatControlEditer bHSeatControlEditer = new BHSeatControlEditer();
			bHSeatControlEditer.DispImageMode = this._dispImageMode;
			bHSeatControlEditer.Image = (this._dispImageMode ? SeatResource.ImgEmpty : null);
			bHSeatControlEditer.DisplayText = true;
			bHSeatControlEditer.CursorSelectedIt = false;
			bHSeatControlEditer.Name = "新建";
			bHSeatControlEditer.Text = "新建";
			bHSeatControlEditer.Location = pt;
			bHSeatControlEditer.Width = matrixUnitWidth;
			bHSeatControlEditer.Height = matrixUnitHeight;
			bHSeatControlEditer.SeatType = BHSeatControl.BHSeatType.One;
			bHSeatControlEditer.SeatStatus = BHSeatControl.BHSeatStatus.Empty;
			string seatId = "新建";
			string seatColumn = "0";
			string seatNumber = "0排0号";
			string seatDisplay = "0";
			string seatRowNumberDisplay = "0";
			bHSeatControlEditer.Tag = new Seat(EditSeatItem.GetString_ByControlFlag(bHSeatControlEditer.SeatType), EditSeatItem.GetControlStatus_ByFlag(bHSeatControlEditer.SeatStatus), "0", seatRowNumberDisplay, seatId, seatColumn, seatNumber, seatDisplay, 1, bHSeatControlEditer.Location.X, bHSeatControlEditer.Location.Y, bHSeatControlEditer.Width, bHSeatControlEditer.Height, "SeatingChartId", "SeatingChartId0");
			base.Controls.Add(bHSeatControlEditer);
			this._seatCharItemsSelect.WireControl(bHSeatControlEditer);
			EditerSelectOneSeat_Events e = new EditerSelectOneSeat_Events(bHSeatControlEditer);
			this.On_InsertOne(e);
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
			if (this._CurrentMouseCursorStatus == UC_SeatChartPanel.MouseCursorStatus.Empty)
			{
				if (this.MouseIsDown)
				{
					this.ResizeToRectangle(e.Location);
				}
			}
		}
		private void UC_SeatChartPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._CurrentMouseCursorStatus == UC_SeatChartPanel.MouseCursorStatus.Empty)
			{
				base.Capture = false;
				Cursor.Clip = Rectangle.Empty;
				this.MouseIsDown = false;
				this.DrawRectangle();
				this.BuildSelectedControl();
				this.MouseRect = Rectangle.Empty;
			}
			else
			{
				if (this._CurrentMouseCursorStatus == UC_SeatChartPanel.MouseCursorStatus.Insert)
				{
					this.InsertControls(new Point(e.X, e.Y));
					this._CurrentMouseCursorStatus = UC_SeatChartPanel.MouseCursorStatus.Empty;
					this.Cursor = Cursors.Default;
				}
			}
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
					if (control.GetType() == typeof(BHSeatControlEditer))
					{
						this._seatCharItemsSelect.BuildSelectedControl(control);
					}
				}
			}
			if (UC_SeatChartPanel._MultSelect != null)
			{
				if (this._seatCharItemsSelect._listControlSelect.Count > 0)
				{
					List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
					foreach (Control control in this._seatCharItemsSelect._listControlSelect)
					{
						list.Add((BHSeatControlEditer)control);
					}
					EditerSelectMultSeat_Events e = new EditerSelectMultSeat_Events(list);
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
			this._seatCharItemsSelect.KeyMoveItems(nMoveFlag, UC_SeatChartPanel._KeyMoveStep);
		}
		public void ClearItems()
		{
			this._seatCharItemsSelect.ClearData();
			base.Controls.Clear();
		}
		public void CreateItems(EditSeatInfo editSiteInfoTemp, SeatingChart seatintChartTemp)
		{
			this.CreateSites(editSiteInfoTemp, seatintChartTemp);
		}
		private void CreateSites(EditSeatInfo editSiteInfoTemp, SeatingChart seatintChartTemp)
		{
			if (editSiteInfoTemp != null)
			{
				this.ClearItems();
				int nRows = editSiteInfoTemp._nRows;
				int num = editSiteInfoTemp._nFirRowColumnCount + editSiteInfoTemp._nIncreaseNumber * nRows;
				this._matrixUnitWidth = editSiteInfoTemp._nUnitWidth;
				this._matrixUnitHeight = editSiteInfoTemp._nUnitHeight;
				this._rectangelXSpace = editSiteInfoTemp._nColumnSpace;
				this._rectangelYSpace = editSiteInfoTemp._nRowSpace;
				this._rectangelXSpace = editSiteInfoTemp._ObjSeatingChart.ColumnSpace;
				this._rectangelYSpace = editSiteInfoTemp._ObjSeatingChart.RowSpace;
				this._RowNumberDispMode = editSiteInfoTemp._szRowNumberDispMode;
				int matrixUnitWidth = this._matrixUnitWidth;
				int matrixUnitHeight = this._matrixUnitHeight;
				int num2 = this._rectangelXSpace + matrixUnitWidth;
				int num3 = this._rectangelYSpace + matrixUnitHeight;
				int num4 = 0;
				int num5 = 1;
				int num6 = 1;
				int num7 = 0;
				int num8 = 0;
				EditSeatInfo.GetFirstData_Char(editSiteInfoTemp, ref num4, ref num5, ref num6, ref num7, ref num8);
				int num9 = EditSeatInfo.MaxColumnCount(editSiteInfoTemp);
				int nContainnerMaxWidth = (num * num2 + this._rectangelXSpace > base.Width) ? (num * num2 + this._rectangelXSpace) : base.Width;
				int nContainnerMaxHeight = (nRows * num3 + this._rectangelYSpace > base.Height) ? (nRows * num3 + this._rectangelXSpace) : base.Height;
				int num10 = editSiteInfoTemp._nRows * num3;
				int num11 = num9 * num2;
				int startLeftSpace = EditSeatInfo.GetStartLeftSpace(nContainnerMaxWidth, num11 + this._rectangelXSpace, editSiteInfoTemp._szShapeCode);
				int startTopSpace = EditSeatInfo.GetStartTopSpace(nContainnerMaxHeight, num10 + this._rectangelYSpace, editSiteInfoTemp._szShapeCode);
				for (int i = 0; i < nRows; i++)
				{
					string text = editSiteInfoTemp._szRowNumType.Equals("int") ? EditSeatInfo.GetRowNum_Int(editSiteInfoTemp, i) : EditSeatInfo.GetRowNum_Char(editSiteInfoTemp, ref num4, ref num5, ref num6, ref num7, ref num8);
					num4 = 1;
					num = editSiteInfoTemp._nFirRowColumnCount + i * editSiteInfoTemp._nIncreaseNumber;
					int leftSpaceNum = EditSeatInfo.GetLeftSpaceNum(num9, num, editSiteInfoTemp._szShapeCode);
					int startLeftSpace2 = EditSeatInfo.GetStartLeftSpace(nContainnerMaxWidth, num * num2 + this._rectangelXSpace, editSiteInfoTemp._szShapeCode);
					for (int j = 0; j < num; j++)
					{
						Point location = new Point(startLeftSpace2 + (j + 1) * num2 - matrixUnitWidth, startTopSpace + (i + 1) * num3 - matrixUnitHeight);
						BHSeatControlEditer bHSeatControlEditer = new BHSeatControlEditer();
						bHSeatControlEditer.DispImageMode = this._dispImageMode;
						bHSeatControlEditer.Image = (this._dispImageMode ? SeatResource.ImgEmpty : null);
						bHSeatControlEditer.DisplayText = true;
						bHSeatControlEditer.CursorSelectedIt = false;
						bHSeatControlEditer.Name = "Site" + (i + 1).ToString() + "_" + (j + 1).ToString();
						bHSeatControlEditer.Text = EditSeatInfo.GetColumnNum(editSiteInfoTemp, num, j);
						bHSeatControlEditer.Location = location;
						bHSeatControlEditer.Width = matrixUnitWidth;
						bHSeatControlEditer.Height = matrixUnitHeight;
						bHSeatControlEditer.SeatType = BHSeatControl.BHSeatType.One;
						bHSeatControlEditer.SeatStatus = BHSeatControl.BHSeatStatus.Empty;
						bHSeatControlEditer.BoxBorderColor = this._BoxBorderColor;
						string seatId = editSiteInfoTemp._ObjSeatingChart.HallId + "_" + bHSeatControlEditer.Name;
						string text2 = (j + 1).ToString();
						string seatColumn = text2;
						string seatNumber = text + "排" + text2 + "号";
						string seatDisplay = text2;
						string seatRowNumberDisplay = text;
						if (editSiteInfoTemp._szRowNumType == "int" && this._RowNumberDispMode == "汉字")
						{
							seatRowNumberDisplay = EditSeatItem.ConvertToCN(i + 1);
						}
						bHSeatControlEditer.Tag = new Seat(EditSeatItem.GetString_ByControlFlag(bHSeatControlEditer.SeatType), EditSeatItem.GetControlStatus_ByFlag(bHSeatControlEditer.SeatStatus), text, seatRowNumberDisplay, seatId, seatColumn, seatNumber, seatDisplay, 1, bHSeatControlEditer.Location.X, bHSeatControlEditer.Location.Y, bHSeatControlEditer.Width, bHSeatControlEditer.Height, seatintChartTemp.SeatingChartId, seatintChartTemp.SeatingChartId + "0");
						base.Controls.Add(bHSeatControlEditer);
						this._seatCharItemsSelect.WireControl(bHSeatControlEditer);
						EventHandler eventHandler = (EventHandler)base.Events[UC_SeatChartPanel._LeftAndRightKeyMove];
						if (eventHandler != null)
						{
							bHSeatControlEditer.LeftAndRightKeyMove += eventHandler;
						}
					}
				}
			}
		}
		public bool SetAllItemSelected()
		{
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					this._seatCharItemsSelect.BuildSelectedControl(control);
				}
			}
			return this._seatCharItemsSelect._listControlSelect.Count == base.Controls.Count;
		}
		public bool SetItemsType(BHSeatControlEditer bh, BHSeatControl.BHSeatType bhSeatType)
		{
			bool result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					if (bh.Name == control.Name)
					{
						((BHSeatControlEditer)control).SeatType = bhSeatType;
						Seat seat = (Seat)control.Tag;
						seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
						control.Tag = seat;
						((BHSeatControlEditer)control).Image = (((BHSeatControlEditer)control).DispImageMode ? EditSeatItem.GetControlImg(seat._seatFlag) : null);
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
		public bool SetItemsStatus(BHSeatControlEditer bh, BHSeatControl.BHSeatStatus bhSeatStatus)
		{
			bool result;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					if (bh.Name == control.Name)
					{
						((BHSeatControlEditer)control).SeatStatus = bhSeatStatus;
						Seat seat = (Seat)control.Tag;
						seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
						control.Tag = seat;
						((BHSeatControlEditer)control).ExtendImage = (((BHSeatControlEditer)control).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
		public int GetAllSeatCount()
		{
			int num = 0;
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
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
		public List<BHSeatControlEditer> RetrieveAllItems()
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					list.Add((BHSeatControlEditer)control);
				}
			}
			return list;
		}
		public List<BHSeatControlEditer> RetrieveAllItems_BySeatStatus(string bhSeatStatus)
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControl))
				{
					Seat seat = (Seat)control.Tag;
					if (!(seat._seatStatusFlag != bhSeatStatus))
					{
						list.Add((BHSeatControlEditer)control);
					}
				}
			}
			return list;
		}
		public List<BHSeatControlEditer> RetrieveAllItems_BySeatType(string bhSeatType)
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			foreach (Control control in base.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					Seat seat = (Seat)control.Tag;
					if (!(seat._seatFlag != bhSeatType))
					{
						list.Add((BHSeatControlEditer)control);
					}
				}
			}
			return list;
		}
		public List<BHSeatControlEditer> RetrieveSelectedItems()
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			List<BHSeatControlEditer> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControlEditer))
					{
						list.Add((BHSeatControlEditer)current);
					}
				}
				result = list;
			}
			return result;
		}
		public List<BHSeatControlEditer> RetrieveSelectedItems_BySeatStatus(string bhSeatStatus)
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			List<BHSeatControlEditer> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControlEditer))
					{
						Seat seat = (Seat)current.Tag;
						if (!(seat._seatStatusFlag != bhSeatStatus))
						{
							list.Add((BHSeatControlEditer)current);
						}
					}
				}
				result = list;
			}
			return result;
		}
		public List<BHSeatControlEditer> RetrieveSelectedItems_BySeatType(string bhSeatType)
		{
			List<BHSeatControlEditer> list = new List<BHSeatControlEditer>();
			List<BHSeatControlEditer> result;
			if (this._seatCharItemsSelect._listControlSelect.Count <= 0)
			{
				result = list;
			}
			else
			{
				foreach (Control current in this._seatCharItemsSelect._listControlSelect)
				{
					if (current.GetType() == typeof(BHSeatControlEditer))
					{
						Seat seat = (Seat)current.Tag;
						if (!(seat._seatFlag != bhSeatType))
						{
							list.Add((BHSeatControlEditer)current);
						}
					}
				}
				result = list;
			}
			return result;
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
						if (control.GetType() == typeof(BHSeatControlEditer))
						{
							BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
							Seat seat = (Seat)bHSeatControlEditer.Tag;
							int num3 = num + (int)((bHSeatControlEditer.Location.X - num) * deciZoon);
							int num4 = num2 + (int)((bHSeatControlEditer.Location.Y - num2) * deciZoon);
							int num5 = (int)(bHSeatControlEditer.Width * deciZoon);
							int num6 = (int)(bHSeatControlEditer.Height * deciZoon);
							Point location = new Point(num3, num4);
							bHSeatControlEditer.Location = location;
							bHSeatControlEditer.Width = num5;
							bHSeatControlEditer.Height = num6;
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
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					if (bHSeatControlEditer.Location.X < nLeft)
					{
						nLeft = bHSeatControlEditer.Location.X;
					}
					if (bHSeatControlEditer.Location.Y < nTop)
					{
						nTop = bHSeatControlEditer.Location.Y;
					}
				}
			}
		}
		private void RotationItems(int nRotation)
		{
			if (nRotation == 0 || nRotation == 180)
			{
				if (base.Controls.Count >= 2)
				{
					int x = base.Controls[1].Location.X;
					int y = base.Controls[1].Location.Y;
					int right = base.Controls[1].Right;
					int bottom = base.Controls[1].Bottom;
					this.GetFourMargin(ref x, ref y, ref right, ref bottom);
					int num = x + (right - x) / 2;
					int num2 = y + (bottom - y) / 2;
					foreach (Control control in base.Controls)
					{
						if (control.GetType() == typeof(BHSeatControlEditer))
						{
							BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
							Seat seat = (Seat)bHSeatControlEditer.Tag;
							bHSeatControlEditer.Rotation = nRotation;
							seat._seatPosX = 2 * num - seat._seatPosX - seat._seatWidth;
							seat._seatPosY = 2 * num2 - seat._seatPosY - seat._seatHeight;
							bHSeatControlEditer.Location = new Point(seat._seatPosX, seat._seatPosY);
							if (seat._brotherList.Count > 0)
							{
								foreach (Seat current in seat._brotherList)
								{
									current._seatPosX = 2 * num - current._seatPosX - current._seatWidth;
									current._seatPosY = 2 * num2 - current._seatPosY - current._seatHeight;
								}
							}
						}
					}
				}
			}
		}
		private void GetFourMargin(ref int nLeft, ref int nTop, ref int nRight, ref int nBottom)
		{
			if (base.Controls.Count >= 2)
			{
				nLeft = base.Controls[1].Left;
				nTop = base.Controls[1].Top;
				nRight = base.Controls[1].Right;
				nBottom = base.Controls[1].Bottom;
				foreach (Control control in base.Controls)
				{
					if (control.GetType() == typeof(BHSeatControlEditer))
					{
						if (control.Left < nLeft)
						{
							nLeft = control.Left;
						}
						if (control.Top < nTop)
						{
							nTop = control.Top;
						}
						if (control.Right > nRight)
						{
							nRight = control.Right;
						}
						if (control.Bottom > nBottom)
						{
							nBottom = control.Bottom;
						}
					}
				}
			}
		}
		public void DeleteItemsInSelectList()
		{
			this._seatCharItemsSelect.DeleteItemsInSelectList();
		}
		public void SplitItems(EditSeatInfo editSiteInfoTemp)
		{
			this._seatCharItemsSelect.SplitMultiItems(editSiteInfoTemp, this._dispImageMode);
		}
		public void MergeItems(EditSeatInfo editSiteInfoTemp)
		{
			this._seatCharItemsSelect.MergeMultiItems(editSiteInfoTemp, this._dispImageMode, this._BoxBorderColor);
		}
		public bool PreImportItems(string szFile, ref EditSeatInfo editSeatInfoTemp)
		{
			byte[] bytes = this.ReadFile(szFile);
			string @string = Encoding.UTF8.GetString(bytes);
			editSeatInfoTemp = new EditSeatInfo();
			StringReader textReader = new StringReader(@string);
			bool result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(editSeatInfoTemp.GetType());
				editSeatInfoTemp = (EditSeatInfo)xmlSerializer.Deserialize(textReader);
				result = (editSeatInfoTemp != null);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public bool ImportItems(string szFile, ref EditSeatInfo editSeatInfoTemp)
		{
			byte[] bytes = this.ReadFile(szFile);
			string @string = Encoding.UTF8.GetString(bytes);
			editSeatInfoTemp = new EditSeatInfo();
			StringReader textReader = new StringReader(@string);
			bool result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(editSeatInfoTemp.GetType());
				editSeatInfoTemp = (EditSeatInfo)xmlSerializer.Deserialize(textReader);
				result = this.ImportSeatChartNew(editSeatInfoTemp._ObjSeatingChart);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
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
				SeatingChart seatingChart = new SeatingChart();
				StringReader textReader = new StringReader(@string);
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(seatingChart.GetType());
					seatingChart = (SeatingChart)xmlSerializer.Deserialize(textReader);
					result = this.ImportSeatChartNew(seatingChart);
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
			this.ClearItems();
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
					BHSeatControlEditer bHSeatControlEditer = new BHSeatControlEditer();
					bHSeatControlEditer.Name = "Site" + current._seatRowNumber + "_" + current._seatColumn;
					bHSeatControlEditer.Text = current._seatColumn;
					bHSeatControlEditer.Location = location;
					bHSeatControlEditer.Width = current._seatWidth;
					bHSeatControlEditer.Height = current._seatHeight;
					bHSeatControlEditer.CursorSelectedIt = false;
					bHSeatControlEditer.DisplayText = true;
					bHSeatControlEditer.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControlEditer.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControlEditer.DispImageMode = this._dispImageMode;
					bHSeatControlEditer.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControlEditer.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControlEditer.BoxBorderColor = this._BoxBorderColor;
					bHSeatControlEditer.Tag = current;
					base.Controls.Add(bHSeatControlEditer);
					this._seatCharItemsSelect.WireControl(bHSeatControlEditer);
					EventHandler eventHandler = (EventHandler)base.Events[UC_SeatChartPanel._LeftAndRightKeyMove];
					if (eventHandler != null)
					{
						bHSeatControlEditer.LeftAndRightKeyMove += eventHandler;
					}
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
				int matrixUnitWidth = this._matrixUnitWidth;
				int matrixUnitHeight = this._matrixUnitHeight;
				foreach (Seat current in sl._listSiteItem)
				{
					Point location = new Point(current._seatPosX, current._seatPosY);
					BHSeatControlEditer bHSeatControlEditer = new BHSeatControlEditer();
					bHSeatControlEditer.Name = "Site" + current._seatRowNumber + "_" + current._seatColumn;
					bHSeatControlEditer.Text = current._seatColumn;
					bHSeatControlEditer.Location = location;
					bHSeatControlEditer.Width = ((EditSeatItem.GetControl_ByFlag(current._seatFlag) == BHSeatControl.BHSeatType.Two) ? (2 * matrixUnitWidth + this._rectangelXSpace) : matrixUnitWidth);
					bHSeatControlEditer.Height = matrixUnitHeight;
					bHSeatControlEditer.CursorSelectedIt = false;
					bHSeatControlEditer.DisplayText = true;
					bHSeatControlEditer.SeatType = EditSeatItem.GetControl_ByFlag(current._seatFlag);
					bHSeatControlEditer.SeatStatus = EditSeatItem.GetControlStatus_ByFlag(current._seatStatusFlag);
					bHSeatControlEditer.DispImageMode = this._dispImageMode;
					bHSeatControlEditer.Image = (this._dispImageMode ? EditSeatItem.GetControlImg(current._seatFlag) : null);
					bHSeatControlEditer.ExtendImage = (this._dispImageMode ? EditSeatItem.GetControlExtendImg(current._seatStatusFlag) : null);
					bHSeatControlEditer.BoxBorderColor = this._BoxBorderColor;
					bHSeatControlEditer.Tag = current;
					base.Controls.Add(bHSeatControlEditer);
					this._seatCharItemsSelect.WireControl(bHSeatControlEditer);
				}
				result = true;
			}
			return result;
		}
		public bool ExportItems(string szFile, EditSeatInfo es)
		{
			bool result;
			if (szFile == null || szFile.Trim().Length <= 0)
			{
				result = false;
			}
			else
			{
				string text = this.ExportItemsToString(es);
				if (text.Trim().Length <= 0)
				{
					result = false;
				}
				else
				{
					this._RowNumberDispMode = es._szRowNumberDispMode;
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					result = this.WriteFile(szFile, bytes);
				}
			}
			return result;
		}
		private string ExportItemsToString(EditSeatInfo es)
		{
			string result;
			if (base.Controls.Count <= 0)
			{
				result = "";
			}
			else
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				int num = 0;
				foreach (Control control in base.Controls)
				{
					if (control.GetType() == typeof(BHSeatControlEditer))
					{
						Seat seat = (Seat)control.Tag;
						seat._seatDisplay = seat._seatColumn;
						if (seat._brotherList.Count > 0)
						{
							foreach (Seat current in seat._brotherList)
							{
								if (!(current._seatColumn == "0") || !(current._seatId == "新建") || !(current._seatRowNumber == "0") || !(current._seatNumber == "0排0号"))
								{
									current._seatDisplay = current._seatColumn;
									num++;
									if (!this.CheckRowOrColumnNumInList(list, current._seatRowNumber))
									{
										list.Add(current._seatRowNumber);
									}
									if (!this.CheckRowOrColumnNumInList(list2, current._seatColumn))
									{
										list2.Add(current._seatColumn);
									}
								}
							}
						}
						else
						{
							if (seat._seatColumn == "0" && seat._seatId == "新建" && seat._seatRowNumber == "0" && seat._seatNumber == "0排0号")
							{
								continue;
							}
							num++;
							if (!this.CheckRowOrColumnNumInList(list, seat._seatRowNumber))
							{
								list.Add(seat._seatRowNumber);
							}
							if (!this.CheckRowOrColumnNumInList(list2, seat._seatColumn))
							{
								list2.Add(seat._seatColumn);
							}
						}
						es._ObjSeatingChart._listSiteItem.Add(seat);
					}
				}
				es._ObjSeatingChart.Seats = num;
				es._ObjSeatingChart.Rows = list.Count;
				es._ObjSeatingChart.Columns = list2.Count;
				es._ObjSeatingChart.RowSpace = es._nRowSpace;
				es._ObjSeatingChart.ColumnSpace = es._nColumnSpace;
				StringBuilder sb = new StringBuilder();
				StringWriter stringWriter = new StringWriter(sb);
				XmlSerializer xmlSerializer = new XmlSerializer(es.GetType());
				xmlSerializer.Serialize(stringWriter, es);
				result = stringWriter.ToString();
			}
			return result;
		}
		private bool CheckRowOrColumnNumInList(List<string> list, string szRows)
		{
			bool result;
			if (list.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (string current in list)
				{
					if (current == szRows)
					{
						result = true;
						return result;
					}
				}
				result = false;
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
			if (szFile == null || szFile.Trim().Length <= 0)
			{
				result = false;
			}
			else
			{
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
			}
			return result;
		}
		private void UC_SeatChartPanel_SizeChanged(object sender, EventArgs e)
		{
			base.Invalidate();
		}
		private void UC_SeatChartPanel_ClientSizeChanged(object sender, EventArgs e)
		{
			base.Invalidate();
		}
		private void UC_SeatChartPanel_Scroll(object sender, ScrollEventArgs e)
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
			base.Name = "UC_SeatChartPanel";
			base.Size = new Size(878, 300);
			base.Scroll += new ScrollEventHandler(this.UC_SeatChartPanel_Scroll);
			base.ClientSizeChanged += new EventHandler(this.UC_SeatChartPanel_ClientSizeChanged);
			base.SizeChanged += new EventHandler(this.UC_SeatChartPanel_SizeChanged);
			base.MouseDown += new MouseEventHandler(this.UC_SeatChartPanel_MouseDown);
			base.MouseMove += new MouseEventHandler(this.UC_SeatChartPanel_MouseMove);
			base.MouseUp += new MouseEventHandler(this.UC_SeatChartPanel_MouseUp);
			base.ResumeLayout(false);
		}
	}
}

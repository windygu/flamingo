using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class BHSeatControl : Label
	{
		public enum BHSeatType : byte
		{
			One,
			Two,
			Box,
			Deformity,
			DeformityOne,
			NotFit,
			Stoped,
			Worked,
			Special
		}
		public enum BHSeatStatus : byte
		{
			Empty,
			Lock,
			SpecialLock,
			PrSuccess,
			Success,
			Selected
		}
		private BHSeatControl.BHSeatType _seatType = BHSeatControl.BHSeatType.One;
		private BHSeatControl.BHSeatStatus _seatStatus = BHSeatControl.BHSeatStatus.Empty;
		private bool _cursorselectedIt = false;
		private bool _displayText = false;
		private bool _dispImageMode = false;
		private Image _extendImage = null;
		private int _GWidth = 30;
		private int _GHeight = 20;
		private int _Rotation = 0;
		private bool _IsUsedBackColor = false;
		private Color _BoxBorderColor = Color.White;
		private IContainer components = null;
		[Category("座位设置"), Description("Specifies the Seat Type.")]
		public BHSeatControl.BHSeatType SeatType
		{
			get
			{
				object obj = this._seatType;
				return (obj == null) ? BHSeatControl.BHSeatType.One : ((BHSeatControl.BHSeatType)obj);
			}
			set
			{
				if (this._seatType != value)
				{
					this._seatType = value;
					base.Invalidate();
				}
			}
		}
		[Category("座位设置"), Description("Specifies the Seat Status.")]
		public BHSeatControl.BHSeatStatus SeatStatus
		{
			get
			{
				object obj = this._seatStatus;
				return (obj == null) ? BHSeatControl.BHSeatStatus.Empty : ((BHSeatControl.BHSeatStatus)obj);
			}
			set
			{
				if (this._seatStatus != value)
				{
					this._seatStatus = value;
					base.Invalidate();
				}
			}
		}
		[Category("座位设置"), Description("Extend Image.")]
		public Image ExtendImage
		{
			get
			{
				return this._extendImage;
			}
			set
			{
				if (this._extendImage != value)
				{
					this._extendImage = value;
					base.Invalidate();
				}
			}
		}
		public int GWidth
		{
			get
			{
				return this._GWidth;
			}
			set
			{
				if (this._GWidth != value)
				{
					this._GWidth = value;
					base.Invalidate();
				}
			}
		}
		public int GHeight
		{
			get
			{
				return this._GHeight;
			}
			set
			{
				if (this._GHeight != value)
				{
					this._GHeight = value;
					base.Invalidate();
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
					base.Invalidate();
				}
			}
		}
		public bool CursorSelectedIt
		{
			get
			{
				return this._cursorselectedIt;
			}
			set
			{
				if (this._cursorselectedIt != value)
				{
					this._cursorselectedIt = value;
					base.Invalidate();
				}
			}
		}
		public bool DisplayText
		{
			get
			{
				return this._displayText;
			}
			set
			{
				if (this._displayText != value)
				{
					this._displayText = value;
					base.Invalidate();
				}
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
		public bool IsUsedBackColor
		{
			get
			{
				return this._IsUsedBackColor;
			}
			set
			{
				if (this._IsUsedBackColor != value)
				{
					this._IsUsedBackColor = value;
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
					base.Invalidate();
				}
			}
		}
		public BHSeatControl()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.StandardClick, true);
			base.SetStyle(ControlStyles.StandardDoubleClick, true);
		}
		private Rectangle DeflateRect(Rectangle rect, Padding padding)
		{
			rect.X += padding.Left;
			rect.Y += padding.Top;
			rect.Width -= padding.Horizontal;
			rect.Height -= padding.Vertical;
			return rect;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rect = this.DeflateRect(base.ClientRectangle, base.Padding);
			if (base.Tag != null)
			{
				Seat seat = (Seat)base.Tag;
				if (seat._brotherList.Count > 0)
				{
					this.DrawDispImageBox(e, rect);
				}
				else
				{
					this.DrawDispImage(e, rect);
				}
				if (this._cursorselectedIt)
				{
					this.DrawSelectBorder(e, base.ClientRectangle);
				}
			}
			else
			{
				Pen pen = new Pen(Color.Black, 4f);
				e.Graphics.DrawRectangle(pen, rect);
				pen.Dispose();
			}
		}
		private void DrawBackColor(PaintEventArgs e, Rectangle rect)
		{
			if (base.Tag != null)
			{
				Seat seat = (Seat)base.Tag;
				if (seat._IsUsedBackColor)
				{
					if (seat._BackColor != 0)
					{
						Color color = Color.FromArgb(seat._BackColor & 255, (seat._BackColor & 65280) >> 8, (seat._BackColor & 16711680) >> 16);
						SolidBrush brush = new SolidBrush(color);
						e.Graphics.FillRectangle(brush, rect);
					}
				}
			}
		}
		private void DrawExtendImg(PaintEventArgs e, Rectangle rect, string szSeatStatusFlag)
		{
			if (szSeatStatusFlag == "1" || szSeatStatusFlag == "2" || szSeatStatusFlag == "3" || szSeatStatusFlag == "4")
			{
				Image controlExtendImg = EditSeatItem.GetControlExtendImg(szSeatStatusFlag);
				if (controlExtendImg != null)
				{
					e.Graphics.DrawImage(controlExtendImg, rect);
				}
			}
		}
		private void DrawDispImage(PaintEventArgs e, Rectangle rect)
		{
			if (base.Tag == null)
			{
				Pen pen = new Pen(Color.Black, 4f);
				e.Graphics.DrawRectangle(pen, rect);
				pen.Dispose();
			}
			else
			{
				Seat seat = (Seat)base.Tag;
				if (seat._IsUsedBackColor)
				{
					if (seat._BackColor != 0)
					{
						Color color = Color.FromArgb(seat._BackColor & 255, (seat._BackColor & 65280) >> 8, (seat._BackColor & 16711680) >> 16);
						SolidBrush solidBrush = new SolidBrush(color);
						e.Graphics.FillRectangle(solidBrush, rect);
						solidBrush.Dispose();
					}
				}
				Image controlImg = EditSeatItem.GetControlImg(seat._seatFlag);
				if (this._Rotation == 180)
				{
					Point point = new Point(rect.X, rect.Bottom);
					Point point2 = new Point(rect.Right, rect.Bottom);
					Point point3 = new Point(rect.X, rect.Y);
					Point[] destPoints = new Point[]
					{
						point,
						point2,
						point3
					};
					e.Graphics.DrawImage(controlImg, destPoints);
				}
				else
				{
					e.Graphics.DrawImage(EditSeatItem.GetControlImg(seat._seatFlag), rect);
				}
				if (this._seatStatus == BHSeatControl.BHSeatStatus.Lock || this._seatStatus == BHSeatControl.BHSeatStatus.SpecialLock || this._seatStatus == BHSeatControl.BHSeatStatus.PrSuccess || this._seatStatus == BHSeatControl.BHSeatStatus.Success)
				{
					this.DrawExtendImg(e, rect, seat._seatStatusFlag);
				}
				if (this._seatStatus == BHSeatControl.BHSeatStatus.Selected)
				{
					this.DrawSelectBorder(e, base.ClientRectangle);
				}
				if (this._displayText)
				{
					if (seat._seatFlag == "0" || seat._seatFlag == "1" || seat._seatFlag == "2" || seat._seatFlag == "5" || seat._seatFlag == "4")
					{
						if (seat._seatStatusFlag == "0" || seat._seatStatusFlag == "5")
						{
							this.DrawDisplayText(e, rect, seat._seatColumn, this._Rotation);
						}
					}
				}
			}
		}
		private void DrawDispImageTwo(PaintEventArgs e, Rectangle rect)
		{
			if (base.Image == null)
			{
				Pen pen = new Pen(Color.Black, 4f);
				e.Graphics.DrawRectangle(pen, rect);
			}
			else
			{
				Seat seat = (Seat)base.Tag;
				if (seat._brotherList.Count == 2)
				{
					Seat seat2 = seat._brotherList[0];
					Seat seat3 = seat._brotherList[1];
					Rectangle rect2 = new Rectangle(rect.X, rect.Y, seat2._seatWidth, seat2._seatHeight);
					e.Graphics.DrawImage(base.Image, rect2);
					if (this._displayText)
					{
						if (this._seatStatus != BHSeatControl.BHSeatStatus.Success)
						{
							this.DrawDisplayText(e, rect2, seat2._seatColumn);
						}
					}
					rect2 = new Rectangle(rect.X + seat3._seatPosX - seat2._seatPosX, rect.Y + seat3._seatPosY - seat2._seatPosY, seat3._seatWidth, seat3._seatHeight);
					e.Graphics.DrawImage(base.Image, rect2);
					if (this._displayText)
					{
						if (this._seatStatus != BHSeatControl.BHSeatStatus.Success)
						{
							this.DrawDisplayText(e, rect2, seat3._seatColumn);
						}
					}
					Pen pen = new Pen(Color.White, 6f);
					e.Graphics.DrawRectangle(pen, rect);
					pen.Dispose();
				}
			}
		}
		private void DrawDispImageBox(PaintEventArgs e, Rectangle rect)
		{
			if (base.Image == null)
			{
				Pen pen = new Pen(Color.Black, 4f);
				e.Graphics.DrawRectangle(pen, rect);
				pen.Dispose();
			}
			else
			{
				Seat seat = (Seat)base.Tag;
				int num = 10000;
				int num2 = 10000;
				this.GetMinLeftAndTopSize(seat._brotherList, ref num, ref num2);
				int num3 = 0;
				foreach (Seat current in seat._brotherList)
				{
					Image controlImg = EditSeatItem.GetControlImg(current._seatFlag);
					Rectangle rect2 = new Rectangle(rect.X + current._seatPosX - num, rect.Y + current._seatPosY - num2, current._seatWidth, current._seatHeight);
					if (current._IsUsedBackColor)
					{
						if (current._BackColor != 0)
						{
							Color color = Color.FromArgb(current._BackColor & 255, (current._BackColor & 65280) >> 8, (current._BackColor & 16711680) >> 16);
							SolidBrush solidBrush = new SolidBrush(color);
							e.Graphics.FillRectangle(solidBrush, rect2);
							solidBrush.Dispose();
						}
					}
					if (this._Rotation == 180)
					{
						Point point = new Point(rect2.X, rect2.Bottom);
						Point point2 = new Point(rect2.Right, rect2.Bottom);
						Point point3 = new Point(rect2.X, rect2.Y);
						Point[] destPoints = new Point[]
						{
							point,
							point2,
							point3
						};
						e.Graphics.DrawImage(controlImg, destPoints);
					}
					else
					{
						e.Graphics.DrawImage(EditSeatItem.GetControlImg(current._seatFlag), rect2);
					}
					if (current._seatStatusFlag == "1" || current._seatStatusFlag == "2" || current._seatStatusFlag == "3" || current._seatStatusFlag == "4")
					{
						this.DrawExtendImg(e, rect2, current._seatStatusFlag);
					}
					if (current._seatStatusFlag == "5")
					{
						this.DrawSelectBorder(e, new Rectangle(rect2.Left + 3, rect2.Top + 4, rect2.Width - 6, rect2.Height - 8), 3);
						num3++;
					}
					if (this._displayText)
					{
						if (current._seatFlag == "0" || current._seatFlag == "1" || current._seatFlag == "2" || current._seatFlag == "5" || current._seatFlag == "4")
						{
							if (current._seatStatusFlag == "0" || current._seatStatusFlag == "5")
							{
								this.DrawDisplayText(e, rect2, current._seatColumn, this._Rotation);
							}
						}
					}
				}
				Pen pen2 = new Pen(this._BoxBorderColor, 6f);
				e.Graphics.DrawRectangle(pen2, rect);
				pen2.Dispose();
				if (num3 == seat._brotherList.Count)
				{
					this.DrawSelectBorder(e, base.ClientRectangle);
				}
			}
		}
		private void GetMinLeftAndTopSize(List<Seat> list, ref int nLeft, ref int nTop)
		{
			if (list != null && list.Count > 0)
			{
				nLeft = 10000;
				nTop = 10000;
				foreach (Seat current in list)
				{
					int seatPosX = current._seatPosX;
					int seatPosY = current._seatPosY;
					if (seatPosX < nLeft)
					{
						nLeft = seatPosX;
					}
					if (seatPosY < nTop)
					{
						nTop = seatPosY;
					}
				}
			}
		}
		public void DrawDisplayText(PaintEventArgs e, Rectangle rect, string szText, int nRotation)
		{
			if (this._Rotation == 180)
			{
				float fontSize = this.GetFontSize(rect);
				float x = (float)(rect.X + 5);
				float num = (float)rect.Y + ((float)rect.Height - fontSize) / 2f;
				float num2 = (float)(rect.Width - 10);
				float num3 = (float)rect.Height;
				if (num < 0f)
				{
					num = 0f;
				}
				if (num2 < fontSize)
				{
					num2 = fontSize;
				}
				if (num3 < fontSize)
				{
					num3 = fontSize;
				}
				RectangleF layoutRectangle = new RectangleF(x, num, num2, num3);
				Font font = new Font("Arial", this.GetFontSize(rect), FontStyle.Bold, GraphicsUnit.Pixel);
				SolidBrush solidBrush = new SolidBrush(Color.Yellow);
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				e.Graphics.DrawString(szText, font, solidBrush, layoutRectangle, stringFormat);
				stringFormat.Dispose();
				font.Dispose();
				solidBrush.Dispose();
			}
			else
			{
				float fontSize = this.GetFontSize(rect);
				float x = (float)(rect.X + 5);
				float num = (float)(rect.Y - 5) + ((float)rect.Height - fontSize) / 2f;
				float num2 = (float)(rect.Width - 10);
				float num3 = (float)(rect.Height - 5);
				if (num < 0f)
				{
					num = 0f;
				}
				if (num2 < fontSize)
				{
					num2 = fontSize;
				}
				if (num3 < fontSize)
				{
					num3 = fontSize;
				}
				RectangleF layoutRectangle = new RectangleF(x, num, num2, num3);
				Font font = new Font("Arial", this.GetFontSize(rect), FontStyle.Bold, GraphicsUnit.Pixel);
				SolidBrush solidBrush = new SolidBrush(Color.Yellow);
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				e.Graphics.DrawString(szText, font, solidBrush, layoutRectangle, stringFormat);
				stringFormat.Dispose();
				font.Dispose();
				solidBrush.Dispose();
			}
		}
		private List<SeatRows> DispathSeat(List<Seat> listSeat)
		{
			List<SeatRows> list = new List<SeatRows>();
			foreach (Seat current in listSeat)
			{
				SeatRows seatRows = this.SeatRowsExist(list, current._seatRowNumber);
				if (seatRows == null)
				{
					seatRows = new SeatRows(current._seatRowNumber);
					list.Add(seatRows);
				}
				seatRows._listSiteItem.Add(current);
			}
			return list;
		}
		private SeatRows SeatRowsExist(List<SeatRows> list, string seatRowNumber)
		{
			SeatRows result;
			if (list == null || list.Count <= 0)
			{
				result = null;
			}
			else
			{
				foreach (SeatRows current in list)
				{
					if (current._seatRowNumber == seatRowNumber)
					{
						result = current;
						return result;
					}
				}
				result = null;
			}
			return result;
		}
		private int GetMinLeftSize(List<SeatRows> list)
		{
			int result;
			if (list == null || list.Count <= 0)
			{
				result = 0;
			}
			else
			{
				int num = -1;
				foreach (SeatRows current in list)
				{
					int seatPosX = current._listSiteItem[0]._seatPosX;
					if (num == -1)
					{
						num = seatPosX;
					}
					if (num > seatPosX)
					{
						num = seatPosX;
					}
				}
				result = num;
			}
			return result;
		}
		public void DrawDisplayText(PaintEventArgs e, Rectangle rect, string szText)
		{
			float fontSize = this.GetFontSize(rect);
			float x = (float)(rect.X + 5);
			float num = (float)(rect.Y - 5) + ((float)rect.Height - fontSize) / 2f;
			float num2 = (float)(rect.Width - 10);
			float num3 = (float)(rect.Height - 5);
			if (num < 0f)
			{
				num = 0f;
			}
			if (num2 < fontSize)
			{
				num2 = fontSize;
			}
			if (num3 < fontSize)
			{
				num3 = fontSize;
			}
			RectangleF layoutRectangle = new RectangleF(x, num, num2, num3);
			Font font = new Font("Arial", this.GetFontSize(rect), FontStyle.Bold, GraphicsUnit.Pixel);
			SolidBrush brush = new SolidBrush(Color.Yellow);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			e.Graphics.DrawString(szText, font, brush, layoutRectangle, stringFormat);
		}
		public void DrawSiteOne(PaintEventArgs e, Rectangle rect)
		{
			LinearGradientBrush brush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), Color.FromArgb(255, 0, 128, 0), Color.FromArgb(255, 0, 0, 255));
			Pen pen = new Pen(brush);
			Rectangle rect2 = new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height - 5);
			LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Color.Yellow, Color.Red, LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush2, rect2);
			brush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 0, 255));
			pen = new Pen(brush);
			e.Graphics.FillRectangle(brush, rect.X, rect.Y + 2, 5, rect.Height - 5);
			e.Graphics.FillRectangle(brush, rect.X + rect.Width - 5, rect.Y + 2, 5, rect.Height - 5);
			e.Graphics.DrawLine(pen, rect.X + 4, rect.Y + rect.Height - 5, rect.X + rect.Width - 4, rect.Y + rect.Height - 5);
			e.Graphics.DrawLine(pen, rect.X + 4, rect.Y + rect.Height - 4, rect.X + rect.Width - 4, rect.Y + rect.Height - 4);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 3, rect.X + rect.Width - 3, rect.Y + rect.Height - 3);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 2, rect.X + rect.Width - 3, rect.Y + rect.Height - 2);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 1, rect.X + rect.Width - 3, rect.Y + rect.Height - 1);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 1, rect.X + rect.Width - 3, rect.Y + rect.Height - 1);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height, rect.X + rect.Width - 3, rect.Y + rect.Height);
		}
		public void DrawSiteTwo(PaintEventArgs e, Rectangle rect)
		{
			LinearGradientBrush brush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), Color.FromArgb(255, 0, 128, 0), Color.FromArgb(255, 0, 0, 255));
			Pen pen = new Pen(brush);
			Rectangle rect2 = new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height - 5);
			LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Color.Yellow, Color.Red, LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush2, rect2);
			brush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 0, 255));
			pen = new Pen(brush);
			e.Graphics.FillRectangle(brush, rect.X, rect.Y + 2, 5, rect.Height - 5);
			e.Graphics.FillRectangle(brush, rect.X + rect.Width - 5, rect.Y + 2, 5, rect.Height - 5);
			e.Graphics.DrawLine(pen, rect.X + 4, rect.Y + rect.Height - 5, rect.X + rect.Width - 4, rect.Y + rect.Height - 5);
			e.Graphics.DrawLine(pen, rect.X + 4, rect.Y + rect.Height - 4, rect.X + rect.Width - 4, rect.Y + rect.Height - 4);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 3, rect.X + rect.Width - 3, rect.Y + rect.Height - 3);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 2, rect.X + rect.Width - 3, rect.Y + rect.Height - 2);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height - 1, rect.X + rect.Width - 3, rect.Y + rect.Height - 1);
			e.Graphics.DrawLine(pen, rect.X + 3, rect.Y + rect.Height, rect.X + rect.Width - 3, rect.Y + rect.Height);
			e.Graphics.DrawLine(pen, rect.X + 5 + (rect.Width - 10) / 2, rect.Y, rect.X + 5 + (rect.Width - 10) / 2, rect.Y + rect.Height);
		}
		public void DrawSiteDeformity(PaintEventArgs e, Rectangle rect)
		{
			Pen pen = new Pen(Color.Black);
			SolidBrush brush = new SolidBrush(Color.Yellow);
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.DrawRectangle(pen, rect);
			Rectangle rect2 = new Rectangle(rect.X + 5, rect.Y + 11, rect.Width - 16, rect.Height - 13);
			float startAngle = 180f;
			float sweepAngle = 360f;
			e.Graphics.DrawArc(pen, rect2, startAngle, sweepAngle);
			Point pt = new Point(rect2.X + rect2.Width / 3, rect2.Y + rect2.Height / 3);
			Point pt2 = new Point(rect.X + rect.Width - 10, rect2.Y + rect2.Height / 3);
			pen = new Pen(Color.Brown, 3f);
			e.Graphics.DrawLine(pen, pt, pt2);
			pt2.X = rect.X + 8;
			pt2.Y = rect.Y + 5;
			e.Graphics.DrawLine(pen, pt, pt2);
			pt.X = rect.X + rect.Width - 10;
			pt.Y = rect2.Y + rect2.Height / 3;
			pt2.X = pt.X + 5;
			pt2.Y = pt.Y + 8;
			e.Graphics.DrawLine(pen, pt, pt2);
		}
		public void DrawSiteOne_OK(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteOne(e, rect);
			this.DrawOK(e, rect);
		}
		public void DrawSiteTwo_OK(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteTwo(e, rect);
			this.DrawOK(e, rect);
		}
		public void DrawSiteDeformity_OK(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteDeformity(e, rect);
			this.DrawOK(e, rect);
		}
		public void DrawSiteOne_Error(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteOne(e, rect);
			this.DrawDisable(e, rect);
		}
		public void DrawSiteTwo_Error(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteTwo(e, rect);
			this.DrawDisable(e, rect);
		}
		public void DrawSiteDeformity_Error(PaintEventArgs e, Rectangle rect)
		{
			this.DrawSiteDeformity(e, rect);
			this.DrawDisable(e, rect);
		}
		private void DrawDisable(PaintEventArgs e, Rectangle rect)
		{
			int num = rect.X;
			int num2 = rect.Y;
			int width = (rect.Width > rect.Height) ? rect.Height : rect.Width;
			int height = (rect.Height > rect.Width) ? rect.Width : rect.Height;
			num += ((rect.Width > rect.Height) ? ((rect.Width - rect.Height) / 2) : 0);
			num2 += ((rect.Height > rect.Width) ? ((rect.Height - rect.Width) / 2) : 0);
			Rectangle rect2 = new Rectangle(num, num2, width, height);
			SolidBrush brush = new SolidBrush(Color.Red);
			Pen pen = new Pen(Color.Yellow, 8f);
			float startAngle = 180f;
			float sweepAngle = 360f;
			Math.Sin(45.0);
			e.Graphics.FillPie(brush, rect2, startAngle, sweepAngle);
			float num3 = (float)rect2.Width - (float)((double)rect2.Width * Math.Sin(45.0));
			float x = (float)rect2.X + num3;
			float y = (float)rect2.Y + num3;
			float x2 = (float)(rect2.X + rect2.Width) - num3;
			float y2 = (float)(rect2.Y + rect2.Width) - num3;
			e.Graphics.DrawLine(pen, x, y, x2, y2);
			x = (float)(rect2.X + rect2.Width) - num3;
			y = (float)rect2.Y + num3;
			x2 = (float)rect2.X + num3;
			y2 = (float)(rect2.Y + rect2.Width) - num3;
			e.Graphics.DrawLine(pen, x, y, x2, y2);
		}
		private void DrawOK(PaintEventArgs e, Rectangle rect)
		{
			int num = rect.X;
			int num2 = rect.Y;
			int width = (rect.Width > rect.Height) ? rect.Height : rect.Width;
			int height = (rect.Height > rect.Width) ? rect.Width : rect.Height;
			num += ((rect.Width > rect.Height) ? ((rect.Width - rect.Height) / 2) : 0);
			num2 += ((rect.Height > rect.Width) ? ((rect.Height - rect.Width) / 2) : 0);
			Rectangle rectangle = new Rectangle(num, num2, width, height);
			SolidBrush solidBrush = new SolidBrush(Color.Red);
			Pen pen = new Pen(Color.Red, 6f);
			Math.Sin(45.0);
			float num3 = (float)rectangle.Width - (float)((double)rectangle.Width * Math.Sin(45.0));
			float x = (float)rectangle.X + num3;
			float y = (float)rectangle.Y + num3;
			float num4 = (float)(rectangle.X + rectangle.Width) - num3;
			float y2 = (float)(rectangle.Y + rectangle.Width) - num3;
			PointF pt = new PointF(x, y);
			PointF pt2 = new PointF((float)(rect.X + rect.Width / 2), y2);
			e.Graphics.DrawLine(pen, pt, pt2);
			pt.X = (float)(rectangle.X + rectangle.Width) - num3;
			pt.Y = (float)rectangle.Y + num3;
			e.Graphics.DrawLine(pen, pt, pt2);
		}
		private float GetFontSize(Rectangle rect)
		{
			float num = 6f;
			float result;
			if (rect.Height >= 50)
			{
				num = (float)rect.Height / 2f;
				result = num;
			}
			else
			{
				if (rect.Height >= 40)
				{
					num = (float)rect.Height / 2f;
					result = num;
				}
				else
				{
					if (rect.Height >= 30)
					{
						num = (float)rect.Height / 2f;
						result = num;
					}
					else
					{
						if (rect.Height >= 20)
						{
							num = 10f;
							result = num;
						}
						else
						{
							if (rect.Height >= 10)
							{
								num = 6f;
								result = num;
							}
							else
							{
								result = num;
							}
						}
					}
				}
			}
			return result;
		}
		public void DrawDisplayText(PaintEventArgs e, Rectangle rect)
		{
			float fontSize = this.GetFontSize(rect);
			float x = (float)(rect.X + 5);
			float num = (float)(rect.Y - 5) + ((float)rect.Height - fontSize) / 2f;
			float num2 = (float)(rect.Width - 10);
			float num3 = (float)(rect.Height - 5);
			if (num < 0f)
			{
				num = 0f;
			}
			if (num2 < fontSize)
			{
				num2 = fontSize;
			}
			if (num3 < fontSize)
			{
				num3 = fontSize;
			}
			RectangleF layoutRectangle = new RectangleF(x, num, num2, num3);
			Font font = new Font("Arial", this.GetFontSize(rect), FontStyle.Bold, GraphicsUnit.Pixel);
			SolidBrush brush = new SolidBrush(Color.Yellow);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			e.Graphics.DrawString(this.Text, font, brush, layoutRectangle, stringFormat);
		}
		private void DrawSelectBorder(PaintEventArgs e, Rectangle rect)
		{
			Pen pen = new Pen(Color.Red, 4f);
			e.Graphics.DrawRectangle(pen, rect);
			pen.Dispose();
		}
		private void DrawSelectBorder(PaintEventArgs e, Rectangle rect, int nPenWidth)
		{
			if (nPenWidth > 10)
			{
				nPenWidth = 8;
			}
			if (nPenWidth <= 0)
			{
				nPenWidth = 2;
			}
			Pen pen = new Pen(Color.Red, (float)nPenWidth);
			e.Graphics.DrawRectangle(pen, rect);
			pen.Dispose();
		}
		private void DrawSelectBorderB(PaintEventArgs e, Rectangle rect)
		{
			Pen pen = new Pen(Color.Yellow, 8f);
			e.Graphics.DrawRectangle(pen, rect);
			pen.Dispose();
		}
		private void DrawExtend(PaintEventArgs e, Rectangle rect)
		{
			if (this._extendImage != null)
			{
				int x = rect.Left + 2;
				int y = rect.Top + 2;
				int width = this._extendImage.Width;
				int height = this._extendImage.Height;
				if (width > rect.Width)
				{
					width = rect.Width;
				}
				if (height > rect.Height)
				{
					height = rect.Height;
				}
				x = rect.Left + (rect.Width - width) / 2;
				y = rect.Top + (rect.Height - height) / 2;
				Rectangle rect2 = new Rectangle(x, y, width, height);
				e.Graphics.DrawImage(this._extendImage, rect2);
			}
		}
		private void DrawDispImageAttrib(PaintEventArgs e, Rectangle rect)
		{
			if (base.Image != null)
			{
                Image thumbnailImage = base.Image.GetThumbnailImage(rect.Width, rect.Height, null, new IntPtr(0));
				ImageAttributes imageAttributes = new ImageAttributes();
				float[][] array = new float[5][];
				float[][] arg_61_0 = array;
				int arg_61_1 = 0;
				float[] array2 = new float[5];
				array2[0] = 2f;
				arg_61_0[arg_61_1] = array2;
				float[][] arg_78_0 = array;
				int arg_78_1 = 1;
				array2 = new float[5];
				array2[1] = 1f;
				arg_78_0[arg_78_1] = array2;
				float[][] arg_8F_0 = array;
				int arg_8F_1 = 2;
				array2 = new float[5];
				array2[2] = 1f;
				arg_8F_0[arg_8F_1] = array2;
				float[][] arg_A6_0 = array;
				int arg_A6_1 = 3;
				array2 = new float[5];
				array2[3] = 1f;
				arg_A6_0[arg_A6_1] = array2;
				array[4] = new float[]
				{
					0.2f,
					0.2f,
					0.2f,
					0f,
					1f
				};
				float[][] newColorMatrix = array;
				ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
				imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				e.Graphics.DrawImage(thumbnailImage, rect, rect.Left, rect.Top, rect.Width, rect.Height, GraphicsUnit.Pixel, imageAttributes);
				imageAttributes.Dispose();
			}
		}
		public void DrawDispImageDeformity(PaintEventArgs e, Rectangle rect)
		{
			if (base.Image != null)
			{
				e.Graphics.DrawImage(base.Image, rect);
				Pen pen = new Pen(Color.Black);
				Rectangle rect2 = new Rectangle(rect.X + 5, rect.Y + 11, rect.Width - 16, rect.Height - 13);
				float startAngle = 180f;
				float sweepAngle = 360f;
				e.Graphics.DrawArc(pen, rect2, startAngle, sweepAngle);
				Point pt = new Point(rect2.X + rect2.Width / 3, rect2.Y + rect2.Height / 3);
				Point pt2 = new Point(rect.X + rect.Width - 10, rect2.Y + rect2.Height / 3);
				pen = new Pen(Color.Brown, 3f);
				e.Graphics.DrawLine(pen, pt, pt2);
				pt2.X = rect.X + 8;
				pt2.Y = rect.Y + 5;
				e.Graphics.DrawLine(pen, pt, pt2);
				pt.X = rect.X + rect.Width - 10;
				pt.Y = rect2.Y + rect2.Height / 3;
				pt2.X = pt.X + 5;
				pt2.Y = pt.Y + 8;
				e.Graphics.DrawLine(pen, pt, pt2);
			}
		}
		private void DrawDispImageAttribDeformity(PaintEventArgs e, Rectangle rect)
		{
			if (base.Image != null)
			{
                Image thumbnailImage = base.Image.GetThumbnailImage(rect.Width, rect.Height, null, new IntPtr(0));
				ImageAttributes imageAttributes = new ImageAttributes();
				float[][] array = new float[5][];
				float[][] arg_61_0 = array;
				int arg_61_1 = 0;
				float[] array2 = new float[5];
				array2[0] = 2f;
				arg_61_0[arg_61_1] = array2;
				float[][] arg_78_0 = array;
				int arg_78_1 = 1;
				array2 = new float[5];
				array2[1] = 1f;
				arg_78_0[arg_78_1] = array2;
				float[][] arg_8F_0 = array;
				int arg_8F_1 = 2;
				array2 = new float[5];
				array2[2] = 1f;
				arg_8F_0[arg_8F_1] = array2;
				float[][] arg_A6_0 = array;
				int arg_A6_1 = 3;
				array2 = new float[5];
				array2[3] = 1f;
				arg_A6_0[arg_A6_1] = array2;
				array[4] = new float[]
				{
					0.2f,
					0.2f,
					0.2f,
					0f,
					1f
				};
				float[][] newColorMatrix = array;
				ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
				imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				e.Graphics.DrawImage(thumbnailImage, rect, rect.Left, rect.Top, rect.Width, rect.Height, GraphicsUnit.Pixel, imageAttributes);
				Pen pen = new Pen(Color.Black);
				Rectangle rect2 = new Rectangle(rect.X + 5, rect.Y + 11, rect.Width - 16, rect.Height - 13);
				float startAngle = 180f;
				float sweepAngle = 360f;
				e.Graphics.DrawArc(pen, rect2, startAngle, sweepAngle);
				Point pt = new Point(rect2.X + rect2.Width / 3, rect2.Y + rect2.Height / 3);
				Point pt2 = new Point(rect.X + rect.Width - 10, rect2.Y + rect2.Height / 3);
				pen = new Pen(Color.Brown, 3f);
				e.Graphics.DrawLine(pen, pt, pt2);
				pt2.X = rect.X + 8;
				pt2.Y = rect.Y + 5;
				e.Graphics.DrawLine(pen, pt, pt2);
				pt.X = rect.X + rect.Width - 10;
				pt.Y = rect2.Y + rect2.Height / 3;
				pt2.X = pt.X + 5;
				pt2.Y = pt.Y + 8;
				e.Graphics.DrawLine(pen, pt, pt2);
			}
		}
		private Image ImageSizeChange(Image image, Rectangle rect)
		{
            return image.GetThumbnailImage(rect.Width, rect.Height, null, new IntPtr(0));
		}
		private void BHSeatControl_MouseClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show("MouseClick");
		}
		private void BHSeatControl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show("MouseDoubleClick");
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
			base.ResumeLayout(false);
		}
	}
}

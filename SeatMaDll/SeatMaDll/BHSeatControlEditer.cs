using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class BHSeatControlEditer : Label
	{
		private IContainer components = null;
		private BHSeatControl.BHSeatType _seatType = BHSeatControl.BHSeatType.One;
		private BHSeatControl.BHSeatStatus _seatStatus = BHSeatControl.BHSeatStatus.Empty;
		private bool _cursorselectedIt = false;
		private bool _displayText = false;
		private bool _dispImageMode = false;
		private Image _extendImage = null;
		private int _GWidth = 30;
		private int _GHeight = 20;
		private int _Rotation = 0;
		private Color _BoxBorderColor = Color.White;
		public event EventHandler LeftAndRightKeyMove;
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
			base.Click += new EventHandler(this.BHSeatControlEditer_Click);
			base.ResumeLayout(false);
		}
		public BHSeatControlEditer()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.StandardClick, true);
			base.SetStyle(ControlStyles.StandardDoubleClick, true);
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Left)
			{
				if (this.LeftAndRightKeyMove != null)
				{
					this.LeftAndRightKeyMove(-1, null);
				}
			}
			else
			{
				if (keyData == Keys.Right)
				{
					if (this.LeftAndRightKeyMove != null)
					{
						this.LeftAndRightKeyMove(1, null);
					}
				}
				else
				{
					if (keyData == Keys.Up)
					{
						if (this.LeftAndRightKeyMove != null)
						{
							this.LeftAndRightKeyMove(-2, null);
						}
					}
					else
					{
						if (keyData == Keys.Down)
						{
							if (this.LeftAndRightKeyMove != null)
							{
								this.LeftAndRightKeyMove(2, null);
							}
						}
					}
				}
			}
			return true;
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
			if (this._seatStatus == BHSeatControl.BHSeatStatus.Empty)
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
			}
			if (this._cursorselectedIt)
			{
				this.DrawSelectBorder(e, base.ClientRectangle);
			}
		}
		private void DrawDispImage(PaintEventArgs e, Rectangle rect)
		{
			Seat seat = (Seat)base.Tag;
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
				e.Graphics.DrawImage(controlImg, rect);
			}
			if (this._displayText)
			{
				if (seat._seatFlag == "0" || seat._seatFlag == "1" || seat._seatFlag == "2" || seat._seatFlag == "5" || seat._seatFlag == "4")
				{
					if (this._seatStatus != BHSeatControl.BHSeatStatus.Success)
					{
						this.DrawDisplayText(e, base.ClientRectangle, this.Text, this._Rotation);
					}
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
				foreach (Seat current in seat._brotherList)
				{
					Image controlImg = EditSeatItem.GetControlImg(current._seatFlag);
					Rectangle rect2 = new Rectangle(rect.X + current._seatPosX - num, rect.Y + current._seatPosY - num2, current._seatWidth, current._seatHeight);
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
						e.Graphics.DrawImage(controlImg, rect2);
					}
					if (this._displayText)
					{
						if (seat._seatFlag == "0" || seat._seatFlag == "1" || seat._seatFlag == "2" || seat._seatFlag == "5" || seat._seatFlag == "4")
						{
							if (this._seatStatus != BHSeatControl.BHSeatStatus.Success)
							{
								this.DrawDisplayText(e, rect2, current._seatDisplay, this._Rotation);
							}
						}
					}
				}
				Pen pen2 = new Pen(this.BoxBorderColor, 6f);
				e.Graphics.DrawRectangle(pen2, rect);
				pen2.Dispose();
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
		private int GetMinLeftSize(List<Seat> list)
		{
			int result;
			if (list == null || list.Count <= 0)
			{
				result = 0;
			}
			else
			{
				int num = -1;
				foreach (Seat current in list)
				{
					int seatPosX = current._seatPosX;
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
		}
		private void DrawSelectBorderB(PaintEventArgs e, Rectangle rect)
		{
			Pen pen = new Pen(Color.Yellow, 8f);
			e.Graphics.DrawRectangle(pen, rect);
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
			}
		}
		private Bitmap RotateImage(Bitmap b, float angle)
		{
			Bitmap bitmap = new Bitmap(b.Width, b.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.TranslateTransform((float)b.Width / 2f, (float)b.Height / 2f);
			graphics.RotateTransform(angle);
			graphics.TranslateTransform(-(float)b.Width / 2f, -(float)b.Height / 2f);
			graphics.DrawImage(b, new Point(0, 0));
			return bitmap;
		}
		private Image ImageSizeChange(Image image, Rectangle rect)
		{
            return image.GetThumbnailImage(rect.Width, rect.Height, null, new IntPtr(0));
		}
		private void BHSeatControlEditer_Click(object sender, EventArgs e)
		{
		}
	}
}

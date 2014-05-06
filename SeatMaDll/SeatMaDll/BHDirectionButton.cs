using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class BHDirectionButton : Control
	{
		public enum DirectType : byte
		{
			Left,
			Right
		}
		private IContainer components = null;
		private BHDirectionButton.DirectType _directType = BHDirectionButton.DirectType.Left;
		private bool _bMinorMax = false;
		private Color _currentColor = Color.Blue;
		public BHDirectionButton.DirectType BHDirectType
		{
			get
			{
				return this._directType;
			}
			set
			{
				if (this._directType != value)
				{
					this._directType = value;
					base.Invalidate();
				}
			}
		}
		public bool IsMinOrMax
		{
			get
			{
				return this._bMinorMax;
			}
			set
			{
				if (this._bMinorMax != value)
				{
					this._bMinorMax = value;
					base.Invalidate();
				}
			}
		}
		public Color CurrentColor
		{
			get
			{
				return this._currentColor;
			}
			set
			{
				if (this._currentColor != value)
				{
					this._currentColor = value;
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
			this.components = new Container();
		}
		public BHDirectionButton()
		{
			this.InitializeComponent();
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
			this.FillDirectButton(e, rect);
		}
		public void FillDirectButton(PaintEventArgs e, Rectangle rect)
		{
			Color color = this._bMinorMax ? Color.Gray : this._currentColor;
			SolidBrush solidBrush = new SolidBrush(color);
			Point point;
			Point point2;
			Point point3;
			if (this._directType == BHDirectionButton.DirectType.Left)
			{
				point = new Point(rect.Left, (rect.Bottom - rect.Top) / 2);
				point2 = new Point(rect.Right, rect.Top);
				point3 = new Point(rect.Right, rect.Bottom);
			}
			else
			{
				point = new Point(rect.Left, rect.Top);
				point2 = new Point(rect.Right, (rect.Bottom - rect.Top) / 2);
				point3 = new Point(rect.Left, rect.Bottom);
			}
			Point[] points = new Point[]
			{
				point,
				point2,
				point3
			};
			FillMode fillmode = FillMode.Winding;
			e.Graphics.FillClosedCurve(solidBrush, points, fillmode);
			Pen pen = new Pen(Color.White, 2f);
			e.Graphics.DrawClosedCurve(pen, points);
			pen.Dispose();
			solidBrush.Dispose();
		}
	}
}

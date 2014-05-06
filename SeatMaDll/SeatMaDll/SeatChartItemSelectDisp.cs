using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class SeatChartItemSelectDisp
	{
		public ContainerControl _container;
		public Control _CurrentSelectControl = null;
		public Cursor _selectedCursor = Cursors.SizeAll;
		private Cursor _oldCursor;
		public bool _dragging = false;
		private int _startX;
		private int _startY;
		public bool _moveFlag = true;
		public List<Control> _listControlSelect = new List<Control>();
		public event SelectOneSeatEventHandler _DoubleClick;
		public event SelectOneSeatEventHandler _LeftOneClick;
		public event RMSelectOneSeatEventHandler _RightOneClick;
		public event SelectOneSeatEventHandler _OnMouseEnter;
		public event SelectOneSeatEventHandler _OnMouseLeave;
		public event SelectOneSeatEventHandler _OnCtrlOrShiftMouseClick;
		public SeatChartItemSelectDisp()
		{
		}
		public SeatChartItemSelectDisp(ContainerControl container)
		{
			this._container = container;
		}
		public void WireControl(Control ctl, SelectOneSeatEventHandler leftoneClick, RMSelectOneSeatEventHandler rightoneClick, SelectOneSeatEventHandler doubleClick, SelectOneSeatEventHandler onMouseEnter, SelectOneSeatEventHandler onMouseLeave, SelectOneSeatEventHandler onCtrlOrShiftMouseClick)
		{
			this._LeftOneClick = leftoneClick;
			this._RightOneClick = rightoneClick;
			this._DoubleClick = doubleClick;
			this._OnMouseEnter = onMouseEnter;
			this._OnMouseLeave = onMouseLeave;
			this._OnCtrlOrShiftMouseClick = onCtrlOrShiftMouseClick;
			ctl.MouseClick += new MouseEventHandler(this.ctl_MouseClick);
			ctl.DoubleClick += new EventHandler(this.ctl_DoubleClick);
			ctl.MouseEnter += new EventHandler(this.ctl_MouseEnter);
			ctl.MouseLeave += new EventHandler(this.ctl_MouseLeave);
		}
		private void ctl_MouseLeave(object sender, EventArgs e)
		{
			this._CurrentSelectControl = (Control)sender;
			if (!this.ExistControlInList(this._CurrentSelectControl))
			{
				((BHSeatControl)this._CurrentSelectControl).CursorSelectedIt = false;
			}
			if (this._OnMouseLeave != null)
			{
				SelectOneSeat_Events e2 = new SelectOneSeat_Events((BHSeatControl)sender);
				this._OnMouseLeave(this, e2);
			}
		}
		private void ctl_MouseEnter(object sender, EventArgs e)
		{
			this._CurrentSelectControl = (Control)sender;
			((BHSeatControl)this._CurrentSelectControl).CursorSelectedIt = true;
			if (this._OnMouseEnter != null)
			{
				SelectOneSeat_Events e2 = new SelectOneSeat_Events((BHSeatControl)sender);
				this._OnMouseEnter(this, e2);
			}
		}
		private void ctl_MouseClick(object sender, MouseEventArgs e)
		{
			this._CurrentSelectControl = (Control)sender;
			if (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)
			{
				if (e.Button == MouseButtons.Left)
				{
					if (!this.ExistControlInList(this._CurrentSelectControl))
					{
						this._listControlSelect.Add(this._CurrentSelectControl);
					}
					SelectOneSeat_Events e2 = new SelectOneSeat_Events((BHSeatControl)sender);
					if (this._OnCtrlOrShiftMouseClick != null)
					{
						this._OnCtrlOrShiftMouseClick(this, e2);
					}
				}
			}
			else
			{
				if (e.Button == MouseButtons.Left)
				{
					if (this._LeftOneClick != null)
					{
						SelectOneSeat_Events e2 = new SelectOneSeat_Events((BHSeatControl)sender);
						this._LeftOneClick(this, e2);
					}
				}
				else
				{
					if (e.Button == MouseButtons.Right)
					{
						if (this._RightOneClick != null)
						{
							RMSelectOneSeat_Events e3 = new RMSelectOneSeat_Events((BHSeatControl)sender, e.X, e.Y);
							this._RightOneClick(this, e3);
						}
					}
				}
			}
		}
		private void ctl_DoubleClick(object sender, EventArgs e)
		{
			this._CurrentSelectControl = (Control)sender;
			this._CurrentSelectControl = (Control)sender;
			if (!this.ExistControlInList(this._CurrentSelectControl))
			{
				if (this._listControlSelect.Count > 0)
				{
					foreach (Control current in this._listControlSelect)
					{
						current.Cursor = this._oldCursor;
						((BHSeatControl)current).CursorSelectedIt = false;
					}
					this._listControlSelect.Clear();
					this._listControlSelect.Add(this._CurrentSelectControl);
				}
				else
				{
					this._listControlSelect.Add(this._CurrentSelectControl);
				}
			}
			if (this._DoubleClick != null)
			{
				SelectOneSeat_Events e2 = new SelectOneSeat_Events((BHSeatControl)sender);
				this._DoubleClick(this, e2);
			}
		}
		private void MoveSelectControl_Mouse(Control c, int nLeftOld, int nTopOld, int nLeftNew, int nTopNew)
		{
			int num = c.Left + (nLeftNew - nLeftOld);
			int num2 = c.Top + (nTopNew - nTopOld);
			c.Left = num;
			c.Top = num2;
			Seat seat = (Seat)c.Tag;
			seat._seatPosX = num;
			seat._seatPosY = num2;
		}
		private void MoveSelectControl_Key(Control c, int nStep, int nFlag)
		{
			int num = c.Left;
			int num2 = c.Top;
			if (nFlag == -1)
			{
				num -= nStep;
			}
			if (nFlag == 1)
			{
				num += nStep;
			}
			if (nFlag == -2)
			{
				num2 -= nStep;
			}
			if (nFlag == 2)
			{
				num2 += nStep;
			}
			c.Left = num;
			c.Top = num2;
			Seat seat = (Seat)c.Tag;
			seat._seatPosX = c.Left;
			seat._seatPosY = c.Top;
		}
		public bool ExistControlInList(Control controlTemp)
		{
			bool result;
			if (this._listControlSelect.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Control current in this._listControlSelect)
				{
					if (current.Name == controlTemp.Name)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public void ResetControlList()
		{
			foreach (Control current in this._listControlSelect)
			{
				current.Cursor = this._oldCursor;
				((BHSeatControl)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._dragging = false;
			this._CurrentSelectControl = null;
		}
		public void ClearData()
		{
			this._listControlSelect.Clear();
			this._CurrentSelectControl = null;
		}
		public bool BuildSelectedControl(Control ctl)
		{
			this._CurrentSelectControl = ctl;
			bool result;
			if (this.ExistControlInList(this._CurrentSelectControl))
			{
				result = false;
			}
			else
			{
				((BHSeatControl)ctl).CursorSelectedIt = true;
				if (this._CurrentSelectControl.Cursor != this._selectedCursor)
				{
					this._oldCursor = this._CurrentSelectControl.Cursor;
					this._CurrentSelectControl.Cursor = this._selectedCursor;
				}
				this._listControlSelect.Add(this._CurrentSelectControl);
				result = true;
			}
			return result;
		}
		public void KeyMoveItems(int nMoveFlag, int nKeyMoveStep)
		{
			this._CurrentSelectControl = null;
			this._dragging = false;
			foreach (Control current in this._listControlSelect)
			{
				this.MoveSelectControl_Key(current, nKeyMoveStep, nMoveFlag);
			}
		}
		public void DeleteItems()
		{
			foreach (Control current in this._listControlSelect)
			{
				this._container.Controls.Remove(current);
			}
			this._listControlSelect.Clear();
		}
		public void SetSelectItemsType_All(BHSeatControl.BHSeatType bhSeatType)
		{
			foreach (Control current in this._listControlSelect)
			{
				((BHSeatControl)current).SeatType = bhSeatType;
				Seat seat = (Seat)current.Tag;
				seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
				current.Tag = seat;
				((BHSeatControl)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._CurrentSelectControl = null;
		}
		public bool SetSelectItemsType_One(BHSeatControl bh, BHSeatControl.BHSeatType bhSeatType)
		{
			bool result;
			if (this._listControlSelect.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Control current in this._listControlSelect)
				{
					if (bh.Name == current.Name)
					{
						((BHSeatControl)current).SeatType = bhSeatType;
						Seat seat = (Seat)current.Tag;
						seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
						current.Tag = seat;
						((BHSeatControl)current).Image = (((BHSeatControl)current).DispImageMode ? EditSeatItem.GetControlImg(seat._seatFlag) : null);
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public void SetSelectItemsStatus_All(BHSeatControl.BHSeatStatus bhSeatStatus)
		{
			foreach (Control current in this._listControlSelect)
			{
				((BHSeatControl)current).SeatStatus = bhSeatStatus;
				Seat seat = (Seat)current.Tag;
				seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
				current.Tag = seat;
				((BHSeatControl)current).ExtendImage = (((BHSeatControl)current).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
				((BHSeatControl)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._CurrentSelectControl = null;
		}
		public bool SetSelectItemsStatus_One(BHSeatControl bh, BHSeatControl.BHSeatStatus bhSeatStatus)
		{
			bool result;
			if (this._listControlSelect.Count <= 0)
			{
				result = false;
			}
			else
			{
				foreach (Control current in this._listControlSelect)
				{
					if (bh.Name == current.Name)
					{
						((BHSeatControl)current).SeatStatus = bhSeatStatus;
						Seat seat = (Seat)current.Tag;
						seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
						current.Tag = seat;
						((BHSeatControl)current).ExtendImage = (((BHSeatControl)current).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public void ExcludeItem(BHSeatControl bh)
		{
			foreach (Control current in this._listControlSelect)
			{
				if (bh.Name == current.Name)
				{
					this._listControlSelect.Remove(current);
					bh.CursorSelectedIt = false;
					return;
				}
			}
			bh.CursorSelectedIt = false;
		}
		public void IncludeItem(BHSeatControl bh)
		{
			if (!this.ExistControlInList(bh))
			{
				bh.CursorSelectedIt = true;
				this._listControlSelect.Add(bh);
			}
		}
	}
}

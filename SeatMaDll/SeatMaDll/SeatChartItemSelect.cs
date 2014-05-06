using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class SeatChartItemSelect
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
		public event EditerSelectOneSeatEventHandler _DoubleClick;
		public event EditerRMSelectOneSeatEventHandler _RightMouseClick;
		public SeatChartItemSelect()
		{
		}
		public SeatChartItemSelect(ContainerControl container)
		{
			this._container = container;
		}
		public void WireControl(Control ctl)
		{
			ctl.MouseDown += new MouseEventHandler(this.ctl_MouseDown);
			ctl.MouseMove += new MouseEventHandler(this.ctl_MouseMove);
			ctl.MouseUp += new MouseEventHandler(this.ctl_MouseUp);
			ctl.MouseDoubleClick += new MouseEventHandler(this.ctl_MouseDoubleClick);
		}
		private void bh_LeftAndRightKeyMove(object sender, EventArgs e)
		{
		}
		public void WireControl(Control ctl, EditerRMSelectOneSeatEventHandler rightMouseClick)
		{
			this._RightMouseClick = rightMouseClick;
			ctl.MouseDown += new MouseEventHandler(this.ctl_MouseDown);
			ctl.MouseMove += new MouseEventHandler(this.ctl_MouseMove);
			ctl.MouseUp += new MouseEventHandler(this.ctl_MouseUp);
			ctl.MouseDoubleClick += new MouseEventHandler(this.ctl_MouseDoubleClick);
		}
		private void ctl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._DoubleClick != null)
			{
				EditerSelectOneSeat_Events e2 = new EditerSelectOneSeat_Events((BHSeatControlEditer)sender);
				this._DoubleClick(this, e2);
			}
		}
		private void ctl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this._CurrentSelectControl = (Control)sender;
				((BHSeatControlEditer)this._CurrentSelectControl).CursorSelectedIt = true;
				if (this._CurrentSelectControl.Cursor != this._selectedCursor)
				{
					this._oldCursor = this._CurrentSelectControl.Cursor;
					this._CurrentSelectControl.Cursor = this._selectedCursor;
				}
				this._dragging = true;
				this._startX = e.X;
				this._startY = e.Y;
				if (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)
				{
					if (!this.ExistControlInList(this._CurrentSelectControl))
					{
						this._listControlSelect.Add(this._CurrentSelectControl);
					}
				}
				else
				{
					if (!this.ExistControlInList(this._CurrentSelectControl))
					{
						if (this._listControlSelect.Count > 0)
						{
							this.ResetControlList();
							this._listControlSelect.Add(this._CurrentSelectControl);
							this._dragging = true;
						}
						else
						{
							this._listControlSelect.Add(this._CurrentSelectControl);
						}
					}
				}
			}
			else
			{
				if (e.Button == MouseButtons.Right)
				{
					if (this._RightMouseClick != null)
					{
						EditerRMSelectOneSeat_Events e2 = new EditerRMSelectOneSeat_Events((BHSeatControlEditer)sender, e.X, e.Y);
						this._RightMouseClick(this, e2);
					}
				}
			}
		}
		private void ctl_MouseMove(object sender, MouseEventArgs e)
		{
			if (this._moveFlag)
			{
				if (this._CurrentSelectControl != null)
				{
					if (this._dragging)
					{
						int left = this._CurrentSelectControl.Left;
						int top = this._CurrentSelectControl.Top;
						int num = this._CurrentSelectControl.Left + e.X - this._startX;
						int num2 = this._CurrentSelectControl.Top + e.Y - this._startY;
						int width = this._CurrentSelectControl.Width;
						int height = this._CurrentSelectControl.Height;
						num = ((num < 0) ? 0 : ((num + width > this._CurrentSelectControl.Parent.ClientRectangle.Width) ? (this._CurrentSelectControl.Parent.ClientRectangle.Width - width) : num));
						num2 = ((num2 < 0) ? 0 : ((num2 + height > this._CurrentSelectControl.Parent.ClientRectangle.Height) ? (this._CurrentSelectControl.Parent.ClientRectangle.Height - height) : num2));
						this._CurrentSelectControl.Left = num;
						this._CurrentSelectControl.Top = num2;
						int left2 = this._CurrentSelectControl.Left;
						int top2 = this._CurrentSelectControl.Top;
						Seat seat = (Seat)this._CurrentSelectControl.Tag;
						seat._seatPosX = this._CurrentSelectControl.Location.X;
						seat._seatPosY = this._CurrentSelectControl.Location.Y;
						if (seat._brotherList.Count > 0)
						{
							foreach (Seat current in seat._brotherList)
							{
								current._seatPosX += left2 - left;
								current._seatPosY += top2 - top;
							}
						}
						foreach (Control current2 in this._listControlSelect)
						{
							if (this._CurrentSelectControl.Name != current2.Name)
							{
								this.MoveSelectControl_Mouse(current2, left, top, left2, top2);
							}
						}
					}
				}
			}
		}
		private void ctl_MouseUp(object sender, MouseEventArgs e)
		{
			this._dragging = false;
			this._CurrentSelectControl.Focus();
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
			if (seat._brotherList.Count > 0)
			{
				foreach (Seat current in seat._brotherList)
				{
					current._seatPosX += nLeftNew - nLeftOld;
					current._seatPosY += nTopNew - nTopOld;
				}
			}
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
			if (seat._brotherList.Count > 0)
			{
				foreach (Seat current in seat._brotherList)
				{
					if (nFlag == -1)
					{
						current._seatPosX -= nStep;
					}
					if (nFlag == 1)
					{
						current._seatPosX += nStep;
					}
					if (nFlag == -2)
					{
						current._seatPosY -= nStep;
					}
					if (nFlag == 2)
					{
						current._seatPosY += nStep;
					}
				}
			}
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
				((BHSeatControlEditer)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._dragging = false;
		}
		public void ClearData()
		{
			this._listControlSelect.Clear();
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
				((BHSeatControlEditer)ctl).CursorSelectedIt = true;
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
		public void DeleteItemsInSelectList()
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
				((BHSeatControlEditer)current).SeatType = bhSeatType;
				Seat seat = (Seat)current.Tag;
				seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
				current.Tag = seat;
				((BHSeatControlEditer)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._CurrentSelectControl = null;
		}
		public bool SetSelectItemsType_One(BHSeatControlEditer bh, BHSeatControl.BHSeatType bhSeatType)
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
						((BHSeatControlEditer)current).SeatType = bhSeatType;
						Seat seat = (Seat)current.Tag;
						seat._seatFlag = EditSeatItem.GetString_ByControlFlag(bhSeatType);
						current.Tag = seat;
						((BHSeatControlEditer)current).Image = (((BHSeatControlEditer)current).DispImageMode ? EditSeatItem.GetControlImg(seat._seatFlag) : null);
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
				((BHSeatControlEditer)current).SeatStatus = bhSeatStatus;
				Seat seat = (Seat)current.Tag;
				seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
				current.Tag = seat;
				((BHSeatControlEditer)current).ExtendImage = (((BHSeatControlEditer)current).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
				((BHSeatControlEditer)current).CursorSelectedIt = false;
			}
			this._listControlSelect.Clear();
			this._CurrentSelectControl = null;
		}
		public bool SetItemsStatusInSelectList_One(BHSeatControlEditer bh, BHSeatControl.BHSeatStatus bhSeatStatus)
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
						((BHSeatControlEditer)current).SeatStatus = bhSeatStatus;
						Seat seat = (Seat)current.Tag;
						seat._seatStatusFlag = EditSeatItem.GetControlStatus_ByFlag(bhSeatStatus);
						current.Tag = seat;
						((BHSeatControlEditer)current).ExtendImage = (((BHSeatControlEditer)current).DispImageMode ? EditSeatItem.GetControlExtendImg(seat._seatStatusFlag) : null);
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public void SplitMultiItems(EditSeatInfo editSiteInfoTemp, bool bDispImageMode)
		{
			if (this._listControlSelect.Count == 1)
			{
				BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)this._listControlSelect[0];
				Seat seat = (Seat)this._listControlSelect[0].Tag;
				if (seat._brotherList.Count > 0)
				{
					Seat seat2 = seat._brotherList[0];
					for (int i = 1; i < seat._brotherList.Count; i++)
					{
						Seat seat3 = seat._brotherList[i];
						BHSeatControlEditer bHSeatControlEditer2 = new BHSeatControlEditer();
						bHSeatControlEditer2.DisplayText = true;
						bHSeatControlEditer2.CursorSelectedIt = false;
						bHSeatControlEditer2.Name = "Site" + seat3._seatRowNumber + "_" + seat3._seatColumn;
						bHSeatControlEditer2.Text = seat3._seatColumn;
						Point location = new Point(seat3._seatPosX, seat3._seatPosY);
						bHSeatControlEditer2.Location = location;
						bHSeatControlEditer2.Width = seat3._seatWidth;
						bHSeatControlEditer2.Height = seat3._seatHeight;
						bHSeatControlEditer2.SeatType = BHSeatControl.BHSeatType.One;
						bHSeatControlEditer2.SeatStatus = BHSeatControl.BHSeatStatus.Empty;
						bHSeatControlEditer2.DispImageMode = bDispImageMode;
						bHSeatControlEditer2.Image = (bDispImageMode ? SeatResource.ImgEmpty : null);
						bHSeatControlEditer2.Rotation = editSiteInfoTemp._nRotation;
						string seatId = seat3._seatId;
						string seatColumn = seat3._seatColumn;
						string seatNumber = seat3._seatNumber;
						string seatDisplay = seat3._seatDisplay;
						bHSeatControlEditer2.Tag = new Seat(EditSeatItem.GetString_ByControlFlag(bHSeatControlEditer2.SeatType), EditSeatItem.GetControlStatus_ByFlag(bHSeatControlEditer2.SeatStatus), seat3._seatRowNumber, seat3._seatRowNumberDisplay, seatId, seatColumn, seatNumber, seatDisplay, 1, bHSeatControlEditer2.Location.X, bHSeatControlEditer2.Location.Y, bHSeatControlEditer2.Width, bHSeatControlEditer2.Height, seat3._seatSeatingChartId, seat3._seatBlockId);
						this._container.Controls.Add(bHSeatControlEditer2);
						this.WireControl(bHSeatControlEditer2);
					}
					bHSeatControlEditer.CursorSelectedIt = false;
					bHSeatControlEditer.SeatType = BHSeatControl.BHSeatType.One;
					bHSeatControlEditer.SeatStatus = BHSeatControl.BHSeatStatus.Empty;
					bHSeatControlEditer.Width = seat2._seatWidth;
					bHSeatControlEditer.Height = seat2._seatHeight;
					bHSeatControlEditer.Location = new Point(seat2._seatPosX, seat2._seatPosY);
					seat._seatFlag = EditSeatItem.GetString_ByControlFlag(BHSeatControl.BHSeatType.One);
					seat._seatColumnCount = 1;
					seat._seatWidth = bHSeatControlEditer.Width;
					seat._seatHeight = bHSeatControlEditer.Height;
					seat._seatPosX = seat2._seatPosX;
					seat._seatPosY = seat2._seatPosY;
					seat._brotherList.Clear();
					this._listControlSelect.Clear();
				}
			}
		}
		private List<SeatRows> DispathControls(List<Control> listSelect, EditSeatInfo editSiteInfoTemp, string szSeatType)
		{
			List<SeatRows> list = new List<SeatRows>();
			List<SeatRows> result;
			foreach (Control current in listSelect)
			{
				BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)current;
				Seat seat = (Seat)bHSeatControlEditer.Tag;
				seat._seatFlag = szSeatType;
				if (seat._brotherList.Count > 0)
				{
					result = null;
					return result;
				}
				bool flag = false;
				int seatRowsInlistPos = this.GetSeatRowsInlistPos(list, seat._seatRowNumber, editSiteInfoTemp, ref flag);
				SeatRows seatRows = flag ? list[seatRowsInlistPos] : new SeatRows(seat._seatRowNumber);
				if (seatRowsInlistPos == -1)
				{
					list.Add(seatRows);
				}
				else
				{
					if (!flag)
					{
						list.Insert(seatRowsInlistPos, seatRows);
					}
				}
				int seatInlistPos = this.GetSeatInlistPos(seatRows._listSiteItem, seat);
				if (seatInlistPos < 0)
				{
					seatRows._listSiteItem.Add(seat);
				}
				else
				{
					seatRows._listSiteItem.Insert(seatInlistPos, seat);
				}
			}
			result = list;
			return result;
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
		private int GetSeatRowsInlistPos(List<SeatRows> list, string seatRowNumber, EditSeatInfo editSiteInfoTemp, ref bool bExit)
		{
			int num = -1;
			int result;
			foreach (SeatRows current in list)
			{
				num++;
				int num2 = -1;
				if (editSiteInfoTemp._szRowNumType == "int")
				{
					num2 = Convert.ToInt32(seatRowNumber) - Convert.ToInt32(current._seatRowNumber);
				}
				else
				{
					seatRowNumber.CompareTo(current._seatRowNumber);
				}
				if (num2 == 0)
				{
					bExit = true;
					result = num;
					return result;
				}
				if (num2 < 0)
				{
					bExit = false;
					result = num;
					return result;
				}
			}
			bExit = false;
			result = -1;
			return result;
		}
		private bool CompareTwoSeatRows(string seatRowNumber1, string seatRowNumber2)
		{
			int num = seatRowNumber1.CompareTo(seatRowNumber2);
			return num > 0;
		}
		private int GetSeatInlistPos(List<Seat> list, Seat stP)
		{
			int result;
			if (list.Count <= 0)
			{
				result = -1;
			}
			else
			{
				int num = -1;
				foreach (Seat current in list)
				{
					num++;
					if (Convert.ToInt32(stP._seatColumn) < Convert.ToInt32(current._seatColumn))
					{
						result = num;
						return result;
					}
				}
				result = -1;
			}
			return result;
		}
		private SeatRows FindSeatRows(List<SeatRows> listSR, string seatRowNumber)
		{
			SeatRows result;
			if (listSR == null || listSR.Count <= 0)
			{
				result = null;
			}
			else
			{
				foreach (SeatRows current in listSR)
				{
					if (seatRowNumber == current._seatRowNumber)
					{
						result = current;
						return result;
					}
				}
				result = null;
			}
			return result;
		}
		private bool CompareItemInList(SeatRows sr, Seat st)
		{
			bool result;
			if (sr._listSiteItem == null || sr._listSiteItem.Count <= 1)
			{
				result = true;
			}
			else
			{
				foreach (Seat current in sr._listSiteItem)
				{
					if (current._seatRowNumber == st._seatRowNumber && current._seatColumn == st._seatColumn)
					{
						result = true;
						return result;
					}
				}
				int num = Convert.ToInt32(st._seatColumn);
				int num2 = Convert.ToInt32(sr._listSiteItem[0]._seatColumn);
				int num3 = Convert.ToInt32(sr._listSiteItem[sr._listSiteItem.Count - 1]._seatColumn);
				result = (num <= num2 || num3 <= num);
			}
			return result;
		}
		private bool ExistInSelectItems_Row(List<SeatRows> listSR)
		{
			bool result;
			foreach (Control control in this._container.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					SeatRows seatRows = this.FindSeatRows(listSR, seat._seatRowNumber);
					if (seatRows != null)
					{
						if (seatRows._listSiteItem != null && seatRows._listSiteItem.Count > 1)
						{
							if (!this.CompareItemInList(seatRows, seat))
							{
								result = false;
								return result;
							}
						}
					}
				}
			}
			result = true;
			return result;
		}
		private bool TwoRowHaveNoSelectRow(string seatRowNumber1, string seatRowNumber2, EditSeatInfo editSiteInfoTemp)
		{
			bool result;
			foreach (Control control in this._container.Controls)
			{
				if (control.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)control;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					int num = -1;
					if (editSiteInfoTemp._szRowNumType == "int")
					{
						num = Convert.ToInt32(seatRowNumber1) - Convert.ToInt32(seat._seatRowNumber);
					}
					else
					{
						seatRowNumber1.CompareTo(seat._seatRowNumber);
					}
					if (num < 0)
					{
						if (editSiteInfoTemp._szRowNumType == "int")
						{
							num = Convert.ToInt32(seatRowNumber2) - Convert.ToInt32(seat._seatRowNumber);
						}
						else
						{
							num = seatRowNumber2.CompareTo(seat._seatRowNumber);
						}
						if (num > 0)
						{
							result = true;
							return result;
						}
					}
				}
			}
			result = false;
			return result;
		}
		private bool CompareTwoRow(SeatRows sr1, SeatRows sr2)
		{
			bool result;
			if (sr1._listSiteItem.Count <= 0)
			{
				result = true;
			}
			else
			{
				if (sr2._listSiteItem.Count <= 0)
				{
					result = true;
				}
				else
				{
					foreach (Seat current in sr1._listSiteItem)
					{
						foreach (Seat current2 in sr2._listSiteItem)
						{
							if (current._seatColumn == current2._seatColumn)
							{
								result = true;
								return result;
							}
						}
					}
					result = false;
				}
			}
			return result;
		}
		private bool ExistInSelectItems_Column(List<SeatRows> listSR, EditSeatInfo editSiteInfoTemp)
		{
			bool result;
			if (listSR == null || listSR.Count < 2)
			{
				result = true;
			}
			else
			{
				SeatRows seatRows = listSR[0];
				for (int i = 1; i < listSR.Count; i++)
				{
					SeatRows seatRows2 = listSR[i];
					if (this.TwoRowHaveNoSelectRow(seatRows._seatRowNumber, seatRows2._seatRowNumber, editSiteInfoTemp))
					{
						result = false;
						return result;
					}
					if (!this.CompareTwoRow(seatRows2, seatRows))
					{
						result = false;
						return result;
					}
					seatRows = seatRows2;
				}
				result = true;
			}
			return result;
		}
		private int GetColumnsSize(List<SeatRows> listSR)
		{
			int result;
			if (listSR == null || listSR.Count <= 0)
			{
				result = 0;
			}
			else
			{
				int num = -1;
				int num2 = -1;
				foreach (SeatRows current in listSR)
				{
					int num3 = Convert.ToInt32(current._listSiteItem[0]._seatColumn);
					int num4 = Convert.ToInt32(current._listSiteItem[current._listSiteItem.Count - 1]._seatColumn);
					if (num == -1)
					{
						num = num3;
					}
					if (num2 == -1)
					{
						num = num4;
					}
					if (num3 < num)
					{
						num = num3;
					}
					if (num4 > num2)
					{
						num2 = num4;
					}
				}
				result = num2 - num + 1;
			}
			return result;
		}
		private Control FindControlInSeatRows(Seat st)
		{
			Control result;
			foreach (Control current in this._listControlSelect)
			{
				if (current.GetType() == typeof(BHSeatControlEditer))
				{
					BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)current;
					Seat seat = (Seat)bHSeatControlEditer.Tag;
					if (st._seatColumn == seat._seatColumn && st._seatRowNumber == seat._seatRowNumber)
					{
						result = current;
						return result;
					}
				}
			}
			result = null;
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
		private bool GetFourMarginControl(List<Control> listSelect, ref BHSeatControlEditer bhLeft, ref BHSeatControlEditer bhTop, ref BHSeatControlEditer bhRight, ref BHSeatControlEditer bhBottom)
		{
			bool result;
			if (listSelect == null || listSelect.Count < 2)
			{
				result = false;
			}
			else
			{
				bhLeft = (BHSeatControlEditer)listSelect[0];
				bhTop = (BHSeatControlEditer)listSelect[0];
				bhRight = (BHSeatControlEditer)listSelect[0];
				bhBottom = (BHSeatControlEditer)listSelect[0];
				foreach (Control current in listSelect)
				{
					if (current.GetType() == typeof(BHSeatControlEditer))
					{
						BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)current;
						Seat seat = (Seat)bHSeatControlEditer.Tag;
						if (seat._brotherList.Count > 0)
						{
							result = false;
							return result;
						}
						if (seat._seatFlag != "0")
						{
							result = false;
							return result;
						}
						if (bHSeatControlEditer.Location.X < bhLeft.Location.X)
						{
							bhLeft = bHSeatControlEditer;
						}
						if (bHSeatControlEditer.Location.Y < bhTop.Location.Y)
						{
							bhTop = bHSeatControlEditer;
						}
						if (bHSeatControlEditer.Location.X > bhRight.Location.X)
						{
							bhRight = bHSeatControlEditer;
						}
						if (bHSeatControlEditer.Location.Y > bhBottom.Location.Y)
						{
							bhBottom = bHSeatControlEditer;
						}
					}
				}
				result = true;
			}
			return result;
		}
		public void MergeMultiItems(EditSeatInfo editSiteInfoTemp, bool bDispImageMode, Color boxBorderColor)
		{
			if (this._listControlSelect.Count >= 2)
			{
				string text = "2";
				if (this._listControlSelect.Count == 2)
				{
					Seat seat = (Seat)((BHSeatControlEditer)this._listControlSelect[0]).Tag;
					Seat seat2 = (Seat)((BHSeatControlEditer)this._listControlSelect[1]).Tag;
					if (seat._seatRowNumber == seat2._seatRowNumber)
					{
						text = "1";
					}
				}
				BHSeatControlEditer bHSeatControlEditer = (BHSeatControlEditer)this._listControlSelect[0];
				BHSeatControlEditer bHSeatControlEditer2 = (BHSeatControlEditer)this._listControlSelect[0];
				BHSeatControlEditer bHSeatControlEditer3 = (BHSeatControlEditer)this._listControlSelect[0];
				BHSeatControlEditer bHSeatControlEditer4 = (BHSeatControlEditer)this._listControlSelect[0];
				if (this.GetFourMarginControl(this._listControlSelect, ref bHSeatControlEditer, ref bHSeatControlEditer2, ref bHSeatControlEditer3, ref bHSeatControlEditer4))
				{
					List<SeatRows> list = this.DispathControls(this._listControlSelect, editSiteInfoTemp, text);
					if (list != null)
					{
						int columnsSize = this.GetColumnsSize(list);
						int count = list.Count;
						Seat seat3 = list[0]._listSiteItem[0];
						int minLeftSize = this.GetMinLeftSize(list);
						BHSeatControlEditer bHSeatControlEditer5 = (BHSeatControlEditer)this.FindControlInSeatRows(seat3);
						BHSeatControlEditer bHSeatControlEditer6 = new BHSeatControlEditer();
						bHSeatControlEditer6.DisplayText = true;
						bHSeatControlEditer6.CursorSelectedIt = false;
						bHSeatControlEditer6.Name = bHSeatControlEditer5.Name;
						bHSeatControlEditer6.Text = bHSeatControlEditer5.Text;
						bHSeatControlEditer6.Location = new Point(bHSeatControlEditer.Location.X, bHSeatControlEditer2.Location.Y);
						bHSeatControlEditer6.Width = bHSeatControlEditer3.Width + bHSeatControlEditer3.Location.X - bHSeatControlEditer.Location.X;
						bHSeatControlEditer6.Height = bHSeatControlEditer4.Height + bHSeatControlEditer4.Location.Y - bHSeatControlEditer2.Location.Y;
						bHSeatControlEditer6.SeatType = EditSeatItem.GetControl_ByFlag(text);
						bHSeatControlEditer6.SeatStatus = BHSeatControl.BHSeatStatus.Empty;
						bHSeatControlEditer6.DispImageMode = bDispImageMode;
						bHSeatControlEditer6.Image = (bDispImageMode ? SeatResource.ImgEmpty : null);
						bHSeatControlEditer6.Rotation = editSiteInfoTemp._nRotation;
						bHSeatControlEditer6.BoxBorderColor = boxBorderColor;
						string seatRowNumber = seat3._seatRowNumber;
						string seatColumn = seat3._seatColumn;
						string text2 = (Convert.ToInt32(seatColumn) + 1).ToString();
						string seatColumn2 = seatColumn;
						string seatNumber = seatRowNumber + "排" + seatColumn + "号";
						string seatId = seat3._seatId;
						string seatDisplay = seat3._seatDisplay;
						string seatRowNumberDisplay = seat3._seatRowNumberDisplay;
						Seat seat4 = new Seat(EditSeatItem.GetString_ByControlFlag(bHSeatControlEditer6.SeatType), EditSeatItem.GetControlStatus_ByFlag(bHSeatControlEditer6.SeatStatus), seatRowNumber, seatRowNumberDisplay, seatId, seatColumn2, seatNumber, seatDisplay, 2, bHSeatControlEditer6.Location.X, bHSeatControlEditer6.Location.Y, bHSeatControlEditer6.Width, bHSeatControlEditer6.Height, seat3._seatSeatingChartId, seat3._seatBlockId);
						bHSeatControlEditer6.Tag = seat4;
						seat4._brotherList.Clear();
						foreach (SeatRows current in list)
						{
							foreach (Seat current2 in current._listSiteItem)
							{
								seat4._brotherList.Add(current2);
							}
						}
						this._container.Controls.Add(bHSeatControlEditer6);
						this.WireControl(bHSeatControlEditer6);
						foreach (Control current3 in this._listControlSelect)
						{
							this._container.Controls.Remove(current3);
						}
						this._listControlSelect.Clear();
					}
				}
			}
		}
	}
}

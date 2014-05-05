using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class UC_LabelVPanel : UserControl
    {
        private static readonly object _ImageButtonItemClick = new object();
        public UC_LabelVPanel()
        {
            InitializeComponent();
        }
        public event EventHandler ImageButtonItemClick
        {
            add { Events.AddHandler(_ImageButtonItemClick, value); }
            remove { Events.RemoveHandler(_ImageButtonItemClick, value); }
        }
        protected virtual void On_ImageButtonItemClick(Object sender, EventArgs e)
        {
            EventHandler onImageButtonItemClick = (EventHandler)Events[_ImageButtonItemClick];
            if (onImageButtonItemClick != null) onImageButtonItemClick(sender, e);
        }

        public void Clear()
        {
            this.Controls.Clear();
        }
        public void ClearAlluibControlSelected()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(Label))
                {
                    Label uib = (Label)ctl;
                    uib.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        public void CreateControl(List<ImageButtonItem> list)
        {
            if(list == null || list.Count <= 0) return;
            int nWidth = 70;
            int nHeight = 30;
            int _RowSpace = 5;
            int nUnitPage = _RowSpace + nHeight;
            int nCount = 0;

            foreach(ImageButtonItem ibi in list)
            {
                Image img = ibi._Img;
                string szDisplayText = ibi._DisplayText;
                Label ibv = new Label();
                //ibv.AutoSize = true;
                ibv.Text = ibi._DisplayText;
                ibv.BackColor = ibi._BackColor == 0 ? Color.Transparent : Color.FromArgb(ibi._BackColor & 0x0000ff, (ibi._BackColor & 0x00ff00) >> 8, (ibi._BackColor & 0xff0000) >> 16);
                ibv.Location = new Point(2, (nCount + 1) * nUnitPage - nHeight);
                ibv.Width = nWidth;
                ibv.Height = nHeight;
                ibv.Tag = ibi._objFlag;
                ibv.Click += new EventHandler(On_ImageButtonItemClick);
                this.Controls.Add(ibv);

                nCount++;
            }
        }
    }
}

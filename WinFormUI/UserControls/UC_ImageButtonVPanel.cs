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
    public partial class UC_ImageButtonVPanel : UserControl
    {
        private static readonly object _ImageButtonItemClick = new object();
        public UC_ImageButtonVPanel()
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
                if (ctl.GetType() == typeof(UC_ImageButtonV))
                {
                    UC_ImageButtonV uib = (UC_ImageButtonV)ctl;
                    uib.Selected = false;
                }
            }
        }
        public void CreateControl(List<ImageButtonItem> list)
        {
            if(list == null || list.Count <= 0) return;
            int nWidth = 80;
            int nHeight = 70;
            int _RowSpace = 5;
            int nUnitPage = _RowSpace + nHeight;
            int nCount = 0;

            foreach(ImageButtonItem ibi in list)
            {
                Image img = ibi._Img;
                string szDisplayText = ibi._DisplayText;
                UC_ImageButtonV ibv = new UC_ImageButtonV(img, szDisplayText);
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

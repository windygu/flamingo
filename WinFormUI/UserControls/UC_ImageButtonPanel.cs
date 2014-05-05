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
    public partial class UC_ImageButtonPanel : UserControl
    {
        private static readonly object _ImageButtonItemClick = new object();
        public UC_ImageButtonPanel()
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
                if (ctl.GetType() == typeof(UC_ImageButton))
                {
                    UC_ImageButton uib = (UC_ImageButton)ctl;
                    uib.Selected = false;
                }
            }
        }
        public void CreateControl(List<ImageButtonItem> list)
        {
            if(list == null || list.Count <= 0) return;
            int nWidth = 100;
            int nHeight = 30;
            int _RowSpace = 5;
            int nUnitPage = _RowSpace + nWidth;
            int nCount = 0;

            foreach(ImageButtonItem ibi in list)
            {
                Image img = ibi._Img;
                string szDisplayText = ibi._DisplayText;
                UC_ImageButton ibv = new UC_ImageButton(img, szDisplayText);
                ibv.Location = new Point((nCount + 1) * nUnitPage - nWidth, 2);
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

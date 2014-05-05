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
    public partial class UC_ImageButtonV : UserControl
    {
        private Image _imageFlag = null;
        private string _displayText = "";
        private bool _bSelected = false;

        //public event MouseEventHandler _LeftOneClick;

        public UC_ImageButtonV()
        {
            InitializeComponent();
        }
        public UC_ImageButtonV(Image imageFlag, string displayText)
        {
            InitializeComponent();
            _imageFlag = imageFlag;
            _displayText = displayText;
            pb_imageFlag.BackgroundImage = _imageFlag;
            lb_displayText.Text = _displayText;
        }
        [Category("图标标识"), Description("Specifies the ImageIcon.")]
        public Image ImageFlag
        {
            get
            {
                return _imageFlag;
            }
            set
            {
                if (_imageFlag != value)
                {
                    _imageFlag = value;
                    SetImage();
                    //this.Invalidate();
                }
            }
        }
        [Category("图标标识"), Description("Specifies the ImageIcon.")]
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    SetdisplayText();
                    //this.Invalidate();
                }
            }
        }
        
        [Category("图标标识"), Description("Specifies the Selected.")]
        public bool Selected
        {
            get
            {
                return _bSelected;
            }
            set
            {
                if (_bSelected != value)
                { 
                    _bSelected = value;
                    if (_bSelected)
                        this.tableLayoutPanel_R.BackColor = System.Drawing.SystemColors.Control;//Color.Yellow;
                    //.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
                    else
                        this.tableLayoutPanel_R.BackColor = System.Drawing.SystemColors.ControlDark;
                        //this.tableLayoutPanel_R.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                    //this.Invalidate();
                    //tableLayoutPanel_R.bo
                }
            }
        }
        private void SetImage()
        {
            pb_imageFlag.BackgroundImage = _imageFlag;
        }
        private void SetdisplayText()
        {
            lb_displayText.Text = _displayText;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = DeflateRect(base.ClientRectangle, base.Padding);
            if (_bSelected)
            {
                DrawSelectBorder(e, rect);
            }
            else
            {
                base.OnPaint(e);
            }
        }
        private Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }
        private void DrawSelectBorder(PaintEventArgs e, Rectangle rect)
        {
            Pen pen = new Pen(Color.Red, 4);
            e.Graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void pb_imageFlag_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            
        }

        private void lb_displayText_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void tableLayoutPanel_R_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.ShowPlanManage
{
    /// <summary>
    /// 具备双缓冲的Label控件
    /// </summary>
    public partial class DoubleBufferedLabel : Label
    {
        public DoubleBufferedLabel()
        {
            InitializeComponent();

            // 启用双缓冲
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// 控件文本改变时，立刻重汇，提高性能
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            Refresh();

            base.OnTextChanged(e);
        }

        /// <summary>
        /// 控件文本改变时，立刻重汇，提高性能
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLocationChanged(EventArgs e)
        {
            Refresh();

            base.OnLocationChanged(e);
        }
    }
}

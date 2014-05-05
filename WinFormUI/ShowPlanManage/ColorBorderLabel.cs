using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    public partial class ColorBorderLabel : Label
    {
        /// <summary>
        /// 1个刻度代表的分钟数
        /// </summary>
        private int minutesPerScale;

        /// <summary>
        /// 1个刻度的长度像素数
        /// </summary>
        private int pixelsOfScale;

        /// <summary>
        /// 默认边框颜色
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// 顶部时间标签
        /// </summary>
        private DoubleBufferedLabel timeLabel;

        /// <summary>
        /// 当用户微调场次方块时发生，用于检测是否越界
        /// </summary>
        public event EventHandler UserChangeOffset;

        /// <summary>
        /// 当用户微调场次方块之前发生，用于检测是否越界
        /// </summary>
        public event EventHandler PreviewUserChangeOffset;

        private DailyShowPlanManage dataManager;

        public ColorBorderLabel(DailyShowPlanManage datemaneger)
        {
            InitializeComponent();

            this.dataManager = datemaneger;
            // 设置双缓冲
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);

            this.minutesPerScale = 5;
            this.pixelsOfScale = 5;

            this.Click += new EventHandler(ColorBorderLabel_Click);
            this.ParentChanged += new EventHandler(ColorBorderLabel_ParentChanged);
        }

        void ColorBorderLabel_SizeChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 控件文本改变时，立刻重绘，提高性能，并且调整文字内容，使其不超过控件宽度
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            ReSetText();

            Refresh();

            base.OnTextChanged(e);
        }

        /// <summary>
        /// 控件大小改变时，调整文字内容，使其不超过控件宽度
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ReSetText();
        }

        private void ReSetText()
        {
            int num = this.Width / 12;

            if (this.Text.Length > num)
                this.Text = this.Text.Substring(0, num);
        }

        /// <summary>
        /// 用于场次方块加入时间轴后，时间标签也跟着加入时间轴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBorderLabel_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null && timeLabel != null)
            {
                this.Parent.Controls.Add(timeLabel);
                timeLabel.Location = new Point(this.Location.X + (this.Width - 60), this.Location.Y - 12);
            }
        }

        ///// <summary>
        ///// 析构函数，用于释放当前场次方块时，同时清理时间标签
        ///// </summary>
        //~ColorBorderLabel()
        //{
        //    timeLabel.Parent = null;
        //    timeLabel = null;
        //}

        /// <summary>
        /// 是否启用顶部时间标签
        /// </summary>
        public bool IsEnableTimeLabel
        {
            get
            {
                return this.timeLabel.Visible;
            }
            set
            {
                // 如果启用，则同时同步时间标签上的标签
                if (value == true)
                {
                    InitTimeLabel();

                    this.timeLabel.Visible = value;

                    SynchronizeTimeLabel();
                }
                else
                {
                    this.timeLabel.Visible = value;
                    this.timeLabel.Dispose();
                }
            }
        }

        /// <summary>
        /// 初始化时间标签
        /// </summary>
        private void InitTimeLabel()
        {
            if (timeLabel == null)
            {
                timeLabel = new DoubleBufferedLabel();

                this.Parent.Controls.Add(timeLabel);

                timeLabel.Width = 60;
                timeLabel.Height = 12;
                timeLabel.ForeColor = Color.Black;
                timeLabel.BackColor = Color.White;
                timeLabel.Font = new Font("宋体", 7f, FontStyle.Regular);
                timeLabel.TextAlign = ContentAlignment.BottomRight;
                timeLabel.Location = new Point(this.Location.X + (this.Width - 60), this.Location.Y - 12);
                timeLabel.Visible = false;
            }
        }

        /// <summary>
        /// 同步时间标签上的时间及位置，根据场次方块上的开始时间
        /// </summary>
        public void SynchronizeTimeLabel()
        {
            if (this.Tag != null && this.Tag.GetType() == typeof(ShowPlan))
            {
                ShowPlan showPlan = this.Tag as ShowPlan;

                try
                {
                    SynchronizeTimeLabel(showPlan.StartTime.Value, showPlan.FilmLength.Value);
                }
                catch
                {
                    timeLabel.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 同步时间标签上的时间及位置，根据指定的开始时间和影片时长
        /// </summary>
        public void SynchronizeTimeLabel(DateTime startTime, int filmLength)
        {
            timeLabel.Text = startTime.ToString("HH:mm") + "-" + startTime.AddMinutes(filmLength).ToString("HH:mm");

            timeLabel.Location = new Point(this.Location.X + (this.Width - 60), this.Location.Y - 12);
            timeLabel.BringToFront();
        }

        /// <summary>
        /// 场次方块移动时，时间标签跟着动，且重绘自己，提高性能
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLocationChanged(EventArgs e)
        {
            if (timeLabel != null && timeLabel.Visible == true)
            {
                SynchronizeTimeLabel();
            }

            Refresh();

            base.OnLocationChanged(e);
        }

        /// <summary>
        /// 点击后，获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBorderLabel_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// 处理键盘操作（左右微调）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                //左键
                this.dataManager.PreviewKey=0;

                if (PreviewUserChangeOffset != null)
                    PreviewUserChangeOffset(this, EventArgs.Empty);

                //ShowPlan showPlan = this.Tag as ShowPlan;

                //if (showPlan != null)
                //{
                //    showPlan.StartTime = showPlan.StartTime.Value.AddMinutes(-(pixelsOfScale / minutesPerScale));
                //}
                this.Location = new Point(this.Location.X - pixelsOfScale / minutesPerScale, this.Location.Y);
                if (UserChangeOffset != null)
                    UserChangeOffset(this, EventArgs.Empty);
            }
            else if (keyData == Keys.Right)
            {
                //右键
                this.dataManager.PreviewKey = 1;

                if (PreviewUserChangeOffset != null)
                    PreviewUserChangeOffset(this, EventArgs.Empty);

                //ShowPlan showPlan = this.Tag as ShowPlan;

                //if (showPlan != null)
                //{
                //    showPlan.StartTime = showPlan.StartTime.Value.AddMinutes(pixelsOfScale / minutesPerScale);
                //}

                this.Location = new Point(this.Location.X + pixelsOfScale / minutesPerScale, this.Location.Y);

                if (UserChangeOffset != null)
                    UserChangeOffset(this, EventArgs.Empty);
            }

            // 屏蔽底层操作，防止焦点丢失
            //return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }

        /// <summary>
        /// 获取或设置控件的边框颜色
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }

        /// <summary>
        /// 绘图事件
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // 绘制边框
            Rectangle rectangle1 = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle rectangle2 = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            ControlPaint.DrawBorder(pe.Graphics, rectangle1, borderColor, ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(pe.Graphics, rectangle2, borderColor, ButtonBorderStyle.Solid);
        }
    }
}

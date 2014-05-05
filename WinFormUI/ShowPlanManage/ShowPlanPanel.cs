using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using WinFormUI;

namespace Flamingo.ShowPlanManage
{
    public partial class ShowPlanPanel : Panel
    {
        #region 窗体变量

        /// <summary>
        /// 放映计划管理对象
        /// </summary>
        private DailyShowPlanManage dataManager;

        /// <summary>
        /// 放映计划是否已保存
        /// </summary>
        private bool isSave;

        /// <summary>
        /// 计划保存状态改变后引发事件
        /// </summary>
        public event EventHandler SaveStateChanged;

        /// <summary>
        /// 是否正在刷新放映计划
        /// </summary>
        private bool isRefreshingShowPlan;

        /// <summary>
        /// 数据源
        /// </summary>
        private DailyShowPlans dataSource;

        /// <summary>
        /// 当前焦点影片
        /// </summary>
        private ColorBorderLabel currentPanel;

        /// <summary>
        /// 当前点击影片的X坐标偏移值(屏幕坐标)
        /// </summary>
        private int xOffset;

        /// <summary>
        /// 当前点击影片的Y坐标偏移值(屏幕坐标)
        /// </summary>
        private int yOffset;

        /// <summary>
        /// 起点位置
        /// </summary>
        private Point startPosition;

        /// <summary>
        /// 电影方块高度
        /// </summary>
        private int panelHeight;

        /// <summary>
        /// 影厅之间的间距
        /// </summary>
        private int hallDistance;

        /// <summary>
        /// 时间线的右边距
        /// </summary>
        private int rightMargin;

        /// <summary>
        /// 1个刻度代表的分钟数
        /// </summary>
        private int minutesPerScale;

        /// <summary>
        /// 1个刻度的长度像素数
        /// </summary>
        private int pixelsOfScale;

        /// <summary>
        /// 小时刻度短线长度像素数
        /// </summary>
        private int shortHeightOfHour;

        /// <summary>
        /// 小时刻度长线长度像素数
        /// </summary>
        private int longHeightOfHour;

        /// <summary>
        /// 分钟刻度短线长度像素数
        /// </summary>
        private int shortHeightOfMinute;

        /// <summary>
        /// 分钟刻度长线长度像素数
        /// </summary>
        private int longHeightOfMinute;

        /// <summary>
        /// 时间线阴影高度像素数
        /// </summary>
        private int heightOfTimeLineShadow;

        /// <summary>
        /// 小时线颜色
        /// </summary>
        private Color colorOfHourLine;

        /// <summary>
        /// 分钟线颜色
        /// </summary>
        private Color colorOfMinuteLine;

        /// <summary>
        /// 时间线颜色
        /// </summary>
        private Color colorOfTimeLine;

        /// <summary>
        /// 时间线阴影颜色
        /// </summary>
        private Color colorOfTimeLineShadow;

        /// <summary>
        /// 时间刻度值文本颜色
        /// </summary>
        private Color colorOfTimeText;

        /// <summary>
        /// 时间刻度值文本字体
        /// </summary>
        private Font fontOfTimeText;

        /// <summary>
        /// 影厅文本颜色
        /// </summary>
        private Color colorOfHallText;

        /// <summary>
        /// 影厅文本字体
        /// </summary>
        private Font fontOfHallText;

        /// <summary>
        /// 影厅文本长度像素值
        /// </summary>
        private int lengthOfHallText;

        /// <summary>
        /// 电影文本字体
        /// </summary>
        private Font fontOfFilmLabel;

        /// <summary>
        /// 绘制出的放映计划图
        /// </summary>
        private Bitmap showPlanImage;

        /// <summary>
        /// 鼠标是否被按下
        /// </summary>
        private bool isMouseDown;

        /// <summary>
        /// 影片拖动之前的位置
        /// </summary>
        private Point lastLocation;

        /// <summary>
        /// 场次状态颜色对应表
        /// </summary>
        private Color[] showStatusColors;

        /// <summary>
        /// 总页数
        /// </summary>
        private int totalPage;

        /// <summary>
        /// 当前页号
        /// </summary>
        private int currentPage;

        /// <summary>
        /// 每页显示多少厅
        /// </summary>
        private int hallsPerPage;

        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        public DailyShowPlans DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (value != null)
                {
                    try
                    {
                        //this.currentPanel = null;
                        this.dataSource = value;

                        DrawShowPlanImage();

                        RefreshShowPlan(true);



                        SetPage(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 强制显示所有影片方块的放映时间
        /// </summary>
        public void ShowFilmLabelTime()
        {
            foreach (Control con in this.Controls)
            {
                ColorBorderLabel lbl = con as ColorBorderLabel;
                if (lbl != null)
                {
                    lbl.IsEnableTimeLabel = true;
                }
            }
        }

        /// <summary>
        /// 获取场次状态颜色
        /// </summary>
        public Color[] ShowStatusColors
        {
            get
            {
                return showStatusColors;
            }
        }

        /// <summary>
        /// 获取或设置关联的放映计划管理对象
        /// </summary>
        public DailyShowPlanManage DataManager
        {
            get
            {
                return this.dataManager;
            }
            set
            {
                this.dataManager = value;
            }
        }

        /// <summary>
        /// 获取或设置是否已保存的状态
        /// </summary>
        public bool IsSave
        {
            get
            {
                return this.isSave;
            }
            set
            {
                this.isSave = value;

                if (SaveStateChanged != null)
                    SaveStateChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        public int TotalPage
        {
            get { return this.totalPage; }
        }

        /// <summary>
        /// 获取当前页号
        /// </summary>
        public int CurrentPage
        {
            get { return this.currentPage; }
        }

        #endregion

        public ShowPlanPanel()
        {
            InitializeComponent();

            // 初始化参数
            InitParameter();

            // 初始化控件
            InitControl();
        }

        /// <summary>
        /// 刷新放映计划
        /// </summary>
        public void RefreshShowPlan()
        {
            RefreshShowPlan(null);
        }

        /// <summary>
        /// 刷新放映计划，选择是否强制刷新
        /// </summary>
        public void RefreshShowPlan(bool isForce)
        {
            RefreshShowPlan(null, isForce);
        }

        /// <summary>
        /// 刷新放映计划
        /// </summary>
        /// <param name="name"></param>
        public void RefreshShowPlan(string name)
        {
            RefreshShowPlan(name, false);
        }

        /// <summary>
        /// 刷新放映计划，选择是否强制刷新
        /// </summary>
        public void RefreshShowPlan(string name, bool isForce)
        {
            this.isRefreshingShowPlan = true;

            //if (isForce == true)
            //{
            foreach (Control con in this.Controls)
                con.Hide();

            this.Controls.Clear();
            //}

            //清除无效的放映计划
            var list = dataManager.DailyShowPlan.ShowPlanList;
            while (list.Remove(list.Where(p => p.ShowPlanId == null || p.DailyPlanId == null || p.FilmId == null).FirstOrDefault())) ;
            bool isFirst = true;
            foreach (ShowPlan showPlan in list)
            {
                string[] Array = new string[10];
                // 新建电影方块
                ColorBorderLabel filmLabel = new ColorBorderLabel(dataManager);

                foreach (Control con in this.Controls)
                {
                    ColorBorderLabel label = con as ColorBorderLabel;
                    if (label != null)
                    {
                        ShowPlan sp = label.Tag as ShowPlan;

                        if (sp != null && sp.ShowPlanId == showPlan.ShowPlanId)
                        {
                            filmLabel = label;
                            break;
                        }
                    }
                }

                int? i = (int?)showPlan.Film_FilmModeId;
                if (i != null)
                {
                    try
                    {
                        Array = dataManager.Getfilm_FilmMode((int)showPlan.Film_FilmModeId).BorderColour.Split(';');
                        Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                        filmLabel.BorderColor = color;
                    }
                    catch
                    {
                        filmLabel.BorderColor = Color.Black;
                    }
                }

                else if (showPlan.Film.BorderColour != null && showPlan.Film.BorderColour != string.Empty)
                {
                    try
                    {
                        Array = showPlan.Film.BorderColour.Split(';');
                        Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                        filmLabel.BorderColor = color;
                    }
                    catch
                    {
                        filmLabel.BorderColor = Color.Black;
                    }
                }
                else
                {
                    filmLabel.BorderColor = Color.Black;
                }

                filmLabel.Width = GetFilmLabelWidth(showPlan.Film);
                filmLabel.TextAlign = ContentAlignment.MiddleLeft;
                filmLabel.Font = fontOfFilmLabel;
                var tmp = dataManager.Ticket_RefundList.Where(p => p.ShowPlanId == showPlan.ShowPlanId).FirstOrDefault();
                try
                {
                    switch (name)
                    {
                        case "FilmCode":
                            filmLabel.Text = showPlan.Film.FilmCode;
                            break;
                        case "Ratio":
                            filmLabel.Text = showPlan.Ratio.ToString();
                            break;
                        case "Price":
                            {
                                filmLabel.Text = showPlan.SinglePrice.ToString() + " 元";

                                //鼠标移进时显示信息
                                string price = "单人票价：" + showPlan.SinglePrice.ToString() + " 元";
                                price += "\n双人票价：" + showPlan.DoublePrice.ToString() + " 元";
                                price += "\n学生票价：" + showPlan.StudentPrice.ToString() + " 元";
                                price += "\n团体票价：" + showPlan.GroupPrice.ToString() + " 元";
                                price += "\n包厢票价：" + showPlan.BoxPrice.ToString() + " 元";
                                price += "\n会员定价：" + showPlan.MemberPrice.ToString() + " 元";

                                ToolTip tpPrice = new ToolTip();
                                tpPrice.SetToolTip(filmLabel, price);
                                break;
                            }
                        case "Seats":
                            filmLabel.Text = showPlan.Hall.Seats.ToString();
                            break;
                        case "Total":
                            {
                                if (tmp != null)
                                    filmLabel.Text = tmp.Total.Value.ToString();
                                else
                                    filmLabel.Text = "0";
                                break;
                            }
                        case "Count_Ticket":
                            {
                                if (tmp != null)
                                    filmLabel.Text = tmp.Ticket.Value.ToString();
                                else
                                    filmLabel.Text = "0";
                                break;
                            }
                        case "Count_Refund":
                            {
                                if (tmp != null)
                                    filmLabel.Text = tmp.Refund.Value.ToString();
                                else
                                    filmLabel.Text = "0";
                                break;
                            }

                        case "Emity":
                            {
                                if (tmp != null)
                                    filmLabel.Text = tmp.Emity.Value.ToString();
                                else
                                    filmLabel.Text = showPlan.Hall.Seats.ToString();
                                break;
                            }
                        case "Rate":
                            {
                                if (tmp != null)
                                    filmLabel.Text = (tmp.Rate.Value * 100).ToString() + "%";
                                else
                                    filmLabel.Text = "0";
                                break;
                            }
                        default:
                            if (showPlan.ShowTypeId != null && showPlan.ShowTypeId == 3 || showPlan.ShowTypeId == 2)
                                filmLabel.Text = showPlan.ShowPlanName + "(" + showPlan.ShowType.ShowTypeName + ")";
                            else
                                filmLabel.Text = showPlan.ShowPlanName;
                            break;
                    }
                }
                catch { }
                filmLabel.Tag = showPlan;

                // 设置场次状态颜色
                SetBackColorToShowPlan(filmLabel);

                try
                {
                    this.Controls.Add(filmLabel);
                }
                catch (Exception ex)
                {
                    this.isRefreshingShowPlan = false;

                    throw ex;
                }

                filmLabel.IsEnableTimeLabel = true;
                filmLabel.Location = GetLocation(showPlan);


                if (isFirst)
                {
                    isFirst = false;
                    this.currentPanel = filmLabel;
                    SetFocus(filmLabel);
                }
            }

            this.isRefreshingShowPlan = false;
            IsSave = true;
            if (SaveStateChanged != null)
                SaveStateChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitParameter()
        {
            hallDistance = 72;

            startPosition = new Point(20, hallDistance - heightOfTimeLineShadow - 15);

            rightMargin = startPosition.X + 20;

            xOffset = 0;
            yOffset = 0;

            panelHeight = 23;

            pixelsOfScale = 5;
            minutesPerScale = 5;

            shortHeightOfHour = 8;
            longHeightOfHour = 11;

            shortHeightOfMinute = 6;
            longHeightOfMinute = 8;

            heightOfTimeLineShadow = 15;

            colorOfHourLine = Color.FromArgb(33, 33, 33);
            colorOfMinuteLine = Color.FromArgb(181, 181, 181);
            colorOfTimeLine = Color.FromArgb(168, 168, 168);
            colorOfTimeLineShadow = Color.FromArgb(255, 209, 250);

            colorOfTimeText = Color.FromArgb(113, 113, 113);
            fontOfTimeText = new Font("宋体", 9f, FontStyle.Regular);

            colorOfHallText = Color.FromArgb(113, 113, 113);
            fontOfHallText = new Font("宋体", 10f, FontStyle.Regular);

            colorOfHallText = Color.FromArgb(0, 0, 0);
            lengthOfHallText = 60 / minutesPerScale * pixelsOfScale;

            fontOfFilmLabel = new Font("宋体", 9f, FontStyle.Regular);

            showStatusColors = new Color[4];

            // 未售
            showStatusColors[0] = Color.FromArgb(202, 226, 255);

            // 已售
            showStatusColors[1] = Color.FromArgb(209, 248, 126);

            // 停售
            showStatusColors[2] = Color.FromArgb(255, 239, 151);

            //开售
            showStatusColors[3] = Color.FromArgb(128, 128, 255);

            isMouseDown = false;

            isSave = false;

            isRefreshingShowPlan = false;

            totalPage = 1;
            currentPage = 1;
            hallsPerPage = 7;
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            // 启用双缓冲
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);

            this.BackColor = Color.White;

            this.ControlAdded += new ControlEventHandler(ShowPlanPanel_ControlAdded);
            this.ControlRemoved += new ControlEventHandler(ShowPlanPanel_ControlRemoved);
        }

        /// <summary>
        /// 上翻页
        /// </summary>
        public void PageUp()
        {
            if (currentPage > 1)
            {
                currentPage -= 1;

                SetPage(currentPage);
            }
        }

        /// <summary>
        /// 下翻页
        /// </summary>
        public void PageDown()
        {
            if (currentPage < totalPage)
            {
                currentPage += 1;

                SetPage(currentPage);
            }
        }

        /// <summary>
        /// 翻到指定页号
        /// </summary>
        /// <param name="page"></param>
        public void SetPage(int page)
        {
            Panel panContainer = this.Parent as Panel;

            if (page >= 1 && page <= totalPage)
            {
                if (page == 1)
                {
                    panContainer.AutoScrollPosition = new Point(-panContainer.AutoScrollPosition.X, 0);
                }
                else
                {
                    panContainer.AutoScrollPosition = new Point(-panContainer.AutoScrollPosition.X, (page - 1) * hallsPerPage * hallDistance + heightOfTimeLineShadow + 1);
                }
            }
        }

        /// <summary>
        /// 左微调
        /// </summary>
        public void MoveLeft()
        {
            if (this.currentPanel != null)
            {
                this.currentPanel.Location = new Point(this.currentPanel.Location.X - 1, this.currentPanel.Location.Y);
            }
        }

        /// <summary>
        /// 右微调
        /// </summary>
        public void MoveRight()
        {
            if (this.currentPanel != null)
                this.currentPanel.Location = new Point(this.currentPanel.Location.X + 1, this.currentPanel.Location.Y);
        }

        /// <summary>
        /// 获取电影方块的宽度(根据影片长度)
        /// </summary>
        /// <returns></returns>
        public int GetFilmLabelWidth(FilmAndFilmMode film)
        {
            try
            {
                // 计算电影方块的宽度(根据影片长度)
                return (int)Math.Ceiling((decimal)film.FilmLength / (decimal)minutesPerScale) * pixelsOfScale;
            }
            catch { return 0; }
        }

        /// <summary>
        /// 获取电影方块的宽度(根据影片长度)
        /// </summary>
        /// <returns></returns>
        public int GetFilmLabelWidth(Film film)
        {
            // 计算电影方块的宽度(根据影片长度)
            try
            {
                return (int)Math.Ceiling((decimal)film.FilmLength / (decimal)minutesPerScale) * pixelsOfScale;
            }
            catch { return 0; }
        }

        /// <summary>
        /// 添加放映计划时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowPlanPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is ColorBorderLabel)
            {
                try
                {
                    ColorBorderLabel filmLabel = e.Control as ColorBorderLabel;

                    if (isRefreshingShowPlan != true)
                    {
                        ShowPlan showPlan = filmLabel.Tag as ShowPlan;

                        // 计算电影方块加入本控件后的正确坐标值(控件坐标)
                        int currectX = filmLabel.Location.X;
                        int currectY = filmLabel.Location.Y;

                        Control c = this;
                        while (c.Parent != null && c.Parent.GetType().BaseType != typeof(Form))
                        {
                            currectX -= c.Parent.Location.X;
                            currectY -= c.Parent.Location.Y;
                            c = c.Parent;
                        }

                        if (this.Parent != null && this.Parent.GetType() == typeof(Panel))
                        {
                            Panel panContainer = this.Parent as Panel;

                            currectX += -panContainer.AutoScrollPosition.X;
                        }

                        if (this.Parent != null && this.Parent.GetType() == typeof(Panel))
                        {
                            Panel panContainer = this.Parent as Panel;

                            currectY += -panContainer.AutoScrollPosition.Y;
                        }

                        filmLabel.Location = new Point(currectX, currectY);

                        // 对齐到时间轴
                        Snap(filmLabel);

                        DateTime startTime = GetStartTimeByLocation(filmLabel.Location);

                        int hall = GetHallByLocation(filmLabel.Location);


                        if (startTime < DateTime.Now.AddMinutes(-dataManager.GetTimeSetting((DateTime)dataManager.DailyShowPlan.DailyPlan.PlanDate).TicketingDeadline))
                        {
                            MessageBox.Show("场次开始时间已小于当前时间，不能进行添加", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.Controls.Remove(filmLabel);
                            filmLabel.IsEnableTimeLabel = false;

                            dataManager.RemoveTempData(showPlan);
                            return;
                        }

                        if (dataManager.GetIsActivePosition(showPlan, startTime, hall, false, false) != true)
                        {
                            filmLabel.BringToFront();

                            MessageBox.Show("影片场次不能重叠，请重新拖放!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.Controls.Remove(filmLabel);
                            filmLabel.IsEnableTimeLabel = false;
                            filmLabel.AutoSize = false;

                            dataManager.RemoveTempData(showPlan);

                            return;
                        }


                        filmLabel.Location = GetLocation(showPlan);

                        // 将影厅和开始时间值写入放映计划
                        SetLocationToShowPlan(filmLabel);

                        // 设置场次状态颜色
                        SetBackColorToShowPlan(filmLabel);

                        // 将该场次电影加入该日放映计划缓存
                        dataManager.Add(showPlan);

                        // 更新场次序号
                        dataManager.RefreshPosition(showPlan);

                        // 设置为当前焦点
                        SetFocus(filmLabel);

                        //如果新新拖进来的，现在就设置它的票价
                        SetNewPrice(showPlan);

                        dataManager.ReSetShowPlan_DailyShowPlan(showPlan);

                        // RefreshShowPlan();
                    }

                    // 改变保存状态
                    this.isSave = false;
                    if (SaveStateChanged != null)
                        SaveStateChanged(this, EventArgs.Empty);

                    // 添加鼠标响应事件
                    filmLabel.MouseUp += new MouseEventHandler(filmLabel_MouseUp);
                    filmLabel.MouseMove += new MouseEventHandler(filmLabel_MouseMove);
                    filmLabel.MouseDown += new MouseEventHandler(filmLabel_MouseDown);
                    filmLabel.PreviewUserChangeOffset += new EventHandler(filmLabel_PreviewUserChangeOffset);
                    filmLabel.UserChangeOffset += new EventHandler(filmLabel_UserChangeOffset);

                    filmLabel.MouseDoubleClick += new MouseEventHandler(filmLabel_MouseDoubleClick);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 设置场次状态颜色
        /// </summary>
        /// <param name="filmLabel"></param>
        private void SetBackColorToShowPlan(ColorBorderLabel filmLabel)
        {
            ShowPlan showPlan = filmLabel.Tag as ShowPlan;

            if (showPlan.ShowStatus != null)
            {
                try
                {
                    int status = Convert.ToInt32(showPlan.ShowStatus);
                    if (status == 0)
                    {
                        if (showPlan.IsSalable == true)
                            filmLabel.BackColor = showStatusColors[3];
                        else
                            filmLabel.BackColor = showStatusColors[0];
                    }
                    else
                        filmLabel.BackColor = showStatusColors[status];
                }
                catch { }
            }
        }

        /// <summary>
        /// 删除放映计划时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPlanPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is ColorBorderLabel)
            {
                if (this.isRefreshingShowPlan != true)
                {
                    ColorBorderLabel filmLabel = e.Control as ColorBorderLabel;
                    ShowPlan showPlan = filmLabel.Tag as ShowPlan;

                    dataManager.Remove(showPlan);

                    this.isSave = false;
                    if (SaveStateChanged != null)
                        SaveStateChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 将指定电影方块设为当前焦点
        /// </summary>
        /// <param name="filmLabel"></param>
        private void SetFocus(ColorBorderLabel filmLabel)
        {
            if (this.currentPanel != null)
            {
                this.currentPanel.ForeColor = Color.Black;
                SetBackColorToShowPlan(this.currentPanel);
            }

            this.currentPanel = filmLabel;

            this.currentPanel.ForeColor = Color.White;
            this.currentPanel.BackColor = Color.Red;

            this.currentPanel.Focus();
            this.currentPanel.BringToFront();
        }
        private void filmLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditShowPlan();
            RefreshShowPlan();
        }


        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <returns></returns>
        public bool EditShowPlan()
        {
            ColorBorderLabel label = this.currentPanel;
            ShowPlan showPlan = label.Tag as ShowPlan;
            if (showPlan.IsLocked != true && showPlan.ShowStatus == 0)
            {
                //还没开售或锁定
                frmUpdateShowPlanInfo frm = new frmUpdateShowPlanInfo(showPlan, this.dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    showPlan = frm.showPlan;

                    //修改场次和日计划信息
                    dataManager.ReSetShowPlan_DailyShowPlan(showPlan);

                    label.Tag = showPlan;
                    currentPanel.Location = GetLocation(showPlan);

                    return true;
                }
                else
                    return false;
            }
            else
            {
                MessageBox.Show("放映计划已锁定或已开售，不能进行修改！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 获取影片开始时间，根据顶部窗体的坐标位置
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartTimeFromTopFormLocation(Point location)
        {
            // 计算电影方块加入本控件后的正确坐标值(控件坐标)
            int currectX = location.X;
            int currectY = location.Y;

            Control c = this;
            while (c.Parent != null && c.Parent.GetType().BaseType != typeof(Form))
            {
                currectX -= c.Parent.Location.X;
                currectY -= c.Parent.Location.Y;
                c = c.Parent;
            }

            if (this.Parent != null && this.Parent.GetType() == typeof(Panel))
            {
                Panel panContainer = this.Parent as Panel;

                currectX += -panContainer.AutoScrollPosition.X;
            }

            location = new Point(currectX, currectY);

            DateTime startTime = GetStartTimeByLocation(location);

            return startTime;
        }

        /// <summary>
        /// 在用户微调之前，保存最后的位置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filmLabel_PreviewUserChangeOffset(object sender, EventArgs e)
        {
            try
            {
                ColorBorderLabel label = sender as ColorBorderLabel;

                lastLocation = label.Location;
            }
            catch { }
        }

        /// <summary>
        /// 检查用户的微调，防止越界
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filmLabel_UserChangeOffset(object sender, EventArgs e)
        {
            try
            {
                ColorBorderLabel label = sender as ColorBorderLabel;
                ShowPlan showPlan = label.Tag as ShowPlan;

                SnapToTimeLine(label);

                if (showPlan.IsLocked != true && showPlan.ShowStatus == 0 && dataManager.GetIsActivePosition(showPlan, GetExactStartTimeByLocation(label.Location), GetHallByLocation(label.Location)) == true)
                {
                    if (dataManager.PreviewKey == 0 && showPlan.StartTime < DateTime.Now.AddMinutes(-dataManager.GetTimeSetting((DateTime)dataManager.DailyShowPlan.DailyPlan.PlanDate).TicketingDeadline))
                    //   if (showPlan.StartTime < DateTime.Now.AddMinutes(-dataManager.GetTimeSetting((DateTime)dataManager.DailyShowPlan.DailyPlan.PlanDate).TicketingDeadline))
                    {
                        label.Location = lastLocation;
                        return;
                    }
                    //场次信息修改，从新设置场次信息和日计划信息
                    dataManager.ReSetShowPlan_DailyShowPlan(showPlan);

                    SetExactLocationToShowPlan(label);

                }
                else
                {
                    label.Location = lastLocation;
                }

                label.SynchronizeTimeLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filmLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ColorBorderLabel label = sender as ColorBorderLabel;

                // 保存当前坐标位置
                lastLocation = label.Location;

                // 计算被点击电影的坐标偏移量(相对于屏幕坐标)
                xOffset = Control.MousePosition.X - label.Location.X;
                yOffset = Control.MousePosition.Y - label.Location.Y;

                SetFocus(label);

                isMouseDown = true;
            }
        }

        private void filmLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ColorBorderLabel label = sender as ColorBorderLabel;
                ShowPlan showPlan = label.Tag as ShowPlan;

                if (showPlan.IsLocked == true || showPlan.ShowStatus != 0)
                {
                    MessageBox.Show("该放映计划已锁定或已开售或已停售，不能移动!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                label.Location = new Point(Control.MousePosition.X - xOffset, Control.MousePosition.Y - yOffset);

                DateTime startTime = GetExactStartTimeByLocation(label.Location);

                label.SynchronizeTimeLabel(startTime, showPlan.FilmLength.Value);
            }
        }

        private void filmLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    ColorBorderLabel label = sender as ColorBorderLabel;
                    ShowPlan showPlan = label.Tag as ShowPlan;

                    if (label.Location.X < 0
                        || label.Location.Y < 0 ||
                        ((label.Location.X > this.Parent.Width - label.Width * 2 / 3 && label.Location.X > this.Width - label.Width * 2 / 3)
                        || label.Location.Y > this.Parent.Height - label.Height * 2 / 3 && label.Location.Y > this.Height - label.Height * 2 / 3))
                    {
                        //如果放映计划锁定或已开售不能进行删除
                        if (showPlan.IsLocked != true && showPlan.ShowStatus == 0)
                        {
                            if (MessageBox.Show("确定删除该放映计划？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                DelShowPlan();

                                isSave = false;
                                if (SaveStateChanged != null)
                                    SaveStateChanged(this, EventArgs.Empty);
                            }
                            else
                                label.Location = lastLocation;
                        }
                        else
                        {
                            label.Location = lastLocation;
                            MessageBox.Show("该放映计划已锁定或已开售或已停售，不能删除!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (label.Location != lastLocation)
                    {
                        // 只有当电影方块位置改变时，才做处理
                        Snap(label);

                        if (dataManager.GetIsActivePosition(showPlan, GetStartTimeByLocation(label.Location), GetHallByLocation(label.Location), true, true) == true)
                        {
                            SetLocationToShowPlan(label);

                            if (showPlan.StartTime < DateTime.Now.AddMinutes(-dataManager.GetTimeSetting((DateTime)dataManager.DailyShowPlan.DailyPlan.PlanDate).TicketingDeadline))
                            {
                                label.Location = lastLocation;
                                SetLocationToShowPlan(label);
                                //  RefreshShowPlan();
                                MessageBox.Show("场次开始时间已小于当前时间，不能进行添加", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            //场次信息修改，从新设置场次信息和日计划信息
                            dataManager.ReSetShowPlan_DailyShowPlan(showPlan);
                            isSave = false;
                            if (SaveStateChanged != null)
                                SaveStateChanged(this, EventArgs.Empty);

                        }
                        else
                        {
                            label.Location = lastLocation;
                            SetLocationToShowPlan(label);
                            //   RefreshShowPlan();
                        }

                        label.SynchronizeTimeLabel();

                        // RefreshShowPlan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isMouseDown = false;
            }
        }

        /// <summary>
        /// 设置分区票价
        /// </summary>
        public bool BlockPrice()
        {
            try
            {
                ShowPlan showPlan = currentPanel.Tag as ShowPlan;

                if (showPlan.IsLocked != true && showPlan.ShowStatus == 0)
                {
                    FrmSeatChartResetBlockPrice frm = new FrmSeatChartResetBlockPrice(showPlan.ShowPlanId, showPlan.HallId);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        isSave = false;

                        if (SaveStateChanged != null)
                            SaveStateChanged(this, EventArgs.Empty);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    throw new NotImplementedException("该场次已锁定或已开售或已停售，不能设置分区票价！");
                }
            }
            catch
            {
                throw new NotImplementedException("没选中任何场次计划，请先选择！");
            }
        }


        /// <summary>
        /// 删除放映计划
        /// </summary>
        public void DelShowPlan()
        {
            try
            {
                ShowPlan showPlan = currentPanel.Tag as ShowPlan;
                string hallId = showPlan.HallId;

                if (showPlan.IsLocked != true && showPlan.ShowStatus == 0)
                {
                    // dataManager.Remove(showPlan);

                    currentPanel.Hide();
                    this.Controls.Remove(currentPanel);
                    currentPanel.IsEnableTimeLabel = false;
                    currentPanel.Dispose();


                    //更新场次序号
                    dataManager.RefreshPosition(hallId);

                    //刷新放映计划
                    //RefreshShowPlan(true);

                    isSave = false;
                    if (SaveStateChanged != null)
                        SaveStateChanged(this, EventArgs.Empty);

                }
                else
                {
                    MessageBox.Show("该场次已锁定或已开售或已停售，不能删除！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { MessageBox.Show("没选中任何场次计划，请先选择！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        /// <summary>
        /// 删除厅放映计划
        /// </summary>
        public void DelCurrentHallShowPlan()
        {
            try
            {
                ShowPlan showPlan = currentPanel.Tag as ShowPlan;
                if (MessageBox.Show("是否确定删除 " + showPlan.Hall.HallName + " 的所有放映计划？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //删除操作
                    dataManager.DelCurrentHallShowPlan(showPlan.HallId);

                    //刷新放映计划
                    RefreshShowPlan(true);

                    isSave = false;
                    if (SaveStateChanged != null)
                        SaveStateChanged(this, EventArgs.Empty);
                }
            }
            catch
            {
                MessageBox.Show("没选中任何影厅，请选择要删除的影厅！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        ///  根据影片自动设置票价信息
        /// </summary>
        /// <param name="showPlan"></param>
        private void SetNewPrice(ShowPlan showPlan)
        {
            //是否已经设置票价的标志
            bool isSetPrice = false;

            //if (isSetPrice == false)
            //{
            //    //检查是否符合设置分片票价
            //    foreach (FilmPrices filmPrice in dataManager.GetFilmPriceList())
            //    {
            //        //判断票价优先级，并设定修改后的票价等级
            //        if (showPlan.FilmId == filmPrice.FilmId && showPlan.FareSettingId <= dataManager.FareSettingFilmPriceId)
            //        {
            //            showPlan.FareSettingId = dataManager.FareSettingFilmPriceId;  //设为全场票价等级

            //            showPlan.SinglePrice = filmPrice.SinglePrice;
            //            showPlan.DoublePrice = filmPrice.DoublePrice;
            //            showPlan.StudentPrice = filmPrice.StudentPrice;
            //            showPlan.GroupPrice = filmPrice.GroupPrice;
            //            showPlan.MemberPrice = filmPrice.MemberPrice;
            //            showPlan.BoxPrice = filmPrice.BoxPrice;

            //            isSetPrice = true;
            //        }
            //    }
            //}

            //if (isSetPrice == false)
            //{
            //    //检查是否符合时段票价
            //    foreach (var list in dataManager.GetPeriodPriceList())
            //    {
            //        //判断票价优先级，并设定修改后的票价等级
            //        if (showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute >= list.StartTime.Value.TotalMinutes
            //            && showPlan.StartTime.Value.Hour * 60 + showPlan.StartTime.Value.Minute <= list.EndTime.Value.TotalMinutes
            //            && showPlan.FareSettingId <= dataManager.FareSettingPeriodPriceId)
            //        {
            //            showPlan.SinglePrice = list.SinglePrice;
            //            showPlan.DoublePrice = list.DoublePrice;
            //            showPlan.StudentPrice = list.StudentPrice;
            //            showPlan.GroupPrice = list.GroupPrice;
            //            showPlan.MemberPrice = list.MemberPrice;
            //            showPlan.BoxPrice = list.BoxPrice;

            //            showPlan.FareSettingId = dataManager.FareSettingPeriodPriceId;
            //            isSetPrice = true;
            //        }

            //    }
            //}

            //if (isSetPrice == false)
            //{
            //    //检查是否符合设置分厅票价
            //    var list = dataManager.GetHallPriceList().Where(p => p.HallId == showPlan.HallId).FirstOrDefault();
            //    if (list != null && list.SinglePrice != 0 && list.DoublePrice != 0 && list.StudentPrice != 0 && list.GroupPrice != 0 && list.BoxPrice != 0 && list.MemberPrice != 0)
            //    {
            //        showPlan.SinglePrice = list.SinglePrice;
            //        showPlan.DoublePrice = list.DoublePrice;
            //        showPlan.StudentPrice = list.StudentPrice;
            //        showPlan.GroupPrice = list.GroupPrice;
            //        showPlan.MemberPrice = list.MemberPrice;
            //        showPlan.BoxPrice = list.BoxPrice;

            //        showPlan.FareSettingId = dataManager.FareSettingHallPriceId;
            //        isSetPrice = true;
            //    }
            //}

            if (isSetPrice == false && showPlan.FareSettingId <= dataManager.FareSettingTheaterPriceId)
            {
                //检查设置为全场票价

                var list = dataManager.GetTheaterPrice();
                if (list != null)
                {
                    showPlan.SinglePrice = list.SinglePrice;
                    showPlan.DoublePrice = list.DoublePrice;
                    showPlan.StudentPrice = list.StudentPrice;
                    showPlan.GroupPrice = list.GroupPrice;
                    showPlan.MemberPrice = list.MemberPrice;
                    showPlan.BoxPrice = list.BoxPrice;

                    showPlan.FareSettingId = dataManager.FareSettingTheaterPriceId;
                    isSetPrice = true;
                }
            }
        }

        /// <summary>
        /// 获取指定位置所在的时间（精确到刻度）
        /// </summary>
        /// <param name="point"></param>
        private DateTime
            GetStartTimeByLocation(Point point)
        {
            // 时间线总刻度数
            int timeLineScale;
            if (this.dataSource.DailyPlan.EndTime.Value <= this.dataSource.DailyPlan.StartTime.Value)
                timeLineScale = ((int)((this.dataSource.DailyPlan.EndTime.Value.TotalMinutes + 24 * 60) - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)) / minutesPerScale;
            else
                timeLineScale = ((int)(this.dataSource.DailyPlan.EndTime.Value.TotalMinutes - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)) / minutesPerScale;
            // 起点在分钟刻度上的刻度值
            int startScale = (point.X - startPosition.X - lengthOfHallText) / pixelsOfScale;

            // 起点时间刻度值不允许小于0
            if (startScale < 0)
                startScale = 0;

            DateTime dt = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value.AddMinutes((int)dataManager.DailyShowPlan.DailyPlan.StartTime.Value.TotalMinutes + startScale * minutesPerScale);

            return dt;
        }

        /// <summary>
        /// 获取指定位置所在的精确时间（精确到分钟）
        /// </summary>
        /// <param name="point"></param>
        public DateTime GetExactStartTimeByLocation(Point point)
        {
            // 起点在分钟刻度上的分钟值
            int startMinute = (point.X - startPosition.X - lengthOfHallText) / (pixelsOfScale / minutesPerScale);

            // 起点时间刻度值不允许小于0
            if (startMinute < 0)
                startMinute = 0;

            DateTime dt = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value.AddMinutes((int)dataManager.DailyShowPlan.DailyPlan.StartTime.Value.TotalMinutes + startMinute);

            return dt;
        }

        /// <summary>
        /// 获取指定位置所在的厅序号
        /// </summary>
        private int GetHallByLocation(Point point)
        {
            // 影厅序号
            int hall = (point.Y - startPosition.Y + hallDistance) / hallDistance;

            // 影厅序号不允许小于0
            if (hall < 0)
                hall = 0;

            // 影厅序号不允许大于最大影厅数
            if (hall > dataManager.DailyShowPlan.HallList.Count - 1)
                hall = dataManager.DailyShowPlan.HallList.Count - 1;

            return hall;
        }

        /// <summary>
        /// 对齐到时间轴
        /// </summary>
        /// <param name="label"></param>
        private void SnapToTimeLine(ColorBorderLabel label)
        {
            // 计算时间总数(分钟)，两种情况，一种跨天（结束时间小于开始时间），一种不跨天（结束时间大于开始时间）
            int timeSpan;
            if (this.dataSource.DailyPlan.EndTime.Value.TotalMinutes >= this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)
            {
                timeSpan = (int)(this.dataSource.DailyPlan.EndTime.Value.TotalMinutes - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes);
            }
            else
            {
                timeSpan = (int)(24 * 60 - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + this.dataSource.DailyPlan.EndTime.Value.TotalMinutes);
            }

            // 计算时间轴长度
            int len = timeSpan / this.minutesPerScale * this.pixelsOfScale;

            // 防止越出时间轴的界限
            if (label.Location.X < startPosition.X + lengthOfHallText)
            {
                label.Location = new Point(startPosition.X + lengthOfHallText, label.Location.Y);
            }
            else if (label.Location.X + label.Width > startPosition.X + lengthOfHallText + len)
            {
                label.Location = new Point(startPosition.X + len + lengthOfHallText - label.Width, label.Location.Y);
            }
        }

        /// <summary>
        /// 对齐到时间刻度表
        /// </summary>
        /// <param name="label">电影方块</param>
        private void Snap(ColorBorderLabel label)
        {
            Panel panContainer = this.Parent as Panel;

            ShowPlan showPlan = label.Tag as ShowPlan;

            int x = label.Location.X;
            int y = label.Location.Y;

            // 计算时间线总刻度数，两种情况，一种跨天（结束时间小于开始时间），一种不跨天（结束时间大于开始时间）
            int timeLineScale;
            if (this.dataSource.DailyPlan.EndTime.Value.TotalMinutes >= this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)
            {
                timeLineScale = (int)(this.dataSource.DailyPlan.EndTime.Value.TotalMinutes - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes) / minutesPerScale; ;
            }
            else
            {
                timeLineScale = (int)(24 * 60 - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + this.dataSource.DailyPlan.EndTime.Value.TotalMinutes) / minutesPerScale; ;
            }

            // 起点在分钟刻度上的刻度值
            int startScale = (x - startPosition.X - lengthOfHallText) / pixelsOfScale;

            // 影片时间长度所占的刻度数(如果不为整数，则用“进一法”取整)
            int filmLengthScale = (int)Math.Ceiling((decimal)showPlan.Film.FilmLength / (decimal)minutesPerScale);

            // 起点时间刻度值不允许小于0
            if (startScale < 0)
                startScale = 0;

            // 终点时间刻度值不能大于时间刻度的最大值
            if (startScale + filmLengthScale > timeLineScale)
                startScale = timeLineScale - filmLengthScale;

            // 影厅序号
            int hall = (y - startPosition.Y + hallDistance) / hallDistance;

            // 影厅序号不允许小于0
            if (hall < 0)
                hall = 0;

            // 影厅序号不允许大于最大影厅数
            if (hall > dataManager.DailyShowPlan.HallList.Count - 1)
                hall = dataManager.DailyShowPlan.HallList.Count - 1;

            label.Location = new Point(startPosition.X + lengthOfHallText + startScale * pixelsOfScale,
                startPosition.Y + hall * hallDistance - longHeightOfHour - panelHeight);
        }

        /// <summary>
        /// 根据放映计划，获取电影方块的坐标(相对坐标)
        /// </summary>
        /// <returns></returns>
        private Point GetLocation(ShowPlan showPlan)
        {
            Point point = new Point();

            try
            {
                int hall = Convert.ToInt32(showPlan.HallId) - 1;

                // 根据跨天或不跨天，计算对齐位置
                int startScale;
                // 计算微调位置
                int startOffset;
                if (showPlan.StartTime.Value.TimeOfDay.TotalMinutes >= this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)
                {
                    startScale = (int)showPlan.StartTime.Value.AddMinutes(-(int)dataSource.DailyPlan.StartTime.Value.TotalMinutes).TimeOfDay.TotalMinutes / minutesPerScale;
                    startOffset = (int)showPlan.StartTime.Value.AddMinutes(-(int)dataSource.DailyPlan.StartTime.Value.TotalMinutes).TimeOfDay.TotalMinutes % minutesPerScale;
                }
                else
                {
                    startScale = (24 * 60 - (int)this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + (int)showPlan.StartTime.Value.TimeOfDay.TotalMinutes) / minutesPerScale;
                    startOffset = (24 * 60 - (int)this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + (int)showPlan.StartTime.Value.TimeOfDay.TotalMinutes) % minutesPerScale;
                }

                point = new Point(startPosition.X + lengthOfHallText + startScale * pixelsOfScale + startOffset * pixelsOfScale / minutesPerScale,
                startPosition.Y + hall * hallDistance - longHeightOfHour - panelHeight);
            }
            catch
            {
                throw new Exception("影厅编号有误，应为01,02,03……，请检查！");
            }

            return point;
        }

        /// <summary>
        /// 绘制放映计划图
        /// </summary>
        private void DrawShowPlanImage()
        {
            if (dataSource != null)
            {
                // 计算时间总数(分钟)，两种情况，一种跨天（结束时间小于开始时间），一种不跨天（结束时间大于开始时间）
                int timeSpan;
                if (this.dataSource.DailyPlan.EndTime.Value.TotalMinutes >= this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)
                {
                    timeSpan = (int)(this.dataSource.DailyPlan.EndTime.Value.TotalMinutes - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes);
                }
                else
                {
                    timeSpan = (int)(24 * 60 - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + this.dataSource.DailyPlan.EndTime.Value.TotalMinutes);
                }

                // 调整面板宽高度，以适应放映计划图
                this.Width = timeSpan / this.minutesPerScale * this.pixelsOfScale + lengthOfHallText + startPosition.X + rightMargin;

                int integerHalls = dataManager.DailyShowPlan.DailyPlan.Halls.Value;
                if (dataManager.DailyShowPlan.DailyPlan.Halls.Value > 7 && dataManager.DailyShowPlan.DailyPlan.Halls.Value % 7 > 0)
                    integerHalls = dataManager.DailyShowPlan.DailyPlan.Halls.Value / hallsPerPage * hallsPerPage + hallsPerPage;

                this.Height = hallDistance * (integerHalls + 1);

                // 面版宽高度不能比容器宽高度小（也即主界面的右面版宽高度）
                if (this.Width < this.Parent.Width)
                    this.Width = this.Parent.Width;
                if (this.Height < this.Parent.Height)
                    this.Height = this.Parent.Height;

                // 计算页数
                //totalPage = (this.Height - hallDistance / 3 - startPosition.Y) / hallDistance / hallsPerPage;
                //if (((this.Height - startPosition.Y) / (hallDistance + heightOfTimeLineShadow)) % hallsPerPage > 0)
                //    totalPage += 1;
                totalPage = integerHalls / hallsPerPage;

                // 置当前页号为1
                currentPage = 1;

                // 绘制放映计划图为背景图
                showPlanImage = new Bitmap(this.Width, this.Height);

                MakeShowPlanImage(Graphics.FromImage(showPlanImage));

                this.BackgroundImage = showPlanImage;
            }
        }

        /// <summary>
        /// 根据数据源更新放映计划图
        /// </summary>
        private void MakeShowPlanImage(Graphics g)
        {
            if (this.dataSource != null)
            {
                // 定义画笔
                Pen penOfHourLine = new Pen(this.colorOfHourLine, 1);
                Pen penOfMinuteLine = new Pen(this.colorOfMinuteLine, 1);
                Pen penOfTimeLine = new Pen(this.colorOfTimeLine, 1);

                // 定义起点坐标变量
                int x = 0;
                int y = 0;

                // 计算时间总数(分钟)，两种情况，一种跨天（结束时间小于开始时间），一种不跨天（结束时间大于开始时间）
                int timeSpan;
                if (this.dataSource.DailyPlan.EndTime.Value.TotalMinutes >= this.dataSource.DailyPlan.StartTime.Value.TotalMinutes)
                {
                    timeSpan = (int)(this.dataSource.DailyPlan.EndTime.Value.TotalMinutes - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes);
                }
                else
                {
                    timeSpan = (int)(24 * 60 - this.dataSource.DailyPlan.StartTime.Value.TotalMinutes + this.dataSource.DailyPlan.EndTime.Value.TotalMinutes);
                }
                // 计算时间轴长度
                int len = timeSpan / this.minutesPerScale * this.pixelsOfScale;

                y = startPosition.Y;

                Color color = new Color();
                // 循环画出各个影厅
                for (int hall = 0; hall < this.dataSource.DailyPlan.Halls.Value; hall++)
                {
                    try
                    {
                        string[] Array = dataManager.DailyShowPlan.HallList[hall].BarColour.Split(';');
                        color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                    }
                    catch
                    {
                        color = Color.Black;
                    }
                    Pen penOfTimeLineShadow = new Pen(color, this.heightOfTimeLineShadow);

                    x = startPosition.X;

                    // 画时间线
                    g.DrawLine(penOfTimeLine, x, y, x + len + lengthOfHallText, y);

                    // 画时间线阴影
                    g.DrawLine(penOfTimeLineShadow, x, y + this.heightOfTimeLineShadow / 2 + 1, x + len + lengthOfHallText, y + this.heightOfTimeLineShadow / 2 + 1);

                    // 写影厅名称
                    // g.DrawString(string.Format("第{0}厅", hall + 1), fontOfHallText, new SolidBrush(colorOfHallText), x, y - 15);
                    g.DrawString(string.Format("{0}", dataManager.DailyShowPlan.HallList[hall].HallName), fontOfHallText, new SolidBrush(colorOfHallText), x, y - 15);

                    x += lengthOfHallText;

                    // 算出起点的小时数
                    int hour = (int)this.dataSource.DailyPlan.StartTime.Value.TotalHours;
                    int minute = (int)this.dataSource.DailyPlan.StartTime.Value.TotalMinutes % 60;

                    // 循环画出各个刻度
                    for (int i = 0; i <= timeSpan / this.minutesPerScale; i++)
                    {
                        // 判断是否偶数刻度
                        if (minute % 60 == 0)
                        {
                            g.DrawLine(penOfHourLine, x, y, x, y - this.longHeightOfHour);

                            // 写时间刻度值
                            g.DrawString(string.Format("{0}:00", hour), fontOfTimeText, new SolidBrush(colorOfTimeText), x, y + 2);
                        }
                        else if (minute % 30 == 0)
                        {
                            g.DrawLine(penOfHourLine, x, y, x, y - this.shortHeightOfHour);
                        }
                        else if (minute % 2 == 0)
                        {
                            g.DrawLine(penOfMinuteLine, x, y, x, y - this.longHeightOfMinute);
                        }
                        else
                        {
                            g.DrawLine(penOfMinuteLine, x, y, x, y - this.shortHeightOfMinute);
                        }

                        // 首尾也要写上时间刻度值
                        if ((i == 0 || i == timeSpan / this.minutesPerScale) && minute != 0 && minute % 60 != 0)
                        {
                            g.DrawString(string.Format("{0}:{1}", hour, minute % 60), fontOfTimeText, new SolidBrush(colorOfTimeText), x, y + 2);
                        }

                        minute += minutesPerScale;

                        if (minute % 60 == 0)
                        {
                            hour += 1;
                            hour = hour % 24;
                        }

                        x += this.pixelsOfScale;
                    }

                    y += hallDistance;
                }
            }
        }

        /// <summary>
        /// 根据电影方块落点，设置电影方块所在的影厅及开始时间
        /// </summary>
        private void SetLocationToShowPlan(ColorBorderLabel filmLabel)
        {
            try
            {
                ShowPlan showPlan = filmLabel.Tag as ShowPlan;

                int x = filmLabel.Location.X;
                int y = filmLabel.Location.Y;

                int startTime = (x - startPosition.X - lengthOfHallText) / pixelsOfScale * minutesPerScale;
                if (startTime < 0)
                    startTime = 0;

                int hall = (y - startPosition.Y + hallDistance) / hallDistance;
                if (hall < 0)
                    hall = 0;
                if (hall > dataManager.DailyShowPlan.HallList.Count - 1)
                    hall = dataManager.DailyShowPlan.HallList.Count - 1;

                string oldHall = showPlan.HallId;

                showPlan.StartTime = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value.Add(dataManager.DailyShowPlan.DailyPlan.StartTime.Value).AddMinutes(startTime);
                showPlan.EndTime = showPlan.StartTime.Value.AddMinutes(showPlan.FilmLength.Value);
                showPlan.HallId = dataManager.DailyShowPlan.HallList[hall].HallId;
                dataManager.RefreshPosition(showPlan, oldHall);
            }
            catch
            {
                throw new Exception("影厅编号有误，应为01,02,03……，请检查！");
            }
        }

        /// <summary>
        /// 根据电影方块落点，设置电影方块所在的影厅及精确开始时间
        /// </summary>
        private void SetExactLocationToShowPlan(ColorBorderLabel filmLabel)
        {
            try
            {
                ShowPlan showPlan = filmLabel.Tag as ShowPlan;

                int x = filmLabel.Location.X;
                int y = filmLabel.Location.Y;

                int startTime = (x - startPosition.X - lengthOfHallText) / (pixelsOfScale / minutesPerScale);
                if (startTime < 0)
                    startTime = 0;

                int hall = (y - startPosition.Y + hallDistance) / hallDistance;
                if (hall < 0)
                    hall = 0;
                if (hall > dataManager.DailyShowPlan.HallList.Count - 1)
                    hall = dataManager.DailyShowPlan.HallList.Count - 1;

                string oldHall = showPlan.HallId;

                showPlan.StartTime = dataManager.DailyShowPlan.DailyPlan.PlanDate.Value.Add(dataManager.DailyShowPlan.DailyPlan.StartTime.Value).AddMinutes(startTime);
                showPlan.EndTime = showPlan.StartTime.Value.AddMinutes(showPlan.FilmLength.Value);
                showPlan.HallId = dataManager.DailyShowPlan.HallList[hall].HallId;
                dataManager.RefreshPosition(showPlan, oldHall);
            }
            catch
            {
                throw new Exception("影厅编号有误，应为01,02,03……，请检查！");
            }
        }
    }
}

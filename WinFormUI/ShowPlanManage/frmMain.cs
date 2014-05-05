using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace Flamingo.ShowPlanManage
{
    public partial class frmMain : Form, IMessageFilter
    {
        #region 窗体变量

        // 用于显示按钮提示
        private ToolTip toolTip;

        // 日放映计划管理类
        private DailyShowPlanManage dataManager;

        // 拖放电影方块时，用于记录鼠标是否按下
        private bool isMouseDown;

        // 拖放电影方块时，用于保存临时的X坐标偏移量(屏幕坐标)
        private int xOffset;

        // 拖放电影方块时，用于保存临时的Y坐标偏移量(屏幕坐标)
        private int yOffset;

        // 拖放电影方块时，用于记录临时电影方块
        private ColorBorderLabel tempLabel;

        // 电影文本字体
        private Font fontOfFilmLabel;

        // 用于更新当前时间
        private System.Windows.Forms.Timer timer;

        // 日计划是否已保存
        private bool isSale;

        // 是否预读取
        private bool isPreLoad;

        // 预读取线程
        private Thread preLoadThread;

        // 初始化数据取是否成功
        private bool isInitDataLoadSuccress;

        #endregion

        #region 启动处理

        public frmMain()
        {
            InitializeComponent();

            // 设置双缓冲
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);

            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(btnMin, "最小化");
            toolTip.SetToolTip(btnClose, "关闭");

            this.MouseWheel += new MouseEventHandler(frmMain_MouseWheel);

            spPanShowPlan.SaveStateChanged += new EventHandler(spPanShowPlan_SaveStateChanged);

            // 设置窗体属性
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            fontOfFilmLabel = new Font("宋体", 9f);

            // 设置场次状态颜色
            lblColorOfIsUnSale.BackColor = spPanShowPlan.ShowStatusColors[0];
            lblColorOfIsSale.BackColor = spPanShowPlan.ShowStatusColors[1];
            lblColorOfIsStopSale.BackColor = spPanShowPlan.ShowStatusColors[2];

            // 拦截系统消息，用于屏蔽滚轮
            Application.AddMessageFilter(this);

            // 用于更新当前时间
            timer = new System.Windows.Forms.Timer();

            // 更新周期为1秒
            timer.Interval = 1 * 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            isSale = true;
            isPreLoad = false;
            isInitDataLoadSuccress = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (isPreLoad != true)
            {
                LoadInitData();

                if (isInitDataLoadSuccress != true)
                {
                    MessageBox.Show("出现错误，请将查数据库连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }

            this.panShowPlanContainer.Width = this.Width - 8 - 169 + 15;
            this.panShowPlanContainer.Height = 550 - 15;
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 时钟事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        /// <summary>
        /// 屏蔽滚轮事件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 522)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 上翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            spPanShowPlan.PageUp();
            lblPage.Text = spPanShowPlan.CurrentPage + " / " + spPanShowPlan.TotalPage;
        }

        /// <summary>
        /// 下翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            spPanShowPlan.PageDown();
            lblPage.Text = spPanShowPlan.CurrentPage + " / " + spPanShowPlan.TotalPage;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataManager.isCheckRatio();

                this.dataManager.Save();
                spPanShowPlan.IsSave = true;

                tsApproved_Click(this, EventArgs.Empty);

                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCopy_Click(object sender, EventArgs e)
        {
            DateTime dtNow = dtDateTime.Value;
            frmCopyShowPlan frm = new frmCopyShowPlan(dataManager, txtTheter.Text);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //数组保存顺序：
                //（0）被复制信息的日期
                //（1）被复制信息的影厅（null表示复制全部影厅）
                //（2）目标日期
                //（3）目标影厅（null表示复制全部影厅）
                string[] str = frm.GetStr;
                if (str[0] == str[2] || spPanShowPlan.IsSave == true)
                {
                    try
                    {
                        //检查是否符合复制的要求
                        try
                        {
                            dataManager.CheckCopy(str);
                        }
                        catch (Exception info)
                        {
                            if (info.Message.EndsWith("?") == true)
                            {
                                if (MessageBox.Show(info.Message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                    return;
                            }
                            else
                            {
                                throw new NotImplementedException(info.Message);
                            }
                        }

                        string mess;
                        if (str[1] != null && str[3] != null)
                            mess = string.Format("确定将日期为：{0} 的 {1} 影厅的放映计划复制到日期为：{2} 的 {3} 影厅",
                                str[0], dataManager.DailyShowPlan.HallList.Where(P => P.HallId == str[1]).FirstOrDefault().HallName, str[2], dataManager.DailyShowPlan.HallList.Where(P => P.HallId == str[3]).FirstOrDefault().HallName);
                        else
                            mess = string.Format("确定将日期为：{0} 的 {1} 影厅的放映计划复制到日期为：{2} 的 {1} 影厅", str[0], "全部", str[2]);
                        if (MessageBox.Show(mess, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            return;
                        if (str[0] != str[2])
                            dtDateTime.Value = Convert.ToDateTime(str[2]);

                        //复制放映计划

                        dataManager.CopyShowPlan(str);

                        //刷新放映计划
                        spPanShowPlan.RefreshShowPlan();

                        //改变保存状态
                        spPanShowPlan.IsSave = false;

                        if (str[3] != null)
                        {
                            spPanShowPlan.SetPage(Convert.ToInt32(str[3]) / 7 + 1);
                            tsCopy.Enabled = true;
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("当前日期的放映计划还没保存，不能复制！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除全天放映计划？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("您是否真的删除全天放映计划？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        dataManager.DelAllShowPlan();

                        spPanShowPlan.RefreshShowPlan(true);

                        spPanShowPlan.IsSave = false;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            // 获取鼠标当前点位置
            Point point = new Point(e.X, e.Y);

            // 将位置平移(解决窗体不在左上角的位置问题)。
            point.Offset(this.Location.X, this.Location.Y);

            // 定义一个面。
            Rectangle rect = new Rectangle(flPanFilm.Location.X, flPanFilm.Location.Y, flPanFilm.Width, flPanFilm.Height);

            // 判断指定的点是否在指定的面中
            if (RectangleToScreen(rect).Contains(point))
            {
                // 开始移动
                flPanFilm.AutoScrollPosition = new Point(0, flPanFilm.VerticalScroll.Value - e.Delta / 5);
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void tsFilmSetting_Click(object sender, EventArgs e)
        {
            FilmSet(null, 0);
        }

        private void FilmSet(string FilmId, int mode)
        {
            frmFilmSet frm = new frmFilmSet(dataManager, FilmId, mode);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //   RefreshLoadFilmList();
                LoadFilmList();
                spPanShowPlan.RefreshShowPlan();
            }
        }


        private void lnkRecordPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManualWeave frm = new frmManualWeave(this.dataManager, (int)nudDefultTimeSpan.Value);
            if (frm.ShowDialog() == DialogResult.OK)
                spPanShowPlan.RefreshShowPlan();
        }

        private void dtDateTime_ValueChanged(object sender, EventArgs e)
        {

            SetDate(dtDateTime.Value.Date);
        }

        private void btnTodayPlan_Click(object sender, EventArgs e)
        {
            //dtDateTime.Value = DateTime.Today.Date;
            frmDayilyShowPlan frm = new frmDayilyShowPlan(txtTheter.Text, dtDateTime.Value.ToShortDateString(), this.dataManager);

            frm.ShowDialog();
        }

        private void lnkDeleteShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("是否确定删除选中的放映场次？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                spPanShowPlan.DelShowPlan();
        }

        private void lnkDeleteHallPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //删除厅计划
            spPanShowPlan.DelCurrentHallShowPlan();
        }

        private void nudDefultTimeSpan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataManager.SetTimeSpan((int)nudDefultTimeSpan.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filmLabel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    ColorBorderLabel label = sender as ColorBorderLabel;

                    // 计算被点击电影的屏幕坐标
                    int x = label.Location.X + flPanFilm.Location.X + gbFilm.Location.X + scSplit.Location.X;
                    int y = label.Location.Y + flPanFilm.Location.Y + gbFilm.Location.Y + scSplit.Location.Y;

                    // 计算被点击电影的坐标偏移量(相对于屏幕坐标)
                    xOffset = Control.MousePosition.X - x;
                    yOffset = Control.MousePosition.Y - y;

                    tempLabel = GetNewTempFilmLabel(label);

                    //ShowPlan film = tempLabel.Tag as ShowPlan;
                    //if (film==null||film.FilmLength == null || film.FilmLength == 0)
                    //{
                    //    MessageBox.Show("影片时长为空，请先进行设置！", "信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //    return;
                    //}
                    this.Controls.Add(tempLabel);

                    tempLabel.Location = new Point(x, y);
                    tempLabel.BringToFront();

                    tempLabel.IsEnableTimeLabel = true;


                    isMouseDown = true;
                }
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    string id;
                    ColorBorderLabel label = sender as ColorBorderLabel;

                    FilmAndFilmMode showPlan = label.Tag as FilmAndFilmMode;
                    id = showPlan.FilmId;
                    if (showPlan.HasMode == true && showPlan.FilmModeId != null && showPlan.Film_FilmModeId != null && showPlan.FilmId.IndexOf(';') == -1)
                        id += ";" + showPlan.FilmModeId;
                    FilmSet(id, 1);
                }
            }
            catch { }
        }


        private void filmLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowPlan showPlan = tempLabel.Tag as ShowPlan;

                if (showPlan == null || showPlan.FilmLength == null || showPlan.FilmLength == 0)
                {
                    MessageBox.Show("影片时长为空，请先进行设置！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Point newLocation = new Point(Control.MousePosition.X - xOffset, Control.MousePosition.Y - yOffset);

                showPlan.StartTime = spPanShowPlan.GetStartTimeFromTopFormLocation(newLocation);

                tempLabel.Location = newLocation;


            }
        }

        private void filmLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ColorBorderLabel label = sender as ColorBorderLabel;

                // 计算放映计划时间表的屏幕坐标
                int x = spPanShowPlan.Location.X + scSplit.Location.X + scSplit.SplitterDistance + scSplit.SplitterWidth;
                int y = spPanShowPlan.Location.Y + panShowPlanContainer.Location.Y + scSplit.Location.Y;

                // 计算放映计划时间表的控件区域(屏幕坐标)
                Rectangle showPlanRectangle = new Rectangle(x, y, spPanShowPlan.Width, spPanShowPlan.Height);

                if (showPlanRectangle.Contains(tempLabel.Location) == true)
                {
                    spPanShowPlan.Controls.Add(tempLabel);
                }
                else
                {
                    ShowPlan showPlan = tempLabel.Tag as ShowPlan;
                    dataManager.RemoveTempData(showPlan);

                    this.Controls.Remove(tempLabel);
                    tempLabel.IsEnableTimeLabel = false;
                    tempLabel.Dispose();
                }

                isMouseDown = false;
            }
        }

        private void spPanShowPlan_SaveStateChanged(object sender, EventArgs e)
        {
            lblIsSave.Text = spPanShowPlan.IsSave == true ? "计划已保存" : "计划未保存";

            tsCopy.Enabled = spPanShowPlan.IsSave == true ? true : false;

            tsApproved.Enabled = spPanShowPlan.IsSave == true ? true : false;

            if (tsApproved.Enabled == false)
                tsSale.Enabled = false;
        }
        private void dataManager_DailyPlanIsSaleChanged(object sender, EventArgs e)
        {
            tsSale.Text = dataManager.DailyShowPlan.DailyPlan.IsSalable == true ? "未售" : "开售";

            isSale = dataManager.DailyShowPlan.DailyPlan.IsSalable == true ? false : true;
        }

        Bitmap bmp;

        private void tsPrint_Click(object sender, EventArgs e)
        {
            if (spPanShowPlan.IsSave == true)
            {
                //获取放映计划的图片
                bmp = DrawControlToBitmap(panShowPlanContainer);

                //保存图片
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "ShowPlan.jpg";
                bmp.Save(path);


                frmReport frm = new frmReport();

                frm.Text = "打印放映计划";
                frm.LocalReport.EnableExternalImages = true;
                frm.LocalReport.ReportPath = System.AppDomain.CurrentDomain.BaseDirectory + "Print.rdlc";
                ReportParameter rp = new ReportParameter("ImagePath", @"file://" + path);
                frm.LocalReport.SetParameters(rp);
                ReportParameter title = new ReportParameter("Title", "影院名称：  " + txtTheter.Text + "     计划日期：  " + dtDateTime.Value.ToShortDateString());
                frm.LocalReport.SetParameters(title);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("计划还没保存，不能打印！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 20, 20);
        }

        private void tsApproved_Click(object sender, EventArgs e)
        {
            if (dataManager.SetApproved() == true)
            {
                // spPanShowPlan.RefreshShowPlan();
                tsSale.Enabled = true;
                //  MessageBox.Show("上报审核成功！", "信息提示");
            }
            //else
            //    MessageBox.Show("报审核失败！", "信息提示");
        }

        private void tsSale_Click(object sender, EventArgs e)
        {
            if (dataManager.SetSale(isSale) == true)
            {
                spPanShowPlan.RefreshShowPlan();
                tsSale.Enabled = true;
                string ms = "开售";
                if (isSale == true)
                    ms = "未售";
                MessageBox.Show(string.Format("已将放映计划设为{0}！", ms), "信息提示");
            }
            else
                MessageBox.Show("可售设置失败！", "信息提示");
        }

        /// <summary>
        /// 全场票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTheterPriceSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmTheterPriceSet frm = new frmTheterPriceSet(dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataManager.Save();
                    SetIsSave();
                    RefreshData();
                }
            }
            catch { }
        }

        private void SetIsSave()
        {
            spPanShowPlan.IsSave = false;
            spPanShowPlan_SaveStateChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// 分厅票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsHallPriceSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmHallPriceSet frm = new frmHallPriceSet(dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataManager.Save();
                    RefreshData();
                    SetIsSave();
                }

            }
            catch { }
        }

        /// <summary>
        /// 时段票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPeriodPriceSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmPeriodPriceSet frm = new frmPeriodPriceSet(dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataManager.Save();
                    RefreshData();
                    SetIsSave();
                }
                else
                {

                    dataManager.RefreshPeriodPrice(frm.GetPeriodPricesList());
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// 分片票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFilmPriceSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmFilmPriceSet frm = new frmFilmPriceSet(dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataManager.Save();
                    SetIsSave();
                    RefreshData();
                }
            }
            catch { }
        }

        /// <summary>
        /// 分场票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsShowPlanPriceSet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowPlanPriceSet frm = new frmShowPlanPriceSet(dataManager);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataManager.Save();
                    SetIsSave();
                    RefreshData();
                }
            }
            catch
            {
                MessageBox.Show("没选择任何场次，设置分场票价请选择场次信息！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  分区票价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBlockPriceSet_Click(object sender, EventArgs e)
        {
            if (spPanShowPlan.IsSave == false)
            {
                MessageBox.Show("请先保存放映计划再设置区域票价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (spPanShowPlan.BlockPrice() == true)
                {
                    dataManager.Save();
                    SetIsSave();
                    RefreshData();
                }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        /// <summary>
        /// 分片票房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFilmBoxOffice_Click(object sender, EventArgs e)
        {
            frmFilmBoxOffice frm = new frmFilmBoxOffice("Film", dtDateTime.Value);
            frm.ShowDialog();
        }

        /// <summary>
        /// 分厅票房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsHallBoxOffice_Click(object sender, EventArgs e)
        {
            try
            {
                frmFilmBoxOffice frm = new frmFilmBoxOffice("Hall", dtDateTime.Value);
                frm.ShowDialog();

            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        /// <summary>
        /// 单日票房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDayBoxOffice_Click(object sender, EventArgs e)
        {
            try
            {
                frmFilmBoxOffice frm = new frmFilmBoxOffice("Day", dtDateTime.Value);
                frm.ShowDialog();
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        /// <summary>
        /// 时段票房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPeriodBoxOffice_Click(object sender, EventArgs e)
        {
            try
            {
                frmFilmBoxOffice frm = new frmFilmBoxOffice("Period", dtDateTime.Value);
                frm.ShowDialog();
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFilmCode_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("FilmCode");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsFilmName_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("FilmName");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsRatio_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Ratio");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsTotal_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Total");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsPrice_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Price");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsCount_Ticket_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Count_Ticket");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsSeats_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Seats");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsEmity_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Emity");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsCount_Refund_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Count_Refund");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void tsRate_Click(object sender, EventArgs e)
        {
            try
            {
                spPanShowPlan.RefreshShowPlan("Rate");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }


        #endregion

        #region 窗体函数

        /// <summary>
        /// 异步展现窗口，要使此方法生效，需预先调用 BeginPreLoad 方法
        /// </summary>
        public void BeginShow()
        {
            if (isPreLoad != true)
                BeginPreLoad();

            preLoadThread.Join();

            if (isInitDataLoadSuccress == true)
            {
                this.Show();
            }
            else
            {
                MessageBox.Show("出现错误，请将查数据库连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 异步展现所有者模式窗口
        /// </summary>
        /// <returns></returns>
        public DialogResult BeginShowDialog()
        {
            if (isPreLoad != true)
                BeginPreLoad();

            preLoadThread.Join();

            if (isInitDataLoadSuccress == true)
            {
                return this.ShowDialog();
            }
            else
            {
                MessageBox.Show("出现错误，请将查数据库连接！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 开始预读取数据
        /// </summary>
        public void BeginPreLoad()
        {
            ThreadStart ts = new ThreadStart(LoadInitData);
            preLoadThread = new Thread(ts);
            preLoadThread.Start();
        }

        /// <summary>
        /// 读取初始化数据
        /// </summary>
        private void LoadInitData()
        {
            try
            {
                isPreLoad = true;

                dataManager = new DailyShowPlanManage();

                spPanShowPlan.DataManager = dataManager;

                dataManager.IsSaleChanged += new EventHandler(dataManager_DailyPlanIsSaleChanged);

                dtDateTime.Value = DateTime.Now;

                dtDateTime.ValueChanged += new EventHandler(dtDateTime_ValueChanged);

                RefreshData();

                spPanShowPlan.ShowFilmLabelTime();

                isInitDataLoadSuccress = true;
            }
            catch (Exception)
            {
                isInitDataLoadSuccress = false;
            }
        }

        /// <summary>
        /// 初始化放映计划相关控件
        /// </summary>
        private void Init()
        {
            try
            {
                LoadFilmList();

                LoadDailyShowPlan();

                txtTheter.Text = dataManager.DailyShowPlan.DailyPlan.Theater.TheaterName;
                nudDefultTimeSpan.Value = dataManager.DailyShowPlan.DailyPlan.Timespan.Value;
                lblIsSave.Text = spPanShowPlan.IsSave == true ? "计划已保存" : "计划未保存";

                lblPage.Text = spPanShowPlan.CurrentPage + " / " + spPanShowPlan.TotalPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误:\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 刷新所有数据，根据当前日期
        /// </summary>
        public void RefreshData()
        {
            SetDate(dtDateTime.Value);
        }

        /// <summary>
        /// 设置日期
        /// </summary>
        /// <param name="date"></param>
        private void SetDate(DateTime date)
        {
            dataManager.SetDate(date);

            Init();

            isSale = (bool)dataManager.DailyShowPlan.DailyPlan.IsSalable;

            //  dataManager.SetSale(isSale);

            tsSale.Enabled = true;
            dataManager_DailyPlanIsSaleChanged(this, EventArgs.Empty);


            ////如果当前时间之前的，不能编辑
            //if (dataManager.DailyShowPlan.DailyPlan.PlanDate < DateTime.Now.Date)
            //{
            //    tsPriceSet.Enabled = false;
            //    tsFilmSetting.Enabled = false;
            //    tsSave.Enabled = false;
            //    tsApproved.Enabled = false;
            //    tsDelete.Enabled = false;
            //    tsSale.Enabled = false;

            //    spPanShowPlan.Enabled = false;
            //    flPanFilm.Enabled = false;
            //}
            //else
            //{
            //    tsPriceSet.Enabled = true;
            //    tsFilmSetting.Enabled = true;
            //    tsSave.Enabled = true;
            //    tsApproved.Enabled = true;
            //    tsDelete.Enabled = true;
            //    tsSale.Enabled = true;

            //    spPanShowPlan.Enabled = true;
            //    flPanFilm.Enabled = true;
            //}
        }

        /// <summary>
        /// 读取可选择的电影列表，从数据库更新
        /// </summary>
        public void LoadFilmList()
        {
            dataManager.RefreshFilmList();

            RefreshLoadFilmList(dataManager.GetFilmAndMode());
        }

        /// <summary>
        /// 不从数据库从新读取
        /// </summary>
        public void RefreshLoadFilmList()
        {
            RefreshLoadFilmList(dataManager.RefreshfilmAndFilmModeList);
        }

        /// <summary>
        /// 不从数据库更新
        /// </summary>
        private void RefreshLoadFilmList(List<FilmAndFilmMode> filmAndFilmModeList)
        {
            string[] defineColor = dataManager.GetColor;
            this.flPanFilm.Controls.Clear();
            Color color;

            foreach (var film in filmAndFilmModeList.OrderBy(p => p.FilmId).ToList())
            {
                ColorBorderLabel filmLabel = new ColorBorderLabel(dataManager);
                filmLabel.BackColor = Color.White;

                filmLabel.Width = 138;
                filmLabel.Margin = new Padding(0, 5, 0, 0);
                filmLabel.TextAlign = ContentAlignment.MiddleLeft;
                filmLabel.Font = fontOfFilmLabel;

                if (film.HasMode == true)
                {
                    if (film.Film_FilmModeColorCode != null && film.Film_FilmModeColorCode.Trim() != string.Empty)
                    {
                        try
                        {
                            string[] Array = film.Film_FilmModeColorCode.Split(';');
                            color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
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

                    if (film.HasMode == true && film.Film_FilmModeId != null && film.FilmModeId != null && film.FilmModeName != null)
                        filmLabel.Text = film.FilmName + "(" + film.FilmModeName + ")";
                    else
                        filmLabel.Text = film.FilmName;
                }
                else
                {
                    if (film.ColorCode != null && film.ColorCode.Trim() != string.Empty)
                    {
                        try
                        {
                            string[] Array = film.ColorCode.Split(';');
                            color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
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
                    filmLabel.Text = film.FilmName;
                }


                filmLabel.Tag = film;

                filmLabel.MouseDown += new MouseEventHandler(filmLabel_MouseDown);
                filmLabel.MouseMove += new MouseEventHandler(filmLabel_MouseMove);
                filmLabel.MouseUp += new MouseEventHandler(filmLabel_MouseUp);
                this.flPanFilm.Controls.Add(filmLabel);
            }
        }

        /// <summary>
        /// 读取该日期的放映计划
        /// </summary>
        private void LoadDailyShowPlan()
        {
            try
            {
                spPanShowPlan.DataSource = dataManager.DailyShowPlan;
            }
            catch { }
        }

        /// <summary>
        /// 根据电影方块信息，生成临时电影方块
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private ColorBorderLabel GetNewTempFilmLabel(ColorBorderLabel label)
        {
            FilmAndFilmMode film = label.Tag as FilmAndFilmMode;

            ColorBorderLabel colorBorderLabel = new ColorBorderLabel(dataManager);


            colorBorderLabel.BackColor = label.BackColor;
            colorBorderLabel.BorderColor = label.BorderColor;
            colorBorderLabel.Width = spPanShowPlan.GetFilmLabelWidth(film);
            colorBorderLabel.TextAlign = label.TextAlign;

            colorBorderLabel.Text = label.Text;
            colorBorderLabel.Font = fontOfFilmLabel;
            colorBorderLabel.Tag = dataManager.GetNewShowPlan(film);

            return colorBorderLabel;
        }

        /// <summary>
        /// 将控件保存为图片
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private Bitmap DrawControlToBitmap(Control control)
        {
            int w = 0, h = 0;
            foreach (Control var in control.Controls)
            {
                if (var.Right > w)
                    w = var.Right;
                if (var.Bottom > h)
                    h = var.Bottom;
            }
            w++;
            h++;
            Bitmap bmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bmp);
            using (Brush backColorBrush = new SolidBrush(control.BackColor))
            {
                g.FillRectangle(backColorBrush, new Rectangle(0, 0, bmp.Width, bmp.Height));
                foreach (Control var in control.Controls)
                {
                    using (Bitmap b = new Bitmap(var.Width, var.Height))
                    {
                        var.DrawToBitmap(b, var.ClientRectangle);
                        g.DrawImage(b, var.Location);
                    }
                }
            }
            return bmp;
        }

        #endregion


    }
}

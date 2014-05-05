using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace WinFormUI.SaleTicket
{
    /// <summary>
    /// 影院售票
    /// </summary>
    public partial class frmSaleChoose : Form
    {
        public frmSaleChoose()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private int LVM_SETICONSPACING = 0x1035;

        private void frmSaleChoose_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            panel1.Left = Screen.PrimaryScreen.Bounds.Width > 1024 ? (panel1.Left + (Screen.PrimaryScreen.Bounds.Width - 1024) / 2) : panel1.Left;
            
            //panel2.Width = panel2.Left + panel2.Width;//panel2 Screen.PrimaryScreen.Bounds.Width > 1024 ? (panel2.Left + (Screen.PrimaryScreen.Bounds.Width - 1024) / 2) : panel2.Left;

            //判断是否有进入该模块的权限
            //获取时间选择
            datechooseindex = 1;
            datechoosetotalpage = BindDateChoose(1);

            SendMessage(this.ltvShowChoose.Handle, LVM_SETICONSPACING, 0, 0x10000 * 50 + 75);
            SendMessage(this.ltvHallChoose.Handle, LVM_SETICONSPACING, 0, 0x10000 * 50 + 75);
            SendMessage(this.ltvDateChoose.Handle, LVM_SETICONSPACING, 0, 0x10000 * 50 + 75);
            SendMessage(this.ltvFilmChoose.Handle, LVM_SETICONSPACING, 0, 0x10000 * 50 + 110);
            timer_DateTimeNow.Enabled = true;
            timer_DateTimeNow.Start();

            string timeNumber = DateTime.Now.ToString("HH:mm:ss").Replace(":", "");
            pictureBoxH.Image = Print.Turn(timeNumber.Substring(0, 1));
            pictureBoxHH.Image = Print.Turn(timeNumber.Substring(1, 1));
            pictureBoxM.Image = Print.Turn(timeNumber.Substring(2, 1));
            pictureBoxMM.Image = Print.Turn(timeNumber.Substring(3, 1));
        }

        #region 时间选择

        /// <summary>
        /// 时间选择pageindex
        /// </summary>
        public int datechooseindex;

        /// <summary>
        /// 时间选择总页数
        /// </summary>
        public int datechoosetotalpage;

        /// <summary>
        /// 日计划ID
        /// </summary>
        private string dpid;

        /// <summary>
        /// 日计划日期
        /// </summary>
        public string dpdate;

        /// <summary>
        /// 获取时间选择
        /// </summary>
        private int BindDateChoose(int pageindex)
        {
            int totalpage = 0;
            try
            {
                DataSet ds = Flamingo.BLL.DailyPlan.GetDateChoose(pageindex, 10, out totalpage);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ltvDateChoose.Items.Clear();
                    ltvDateChoose.Columns.Clear();
                    ltvDateChoose.Columns.Add("时间选择", 100, HorizontalAlignment.Center);
                    ltvDateChoose.View = View.LargeIcon;

                    //日期图片保存地址
                    string path = "images/imgs/";
                    string ppath = "";
                    //日期图片底板地址
                    string bpath = "images/imgs/dailyplandate.jpg";
                    Flamingo.Common.Draw draw = new Flamingo.Common.Draw();

                    imgltDateChoose.Images.Clear();
                    ltvDateChoose.LargeImageList = imgltDateChoose;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Name = row["DailyPlanId"].ToString().Trim();
                        item.Tag = (object)DateTime.Parse(row["PlanDate"].ToString()).ToString("MM月dd日");

                        try
                        {
                            //生成日期图片
                            ppath = path + DateTime.Parse(row["PlanDate"].ToString()).ToString("MMdd") + ".jpg";
                            if (!File.Exists(ppath))
                            {
                                draw.CreateImage(DateTime.Parse(row["PlanDate"].ToString()).ToString("MM月dd日"), ppath, bpath);
                                draw.CreateImage(DateTime.Parse(row["PlanDate"].ToString()).ToString("MM月dd日"), ppath.Replace(".", "_."), bpath.Replace(".", "_."));
                            }
                            imgltDateChoose.Images.Add(item.Name, Image.FromFile(ppath));
                            imgltDateChoose.Images.Add(item.Name + "_", Image.FromFile(ppath.Replace(".", "_.")));
                            item.ImageKey = item.Name;
                        }
                        catch
                        {
                            item.Text = DateTime.Parse(row["PlanDate"].ToString()).ToString("MM月dd日");
                        }
                        ltvDateChoose.Items.Add(item);
                    }

                    ltvDateChoose.Items[0].Selected = true;
                    dpid = ltvDateChoose.Items[0].Name;
                    dpdate = ltvDateChoose.Items[0].Tag.ToString();
                    ltvDateChoose.Items[0].ImageKey = dpid + "_";

                    ////获取影片选择
                    BindFilmChoose(1);

                    ////获取影厅选择
                    BindFHallChoose(1);

                    ////获取场次选择
                    BindShowChoose(1);
                }
                else
                {
                    //MessageBox.Show("没有可用日计划");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取日计划失败!" + ex.Message);
            }
            return totalpage;
        }

        /// <summary>
        /// 时间选择上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateUp_Click(object sender, EventArgs e)
        {
            if ((datechooseindex - 1) > 0)
            {
                datechooseindex -= 1;
                BindDateChoose(datechooseindex);
            }
        }

        /// <summary>
        /// 时间选择下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateDown_Click(object sender, EventArgs e)
        {
            if ((datechooseindex + 1) <= datechoosetotalpage)
            {
                datechooseindex += 1;
                BindDateChoose(datechooseindex);
            }
        }

        /// <summary>
        /// 日期选择ltvDateChoose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltvDateChoose_Click(object sender, EventArgs e)
        {
            fid = null;
            fname = null;
            dpdate = null;
            hid = null;

            ListView lv = ((ListView)sender);

            foreach (ListViewItem item in lv.Items)
            {
                item.Checked = false;
                item.ImageKey = item.Name;
            }

            lv.SelectedItems[0].Checked = true;

            //获得当前选中的日期
            dpid = lv.SelectedItems[0].Name;

            //设置影片默认选中时所需的参数
            dpdate = lv.SelectedItems[0].Tag.ToString();

            //改变选中Item的属性
            lv.SelectedItems[0].ImageKey = lv.SelectedItems[0].Name + "_";

            //获取影片选择
            BindFilmChoose(1);

            //获取影厅选择
            BindFHallChoose(1);

            //获取场次选择
            BindShowChoose(1);

            lv.SelectedItems.Clear();

        }

        #endregion

        #region 影片选择

        /// <summary>
        /// 当前影片显示位置
        /// </summary>
        private int filmCurrentIndex = 1;

        /// <summary>
        /// 影片总数
        /// </summary>
        private int filmchoosetotalpage;

        /// <summary>
        /// 获得影片
        /// </summary>
        /// <param name="dailyplanid">日计划ID</param>
        private void BindFilmChoose(int pageindex)
        {
            DataSet ds = Flamingo.BLL.Film.GetFilmChoose(pageindex, 7, out filmchoosetotalpage, dpid, "");

            ltvFilmChoose.Items.Clear();
            ltvFilmChoose.Columns.Clear();

            if (ds.Tables[ds.Tables.Count - 2].Rows.Count > 0)
            {
                ltvFilmChoose.Columns.Add("影片选择", 80, HorizontalAlignment.Center);
                ltvFilmChoose.View = View.LargeIcon;
                ltvFilmChoose.LargeImageList = imgltFilmChoose;
                StringBuilder tooltiptext;
                foreach (DataRow row in ds.Tables[ds.Tables.Count - 2].Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = row["FilmName"].ToString().Trim();
                    item.Name = row["FilmId"].ToString().Trim();
                    tooltiptext = new StringBuilder();
                    tooltiptext.Append("《");
                    tooltiptext.Append(item.Text);
                    tooltiptext.Append("》\r\n导演：");
                    tooltiptext.Append(row["Director"].ToString().Trim());
                    tooltiptext.Append("\r\n演员：");
                    tooltiptext.Append(row["Cast"].ToString().Trim());
                    item.ToolTipText = tooltiptext.ToString();
                    try
                    {
                        if (row["Poster"].ToString().Length == 0)
                        {
                            if (imgltFilmChoose.Images.IndexOfKey(item.Name) < 0)
                                imgltFilmChoose.Images.Add(item.Name, Image.FromFile("images/film/filmNone.jpg"));
                            else
                            { }
                        }
                        else
                        {
                            //Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(row["Poster"].ToString()));
                            byte[] b = (byte[])row["Poster"];
                            Stream s = new MemoryStream(b);
                            imgltFilmChoose.Images.Add(item.Name, System.Drawing.Image.FromStream(s));
                            s.Close();

                        }
                        item.ImageKey = item.Name;
                    }
                    catch
                    { }

                    ltvFilmChoose.Items.Add(item);
                }
                //设置默认选中
                int index = Flamingo.BLL.Setting.GetFilmAuto(dpdate);
                if (index >= 0)
                    ltvFilmChoose.Items[index].Selected = true;

                filmCurrentIndex = pageindex;
            }
        }

        /// <summary>
        /// 影片选择上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFimlUp_Click(object sender, EventArgs e)
        {
            if (filmCurrentIndex - 1 > 0)
            {
                filmCurrentIndex -= 1;
                BindFilmChoose(filmCurrentIndex);
            }
        }

        /// <summary>
        /// 影片选择下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFimlDown_Click(object sender, EventArgs e)
        {
            if (filmCurrentIndex + 1 <= filmchoosetotalpage)
            {
                filmCurrentIndex += 1;
                BindFilmChoose(filmCurrentIndex);
            }
        }

        /// <summary>
        /// 影片ID
        /// </summary>
        private string fid;
        private string fname;

        /// <summary>
        /// 影片选择ltvFilmChoose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltvFilmChoose_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem item = lv.SelectedItems[0];
            if (e.Button == MouseButtons.Left)
            {
                fid = null;
                if (item.Checked == false)
                {
                    foreach (ListViewItem it in lv.Items)
                    {
                        it.Checked = false;
                    }
                    item.Checked = true;
                    fid = item.Name;
                    fname = item.Text;
                }
                else
                {
                    item.Checked = false;
                    fid = null;
                    fname = null;
                    ltvFilmChoose.SelectedItems.Clear();
                }
                BindFHallChoose(1);
                BindShowChoose(1);
            }
            else if (e.Button == MouseButtons.Right)    //设置默认选择
            {
                ContextMenuStrip cms = CreateMouseRightMenu();
                cms.Show(MousePosition.X, MousePosition.Y);
            }
        }

        #region 设置影片默认选择

        /// <summary>
        /// 创建右键Menu项
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateMouseRightMenu()
        {
            int index = Flamingo.BLL.Setting.GetFilmAuto(dpdate);
            string msg = string.Empty;
            object tag = new object();
            if (index >= 0)
            {
                msg = "取消默认选中";
                tag = "取消";
            }
            else
            {
                msg = "设为默认选中";
                tag = "设置";
            }
            ContextMenuStrip cms = new ContextMenuStrip();
            ToolStripItem item = cms.Items.Add(msg, null, this.Menu_Click);
            item.Tag = tag;
            return cms;
        }

        /// <summary>
        /// 设置Menu项点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, EventArgs e)
        {
            string msg = "";
            bool tf = false;
            ToolStripItem item = (ToolStripItem)sender;
            int index = -1;
            if (item.Tag.ToString() == "设置")
            {
                index = ltvFilmChoose.SelectedItems[0].Index;
            }
            //else if (item.Tag.ToString() == "cancel")
            //{
            //    index = -1;
            //}
            if (dpdate != null)
            {
                tf = Flamingo.BLL.Setting.SetFilmAuto(dpdate, index, out msg);
            }
            if (tf == true)
            {
                MessageBox.Show(item.Tag.ToString() + "成功");
            }
            else
            {
                //MessageBox.Show(msg);
            }
            ltvFilmChoose.SelectedItems.Clear();
        }

        #endregion

        #endregion

        #region 影厅选择

        /// <summary>
        /// 当前影厅显示位置
        /// </summary>
        private int hallCurrentIndex;
        /// <summary>
        /// 影厅总数
        /// </summary>
        private int hallItemsCount;

        private string hid;

        /// <summary>
        /// 获得影厅
        /// </summary>
        private void BindFHallChoose(int pageindex)
        {
            DataSet ds = Flamingo.BLL.ShowPlan.GetHallByDailyPlan(dpid, fname, pageindex, 10, out  hallItemsCount);

            ltvHallChoose.Items.Clear();
            ltvHallChoose.Columns.Clear();
            if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
            {
                ltvHallChoose.Columns.Add("影厅选择", 80, HorizontalAlignment.Center);
                ltvHallChoose.View = View.LargeIcon;

                //日期图片保存地址
                string path = "images/imgs/";
                string ppath = "";
                //日期图片底板地址
                string bpath = "images/imgs/dailyplandate.jpg";
                Flamingo.Common.Draw draw = new Flamingo.Common.Draw();

                imgltHallChoose.Images.Clear();
                ltvHallChoose.LargeImageList = imgltHallChoose;
                foreach (DataRow row in ds.Tables[ds.Tables.Count - 1].Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Name = row["HallID"].ToString().Trim();
                    try
                    {
                        //生成厅图片
                        ppath = path + row["HallName"].ToString().Trim() + ".jpg";
                        if (!File.Exists(ppath))
                        {
                            draw.CreateImage(row["HallName"].ToString().Trim(), ppath, bpath);
                            draw.CreateImage(row["HallName"].ToString().Trim(), ppath.Replace(".", "_."), bpath.Replace(".", "_."));
                        }
                        imgltHallChoose.Images.Add(item.Name, Image.FromFile(ppath));
                        imgltHallChoose.Images.Add(item.Name + "_", Image.FromFile(ppath.Replace(".", "_.")));
                        item.ImageKey = item.Name;
                    }
                    catch
                    {
                        item.Text = item.Text = row["HallName"].ToString().Trim();
                    }

                    ltvHallChoose.Items.Add(item);
                }
                ltvHallChoose.Items[0].Selected = true;
                hallCurrentIndex = pageindex;
            }
        }

        /// <summary>
        /// 影厅选择ltvHallChoose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltvHallChoose_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem item = lv.SelectedItems[0];

            foreach (ListViewItem it in lv.Items)
            {
                it.ImageKey = it.Name;
            }

            hid = null;
            if (item.Checked == false)
            {
                foreach (ListViewItem it in lv.Items)
                {
                    it.Checked = false;
                }
                item.Checked = true;
                hid = item.Name;
                //改变选中Item的属性
                item.ImageKey = item.Name + "_";
            }
            else
            {
                item.Checked = false;
                hid = null;
                //改变选中Item的属性
                item.ImageKey = item.Name;
            }
            //fid = ltvFilmChoose.CheckedItems.Count > 0 ? ltvFilmChoose.CheckedItems[0].Name : null;
            if (!string.IsNullOrEmpty(hid))
                hid = hid.Trim().Length == 2 ? hid : (" " + hid);

            BindShowChoose(1);
            lv.SelectedItems.Clear();
        }

        /// <summary>
        /// 影厅选择上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHallUp_Click(object sender, EventArgs e)
        {
            if (hallCurrentIndex - 1 > 0)
            {
                hallCurrentIndex -= 1;
                BindFHallChoose(hallCurrentIndex);
            }
        }

        /// <summary>
        /// 影厅选择下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHallDown_Click(object sender, EventArgs e)
        {
            if (hallCurrentIndex + 1 <= hallItemsCount)
            {
                hallCurrentIndex += 1;
                BindFHallChoose(hallCurrentIndex);
            }
        }

        #endregion

        #region 场次选择
        private int showcurrentindex;
        private int showtotalcount;

        /// <summary>
        /// 场次选择
        /// </summary>
        /// <param name="dailyplanid">日计划ID</param>
        /// <param name="filmid">影片ID</param>
        /// <param name="hallid">影厅ID</param>
        private void BindShowChoose(int pageindex)
        {
            DataSet ds = Flamingo.BLL.ShowPlan.GetShowPlan(dpid, fname, hid, pageindex, 10, out showtotalcount);
            ltvShowChoose.Items.Clear();
            ltvShowChoose.Columns.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ltvShowChoose.Columns.Add("场次选择", 80, HorizontalAlignment.Center);
                ltvShowChoose.View = View.LargeIcon;

                //日期图片保存地址
                string path = "images/imgs/showplan/";
                string ppath = "";
                //日期图片底板地址
                string bpath = "images/imgs/dailyplandate.jpg";
                Flamingo.Common.Draw draw = new Flamingo.Common.Draw();

                imgltShowChoose.Images.Clear();
                ltvShowChoose.LargeImageList = imgltShowChoose;

                string imgname = string.Empty;
                foreach (DataRow row in ds.Tables[ds.Tables.Count - 1].Rows)
                {
                    ListViewItem item = new ListViewItem();

                    item.Name = row["ShowPlanID"].ToString().Trim();
                    item.Tag = row["ShowPlanTime"].ToString();
                    try
                    {
                        //生成场次图片
                        imgname = row["ShowPlanTime"].ToString().Trim().Replace(":", "");
                        ppath = path + imgname + ".jpg";
                        if (!File.Exists(ppath))
                        {
                            draw.CreateImage(row["ShowPlanTime"].ToString().Trim(), ppath, bpath);
                        }
                        imgltShowChoose.Images.Add(item.Name, Image.FromFile(ppath));
                        item.ImageKey = item.Name;
                    }
                    catch
                    {
                        item.Text = item.Text = row["ShowPlanTime"].ToString().Trim();
                    }
                    ltvShowChoose.Items.Add(item);
                }
                //ltvShowChoose.Items[0].Selected = true;
                showcurrentindex = pageindex;
            }
        }

        /// <summary>
        /// 选择影厅 进入座位选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltvShowChoose_Click(object sender, EventArgs e)
        {
            ListViewItem item = ltvShowChoose.SelectedItems[0];


            if (Application.OpenForms["FrmTicket"] != null)
            {
                Form fm = Application.OpenForms["FrmTicket"];
                //fm.Close();
                fm.Activate();
                if (((FrmTicket)fm).ShowplanId != item.Name)
                    ((FrmTicket)fm).ReSetParam(item.Name, dpdate, item.Tag.ToString());
            }
            else
            {
                FrmTicket form = new FrmTicket(item.Name, dpdate, item.Tag.ToString());
                form.Text = "座位选择";
                //form.MdiParent = Program._Main;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        private void btnShowUp_Click(object sender, EventArgs e)
        {
            if (showcurrentindex - 1 > 0)
            {
                showcurrentindex -= 1;
                BindShowChoose(showcurrentindex);
            }
        }

        private void btnShowDown_Click(object sender, EventArgs e)
        {
            if (showcurrentindex + 1 <= showtotalcount)
            {
                showcurrentindex += 1;
                BindShowChoose(showcurrentindex);
            }
        }


        #endregion

        private void timer_DateTimeNow_Tick(object sender, EventArgs e)
        {
            string timeNumber = DateTime.Now.ToString("HH:mm:ss").Replace(":", "");
            pictureBoxH.Image = Print.Turn(timeNumber.Substring(0, 1));
            pictureBoxHH.Image = Print.Turn(timeNumber.Substring(1, 1));
            pictureBoxM.Image = Print.Turn(timeNumber.Substring(2, 1));
            pictureBoxMM.Image = Print.Turn(timeNumber.Substring(3, 1));
        }

        private void btnCloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}

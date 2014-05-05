using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.Right;
using Flamingo.ShowPlanManage;
using Flamingo.TheaterManage;
using Flamingo.FilmManage;
using Flamingo.TicketManage;
using System.Reflection;
using System.Threading;
using System.Drawing;

namespace WinFormUI
{
    public delegate void OnLineUserOpt();

    public partial class FrmMain : Form
    {
        static OnLineUserLog g_onlineUser = null;
        private Thread OnLineUserThread;
        bool g_bLinkServer = true;
        bool g_bFirstLinkServer = true;

        private int childFormNumber = 0;
        public static Flamingo.Right.User curUser = null;
        //lzz
        public static Flamingo.TemplateCore.Template template = null;

        private ToolStrip toolStrip;

        private frmMain frmSP;

        public FrmMain()
        {
            InitializeComponent();

            //toolTip = new ToolTip();
            //toolTip.AutoPopDelay = 5000;
            //toolTip.InitialDelay = 1000;
            //toolTip.ReshowDelay = 500;
            //toolTip.ShowAlways = true;

            //toolTip.SetToolTip(btnMin, "最小化");
            //toolTip.SetToolTip(btnClose, "关闭");

            // 预读，优化性能
            PreLoadShowPlanForm();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ClearCheckState()
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton6.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;
            toolStripButton1.Image = WinFormUI.Properties.Resources.theater1;
            toolStripButton2.Image = WinFormUI.Properties.Resources.showplan1;
            toolStripButton3.Image = WinFormUI.Properties.Resources.film1;
            toolStripButton4.Image = WinFormUI.Properties.Resources.ticket1;
            toolStripButton5.Image = WinFormUI.Properties.Resources.report1;
            toolStripButton6.Image = WinFormUI.Properties.Resources.voucher1;
            toolStripButton7.Image = WinFormUI.Properties.Resources.template1;
            toolStripButton8.Image = WinFormUI.Properties.Resources.user1;
            toolStripButton9.Image = WinFormUI.Properties.Resources.seatingchart1;
        }

        private void CheckSubToolStripState(ToolStripItem ts)
        {
            switch (ts.Name)
            {
                case "frmTheaterInfoManage":
                    ts.Image = WinFormUI.Properties.Resources.theaterinfo2;
                    break;
                case "frmFilmHallManage":
                    ts.Image = WinFormUI.Properties.Resources.hall2;
                    break;
                case "frmTaxManage":
                    ts.Image = WinFormUI.Properties.Resources.tax2;
                    break;
                case "frmUploadSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.upload2;
                    break;
                case "frmTimeSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.timesetting2;
                    break;
                case "frmFareSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.price2;
                    break;
                case "frmShowTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.showtype2;
                    break;
                case "frmDiscountManage":
                    ts.Image = WinFormUI.Properties.Resources.discount2;
                    break;
                case "frmFilmInfoManage":
                    ts.Image = WinFormUI.Properties.Resources.filminfo2;
                    break;
                case "frmFilmCategoryManage":
                    ts.Image = WinFormUI.Properties.Resources.filmcategory2;
                    break;
                case "frmFilmAreaManage":
                    ts.Image = WinFormUI.Properties.Resources.filmarea2;
                    break;
                case "frmFilmModeManage":
                    ts.Image = WinFormUI.Properties.Resources.filmmode2;
                    break;
                case "frmFilmDownloadManage":
                    ts.Image = WinFormUI.Properties.Resources.filmdownload2;
                    break;
                case "frmDownloadSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.downloadmanage2;
                    break;
                case "frmFilmDownloadSetting":
                    ts.Image = WinFormUI.Properties.Resources.downloadsetting2;
                    break;
                case "frmCustomerManage":
                    ts.Image = WinFormUI.Properties.Resources.customermanage2;
                    break;
                case "frmCustomerTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.customertype2;
                    break;
                case "frmDebtManage":
                    ts.Image = WinFormUI.Properties.Resources.debt2;
                    break;
                case "frmVoucherTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.vouchertype2;
                    break;
                case "frmVoucherSubType":
                    ts.Image = WinFormUI.Properties.Resources.subtype2;
                    break;
                case "frmVoucherBatchManage":
                    ts.Image = WinFormUI.Properties.Resources.voucherbatch2;
                    break;
                case "FrmSeatChartImport":
                    ts.Image = WinFormUI.Properties.Resources.seatingchartimport2;
                    break;
                case "FrmSeatChartResetType":
                    ts.Image = WinFormUI.Properties.Resources.seattype2;
                    break;
                case "FrmSeatChartResetBlock":
                    ts.Image = WinFormUI.Properties.Resources.block2;
                    break;
                case "UserPermission":
                    ts.Image = WinFormUI.Properties.Resources.basicinfo2;
                    break;
                case "RoleAndUser":
                    ts.Image = WinFormUI.Properties.Resources.userrole2;
                    break;
                case "RoleSetting":
                    ts.Image = WinFormUI.Properties.Resources.rolepermission2;
                    break;
                case "UserRightSetting":
                    ts.Image = WinFormUI.Properties.Resources.userpermission2;
                    break;
            }
        }

        private void ClearSubToolStripState(ToolStripItem ts)
        {
            switch (ts.Name)
            {
                case "frmTheaterInfoManage":
                    ts.Image = WinFormUI.Properties.Resources.theaterinfo1;
                    break;
                case "frmFilmHallManage":
                    ts.Image = WinFormUI.Properties.Resources.hall1;
                    break;
                case "frmTaxManage":
                    ts.Image = WinFormUI.Properties.Resources.tax1;
                    break;
                case "frmUploadSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.upload1;
                    break;
                case "frmTimeSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.timesetting1;
                    break;
                case "frmFareSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.price1;
                    break;
                case "frmShowTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.showtype1;
                    break;
                case "frmDiscountManage":
                    ts.Image = WinFormUI.Properties.Resources.discount1;
                    break;
                case "frmFilmInfoManage":
                    ts.Image = WinFormUI.Properties.Resources.filminfo1;
                    break;
                case "frmFilmCategoryManage":
                    ts.Image = WinFormUI.Properties.Resources.filmcategory1;
                    break;
                case "frmFilmAreaManage":
                    ts.Image = WinFormUI.Properties.Resources.filmarea1;
                    break;
                case "frmFilmModeManage":
                    ts.Image = WinFormUI.Properties.Resources.filmmode1;
                    break;
                case "frmFilmDownloadManage":
                    ts.Image = WinFormUI.Properties.Resources.filmdownload1;
                    break;
                case "frmDownloadSettingManage":
                    ts.Image = WinFormUI.Properties.Resources.downloadmanage1;
                    break;
                case "frmFilmDownloadSetting":
                    ts.Image = WinFormUI.Properties.Resources.downloadsetting1;
                    break;
                case "frmCustomerManage":
                    ts.Image = WinFormUI.Properties.Resources.customermanage1;
                    break;
                case "frmCustomerTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.customertype1;
                    break;
                case "frmDebtManage":
                    ts.Image = WinFormUI.Properties.Resources.debt1;
                    break;
                case "frmVoucherTypeManage":
                    ts.Image = WinFormUI.Properties.Resources.vouchertype1;
                    break;
                case "frmVoucherSubType":
                    ts.Image = WinFormUI.Properties.Resources.subtype1;
                    break;
                case "frmVoucherBatchManage":
                    ts.Image = WinFormUI.Properties.Resources.voucherbatch1;
                    break;
                case "FrmSeatChartImport":
                    ts.Image = WinFormUI.Properties.Resources.seatingchartimport1;
                    break;
                case "FrmSeatChartResetType":
                    ts.Image = WinFormUI.Properties.Resources.seattype1;
                    break;
                case "FrmSeatChartResetBlock":
                    ts.Image = WinFormUI.Properties.Resources.block1;
                    break;
                case "UserPermission":
                    ts.Image = WinFormUI.Properties.Resources.basicinfo1;
                    break;
                case "RoleAndUser":
                    ts.Image = WinFormUI.Properties.Resources.userrole1;
                    break;
                case "RoleSetting":
                    ts.Image = WinFormUI.Properties.Resources.rolepermission1;
                    break;
                case "UserRightSetting":
                    ts.Image = WinFormUI.Properties.Resources.userpermission1;
                    break;
            }
        }

        #region 按钮单击事件

        private void 放映计划toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton2.Checked = true;
            if (toolStripButton2.Checked) toolStripButton2.Image = WinFormUI.Properties.Resources.showplan2;
            CloseSubToolSttip();
            frmSP.WindowState = FormWindowState.Maximized;
            frmSP.MdiParent = this;
            frmSP.BeginShow();
            frmSP.FormClosed += new FormClosedEventHandler(frmSP_FormClosed);
        }

        private void 影院售票toolStripButton4_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton4.Checked = true;
            if (toolStripButton4.Checked) toolStripButton4.Image = WinFormUI.Properties.Resources.ticket2;
            CloseSubToolSttip();
            TemplateUI.TemplatePrint form = new TemplateUI.TemplatePrint();
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                template = form.Template1;
                SaleTicket.frmSaleChoose frm = new SaleTicket.frmSaleChoose();
                OpenFrame(frm, "场次选择");
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("未正确选择打印机和票版 可能无法打印影票");
                template = form.Template1;
                SaleTicket.frmSaleChoose frm = new SaleTicket.frmSaleChoose();
                OpenFrame(frm, "场次选择");
            }
        }

        private void 统计分析toolStripButton5_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton5.Checked = true;
            if (toolStripButton5.Checked) toolStripButton5.Image = WinFormUI.Properties.Resources.report2;
            CloseSubToolSttip();
            Reporting.FrmReporting form = new Reporting.FrmReporting();
            OpenFrame(form, "统计分析");
        }

        private void 影片管理toolStripButton3_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton3.Checked = true;
            if (toolStripButton3.Checked) toolStripButton3.Image = WinFormUI.Properties.Resources.film2;
            LoadFilmManageToolStrip();
            FrmMain.ActiveForm.BackgroundImage = WinFormUI.Properties.Resources.BgImage;
            FrmMain.ActiveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PreLoadShowPlanForm();
        }

        private void 影院管理toolStripButton1_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton1.Checked = true;
            if (toolStripButton1.Checked) toolStripButton1.Image = WinFormUI.Properties.Resources.theater2;
            LoadTheaterManageToolStrip();
            FrmMain.ActiveForm.BackgroundImage = WinFormUI.Properties.Resources.BgImage;
            FrmMain.ActiveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PreLoadShowPlanForm();
        }

        private void 座位图工具toolStripButton9_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton9.Checked = true;
            if (toolStripButton9.Checked) toolStripButton9.Image = WinFormUI.Properties.Resources.seatingchart2;
            LoadSeatingChartToolStrip();
            FrmMain.ActiveForm.BackgroundImage = WinFormUI.Properties.Resources.BgImage;
            FrmMain.ActiveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PreLoadShowPlanForm();
        }

        private void 用户管理toolStripButton8_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton8.Checked = true;
            if (toolStripButton8.Checked) toolStripButton8.Image = WinFormUI.Properties.Resources.user2;
            LoadUserManageToolStrip();
            FrmMain.ActiveForm.BackgroundImage = WinFormUI.Properties.Resources.BgImage;
            FrmMain.ActiveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PreLoadShowPlanForm();
        }

        private void 票版工具toolStripButton7_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton7.Checked = true;
            if (toolStripButton7.Checked) toolStripButton7.Image = WinFormUI.Properties.Resources.template2;
            CloseSubToolSttip();
            TemplateUI.TemplateListForm frm = new TemplateUI.TemplateListForm();
            OpenFrame(frm, "票版管理");
        }

        private void 票券管理toolStripButton6_Click(object sender, EventArgs e)
        {
            ClearCheckState();
            toolStripButton6.Checked = true;
            if (toolStripButton6.Checked) toolStripButton6.Image = WinFormUI.Properties.Resources.voucher2;
            LoadTicketManageToolStrip();
            FrmMain.ActiveForm.BackgroundImage = WinFormUI.Properties.Resources.BgImage;
            PreLoadShowPlanForm();
        }

        #endregion

        #region 页面缓存读取

        private void PreLoadShowPlanForm()
        {
            frmSP = new frmMain();
            frmSP.WindowState = FormWindowState.Maximized;

            frmSP.BeginPreLoad();
        }

        //预读，优化性能
        private void frmSP_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreLoadShowPlanForm();
        }

        private void OpenFrame(Form form, string szFrameTitle)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
                if (childForm.Text == (szFrameTitle))
                {
                    //childForm.Show();
                    childForm.Activate();
                    return;
                }
                else
                {
                    //childForm.Close();
                }
            }
            //FrmOnlineUserClear form = new FrmOnlineUserClear();
            form.Text = szFrameTitle;
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RightUI.LoginForm LgFrm = new RightUI.LoginForm();
            if (DialogResult.OK == LgFrm.ShowDialog())
            {
                curUser = LgFrm.User;
                timer_LinkServer.Enabled = true;
                
                //模块权限判断
                if (!curUser.HavePermission(Permissions.TheaterManage)) toolStripButton1.Enabled = false;
                if (!curUser.HavePermission(Permissions.Schedules)) toolStripButton2.Enabled = false;
                if (!curUser.HavePermission(Permissions.FilmManage)) toolStripButton3.Enabled = false;
                if (!curUser.HavePermission(Permissions.TicketSelling)) toolStripButton4.Enabled = false;
                if (!curUser.HavePermission(Permissions.Report)) toolStripButton5.Enabled = false;
                if (!curUser.HavePermission(Permissions.VoucherManager)) toolStripButton6.Enabled = false;
                if (!curUser.HavePermission(Permissions.TemplateManager)) toolStripButton7.Enabled = false;
                if (!curUser.HavePermission(Permissions.EmployeeInformation)) toolStripButton8.Enabled = false;
                if (!curUser.HavePermission(Permissions.SeatingChat)) toolStripButton9.Enabled = false;
            }
            else
            {
                LgFrm.Close();
                LgFrm.Dispose();
                Close();
                Dispose();
            }
        }

        #region 生成二级菜单

        private void LoadTheaterManageToolStrip()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                childForm.MdiParent = null;
            }

            CreateSubToolStrip();

            toolStrip.Items.Clear();

            toolStrip.Items.Add("影院信息管理").Name = "frmTheaterInfoManage";
            toolStrip.Items.Add("影厅信息管理").Name = "frmFilmHallManage";
            toolStrip.Items.Add("税费维护").Name = "frmTaxManage";
            toolStrip.Items.Add("数据上报").Name = "frmUploadSettingManage";
            toolStrip.Items.Add("经营时间").Name = "frmTimeSettingManage";
            toolStrip.Items.Add("票价维护").Name = "frmFareSettingManage";
            toolStrip.Items.Add("场次类型").Name = "frmShowTypeManage";
            toolStrip.Items.Add("特价维护").Name = "frmDiscountManage";
            //toolStrip.Items.Add("系统参数设置").Name = "frmSystemParameterManage";
            //toolStrip.Items.Add("数据库备份/恢复").Name = "frmBackupManage";

            foreach (ToolStripItem ts in toolStrip.Items)
            {
                ts.Tag = "TheaterManage";
                ts.Click += new EventHandler(toolStrip_Click);
                ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                ts.ImageScaling = ToolStripItemImageScaling.None;
                switch (ts.Name)
                {
                    case "frmTheaterInfoManage":
                        ts.Image = WinFormUI.Properties.Resources.theaterinfo1;
                        if (!curUser.HavePermission(Permissions.TheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmHallManage":
                        ts.Image = WinFormUI.Properties.Resources.hall1;
                        if (!curUser.HavePermission(Permissions.HallTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmTaxManage":
                        ts.Image = WinFormUI.Properties.Resources.tax1;
                        if (!curUser.HavePermission(Permissions.TaxTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmUploadSettingManage":
                        ts.Image = WinFormUI.Properties.Resources.upload1;
                        if (!curUser.HavePermission(Permissions.UploadSettingTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmTimeSettingManage":
                        ts.Image = WinFormUI.Properties.Resources.timesetting1;
                        if (!curUser.HavePermission(Permissions.TimeSettingTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmFareSettingManage":
                        ts.Image = WinFormUI.Properties.Resources.price1;
                        if (!curUser.HavePermission(Permissions.PriceTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmShowTypeManage":
                        ts.Image = WinFormUI.Properties.Resources.showtype1;
                        if (!curUser.HavePermission(Permissions.ShowtypeTheaterInformation)) ts.Enabled = false;
                        break;
                    case "frmDiscountManage":
                        ts.Image = WinFormUI.Properties.Resources.discount1;
                        if (!curUser.HavePermission(Permissions.DiscountTheaterInformation)) ts.Enabled = false;
                        break;
                    //case "frmSystemParameterManage":
                    //    ts.Image = WinFormUI.Properties.Resources.config1;
                    //    if (!curUser.HavePermission(Permissions.TheaterInformation)) ts.Enabled = false;
                    //    break;
                    case "frmBackupManage": 
                        ts.Image = WinFormUI.Properties.Resources.config1;
                        //if (!curUser.HavePermission(Permissions.DiscountTheaterInformation)) ts.Enabled = false;
                        break;
                }
            }

            ShowSubToolStrip();
        }

        private void LoadFilmManageToolStrip()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                childForm.MdiParent = null;
            }

            CreateSubToolStrip();

            toolStrip.Items.Clear();

            toolStrip.Items.Add("影片信息维护").Name = "frmFilmInfoManage";
            toolStrip.Items.Add("影片介质维护").Name = "frmFilmCategoryManage";
            toolStrip.Items.Add("影片类型维护").Name = "frmFilmTypeManage";
            toolStrip.Items.Add("影片产地维护").Name = "frmFilmAreaManage";
            toolStrip.Items.Add("影片放映模式").Name = "frmFilmModeManage";
            toolStrip.Items.Add("影片下载").Name = "frmFilmDownloadManage";
            toolStrip.Items.Add("下载地址维护").Name = "frmDownloadSettingManage";
            toolStrip.Items.Add("下载参数维护").Name = "frmFilmDownloadSetting";

            foreach (ToolStripItem ts in toolStrip.Items)
            {
                ts.Tag = "FilmManage";
                ts.Click += new EventHandler(toolStrip_Click);
                ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                ts.ImageScaling = ToolStripItemImageScaling.None;
                switch (ts.Name)
                {
                    case "frmFilmInfoManage":
                        ts.Image = WinFormUI.Properties.Resources.filminfo1;
                        if (!curUser.HavePermission(Permissions.FilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmCategoryManage":
                        ts.Image = WinFormUI.Properties.Resources.filmcategory1;
                        if (!curUser.HavePermission(Permissions.CategoryFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmTypeManage":
                        ts.Image = WinFormUI.Properties.Resources.filmcategory1;
                        if (!curUser.HavePermission(Permissions.CategoryFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmAreaManage":
                        ts.Image = WinFormUI.Properties.Resources.filmarea1;
                        if (!curUser.HavePermission(Permissions.AreaFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmModeManage":
                        ts.Image = WinFormUI.Properties.Resources.filmmode1;
                        if (!curUser.HavePermission(Permissions.PlayModeFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmDownloadManage":
                        ts.Image = WinFormUI.Properties.Resources.filmdownload1;
                        if (!curUser.HavePermission(Permissions.DownloadFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmDownloadSettingManage":
                        ts.Image = WinFormUI.Properties.Resources.downloadmanage1;
                        if (!curUser.HavePermission(Permissions.DownloadSettingFilmInformation)) ts.Enabled = false;
                        break;
                    case "frmFilmDownloadSetting":
                        ts.Image = WinFormUI.Properties.Resources.downloadsetting1;
                        if (!curUser.HavePermission(Permissions.DownloadSettingFilmInformation)) ts.Enabled = false;
                        break;
                }
            }

            ShowSubToolStrip();
        }

        private void LoadTicketManageToolStrip()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                childForm.MdiParent = null;
            }

            CreateSubToolStrip();

            toolStrip.Items.Clear();
            toolStrip.Items.Add("客户信息维护").Name = "frmCustomerManage";
            toolStrip.Items.Add("客户类型维护").Name = "frmCustomerTypeManage";
            toolStrip.Items.Add("欠款信息维护").Name = "frmDebtManage";
            toolStrip.Items.Add("票券类型维护").Name = "frmVoucherTypeManage";
            toolStrip.Items.Add("票卷券类维护").Name = "frmVoucherSubType";
            toolStrip.Items.Add("票券批次维护").Name = "frmVoucherBatchManage";
            //toolStrip.Items.Add("票卷打印").Name = "frmFilmDownloadSetting";

            foreach (ToolStripItem ts in toolStrip.Items)
            {
                ts.Tag = "TicketManage";
                ts.Click += new EventHandler(toolStrip_Click);
                ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                ts.ImageScaling = ToolStripItemImageScaling.None;
                switch (ts.Name)
                {
                    case "frmCustomerManage":
                        ts.Image = WinFormUI.Properties.Resources.customermanage1;
                        if (!curUser.HavePermission(Permissions.CustomerManager)) ts.Enabled = false;
                        break;
                    case "frmCustomerTypeManage":
                        ts.Image = WinFormUI.Properties.Resources.customertype1;
                        if (!curUser.HavePermission(Permissions.CustomerTypeManager)) ts.Enabled = false;
                        break;
                    case "frmDebtManage":
                        ts.Image = WinFormUI.Properties.Resources.debt1;
                        if (!curUser.HavePermission(Permissions.DebtManager)) ts.Enabled = false;
                        break;
                    case "frmVoucherTypeManage":
                        ts.Image = WinFormUI.Properties.Resources.vouchertype1;
                        if (!curUser.HavePermission(Permissions.VoucherTypeManager)) ts.Enabled = false;
                        break;
                    case "frmVoucherSubType":
                        ts.Image = WinFormUI.Properties.Resources.subtype1;
                        if (!curUser.HavePermission(Permissions.VoucherSubTypeManager)) ts.Enabled = false;
                        break;
                    case "frmVoucherBatchManage":
                        ts.Image = WinFormUI.Properties.Resources.voucherbatch1;
                        if (!curUser.HavePermission(Permissions.VoucherBatchManager)) ts.Enabled = false;
                        break;
                }
            }

            ToolStripDropDownButton dropDownButton = new ToolStripDropDownButton("票券查询统计");
            toolStrip.Items.Add(dropDownButton);

            dropDownButton.DropDownItems.Add("影院票券销售统计").Name = "frmTicketSaleStatistic";
            dropDownButton.DropDownItems.Add("影院票券使用情况统计").Name = "frmBestowCircsStatManage";
            dropDownButton.DropDownItems.Add("影院单批次票券使用情况统计").Name = "frmSingleVoucherBatch";
            dropDownButton.DropDownItems.Add("单用户票券使用情况统计").Name = "frmChangeManage";

            foreach (ToolStripItem ts in dropDownButton.DropDownItems)
            {
                ts.Tag = "TicketManage";
                ts.Click += new EventHandler(toolStrip_Click);
            }

            ShowSubToolStrip();
        }

        private void LoadSeatingChartToolStrip()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                childForm.MdiParent = null;
            }

            CreateSubToolStrip();

            toolStrip.Items.Clear();

            toolStrip.Items.Add("座位图导入").Name = "FrmSeatChartImport";
            toolStrip.Items.Add("座位类型编辑").Name = "FrmSeatChartResetType";
            toolStrip.Items.Add("座位区域编辑").Name = "FrmSeatChartResetBlock";

            foreach (ToolStripItem ts in toolStrip.Items)
            {
                ts.Tag = "SeatingChart";
                switch (ts.Name)
                {
                    case "FrmSeatChartImport":
                        ts.Click += new EventHandler(座位图导入ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.seatingchartimport1;
                        if (!curUser.HavePermission(Permissions.ImportSeatingChat)) ts.Enabled = false;
                        break;
                    case "FrmSeatChartResetType":
                        ts.Click += new EventHandler(座位类型编辑ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.seattype1;
                        if (!curUser.HavePermission(Permissions.EditStateSeatingChat)) ts.Enabled = false;
                        break;
                    case "FrmSeatChartResetBlock":
                        ts.Click += new EventHandler(座位区域编辑ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.block1;
                        if (!curUser.HavePermission(Permissions.BlockSeatingChat)) ts.Enabled = false;
                        break;
                }
            }

            ShowSubToolStrip();
        }

        private void 座位图导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            FrmSeatChartImport form = new FrmSeatChartImport();
            OpenFrame(form, "座位图导入");
        }

        private void 座位类型编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            FrmSeatChartResetType form = new FrmSeatChartResetType();
            OpenFrame(form, "座位类型编辑");
        }

        private void 座位区域编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            FrmSeatChartResetBlock form = new FrmSeatChartResetBlock();
            OpenFrame(form, "座位区域编辑");
        }

        private void LoadUserManageToolStrip()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                childForm.MdiParent = null;
            }

            CreateSubToolStrip();

            toolStrip.Items.Clear();

            toolStrip.Items.Add("基本信息维护").Name = "UserPermission";
            toolStrip.Items.Add("角色用户管理").Name = "RoleAndUser";
            toolStrip.Items.Add("角色权限管理").Name = "RoleSetting";
            toolStrip.Items.Add("用户权限管理").Name = "UserRightSetting";

            foreach (ToolStripItem ts in toolStrip.Items)
            {
                ts.Tag = "SeatingChart";
                switch (ts.Name)
                {
                    case "UserPermission":
                        ts.Click += new EventHandler(基本信息维护ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.basicinfo1;
                        if (!curUser.HavePermission(Permissions.UserInformation)) ts.Enabled = false;
                        break;
                    case "RoleAndUser":
                        ts.Click += new EventHandler(角色用户管理ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.userrole1;
                        if (!curUser.HavePermission(Permissions.RoleUserInformation)) ts.Enabled = false;
                        break;
                    case "RoleSetting":
                        ts.Click += new EventHandler(角色权限管理ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.rolepermission1;
                        if (!curUser.HavePermission(Permissions.RolePermissionInformation)) ts.Enabled = false;
                        break;
                    case "UserRightSetting":
                        ts.Click += new EventHandler(用户权限管理ToolStripMenuItem_Click);
                        ts.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        ts.ImageScaling = ToolStripItemImageScaling.None;
                        ts.Image = WinFormUI.Properties.Resources.userpermission1;
                        if (!curUser.HavePermission(Permissions.UserPermissionInformation)) ts.Enabled = false;
                        break;
                }
            }

            ShowSubToolStrip();
        }

        private void 基本信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            RightUI.UserPermission FrmUP = new RightUI.UserPermission();
            OpenFrame(FrmUP, "基本信息维护");
        }

        private void 角色用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            RightUI.RoleAndUser roleAndUser = new RightUI.RoleAndUser();
            OpenFrame(roleAndUser, "角色用户管理");
        }

        private void 角色权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            RightUI.RoleSetting FrmRole = new RightUI.RoleSetting();
            OpenFrame(FrmRole, "角色权限管理");
        }

        private void 用户权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = sender as ToolStripItem;
            CheckSubToolStripState(ts);
            RightUI.UserRightSetting FrmUR = new RightUI.UserRightSetting();
            OpenFrame(FrmUR, "用户权限管理");
        }

        private void CreateSubToolStrip()
        {
            if (toolStrip == null)
            {
                toolStrip = new ToolStrip();
                toolStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                toolStrip.Dock = DockStyle.Left;
                toolStrip.GripStyle = ToolStripGripStyle.Hidden;
                toolStrip.AutoSize = false;
                toolStrip.Size = new System.Drawing.Size(121, 1024);
                //toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(218)))), ((int)(((byte)(248)))));
                toolStrip.BackgroundImage = WinFormUI.Properties.Resources.secondmenu;
                toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                toolStrip.Hide();
                this.Controls.Add(toolStrip);
                toolStrip.BringToFront();
                toolStrip.Show();
            }
        }

        private void CloseSubToolSttip()
        {
            if (toolStrip != null)
            {
                this.Controls.Remove(toolStrip);
                toolStrip = null;
            }
        }

        private void ShowSubToolStrip()
        {
            toolStrip.Refresh();
            this.Refresh();
        }

        #endregion

        private void toolStrip_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                    childForm.MdiParent = null;
                }

                ToolStripItem ts = sender as ToolStripItem;
                Form frm = (Form)Assembly.Load(Assembly.GetExecutingAssembly().FullName).CreateInstance("Flamingo." + ts.Tag.ToString() + "." + ts.Name);

                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;

                if (frm.GetType() == typeof(frmFilmDownloadManage))
                {
                    ((frmFilmDownloadManage)frm).FilmInfoChanged += new EventHandler(FrmMain_FilmInfoChanged);
                }
                else if (frm.GetType() == typeof(frmFilmInfoManage))
                {
                    ((frmFilmInfoManage)frm).FilmInfoChanged += new EventHandler(FrmMain_FilmInfoChanged);
                }

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载窗体出错!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        public void FrmMain_FilmInfoChanged(object sender, EventArgs e)
        {
            PreLoadShowPlanForm();
        }

        private void 影票补登ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FrmMain.curUser.HavePermission(Permissions.FillupTicketSelling))
            {
                MessageBox.Show("您没有人工补登权限,请联系管理员", "提示");
                return;
            }
            SaleTicket.frmFillUp frm = new SaleTicket.frmFillUp();
            OpenFrame(frm, "影票补登");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要关闭火烈鸟系统", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /*
        #region 单用户登录

        private void timer_LinkServer_Tick(object sender, EventArgs e)
        {
            timer_LinkServer.Enabled = false;

            if (g_onlineUser == null) BuildOnLineUser();
            BeginOnLineUser();
        }
        private void BuildOnLineUser()
        {
            g_onlineUser = new OnLineUserLog();
            g_onlineUser.UserId = curUser.UserId;
            g_onlineUser.UserName = curUser.UserName;
            g_onlineUser.WS_IP = RegistryWin32.CRegistryOption.GetClientIP();
            g_onlineUser.WS_MAC = RegistryWin32.CRegistryOption.GetClientMac();
            g_onlineUser.Created = DateTime.Now;
        }

        public void BeginOnLineUser()
        {
            ThreadStart ts = new ThreadStart(LinkServer);
            OnLineUserThread = new Thread(ts);
            OnLineUserThread.IsBackground = true;
            OnLineUserThread.Start();
        }
        private void LinkServer()
        {
            while (g_bLinkServer)
            {
                if (g_onlineUser == null) BuildOnLineUser();
                OnLineUserLog ou = OnLineUserLog.RetrieveObj(g_onlineUser.UserId);
                if (ou == null)
                {
                    bool bR = OnLineUserLog.CreateObj(g_onlineUser);
                    if (bR) g_onlineUser = ou;
                    g_bFirstLinkServer = false;
                }
                else
                {
                    if (g_bFirstLinkServer)
                    {
                        bool bR = OnLineUserLog.UpdateObj(g_onlineUser);
                        if (bR) g_onlineUser = ou;
                        g_bFirstLinkServer = false;
                    }
                    else
                    {
                        if (ou.WS_MAC != g_onlineUser.WS_MAC)
                        {
                            g_bLinkServer = false;
                            break;
                            //this.Close();
                        }
                        else
                        {
                            bool bR = OnLineUserLog.UpdateObj(g_onlineUser);
                            if (bR) g_onlineUser = ou;
                        }
                    }
                }
                Thread.Sleep(10000);
            }

            this.Invoke(new OnLineUserOpt(CloseOnLineUserForm));

        }
        private void CloseOnLineUserForm()
        {
            MessageBox.Show("已经有其它终端使用相同的帐号登陆！");
            this.Close();
        }

        #endregion
        */
    }
}

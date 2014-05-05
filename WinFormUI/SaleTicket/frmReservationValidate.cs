using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI.SaleTicket
{
    public partial class frmReservationValidate : Form
    {
        private string _ShowPlanId;
        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowPlanId
        {
            set { _ShowPlanId = value; }
            get { return _ShowPlanId; }
        }
        private string _ShowPlanName;
        /// <summary>
        /// 场计划名称
        /// </summary>
        public string ShowPlanName
        {
            get { return _ShowPlanName; }
            set { _ShowPlanName = value; }
        }
        private string _ShowPlanDate;
        /// <summary>
        /// 计划日期
        /// </summary>
        public string ShowPlanDate
        {
            get { return _ShowPlanDate; }
            set { _ShowPlanDate = value; }
        }
        private string _ShowPlanHall;
        /// <summary>
        /// 影厅
        /// </summary>
        public string ShowPlanHall
        {
            get { return _ShowPlanHall; }
            set { _ShowPlanHall = value; }
        }
        private string _ShowPlanStartTime;
        /// <summary>
        /// 开场时间
        /// </summary>
        public string ShowPlanStartTime
        {
            get { return _ShowPlanStartTime; }
            set { _ShowPlanStartTime = value; }
        }
        private string _TheaterName;
        /// <summary>
        /// 影院名称
        /// </summary>
        public string TheaterName
        {
            get { return _TheaterName; }
            set { _TheaterName = value; }
        }
        private string _CheckingType;
        /// <summary>
        /// 是否对号入座
        /// </summary>
        public string CheckingType
        {
            get { return _CheckingType; }
            set { _CheckingType = value; }
        }
        private string _HallId;
        /// <summary>
        /// 影厅ID
        /// </summary>
        public string HallId
        {
            get { return _HallId; }
            set { _HallId = value; }
        }
        private string _FilmId;
        /// <summary>
        /// 影片ID (验证最低票价用参数)
        /// </summary>
        public string FilmId
        {
            set { _FilmId = value; }
            get { return _FilmId; }
        }
        private string _showGroupFilmIds;
        /// <summary>
        /// 连场影片集合
        /// </summary>
        public string ShowGroupFilmIds
        {
            get { return _showGroupFilmIds; }
            set { _showGroupFilmIds = value; }
        }
        private bool _isShowGroup;
        /// <summary>
        /// 是否是连场
        /// </summary>
        public bool IsShowGroup
        {
            get { return _isShowGroup; }
            set { _isShowGroup = value; }
        }
        private string _showGroupShowPlanIds;
        /// <summary>
        /// 连场场次IDs
        /// </summary>
        public string ShowGroupShowPlanIds
        {
            get { return _showGroupShowPlanIds; }
            set { _showGroupShowPlanIds = value; }
        }
        private string _showGroupShowPlanNames;
        /// <summary>
        /// 连场影片名称
        /// </summary>
        public string ShowGroupShowPlanNames
        {
            get { return _showGroupShowPlanNames; }
            set { _showGroupShowPlanNames = value; }
        }
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_Cancel;
        /// <summary>
        /// 取消预定的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_Cancel
        {
            get { return _SeatStatusSimList_Cancel; }
        }
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_Sold;
        /// <summary>
        /// 预定出票的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_Sold
        {
            get { return _SeatStatusSimList_Sold; }
        }
        private List<SeatMaDll.SeatStatusSim> _SeatStatusSimList_SoldByVoucher = new List<SeatMaDll.SeatStatusSim>();
        /// <summary>
        /// 预定出票(票券)的座位ID&状态
        /// </summary>
        public List<SeatMaDll.SeatStatusSim> SeatStatusSimList_SoldByVoucher
        {
            get { return _SeatStatusSimList_SoldByVoucher; }
        }
        /// <summary>
        /// 场次序号
        /// </summary>
        private string _showPlanPosition;
        public string ShowPlanPosition
        {
            get { return _showPlanPosition; }
            set { _showPlanPosition = value; }
        }

        public frmReservationValidate()
        {
            InitializeComponent();
        }

        public frmReservationValidate(string name)
        {
            InitializeComponent();
            this.txtName.Text = name;
            this.txtPWD.Focus();
        }

        private void frmReservationValidate_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            if (!FrmMain.curUser.HavePermission(Flamingo.Right.Permissions.BookSaleTicketSelling))
            {
                btnYes.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) && string.IsNullOrEmpty(txtVipNumber.Text.Trim()))
            {
                MessageBox.Show("请填写填写会员卡号或姓名");
            }
            else if (string.IsNullOrEmpty(txtPWD.Text.Trim()))
            {
                MessageBox.Show("请填写密码");
            }
            else if (string.IsNullOrEmpty(txtCardNum.Text.Trim()))
            {
                MessageBox.Show("请填写身份证号");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtVipNumber.Text.Trim()))
                {
                    MessageBox.Show("暂无会员卡验证订票功能");
                }
                else
                {
                    Flamingo.Entity.Para_ReservationTicket model = Flamingo.BLL.Ticket.ReservationValidate(_ShowPlanId, txtName.Text.Trim(), txtPWD.Text.Trim(), txtCardNum.Text.Trim());
                    if (string.IsNullOrEmpty(model.ErrorMsg))
                    {
                        SaleTicket.frmReservationOut frm = new frmReservationOut();
                        frm.Parent = this.Parent;
                        frm.ShowPlanDate = _ShowPlanDate;
                        frm.ShowPlanHall = _ShowPlanHall;
                        frm.ShowPlanName = _ShowPlanName;
                        frm.ShowPlanStartTime = _ShowPlanStartTime;
                        frm.Model = model;
                        frm.FilmId = _FilmId;
                        frm.ShowPlanId = _ShowPlanId;
                        frm.TheaterName = _TheaterName;
                        frm.HallId = _HallId;
                        frm.CheckingType = _CheckingType;
                        frm.IsShowGroup=_isShowGroup;
                        frm.ShowGroupShowPlanIds = _showGroupShowPlanIds;
                        frm.ShowGroupFilmIds = _showGroupFilmIds;
                        frm.ShowGroupShowPlanNames = _showGroupShowPlanNames;
                        frm.ShowPlanPosition = _showPlanPosition;
                        frm.ShowDialog();
                        _SeatStatusSimList_Cancel = frm.SeatStatusSimList_Cancel;
                        _SeatStatusSimList_Sold = frm.SeatStatusSimList_Sold;
                        _SeatStatusSimList_SoldByVoucher = frm.SeatStatusSimList_SoldByVoucher;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(model.ErrorMsg);
                    }
                }
            }
        }
    }
}

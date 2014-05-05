using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WinFormUI.SaleTicket
{
    public partial class frmVoucherTickets : Form
    {
        private string _TicketType;
        /// <summary>
        /// 售票类型
        /// </summary>
        public string TicketType
        {
            get { return _TicketType; }
            set { _TicketType = value; }
        }
        private StringBuilder _sb_ticketid;
        /// <summary>
        /// 票ID集合
        /// </summary>
        public StringBuilder sb_ticketid
        {
            get { return _sb_ticketid; }
            set { _sb_ticketid = value; }
        }
        private StringBuilder _sb_ticketprice;
        /// <summary>
        /// 票价集合
        /// </summary>
        public StringBuilder sb_ticketprice
        {
            get { return _sb_ticketprice; }
            set { _sb_ticketprice = value; }
        }
        private StringBuilder _sb_seatnumber;
        /// <summary>
        /// 座位号
        /// </summary>
        public StringBuilder sb_seatnumber
        {
            get { return _sb_seatnumber; }
            set { _sb_seatnumber = value; }
        }

        public frmVoucherTickets()
        {
            InitializeComponent();
        }

        private void frmVoucherTickets_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            DataTable dt = new DataTable();
            dt.Columns.Add("TicketId");
            dt.Columns.Add("票种");
            dt.Columns.Add("座位");
            dt.Columns.Add("价格");
            dt.Columns.Add("票券");
            dt.Columns.Add("面值");
            dt.Columns.Add("补票面差额");
            dt.Columns.Add("合计");

            string[] ticketids = _sb_ticketid.ToString().Split('|');
            string[] ticketprices = _sb_ticketprice.ToString().Split('|');
            string[] seatnumbers = sb_seatnumber.ToString().Split('|');

            DataRow dr;
            for (int i = 0; i < ticketids.Length; i++)
            {
                dr = dt.NewRow();
                dr["TicketId"] = ticketids[i];
                dr["票种"] = _TicketType;
                dr["座位"] = seatnumbers[i];
                dr["价格"] = ticketprices[i];
                dr["票券"] = "票券x0";
                dr["面值"] = "0";
                dr["补票面差额"] = "0";
                dr["合计"] = "0";
                dt.Rows.Add(dr);
            }
            dgvTicketList.DataSource = dt;
        }
    }
}

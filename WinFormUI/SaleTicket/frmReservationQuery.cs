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
    public partial class frmReservationQuery : Form
    {
        private string _showplanid;
        public frmReservationQuery(string showplanid)
        {
            _showplanid = showplanid;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReservationQuery_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            DataTable dt = Flamingo.BLL.Ticket.ReservationQuery(_showplanid);
            dgvReservation.DataSource = dt;

            if (!FrmMain.curUser.HavePermission(Flamingo.Right.Permissions.BookSaleTicketSelling))
            {
                btnOut.Enabled = false;
            }
        }

        private string username = string.Empty;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            if (dgvReservation.SelectedRows.Count <= 0)
                return;
            username = dgvReservation.SelectedRows[0].Cells["姓名"].Value.ToString().Trim();
            this.Close();
        }
    }
}

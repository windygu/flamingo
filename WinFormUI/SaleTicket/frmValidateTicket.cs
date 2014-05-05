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
    public partial class frmValidateTicket : Form
    {
        public frmValidateTicket()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarCode.Text.Trim()))
                return;
            bool tf = false;
            DataTable dt = Flamingo.BLL.Ticket.ValidateTicket(this.txtBarCode.Text.Trim(), out tf);
            if (tf == true)
            {
                string msg = string.Format("影厅：{0}\r\n影片：{1}\r\n场次：{2}\r\n座号：{3}",
                    dt.Rows[0]["hallname"].ToString(), dt.Rows[0]["showplanname"].ToString(),
                    DateTime.Parse(dt.Rows[0]["StartTime"].ToString()).ToString("hh:mm"), dt.Rows[0]["seatnumber"].ToString());
                MessageBox.Show(msg, "验票", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("查无此票");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmValidateTicket_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            if (!FrmMain.curUser.HavePermission(Flamingo.Right.Permissions.ValidationTicketSelling))
                btnYes.Enabled = true;
        }
    }
}

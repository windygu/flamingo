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
    public partial class frmDiscountT : Form
    {
        private float discountPrice;
        public float DiscountPrice
        {
            get { return discountPrice; }
        }

        private string _showPlanId;

        public string ShowPlanId
        {
            get { return _showPlanId; }
            set { _showPlanId = value; }
        }

        public frmDiscountT()
        {
            InitializeComponent();
        }

        private void frmDiscountT_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            string discountTypeName = string.Empty;
            DataTable dt = Flamingo.BLL.Ticket.GetDiscount(_showPlanId, out discountTypeName);
            lblDiscountTypeName.Text = discountTypeName;
            combDiscount.DataSource = dt;
            combDiscount.DisplayMember = "DiscountId";
            combDiscount.ValueMember = "DiscountPrice";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                discountPrice = float.Parse(combDiscount.SelectedValue.ToString());
                float lowestprice = Flamingo.BLL.Ticket.GetLowestPrice(_showPlanId);
                if (discountPrice > lowestprice && discountPrice > 0)
                    this.DialogResult = DialogResult.Yes;
                else
                    MessageBox.Show("票价不能低于最低票价" + lowestprice.ToString("0.00"));
                this.Close();
            }
            catch
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}

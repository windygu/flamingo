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
    public partial class frmGroup : Form
    {

        public float Price;
        private string showplanid;

        public frmGroup(string _showplanid)
        {
            InitializeComponent();
            showplanid = _showplanid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Price = -1;
            this.Close();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Price = 0;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            this.txtGroupPrice.Text = rb.Tag.ToString();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            bool tf = Flamingo.Common.StringHelper.IsFloat(txtGroupPrice.Text.Trim());
            if (tf == true)
            {
                //判断是否低于最低票价
                float lowestprice = Flamingo.BLL.Ticket.GetLowestPrice(showplanid);
                Price = float.Parse(txtGroupPrice.Text);
                if (Price >= lowestprice && Price > 0)
                {
                    this.Close();
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show(string.Format("输入票价不能低于最低票价{0}", lowestprice.ToString("0.00")));
                }
            }
            else
            {
                MessageBox.Show("请输入有效票价");
            }
        }
    }
}

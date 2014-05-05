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
    public partial class frmVoucher : Form
    {
        private float _TicketPrice;
        /// <summary>
        /// 应付票价(差额)
        /// </summary>
        public float OutTicketPrice
        {
            get
            {
                return (float.Parse(txtCash1.Text) + float.Parse(txtCash2.Text.Trim()) + float.Parse(txtCash3.Text.Trim()));
            }
        }

        private List<Flamingo.Entity.Para_Voucher> allVoucher;

        public List<Flamingo.Entity.Para_Voucher> AllVoucher
        {
            set
            {
                allVoucher = value;
            }
            get 
            { 
                return allVoucher;
            }
        }

        public frmVoucher(float ticketprice, Flamingo.BLL.Type.PayType.Paytype vouchertype)
        {
            InitializeComponent();
            _TicketPrice = ticketprice;
            _voucherType = vouchertype;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<Flamingo.Entity.Para_Voucher> list = new List<Flamingo.Entity.Para_Voucher>();
        private Flamingo.BLL.Type.PayType.Paytype _voucherType;
        /// <summary>
        /// 兑换券类型
        /// </summary>
        public Flamingo.BLL.Type.PayType.Paytype VoucherType
        {
            get { return _voucherType; }
        }
        /// <summary>
        /// 票券信息
        /// </summary>
        public List<Flamingo.Entity.Para_Voucher> Voucherlist
        {
            get { return list; }
        }
        private void frmVoucher_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = _voucherType.ToString();
            lblVoucherType.Text = "";
            combVoucherType.Enabled = false;
            this.Width = 457;
            lblTicketPrice.Text = "票价：" + _TicketPrice.ToString() + "元";
            if (_voucherType == Flamingo.BLL.Type.PayType.Paytype.优惠券)
                combVoucherType.SelectedIndex = 0;
            else if (_voucherType == Flamingo.BLL.Type.PayType.Paytype.兑换券)
                combVoucherType.SelectedIndex = 1;
            else if (_voucherType == Flamingo.BLL.Type.PayType.Paytype.代用券)
            {
                combVoucherType.SelectedIndex = 2;
                panelDYMore.Visible = true;
                lblDYTicketPrice.Text = lblTicketPrice.Text;
                panelDYAdd.Location = new Point(13, 18);
                lblDY1.Text = "";
                lblDY2.Text = "";
                lblDY3.Text = "";
            }
        }

        #region 优惠券 兑换券处理

        private void btnManyToOne_Click(object sender, EventArgs e)
        {
            if (panelMore.Visible == false)
            {
                panelMore.Visible = true;
                txtCash2.Enabled = false;
                txtCash3.Enabled = false;
            }
        }

        private void btnOneToOne_Click(object sender, EventArgs e)
        {
            if (panelMore.Visible == true)
            {
                panelMore.Visible = false;
                lblVoucher2.Text = "0";
                lblVoucher3.Text = "0";
                txtCash2.Text = "0";
                txtCash3.Text = "0";
                lblTotal.Text = txtResult1.Text;

                txtCash1.Enabled = true;

                for (int i = list.Count - 1; i > 0; i--)
                {
                    list.RemoveAt(i);
                }
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVoucherId.Text.Trim()))
            {
                MessageBox.Show("请输入票券编号");
            }
            else if (txtVoucherId.Text.Trim().Length < 16)
            {
                MessageBox.Show("票券应该是16位编码");
            }
            else if (!Flamingo.Common.StringHelper.IsInt64(txtVoucherId.Text.Trim()))
            {
                MessageBox.Show("请输入有效票券编号");
            }
            else
            {
                bool hasTheVoucher = false;
                foreach (Flamingo.Entity.Para_Voucher m in list)
                {
                    if (m.VoucherId == txtVoucherId.Text.Trim())
                    {
                        hasTheVoucher = true;
                        break;
                    }
                }
                foreach (Flamingo.Entity.Para_Voucher m in allVoucher)
                {
                    if (m.VoucherId == txtVoucherId.Text.Trim())
                    {
                        hasTheVoucher = true;
                        break;
                    }
                }
                if (hasTheVoucher == true)
                {
                    MessageBox.Show("该票券正在使用");
                }
                else if (panelMore.Visible == false && list.Count > 0)
                {
                    MessageBox.Show("您使用的是单换模式");
                }
                else if (list.Count == 3)
                {
                    MessageBox.Show("多换模式最多使用三张票券");
                }
                else
                {
                    Flamingo.Entity.Para_Voucher model = Flamingo.BLL.Voucher.Validate(txtVoucherId.Text.Trim());
                    if (model.AllowUse == true)
                    {
                        list.Add(model);
                        allVoucher.Add(model);
                        if (list.Count == 1)
                        {
                            lblVoucher1.Text = model.VoucherPrice.ToString();
                            float total1 = model.VoucherPrice + float.Parse(txtCash1.Text.Trim());
                            txtResult1.Text = total1.ToString();
                        }
                        else if (list.Count == 2)
                        {
                            lblVoucher2.Text = model.VoucherPrice.ToString();
                            float total2 = model.VoucherPrice + float.Parse(txtCash2.Text.Trim());
                            txtResult2.Text = total2.ToString();

                            txtCash2.Text = txtCash1.Text;
                            txtCash2.Enabled = true;
                            txtCash1.Text = "0";
                            txtCash1.Enabled = false;
                        }
                        else if (list.Count == 3)
                        {
                            lblVoucher3.Text = model.VoucherPrice.ToString();
                            float total3 = model.VoucherPrice + float.Parse(txtCash3.Text.Trim());
                            txtResult3.Text = total3.ToString();

                            txtCash3.Text = txtCash1.Text;
                            txtCash3.Enabled = true;
                            txtCash2.Text = "0";
                            txtCash2.Enabled = false;
                        }
                        lblTotal.Text = (float.Parse(txtResult1.Text) + float.Parse(txtResult2.Text.Trim()) + float.Parse(txtResult3.Text.Trim())).ToString();

                        if (model.VoucherTypeId == 1)
                            _voucherType = Flamingo.BLL.Type.PayType.Paytype.兑换券;
                        if (model.VoucherTypeId == 2)
                            _voucherType = Flamingo.BLL.Type.PayType.Paytype.代用券;
                        if (model.VoucherTypeId == 3)
                            _voucherType = Flamingo.BLL.Type.PayType.Paytype.优惠券;

                        lblVoucherType.Text = model.VoucherType + "  " + model.VoucherSubType;
                    }
                    else
                    {
                        MessageBox.Show(model.ErrorMsg);
                    }
                    lblValidate.Text = model.ErrorMsg;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVoucherId.Text.Trim()))
            {
                MessageBox.Show("请输入票券编号");
            }
            else if (txtVoucherId.Text.Trim().Length < 16)
            {
                MessageBox.Show("票券应该是16位编码");
            }
            else if (!Flamingo.Common.StringHelper.IsInt64(txtVoucherId.Text.Trim()))
            {
                MessageBox.Show("请输入有效票券编号");
            }
            else
            {
                bool hasTheVoucher = false;
                foreach (Flamingo.Entity.Para_Voucher m in list)
                {
                    if (m.VoucherId == txtVoucherId.Text.Trim())
                    {
                        hasTheVoucher = true;
                        break;
                    }
                }
                Flamingo.Entity.Para_Voucher model = Flamingo.BLL.Voucher.Validate(txtVoucherId.Text.Trim());
                if (hasTheVoucher == true)
                {
                    model.ErrorMsg = "正在使用";
                }
                string msg = string.Format("票券批号:{0}\r\n票券号码:{1}\r\n有效期:{2}\r\n券类:{3}  {7}\r\n票面价值:{4}元\r\n购券单位:{5}\r\n状态:{6}\r\n",
                    model.VoucherBatchId, model.VoucherId, model.BeginDate.ToString("yyyy.MM.dd") + "-" + model.EndDate.ToString("yyyy.MM.dd"), model.VoucherType
                    , model.VoucherPrice.ToString(), model.VoucherName, model.ErrorMsg, model.VoucherSubType);
                MessageBox.Show(msg, "票券查询", MessageBoxButtons.OK);

            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("请添加票券");
            }
            else
            {
                float mian = 0, cha = 0;//mian:票券面值;cha:补票差额
                foreach (Flamingo.Entity.Para_Voucher pv in list)
                {
                    mian += pv.Price;
                }
                cha = float.Parse(txtCash1.Text.Trim()) + float.Parse(txtCash2.Text.Trim()) + float.Parse(txtCash3.Text.Trim());

                if ((mian + cha) < _TicketPrice)
                {
                    if (MessageBox.Show("票券价值加补票差额小于票价\r\n是否确定出票?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }

        private void txtCash1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtResult1.Text = (float.Parse(lblVoucher1.Text) + float.Parse(txtCash1.Text.Trim())).ToString();
                lblTotal.Text = (float.Parse(txtResult1.Text) + float.Parse(txtResult2.Text.Trim()) + float.Parse(txtResult3.Text.Trim())).ToString();
            }
            catch
            {
                txtCash1.Text = "0";
            }
        }

        private void txtCash2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtResult2.Text = (float.Parse(lblVoucher2.Text) + float.Parse(txtCash2.Text.Trim())).ToString();
                lblTotal.Text = (float.Parse(txtResult1.Text) + float.Parse(txtResult2.Text.Trim()) + float.Parse(txtResult3.Text.Trim())).ToString();
            }
            catch
            {
                txtCash2.Text = "0";
            }
        }

        private void txtCash3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtResult3.Text = (float.Parse(lblVoucher3.Text) + float.Parse(txtCash3.Text.Trim())).ToString();
                lblTotal.Text = (float.Parse(txtResult1.Text) + float.Parse(txtResult2.Text.Trim()) + float.Parse(txtResult3.Text.Trim())).ToString();
            }
            catch
            {
                txtCash3.Text = "0";
            }
        }

        private void combVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combVoucherType.SelectedIndex == 2)
            {
                this.panelDYAdd.Visible = true;
                this.groupBoxVoucher.Visible = false;
                DataTable dt = Flamingo.BLL.Voucher.GetVoucherSubstituteVoucherName();
                combVoucherName.DataSource = dt;
                combVoucherName.ValueMember = "VoucherBatchId";
                combVoucherName.DisplayMember = "VoucherName";
            }
            else
            {
                this.panelDYAdd.Visible = false;
                this.groupBoxVoucher.Visible = true;
            }
        }

        private void groupBoxVoucher_VisibleChanged(object sender, EventArgs e)
        {
            if (groupBoxVoucher.Visible == false)
            {
                groupBoxDY.Visible = true;
                groupBoxDY.Location = new Point(13, 78);
            }
            else
            {
                groupBoxDY.Visible = false;
            }
        }
        #endregion

        #region 代用券处理

        private void btnDYQuery_Click(object sender, EventArgs e)
        {
            if (combVoucherName.SelectedIndex > -1)
            {
                Flamingo.Entity.Para_Voucher model = Flamingo.BLL.Voucher.ValidateVoucherSubstitute(combVoucherName.SelectedValue.ToString());
                string msg = string.Format("票券批号:{0}\r\n有效期:{1}\r\n券类:{2}  {3}\r\n购券单位:{4}\r\n状态:{5}\r\n",
                    model.VoucherBatchId, model.BeginDate.ToString("yyyy.MM.dd") + "-" + model.EndDate.ToString("yyyy.MM.dd"), model.VoucherType
                    , model.VoucherSubType, model.VoucherName, model.ErrorMsg);
                MessageBox.Show(msg, "票券查询", MessageBoxButtons.OK);
            }
        }

        private void btnDYClear_Click(object sender, EventArgs e)
        {
            lblDY1.Text = "";
            lblDY2.Text = "";
            lblDY3.Text = "";
            lblDYStatus.Text = "";

            htVoucherModels.Clear();
            htLables.Clear();
            list.Clear();
            lblDYTotal.Text = "0";
        }

        private void btnDYYes_Click(object sender, EventArgs e)
        {
            if (htVoucherModels.Count == 0)
            {
                MessageBox.Show("请添加代用券");
            }
            else
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private Hashtable htVoucherModels = new Hashtable();
        private Hashtable htLables = new Hashtable();
        private void btnDYAdd_Click(object sender, EventArgs e)
        {
            if (combVoucherName.Items.Count == 0) return;
            string key = combVoucherName.Text;
            Flamingo.Entity.Para_Voucher model = Flamingo.BLL.Voucher.ValidateVoucherSubstitute(combVoucherName.SelectedValue.ToString());
            if (model.AllowUse == true)
            {
                if (htVoucherModels.Count == 3)
                {
                    MessageBox.Show("最多只能添加3张代用券");
                    return;
                }
                if (htVoucherModels[key] == null)
                {
                    List<Flamingo.Entity.Para_Voucher> listDY = new List<Flamingo.Entity.Para_Voucher>();
                    list.Add(model);
                    listDY.Add(model);
                    htVoucherModels.Add(key, listDY);
                    if (htVoucherModels.Count == 1)
                    {
                        lblDY1.Text = model.VoucherName + "  1 张";
                        htLables.Add(key, lblDY1);
                    }
                    else if (htVoucherModels.Count == 2)
                    {
                        lblDY2.Text = model.VoucherName + "  1 张";
                        htLables.Add(key, lblDY2);
                    }
                    else if (htVoucherModels.Count == 3)
                    {
                        lblDY3.Text = model.VoucherName + "  1 张";
                        htLables.Add(key, lblDY3);
                    }
                }
                else
                {
                    List<Flamingo.Entity.Para_Voucher> listDY = ((List<Flamingo.Entity.Para_Voucher>)htVoucherModels[key]);
                    list.Add(model);
                    listDY.Add(model);
                }
                //显示数量
                int count = 0;
                int total = 0;
                Label l;
                foreach (object k in htVoucherModels.Keys)
                {
                    count = ((List<Flamingo.Entity.Para_Voucher>)htVoucherModels[k]).Count;
                    total += count;
                    l = ((Label)htLables[k]);
                    if (l == null)
                        break;
                    l.Text = k.ToString() + "  " + count.ToString() + "张";
                }
                lblDYTotal.Text = total.ToString();

            }
            lblDYStatus.Text = model.ErrorMsg;
        }

        #endregion

    }
}

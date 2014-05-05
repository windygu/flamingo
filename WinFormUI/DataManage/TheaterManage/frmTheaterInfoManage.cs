using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using RCLibrary;
using System.Text.RegularExpressions;


namespace Flamingo.TheaterManage
{
    //2011/12/21,Qiu
    public partial class frmTheaterInfoManage : Form
    {
        private TheaterInfoManage dataManager;
        private BindingSource dataBindingSource;
        public frmTheaterInfoManage()
        {
            InitializeComponent();

            dataManager = new TheaterInfoManage();
            dataBindingSource = new BindingSource();
            dataBindingSource.DataSource = dataManager.GetDataList();

        }

        private void frmTheaterInfoManage_Load(object sender, EventArgs e)
        {
            int x = (this.Width - panTheater.Width) / 2;
            int y = (this.Height - panTheater.Height) / 2;

            panTheater.Location = new Point(x, y);
            BindData();
            RefreshDataList();
        }

        private void BindData()
        {
            txtTheaterName.DataBindings.Clear();
            txtTheaterType.DataBindings.Clear();
            txtCorporation.DataBindings.Clear();
            txtTelephone.DataBindings.Clear();
            txtContactPeople.DataBindings.Clear();
            txtHalls.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtProvince.DataBindings.Clear();
            txtCity.DataBindings.Clear();
            txtDistrict.DataBindings.Clear();
            txtPostCode.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtMobile.DataBindings.Clear();
            txtCineChainId.DataBindings.Clear();
            txtSerialNumber.DataBindings.Clear();
            txtMobile.DataBindings.Clear();
            txtRating.DataBindings.Clear();
            txtTheaterId.DataBindings.Clear();
            txtVersion.DataBindings.Clear();

            txtTheaterId.DataBindings.Add("Text", dataBindingSource, "TheaterId", true);
            txtTheaterName.DataBindings.Add("Text", dataBindingSource, "TheaterName", true);
            txtTheaterType.DataBindings.Add("Text", dataBindingSource, "TheaterType", true);
            txtCorporation.DataBindings.Add("Text", dataBindingSource, "Corporation", true);
            txtTelephone.DataBindings.Add("Text", dataBindingSource, "Telephone", true);
            txtContactPeople.DataBindings.Add("Text", dataBindingSource, "Manager", true);
            txtHalls.DataBindings.Add("Text", dataBindingSource, "Halls", true);
            txtSeats.DataBindings.Add("Text", dataBindingSource, "Seats", true);
            txtProvince.DataBindings.Add("Text", dataBindingSource, "Province", true);
            txtCity.DataBindings.Add("Text", dataBindingSource, "City", true);
            txtDistrict.DataBindings.Add("Text", dataBindingSource, "District", true);
            txtPostCode.DataBindings.Add("Text", dataBindingSource, "PostCode", true);
            txtAddress.DataBindings.Add("Text", dataBindingSource, "Address", true);
            txtCineChainId.DataBindings.Add("Text", dataBindingSource, "CineChainId", true);
            txtSerialNumber.DataBindings.Add("Text", dataBindingSource, "SerialNumber", true);
            txtMobile.DataBindings.Add("Text", dataBindingSource, "Mobile", true);
            txtRating.DataBindings.Add("Text", dataBindingSource, "Rating", true);
            txtVersion.DataBindings.Add("Text", dataBindingSource, "Version", true);
        }
        /// <summary>
        /// 绑定控件数据 控件只读
        /// </summary>
        private void RefreshDataList()
        {
            //List<Theater> list = dataManager.GetDataList();

            //foreach (Theater data in list)
            //{
            //   // txtTheaterId.Text = data.TheaterId;
            //    txtTheaterName.Text = data.TheaterName;
            //    txtTheaterType.Text = data.TheaterType;
            //    txtCorporation.Text = data.Corporation;
            //    txtTelephone.Text = data.Telephone;
            //    txtContactPeople.Text = data.Corporation;
            //    txtHalls.Text = data.Halls.ToString();
            //    txtSeats.Text = data.Seats.ToString();
            //    txtProvince.Text = data.Province;
            //    txtCity.Text = data.City;
            //   txtDistrict.Text = data.District;
            //    txtPostCode.Text = data.PostCode;
            //    txtAddress.Text = data.Address;
            //    txtTheaterCode.Text = data.TheaterCode;
            //    txtCineChainId.Text = data.CineChainId;
            //   txtSerialNumber.Text = data.SerialNumber;
            //   // txtRatio.Text = data.Ratio.ToString();
            //}
            txtAddress.ReadOnly = true;
            txtCineChainId.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtContactPeople.ReadOnly = true;
            txtCorporation.ReadOnly = true;
            txtDistrict.ReadOnly = true;
            txtHalls.ReadOnly = true;
            txtPostCode.ReadOnly = true;
            txtProvince.ReadOnly = true;
            //  txtRatio.ReadOnly = true;
            txtSeats.ReadOnly = true;
            txtSerialNumber.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtMobile.ReadOnly = true;
            //txtTheaterId.ReadOnly = true;
            txtTheaterName.ReadOnly = true;
            txtTheaterType.ReadOnly = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditTxt();

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public void EditTxt()
        {
            txtContactPeople.ReadOnly = false;
            txtTelephone.ReadOnly = false;
            txtMobile.ReadOnly = false;
            txtFax.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPostCode.ReadOnly = false;
         //   txtEmail.ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataBindingSource.DataSource = dataManager.GetDataList();
                RefreshDataList();
            }
            //try
            //{
            //    string oldstr;
            //    string pathstr;
            //    OpenFileDialog file = new OpenFileDialog();
            //    file.Filter = "授权文件(*.key)|*.key|所有文件(*.*)|*.*";
            //    if (file.ShowDialog() == DialogResult.OK)
            //    {
            //        pathstr = file.FileName;

            //        StreamReader sr = new StreamReader(pathstr);
            //        oldstr = sr.ReadToEnd();
            //        string ss = RC6Encryption.Decrypt(oldstr);
            //        sr.Dispose();
            //        sr.Close();

            //        StreamWriter sw = new StreamWriter(pathstr, false);
            //        sw.Write(ss);
            //        sw.Flush();
            //        sw.Dispose();
            //        sw.Close();

            //        DataSet ds = new DataSet();
            //        ds.ReadXml(pathstr);

            //        sw = new StreamWriter(pathstr, false);
            //        sw.Write(oldstr);
            //        sw.Flush();
            //        sw.Dispose();
            //        sw.Close();
            //        dataManager.SetInfo(ds);
            //        dataBindingSource.DataSource = dataManager.GetDataList();
            //        RefreshDataList();
            //        MessageBox.Show("导入授权文件成功！", "信息提示");
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show("导入授权文件失败！\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            //    if (txtTelephone.Text == null || txtTelephone.Text == string.Empty)
            //        return;
            //    List<Theater> list = dataManager.GetDataList();

            //    foreach (Theater data in list)
            //    {
            //        txtTelephone.Text = data.Telephone;
            //    }
            //    string s1 = @"(\(\d{4}\)|\d{3}-)?((\d{8})|(\d{7}))  ";         
            //    Match m = Regex.Match(this.txtTelephone.Text, s1);
            //    {
            //        if (!m.Success)   
            //        {
            //            MessageBox.Show("电话号码格式不正确", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }                        
            //    }
            //    txtTelephone.Clear();
            //    txtTelephone.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataManager.Save();

            txtContactPeople.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtMobile.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPostCode.ReadOnly = true;
            //txtEmail.ReadOnly = true;

            btnSave.Enabled = false;
            btnEdit.Enabled = true;

            MessageBox.Show("修改成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (txtTelephone.Text != string.Empty)
            {
                string tel = txtTelephone.Text;
                string s1 = @"(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,5}))?";
                if (!Regex.IsMatch(tel, s1))
                {
                    MessageBox.Show("电话号码格式不正确", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelephone.Select();
                }
            }
        }

    }
}

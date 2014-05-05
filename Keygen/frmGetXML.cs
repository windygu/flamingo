using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using RCLibrary;
using System.Text.RegularExpressions;
using Flamingo.Keygen;

namespace Keygen
{
    public partial class frmGetXML : Form
    {
        List<CustomDataTypes.HallInfo> hallList;
        CustomDataTypes.HallInfo hallInfo;
        private CustomDataTypes.TheaterInfo TheaterInfo;
        private BindingSource dataBindingSource;
        //设置文件的保存路径
        string Path;
        public frmGetXML()
        {
            InitializeComponent();
            TheaterInfo = new CustomDataTypes.TheaterInfo();
            hallInfo = new CustomDataTypes.HallInfo();
            BindDataTheater();
            hallList = new List<CustomDataTypes.HallInfo>();
            dataBindingSource = new BindingSource();

            dgvList.DataSource = dataBindingSource;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTelephone.Text != string.Empty && (IsTelNumber() != "" || IsTelNumber() != string.Empty))
                {
                    if (TheaterInfo.TheaterId == null)
                    {
                        MessageBox.Show("请先完善影院信息！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                TheaterInfo.Created = DateTime.Now;
                TheaterInfo.Updated = DateTime.Now;

                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "授权文件(*.key)|*.key|所有文件(*.*)|*.*";
                file.FileName = TheaterInfo.TheaterId + TheaterInfo.TheaterName + ".key";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Path = file.FileName;

                    try
                    {
                        SaveXML();
                        MessageBox.Show("导出成功！", "信息提示");
                    }
                    catch { MessageBox.Show("导出失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataTable SaveModule(DataTable dt)
        {
            foreach (Control ctl in tableLayoutPanel3.Controls)
            {
                CheckBox cbx = (CheckBox)ctl;
                DataRow dw = dt.NewRow();
                dw["Name"] = cbx.Tag.ToString();
                dw["Value"] = cbx.Checked == true ? 1 : 0;
                dt.Rows.Add(dw);
            }
            return dt;
        }

        /// <summary>
        /// 保存XML文档
        /// </summary>
        private void SaveXML()
        {
            DataSet ds = new DataSet("TheaterAndHall");

            DataTable dtTime = new DataTable("dtTime");

            dtTime.Columns.Add("StartTime");
            dtTime.Columns.Add("EndTime");
            DataRow dw = dtTime.NewRow();
            dw["StartTime"] = dtpStart.Value.Date;
            dw["EndTime"] = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);
            dtTime.Rows.Add(dw);
            ds.Tables.Add(dtTime);


            DataTable dtModule = new DataTable("dtModule");
            dtModule.Columns.Add("Name");
            dtModule.Columns.Add("Value");
            dtModule = SaveModule(dtModule);
            ds.Tables.Add(dtModule);

            DataTable TheaterInformation = new DataTable("TheaterInformation");


            //由于下面的方法只支持List，所以在此先定义一个中间变量
            List<CustomDataTypes.TheaterInfo> TheaterList = new List<CustomDataTypes.TheaterInfo>();
            TheaterList.Add(TheaterInfo);
            if (TheaterList.Count > 0)
            {
                PropertyInfo[] propertys = TheaterList[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取DailyPlan表的标题名称
                    TheaterInformation.Columns.Add(pi.Name);//, pi.PropertyType
                }

                for (int i = 0; i < TheaterList.Count; i++)
                {
                    //获取数据
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(TheaterList[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    TheaterInformation.LoadDataRow(array, true);
                }
            }
            DataTable HallInformation = new DataTable("HallInformation");
            hallList = dataBindingSource.DataSource as List<CustomDataTypes.HallInfo>;
            if (hallList.Count > 0)
            {
                PropertyInfo[] propertys = hallList[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取DailyPlan表的标题名称
                    HallInformation.Columns.Add(pi.Name);//, pi.PropertyType
                }

                for (int i = 0; i < hallList.Count; i++)
                {
                    //获取数据
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(hallList[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    HallInformation.LoadDataRow(array, true);
                }
            }
            ds.Tables.Add(TheaterInformation);

            //将放映计划信息信息加入到dataset中
            ds.Tables.Add(HallInformation);

            //导出XML文件
            ds.WriteXml(Path);

            StreamReader sr = new StreamReader(Path);
            string ss = RC6Encryption.Encrypt(sr.ReadToEnd());
            sr.Dispose();
            sr.Close();

            StreamWriter sw = new StreamWriter(Path, false);
            sw.Write(ss);
            sw.Flush();
            sw.Dispose();
            sw.Close();
        }

        private void BindDataTheater()
        {
            txtTheaterId.DataBindings.Clear();
            txtTheaterName.DataBindings.Clear();
            txtTheaterType.DataBindings.Clear();
            txtCorporation.DataBindings.Clear();
            txtTelephone.DataBindings.Clear();
            txtManager.DataBindings.Clear();
            txtHalls.DataBindings.Clear();
            txtSeatsAll.DataBindings.Clear();
            txtProvince.DataBindings.Clear();
            txtCity.DataBindings.Clear();
            txtDistrict.DataBindings.Clear();
            txtPostCode.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtTheaterCode.DataBindings.Clear();
            txtCineChainId.DataBindings.Clear();
            txtSerialNumber.DataBindings.Clear();
            txtFax.DataBindings.Clear();
            txtRating.DataBindings.Clear();
            txtMobile.DataBindings.Clear();
            txtVersion.DataBindings.Clear();


            txtServerModle.DataBindings.Clear();
            txtServerCPU.DataBindings.Clear();
            txtServerMemory.DataBindings.Clear();
            txtServerHardDriver.DataBindings.Clear();
            txtClients.DataBindings.Clear();

            txtTheaterId.DataBindings.Add("Text", TheaterInfo, "TheaterId", true);
            txtTheaterName.DataBindings.Add("Text", TheaterInfo, "TheaterName", true);
            txtTheaterType.DataBindings.Add("Text", TheaterInfo, "TheaterType", true);
            txtCorporation.DataBindings.Add("Text", TheaterInfo, "Corporation", true);
            txtTelephone.DataBindings.Add("Text", TheaterInfo, "Telephone", true);
            txtManager.DataBindings.Add("Text", TheaterInfo, "Manager", true);
            txtHalls.DataBindings.Add("Text", TheaterInfo, "Halls", true);
            txtSeatsAll.DataBindings.Add("Text", TheaterInfo, "Seats", true);
            txtProvince.DataBindings.Add("Text", TheaterInfo, "Province", true);
            txtCity.DataBindings.Add("Text", TheaterInfo, "City", true);
            txtDistrict.DataBindings.Add("Text", TheaterInfo, "District", true);
            txtPostCode.DataBindings.Add("Text", TheaterInfo, "PostCode", true);
            txtAddress.DataBindings.Add("Text", TheaterInfo, "Address", true);
            txtTheaterCode.DataBindings.Add("Text", TheaterInfo, "TheaterCode", true);
            txtCineChainId.DataBindings.Add("Text", TheaterInfo, "CineChainId", true);
            txtSerialNumber.DataBindings.Add("Text", TheaterInfo, "SerialNumber", true);
            txtFax.DataBindings.Add("Text", TheaterInfo, "Rating", true);
            txtRating.DataBindings.Add("Text", TheaterInfo, "Fax", true);
            txtMobile.DataBindings.Add("Text", TheaterInfo, "Mobile", true);
            txtVersion.DataBindings.Add("Text", TheaterInfo, "Version", true);

            txtServerModle.DataBindings.Add("Text", TheaterInfo, "ServerModle", true);
            txtServerCPU.DataBindings.Add("Text", TheaterInfo, "ServerCPU", true);
            txtServerMemory.DataBindings.Add("Text", TheaterInfo, "ServerMemory", true);
            txtServerHardDriver.DataBindings.Add("Text", TheaterInfo, "ServerHardDriver", true);
            txtClients.DataBindings.Add("Text", TheaterInfo, "Clients", true);

        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtHallId.DataBindings.Clear();
            txtFilmName.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtLevels.DataBindings.Clear();
            txtScreen.DataBindings.Clear();
            txtProjector.DataBindings.Clear();
            txtPlayMode.DataBindings.Clear();
            txtSoundSystem.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            txtTheaterId1.DataBindings.Clear();

            txtHallId.DataBindings.Add("Text", hallInfo, "HallId", true);
            txtFilmName.DataBindings.Add("Text", hallInfo, "HallName", true);
            txtSeats.DataBindings.Add("Text", hallInfo, "Seats", true);
            txtLevels.DataBindings.Add("Text", hallInfo, "Levels", true);
            txtScreen.DataBindings.Add("Text", hallInfo, "Screen", true);
            txtProjector.DataBindings.Add("Text", hallInfo, "Projector", true);
            txtPlayMode.DataBindings.Add("Text", hallInfo, "PlayMode", true);
            txtSoundSystem.DataBindings.Add("Text", hallInfo, "SoundSystem", true);
            txtDescription.DataBindings.Add("Text", hallInfo, "Description", true);
            txtTheaterId1.DataBindings.Add("Text", hallInfo, "TheaterId", true);
        }

        private void frmGetXML_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshDataList();
                BindData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataBindingSource.Current != null)
            {
                dataBindingSource.RemoveCurrent();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                hallInfo = NewData();
                dataBindingSource.Add(hallInfo);
                dataBindingSource.MoveLast();

                BindData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        public CustomDataTypes.HallInfo NewData()
        {
            string lastId;
            // 使用创建时间先后来获取最后ID
            if (dataBindingSource.DataSource != null)
            {
                hallList = dataBindingSource.DataSource as List<CustomDataTypes.HallInfo>;
                if (TheaterInfo.TheaterId != null)
                {
                    foreach (var tmp in hallList)
                    {
                        tmp.TheaterId = TheaterInfo.TheaterId;
                    }
                }
                CustomDataTypes.HallInfo lastData = hallList.OrderByDescending(p => p.Created).FirstOrDefault();


                // 不能两条记录的创建时间一样，避免主键重复
                if (lastData != null && lastData.Created == DateTime.Now)
                    throw new Exception();

                if (lastData != null)
                {
                    lastId = lastData.HallId;
                }
                else
                {
                    lastId = "0";
                }
            }
            else
                lastId = "0";

            string newId;
            // 生成新的Id（这里长度是12位）
            try
            {
                newId = string.Format("{0:D2}", Convert.ToInt64(lastId) + 1);
            }
            catch
            {
                newId = string.Format("{0:D2}", 1);
            }

            CustomDataTypes.HallInfo data = new CustomDataTypes.HallInfo();
            data.HallId = newId;

            // 更新数据基础值
            data.Created = DateTime.Now;
            data.Updated = data.Created;
            data.ActiveFlag = true;
            data.TheaterId = TheaterInfo.TheaterId;
            return data;
        }

        private void dgvList_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                this.dgvList.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;

                try
                {
                    hallList = dataBindingSource.DataSource as List<CustomDataTypes.HallInfo>;
                    if (TheaterInfo.TheaterId != null)
                    {
                        foreach (var tmp in hallList)
                        {
                            tmp.TheaterId = TheaterInfo.TheaterId;
                        }
                    }
                    if (dgvList.CurrentRow.Cells["HallId"].Value != null)
                    {
                        hallInfo = hallList.Where(p => p.HallId == dgvList.CurrentRow.Cells["HallId"].Value.ToString()).FirstOrDefault();
                        if (hallInfo != null)
                            BindData();
                    }
                }
                catch { }

            }
        }


        /// <summary>
        /// 刷新所有数据
        /// </summary>
        public void RefreshDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSource.DataSource == null)
            {
                if (hallList == null)
                    hallList = new List<CustomDataTypes.HallInfo>();
                dataBindingSource.DataSource = hallList;
                formatFlag = true;
            }
            bvNavigator.BindingSource = dataBindingSource;
            dgvList.DataSource = dataBindingSource;

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
                FormatDataList();
        }

        /// <summary>
        /// 判断电话号码的格式是否正确
        /// </summary>2012.1.9 LIN
        /// <returns></returns>
        public string IsTelNumber()
        {
            if (txtTelephone.Text == null || txtTelephone.Text == string.Empty)
                return txtTelephone.Text;
            string tel = txtTelephone.Text;
            string s1 = @"(\(\d{4}\)|\d{3}-)?((\d{8})|(\d{7}))";
            Match m = Regex.Match(tel, s1);
            {
                if (!m.Success)
                {
                    txtTelephone.Clear();
                    txtTelephone.Select();
                    throw new NotImplementedException("电话号码格式不正确");
                }
            }
            return txtTelephone.Text;
        }
        /// <summary>
        /// 格式化数据表格
        /// </summary>
        protected void FormatDataList()
        {
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns["Created"].Visible = false;
            dgvList.Columns["Updated"].Visible = false;
            dgvList.Columns["ActiveFlag"].Visible = false;
            dgvList.Columns["BarColour"].Visible = false;
            dgvList.Columns["HallId"].HeaderText = "影厅编号";
            dgvList.Columns["TheaterId"].HeaderText = "影院编号";
            dgvList.Columns["HallName"].HeaderText = "影厅名称";
            dgvList.Columns["Seats"].HeaderText = "座位数量";
            dgvList.Columns["Levels"].HeaderText = "楼层数量";
            dgvList.Columns["Screen"].HeaderText = "银幕";
            dgvList.Columns["Projector"].HeaderText = "放映机";
            dgvList.Columns["PlayMode"].HeaderText = "放映模式";
            dgvList.Columns["SoundSystem"].HeaderText = "声音模式";
            dgvList.Columns["Description"].HeaderText = "说明";

            dgvList.Columns["HallId"].Width = 85;
            dgvList.Columns["TheaterId"].Width = 85;
            dgvList.Columns["HallName"].Width = 85;
            dgvList.Columns["Seats"].Width = 85;
            dgvList.Columns["Levels"].Width = 85;
            dgvList.Columns["Screen"].Width = 85;
            dgvList.Columns["Projector"].Width = 85;
            dgvList.Columns["PlayMode"].Width = 85;
            dgvList.Columns["SoundSystem"].Width = 85;
            dgvList.Columns["Description"].Width = 76;
        }

        private void txtTheaterName_TextChanged(object sender, EventArgs e)
        {
            if (txtTheaterId.Text != string.Empty && txtTheaterName.Text != string.Empty
                && txtHalls.Text != string.Empty && txtSeatsAll.Text != string.Empty)
            {
                string str = txtTheaterId.Text + "," + txtTheaterName.Text + "," + txtHalls.Text + "," + txtSeatsAll.Text;
                str = RC6Encryption.Encrypt(str, 256);
                if (str.Length >= 25)
                    txtSerialNumber.Text = str.Substring(0, 25);
                else
                    txtSerialNumber.Text = str;

                TheaterInfo.SerialNumber = txtSerialNumber.Text.Trim();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string oldstr;
                string pathstr;
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "授权文件(*.key)|*.key|所有文件(*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    TheaterInfo = new CustomDataTypes.TheaterInfo();
                    hallList = new List<CustomDataTypes.HallInfo>();

                    pathstr = file.FileName;

                    StreamReader sr = new StreamReader(pathstr);
                    oldstr = sr.ReadToEnd();
                    string ss = RC6Encryption.Decrypt(oldstr);
                    sr.Dispose();
                    sr.Close();

                    StreamWriter sw = new StreamWriter(pathstr, false);
                    sw.Write(ss);
                    sw.Flush();
                    sw.Dispose();
                    sw.Close();

                    DataSet ds = new DataSet();
                    ds.ReadXml(pathstr);

                    sw = new StreamWriter(pathstr, false);
                    sw.Write(oldstr);
                    sw.Flush();
                    sw.Dispose();
                    sw.Close();
                    SetInfo(ds);
                    Rebind();
                }
            }
            catch { }
        }

        private void Rebind()
        {
            try
            {
                dataBindingSource.DataSource = null;

                RefreshDataList();
                BindDataTheater();
                BindData();

                dgvList_Click(this, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FillModule(DataTable dt)
        {
            if (dt == null)
                return;

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (Control ctl in tableLayoutPanel3.Controls)
                    {
                        CheckBox cbx = (CheckBox)ctl;
                        if (cbx.Tag.ToString() == dr["Name"].ToString())
                            cbx.Checked = dr["Value"].ToString() == "1" ? true : false;
                    }
                }
            }
            catch { }
        }

        public void SetInfo(DataSet ds)
        {
            DateTime starttime=DateTime.Now;
            DateTime endTime=DateTime.Now;

            try
            {
                starttime = Convert.ToDateTime(ds.Tables["dtTime"].Rows[0]["StartTime"].ToString());
                endTime = Convert.ToDateTime(ds.Tables["dtTime"].Rows[0]["EndTime"].ToString());
            }
            catch
            {
                //MessageBox.Show("授权文件起始时间和截止时间设置不正确，无法将该文件导进！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            //if ((starttime.Date > DateTime.Now.Date)
            //    || (endTime.Date < DateTime.Now.Date))
            //{
            //    MessageBox.Show("不在授权文件的有效期内，无法将该文件导进！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            dtpStart.Value = starttime;
            dtpEnd.Value = endTime;

            FillModule(ds.Tables["dtModule"]);

            try
            {
                TheaterInfo.TheaterId = ds.Tables["TheaterInformation"].Rows[0]["TheaterId"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.TheaterName = ds.Tables["TheaterInformation"].Rows[0]["TheaterName"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.TheaterType = ds.Tables["TheaterInformation"].Rows[0]["TheaterType"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.Corporation = ds.Tables["TheaterInformation"].Rows[0]["Corporation"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.Telephone = ds.Tables["TheaterInformation"].Rows[0]["Telephone"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.Manager = ds.Tables["TheaterInformation"].Rows[0]["Manager"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Halls = Convert.ToInt32(ds.Tables["TheaterInformation"].Rows[0]["Halls"].ToString());
            }
            catch { }

            try
            {
                TheaterInfo.Seats = Convert.ToInt32(ds.Tables["TheaterInformation"].Rows[0]["Seats"].ToString());
            }
            catch { }
            try
            {
                TheaterInfo.Province = ds.Tables["TheaterInformation"].Rows[0]["Province"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.City = ds.Tables["TheaterInformation"].Rows[0]["City"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.District = ds.Tables["TheaterInformation"].Rows[0]["District"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.PostCode = ds.Tables["TheaterInformation"].Rows[0]["PostCode"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Address = ds.Tables["TheaterInformation"].Rows[0]["Address"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.TheaterCode = ds.Tables["TheaterInformation"].Rows[0]["TheaterCode"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.CineChainId = ds.Tables["TheaterInformation"].Rows[0]["CineChainId"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.SerialNumber = ds.Tables["TheaterInformation"].Rows[0]["SerialNumber"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Rating = ds.Tables["TheaterInformation"].Rows[0]["Rating"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Fax = ds.Tables["TheaterInformation"].Rows[0]["Fax"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Mobile = ds.Tables["TheaterInformation"].Rows[0]["Mobile"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Version = ds.Tables["TheaterInformation"].Rows[0]["Version"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.Created = Convert.ToDateTime(ds.Tables["TheaterInformation"].Rows[0]["Created"].ToString());
            }
            catch { }
            try
            {
                TheaterInfo.Updated = Convert.ToDateTime(ds.Tables["TheaterInformation"].Rows[0]["Updated"].ToString());
            }
            catch { }


            try
            {
                TheaterInfo.ServerModle = ds.Tables["TheaterInformation"].Rows[0]["ServerModle"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.ServerCPU = ds.Tables["TheaterInformation"].Rows[0]["ServerCPU"].ToString();
            }
            catch { }

            try
            {
                TheaterInfo.ServerMemory =ds.Tables["TheaterInformation"].Rows[0]["ServerMemory"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.ServerHardDriver = ds.Tables["TheaterInformation"].Rows[0]["ServerHardDriver"].ToString();
            }
            catch { }
            try
            {
                TheaterInfo.Clients =Convert.ToInt32( ds.Tables["TheaterInformation"].Rows[0]["Clients"].ToString());
            }
            catch { }


            foreach (DataRow tmp in ds.Tables["HallInformation"].Rows)
            {
                CustomDataTypes.HallInfo hallInfo = new CustomDataTypes.HallInfo();
                try
                {
                    hallInfo.HallId = tmp["HallId"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.TheaterId = tmp["TheaterId"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.HallName = tmp["HallName"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Seats = Convert.ToInt32(tmp["Seats"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Levels = Convert.ToInt32(tmp["Levels"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Screen = tmp["Screen"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Projector = tmp["Projector"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.PlayMode = tmp["PlayMode"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.SoundSystem = tmp["SoundSystem"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Description = tmp["Description"].ToString();
                }
                catch { }
                try
                {
                    hallInfo.Created = Convert.ToDateTime(tmp["Created"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.Updated = Convert.ToDateTime(tmp["Updated"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.ActiveFlag = Convert.ToBoolean(tmp["ActiveFlag"].ToString());
                }
                catch { }
                try
                {
                    hallInfo.BarColour = tmp["BarColour"].ToString();
                }
                catch { }

                hallList.Add(hallInfo);
            }
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in tableLayoutPanel3.Controls)
            {
                CheckBox cbx = (CheckBox)ctl;
                cbx.Checked = cbxAll.Checked == true ? true : false;
            }
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

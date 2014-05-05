using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PresentationControls;
using Flamingo.TicketManage;

namespace Flamingo.FilmManage
{
    // 2011.12.22, Jiang
    public partial class frmFilmInfoManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量

        private FilmInfoManage dataManager;
        public event EventHandler FilmInfoChanged;
        private string filmId = string.Empty;
        private bool isReSetDataArea = true;

        #endregion

        #region 启动处理

        public frmFilmInfoManage()
        {
            InitializeComponent();

            lblListTitle.Text = "影片信息";

            dataManager = new FilmInfoManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;

            dataBindingSource.CurrentItemChanged += new EventHandler(dataBindingSource_CurrentItemChanged);
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvList_CellFormatting);
            this.Load += new EventHandler(frmFilmInfoManage_Load);
            cblMode.SelectedIndexChanged += new EventHandler(cblMode_ItemCheck);
            cblType.SelectedIndexChanged += new EventHandler(cblType_ItemCheck);

        }

        private void frmFilmInfoManage_Load(object sender, EventArgs e)
        {
            InitData();

            //        BindModeLv();

            txtKeyWord.Select();

            //if (dataBindingSource.Count > 0)
            //{
            //    dataBindingSource.MoveNext();
            //    dataBindingSource.MovePrevious();
            //}

        }

        private void InitData()
        {
            RefreshDataList();

            BindData();

            FillList();
        }


        #endregion

        #region 窗体事件

        private void cblType_ItemCheck(object sender, EventArgs e)
        {
            bool isFirst = true;
            txtType.Text = "";
            foreach (var tmp in this.cblType.CheckedItems)
            {
                if (isFirst == true)
                {
                    isFirst = false;
                    txtType.Text = tmp.ToString();
                }
                else
                    txtType.Text += "," + tmp.ToString();
            }
            dataManager.SaveType(txtFilmId.Text, txtType.Text);
        }

        private void cblMode_ItemCheck(object sender, EventArgs e)
        {
            bool isFirst = true;
            txtMode.Text = "";
            foreach (var tmp in this.cblMode.CheckedItems)
            {

                if (isFirst == true)
                {
                    isFirst = false;
                    txtMode.Text = tmp.ToString();
                }
                else
                    txtMode.Text += "," + tmp.ToString();
            }
            dataManager.SaveMode(txtFilmId.Text, txtMode.Text);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtKeyWord.Text == "")
            {
                MessageBox.Show("请输入影片名称!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtKeyWord.Focus();
            }
            else
            {
                dataBindingSource.DataSource = dataManager.GetSearchList("FilmName", txtKeyWord.Text.Trim());
            }
        }

        private void btnUploadPoster_Click(object sender, EventArgs e)
        {
            if (btnUploadPoster.Text == "上传海报")
            {
                Upload(true);
            }
            else
            {
                ViewPoster();
            }
        }
        private void Upload(bool isMes)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Filter = "图片（*.jpg;*.bmp;*.gif;*.png;*.jpeg）|*.jpg;*.bmp;*.gif;*.png;*.jpeg";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                byte[] content;
                FileInfo finfo = new FileInfo(frm.FileName);   //绝对路径
                if (finfo.Exists == true)
                {
                    if (finfo.Length > 1024 * 1024 * 10)
                    {
                        MessageBox.Show("上传的文件不能超过10M！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //读取文件内容，写入byte数组
                    content = new byte[finfo.Length];
                    FileStream stream = finfo.OpenRead();
                    stream.Read(content, 0, content.Length);
                    stream.Close();

                    List<Film> list = new List<Film>();
                    list = dataBindingSource.DataSource as List<Film>;
                    list.Find(p => p.FilmId == (txtFilmId.Text.Trim())).Poster = content;
                    btnUploadPoster.Text = "预览海报";

                    if (isMes)
                    {
                        if (MessageBox.Show("上传海报成功，是否现在进行预览？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            ViewPoster();
                    }
                }
            }
        }
        private void ViewPoster()
        {
            //frmPoster frm = new frmPoster(((Film)(this.dataBindingSource.Current)).Poster);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //   // btnUploadPoster.Text = "上传海报";
            //    Upload(false);
            //    ViewPoster();
            //}
        }

        ///// <summary>
        ///// 数据显示格式处理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    if (dgv.Columns[e.ColumnIndex].Name.Contains("Price"))
        //    {
        //        try
        //        {

        //            e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

        private void btnShowFilm_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetShowList();
        }

        private void btnAllFilm_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetDataList();
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.Blue;

            if (dgvList.Columns[e.ColumnIndex].Name == "BorderColour")
            {
                try
                {
                    if (e.Value != null && string.IsNullOrWhiteSpace(e.Value.ToString()) != true)
                    {
                        string[] Array = e.Value.ToString().Split(';');
                        Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));

                        dgvList[e.ColumnIndex, e.RowIndex].Style.BackColor = color;
                    }
                    else
                    {
                        dgvList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    }
                }
                catch
                {
                    dgvList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("Ratio"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value) * 100).ToString() + "%";
                }
                catch
                {
                    e.Value = "0%";
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name.Contains("Price"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString("0.00") + "元";
                }
                catch
                {
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "FilmAreaId")
            {
                string nId;
                nId = e.Value.ToString();
                try
                {
                    e.Value = dataManager.GetFilmAreaName(nId);

                }
                catch { }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "FilmCategoryId")
            {
                string nId;
                nId = e.Value.ToString();
                try
                {
                    e.Value = dataManager.GetFilmCategoryName(nId);

                }
                catch { }
            }
        }

        private void dataBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                Film film = ((Film)(this.dataBindingSource.Current));
                string borderColour = film.BorderColour;

                BindMode(film.FilmId);
                BindType(film.FilmId);
                if (string.IsNullOrWhiteSpace(borderColour) != true)
                {
                    string[] Array = borderColour.Split(';');
                    Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));

                    txtBorderColour.BackColor = color;
                }
                else
                {
                    txtBorderColour.BackColor = Color.White;
                }
                btnUploadPoster.Text = film.Poster == null ? "上传海报" : "预览海报";

                try
                {
                    if (film.StartDate == null)
                        dtStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
                try
                {
                    if (film.EndDate == null)
                        dtEndDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                }
                catch { }
            }
            catch
            {
                txtBorderColour.BackColor = Color.White;
            }
        }

        private void txtBorderColour_Click(object sender, EventArgs e)
        {
            if (txtBorderColour.Enabled == true)
            {
                ColorDialog frm = new ColorDialog();
                frm.AllowFullOpen = true;
                frm.AnyColor = true;
                frm.FullOpen = true;
                frm.ShowHelp = true;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ((Film)(this.dataBindingSource.Current)).BorderColour = frm.Color.A.ToString() + ";"
                                                                        + frm.Color.R.ToString() + ";"
                                                                        + frm.Color.G.ToString() + ";"
                                                                        + frm.Color.B.ToString();

                    txtBorderColour.BackColor = frm.Color;
                }
            }
        }


        #endregion

        #region 窗体函数

        #region 继承父窗体函数

        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();
                //2011.12.24LIN
                //txtFilmId.ReadOnly = true;
                txtFilmCode.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData()
        {
            txtFilmCode.Select();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Film)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        protected override void ApplyReadonlyConfig()
        {
            txtFilmCode.Enabled = false;
            txtFilmName.Enabled = false;
            cbFilmCategory.Enabled = false;
            cbFilmArea.Enabled = false;
            txtPublisher.Enabled = false;
            txtProducer.Enabled = false;
            txtDirector.Enabled = false;
            dtPublishDate.Enabled = false;
            //  txtPoster.Enabled = false;
            txtCast.Enabled = false;
            txtBrief.Enabled = false;

        }
        private Film CheckLowestPrice()
        {
            var list = dataBindingSource.DataSource as List<Film>;
            return list.Find(p => (p.LowestPrice == null || p.LowestPrice == 0) && p.StartDate != null);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            try
            {
                Film obj = CheckLowestPrice();
                if (obj != null)
                {
                    MessageBox.Show(obj.FilmName + "  的最低票价不能为空或0，请检查！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.dataManager.Save();

                // this.dataManager = new FilmInfoManage();
                InitData();

                if (FilmInfoChanged != null)
                    FilmInfoChanged(this, EventArgs.Empty);

                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        #endregion

        #region 其它函数

        /// <summary>
        /// 刷新所有数据
        /// </summary>
        public void RefreshDataList()
        {
            // 记录是否需要格式化列信息
            bool formatFlag = false;

            // 假如列表还没有数据（初始状态），那么填充数据后，需要格式化列信息
            if (dataBindingSource.DataSource == null)
                formatFlag = true;

            // 获取数据列表            
            dataBindingSource.DataSource = dataManager.GetDataList();
            bvNavigator.BindingSource = dataBindingSource;
            dgvList.DataSource = dataBindingSource;

            // 根据标记，如果列表之前没有数据（初始状态），则需要格式化列信息
            if (formatFlag == true)
            {
                FormatDataList();
                dgvList.Columns["FilmId"].Visible = false;
            }

            if (isReSetDataArea == true)
            {
                ReSetDataArea();

                isReSetDataArea = false;
            }
        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtFilmId.DataBindings.Clear();
            txtFilmCode.DataBindings.Clear();
            txtFilmName.DataBindings.Clear();
            dtPublishDate.DataBindings.Clear();
            txtPublisher.DataBindings.Clear();
            txtProducer.DataBindings.Clear();
            txtDirector.DataBindings.Clear();
            dtStartDate.DataBindings.Clear();
            txtFilmLength.DataBindings.Clear();
            txtRatio.DataBindings.Clear();
            txtLowestPrice.DataBindings.Clear();
            dtEndDate.DataBindings.Clear();
            // chbHasMode.DataBindings.Clear();
            txtCast.DataBindings.Clear();
            txtBrief.DataBindings.Clear();
            // txtPoster.DataBindings.Clear();
            txtBorderColour.DataBindings.Clear();
            cbFilmArea.DataBindings.Clear();
            cbFilmCategory.DataBindings.Clear();

            txtFilmId.DataBindings.Add("Text", dataBindingSource, "FilmId", true);
            txtFilmCode.DataBindings.Add("Text", dataBindingSource, "FilmCode", true);
            txtFilmName.DataBindings.Add("Text", dataBindingSource, "FilmName", true);
            dtPublishDate.DataBindings.Add("Value", dataBindingSource, "PublishDate", true);
            txtPublisher.DataBindings.Add("Text", dataBindingSource, "Publisher", true);
            txtProducer.DataBindings.Add("Text", dataBindingSource, "Producer", true);
            txtDirector.DataBindings.Add("Text", dataBindingSource, "Director", true);
            dtStartDate.DataBindings.Add("Value", dataBindingSource, "StartDate", true);
            txtFilmLength.DataBindings.Add("Text", dataBindingSource, "FilmLength", true);

            txtRatio.DataBindings.Add("Text", dataBindingSource, "Ratio", true);
            txtRatio.DataBindings["Text"].Format += TextBox_Percent_Format;
            txtRatio.DataBindings["Text"].Parse += TextBox_Percent_Parse;

            txtLowestPrice.DataBindings.Add("Text", dataBindingSource, "LowestPrice", true);
            txtLowestPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtLowestPrice.DataBindings["Text"].Parse += TextBox_Currency_Parse;
            dtEndDate.DataBindings.Add("Value", dataBindingSource, "EndDate", true);
            // chbHasMode.DataBindings.Add("Checked", dataBindingSource, "HasMode", true);
            txtCast.DataBindings.Add("Text", dataBindingSource, "Cast", true);
            txtBrief.DataBindings.Add("Text", dataBindingSource, "Brief", true);
            //  txtPoster.DataBindings.Add("Text", dataBindingSource, "Poster", true);
            txtBorderColour.DataBindings.Add("Text", dataBindingSource, "BorderColour", true);
            cbFilmArea.DataBindings.Add("SelectedValue", dataBindingSource, "FilmAreaId", true);
            cbFilmCategory.DataBindings.Add("SelectedValue", dataBindingSource, "FilmCategoryId", true);
        }

        /// <summary>
        /// 填充所有 ComboBox 控件数据
        /// </summary>
        private void FillList()
        {
            FillFilmAreaList();
            FillFilmCategoryList();
        }

        private void BindModeLv()
        {
            cblMode.Items.Clear();
            txtMode.Text = "";
            var list = dataManager.GetFilmModeList();
            int i = 0;

            foreach (var tmp in list)
            {
                cblMode.Items.Add((object)tmp.FilmModeName);
                i++;
            }
        }

        private void BeginSave()
        {
            dataBindingSource.MoveNext();
            filmId = string.Empty;
            dataBindingSource.MovePrevious();
        }



        /// <summary>
        /// 填充下拉框：影片产地
        /// </summary>
        private void FillFilmAreaList()
        {
            cbFilmArea.DisplayMember = "FilmAreaName";
            cbFilmArea.ValueMember = "FilmAreaId";

            cbFilmArea.DataSource = FilmAreaManage.DirectGetAllList();
        }

        /// <summary>
        /// 填充下拉框：影片类型
        /// </summary>
        private void FillFilmCategoryList()
        {
            cbFilmCategory.DisplayMember = "FilmCategoryName";
            cbFilmCategory.ValueMember = "FilmCategoryId";

            cbFilmCategory.DataSource = FilmCategoryManage.DirectGetAllList();
        }

        private void BindType(string filmId)
        {
            cblType.Items.Clear();
            var list = dataManager.GetFilmTypeList();

            var listFilm = dataManager.GetFilm_FilmTypeList(filmId);



            foreach (var tmp in list)
            {
                var obj = listFilm.Find(p => p.FilmTypeId == tmp.FilmTypeId);

                if (obj != null)
                {
                    cblType.Items.Add((object)tmp.FilmTypeName, true);
                }
                else
                {
                    cblType.Items.Add((object)tmp.FilmTypeName, false);
                }

            }
            cblType_ItemCheck(this, EventArgs.Empty);
        }

        private void BindMode(string filmId)
        {
            cblMode.Items.Clear();
            var list = dataManager.GetFilmModeList();

            var listFilm = dataManager.GetFilm_FilmModeList(filmId);

            foreach (var tmp in list)
            {
                var obj = listFilm.Find(p => p.FilmModeId == tmp.FilmModeId);
                if (obj != null)
                {
                    cblMode.Items.Add((object)tmp.FilmModeName, true);
                }
                else
                {
                    cblMode.Items.Add((object)tmp.FilmModeName, false);
                }

            }
            cblMode_ItemCheck(this, EventArgs.Empty);
        }

        #endregion

        private void chbHasMode_CheckedChanged(object sender, EventArgs e)
        {

            if (((CheckBox)sender).Checked == true)
            {
                List<Film> list = new List<Film>();
                list = dataBindingSource.DataSource as List<Film>;
                list.Find(p => p.FilmId == (txtFilmId.Text.Trim())).HasMode = true;
            }

        }

        #endregion

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("元", string.Empty)));
            }
            catch
            {
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((float)e.Value).ToString("0.00") + "元";
                }
                catch
                {

                }
            }
        }



        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Percent_Format(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = ((float)e.Value * 100).ToString() + "%";
            }
            catch
            {
                e.Value = "0%";
            }
        }


        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_Percent_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("%", string.Empty)) / 100);
            }
            catch
            {
            }
        }
        private void txtFilmLength_Validating(object sender, CancelEventArgs e)
        {
            if (txtFilmLength.Text != "")
            {
                if (VoucherBatchManage.IsIntegerNumber(txtFilmLength.Text) == false)
                {
                    MessageBox.Show("片长请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtFilmLength.Clear();
                    //txtFilmLength.DataBindings.Clear();
                    //txtFilmLength.DataBindings.Add("Text", dataBindingSource, "FilmLength", true);
                    //txtFilmLength.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilmLength.Focus();
                return;
            }
        }

        private void txtLowestPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtLowestPrice.Text == "" || txtLowestPrice.Text.Trim() == "0")
            {
                MessageBox.Show("影片最低票价不能为空或0！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (VoucherBatchManage.IsNumber(txtLowestPrice.Text) == false)
                {
                    MessageBox.Show("影片最低票价请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtLowestPrice.Clear();
                    //txtLowestPrice.DataBindings.Clear();
                    //txtLowestPrice.DataBindings.Add("Text", dataBindingSource, "LowestPrice", true);
                    //txtLowestPrice.Focus();
                    return;
                }

            }
        }

        private void txtRatio_Validating(object sender, CancelEventArgs e)
        {
            if (txtRatio.Text != "")
            {
                if (VoucherBatchManage.IsNumber(txtRatio.Text) == false)
                {
                    MessageBox.Show("片方分账比例请输入数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        txtRatio.Clear();
                    //        txtRatio.DataBindings.Clear();
                    //        txtRatio.DataBindings.Add("Text", dataBindingSource, "Ratio", true);
                    //        txtRatio.DataBindings["Text"].Format += TextBox_Percent_Format;
                    //        txtRatio.DataBindings["Text"].Parse += TextBox_Percent_Parse;
                    //        txtRatio.Focus();
                    //        return;
                }

            }
            //else
            //{
            //    txtRatio.Text = "0";
            //}
        }

    }
}

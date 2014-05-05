using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.ShowPlanManageLib;

namespace Flamingo.ShowPlanManage
{
    public partial class frmFilmSet : Form
    {

        #region 窗体变量
        private bool hashMode = false;
        private FilmSet filmSet;
        private DailyShowPlanManage dataManager;
        private Film film;
        private Film_FilmMode film_FilmMode;
        private string filmId = null;
        private List<FilmAndFilmMode> filmAndFilmModeList;
        #endregion


        #region 启动处理

        public frmFilmSet(DailyShowPlanManage datamanager, string FilmId, int Mode)
        {
            filmId = FilmId;
            InitializeComponent();
            filmSet = new FilmSet();
            this.dataManager = datamanager;
            Set(Mode);

        }
        private void Set(int mode)
        {
            if (mode == 0)
            {
                lblCode.Visible = false;
                lblNo.Visible = false;
                txtFilmId.Visible = false;
                txtFilmCode.Visible = false;
                this.Size = new Size(559, 158);
                label14.Visible = false;
                txtProducer.Visible = false;
            }
        }

        private void frmFilmSet_Load(object sender, EventArgs e)
        {
            try
            {
                //从数据库读取全部影片
                //   filmAndFilmModeList = filmSet.GetFilmAndFilmModeList();

                //只读取当天有效的影片
                filmAndFilmModeList = dataManager.RefreshfilmAndFilmModeList;
                foreach (var tmp in filmAndFilmModeList)
                {
                    if (tmp.HasMode == true && tmp.Film_FilmModeId != null && tmp.FilmModeId != null && tmp.FilmModeName != null)
                    {
                        if (tmp.FilmName.IndexOf('(') == -1 && tmp.FilmName.IndexOf(')') == -1)
                        {
                            tmp.FilmName = tmp.FilmName + "(" + tmp.FilmModeName + ")";
                        }
                        if (tmp.FilmId.IndexOf(';') == -1)
                            tmp.FilmId += ";" + tmp.FilmModeId;
                    }
                }

                FillData();

                try
                {
                    txtLowestPrice.Text = decimal.Round(Convert.ToDecimal(this.film.LowestPrice), 1).ToString("0.00");
                }
                catch { txtLowestPrice.Text = "0.00"; }
            }
            catch { }
        }

        #endregion


        #region 窗体事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据显示格式处理，添加到控件的Format事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Ratio_Format(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = ((float)e.Value * 100).ToString() + "%";
            }
            catch
            {
                e.Value =  "0%";
            }
        }


        /// <summary>
        /// TextBox控件绑定到百分比类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_Ratio_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("%", string.Empty)) / 100);
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
        public void TextBox_Currency_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((float)e.Value).ToString("0.00");
                }
                catch
                {
                   
                }
            }
            else
                e.Value = "0.00";
        }
   
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                film.HasMode = rbIsHrbIsHashMode_Yes.Checked;

                if (hashMode == false)
                {
                    film.BorderColour = lblColor.BackColor.A.ToString() + ";" + lblColor.BackColor.R.ToString() + ";" + lblColor.BackColor.G.ToString() + ";" + lblColor.BackColor.B.ToString();

                    dataManager.CheckShowPlanTime(film);
                }
                else
                {
                    film_FilmMode.BorderColour = lblColor.BackColor.A.ToString() + ";" + lblColor.BackColor.R.ToString() + ";" + lblColor.BackColor.G.ToString() + ";" + lblColor.BackColor.B.ToString();

                    dataManager.CheckShowPlanTime(film, film_FilmMode);
                }
                filmSet.Save();
                MessageBox.Show("修改成功！", "信息提示");
                DialogResult = DialogResult.OK;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #endregion

        #region 窗体函数


        //填充ComboBox
        private void FillData()
        {
            cbFilmName.ValueMember = "FilmId";
            cbFilmName.DisplayMember = "FilmName";
            cbFilmName.DataSource = filmAndFilmModeList;
            cbFilmName.SelectedValueChanged += new EventHandler(cbFilmName_SelectedIndexChanged);

            if (filmId != null)
                cbFilmName.SelectedValue = filmId;
            else
                cbFilmName.SelectedIndex = 0;
            cbFilmName_SelectedIndexChanged(this, EventArgs.Empty);

            cbFilmArea.ValueMember = "FilmAreaId";
            cbFilmArea.DisplayMember = "FilmAreaName";
            cbFilmArea.DataSource = filmSet.GetFilmAreaList();

            cbFilmArea.SelectedValueChanged += new EventHandler(cbFilmArea_SelectedIndexChanged);
            cbFilmArea.SelectedValue = film.FilmAreaId;

            cbFilmCategory.ValueMember = "FilmCategoryId";
            cbFilmCategory.DisplayMember = "FilmCategoryName";
            cbFilmCategory.DataSource = filmSet.GetFilmCategoryList();

            cbFilmCategory.SelectedValueChanged += new EventHandler(cbFilmCategory_SelectedIndexChanged);
            if (film.FilmCategoryId != null)
                cbFilmCategory.SelectedValue = film.FilmCategoryId;
        }

        #endregion

        private void cbFilmArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            film.FilmAreaId = cbFilmArea.SelectedValue.ToString();
        }

        private void cbFilmCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            film.FilmCategoryId = cbFilmCategory.SelectedValue.ToString();
        }


        private void cbFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Id;
            try
            {
                //取消下拉框以外控件的绑定
                UnBindData();

                //获取下拉框选择的值
                string FilmAndModeid = cbFilmName.SelectedValue.ToString();
                if (FilmAndModeid.Contains(";") == true)
                {
                    hashMode = true;
                    Id = FilmAndModeid.Split(';');
                    film = filmSet.GetFilm(Id[0]);
                    film_FilmMode = filmSet.GetFilm_FilmMode(Id[0], Convert.ToInt32(Id[1]));
                    try
                    {
                        string[] Array = film_FilmMode.BorderColour.Split(';');
                        Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                        lblColor.BackColor = color;
                    }
                    catch { lblColor.BackColor = Color.White; }
                }
                else
                {
                    //没有放映模式的
                    film = filmSet.GetFilm(FilmAndModeid);
                    hashMode = false;
                    try
                    {
                        string[] Array = film.BorderColour.Split(';');
                        Color color = Color.FromArgb(Convert.ToInt32(Array[0]), Convert.ToInt32(Array[1]), Convert.ToInt32(Array[2]), Convert.ToInt32(Array[3]));
                        lblColor.BackColor = color;
                    }
                    catch { lblColor.BackColor = Color.White; }
                }

                BindData();
                txtRatio.Text = film.Ratio * 100 + "%";
            }
            catch { }

        }

        private void BindData()
        {
            if (dataManager.CheckFilmUsed(film) == true)
                txtFilmLength.Enabled = true;
            else
                txtFilmLength.Enabled = false;

            txtFilmLength.DataBindings.Add("Text", film, "FilmLength", true);


            txtRatio.DataBindings.Add("Text", film, "Ratio", true);
            txtRatio.DataBindings["Text"].Format += TextBox_Ratio_Format;
            txtRatio.DataBindings["Text"].Parse += TextBox_Ratio_Parse;


            txtFilmId.DataBindings.Add("Text", film, "FilmId", true);
            txtFilmCode.DataBindings.Add("Text", film, "FilmCode", true);
            dtpPublishDate.DataBindings.Add("Value", film, "PublishDate", true);
            dtpStartDate.DataBindings.Add("Value", film, "StartDate", true);
            dtpEndDate.DataBindings.Add("Value", film, "EndDate", true);
            txtPubilsher.DataBindings.Add("Text", film, "Publisher", true);
            txtProducer.DataBindings.Add("Text", film, "Producer", true);
            txtDirector.DataBindings.Add("Text", film, "Director", true);
          
            txtLowestPrice.DataBindings.Add("Text", film, "LowestPrice", true);
            txtLowestPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
          
            // txtPoster.DataBindings.Add("Text", film, "Ratio", true);
            txtBrief.DataBindings.Add("Text", film, "Brief", true);
            txtCast.DataBindings.Add("Text", film, "Cast", true);

            if (film.HasMode != null)
                rbIsHrbIsHashMode_Yes.Checked = Convert.ToBoolean(film.HasMode);
        }

        // 清除绑定控件的值
        private void UnBindData()
        {
            try
            {
                txtRatio.DataBindings["Text"].Format -= TextBox_Ratio_Format;
                txtRatio.DataBindings["Text"].Parse -= TextBox_Ratio_Parse;
            }
            catch { }
            txtFilmLength.DataBindings.Clear();
            txtRatio.DataBindings.Clear();

            txtFilmId.DataBindings.Clear();
            txtFilmCode.DataBindings.Clear();

            dtpPublishDate.DataBindings.Clear();
            dtpStartDate.DataBindings.Clear();
            dtpEndDate.DataBindings.Clear();
            txtPubilsher.DataBindings.Clear();

            txtProducer.DataBindings.Clear();
            txtDirector.DataBindings.Clear();
            txtLowestPrice.DataBindings.Clear();

            txtPoster.DataBindings.Clear();
            txtBrief.DataBindings.Clear();
            txtCast.DataBindings.Clear();
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            ColorDialog frm = new ColorDialog();
            frm.AllowFullOpen = true;
            frm.AnyColor = true;
            frm.FullOpen = true;
            frm.ShowHelp = true;
            if (frm.ShowDialog() == DialogResult.OK)
                lblColor.BackColor = frm.Color;

        }

    }
}

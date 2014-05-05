using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Flamingo.TicketManage;

namespace Flamingo.TheaterManage
{
    //2011/12/20,Qiu
    public partial class frmFilmHallManage : Flamingo.BaseForm.frmManageBase
    {
        #region 窗体变量

        private FilmHallManage dataManager;

        #endregion

        #region   启动处理

        public frmFilmHallManage()
        {
            InitializeComponent();

            dataManager = new FilmHallManage();
            dataBindingSource = new BindingSource();

            this.dataGridViewColumnInfoList = dataManager.ColumnInfoList;
            dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);
            this.Load += new EventHandler(frmFilmHallManage_Load);
        }

        private void frmFilmHallManage_Load(object sender, EventArgs e)
        {

            RefreshDataList();

            BindData();

            FillList();

            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;

            txtKeyWord.Select();

            // ReSetListLocate();
        }


        #endregion

        #region   窗体事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataBindingSource.DataSource = dataManager.GetSearchList("HallName", txtKeyWord.Text.Trim());
        }

        /// <summary>
        /// 数据显示格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name.Contains("Seats"))
            {
                try
                {

                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString() + "个";
                }
                catch
                {
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Contains("Levels"))
            {
                try
                {
                    e.Value = decimal.Round(Convert.ToDecimal(e.Value), 2).ToString() + "层";
                }
                catch
                {
                }
            }
        }

        #endregion

        #region  窗体函数

        #region  父窗体函数

        /// <summary>
        /// 新增数据
        /// </summary>
        protected override void AddData()
        {
            try
            {
                dataBindingSource.Add(dataManager.NewData());
                dataBindingSource.MoveLast();

                // txtHallId.Select();
            }
            catch { }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        protected override void EditData() { }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override void DelData()
        {
            if (dataBindingSource.Current != null)
            {
                dataManager.DeleteData((Hall)dataBindingSource.Current);
                dataBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool Save()
        {
            try
            {
                this.dataManager.Save();

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

        #region  其它函数

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
                FormatDataList();

            ReSetDataArea();
        }

        /// <summary>
        /// 绑定明细控件
        /// </summary>
        private void BindData()
        {
            txtHallId.DataBindings.Clear();
            txtFilmName.DataBindings.Clear();
            CbTheaterName.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtLevels.DataBindings.Clear();
            txtScreen.DataBindings.Clear();
            txtProjector.DataBindings.Clear();
            txtPlayMode.DataBindings.Clear();
            txtSoundSystem.DataBindings.Clear();
            txtDescription.DataBindings.Clear();

            txtHallId.DataBindings.Add("Text", dataBindingSource, "HallId", true);
            txtFilmName.DataBindings.Add("Text", dataBindingSource, "HallName", true);
            txtSeats.DataBindings.Add("Text", dataBindingSource, "Seats", true);
            txtSeats.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtSeats.DataBindings["Text"].Parse += TextBox_Currency_Parse;

            txtLevels.DataBindings.Add("Text", dataBindingSource, "Levels", true);
            txtLevels.DataBindings["Text"].Format += TextBox_Currency_Format1;
            txtLevels.DataBindings["Text"].Parse += TextBox_Currency_Parse1;
            
            txtScreen.DataBindings.Add("Text", dataBindingSource, "Screen", true);
            txtProjector.DataBindings.Add("Text", dataBindingSource, "Projector", true);
            txtPlayMode.DataBindings.Add("Text", dataBindingSource, "PlayMode", true);
            txtSoundSystem.DataBindings.Add("Text", dataBindingSource, "SoundSystem", true);
            txtDescription.DataBindings.Add("Text", dataBindingSource, "Description", true);
            CbTheaterName.DataBindings.Add("SelectedValue", dataBindingSource, "TheaterId", true);
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (int)(Convert.ToDecimal(((string)e.Value).Replace("个", string.Empty)));
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
                    e.Value = ((int)e.Value).ToString() + "个";
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Currency_Parse1(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (int)(Convert.ToDecimal(((string)e.Value).Replace("层", string.Empty)));
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
        public static void TextBox_Currency_Format1(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = ((int)e.Value).ToString() + "层";
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 填充所有 ComboBox 控件数据
        /// </summary>
        private void FillList()
        {
            TheaterList();

        }

        /// <summary>
        /// 填充下拉框：影院名称
        /// </summary>
        private void TheaterList()
        {
            CbTheaterName.DisplayMember = "TheaterName";
            CbTheaterName.ValueMember = "TheaterId";

            CbTheaterName.DataSource = TheaterInfoManage.DirectGetAllList();
        }

        protected override void ApplyReadonlyConfig()
        {
            txtHallId.Enabled = false;
            //CbTheaterName.Enabled = false;
            txtFilmName.Enabled = false;
            txtSeats.Enabled = false;
            txtLevels.Enabled = false;
        }


        #endregion

        private void scSplit_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        private void txtSeats_Validating(object sender, CancelEventArgs e)
        {
            if (txtSeats.Text != "")
            {
                txtSeats.Text = txtSeats.Text.Replace("个", string.Empty);
                if (VoucherBatchManage.IsIntegerNumber(txtSeats.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
                    txtSeats.DataBindings.Clear();
                    txtSeats.DataBindings.Add("Text", dataBindingSource, "Seats", true);
                    txtSeats.DataBindings["Text"].Format += TextBox_Currency_Format;
                    txtSeats.DataBindings["Text"].Parse += TextBox_Currency_Parse;
                    txtSeats.Clear();
                    txtSeats.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSeats.Focus();
                return;
            }
        }

        private void txtLevels_Validating(object sender, CancelEventArgs e)
        {
            if (txtLevels.Text != "")
            {
                txtLevels.Text = txtLevels.Text.Replace("层", string.Empty);
                if (VoucherBatchManage.IsIntegerNumber(txtLevels.Text) == false)
                {
                    MessageBox.Show("请输入整数", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    txtLevels.DataBindings.Clear();
                    txtLevels.DataBindings.Add("Text", dataBindingSource, "Levels", true);
                    txtLevels.DataBindings["Text"].Format += TextBox_Currency_Format1;
                    txtLevels.DataBindings["Text"].Parse += TextBox_Currency_Parse1;
                    txtLevels.Clear();
                    txtLevels.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请输入符合的数字", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLevels.Focus();
                return;
            }
        }
    }
}

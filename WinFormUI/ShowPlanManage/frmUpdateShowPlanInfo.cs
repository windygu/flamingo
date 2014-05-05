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
    public partial class frmUpdateShowPlanInfo : Form
    {
        #region 窗体变量
        private FlamingoEntities de;
        public ShowPlan showPlan;
        private DailyShowPlanManage dataManager;
        private int fareSettingId;
        private List<EmployeeInfo> employeeInfoList;

        #endregion

        #region 启动处理
        public frmUpdateShowPlanInfo(ShowPlan Showplan, DailyShowPlanManage datamager)
        {
            InitializeComponent();

            this.showPlan = Showplan;

            this.dataManager = datamager;
            de = Database.GetNewDataEntity();
            employeeInfoList = new List<EmployeeInfo>();            
        }

        private void frmUpdateShowPlanInfo_Load(object sender, EventArgs e)
        {
            employeeInfoList = dataManager.GetEmployeeInfoList();

            //获取分场票价的等级编号
            fareSettingId = dataManager.GetFareSettingId("分场票价");

            //绑定Text控件
            BindData();

            //填充ComboBox
            FillData();

            //填充单选控件的值
            FillrbData();
         //   SetPrice();

        }

        #endregion

        #region 窗体事件
        private void cbShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取场次类型
            this.showPlan.ShowTypeId = Convert.ToInt32(cbShowType.SelectedValue);
            SelectShowType((int)this.showPlan.ShowTypeId);
        }

        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取特价类型
            this.showPlan.DiscountTypeId = Convert.ToInt32(cbDiscount.SelectedValue);
            //if (cbDiscount.SelectedValue == string.Empty)
            //    this.showPlan.IsDiscounted = false ;
        }

        private void cbStagehand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStagehand.SelectedValue != null)
                this.showPlan.Stagehand = Convert.ToInt32(cbStagehand.SelectedValue);
            else
                this.showPlan.Stagehand = null;
        }


        private void cbProjectionist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProjectionist.SelectedValue != null)
                this.showPlan.Projectionist = Convert.ToInt32(cbProjectionist.SelectedValue);
            else
                this.showPlan.Projectionist = null;
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
        }

        /// <summary>
        /// TextBox控件绑定到货币类型数据源时的数据填充处理，添加到控件的Parse事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_Currency_Parse(object sender, ConvertEventArgs e)
        {
            try
            {
                e.Value = (float)(Convert.ToDecimal(((string)e.Value)));
            }
            catch
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //if ((int)nuTimeSpan.Value < dataManager.DailyShowPlan.DailyPlan.Timespan)
                //{
                //    nuTimeSpan.Value = (decimal)dataManager.DailyShowPlan.DailyPlan.Timespan;
                //    MessageBox.Show("最小场间隔不能小于日计划的场间隔！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (this.showPlan.ShowTypeId == 2 && cbCarom.SelectedIndex < 0)
                {
                    MessageBox.Show("请先选择连场组号！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.showPlan.ShowTypeId == 3 && cbCycles.SelectedIndex < 0)
                {
                    MessageBox.Show("请先选择循环场组号！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.showPlan.LowestPrice > this.showPlan.SinglePrice
                    || this.showPlan.LowestPrice > this.showPlan.DoublePrice
                    || this.showPlan.LowestPrice > this.showPlan.StudentPrice
                    //|| tmp.Film.LowestPrice > theaterPrice.GroupPrice
                    || this.showPlan.LowestPrice > this.showPlan.MemberPrice
                    || this.showPlan.LowestPrice > this.showPlan.BoxPrice)
                {
                    MessageBox.Show("最低票价不能小于影片的最低价！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //判断设置的放映时间是否符合要求
                dataManager.CheckShowPlan(this.showPlan);

                //把票价设置等级更新为分场票价等级
                this.showPlan.FareSettingId = fareSettingId;


                //重新更新单选控件的值
                Updaterb();

                DialogResult = DialogResult.OK;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            dtpEndTime.Value = dtpStartTime.Value.AddMinutes((int)this.showPlan.FilmLength);
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
                e.Value = (float)(Convert.ToDecimal(((string)e.Value).Replace("%", string.Empty))/100);
            }
            catch
            {
                e.Value = "0%";
            }
        }

        #endregion

        #region 窗体函数

        private void SelectShowType(int showType)
        {
            gbShowType.Enabled = true;

            switch (showType)
            {
                case 2:
                    this.showPlan.Timespan = 0;
                    rbCarom.Checked = true;
                    cbCarom.SelectedItem = showPlan.ShowGroup.ToString();

                    rbCarom.Enabled = true;
                    cbCarom.Enabled = true;
                    rbCycles.Enabled = false;
                    cbCycles.Enabled = false;
                    this.showPlan.ShowPlanName.Replace("(循环场)", "");
                    if (this.showPlan.ShowPlanName.Contains("(连场)") != true)
                        this.showPlan.ShowPlanName += "(连场)";
                    rbCommon.Enabled = false;
                    break;
                case 3:
                    this.showPlan.Timespan = 0;
                    rbCycles.Checked = true;
                    cbCycles.SelectedItem = showPlan.ShowGroup.ToString();
                    this.showPlan.ShowPlanName.Replace("(连场)", "");
                    if (this.showPlan.ShowPlanName.Contains("(循环场)") != true)
                        this.showPlan.ShowPlanName += "(循环场)";
                    rbCycles.Enabled = true;
                    cbCycles.Enabled = true;

                    rbCarom.Enabled = false;
                    cbCarom.Enabled = false;

                    rbCommon.Enabled = false;
                    break;
                case 4:
                    rbCommon.Checked = true;
                    rbCommon.Enabled = true;
                    this.showPlan.ShowPlanName.Replace("(连场)", "");
                    this.showPlan.ShowPlanName.Replace("(循环场)", "");
                    rbCarom.Enabled = false;
                    cbCarom.Enabled = false;

                    rbCycles.Enabled = false;
                    cbCycles.Enabled = false;
                    break;
                default:
                    gbShowType.Enabled = false;
                    this.showPlan.ShowPlanName.Replace("(连场)", "");
                    this.showPlan.ShowPlanName.Replace("(循环场)", "");
                    break;
            }
        }

        /// <summary>
        /// 填充单选控件的值
        /// </summary>

        private void FillrbData()
        {
            rbIsCheckingNumber_Yes.Checked = (bool)this.showPlan.IsCheckingNumber;
            rbIsOnlineTicketing_Yes.Checked = (bool)this.showPlan.IsOnlineTicketing;
            rbIsTicketChecking_Yes.Checked = (bool)this.showPlan.IsTicketChecking;
            rbIsDiscounted_Yes.Checked = (bool)this.showPlan.IsDiscounted;
        }

        /// <summary>
        /// 重新更新showPlan的值
        /// </summary>
        private void Updaterb()
        {
            this.showPlan.IsCheckingNumber = rbIsCheckingNumber_Yes.Checked;
            this.showPlan.IsOnlineTicketing = rbIsOnlineTicketing_Yes.Checked;
            this.showPlan.IsTicketChecking = rbIsTicketChecking_Yes.Checked;
            this.showPlan.IsDiscounted = rbIsDiscounted_Yes.Checked;
        }


        // 绑定控件的值
        private void BindData()
        {
            //if (this.showPlan.ShowTypeId != null && (this.showPlan.ShowTypeId == 3 || this.showPlan.ShowTypeId == 2))
            //    txtFilmName.Text = this.showPlan.Film.FilmName + "(" + this.showPlan.ShowType.ShowTypeName + ")";
            //else
            txtFilmName.Text = this.showPlan.ShowPlanName;

            txtHall.Text = this.showPlan.Hall.HallName;
            txtTheater.Text = this.showPlan.Hall.Theater.TheaterName;

            //如果现在票价的优先级大于分场票价的优先级，把价格设置设为只读
            if (this.showPlan.FareSettingId > fareSettingId)
            {
                txtSinglePrice.Enabled = false;
                txtDoublePrice.Enabled = false;
                txtStudentPrice.Enabled = false;
                txtGroupPrice.Enabled = false;
                txtMemberPrice.Enabled = false;
                txtBoxPrice.Enabled = false;
            }
            txtLowestPrice.DataBindings.Add("Text", this.showPlan, "LowestPrice", true);
            txtLowestPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtLowestPrice.DataBindings["Text"].ReadValue();

            txtSinglePrice.DataBindings.Add("Text", this.showPlan, "SinglePrice", true);
            txtSinglePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtSinglePrice.DataBindings["Text"].ReadValue();

            txtDoublePrice.DataBindings.Add("Text", this.showPlan, "DoublePrice", true);
            txtDoublePrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtDoublePrice.DataBindings["Text"].ReadValue();

            txtStudentPrice.DataBindings.Add("Text", this.showPlan, "StudentPrice", true);
            txtStudentPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtStudentPrice.DataBindings["Text"].ReadValue();

            txtGroupPrice.DataBindings.Add("Text", this.showPlan, "GroupPrice", true);
            txtGroupPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtGroupPrice.DataBindings["Text"].ReadValue();

            txtMemberPrice.DataBindings.Add("Text", this.showPlan, "MemberPrice", true);
            txtMemberPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtMemberPrice.DataBindings["Text"].ReadValue();

            txtBoxPrice.DataBindings.Add("Text", this.showPlan, "BoxPrice", true);
            txtBoxPrice.DataBindings["Text"].Format += TextBox_Currency_Format;
            txtBoxPrice.DataBindings["Text"].ReadValue();


            txtPosition.DataBindings.Add("Text", this.showPlan, "Position", true);
            txtNo.DataBindings.Add("Text", this.showPlan, "ShowPlanId", true);
            txtShowPlanNo.DataBindings.Add("Text", this.showPlan, "ShowPlanId", true);

            dtpStartTime.DataBindings.Add("Text", this.showPlan, "StartTime", true);
            dtpEndTime.DataBindings.Add("Text", this.showPlan, "EndTime", true);
            nuTimeSpan.DataBindings.Add("Value", this.showPlan, "Timespan", true);

            txtFilmLength.DataBindings.Add("Text", this.showPlan, "FilmLength", true);
            txtRatio.DataBindings.Add("Text", this.showPlan, "Ratio", true);
            txtRatio.DataBindings["Text"].Format += TextBox_Ratio_Format;
            txtRatio.DataBindings["Text"].Parse += TextBox_Ratio_Parse;
            txtRatio.DataBindings["Text"].ReadValue();
        }

        private void SetPrice()
        {
            try
            {
                txtSinglePrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.SinglePrice), 1).ToString("0.00");
                txtDoublePrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.DoublePrice), 1).ToString("0.00");
                txtStudentPrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.StudentPrice), 1).ToString("0.00");
                txtGroupPrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.GroupPrice), 1).ToString("0.00");
                txtMemberPrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.MemberPrice), 1).ToString("0.00");
                txtBoxPrice.Text = decimal.Round(Convert.ToDecimal(this.showPlan.BoxPrice), 1).ToString("0.00");
            }
            catch { }
        }

        //填充ComboBox
        private void FillData()
        {
            //绑定场次类型
            cbShowType.ValueMember = "ShowTypeId";
            cbShowType.DisplayMember = "ShowTypeName";
            cbShowType.DataSource = de.ShowType.OrderBy(p => p.ShowTypeId).ToList();
            cbShowType.SelectedValueChanged += new EventHandler(cbShowType_SelectedIndexChanged);
            cbShowType.SelectedValue = this.showPlan.ShowTypeId.Value;




            ////绑定特价类型
            cbDiscount.ValueMember = "DiscountTypeId";
            cbDiscount.DisplayMember = "DiscountTypeName";
            cbDiscount.DataSource = de.DiscountType.OrderBy(p => p.DiscountTypeId).ToList();

            cbDiscount.SelectedValueChanged += new EventHandler(cbDiscount_SelectedIndexChanged);
            if (this.showPlan.DiscountTypeId != null)
                cbDiscount.SelectedValue = this.showPlan.DiscountTypeId.Value;

            EmployeeInfo tmp = new EmployeeInfo();
            tmp.UserNmae = "请选择";

            //场务员
            cbStagehand.ValueMember = "UserId";
            cbStagehand.DisplayMember = "UserNmae";
            List<EmployeeInfo> StagehandList = new List<EmployeeInfo>();
            StagehandList.Add(tmp);
            StagehandList.AddRange(employeeInfoList.Where(p => p.RoleName == "场务员").OrderBy(p => p.UserId).ToList());
            cbStagehand.DataSource = StagehandList;

            cbStagehand.SelectedValueChanged += new EventHandler(cbStagehand_SelectedIndexChanged);
            if (this.showPlan.Stagehand != null)
                cbStagehand.SelectedValue = this.showPlan.Stagehand.Value;
            //放映员
            cbProjectionist.ValueMember = "UserId";
            cbProjectionist.DisplayMember = "UserNmae";
            List<EmployeeInfo> ProjectionistList = new List<EmployeeInfo>();
            ProjectionistList.Add(tmp);
            ProjectionistList.AddRange(employeeInfoList.Where(p => p.RoleName == "放映员").OrderBy(p => p.UserId).ToList());
            cbProjectionist.DataSource = ProjectionistList;

            cbProjectionist.SelectedValueChanged += new EventHandler(cbProjectionist_SelectedIndexChanged);
            if (this.showPlan.Projectionist != null)
                cbProjectionist.SelectedValue = this.showPlan.Projectionist.Value;
        }

        #endregion

        private void cbCarom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showPlan.ShowGroup = Convert.ToInt32(cbCarom.SelectedItem);
        }

        private void cbCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showPlan.ShowGroup = Convert.ToInt32(cbCycles.SelectedItem);
        }

        private void rbIsDiscounted_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIsDiscounted_Yes.Checked == true)
                cbDiscount.Enabled = true;
            else
                cbDiscount.Enabled = false;
        }

    }
}

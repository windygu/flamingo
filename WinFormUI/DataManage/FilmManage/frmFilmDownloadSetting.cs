using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flamingo.FilmManage
{
    public partial class frmFilmDownloadSetting : Form
    {
        public frmFilmDownloadSetting()
        {
            InitializeComponent();

            LoadParameter();
        }

        private void frmFilmDownloadSetting_Load(object sender, EventArgs e)
        {
            int x = (this.Width - panel2.Width) / 2;
            int y = (this.Height - panel2.Height) / 2;
            panel2.Location = new Point(x, y);
        }

        private void LoadParameter()
        {
            string startYear = Property.Setting.StartYear;
            string yearPara = Property.Setting.YearPara;
            string downloadMethod = Property.Setting.DownloadMethod;

            txtStartYear.Text = startYear;

            txtYearPara.Text = yearPara;

            switch (downloadMethod)
            {
                case "HTTP":
                    rbHttp.Checked = true;
                    break;

                case "FTP":
                    rbFtp.Checked = true;
                    break;

                case "FILE":
                    rbFile.Checked = true;
                    break;
            }
        }

        private void SaveParameter()
        {
            Property.Setting.StartYear = txtStartYear.Text;
            Property.Setting.YearPara = txtYearPara.Text;

            if (rbHttp.Checked == true)
                Property.Setting.DownloadMethod = "HTTP";
            else if (rbFtp.Checked == true)
                Property.Setting.DownloadMethod = "FTP";
            else if (rbFile.Checked == true)
                Property.Setting.DownloadMethod = "FILE";

            Property.Setting.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveParameter();

                MessageBox.Show("保存成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("保存失败!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

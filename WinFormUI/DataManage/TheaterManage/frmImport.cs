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
    public partial class frmImport : Form
    {
        private TheaterInfoManage dataManager;
        public frmImport()
        {
            InitializeComponent();

            dataManager = new TheaterInfoManage();

        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            int x = (this.Width - panTheater.Width) / 2;
            int y = (this.Height - panTheater.Height) / 2;
            panTheater.Location = new Point(x, y);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string oldstr;
                string pathstr = txtPath.Text;
                if (File.Exists(pathstr) == true)
                {
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
                    dataManager.SetInfo(ds);
                    MessageBox.Show("导入授权文件成功！", "信息提示");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("选择的授权文件不存在，请重新选择！", "信息提示");
                }
            }
            catch (Exception ex) { MessageBox.Show("导入授权文件失败！\n" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "授权文件(*.key)|*.key|所有文件(*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
                txtPath.Text = file.FileName;
        }
    }
}

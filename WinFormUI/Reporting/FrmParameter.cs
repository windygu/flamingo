using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System.Xml;

namespace WinFormUI.Reporting
{
    public partial class FrmParameter : Form
    {
        private DateTime StartDate = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
        private DateTime EndDate = System.DateTime.Today.AddDays(-1);
        private String Halls = null;
        private String Films = null;
        private String Users = null;

        public FrmParameter()
        {
            InitializeComponent();
        }

        private void FrmParameter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flamingoDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.flamingoDataSet.user);
            // TODO: This line of code loads data into the 'flamingoDataSet.hall' table. You can move, or remove it, as needed.
            this.hallTableAdapter.Fill(this.flamingoDataSet.hall);
            // TODO: This line of code loads data into the 'flamingoDataSet.film' table. You can move, or remove it, as needed.
            this.filmTableAdapter.FillByDate(this.flamingoDataSet.film, StartDate, EndDate);
            this.dateTimePicker1.Value = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
            this.dateTimePicker2.Value = System.DateTime.Today.AddDays(-1);
            setTreeViewHall();
            setTreeViewUser();
            setTreeViewFilm();
        }

        public DateTime GetStartDate()
        {
            return StartDate;
        }

        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public String GetHalls()
        {
            return Halls;
        }

        public String GetFilms()
        {
            return Films;
        }

        public String GetUsers()
        {
            return Users;
        }

        private void SetHalls(TreeView tv)
        {
            TreeNode rootHall = tv.Nodes[0];
            if (rootHall.Checked == true || rootHall == null)
                Halls = null;
            else
            {
                foreach (TreeNode tn in rootHall.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        if (Halls == null)
                            Halls += tn.Name;
                        else
                            Halls += "," + tn.Name;
                    }
                }
            }
        }

        private void SetFilms(TreeView tv)
        {
            TreeNode rootFilm = tv.Nodes[0];
            if (rootFilm.Checked == true || rootFilm == null)
                Films = null;
            else
            {
                foreach (TreeNode tn in rootFilm.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        if (Films == null)
                            Films += tn.Name;
                        else
                            Films += "," + tn.Name;
                    }
                }
            }
        }

        private void SetUsers(TreeView tv)
        {
            TreeNode rootUser = tv.Nodes[0];
            if (rootUser.Checked == true || rootUser == null)
                Users = null;
            else
            {
                foreach (TreeNode tn in rootUser.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        if (Users == null)
                            Users += tn.Name;
                        else
                            Users += "," + tn.Name;
                    }
                }
            }
        }

        //private TreeNode FindNode(TreeNode tnParent, string strValue)
        //{
        //    if (tnParent == null) return null;
        //    if (tnParent.Text == strValue) return tnParent;
        //    TreeNode tnRet = null;
        //    foreach (TreeNode tn in tnParent.Nodes)
        //    {
        //        tnRet = FindNode(tn, strValue);
        //        if (tnRet != null) break;
        //    }
        //    return tnRet;
        //}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null && e.Node.Nodes.Count != 0)
            {
                if (e.Node.Checked == true)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == false)
                        {
                            e.Node.Nodes[i].Checked = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == true)
                        {
                            e.Node.Nodes[i].Checked = false;
                        }
                    }
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null && e.Node.Nodes.Count != 0)
            {
                if (e.Node.Checked == true)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == false)
                        {
                            e.Node.Nodes[i].Checked = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == true)
                        {
                            e.Node.Nodes[i].Checked = false;
                        }
                    }
                }
            }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null && e.Node.Nodes.Count != 0)
            {
                if (e.Node.Checked == true)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == false)
                        {
                            e.Node.Nodes[i].Checked = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        if (e.Node.Nodes[i].Checked == true)
                        {
                            e.Node.Nodes[i].Checked = false;
                        }
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StartDate = this.dateTimePicker1.Value;
            filmTableAdapter.FillByDate(this.flamingoDataSet.film, StartDate, EndDate);
            this.treeView2.Nodes.Clear();
            setTreeViewFilm();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            EndDate = this.dateTimePicker2.Value;
            filmTableAdapter.FillByDate(this.flamingoDataSet.film, StartDate, EndDate);
            this.treeView2.Nodes.Clear();
            setTreeViewFilm();
        }

        private void setTreeViewHall()
        {
            TreeNode rootHall = new TreeNode();
            rootHall.Text = "全部影厅";
            rootHall.Checked = true;
            this.treeView1.Nodes.Add(rootHall);
            foreach (DataRow dr in this.flamingoDataSet.hall.Rows)
            {
                rootHall.Nodes.Add(dr["HallName"].ToString()).Name = dr["HallId"].ToString();
            }
            this.treeView1.TopNode.ExpandAll();
        }

        private void setTreeViewFilm()
        {
            TreeNode rootFilm = new TreeNode();
            rootFilm.Text = "全部影片";
            rootFilm.Checked = true;
            this.treeView2.Nodes.Add(rootFilm);
            foreach (DataRow dr in this.flamingoDataSet.film.Rows)
            {
                rootFilm.Nodes.Add(dr["FilmName"].ToString()).Name = dr["FilmId"].ToString();
            }
            this.treeView2.TopNode.ExpandAll();
        }

        private void setTreeViewUser()
        {
            TreeNode rootUser = new TreeNode();
            rootUser.Text = "全部员工";
            rootUser.Checked = true;
            this.treeView3.Nodes.Add(rootUser);
            foreach (DataRow dr in this.flamingoDataSet.user.Rows)
            {
                rootUser.Nodes.Add(dr["EmployeeName"].ToString()).Name = dr["UserId"].ToString();
            }
            this.treeView3.TopNode.ExpandAll();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                MessageBox.Show("截止日期不能早于开始日期，请重新选择", "日期选择错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SetHalls(treeView1);
                SetFilms(treeView2);
                SetUsers(treeView3);
                StartDate = this.dateTimePicker1.Value;
                EndDate = this.dateTimePicker2.Value;
                DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}

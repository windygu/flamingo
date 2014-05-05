using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Flamingo.FilmManage
{
    public partial class frmPoster : Form
    {
        public frmPoster(byte[] Poster)
        {
            InitializeComponent();
            pbPoster.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
            MemoryStream ms = new MemoryStream(Poster);
            Image img = Image.FromStream(ms);
            this.Size = new System.Drawing.Size(img.Width + 20, img.Height + 110);
            pbPoster.Size = new Size(img.Width, img.Height);
            this.pbPoster.Image = img;
            btnCancel.Location = new Point(this.panel1.Width / 2 - 100, this.btnOk.Location.Y);
            btnOk.Location = new Point(this.panel1.Width / 2 + 100, this.btnOk.Location.Y);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flamingo.TemplateCore;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace WinFormUI.TemplateUI
{
    public partial class TemplateSettingForm : Form
    {

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);
        public static double MillimetersToPixelsWidth(double length)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 88);     // HORZRES 
            //int pixels = GetDeviceCaps(hdc, 88);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            //return (((double)pixels / (double)width) * (double)length) / 25.4;
            return width * length / 254;
        }
        public static double PixelsToMillimetersWidth(double pixels)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 88);     // HORZRES 
            //int pixels = GetDeviceCaps(hdc, 8);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            //return (((double)width / (double)pixels) * (double)length) * 25.4;
            return 254 * pixels / (double)width;
            //254.0 / (double)GetDeviceCaps(hdc, LOGPIXELSX)
        }

        TemplateSettingType type;

        Template template = null;

        TemplateCore temp = new Flamingo.TemplateCore.TemplateCore();

        public Template Template
        {
            get { return template; }
            set { template = value; }
        }

        public TemplateSettingForm(TemplateSettingType type)
        {
            InitializeComponent();
            this.type = type;
            InitForm();
        }

        private void InitForm()
        {
            //InitPrintComboBox
            InitPrintComboBox();

            if (type == TemplateSettingType.New)
            {
                EditButton.Enabled = false;
                PictureSelectButton.Enabled = true;
                radioButton1.Enabled = true;
                lengthTextBox.Enabled = true;
                widthTextBox.Enabled = true;
                radioButton2.Enabled = true;
                SettingTextBox.Enabled = false;
                BgEditButton.Enabled = false;
                bgSaveButton.Enabled = true;
                radioButton1.Checked = true;
                SettingButton.Enabled = true;
                template = temp.CreateNewTemplate();
            }
            if (type == TemplateSettingType.View)
            {
                TemplateNameTextbox.Enabled = false;
                TemplateTypeComboBox.Enabled = false;
                EditButton.Enabled = false;
                PictureSelectButton.Enabled = false;
                radioButton1.Enabled = false;
                lengthTextBox.Enabled = false;
                widthTextBox.Enabled = false;
                radioButton2.Enabled = false;
                SettingTextBox.Enabled = false;
                BgEditButton.Enabled = false;
                bgSaveButton.Enabled = false;
                radioButton1.Checked = false;
                SettingButton.Enabled = false;
                SaveButton.Enabled = false;
                TemplateFaceListBox.Enabled = false;
                FaceItemsListBox.Enabled = false;
                //this.TemplateFaceListBox.SelectedIndexChanged -= new System.EventHandler(this.TemplateFaceListBox_SelectedIndexChanged);
                //InitTemplate();
            }
            if (type == TemplateSettingType.Edit)
            {
                radioButton1.Checked = true;
            }

        }

        private void InitListForm(int templateId)
        {
            if (TemplateSettingType.New == type)
            {
                return;
            }
            else if (template.Template_Type == TemplateType.File)
            {
                TemplateFaceListBox.Items.Clear();
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影院名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影厅名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影片名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "排号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "座号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "排号座号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "时间"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票价"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票种"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "入座方式"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "支付方式"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "售票员工号"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "出票时间"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "条码"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "图标"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "厅场码"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "售票时间和工号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "场次序号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "厅号和场次"));
            }
            else
            {
                TemplateFaceListBox.Items.Clear();
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票券名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票券面值"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影院名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "发行日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "使用截至日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "描述"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "类型"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "券类"));
            }
            AddTemplateFaceByTemplateId();
        }

        private void AddTemplateFaceByTemplateId()
        {
            IList<string> itemNames = temp.GetAllTemplateItemExt(TemplateTypeHelp.GetTemplateString(template.Template_Type));
            foreach (string itemName in itemNames)
            {
                TemplateFaceListBox.Items.Add(new ItemTypeField(false, itemName));
            }
        }

        private void SaveTemplateFaceItem()
        {
            //template.CustomItems.Clear();
            temp.DeleteCustomItem(TemplateTypeHelp.GetTemplateString(template.Template_Type));
            foreach (object o in TemplateFaceListBox.Items)
            {
                ItemTypeField field = o as ItemTypeField;
                if (field.Basic == false)
                {
                    temp.SaveCustomItems(TemplateTypeHelp.GetTemplateString(template.Template_Type), field.Name);
                }
            }
        }

        class ItemTypeField
        {
            bool basic;

            public bool Basic
            {
                get { return basic; }
                // set { basic = value; }
            }
            string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public ItemTypeField(bool b, string n)
            {
                basic = b;
                name = n;
            }

            public override string ToString()
            {
                return name;
            }

        }

        private void ChangeForm()
        {
            if (TemplateTypeComboBox.Text == TemplateTypeHelp.GetTemplateString(TemplateType.File))
            {
                TemplateFaceListBox.Items.Clear();
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影院名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影厅名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影片名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "排号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "座号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "排号座号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "时间"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票价"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票种"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "入座方式"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "支付方式"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "售票员工号"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "出票时间"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "条码"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "图标"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "厅场码"));
            }
            else
            {
                TemplateFaceListBox.Items.Clear();
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票券名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "票券面值"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "影院名称"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "发行日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "使用截至日期"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "描述"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "类型"));
                TemplateFaceListBox.Items.Add(new ItemTypeField(true, "券类"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "售票员工号2"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "出票时间2"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "条码2"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "图标2"));
                //TemplateFaceListBox.Items.Add(new ItemTypeField(true, "厅场码2"));
            }
            AddTemplateFaceByTemplateId();
        }

        private void InitPrintComboBox()
        {
            PrintComboBox.Items.Clear();
            foreach (string printName in PrinterSettings.InstalledPrinters)
            {
                PrintComboBox.Items.Add(printName);
            }
        }

        internal void InitTemplate()
        {
            TemplateNameTextbox.Text = template.Name;
            TemplateTypeComboBox.Text = TemplateTypeHelp.GetTemplateString(template.Template_Type);
            lengthTextBox.Text = template.Background.ImageWidth.ToString();
            widthTextBox.Text = template.Background.ImageHeight.ToString();
            pictureBox1.Image = template.Background.BgImage;
            pictureBox1.Size = new Size((int)MillimetersToPixelsWidth(template.Background.ImageWidth), (int)MillimetersToPixelsWidth(template.Background.ImageHeight));
            TemplateFacePanel.BackgroundImage = template.Background.BgImage;
            TemplateFacePanel.Size = new Size((int)MillimetersToPixelsWidth(template.Background.ImageWidth), (int)MillimetersToPixelsWidth((template.Background.ImageHeight)));
            xLe = template.Background.ImageWidth;
            yLe = template.Background.ImageHeight;

            if (template.PrintSetting != null)
            {
                PrintComboBox.Text = template.PrintSetting.PrintModule;
            }
            BindFaceItemsListBox();
            //EditPrintBtn.Enabled = false;
            EditButton.Enabled = false;
            BgEditButton.Enabled = false;
            //FaceItemsListBox.SelectedIndex = -1;
            InitListForm(template.TemplateId);
        }

        #region Page1

        private void EditButton_Click(object sender, EventArgs e)
        {
            TemplateNameTextbox.Enabled = true;
            TemplateTypeComboBox.Enabled = true;
            EditButton.Enabled = false;
            SaveButton.Enabled = true;
            PrintComboBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (TemplateNameTextbox.Text.Trim() == "")
            {
                MessageBox.Show("请输入票板名称");
                return;
            }
            if (TemplateTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择正确的票板类型");
                return;
            }

            if (PrintComboBox.Text == "")
            {
                MessageBox.Show("请选择打印机类型");
                return;
            }
            TemplateNameTextbox.Enabled = false;
            TemplateTypeComboBox.Enabled = false;
            SaveButton.Enabled = false;
            EditButton.Enabled = true;
            PrintComboBox.Enabled = false;
            template.Name = TemplateNameTextbox.Text.Trim();
            if (template.PrintSetting == null)
            {
                PrintSetting setting = new PrintSetting();
                setting.PrintModule = PrintComboBox.Text.Trim();
                template.PrintSetting = setting;
            }
            else
            {
                template.PrintSetting.PrintModule = PrintComboBox.Text.Trim();
            }
            template.Template_Type = TemplateTypeHelp.GetTemplateString(TemplateTypeComboBox.SelectedText);
            ChangeForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lengthTextBox.Enabled = true;
                widthTextBox.Enabled = true;
                SettingTextBox.Enabled = false;
            }
            if (radioButton2.Checked)
            {
                lengthTextBox.Enabled = false;
                widthTextBox.Enabled = false;
                SettingTextBox.Enabled = true;
            }

        }

        private void BgEditButton_Click(object sender, EventArgs e)
        {
            PictureSelectButton.Enabled = true;
            radioButton1.Enabled = true;
            if (radioButton1.Checked)
            {
                lengthTextBox.Enabled = true;
                widthTextBox.Enabled = true;
                SettingTextBox.Enabled = false;
            }
            else
            {
                lengthTextBox.Enabled = false;
                widthTextBox.Enabled = false;
                SettingTextBox.Enabled = true;
            }
            radioButton2.Enabled = true;
            BgEditButton.Enabled = false;
            bgSaveButton.Enabled = true;
            SettingButton.Enabled = true;
        }

        private void bgSaveButton_Click(object sender, EventArgs e)
        {
            PictureSelectButton.Enabled = false;
            radioButton1.Enabled = false;
            lengthTextBox.Enabled = false;
            widthTextBox.Enabled = false;
            radioButton2.Enabled = false;
            SettingTextBox.Enabled = false;
            BgEditButton.Enabled = true;
            bgSaveButton.Enabled = false;
            SettingButton.Enabled = false;

            template.Background.ImageWidth = (int)PixelsToMillimetersWidth(pictureBox1.Size.Width);
            template.Background.ImageHeight = (int)PixelsToMillimetersWidth(pictureBox1.Size.Height);
            template.Background.BgImage = pictureBox1.Image;

            TemplateFacePanel.BackgroundImage = template.Background.BgImage;
            TemplateFacePanel.Size = new Size((int)MillimetersToPixelsWidth(template.Background.ImageWidth), (int)MillimetersToPixelsWidth(template.Background.ImageHeight));
        }

        int xLe;
        int yLe;
        private void PictureSelectButton_Click(object sender, EventArgs e)
        {
            BgChooseDialog.Filter = "*jpg|*JPG|*GIF|*.BMP|*PNG|*.PNG";
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            if (DialogResult.OK == BgChooseDialog.ShowDialog())
            {
                string fullpath = BgChooseDialog.FileName;
                pictureBox1.LoadCompleted += new AsyncCompletedEventHandler(pictureBox1_LoadCompleted);
                //图片加载时，显示等待光标 
                pictureBox1.UseWaitCursor = true;

                //采用异步加载方式 
                pictureBox1.WaitOnLoad = false;
                Bitmap bm = new Bitmap(fullpath);
                Point pt = new Point(bm.Size);
                if (pt.X > pictureBox1.Size.Width || pt.Y > pictureBox1.Size.Height)
                {
                    pictureBox1.Size = new Size(pt.X, pt.Y);
                    xLe = (int)PixelsToMillimetersWidth(pt.X);

                    yLe = (int)PixelsToMillimetersWidth(pt.Y);
                    lengthTextBox.Text = xLe.ToString();
                    widthTextBox.Text = yLe.ToString();
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                template.Background.BgImage = bm;

                //开始异步加载，图片的地址，请自行更换 
                pictureBox1.LoadAsync(fullpath);
            }

        }

        void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //图片加载完成后，将光标恢复 
            pictureBox1.UseWaitCursor = false;
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            try
            {
                if (radioButton1.Checked)
                {
                    x = (int)MillimetersToPixelsWidth(Convert.ToInt32(lengthTextBox.Text.Trim()));
                    y = (int)MillimetersToPixelsWidth(Convert.ToInt32(widthTextBox.Text.Trim()));
                }
                else
                {
                    int length = Convert.ToInt32(SettingTextBox.Text.Trim());
                    x = (int)MillimetersToPixelsWidth(xLe) * length / 100;
                    y = (int)MillimetersToPixelsWidth(yLe) * length / 100;
                }
            }
            catch
            {
                MessageBox.Show("您的输入有误.");
                return;
            }
            pictureBox1.Size = new Size(x, y);
        }

        #endregion

        #region Page2

        //private void TemplateFaceListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (TemplateFaceListBox.SelectedIndex != -1)
        //    {
        //        string itemType = TemplateFaceListBox.SelectedItem.ToString();
        //        TemplateItemSetting setting = new TemplateItemSetting(TemplateSettingType.New, null);
        //        if (DialogResult.OK == setting.ShowDialog())
        //        {
        //            TemplateFaceItem item = setting.Item;
        //            item.Itemtype = itemType;
        //            template.Face.Items.AddItem(item);
        //            BindFaceItemsListBox();
        //        }
        //    }
        //}

        private void BindFaceItemsListBox()
        {
            FaceItemsListBox.Items.Clear();
            TemplateFacePanel.Controls.Clear();
            //throw new NotImplementedException();
            TemplateFaceItemCollection items = template.Face.Items;
            items.Reset();
            while (items.MoveNext())
            {
                TemplateFaceItem item = items.Current as TemplateFaceItem;
                if (item.Status != TemplateItemStatus.Delete)
                {
                    FaceItemsListBox.Items.Add(new ItemListBoxItem(item));
                }
                CreateItemTextBox(item);
            }
        }

        void CreateItemTextBox(TemplateFaceItem item)
        {

            Label box = new Label();
            box.Text = item.Name;
            box.Font = item.ItemFont;
            box.ForeColor = item.ItemColor;
            box.BorderStyle = BorderStyle.None;
            //box.Enabled = false;
            box.Location = new Point((int)MillimetersToPixelsWidth(item.XAxis), (int)MillimetersToPixelsWidth(item.YAxis));
            box.Tag = item;
            if (type != TemplateSettingType.View)
            {
                box.MouseMove += label6_MouseMove;
                box.MouseDown += label6_MouseDown;
                box.MouseUp += label6_MouseUp;

                //box.c
            }
            //box.BackColor = Color.Transparent;
            box.AutoSize = true;
            TemplateFacePanel.Controls.Add(box);
        }

        private void FaceItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FaceItemsListBox.SelectedIndex != -1)
            {
                ItemListBoxItem item1 = FaceItemsListBox.SelectedItem as ItemListBoxItem;
                if (item1 == null)
                {
                    return;
                }
                TemplateItemSetting setting = new TemplateItemSetting(TemplateSettingType.Edit, item1.Item);
                DialogResult result = setting.ShowDialog();
                if (DialogResult.OK == result)
                {
                    TemplateFaceItem item = setting.Item;
                    TemplateFaceItem newItem = template.Face.Items.EditItem(item1.Item);
                    if (newItem != null)
                    {
                        newItem.Name = item.Name;
                        newItem.XAxis = item.XAxis;//(int)PixelsToMillimetersWidth(item.XAxis);
                        newItem.YAxis = item.YAxis; //(int)PixelsToMillimetersWidth(item.YAxis);
                        newItem.ItemColor = item.ItemColor;
                        newItem.ItemFont = item.ItemFont;
                        newItem.Description = item.Description;
                    }

                }
                else if (DialogResult.Abort == result)
                {
                    TemplateFaceItem item = setting.Item;
                    template.Face.Items.DeleteItem(item1.Item);
                }
                BindFaceItemsListBox();
            }
        }


        Point _oldPosition = new Point();

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            Label la = sender as Label;

            if (e.Button == MouseButtons.Left)
            {
                la.Left += Cursor.Position.X - _oldPosition.X;
                la.Top += Cursor.Position.Y - _oldPosition.Y;
                _oldPosition = Cursor.Position;
            }

        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            _oldPosition = Cursor.Position;
            Label la = sender as Label;
            la.Select();
        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            Label la = sender as Label;
            TemplateFaceItem item = la.Tag as TemplateFaceItem;
            TemplateFaceItem newItem = template.Face.Items.EditItem(item);
            if (newItem != null)
            {

                newItem.Name = item.Name;
                newItem.XAxis = (int)PixelsToMillimetersWidth(la.Left);
                newItem.YAxis = (int)PixelsToMillimetersWidth(la.Top);
                newItem.ItemColor = item.ItemColor;
                newItem.ItemFont = item.ItemFont;
                newItem.Description = item.Description;
            }
            BindFaceItemsListBox();
        }

        #endregion

        class ItemListBoxItem
        {
            public ItemListBoxItem(TemplateFaceItem item)
            {
                this.item = item;
            }

            TemplateFaceItem item;

            public TemplateFaceItem Item
            {
                get { return item; }
                set { item = value; }
            }

            public override string ToString()
            {
                return item.Name.ToString();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (type != TemplateSettingType.View)
            {
                if (Template.Name == "" || Template.Name == null)
                {
                    MessageBox.Show("请设定模板名称");
                    return;
                }
                if (template.Background.BgImage == null)
                {
                    MessageBox.Show("请设定背景图片");
                    return;
                }
                template.Template_Type = TemplateTypeHelp.GetTemplateString(TemplateTypeComboBox.Text.Trim());
                template.Background.ImageHeight = (int)(PixelsToMillimetersWidth(pictureBox1.Size.Height));
                template.Background.ImageWidth = (int)(PixelsToMillimetersWidth(pictureBox1.Size.Width));

                int templateId = temp.SaveTemplate(template);
                SaveTemplateFaceItem();
            }
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }



        private void TemplateFacePanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Label label = sender as Label;
            if (e.KeyCode == Keys.Up)
            {
                label.Location = new Point(label.Location.X - 1, label.Location.Y);
            }
            if (e.KeyCode == Keys.Down)
            {
                label.Location = new Point(label.Location.X + 1, label.Location.Y);
            }
            if (e.KeyCode == Keys.Left)
            {
                label.Location = new Point(label.Location.X, label.Location.Y - 1);
            }
            if (e.KeyCode == Keys.Right)
            {
                label.Location = new Point(label.Location.X, label.Location.Y + 1);
            }

        }

        int lastIndex = -1;

        private void TemplateFaceListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (TemplateFaceListBox.Items.Count == 0)
                return;

            int index = TemplateFaceListBox.IndexFromPoint(e.X, e.Y);
            //lastIndex = index;
            if (index == -1)
            {
                return;
            }
            string s = TemplateFaceListBox.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                //TemplateFaceListBox.Items.RemoveAt(TemplateFaceListBox.IndexFromPoint(e.X, e.Y));
            }

            if (TemplateFaceListBox.Items[index] != null)
            {
                ItemTypeField field = TemplateFaceListBox.Items[index] as ItemTypeField;
                if (field.Basic)
                {
                    EditCustomBtn.Enabled = false;
                    DeleteCustomBtn.Enabled = false;
                }
                else
                {
                    EditCustomBtn.Enabled = true;
                    DeleteCustomBtn.Enabled = true;
                }
            }
        }

        private void TemplateFacePanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void TemplateFacePanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                TemplateFaceItem item = new TemplateFaceItem();
                item.Itemtype = (string)e.Data.GetData(
                    DataFormats.StringFormat);
                item.Description = item.Itemtype;
                item.XAxis = (int)PixelsToMillimetersWidth(e.X - GetPosX() + 3);
                item.YAxis = (int)PixelsToMillimetersWidth(e.Y - GetPosY() - 1);
                TemplateItemSetting setting = new TemplateItemSetting(TemplateSettingType.Edit, item);
                if (DialogResult.OK == setting.ShowDialog())
                {
                    TemplateFaceItem item1 = setting.Item;
                    template.Face.Items.AddItem(item1);
                    BindFaceItemsListBox();
                }
            }
        }

        private int GetPosY()
        {
            Control co = pictureBox1;
            int x = 0;
            while (co != null)
            {
                x += co.Location.Y;
                co = co.Parent;
            }
            return x;
        }

        private int GetPosX()
        {
            Control co = pictureBox1;
            int x = 0;
            while (co != null)
            {
                x += co.Location.X;
                co = co.Parent;
            }
            return x;
        }

        private void EditPrintBtn_Click(object sender, EventArgs e)
        {
            PrintComboBox.Enabled = true;
        }

        private void SavePrintBtn_Click(object sender, EventArgs e)
        {
            PrintComboBox.Enabled = false;
            if (template.PrintSetting == null)
            {
                PrintSetting setting = new PrintSetting();
                setting.PrintModule = PrintComboBox.Text.Trim();
                template.PrintSetting = setting;
            }
            else
            {
                template.PrintSetting.PrintModule = PrintComboBox.Text.Trim();
            }
        }

        private void TemplateFaceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TemplateFaceListBox.SelectedIndex != -1)
            {
                ItemTypeField field = TemplateFaceListBox.SelectedItem as ItemTypeField;
                if (field.Basic)
                {
                    EditCustomBtn.Enabled = false;
                    DeleteCustomBtn.Enabled = false;
                }
                else
                {
                    EditCustomBtn.Enabled = true;
                    DeleteCustomBtn.Enabled = true;
                }
            }
        }

        private void AddCustomBtn_Click(object sender, EventArgs e)
        {
            TemplateItemName itemNameForm = new TemplateItemName();
            if (itemNameForm.ShowDialog() == DialogResult.OK)
            {
                TemplateFaceListBox.Items.Add(new ItemTypeField(false, itemNameForm.Name1));
            }
        }

        private void EditCustomBtn_Click(object sender, EventArgs e)
        {
            TemplateItemName itemNameForm = new TemplateItemName();
            if (TemplateFaceListBox.SelectedIndex != -1)
            {
                itemNameForm.Name1 = TemplateFaceListBox.SelectedItem.ToString();
                itemNameForm.InitFormName();
                if (itemNameForm.ShowDialog() == DialogResult.OK)
                {
                    ItemTypeField field = TemplateFaceListBox.SelectedItem as ItemTypeField;
                    field.Name = itemNameForm.Name1;
                    TemplateFaceListBox.Items[TemplateFaceListBox.SelectedIndex] = field;
                    //TemplateFaceListBox.Items.Add(new ItemTypeField(false, itemNameForm.Name1));
                }
            }
        }

        private void DeleteCustomBtn_Click(object sender, EventArgs e)
        {
            if (TemplateFaceListBox.SelectedIndex != -1)
            {
                TemplateFaceListBox.Items.RemoveAt(TemplateFaceListBox.SelectedIndex);
            }
        }

        //private void FaceItemsListBox_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        int xy = FaceItemsListBox.IndexFromPoint(e.X, e.Y);
        //        if (xy != -1)
        //        {
        //            //NewToolStripMenuItem.Enabled = true;
        //            //EditToolStripMenuItem.Enabled = true;
        //            //DeleteToolStripMenuItem.Enabled = true;
        //            //ViewToolStripMenuItem1.Enabled = true;
        //            Point point = this.PointToClient(FaceItemsListBox.PointToScreen(new Point(e.X, e.Y)));
        //            this.contextMenuStrip1.Show(this, point);
        //        }
        //        //else
        //        //{
        //        //    NewToolStripMenuItem.Enabled = true;
        //        //    EditToolStripMenuItem.Enabled = false;
        //        //    DeleteToolStripMenuItem.Enabled = false;
        //        //    ViewToolStripMenuItem1.Enabled = false;
        //        //    Point point = this.PointToClient(FaceItemsListBox.PointToScreen(new Point(e.X, e.Y)));
        //        //    this.contextMenuStrip1.Show(this, point);
        //        //}
        //    }
        //}
    }
}

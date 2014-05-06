using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace SeatMaDll
{
	public class BHDirectionBtPanel : UserControl
	{
		private SeatingChart _CurrentSeatingChart = null;
		private List<SeatingChart> _ListSeatingChart = new List<SeatingChart>();
		private int _nIndexPos = -1;
		private IContainer components = null;
		private TableLayoutPanel tableLayoutPanel1;
		public BHDirectionButton bhDirectionButton_L;
		public BHDirectionButton bhDirectionButton_R;
		public BHDirectionBtPanel()
		{
			this.InitializeComponent();
		}
		public void InitData(SeatingChart currentSeatingChart, List<SeatingChart> listSeatingChart)
		{
			this._CurrentSeatingChart = currentSeatingChart;
			this._ListSeatingChart = listSeatingChart;
			this._nIndexPos = 0;
			if (this.IsMinObj())
			{
				this.bhDirectionButton_L.IsMinOrMax = true;
			}
			else
			{
				this.bhDirectionButton_L.IsMinOrMax = false;
			}
			if (this.IsMaxObj())
			{
				this.bhDirectionButton_R.IsMinOrMax = true;
			}
			else
			{
				this.bhDirectionButton_R.IsMinOrMax = false;
			}
		}
		public SeatingChart GetCurrentSeatingChart()
		{
			return this._CurrentSeatingChart;
		}
		public SeatingChart NextSeatingChart()
		{
			SeatingChart result;
			if (this._ListSeatingChart.Count <= 0)
			{
				result = null;
			}
			else
			{
				this._nIndexPos++;
				if (this._nIndexPos < 0)
				{
					this._nIndexPos = 0;
				}
				if (this._nIndexPos >= this._ListSeatingChart.Count)
				{
					this._nIndexPos = this._ListSeatingChart.Count - 1;
				}
				this._CurrentSeatingChart = this._ListSeatingChart[this._nIndexPos];
				if (this.IsMinObj())
				{
					this.bhDirectionButton_L.IsMinOrMax = true;
				}
				else
				{
					this.bhDirectionButton_L.IsMinOrMax = false;
				}
				if (this.IsMaxObj())
				{
					this.bhDirectionButton_R.IsMinOrMax = true;
				}
				else
				{
					this.bhDirectionButton_R.IsMinOrMax = false;
				}
				result = this._CurrentSeatingChart;
			}
			return result;
		}
		public SeatingChart PreSeatingChart()
		{
			SeatingChart result;
			if (this._ListSeatingChart.Count <= 0)
			{
				result = null;
			}
			else
			{
				this._nIndexPos--;
				if (this._nIndexPos < 0)
				{
					this._nIndexPos = 0;
				}
				if (this._nIndexPos >= this._ListSeatingChart.Count)
				{
					this._nIndexPos = this._ListSeatingChart.Count - 1;
				}
				this._CurrentSeatingChart = this._ListSeatingChart[this._nIndexPos];
				if (this.IsMinObj())
				{
					this.bhDirectionButton_L.IsMinOrMax = true;
				}
				else
				{
					this.bhDirectionButton_L.IsMinOrMax = false;
				}
				if (this.IsMaxObj())
				{
					this.bhDirectionButton_R.IsMinOrMax = true;
				}
				else
				{
					this.bhDirectionButton_R.IsMinOrMax = false;
				}
				result = this._CurrentSeatingChart;
			}
			return result;
		}
		public bool IsMinObj()
		{
			bool result;
			if (this._CurrentSeatingChart == null)
			{
				result = true;
			}
			else
			{
				if (this._ListSeatingChart.Count <= 0)
				{
					result = true;
				}
				else
				{
					bool flag = this._CurrentSeatingChart.SeatingChartId == this._ListSeatingChart[0].SeatingChartId;
					result = flag;
				}
			}
			return result;
		}
		public bool IsMaxObj()
		{
			bool result;
			if (this._CurrentSeatingChart == null)
			{
				result = true;
			}
			else
			{
				if (this._ListSeatingChart.Count <= 0)
				{
					result = true;
				}
				else
				{
					int count = this._ListSeatingChart.Count;
					bool flag = this._CurrentSeatingChart.SeatingChartId == this._ListSeatingChart[count - 1].SeatingChartId;
					result = flag;
				}
			}
			return result;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.bhDirectionButton_L = new BHDirectionButton();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.bhDirectionButton_R = new BHDirectionButton();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.bhDirectionButton_L.BHDirectType = BHDirectionButton.DirectType.Left;
			this.bhDirectionButton_L.CurrentColor = Color.Blue;
			this.bhDirectionButton_L.Dock = DockStyle.Fill;
			this.bhDirectionButton_L.IsMinOrMax = true;
			this.bhDirectionButton_L.Location = new Point(3, 3);
			this.bhDirectionButton_L.Name = "bhDirectionButton_L";
			this.bhDirectionButton_L.Size = new Size(44, 31);
			this.bhDirectionButton_L.TabIndex = 0;
			this.bhDirectionButton_L.Text = "bhDirectionButton_L";
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.bhDirectionButton_L, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.bhDirectionButton_R, 1, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Size = new Size(101, 37);
			this.tableLayoutPanel1.TabIndex = 1;
			this.bhDirectionButton_R.BHDirectType = BHDirectionButton.DirectType.Right;
			this.bhDirectionButton_R.CurrentColor = Color.Blue;
			this.bhDirectionButton_R.Dock = DockStyle.Fill;
			this.bhDirectionButton_R.IsMinOrMax = false;
			this.bhDirectionButton_R.Location = new Point(53, 3);
			this.bhDirectionButton_R.Name = "bhDirectionButton_R";
			this.bhDirectionButton_R.Size = new Size(45, 31);
			this.bhDirectionButton_R.TabIndex = 2;
			this.bhDirectionButton_R.Text = "bhDirectionButton_R";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "BHDirectionBtPanel";
			base.Size = new Size(101, 37);
			this.tableLayoutPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}

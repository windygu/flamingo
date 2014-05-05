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
    public partial class frmSelectBlock : Form
    {
        private List<Block> blockList;
        public string blockId;
        private List<SeatingChart> seatingChartList;
        public frmSelectBlock(List<Block> blocklist, List<SeatingChart> SeatingChartList, string HallId)
        {
            InitializeComponent();

            this.blockList = blocklist;

            //根据影厅编号，获取座位图
            this.seatingChartList = SeatingChartList.Where(P => P.HallId == HallId).ToList(); ;
        }

        private void frmSelectBlock_Load(object sender, EventArgs e)
        {
            List<Block> tmpList = new List<Block>();

            //根据座位图，获取分区记录
            foreach (var tmp in this.seatingChartList)
            {
                tmpList.AddRange(this.blockList.Where(p => p.SeatingChartId == tmp.SeatingChartId).ToList()); 
            }

            cbBlock.ValueMember = "BlockId";
            cbBlock.DisplayMember = "BlockName";
            cbBlock.DataSource = tmpList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            blockId = cbBlock.SelectedValue.ToString();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}

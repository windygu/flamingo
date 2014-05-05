using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;
namespace WinFormUI
{
    public class Block
    {
        public string BlockId;
        public string BlockName;
        public int Bgcolour;
        public int Seats;
        public int HasBlockPrice;
        public string SeatingChartId;
        public DateTime Created;
        public DateTime Updated;
        public int ActiveFlag;
        public Block()
        { }
        public static bool CreateObj(Block bk)
        {
            BlockDbo dbo = new BlockDbo();
            BlockPo po = new BlockPo();
            po.BLOCKID = bk.BlockId.Trim().Length <= 0 ? dbo.BuildId(bk.SeatingChartId) : bk.BlockId;
            po.BLOCKNAME = bk.BlockName;
            po.BGCOLOUR = bk.Bgcolour;
            po.HASBLOCKPRICE = bk.HasBlockPrice;
            po.SEATINGCHARTID = bk.SeatingChartId;
            po.SEATS = bk.Seats;
            po.CREATED = DateTime.Now;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = 1;

            return dbo.Insert(po);
        }
        public static bool UpdateObj(Block bk)
        {
            BlockDbo dbo = new BlockDbo();
            BlockPo po = new BlockPo();
            po.BLOCKID = bk.BlockId;
            po.BLOCKNAME = bk.BlockName;
            po.BGCOLOUR = bk.Bgcolour;
            po.HASBLOCKPRICE = bk.HasBlockPrice;
            po.SEATINGCHARTID = bk.SeatingChartId;
            po.SEATS = bk.Seats;
            po.CREATED = DateTime.Now;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = 1;

            return dbo.Update(po);
        }
        public static bool DeleteObj(Block bk, string szBlockId_Default)
        {
            BlockDbo dbo = new BlockDbo();
            BlockPo po = new BlockPo();
            po.BLOCKID = bk.BlockId;
            po.BLOCKNAME = bk.BlockName;
            po.BGCOLOUR = bk.Bgcolour;
            po.HASBLOCKPRICE = bk.HasBlockPrice;
            po.SEATINGCHARTID = bk.SeatingChartId;
            po.SEATS = bk.Seats;
            po.CREATED = DateTime.Now;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = 1;

            return dbo.DeleteAll(po, szBlockId_Default);
        }
        public static string GetDefaultBlock(string szSeatingChartId)
        {
            BlockDbo dbo = new BlockDbo();
            return dbo.GetDefaultBlock(szSeatingChartId);
        }
        public static List<Block> RetrieveObjList(string szSeatingChartId)
        {
            List<Block> list = new List<Block>();
            BlockDbo dbo = new BlockDbo();
            DataTable dt = dbo.RetrieveALLItems(szSeatingChartId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                Block obj = ChangeObj(dr);
                if (obj != null) list.Add(obj);
            }
            return list;
        }
        public static Block RetrieveObj(string szSeatingChartId, string szBlockName)
        {
            BlockDbo dbo = new BlockDbo();
            DataTable dt = dbo.RetrieveALLItems(szSeatingChartId, szBlockName);
            if (dt == null || dt.Rows.Count <= 0) return null;
            Block obj = ChangeObj(dt.Rows[0]);
            return obj;
        }
        public static Block ChangeObj(DataRow dr)
        {
            Block obj = new Block();
            obj.BlockId = dr["BlockId"] == DBNull.Value ? "" : dr["BlockId"].ToString();
            obj.BlockName = dr["BlockName"] == DBNull.Value ? "" : dr["BlockName"].ToString();
            obj.Bgcolour = dr["Bgcolour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Bgcolour"]);
            obj.Seats = dr["Seats"] == DBNull.Value ? 1 : Convert.ToInt32(dr["Seats"]);
            obj.HasBlockPrice = dr["HasBlockPrice"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HasBlockPrice"]);
            obj.SeatingChartId = dr["SeatingChartId"] == DBNull.Value ? "" : dr["SeatingChartId"].ToString();

            obj.Created = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
            obj.Updated = dr["Updated"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Updated"]);
            obj.ActiveFlag = dr["ActiveFlag"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ActiveFlag"]);
            return obj;
        }
    }
    public class BlockRich
    {
        public Block _ObjBlock;
        public SeatMaDll.SeatingChart _ObjSeatingChart;
        public static BlockRich RetrieveObj(string szHallId, int nLevel)
        {
            SeatMaDll.SeatingChart objSeatingChart = SeatingChartAction.RetrieveObj(szHallId, nLevel);
            if (objSeatingChart == null) return null;
            BlockRich blcR = new BlockRich();
            blcR._ObjSeatingChart = objSeatingChart;
            if (blcR._ObjSeatingChart != null)
                blcR._ObjBlock = Block.RetrieveObj(blcR._ObjSeatingChart.SeatingChartId, "0");
            return blcR;
        }
    }
    public class SimBlock
    {
        public string _BlockId = string.Empty;
        public string _BlockName = string.Empty;
        public int _BgColour = 0;
        public static List<SimBlock> RetrieveItems(string szSeatingChartId)
        {
            List<SimBlock> list = new List<SimBlock>();
            DataTable dt = new BlockDbo().RetrieveALLItems(szSeatingChartId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                SimBlock obj = ChangeObj(dr);
                list.Add(obj);
            }
            return list;
        }
        private static SimBlock ChangeObj(DataRow dr)
        {
            SimBlock obj = new SimBlock();
            obj._BlockId = dr["BlockId"] == DBNull.Value ? "" : dr["BlockId"].ToString();
            obj._BlockName = dr["BlockName"] == DBNull.Value ? "" : dr["BlockName"].ToString();
            obj._BgColour = dr["BgColour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColour"]);
            return obj;
        }
    }
}

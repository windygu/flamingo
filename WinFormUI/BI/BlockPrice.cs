using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;
namespace WinFormUI
{
    public class BlockPrice
    {
        public string BlockPriceId = "";
        public string BlockId;
        public string ShowPlanId;
        public decimal SinglePrice;
        public decimal DoublePrice;
        public decimal BoxPrice;
        public decimal StudentPrice;
        public decimal GroupPrice;
        public decimal MemberPrice;
        public decimal DiscountPrice;

        public DateTime Created;
        public DateTime Updated;
        public int ActiveFlag;
        public BlockPrice()
        { }
        public static bool CreateObj(BlockPrice bk)
        {
            BlockPriceDbo dbo = new BlockPriceDbo();
            BlockPricePo po = new BlockPricePo();
            po.BLOCKPRICEID = bk.ShowPlanId + bk.BlockId;
                //bk.BlockPriceId == 0 ? dbo.BuildId() : bk.BlockPriceId;
            po.BLOCKID = bk.BlockId;
            po.SHOWPLANID = bk.ShowPlanId;
            po.SINGLEPRICE = bk.SinglePrice;
            po.DOUBLEPRICE = bk.DoublePrice;
            po.BOXPRICE = bk.BoxPrice;
            po.STUDENTPRICE = bk.StudentPrice;
            po.GROUPPRICE = bk.GroupPrice;
            po.MEMBERPRICE = bk.MemberPrice;
            po.DISCOUNTPRICE = bk.DiscountPrice;

            po.CREATED = DateTime.Now;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = 1;

            return dbo.Insert(po);
        }
        public static bool UpdateObj(BlockPrice bk)
        {
            BlockPriceDbo dbo = new BlockPriceDbo();
            BlockPricePo po = new BlockPricePo();
            po.BLOCKPRICEID = bk.BlockPriceId;
            po.BLOCKID = bk.BlockId;
            po.SHOWPLANID = bk.ShowPlanId;
            po.SINGLEPRICE = bk.SinglePrice;
            po.DOUBLEPRICE = bk.DoublePrice;
            po.BOXPRICE = bk.BoxPrice;
            po.STUDENTPRICE = bk.StudentPrice;
            po.GROUPPRICE = bk.GroupPrice;
            po.MEMBERPRICE = bk.MemberPrice;
            po.DISCOUNTPRICE = bk.DiscountPrice;

            po.CREATED = bk.Created;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = bk.ActiveFlag;

            return dbo.Update(po);
        }
        public static bool DeleteObj(BlockPrice bk)
        {
            BlockPriceDbo dbo = new BlockPriceDbo();
            BlockPricePo po = new BlockPricePo();
            po.BLOCKPRICEID = bk.BlockPriceId;
            po.BLOCKID = bk.BlockId;
            po.SHOWPLANID = bk.ShowPlanId;
            po.SINGLEPRICE = bk.SinglePrice;
            po.DOUBLEPRICE = bk.DoublePrice;
            po.BOXPRICE = bk.BoxPrice;
            po.STUDENTPRICE = bk.StudentPrice;
            po.GROUPPRICE = bk.GroupPrice;
            po.MEMBERPRICE = bk.MemberPrice;
            po.DISCOUNTPRICE = bk.DiscountPrice;

            po.CREATED = bk.Created;
            po.UPDATED = DateTime.Now;
            po.ACTIVEFLAG = bk.ActiveFlag;

            return dbo.Delete(po);
        }
        public static List<BlockPrice> RetrieveObjList(string szShowPlanId)
        {
            List<BlockPrice> list = new List<BlockPrice>();
            BlockPriceDbo dbo = new BlockPriceDbo();
            DataTable dt = dbo.RetrieveALLItems(szShowPlanId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                BlockPrice obj = ChangeObj(dr);
                if (obj != null) list.Add(obj);
            }
            return list;
        }
        public static BlockPrice RetrieveObj(string szShowPlanId, string szBlockId)
        {
            BlockDbo dbo = new BlockDbo();
            DataTable dt = dbo.RetrieveALLItems(szShowPlanId, szBlockId);
            if (dt == null || dt.Rows.Count <= 0) return null;
            BlockPrice obj = ChangeObj(dt.Rows[0]);
            return obj;
        }
        public static BlockPrice ChangeObj(DataRow dr)
        {
            BlockPrice obj = new BlockPrice();
            obj.BlockPriceId = dr["BlockPriceId"] == DBNull.Value ? "" : dr["BlockPriceId"].ToString() ;
            obj.BlockId = dr["BlockId"] == DBNull.Value ? "" : dr["BlockId"].ToString();
            obj.ShowPlanId = dr["ShowPlanId"] == DBNull.Value ? "" : dr["ShowPlanId"].ToString();
            obj.SinglePrice = dr["SinglePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["SinglePrice"]);
            obj.DoublePrice = dr["DoublePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["DoublePrice"]);
            obj.BoxPrice = dr["BoxPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["BoxPrice"]);
            obj.StudentPrice = dr["StudentPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["StudentPrice"]);
            obj.GroupPrice = dr["GroupPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["GroupPrice"]);
            obj.MemberPrice = dr["MemberPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["MemberPrice"]);
            obj.DiscountPrice = dr["DiscountPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["DiscountPrice"]);

            obj.Created = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
            obj.Updated = dr["Updated"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Updated"]);
            obj.ActiveFlag = dr["ActiveFlag"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ActiveFlag"]);
            return obj;
        }
    }

    public class BlockPriceRich
    {
        public BlockPrice _blockPrice = null;
        public Block _block = null;
        public BlockPriceRich()
        { }
        public static List<BlockPriceRich> RetrieveObjList(string szSeatingChartId, string szShowPlanId)
        {
            List<BlockPriceRich> list = new List<BlockPriceRich>();
            BlockDbo dbo = new BlockDbo();
            DataTable dt = dbo.RetrieveALLItems_Ext(szSeatingChartId, szShowPlanId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                BlockPriceRich bpR = new BlockPriceRich();
                bpR._block = Block.ChangeObj(dr);
                bpR._blockPrice = BlockPrice.ChangeObj(dr);
                list.Add(bpR);
            }
            return list;
        }

    }
    
}

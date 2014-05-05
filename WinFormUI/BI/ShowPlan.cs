using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;
namespace WinFormUI
{
    public class ShowPlan
    {
        public string ShowPlanId;
        public string ShowPlanName;
        public string FilmId;
        public int Film_FilmModeId;
        public int Position;
        public DateTime StartTime = DateTime.Now;
        public DateTime EndTime = DateTime.Now;
        public int FilmLength = 0;
        public string HallId;
        public string DailyPlanId;
        public int Timespan;
        public decimal Ratio;
        public decimal LowestPrice;
        public int FareSettingId;
        public decimal SinglePrice;
        public decimal DoublePrice;
        public decimal BoxPrice;
        public decimal StudentPrice;
        public decimal GroupPrice;
        public decimal MemberPrice;
        public decimal DiscountPrice;
        public int ShowStatus ;
        public int ShowTypeId;
        public int ShowGroup;
        public int IsDiscounted;
        public int IsCheckingNumber;
        public int IsTicketChecking;
        public int IsOnlineTicketing;
        public int IsApproved;
        public int IsSalable;
        public int IsLocked;
        public int Stagehand;
        public int Projectionist;
        public DateTime Created = DateTime.Now;
        public DateTime Updated = DateTime.Now;
        public int ActiveFlag = 1;
        public ShowPlan()
        { }
        public static ShowPlan RetrieveObj(string szShowPlanId)
        {
            ShowPlanDbo dbo = new ShowPlanDbo();
            DataTable dt = dbo.RetrieveALLItems(szShowPlanId);
            if (dt == null || dt.Rows.Count <= 0) return null;
            ShowPlan obj = ChangeObj(dt.Rows[0]);
            return obj;
        }
        public static ShowPlan ChangeObj(DataRow dr)
        {
            ShowPlan obj = new ShowPlan();
            obj.ShowPlanId = dr["ShowPlanId"] == DBNull.Value ? "" : dr["ShowPlanId"].ToString();
            obj.ShowPlanName = dr["ShowPlanName"] == DBNull.Value ? "" : dr["ShowPlanName"].ToString();
            obj.FilmId = dr["FilmId"] == DBNull.Value ? "" : dr["FilmId"].ToString();
            obj.Film_FilmModeId = dr["Film_FilmModeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Film_FilmModeId"]);
            obj.Position = dr["Position"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Position"]);
            obj.StartTime = dr["StartTime"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["StartTime"]);
            obj.EndTime = dr["EndTime"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["EndTime"]);
            obj.FilmLength = dr["FilmLength"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FilmLength"]);
            obj.HallId = dr["HallId"] == DBNull.Value ? "" : dr["HallId"].ToString();
            obj.DailyPlanId = dr["DailyPlanId"] == DBNull.Value ? "" : dr["DailyPlanId"].ToString();
            obj.Timespan = dr["Timespan"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Timespan"]);
            obj.Ratio = dr["Ratio"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Ratio"]);
            obj.LowestPrice = dr["LowestPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["LowestPrice"]);
            obj.FareSettingId = dr["FareSettingId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FareSettingId"]);
            obj.SinglePrice = dr["SinglePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["SinglePrice"]);
            obj.DoublePrice = dr["DoublePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["DoublePrice"]);
            obj.BoxPrice = dr["BoxPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["BoxPrice"]);
            obj.StudentPrice = dr["StudentPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["StudentPrice"]);
            obj.GroupPrice = dr["GroupPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["GroupPrice"]);
            obj.MemberPrice = dr["MemberPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["MemberPrice"]);
            obj.DiscountPrice = dr["DiscountPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["DiscountPrice"]);
            obj.ShowStatus = dr["ShowStatus"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ShowStatus"]);
            obj.ShowTypeId = dr["ShowTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ShowTypeId"]);
            obj.ShowGroup = dr["ShowGroup"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ShowGroup"]);
            obj.IsDiscounted = dr["IsDiscounted"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsDiscounted"]);
            obj.IsCheckingNumber = dr["IsCheckingNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsCheckingNumber"]);
            obj.IsTicketChecking = dr["IsTicketChecking"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsTicketChecking"]);
            obj.IsOnlineTicketing = dr["IsOnlineTicketing"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsOnlineTicketing"]);
            obj.IsApproved = dr["IsApproved"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsApproved"]);
            obj.IsSalable = dr["IsSalable"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsSalable"]);
            obj.IsLocked = dr["IsLocked"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsLocked"]);
            obj.Stagehand = dr["Stagehand"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Stagehand"]);
            obj.Projectionist = dr["Projectionist"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Projectionist"]);

            obj.Created = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
            obj.Updated = dr["Updated"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Updated"]);
            obj.ActiveFlag = dr["ActiveFlag"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ActiveFlag"]);
            return obj;
        }
    }
    public class ShowPlanRich
    {
        public ShowPlan _ObjShowPlan = null;
        public string _HallName = "";
        public string _FilmCode = "";
        public string _FilmName = "";
        public static ShowPlanRich RetrieveObj(string szShowPlanId)
        {
            ShowPlanDbo dbo = new ShowPlanDbo();
            DataTable dt = dbo.RetrieveALLItems_Ext(szShowPlanId);
            if (dt == null || dt.Rows.Count <= 0) return null;

            ShowPlanRich spR = new ShowPlanRich();
            spR._ObjShowPlan = ShowPlan.ChangeObj(dt.Rows[0]);
            spR._HallName = dt.Rows[0]["HallName"] == DBNull.Value ? "" : dt.Rows[0]["HallName"].ToString();
            spR._FilmCode = dt.Rows[0]["FilmCode"] == DBNull.Value ? "" : dt.Rows[0]["FilmCode"].ToString();
            spR._FilmName = dt.Rows[0]["FilmName"] == DBNull.Value ? "" : dt.Rows[0]["FilmName"].ToString();

            return spR;
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;
namespace WinFormUI
{
    public class Hall
    {
        public string _HallId = "1";
        public string _TheaterId = "1";
        public string _HallName;
        public int _Seats = 0;
        public int _Levels = 0;
        private string _Screen;
        private string _Projector;
        private string _PlayMode;
        private string _SoundSystem;
        private string _Description;
        public Hall()
        { }

        public static bool UpdateSeat(string szHallId)
        {
            int nCount = SeatAction.GetSeatsByHallId(szHallId);
            HallPo po = new HallPo();
            po.HALLID = szHallId;
            po.SEATS = nCount;
            HallDbo dbo = new HallDbo();
            return dbo.UpdateSeat(po);

        }
        
    }
    public class SimHall
    {
        public string _HallId = string.Empty;
        public string _HallName = string.Empty;
        public override string ToString()
        {
            return (string.IsNullOrEmpty(this._HallId) ? "" : this._HallId + "|" + this._HallName);
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }
            if (obj.GetType() != typeof(SimHall) &&
                !obj.GetType().IsSubclassOf(typeof(SimHall)))
            {
                return false;
            }
            SimHall that = (SimHall)obj;
            return this._HallId == that._HallId;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static List<SimHall> RetrieveItems(string szTheaterId)
        {
            List<SimHall> list = new List<SimHall>();
            DataTable dt = new HallDbo().RetrieveALLItems(szTheaterId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                SimHall obj = ChangeObj(dr);
                list.Add(obj);
            }
            return list;
        }
        private static SimHall ChangeObj(DataRow dr)
        {
            SimHall obj = new SimHall();
            obj._HallId = dr["HallId"] == DBNull.Value ? "" : dr["HallId"].ToString();
            obj._HallName = dr["HallName"] == DBNull.Value ? "" : dr["HallName"].ToString();
            return obj;
        }
    }
    public class SimHallLevel
    {
        public string _TheaterId = string.Empty;
        public string _HallId = string.Empty;
        public string _LevelId = string.Empty;
        
        public override string ToString()
        {
            return (string.IsNullOrEmpty(this._LevelId) ? "" : this._LevelId );
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }
            if (obj.GetType() != typeof(SimHallLevel) &&
                !obj.GetType().IsSubclassOf(typeof(SimHallLevel)))
            {
                return false;
            }
            SimHallLevel that = (SimHallLevel)obj;
            return this._LevelId == that._LevelId;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static List<SimHallLevel> RetrieveLevelItemsByTH(string szTheaterId, string szHallId)
        {
            List<SimHallLevel> list = new List<SimHallLevel>();
            int nLevels = new HallDbo().GetHallLevel(szTheaterId, szHallId);
            if (nLevels <= 0) return list;
            for (int i = 1; i <= nLevels; i++)
            {
                SimHallLevel obj = new SimHallLevel();
                obj._TheaterId = szTheaterId;
                obj._HallId = szHallId;
                obj._LevelId = i.ToString();
                list.Add(obj);
            }
            return list;
        }
        public static List<SimHallLevel> RetrieveLevelItems(string szTheaterId, string szHallId)
        {
            List<SimHallLevel> list = new List<SimHallLevel>();
            DataTable dt = new SeatingchartDbo().RetrieveLevelItems(szTheaterId, szHallId);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                SimHallLevel obj = ChangeObj(dr, szTheaterId);
                list.Add(obj);
            }
            return list;
        }
        private static SimHallLevel ChangeObj(DataRow dr, string szTheaterId)
        {
            SimHallLevel obj = new SimHallLevel();
            obj._TheaterId = szTheaterId;
                //dr["TheaterId"] == DBNull.Value ? "" : dr["TheaterId"].ToString();
            obj._HallId = dr["HallId"] == DBNull.Value ? "" : dr["HallId"].ToString();
            obj._LevelId = dr["Level"] == DBNull.Value ? "" : dr["Level"].ToString();
            return obj;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;

namespace WinFormUI
{
    public class TheaterInfo
    {
        public string _TheaterId = "1";       
        public string _AuthorizationId = "1";
        public string _TheaterTypeId = "1";
        public string _TheaterName;
        public TheaterInfo()
        { }
    }
    public class SimTheaterInfo
    {
        public string _TheaterId = string.Empty;
        public string _TheaterName = string.Empty;
        public override string ToString()
        {
            return (string.IsNullOrEmpty(this._TheaterId) ? "" : this._TheaterId + "|" + this._TheaterName);
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }
            if (obj.GetType() != typeof(SimTheaterInfo) &&
                !obj.GetType().IsSubclassOf(typeof(SimTheaterInfo)))
            {
                return false;
            }
            SimTheaterInfo that = (SimTheaterInfo)obj;
            return this._TheaterId == that._TheaterId;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static List<SimTheaterInfo> RetrieveItems()
        {
            List<SimTheaterInfo> list = new List<SimTheaterInfo>();
            DataTable dt = new TheaterInfoDbo().RetrieveALLItems();
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            { 
                SimTheaterInfo obj = ChangeObj(dr);
                list.Add(obj);
            }
            dt.Dispose();
            return list;
        }
        private static SimTheaterInfo ChangeObj(DataRow dr)
        {
            SimTheaterInfo obj = new SimTheaterInfo();
            string szID = dr["TheaterId"] == DBNull.Value ? "" : dr["TheaterId"].ToString();
            string szName = dr["TheaterName"] == DBNull.Value ? "" : dr["TheaterName"].ToString();
            obj._TheaterId = szID;
            obj._TheaterName = szName;
            return obj;
        }
    }
}

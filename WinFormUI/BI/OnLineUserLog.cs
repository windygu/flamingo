using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;
namespace WinFormUI
{
    public class OnLineUserLog
    {
        public int UserId = 0;
        public string UserName = "";
        public string WS_IP = "";
        public string WS_MAC = "";
        public DateTime Created;
        public OnLineUserLog()
        { }
        public OnLineUserLog(int nUserId, string szUserName, string szWS_IP, string szWS_MAC, DateTime dtCreated)
        {
            UserId = nUserId;
            UserName = szUserName;
            WS_IP = szWS_IP;
            WS_MAC = szWS_MAC;
            Created = dtCreated;
        }
        public static bool CreateObj(OnLineUserLog ou)
        {
            OnLineUserLogDbo dbo = new OnLineUserLogDbo();
            OnLineUserLogPo po = new OnLineUserLogPo();
            po.USERID = ou.UserId;
            po.USERNAME = ou.UserName;
            po.WS_IP = ou.WS_IP;
            po.WS_MAC = ou.WS_MAC;
            po.CREATED = DateTime.Now;
            
            return dbo.Insert(po);
        }
        public static bool UpdateObj(OnLineUserLog ou)
        {
            OnLineUserLogDbo dbo = new OnLineUserLogDbo();
            OnLineUserLogPo po = new OnLineUserLogPo();
            po.USERID = ou.UserId;
            po.USERNAME = ou.UserName;
            po.WS_IP = ou.WS_IP;
            po.WS_MAC = ou.WS_MAC;
            po.CREATED = DateTime.Now;

            return dbo.Update(po);
        }
        public static bool DeleteObj(OnLineUserLog ou)
        {
            OnLineUserLogDbo dbo = new OnLineUserLogDbo();
            OnLineUserLogPo po = new OnLineUserLogPo();
            po.USERID = ou.UserId;
            po.USERNAME = ou.UserName;
            po.WS_IP = ou.WS_IP;
            po.WS_MAC = ou.WS_MAC;
            po.CREATED = ou.Created;

            return dbo.Delete(po);
        }
      
        public static List<OnLineUserLog> RetrieveObjList()
        {
            List<OnLineUserLog> list = new List<OnLineUserLog>();
            OnLineUserLogDbo dbo = new OnLineUserLogDbo();
            DataTable dt = dbo.RetrieveALLItems();
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                OnLineUserLog obj = ChangeObj(dr);
                if (obj != null) list.Add(obj);
            }
            return list;
        }
        public static OnLineUserLog RetrieveObj(int nUserId)
        {
            OnLineUserLogDbo dbo = new OnLineUserLogDbo();
            DataTable dt = dbo.RetrieveOneItems(nUserId);
            if (dt == null || dt.Rows.Count <= 0) return null;
            OnLineUserLog obj = ChangeObj(dt.Rows[0]);
            return obj;
        }
        public static OnLineUserLog ChangeObj(DataRow dr)
        {
            OnLineUserLog obj = new OnLineUserLog();
            obj.UserId = dr["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UserId"]);
            obj.UserName = dr["UserName"] == DBNull.Value ? "" : dr["UserName"].ToString();
            obj.WS_IP = dr["WS_IP"] == DBNull.Value ? "" : dr["WS_IP"].ToString();
            obj.WS_MAC = dr["WS_MAC"] == DBNull.Value ? "" : dr["WS_MAC"].ToString();
            obj.Created = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
            return obj;
        }
    }
    public class OnLineUserLogRich
    { 
        public static int UserId = 0;
        public static string UserName = "";
        public static string WS_IP = "";
        public static string WS_MAC = "";
    }
}

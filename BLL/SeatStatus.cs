using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 座位状态业务处理 by lzz 2011-12-05
    /// </summary>
    public class SeatStatus
    {
        /// <summary>
        /// 锁定一个座位状态
        /// </summary>
        /// <param name="showplanid">场计划ID</param>
        /// <param name="seatid">座位ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态</returns>
        public static int Lock(string showplanid, string seatid, int lockedby)
        {
            try
            {
                int statusNum = DAL.SeatStatus.Lock(showplanid, seatid, lockedby);
                return statusNum;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 锁定多个座位状态
        /// </summary>
        /// <param name="seatids">座位状态ID集合 |</param>
        /// <param name="showplanid">场次ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态集合</returns>
        public static List<SeatMaDll.SeatStatusSim> Lock(StringBuilder sb_seatstatusids, string showplanid, int lockedby)
        {
            List<SeatMaDll.SeatStatusSim> list = new List<SeatMaDll.SeatStatusSim>();
            try
            {
                DataTable dt = DAL.SeatStatus.Lock(sb_seatstatusids, showplanid, lockedby);
                if (dt.Rows.Count > 0)
                {
                    SeatMaDll.SeatStatusSim sss;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sss = new SeatMaDll.SeatStatusSim();
                        sss._seatId = dr[0].ToString();
                        sss._seatStatusFlag = dr[2].ToString() == lockedby.ToString() ? "5" : dr[1].ToString();
                        list.Add(sss);
                    }
                }
            }
            catch
            {
                return new List<SeatMaDll.SeatStatusSim>();
            }
            return list;
        }

        /// <summary>
        /// 取消一个座位的锁定状态
        /// </summary>
        /// <param name="showplanid">场计划ID</param>
        /// <param name="seatid">座位ID</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态</returns>
        public static int CancelLock(string showplanid, string seatid, int lockedby)
        {
            try
            {
                int statusNum = DAL.SeatStatus.CancelLock(showplanid, seatid, lockedby);
                return statusNum;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 取消多个座位的锁定状态
        /// </summary>
        /// <param name="seatstatusids">座位状态ID集合 |</param>
        /// <param name="lockedby">锁定人</param>
        /// <returns>座位状态</returns>
        public static bool CancelLock(string seatstatusids, string lockedby)
        {
            bool tf = DAL.SeatStatus.CancelLock(seatstatusids, lockedby);
            return tf;
        }

        /// <summary>
        /// 锁定多个座位
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <param name="showplanid"></param>
        /// <param name="lockedby"></param>
        /// <returns></returns>
        public static List<SeatMaDll.SeatStatusSim> SpecialLockAlot(StringBuilder sb_seatstatusids, string showplanid, int lockedby)
        {
            List<SeatMaDll.SeatStatusSim> list = new List<SeatMaDll.SeatStatusSim>();
            try
            {
                DataTable dt = DAL.SeatStatus.SpecialLockAlot(sb_seatstatusids, showplanid, lockedby);
                if (dt.Rows.Count > 0)
                {
                    SeatMaDll.SeatStatusSim sss;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sss = new SeatMaDll.SeatStatusSim();
                        sss._seatId = dr[0].ToString();
                        if (dr[1].ToString() == "1")
                            sss._seatStatusFlag = dr[2].ToString() == lockedby.ToString() ? "5" : "1";
                        else
                            sss._seatStatusFlag = dr[1].ToString();
                        list.Add(sss);
                    }
                }
            }
            catch
            {
                return new List<SeatMaDll.SeatStatusSim>();
            }
            return list;
        }

        
        /// <summary>
        /// 解除锁定多个座位
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <param name="showplanid"></param>
        /// <param name="lockedby"></param>
        /// <returns></returns>
        public static List<SeatMaDll.SeatStatusSim> CancelSpecialLockAlot(StringBuilder sb_seatstatusids, string showplanid, int lockedby)
        {
            List<SeatMaDll.SeatStatusSim> list = new List<SeatMaDll.SeatStatusSim>();
            try
            {
                DataTable dt = DAL.SeatStatus.CancelSpecialLockAlot(sb_seatstatusids, showplanid, lockedby);
                if (dt.Rows.Count > 0)
                {
                    SeatMaDll.SeatStatusSim sss;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sss = new SeatMaDll.SeatStatusSim();
                        sss._seatId = dr[0].ToString();
                        if (dr[1].ToString() == "1")
                            sss._seatStatusFlag = dr[2].ToString() == lockedby.ToString() ? "5" : "1";
                        else
                            sss._seatStatusFlag = dr[1].ToString();
                        list.Add(sss);
                    }
                }
            }
            catch
            {
                return new List<SeatMaDll.SeatStatusSim>();
            }
            return list;
        }
    }
}

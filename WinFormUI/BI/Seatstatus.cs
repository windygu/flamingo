using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObject.PO;
using DataObject.DBO;

namespace WinFormUI
{
    public class Seatstatus
    {
        public SeatMaDll.Seat _seat;
        public static List<SeatMaDll.SeatingChart> RetrieveSeatingChartList(string szShowPlanId, string szHallId, int nLevel, int nUser)
        {
            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            return scList;

        }
        public static List<SeatMaDll.SeatingChart> RetrieveSeatingChartList(string szHallId, int nLevel)
        {
            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);

            return scList;
        }

        public static List<SeatMaDll.Seat> RetrieveObjWithSeatingchart(string szShowPlanId, string szHallId, int nLevel, int nUser,ref SeatMaDll.SeatingChart seatingchart)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            if (scList == null || scList.Count <= 0) return listAll;

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, scList[0].SeatingChartId);
            seatingchart = scList[0];

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromData(po);

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
                //if (!SeatAction.MergeObj(list, st)) list.Add(st);
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);

            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            //if (listHaveBrother.Count > 0)
            //    listAll.AddRange(listHaveBrother[0], listHaveBrother[listHaveBrother.Count-1]);
            //listAll = listAll.AddRange(listNoBrother);
            //.CopyTo(listNoBrother);
            return listAll;

        }
        public static List<SeatMaDll.Seat> RetrieveObjWithSeatingchartAndBlock(string szShowPlanId, SeatMaDll.SeatingChart seatingChartTemp, int nUser, int nLeftPad, int nTopPad, ref SeatMaDll.SeatingChart seatingchart)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            if (seatingChartTemp == null) return listAll;
            SeatstatusDbo dbo = new SeatstatusDbo();
            DataTable dt = dbo.RetrieveItemStatus_InitWithBlock(szShowPlanId, seatingChartTemp.SeatingChartId);
            seatingchart = seatingChartTemp;

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            //var sw = new Stopwatch();
            //sw.Restart();
            foreach (DataRow dr in dt.Rows)
            {
                int nBgColour = dr["BgColour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColour"]);

                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromDataWithPad(po, nLeftPad, nTopPad);

                st._BackColor = nBgColour;
                st._IsUsedBackColor = true;

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._BackColor = nBgColour;
                        st._brotherList[0]._IsUsedBackColor = true;
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
            }
            //sw.Stop();
            //TimeSpan time = sw.Elapsed;
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);
            dt.Dispose();
            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            return listAll;

        }
        public static List<SeatMaDll.Seat> RetrieveObjWithSeatingchartAndBlock(string szShowPlanId, string szHallId, int nLevel, int nUser, int nLeftPad, int nTopPad, ref SeatMaDll.SeatingChart seatingchart)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            if (scList == null || scList.Count <= 0) return listAll;

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus_InitWithBlock(szShowPlanId, scList[0].SeatingChartId);
            seatingchart = scList[0];

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            //var sw = new Stopwatch();
            //sw.Restart();
            foreach (DataRow dr in dt.Rows)
            {
                int nBgColour = dr["BgColour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColour"]);

                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromDataWithPad(po, nLeftPad, nTopPad);

                st._BackColor = nBgColour;
                st._IsUsedBackColor = true;

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._BackColor = nBgColour;
                        st._brotherList[0]._IsUsedBackColor = true;
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
            }
            //sw.Stop();
            //TimeSpan time = sw.Elapsed;
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);
            dt.Dispose();
            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            return listAll;

        }

        public static List<SeatMaDll.Seat> RetrieveObjWithSeatingchartAndBlock(string szShowPlanId, string szHallId, int nLevel, int nUser, ref SeatMaDll.SeatingChart seatingchart)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            if (scList == null || scList.Count <= 0) return listAll;

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus_InitWithBlock(szShowPlanId, scList[0].SeatingChartId);
            seatingchart = scList[0];

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                int nBgColour = dr["BgColour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColour"]);

                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromData(po);

                st._BackColor = nBgColour;
                st._IsUsedBackColor = true;

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._BackColor = nBgColour;
                        st._brotherList[0]._IsUsedBackColor = true;
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);

            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            return listAll;

        }

        public static List<SeatMaDll.Seat> RetrieveObj(string szShowPlanId, string szHallId, int nLevel, int nUser)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            if (scList == null || scList.Count <= 0) return listAll;

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, scList[0].SeatingChartId);

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromData(po);

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
                //if (!SeatAction.MergeObj(list, st)) list.Add(st);
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);

            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            //if (listHaveBrother.Count > 0)
            //    listAll.AddRange(listHaveBrother[0], listHaveBrother[listHaveBrother.Count-1]);
            //listAll = listAll.AddRange(listNoBrother);
            //.CopyTo(listNoBrother);
            return listAll;

        }
        private static SeatPo ChangeObj(DataRow dr, int nUser, ref string szStatusFlag)
        {
            SeatPo obj = new SeatPo();
            obj.SEATID = dr["SeatId"] == DBNull.Value ? "" : dr["SeatId"].ToString();
            obj.ROWNUMBER = dr["RowNumber"] == DBNull.Value ? "" : dr["RowNumber"].ToString();
            obj.COLUMNNUMBER = dr["ColumnNumber"] == DBNull.Value ? "" : dr["ColumnNumber"].ToString();
            obj.SEATNUMBER = dr["SeatNumber"] == DBNull.Value ? "" : dr["SeatNumber"].ToString();
            obj.XAXIS = dr["Xaxis"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Xaxis"]);
            obj.YAXIS = dr["Yaxis"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Yaxis"]);
            obj.HEIGHT = dr["Height"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Height"]);
            obj.WIDTH = dr["Width"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Width"]);
            obj.PROPERTY = dr["Property"] == DBNull.Value ? "" : dr["Property"].ToString();
            obj.SEATINGCHARTID = dr["SeatingChartId"] == DBNull.Value ? "" : dr["SeatingChartId"].ToString();
            obj.BLOCKID = dr["BlockId"] == DBNull.Value ? "" : dr["BlockId"].ToString();
            obj.SEATTYPE = dr["SeatType"] == DBNull.Value ? "" : dr["SeatType"].ToString();
            obj.SEATGROUP = dr["SeatGroup"] == DBNull.Value ? "" : dr["SeatGroup"].ToString();
            obj.CREATED = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
            obj.UPDATED = dr["Updated"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Updated"]);
            obj.ACTIVEFLAG = dr["ActiveFlag"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ActiveFlag"]);

            int nLockedBy = dr["LockedBy"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LockedBy"]);
            szStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
            if (szStatusFlag == "1")
            {
                if (nLockedBy == nUser) szStatusFlag = "5";
            }
            return obj;
        }
        public static List<SeatMaDll.Seat> RetrieveStatusObjs(string szShowPlanId, string szHallId, int nLevel, int nUser)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            List<SeatMaDll.SeatingChart> scList = SeatingChartAction.RetrieveObjList(szHallId, nLevel);
            if (scList == null || scList.Count <= 0) return listAll;

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus(szShowPlanId, scList[0].SeatingChartId);

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromData(po);

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0)
                    {
                        listNoBrother.Add(st);
                    }
                    else
                    {
                        st._brotherList[0]._seatStatusFlag = szStatusFlag;
                        listHaveBrother.Add(st);
                    }
                }
                //if (!SeatAction.MergeObj(list, st)) list.Add(st);
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);

            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            //if (listHaveBrother.Count > 0)
            //    listAll.AddRange(listHaveBrother[0], listHaveBrother[listHaveBrother.Count-1]);
            //listAll = listAll.AddRange(listNoBrother);
            //.CopyTo(listNoBrother);
            return listAll;

        }

        public static List<SeatMaDll.Seat> RetrieveStatusObjsBySeatingChartId(string szShowPlanId, string szSeatingChartId, int nUser)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();

            SeatstatusDbo dbo = new SeatstatusDbo();
            //DataTable dt = dbo.RetrieveItemStatus_Init(szShowPlanId, szHallId, nLevel);
            DataTable dt = dbo.RetrieveItemStatus(szShowPlanId, szSeatingChartId);

            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                string szStatusFlag = "0";
                SeatPo po = ChangeObj(dr, nUser, ref szStatusFlag);

                SeatMaDll.Seat st = SeatAction.ChangeObjFromData(po);

                //st._seatStatusFlag = dr["TicketingState"] == DBNull.Value ? "0" : dr["TicketingState"].ToString();
                st._seatStatusFlag = szStatusFlag;
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0) listNoBrother.Add(st);
                    else listHaveBrother.Add(st);
                }
                //if (!SeatAction.MergeObj(list, st)) list.Add(st);
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);

            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            //if (listHaveBrother.Count > 0)
            //    listAll.AddRange(listHaveBrother[0], listHaveBrother[listHaveBrother.Count-1]);
            //listAll = listAll.AddRange(listNoBrother);
            //.CopyTo(listNoBrother);
            return listAll;

        }

    }
}
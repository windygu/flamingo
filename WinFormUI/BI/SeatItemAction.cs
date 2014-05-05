using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DataObject.PO;
using DataObject.DBO;

namespace WinFormUI
{
    public class SeatBgColorSetup
    {
        public int _BgColor = ColorTranslator.ToWin32(System.Drawing.SystemColors.WindowFrame);
        public SeatBgColorSetup()
        { }
        #region Export Object
        public bool ExportObj(string szFile)
        {
            string szXml = ExportData(this);
            byte[] arrByteFile = Encoding.UTF8.GetBytes(szXml);
            return WriteFile(szFile, arrByteFile);
            //return WriteFileXML(szFile, szXml);
        }
        private bool WriteFileXML(string szFile, string szItems)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(szItems);
            doc.Save(szFile);
            return true;
        }
        private bool WriteFile(string szFile, byte[] arrFile)
        {
            if (szFile == null || szFile.Trim().Length <= 0) return false;
            if (arrFile == null) return false;
            using (FileStream fs = new FileStream(szFile, FileMode.Create))
            {
                fs.Write(arrFile, 0, arrFile.Length);
            }
            return true;
        }
        public string ExportData(SeatBgColorSetup sysSetUp)
        {
            try
            {
                StringBuilder sbXML = new StringBuilder();
                System.IO.StringWriter strw = new System.IO.StringWriter(sbXML);
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(sysSetUp.GetType());
                reader.Serialize(strw, sysSetUp);
                return strw.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Import Object
        public static SeatBgColorSetup ImportObj(string szFile)
        {
            if (szFile.Trim().Length <= 0) return null;
            if (!File.Exists(szFile)) return null;

            byte[] arrFile = ReadFile(szFile);
            if (arrFile == null) return null;
            try
            {
                string szXml = Encoding.UTF8.GetString(arrFile);
                SeatBgColorSetup sysSetup = ImpportData(szXml);
                return sysSetup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static byte[] ReadFile(string szFile)
        {
            if (szFile.Trim().Length <= 0) return null;
            byte[] arrFile = null;
            using (FileStream fs = new FileStream(szFile, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            return arrFile;
        }
        public static SeatBgColorSetup ImpportData(string szSysSetUp)
        {
            try
            {
                StringReader sr = new StringReader(szSysSetUp);
                SeatBgColorSetup sysSetUp = new SeatBgColorSetup();
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(sysSetUp.GetType());
                sysSetUp = (SeatBgColorSetup)reader.Deserialize(sr);
                return sysSetUp;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
    public class SeatAction
    {
        public static bool CommitData(SeatMaDll.SeatChartDisp seatChartDispTemp,
           ref SeatMaDll.SeatingChart seatingchartTemp, ref SeatMaDll.EditSeatInfo editSeatInfoTemp)
        {
            try
            {
                DataObject.DBO.SeatDbo dbo = new DataObject.DBO.SeatDbo();

                //SeatAction.DeleteBySeatingChartId(seatingchartTemp.SeatingChartId);
                List<DataObject.PO.SeatPo> listSeat = new List<DataObject.PO.SeatPo>();
                int nSeatCount = 0;
                foreach (Control c in seatChartDispTemp.Controls)
                {
                    if (c.GetType() == typeof(SeatMaDll.BHSeatControl))
                    {
                        string szSeatGuid = string.Format("{0:D4}", nSeatCount);
                        SeatMaDll.Seat si = (SeatMaDll.Seat)c.Tag;
                        if (si._brotherList.Count <= 0)
                        {
                            nSeatCount++;
                            szSeatGuid = string.Format("{0:D4}", nSeatCount);
                            si._seatSeatingChartId = seatingchartTemp.SeatingChartId;
                            si._seatId = si._seatSeatingChartId + szSeatGuid;
                            si._seatBlockId = si._seatSeatingChartId + "0";
                        }
                        else
                        {
                            for (int i = 0; i < si._brotherList.Count; i++)
                            {
                                nSeatCount++;
                                szSeatGuid = string.Format("{0:D4}", nSeatCount);
                                si._brotherList[i]._seatSeatingChartId = seatingchartTemp.SeatingChartId;
                                szSeatGuid = si._brotherList[i]._seatSeatingChartId + szSeatGuid;
                                si._brotherList[i]._seatId = szSeatGuid;
                                si._brotherList[i]._seatBlockId = si._brotherList[i]._seatSeatingChartId + "0";
                            }
                        }

                        if (listSeat != null) listSeat.Clear();
                        listSeat = SeatAction.SplitDBObj(si);
                        foreach (DataObject.PO.SeatPo po in listSeat)
                        {
                            if (dbo.Insert(po))
                            {
                                seatingchartTemp._listSiteItem.Add(si);
                            }
                        }
                    }
                }
                seatingchartTemp.Seats = editSeatInfoTemp._ObjSeatingChart.Seats;
                seatingchartTemp.Rows = editSeatInfoTemp._ObjSeatingChart.Rows;
                seatingchartTemp.Columns = editSeatInfoTemp._ObjSeatingChart.Columns;
                seatingchartTemp.RowSpace = editSeatInfoTemp._ObjSeatingChart.RowSpace;
                seatingchartTemp.ColumnSpace = editSeatInfoTemp._ObjSeatingChart.ColumnSpace;
                seatingchartTemp.Rotation = editSeatInfoTemp._ObjSeatingChart.Rotation;
                bool bR = SeatingChartAction.ResetData(seatingchartTemp);
                bR = Hall.UpdateSeat(seatingchartTemp.HallId);
                return bR;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateTypeData(SeatMaDll.SeatChartDisp seatChartDispTemp)
        {
            try
            {
                DataObject.DBO.SeatDbo dbo = new DataObject.DBO.SeatDbo();
                List<DataObject.PO.SeatPo> listSeat = new List<DataObject.PO.SeatPo>();
                bool bR = true;
                foreach (Control c in seatChartDispTemp.Controls)
                {
                    if (c.GetType() != typeof(SeatMaDll.BHSeatControl)) continue;
                    SeatMaDll.Seat si = (SeatMaDll.Seat)c.Tag;

                    if (listSeat != null) listSeat.Clear();
                    listSeat = SeatAction.SplitDBObj_ForUpdate(si);
                    foreach (DataObject.PO.SeatPo po in listSeat)
                    {
                        if (!dbo.UpdateType(po)) bR = false;
                    }
                }
                return bR;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdatBlockData(SeatMaDll.SeatChartDisp seatChartDispTemp)
        {
            DataObject.DBO.SeatDbo dbo = new DataObject.DBO.SeatDbo();
            List<DataObject.PO.SeatPo> listSeat = new List<DataObject.PO.SeatPo>();
            bool bR = true;
            foreach (Control c in seatChartDispTemp.Controls)
            {
                if (c.GetType() == typeof(SeatMaDll.BHSeatControl))
                {
                    SeatMaDll.Seat si = (SeatMaDll.Seat)c.Tag;

                    if (listSeat != null) listSeat.Clear();
                    listSeat = SeatAction.SplitDBObj(si);
                    foreach (DataObject.PO.SeatPo po in listSeat)
                    {

                        if (!dbo.UpdateBlock(po.SEATID, po.BLOCKID)) bR = false;
                    }
                }
            }
            return bR;
        }
        
        public static List<SeatPo> SplitDBObj(SeatMaDll.Seat st)
        {
            List<SeatPo> list = new List<SeatPo>();
            if (st._brotherList.Count <= 0)
            {
                SeatPo po = new SeatPo();
                po.SEATID = st._seatId;
                po.ROWNUMBER = st._seatRowNumberDisplay;//st._seatRowNumber;
                po.COLUMNNUMBER = st._seatColumn;
                po.SEATNUMBER = st._seatNumber;
                po.XAXIS = st._seatPosX;
                po.YAXIS = st._seatPosY;
                po.WIDTH = st._seatWidth;
                po.HEIGHT = st._seatHeight;
                po.PROPERTY = st._seatProperty;
                po.SEATINGCHARTID = st._seatSeatingChartId;
                po.BLOCKID = st._seatBlockId;
                po.SEATTYPE = st._seatFlag;
                po.SEATGROUP = st._seatSeatGroup;
                po.CREATED = DateTime.Now;//st._seatStatusFlag;
                po.UPDATED = DateTime.Now;//st._seatStatusFlag;
                po.ACTIVEFLAG = 1;
                list.Add(po);
            }
            else
            {
                string szSeatGroup = st._brotherList[0]._seatId;
                for (int i = 0; i < st._brotherList.Count; i++)
                {
                    SeatPo po = new SeatPo();
                    po.SEATID = st._brotherList[i]._seatId;
                    po.ROWNUMBER = st._brotherList[i]._seatRowNumberDisplay;//st._brotherList[i]._seatRowNumber;
                    po.COLUMNNUMBER = st._brotherList[i]._seatColumn;
                    po.SEATNUMBER = st._brotherList[i]._seatNumber;
                    po.XAXIS = st._brotherList[i]._seatPosX;
                    po.YAXIS = st._brotherList[i]._seatPosY;
                    po.WIDTH = st._brotherList[i]._seatWidth;
                    po.HEIGHT = st._brotherList[i]._seatHeight;
                    po.PROPERTY = st._brotherList[i]._seatProperty;
                    po.SEATINGCHARTID = st._brotherList[i]._seatSeatingChartId;
                    po.BLOCKID = st._brotherList[i]._seatBlockId;
                    po.SEATTYPE = st._brotherList[i]._seatFlag;
                    po.SEATGROUP = szSeatGroup;

                    //po.SEATGROUP = st._brotherList[i]._seatFlag == "0" ? szSeatGroup : "";
                    po.CREATED = DateTime.Now;//st._seatStatusFlag;
                    po.UPDATED = DateTime.Now;//st._seatStatusFlag;
                    po.ACTIVEFLAG = 1;
                    list.Add(po);
                }
            }
            return list;
        }

        public static List<SeatPo> SplitDBObj_ForUpdate(SeatMaDll.Seat st)
        {
            List<SeatPo> list = new List<SeatPo>();
            if (st._brotherList.Count <= 0)
            {
                SeatPo po = new SeatPo();
                po.SEATID = st._seatId;
                po.ROWNUMBER = st._seatRowNumber;
                po.COLUMNNUMBER = st._seatColumn;
                po.SEATNUMBER = st._seatNumber;
                po.XAXIS = st._seatPosX;
                po.YAXIS = st._seatPosY;
                po.WIDTH = st._seatWidth;
                po.HEIGHT = st._seatHeight;
                po.PROPERTY = st._seatProperty;
                po.SEATINGCHARTID = st._seatSeatingChartId;
                po.BLOCKID = st._seatBlockId;
                po.SEATTYPE = st._seatFlag;
                po.SEATGROUP = st._seatSeatGroup;
                po.CREATED = DateTime.Now;//st._seatStatusFlag;
                po.UPDATED = DateTime.Now;//st._seatStatusFlag;
                po.ACTIVEFLAG = 1;
                list.Add(po);
            }
            else
            {
                string szSeatGroup = st._brotherList[0]._seatId;
                int nGroupCount = 0;
                ReFindGroupId(st._brotherList, ref szSeatGroup, ref nGroupCount);
                for (int i = 0; i < st._brotherList.Count; i++)
                {
                    SeatPo po = new SeatPo();
                    po.SEATID = st._brotherList[i]._seatId;
                    po.ROWNUMBER = st._brotherList[i]._seatRowNumber;
                    po.COLUMNNUMBER = st._brotherList[i]._seatColumn;
                    po.SEATNUMBER = st._brotherList[i]._seatNumber;
                    po.XAXIS = st._brotherList[i]._seatPosX;
                    po.YAXIS = st._brotherList[i]._seatPosY;
                    po.WIDTH = st._brotherList[i]._seatWidth;
                    po.HEIGHT = st._brotherList[i]._seatHeight;
                    po.PROPERTY = st._brotherList[i]._seatProperty;
                    po.SEATINGCHARTID = st._brotherList[i]._seatSeatingChartId;
                    po.BLOCKID = st._brotherList[i]._seatBlockId;




                    if (st._brotherList[i]._seatFlag != "0" && st._brotherList[i]._seatFlag != "1" && st._brotherList[i]._seatFlag != "2")
                    {
                        po.SEATGROUP = "";
                        po.SEATTYPE = st._brotherList[i]._seatFlag;
                    }
                    else
                    {
                        if (nGroupCount <= 1)
                        {
                            po.SEATGROUP = "";
                            po.SEATTYPE = "0";
                        }
                        else
                        {
                            po.SEATGROUP = szSeatGroup;
                            po.SEATTYPE = st._brotherList[i]._seatFlag;
                        }
                    }
                    po.CREATED = DateTime.Now;//st._seatStatusFlag;
                    po.UPDATED = DateTime.Now;//st._seatStatusFlag;
                    po.ACTIVEFLAG = 1;
                    list.Add(po);
                }
            }
            return list;
        }

        public static void ReFindGroupId(List<SeatMaDll.Seat> list, ref string szGroup, ref int nGroupCount)
        {
            szGroup = "";
            nGroupCount = 0;
            foreach (SeatMaDll.Seat siB in list)
            {
                if (siB._seatFlag == "0" || siB._seatFlag == "1" || siB._seatFlag == "2")
                {
                    nGroupCount++;
                    if (szGroup.Trim().Length >= 0) szGroup = siB._seatId;
                }
            }
        }

        public static SeatMaDll.Seat ChangeObjFromDataWithPad(SeatPo po, int nLeftPad, int nTopPad)
        {
            SeatMaDll.Seat st = new SeatMaDll.Seat();
            st._seatFlag = po.SEATTYPE;
            st._seatStatusFlag = "0"; //po.SEATSTATUSID;
            st._seatRowNumber = po.ROWNUMBER;
            st._seatRowNumberDisplay = po.ROWNUMBER; //new 
            st._seatColumn = po.COLUMNNUMBER;
            st._seatNumber = po.SEATNUMBER;
            st._seatId = po.SEATID;
            st._seatColumnCount = 1;
            st._seatPosX = po.XAXIS + nLeftPad;
            st._seatPosY = po.YAXIS + nTopPad;
            st._seatWidth = po.WIDTH;
            st._seatHeight = po.HEIGHT;
            st._seatProperty = po.PROPERTY;
            st._seatSeatingChartId = po.SEATINGCHARTID;
            st._seatBlockId = po.BLOCKID;
            st._seatSeatGroup = po.SEATGROUP;
            if (po.SEATGROUP.Trim().Length > 0 && po.SEATGROUP == po.SEATID)
            {
                SeatMaDll.Seat stN = new SeatMaDll.Seat();
                stN._seatFlag = po.SEATTYPE;
                stN._seatStatusFlag = "0"; //po.SEATSTATUSID;
                stN._seatRowNumber = po.ROWNUMBER;
                stN._seatRowNumberDisplay = po.ROWNUMBER;
                stN._seatColumn = po.COLUMNNUMBER;
                stN._seatNumber = po.SEATNUMBER;
                stN._seatId = po.SEATID;
                stN._seatColumnCount = 1;
                stN._seatPosX = po.XAXIS + nLeftPad;
                stN._seatPosY = po.YAXIS + nTopPad;
                stN._seatWidth = po.WIDTH;
                stN._seatHeight = po.HEIGHT;
                stN._seatProperty = po.PROPERTY;
                stN._seatSeatingChartId = po.SEATINGCHARTID;
                stN._seatBlockId = po.BLOCKID;
                stN._seatSeatGroup = po.SEATGROUP;
                st._brotherList.Add(stN);
            }
            return st;
        }

        public static SeatMaDll.Seat ChangeObjFromData(SeatPo po)
        {
            SeatMaDll.Seat st = new SeatMaDll.Seat();
            st._seatFlag = po.SEATTYPE;
            st._seatStatusFlag = "0"; //po.SEATSTATUSID;
            st._seatRowNumber = po.ROWNUMBER;
            st._seatRowNumberDisplay = po.ROWNUMBER; //new 
            st._seatColumn = po.COLUMNNUMBER;
            st._seatNumber = po.SEATNUMBER;
            st._seatId = po.SEATID;
            st._seatColumnCount = 1;
            st._seatPosX = po.XAXIS;
            st._seatPosY = po.YAXIS;
            st._seatWidth = po.WIDTH;
            st._seatHeight = po.HEIGHT;
            st._seatProperty = po.PROPERTY;
            st._seatSeatingChartId = po.SEATINGCHARTID;
            st._seatBlockId = po.BLOCKID;
            st._seatSeatGroup = po.SEATGROUP;
            if (po.SEATGROUP.Trim().Length > 0 && po.SEATGROUP == po.SEATID)
            {
                SeatMaDll.Seat stN = new SeatMaDll.Seat();
                stN._seatFlag = po.SEATTYPE;
                stN._seatStatusFlag = "0"; //po.SEATSTATUSID;
                stN._seatRowNumber = po.ROWNUMBER;
                stN._seatRowNumberDisplay = po.ROWNUMBER;
                stN._seatColumn = po.COLUMNNUMBER;
                stN._seatNumber = po.SEATNUMBER;
                stN._seatId = po.SEATID;
                stN._seatColumnCount = 1;
                stN._seatPosX = po.XAXIS;
                stN._seatPosY = po.YAXIS;
                stN._seatWidth = po.WIDTH;
                stN._seatHeight = po.HEIGHT;
                stN._seatProperty = po.PROPERTY;
                stN._seatSeatingChartId = po.SEATINGCHARTID;
                stN._seatBlockId = po.BLOCKID;
                stN._seatSeatGroup = po.SEATGROUP;
                st._brotherList.Add(stN);
            }
            return st;
        }
        public static SeatMaDll.Seat ChangeObjFromDataWithBlock(SeatPo po)
        {
            SeatMaDll.Seat st = new SeatMaDll.Seat();
            st._seatFlag = po.SEATTYPE;
            st._seatStatusFlag = "0"; //po.SEATSTATUSID;
            st._seatRowNumber = po.ROWNUMBER;
            st._seatRowNumberDisplay = po.ROWNUMBER;
            st._seatColumn = po.COLUMNNUMBER;
            st._seatNumber = po.SEATNUMBER;
            st._seatId = po.SEATID;
            st._seatColumnCount = 1;
            st._seatPosX = po.XAXIS;
            st._seatPosY = po.YAXIS;
            st._seatWidth = po.WIDTH;
            st._seatHeight = po.HEIGHT;
            st._seatProperty = po.PROPERTY;
            st._seatSeatingChartId = po.SEATINGCHARTID;
            st._seatBlockId = po.BLOCKID;
            st._seatSeatGroup = po.SEATGROUP;
            st._IsUsedBackColor = true;
            if (po.SEATGROUP.Trim().Length > 0 && po.SEATGROUP == po.SEATID)
            {
                SeatMaDll.Seat stN = new SeatMaDll.Seat();
                stN._seatFlag = po.SEATTYPE;
                stN._seatStatusFlag = "0"; //po.SEATSTATUSID;
                stN._seatRowNumber = po.ROWNUMBER;
                stN._seatRowNumberDisplay = po.ROWNUMBER;
                stN._seatColumn = po.COLUMNNUMBER;
                stN._seatNumber = po.SEATNUMBER;
                stN._seatId = po.SEATID;
                stN._seatColumnCount = 1;
                stN._seatPosX = po.XAXIS;
                stN._seatPosY = po.YAXIS;
                stN._seatWidth = po.WIDTH;
                stN._seatHeight = po.HEIGHT;
                stN._seatProperty = po.PROPERTY;
                stN._seatSeatingChartId = po.SEATINGCHARTID;
                stN._seatBlockId = po.BLOCKID;
                stN._seatSeatGroup = po.SEATGROUP;
                stN._IsUsedBackColor = true;
                st._brotherList.Add(stN);
            }
            return st;
        }
        public static void MergeObjNew(List<SeatMaDll.Seat> listSeatNoBrother, List<SeatMaDll.Seat> listSeatHaveBrother)
        {
            if (listSeatNoBrother == null || listSeatNoBrother.Count <= 0) return;
            if (listSeatHaveBrother == null || listSeatHaveBrother.Count <= 0) return;

            foreach (SeatMaDll.Seat st in listSeatHaveBrother)
            {
                MergeSeatByGroup(listSeatNoBrother, st);
            }

            /*
            foreach (SeatMaDll.Seat st in listSeatNoBrother)
            {
                SeatMaDll.Seat stBrother = FindSeatByGroup(listSeatHaveBrother, st);
                if (stBrother == null) continue;
                stBrother._brotherList.Add(st);
                if (st._seatPosX < stBrother._seatPosX)
                {
                    stBrother._seatPosX = st._seatPosX;

                }
                else
                {
                    stBrother._seatWidth = st._seatWidth + st._seatPosX - stBrother._seatPosX;
                }
                if (st._seatPosY < stBrother._seatPosY)
                {
                    stBrother._seatPosY = st._seatPosY;
                }
                else
                {
                    stBrother._seatHeight = st._seatHeight + st._seatPosY - stBrother._seatPosY;
                }
                
            }
            */
        }
        //private static SeatMaDll.Seat FindSeatByGroup(List<SeatMaDll.Seat> listSeatHaveBrother, SeatMaDll.Seat stNoBrother)
        //{
        //    if (stNoBrother._seatSeatGroup.Trim().Length <= 0) return null;
        //    foreach (SeatMaDll.Seat st in listSeatHaveBrother)
        //    {
        //        if (st._seatSeatGroup.Trim().Length <= 0) continue;

        //        if (stNoBrother._seatSeatGroup == st._seatSeatGroup) return st;
        //    }
        //    return null;
        //}
        private static void MergeSeatByGroup(List<SeatMaDll.Seat> listSeatNoBrother, SeatMaDll.Seat stBrother)
        {
            if (listSeatNoBrother.Count <= 0) return;
            if (stBrother._seatSeatGroup.Trim().Length <= 0) return;
            int nLeft = stBrother._seatPosX;
            int nTop = stBrother._seatPosY;
            int nRight = stBrother._seatPosX;
            int nBottom = stBrother._seatPosY;
            int nWidth = stBrother._seatWidth;
            int nHeight = stBrother._seatHeight;
            //SeatMaDll.Seat bhLeft = stBrother;
            //SeatMaDll.Seat bhTop = stBrother;
            //SeatMaDll.Seat bhRight = stBrother;
            //SeatMaDll.Seat bhBottom = stBrother;
            int nCount = listSeatNoBrother.Count;
            //foreach (SeatMaDll.Seat st in listSeatNoBrother)
            //for (int i = 0; i < nCount;i++ )
            int nNum = 0;
            while (nNum < nCount)
            {
                SeatMaDll.Seat st = listSeatNoBrother[nNum];
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    nNum++;
                    continue;
                }

                if (stBrother._seatSeatGroup == st._seatSeatGroup)
                {
                    stBrother._brotherList.Add(st);
                    //if (st._seatPosX < bhLeft._seatPosX)
                    if (st._seatPosX < nLeft)
                    {
                        nLeft = st._seatPosX;
                        //bhLeft = st;
                    }
                    //if (st._seatPosY < bhTop._seatPosY)
                    if (st._seatPosY < nTop)
                    {
                        //bhTop = st;
                        nTop = st._seatPosY;
                    }
                    //if (st._seatPosX > bhRight._seatPosX)
                    if (st._seatPosX > nRight)
                    {
                        nRight = st._seatPosX;
                        nWidth = st._seatWidth;
                        //bhRight = st;
                    }
                    //if (st._seatPosY > bhBottom._seatPosY)
                    if (st._seatPosY > nBottom)
                    {
                        nBottom = st._seatPosY;
                        nHeight = st._seatHeight;
                        //bhBottom = st;

                    }
                    listSeatNoBrother.Remove(st);
                    nCount--;
                }
                else
                {
                    nNum++;
                }
            }
            stBrother._seatPosX = nLeft;
            stBrother._seatPosY = nTop;
            stBrother._seatWidth = nWidth + nRight - nLeft;
            stBrother._seatHeight = nHeight + nBottom - nTop;
            //stBrother._seatPosX = bhLeft._seatPosX;
            //stBrother._seatPosY = bhTop._seatPosY;
            //stBrother._seatWidth = bhRight._seatWidth + bhRight._seatPosX - bhLeft._seatPosX;
            //stBrother._seatHeight = bhBottom._seatHeight + bhBottom._seatPosY - bhTop._seatPosY;
        }

        public static bool MergeObj(List<SeatMaDll.Seat> listSeat, SeatMaDll.Seat po)
        {
            if (listSeat.Count <= 0) return false;
            foreach (SeatMaDll.Seat st in listSeat)
            {
                //if (st._seatRowNumber == po.ROWNUMBER && st._seatPosX == po.XAXIS && st._seatPosY == po.YAXIS)
                if (po._seatSeatGroup == st._seatId && po._seatId != st._seatId)
                {
                    st._seatColumnCount++;
                    if (po._seatPosX != st._seatPosX)
                        st._seatWidth = po._seatPosX - st._seatPosX + po._seatWidth;
                    if (po._seatPosY != st._seatPosY)
                        st._seatHeight = po._seatPosY - st._seatPosY + po._seatHeight;
                    st._brotherList.Add(po);
                    return true;
                }
            }
            return false;
        }
        public static List<SeatMaDll.Seat> RetrieveItemsWithBlock(string SeatingChartId)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();
            SeatDbo dbo = new SeatDbo();
            DataTable dt = dbo.RetrieveALLItemsWithBlock(SeatingChartId);
            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                int nBgColour = dr["BgColour"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BgColour"]);
                SeatPo po = ChangeObj(dr);
                SeatMaDll.Seat st = ChangeObjFromData(po);
                st._BackColor = nBgColour;
                st._IsUsedBackColor = true;

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
                        listHaveBrother.Add(st);
                    }
                }
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);
            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            return listAll;
        }
        public static List<SeatMaDll.Seat> RetrieveItems(string SeatingChartId)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();
            SeatDbo dbo = new SeatDbo();
            DataTable dt = dbo.RetrieveALLItems(SeatingChartId);
            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                SeatPo po = ChangeObj(dr);
                SeatMaDll.Seat st = ChangeObjFromData(po);

                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0) listNoBrother.Add(st);
                    else listHaveBrother.Add(st);
                }
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);
            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            //if (listHaveBrother.Count > 0)
            //    listAll.AddRange(listHaveBrother[0], listHaveBrother[listHaveBrother.Count-1]);
            //listAll = listAll.AddRange(listNoBrother);
            //.CopyTo(listNoBrother);
            return listAll;
        }
        public static List<SeatMaDll.Seat> RetrieveItems(string SeatingChartId, string szBlockId)
        {
            List<SeatMaDll.Seat> listAll = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listNoBrother = new List<SeatMaDll.Seat>();
            List<SeatMaDll.Seat> listHaveBrother = new List<SeatMaDll.Seat>();
            SeatDbo dbo = new SeatDbo();
            DataTable dt = dbo.RetrieveALLItems(SeatingChartId, szBlockId);
            if (dt == null || dt.Rows.Count <= 0) return listAll;
            foreach (DataRow dr in dt.Rows)
            {
                SeatPo po = ChangeObj(dr);
                SeatMaDll.Seat st = ChangeObjFromData(po);
                if (st._seatSeatGroup.Trim().Length <= 0)
                {
                    listAll.Add(st);
                }
                else
                {
                    if (st._brotherList.Count <= 0) listNoBrother.Add(st);
                    else listHaveBrother.Add(st);
                }
            }
            SeatAction.MergeObjNew(listNoBrother, listHaveBrother);
            foreach (SeatMaDll.Seat st in listHaveBrother) listAll.Add(st);
            return listAll;
        }
        private static SeatPo ChangeObj(DataRow dr)
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
            return obj;
        }

        public static bool DeleteBySeatingChartId(string SeatingChartId)
        {
            SeatDbo dbo = new SeatDbo();
            return dbo.DeleteBySeatingChartId(SeatingChartId);
        }
        public static int GetSeatsByHallId(string szHallId)
        {
            SeatDbo dbo = new SeatDbo();
            return dbo.GetSeatsByHallId(szHallId);
        }
    }
    public class SeatingChartAction
    {
        public static string BuildSeatingchartId(string szHallId, int nLevel)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            string szSeatingchartId = dbo.BuildId(szHallId, nLevel);
            return szSeatingchartId;
        }
        public static bool SeatingChartExist(string szSeatingChartName)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.CheckExistByName(szSeatingChartName);
        }
        public static bool SeatingChartExistHaveUsed(string szSeatingChartId)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.CheckExistByIdHaveUsed(szSeatingChartId);
        }
        public static bool SeatingChartExistWillUsed(string szSeatingChartName, DateTime dtStartTime)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.CheckExistByNameWillUsed(szSeatingChartName, dtStartTime);
        }
        public static SeatMaDll.SeatingChart GetSeatingChart(string szSeatingChartName)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            DataTable dt = dbo.GetSeatingChart(szSeatingChartName);
            if (dt == null || dt.Rows.Count <= 0) return null;
            SeatMaDll.SeatingChart obj = ChangeObj(dt.Rows[0]);
            return obj;
        }

        public static bool UpdateActiveFlag(string szSeatingchartId, int nActiveFlag)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.UpdateActiveFlag(szSeatingchartId, nActiveFlag);
        }
        public static bool Update(SeatMaDll.SeatingChart sc)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            SeatingchartPo scPo = new SeatingchartPo();
            scPo.SEATINGCHARTID = sc.SeatingChartId;
            scPo.SEATINGCHARTNAME = sc.SeatingChartName;
            scPo.LEVEL = sc.Level;
            scPo.SEATS = sc.Seats;
            scPo.COLUMNS = sc.Columns;
            scPo.ROWSPACE = sc.RowSpace;
            scPo.COLUMNSPACE = sc.ColumnSpace;
            scPo.ROTATION = sc.Rotation;
            scPo.HALLID = sc.HallId;
            scPo.THEATERID = sc.TheaterId;

            BlockPo blPo = new BlockPo();

            blPo.BLOCKID = scPo.SEATINGCHARTID + "0";
            blPo.BLOCKNAME = "默认";
            blPo.SEATINGCHARTID = scPo.SEATINGCHARTID;

            DataTable dt = dbo.RetrieveALLItemsBySeatingchartId(sc.SeatingChartId);
            bool bReturn = false;
            if (dt == null || dt.Rows.Count <= 0)
            {
                bReturn = dbo.InsertWithBlock(scPo, blPo);
            }
            dt.Dispose();
            return bReturn;
        }
        public static bool UpdateThumbnail(string szSeatingchartId, byte[] byteThumbnail)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.UpdateThumbnail(szSeatingchartId, byteThumbnail);
        }
        public static byte[] GetThumbnailBytes(string szSeatingchartId)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            return dbo.GetThumbnailValue(szSeatingchartId);

            //byte[] binaryDataResult = null;
            //MemoryStream memStream = new MemoryStream();
            //IFormatter brFormatter = new BinaryFormatter();
            //brFormatter.Serialize(memStream, obj);
            //binaryDataResult = memStream.ToArray();
            //memStream.Close();
            //memStream.Dispose();

            //return binaryDataResult;
            //return Compress(binaryDataResult);

        }

        public static bool ResetData(SeatMaDll.SeatingChart sc)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            SeatingchartPo scPo = new SeatingchartPo();
            scPo.SEATINGCHARTID = sc.SeatingChartId;
            scPo.SEATINGCHARTNAME = sc.SeatingChartName;
            scPo.LEVEL = sc.Level;
            scPo.SEATS = sc.Seats;
            scPo.ROWS = sc.Rows;
            scPo.COLUMNS = sc.Columns;
            scPo.ROWSPACE = sc.RowSpace;
            scPo.COLUMNSPACE = sc.ColumnSpace;
            scPo.ROTATION = sc.Rotation;
            scPo.HALLID = sc.HallId;
            scPo.THEATERID = sc.TheaterId;
            scPo.BGCOLOUR = sc.BgColour;
            scPo.SHAPE = sc.Shape;
            bool bReturn = dbo.Update(scPo);
            return bReturn;
        }
        public static List<SeatMaDll.SeatingChart> RetrieveObjList(string szHallId, int nLevel)
        {
            List<SeatMaDll.SeatingChart> list = new List<SeatMaDll.SeatingChart>();
            SeatingchartDbo dbo = new SeatingchartDbo();
            DataTable dt = dbo.RetrieveALLItems(szHallId, nLevel);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                SeatMaDll.SeatingChart obj = ChangeObj(dr);
                obj._listSiteItem = SeatAction.RetrieveItems(obj.SeatingChartId);
                list.Add(obj);
            }
            return list;
        }
        public static List<SeatMaDll.SeatingChart> RetrieveObjListWithBlock(string szHallId, int nLevel)
        {
            List<SeatMaDll.SeatingChart> list = new List<SeatMaDll.SeatingChart>();
            SeatingchartDbo dbo = new SeatingchartDbo();
            DataTable dt = dbo.RetrieveALLItems(szHallId, nLevel);
            if (dt == null || dt.Rows.Count <= 0) return list;
            foreach (DataRow dr in dt.Rows)
            {
                SeatMaDll.SeatingChart obj = ChangeObj(dr);
                obj._listSiteItem = SeatAction.RetrieveItemsWithBlock(obj.SeatingChartId);
                list.Add(obj);
            }
            return list;
        }
        public static SeatMaDll.SeatingChart RetrieveObj(string szHallId, int nLevel)
        {
            SeatingchartDbo dbo = new SeatingchartDbo();
            DataTable dt = dbo.RetrieveALLItems(szHallId, nLevel);
            if (dt == null || dt.Rows.Count <= 0) return null;
            SeatMaDll.SeatingChart obj = ChangeObj(dt.Rows[0]);
            if (obj != null)
                obj._listSiteItem = SeatAction.RetrieveItems(obj.SeatingChartId);
            return obj;
        }
        private static SeatMaDll.SeatingChart ChangeObj(DataRow dr)
        {
            SeatMaDll.SeatingChart obj = new SeatMaDll.SeatingChart();
            obj.SeatingChartId = dr["SeatingChartId"] == DBNull.Value ? "" : dr["SeatingChartId"].ToString();
            obj.SeatingChartName = dr["SeatingChartName"] == DBNull.Value ? "" : dr["SeatingChartName"].ToString();
            obj.Level = dr["Level"] == DBNull.Value ? 1 : Convert.ToInt32(dr["Level"]);
            obj.Seats = dr["Seats"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Seats"]);
            obj.Columns = dr["Columns"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Columns"]);
            obj.RowSpace = dr["RowSpace"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RowSpace"]);
            obj.ColumnSpace = dr["ColumnSpace"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ColumnSpace"]);
            obj.Shape = dr["Shape"] == DBNull.Value ? "" : dr["Shape"].ToString();
            obj.BgColour = dr["BgColour"] == DBNull.Value ? "" : dr["BgColour"].ToString();
            obj.HallId = dr["HallId"] == DBNull.Value ? "" : dr["HallId"].ToString();
            //obj.TheaterId = dr["TheaterId"] == DBNull.Value ? "" : dr["TheaterId"].ToString();
            obj.Rotation = dr["Rotation"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Rotation"]);
            return obj;
        }
    }
}

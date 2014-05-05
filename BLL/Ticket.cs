using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Flamingo.BLL
{
    /// <summary>
    ///  影票业务逻辑 by lzz 2011-12-07
    /// </summary>
    public class Ticket
    {

        /// <summary>
        /// 获得提示票价
        /// </summary>
        /// <param name="showplanid">场次ID</param>
        /// <returns>票价(单座,双座,学生)</returns>
        public static float[] GetPrice(string showplanid)
        {
            return DAL.Ticket.GetPrice(showplanid);
        }

        /// <summary>
        /// 获得连场票价
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static float[] GetPriceSubstitute(string showplanid, string theaterid)
        {
            return DAL.Ticket.GetPriceSubstitute(showplanid, theaterid);
        }

        /// <summary>
        /// 获得总票价
        /// </summary>
        /// <param name="showplanid">场次ID</param>
        /// <param name="seatids">座位ID集合</param>
        /// <param name="blockid">区域ID</param>
        /// <returns>票价</returns>
        public static float GetPrice(string showplanid, string seatids, string saletype, bool ischangeed)
        {
            return DAL.Ticket.GetPrice(showplanid, seatids, saletype, ischangeed);
        }

        public static float GetPriceTotal(string showplanid, string seatids, string saletype, out Hashtable ht,
            bool isGroupShow, string showgroupshowplanids)
        {
            DataSet ds; DataTable dt;
            float total = 0;
            ht = null;
            if (isGroupShow)
            {
                ht = new Hashtable();
                string[] seatidsstr = seatids.Split(',');
                seatids = seatids.Replace('|', ',');
                ds = GetPriceGroup(showgroupshowplanids, seatids);
                dt = ds.Tables[0];
                DataTable dtsum = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ht.Add(dr["ShowPlanId"].ToString() + dr["SeatId"].ToString(), dr[saletype].ToString());
                        total += float.Parse(dr[saletype].ToString());
                    }
                    foreach (DataRow dr in dtsum.Rows)
                    {
                        ht.Add(dr["SeatId"].ToString(), dr[saletype].ToString());
                    }
                }
            }
            else
            {
                dt = GetPrice(showplanid, seatids);
                if (dt.Rows.Count > 0)
                {
                    ht = new Hashtable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[saletype].ToString()))
                        {
                            ht.Add(dr["SeatId"].ToString(), "0");
                        }
                        else
                        {
                            ht.Add(dr["SeatId"].ToString(), dr[saletype].ToString());
                            total += float.Parse(dr[saletype].ToString());
                        }
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// 获得座位的票价 key:SeatStatusId ;  value:Para_SeatPrices
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="seatids"></param>
        /// <returns></returns>
        public static Hashtable GetPriceList(string showplanid, string seatids)
        {
            Hashtable ht = new Hashtable();
            DataTable dt = GetPrice(showplanid, seatids);
            if (dt.Rows.Count > 0)
            {
                Flamingo.Entity.Para_SeatPrices model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Entity.Para_SeatPrices();
                    model.SeatStatusId = showplanid + dr["SeatId"].ToString();
                    if (!string.IsNullOrEmpty(dr["零售"].ToString()))
                        model.RetailPrice = float.Parse(dr["零售"].ToString());
                    if (!string.IsNullOrEmpty(dr["学生"].ToString()))
                        model.StudentPrice = float.Parse(dr["学生"].ToString());
                    if (!string.IsNullOrEmpty(dr["团体"].ToString()))
                        model.GroupPrice = float.Parse(dr["团体"].ToString());
                    if (!string.IsNullOrEmpty(dr["会员"].ToString()))
                        model.MemberPrice = float.Parse(dr["会员"].ToString());
                    ht.Add(model.SeatStatusId, model);
                }
            }
            return ht;
        }

        /// <summary>
        /// 获得多个座位的票价
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="seatids"></param>
        /// <returns></returns>
        public static DataTable GetPrice(string showplanid, string seatids)
        {
            return DAL.Ticket.GetPrice(showplanid, seatids);
        }

        /// <summary>
        /// 获得连场票价
        /// </summary>
        /// <param name="showplanids">场次ID</param>
        /// <param name="blockid">座位ID集合 |</param>
        /// <returns>票价</returns>
        public static DataSet GetPriceGroup(string showplanids, string seatids)
        {
            return DAL.Ticket.GetPriceGroup(showplanids, seatids);
        }

        /// <summary>
        /// 获得最低价格
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static float GetLowestPrice(string showplanid)
        {
            return DAL.Ticket.GetLowestPrice(showplanid);
        }

        /// <summary>
        /// 获得特价列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDiscount()
        {
            return DAL.Ticket.GetDiscount();
        }

        /// <summary>
        /// 获得特价价格
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="discountTypeName"></param>
        /// <returns></returns>
        public static DataTable GetDiscount(string showplanid, out string discountTypeName)
        {
            return DAL.Ticket.GetDiscount(showplanid, out discountTypeName);
        }

        /// <summary>
        /// 是否允许售票
        /// </summary>
        /// <param name="theaterid"></param>
        /// <param name="showplanid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SaleIsAllow(string theaterid, string showplanid, out string msg)
        {
            return DAL.Ticket.SaleIsAllow(theaterid, showplanid, out msg);
        }

        /// <summary>
        /// 零售
        /// </summary>
        /// <param name="ticketids">影票ID集合 |</param>
        /// <param name="showplanid">场次ID</param>
        /// <param name="seatids">座位ID集合 |</param>
        /// <param name="paymengmethodid">支付方式ID</param>
        /// <param name="totalprice">总票价</param>
        /// <param name="tickettypes">售票类型集合 |</param>
        /// <param name="ticketprices">票价集合 |</param>
        /// <param name="barcode">条形码</param>
        /// <param name="soldby">出售人</param>
        /// <param name="templateid">模版ID</param>
        /// <returns></returns>
        public static bool Sale(string ticketids, string showplanid, string seatids, int paymengmethodid, float totalprice,
            string tickettypes, string ticketprices, string barcode, string soldby, int templateid, string filmid)
        {
            return DAL.Ticket.Sale(ticketids, showplanid, seatids, paymengmethodid, totalprice, tickettypes, ticketprices, barcode, soldby, templateid, filmid);
        }

        /// <summary>
        /// 连场售票
        /// </summary>
        /// <param name="_TicketIds"></param>
        /// <param name="_TicketPrices"></param>
        /// <param name="_SpecialFunds"></param>
        /// <param name="_SalesTaxs"></param>
        /// <param name="_CityTaxs"></param>
        /// <param name="_EducationTaxs"></param>
        /// <param name="_AdditionalTaxs"></param>
        /// <param name="_RatioFees"></param>
        /// <param name="_NetIncomes"></param>
        /// <param name="_SoldBy"></param>
        /// <param name="_SeatStatusIds"></param>
        /// <param name="_TicketTypeIds"></param>
        /// <param name="_PaymentIds"></param>
        /// <param name="_TemplateId"></param>
        /// <param name="_ShowPlanIds"></param>
        /// <param name="_FilmIds"></param>
        /// <param name="_Count"></param>
        /// <returns></returns>
        public static bool SaleSubstitute(string _TicketIds, string _TicketPrices, int _SoldBy,
            string _SeatStatusIds, string _TicketTypeIds, int _PaymentId, int _TemplateId, string _ShowPlanIds, string _FilmIds, int _Count)
        {
            return DAL.Ticket.SaleSubstitute(_TicketIds, _TicketPrices, _SoldBy,
                _SeatStatusIds, _TicketTypeIds, _PaymentId, _TemplateId, _ShowPlanIds, _FilmIds, _Count);
        }


        /// <summary>
        /// 预定连场售票
        /// </summary>
        /// <param name="_TicketIds"></param>
        /// <param name="_TicketPrices"></param>
        /// <param name="_SpecialFunds"></param>
        /// <param name="_SalesTaxs"></param>
        /// <param name="_CityTaxs"></param>
        /// <param name="_EducationTaxs"></param>
        /// <param name="_AdditionalTaxs"></param>
        /// <param name="_RatioFees"></param>
        /// <param name="_NetIncomes"></param>
        /// <param name="_SoldBy"></param>
        /// <param name="_SeatStatusIds"></param>
        /// <param name="_TicketTypeIds"></param>
        /// <param name="_PaymentIds"></param>
        /// <param name="_TemplateId"></param>
        /// <param name="_ShowPlanIds"></param>
        /// <param name="_FilmIds"></param>
        /// <param name="_Count"></param>
        /// <param name="_SeatStatusIds"></param>
        /// <returns></returns>
        public static bool ReservationOutTicketGroup(string _TicketIds, string _TicketPrices, int _SoldBy, string _SeatStatusIds,
            string _TicketTypeIds, string _PaymentIds, int _TemplateId, string _ShowPlanIds, string _FilmIds, int _Count, string _ReservationIds)
        {
            return DAL.Ticket.ReservationOutTicketGroup(_TicketIds, _TicketPrices, _SoldBy, _SeatStatusIds,
             _TicketTypeIds, _PaymentIds, _TemplateId, _ShowPlanIds, _FilmIds, _Count, _ReservationIds);
        }

        /// <summary>
        /// 获得已售出座位信息
        /// </summary>
        /// <param name="_seatstatusids">座位状态ID</param>
        /// <returns></returns>
        public static string GetShowSoldSeatInfo(string _seatstatusids)
        {
            DataTable dt = DAL.Ticket.GetShowSoldSeatInfo(_seatstatusids);
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count == 1)
            {
                //排号 价格 售出类型 座位类型 售出者 --卖出场
                sb.Append("排  号：  {0}\r\n");
                sb.Append("价  格：  ");
                sb.Append(dt.Rows[0]["TicketPrice"].ToString());
                sb.Append("元\r\n");
                string tickettype = ToTicketType(dt.Rows[0]["TicketType"].ToString()).ToString();
                sb.Append("类  型：  ");
                sb.Append(tickettype);
                sb.Append(" {1}\r\n");
                sb.Append("售出者：  ");
                sb.Append(dt.Rows[0]["soldby"].ToString());
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获得影票信息 by 条形码
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static DataTable GetTicket(string barcode)
        {
            return DAL.Ticket.GetTicket(barcode);

        }

        /// <summary>
        /// 是否允许退票
        /// </summary>
        /// <param name="theaterid"></param>
        /// <param name="showplanid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RefundIsAllow(string theaterid, string showplanid, out string msg)
        {
            return DAL.Ticket.RefundIsAllow(theaterid, showplanid, out msg);
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="_ticketids">影票IDs |</param>
        /// <param name="_seatstatusids">座位状态IDs |</param>
        /// <param name="_refundby">经办人</param>
        /// <returns>是否退票成功</returns>
        public static bool RefundTicket(string ticketids, string seatstatusids, int refundby)
        {
            return DAL.Ticket.RefundTicket(ticketids, seatstatusids, refundby);
        }

        /// <summary>
        /// 获得要退票的票ID集合
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <returns></returns>
        public static string RefundGetTicketIds(string seatstatusids)
        {
            return DAL.Ticket.RefundGetTicketIds(seatstatusids);
        }

        /// <summary>
        /// 支票购票
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="debt"></param>
        /// <returns></returns>
        public static bool AddCheque(Entity.Customer customer, Entity.Debt debt, out string debtid)
        {
            return DAL.Ticket.AddCheque(customer, debt, out debtid);
        }

        /// <summary>
        /// 删除支票
        /// </summary>
        /// <param name="debtid"></param>
        /// <returns></returns>
        public static bool DelCheque(string debtid)
        {
            return DAL.Ticket.DelCheque(debtid);
        }

        /// <summary>
        /// 是否允许订票
        /// </summary>
        /// <param name="theaterid"></param>
        /// <param name="showplanid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ReservationIsAllow(string theaterid, string showplanid, out string msg)
        {
            return DAL.Ticket.ReservationIsAllow(theaterid, showplanid, out msg);
        }
        /// <summary>
        /// 影票预定
        /// </summary>
        /// <param name="pReservationTicket">影票预定参数实体</param>
        /// <returns></returns>
        public static bool ReservationTicket(Flamingo.Entity.Para_ReservationTicket pReservationTicket)
        {
            return DAL.Ticket.ReservationTicket(pReservationTicket);
        }

        /// <summary>
        /// 预定出票验证
        /// </summary>
        /// <param name="showplanid">场次ID</param>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <param name="cardnum">身份证号</param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_ReservationTicket ReservationValidate(string showplanid, string name, string pwd, string cardnum)
        {
            return DAL.Ticket.ReservationValidate(showplanid, name, pwd, cardnum);
        }

        /// <summary>
        /// 预定取消
        /// </summary>
        /// <param name="reservationids">预订票ID集合 |</param>
        /// <param name="seatstatusids">座位状态ID集合 |</param>
        /// <returns></returns>
        public static bool ReservationCancel(string reservationids)
        {
            return DAL.Ticket.ReservationCancel(reservationids);
        }

        /// <summary>
        /// 删除预定
        /// </summary>
        /// <param name="reservationid"></param>
        public static void ReservationDel(string reservationid)
        {
            DAL.Ticket.ReservationDel(reservationid);
        }

        /// <summary>
        /// 预定出票
        /// </summary>
        /// <param name="reservationids">预定ID集合 |</param>
        /// <param name="ticketids">影票ID集合 |</param>
        /// <param name="showplanid">场次ID</param>
        /// <param name="seatids">座位ID集合 |</param>
        /// <param name="paymengmethodid">支付方式ID</param>
        /// <param name="totalprice">总票价</param>
        /// <param name="tickettypes">售票类型集合 |</param>
        /// <param name="ticketprices">票价集合 |</param>
        /// <param name="barcode">条形码</param>
        /// <param name="soldby">出售人</param>
        /// <param name="templateid">模版ID</param>
        /// <returns>是否执行成功</returns>
        public static bool ReservationOutTicket(string reservationids, string ticketids, string showplanid, string seatids, int paymengmethodid,
            float totalprice, string tickettypes, string ticketprices, string barcode, string soldby, int templateid, string filmid)
        {
            return DAL.Ticket.ReservationOutTicket(reservationids, ticketids, showplanid, seatids, paymengmethodid, totalprice, tickettypes,
                ticketprices, barcode, soldby, templateid, filmid);
        }

        /// <summary>
        /// 票券售票
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool VoucherSale(Flamingo.Entity.Para_VoucherAdd model)
        {
            return DAL.Ticket.VoucherSale(model);
        }

        /// <summary>
        /// 代用券售票
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool VoucherSubstituteSale(Flamingo.Entity.Para_VoucherAdd model)
        {
            return DAL.Ticket.VoucherSubstituteSale(model);
        }

        /// <summary>
        /// 票券连场售票
        /// </summary>
        /// <param name="_VoucherIds"></param>
        /// <param name="_Prices"></param>
        /// <param name="_BarCodes"></param>
        /// <param name="_VoucherTypeId"></param>
        /// <param name="_VoucherBatchIds"></param>
        /// <param name="_TicketIds"></param>
        /// <param name="_TicketPrices"></param>
        /// <param name="_SoldBy"></param>
        /// <param name="_SeatStatusIds"></param>
        /// <param name="_TicketTypeIds"></param>
        /// <param name="_PaymentId"></param>
        /// <param name="_TemplateId"></param>
        /// <param name="_ShowPlanIds"></param>
        /// <param name="_FilmIds"></param>
        /// <param name="_Count"></param>
        /// <returns></returns>
        public static bool VoucherSaleGroup(string _VoucherIds, string _Prices, string _BarCodes, int _VoucherTypeId, string _VoucherBatchIds, string _TicketIds,
            string _TicketPrices, int _SoldBy, string _SeatStatusIds, string _TicketTypeIds, int _PaymentId, int _TemplateId, string _ShowPlanIds,
            string _FilmIds, int _Count)
        {
            return DAL.Ticket.VoucherSaleGroup(_VoucherIds, _Prices, _BarCodes, _VoucherTypeId, _VoucherBatchIds, _TicketIds, _TicketPrices, _SoldBy,
                _SeatStatusIds, _TicketTypeIds, _PaymentId, _TemplateId, _ShowPlanIds, _FilmIds, _Count);
        }

        /// <summary>
        /// 代用券连场售票
        /// </summary>
        /// <param name="_VoucherBatchIds"></param>
        /// <param name="_TicketIds"></param>
        /// <param name="_TicketPrices"></param>
        /// <param name="_SoldBy"></param>
        /// <param name="_SeatStatusIds"></param>
        /// <param name="_TicketTypeIds"></param>
        /// <param name="_PaymentId"></param>
        /// <param name="_TemplateId"></param>
        /// <param name="_ShowPlanIds"></param>
        /// <param name="_FilmIds"></param>
        /// <param name="_Count"></param>
        /// <returns></returns>
        public static bool VoucherSubstituteSaleGroup(string _VoucherBatchIds, string _TicketIds, string _TicketPrices, int _SoldBy, string _SeatStatusIds,
            string _TicketTypeIds, int _PaymentId, int _TemplateId, string _ShowPlanIds, string _FilmIds, int _Count)
        {
            return DAL.Ticket.VoucherSubstituteSaleGroup(_VoucherBatchIds, _TicketIds, _TicketPrices, _SoldBy, _SeatStatusIds, _TicketTypeIds,
                _PaymentId, _TemplateId, _ShowPlanIds, _FilmIds, _Count);
        }

        /// <summary>
        /// 特殊锁定
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool SpecialLock(string seatstatusids, int status, int lockedby)
        {
            return DAL.Ticket.SpecialLock(seatstatusids, status, lockedby);
        }

        /// <summary>
        /// 售票查询
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_UserSoldInfo Query(string showplanid, int userid)
        {
            DataTable dt = DAL.Ticket.Query(showplanid, userid);
            Flamingo.Entity.Para_UserSoldInfo model = new Entity.Para_UserSoldInfo(dt);
            return model;
        }

        /// <summary>
        /// 条形码验票
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static DataTable ValidateTicket(string barcode, out bool tf)
        {
            DataTable dt = DAL.Ticket.ValidateTicket(barcode);
            if (dt.Rows.Count != 1)
                tf = false;
            else
                tf = true;
            return dt;

        }

        /// <summary>
        /// 订票查询
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static DataTable ReservationQuery(string showplanid)
        {
            return DAL.Ticket.ReservationQuery(showplanid);
        }

        /// <summary>
        /// 创建条形码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateBarCode(int length)
        {
            string barcode = Flamingo.Common.StringHelper.Random(length);
            if (DAL.Ticket.BarCodeExist(barcode))
                CreateBarCode(length);
            return barcode;
        }

        /// <summary>
        /// 验证是否可以打印
        /// </summary>
        /// <param name="seatstatusid"></param>
        /// <returns></returns>
        public static bool IsAllowPrintAgain(string seatstatusid, out string ticketid)
        {
            bool tf = false;
            tf = !DAL.Ticket.HasPrinted(seatstatusid, out ticketid);
            return tf;
        }

        /// <summary>
        /// 修改打印状态
        /// </summary>
        /// <param name="ticketid"></param>
        /// <param name="status"></param>
        public static void SetPrintStatus(string ticketid, int status)
        {
            DAL.Ticket.SetPrintStatus(ticketid, status);
        }

        /// <summary>
        /// 修改打印状态
        /// </summary>
        /// <param name="ticketid"></param>
        /// <param name="status"></param>
        public static void SetPrintStatus(StringBuilder ticketid, int status)
        {
            DAL.Ticket.SetPrintStatus(ticketid, status);
        }

        /// <summary>
        /// 获得补打信息
        /// </summary>
        /// <param name="ticketid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_TicketPrintInfo GetTicketPrintInfo(string ticketid)
        {
            return DAL.Ticket.GetTicketPrintInfo(ticketid);
        }

        /// <summary>
        /// 获得售票类型
        /// </summary>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static DataTable GetTicketType()
        {
            return DAL.Ticket.GetTicketType();
        }

        /// <summary>
        /// 获得补登影票信息
        /// </summary>
        /// <param name="_DailyPlanId"></param>
        /// <param name="_HallId"></param>
        /// <param name="_ShowPlanId"></param>
        /// <returns></returns>
        public static DataTable GetFillUp(string _DailyPlanId, string _HallId, string _ShowPlanId)
        {
            return DAL.Ticket.GetFillUp(_DailyPlanId, _HallId, _ShowPlanId);
        }

        /// <summary>
        /// 补登
        /// </summary>
        /// <param name="ticketids"></param>
        /// <param name="ticketprice"></param>
        /// <param name="soldby"></param>
        /// <param name="tickettypeid"></param>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static bool AddFillUp(string ticketids, float ticketprice, int soldby, int tickettypeid, string showplanid)
        {
            return DAL.Ticket.AddFillUp(ticketids, ticketprice, soldby, tickettypeid, showplanid);
        }

        #region 售票类型
        /// <summary>
        /// 售票类型
        /// </summary>
        public enum TicketType
        {
            /// <summary>
            /// 零售 (单人,双人,包厢)
            /// </summary>
            零售 = 0,

            /// <summary>
            /// 单人
            /// </summary>
            单人 = 1,

            /// <summary>
            /// 双座
            /// </summary>
            双人 = 2,

            /// <summary>
            /// 包厢
            /// </summary>
            包厢 = 3,

            /// <summary>
            /// 学生
            /// </summary>
            学生 = 4,

            /// <summary>
            /// 特价
            /// </summary>
            特价 = 5,

            /// <summary>
            /// 团体
            /// </summary>
            团体 = 6
        }

        /// <summary>
        /// 将数据量转化为对象
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static TicketType ToTicketType(object Number)
        {
            TicketType ty = TicketType.单人;
            switch (Number.ToString())
            {
                case "0":
                    ty = TicketType.零售;
                    break;
                case "1":
                    ty = TicketType.单人;
                    break;
                case "2":
                    ty = TicketType.双人;
                    break;
                case "3":
                    ty = TicketType.包厢;
                    break;
                case "4":
                    ty = TicketType.学生;
                    break;
                case "5":
                    ty = TicketType.特价;
                    break;
                case "6":
                    ty = TicketType.团体;
                    break;
            }
            return ty;
        }

        /// <summary>
        /// 将对象转化为数据类型
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static int ToTicketType(TicketType ticketType)
        {
            int ty = 1;
            switch (ticketType)
            {
                case TicketType.零售:
                    ty = 0;
                    break;
                case TicketType.单人:
                    ty = 1;
                    break;
                case TicketType.双人:
                    ty = 2;
                    break;
                case TicketType.包厢:
                    ty = 3;
                    break;
                case TicketType.学生:
                    ty = 4;
                    break;
                case TicketType.特价:
                    ty = 5;
                    break;
                case TicketType.团体:
                    ty = 6;
                    break;
            }
            return ty;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Flamingo.DAL
{
    /// <summary>
    /// 影票数据库访问 by lzz 2011-12-07
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
            MySqlParameter[] parameters = {
					new MySqlParameter("@spid", MySqlDbType.VarChar,12)};
            parameters[0].Value = showplanid;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getShowPrices", parameters, "getShowPrices");

            float[] price = new float[3];
            if (ds.Tables[0].Rows.Count == 1)
            {
                price[0] = float.Parse(ds.Tables[0].Rows[0]["SinglePrice"].ToString());
                price[1] = float.Parse(ds.Tables[0].Rows[0]["DoublePrice"].ToString());
                price[2] = float.Parse(ds.Tables[0].Rows[0]["StudentPrice"].ToString());
            }
            return price;
        }

        /// <summary>
        /// 获得连场票价
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static float[] GetPriceSubstitute(string showplanid, string theaterid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12)};
            parameters[0].Value = theaterid;
            parameters[1].Value = showplanid;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getShowPricesSubstitute", parameters, "getShowPricesSubstitute");
            DataTable dt = ds.Tables[ds.Tables.Count - 1];
            float[] price = new float[3];
            if (dt.Rows.Count > 0)
            {
                price[0] = float.Parse(dt.Rows[0]["SinglePrice"].ToString());
                price[1] = float.Parse(dt.Rows[0]["DoublePrice"].ToString());
                price[2] = float.Parse(dt.Rows[0]["StudentPrice"].ToString());
            }
            return price;
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
            Hashtable ht = new Hashtable();
            MySqlParameter[] parameters = {
					new MySqlParameter("@spid", MySqlDbType.VarChar,12),
					new MySqlParameter("@stids", MySqlDbType.Text),
					new MySqlParameter("@saletype", MySqlDbType.VarChar,15),
                    new MySqlParameter("@totalprice", MySqlDbType.Float,8)};
            parameters[0].Value = showplanid;
            parameters[1].Value = seatids;
            parameters[2].Value = saletype;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_showplan_getTotalPrice", parameters, "getTotalPrice");
            float price = -1;
            if (!string.IsNullOrEmpty(parameters[3].Value.ToString()))
                price = float.Parse(parameters[3].Value.ToString());
            return price;
        }

        /// <summary>
        /// 获得多个座位的票价
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="seatids"></param>
        /// <returns></returns>
        public static DataTable GetPrice(string showplanid, string seatids)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@spid", MySqlDbType.VarChar,12),
					new MySqlParameter("@stids", MySqlDbType.Text)};
            parameters[0].Value = showplanid;
            parameters[1].Value = seatids;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getSeatsPrice", parameters, "getSeatsPrice");
            DataTable dt = ds.Tables[ds.Tables.Count - 1];
            return dt;
        }

        /// <summary>
        /// 获得连场票价
        /// </summary>
        /// <param name="showplanids">场次ID</param>
        /// <param name="blockid">座位ID集合 |</param>
        /// <returns>票价</returns>
        public static DataSet GetPriceGroup(string showplanids, string seatids)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanIds", MySqlDbType.Text),
					new MySqlParameter("@_SeatIds", MySqlDbType.Text)};
            parameters[0].Value = showplanids;
            parameters[1].Value = seatids;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getSeatsPriceSubstitute", parameters, "getPrice");
            return ds;
        }

        /// <summary>
        /// 获得最低价格
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static float GetLowestPrice(string showplanid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12)};
            parameters[0].Value = showplanid;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getLowestPrice", parameters, "getlowestPrice");
            float price = -1;
            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        price = float.Parse(ds.Tables[0].Rows[0]["LowestPrice"].ToString());
                    }
                }
            }
            return price;
        }

        /// <summary>
        /// 获得特价列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDiscount()
        {
            DataSet ds = DbHelperMySQL.RunProcedure("proc_discount_get", null, "discount_get");
            DataTable dt = ds.Tables[ds.Tables.Count - 1];
            return dt;
        }

        /// <summary>
        /// 获得特价价格
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="discountTypeName"></param>
        /// <returns></returns>
        public static DataTable GetDiscount(string showplanid, out string discountTypeName)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
                    new MySqlParameter("@_DiscountTypeName",MySqlDbType.VarChar,64)};
            parameters[0].Value = showplanid;
            parameters[1].Direction = ParameterDirection.Output;
            DataSet ds= DbHelperMySQL.RunProcedure("proc_discount_getShowPlanDiscount", parameters, "getShowPlanDiscount");
            discountTypeName = parameters[1].Value.ToString();
            return ds.Tables[ds.Tables.Count - 1];
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_isTrue", MySqlDbType.Bit),
					new MySqlParameter("@_ErrorMsg", MySqlDbType.VarChar,40)};
            parameters[0].Value = theaterid;
            parameters[1].Value = showplanid;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_ticket_saleIsAllow", parameters, "saleIsAllow");
            tf = parameters[2].Value.ToString().Trim() == "1" ? true : false;
            msg = parameters[3].Value.ToString();
            return tf;
        }

        /// <summary>
        /// 售票
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
        /// <returns>是否执行成功</returns>
        public static bool Sale(string ticketids, string showplanid, string seatids, int paymengmethodid, float totalprice, string tickettypes,
            string ticketprices, string barcode, string soldby, int templateid, string filmid)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@spid", MySqlDbType.VarChar,12),
					new MySqlParameter("@stids", MySqlDbType.Text),
					new MySqlParameter("@pmid", MySqlDbType.Int32,4),
					new MySqlParameter("@tp", MySqlDbType.Float),
					new MySqlParameter("@_tickettypes", MySqlDbType.Text),
					new MySqlParameter("@_ticketprices", MySqlDbType.Text),
					new MySqlParameter("@_barcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@_soldby", MySqlDbType.VarChar,12),
					new MySqlParameter("@_templateid", MySqlDbType.Int32,4),
					new MySqlParameter("@_ticketids", MySqlDbType.Text),
                    new MySqlParameter("@isTrue",MySqlDbType.Bit),
                    new MySqlParameter("@_FilmId",MySqlDbType.VarChar,12)
                                          };
            parameters[0].Value = showplanid;
            parameters[1].Value = seatids;
            parameters[2].Value = paymengmethodid;
            parameters[3].Value = totalprice;
            parameters[4].Value = tickettypes;
            parameters[5].Value = ticketprices;
            parameters[6].Value = barcode;
            parameters[7].Value = soldby;
            parameters[8].Value = templateid;
            parameters[9].Value = ticketids;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = filmid;
            DbHelperMySQL.RunProcedure("proc_ticket_sale", parameters, "ticket_sale");
            tf = parameters[10].Value.ToString().Trim() == "1" ? true : false;
            return tf;
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
            #region 参数说明
            //_TicketIds         text,
            //_TicketPrices      text,
            //_SpecialFunds      text,
            //_SalesTaxs         text,
            //_CityTaxs          text,
            //_EducationTaxs     text,
            //_AdditionalTaxs    text,
            //_RatioFees         text,
            //_NetIncomes        text,
            //_SoldBy            int,
            //_SeatStatusIds     text,
            //_TicketTypeIds     text,
            //_PaymentIds        text,
            //_TemplateId        int,
            //_ShowPlanIds       text,
            //_FilmIds           text,
            //_Count             int,
            //out _isTrue        bool
            #endregion
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketPrices", MySqlDbType.Text),					
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_SeatStatusIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketTypeIds", MySqlDbType.Text),
					new MySqlParameter("@_PaymentId", MySqlDbType.Int32,11),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanIds", MySqlDbType.Text),
					new MySqlParameter("@_FilmIds", MySqlDbType.Text),
					new MySqlParameter("@_Count", MySqlDbType.Int32,11),
					new MySqlParameter("@_isTrue", MySqlDbType.Int32,1)};
            parameters[0].Value = _TicketIds;
            parameters[1].Value = _TicketPrices;
            parameters[2].Value = _SoldBy;
            parameters[3].Value = _SeatStatusIds;
            parameters[4].Value = _TicketTypeIds;
            parameters[5].Value = _PaymentId;
            parameters[6].Value = _TemplateId;
            parameters[7].Value = _ShowPlanIds;
            parameters[8].Value = _FilmIds;
            parameters[9].Value = _Count;
            parameters[10].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_saleSubstitute", parameters, "ticket_saleSubstitute");
            tf = parameters[10].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 获得已售出座位信息
        /// </summary>
        /// <param name="_seatstatusids">座位状态ID</param>
        /// <returns></returns>
        public static DataTable GetShowSoldSeatInfo(string _seatstatusids)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_seatstatusids", MySqlDbType.Text)};
            parameters[0].Value = _seatstatusids;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_showplan_getShowSoldSeatInfo", parameters, "getShowSoldSeatInfo");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 获得影票信息 by 条形码
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static DataTable GetTicket(string barcode)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_barcode", MySqlDbType.Text)};
            parameters[0].Value = barcode;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_getTicketByBarCode", parameters, "getTicketByBarCode");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public static bool IsAllowRefund(string showplanid, string threadid)
        {
            bool tf = false;
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_isTrue", MySqlDbType.Bit),
					new MySqlParameter("@_ErrorMsg", MySqlDbType.VarChar,40)};
            parameters[0].Value = theaterid;
            parameters[1].Value = showplanid;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_ticket_refundIsAllow", parameters, "refundIsAllow");
            tf = parameters[2].Value.ToString().Trim() == "1" ? true : false;
            msg = parameters[3].Value.ToString();
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ticketids", MySqlDbType.Text),
					new MySqlParameter("@_seatstatusids", MySqlDbType.Text),
					new MySqlParameter("@_refundby", MySqlDbType.Int32),
					new MySqlParameter("@isTrue", MySqlDbType.Bit)};
            parameters[0].Value = ticketids;
            parameters[1].Value = seatstatusids;
            parameters[2].Value = refundby;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_refund_refundTicke", parameters, "refundTicke");
            tf = parameters[3].Value.ToString().Trim() == "1" ? true : false;
            return tf;

        }

        /// <summary>
        /// 获得要退票的票ID集合
        /// </summary>
        /// <param name="seatstatusids"></param>
        /// <returns></returns>
        public static string RefundGetTicketIds(string seatstatusids)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_seatstatusids", MySqlDbType.Text)};
            parameters[0].Value = seatstatusids;
            DataTable dt = DbHelperMySQL.RunProcedure("proc_ticket_refundGetTicketIds", parameters, "refundGetTicketIds").Tables[0];
            return dt.Rows[0][0].ToString();
        }

        /// <summary>
        /// 支票购票
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="debt"></param>
        /// <param name="DebtId">添加成功后的支票ID</param>
        /// <returns></returns>
        public static bool AddCheque(Entity.Customer customer, Entity.Debt debt, out string DebtId)
        {
            #region 参数说明
            ///#客户信息
            //_CustomerId int,              #客户ID
            //_CustomerTypeId int,          #客户类型ID
            //_CustomerName varchar(16),    #客户名称
            //_BankBranch varchar(32),      #开户银行
            //_Telephone  varchar(32),      #联系电话
            //_Contact varchar(32),         #联系人

            //#支票信息
            //_Buyer varchar(16),           #购买者
            //_Tickets int,                 #票数
            //_Amount float,                #金额
            //_ChequeNumber varchar(32),    #支票号
            //_Casher int,                  #收银员

            //#其他
            //_isTrue bool,                 #是否成功
            //_DebtId char(10)              #添加成功后的支票ID
            #endregion
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_CustomerId", MySqlDbType.Int32,11),
					new MySqlParameter("@_CustomerTypeId", MySqlDbType.Int32,11),
					new MySqlParameter("@_CustomerName", MySqlDbType.VarChar,16),
					new MySqlParameter("@_BankBranch", MySqlDbType.VarChar,32),
					new MySqlParameter("@_Telephone", MySqlDbType.VarChar,32),
					new MySqlParameter("@_Contact", MySqlDbType.VarChar,32),
                    
					new MySqlParameter("@_Buyer", MySqlDbType.VarChar,16),
					new MySqlParameter("@_Tickets", MySqlDbType.Int32,11),
					new MySqlParameter("@_Amount", MySqlDbType.Float,8),
					new MySqlParameter("@_ChequeNumber", MySqlDbType.VarChar,32),
					new MySqlParameter("@_Casher", MySqlDbType.Int32,11),

					new MySqlParameter("@_isTrue", MySqlDbType.Bit),
                    new MySqlParameter("@_DebtId",MySqlDbType.VarChar,10)
                                          };
            parameters[0].Value = customer.CustomerId;
            parameters[1].Value = customer.CustomerTypeId;
            parameters[2].Value = customer.CustomerName;
            parameters[3].Value = customer.BankBranch;
            parameters[4].Value = customer.Telephone;
            parameters[5].Value = customer.Contact;

            parameters[6].Value = debt.Buyer;
            parameters[7].Value = debt.Tickets;
            parameters[8].Value = debt.Amount;
            parameters[9].Value = debt.ChequeNumber;
            parameters[10].Value = debt.Casher;

            parameters[11].Direction = ParameterDirection.Output;
            parameters[12].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_debt_add", parameters, "debt_add");
            tf = parameters[11].Value.ToString().Trim() == "1" ? true : false;
            DebtId = parameters[12].Value.ToString();
            return tf;
        }

        /// <summary>
        /// 删除支票
        /// </summary>
        /// <param name="debtid"></param>
        /// <returns></returns>
        public static bool DelCheque(string debtid)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_DebtId", MySqlDbType.VarChar,10)};
            parameters[0].Value = debtid;
            int rowsAffected = 0;
            DbHelperMySQL.RunProcedure("proc_debt_del", parameters, out rowsAffected);
            if (rowsAffected == 1)
            {
                tf = true;
            }
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TheaterId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_isTrue", MySqlDbType.Bit),
					new MySqlParameter("@_ErrorMsg", MySqlDbType.VarChar,40)};
            parameters[0].Value = theaterid;
            parameters[1].Value = showplanid;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_ticket_reservationIsAllow", parameters, "reservationIsAllow");
            tf = parameters[2].Value.ToString().Trim() == "1" ? true : false;
            msg = parameters[3].Value.ToString();
            return tf;
        }

        /// <summary>
        /// 影票预定
        /// </summary>
        /// <param name="pReservationTicket">影票预定参数实体</param>
        /// <returns></returns>
        public static bool ReservationTicket(Flamingo.Entity.Para_ReservationTicket pReservationTicket)
        {
            #region 参数说明
            //_ShowPlanId varchar(12),        #场次ID
            //_CustomerName varchar(16),      #订票人姓名
            //_CustomerMobile varchar(16),    #预定人电话
            //_CustomerCode varchar(16),      #预定人密码
            //_Identity varchar(18),          #预定人身份证号
            //_SeatStatusIds text ,           #座位状态ID集合 |
            //_TicketTypes text,              #售票类型集合 |
            //_SeatNumbers text,              #座位号集合 |
            //_TicketPrices text,             #票价集合 |
            //_IssuedBy int,                  #经办人
            //_Count int,                     #预定票数
            //out _IsTrue bool                #是否预定成功
            #endregion
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_CustomerName", MySqlDbType.VarChar,16),
					new MySqlParameter("@_CustomerMobile", MySqlDbType.VarChar,16),
					new MySqlParameter("@_CustomerCode", MySqlDbType.VarChar,16),
					new MySqlParameter("@_Identity", MySqlDbType.VarChar,18),
					new MySqlParameter("@_SeatStatusIds", MySqlDbType.Text),   
					new MySqlParameter("@_TicketTypes", MySqlDbType.Text), 
					new MySqlParameter("@_SeatNumbers", MySqlDbType.Text),  
					new MySqlParameter("@_TicketPrices", MySqlDbType.Text),                 
					new MySqlParameter("@_IssuedBy", MySqlDbType.Int32,4),
					new MySqlParameter("@_Count", MySqlDbType.Int32,4),
					new MySqlParameter("@_isTrue", MySqlDbType.Bit)};
            parameters[0].Value = pReservationTicket.ShowPlanId;
            parameters[1].Value = pReservationTicket.CustomerName;
            parameters[2].Value = pReservationTicket.CustomerMobile;
            parameters[3].Value = pReservationTicket.CustomerCode;
            parameters[4].Value = pReservationTicket.Identity;
            parameters[5].Value = pReservationTicket.SeatStatusIds;
            parameters[6].Value = pReservationTicket.TicketTypes;
            parameters[7].Value = pReservationTicket.SeatNumbers;
            parameters[8].Value = pReservationTicket.TicketPrices;
            parameters[9].Value = pReservationTicket.IssuedBy;
            parameters[10].Value = pReservationTicket.Count;

            parameters[11].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_reservation_add", parameters, "reservation_add");
            tf = parameters[11].Value.ToString().Trim() == "1" ? true : false;
            return tf;
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
            Flamingo.Entity.Para_ReservationTicket model = new Entity.Para_ReservationTicket();
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_CustomerName", MySqlDbType.VarChar,16),
					new MySqlParameter("@_CustomerCode", MySqlDbType.VarChar,16),
					new MySqlParameter("@_Identity", MySqlDbType.VarChar,18)};
            parameters[0].Value = showplanid;
            parameters[1].Value = name;
            parameters[2].Value = pwd;
            parameters[3].Value = cardnum;
            DataTable dt = DbHelperMySQL.RunProcedure("proc_reservation_validate", parameters, "reservation_validate").Tables[0];
            if (dt.Rows.Count == 0)
            {
                model.ErrorMsg = "没有该预定信息";
            }
            else
            {
                model.Count = dt.Rows.Count;
                model.CustomerCode = pwd;
                //model.CustomerMobile
                model.CustomerName = name;
                model.Identity = cardnum;
                //model.IssuedBy
                model.ShowPlanId = showplanid;

                model.DT = dt;

            }
            return model;
        }

        /// <summary>
        /// 预定取消
        /// </summary>
        /// <param name="reservationids">预订票ID集合 |</param>
        /// <param name="seatstatusids">座位状态ID集合 |</param>
        /// <returns></returns>
        public static bool ReservationCancel(string reservationids)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ReservationIds", MySqlDbType.Text),
					new MySqlParameter("@_isTrue", MySqlDbType.Bit)};
            parameters[0].Value = reservationids;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_reservation_cancel", parameters, "reservation_cancel");
            tf = parameters[1].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 删除预定
        /// </summary>
        /// <param name="reservationid"></param>
        public static void ReservationDel(string reservationid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_reservationid", MySqlDbType.VarChar,16)};
            parameters[0].Value = reservationid;
            DbHelperMySQL.RunProcedure("proc_reservation_del", parameters, "reservation_del");
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
        public static bool ReservationOutTicket(string reservationids, string ticketids, string showplanid, string seatids, int paymengmethodid, float totalprice,
            string tickettypes,
            string ticketprices, string barcode, string soldby, int templateid, string filmid)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@spid", MySqlDbType.VarChar,12),
					new MySqlParameter("@stids", MySqlDbType.Text),
					new MySqlParameter("@pmid", MySqlDbType.Int32,4),
					new MySqlParameter("@tp", MySqlDbType.Float),
					new MySqlParameter("@_tickettypes", MySqlDbType.Text),
					new MySqlParameter("@_ticketprices", MySqlDbType.Text),
					new MySqlParameter("@_barcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@_soldby", MySqlDbType.VarChar,12),
					new MySqlParameter("@_templateid", MySqlDbType.Int32,4),
					new MySqlParameter("@_ticketids", MySqlDbType.Text),
                    new MySqlParameter("@isTrue",MySqlDbType.Bit),
					new MySqlParameter("@_ReservationIds", MySqlDbType.Text),
                    new MySqlParameter("@_FilmId",MySqlDbType.VarChar,12)
                                          };
            parameters[0].Value = showplanid;
            parameters[1].Value = seatids;
            parameters[2].Value = paymengmethodid;
            parameters[3].Value = totalprice;
            parameters[4].Value = tickettypes;
            parameters[5].Value = ticketprices;
            parameters[6].Value = barcode;
            parameters[7].Value = soldby;
            parameters[8].Value = templateid;
            parameters[9].Value = ticketids;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = reservationids;
            parameters[12].Value = filmid;
            DbHelperMySQL.RunProcedure("proc_reservation_outTicket", parameters, "reservation_outTicket");
            tf = parameters[10].Value.ToString().Trim() == "1" ? true : false;
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketPrices", MySqlDbType.Text),					
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_SeatStatusIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketTypeIds", MySqlDbType.Text),
					new MySqlParameter("@_PaymentId", MySqlDbType.Text),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanIds", MySqlDbType.Text),
					new MySqlParameter("@_FilmIds", MySqlDbType.Text),
					new MySqlParameter("@_Count", MySqlDbType.Int32,11),
					new MySqlParameter("@_isTrue", MySqlDbType.Int32,1),
                    new MySqlParameter("@_ReservationIds", MySqlDbType.Text)};
            parameters[0].Value = _TicketIds;
            parameters[1].Value = _TicketPrices;
            parameters[2].Value = _SoldBy;
            parameters[3].Value = _SeatStatusIds;
            parameters[4].Value = _TicketTypeIds;
            parameters[5].Value = _PaymentIds;
            parameters[6].Value = _TemplateId;
            parameters[7].Value = _ShowPlanIds;
            parameters[8].Value = _FilmIds;
            parameters[9].Value = _Count;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = _ReservationIds;
            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_reservationOutTicketGroup", parameters, "reservationOutTicketGroup");
            tf = parameters[10].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }


        /// <summary>
        /// 票券售票
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool VoucherSale(Flamingo.Entity.Para_VoucherAdd model)
        {
            #region 参数说明
            //#票券参数
            //_VoucherIds        varchar(50),       #票券ID(编号)
            //_Prices            varchar(15),       #票券面值
            //_BarCodes          text,              #票券条形码
            //_VoucherTypeIds    varchar(20),       #票券类型ID 集合 |
            //_VoucherBatchIds   varchar(20),       #票券小类型ID 集合 |
            //#影票参数
            //_PaymentMethodId   int,               #支付方式ID
            //_TicketType        int,               #售票类型
            //_TicketPrice       float,             #票价
            //_BarCode           varchar(255),      #影票条形码
            //_SoldBy            int,               #售票员
            //_ShowPlanId        char(12),          #场次ID
            //_SeatId            char(8),           #座位ID
            //_TemplateId        int,               #模版ID
            //_FilmId            char(12),          #影片ID
            //_TicketId          char(36),          #影票ID
            //#其他
            //out _isTrue        bool               #是否执行成功
            #endregion
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherIds", MySqlDbType.VarChar,50),
					new MySqlParameter("@_Prices", MySqlDbType.VarChar,15),
					new MySqlParameter("@_BarCodes", MySqlDbType.Text),
					new MySqlParameter("@_VoucherTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("@_VoucherBatchIds", MySqlDbType.VarChar,50),
					new MySqlParameter("@_PaymentMethodId", MySqlDbType.Int32,11),
					new MySqlParameter("@_TicketType", MySqlDbType.Int32,11),
					new MySqlParameter("@_TicketPrice", MySqlDbType.Float),
					new MySqlParameter("@_BarCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_SeatId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_FilmId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_TicketId", MySqlDbType.VarChar,36),
                    new MySqlParameter("@_isTrue",MySqlDbType.Bit)};
            parameters[0].Value = model.VoucherIds;
            parameters[1].Value = model.Prices;
            parameters[2].Value = model.BarCodes;
            parameters[3].Value = model.VoucherTypeId;
            parameters[4].Value = model.VoucherBatchIds;
            parameters[5].Value = model.PaymentMethodId;
            parameters[6].Value = model.TicketType;
            parameters[7].Value = model.TicketPrice;
            parameters[8].Value = model.BarCode;
            parameters[9].Value = model.SoldBy;
            parameters[10].Value = model.ShowPlanId;
            parameters[11].Value = model.SeatId;
            parameters[12].Value = model.TemplateId;
            parameters[13].Value = model.FilmId;
            parameters[14].Value = model.TicketId;
            parameters[15].Direction = ParameterDirection.Output;

            DbHelperMySQL.RunProcedure("proc_voucher_add", parameters, "voucher_add");
            tf = parameters[15].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 代用券售票
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool VoucherSubstituteSale(Flamingo.Entity.Para_VoucherAdd model)
        {
            #region 参数说明
            //#代用券参数
            //_VoucherBatchIds   varchar(50),        #代用券ID
            //#影票参数
            //_PaymentMethodId   int,               #支付方式ID
            //_TicketType        int,               #售票类型
            //_TicketPrice       float,             #票价
            //_BarCode           varchar(255),      #影票条形码
            //_SoldBy            int,               #售票员
            //_ShowPlanId        char(12),          #场次ID
            //_SeatId            char(8),           #座位ID
            //_TemplateId        int,               #模版ID
            //_FilmId            char(12),          #影片ID
            //_TicketId          char(36),          #影票ID
            //#其他
            //out _isTrue        bool               #是否执行成功
            #endregion
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherBatchIds", MySqlDbType.Text),
					new MySqlParameter("@_PaymentMethodId", MySqlDbType.Int32,11),
					new MySqlParameter("@_TicketType", MySqlDbType.Int32,11),
					new MySqlParameter("@_TicketPrice", MySqlDbType.Float),
					new MySqlParameter("@_BarCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_SeatId", MySqlDbType.VarChar,8),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_FilmId", MySqlDbType.VarChar,12),
					new MySqlParameter("@_TicketId", MySqlDbType.VarChar,36),
                    new MySqlParameter("@_isTrue",MySqlDbType.Bit)};
            parameters[0].Value = model.VoucherBatchIds;
            parameters[1].Value = model.PaymentMethodId;
            parameters[2].Value = model.TicketType;
            parameters[3].Value = model.TicketPrice;
            parameters[4].Value = model.BarCode;
            parameters[5].Value = model.SoldBy;
            parameters[6].Value = model.ShowPlanId;
            parameters[7].Value = model.SeatId;
            parameters[8].Value = model.TemplateId;
            parameters[9].Value = model.FilmId;
            parameters[10].Value = model.TicketId;
            parameters[11].Direction = ParameterDirection.Output;

            DbHelperMySQL.RunProcedure("proc_voucher_addSubstitute", parameters, "addSubstitute");
            tf = parameters[11].Value.ToString().Trim() == "1" ? true : false;
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherIds", MySqlDbType.VarChar,50),
					new MySqlParameter("@_Prices", MySqlDbType.VarChar,15),
					new MySqlParameter("@_BarCodes", MySqlDbType.Text),
					new MySqlParameter("@_VoucherTypeId", MySqlDbType.Int32,11),
					new MySqlParameter("@_VoucherBatchIds", MySqlDbType.VarChar,50),
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketPrices", MySqlDbType.Text),
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_SeatStatusIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketTypeIds", MySqlDbType.Text),
					new MySqlParameter("@_PaymentId", MySqlDbType.Int32,11),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanIds", MySqlDbType.Text),
					new MySqlParameter("@_FilmIds", MySqlDbType.Text),
					new MySqlParameter("@_Count", MySqlDbType.Int32,11),
					new MySqlParameter("@_isTrue", MySqlDbType.Int32,1)};
            parameters[0].Value = _VoucherIds;
            parameters[1].Value = _Prices;
            parameters[2].Value = _BarCodes;
            parameters[3].Value = _VoucherTypeId;
            parameters[4].Value = _VoucherBatchIds;
            parameters[5].Value = _TicketIds;
            parameters[6].Value = _TicketPrices;
            parameters[7].Value = _SoldBy;
            parameters[8].Value = _SeatStatusIds;
            parameters[9].Value = _TicketTypeIds;
            parameters[10].Value = _PaymentId;
            parameters[11].Value = _TemplateId;
            parameters[12].Value = _ShowPlanIds;
            parameters[13].Value = _FilmIds;
            parameters[14].Value = _Count;
            parameters[15].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_voucher_addGroup", parameters, "voucher_addGroup");
            tf = parameters[15].Value.ToString().Trim() == "1" ? true : false;
            return tf;
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherBatchIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketPrices", MySqlDbType.Text),
					new MySqlParameter("@_SoldBy", MySqlDbType.Int32,11),
					new MySqlParameter("@_SeatStatusIds", MySqlDbType.Text),
					new MySqlParameter("@_TicketTypeIds", MySqlDbType.Text),
					new MySqlParameter("@_PaymentId", MySqlDbType.Int32,11),
					new MySqlParameter("@_TemplateId", MySqlDbType.Int32,11),
					new MySqlParameter("@_ShowPlanIds", MySqlDbType.Text),
					new MySqlParameter("@_FilmIds", MySqlDbType.Text),
					new MySqlParameter("@_Count", MySqlDbType.Int32,11),
					new MySqlParameter("@_isTrue", MySqlDbType.Int32,1)};
            parameters[0].Value = _VoucherBatchIds;
            parameters[1].Value = _TicketIds;
            parameters[2].Value = _TicketPrices;
            parameters[3].Value = _SoldBy;
            parameters[4].Value = _SeatStatusIds;
            parameters[5].Value = _TicketTypeIds;
            parameters[6].Value = _PaymentId;
            parameters[7].Value = _TemplateId;
            parameters[8].Value = _ShowPlanIds;
            parameters[9].Value = _FilmIds;
            parameters[10].Value = _Count;
            parameters[11].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("proc_voucher_addSubstituteGroup", parameters, "addSubstituteGroup");
            tf = parameters[11].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 特殊锁定
        /// </summary>
        /// <param name="seatstatusid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool SpecialLock(string seatstatusid, int status, int lockedby)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_SeatStatusId", MySqlDbType.VarChar,50),
                    new MySqlParameter("@_status",MySqlDbType.Int32,4),
                    new MySqlParameter("@_Lockedby",MySqlDbType.Int32,4),
                    new MySqlParameter("@_isTrue",MySqlDbType.Int16)};

            parameters[0].Value = seatstatusid;
            parameters[1].Value = status;
            parameters[2].Value = lockedby;
            parameters[3].Direction = ParameterDirection.Output;

            DbHelperMySQL.RunProcedure("proc_seatstatus_specialLock", parameters, "specialLockLock");
            tf = parameters[3].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }

        /// <summary>
        /// 售票查询
        /// </summary>
        /// <param name="showplanid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static DataTable Query(string showplanid, int userid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12),
                    new MySqlParameter("@_SoldBy",MySqlDbType.Int32,4)};

            parameters[0].Value = showplanid;
            parameters[1].Value = userid;

            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_queryByUserId", parameters, "queryByUserId");
            return ds.Tables[0];
        }

        /// <summary>
        /// 条形码验票
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static DataTable ValidateTicket(string barcode)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_BarCode", MySqlDbType.VarChar,255)};

            parameters[0].Value = barcode;

            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_validateTicket", parameters, "validateTicket");
            return ds.Tables[ds.Tables.Count - 1];
        }

        /// <summary>
        /// 订票查询
        /// </summary>
        /// <param name="showplanid"></param>
        /// <returns></returns>
        public static DataTable ReservationQuery(string showplanid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,255)};

            parameters[0].Value = showplanid;

            DataSet ds = DbHelperMySQL.RunProcedure("proc_reservation_sel", parameters, "reservation_sel");
            return ds.Tables[ds.Tables.Count - 1];
        }

        /// <summary>
        /// 验证条形码存在
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>true:存在;false:不存在</returns>
        public static bool BarCodeExist(string barcode)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_BarCode", MySqlDbType.VarChar,50)};
            parameters[0].Value = barcode;

            DataTable dt = DbHelperMySQL.RunProcedure("proc_ticket_barCodeValidate", parameters, "barCodeValidate").Tables[0];
            tf = dt.Rows[0][0].ToString().Trim() == "0" ? false : true;
            return tf;
        }

        /// <summary>
        /// 判断是否已打印
        /// </summary>
        /// <param name="seatstatusid"></param>
        /// <param name="ticketid"></param>
        /// <returns></returns>
        public static bool HasPrinted(string seatstatusid, out string ticketid)
        {
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_SeatStatusid", MySqlDbType.VarChar,20),
                    new MySqlParameter("@_HasPrinted",MySqlDbType.Bit),
                    new MySqlParameter("@_TicketId",MySqlDbType.VarChar,36)};
            parameters[0].Value = seatstatusid;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;

            DbHelperMySQL.RunProcedure("proc_ticket_checkHasPrinted", parameters, "checkHasPrinted");
            tf = parameters[1].Value.ToString() == "0" ? false : true;
            ticketid = parameters[2].Value.ToString();
            return tf;

        }

        /// <summary>
        /// 修改打印状态
        /// </summary>
        /// <param name="ticketid"></param>
        /// <param name="status"></param>
        public static void SetPrintStatus(string ticketid, int status)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketId", MySqlDbType.VarChar,36),
                    new MySqlParameter("@_Status",MySqlDbType.Int32,4)};
            parameters[0].Value = ticketid;
            parameters[1].Value = status;
            int outint;
            DbHelperMySQL.RunProcedure("proc_ticket_setPrintStatus", parameters,out outint);
        }

        /// <summary>
        /// 修改打印状态
        /// </summary>
        /// <param name="ticketid"></param>
        /// <param name="status"></param>
        public static void SetPrintStatus(StringBuilder ticketid, int status)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
                    new MySqlParameter("@_Status",MySqlDbType.Int32,4)};
            parameters[0].Value = ticketid.ToString();
            parameters[1].Value = status;
            int outint;
            DbHelperMySQL.RunProcedure("proc_ticket_setPrintStatusAlot", parameters,out outint);
        }

        /// <summary>
        /// 获得补打信息
        /// </summary>
        /// <param name="ticketid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_TicketPrintInfo GetTicketPrintInfo(string ticketid)
        {
            Flamingo.Entity.Para_TicketPrintInfo model = null;

            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketId", MySqlDbType.VarChar,36)};

            parameters[0].Value = ticketid;

            DataTable dt = DbHelperMySQL.RunProcedure("proc_ticket_getPrintAgainInfo", parameters, "getPrintAgainInfo").Tables[0];
            if (dt.Rows.Count == 1)
            {
                model = new Entity.Para_TicketPrintInfo();
                model.BarCode = dt.Rows[0]["BarCode"].ToString();
                model.Payment = dt.Rows[0]["PaymentName"].ToString();
                model.SoldBy = dt.Rows[0]["EmployeeId"].ToString();
                model.SoldTime = DateTime.Parse(dt.Rows[0]["SoldTime"].ToString());
                model.TemplateId = Int32.Parse(dt.Rows[0]["TemplateId"].ToString());
                model.TicketId = dt.Rows[0]["TicketId"].ToString();
                model.TicketPrice = float.Parse(dt.Rows[0]["TicketPrice"].ToString());
                model.TicketType = dt.Rows[0]["TicketTypeName"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 获得售票类型
        /// </summary>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static DataTable GetTicketType()
        {
            return DbHelperMySQL.RunProcedure("proc_tickettype_sel", null, "tickettype_sel").Tables[0];
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
            MySqlParameter[] parameters = {
					new MySqlParameter("@_DailyPlanId", MySqlDbType.VarChar,8),                                          
					new MySqlParameter("@_HallId", MySqlDbType.VarChar,2),
					new MySqlParameter("@_ShowPlanId", MySqlDbType.VarChar,12)};

            parameters[0].Value = _DailyPlanId;
            parameters[1].Value = _HallId;
            parameters[2].Value = _ShowPlanId;

            DataSet ds = DbHelperMySQL.RunProcedure("proc_ticket_selFillUp", parameters, "ticket_selFillUp");
            return ds.Tables[ds.Tables.Count - 1];
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
            bool tf = false;
            MySqlParameter[] parameters = {
					new MySqlParameter("@_TicketIds", MySqlDbType.Text),
                    new MySqlParameter("@_TicketPrice",MySqlDbType.Float),
                    new MySqlParameter("@_SoldBy",MySqlDbType.Int32,4),
                    new MySqlParameter("@_TicketTypeId",MySqlDbType.Int32,4),
                    new MySqlParameter("@_ShowPlanId",MySqlDbType.VarChar,12),
                    new MySqlParameter("@_isTrue",MySqlDbType.Int32,4)};
            parameters[0].Value = ticketids;
            parameters[1].Value = ticketprice;
            parameters[2].Value = soldby;
            parameters[3].Value = tickettypeid;
            parameters[4].Value = showplanid;
            parameters[5].Direction = ParameterDirection.Output;

            DbHelperMySQL.RunProcedure("proc_ticket_addFillUp", parameters, "ticket_addFillUp");
            tf = parameters[5].Value.ToString().Trim() == "1" ? true : false;
            return tf;
        }
    }
}

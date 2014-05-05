using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Flamingo.Common;
using Flamingo.Right;

namespace Flamingo.BLL.Type
{
    /// <summary>
    /// 支付方式类
    /// </summary>
    public class PayType
    {
        /// <summary>
        /// 支付方式
        /// </summary>
        public enum Paytype
        {
            现金 = 1,
            //刷卡=2,
            支票 = 3,
            兑换券 = 4,
            代用券 = 5,
            优惠券 = 6,
            会员卡 = 7,
            会员卡支付卡 = 8,
            积分 = 9,
            赠票 = 10,
            票券 = 11
        }

        /// <summary>
        /// 支付方式总数
        /// </summary>
        public static int Count
        {
            get { return 8; }
        }

        /// <summary>
        /// 支付方式集合
        /// </summary>
        /// <returns></returns>
        public static NoSortHashTable List
        {
            get
            {
                NoSortHashTable ht = new NoSortHashTable();
                ht.Add(Paytype.现金, 1);
                //ht.Add(Paytype.刷卡, 2);
                ht.Add(Paytype.支票, 3);
                ht.Add(Paytype.优惠券, 6);
                ht.Add(Paytype.兑换券, 4);
                ht.Add(Paytype.代用券, 5);
                ht.Add(Paytype.会员卡, 7);
                ht.Add(Paytype.会员卡支付卡, 8);
                ht.Add(Paytype.积分, 9);
                ht.Add(Paytype.赠票, 10);
                return ht;
            }

        }

        /// <summary>
        /// 支付方式权限集合
        /// </summary>
        /// <returns></returns>
        public static NoSortHashTable ListPermissions
        {
            get
            {
                NoSortHashTable ht = new NoSortHashTable();
                ht.Add(Paytype.现金, Permissions.CashTicketSelling);
                //ht.Add(Paytype.刷卡, 2);
                ht.Add(Paytype.支票, Permissions.ChequeTicketSelling);
                ht.Add(Paytype.优惠券, Permissions.DiscountVoucherSelling);
                ht.Add(Paytype.兑换券, Permissions.ExchangeVoucherSelling);
                ht.Add(Paytype.代用券, Permissions.SubstituteVoucherSelling);
                ht.Add(Paytype.会员卡, Permissions.MembercardTicketSelling);
                ht.Add(Paytype.会员卡支付卡, Permissions.MembercardPayTicketSelling);
                ht.Add(Paytype.积分, Permissions.CreditTicketSelling);
                ht.Add(Paytype.赠票, Permissions.FreeTicketSelling);
                return ht;
            }

        }

        /// <summary>
        /// 数据类型转化为对象
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static Paytype ToPayType(object Number)
        {
            Paytype pt = Paytype.现金;
            switch (Number.ToString())
            {
                case "1":
                    pt = Paytype.现金;
                    break;
                //case "2":
                //    pt = Paytype.刷卡;
                //    break;
                case "3":
                    pt = Paytype.支票;
                    break;
                case "4":
                    pt = Paytype.兑换券;
                    break;
                case "5":
                    pt = Paytype.代用券;
                    break;
                case "6":
                    pt = Paytype.优惠券;
                    break;
                case "7":
                    pt = Paytype.会员卡;
                    break;
                case "8":
                    pt = Paytype.会员卡支付卡;
                    break;
                case "9":
                    pt = Paytype.积分;
                    break;
                case "10":
                    pt = Paytype.赠票;
                    break;
                //string类型
                case "现金":
                    pt = Paytype.现金;
                    break;
                //case "刷卡":
                //    pt = Paytype.刷卡;
                //    break;
                case "支票":
                    pt = Paytype.支票;
                    break;
                case "兑换券":
                    pt = Paytype.兑换券;
                    break;
                case "代用券":
                    pt = Paytype.代用券;
                    break;
                case "优惠券":
                    pt = Paytype.优惠券;
                    break;
                case "会员卡":
                    pt = Paytype.会员卡;
                    break;
                case "会员卡支付卡":
                    pt = Paytype.会员卡支付卡;
                    break;
                case "积分":
                    pt = Paytype.积分;
                    break;
                case "赠票":
                    pt = Paytype.赠票;
                    break;
            }
            return pt;
        }

        /// <summary>
        /// 类型转化为int
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static int ToPayType(Paytype pt)
        {
            switch (pt)
            {
                case Paytype.现金:
                    return 1;
                //case Paytype.刷卡:
                //    return 2;
                case Paytype.支票:
                    return 3;
                case Paytype.兑换券:
                    return 4;
                case Paytype.代用券:
                    return 5;
                case Paytype.优惠券:
                    return 6;
                case Paytype.会员卡:
                    return 7;
                case Paytype.会员卡支付卡:
                    return 8;
                case Paytype.积分:
                    return 9;
                case Paytype.赠票:
                    return 10;
            }
            return 0;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 票券业务处理 by lzz 2011-12-21
    /// </summary>
    public class Voucher
    {
        /// <summary>
        /// 获得票券信息(优惠券/兑换券)
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_Voucher Validate(string voucherid)
        {
            Flamingo.Entity.Para_Voucher model = DAL.Voucher.GetVoucher(voucherid);
            if (model.AllowUse != false)
            {
                Int64 voucherid_int = Int64.Parse(voucherid);
                if (voucherid_int < model.SerialScopeBegin || voucherid_int > model.SerialScopeEnd)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "无效票券";
                }
                else if (model.BeginDate > DateTime.Now)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "票券未到启用时间";
                }
                else if (model.EndDate < DateTime.Now)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "票券已过期";
                }
                else
                {
                    model.AllowUse = true;
                    model.ErrorMsg = "有效";
                }
            }
            return model;
        }

        /// <summary>
        /// 获得代用券信息
        /// </summary>
        /// <param name="voucherbatchid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_Voucher ValidateVoucherSubstitute(string voucherbatchid)
        {
            Flamingo.Entity.Para_Voucher model = DAL.Voucher.GetVoucherSubstitute(voucherbatchid);
            if (model.AllowUse != false)
            {
                if (model.BeginDate > DateTime.Now)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "代用券未到启用时间";
                }
                else if (model.EndDate < DateTime.Now)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "代用券已过期";
                }
                else
                {
                    //Int64 count = model.SerialScopeEnd - model.SerialScopeBegin;
                    //model.Count = (Int32)count;
                    //if (count > 0)
                    //{
                        model.AllowUse = true;
                        model.ErrorMsg = "有效";
                    //}
                    //else
                    //{
                    //    model.AllowUse = false;
                    //    model.ErrorMsg = "兑换券已用完";
                    //}
                }
            }
            return model;
        }

        /// <summary>
        /// 获得代用券名称
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVoucherSubstituteVoucherName()
        {
            return DAL.Voucher.GetVoucherSubstituteVoucherName();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Flamingo.DAL
{
    /// <summary>
    /// 票券数据库访问 by lzz 2011-12-21
    /// </summary>
    public class Voucher
    {
        /// <summary>
        /// 获得票券信息(优惠券/兑换券)
        /// </summary>
        /// <param name="voucherid">票券ID(编号)</param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_Voucher GetVoucher(string voucherid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherId", MySqlDbType.VarChar,16),
                    new MySqlParameter("@_HasUsed",MySqlDbType.Bit)
                                          };
            parameters[0].Value = voucherid;
            parameters[1].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperMySQL.RunProcedure("proc_voucherbatch_getByVoucherId", parameters, "getByVoucherId").Tables[0];
            bool tf = parameters[1].Value.ToString().Trim() == "1" ? true : false;
            Flamingo.Entity.Para_Voucher model = new Entity.Para_Voucher();

            if (dt.Rows.Count > 0)
            {
                model.VoucherBatchId = dt.Rows[0]["VoucherBatchId"].ToString();
                model.VoucherId = voucherid;
                model.VoucherName = dt.Rows[0]["VoucherName"].ToString();
                model.VoucherTypeId = Int32.Parse(dt.Rows[0]["VoucherTypeId"].ToString());
                model.VoucherType = dt.Rows[0]["VoucherTypeName"].ToString();
                model.BeginDate = DateTime.Parse(dt.Rows[0]["ReleaseDate"].ToString());
                model.EndDate = DateTime.Parse(dt.Rows[0]["ExpireDate"].ToString());
                model.Price = float.Parse(dt.Rows[0]["UnitPrice"].ToString());
                model.SerialScope = dt.Rows[0]["SerialScope"].ToString();
                model.TemplateId = 0;// Int32.Parse(dt.Rows[0]["TemplateId"].ToString());
                model.VoucherPrice = float.Parse(dt.Rows[0]["VoucherPrice"].ToString());
                model.VoucherSubTypeId = Int32.Parse(dt.Rows[0]["VoucherSubTypeId"].ToString());
                model.VoucherSubType = dt.Rows[0]["VoucherSubTypeName"].ToString();
                model.AllowUse = true;
                model.ErrorMsg = string.Empty;
                if (tf == true)
                {
                    model.AllowUse = false;
                    model.ErrorMsg = "票券已被使用";
                }
            }
            return model;
        }

        /// <summary>
        /// 获得代用券信息
        /// </summary>
        /// <param name="voucherbatchid"></param>
        /// <returns></returns>
        public static Flamingo.Entity.Para_Voucher GetVoucherSubstitute(string voucherbatchid)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_VoucherBatchId", MySqlDbType.VarChar,10)
                                          };
            parameters[0].Value = voucherbatchid;
            DataTable dt = DbHelperMySQL.RunProcedure("proc_voucherbatch_getByVoucherBatchId", parameters, "getByVoucherBatchId").Tables[0];
            
            Flamingo.Entity.Para_Voucher model = new Entity.Para_Voucher();

            if (dt.Rows.Count > 0)
            {
                model.VoucherBatchId = dt.Rows[0]["VoucherBatchId"].ToString();                
                model.VoucherName = dt.Rows[0]["VoucherName"].ToString();
                model.VoucherTypeId = Int32.Parse(dt.Rows[0]["VoucherTypeId"].ToString());
                model.VoucherType = dt.Rows[0]["VoucherTypeName"].ToString();
                model.BeginDate = DateTime.Parse(dt.Rows[0]["ReleaseDate"].ToString());
                model.EndDate = DateTime.Parse(dt.Rows[0]["ExpireDate"].ToString());
                model.Price = float.Parse(dt.Rows[0]["UnitPrice"].ToString());
                model.SerialScope = dt.Rows[0]["SerialScope"].ToString();
                model.VoucherPrice = float.Parse(dt.Rows[0]["VoucherPrice"].ToString());
                model.VoucherSubTypeId = Int32.Parse(dt.Rows[0]["VoucherSubTypeId"].ToString());
                model.VoucherSubType = dt.Rows[0]["VoucherSubTypeName"].ToString();
                model.AllowUse = true;
                model.ErrorMsg = string.Empty;
            }
            return model;

        }

        /// <summary>
        /// 获得代用券名称
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVoucherSubstituteVoucherName()
        {
            DataSet ds = DbHelperMySQL.RunProcedure("proc_voucherbatch_getSubstitute", null, "getSubstitute");
            return ds.Tables[0];
        }
    }
}

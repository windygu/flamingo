using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Flamingo.DAL
{
    /// <summary>
    /// 客户数据库访问 by lzz 2011-12-16
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 获得客户列表 模糊customername
        /// </summary>
        /// <param name="customername"></param>
        /// <returns></returns>
        public static DataTable GetCustomer(string customername)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("@_CustomerName", MySqlDbType.VarChar,16)};
            parameters[0].Value = customername;
            DataTable dt = DbHelperMySQL.RunProcedure("proc_customer_getByNameLike", parameters, "getByNameLike").Tables[0];
            return dt;
        }

        /// <summary>
        /// 获得客户类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCustomerType()
        {
            DataTable dt = DbHelperMySQL.RunProcedure("proc_customer_getCustomerType", null, "getCustomerType").Tables[0];
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 客户业务逻辑 by lzz 2011-12-16
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
            return DAL.Customer.GetCustomer(customername);
        }

        /// <summary>
        /// 获得客户类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCustomerType()
        {
            return DAL.Customer.GetCustomerType();
        }
    }
}

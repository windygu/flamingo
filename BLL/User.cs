using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 业务逻辑类:User 用户表
    /// </summary>
    public class User
    {

        /// <summary>
        /// 获得影院信息
        /// </summary>
        /// <returns></returns>
        public static string[] GetTheater()
        {
            string str = DAL.User.GetTheater();
            return str.Split(',');
        }

        /// <summary>
        /// 获得影厅
        /// </summary>
        /// <param name="theaterid"></param>
        /// <returns></returns>
        public static DataTable GetHall(string theaterid)
        {
            return DAL.User.GetHall(theaterid);
        }
    }
}

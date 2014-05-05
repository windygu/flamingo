using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.Common
{
    public class StringHelper
    {
        /// <summary>
        /// 判断是否是float类型并>0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(string str)
        {
            bool tf = false;
            try
            {
                float f = float.Parse(str);
                if (f > 0)
                    tf = true;
            }
            catch
            {
                tf = false;
            }
            return tf;
        }
        /// <summary>
        /// 判断是否为Int64 >0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt64(string str)
        {
            bool tf = false;
            try
            {
                float f = Int64.Parse(str);
                if (f > 0)
                    tf = true;
            }
            catch
            {
                tf = false;
            }
            return tf;
        }

        /// <summary>
        /// 判断是否为Int32 >0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt32(string str)
        {
            bool tf = false;
            try
            {
                float f = Int32.Parse(str);
                if (f > 0)
                    tf = true;
            }
            catch
            {
                tf = false;
            }
            return tf;
        }

        /// <summary>
        /// 判断是否是日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {

            bool tf = false;
            try
            {
                DateTime dt = DateTime.Parse(str);
                tf = true;
            }
            catch
            {
                tf = false;
            }
            return tf;
        }

        /// <summary>
        /// 随机
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Random(int length)
        {
            string strChar = "0123456789"; //abcdefghigklmnopqrstuvwxyz
            char[] aryChar = strChar.ToCharArray();
            StringBuilder strRandom = new StringBuilder();
            Random Rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                strRandom.Append(aryChar[Rnd.Next(8)]);
            }

            return strRandom.ToString();
        }

        /// <summary>
        /// 生成一定数量的GUID ,分割
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string NewGuids(int count)
        {
            if (count <= 0)
                return "";
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    sb.Append(Guid.NewGuid().ToString());
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        }
    }
}

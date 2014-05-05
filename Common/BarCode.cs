using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace Flamingo.Common
{
    public class BarCode
    {
        public string CreateCodeLogo(string code)
        {

            long len = code.Length;
            string lastString = "";
            char[] list = new char[len + 1];

            list = code.ToCharArray();

            for (int i = 0; i < list.Length; i++)
            {
                lastString += this.ConvertToBinaryString(list[i].ToString());
            }
            return lastString;
        }

        //将字符串数值转换为二进制字符串数值
        public string ConvertToBinaryString(string buf)
        {
            int[] temp = new int[20];
            string binary;
            int val = 0, i = 0, j;

            //先将字符转化为十进制数
            try
            {
                val = Convert.ToInt32(buf);
            }
            catch
            {
                val = 0;
            }

            if (val == 0)
            {
                return ("0000");
            }

            i = 0;
            while (val != 0)
            {
                temp[i++] = val % 2;
                val /= 2;
            }

            binary = "";

            for (j = 0; j <= i - 1; j++)
            {
                binary += (char)(temp[i - j - 1] + 48);
            }

            if (binary.Length < 4)   //如果小于4位左边补零
            {
                int len = 4 - binary.Length;
                string str = "";

                while (len > 0)
                {
                    str += "0";
                    len--;
                }

                binary = str + binary;
            }

            return (binary);
        }
    }
}

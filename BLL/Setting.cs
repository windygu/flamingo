using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    /// <summary>
    /// 设置场次选择配置信息
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 设置影片默认选择
        /// </summary>
        /// <param name="dailydate">计划日期</param>
        /// <param name="index">影片索引值</param>
        /// <param name="errorMessage">输入信息</param>
        /// <returns>是否设置成功</returns>
        public static bool SetFilmAuto(string dailydate, int index, out string errorMessage)
        {
            bool tf = false;
            errorMessage = "设置失败,请检查配置文件是否存在";

            string path = "Files/Setting.xml";
            try
            {
                Common.XML.SetElement(path, dailydate, "filmchoose", index);
                tf = true;
            }
            catch
            {
                errorMessage = "请检查配置文件Setting.xml";
            }
            return tf;
        }

        /// <summary>
        /// 获得影片默认选择
        /// </summary>
        /// <param name="dailydate"></param>
        /// <returns></returns>
        public static int GetFilmAuto(string dailydate)
        {
            string path = "Files/Setting.xml";
            int index = Common.XML.GetElement(path, "filmchoose", dailydate);
            return index;
        }
    }
}

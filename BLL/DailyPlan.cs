using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Flamingo.BLL
{
    /// <summary>
    /// 日计划表 业务逻辑 by lzz 2011-11-25
    /// </summary>
    public class DailyPlan
    {
        /// <summary>
        /// 获取可用日计划的ID和日期
        /// </summary>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagecount">每页数量</param>
        /// <param name="totalpage">总页数</param>
        /// <returns></returns>
        public static DataSet GetDateChoose(int pageindex, int pagecount, out int totalpage)
        {
            try
            {
                DataSet ds = new DataSet ();
                //string path = Directory.GetCurrentDirectory() + "\\Files\\GetDateChoose.xml";
                //if (File.Exists(path))
                //{
                //    totalpage = 1;
                //    ds = Common.XML.CXmlFileToDataSet(path);
                   
                //    //ds.ReadXml(path);
                //}
                //else
                //{
                    ds = DAL.DailyPlan.GetDateChoose(pageindex, pagecount, out totalpage);
                    //Flamingo.Common.XML.CDataToXmlFile(ds, path);
                //}
                return ds;
            }
            catch
            {
                totalpage = 0;
                return null;
            }
        }
    }
}

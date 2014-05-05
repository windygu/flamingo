using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Flamingo.BLL
{
    public class BackUp
    {
        /// <summary>
        /// 获得备份设置信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBackUpSetting()
        {
            return DAL.BackUp.GetBackUpSetting();
        }
        
        /// <summary>
        /// 编辑备份设置信息
        /// </summary>
        /// <param name="BackupSettingId"></param>
        /// <param name="BackupTime"></param>
        /// <param name="RepeatDay"></param>
        /// <param name="DatabasePath"></param>
        /// <param name="BackupPath"></param>
        public static void EditBackUpSetting(int BackupSettingId, string BackupTime, int RepeatDay, string DatabasePath, string BackupPath)
        {
            DAL.BackUp.EditBackUpSetting(BackupSettingId, BackupTime, RepeatDay, DatabasePath, BackupPath);
        }

        
        /// <summary>
        /// 添加立即备份动作
        /// </summary>
        /// <param name="userid"></param>
        public static int AddServerDirection(int userid)
        {
            return DAL.BackUp.AddServerDirection(userid);
        }
        
        /// <summary>
        /// 获得服务器动作结果
        /// </summary>
        /// <param name="serverdirectionid"></param>
        /// <returns></returns>
        public static int GetServerDirectionResult(int serverdirectionid)
        {
            return DAL.BackUp.GetServerDirectionResult(serverdirectionid);
        }
        
        /// <summary>
        /// 添加备份日志
        /// </summary>
        /// <param name="_ServerDirectionId"></param>
        /// <param name="_BackupDate"></param>
        /// <param name="_Result"></param>
        public static void AddBackUpLog(int ServerDirectionId, DateTime BackupDate, int Result)
        {
            DAL.BackUp.AddBackUpLog(ServerDirectionId, BackupDate, Result);
        }
    }
}

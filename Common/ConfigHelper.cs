﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Flamingo.Common
{
    /// <summary>
    /// web.config操作类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到tConnectionString中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        /// <summary>
        /// 得到tConnectionString中的配置字符串信息(解密)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionStringDecrypt(string key)
        {
            return DESEncrypt.Decrypt(ConfigurationManager.AppSettings[key].ToString());
        }

        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            //string CacheKey = "AppSettings-" + key;
            object objModel = new object();// = DataCache.GetCache(CacheKey);
            //if (objModel == null)
            //{
                try
                {
                    objModel = ConfigurationManager.AppSettings[key];
                    //if (objModel != null)
                    //{
                    //    DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    //}
                }
                catch
                { }
            //}
            return objModel.ToString();
        }

        /// <summary>
        /// 得到AppSettings中的配置字符串信息(解密)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigStringDecrypt(string key)
        {
            object objModel = new object();
            try
            {
                objModel = DESEncrypt.Decrypt(ConfigurationManager.AppSettings[key]);
            }
            catch
            { }
            return objModel.ToString();
        }

        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = bool.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = decimal.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
    }
}

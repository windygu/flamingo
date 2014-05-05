using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.EntityClient;
using System.IO;

namespace Flamingo
{
    public static class Database
    {
        private static string connectionString;

        private static string server = "127.0.0.1";
        private static uint port = 3306;
        private static string database = "icefish";
        private static string userId = "root";
        private static string password = "Mustang999";
        private static string characterSet = "utf8";

        private static string dataEntityName = "FlamingoModel";

        /// <summary>
        /// 获取或设置数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                {
                    connectionString = MakeConnectionString();
                }

                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        /// <summary>
        /// 获取新的数据库实体
        /// </summary>
        /// <returns></returns>
        public static FlamingoEntities GetNewDataEntity()
        {
            if (connectionString == null)
            {
                connectionString = MakeConnectionString();
            }
            return new FlamingoEntities(new EntityConnection(connectionString));
        }

		/// <summary>
        /// 读取数据库配置信息
        /// </summary>
        public static void LoadDatabaseConfig()
        {
            string cnnStr = DataManager.CommandString.ConnectionString;

            try
            {
                string[] cnn = cnnStr.Split(';');
                foreach (string cnnData in cnn)
                {
                    string[] Array = cnnData.Split('=');
                    switch (Array[0].Trim().ToUpper())
                    {
                        case "SERVER":
                            {
                                server = Array[1].ToString().Trim();
                                break;
                            }
                        case "DATABASE":
                            {
                                database = Array[1].ToString().Trim();
                                break;
                            }
                        case "USER ID":
                            {
                                userId = Array[1].ToString().Trim();
                                break;
                            }
                        case "PASSWORD":
                            {
                                password = Array[1].ToString().Trim();
                                break;
                            }
                        case "PORT":
                            {
                                port = Convert.ToUInt32(Array[1].ToString().Trim());
                                break;
                            }
                    }
                }
            }
            catch { }

            //string FilePath = System.Environment.CurrentDirectory + @"\Config.txt";
            //if (File.Exists(FilePath) != true)
            //    return;

            //try
            //{
            //    StreamReader sr = new StreamReader(FilePath);
            //    while (sr.Peek() > 0)
            //    {
            //        string[] Array = sr.ReadLine().Split('=');
            //        switch (Array[0].Trim().ToUpper())
            //        {
            //            case "SERVER":
            //                {
            //                    server = Array[1].ToString().Trim();
            //                    break;
            //                }
            //            case "DATABASE":
            //                {
            //                    database = Array[1].ToString().Trim();
            //                    break;
            //                }
            //            case "USERID":
            //                {
            //                    userId = Array[1].ToString().Trim();
            //                    break;
            //                }
            //            case "PASSWORD":
            //                {
            //                    password = Array[1].ToString().Trim();
            //                    break;
            //                }
            //            case "PORT":
            //                {
            //                    port = Convert.ToUInt32(Array[1].ToString().Trim());
            //                    break;
            //                }
            //        }
            //    }
            //}
            //catch { }
        }

        /// <summary>
        /// 构造连接字符串
        /// </summary>
        private static string MakeConnectionString()
        {
            MySqlConnectionStringBuilder mySqlcnnStrBdr = new MySqlConnectionStringBuilder();
            mySqlcnnStrBdr.Server = server;
            mySqlcnnStrBdr.Database = database;
            mySqlcnnStrBdr.UserID = userId;
            mySqlcnnStrBdr.Password = password;
            mySqlcnnStrBdr.CharacterSet = characterSet;
            mySqlcnnStrBdr.Port = port;
            mySqlcnnStrBdr.AllowZeroDateTime = true;

            EntityConnectionStringBuilder entityCnnStrBdr = new EntityConnectionStringBuilder();
            entityCnnStrBdr.Provider = "MySql.Data.MySqlClient";
            entityCnnStrBdr.ProviderConnectionString = mySqlcnnStrBdr.ConnectionString;
            entityCnnStrBdr.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", dataEntityName);

            return entityCnnStrBdr.ConnectionString;
        }
    }
}

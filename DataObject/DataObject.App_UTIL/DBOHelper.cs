using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.App_UTIL
{
	public class DBOHelper
	{
		private static string m_szConnString = "";
		public static string connString
		{
			get
			{
				return DBOHelper.m_szConnString;
			}
			set
			{
				DBOHelper.m_szConnString = value;
			}
		}
		public static MySqlConnection GetConnection()
		{
			if (string.IsNullOrEmpty(DBOHelper.connString))
			{
				throw new Exception("数据库连接字符串错误");
			}
			MySqlConnection result;
			try
			{
				MySqlConnection mySqlConnection = new MySqlConnection(DBOHelper.connString);
				result = mySqlConnection;
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			return result;
		}
		public static MySqlTransaction OpenTransaction(MySqlConnection conn)
		{
			MySqlTransaction result;
			if (conn != null)
			{
				result = conn.BeginTransaction();
			}
			else
			{
				result = null;
			}
			return result;
		}
		public static void CommitTransaction(MySqlTransaction tran)
		{
			tran.Commit();
		}
		public static void RollBackTransction(MySqlTransaction tran)
		{
			tran.Rollback();
		}
		public static void OpenConnection(MySqlConnection conn)
		{
			if (conn == null)
			{
				conn = DBOHelper.GetConnection();
			}
			try
			{
				conn.Open();
			}
			catch
			{
				conn = null;
				throw new Exception("连接数据库字符串是否正确，sqlserver是否打开远程连接");
			}
		}
		public static void CloseConnection(MySqlConnection conn)
		{
			if (conn != null)
			{
				try
				{
					if (conn.State == ConnectionState.Open)
					{
						conn.Close();
					}
				}
				catch (MySqlException ex)
				{
					conn = null;
					throw new Exception(ex.Message);
				}
			}
		}
		public static void CloseSqlDataReader(MySqlDataReader reader)
		{
			if (reader != null)
			{
				reader.Close();
			}
		}
		public static DateTime GetDateTime(MySqlDataReader reader, string colName)
		{
			DateTime result;
			if (Convert.IsDBNull(reader[colName]))
			{
				result = DateTime.MinValue;
			}
			else
			{
				result = Convert.ToDateTime(reader[colName]);
			}
			return result;
		}
		public static long Trans8ByteToInt64(MySqlDataReader reader, string colName)
		{
			long num = 0L;
			byte[] array = (byte[])reader[colName];
			int num2 = array.Length;
			long result;
			if (num2 <= 0)
			{
				result = 0L;
			}
			else
			{
				for (int i = num2 - 1; i >= 0; i--)
				{
					byte b = array[i];
					long num3 = (long)((ulong)b);
					num3 <<= (7 - i) * 8;
					num += num3;
				}
				result = num;
			}
			return result;
		}
		public static long Trans8ByteToLong(byte[] ts)
		{
			long num = 0L;
			int num2 = ts.Length;
			long result;
			if (num2 <= 0)
			{
				result = 0L;
			}
			else
			{
				for (int i = num2 - 1; i >= 0; i--)
				{
					byte b = ts[i];
					long num3 = (long)((ulong)b);
					num3 <<= (7 - i) * 8;
					num += num3;
				}
				result = num;
			}
			return result;
		}
		public static bool fucCheckNUM(string NUM)
		{
			int num = 0;
			bool flag = false;
			string text = "0123456789.-";
			bool result;
			if (NUM.Trim().Length <= 0)
			{
				NUM = "0";
				result = true;
			}
			else
			{
				for (int i = 0; i < NUM.Length; i++)
				{
					for (int j = 0; j < 11; j++)
					{
						if (NUM[i].Equals(text[j]))
						{
							if (j == 10)
							{
								num++;
							}
							flag = true;
							break;
						}
						flag = false;
					}
					if (!flag)
					{
						break;
					}
				}
				result = (num <= 1 && flag);
			}
			return result;
		}
		public static bool fucCheckNUM(ref string NUM)
		{
			int num = 0;
			bool flag = false;
			string text = "0123456789.-";
			bool result;
			if (NUM.Trim().Length <= 0)
			{
				NUM = "0";
				result = true;
			}
			else
			{
				if (NUM.Trim() == "-" || NUM.Trim() == ".")
				{
					NUM = "0";
					result = true;
				}
				else
				{
					for (int i = 0; i < NUM.Length; i++)
					{
						for (int j = 0; j < 11; j++)
						{
							if (NUM[i].Equals(text[j]))
							{
								if (j == 10)
								{
									num++;
								}
								flag = true;
								break;
							}
							flag = false;
						}
						if (!flag)
						{
							break;
						}
					}
					result = (num <= 1 && flag);
				}
			}
			return result;
		}
		public static bool fucCheckNUM2(string NUM)
		{
			int num = 0;
			bool flag = false;
			string text = "0123456789.-";
			bool result;
			if (NUM.Trim().Length <= 0)
			{
				NUM = "0";
				result = true;
			}
			else
			{
				for (int i = 0; i < NUM.Length; i++)
				{
					for (int j = 0; j < 12; j++)
					{
						if (NUM[i].Equals(text[j]))
						{
							if (j == 10)
							{
								if (i == NUM.Length - 1)
								{
									flag = false;
									break;
								}
								num++;
							}
							flag = (j != 11 || i == 0);
							break;
						}
						flag = false;
					}
					if (!flag)
					{
						break;
					}
				}
				result = (num <= 1 && flag);
			}
			return result;
		}
		public static string GetString(MySqlDataReader reader, string colName)
		{
			string result;
			if (Convert.IsDBNull(reader[colName]))
			{
				result = string.Empty;
			}
			else
			{
				result = reader[colName].ToString();
			}
			return result;
		}
		public static decimal GetDecimal(MySqlDataReader reader, string colName)
		{
			decimal result;
			if (Convert.IsDBNull(reader[colName]))
			{
				result = 0m;
			}
			else
			{
				result = Convert.ToDecimal(reader[colName]);
			}
			return result;
		}
	}
}

using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class OnLineUserLogDbo
	{
		public class CmdParam
		{
			public static string USERID = "@USERID";
			public static string USERNAME = "@USERNAME";
			public static string WS_IP = "@WS_IP";
			public static string WS_MAC = "@WS_MAC";
			public static string CREATED = "@CREATED";
		}
		private string TABLE_NAME = "onlineuserlog";
		private string SQL_SELECT_COLUMNS = " USERID,USERNAME,WS_IP,WS_MAC,CREATED ";
		private string SQL_INSERT_COLUMNS = " USERID,USERNAME,WS_IP,WS_MAC,CREATED ";
		private string SQL_INSERT_VALUES = " @USERID,@USERNAME,@WS_IP,@WS_MAC,@CREATED ";
		private string SQL_UPDATE_FIELD = " USERNAME=@USERNAME,WS_IP=@WS_IP,WS_MAC=@WS_MAC,CREATED=@CREATED ";
		private string SQL_WHERE_KEYS = " WHERE USERID=@USERID ";
		private void SetKeyParams(MySqlCommand cmd, OnLineUserLogPo obj)
		{
			cmd.Parameters.AddWithValue(OnLineUserLogDbo.CmdParam.USERID, 3).Value = obj.USERID;
		}
		private void SetAttParams(MySqlCommand cmd, OnLineUserLogPo obj)
		{
			cmd.Parameters.AddWithValue(OnLineUserLogDbo.CmdParam.USERNAME, 253).Value = obj.USERNAME;
			cmd.Parameters.AddWithValue(OnLineUserLogDbo.CmdParam.WS_IP, 253).Value = obj.WS_IP;
			cmd.Parameters.AddWithValue(OnLineUserLogDbo.CmdParam.WS_MAC, 253).Value = obj.WS_MAC;
			cmd.Parameters.AddWithValue(OnLineUserLogDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, OnLineUserLogPo obj)
		{
			string text = string.Concat(new string[]
			{
				"INSERT INTO ",
				this.TABLE_NAME,
				" (",
				this.SQL_INSERT_COLUMNS,
				") VALUES (",
				this.SQL_INSERT_VALUES,
				")"
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, conn, trans);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			return result;
		}
		public bool Insert(OnLineUserLogPo obj)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = string.Concat(new string[]
			{
				"INSERT INTO ",
				this.TABLE_NAME,
				" (",
				this.SQL_INSERT_COLUMNS,
				") VALUES (",
				this.SQL_INSERT_VALUES,
				")"
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
		public bool Update(MySqlConnection conn, MySqlTransaction trans, OnLineUserLogPo obj)
		{
			string text = string.Concat(new string[]
			{
				"UPDATE ",
				this.TABLE_NAME,
				" SET ",
				this.SQL_UPDATE_FIELD,
				this.SQL_WHERE_KEYS
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, conn, trans);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			return result;
		}
		public bool Update(OnLineUserLogPo obj)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = string.Concat(new string[]
			{
				"UPDATE ",
				this.TABLE_NAME,
				" SET ",
				this.SQL_UPDATE_FIELD,
				this.SQL_WHERE_KEYS
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, OnLineUserLogPo obj)
		{
			string text = " DELETE FROM " + this.TABLE_NAME + this.SQL_WHERE_KEYS;
			MySqlCommand mySqlCommand = new MySqlCommand(text, conn, trans);
			this.SetKeyParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			return result;
		}
		public bool Delete(OnLineUserLogPo obj)
		{
			string text = " DELETE FROM " + this.TABLE_NAME + this.SQL_WHERE_KEYS;
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			this.SetKeyParams(mySqlCommand, obj);
			bool result;
			try
			{
				result = (mySqlCommand.ExecuteNonQuery() > 0);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
		public DataTable RetrieveALLItems()
		{
			string text = "select * from onlineuserlog ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("onlineuserlog");
				mySqlDataAdapter.Fill(dataTable);
				int count = dataTable.Rows.Count;
				mySqlDataAdapter.Dispose();
				result = dataTable;
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
		public DataTable RetrieveOneItems(int nUserId)
		{
			string text = "SELECT * FROM onlineuserlog WHERE UserId = {0} ";
			text = string.Format(text, nUserId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("onlineuserlog");
				mySqlDataAdapter.Fill(dataTable);
				int count = dataTable.Rows.Count;
				mySqlDataAdapter.Dispose();
				result = dataTable;
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
	}
}

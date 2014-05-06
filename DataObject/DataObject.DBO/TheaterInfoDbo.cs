using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class TheaterInfoDbo
	{
		public class CmdParam
		{
			public static string THEATERID = "@THEATERID";
			public static string AUTHORIZATIONID = "@AUTHORIZATIONID";
			public static string THEATERTYPEID = "@THEATERTYPEID";
			public static string THEATERNAME = "@THEATERNAME";
			public static string CORPORATION = "@CORPORATION";
			public static string TELEPHONE = "@TELEPHONE";
			public static string CONTACTPEOPLE = "@CONTACTPEOPLE";
			public static string HALLS = "@HALLS";
			public static string SEATS = "@SEATS";
			public static string PROVINCE = "@PROVINCE";
			public static string CITY = "@CITY";
			public static string DISTRICT = "@DISTRICT";
			public static string POSTCODE = "@POSTCODE";
			public static string ADDRESS = "@ADDRESS";
			public static string THEATERCODE = "@THEATERCODE";
			public static string CINECHAINID = "@CINECHAINID";
			public static string SERIALNUMER = "@SERIALNUMER";
			public static string RATIO = "@RATIO";
		}
		private string TABLE_NAME = "Theater";
		private string SQL_SELECT_COLUMNS = " THEATERID,AUTHORIZATIONID,THEATERTYPEID,THEATERNAME,CORPORATION,TELEPHONE,CONTACTPEOPLE,HALLS,SEATS,PROVINCE,CITY,DISTRICT,POSTCODE,ADDRESS,THEATERCODE,CINECHAINID,SERIALNUMER,RATIO ";
		private string SQL_INSERT_COLUMNS = " THEATERID,AUTHORIZATIONID,THEATERTYPEID,THEATERNAME,CORPORATION,TELEPHONE,CONTACTPEOPLE,HALLS,SEATS,PROVINCE,CITY,DISTRICT,POSTCODE,ADDRESS,THEATERCODE,CINECHAINID,SERIALNUMER,RATIO ";
		private string SQL_INSERT_VALUES = " @THEATERID,@AUTHORIZATIONID,@THEATERTYPEID,@THEATERNAME,@CORPORATION,@TELEPHONE,@CONTACTPEOPLE,@HALLS,@SEATS,@PROVINCE,@CITY,@DISTRICT,@POSTCODE,@ADDRESS,@THEATERCODE,@CINECHAINID,@SERIALNUMER,@RATIO ";
		private string SQL_UPDATE_FIELD = " AUTHORIZATIONID=@AUTHORIZATIONID,THEATERTYPEID=@THEATERTYPEID,THEATERNAME=@THEATERNAME,CORPORATION=@CORPORATION,TELEPHONE=@TELEPHONE,CONTACTPEOPLE=@CONTACTPEOPLE,HALLS=@HALLS,SEATS=@SEATS,PROVINCE=@PROVINCE,CITY=@CITY,DISTRICT=@DISTRICT,POSTCODE=@POSTCODE,ADDRESS=@ADDRESS,THEATERCODE=@THEATERCODE,CINECHAINID=@CINECHAINID,SERIALNUMER=@SERIALNUMER,RATIO=@RATIO ";
		private string SQL_WHERE_KEYS = " WHERE THEATERID=@THEATERID ";
		private void SetKeyParams(MySqlCommand cmd, TheaterInfoPo obj)
		{
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.THEATERID, 253).Value = obj.THEATERID;
		}
		private void SetAttParams(MySqlCommand cmd, TheaterInfoPo obj)
		{
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.AUTHORIZATIONID, 253).Value = obj.AUTHORIZATIONID;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.THEATERTYPEID, 253).Value = obj.THEATERTYPEID;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.THEATERNAME, 253).Value = obj.THEATERNAME;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.CORPORATION, 253).Value = obj.CORPORATION;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.TELEPHONE, 253).Value = obj.TELEPHONE;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.CONTACTPEOPLE, 253).Value = obj.CONTACTPEOPLE;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.HALLS, 503).Value = obj.HALLS;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.SEATS, 503).Value = obj.SEATS;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.PROVINCE, 253).Value = obj.PROVINCE;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.CITY, 253).Value = obj.CITY;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.DISTRICT, 253).Value = obj.DISTRICT;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.POSTCODE, 253).Value = obj.POSTCODE;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.ADDRESS, 253).Value = obj.ADDRESS;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.THEATERCODE, 253).Value = obj.THEATERCODE;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.CINECHAINID, 253).Value = obj.CINECHAINID;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.SERIALNUMER, 253).Value = obj.SERIALNUMER;
			cmd.Parameters.AddWithValue(TheaterInfoDbo.CmdParam.RATIO, 4).Value = obj.RATIO;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, TheaterInfoPo obj)
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
		public bool Insert(TheaterInfoPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, TheaterInfoPo obj)
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
		public bool Update(TheaterInfoPo obj)
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, TheaterInfoPo obj)
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
		public bool Delete(TheaterInfoPo obj)
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
			string text = "select * from Theater ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("TheaterInfo");
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
		public DataTable RetrieveALLItems(string szCineChainId)
		{
			string text = "SELECT * FROM Theater WHERE CineChainId = '{0}' ";
			text = string.Format(text, szCineChainId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("TheaterInfo");
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

using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class HallDbo
	{
		public class CmdParam
		{
			public static string HALLID = "@HALLID";
			public static string THEATERID = "@THEATERID";
			public static string HALLNAME = "@HALLNAME";
			public static string SEATS = "@SEATS";
			public static string LEVELS = "@LEVELS";
			public static string SCREEN = "@SCREEN";
			public static string PROJECTOR = "@PROJECTOR";
			public static string PLAYMODE = "@PLAYMODE";
			public static string SOUNDSYSTEM = "@SOUNDSYSTEM";
			public static string DESCRIPTION = "@DESCRIPTION";
		}
		private string TABLE_NAME = "Hall";
		private string SQL_SELECT_COLUMNS = " HALLID,THEATERID,HALLNAME,SEATS,LEVELS,SCREEN,PROJECTOR,PLAYMODE,SOUNDSYSTEM,DESCRIPTION ";
		private string SQL_INSERT_COLUMNS = " HALLID,THEATERID,HALLNAME,SEATS,LEVELS,SCREEN,PROJECTOR,PLAYMODE,SOUNDSYSTEM,DESCRIPTION ";
		private string SQL_INSERT_VALUES = " @HALLID,@THEATERID,@HALLNAME,@SEATS,@LEVELS,@SCREEN,@PROJECTOR,@PLAYMODE,@SOUNDSYSTEM,@DESCRIPTION ";
		private string SQL_UPDATE_FIELD = " THEATERID=@THEATERID,HALLNAME=@HALLNAME,SEATS=@SEATS,LEVELS=@LEVELS,SCREEN=@SCREEN,PROJECTOR=@PROJECTOR,PLAYMODE=@PLAYMODE,SOUNDSYSTEM=@SOUNDSYSTEM,DESCRIPTION=@DESCRIPTION ";
		private string SQL_UPDATE_FIELD_SEATS = " SEATS=@SEATS ";
		private string SQL_WHERE_KEYS = " WHERE HALLID=@HALLID ";
		private void SetKeyParams(MySqlCommand cmd, HallPo obj)
		{
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.HALLID, 253).Value = obj.HALLID;
		}
		private void SetAttParams(MySqlCommand cmd, HallPo obj)
		{
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.THEATERID, 253).Value = obj.THEATERID;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.HALLNAME, 253).Value = obj.HALLNAME;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.SEATS, 503).Value = obj.SEATS;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.LEVELS, 502).Value = obj.LEVELS;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.SCREEN, 253).Value = obj.SCREEN;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.PROJECTOR, 253).Value = obj.PROJECTOR;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.PLAYMODE, 253).Value = obj.PLAYMODE;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.SOUNDSYSTEM, 253).Value = obj.SOUNDSYSTEM;
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.DESCRIPTION, 253).Value = obj.DESCRIPTION;
		}
		private void SetAttParams_Seats(MySqlCommand cmd, HallPo obj)
		{
			cmd.Parameters.AddWithValue(HallDbo.CmdParam.SEATS, 503).Value = obj.SEATS;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, HallPo obj)
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
		public bool Insert(HallPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, HallPo obj)
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
		public bool Update(HallPo obj)
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
		public bool UpdateSeat(HallPo obj)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = string.Concat(new string[]
			{
				"UPDATE ",
				this.TABLE_NAME,
				" SET ",
				this.SQL_UPDATE_FIELD_SEATS,
				this.SQL_WHERE_KEYS
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams_Seats(mySqlCommand, obj);
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, HallPo obj)
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
		public bool Delete(HallPo obj)
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
		public int GetHallLevel(string szTheaterId, string szHallId)
		{
			string text = "SELECT Levels FROM Hall WHERE TheaterId = '{0}' and HallId = '{1}'";
			text = string.Format(text, szTheaterId, szHallId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 3000;
            mySqlCommand.Connection = connection;
			int result;
			try
			{
				object obj = mySqlCommand.ExecuteScalar();
				if (obj == DBNull.Value || obj == null)
				{
					result = 0;
				}
				else
				{
					result = Convert.ToInt32(obj);
				}
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
		public DataTable RetrieveALLItems()
		{
			string text = "select * from Hall ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Hall");
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
		public DataTable RetrieveALLItems(string szTheaterId)
		{
			string text = "SELECT * FROM Hall WHERE TheaterId = '{0}' ";
			text = string.Format(text, szTheaterId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Hall");
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

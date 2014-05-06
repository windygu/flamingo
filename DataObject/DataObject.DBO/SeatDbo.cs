using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class SeatDbo
	{
		public class CmdParam
		{
			public static string SEATID = "@SEATID";
			public static string ROWNUMBER = "@ROWNUMBER";
			public static string COLUMNNUMBER = "@COLUMNNUMBER";
			public static string SEATNUMBER = "@SEATNUMBER";
			public static string XAXIS = "@XAXIS";
			public static string YAXIS = "@YAXIS";
			public static string HEIGHT = "@HEIGHT";
			public static string WIDTH = "@WIDTH";
			public static string PROPERTY = "@PROPERTY";
			public static string SEATGROUP = "@SEATGROUP";
			public static string CAPACITY = "@CAPACITY";
			public static string SEATINGCHARTID = "@SEATINGCHARTID";
			public static string BLOCKID = "@BLOCKID";
			public static string SEATTYPE = "@SEATTYPE";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "Seat";
		private string SQL_SELECT_COLUMNS = " SEATID,ROWNUMBER,COLUMNNUMBER,SEATNUMBER,XAXIS,YAXIS,HEIGHT,WIDTH,PROPERTY,SEATGROUP,CAPACITY,SEATINGCHARTID,BLOCKID,SEATTYPE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " SEATID,ROWNUMBER,COLUMNNUMBER,SEATNUMBER,XAXIS,YAXIS,HEIGHT,WIDTH,PROPERTY,SEATGROUP,CAPACITY,SEATINGCHARTID,BLOCKID,SEATTYPE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @SEATID,@ROWNUMBER,@COLUMNNUMBER,@SEATNUMBER,@XAXIS,@YAXIS,@HEIGHT,@WIDTH,@PROPERTY,@SEATGROUP,@CAPACITY,@SEATINGCHARTID,@BLOCKID,@SEATTYPE,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " ROWNUMBER=@ROWNUMBER,COLUMNNUMBER=@COLUMNNUMBER,SEATNUMBER=@SEATNUMBER,XAXIS=@XAXIS,YAXIS=@YAXIS,HEIGHT=@HEIGHT,WIDTH=@WIDTH,PROPERTY=@PROPERTY,SEATGROUP=@SEATGROUP,CAPACITY=@CAPACITY,SEATINGCHARTID=@SEATINGCHARTID,BLOCKID=@BLOCKID,SEATTYPE=@SEATTYPE,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_UPDATETYPE_FIELD = " SEATGROUP=@SEATGROUP,SEATTYPE=@SEATTYPE,UPDATED=@UPDATED ";
		private string SQL_WHERE_KEYS = " WHERE SEATID=@SEATID ";
		private void SetKeyParams(MySqlCommand cmd, SeatPo obj)
		{
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATID, 253).Value = obj.SEATID;
		}
		private void SetAttParams(MySqlCommand cmd, SeatPo obj)
		{
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.ROWNUMBER, 15).Value = obj.ROWNUMBER;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.COLUMNNUMBER, 15).Value = obj.COLUMNNUMBER;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATNUMBER, 15).Value = obj.SEATNUMBER;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.XAXIS, 3).Value = obj.XAXIS;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.YAXIS, 3).Value = obj.YAXIS;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.HEIGHT, 3).Value = obj.HEIGHT;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.WIDTH, 3).Value = obj.WIDTH;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.PROPERTY, 253).Value = obj.PROPERTY;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATGROUP, 253).Value = obj.SEATGROUP;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.CAPACITY, 3).Value = obj.CAPACITY;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATINGCHARTID, 253).Value = obj.SEATINGCHARTID;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.BLOCKID, 253).Value = obj.BLOCKID;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATTYPE, 253).Value = obj.SEATTYPE;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		private void SetAttParams_UpdateType(MySqlCommand cmd, SeatPo obj)
		{
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATGROUP, 253).Value = obj.SEATGROUP;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.SEATTYPE, 253).Value = obj.SEATTYPE;
			cmd.Parameters.AddWithValue(SeatDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, SeatPo obj)
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
		public bool Insert(SeatPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, SeatPo obj)
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
		public bool Update(SeatPo obj)
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
		public bool UpdateType(SeatPo obj)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = string.Concat(new string[]
			{
				"UPDATE ",
				this.TABLE_NAME,
				" SET ",
				this.SQL_UPDATETYPE_FIELD,
				this.SQL_WHERE_KEYS
			});
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			this.SetKeyParams(mySqlCommand, obj);
			this.SetAttParams_UpdateType(mySqlCommand, obj);
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
		public bool UpdateBlock(string szSeatId, string szBlockId)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = "UPDATE Seat SET BlockId = '{0}' WHERE Seatid = '{1}'";
			text = string.Format(text, szBlockId, szSeatId);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
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
		public bool UpdateBlockWithNew(MySqlConnection conn, MySqlTransaction trans, string szBlockIdOld, string szBlockIdNew)
		{
			string text = "UPDATE Seat SET BlockId = '{0}' WHERE BlockId = '{1}'";
			text = string.Format(text, szBlockIdNew, szBlockIdOld);
			MySqlCommand mySqlCommand = new MySqlCommand(text, conn, trans);
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, SeatPo obj)
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
		public bool Delete(SeatPo obj)
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
		public bool DeleteBySeatingChartId(string szSeatingChartId)
		{
			string text = " DELETE FROM Seat WHERE SeatingChartId = '{0}'";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
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
			string text = "select * from Seat ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seat");
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
		public DataTable RetrieveALLItemsWithBlock(string szSeatingChartId)
		{
			string text = "SELECT s.*,b.BgColour\r\nFROM Seat s\r\ninner join block b on b.BlockId = s.BlockId\r\nWHERE s.SeatingChartId = '{0}' \r\norder by ROWNumber,ColumnNumber,SeatGroup";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seat");
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
		public DataTable RetrieveALLItems(string szSeatingChartId)
		{
			string text = "SELECT * FROM Seat WHERE SeatingChartId = '{0}' order by ROWNumber,ColumnNumber,SeatGroup";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seat");
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
		public DataTable RetrieveALLItems(string szSeatingChartId, string szBlockId)
		{
			string text = "SELECT * FROM Seat WHERE SeatingChartId = '{0}' AND BlockId = '{1}' order by ROWNumber,ColumnNumber,SeatGroup";
			text = string.Format(text, szSeatingChartId, szBlockId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seat");
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
		public int GetSeatsByHallId(string szHallId)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			string text = "SELECT COUNT(*)  FROM Seat s\r\ninner join SeatingChart sc on sc.SeatingChartId = s.SeatingChartId\r\nWHERE sc.HallId = '{0}' ";
			text = string.Format(text, szHallId);
			DBOHelper.OpenConnection(connection);
			int result;
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				mySqlCommand.CommandText = text;
				mySqlCommand.Connection = connection;
				object obj = mySqlCommand.ExecuteScalar();
				int num;
				if (obj == DBNull.Value || obj == null)
				{
					num = 0;
				}
				else
				{
					num = Convert.ToInt32(obj);
				}
				result = num;
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

using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class SeatstatusDbo
	{
		public class CmdParam
		{
			public static string SEATSTATUSID = "@SEATSTATUSID";
			public static string SEATID = "@SEATID";
			public static string SHOWPLANID = "@SHOWPLANID";
			public static string TICKETINGSTATE = "@TICKETINGSTATE";
			public static string LOCKEDBY = "@LOCKEDBY";
			public static string SOLDBY = "@SOLDBY";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "Seatstatus";
		private string SQL_SELECT_COLUMNS = " SEATSTATUSID,SEATID,SHOWPLANID,TICKETINGSTATE,LOCKEDBY,SOLDBY,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " SEATSTATUSID,SEATID,SHOWPLANID,TICKETINGSTATE,LOCKEDBY,SOLDBY,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @SEATSTATUSID,@SEATID,@SHOWPLANID,@TICKETINGSTATE,@LOCKEDBY,@SOLDBY,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " SEATID=@SEATID,SHOWPLANID=@SHOWPLANID,TICKETINGSTATE=@TICKETINGSTATE,LOCKEDBY=@LOCKEDBY,SOLDBY=@SOLDBY,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_WHERE_KEYS = " WHERE SEATSTATUSID=@SEATSTATUSID ";
		private void SetKeyParams(MySqlCommand cmd, SeatstatusPo obj)
		{
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.SEATSTATUSID, 253).Value = obj.SEATSTATUSID;
		}
		private void SetAttParams(MySqlCommand cmd, SeatstatusPo obj)
		{
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.SEATID, 253).Value = obj.SEATID;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.SHOWPLANID, 15).Value = obj.SHOWPLANID;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.TICKETINGSTATE, 3).Value = obj.TICKETINGSTATE;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.LOCKEDBY, 3).Value = obj.LOCKEDBY;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.SOLDBY, 3).Value = obj.SOLDBY;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(SeatstatusDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, SeatstatusPo obj)
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
		public bool Insert(SeatstatusPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, SeatstatusPo obj)
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
		public bool Update(SeatstatusPo obj)
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, SeatstatusPo obj)
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
		public bool Delete(SeatstatusPo obj)
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
			string text = "select * from Seatstatus ";
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
		public DataTable RetrieveALLItems(string szShowPlanId)
		{
			string text = "SELECT * FROM Seatstatus WHERE ShowPlanId = '{0}' ";
			text = string.Format(text, szShowPlanId);
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
		public DataTable RetrieveItemStatus_Init_BySeatingChartId(string szSeatingChartId)
		{
			string text = "select sp.showplanId,\r\ns.SeatId,s.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup,\r\nss.SeatStatusId,ss.TicketingState,ss.LockedBy,ss.SoldBy,ss.Created,ss.Updated,ss.ActiveFlag\r\nfrom showplan sp\r\nleft outer join seatingChart sc on sp.Hallid = sc.Hallid \r\nleft outer join seat s on s.seatingChartid = sc.seatingChartid\r\nleft outer join seatstatus ss on ss.seatid = s.seatid\r\nwhere sc.SeatingChartId = '{0}' order by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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
		public DataTable RetrieveItemStatus_InitWithBlock(string szShowPlanId, string szSeatingChartId)
		{
			string text = "select sp.showplanId,\r\ns.SeatId,s.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup,\r\nss.SeatStatusId,ss.TicketingState,ss.LockedBy,ss.SoldBy,ss.Created,ss.Updated,ss.ActiveFlag,b.BgColour\r\nfrom showplan sp\r\nleft outer join seatingChart sc on sp.Hallid = sc.Hallid \r\nleft outer join seat s on s.seatingChartid = sc.seatingChartid\r\nleft outer join block b on b.BlockId = s.BlockId\r\nleft outer join seatstatus ss on ss.seatid = s.seatid and ss.ShowPlanId = sp.showplanId\r\nwhere sp.showplanId = '{0}' and s.seatingChartid = '{1}' \r\norder by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, szShowPlanId, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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
		public DataTable RetrieveItemStatus_Init(string szShowPlanId, string szSeatingChartId)
		{
			string text = "select sp.showplanId,\r\ns.SeatId,s.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup,\r\nss.SeatStatusId,ss.TicketingState,ss.LockedBy,ss.SoldBy,ss.Created,ss.Updated,ss.ActiveFlag\r\nfrom showplan sp\r\nleft outer join seatingChart sc on sp.Hallid = sc.Hallid \r\nleft outer join seat s on s.seatingChartid = sc.seatingChartid\r\nleft outer join seatstatus ss on ss.seatid = s.seatid and ss.ShowPlanId = sp.showplanId\r\nwhere sp.showplanId = '{0}' and s.seatingChartid = '{1}' \r\norder by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, szShowPlanId, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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
		public DataTable RetrieveItemStatus_Init(string szShowPlanId, string szHallId, int nLevel)
		{
			string text = "select sp.showplanId,\r\ns.SeatId,s.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup,\r\nss.SeatStatusId,ss.TicketingState,ss.LockedBy,ss.SoldBy,ss.Created,ss.Updated,ss.ActiveFlag\r\nfrom showplan sp\r\nleft outer join seatingChart sc on sp.Hallid = sc.Hallid \r\nleft outer join seat s on s.seatingChartid = sc.seatingChartid\r\nleft outer join seatstatus ss on ss.seatid = s.seatid and ss.ShowPlanId = sp.showplanId\r\nwhere sp.showplanId = '{0}' and sc.Hallid = '{1}' and sc.Level = {2} order by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, szShowPlanId, szHallId, nLevel);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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
		public DataTable RetrieveItemStatus(string szShowPlanId, string szHallId, int nLevel, string szSeatingChartId)
		{
			string text = "select ss.*,\r\ns.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup\r\nfrom seatstatus ss\r\ninner join showplan sp on sp.showplanId = ss.showplanId\r\ninner join seatingChart sc on sc.Hallid = sp.Hallid \r\ninner join seat s on s.SeatId = ss.SeatId \r\nwhere sp.showplanId = '{0}' and sc.Hallid = '{1}' and sc.Level = {2} and s.seatingChart = '{3}' \r\norder by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, new object[]
			{
				szShowPlanId,
				szHallId,
				nLevel,
				szSeatingChartId
			});
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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
		public DataTable RetrieveItemStatus(string szShowPlanId, string szSeatingChartId)
		{
			string text = "select ss.*,\r\ns.RowNumber,s.ColumnNumber,s.SeatNumber,s.Xaxis,s.Yaxis,s.Height,s.Width,s.Property,s.SeatGroup,s.Capacity,s.SeatingChartId,s.BlockId,s.SeatType,s.SeatGroup\r\nfrom seatstatus ss\r\ninner join showplan sp on sp.showplanId = ss.showplanId\r\ninner join seatingChart sc on sc.Hallid = sp.Hallid \r\ninner join seat s on s.SeatId = ss.SeatId \r\nwhere sp.showplanId = '{0}' and s.seatingChartId = '{1}' \r\norder by s.ROWNumber,s.ColumnNumber,s.SeatGroup";
			text = string.Format(text, szShowPlanId, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("seatstatus");
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

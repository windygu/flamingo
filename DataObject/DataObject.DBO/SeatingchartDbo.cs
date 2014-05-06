using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class SeatingchartDbo
	{
		public class CmdParam
		{
			public static string SEATINGCHARTID = "@SEATINGCHARTID";
			public static string SEATINGCHARTNAME = "@SEATINGCHARTNAME";
			public static string LEVEL = "@LEVEL";
			public static string SEATS = "@SEATS";
			public static string ROWS = "@ROWS";
			public static string COLUMNS = "@COLUMNS";
			public static string ROWSPACE = "@ROWSPACE";
			public static string COLUMNSPACE = "@COLUMNSPACE";
			public static string SHAPE = "@SHAPE";
			public static string BGCOLOUR = "@BGCOLOUR";
			public static string HALLID = "@HALLID";
			public static string ROTATION = "@ROTATION";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "Seatingchart";
		private string SQL_SELECT_COLUMNS = " SEATINGCHARTID,SEATINGCHARTNAME,LEVEL,SEATS,ROWS,COLUMNS,ROWSPACE,COLUMNSPACE,SHAPE,BGCOLOUR,HALLID,ROTATION,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " SEATINGCHARTID,SEATINGCHARTNAME,LEVEL,SEATS,ROWS,COLUMNS,ROWSPACE,COLUMNSPACE,SHAPE,BGCOLOUR,HALLID,ROTATION,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @SEATINGCHARTID,@SEATINGCHARTNAME,@LEVEL,@SEATS,@ROWS,@COLUMNS,@ROWSPACE,@COLUMNSPACE,@SHAPE,@BGCOLOUR,@HALLID,@ROTATION,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " SEATINGCHARTNAME=@SEATINGCHARTNAME,LEVEL=@LEVEL,SEATS=@SEATS,ROWS=@ROWS,ROWSPACE=@ROWSPACE,COLUMNS=@COLUMNS,COLUMNSPACE=@COLUMNSPACE,SHAPE=@SHAPE,BGCOLOUR=@BGCOLOUR,HALLID=@HALLID,ROTATION=@ROTATION,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_WHERE_KEYS = " WHERE SEATINGCHARTID=@SEATINGCHARTID ";
		private void SetKeyParams(MySqlCommand cmd, SeatingchartPo obj)
		{
            cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.SEATINGCHARTID, 253).Value = obj.SEATINGCHARTID;
		}
		private void SetAttParams(MySqlCommand cmd, SeatingchartPo obj)
		{
            cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.SEATINGCHARTNAME, 253).Value = obj.SEATINGCHARTNAME;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.LEVEL, 3).Value = obj.LEVEL;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.SEATS, 503).Value = obj.SEATS;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.ROWS, 503).Value = obj.ROWS;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.COLUMNS, 503).Value = obj.COLUMNS;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.ROWSPACE, 503).Value = obj.ROWSPACE;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.COLUMNSPACE, 503).Value = obj.COLUMNSPACE;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.SHAPE, 253).Value = (string.IsNullOrEmpty(obj.SHAPE) ? null : obj.SHAPE);
            cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.BGCOLOUR, 253).Value = (string.IsNullOrEmpty(obj.BGCOLOUR) ? null : obj.BGCOLOUR);
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.HALLID, 253).Value = obj.HALLID;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.ROTATION, 503).Value = obj.ROTATION;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(SeatingchartDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, SeatingchartPo obj)
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
		public bool Insert(SeatingchartPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, SeatingchartPo obj)
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
		public bool Update(SeatingchartPo obj)
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
		public bool UpdateThumbnail(string szSeatingchartId, byte[] byteThumbnail)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = "UPDATE Seatingchart SET Thumbnail = @Thumbnail WHERE SeatingchartId = '{0}'";
			text = string.Format(text, szSeatingchartId);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			mySqlCommand.Parameters.AddWithValue("@Thumbnail", 251).Value = byteThumbnail;
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
		public bool UpdateActiveFlag(string szSeatingchartId, int nActiveFlag)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string text = "UPDATE Seatingchart SET ActiveFlag = @ActiveFlag WHERE SeatingchartId = '{0}'";
			text = string.Format(text, szSeatingchartId);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			mySqlCommand.Parameters.AddWithValue("@ActiveFlag", 3).Value = nActiveFlag;
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, SeatingchartPo obj)
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
		public bool Delete(SeatingchartPo obj)
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
			string text = "select * from Seatingchart ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Block");
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
		public DataTable RetrieveALLItemsBySeatingchartId(string szSeatingchartId)
		{
			string text = "SELECT * FROM Seatingchart WHERE SeatingchartId = '{0}' ";
			text = string.Format(text, szSeatingchartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seatingchart");
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
		public DataTable RetrieveALLItems(string szHallId)
		{
			string text = "SELECT * FROM Seatingchart WHERE ActiveFlag = 1 AND HallId = '{0}' order by Level,SeatingChartId ";
			text = string.Format(text, szHallId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seatingchart");
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
		public DataTable RetrieveALLItems(string szHallId, int nLevel)
		{
			string text = "SELECT * FROM Seatingchart WHERE ActiveFlag = 1 AND HallId = '{0}' AND Level = {1}";
			text = string.Format(text, szHallId, nLevel);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seatingchart");
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
		public bool InsertWithBlock(SeatingchartPo scPo, BlockPo blPo)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlTransaction mySqlTransaction = connection.BeginTransaction();
			bool result;
			try
			{
				bool flag = this.Insert(connection, mySqlTransaction, scPo);
				if (flag)
				{
					flag = new BlockDbo().Insert(connection, mySqlTransaction, blPo);
				}
				if (flag)
				{
					DBOHelper.CommitTransaction(mySqlTransaction);
				}
				else
				{
					DBOHelper.RollBackTransction(mySqlTransaction);
				}
				result = flag;
			}
			catch (MySqlException ex)
			{
				DBOHelper.RollBackTransction(mySqlTransaction);
				throw ex;
			}
			catch (Exception ex2)
			{
				DBOHelper.RollBackTransction(mySqlTransaction);
				throw ex2;
			}
			finally
			{
				DBOHelper.CloseConnection(connection);
			}
			return result;
		}
		public DataTable RetrieveLevelItems(string szTheaterId, string szHallId)
		{
			string text = "SELECT DISTINCT HallId,Level FROM SeatingChart WHERE ActiveFlag = 1 and HallId = '{0}' ";
			text = string.Format(text, szHallId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("SeatingChart");
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
		public DataTable RetrieveSeatingChartItems(string szTheaterId, string szHallId, int nLevel)
		{
			string text = "SELECT DISTINCT SeatingChartId,HallId,Level FROM SeatingChart WHERE ActiveFlag = 1 and HallId = '{0}' and Level = {1} ";
			text = string.Format(text, szHallId, nLevel);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("SeatingChart");
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
		public DataTable GetSeatingChart(string szSeatingChartName)
		{
			string text = "SELECT * FROM Seatingchart WHERE ActiveFlag = 1 AND SeatingChartName = '{0}' ";
			text = string.Format(text, szSeatingChartName);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("Seatingchart");
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
		public bool CheckExistByName(string szSeatingChartName)
		{
			string text = "SELECT SeatingChartId FROM seatingchart where ActiveFlag = 1 and SeatingChartName = '{0}'";
			text = string.Format(text, szSeatingChartName);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 300;
            mySqlCommand.Connection = connection;
			bool result;
			try
			{
				object obj = mySqlCommand.ExecuteScalar();
				if (obj == DBNull.Value || obj == null)
				{
					result = false;
				}
				else
				{
					result = true;
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
		public bool CheckExistByIdHaveUsed(string szSeatingChartId)
		{
			string text = "SELECT count(*) FROM seatstatus ss\r\ninner join Seat st on st.SeatId = ss.SeatId\r\ninner join seatingchart sc on sc.SeatingChartId = st.SeatingChartId\r\nwhere sc.SeatingChartId = '{0}' ";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 300;
            mySqlCommand.Connection = connection;
			bool result;
			try
			{
				object obj = mySqlCommand.ExecuteScalar();
				if (obj == DBNull.Value || obj == null)
				{
					result = false;
				}
				else
				{
					result = (Convert.ToInt32(obj) > 0);
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
		public bool CheckExistByNameWillUsed(string szSeatingChartName, DateTime dtStartTime)
		{
			string text = "SELECT count(*) FROM showplan sp\r\ninner join seatstatus ss on ss.ShowPlanId = sp.ShowPlanId\r\ninner join Seat st on st.SeatId = ss.SeatId\r\ninner join seatingchart sc on sc.SeatingChartId = st.SeatingChartId\r\nwhere sc.ActiveFlag = 1 and sc.SeatingChartName = '{0}' and sp.StartTime >= '{1}' ";
			text = string.Format(text, szSeatingChartName, dtStartTime);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 300;
            mySqlCommand.Connection = connection;
			bool result;
			try
			{
				object obj = mySqlCommand.ExecuteScalar();
				if (obj == DBNull.Value || obj == null)
				{
					result = false;
				}
				else
				{
					result = (Convert.ToInt32(obj) > 0);
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
		public string BuildId(string szHallId, int nLevel)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string result;
			try
			{
				object idValue = this.GetIdValue(connection, szHallId, nLevel);
				string text = szHallId + nLevel.ToString() + "1";
				if (idValue == DBNull.Value || idValue == null)
				{
					result = text;
				}
				else
				{
					text = idValue.ToString();
					text = text.Replace(szHallId + nLevel.ToString(), "");
					if (text.Trim().Length <= 0)
					{
						text = "1";
					}
					else
					{
						text = (Convert.ToInt32(text.Trim()) + 1).ToString();
					}
					text = szHallId + nLevel.ToString() + text;
					result = text;
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
		private object GetIdValue(MySqlConnection conn, string szHallId, int nLevel)
		{
			string text = "SELECT Max(SeatingChartId) FROM seatingchart where HallId = '{0}' and Level = {1}";
			text = string.Format(text, szHallId, nLevel);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 3000;
			mySqlCommand.Connection = conn;
			return mySqlCommand.ExecuteScalar();
		}
		public byte[] GetThumbnailValue(string szSeatingchartId)
		{
			string text = "SELECT Thumbnail FROM seatingchart where SeatingchartId = '{0}' ";
			text = string.Format(text, szSeatingchartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			byte[] result;
			try
			{
				byte[] array = (byte[])mySqlCommand.ExecuteScalar();
				result = array;
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

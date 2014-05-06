using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class BlockDbo
	{
		public class CmdParam
		{
			public static string BLOCKID = "@BLOCKID";
			public static string BLOCKNAME = "@BLOCKNAME";
			public static string BGCOLOUR = "@BGCOLOUR";
			public static string SEATS = "@SEATS";
			public static string SEATINGCHARTID = "@SEATINGCHARTID";
			public static string HASBLOCKPRICE = "@HASBLOCKPRICE";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "Block";
		private string SQL_SELECT_COLUMNS = " BLOCKID,BLOCKNAME,BGCOLOUR,SEATS,SEATINGCHARTID,HASBLOCKPRICE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " BLOCKID,BLOCKNAME,BGCOLOUR,SEATS,SEATINGCHARTID,HASBLOCKPRICE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @BLOCKID,@BLOCKNAME,@BGCOLOUR,@SEATS,@SEATINGCHARTID,@HASBLOCKPRICE,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " BLOCKNAME=@BLOCKNAME,BGCOLOUR=@BGCOLOUR,SEATS=@SEATS,SEATINGCHARTID=@SEATINGCHARTID,HASBLOCKPRICE=@HASBLOCKPRICE,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_WHERE_KEYS = " WHERE BLOCKID=@BLOCKID ";
		private void SetKeyParams(MySqlCommand cmd, BlockPo obj)
		{
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.BLOCKID, 253).Value = obj.BLOCKID;
		}
		private void SetAttParams(MySqlCommand cmd, BlockPo obj)
		{
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.BLOCKNAME, 253).Value = obj.BLOCKNAME;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.BGCOLOUR, 3).Value = obj.BGCOLOUR;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.SEATS, 503).Value = obj.SEATS;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.HASBLOCKPRICE, 3).Value = obj.HASBLOCKPRICE;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.SEATINGCHARTID, 253).Value = obj.SEATINGCHARTID;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(BlockDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, BlockPo obj)
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
		public bool Insert(BlockPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, BlockPo obj)
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
		public bool Update(BlockPo obj)
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, BlockPo obj)
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
		public bool Delete(BlockPo obj)
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
		public bool DeleteAll(BlockPo obj, string szBlockIdNew)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlTransaction mySqlTransaction = connection.BeginTransaction();
			bool result;
			try
			{
				SeatDbo seatDbo = new SeatDbo();
				BlockPriceDbo blockPriceDbo = new BlockPriceDbo();
				bool flag = true;
				seatDbo.UpdateBlockWithNew(connection, mySqlTransaction, obj.BLOCKID, szBlockIdNew);
				blockPriceDbo.DeleteAllByBlockId(connection, mySqlTransaction, obj.BLOCKID);
				if (flag)
				{
					flag = this.Delete(connection, mySqlTransaction, obj);
				}
				if (flag)
				{
					mySqlTransaction.Commit();
				}
				else
				{
					mySqlTransaction.Rollback();
				}
				result = flag;
			}
			catch (MySqlException ex)
			{
				mySqlTransaction.Rollback();
				throw ex;
			}
			catch (Exception ex2)
			{
				mySqlTransaction.Rollback();
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
			string text = "select * from Block ";
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
		public DataTable RetrieveALLItems(string szSeatingChartId)
		{
			string text = "SELECT * FROM Block WHERE SeatingChartId = '{0}' ";
			text = string.Format(text, szSeatingChartId);
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
		public DataTable RetrieveALLItems_Ext(string szSeatingChartId, string szShowPlanId)
		{
			string text = "SELECT b.* ,\r\nbp.BlockPriceId,bp.ShowPlanId,bp.SinglePrice,bp.DoublePrice,bp.BoxPrice,bp.StudentPrice,bp.GroupPrice,bp.MemberPrice,bp.DiscountPrice \r\nFROM Block b\r\nLEFT OUTER JOIN BlockPrice bp ON bp.BlockId = b.BlockId AND bp.ShowPlanId = '{0}'\r\n            WHERE b.SeatingChartId = '{1}' ";
			text = string.Format(text, szShowPlanId, szSeatingChartId);
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
		public DataTable RetrieveALLItems(string szSeatingChartId, string szBlockName)
		{
			string text = "SELECT * FROM Block WHERE SeatingChartId = '{0}' and BlockName = '{1}'";
			text = string.Format(text, szSeatingChartId, szBlockName);
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
		public string GetDefaultBlock(string szSeatingChartId)
		{
			string text = "SELECT BlockId FROM Block WHERE SeatingChartId = '{0}' and BlockName = '默认'";
			text = string.Format(text, szSeatingChartId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 3000;
            mySqlCommand.Connection = connection;
			string result;
			try
			{
				object obj = mySqlCommand.ExecuteScalar();
				if (obj == DBNull.Value || obj == null)
				{
					result = "";
				}
				else
				{
					result = obj.ToString();
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
		public string BuildId(string szSeatingChartId)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string result;
			try
			{
				object idValue = this.GetIdValue(connection, szSeatingChartId);
				string text = szSeatingChartId + "1";
				if (idValue == DBNull.Value || idValue == null)
				{
					result = text;
				}
				else
				{
					text = idValue.ToString();
					text = text.Replace(szSeatingChartId, "");
					if (text.Trim().Length <= 0)
					{
						text = "1";
					}
					else
					{
						text = (Convert.ToInt32(text.Trim()) + 1).ToString();
					}
					text = szSeatingChartId + text;
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
		private object GetIdValue(MySqlConnection conn, string szSeatingChartId)
		{
			string text = "SELECT Max(BlockId) FROM Block where SeatingChartId = '{0}'";
			text = string.Format(text, szSeatingChartId);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 3000;
            mySqlCommand.Connection = conn;
			return mySqlCommand.ExecuteScalar();
		}
	}
}

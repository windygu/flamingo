using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class BlockPriceDbo
	{
		public class CmdParam
		{
			public static string BLOCKPRICEID = "@BLOCKPRICEID";
			public static string BLOCKID = "@BLOCKID";
			public static string SHOWPLANID = "@SHOWPLANID";
			public static string SINGLEPRICE = "@SINGLEPRICE";
			public static string DOUBLEPRICE = "@DOUBLEPRICE";
			public static string BOXPRICE = "@BOXPRICE";
			public static string STUDENTPRICE = "@STUDENTPRICE";
			public static string GROUPPRICE = "@GROUPPRICE";
			public static string MEMBERPRICE = "@MEMBERPRICE";
			public static string DISCOUNTPRICE = "@DISCOUNTPRICE";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "blockprice";
		private string SQL_SELECT_COLUMNS = " BLOCKPRICEID,BLOCKID,SHOWPLANID,SINGLEPRICE,DOUBLEPRICE,BOXPRICE,STUDENTPRICE,GROUPPRICE,MEMBERPRICE,DISCOUNTPRICE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " BLOCKPRICEID,BLOCKID,SHOWPLANID,SINGLEPRICE,DOUBLEPRICE,BOXPRICE,STUDENTPRICE,GROUPPRICE,MEMBERPRICE,DISCOUNTPRICE,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @BLOCKPRICEID,@BLOCKID,@SHOWPLANID,@SINGLEPRICE,@DOUBLEPRICE,@BOXPRICE,@STUDENTPRICE,@GROUPPRICE,@MEMBERPRICE,@DISCOUNTPRICE,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " BLOCKID=@BLOCKID,SHOWPLANID=@SHOWPLANID,SINGLEPRICE=@SINGLEPRICE,DOUBLEPRICE=@DOUBLEPRICE,BOXPRICE=@BOXPRICE,STUDENTPRICE=@STUDENTPRICE,GROUPPRICE=@GROUPPRICE,MEMBERPRICE=@MEMBERPRICE,DISCOUNTPRICE=@DISCOUNTPRICE,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_WHERE_KEYS = " WHERE BLOCKPRICEID=@BLOCKPRICEID ";
		private void SetKeyParams(MySqlCommand cmd, BlockPricePo obj)
		{
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.BLOCKPRICEID, 253).Value = obj.BLOCKPRICEID;
		}
		private void SetAttParams(MySqlCommand cmd, BlockPricePo obj)
		{
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.BLOCKID, 253).Value = obj.BLOCKID;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.SHOWPLANID, 253).Value = obj.SHOWPLANID;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.SINGLEPRICE, 4).Value = obj.SINGLEPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.DOUBLEPRICE, 4).Value = obj.DOUBLEPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.BOXPRICE, 4).Value = obj.BOXPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.STUDENTPRICE, 4).Value = obj.STUDENTPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.GROUPPRICE, 4).Value = obj.GROUPPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.MEMBERPRICE, 4).Value = obj.MEMBERPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.DISCOUNTPRICE, 4).Value = obj.DISCOUNTPRICE;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(BlockPriceDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, BlockPricePo obj)
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
		public bool Insert(BlockPricePo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, BlockPricePo obj)
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
		public bool Update(BlockPricePo obj)
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
		public bool DeleteAllByBlockId(MySqlConnection conn, MySqlTransaction trans, string szBlockId)
		{
			string text = " DELETE FROM blockprice WHERE BlockId = '{0}'";
			text = string.Format(text, szBlockId);
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, BlockPricePo obj)
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
		public bool Delete(BlockPricePo obj)
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
			string text = "select * from blockprice ";
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
		public DataTable RetrieveALLItems(string szShowPlanId)
		{
			string text = "SELECT * FROM blockprice WHERE ShowPlanId = '{0}' ";
			text = string.Format(text, szShowPlanId);
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
		public DataTable RetrieveALLItems(string szShowPlanId, string szBlockId)
		{
			string text = "SELECT * FROM blockprice WHERE ShowPlanId = '{0}' and BlockId = '{1}'";
			text = string.Format(text, szShowPlanId, szBlockId);
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
		public int BuildId()
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			int result;
			try
			{
				object idValue = this.GetIdValue(connection);
				int num;
				if (idValue == DBNull.Value || idValue == null)
				{
					num = 1;
				}
				else
				{
					num = Convert.ToInt32(idValue) + 1;
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
		private object GetIdValue(MySqlConnection conn)
		{
			string commandText = "SELECT Max(blockpriceId) FROM Blockprice ";
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = commandText;
			mySqlCommand.CommandTimeout = 3000;
            mySqlCommand.Connection = conn;
			return mySqlCommand.ExecuteScalar();
		}
	}
}

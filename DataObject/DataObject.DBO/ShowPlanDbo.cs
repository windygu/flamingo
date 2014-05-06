using DataObject.App_UTIL;
using DataObject.PO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace DataObject.DBO
{
	public class ShowPlanDbo
	{
		public class CmdParam
		{
			public static string SHOWPLANID = "@SHOWPLANID";
			public static string SHOWPLANNAME = "@SHOWPLANNAME";
			public static string FILMID = "@FILMID";
			public static string FILM_FILMMODEID = "@FILM_FILMMODEID";
			public static string POSITION = "@POSITION";
			public static string STARTTIME = "@STARTTIME";
			public static string ENDTTIME = "@ENDTTIME";
			public static string FILMLENGTH = "@FILMLENGTH";
			public static string HALLID = "@HALLID";
			public static string DAILYPLANID = "@DAILYPLANID";
			public static string TIMESPAN = "@TIMESPAN";
			public static string RATIO = "@RATIO";
			public static string LOWESTPRICE = "@LOWESTPRICE";
			public static string FARESETTINGID = "@FARESETTINGID";
			public static string SINGLEPRICE = "@SINGLEPRICE";
			public static string DOUBLEPRICE = "@DOUBLEPRICE";
			public static string BOXPRICE = "@BOXPRICE";
			public static string STUDENTPRICE = "@STUDENTPRICE";
			public static string GROUPPRICE = "@GROUPPRICE";
			public static string MEMBERPRICE = "@MEMBERPRICE";
			public static string DISCOUNTPRICE = "@DISCOUNTPRICE";
			public static string SHOWSTATUS = "@SHOWSTATUS";
			public static string SHOWTYPEID = "@SHOWTYPEID";
			public static string SHOWGROUP = "@SHOWGROUP";
			public static string ISDISCOUNTED = "@ISDISCOUNTED";
			public static string ISCHECKINGNUMBER = "@ISCHECKINGNUMBER";
			public static string ISTICKETCHECKING = "@ISTICKETCHECKING";
			public static string ISONLINETICKETING = "@ISONLINETICKETING";
			public static string ISAPPROVED = "@ISAPPROVED";
			public static string ISSALABLE = "@ISSALABLE";
			public static string ISLOCKED = "@ISLOCKED";
			public static string STAGEHAND = "@STAGEHAND";
			public static string PROJECTIONIST = "@PROJECTIONIST";
			public static string CREATED = "@CREATED";
			public static string UPDATED = "@UPDATED";
			public static string ACTIVEFLAG = "@ACTIVEFLAG";
		}
		private string TABLE_NAME = "ShowPlan";
		private string SQL_SELECT_COLUMNS = " SHOWPLANID,SHOWPLANNAME,FILMID,FILM_FILMMODEID,POSITION,\r\nSTARTTIME,ENDTTIME,FILMLENGTH,HALLID,DAILYPLANID,TIMESPAN,RATIO,LOWESTPRICE,FARESETTINGID,\r\nSINGLEPRICE,DOUBLEPRICE,BOXPRICE,STUDENTPRICE,GROUPPRICE,MEMBERPRICE,DISCOUNTPRICE,\r\nSHOWSTATUS,SHOWTYPEID,SHOWGROUP,ISDISCOUNTED,ISCHECKINGNUMBER,ISTICKETCHECKING,ISONLINETICKETING,ISAPPROVED,ISSALABLE,ISLOCKED,STAGEHAND,PROJECTIONIST,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_COLUMNS = " SHOWPLANID,SHOWPLANNAME,FILMID,FILM_FILMMODEID,POSITION,\r\nSTARTTIME,ENDTTIME,FILMLENGTH,HALLID,DAILYPLANID,TIMESPAN,RATIO,LOWESTPRICE,FARESETTINGID,\r\nSINGLEPRICE,DOUBLEPRICE,BOXPRICE,STUDENTPRICE,GROUPPRICE,MEMBERPRICE,DISCOUNTPRICE,\r\nSHOWSTATUS,SHOWTYPEID,SHOWGROUP,ISDISCOUNTED,ISCHECKINGNUMBER,ISTICKETCHECKING,ISONLINETICKETING,ISAPPROVED,ISSALABLE,ISLOCKED,STAGEHAND,PROJECTIONIST,CREATED,UPDATED,ACTIVEFLAG ";
		private string SQL_INSERT_VALUES = " @SHOWPLANID,@SHOWPLANNAME,@FILMID,@FILM_FILMMODEID,@POSITION,\r\n@STARTTIME,@ENDTTIME,@FILMLENGTH,@HALLID,@DAILYPLANID,@TIMESPAN,@RATIO,@LOWESTPRICE,@FARESETTINGID,\r\n@SINGLEPRICE,@DOUBLEPRICE,@BOXPRICE,@STUDENTPRICE,@GROUPPRICE,@MEMBERPRICE,@DISCOUNTPRICE,\r\n@SHOWSTATUS,@SHOWTYPEID,@SHOWGROUP,@ISDISCOUNTED,@ISCHECKINGNUMBER,@ISTICKETCHECKING,@ISONLINETICKETING,@ISAPPROVED,@ISSALABLE,@ISLOCKED,@STAGEHAND,@PROJECTIONIST,@CREATED,@UPDATED,@ACTIVEFLAG ";
		private string SQL_UPDATE_FIELD = " SHOWPLANID=@SHOWPLANID,SHOWPLANNAME=@SHOWPLANNAME,FILMID=@FILMID,FILM_FILMMODEID=@FILM_FILMMODEID,POSITION=@POSITION,\r\nSTARTTIME=@STARTTIME,ENDTTIME=@ENDTTIME,FILMLENGTH=@FILMLENGTH,HALLID=@HALLID,DAILYPLANID=@DAILYPLANID,TIMESPAN=@TIMESPAN,RATIO=@RATIO,LOWESTPRICE=@LOWESTPRICE,FARESETTINGID=@FARESETTINGID,\r\nSINGLEPRICE=@SINGLEPRICE,DOUBLEPRICE=@DOUBLEPRICE,BOXPRICE=@BOXPRICE,STUDENTPRICE=@STUDENTPRICE,GROUPPRICE=@GROUPPRICE,MEMBERPRICE=@MEMBERPRICE,DISCOUNTPRICE=@DISCOUNTPRICE,\r\nSHOWSTATUS=@SHOWSTATUS,SHOWTYPEID=@SHOWTYPEID,SHOWGROUP=@SHOWGROUP,ISDISCOUNTED=@ISDISCOUNTED,ISCHECKINGNUMBER=@ISCHECKINGNUMBER,ISTICKETCHECKING=@ISTICKETCHECKING,ISONLINETICKETING=@ISONLINETICKETING,ISAPPROVED=@ISAPPROVED,ISSALABLE=@ISSALABLE,ISLOCKED=@ISLOCKED,STAGEHAND=@STAGEHAND,PROJECTIONIST=@PROJECTIONIST,CREATED=@CREATED,UPDATED=@UPDATED,ACTIVEFLAG=@ACTIVEFLAG ";
		private string SQL_WHERE_KEYS = " WHERE SHOWPLANID=@SHOWPLANID ";
		private void SetKeyParams(MySqlCommand cmd, ShowPlanPo obj)
		{
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SHOWPLANID, 253).Value = obj.SHOWPLANID;
		}
		private void SetAttParams(MySqlCommand cmd, ShowPlanPo obj)
		{
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SHOWPLANNAME, 253).Value = obj.SHOWPLANNAME;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.FILMID, 253).Value = obj.FILMID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.FILM_FILMMODEID, 3).Value = obj.FILM_FILMMODEID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.POSITION, 3).Value = obj.POSITION;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.STARTTIME, 12).Value = obj.STARTTIME;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ENDTTIME, 12).Value = obj.ENDTTIME;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.FILMLENGTH, 3).Value = obj.FILMLENGTH;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.HALLID, 253).Value = obj.HALLID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.DAILYPLANID, 253).Value = obj.DAILYPLANID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.TIMESPAN, 3).Value = obj.TIMESPAN;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.RATIO, 4).Value = obj.RATIO;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.LOWESTPRICE, 4).Value = obj.LOWESTPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.FARESETTINGID, 3).Value = obj.FARESETTINGID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SINGLEPRICE, 4).Value = obj.SINGLEPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.DOUBLEPRICE, 4).Value = obj.DOUBLEPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.BOXPRICE, 4).Value = obj.BOXPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.STUDENTPRICE, 4).Value = obj.STUDENTPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.GROUPPRICE, 4).Value = obj.GROUPPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.MEMBERPRICE, 4).Value = obj.MEMBERPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.DISCOUNTPRICE, 4).Value = obj.DISCOUNTPRICE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SHOWSTATUS, 502).Value = obj.SHOWSTATUS;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SHOWTYPEID, 502).Value = obj.SHOWTYPEID;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.SHOWGROUP, 502).Value = obj.SHOWGROUP;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISDISCOUNTED, 502).Value = obj.ISDISCOUNTED;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISCHECKINGNUMBER, 502).Value = obj.ISCHECKINGNUMBER;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISTICKETCHECKING, 502).Value = obj.ISTICKETCHECKING;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISONLINETICKETING, 502).Value = obj.ISONLINETICKETING;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISAPPROVED, 502).Value = obj.ISAPPROVED;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISSALABLE, 502).Value = obj.ISSALABLE;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ISLOCKED, 502).Value = obj.ISLOCKED;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.STAGEHAND, 502).Value = obj.STAGEHAND;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.PROJECTIONIST, 502).Value = obj.PROJECTIONIST;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.CREATED, 12).Value = obj.CREATED;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.UPDATED, 12).Value = obj.UPDATED;
			cmd.Parameters.AddWithValue(ShowPlanDbo.CmdParam.ACTIVEFLAG, 3).Value = obj.ACTIVEFLAG;
		}
		public bool Insert(MySqlConnection conn, MySqlTransaction trans, ShowPlanPo obj)
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
		public bool Insert(ShowPlanPo obj)
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
		public bool Update(MySqlConnection conn, MySqlTransaction trans, ShowPlanPo obj)
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
		public bool Update(ShowPlanPo obj)
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
		public bool Delete(MySqlConnection conn, MySqlTransaction trans, ShowPlanPo obj)
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
		public bool Delete(ShowPlanPo obj)
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
			string text = "select * from ShowPlan ";
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("ShowPlan");
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
			string text = "SELECT * FROM ShowPlan WHERE ShowPlanId = '{0}' ";
			text = string.Format(text, szShowPlanId);
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			MySqlCommand mySqlCommand = new MySqlCommand(text, connection);
			DataTable result;
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
				DataTable dataTable = new DataTable("ShowPlan");
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
		public DataTable RetrieveALLItems_Ext(string szShowPlanId)
		{
			string text = "SELECT sp.*,\r\nh.HallName,f.FilmCode,f.FilmName \r\nFROM ShowPlan sp\r\nINNER JOIN hall h ON h.HallId = sp.HallId\r\nINNER JOIN film f ON f.FilmId = sp.FilmId\r\nWHERE sp.ShowPlanId = '{0}'";
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
		public string BuildId(string szShowPlanId)
		{
			MySqlConnection connection = DBOHelper.GetConnection();
			DBOHelper.OpenConnection(connection);
			string result;
			try
			{
				object idValue = this.GetIdValue(connection, szShowPlanId);
				string text = szShowPlanId + "1";
				if (idValue == DBNull.Value || idValue == null)
				{
					result = text;
				}
				else
				{
					text = idValue.ToString();
					text = text.Replace(szShowPlanId, "");
					if (text.Trim().Length <= 0)
					{
						text = "1";
					}
					else
					{
						text = (Convert.ToInt32(text.Trim()) + 1).ToString();
					}
					text = szShowPlanId + text;
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
		private object GetIdValue(MySqlConnection conn, string szShowPlanId)
		{
			string text = "SELECT Max(ShowPlanId) FROM ShowPlan where ShowPlanId = '{0}'";
			text = string.Format(text, szShowPlanId);
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandText = text;
			mySqlCommand.CommandTimeout = 3000;
			mySqlCommand.Connection = conn;
			return mySqlCommand.ExecuteScalar();
		}
	}
}

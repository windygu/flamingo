using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Showtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Showtype
	{
		public Showtype()
		{}
		#region Model
		private int _showtypeid;
		private string _showtypename;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int ShowTypeId
		{
			set{ _showtypeid=value;}
			get{return _showtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShowTypeName
		{
			set{ _showtypename=value;}
			get{return _showtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Updated
		{
			set{ _updated=value;}
			get{return _updated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActiveFlag
		{
			set{ _activeflag=value;}
			get{return _activeflag;}
		}
		#endregion Model

	}
}


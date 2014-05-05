using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Theatertype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Theatertype
	{
		public Theatertype()
		{}
		#region Model
		private string _theatertypeid;
		private string _theatertypename;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string TheaterTypeId
		{
			set{ _theatertypeid=value;}
			get{return _theatertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheaterTypeName
		{
			set{ _theatertypename=value;}
			get{return _theatertypename;}
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


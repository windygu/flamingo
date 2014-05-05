using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Filmarea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Filmarea
	{
		public Filmarea()
		{}
		#region Model
		private string _filmareaid;
		private string _filmareaname;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string FilmAreaId
		{
			set{ _filmareaid=value;}
			get{return _filmareaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmAreaName
		{
			set{ _filmareaname=value;}
			get{return _filmareaname;}
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


using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Filmmode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Filmmode
	{
		public Filmmode()
		{}
		#region Model
		private int _filmmodeid;
		private string _filmmodename;
		private string _filmid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int FilmModeId
		{
			set{ _filmmodeid=value;}
			get{return _filmmodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmModeName
		{
			set{ _filmmodename=value;}
			get{return _filmmodename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmId
		{
			set{ _filmid=value;}
			get{return _filmid;}
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


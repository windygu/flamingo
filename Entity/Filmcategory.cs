using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Filmcategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Filmcategory
	{
		public Filmcategory()
		{}
		#region Model
		private string _filmcategoryid;
		private string _filmcategoryname;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string FilmCategoryId
		{
			set{ _filmcategoryid=value;}
			get{return _filmcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilmCategoryName
		{
			set{ _filmcategoryname=value;}
			get{return _filmcategoryname;}
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


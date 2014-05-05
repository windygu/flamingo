using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Authorization:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Authorization
	{
		public Authorization()
		{}
		#region Model
		private string _authorizationid;
		private string _theaterid;
		private string _featurefile;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string AuthorizationId
		{
			set{ _authorizationid=value;}
			get{return _authorizationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TheaterId
		{
			set{ _theaterid=value;}
			get{return _theaterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeatureFile
		{
			set{ _featurefile=value;}
			get{return _featurefile;}
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


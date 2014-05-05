using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Permission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Permission
	{
		public Permission()
		{}
		#region Model
		private int _permissionid;
		private string _permissionname;
		private string _module;
		private int? _isreadonly;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int PermissionId
		{
			set{ _permissionid=value;}
			get{return _permissionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PermissionName
		{
			set{ _permissionname=value;}
			get{return _permissionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Module
		{
			set{ _module=value;}
			get{return _module;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsReadOnly
		{
			set{ _isreadonly=value;}
			get{return _isreadonly;}
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


using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Uploadsetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Uploadsetting
	{
		public Uploadsetting()
		{}
		#region Model
		private int _uploadid;
		private string _theaterid;
		private string _targetname;
		private string _uploadmethod;
		private int? _isactive;
		private string _uploadaddr;
		private DateTime? _uploadtime;
		private string _emailaddr;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int UploadId
		{
			set{ _uploadid=value;}
			get{return _uploadid;}
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
		public string TargetName
		{
			set{ _targetname=value;}
			get{return _targetname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UploadMethod
		{
			set{ _uploadmethod=value;}
			get{return _uploadmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UploadAddr
		{
			set{ _uploadaddr=value;}
			get{return _uploadaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmailAddr
		{
			set{ _emailaddr=value;}
			get{return _emailaddr;}
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


using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Downloadsetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Downloadsetting
	{
		public Downloadsetting()
		{}
		#region Model
		private int _downloadid;
		private string _theaterid;
		private string _sourcename;
		private string _downloadmethod;
		private string _downloadaddr;
		private int? _port;
		private string _username;
		private string _password;
		private int? _isanonymallowed;
		private int? _isproxy;
		private string _proxyserver;
		private int? _proxyport;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int DownloadId
		{
			set{ _downloadid=value;}
			get{return _downloadid;}
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
		public string SourceName
		{
			set{ _sourcename=value;}
			get{return _sourcename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DownloadMethod
		{
			set{ _downloadmethod=value;}
			get{return _downloadmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DownloadAddr
		{
			set{ _downloadaddr=value;}
			get{return _downloadaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Port
		{
			set{ _port=value;}
			get{return _port;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsAnonymAllowed
		{
			set{ _isanonymallowed=value;}
			get{return _isanonymallowed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsProxy
		{
			set{ _isproxy=value;}
			get{return _isproxy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProxyServer
		{
			set{ _proxyserver=value;}
			get{return _proxyserver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProxyPort
		{
			set{ _proxyport=value;}
			get{return _proxyport;}
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


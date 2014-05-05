using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Printsetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Printsetting
	{
		public Printsetting()
		{}
		#region Model
		private int _printsettingid;
		private string _printmodel;
		private string _settingfile;
		private int? _templateid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int PrintSettingId
		{
			set{ _printsettingid=value;}
			get{return _printsettingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintModel
		{
			set{ _printmodel=value;}
			get{return _printmodel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SettingFile
		{
			set{ _settingfile=value;}
			get{return _settingfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TemplateId
		{
			set{ _templateid=value;}
			get{return _templateid;}
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


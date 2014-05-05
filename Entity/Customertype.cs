using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Customertype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customertype
	{
		public Customertype()
		{}
		#region Model
		private int _customertypeid;
		private string _customertypename;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int CustomerTypeId
		{
			set{ _customertypeid=value;}
			get{return _customertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerTypeName
		{
			set{ _customertypename=value;}
			get{return _customertypename;}
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


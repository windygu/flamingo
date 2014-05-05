using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Vouchertype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Vouchertype
	{
		public Vouchertype()
		{}
		#region Model
		private int _vouchertypeid;
		private string _vouchertypename;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int VoucherTypeId
		{
			set{ _vouchertypeid=value;}
			get{return _vouchertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoucherTypeName
		{
			set{ _vouchertypename=value;}
			get{return _vouchertypename;}
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


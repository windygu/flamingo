using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Templateitem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Templateitem
	{
		public Templateitem()
		{}
		#region Model
		private int _templateitemid;
		private string _templateitemname;
		private int? _abscissa;
		private int? _ordinate;
		private string _font;
		private int? _fontsize;
		private string _fontcolour;
		private string _description;
		private int? _templateid;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public int TemplateItemId
		{
			set{ _templateitemid=value;}
			get{return _templateitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TemplateItemName
		{
			set{ _templateitemname=value;}
			get{return _templateitemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Abscissa
		{
			set{ _abscissa=value;}
			get{return _abscissa;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Ordinate
		{
			set{ _ordinate=value;}
			get{return _ordinate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Font
		{
			set{ _font=value;}
			get{return _font;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FontSize
		{
			set{ _fontsize=value;}
			get{return _fontsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FontColour
		{
			set{ _fontcolour=value;}
			get{return _fontcolour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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


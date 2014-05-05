using System;
namespace Flamingo.Entity
{
	/// <summary>
	/// Hall:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hall
	{
		public Hall()
		{}
		#region Model
		private string _hallid;
		private string _theaterid;
		private string _hallname;
		private int? _seats;
		private int? _levels;
		private string _screen;
		private string _projector;
		private string _playmode;
		private string _soundsystem;
		private string _description;
		private DateTime _created;
		private DateTime _updated;
		private int _activeflag;
		/// <summary>
		/// 
		/// </summary>
		public string HallId
		{
			set{ _hallid=value;}
			get{return _hallid;}
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
		public string HallName
		{
			set{ _hallname=value;}
			get{return _hallname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Seats
		{
			set{ _seats=value;}
			get{return _seats;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Levels
		{
			set{ _levels=value;}
			get{return _levels;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Screen
		{
			set{ _screen=value;}
			get{return _screen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Projector
		{
			set{ _projector=value;}
			get{return _projector;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlayMode
		{
			set{ _playmode=value;}
			get{return _playmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SoundSystem
		{
			set{ _soundsystem=value;}
			get{return _soundsystem;}
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


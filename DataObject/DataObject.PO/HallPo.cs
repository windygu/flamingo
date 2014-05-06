using System;
namespace DataObject.PO
{
	public class HallPo
	{
		private string _HallId;
		private string _TheaterId;
		private string _HallName;
		private int _Seats;
		private int _Levels;
		private string _Screen;
		private string _Projector;
		private string _PlayMode;
		private string _SoundSystem;
		private string _Description;
		public string HALLID
		{
			get
			{
				return this._HallId;
			}
			set
			{
				this._HallId = value;
			}
		}
		public string THEATERID
		{
			get
			{
				return this._TheaterId;
			}
			set
			{
				this._TheaterId = value;
			}
		}
		public string HALLNAME
		{
			get
			{
				return this._HallName;
			}
			set
			{
				this._HallName = value;
			}
		}
		public int SEATS
		{
			get
			{
				return this._Seats;
			}
			set
			{
				this._Seats = value;
			}
		}
		public int LEVELS
		{
			get
			{
				return this._Levels;
			}
			set
			{
				this._Levels = value;
			}
		}
		public string SCREEN
		{
			get
			{
				return this._Screen;
			}
			set
			{
				this._Screen = value;
			}
		}
		public string PROJECTOR
		{
			get
			{
				return this._Projector;
			}
			set
			{
				this._Projector = value;
			}
		}
		public string PLAYMODE
		{
			get
			{
				return this._PlayMode;
			}
			set
			{
				this._PlayMode = value;
			}
		}
		public string SOUNDSYSTEM
		{
			get
			{
				return this._SoundSystem;
			}
			set
			{
				this._SoundSystem = value;
			}
		}
		public string DESCRIPTION
		{
			get
			{
				return this._Description;
			}
			set
			{
				this._Description = value;
			}
		}
		public HallPo()
		{
		}
		public HallPo(string _HallId, string _TheaterId, string _HallName, int _Seats, int _Levels, string _Screen, string _Projector, string _PlayMode, string _SoundSystem, string _Description)
		{
			this._HallId = _HallId;
			this._TheaterId = _TheaterId;
			this._HallName = _HallName;
			this._Seats = _Seats;
			this._Levels = _Levels;
			this._Screen = _Screen;
			this._Projector = _Projector;
			this._PlayMode = _PlayMode;
			this._SoundSystem = _SoundSystem;
			this._Description = _Description;
		}
	}
}

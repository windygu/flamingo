using System;
namespace DataObject.PO
{
	public class OnLineUserLogPo
	{
		private int _UserId;
		private string _UserName;
		private string _WS_IP;
		private string _WS_MAC;
		private DateTime _Created = DateTime.Now;
		public int USERID
		{
			get
			{
				return this._UserId;
			}
			set
			{
				this._UserId = value;
			}
		}
		public string USERNAME
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}
		public string WS_IP
		{
			get
			{
				return this._WS_IP;
			}
			set
			{
				this._WS_IP = value;
			}
		}
		public string WS_MAC
		{
			get
			{
				return this._WS_MAC;
			}
			set
			{
				this._WS_MAC = value;
			}
		}
		public DateTime CREATED
		{
			get
			{
				return this._Created;
			}
			set
			{
				this._Created = value;
			}
		}
		public OnLineUserLogPo()
		{
		}
		public OnLineUserLogPo(int _UserId, string _UserName, string _WS_IP, string _WS_MAC, DateTime _Created)
		{
			this._UserId = _UserId;
			this._UserName = _UserName;
			this._WS_IP = _WS_IP;
			this._WS_MAC = _WS_MAC;
			this._Created = _Created;
		}
	}
}

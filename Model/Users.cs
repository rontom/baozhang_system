using System;
namespace Model
{
	/// <summary>
	/// ʵ����Users ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Users
	{
		public Users()
		{}
		#region Model
		private string _username;
		private string _password;
		private string _status;
		private string _ipaddress;
		private DateTime _logintime;
		private string _truename;
		private string _usertype;
        private DateTime _addTime;
        private string phone;
        private string beizhu;
        private string yuanxi;
        private byte[] _face;
        private int chatport;

        public int Chatport
        {
            get { return chatport; }
            set { chatport = value; }
        }

        public byte[] Face
        {
            get { return _face; }
            set { _face = value; }
        }

        public string Yuanxi
        {
            get { return yuanxi; }
            set { yuanxi = value; }
        }
        private string zhuanye;

        public string Zhuanye
        {
            get { return zhuanye; }
            set { zhuanye = value; }
        }

        public string Beizhu
        {
            get { return beizhu; }
            set { beizhu = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public DateTime AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }
        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
		/// <summary>
		/// �û����ƣ�varchar(50)
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �û����룬varchar(50)��Ĭ��Ϊ'hsnt'
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// �û�״̬��varchar(50)��Ĭ��Ϊ'0'
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// IP��ַ��varchar(50)��Ĭ��Ϊ'0'
		/// </summary>
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// �����½ʱ�䣬datetime��Ĭ��Ϊgetdate()
		/// </summary>
		public DateTime LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// ��ʵ������varchar(50)
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		#endregion Model

	}
}


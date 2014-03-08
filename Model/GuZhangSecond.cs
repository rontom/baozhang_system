using System;
namespace Model
{
	/// <summary>
	/// 实体类GuZhangSecond 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class GuZhangSecond
	{
		public GuZhangSecond()
		{}
		#region Model
		private int _guzhangsecondid;
		private string _zhanghao;
		private string _guzhangcontent;
		private string _address;
		private string _fuzeren;
		private int _dongid;
		private string _doliucheng;
		private bool _isdo;
		private string _beizhu;
		private DateTime? _dodate;
        private bool _isdel;
        private string _name;
        private string _phone;
        private bool _isonprintqueue;
        private string _recevier;
        private string _menth;
        private int _guZhangFirstID;
        private string _forward_description;
        private string _dopeoples;

        public string Dopeoples
        {
            get { return _dopeoples; }
            set { _dopeoples = value; }
        }

        public string Forward_description
        {
            get { return _forward_description; }
            set { _forward_description = value; }
        }
        private string _result_descript;

        public string Result_descript
        {
            get { return _result_descript; }
            set { _result_descript = value; }
        }

        public int GuZhangFirstID
        {
            get { return _guZhangFirstID; }
            set { _guZhangFirstID = value; }
        }

        public string Menth
        {
            get { return _menth; }
            set { _menth = value; }
        }
        private DateTime _ReceivedDate;

        public DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        public string Recevier
        {
            get { return _recevier; }
            set { _recevier = value; }
        }

        public bool Isonprintqueue
        {
            get { return _isonprintqueue; }
            set { _isonprintqueue = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

      

        public bool Isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }
        private string delUser;

        public string DelUser
        {
            get { return delUser; }
            set { delUser = value; }
        }
		/// <summary>
		/// 分类故障ID，int，对应GuZhangFirst的GuZhangFirstID
		/// </summary>
		public int GuZhangSecondID
		{
			set{ _guzhangsecondid=value;}
			get{return _guzhangsecondid;}
		}
		/// <summary>
		/// 帐号，varchar(50)，对应BaoZhangRen的ZhangHao
		/// </summary>
		public string ZhangHao
		{
			set{ _zhanghao=value;}
			get{return _zhanghao;}
		}
		/// <summary>
		/// 故障内容，varchar(200)
		/// </summary>
		public string GuZhangContent
		{
			set{ _guzhangcontent=value;}
			get{return _guzhangcontent;}
		}
		/// <summary>
		/// 故障地址，varchar(50)
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 负责人ID，int
		/// </summary>
		public string FuZeRen
		{
			set{ _fuzeren=value;}
			get{return _fuzeren;}
		}
		/// <summary>
		/// 一栋楼的ID，int，用来做统计用
		/// </summary>
		public int DongID
		{
			set{ _dongid=value;}
			get{return _dongid;}
		}
		/// <summary>
		/// 故障处理流程，varchar(200)
		/// </summary>
		public string DoLiuCheng
		{
			set{ _doliucheng=value;}
			get{return _doliucheng;}
		}
		/// <summary>
		/// 故障是否处理，bit，默认为0
		/// </summary>
		public bool IsDo
		{
			set{ _isdo=value;}
			get{return _isdo;}
		}
		/// <summary>
		/// 处理故障的备注，varchar(200)
		/// </summary>
		public string BeiZhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		/// <summary>
		/// 处理完故障的日期，datetime
		/// </summary>
		public DateTime? DoDate
		{
			set{ _dodate=value;}
			get{return _dodate;}
		}
		#endregion Model

	}
}


using System;
namespace Model
{
	/// <summary>
	/// ʵ����Dong ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Dong
	{
		public Dong()
		{}
		#region Model
		private int _dongid;
		private string _dongname;
        private string _anothername;

        public string Anothername
        {
            get { return _anothername; }
            set { _anothername = value; }
        }
		/// <summary>
		/// ¥��ID��int������
		/// </summary>
		public int DongID
		{
			set{ _dongid=value;}
			get{return _dongid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DongName
		{
			set{ _dongname=value;}
			get{return _dongname;}
		}
		#endregion Model

	}
}


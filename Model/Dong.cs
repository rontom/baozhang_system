using System;
namespace Model
{
	/// <summary>
	/// 实体类Dong 。(属性说明自动提取数据库字段的描述信息)
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
		/// 楼层ID，int，自增
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


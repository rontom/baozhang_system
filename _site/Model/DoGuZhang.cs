using System;
namespace Model
{
	/// <summary>
	/// ʵ����DoGuZhang ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class DoGuZhang
	{
		public DoGuZhang()
		{}
		#region Model
		private int _guzhangsecondid;
		private string _username;
		/// <summary>
		/// 
		/// </summary>
		public int GuZhangSecondID
		{
			set{ _guzhangsecondid=value;}
			get{return _guzhangsecondid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		#endregion Model

	}
}


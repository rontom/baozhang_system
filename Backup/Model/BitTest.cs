using System;
namespace Model
{
	/// <summary>
	/// ʵ����BitTest ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class BitTest
	{
		public BitTest()
		{}
		#region Model
		private bool _col1;
		/// <summary>
		/// 
		/// </summary>
		public bool col1
		{
			set{ _col1=value;}
			get{return _col1;}
		}
		#endregion Model

	}
}


using System;
namespace Model
{
	/// <summary>
	/// ʵ����BaoZhangRen ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class BaoZhangRen
	{
		public BaoZhangRen()
		{}
		#region Model
		private string _zhanghao;
		private string _baozhangrenname;
		/// <summary>
		/// �������ʺ�
		/// </summary>
		public string ZhangHao
		{
			set{ _zhanghao=value;}
			get{return _zhanghao;}
		}
		/// <summary>
		/// ������������varchar(50)
		/// </summary>
		public string BaoZhangRenName
		{
			set{ _baozhangrenname=value;}
			get{return _baozhangrenname;}
		}
		#endregion Model

	}
}


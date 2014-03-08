using System;
namespace Model
{
	/// <summary>
	/// 实体类BaoZhangRen 。(属性说明自动提取数据库字段的描述信息)
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
		/// 报障人帐号
		/// </summary>
		public string ZhangHao
		{
			set{ _zhanghao=value;}
			get{return _zhanghao;}
		}
		/// <summary>
		/// 报障人姓名，varchar(50)
		/// </summary>
		public string BaoZhangRenName
		{
			set{ _baozhangrenname=value;}
			get{return _baozhangrenname;}
		}
		#endregion Model

	}
}


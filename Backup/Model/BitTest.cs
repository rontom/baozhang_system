using System;
namespace Model
{
	/// <summary>
	/// 实体类BitTest 。(属性说明自动提取数据库字段的描述信息)
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


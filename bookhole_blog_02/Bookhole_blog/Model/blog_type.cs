using System;
namespace Bookhole_blog.Model
{
	/// <summary>
	/// blog_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class blog_type
	{
		public blog_type()
		{}
		#region Model
		private int _type_id;
		private string _type_name;
		private int? _type_percentage;
		/// <summary>
		/// 
		/// </summary>
		public int Type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type_percentage
		{
			set{ _type_percentage=value;}
			get{return _type_percentage;}
		}
		#endregion Model

	}
}


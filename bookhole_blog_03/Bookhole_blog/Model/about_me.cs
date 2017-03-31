using System;
namespace Bookhole_blog.Model
{
	/// <summary>
	/// about_me:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class about_me
	{
		public about_me()
		{}
		#region Model
		private string _about_title;
		private string _about_text;
		private string _about_img;
		private int? _about_phone;
		private string _about_email;
		/// <summary>
		/// 
		/// </summary>
		public string About_title
		{
			set{ _about_title=value;}
			get{return _about_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string About_text
		{
			set{ _about_text=value;}
			get{return _about_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string About_img
		{
			set{ _about_img=value;}
			get{return _about_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? About_phone
		{
			set{ _about_phone=value;}
			get{return _about_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string About_email
		{
			set{ _about_email=value;}
			get{return _about_email;}
		}
		#endregion Model

	}
}


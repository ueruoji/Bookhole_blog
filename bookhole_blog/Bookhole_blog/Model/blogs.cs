using System;
namespace Bookhole_blog.Model
{
	/// <summary>
	/// blogs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class blogs
	{
		public blogs()
		{}
		#region Model
		private int _blog_id;
		private string _blog_title;
		private string _blog_text;
		private int? _blog_read;
		private string _blog_img;
		private int? _blog_is;
		private string _blog_time;
		private int? _blog_delete;
		private int? _blog_typeid;
		private string _blog_abstract;
        private string _blog_typename;
		/// <summary>
		/// 
		/// </summary>
		public int Blog_id
		{
			set{ _blog_id=value;}
			get{return _blog_id;}
		}
        public string Blog_typename
        {
            set { _blog_typename = value; }
            get { return _blog_typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Blog_title
		{
			set{ _blog_title=value;}
			get{return _blog_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Blog_text
		{
			set{ _blog_text=value;}
			get{return _blog_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Blog_read
		{
			set{ _blog_read=value;}
			get{return _blog_read;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Blog_img
		{
			set{ _blog_img=value;}
			get{return _blog_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Blog_is
		{
			set{ _blog_is=value;}
			get{return _blog_is;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Blog_time
		{
			set{ _blog_time=value;}
			get{return _blog_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Blog_delete
		{
			set{ _blog_delete=value;}
			get{return _blog_delete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Blog_typeid
		{
			set{ _blog_typeid=value;}
			get{return _blog_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Blog_abstract
		{
			set{ _blog_abstract=value;}
			get{return _blog_abstract;}
		}
		#endregion Model

	}
}


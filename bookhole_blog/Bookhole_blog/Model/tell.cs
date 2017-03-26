using System;
namespace Bookhole_blog.Model
{
	/// <summary>
	/// tell:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tell
	{
		public tell()
		{}
		#region Model
		private int _tell_blogid;
		private int? _tell_userid;
		private string _tell_text;
		private string _tell_time;
		/// <summary>
		/// 
		/// </summary>
		public int Tell_blogid
		{
			set{ _tell_blogid=value;}
			get{return _tell_blogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Tell_userid
		{
			set{ _tell_userid=value;}
			get{return _tell_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tell_text
		{
			set{ _tell_text=value;}
			get{return _tell_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tell_time
		{
			set{ _tell_time=value;}
			get{return _tell_time;}
		}
		#endregion Model

	}
}


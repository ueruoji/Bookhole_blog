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
        { }
        #region Model
        private int? _tell_blogid;
        private int? _tell_userid;
        private string _tell_text;
        private string _tell_time;
        private int _tell_id;
        private string _tell_username;
        private string _tell_img;
        private string _tell_name;
        /// <summary>
        /// 
        /// </summary>
        public int? Tell_blogid
        {
            set { _tell_blogid = value; }
            get { return _tell_blogid; }
        }
        public string Tell_img
        {
            set { _tell_img = value; }
            get { return _tell_img; }
        }
        public string Tell_name
        {
            set { _tell_name = value; }
            get { return _tell_name; }
        }

        public string Tell_username
        {
            set { _tell_username = value; }
            get { return _tell_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tell_userid
        {
            set { _tell_userid = value; }
            get { return _tell_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tell_text
        {
            set { _tell_text = value; }
            get { return _tell_text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tell_time
        {
            set { _tell_time = value; }
            get { return _tell_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Tell_id
        {
            set { _tell_id = value; }
            get { return _tell_id; }
        }
        #endregion Model

    }
}


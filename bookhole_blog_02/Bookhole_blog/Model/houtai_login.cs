using System;
namespace Bookhole_blog.Model
{
    /// <summary>
    /// houtai_login:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class houtai_login
    {
        public houtai_login()
        { }
        #region Model
        private int _houtai_id;
        private string _houtai_pwd;
        private int? _houtai_level;
        /// <summary>
        /// 
        /// </summary>
        public int houtai_id
        {
            set { _houtai_id = value; }
            get { return _houtai_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string houtai_pwd
        {
            set { _houtai_pwd = value; }
            get { return _houtai_pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? houtai_level
        {
            set { _houtai_level = value; }
            get { return _houtai_level; }
        }
        #endregion Model

    }
}


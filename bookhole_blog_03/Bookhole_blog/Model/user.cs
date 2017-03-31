using System;
namespace Bookhole_blog.Model
{
    /// <summary>
    /// user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class user
    {
        public user()
        { }
        #region Model
        private double _user_id;
        private string _user_name;
        private string _user_pwd;
        private string _user_img;
        private double? _user_qq;
        private double? _user_phone;
        /// <summary>
        /// 
        /// </summary>
        public double User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_pwd
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_img
        {
            set { _user_img = value; }
            get { return _user_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? User_qq
        {
            set { _user_qq = value; }
            get { return _user_qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? User_phone
        {
            set { _user_phone = value; }
            get { return _user_phone; }
        }
        #endregion Model

    }
}


using System;
namespace Bookhole_blog.Model
{
    /// <summary>
    /// img:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class img
    {
        public img()
        { }
        #region Model
        private int _img_id;
        private string _img_address;
        private string _img_text;
        private int? _img_is;
        /// <summary>
        /// 
        /// </summary>
        public int Img_id
        {
            set { _img_id = value; }
            get { return _img_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img_address
        {
            set { _img_address = value; }
            get { return _img_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img_text
        {
            set { _img_text = value; }
            get { return _img_text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Img_is
        {
            set { _img_is = value; }
            get { return _img_is; }
        }
        #endregion Model

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookhole_blog.Web.houtai
{
    public partial class page_blog : System.Web.UI.Page
    {
        public List<Model.blogs> oblogs { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.blogs bll_blogs = new BLL.blogs();
            List<Model.blogs> blogs = bll_blogs.GetModelList("Blog_delete=0");
            BLL.blog_type bll_type = new BLL.blog_type();

            for (int i = 0; i < blogs.Count; i++)
            {
                Model.blog_type model_type = bll_type.GetModel((int)blogs[i].Blog_typeid);
                blogs[i].Blog_typename = model_type.Type_name;
            }
            oblogs = blogs;

        }
    }
}
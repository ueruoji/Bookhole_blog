using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookhole_blog.Web.houtai
{
    public partial class page_type : System.Web.UI.Page
    {
        public List<Model.blog_type> list_type { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ht_id"] == null && Request.Cookies["ht_pwd"] == null)
            {
                Response.Redirect("login.html");
            }
            else
            {
                BLL.blog_type bll_type = new BLL.blog_type();
                list_type = bll_type.GetModelList("");
            }
           

        
        }
    }
}
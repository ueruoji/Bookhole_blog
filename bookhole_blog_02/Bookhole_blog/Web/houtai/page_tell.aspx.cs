using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookhole_blog.Web.houtai
{
    public partial class page_tell : System.Web.UI.Page
    {
        public List<Model.blogs> list_blog { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ht_id"] == null && Request.Cookies["ht_pwd"] == null)
            {
                Response.Redirect("login.html");
            }
            else {
                BLL.blogs bll_blog = new BLL.blogs();
                list_blog = bll_blog.GetModelList("");
            }
           
          

        }
    }
}
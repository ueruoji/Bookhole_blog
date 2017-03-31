using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookhole_blog.Web.houtai
{
    public partial class page_user : System.Web.UI.Page
    {
        public List<Model.user> list_user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ht_id"] == null && Request.Cookies["ht_pwd"] == null)
            {
                Response.Redirect("login.html");
            }
            else {
                BLL.user bll_user = new BLL.user();
                list_user = bll_user.GetModelList("");
            }
          
        }
    }
}
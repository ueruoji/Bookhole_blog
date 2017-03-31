using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookhole_blog.Web.houtai
{
    public partial class page_img : System.Web.UI.Page
    {
        public List<Model.img> List_img { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ht_id"] == null && Request.Cookies["ht_pwd"] == null)
            {
                Response.Redirect("login.html");
            }
            else {
                BLL.img bll_img = new BLL.img();
                List_img = bll_img.GetModelList("");
            }
           
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// blog_select 的摘要说明
    /// </summary>
    public class blog_select : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id =Convert.ToInt32(context.Request["id"]);
            BLL.blogs bll_blog = new BLL.blogs();
            Model.blogs model_blog = bll_blog.GetModel(id);
            context.Response.Write(model_blog.Blog_text);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// delete 的摘要说明
    /// </summary>
    public class delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = 0;
            if (context.Request["page"] == "blog") {
                id = Convert.ToInt32(context.Request["id"]);
                BLL.blogs bll_blog = new BLL.blogs();
                bool blog_delete = bll_blog.Delete(id);
                if (blog_delete == true)
                {
                    context.Response.Write("删除成功");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
            if (context.Request["page"] == "type") {
                id = Convert.ToInt32(context.Request["id"]);
                BLL.blog_type bll_type = new BLL.blog_type();
                bool a = bll_type.Delete(id);
                if (a == true)
                {
                    context.Response.Write("删除成功");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
            
        }
        public void  delete_is() {


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
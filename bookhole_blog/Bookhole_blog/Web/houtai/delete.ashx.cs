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
            //图片
            if (context.Request["page"] == "img")
            {
                id = Convert.ToInt32(context.Request["id"]);
                BLL.img bll_img = new BLL.img();
                if (bll_img.Delete(id) == true)
                {
                    context.Response.Write("删除成功");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
            //用户
            if (context.Request["page"] == "user")
            {
                id = Convert.ToInt32(context.Request["id"]);
                BLL.user bll_user = new BLL.user();
                if (bll_user.Delete(id) == true)
                {
                    context.Response.Write("删除成功");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
            //博客评论
            if (context.Request["page"] == "tell") {
                id = Convert.ToInt32(context.Request["id"]);
                BLL.tell bll_tell = new BLL.tell();
                bool tell_delete =  bll_tell.Delete(id);
                if (tell_delete == true)
                {
                    context.Response.Write("删除成功");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
            //博客
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
            //博客类型
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
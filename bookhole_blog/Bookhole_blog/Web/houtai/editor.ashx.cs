using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// editor 的摘要说明
    /// </summary>
    public class editor : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //博客
            if (context.Request["page"] == "blog")
            {
                int id = Convert.ToInt32(context.Request["id"]);
                string title = context.Request["title"];
                string img = context.Request["img"];
                int showis = Convert.ToInt32(context.Request["showis"]);
                string time = context.Request["time"];
                string typename = context.Request["typename"];
                string text = context.Request["text"];
                BLL.blog_type bll_type = new BLL.blog_type();
                List<Model.blog_type> list_type = bll_type.GetModelList("Type_name='" + typename + "'");
                Model.blogs model_blog = new Model.blogs()
                {
                    Blog_id = id,
                    Blog_title = title,
                    Blog_img = img,
                    Blog_is = showis,
                    Blog_time = time,
                    Blog_typeid = list_type[0].Type_id,
                    Blog_text = text,
                    Blog_delete = 0
                };
                BLL.blogs blogs = new BLL.blogs();
                bool blog_add = blogs.Update(model_blog);
                if (blog_add == true)
                {
                    context.Response.Write("修改成功");
                }
                else
                {
                    context.Response.Write("修改失败");
                }
            }

                //博客类型
                if (context.Request["page"] == "type") {
                int id = Convert.ToInt32(context.Request["id"]);
                string type = context.Request["type"];
                int bai = Convert.ToInt32(context.Request["bai"]);
                Model.blog_type model_type = new Model.blog_type()
                {
                    Type_id = id,
                    Type_name = type,
                    Type_percentage = bai
                };
                BLL.blog_type bll_type = new BLL.blog_type();
                bool a = bll_type.Update(model_type);
                if (a == true)
                {
                    context.Response.Write("修改成功");
                }
                else {
                    context.Response.Write("修改失败");
                }
            }
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
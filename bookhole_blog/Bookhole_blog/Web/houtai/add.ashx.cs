using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// add 的摘要说明
    /// </summary>
    public class add : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //图片
            if (context.Request["page"] == "img")
            {
                int id = Convert.ToInt32(context.Request["id"]);
                string text = context.Request["text"];
                string img = context.Request["img"];
                int img_is = Convert.ToInt32(context.Request["is"]);
                Model.img model_img = new Model.img()
                {
                    Img_id=id,
                    Img_address =img,
                    Img_is =img_is,
                    Img_text = text

                };
                BLL.img bll_img = new BLL.img();
                if (bll_img.Add(model_img) == true)
                {
                    context.Response.Write("添加成功");
                }
                else
                {
                    context.Response.Write("添加失败");
                }
            }
            //用户
            if (context.Request["page"] == "user") {
                int id = Convert.ToInt32(context.Request["id"]);
                string name = context.Request["name"];
                string img = context.Request["img"];
                int qq = Convert.ToInt32(context.Request["qq"]);
                int phone = Convert.ToInt32(context.Request["phone"]);
                Model.user model_user = new Model.user() {
                    User_id = id,
                    User_name = name,
                    User_img = img,
                    User_qq = qq,
                    User_phone = phone,
                    User_pwd = id.ToString()
                };
                BLL.user bll_user = new BLL.user();
                if (bll_user.Add(model_user) == true)
                {
                    context.Response.Write("添加成功");
                }
                else
                {
                    context.Response.Write("添加失败");
                }
            }
            //博客
            if (context.Request["page"] == "blog")
            {
                int id = Convert.ToInt32(context.Request["id"]);
                string title = context.Request["title"];
                string img = context.Request["img"];
                int showis = Convert.ToInt32(context.Request["showis"]);
                string time = context.Request["time"];
                string typename =context.Request["typename"];
                string text = context.Request["text"];
                string abs = context.Request["abstract"];
                BLL.blog_type bll_type = new BLL.blog_type();
                List<Model.blog_type> list_type = bll_type.GetModelList("Type_name='"+typename+"'");
                Model.blogs model_blog = new Model.blogs()
                {
                    Blog_id = id,
                    Blog_title = title,
                    Blog_img = img,
                    Blog_is = showis,
                    Blog_time = time,
                    Blog_typeid = list_type[0].Type_id,
                    Blog_abstract = abs,
                    Blog_text = text,
                    Blog_delete = 0
                };
                BLL.blogs blogs = new BLL.blogs();
                bool blog_add = blogs.Add(model_blog);
                if (blog_add == true)
                {
                    context.Response.Write("添加成功");
                }
                else
                {
                    context.Response.Write("添加失败");
                }
            }

            //博客类型
            if (context.Request["page"] == "type") {
                int id =Convert.ToInt32(context.Request["id"]);
                string type = context.Request["type"];
                int bai = Convert.ToInt32(context.Request["bai"]);
                Model.blog_type model_type = new Model.blog_type()
                {
                    Type_id = id,
                    Type_name = type,
                    Type_percentage = bai
                };
                BLL.blog_type bll_type = new BLL.blog_type();
                bool is_type = bll_type.Add(model_type);
                if (is_type == true)
                {
                    context.Response.Write("添加成功");
                }
                else {
                    context.Response.Write("添加失败");
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
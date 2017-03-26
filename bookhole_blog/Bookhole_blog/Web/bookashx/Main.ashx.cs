using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// Main1 的摘要说明
    /// </summary>
    public class Main1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //博客类别
            BLL.blog_type bll_type = new BLL.blog_type();
            List<Model.blog_type> list_type = bll_type.GetModelList("");
            //热门博客
            BLL.blogs bll_blogs = new BLL.blogs();
            List<Model.blogs> list_hotblogs = bll_blogs.GetModelList(" Blog_delete = 0 and Blog_is = 1 order by Blog_read  desc");
            Model.blogs moblogs = list_hotblogs[0];
            moblogs.Blog_text = moblogs.Blog_text.Substring(0, 150);

            //图片分享
            //推荐博客tui

            List<Model.blogs> list_tuiblogs = new List<Model.blogs> { list_hotblogs[1], list_hotblogs[2], list_hotblogs[3] };
            for (int i = 1; i < 4; i++)
            {
                Model.blogs modelblogs = list_hotblogs[i];
                modelblogs.Blog_text = modelblogs.Blog_text.Substring(0, 30);
            }

            Model.Main main = new Model.Main()
            {
                Main_type = list_type,
                Main_hotblogs = moblogs,
                Main_tuiblogs = list_tuiblogs
            };
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(main);
            context.Response.Write(json);
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
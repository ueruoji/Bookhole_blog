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
            string session_user = null;
            //if (context.Session["USER"] != null){
            //    session_user = context.Session["USER"].ToString();
            //}
            BLL.blog_type bll_type = new BLL.blog_type();
            List<Model.blog_type> list_type = bll_type.GetModelList("");
            //热门博客
            BLL.blogs bll_blogs = new BLL.blogs();
            List<Model.blogs> list_hotblogs = bll_blogs.GetModelList(" Blog_delete = 0 and Blog_is = 1 order by Blog_read  desc");
            Model.blogs moblogs = list_hotblogs[0];
            //图片分享
            BLL.img bll_img = new BLL.img();
            List<Model.img> list_img = bll_img.GetModelList("Img_is=1");
            //评论
            BLL.tell bll_tell = new BLL.tell();
            BLL.user bll_user = new BLL.user();
            List<Model.tell> list_tell = bll_tell.GetModelList(" Tell_id>0 order by Tell_blogid  LIMIT 3");
            for (int i = 0; i < list_tell.Count; i++)
            {
                Model.user model_user = bll_user.GetModel((int)list_tell[i].Tell_userid);
                list_tell[i].Tell_img = model_user.User_img;
                list_tell[i].Tell_name = model_user.User_name;
            }
            //推荐博客

            List<Model.blogs> list_tuiblogs = new List<Model.blogs> { list_hotblogs[1], list_hotblogs[2], list_hotblogs[3] };
            Model.Main main = new Model.Main()
            {
                Main_type = list_type,
                Main_hotblogs = moblogs,
                Main_tuiblogs = list_tuiblogs,
                Main_tell = list_tell,
                Main_img = list_img,
                name = session_user
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
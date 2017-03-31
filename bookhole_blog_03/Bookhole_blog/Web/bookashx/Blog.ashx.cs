using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// Blog 的摘要说明
    /// </summary>
    public class Blog : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            BLL.blogs bll_blog = new BLL.blogs();
            Model.blogs model_blog = bll_blog.GetModel(id);
            //阅读排行榜
            List<Model.blogs> list_blog = bll_blog.GetModelList("Blog_delete = 0 and Blog_is = 1 order by Blog_read desc LIMIT 4");
            //评论
            BLL.tell bll_tell = new BLL.tell();
            List<Model.tell> list_tell = bll_tell.GetModelList("Tell_blogid="+ id + "");
            BLL.user bll_user = new BLL.user();
            for (int i = 0; i < list_tell.Count; i++)
            {
                Model.user model_user = bll_user.GetModel((double)list_tell[i].Tell_userid);
                list_tell[i].Tell_name = model_user.User_name;
            }
           

            Model.showblog model_show = new Model.showblog() { 
            Show_blog=model_blog,
            Show_list=list_blog,
            Show_tell =list_tell
            };
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string is_show = js.Serialize(model_show);
            context.Response.Write(is_show);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// tell 的摘要说明
    /// </summary>
    public class tell : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (Convert.ToString(context.Session["USER"]) != "")
            {
                string text_tell = context.Request["text_tell"];
                int bid = Convert.ToInt32(context.Request["bid"]);
                object a = context.Session["USER"];
                Model.user user = (Model.user)a;
                Model.tell model_tell = new Model.tell()
                {
                    Tell_blogid = bid,
                    Tell_userid = user.User_id,
                    Tell_text = text_tell
                };
                BLL.tell bll_tell = new BLL.tell();
                if (bll_tell.Add(model_tell))
                {
                    context.Response.Write(1);
                }


            }
            else {
                context.Response.Write(0);
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
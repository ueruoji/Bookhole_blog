using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Cookies["userid"] != null && context.Request.Cookies["userpwd"] != null)
            {
                context.Response.Write(1);
            }
            else {
                int userid = 0;
                #region 没有cookie
                if (int.TryParse(context.Request["username"], out userid))
                {
                    #region 账号格式正确
                    userid = Convert.ToInt32(context.Request["username"]);
                    BLL.user bll_user = new BLL.user();
                    Model.user model_user = bll_user.GetModel(userid);
                    if (model_user != null)
                    {
                        string pwd = context.Request["password"];
                        if (model_user.User_pwd == pwd)
                        {
                            #region 密码正确
                            context.Session["USER"] = model_user;
                            string loginkeeping = context.Request["loginkeeping"];
                            if (loginkeeping != null)
                            {
                                #region 记住我
                                HttpCookie cookie_id = new HttpCookie("userid");
                                cookie_id.Expires = DateTime.Now.AddDays(1);
                                cookie_id.Value = userid.ToString();
                                context.Response.AppendCookie(cookie_id);
                                HttpCookie cookie_pwd = new HttpCookie("userpwd");
                                cookie_pwd.Expires = DateTime.Now.AddDays(1);
                                cookie_pwd.Value = pwd.ToString();
                                context.Response.AppendCookie(cookie_pwd);
                                context.Response.Write(1);
                                #endregion
                            }
                            #endregion

                        }
                        else
                        {
                            context.Response.Write("密码输入错误");
                        }

                    }
                    else {
                        context.Response.Write("账号格式错误");
                    }
                    #endregion
                }
                #endregion
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
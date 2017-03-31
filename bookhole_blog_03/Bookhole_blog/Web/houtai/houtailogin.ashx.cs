using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// houtailogin 的摘要说明
    /// </summary>
    public class houtailogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            string pwd = context.Request["pwd"];
            string check = context.Request["user_Remember"];
            BLL.houtai_login bll_login = new BLL.houtai_login();
            if (bll_login.Exists(id))
            {
                Model.houtai_login model_houtai = bll_login.GetModel(id);
                if (pwd == model_houtai.houtai_pwd)
                {
                    if (check=="true") {
                        HttpCookie cookie_id = new HttpCookie("ht_id");
                        cookie_id.Expires = DateTime.Now.AddDays(1);
                        cookie_id.Value = id.ToString();
                        context.Response.AppendCookie(cookie_id);
                        HttpCookie cookie_pwd = new HttpCookie("ht_pwd");
                        cookie_pwd.Expires = DateTime.Now.AddDays(1);
                        cookie_pwd.Value = pwd.ToString();
                        context.Response.AppendCookie(cookie_pwd);
                    }
                    //如果是1就跳转登录
                    context.Response.Write(1);
                }
                else {
                    context.Response.Write("密码输入有误");
                }
                
            }
            else {
                context.Response.Write("用户名输入有误");
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
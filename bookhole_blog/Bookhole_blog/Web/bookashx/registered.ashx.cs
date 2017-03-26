using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// registered 的摘要说明
    /// </summary>
    public class registered : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int userid = 0;
            if (int.TryParse(context.Request["username"], out userid))
            {
                userid = Convert.ToInt32(context.Request["username"]);
                int phone = 0;
                if (int.TryParse(context.Request["phone"], out phone))
                {
                    phone = Convert.ToInt32(context.Request["phone"]);
                    string pwd = context.Request["pwd"];
                    string cpwd = context.Request["cpwd"];
                    if (pwd == cpwd)
                    {
                        Model.user model_user = new Model.user()
                        {
                            User_id = userid,
                            User_pwd = pwd,
                            User_phone = phone
                        };
                        BLL.user bll_user = new BLL.user();
                        bool add = bll_user.Add(model_user);
                        HttpCookie cookie_id = new HttpCookie("userid");
                        cookie_id.Expires = DateTime.Now.AddDays(1);
                        cookie_id.Value = userid.ToString();
                        context.Response.AppendCookie(cookie_id);
                        HttpCookie cookie_pwd = new HttpCookie("userpwd");
                        cookie_pwd.Expires = DateTime.Now.AddDays(1);
                        cookie_pwd.Value = pwd.ToString();
                        context.Response.AppendCookie(cookie_pwd);
                        context.Response.Write(1);
                    }
                    else
                    {
                        context.Response.Write("密码输入有错误");
                    }
                }
                else {

                    context.Response.Write("手机号输入有误");
                }
               
            }
            else {
                context.Response.Write("用户名格式有误");
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
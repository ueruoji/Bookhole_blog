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
    public class registered : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string user = context.Request["username"];
            string uphone = context.Request["phone"];
            string pattern = @"^\d*$";

            if (Regex.IsMatch(user, pattern))
            {
                if (Regex.IsMatch(uphone, pattern)) {
                    double phone = Convert.ToDouble(uphone);
                    double userid = Convert.ToDouble(user);
                    string pwd = context.Request["pwd"];
                    string cpwd = context.Request["cpwd"];
                    if (pwd == cpwd)
                    {
                        Model.user model_user = new Model.user()
                        {
                            User_id = userid,
                            User_pwd = pwd,
                            User_phone = phone,
                            User_name = userid.ToString(),
                            User_img = "../images/m_01.jpg",
                            User_qq = 0
                        };
                        BLL.user bll_user = new BLL.user();
                        if (!bll_user.Exists(userid))
                        {
                            if (bll_user.Add(model_user))
                            {
                                context.Session["USER"] = model_user;
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
                        }
                        else
                        {
                            context.Response.Write("用户名已存在");
                        }

                    }
                    else
                    {
                        context.Response.Write("密码输入有错误");
                    }
                }
                else {
                    context.Response.Write("电话输入有误");
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
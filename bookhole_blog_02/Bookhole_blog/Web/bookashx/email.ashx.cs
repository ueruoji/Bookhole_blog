using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Bookhole_blog.Web.bookashx
{
    /// <summary>
    /// email 的摘要说明
    /// </summary>
    public class email : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          
                string name = context.Request["name"];
                string user_email = context.Request["email"];
                MailMessage mail = new MailMessage();
                //设置发件箱
                mail.From = new MailAddress("ryh15034686832@163.com", "书洞博客");
                //设置收件箱
                mail.To.Add(new MailAddress(user_email, name));
                mail.Subject = "欢迎订阅书洞博客";
                mail.Body = name+"您好！更新会及时通知您";
                //配置发送邮件服务器
                SmtpClient client = new SmtpClient("smtp.163.com");
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ryh15034686832@163.com", "ryh15034686832hh");
                client.Send(mail);
                context.Response.Write("发送成功");
            

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
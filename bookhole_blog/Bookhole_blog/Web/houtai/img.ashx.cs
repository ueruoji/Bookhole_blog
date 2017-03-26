using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookhole_blog.Web.houtai
{
    /// <summary>
    /// img 的摘要说明
    /// </summary>
    public class img : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bolg = context.Request["name"];
            if (bolg == "blog")
            {
                HttpFileCollection files = context.Request.Files;
                string msg = string.Empty;
                string error = string.Empty;
                string imgurl;
                if (files.Count > 0)
                {
                    files[0].SaveAs(@"C:\Users\ryh\Desktop\bookhole_blog\Bookhole_blog\Web\images\" + files[0].FileName + "");
                    msg = " 成功! 文件大小为:" + files[0].ContentLength;
                    imgurl = "images/" + files[0].FileName;
                    string res = "{ error:'" + error + "', msg:'" + msg + "',imgurl:'" + imgurl + "'}";
                    context.Response.Write(res);
                    context.Response.End();
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MysqlPractise
{
    /// <summary>
    /// Summary description for PersonList
    /// </summary>
    public class PersonList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from wifi_area");
            string html = CommonHelper.RenderHtml("test.html", dt.Rows);
            context.Response.Write(html);
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
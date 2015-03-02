using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MysqlPractise
{
    /// <summary>
    /// Summary description for insert1
    /// </summary>
    public class insert1 : IHttpHandler
    {
        public static readonly string connstr =
            ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //string uname = context.Request["name"];
            
            DataTable dt=new DataTable();
            dt = MySqlHelper.ExecuteDataTable("select * from wifi_area");
            string html = CommonHelper.RenderHtml("test.html", dt.Rows);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        context.Response.Write(dt.Rows[i][j]);
            //    }
            //}
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
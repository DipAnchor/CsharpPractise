using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysqlPractise
{
    /// <summary>
    /// Summary description for DataAdd
    /// </summary>
    public class DataAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            //DataEdit.ashx?action=AddNew
            //DataEdit.ashx?action=Edit%name=test3
            var area=new {name=context.Request["name"],ssid=context.Request["ssid"], pw=context.Request["pw"],description=context.Request["description"]};
            switch (action)
            {
                case null: { context.Response.Write(CommonHelper.RenderHtml("dataedit.html", MySqlHelper.ExecuteDataTable("select * from wifi_area").Rows)); break; }
                case "AddNew": { context.Response.Write(MySqlHelper.ExecuteNonQuery("insert into wifi_area (name,wifi_ssid,wifi_password,area_description) values ('" + area.name + "','" + area.ssid + "','" + area.pw + "','" + area.description + "') ") > 0 ? "Add Success" : "Add Fail"); break; }
                case "Edit": { context.Response.Write(MySqlHelper.ExecuteNonQuery("update wifi_area set name='" + area.name + "',wifi_ssid='" + area.ssid + "',wifi_password='" + area.pw + "',area_description='" + area.description + "' where name='"+area.name+"'") > 0 ? "Edit Success" : "Edit Fail"); break; }

                default:
                    context.Response.Write("Action参数错误"); break;
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
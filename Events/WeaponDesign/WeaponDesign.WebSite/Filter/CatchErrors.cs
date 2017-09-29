using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WeaponDesign.WebSite.Filter
{
    public class CatchErrors : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                object data = null;
                var obj = new { Code = 20, Message = "请求失败", Data = data };
                string json = JsonConvert.SerializeObject(obj);
                string jsonp = filterContext.HttpContext.Request["jsonpcallback"];
                string result = jsonp + "(" + json + ")";
                ContentResult contentResult = new ContentResult();
                contentResult.Content = result;
                contentResult.ContentEncoding = Encoding.UTF8;
                filterContext.Result = contentResult;
                filterContext.HttpContext.Response.End();
            }
            else
            {
                filterContext.HttpContext.Response.Write("<script>alert(\"请求失败\");</script>");
                string preUrl = filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri;
                filterContext.HttpContext.Response.Redirect(preUrl, true);
            }
        }
    }
}
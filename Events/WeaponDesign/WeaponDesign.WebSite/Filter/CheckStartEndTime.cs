using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeaponDesign.WebSite.Filter
{
    public class CheckStartEndTime : AuthorizeAttribute
    {
        //如果活动结束
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            DateTime siteEndTime = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["SiteEndTime"]);
             if (System.DateTime.Now >= siteEndTime)
            {
                object data = null;
                var obj = new { Code = 90, Message = "活动已结束", Data = data };

                ContentResult result = new ContentResult();
                string json = JsonConvert.SerializeObject(obj);
                string jsonp = filterContext.HttpContext.Request["jsonpcallback"];
                string returnString = jsonp + "(" + json + ")";
                result.Content = returnString;
                filterContext.Result = result;
            }
        }

    }
}
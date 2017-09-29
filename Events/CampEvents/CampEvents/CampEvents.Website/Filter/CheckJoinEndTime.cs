using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObjectUtil.Common;
using CampEvents.Database.Enums;

namespace CampEvents.Website.Filter
{
    public class CheckJoinEndTime : AuthorizeAttribute
    {
        //如果活动结束
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            DateTime siteStartTime = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["SiteStartTime"]);
            DateTime JoinEndTime = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["JoinEndTime"]);
            object data = null;
            ContentResult result = new ContentResult();
            if ((System.DateTime.Now >= JoinEndTime) || (System.DateTime.Now < siteStartTime))
            {
                var obj = new { Code = ErrorCode.EventExpired, Message = ErrorCode.EventExpired.ToDescription(), Data = data };
                string json = JsonConvert.SerializeObject(obj);
                string jsonp = filterContext.HttpContext.Request["jsonpcallback"];
                string returnString = jsonp + "(" + json + ")";
                result.Content = returnString;
                filterContext.Result = result;
            }
        }
    }
}
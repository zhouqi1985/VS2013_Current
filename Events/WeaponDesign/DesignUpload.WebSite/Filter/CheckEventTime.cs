using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponDesign.Database.Database;

namespace DesignUpload.WebSite.Filter
{
    public class CheckEventTime : ActionFilterAttribute
    {
        private readonly DateTime siteEndTime = CommonLibs.Common.AppSetting.GetDateTime("SiteEndTime");
        private readonly DateTime siteStartTime = CommonLibs.Common.AppSetting.GetDateTime("SiteStartTime");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            int eventtype = (int)filterContext.ActionParameters["EventType"];
            DesignEventType designeventtype = new DesignEventType();


            if (eventtype == 1)
            {
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
}
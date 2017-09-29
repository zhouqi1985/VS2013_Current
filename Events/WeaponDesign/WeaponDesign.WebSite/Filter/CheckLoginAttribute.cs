using AvatarSelector.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeaponDesign.WebSite.Models;


namespace WeaponDesign.WebSite.Filter
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Avatar avatar = filterContext.HttpContext.Session[SessionKey.AvatarKey] as Avatar;
            if (avatar == null || !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                object data = null;
                var obj = new { Code = 1, Message = "请登录后再操作", Data = data };

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
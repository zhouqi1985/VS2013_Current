using AvatarSelector.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CampEvents.Website.Models;
using ObjectUtil.Common;
using PageControllerBase;
using System.Security.Principal;
using CampEvents.Database.Enums;




namespace CampEvents.Website.Filter
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Avatar avatar = filterContext.HttpContext.Session[SessionKey.AvatarKey] as Avatar;
            IIdentity iden = filterContext.HttpContext.User.Identity;
            CookieData cookie = iden.ToUserCookie();
            if (avatar == null || !iden.IsAuthenticated || avatar.UserID != cookie.UserID)
            {
                object data = null;
                var obj = new { Code = ErrorCode.LoginError, Message = ErrorCode.LoginError.ToDescription(), Data = data };
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
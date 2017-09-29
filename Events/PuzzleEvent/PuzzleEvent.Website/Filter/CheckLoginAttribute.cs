using AvatarSelector.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PuzzleEvent.Website.Models;
using PuzzleEvent.Website.Enums;
using ObjectUtil.Common;



namespace PuzzleEvent.Website.Filter
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Avatar avatar = filterContext.HttpContext.Session[SessionKey.AvatarKey] as Avatar;
            if (avatar == null || !filterContext.HttpContext.User.Identity.IsAuthenticated)
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
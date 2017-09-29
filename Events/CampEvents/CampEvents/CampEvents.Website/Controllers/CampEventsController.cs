using AvatarSelector.Libs;
using Newtonsoft.Json;
using CampEvents.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ObjectUtil.Common;
using CommonLibs.Common;
using CampEvents.Database.Database;
using CampEvents.Database.Enums;

namespace CampEvents.Website.Controllers
{
    public class CampEventsController : PageControllerBase.BaseController
    {
        private readonly CampEvents.DAL.WCF.Client.ICampEventsServiceClient CampEventsBll = new DAL.WCF.Client.CampEventsServiceClient();
        private readonly MarsGameApi.WCF.Client.IMarsGameApiClient MarsGameApiBll = new MarsGameApi.WCF.Client.MarsGameApiClient();
        private readonly bool IsNotice = CommonLibs.Common.AppSetting.GetBool("IsNotice");
        private readonly string NoticeContent = CommonLibs.Common.AppSetting.GetString("NoticeContent");

        public ActionResult Index()
        {


            return View();
        }
        public ActionResult IsLogin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Jsonp(ErrorCode.LoginError, null);
            }

            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;

            if (avatar == null)
            {
                return Jsonp(ErrorCode.LoginError, null);

            }
            else if (avatar.UserID != UserID)
            {
                return Jsonp(ErrorCode.LoginError, null);
            }
            else
            {
                return Jsonp(ErrorCode.Succuess, null);
            }

        }

        public ActionResult Login(Avatar avatar)
        {
            string returnUrl = CommonLibs.Common.AppSetting.GetString("returnUrl");
            if (!User.Identity.IsAuthenticated || avatar == null)
            {
                return Redirect(returnUrl);
            }
            Session[SessionKey.AvatarKey] = avatar;
            return Redirect(returnUrl);

        }
        public ActionResult GetCampInfo()
        {
            List<CampConfig> CampInfo = CampEventsBll.GetCampInfo();
            return Jsonp(ErrorCode.Succuess, CampInfo);
        }

        [Filter.CheckLogin]
        public ActionResult GetUserInfo()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo() { UserId = UserCookie.UserID, AreaId = avatar.GameAreaID, AvatarId = avatar.AvatarID,LoginName=UserCookie.LoginName,AvatarName=avatar.AvatarName };
            List<RankListTop20> RankLists = CampEventsBll.GetRankListTop20(userinfo);
            ResultInfo resultinfo = CampEventsBll.GetUserInfo(userinfo);
            return Jsonp(resultinfo.Result, new { UserInfo = userinfo, ResultInfo = resultinfo, RankLists = RankLists });
        }

        [Filter.CheckLogin]
        [Filter.CheckJoinEndTime]
        public ActionResult UserChooseCamp(int CampId)
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo() { UserId = UserCookie.UserID, AreaId = avatar.GameAreaID, AvatarId = avatar.AvatarID, AvatarName = avatar.AvatarName, LoginName = UserCookie.LoginName, Sex = avatar.OriginalSex, CampId = CampId };
            ResultInfo resultinfo = CampEventsBll.UserChooseCamp(userinfo);
            return Jsonp(resultinfo.Result, null);
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult ExchangePointPacket(int ExchangeId)
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo() { UserId = UserCookie.UserID, AreaId = avatar.GameAreaID, AvatarId = avatar.AvatarID, AvatarName = avatar.AvatarName, LoginName = UserCookie.LoginName, Sex = avatar.OriginalSex, ExchangeID = ExchangeId };
            ResultInfo resultinfo = CampEventsBll.ExchangePointPacket(userinfo);
            if (resultinfo.Result == ErrorCode.Succuess)
            {
                if (resultinfo.IsNotice && IsNotice)
                {
                    string content = string.Format(NoticeContent, avatar.AvatarName, resultinfo.PacketName);
                    MarsGameApiBll.PublishBC(avatar.GameAreaID, content, "欲望囚牢活动");
                }
                return Jsonp(ErrorCode.Succuess, resultinfo);
            }
            return Jsonp(resultinfo.Result, resultinfo);
        }

        public ContentResult Jsonp(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            string jsonp = Request["jsonpcallback"];
            string result = jsonp + "(" + json + ")";
            return Content(result, "Jsonp", Encoding.UTF8);
        }

        public ContentResult Jsonp(int code, string message, object data)
        {
            var obj = new { Code = code, Message = message, Data = data };
            return Jsonp(obj);
        }

        public ContentResult Jsonp(ErrorCode errorcode, object data)
        {
            var obj = new { Code = (int)errorcode, Message = errorcode.ToDescription(), Data = data };
            return Jsonp(obj);
        }


    }
}

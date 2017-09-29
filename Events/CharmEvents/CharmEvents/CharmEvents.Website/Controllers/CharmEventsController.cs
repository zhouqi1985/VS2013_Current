using AvatarSelector.Libs;
using Newtonsoft.Json;
using CharmEvents.Website.Enums;
using CharmEvents.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ObjectUtil.Common;
using CommonLibs.Common;
using CharmEvents.Database.Database;

namespace CharmEvents.Website.Controllers
{
    public class CharmEventsController : PageControllerBase.BaseController
    {
        private readonly CharmEvents.DAL.WCF.Client.ICharmEventsServiceClient CharmEventsBll = new DAL.WCF.Client.CharmEventsServiceClient();
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


        public ActionResult GetRankList()
        {
            DataPage dp = new DataPage { PageIndex = 1, PageSize = 0 };
            List<RankList> RankLists = new List<RankList>();
            RankLists = CharmEventsBll.GetRankListList(ref dp);
            return Jsonp(ErrorCode.Succuess, new { RankLists = RankLists });
        }

        [Filter.CheckLogin]
        public ActionResult GetUserInfo()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo usersinfo = new UserInfo();
            usersinfo.AreaID = avatar.GameAreaID;
            usersinfo.UserId = avatar.UserID;
            usersinfo.AvatarId = avatar.AvatarID;
            List<ResultInfo> resultinfo = CharmEventsBll.GetUserInfo(usersinfo);
            var data = new { LoginName = UserCookie.LoginName, AvatarName = avatar.AvatarName, GameAreaID = avatar.GameAreaID, ResultInfo = resultinfo };
            return Jsonp(ErrorCode.Succuess, data);
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult UsersExchangePackets(int exchangeid)
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo();
            userinfo.UserId = avatar.UserID;
            userinfo.AreaID = avatar.GameAreaID;
            userinfo.AvatarId = avatar.AvatarID;
            userinfo.AvatarName = avatar.AvatarName;
            userinfo.LoginName = UserCookie.LoginName;
            userinfo.Sex = avatar.OriginalSex;
            userinfo.ExchangeID = exchangeid;
            ResultInfo resultinfo = CharmEventsBll.UsersExchangePackets(userinfo);
            switch (resultinfo.Result)
            {
                case 1:
                    return Jsonp(ErrorCode.Succuess, null);
                case -1:
                    return Jsonp(ErrorCode.ErrorRules, null);
                case -2:
                    return Jsonp(ErrorCode.NoPoints, null);
                case -3:
                    return Jsonp(ErrorCode.PacketLimit, null);
                case -4:
                    return Jsonp(ErrorCode.TypeLimit, null);
            }
            return Jsonp(ErrorCode.PacketFailed, null);
        }


        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult UsersDrawPackets()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo();
            userinfo.UserId = avatar.UserID;
            userinfo.AreaID = avatar.GameAreaID;
            userinfo.AvatarId = avatar.AvatarID;
            userinfo.AvatarName = avatar.AvatarName;
            userinfo.LoginName = UserCookie.LoginName;
            userinfo.Sex = avatar.OriginalSex;
            ResultInfo resultinfo = CharmEventsBll.UsersDrawPackets(userinfo);
            switch (resultinfo.Result)
            {
                case 1:
                    return Jsonp(ErrorCode.Succuess, new { ResultInfo = resultinfo });
                case -2:
                    return Jsonp(ErrorCode.NoPoints, null);
            }
            return Jsonp(ErrorCode.PacketFailed, null);
        }
        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult UsersLoginPacket()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserInfo userinfo = new UserInfo();
            userinfo.UserId = avatar.UserID;
            userinfo.AreaID = avatar.GameAreaID;
            userinfo.AvatarId = avatar.AvatarID;
            userinfo.AvatarName = avatar.AvatarName;
            userinfo.LoginName = UserCookie.LoginName;
            userinfo.Sex = avatar.OriginalSex;
            ResultInfo resultinfo = CharmEventsBll.UsersLoginPacket(userinfo);
            switch (resultinfo.Result)
            {
                case 1:
                    return Jsonp(ErrorCode.Succuess, new { ResultInfo = resultinfo });
                case -1:
                    return Jsonp(ErrorCode.RepeatedFailed, null);
            }
            return Jsonp(ErrorCode.PacketFailed, null);
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

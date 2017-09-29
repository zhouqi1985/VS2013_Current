using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ObjectUtil.Common;
using PuzzleEvent.Website.Enums;
using PuzzleEvent.Website.Models;
using PageControllerBase.Filter;
using PuzzleEvent.Database.Database;
using CommonLibs.Common;
using System.Web.Security;
using AvatarSelector.Libs;

namespace PuzzleEvent.Website.Controllers
{
    public class PuzzleEventController : PageControllerBase.BaseController
    {
        //
        // GET: /PuzzleEvent/

        private readonly PuzzleEvent.DAL.WCF.Client.PuzzleEventServiceClient PuzzleEventBll = new DAL.WCF.Client.PuzzleEventServiceClient();
        private readonly MarsGameApi.WCF.Client.IMarsGameApiClient marsApi = new MarsGameApi.WCF.Client.MarsGameApiClient();
        private readonly DateTime siteEndTime = CommonLibs.Common.AppSetting.GetDateTime("SiteEndTime");
        private readonly DateTime siteStartTime = CommonLibs.Common.AppSetting.GetDateTime("SiteStartTime");
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
                //Session[SessionKey.AvatarKey] = avatar;
                return Jsonp(ErrorCode.Succuess, UserCookie);
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


        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult GetUserInfo()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            //Session[SessionKey.AvatarKey] = avatar;
            UserPiecesTotal usepiecestotal = new UserPiecesTotal();
            usepiecestotal.AreaID = avatar.GameAreaID;
            usepiecestotal.UserId = avatar.UserID;
            List<UserPiecesTotal> userinfo = PuzzleEventBll.GetUserPiecesTotalAll(usepiecestotal);
            var data = new { UserID = UserCookie.UserID, LoginName = UserCookie.LoginName, GameAreaID = avatar.GameAreaID, AvatarName = avatar.AvatarName, userinfo = userinfo };
            return Jsonp(ErrorCode.Succuess, data);
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult GetPiecesReceive()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserSearch useinfo = new UserSearch();
            useinfo.AreaID = avatar.GameAreaID;
            useinfo.UserId = avatar.UserID;
            List<PuzzlePieces> UserPieces = new List<PuzzlePieces>();
            UserPieces = PuzzleEventBll.GetPiecesReceive(useinfo);
            return Jsonp(ErrorCode.Succuess, UserPieces);

        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult AddOrdinaryPacketReceive()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserSearch useinfo = new UserSearch();
            useinfo.AreaID = avatar.GameAreaID;
            useinfo.UserId = avatar.UserID;
            useinfo.Sex = avatar.OriginalSex;
            useinfo.AvatarID = avatar.AvatarID;
            int result = PuzzleEventBll.AddOrdinaryPacketReceive(useinfo);
            if (result == 1)
            { return Jsonp(ErrorCode.Succuess, null); }
            else
            { return Jsonp(ErrorCode.PacketFailed, null); }
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult AddExchangePacketReceive(int PacketId, int PuzzleTypeID)
        {
            bool IsNotice = false;
            string PacketName = string.Empty;
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            UserSearch useinfo = new UserSearch();
            useinfo.AreaID = avatar.GameAreaID;
            useinfo.UserId = avatar.UserID;
            useinfo.Sex = avatar.OriginalSex;
            useinfo.AvatarID = avatar.AvatarID;
            useinfo.PacketID = PacketId;
            useinfo.PuzzleTypeID = PuzzleTypeID;
            int result = PuzzleEventBll.AddExchangePacketReceive(useinfo, ref IsNotice, ref PacketName);
            if (result == 1)
            {
                //游戏公告
                if (IsNotice && CommonLibs.Common.AppSetting.GetBool("IsNotice"))
                {
                    string content = string.Format(CommonLibs.Common.AppSetting.GetString("NoticeContent"), avatar.AvatarName, PacketName);
                    marsApi.PublishBC(avatar.GameAreaID, content, "五周年纪念活动");
                }
                return Jsonp(ErrorCode.Succuess, null);
            }

            else
            { return Jsonp(ErrorCode.PacketFailed, null); }
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult PuzzleDraw(int DrawCount, int PuzzleTypeID)
        {
            int DrawConfig = CommonLibs.Common.AppSetting.GetInt32("DrawConfig");
            int DrawExtra = CommonLibs.Common.AppSetting.GetInt32("DrawExtra");
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            PuzzleDrawDetails useinfo = new PuzzleDrawDetails();

            useinfo.UserID = avatar.UserID;
            useinfo.LoginName = UserCookie.LoginName;
            useinfo.AreaID = avatar.GameAreaID;
            useinfo.AvatarID = avatar.AvatarID;
            useinfo.AvatarName = avatar.AvatarName;
            useinfo.DrawCount = DrawCount;
            useinfo.PuzzleTypeId = PuzzleTypeID;
            useinfo.Sex = avatar.OriginalSex;
            if (DrawCount == DrawConfig)
            {
                useinfo.ExtraCount = DrawExtra;
                useinfo.ActualCount = DrawCount + DrawExtra;
            }
            else
            {
                useinfo.ExtraCount = 0;
                useinfo.ActualCount = DrawCount;
            }

            List<PuzzleDrawDetails> DrawResult = PuzzleEventBll.PuzzleDraw(useinfo);
            if (DrawResult.Count > 0)
            {
                foreach (PuzzleDrawDetails drawdetail in DrawResult)
                {
                    if (drawdetail.IsNotice && CommonLibs.Common.AppSetting.GetBool("IsNotice"))
                    {
                        string content = string.Format(CommonLibs.Common.AppSetting.GetString("NoticeContent"), avatar.AvatarName, drawdetail.AwardName);
                        marsApi.PublishBC(avatar.GameAreaID, content, "五周年纪念活动");
                    }
                    if (drawdetail.PuzzleNotice && CommonLibs.Common.AppSetting.GetBool("IsNotice"))
                    {
                        string content = string.Format(CommonLibs.Common.AppSetting.GetString("NoticeContent"), avatar.AvatarName, drawdetail.AwardPuzzlePacket);
                        marsApi.PublishBC(avatar.GameAreaID, content, "五周年纪念活动");
                    }
                }
                return Jsonp(ErrorCode.Succuess, DrawResult);
            }
            return Jsonp(ErrorCode.DrawFailed, null);

        }



        //[Filter.CheckLogin]
        //[Filter.CheckStartEndTime]
        //public ActionResult PuzzleReceive(int PuzzleTypeID, int PuzzID)
        //{
        //    Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
        //    PuzzleDrawDetails useinfo = new PuzzleDrawDetails();

        //    useinfo.UserID = avatar.UserID;
        //    useinfo.LoginName = UserCookie.LoginName;
        //    useinfo.AreaID = avatar.GameAreaID;
        //    useinfo.AvatarID = avatar.AvatarID;
        //    useinfo.AvatarName = avatar.AvatarName;
        //    useinfo.PuzzleTypeId = PuzzleTypeID;
        //    useinfo.Sex = avatar.OriginalSex;
        //    useinfo.PuzzleID = PuzzID;
        //    useinfo.CreateTS = DateTime.Now;

        //    PuzzleDrawDetails DrawResult = PuzzleEventBll.PuzzleReceive(useinfo);
        //    if (!string.IsNullOrEmpty(DrawResult.AwardPuzzlePacket))
        //    {

        //        if (DrawResult.PuzzleNotice && CommonLibs.Common.AppSetting.GetBool("IsNotice"))
        //        {
        //            string content = string.Format(CommonLibs.Common.AppSetting.GetString("NoticeContent"), avatar.AvatarName, DrawResult.AwardPuzzlePacket);
        //            marsApi.PublishBC(avatar.GameAreaID, content, "五周年纪念活动");
        //        }

        //        return Jsonp(ErrorCode.Succuess, DrawResult);
        //    }
        //    return Jsonp(ErrorCode.DrawFailed, null);

        //}


        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult GetRedPacket()
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            int rs = PuzzleEventBll.GetRedPacket(avatar.UserID, avatar.GameAreaID);
            if (rs == 1)
            {
                return Jsonp(0, "领取成功！", null);
            }
            else if (rs == 2)
            {
                return Jsonp(2, "您昨天没有登录游戏不能领取！", null);
            }
            else if (rs == 3)
            {
                return Jsonp(2, "您今天已经领取过红包！", null);
            }
            else
            {
                return Jsonp(0, "领取失败！", null);
            }

        }


        public ActionResult GetRankListList()
        {
            RankList ranklist = new RankList();
            DataPage datapage = new DataPage() { PageIndex = 1, PageSize = 20 };

            List<RankList> lists = PuzzleEventBll.GetRankListList(ref datapage, ranklist);
            return Jsonp(ErrorCode.Succuess, lists);
        }


        //[Filter.CheckLogin]
        //[Filter.CheckStartEndTime]
        //public ActionResult TestDraw(int count,int pid)
        //{
        //    for (int i = 0; i < count; i++)
        //    { PuzzleDraw(10, pid); }
        //    return Jsonp(ErrorCode.Succuess, null);
        //}

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

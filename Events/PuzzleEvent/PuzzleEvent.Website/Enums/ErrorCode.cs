using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PuzzleEvent.Website.Enums
{
    public enum ErrorCode : int
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Succuess = 0,

        [Description("请登录后再操作")]
        LoginError = 1,

        [Description("活动已结束")]
        EventExpired = 90,
        [Description("领取礼包失败")]
        PacketFailed = 21,
        [Description("兑换失败")]
        DrawFailed = 31




    }
}
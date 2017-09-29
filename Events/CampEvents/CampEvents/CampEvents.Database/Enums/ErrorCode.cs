using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CampEvents.Database.Enums
{
    public enum ErrorCode : int
    {
        [Description("成功")]
        Succuess = 100,
        [Description("失败")]
        UnSuccessful = 0,
        [Description("请登录后再操作")]
        LoginError = 1,
        [Description("活动未开放")]
        EventExpired = 90,
        [Description("领取礼包失败")]
        PacketFailed = 21,
        [Description("重复领取")]
        RepeatedFailed = 22,
        [Description("不符合领取规则")]
        ErrorRules = 23,
        [Description("礼包兑换次数已达上限")]
        PacketLimit = 24,
        [Description("没有加入阵营")]
        NoCampFailed = 25,
        [Description("积分不足")]
        NoPoints = 31,
        [Description("种类兑换次数已达上限")]
        TypeLimit = 32,
        [Description("加入阵营失败")]
        JoinCampFailed = 41,
        [Description("已加入阵营")]
        RepeatJoinFailed = 42,
        [Description("该阵营已满")]
        CampLimitFailed = 43,
        [Description("阵营不存在")]
        CampErrorFailed = 44





    }
}
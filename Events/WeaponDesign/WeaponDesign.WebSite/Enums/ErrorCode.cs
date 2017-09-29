using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WeaponDesign.Website.Enums
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
        [Description("添加数据失败")]
        AddDataError = 2,
        [Description("更新数据失败")]
        UpdateDataError = 3,
        [Description("删除数据失败")]
        DeleteDataError = 4,
        [Description("添加评论失败")]
        AddCommentError = 5,
        [Description("点赞失败")]
        PraiseFailed = 6,
        [Description("重复点赞")]
        RepeatPraise = 7,
        [Description("活动未开放")]
        EventExpired = 90,
        [Description("图片验证通过")]
        PictureSuccess = 130,
        [Description("图片大小错误")]
        PictureContentLengthError = 131,
        [Description("图片格式错误")]
        PictureFormatError = 132,
        [Description("图片尺寸错误")]
        PictureSizeError = 133,
        [Description("名称非法或超过50个字符")]
        NameError = 11,
        [Description("联系方式填写非法或超过50个字符")]
        ContractError = 16,
        [Description("描述非法或超过200个字符")]
        DescError = 12,
        [Description("类型选择非法")]
        TypeError = 14,
        [Description("图片不能为空")]
        PictureEmpty = 17,
        [Description("修改用户与创建用户不同")]
        UsersDifferent = 15,
        [Description("评论内容非法或不能超过200字符")]
        CommentError = 13,
        [Description("姓氏非法或不能超过10字符")]
        FirstNameError = 18,
        [Description("性别非法")]
        GenderError = 19




    }
}
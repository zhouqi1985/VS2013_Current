/**
 * Created by tengxiaolei on 2015/12/11.
 */
var weap = {
    $islogin: 1,
    i: 0,
    showLength: 30,  //初始展示图片数量
    msgLeng: 0,
    showPraise: [],  //赞
    SpicAddress: [],  //图片地址
    weaponID: [],  //武器 id
    weaponName: [],  //武器名称
    weaType: [],  //武器类型
    avatarName: [], //角色名
    modify: function (wid) {
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/GetWeaponList?wid=' + wid,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {

                var weaponName = data.Data.WeaponName;  //武器名
                var weaponDesc = data.Data.WeaponDesc;  //简介
                var $imgUrl = data.Data.PicAddress;  //图片
                //var $ShowPraise = data.Data.ShowPraise;  //图片
                var $WeaType = data.Data.WeaType;  //类型
                $('.fileText').val(weaponName);
                $('.uploadArea').val(weaponDesc);
                $('.modiy_img').attr("src", "http://event.zygames.com/qqsm/201512/WeaponDesign/" + $imgUrl);

            }
        });
    },
    documentWidth: function () { //动态窗口大小调整
        var $dwidth = $(document).width();
        $(".proImg").outerWidth($dwidth - 460);
    },
    delWeapon: function (wid) { // 删除作品
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/DelWeapon?WeaponID=' + wid,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                alert(data.Code);
                if (data.Code == 0) {
                    alert("关闭成功");
                }
            }
        });
    },
    showWeaponList: function () {  //个人作品
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: "http://event.zygames.com/qqsm/201512/WeaponDesign/ShowWeaponList",
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var $data = data.Data;
                var $htmls = "";
                $($data).each(function (a) {
                    $htmls += "<tr>" +
                        "<td class='td1'>" + $data[a].WeaponID + "</td>" +
                        "<td class='td2'><img src='http://event.zygames.com/qqsm/201512/WeaponDesign" + $data[a].SpicAddress + "' alt=''/></td>" +
                        "<td class='td3'>" +
                        "<h2>" + $data[a].WeaponName + "</h2>" +
                        "<p class='typeOfwq'>" + $data[a].WeaType + "</p>" +
                        "<div class='myProDesc'><div class='heartLine'>" +
                        "<div class='zan'>" + $data[a].ShowPraise + "</div>" +
                        "<div class='talk'>评论：<span>" + $data[a].TotalCom + "</span></div>" +
                        "</div>" +
                        "</div>" +
                        "</td>";
                    switch ($data[a].StatusType) {
                        case "已审核":
                            $htmls += "<td class='td4'><span class='type1'>已审核</span></td>" +
                                "<td class='td5'>" +
                                "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                                "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                                "</td>" +
                                "</tr>";
                            break;
                        case "已关闭":
                            $htmls += "<td class='td4'><span class='type2'>已关闭</span></td>" +
                                "<td class='td5'>" +
                                "</td>" +
                                "</tr>";
                            break;
                        case "未审核":
                            $htmls += "<td class='td4'><span class='type2'>待审核</span><p class='type2'>审核通过，作品上线后作者将无法修改</p></td>" +
                                "<td class='td5'>" +
                                "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                                "<a target='_blank' href='http://localhost:63342/design/modify.html?weaponID=" + $data[a].WeaponID + "' class='btn2'>修改作品</a>" +
                                "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                                "</td>" +
                                "</tr>";
                            break;
                        case "审核不通过":
                            $htmls += "<td class='td4'><span class='type2'>审核不通过</span><p>管理员留言：</p><p class='type2'>" + $data[a].Reason + "</p></td>" +
                                "<td class='td5'>" +
                                "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                                "<a target='_blank' href='http://localhost:63342/design/modify.html?weaponID=" + $data[a].WeaponID + "' class='btn2'>修改作品</a>" +
                                "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                                "</td>" +
                                "</tr>";
                            break;
                        default :
                            $htmls += "<td class='td4'><span class='type2'></span><p>管理员留言123：</p><p class='type2'>" + $data[a].Reason + "</p></td>" +
                                "<td class='td5'>" +
                                "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                                "<a target='_blank' href='http://localhost:63342/design/modify.html?weaponID=" + $data[a].WeaponID + "' class='btn2'>修改作品</a>" +
                                "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                                "</td>" +
                                "</tr>";
                    }

                    //if ($data[a].StatusType == "已审核") {
                    //    $statusType = "<span class='type1'>已审核</span>";
                    //    $htmls+="<td class='td5'>" +
                    //        "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                    //        "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                    //        "</td>" +
                    //        "</tr>";
                    //}
                    //if ($data[a].StatusType == "已关闭") {
                    //    $statusType = "<span class='type2'>已关闭</span>";
                    //    $htmls+="<td class='td5'>" +
                    //        "</td>" +
                    //        "</tr>";
                    //}
                    //if ($data[a].StatusType == "未审核") {
                    //    $statusType = "<span class='type2'>待审核</span><p class='type2'>审核通过，作品上线后作者将无法修改</p>";
                    //    $htmls+="<td class='td5'>" +
                    //        "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                    //        "<a target='_blank' href='http://localhost:63342/design/modify.html?weaponID=" + $data[a].WeaponID + "' class='btn2'>修改作品</a>" +
                    //        "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                    //        "</td>" +
                    //        "</tr>";
                    //}
                    //if ($data[a].StatusType == "审核不通过") {
                    //    $statusType = "<span class='type2'>审核不通过</span><p>管理员留言：</p><p class='type2'>" + $data[a].Reason + "</p>";
                    //    $htmls+="<td class='td5'>" +
                    //        "<a target='_blank' href='http://localhost:63342/design/proShow.html?weaponID=" + $data[a].WeaponID + "' class='btn1'>查看作品</a>" +
                    //        "<a target='_blank' href='http://localhost:63342/design/modify.html?weaponID=" + $data[a].WeaponID + "' class='btn2'>修改作品</a>" +
                    //        "<a target='_blank' href='javascript:;' class='btn3' onclick='weap.delWeapon(" + $data[a].WeaponID + ")'>关闭作品</a>" +
                    //        "</td>" +
                    //        "</tr>";
                    //}


                });
                $(".myProTbale").html($htmls);

            }
        });
    },
    getWeaponList: function (wid) {    //武器信息
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/GetWeaponList?wid=' + wid,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var weaponName = data.Data.WeaponName;  //武器名
                var weaponDesc = data.Data.WeaponDesc;  //简介
                var $imgUrl = data.Data.PicAddress;  //图片
                var $ShowPraise = data.Data.ShowPraise;  //图片
                var $author = data.Data.AvatarName; //作者
                var $AreaName = data.Data.AreaName; //区服
                var $WeaType = data.Data.WeaType;  //类型

                $(".proImg").html("<div class='zan1' onclick='weap.addHeart(" + wid + ",this)'>" + $ShowPraise + "</div><img src='http://event.zygames.com/qqsm/201512/WeaponDesign" + $imgUrl + "' alt=''/>");
                $(".pro_msg").html("<h2>" + weaponName + "</h2><p class='pro_type'>" + $WeaType + "</p><p class='pro_author'>" + $author + "/" + $AreaName + "</p><p class='pro_desc'><span>作品描述：</span>" + weaponDesc + "</p>")
            }
        });
    },
    addComment: function (weaponID, comment, $url) { //添加评论
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/AddComment?weaponID=' + weaponID + "&comment=" + comment,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var $isok = data.Code;
                if ($isok == 0) {
                    alert("提交成功。")
                }
                if ($isok == 1) {
                    weap.islogin($url);
                }
            }
        });
    },
    showCommentsList: function (weapId, pageIndex, pageSize) {  // 留言列表
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/ShowCommentsList?wid=' + weapId + "&PageIndex=" + pageIndex + "&PageSize=" + pageSize,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                //var code = data.Code;
                var $data = data.Data.List;
                var pageCount = data.Data.Page.PageCount;
                var rowCount = data.Data.Page.RowCount; //总条数
                var htmls = "", pages = "";
                $(".commentList").empty();
                $(".pageNum").empty();
                $($data).each(function (i) {
                    htmls += "<li>" +
                        "<h2>" + $data[i].AvatarName + "</h2>" +
                        "<p class='floorMsg'><span>" + $data[i].RowID + "楼</span>来自" + $data[i].AreaName + "的玩家</p>" +
                        "<p class='commentMsg'>" + $data[i].Comments + "</p>" +
                        "</li>";
                });
                $(htmls).appendTo(".commentList");
                //分页
                if (rowCount > 0) {
                    for (var j = 0; j < pageCount; j++) {
                        pages += "<a href='javascript:void(0);' onclick='weap.showCommentsList(" + weapId + "," + (j + 1) + ",8)'>" + (j + 1) + "</a>";
                    }
                    $(pages).appendTo(".pageNum");
                    $(".pageNum a").eq(data.Data.Page.PageIndex - 1).addClass("on");
                }

            }
        });
    },
    islogin: function ($url) { //判断是否登录
        $.ajax({
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/IsLogin',
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var code = data.Code;
                if (code == 0) {
                    weap.$islogin = 0;
                    return 0;
                }
                if (code != 0) {
                    startPop_fmAvatar('http://event.zygames.com/qqsm/201512/WeaponDesign/Login?returnUrl=' + $url, '_top', 1)
                }

            }
        });
    },
    getMsg: function () {   //获取瀑布列表
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/ShowAllWeaponList',
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var code = data.Code;
                var listMsg = data.Data;
                weap.msgLeng = listMsg.length;
                if (code === 0) {
                    $(listMsg).each(function (i) {
                        weap.showPraise.push(listMsg[i].ShowPraise);
                        weap.SpicAddress.push(listMsg[i].SpicAddress);
                        //weap.SpicAddress.push(listMsg[i].PicAddress);
                        weap.weaponID.push(listMsg[i].WeaponID);
                        weap.weaponName.push(listMsg[i].WeaponName);
                        weap.weaType.push(listMsg[i].WeaType);
                        weap.avatarName.push(listMsg[i].AvatarName);
                    });
                }
                //初始化页面；
                weap.innerMsg();
            },
            error: function () {
                console.log("数据加载错误，CODE:001");
            }
        });
    },
    innerMsg: function (scrollMove) {  //插入瀑布
        if (scrollMove === 1) {
            weap.showLength = (weap.showLength + 15 > weap.msgLeng ? weap.msgLeng : weap.showLength + 15);
        } else {
            weap.showLength = weap.showLength > weap.msgLeng ? weap.msgLeng : weap.showLength;
        }

        for (weap.i; weap.i < weap.showLength; weap.i++) {//每次加载时模拟随机加载图片
            var html = "";
            html = "<li>" +
                "<div class='zan' onclick='weap.addHeart(" + weap.weaponID[weap.i] + ",this)'>" + weap.showPraise[weap.i] + "</div>" +
                "<a href='proShow.html?weaponID=" + weap.weaponID[weap.i] + "'><img src ='http://event.zygames.com/qqsm/201512/WeaponDesign/" + weap.SpicAddress[weap.i] + "'></a> " +
                "<p class='wqname'><label class='weapId'>" + weap.weaponID[weap.i] + "</label>：<span>" + weap.weaponName[weap.i].substring(1, 7) + "</span></p>" +
                "<div class='wqMsg'>" +
                "<p class='wqType'>" + weap.weaType[weap.i] + "</p>" +
                "<p class='wqMaster'>" + weap.avatarName[weap.i] + "</p>" +
                "</div>" +
                "</li>";
            $minUl = weap.getMinUl();
            $minUl.append(html);
        }
    },
    getMinUl: function () { //每次获取最短的ul,将图片放到其后
        var $arrUl = $("#pubu .col");
        $minUl = $arrUl.eq(0);
        $arrUl.each(function (index, elem) {
            if ($(elem).height() < $minUl.height()) {
                $minUl = $(elem);
            }
        });
        return $minUl;
    },
    addHeart: function (weapId, $this) {  //点赞动作
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/AddPraise?WeaponID=' + weapId,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                if (data.Code == 0) {
                    $.tipsBox({
                        obj: $($this),
                        str: "+1",
                        callback: function () {

                        }
                    });
                    //数字+1
                    var heartNum = parseInt($($this).html()) + 1;
                    $($this).html(heartNum);

                } else {
                    alert(data.Message);
                }
            },
            error: function () {
                console.log("数据加载错误，CODE:002");
            }
        });
    }
};

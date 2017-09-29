/**
 * Created by tengxiaolei on 2015/12/11.
 */

$(function () {
    weap.getMsg();
    //weap.innerMsg();
    var $minUl;
    $(window).on("scroll", function () {
        $minUl = weap.getMinUl();
        if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
            //当最短的ul的高度比窗口滚出去的高度+浏览器高度大时加载新图片
            weap.innerMsg(1);
        }
    });
});

//var showPraise = [],  //赞
//    SpicAddress = [],  //图片地址
//    weaponID = [],  //武器 id
//    weaponName = [],  //武器名称
//    weaType = [],  //武器类型
//    avatarName = []; //角色名
//var i = 0, showLength = 10, msgLeng = 0;
var weap = {
    i:0,
    showLength :9,  //初始展示图片数量
    msgLeng: 0,
    showPraise :[],  //赞
    SpicAddress:[],  //图片地址
    weaponID:[],  //武器 id
    weaponName : [],  //武器名称
    weaType :[],  //武器类型
    avatarName : [], //角色名
    getMsg: function () {
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            //url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/ShowAllWeaponList',
            //dataType: 'jsonp',
            //jsonp: "jsonpcallback",
            url: 'resource/js/test.json',
            dataType: 'json',
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                var code = data.Code;
                var listMsg = data.Data;
                weap.msgLeng = listMsg.length;
                if (code === 0) {
                    weap.showPraise = [];  //赞
                    weap.SpicAddress = [];  //图片地址
                    weap.weaponID = [];  //武器 id
                    weap.weaponName = [];  //武器名称
                    weap.weaType = [];  //武器类型
                    weap.avatarName = []; //角色名
                    $(listMsg).each(function (i) {
                        weap.showPraise.push(listMsg[i].ShowPraise);
                        //SpicAddress.push(listMsg[i].SpicAddress);
                        weap.SpicAddress.push(listMsg[i].PicAddress);
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
                alert("数据加载错误，CODE:001");
            }
        });
    },
    innerMsg: function (scrollMove) {
        if (scrollMove === 1) {
            weap.showLength = (weap.showLength + 5 > weap.msgLeng ? weap.msgLeng : weap.showLength + 5);
        }else{
            weap.showLength =weap.showLength  > weap.msgLeng ? weap.msgLeng : weap.showLength;
        }

        for (weap.i; weap.i < weap.showLength; weap.i++) {//每次加载时模拟随机加载图片
            var html = "";
            html = "<li>" +
                "<div class='zan' onclick='weap.addHeart(" + weap.weaponID[weap.i] + ",this)'>" + weap.showPraise[weap.i] + "</div>" +
                "<img src ='http://event.zygames.com/qqsm/201512/WeaponDesign/" + weap.SpicAddress[weap.i] + "'>" +
                "<p class='wqname'><label class='weapId'>" + weap.weaponID[weap.i] + "</label>：<span>" + weap.weaponName[weap.i] + "</span></p>" +
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
    addHeart: function (weapId, $this) {
        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: 'http://event.zygames.com/qqsm/201512/WeaponDesign/AddPraise?WeaponID=' + weapId,
            dataType: 'jsonp',
            jsonp: "jsonpcallback",
            async: false, //默认设置下，所有请求均为异步请求。
            success: function (data) {
                if (data.Code ==0) {
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
                alert("数据加载错误，CODE:002");
            }
        });
    }
};

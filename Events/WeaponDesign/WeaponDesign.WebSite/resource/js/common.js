/**
 * Created by tengxiaolei on 2015/9/21.
 */
$("<script language=javascript src='http://cdn1.zygames.com/Public/PopupLogin/js/pup-avatarSelector.js'></script>").appendTo("head");
//切换
function changeBOx(a, ona, b, onb) {
    var _index = 0;
    var _a = $("." + a);
    var _b = $("." + b);
    _a.click(function () {
        _a.removeClass(ona);
        $(this).addClass(ona);
        _index = $(this).index();
        _b.removeClass(onb);
        _b.eq(_index).addClass(onb);
    })
}


$(function () {
    //上传图片路径
    $(".upfile").change(function () {
        $("a.fileText").html($(".upfile").val());
    });

    //活动规则显示
    var hdrule = "<div class='hdrule'>" +
        "<h2>活动规则：</h2>" +
        "<p>1、玩家可以对所有枪械（狙击枪、突击枪、冲锋枪等）进行自由创作。</p>" +
        "<p>2、参与活动的玩家将自己的武器设计稿上传，手绘稿、电子稿皆可，形式不限</p>" +
        "<p>3、文件格式：支持 Jpg/Jpeg、gif、png 格式的图片文件，文件大小：不大于2MB；图片尺寸：不大于2000px * 2000px）。</p>" +
        "<p>4、参与活动的作品必须包含武器名称与武器类型，玩家可以以纯文字描述武器作品，并以默认图片参与活动。</p>" +
        "<p>5、所有玩家可为自己喜欢的作品点赞，每幅作品每位玩家仅能点赞一次。</p>" +
        "<p>6、玩家上传作品后将会进行审核，审核时间为每个工作日的10:00-18:00。</p>" +
        "<p>7、不得上传涉及低俗、暴力、黄色等内容，否则取消活动资格。</p>" +
        "<p>8、本次活动最终解释权归《全球使命2》运营团队所有。</p>" +
        "</div>";
    $(hdrule).appendTo(".nav2");
    $(".nav2").hover(function(){
        $(".hdrule").show();
    },function(){
        $(".hdrule").hide();
    })



});
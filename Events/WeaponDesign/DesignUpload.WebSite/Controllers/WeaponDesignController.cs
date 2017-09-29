using AvatarSelector.Libs;
using CommonLibs.Common;
using Newtonsoft.Json;
using PageControllerBase.Filter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WeaponDesign.Database.Database;
using WeaponDesign.Website.Enums;
using DesignUpload.WebSite.Filter;
using DesignUpload.WebSite.Models;
using ObjectUtil.Common;

namespace DesignUpload.WebSite.Controllers
{
    [CatchErrors]
    public class WeaponDesignController : PageControllerBase.BaseController
    {

        private WeaponDesign.DAL.WeaponDesignDAL dal = new WeaponDesign.DAL.WeaponDesignDAL();
        private readonly WeaponDesign.DAL.WCF.Client.WeaponDesignServiceClient WeapDesignBll = new WeaponDesign.DAL.WCF.Client.WeaponDesignServiceClient();
        private readonly DateTime siteEndTime = CommonLibs.Common.AppSetting.GetDateTime("SiteEndTime");
        private readonly DateTime siteStartTime = CommonLibs.Common.AppSetting.GetDateTime("SiteStartTime");
        private readonly string allowPicExtension = CommonLibs.Common.AppSetting.GetString("AllowPicExtension");
        private readonly string picturedir = CommonLibs.Common.AppSetting.GetString("PicturePath");
        private readonly string spicturedir = CommonLibs.Common.AppSetting.GetString("SPicturePath");
        private readonly string errorurl = CommonLibs.Common.AppSetting.GetString("UploadErrorUrl");
        private readonly string successurl = CommonLibs.Common.AppSetting.GetString("UploadSuccessUrl");
        private readonly Int64 contentlength = CommonLibs.Common.AppSetting.GetInt32("ContentLength") * 1024 * 1024;


        public ActionResult GetWeaponList(int wid)
        {
            WeaponList weaponlist = new WeaponList();
            weaponlist.WeaponID = wid;
            WeaponList lists = WeapDesignBll.GetWeaponList(weaponlist);
            return Jsonp(ErrorCode.Succuess, lists);
        }

        public ActionResult ShowWeaponList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Jsonp(ErrorCode.LoginError, null);

            }
            else
            {
                WeaponUserList weaponuser = new WeaponUserList();
                weaponuser.UserID = UserCookie.UserID;
                weaponuser.Sort = 0;
                List<WeaponUserList> lists = WeapDesignBll.GetWeaponUserList(weaponuser);
                return Jsonp(ErrorCode.Succuess, lists);
            }
        }

        public ActionResult ShowAllWeaponList(int sort = 0)
        {
            WeaponUserList weaponuser = new WeaponUserList();
            weaponuser.UserID = 0;
            weaponuser.StatusID = 1;
            weaponuser.Sort = sort;
            List<WeaponUserList> lists = WeapDesignBll.GetWeaponUserList(weaponuser);

            return Jsonp(ErrorCode.Succuess, lists);

        }

        public ActionResult ShowCommentsList(int wid, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 20;

            WeaponComments weaponcomments = new WeaponComments();
            weaponcomments.WeaponID = wid;
            DataPage datapage = new DataPage() { PageIndex = pageIndex.Value, PageSize = pageSize.Value };

            List<WeaponComments> lists = WeapDesignBll.GetWeaponCommentsList(ref datapage, weaponcomments);
            var data = new { List = lists, Page = datapage };
            return Jsonp(ErrorCode.Succuess, data);
        }


        public WeaponList Upload(HttpPostedFileBase file)
        {

            string fileEx = System.IO.Path.GetExtension(file.FileName);
            string fileName = System.IO.Path.GetFileName(file.FileName);
            string savename = Guid.NewGuid().ToString() + fileEx;

            string picpath = System.IO.Path.Combine(picturedir, DateTime.Now.ToString("yyMMddHHmmss") + "_" + savename);
            string spicpath = System.IO.Path.Combine(spicturedir, DateTime.Now.ToString("yyMMddHHmmss") + "_spic_" + savename);
            string picdir = Server.MapPath("~/Upload/Pics");
            string spicdir = Server.MapPath("~/Upload/SPics");

            if (!Directory.Exists(picdir))//判断上传文件夹是否存在，若不存在，则创建
            {
                Directory.CreateDirectory(picdir);//创建文件夹
            }

            if (!Directory.Exists(spicdir))//判断上传文件夹是否存在，若不存在，则创建
            {
                Directory.CreateDirectory(spicdir);//创建文件夹
            }

            string picfull = System.IO.Path.Combine(picdir, DateTime.Now.ToString("yyMMddHHmmss") + "_" + savename);
            string spicfull = System.IO.Path.Combine(spicdir, DateTime.Now.ToString("yyMMddHHmmss") + "_spic_" + savename);
            System.Drawing.Image pic = System.Drawing.Image.FromStream(file.InputStream);
            WeaponList weaponlist = new WeaponList();
            weaponlist.Length = pic.Width;
            weaponlist.Width = pic.Height;
            weaponlist.PicAddress = picpath;
            weaponlist.SpicAddress = spicpath;
            file.SaveAs(picfull);
            ObjectUtil.Common.ImageHelper.MakeThumbnail(picfull, spicfull, 0, 210, "H", "jpg");
            System.Drawing.Image spic = Image.FromFile(spicfull);
            weaponlist.SLength = spic.Width;
            weaponlist.SWidth = spic.Height;
            return weaponlist;

        }

        public ErrorCode CheckPicture(HttpPostedFileBase file)
        {
            ErrorCode errorcode = new ErrorCode();
            string fileEx = System.IO.Path.GetExtension(file.FileName);
            if (file.ContentLength > contentlength)
            {
                return errorcode = ErrorCode.PictureContentLengthError;        //图片不能大于2MB
            }

            string[] apeArr = allowPicExtension.Split(',');
            if (!apeArr.Contains(fileEx.ToLower()))
            {
                return errorcode = ErrorCode.PictureFormatError;        //图片格式应为jpg,jpeg,gif,png  
            }
            System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream);
            int len = image.Width;
            int wid = image.Height;
            if (len < 640 || len > 2000 || wid < 480 || wid > 2000)
            {
                errorcode = ErrorCode.PictureSizeError;             //图片尺寸为640*480-2000*2000
            }
            else
            {
                errorcode = ErrorCode.PictureSuccess;
            }
            return errorcode;
        }

        //[HttpPost]
        // GET: WeaponDesign
        [Filter.CheckStartEndTime]
        public ActionResult AddWeapon(WeaponList model, HttpPostedFileBase file)
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            if (avatar == null || !User.Identity.IsAuthenticated || avatar.UserID != UserID)
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.LoginError);
                return Jsonp(ErrorCode.LoginError, null);
            }
            if (!CheckText(model.WeaponName, 50, false))
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.NameError);
                return Jsonp(ErrorCode.NameError, null);
            }
            if (!CheckText(model.WeaponDesc, 200, true))
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.DescError);
                return Jsonp(ErrorCode.DescError, null);
            }
            if (!CheckText(model.WeaType, 10, false))
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.TypeError);
                return Jsonp(ErrorCode.TypeError, null);
            }
            WeaponList weaponlist = new WeaponList();
            weaponlist.WeaponName = model.WeaponName.Trim();
            if (!(model.WeaponDesc == null))
            { weaponlist.WeaponDesc = model.WeaponDesc.Trim(); }
            weaponlist.WeaType = model.WeaType.Trim();
            weaponlist.TruePraise = 0;
            weaponlist.ShowPraise = 0;
            weaponlist.StatusID = (int)StatusIDEnum.StatusIDEnum.NoApprove;
            if (file == null)
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.PictureEmpty);
                return Jsonp(ErrorCode.PictureEmpty, null);

            }
            else
            {
                if (!CheckPicture(file).Equals(ErrorCode.PictureSuccess))
                {
                    Response.Redirect(errorurl + "?code=" + (int)CheckPicture(file));
                    return Jsonp(CheckPicture(file), null);
                }
                else
                {
                    WeaponList weaponlistpic = Upload(file);
                    weaponlist.Length = weaponlistpic.Length;
                    weaponlist.Width = weaponlistpic.Width;
                    weaponlist.SLength = weaponlistpic.SLength;
                    weaponlist.SWidth = weaponlistpic.SWidth;
                    weaponlist.PicAddress = weaponlistpic.PicAddress;
                    weaponlist.SpicAddress = weaponlistpic.SpicAddress;
                }
            }
            weaponlist.AreaID = avatar.GameAreaID;
            weaponlist.AvatarID = avatar.AvatarID;
            weaponlist.UserID = UserCookie.UserID;
            weaponlist.CreateTS = DateTime.Now;
            weaponlist.UpdateTS = DateTime.Now;
            int result = WeapDesignBll.AddWeaponList(weaponlist);
            if (result > 0)
            {
                Response.Redirect(successurl);
                return Jsonp(ErrorCode.Succuess, null);
            }
            else
            {
                Response.Redirect(errorurl + "?code=" + (int)ErrorCode.AddDataError);
                return Jsonp(ErrorCode.AddDataError, null);
            }

        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        // GET: WeaponDesign
        public ActionResult EditWeapon(WeaponList model)
        {
            if (!CheckText(model.WeaponName, 50, false))
            {
                return Jsonp(ErrorCode.NameError, null);
            }
            if (!CheckText(model.WeaponDesc, 200, false))
            {
                return Jsonp(ErrorCode.DescError, null);
            }
            if (!CheckText(model.WeaType, 10, false))
            {
                return Jsonp(ErrorCode.TypeError, null);
            }
            WeaponList weaponuser = new WeaponList();
            weaponuser.WeaponID = model.WeaponID;
            WeaponList lists = WeapDesignBll.GetWeaponList(weaponuser);
            if (!(lists.UserID == UserCookie.UserID))
            {
                return Jsonp(ErrorCode.UsersDifferent, null);
            }

            WeaponList weaponlists = new WeaponList();
            weaponlists.WeaponID = model.WeaponID;
            weaponlists.WeaponName = model.WeaponName.Trim();
            if (!(model.WeaponDesc == null))
            { weaponlists.WeaponDesc = model.WeaponDesc.Trim(); }
            weaponlists.WeaType = model.WeaType.Trim();
            weaponlists.UpdateTS = DateTime.Now;

            int result = WeapDesignBll.UpdateWeaponList(weaponlists);
            if (result > 0)
            {
                return Jsonp(ErrorCode.Succuess, null);
            }
            else
            {
                return Jsonp(ErrorCode.UpdateDataError, null);
            }


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

        public ActionResult Login(Avatar avatar, string returnUrl)
        {
            if (!User.Identity.IsAuthenticated || avatar == null)
            {
                return Redirect(returnUrl);
            }

            Session[SessionKey.AvatarKey] = avatar;
            UserList user = new UserList();
            user.UserID = avatar.UserID;
            user.AvatarID = avatar.AvatarID;
            user.AvatarName = avatar.AvatarName;
            user.AreaID = avatar.GameAreaID;
            user.Sex = avatar.Sex.ToString();
            user.LoginName = UserCookie.LoginName;
            int result = WeapDesignBll.AddUserList(user);
            if (result > 0 || result == -1)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Jsonp(ErrorCode.AddDataError, null);
            }


        }


        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult DelWeapon(int WeaponID)
        {
            WeaponList weaponuser = new WeaponList();
            weaponuser.WeaponID = WeaponID;
            WeaponList lists = WeapDesignBll.GetWeaponList(weaponuser);
            if (!(lists.UserID == UserCookie.UserID))
            { return Jsonp(ErrorCode.UsersDifferent, null); }
            WeaponList model = new WeaponList();
            model.WeaponID = WeaponID;
            model.StatusID = (int)StatusIDEnum.StatusIDEnum.Deleted;
            model.UpdateTS = DateTime.Now;
            int result = WeapDesignBll.UpdateWeaponStatus(model);
            if (result > 0)
            {
                return Jsonp(ErrorCode.Succuess, null);
            }
            else
            {
                return Jsonp(ErrorCode.DeleteDataError, null);
            }
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult AddComment(int weaponID, String comment)
        {
            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            CommentsList comlist = new CommentsList();
            comlist.WeaponID = weaponID;
            comlist.Comments = comment;
            comlist.CreateTS = DateTime.Now;
            comlist.AreaID = avatar.GameAreaID;
            comlist.AvatarID = avatar.AvatarID;

            if (!CheckText(comlist.Comments, 200, false))
            {
                return Jsonp(ErrorCode.CommentError, null);
            }
            else
            {
                int result = WeapDesignBll.AddCommentsList(comlist);
                if (result > 0)
                {
                    return Jsonp(ErrorCode.Succuess, null);
                }
                else
                {
                    return Jsonp(ErrorCode.AddCommentError, null);
                }

            }
        }

        [Filter.CheckLogin]
        [Filter.CheckStartEndTime]
        public ActionResult AddPraise(int weaponID)
        {

            Avatar avatar = Session[SessionKey.AvatarKey] as Avatar;
            PraiseLog pralog = new PraiseLog();
            pralog.PraiseIP = Request.UserHostAddress;
            pralog.WeaponID = weaponID;
            pralog.PraiseNumber = 1;
            pralog.Source = 0;
            pralog.CreateTS = DateTime.Now;
            pralog.AreaID = avatar.GameAreaID;
            pralog.AvatarID = avatar.AvatarID;
            pralog.UserID = avatar.UserID;
            int result = WeapDesignBll.AddPraiseLog(pralog);
            if (result > 0 || result == -3)
            {
                return Jsonp(ErrorCode.Succuess, result);
            }
            else if (result == -2)
            {
                return Jsonp(ErrorCode.RepeatPraise, null);
            }
            else
            {
                return Jsonp(ErrorCode.PraiseFailed, null);
            }
        }


        public ActionResult GetAvatar()
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
                Dictionary<string, string> avatarinfo = new Dictionary<string, string>();
                avatarinfo.Add("LoginName", UserCookie.LoginName);
                avatarinfo.Add("AvatarName", avatar.AvatarName);
                avatarinfo.Add("GameAreaId", avatar.GameAreaID.ToString());
                return Jsonp(ErrorCode.Succuess, avatarinfo);
            }
        }
        public ActionResult aaTest()
        {
            //FormsAuthentication.SetAuthCookie("test0098".TrimEnd(), true, FormsAuthentication.FormsCookiePath);

            //return Jsonp(0, "请登录后再操作", Request.UserHostAddress);

            return View();

        }


        public bool CheckText(string text, int len, bool empty)
        {
            if (text == null)
            {
                if (empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            string realtext = text.Trim();
            if (realtext == null || realtext.Length < 1)
            {
                if (empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (CommonLibs.Common.StringExtension.HasHtml(realtext))
            {
                return false;
            }
            else if (realtext.Length > len)
            {
                return false;
            }
            else
            {
                return true;
            }

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
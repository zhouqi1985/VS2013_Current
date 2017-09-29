using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponDesign.Database.Database;
using AdminPage.BaseController;
using ObjectUtil.Dictionary;
using System.IO;
using System.Net;
using System.Drawing;


namespace WeaponDesign.AdminWebsite.Controllers
{
    [AdminPage.Filter.CheckLoginFilter]
    [AdminPage.Filter.CheckRoleFilter]
    public class DesignUploadController : SupervisorController
    {
        private WeaponDesign.DAL.AdminWCF.Client.WeaponDesignAdminServiceClient _adminBLL = new DAL.AdminWCF.Client.WeaponDesignAdminServiceClient();

        public ActionResult Index()
        {
            return View();
        }


        #region 武器查询及审核
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult WeaponAllUserList(CommonLibs.Common.DataPage dp, WeaponUserList model, int? AreaID)
        {

            ViewBag.AreaID = GetGameAreaList();
            ViewBag.StatusID = GetWeaponStatusList();
            model.AreaID = AreaID ?? -1;
            List<WeaponUserList> lists = new List<WeaponUserList>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetWeaponAllUserList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetWeaponAllUserList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "WeaponAllUserList" + lists.Count() + "_Item";
                Dictionary<string, Func<WeaponUserList, string>> showFields = new Dictionary<string, Func<WeaponUserList, string>>();
                showFields.Add(WeaponUserList.WeaponIDField, z => "'" + z.WeaponID.ToString());
                showFields.Add(WeaponUserList.WeaponNameField, z => "'" + z.WeaponName.ToString());
                showFields.Add(WeaponUserList.WeaTypeField, z => "'" + z.WeaType.ToString());
                showFields.Add(WeaponUserList.WeaponDescField, z => "'" + z.WeaponDesc.ToString());
                showFields.Add(WeaponUserList.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(WeaponUserList.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(WeaponUserList.AreaNameField, z => "'" + z.AreaName.ToString());
                showFields.Add(WeaponUserList.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(WeaponUserList.ShowPraiseField, z => "'" + z.ShowPraise.ToString());
                showFields.Add(WeaponUserList.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(WeaponUserList.UpdateTSField, z => "'" + z.UpdateTS.ToString());
                showFields.Add(WeaponUserList.StatusTypeField, z => "'" + z.StatusType.ToString());
                showFields.Add(WeaponUserList.ReasonField, z => "'" + z.Reason.ToString());
                showFields.Add(WeaponUserList.FirstNameField, z => "'" + z.FirstName.ToString());
                showFields.Add(WeaponUserList.GenderField, z => "'" + z.Gender.ToString());
                showFields.Add(WeaponUserList.ContactMethodField, z => "'" + z.ContactMethod.ToString());
                ObjectUtil.Common.ExcelHelper2<WeaponUserList> elh = new ObjectUtil.Common.ExcelHelper2<WeaponUserList>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }

            //记录日志
            Log(string.Format("查看[WeaponUserList]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        public ActionResult DownFile(int wid)
        {
            WeaponList wlist = new WeaponList();
            wlist.WeaponID = wid;
            WeaponList weaponList = _adminBLL.GetWeaponList(wlist);
            string websitepath = AppSetting.GetString("WebsitePath");
            string address2 = websitepath + weaponList.PicAddress;
            string fileEx = System.IO.Path.GetExtension(weaponList.PicAddress);
            string filename = wid + fileEx;
            WebRequest request = WebRequest.Create(address2);
            WebResponse response = request.GetResponse();
            Stream reader = response.GetResponseStream();
            return File(reader, "application/octet-stream", filename);


        }


        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="WeaponID">要查看的WeaponID</param>
        /// <returns></returns>
        public ActionResult EditWeaponList(int WeaponID)
        {

            WeaponList wlist = new WeaponList();
            wlist.WeaponID = WeaponID;
            WeaponList weaponList = _adminBLL.GetWeaponList(wlist);
            ViewBag.StatusID = GetWeaponStatusList(weaponList.StatusID);

            //记录日志
            Log(string.Format("查看[WeaponList]]编辑页面 数据:{0}", WeaponID));

            return View("EditWeaponList", weaponList);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="weaponList">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditWeaponList(WeaponList weaponList)
        {

            if (!CheckText(weaponList.Reason, 200, true))
            {
                return UnSuccessful("审核未通过原因非法或超过200字符", "AddPraiseLog");
            }
            WeaponList wlist = new WeaponList();
            wlist.WeaponID = weaponList.WeaponID;
            wlist.UpdateTS = DateTime.Now;
            wlist.StatusID = weaponList.StatusID;
            wlist.Reason = weaponList.Reason;
            int rs = _adminBLL.UpdateWeaponStatus(wlist);

            //记录日志
            Log(string.Format("编辑[WeaponList]数据:{0}", wlist.ToString()));

            return EditResult(rs, "审核提交失败", "WeaponAllUserList");
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

            if (text.HasHtml())
            {
                return false;
            }
            else if (text.Length > len)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

        #region 后台点赞

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PraiseLogList(DataPage dp, PraiseLog model)
        {
            List<PraiseLog> lists = new List<PraiseLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPraiseLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPraiseLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PraiseLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<PraiseLog, string>> showFields = new Dictionary<string, Func<PraiseLog, string>>();
                showFields.Add(PraiseLog.WeaponIDField, z => "'" + z.WeaponID.ToString());
                showFields.Add(PraiseLog.PraiseNumberField, z => "'" + z.PraiseNumber.ToString());
                showFields.Add(PraiseLog.PraiseIPField, z => "'" + z.PraiseIP.ToString());
                showFields.Add(PraiseLog.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(PraiseLog.SourceField, z => "'" + z.Source.ToString());
                showFields.Add(PraiseLog.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(PraiseLog.AreaNameField, z => "'" + z.AreaName.ToString());
                showFields.Add(PraiseLog.AvatarIDField, z => "'" + z.AvatarID.ToString());
                ObjectUtil.Common.ExcelHelper2<PraiseLog> elh = new ObjectUtil.Common.ExcelHelper2<PraiseLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PraiseLog]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPraiseLog(int? WeaponID)
        {
            PraiseLog praiseLog = new PraiseLog();
            praiseLog.WeaponID = Convert.ToInt32(WeaponID);
            //记录日志
            Log(string.Format("查看[PraiseLog]新增页面"));

            return View(praiseLog);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="praiseLog">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPraiseLog(PraiseLog praiseLog)
        {
            PraiseLog pLog = new PraiseLog();
            pLog.WeaponID = praiseLog.WeaponID;
            pLog.CreateTS = DateTime.Now;
            pLog.PraiseNumber = praiseLog.PraiseNumber;
            pLog.Source = 1;
            pLog.PraiseIP = "admin";
            pLog.AreaID = -1;
            pLog.UserID = -1;
            pLog.AvatarID = -1;
            int rs = _adminBLL.AddPraiseLog(pLog);

            //记录日志
            Log(string.Format("新增PraiseLog 数据:{0}", pLog.ToString()));
            if (rs == -1)
            {
                return UnSuccessful("新增赞数失败", "AddPraiseLog");
            }
            else
            {
                return Success("PraiseLogList");
            }



        }


        #endregion

        #region 评论列表
        //public ActionResult CommentsListList(DataPage dp, int wid)
        //{
        //    ViewBag.WeaponID = wid;
        //    ViewBag.AreaID = GetGameAreaList();
        //    CommentsList model = new CommentsList();
        //    model.WeaponID = wid;
        //    List<CommentsList> lists = new List<CommentsList>();

        //        lists = _adminBLL.GetCommentsListList(ref dp, model);
        //        GetDataPage(dp);

        //    //记录日志
        //    Log(string.Format("查看[CommentsList]列表页面 搜索数据:{0}", model.ToString()));

        //    return View(lists);
        //}

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult CommentsListList(DataPage dp, CommentsList model, int? AreaID)
        {
            ViewBag.AreaID = GetGameAreaList();
            ViewBag.WeaponID = model.WeaponID;
            model.AreaID = AreaID ?? -1;
            List<CommentsList> lists = new List<CommentsList>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                CommentsList model1 = new CommentsList();
                model1.WeaponID = model.WeaponID;
                lists = _adminBLL.GetCommentsListList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetCommentsListList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "CommentsListList" + lists.Count() + "_Item";
                Dictionary<string, Func<CommentsList, string>> showFields = new Dictionary<string, Func<CommentsList, string>>();
                showFields.Add(CommentsList.IDField, z => "'" + z.ID.ToString());
                showFields.Add(CommentsList.WeaponIDField, z => "'" + z.WeaponID.ToString());
                showFields.Add(CommentsList.CommentsField, z => "'" + z.Comments.ToString());
                showFields.Add(CommentsList.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(CommentsList.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(CommentsList.AreaNameField, z => "'" + z.AreaName.ToString());
                showFields.Add(CommentsList.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(CommentsList.AvatarNameField, z => "'" + z.AvatarName.ToString());
                ObjectUtil.Common.ExcelHelper2<CommentsList> elh = new ObjectUtil.Common.ExcelHelper2<CommentsList>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[CommentsList]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        public ActionResult DelCommentsList(int id)
        {
            int rs = _adminBLL.DelComment(id);

            //记录日志
            Log(string.Format("删除[CommentsList]数据:{0}", id));

            return DelResult(rs, "CommentsListList");
        }

        #endregion

        #region 自动刷票配置
        public ActionResult PraiseScheduleList(DataPage dp)
        {
            List<PraiseSchedule> lists = new List<PraiseSchedule>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.PraiseScheduleGetList(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.PraiseScheduleGetList(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PraiseScheduleList" + lists.Count() + "_Item";
                Dictionary<string, Func<PraiseSchedule, string>> showFields = new Dictionary<string, Func<PraiseSchedule, string>>();
                showFields.Add(PraiseSchedule.IDField, z => "'" + z.ID.ToString());
                showFields.Add(PraiseSchedule.StartTSField, z => "'" + z.StartTS.ToString());
                showFields.Add(PraiseSchedule.EndTSField, z => "'" + z.EndTS.ToString());
                showFields.Add(PraiseSchedule.StatusField, z => "'" + z.Status.ToString());
                showFields.Add(PraiseSchedule.MinField, z => "'" + z.Min.ToString());
                showFields.Add(PraiseSchedule.MaxField, z => "'" + z.Max.ToString());
                showFields.Add(PraiseSchedule.WeaponIDField, z => "'" + z.WeaponID.ToString());
                showFields.Add(PraiseSchedule.RandNumField, z => "'" + z.RandNum.ToString());
                ObjectUtil.Common.ExcelHelper2<PraiseSchedule> elh = new ObjectUtil.Common.ExcelHelper2<PraiseSchedule>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPraiseSchedule()
        {
            PraiseSchedule praiseSchedule = new PraiseSchedule();

            //记录日志
            Log(string.Format("查看[PraiseSchedule]新增页面"));

            return View(praiseSchedule);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="praiseSchedule">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPraiseSchedule(PraiseSchedule praiseSchedule)
        {
            praiseSchedule.WeaponID = -1;
            praiseSchedule.Min = 0;
            praiseSchedule.Max = 0;
            int rs = _adminBLL.PraiseScheduleAdd(praiseSchedule);

            //记录日志
            Log(string.Format("新增PraiseSchedule 数据:{0}", praiseSchedule.ToString()));

            return EditResult(rs, "操作失败", "PraiseScheduleList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ID">要查看的ID</param>
        /// <returns></returns>
        public ActionResult EditPraiseSchedule(int ID)
        {
            PraiseSchedule praiseSchedule = _adminBLL.PraiseScheduleGetByID(new PraiseSchedule { ID = ID });

            //记录日志
            Log(string.Format("查看[PraiseSchedule]]编辑页面 数据:{0}", ID));

            return View("AddPraiseSchedule", praiseSchedule);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="praiseSchedule">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPraiseSchedule(PraiseSchedule praiseSchedule)
        {
            praiseSchedule.WeaponID = -1;
            praiseSchedule.Min = 0;
            praiseSchedule.Max = 0;
            int rs = _adminBLL.PraiseScheduleUpdate(praiseSchedule);

            //记录日志
            Log(string.Format("编辑[PraiseSchedule]数据:{0}", praiseSchedule.ToString()));

            return EditResult(rs, "操作失败", "PraiseScheduleList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="praiseSchedule">要删除的 实际使用ID删除</param>
        /// <returns></returns>
        public ActionResult DelPraiseSchedule(PraiseSchedule praiseSchedule)
        {
            bool rs = _adminBLL.PraiseScheduleDel(praiseSchedule);

            //记录日志
            Log(string.Format("删除[PraiseSchedule]数据:{0}", praiseSchedule.ToString()));

            return DelResult(rs, "PraiseScheduleList");
        }



        #endregion

        #region 公用


        private SelectList GetGameAreaList(int gameAreaId = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--全部--" });
            enumItem.Insert(1, new EnumItem { ItemValue = "0", ItemDescription = "电信一区、二区" });
            enumItem.Insert(2, new EnumItem { ItemValue = "1", ItemDescription = "网通一区" });
            var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, gameAreaId);
            return list;
        }

        private SelectList GetWeaponStatusList(int statusid = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--全部--" });
            enumItem.Insert(1, new EnumItem { ItemValue = "5", ItemDescription = "未审核" });
            enumItem.Insert(2, new EnumItem { ItemValue = "1", ItemDescription = "已审核" });
            enumItem.Insert(3, new EnumItem { ItemValue = "2", ItemDescription = "取消审核" });
            //enumItem.Insert(4, new EnumItem { ItemValue = "3", ItemDescription = "已关闭" });
            enumItem.Insert(4, new EnumItem { ItemValue = "4", ItemDescription = "审核不通过" });
            enumItem.Insert(5, new EnumItem { ItemValue = "9", ItemDescription = "已关闭" });
            var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, statusid);
            return list;
        }

        //private SelectList GetSourceType(int sourceid = -1)
        //{
        //    var enumItem = new List<EnumItem>();
        //    enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--全部--" });
        //    enumItem.Insert(1, new EnumItem { ItemValue = "0", ItemDescription = "用户" });
        //    enumItem.Insert(2, new EnumItem { ItemValue = "1", ItemDescription = "后台" });
        //    var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, sourceid);
        //    return list;
        //}

        private void GetDataPage(CommonLibs.Common.DataPage dp)
        {

            Pager.RowCount = dp.RowCount;
            Pager.PageSize = dp.PageSize;
            Pager.PageCount = dp.PageCount;
            Pager.PageIndex = dp.PageIndex;
        }
        private DataPage GetCommonDataPage()
        {
            DataPage dp = new DataPage();
            dp.RowCount = Pager.RowCount;
            dp.PageSize = Pager.PageSize;
            dp.PageCount = Pager.PageCount;
            dp.PageIndex = Pager.PageIndex;
            return dp;
        }
        private void Log(string note)
        {
            this.AddLog(ObjectUtil.ObjectAdmin.Application.Event, note);
        }

        #endregion

    }
}

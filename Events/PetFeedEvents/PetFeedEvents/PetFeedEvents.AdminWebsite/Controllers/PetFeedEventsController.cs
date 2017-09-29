using AdminPage.BaseController;
using PetFeedEvents.Database.Database;
using CommonLibs.Common;
using CommonLibs.Common.Enums;
using ObjectUtil.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DataTableOperator;
using AutoMapper;

namespace PetFeedEvents.AdminWebsite.Controllers
{
    public class PetFeedEventsController : SupervisorController
    {
        //
        // GET: /ArmoryEvents/
        private readonly PetFeedEvents.DAL.AdminWCF.Client.IPetFeedEventsAdminServiceClient PetFeedEventsBll = new DAL.AdminWCF.Client.PetFeedEventsAdminServiceClient();
        DateTime defaultDate = DateTime.Parse("1900/1/1 0:00:00");
        public ActionResult Index()
        {
            return View();
        }



        #region 代码生成器生成|DynamicPacketQueue

        public ActionResult DynamicPacketQueueList(DataPage dp, DynamicPacketQueue model)
        {
            model.GUID = Guid.Empty;
            model.CreateTime = defaultDate;
            List<DynamicPacketQueue> lists = new List<DynamicPacketQueue>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = PetFeedEventsBll.GetDynamicPacketQueueList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = PetFeedEventsBll.GetDynamicPacketQueueList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "DynamicPacketQueueList" + lists.Count() + "_Item";
                Dictionary<string, Func<DynamicPacketQueue, string>> showFields = new Dictionary<string, Func<DynamicPacketQueue, string>>();
                showFields.Add("Id", z => "'" + z.Id.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("Site", z => "'" + z.Site.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("ItemCode", z => "'" + z.ItemCode.ToString());
                showFields.Add("PacketItemTime", z => "'" + z.PacketItemTime.ToString());
                showFields.Add("PacketItemCount", z => "'" + z.PacketItemCount.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                showFields.Add("GUID", z => "'" + z.GUID.ToString());
                showFields.Add("Gold", z => "'" + z.Gold.ToString());
                showFields.Add("BindCash", z => "'" + z.BindCash.ToString());
                ExcelHelper2<DynamicPacketQueue> elh = new ExcelHelper2<DynamicPacketQueue>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        #endregion

        #region 代码生成器生成|DynamicPacketQueueLog
        public ActionResult DynamicPacketQueueLogList(DataPage dp, DynamicPacketQueueLog model)
        {
            model.GUID = Guid.Empty;
            model.CreateTime = defaultDate;
            List<DynamicPacketQueueLog> lists = new List<DynamicPacketQueueLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = PetFeedEventsBll.GetDynamicPacketQueueLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = PetFeedEventsBll.GetDynamicPacketQueueLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "DynamicPacketQueueLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<DynamicPacketQueueLog, string>> showFields = new Dictionary<string, Func<DynamicPacketQueueLog, string>>();
                showFields.Add("LogId", z => "'" + z.LogId.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("Site", z => "'" + z.Site.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("ItemCode", z => "'" + z.ItemCode.ToString());
                showFields.Add("PacketItemTime", z => "'" + z.PacketItemTime.ToString());
                showFields.Add("PacketItemCount", z => "'" + z.PacketItemCount.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                showFields.Add("GUID", z => "'" + z.GUID.ToString());
                showFields.Add("Gold", z => "'" + z.Gold.ToString());
                showFields.Add("BindCash", z => "'" + z.BindCash.ToString());
                ExcelHelper2<DynamicPacketQueueLog> elh = new ExcelHelper2<DynamicPacketQueueLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }
 

        #endregion

        #region 代码生成器生成|GameDailyLog

        public ActionResult GameDailyLogList(DataPage dp,DateTime? RecordDate, GameDailyLog model)
        {
            model.GUID = Guid.Empty;
            model.RecordDate = RecordDate??DateTime.Now.AddDays(-1);
            model.CreateTime = defaultDate;
            List<GameDailyLog> lists = new List<GameDailyLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = PetFeedEventsBll.GetGameDailyLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = PetFeedEventsBll.GetGameDailyLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "GameDailyLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<GameDailyLog, string>> showFields = new Dictionary<string, Func<GameDailyLog, string>>();
                showFields.Add("RecordId", z => "'" + z.RecordId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("RecordDate", z => "'" + z.RecordDate.ToString());
                showFields.Add("TaskConfigId", z => "'" + z.TaskConfigId.ToString());
                showFields.Add("ActualNum", z => "'" + z.ActualNum.ToString());
                showFields.Add("FinalGetNum", z => "'" + z.FinalGetNum.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("GUID", z => "'" + z.GUID.ToString());
                showFields.Add("Source",z=>"'"+z.Source.ToString());
                ExcelHelper2<GameDailyLog> elh = new ExcelHelper2<GameDailyLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }





        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddGameDailyLog()
        {
            GameDailyLog gameDailyLog = new GameDailyLog();

            //记录日志
            Log(string.Format("查看[GameDailyLog]新增页面"));

            return View(gameDailyLog);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="gameDailyLog">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddGameDailyLog(GameDailyLog gameDailyLog)
        {
            gameDailyLog.GUID = Guid.NewGuid();
            int rs = PetFeedEventsBll.InsertGameDailyLog(gameDailyLog);

            //记录日志
            Log(string.Format("新增GameDailyLog 数据:{0}", gameDailyLog.ToString()));

            return EditResult(rs, "操作失败", "GameDailyLogList");
        }





        #endregion


        #region 代码生成器生成|TaskConfig
        public ActionResult TaskConfigList(DataPage dp)
        {
            List<TaskConfig> lists = new List<TaskConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = PetFeedEventsBll.GetTaskConfig(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = PetFeedEventsBll.GetTaskConfig(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "TaskConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<TaskConfig, string>> showFields = new Dictionary<string, Func<TaskConfig, string>>();
                showFields.Add("TaskConfigId", z => "'" + z.TaskConfigId.ToString());
                showFields.Add("TaskName", z => "'" + z.TaskName.ToString());
                showFields.Add("TaskDesc", z => "'" + z.TaskDesc.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("ItemCode", z => "'" + z.ItemCode.ToString());
                showFields.Add("ItemTimePerTask", z => "'" + z.ItemTimePerTask.ToString());
                showFields.Add("ItemCountPerTask", z => "'" + z.ItemCountPerTask.ToString());
                showFields.Add("GoldPerTask", z => "'" + z.GoldPerTask.ToString());
                showFields.Add("BindCashPerTask", z => "'" + z.BindCashPerTask.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                ExcelHelper2<TaskConfig> elh = new ExcelHelper2<TaskConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTaskConfig()
        {
            TaskConfig taskConfig = new TaskConfig();

            //记录日志
            Log(string.Format("查看[TaskConfig]新增页面"));

            return View(taskConfig);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="taskConfig">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTaskConfig(TaskConfig taskConfig)
        {
            int rs = PetFeedEventsBll.InsertTaskConfig(taskConfig);

            //记录日志
            Log(string.Format("新增TaskConfig 数据:{0}", taskConfig.ToString()));

            return EditResult(rs, "操作失败", "TaskConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="TaskConfigId">要查看的TaskConfigId</param>
        /// <returns></returns>
        public ActionResult EditTaskConfig(int TaskConfigId)
        {
            DataPage dp = new DataPage() { PageIndex=1,PageSize=0};
            TaskConfig taskConfig = PetFeedEventsBll.GetTaskConfig(ref dp).Where(p=>p.TaskConfigId==TaskConfigId).Single();

            //记录日志
            Log(string.Format("查看[TaskConfig]]编辑页面 数据:{0}", TaskConfigId));

            return View("AddTaskConfig", taskConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="taskConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTaskConfig(TaskConfig taskConfig)
        {
            int rs = PetFeedEventsBll.UpdateTaskConfig(taskConfig);

            //记录日志
            Log(string.Format("编辑[TaskConfig]数据:{0}", taskConfig.ToString()));

            return EditResult(rs, "操作失败", "TaskConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="taskConfig">要删除的 实际使用TaskConfigId删除</param>
        /// <returns></returns>
        public ActionResult DelTaskConfig(TaskConfig taskConfig)
        {
            int rs = PetFeedEventsBll.DeleteTaskConfig(taskConfig);

            //记录日志
            Log(string.Format("删除[TaskConfig]数据:{0}", taskConfig.ToString()));

            return DelResult(rs, "TaskConfigList");
        }

        public ActionResult CleanAllData()
        {
            int rs = PetFeedEventsBll.CleanAllData();

            //记录日志
            Log(string.Format("清除活动所有数据"));

            return EditResult(rs, "操作失败", "TaskConfigList");
        }

        #endregion

        #region 公用

        private SelectList GetGameAreaList(int gameAreaId = -1)
        {
            var enumItem = new List<CommonLibs.Common.Enums.EnumItem>();
            enumItem.Insert(0, new CommonLibs.Common.Enums.EnumItem { ItemValue = "-1", ItemDescription = "--全部--" });
            enumItem.Insert(1, new CommonLibs.Common.Enums.EnumItem { ItemValue = "0", ItemDescription = "电信1" });
            enumItem.Insert(2, new CommonLibs.Common.Enums.EnumItem { ItemValue = "2", ItemDescription = "电信2" });
            enumItem.Insert(3, new CommonLibs.Common.Enums.EnumItem { ItemValue = "1", ItemDescription = "网通1" });

            var list = new SelectList(enumItem, CommonLibs.Common.Enums.EnumItem.ItemValueField, CommonLibs.Common.Enums.EnumItem.ItemDescriptionField, gameAreaId);
            return list;
        }


        private void GetDataPage(DataPage dp)
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

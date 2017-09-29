using AdminPage.BaseController;
using CampEvents.Database.Database;
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

namespace CampEvents.AdminWebsite.Controllers
{
    public class CampEventsController : SupervisorController
    {
        //
        // GET: /ArmoryEvents/
        private readonly CampEvents.DAL.AdminWCF.Client.ICampEventsAdminServiceClient CampEventsBll = new DAL.AdminWCF.Client.CampEventsAdminServiceClient();
        DateTime defaultDate = DateTime.Parse("1900/1/1 0:00:00");
        public ActionResult Index()
        {
            return View();
        }

        #region BasicConfigs
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult BasicConfigList()
        {
            List<BasicConfig> lists = new List<BasicConfig>();
            lists = CampEventsBll.GetBasicConfigList();

            //记录日志
            Log(string.Format("查看[BasicConfig]列表页面 搜索数据"));

            return View(lists);
        }


        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ConfigId">要查看的ConfigId</param>
        /// <returns></returns>
        public ActionResult EditBasicConfig(int BasicId)
        {
            BasicConfig basicConfig = CampEventsBll.GetBasicConfigList().Where(p => p.BasicId == BasicId).Single();

            //记录日志
            Log(string.Format("查看[BasicConfig]]编辑页面 数据:{0}", BasicId));

            return View("EditBasicConfig", basicConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="basicConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditBasicConfig(BasicConfig basicConfig)
        {
            int rs = CampEventsBll.UpdateBasicConfig(basicConfig);

            //记录日志
            Log(string.Format("编辑[BasicConfig]数据:{0}", basicConfig.ToString()));

            return EditResult(rs, "操作失败", "BasicConfigList");
        }



        #endregion

        #region CampConfigs
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult CampConfigsList()
        {
            List<CampConfig> lists = new List<CampConfig>();

            lists = CampEventsBll.GetCampConfigList();
            //记录日志
            Log(string.Format("查看[CampConfigs]列表页面 搜索数据"));

            return View(lists);
        }

        #endregion

        #region DailyTaskConfigs


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult DailyTaskConfigsList()
        {
            List<DailyTaskConfig> lists = new List<DailyTaskConfig>();

            lists = CampEventsBll.GetDailyTaskConfigList();
            //记录日志
            Log(string.Format("查看[DailyTaskConfigs]列表页面 搜索数据"));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDailyTaskConfigs()
        {
            DailyTaskConfig dailyTaskConfigs = new DailyTaskConfig();

            //记录日志
            Log(string.Format("查看[DailyTaskConfigs]新增页面"));

            return View(dailyTaskConfigs);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="dailyTaskConfigs">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDailyTaskConfigs(DailyTaskConfig dailyTaskConfigs)
        {
            int rs = CampEventsBll.InsertDailyTaskConfig(dailyTaskConfigs);

            //记录日志
            Log(string.Format("新增DailyTaskConfigs 数据:{0}", dailyTaskConfigs.ToString()));

            return EditResult(rs, "操作失败", "DailyTaskConfigsList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="TaskConfigId">要查看的TaskConfigId</param>
        /// <returns></returns>
        public ActionResult EditDailyTaskConfigs(int TaskConfigId)
        {
            DailyTaskConfig dailyTaskConfigs = CampEventsBll.GetDailyTaskConfigList().Where(p => p.TaskConfigId == TaskConfigId).Single();

            //记录日志
            Log(string.Format("查看[DailyTaskConfigs]]编辑页面 数据:{0}", TaskConfigId));

            return View("AddDailyTaskConfigs", dailyTaskConfigs);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="dailyTaskConfigs">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditDailyTaskConfigs(DailyTaskConfig dailyTaskConfigs)
        {
            int rs = CampEventsBll.UpdateDailyTaskConfig(dailyTaskConfigs);

            //记录日志
            Log(string.Format("编辑[DailyTaskConfigs]数据:{0}", dailyTaskConfigs.ToString()));

            return EditResult(rs, "操作失败", "DailyTaskConfigsList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="dailyTaskConfigs">要删除的 实际使用TaskConfigId删除</param>
        /// <returns></returns>
        public ActionResult DelDailyTaskConfigs(DailyTaskConfig dailyTaskConfigs)
        {
            int rs = CampEventsBll.DeleteDailyTaskConfig(dailyTaskConfigs);

            //记录日志
            Log(string.Format("删除[DailyTaskConfigs]数据:{0}", dailyTaskConfigs.ToString()));

            return DelResult(rs, "DailyTaskConfigsList");
        }



        #endregion

        #region GameDailyLogHistories
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult GameDailyLogHistoriesList(DataPage dp, DateTime? RecordDate, GameDailyLogHistory model)
        {
            if (RecordDate == null)
            {
                model.RecordDate = DateTime.Now.AddDays(-1);
            }
            model.CreateTime = defaultDate;
            List<GameDailyLogHistory> lists = new List<GameDailyLogHistory>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetGameDailyLogHistoryList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetGameDailyLogHistoryList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "GameDailyLogHistoriesList" + lists.Count() + "_Item";
                Dictionary<string, Func<GameDailyLogHistory, string>> showFields = new Dictionary<string, Func<GameDailyLogHistory, string>>();
                showFields.Add("HistoryId", z => "'" + z.HistoryId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("RecordDate", z => "'" + z.RecordDate.ToString());
                showFields.Add("TaskConfigId", z => "'" + z.TaskConfigId.ToString());
                showFields.Add("FinalNumber", z => "'" + z.FinalNumber.ToString());
                showFields.Add("TaskGetPoints", z => "'" + z.TaskGetPoints.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("FromId", z => "'" + z.FromId.ToString());
                ObjectUtil.Common.ExcelHelper2<GameDailyLogHistory> elh = new ObjectUtil.Common.ExcelHelper2<GameDailyLogHistory>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[GameDailyLogHistories]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        #endregion

        #region GameDailyLogs


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult GameDailyLogsList(DataPage dp, GameDailyLog model)
        {
            model.CreateTime = defaultDate;
            List<GameDailyLog> lists = new List<GameDailyLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetGameDailyLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetGameDailyLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "GameDailyLogsList" + lists.Count() + "_Item";
                Dictionary<string, Func<GameDailyLog, string>> showFields = new Dictionary<string, Func<GameDailyLog, string>>();
                showFields.Add("RecordId", z => "'" + z.RecordId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("RecordDate", z => "'" + z.RecordDate.ToString());
                showFields.Add("TaskConfigId", z => "'" + z.TaskConfigId.ToString());
                showFields.Add("FinalNumber", z => "'" + z.FinalNumber.ToString());
                showFields.Add("TaskGetPoints", z => "'" + z.TaskGetPoints.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                ObjectUtil.Common.ExcelHelper2<GameDailyLog> elh = new ObjectUtil.Common.ExcelHelper2<GameDailyLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[GameDailyLogs]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        #endregion

        #region PacketQueueLogs


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PacketQueueLogsList(DataPage dp, PacketQueueLog model)
        {
            model.CreateTime = defaultDate;
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetPacketQueueLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetPacketQueueLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PacketQueueLogsList" + lists.Count() + "_Item";
                Dictionary<string, Func<PacketQueueLog, string>> showFields = new Dictionary<string, Func<PacketQueueLog, string>>();
                showFields.Add("LogId", z => "'" + z.LogId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                showFields.Add("FromId", z => "'" + z.FromId.ToString());
                ObjectUtil.Common.ExcelHelper2<PacketQueueLog> elh = new ObjectUtil.Common.ExcelHelper2<PacketQueueLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PacketQueueLogs]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        #endregion

        #region PacketQueues


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PacketQueueList(DataPage dp, PacketQueue model)
        {
            model.CreateTime = defaultDate;
            List<PacketQueue> lists = new List<PacketQueue>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetPacketQueueList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetPacketQueueList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PacketQueueList" + lists.Count() + "_Item";
                Dictionary<string, Func<PacketQueue, string>> showFields = new Dictionary<string, Func<PacketQueue, string>>();
                showFields.Add("Id", z => "'" + z.Id.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                showFields.Add("FromId", z => "'" + z.FromId.ToString());
                ObjectUtil.Common.ExcelHelper2<PacketQueue> elh = new ObjectUtil.Common.ExcelHelper2<PacketQueue>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PacketQueue]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPacketQueue()
        {
            PacketQueue PacketQueue = new PacketQueue();

            //记录日志
            Log(string.Format("查看[PacketQueue]新增页面"));

            return View(PacketQueue);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="PacketQueue">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPacketQueue(PacketQueue PacketQueue)
        {
            int rs = CampEventsBll.InsertPacketQueue(PacketQueue);

            //记录日志
            Log(string.Format("新增PacketQueue 数据:{0}", PacketQueue.ToString()));

            return EditResult(rs, "操作失败", "PacketQueueList");
        }


        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="PacketQueue">要删除的 实际使用Id删除</param>
        /// <returns></returns>
        public ActionResult DelPacketQueue(PacketQueue PacketQueue)
        {
            int rs = CampEventsBll.DeletePacketQueue(PacketQueue);

            //记录日志
            Log(string.Format("删除[PacketQueue]数据:{0}", PacketQueue.ToString()));

            return DelResult(rs, "PacketQueueList");
        }

        public ActionResult CalculateFinalPackets()
        {
            int rs = CampEventsBll.CalculateFinalPackets();

            //记录日志
            Log(string.Format("统计礼包 PacketQueue 数据"));

            return EditResult(rs, "操作失败", "PacketQueueList");
        }

        #endregion

        #region PointPacketConfigs


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PointPacketConfigList(DataPage dp)
        {
            List<PointPacketConfig> lists = new List<PointPacketConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetPointPacketConfigsList(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetPointPacketConfigsList(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PointPacketConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<PointPacketConfig, string>> showFields = new Dictionary<string, Func<PointPacketConfig, string>>();
                showFields.Add("ConfigId", z => "'" + z.ConfigId.ToString());
                showFields.Add("ConfigContent", z => "'" + z.ConfigContent.ToString());
                showFields.Add("PacketId", z => "'" + z.PacketId.ToString());
                showFields.Add("PacketName", z => "'" + z.PacketName.ToString());
                showFields.Add("NeedPoints", z => "'" + z.NeedPoints.ToString());
                showFields.Add("CampId", z => "'" + z.CampId.ToString());
                showFields.Add("IsNotice", z => "'" + z.IsNotice.ToString());
                showFields.Add("ShowId", z => "'" + z.ShowId.ToString());
                ObjectUtil.Common.ExcelHelper2<PointPacketConfig> elh = new ObjectUtil.Common.ExcelHelper2<PointPacketConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PointPacketConfig]列表页面 搜索数据"));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPointPacketConfig()
        {
            PointPacketConfig PointPacketConfig = new PointPacketConfig();

            //记录日志
            Log(string.Format("查看[PointPacketConfig]新增页面"));

            return View(PointPacketConfig);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="PointPacketConfig">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPointPacketConfig(PointPacketConfig PointPacketConfig)
        {
            int rs = CampEventsBll.InsertPointPacketConfig(PointPacketConfig);

            //记录日志
            Log(string.Format("新增PointPacketConfig 数据:{0}", PointPacketConfig.ToString()));

            return EditResult(rs, "操作失败", "PointPacketConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ConfigId">要查看的ConfigId</param>
        /// <returns></returns>
        public ActionResult EditPointPacketConfig(int ConfigId)
        {
            DataPage dp = new DataPage { PageIndex = 1, PageSize = 0 };
            PointPacketConfig PointPacketConfig = CampEventsBll.GetPointPacketConfigsList(ref dp).Where(p => p.ConfigId == ConfigId).Single();

            //记录日志
            Log(string.Format("查看[PointPacketConfig]]编辑页面 数据:{0}", ConfigId));

            return View("AddPointPacketConfig", PointPacketConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="PointPacketConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPointPacketConfig(PointPacketConfig PointPacketConfig)
        {
            int rs = CampEventsBll.UpdatePointPacketConfig(PointPacketConfig);

            //记录日志
            Log(string.Format("编辑[PointPacketConfig]数据:{0}", PointPacketConfig.ToString()));

            return EditResult(rs, "操作失败", "PointPacketConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="PointPacketConfig">要删除的 实际使用ConfigId删除</param>
        /// <returns></returns>
        public ActionResult DelPointPacketConfig(PointPacketConfig PointPacketConfig)
        {
            int rs = CampEventsBll.DeletePointPacketConfig(PointPacketConfig);

            //记录日志
            Log(string.Format("删除[PointPacketConfig]数据:{0}", PointPacketConfig.ToString()));

            return DelResult(rs, "PointPacketConfigList");
        }



        #endregion

        #region PointPacketExchangeLogs


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PointPacketExchangeLogList(DataPage dp, PointPacketExchangeLog model)
        {
            model.CreateTime = defaultDate;
            List<PointPacketExchangeLog> lists = new List<PointPacketExchangeLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetPointPacketExchangeLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetPointPacketExchangeLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PointPacketExchangeLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<PointPacketExchangeLog, string>> showFields = new Dictionary<string, Func<PointPacketExchangeLog, string>>();
                showFields.Add("Id", z => "'" + z.Id.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("LoginName", z => "'" + z.LoginName.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("PointPacketConfigId", z => "'" + z.PointPacketConfigId.ToString());
                showFields.Add("CurrentPoints", z => "'" + z.CurrentPoints.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                ObjectUtil.Common.ExcelHelper2<PointPacketExchangeLog> elh = new ObjectUtil.Common.ExcelHelper2<PointPacketExchangeLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PointPacketExchangeLog]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        #endregion

        #region RankListTop20


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult RankListTop20List(DataPage dp, RankListTop20 model)
        {
            model.CreateTime = defaultDate;
            List<RankListTop20> lists = new List<RankListTop20>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetRankListTop20List(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetRankListTop20List(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "RankListTop20List" + lists.Count() + "_Item";
                Dictionary<string, Func<RankListTop20, string>> showFields = new Dictionary<string, Func<RankListTop20, string>>();
                showFields.Add("Id", z => "'" + z.Id.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AreaName", z => "'" + z.AreaName.ToString());
                showFields.Add("TotalGetPoints", z => "'" + z.TotalGetPoints.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("RankOrder", z => "'" + z.RankOrder.ToString());
                showFields.Add("CutOffDate", z => "'" + z.CutOffDate.ToString());
                showFields.Add("CampId", z => "'" + z.CampId.ToString());
                ObjectUtil.Common.ExcelHelper2<RankListTop20> elh = new ObjectUtil.Common.ExcelHelper2<RankListTop20>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[RankListTop20]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRankListTop20()
        {
            RankListTop20 rankListTop20 = new RankListTop20();

            //记录日志
            Log(string.Format("查看[RankListTop20]新增页面"));

            return View(rankListTop20);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="rankListTop20">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRankListTop20(RankListTop20 rankListTop20)
        {
            int rs = CampEventsBll.InsertRankListTop20(rankListTop20);

            //记录日志
            Log(string.Format("新增RankListTop20 数据:{0}", rankListTop20.ToString()));

            return EditResult(rs, "操作失败", "RankListTop20List");
        }


        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="rankListTop20">要删除的 实际使用Id删除</param>
        /// <returns></returns>
        public ActionResult DelRankListTop20(RankListTop20 rankListTop20)
        {
            int rs = CampEventsBll.DeleteRankListTop20(rankListTop20);

            //记录日志
            Log(string.Format("删除[RankListTop20]数据:{0}", rankListTop20.ToString()));

            return DelResult(rs, "RankListTop20List");
        }

        public ActionResult CalculateRankPacket(List<int> RankId, List<int> PacketId)
        {
            int rs = 0;        
            for (int i = 0; i < RankId.Count; i++)
            {
                int rankid = RankId[i];
                int packetid = PacketId[i];      
                if (rankid < 1 || packetid < 1)
                    continue;
                RankListTop20 rank = new RankListTop20 { Id = rankid };
                rs = CampEventsBll.CalculateRankPacket(rank, packetid) + rs;
            }

            //记录日志
            Log(string.Format("发送礼包[RankListTop20]数据:{0},{1}", RankId.ToString(), PacketId));

            return DelResult(rs, "RankListTop20List");
        }

        #endregion

        #region UserCampLogs



        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult UserCampLogList(DataPage dp, UserCampLog model)
        {
            model.CreateTime = defaultDate;
            List<UserCampLog> lists = new List<UserCampLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetUserCampLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetUserCampLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "UserCampLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<UserCampLog, string>> showFields = new Dictionary<string, Func<UserCampLog, string>>();
                showFields.Add("LogId", z => "'" + z.LogId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("LoginName", z => "'" + z.LoginName.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("Sex", z => "'" + z.Sex.ToString());
                showFields.Add("CampId", z => "'" + z.CampId.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                ObjectUtil.Common.ExcelHelper2<UserCampLog> elh = new ObjectUtil.Common.ExcelHelper2<UserCampLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[UserCampLog]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }





        #endregion

        #region Wallets


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult WalletList(DataPage dp, DateTime? RecordDate, Wallet model)
        {
            model.CreateTime = defaultDate;
            if (RecordDate == null)
            {
                model.RecordDate = DateTime.Now.AddDays(-1);
            }
            List<Wallet> lists = new List<Wallet>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CampEventsBll.GetWalletList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CampEventsBll.GetWalletList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "WalletList" + lists.Count() + "_Item";
                Dictionary<string, Func<Wallet, string>> showFields = new Dictionary<string, Func<Wallet, string>>();
                showFields.Add("WId", z => "'" + z.WId.ToString());
                showFields.Add("UserId", z => "'" + z.UserId.ToString());
                showFields.Add("AreaId", z => "'" + z.AreaId.ToString());
                showFields.Add("AvatarId", z => "'" + z.AvatarId.ToString());
                showFields.Add("AvatarName", z => "'" + z.AvatarName.ToString());
                showFields.Add("DailyGetPoints", z => "'" + z.DailyGetPoints.ToString());
                showFields.Add("BalancePoints", z => "'" + z.BalancePoints.ToString());
                showFields.Add("FinishedTaskNum", z => "'" + z.FinishedTaskNum.ToString());
                showFields.Add("RecordDate", z => "'" + z.RecordDate.ToString());
                showFields.Add("CreateTime", z => "'" + z.CreateTime.ToString());
                showFields.Add("Source", z => "'" + z.Source.ToString());
                showFields.Add("FromId", z => "'" + z.FromId.ToString());
                showFields.Add("CampId", z => "'" + z.CampId.ToString());

                ObjectUtil.Common.ExcelHelper2<Wallet> elh = new ObjectUtil.Common.ExcelHelper2<Wallet>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[Wallet]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWallet()
        {
            Wallet Wallet = new Wallet();

            //记录日志
            Log(string.Format("查看[Wallet]新增页面"));

            return View(Wallet);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="Wallet">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddWallet(Wallet Wallet)
        {
            int rs = CampEventsBll.InsertWallet(Wallet);

            //记录日志
            Log(string.Format("新增Wallet 数据:{0}", Wallet.ToString()));

            return EditResult(rs, "操作失败", "WalletList");
        }


        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="Wallet">要删除的 实际使用WId删除</param>
        /// <returns></returns>
        public ActionResult DelWallet(Wallet Wallet)
        {
            int rs = CampEventsBll.DeleteWallet(Wallet);

            //记录日志
            Log(string.Format("删除[Wallet]数据:{0}", Wallet.ToString()));

            return DelResult(rs, "WalletList");
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

        //private SelectList GetExchangeTypeList(int? ExchangeTypeId)
        //{
        //    int TypeId = ExchangeTypeId ?? -1;
        //    List<ExchangePacketTypeConfig> enumItem = new List<ExchangePacketTypeConfig>();
        //    enumItem.Add(new ExchangePacketTypeConfig { ExchangeTypeId = -1, ExchangeTypeName = "请选择" });
        //    DataPage dp = new DataPage() { PageIndex = 1, PageSize = 0 };
        //    enumItem.AddRange(CampEventsBll.GetExchangePacketTypeConfigList(ref dp));
        //    var list = new SelectList(enumItem, ExchangePacketTypeConfig.ExchangeTypeIdField, ExchangePacketTypeConfig.ExchangeTypeNameField, TypeId);
        //    return list;
        //}

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

        //#region ImportCSV
        //public ActionResult ImportExcel()
        //{

        //    ViewBag.Typeid = ImportType();
        //    return View();

        //}
        //[HttpPost]
        //public ActionResult ImportExcel(string Typeid, HttpPostedFileBase file)
        //{
        //    ViewBag.Typeid = ImportType();
        //    string fileEx = System.IO.Path.GetExtension(file.FileName);
        //    if (!fileEx.ToLower().Equals(".csv"))
        //    {
        //        return UnSuccessful("导入文件格式不正确", "ImportExcel");
        //    }
        //    DataTable dt = new DataTable();
        //    dt = importCSV(file);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dt);
        //    int rs = CampEventsBll.importCSVtoDB(ds, Typeid);
        //    if (rs == 1)
        //    {
        //        return Success("ImportExcel");
        //    }

        //    return UnSuccessful("导入失败", "ImportExcel");
        //}



        //private SelectList ImportType(string typeid = "-1")
        //{
        //    var enumItem = new List<ObjectUtil.Common.EnumItem>();
        //    enumItem.Insert(0, new ObjectUtil.Common.EnumItem { ItemValue = "-1", ItemDescription = "请选择" });
        //    enumItem.Insert(1, new ObjectUtil.Common.EnumItem { ItemValue = "DrawPacketConfig", ItemDescription = "抽奖礼包及概率表" });
        //    enumItem.Insert(2, new ObjectUtil.Common.EnumItem { ItemValue = "ExchangePacketConfig", ItemDescription = "阶梯礼包" });
        //    var list = new SelectList(enumItem, ObjectUtil.Common.EnumItem.ItemValueField, ObjectUtil.Common.EnumItem.ItemDescriptionField, typeid);
        //    return list;
        //}

        //public DataTable importCSV(HttpPostedFileBase file)
        //{
        //    DataTable dt = new DataTable();
        //    StreamReader sr = new StreamReader(file.InputStream, System.Text.Encoding.Default);
        //    //记录每次读取的一行记录
        //    string strLine = "";
        //    //记录每行记录中的各字段内容
        //    string[] aryLine;
        //    //标示列数
        //    int columnCount = 0;
        //    //标示是否是读取的第一行
        //    bool IsFirst = true;
        //    //逐行读取CSV中的数据
        //    while ((strLine = sr.ReadLine()) != null)
        //    {
        //        aryLine = strLine.Split(',');
        //        if (IsFirst == true)
        //        {

        //            columnCount = aryLine.Length;
        //            //创建列
        //            for (int i = 0; i < columnCount; i++)
        //            {
        //                DataColumn dc = new DataColumn(aryLine[i]);
        //                dt.Columns.Add(dc);
        //            }
        //            IsFirst = false;
        //        }
        //        else
        //        {
        //            DataRow dr = dt.NewRow();
        //            for (int j = 0; j < columnCount; j++)
        //            {
        //                dr[j] = aryLine[j];
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //    }
        //    sr.Close();
        //    //fs.Close();
        //    return dt;
        //}
        //#endregion
    }
}

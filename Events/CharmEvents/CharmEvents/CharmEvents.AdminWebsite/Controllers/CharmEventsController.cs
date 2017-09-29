using AdminPage.BaseController;
using CharmEvents.Database.Database;
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

namespace CharmEvents.AdminWebsite.Controllers
{
    public class CharmEventsController : SupervisorController
    {
        //
        // GET: /ArmoryEvents/
        private readonly CharmEvents.DAL.AdminWCF.Client.ICharmEventsAdminServiceClient CharmEventsBll = new DAL.AdminWCF.Client.CharmEventsAdminServiceClient();
        DateTime defaultDate = DateTime.Parse("1900/1/1 0:00:00");
        public ActionResult Index()
        {
            return View();
        }

        #region OtherLists

        public ActionResult ExchangeAndDrawLogList(DataPage dp, ExchangeAndDrawLog model, int? AreaId)
        {
            model.AreaId = AreaId ?? -1;
            ViewBag.AreaId = GetGameAreaList(model.AreaId);
            List<ExchangeAndDrawLog> lists = new List<ExchangeAndDrawLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetExchangeAndDrawLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetExchangeAndDrawLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "ExchangeAndDrawLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<ExchangeAndDrawLog, string>> showFields = new Dictionary<string, Func<ExchangeAndDrawLog, string>>();
                showFields.Add(ExchangeAndDrawLog.ConsumeIdField, z => "'" + z.ConsumeId.ToString());
                showFields.Add(ExchangeAndDrawLog.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(ExchangeAndDrawLog.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(ExchangeAndDrawLog.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(ExchangeAndDrawLog.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(ExchangeAndDrawLog.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(ExchangeAndDrawLog.SexField, z => "'" + z.Sex.ToString());
                showFields.Add(ExchangeAndDrawLog.ExchangeIdField, z => "'" + z.ExchangeId.ToString());
                showFields.Add(ExchangeAndDrawLog.PointsField, z => "'" + z.Points.ToString());
                showFields.Add(ExchangeAndDrawLog.RandNumField, z => "'" + z.RandNum.ToString());
                showFields.Add(ExchangeAndDrawLog.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(ExchangeAndDrawLog.SourceField, z => "'" + z.Source.ToString());
                ExcelHelper2<ExchangeAndDrawLog> elh = new ExcelHelper2<ExchangeAndDrawLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }



        public ActionResult LoginPacketLogList(DataPage dp, LoginPacketLog model, int? AreaId)
        {
            model.AreaId = AreaId ?? -1;
            ViewBag.AreaId = GetGameAreaList(model.AreaId);
            List<LoginPacketLog> lists = new List<LoginPacketLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetLoginPacketLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetLoginPacketLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "LoginPacketLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<LoginPacketLog, string>> showFields = new Dictionary<string, Func<LoginPacketLog, string>>();
                showFields.Add(LoginPacketLog.IdField, z => "'" + z.Id.ToString());
                showFields.Add(LoginPacketLog.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(LoginPacketLog.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(LoginPacketLog.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(LoginPacketLog.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(LoginPacketLog.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(LoginPacketLog.SexField, z => "'" + z.Sex.ToString());
                showFields.Add(LoginPacketLog.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(LoginPacketLog.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(LoginPacketLog.SourceField, z => "'" + z.Source.ToString());
                ExcelHelper2<LoginPacketLog> elh = new ExcelHelper2<LoginPacketLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        public ActionResult PacketQueueLogList(DataPage dp, PacketQueueLog model, int? AreaId, long? PacketId)
        {
            model.AreaId = AreaId ?? -1;
            ViewBag.AreaId = GetGameAreaList(model.AreaId);
            model.PacketId = PacketId ?? 0;
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetPacketQueueLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetPacketQueueLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PacketQueueLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<PacketQueueLog, string>> showFields = new Dictionary<string, Func<PacketQueueLog, string>>();
                showFields.Add(PacketQueueLog.IdField, z => "'" + z.Id.ToString());
                showFields.Add(PacketQueueLog.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(PacketQueueLog.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(PacketQueueLog.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(PacketQueueLog.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(PacketQueueLog.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(PacketQueueLog.SexField, z => "'" + z.Sex.ToString());
                showFields.Add(PacketQueueLog.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(PacketQueueLog.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(PacketQueueLog.SourceField, z => "'" + z.Source.ToString());
                showFields.Add(PacketQueueLog.FromIdField, z => "'" + z.FromId.ToString());
                ExcelHelper2<PacketQueueLog> elh = new ExcelHelper2<PacketQueueLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        #endregion

        #region Wallets


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult WalletsList(DataPage dp, Wallets model)
        {
            List<Wallets> lists = new List<Wallets>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetWalletsList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetWalletsList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "WalletsList" + lists.Count() + "_Item";
                Dictionary<string, Func<Wallets, string>> showFields = new Dictionary<string, Func<Wallets, string>>();
                showFields.Add(Wallets.WIdField, z => "'" + z.WId.ToString());
                showFields.Add(Wallets.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(Wallets.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(Wallets.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(Wallets.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(Wallets.RecordDateField, z => "'" + z.RecordDate.ToString());
                showFields.Add(Wallets.GetPointsField, z => "'" + z.GetPoints.ToString());
                showFields.Add(Wallets.BalancePointsField, z => "'" + z.BalancePoints.ToString());
                showFields.Add(Wallets.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(Wallets.SourceField, z => "'" + z.Source.ToString());
                showFields.Add(Wallets.GetLastTimeField, z => "'" + z.GetLastTime.ToString());
                showFields.Add(Wallets.FromIdField, z => "'" + z.FromId.ToString());
                ObjectUtil.Common.ExcelHelper2<Wallets> elh = new ObjectUtil.Common.ExcelHelper2<Wallets>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[Wallets]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddWallets()
        {
            Wallets wallets = new Wallets();

            //记录日志
            Log(string.Format("查看[Wallets]新增页面"));

            return View(wallets);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="wallets">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddWallets(Wallets wallets)
        {
            if (wallets.GetPoints < wallets.BalancePoints)
            {
                return UnSuccessful("GetPoints必须大于BalancePoints", "AddWallets");
            }
            wallets.CreateTime = System.DateTime.Now;
            wallets.FromId = -1;
            long rs = CharmEventsBll.AddWallets(wallets);

            //记录日志
            Log(string.Format("新增Wallets 数据:{0}", wallets.ToString()));

            return EditResult(rs, "操作失败", "WalletsList");
        }

        #endregion

        #region DrawPacketConfig


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult DrawPacketConfigList(DataPage dp, DrawPacketConfig model)
        {
            List<DrawPacketConfig> lists = new List<DrawPacketConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetDrawPacketConfigList(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetDrawPacketConfigList(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "DrawPacketConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<DrawPacketConfig, string>> showFields = new Dictionary<string, Func<DrawPacketConfig, string>>();
                showFields.Add(DrawPacketConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(DrawPacketConfig.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(DrawPacketConfig.PacketNameField, z => "'" + z.PacketName.ToString());
                showFields.Add(DrawPacketConfig.PacketDescField, z => "'" + z.PacketDesc.ToString());
                showFields.Add(DrawPacketConfig.RateValueField, z => "'" + z.RateValue.ToString());
                showFields.Add(DrawPacketConfig.RateBeginField, z => "'" + z.RateBegin.ToString());
                showFields.Add(DrawPacketConfig.RateEndField, z => "'" + z.RateEnd.ToString());
                ObjectUtil.Common.ExcelHelper2<DrawPacketConfig> elh = new ObjectUtil.Common.ExcelHelper2<DrawPacketConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[DrawPacketConfig]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDrawPacketConfig()
        {
            DrawPacketConfig drawPacketConfig = new DrawPacketConfig();

            //记录日志
            Log(string.Format("查看[DrawPacketConfig]新增页面"));

            return View(drawPacketConfig);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="drawPacketConfig">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {

            int rs = CharmEventsBll.AddDrawPacketConfig(drawPacketConfig);

            //记录日志
            Log(string.Format("新增DrawPacketConfig 数据:{0}", drawPacketConfig.ToString()));

            return EditResult(rs, "操作失败", "DrawPacketConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PacketId">要查看的PacketId</param>
        /// <returns></returns>
        public ActionResult EditDrawPacketConfig(int Id)
        {
            DrawPacketConfig drawPacketConfig = CharmEventsBll.GetDrawPacketConfig(new DrawPacketConfig { Id = Id });

            //记录日志
            Log(string.Format("查看[DrawPacketConfig]]编辑页面 数据:{0}", Id));

            return View("AddDrawPacketConfig", drawPacketConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="drawPacketConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            int rs = CharmEventsBll.UpdateDrawPacketConfig(drawPacketConfig);

            //记录日志
            Log(string.Format("编辑[DrawPacketConfig]数据:{0}", drawPacketConfig.ToString()));

            return EditResult(rs, "操作失败", "DrawPacketConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="drawPacketConfig">要删除的 实际使用PacketId删除</param>
        /// <returns></returns>
        public ActionResult DelDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            bool rs = CharmEventsBll.DelDrawPacketConfig(drawPacketConfig);

            //记录日志
            Log(string.Format("删除[DrawPacketConfig]数据:{0}", drawPacketConfig.ToString()));

            return DelResult(rs, "DrawPacketConfigList");
        }

        public ActionResult SubmitDrawPacketConfigRate()
        {
            int rs = CharmEventsBll.SubmitDrawPacketConfigRate();

            //记录日志
            Log(string.Format("提交[SubmitDrawPacketConfigRate]数据:{0}", "SubmitDrawPacketConfigRate"));

            return EditResult(rs, "操作失败", "DrawPacketConfigList");
        }


        #endregion

        #region ExchangePacketTypeConfig


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult ExchangePacketTypeConfigList(DataPage dp, ExchangePacketTypeConfig model)
        {
            List<ExchangePacketTypeConfig> lists = new List<ExchangePacketTypeConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetExchangePacketTypeConfigList(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetExchangePacketTypeConfigList(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "ExchangePacketTypeConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<ExchangePacketTypeConfig, string>> showFields = new Dictionary<string, Func<ExchangePacketTypeConfig, string>>();
                showFields.Add(ExchangePacketTypeConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(ExchangePacketTypeConfig.ExchangeTypeIdField, z => "'" + z.ExchangeTypeId.ToString());
                showFields.Add(ExchangePacketTypeConfig.ExchangeTypeNameField, z => "'" + z.ExchangeTypeName.ToString());
                showFields.Add(ExchangePacketTypeConfig.ExchangeTypeDescField, z => "'" + z.ExchangeTypeDesc.ToString());
                showFields.Add(ExchangePacketTypeConfig.AccumulatePointsField, z => "'" + z.AccumulatePoints.ToString());
                showFields.Add(ExchangePacketTypeConfig.TypeLimitField, z => "'" + z.TypeLimit.ToString());
                ObjectUtil.Common.ExcelHelper2<ExchangePacketTypeConfig> elh = new ObjectUtil.Common.ExcelHelper2<ExchangePacketTypeConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[ExchangePacketTypeConfig]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddExchangePacketTypeConfig()
        {
            ExchangePacketTypeConfig exchangePacketTypeConfig = new ExchangePacketTypeConfig();

            //记录日志
            Log(string.Format("查看[ExchangePacketTypeConfig]新增页面"));

            return View(exchangePacketTypeConfig);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="exchangePacketTypeConfig">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            int rs = CharmEventsBll.AddExchangePacketTypeConfig(exchangePacketTypeConfig);

            //记录日志
            Log(string.Format("新增ExchangePacketTypeConfig 数据:{0}", exchangePacketTypeConfig.ToString()));

            return EditResult(rs, "操作失败", "ExchangePacketTypeConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ExchangeTypeId">要查看的ExchangeTypeId</param>
        /// <returns></returns>
        public ActionResult EditExchangePacketTypeConfig(int Id)
        {
            ExchangePacketTypeConfig exchangePacketTypeConfig = CharmEventsBll.GetExchangePacketTypeConfig(new ExchangePacketTypeConfig { Id = Id });

            //记录日志
            Log(string.Format("查看[ExchangePacketTypeConfig]]编辑页面 数据:{0}", Id));

            return View("AddExchangePacketTypeConfig", exchangePacketTypeConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="exchangePacketTypeConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            int rs = CharmEventsBll.UpdateExchangePacketTypeConfig(exchangePacketTypeConfig);

            //记录日志
            Log(string.Format("编辑[ExchangePacketTypeConfig]数据:{0}", exchangePacketTypeConfig.ToString()));

            return EditResult(rs, "操作失败", "ExchangePacketTypeConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="exchangePacketTypeConfig">要删除的 实际使用ExchangeTypeId删除</param>
        /// <returns></returns>
        public ActionResult DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            bool rs = CharmEventsBll.DelExchangePacketTypeConfig(exchangePacketTypeConfig);

            //记录日志
            Log(string.Format("删除[ExchangePacketTypeConfig]数据:{0}", exchangePacketTypeConfig.ToString()));

            return DelResult(rs, "ExchangePacketTypeConfigList");
        }



        #endregion

        #region ExchangePacketConfig


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult ExchangePacketConfigList(DataPage dp, ExchangePacketConfig model)
        {
            List<ExchangePacketConfig> lists = new List<ExchangePacketConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetExchangePacketConfigList(ref dp);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetExchangePacketConfigList(ref dp);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "ExchangePacketConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<ExchangePacketConfig, string>> showFields = new Dictionary<string, Func<ExchangePacketConfig, string>>();
                showFields.Add(ExchangePacketConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(ExchangePacketConfig.ExchangeIdField, z => "'" + z.ExchangeId.ToString());
                showFields.Add(ExchangePacketConfig.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(ExchangePacketConfig.PacketNameField, z => "'" + z.PacketName.ToString());
                showFields.Add(ExchangePacketConfig.PacketDescField, z => "'" + z.PacketDesc.ToString());
                showFields.Add(ExchangePacketConfig.ExchangeLimitField, z => "'" + z.ExchangeLimit.ToString());
                showFields.Add(ExchangePacketConfig.ExchangePointsField, z => "'" + z.ExchangePoints.ToString());
                showFields.Add(ExchangePacketConfig.ExchangeTypeIdField, z => "'" + z.ExchangeTypeId.ToString());
                showFields.Add(ExchangePacketConfig.PacketCountField, z => "'" + z.PacketCount.ToString());
                ObjectUtil.Common.ExcelHelper2<ExchangePacketConfig> elh = new ObjectUtil.Common.ExcelHelper2<ExchangePacketConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[ExchangePacketConfig]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddExchangePacketConfig()
        {
            ViewBag.ExchangeTypeId = GetExchangeTypeList(-1);
            ExchangePacketConfig exchangePacketConfig = new ExchangePacketConfig();

            //记录日志
            Log(string.Format("查看[ExchangePacketConfig]新增页面"));

            return View(exchangePacketConfig);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="exchangePacketConfig">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {

            int rs = CharmEventsBll.AddExchangePacketConfig(exchangePacketConfig);

            //记录日志
            Log(string.Format("新增ExchangePacketConfig 数据:{0}", exchangePacketConfig.ToString()));

            return EditResult(rs, "操作失败", "ExchangePacketConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ExchangeId">要查看的ExchangeId</param>
        /// <returns></returns>
        public ActionResult EditExchangePacketConfig(int Id)
        {
            ExchangePacketConfig exchangePacketConfig = CharmEventsBll.GetExchangePacketConfig(new ExchangePacketConfig { Id = Id });
            ViewBag.ExchangeTypeId = GetExchangeTypeList(exchangePacketConfig.ExchangeTypeId);
            //记录日志
            Log(string.Format("查看[ExchangePacketConfig]]编辑页面 数据:{0}", Id));

            return View("AddExchangePacketConfig", exchangePacketConfig);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="exchangePacketConfig">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            int rs = CharmEventsBll.UpdateExchangePacketConfig(exchangePacketConfig);

            //记录日志
            Log(string.Format("编辑[ExchangePacketConfig]数据:{0}", exchangePacketConfig.ToString()));

            return EditResult(rs, "操作失败", "ExchangePacketConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="exchangePacketConfig">要删除的 实际使用ExchangeId删除</param>
        /// <returns></returns>
        public ActionResult DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            bool rs = CharmEventsBll.DelExchangePacketConfig(exchangePacketConfig);

            //记录日志
            Log(string.Format("删除[ExchangePacketConfig]数据:{0}", exchangePacketConfig.ToString()));

            return DelResult(rs, "ExchangePacketConfigList");
        }


        #endregion

        #region BasicConfig


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult BasicConfigList()
        {
            List<BasicConfig> lists = new List<BasicConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetBasicConfigAll();
            }
            else
            {
                lists = CharmEventsBll.GetBasicConfigAll();
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "BasicConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<BasicConfig, string>> showFields = new Dictionary<string, Func<BasicConfig, string>>();
                showFields.Add(BasicConfig.ConfigIdField, z => "'" + z.ConfigId.ToString());
                showFields.Add(BasicConfig.ConfigNameField, z => "'" + z.ConfigName.ToString());
                showFields.Add(BasicConfig.ConfigValueField, z => "'" + z.ConfigValue.ToString());
                ObjectUtil.Common.ExcelHelper2<BasicConfig> elh = new ObjectUtil.Common.ExcelHelper2<BasicConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[BasicConfig]列表页面 搜索数据:{0}", "BasicConfig"));

            return View(lists);
        }


        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ConfigId">要查看的ConfigId</param>
        /// <returns></returns>
        public ActionResult EditBasicConfig(int ConfigId)
        {
            BasicConfig basicConfig = CharmEventsBll.GetBasicConfig(new BasicConfig { ConfigId = ConfigId });

            //记录日志
            Log(string.Format("查看[BasicConfig]]编辑页面 数据:{0}", ConfigId));

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
            int rs = CharmEventsBll.UpdateBasicConfig(basicConfig);

            //记录日志
            Log(string.Format("编辑[BasicConfig]数据:{0}", basicConfig.ToString()));

            return EditResult(rs, "操作失败", "BasicConfigList");
        }



        #endregion

        #region Report


        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult DailyReportTotalPeopleList(DataPage dp, DailyReportTotalPeople model)
        {
            List<DailyReportTotalPeople> lists = new List<DailyReportTotalPeople>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetDailyReportTotalPeopleList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetDailyReportTotalPeopleList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "DailyReportTotalPeopleList" + lists.Count() + "_Item";
                Dictionary<string, Func<DailyReportTotalPeople, string>> showFields = new Dictionary<string, Func<DailyReportTotalPeople, string>>();
                showFields.Add(DailyReportTotalPeople.IdField, z => "'" + z.Id.ToString());
                showFields.Add(DailyReportTotalPeople.ReportDateField, z => "'" + z.ReportDate.ToString());
                showFields.Add(DailyReportTotalPeople.DrawPacketPeopleField, z => "'" + z.DrawPacketPeople.ToString());
                showFields.Add(DailyReportTotalPeople.AllPacketPeopleField, z => "'" + z.AllPacketPeople.ToString());
                showFields.Add(DailyReportTotalPeople.CreateTsField, z => "'" + z.CreateTs.ToString());
                ObjectUtil.Common.ExcelHelper2<DailyReportTotalPeople> elh = new ObjectUtil.Common.ExcelHelper2<DailyReportTotalPeople>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[TotalPeople]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="totalPeople">要增加的实例</param>
        /// <returns></returns>
        public ActionResult RefreshDailyReportTotalPeople(DailyReportTotalPeople totalPeople)
        {
            int rs = CharmEventsBll.AddDailyReportTotalPeople(totalPeople);

            //记录日志
            Log(string.Format("新增TotalPeople 数据:{0}", totalPeople.ToString()));

            return EditResult(rs, "刷新数据失败", "DailyReportTotalPeopleList");
        }

        public ActionResult DailyReportItemConsumeList()
        {
            List<DailyReportItemConsume> lists = new List<DailyReportItemConsume>();
            DataTable viewdt = new DataTable();
            lists = CharmEventsBll.GetDailyReportItemConsumeAll();
            viewdt = TransposeOperator.ListTransposeToDT(lists, p => p.ItemName, p => p.ReportDate, p => p.TotalConsume, DailyReportItemConsume.ReportDateField);
            if (Request["btnExportExcel"] != null)//导出Excel
            {
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "DailyReportItemConsumeList" + lists.Count() + "_Item";
                ExcelHelper2 elh = new ExcelHelper2(viewdt, null);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(viewdt);

        }

        public ActionResult GameDetailsPerUserList()
        {
            List<DailyReportGameDetailsPerUser> lists = new List<DailyReportGameDetailsPerUser>();
            DataTable viewdt = new DataTable();
            lists = CharmEventsBll.GetDailyReportGameDetailsPerUserAll();
            viewdt = TransposeOperator.ListTransposeToDT(lists, p => p.StatisticalItem, p => p.FromId, p => p.StatisticalResult, DailyReportGameDetailsPerUser.FromIdField);
            List<DailyReportGameDetailsPerUser> avtarlist = (from g in lists select new DailyReportGameDetailsPerUser { FromId = g.FromId, RankOrder = g.RankOrder, AvatarName = g.AvatarName, AreaId = g.AreaId }).Distinct().ToList<DailyReportGameDetailsPerUser>();
            viewdt.Columns.Add("RankOrder", typeof(int));
            viewdt.Columns.Add("AvatarName", typeof(string));
            viewdt.Columns.Add("AreaId", typeof(int));

            foreach (DataRow dr in viewdt.Rows)
            {
                foreach (DailyReportGameDetailsPerUser peruser in avtarlist)
                {
                    if (dr["FromId"].ToString() == peruser.FromId.ToString())
                    {
                        dr["RankOrder"] = peruser.RankOrder;
                        dr["AvatarName"] = peruser.AvatarName;
                        dr["AreaId"] = peruser.AreaId;
                    }
                }
            }

            if (Request["btnExportExcel"] != null)//导出Excel
            {
                string fileName = "nothing";
                if (viewdt.Rows.Count > 0) fileName = "DailyReportGameDetailsPerUserList" + lists.Count() + "_Item";
                ExcelHelper2 elh = new ExcelHelper2(viewdt, null);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(viewdt);

        }
        public ActionResult RankTopNList(DataPage dp, DateTime? CutOffDate, RankList_TopN model)
        {
            if (CutOffDate == null)
            {
                model.CutOffDate = DateTime.Now.AddDays(-1);
            }
            model.CutOffDate = Convert.ToDateTime(model.CutOffDate.ToShortDateString().ToString() + " 23:59:59");
            List<RankList_TopN> lists = new List<RankList_TopN>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.GetRankListTopNList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.GetRankListTopNList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "RankList_TopNList" + lists.Count() + "_Item";
                Dictionary<string, Func<RankList_TopN, string>> showFields = new Dictionary<string, Func<RankList_TopN, string>>();
                showFields.Add(RankList_TopN.IdField, z => "'" + z.Id.ToString());
                showFields.Add(RankList_TopN.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(RankList_TopN.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(RankList_TopN.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(RankList_TopN.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(RankList_TopN.AreaNameField, z => "'" + z.AreaName.ToString());
                showFields.Add(RankList_TopN.GetPointsField, z => "'" + z.GetPoints.ToString());
                showFields.Add(RankList_TopN.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(RankList_TopN.RankOrderField, z => "'" + z.RankOrder.ToString());
                showFields.Add(RankList_TopN.GetLastTimeField, z => "'" + z.GetLastTime.ToString());
                showFields.Add(RankList_TopN.CutOffDateField, z => "'" + z.CutOffDate.ToString());
                ExcelHelper2<RankList_TopN> elh = new ExcelHelper2<RankList_TopN>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }

        public ActionResult RefreshTopNList()
        {
            int rs = CharmEventsBll.RefreshTopNList();

            //记录日志
            Log(string.Format("提交[RefreshTop]数据:{0}", "RefreshTopNList"));

            return Success("RankTopNList");
        }

        #endregion


        #region 代码生成器生成|TransferData_All_ReportDateConfig
        public ActionResult TransferDataAllReportDateConfigList(DataPage dp, TransferData_All_ReportDateConfig model)
        {
            List<TransferData_All_ReportDateConfig> lists = new List<TransferData_All_ReportDateConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.TransferDataAllReportDateConfigGetList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.TransferDataAllReportDateConfigGetList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "TransferData_All_ReportDateConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<TransferData_All_ReportDateConfig, string>> showFields = new Dictionary<string, Func<TransferData_All_ReportDateConfig, string>>();
                showFields.Add(TransferData_All_ReportDateConfig.ConfigIdField, z => "'" + z.ConfigId.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.ConfigNameField, z => "'" + z.ConfigName.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.StatusField, z => "'" + z.Status.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.ReportIdField, z => "'" + z.ReportId.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.StartTimeField, z => "'" + z.StartTime.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.EndTimeField, z => "'" + z.EndTime.ToString());
                showFields.Add(TransferData_All_ReportDateConfig.CreateTimeField, z => "'" + z.CreateTime.ToString());
                ExcelHelper2<TransferData_All_ReportDateConfig> elh = new ExcelHelper2<TransferData_All_ReportDateConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTransferDataAllReportDateConfig()
        {
            TransferData_All_ReportDateConfig all = new TransferData_All_ReportDateConfig();
            all.CreateTime = System.DateTime.Now;

            //记录日志
            Log(string.Format("查看[All]新增页面"));

            return View(all);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="all">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTransferDataAllReportDateConfig(TransferData_All_ReportDateConfig all)
        {
            all.CreateTime = System.DateTime.Now;
            int rs = CharmEventsBll.TransferDataAllReportDateConfigAdd(all);

            //记录日志
            Log(string.Format("新增All 数据:{0}", all.ToString()));

            return EditResult(rs, "操作失败", "TransferDataAllReportDateConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ConfigId">要查看的ConfigId</param>
        /// <returns></returns>
        public ActionResult EditTransferDataAllReportDateConfig(int ConfigId)
        {
            TransferData_All_ReportDateConfig all = CharmEventsBll.TransferDataAllReportDateConfigGetByConfigId(new TransferData_All_ReportDateConfig { ConfigId = ConfigId });

            //记录日志
            Log(string.Format("查看[All]]编辑页面 数据:{0}", ConfigId));

            return View("AddTransferDataAllReportDateConfig", all);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="all">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTransferDataAllReportDateConfig(TransferData_All_ReportDateConfig all)
        {
            int rs = CharmEventsBll.TransferDataAllReportDateConfigUpdate(all);

            //记录日志
            Log(string.Format("编辑[All]数据:{0}", all.ToString()));

            return EditResult(rs, "操作失败", "TransferDataAllReportDateConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="all">要删除的 实际使用ConfigId删除</param>
        /// <returns></returns>
        public ActionResult DelTransferDataAllReportDateConfig(TransferData_All_ReportDateConfig all)
        {
            bool rs = CharmEventsBll.TransferDataAllReportDateConfigDel(all);

            //记录日志
            Log(string.Format("删除[All]数据:{0}", all.ToString()));

            return DelResult(rs, "TransferDataAllReportDateConfigList");
        }


        #endregion

        #region 代码生成器生成|TransferData_GameDetails_ItemConfig
        public ActionResult TransferDataGameDetailsItemConfigList(DataPage dp, TransferData_GameDetails_ItemConfig model)
        {
            List<TransferData_GameDetails_ItemConfig> lists = new List<TransferData_GameDetails_ItemConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.TransferDataGameDetailsItemConfigGetList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.TransferDataGameDetailsItemConfigGetList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "TransferData_GameDetails_ItemConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<TransferData_GameDetails_ItemConfig, string>> showFields = new Dictionary<string, Func<TransferData_GameDetails_ItemConfig, string>>();
                showFields.Add(TransferData_GameDetails_ItemConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(TransferData_GameDetails_ItemConfig.ItemIdField, z => "'" + z.ItemId.ToString());
                showFields.Add(TransferData_GameDetails_ItemConfig.ItemNameField, z => "'" + z.ItemName.ToString());
                showFields.Add(TransferData_GameDetails_ItemConfig.ShowNameField, z => "'" + z.ShowName.ToString());
                showFields.Add(TransferData_GameDetails_ItemConfig.StatusField, z => "'" + z.Status.ToString());
                ExcelHelper2<TransferData_GameDetails_ItemConfig> elh = new ExcelHelper2<TransferData_GameDetails_ItemConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTransferDataGameDetailsItemConfig()
        {
            TransferData_GameDetails_ItemConfig gameDetails = new TransferData_GameDetails_ItemConfig();

            //记录日志
            Log(string.Format("查看[GameDetails]新增页面"));

            return View(gameDetails);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="gameDetails">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTransferDataGameDetailsItemConfig(TransferData_GameDetails_ItemConfig gameDetails)
        {
            int rs = CharmEventsBll.TransferDataGameDetailsItemConfigAdd(gameDetails);

            //记录日志
            Log(string.Format("新增GameDetails 数据:{0}", gameDetails.ToString()));

            return EditResult(rs, "操作失败", "TransferDataGameDetailsItemConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ItemId">要查看的ItemId</param>
        /// <returns></returns>
        public ActionResult EditTransferDataGameDetailsItemConfig(int ItemId)
        {
            TransferData_GameDetails_ItemConfig gameDetails = CharmEventsBll.TransferDataGameDetailsItemConfigGetByItemId(new TransferData_GameDetails_ItemConfig { ItemId = ItemId });

            //记录日志
            Log(string.Format("查看[GameDetails]]编辑页面 数据:{0}", ItemId));

            return View("AddTransferDataGameDetailsItemConfig", gameDetails);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="gameDetails">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTransferDataGameDetailsItemConfig(TransferData_GameDetails_ItemConfig gameDetails)
        {
            int rs = CharmEventsBll.TransferDataGameDetailsItemConfigUpdate(gameDetails);

            //记录日志
            Log(string.Format("编辑[GameDetails]数据:{0}", gameDetails.ToString()));

            return EditResult(rs, "操作失败", "TransferDataGameDetailsItemConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="gameDetails">要删除的 实际使用ItemId删除</param>
        /// <returns></returns>
        public ActionResult DelTransferDataGameDetailsItemConfig(TransferData_GameDetails_ItemConfig gameDetails)
        {
            bool rs = CharmEventsBll.TransferDataGameDetailsItemConfigDel(gameDetails);

            //记录日志
            Log(string.Format("删除[GameDetails]数据:{0}", gameDetails.ToString()));

            return DelResult(rs, "TransferDataGameDetailsItemConfigList");
        }

        [HttpPost]
        public ActionResult SynchroniseGameDetailsConsumeItemConfig(List<string> ItemSelect)
        {
            int rs = 0;
            if (ItemSelect.Count() < 1)
            { return UnSuccessful("操作失败", "TransferDataGameDetailsItemConfigList"); }
            foreach (string item in ItemSelect)
            {
                TransferData_GameDetails_ItemConfig consumeitem = CharmEventsBll.TransferDataGameDetailsItemConfigGetByItemId(new TransferData_GameDetails_ItemConfig() { ItemId = Convert.ToInt32(item) });

                Mapper.CreateMap<TransferData_GameDetails_ItemConfig, TransferData_ItemConsume_ItemConfig>();
                TransferData_ItemConsume_ItemConfig gameitem = Mapper.Map<TransferData_ItemConsume_ItemConfig>(consumeitem);
                rs = CharmEventsBll.TransferDataItemConsumeItemConfigAdd(gameitem);
            }
            if (rs < ItemSelect.Count())
                return UnSuccessful("部分数据操作失败", "TransferDataItemConsumeItemConfigList");
            else
                return Success("TransferDataItemConsumeItemConfigList");
        }

        #endregion

        #region 代码生成器生成|TransferData_GameDetails_UsersConfig
        public ActionResult TransferDataGameDetailsUsersConfigList(DataPage dp, TransferData_GameDetails_UsersConfig model)
        {
            List<TransferData_GameDetails_UsersConfig> lists = new List<TransferData_GameDetails_UsersConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.TransferDataGameDetailsUsersConfigGetList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.TransferDataGameDetailsUsersConfigGetList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "TransferData_GameDetails_UsersConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<TransferData_GameDetails_UsersConfig, string>> showFields = new Dictionary<string, Func<TransferData_GameDetails_UsersConfig, string>>();
                showFields.Add(TransferData_GameDetails_UsersConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.RankOrderField, z => "'" + z.RankOrder.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.AreaIdField, z => "'" + z.AreaId.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(TransferData_GameDetails_UsersConfig.FromIdField, z => "'" + z.FromId.ToString());
                ExcelHelper2<TransferData_GameDetails_UsersConfig> elh = new ExcelHelper2<TransferData_GameDetails_UsersConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }


        ///// <summary>
        ///// 增加
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult AddTransferDataGameDetailsUsersConfig()
        //{
        //    TransferData_GameDetails_UsersConfig gameDetails = new TransferData_GameDetails_UsersConfig();

        //    //记录日志
        //    Log(string.Format("查看[GameDetails]新增页面"));

        //    return View(gameDetails);
        //}

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="gameDetails">要增加的实例</param>
        /// <returns></returns>
        public ActionResult AddTransferDataGameDetailsUsersConfig(long Id)
        {
            DataPage dp = new DataPage { PageSize = 0, PageIndex = 1 };
            RankList_TopN userconfig = CharmEventsBll.GetRankListTopNList(ref dp, new RankList_TopN { Id = Id, CutOffDate = Convert.ToDateTime("1900/1/1 23:59:59") }).SingleOrDefault();
            if (userconfig == null)
            {
                return UnSuccessful("操作失败");
            }
            TransferData_GameDetails_UsersConfig gameDetails = new TransferData_GameDetails_UsersConfig();
            gameDetails.UserId = userconfig.UserId;
            gameDetails.RankOrder = userconfig.RankOrder;
            gameDetails.AreaId = userconfig.AreaId;
            gameDetails.AvatarId = userconfig.AvatarId;
            gameDetails.AvatarName = userconfig.AvatarName;
            gameDetails.CreateTime = System.DateTime.Now;
            gameDetails.FromId = userconfig.Id;
            int rs = CharmEventsBll.TransferDataGameDetailsUsersConfigAdd(gameDetails);

            //记录日志
            Log(string.Format("新增GameDetails 数据:{0}", gameDetails.ToString()));

            return EditResult(rs, "操作失败", "TransferDataGameDetailsUsersConfigList");
        }

        public ActionResult BatchAddTransferDataGameDetailsUsersConfig(long startid, long endid)
        {
            DataPage dp = new DataPage { PageSize = 0, PageIndex = 1 };
            List<RankList_TopN> userranks = CharmEventsBll.GetRankListTopNList(ref dp, new RankList_TopN() { CutOffDate = Convert.ToDateTime("1900/1/1 23:59:59") }).Where(p => p.Id >= startid).Where(p => p.Id <= endid).ToList<RankList_TopN>();
            if (userranks == null)
            {
                return UnSuccessful("操作失败", "TransferDataGameDetailsUsersConfigList");
            }
            List<TransferData_GameDetails_UsersConfig> listuserconfig = new List<TransferData_GameDetails_UsersConfig>();
            foreach (RankList_TopN userrank in userranks)
            {
                TransferData_GameDetails_UsersConfig userconfig = new TransferData_GameDetails_UsersConfig();
                userconfig.UserId = userrank.UserId;
                userconfig.RankOrder = userrank.RankOrder;
                userconfig.AreaId = userrank.AreaId;
                userconfig.AvatarId = userrank.AvatarId;
                userconfig.AvatarName = userrank.AvatarName;
                userconfig.CreateTime = System.DateTime.Now;
                userconfig.FromId = userrank.Id;
                listuserconfig.Add(userconfig);
            }
            int rs = CharmEventsBll.TransferDataGameDetailsUsersConfigBatchAdd(listuserconfig);
            if (rs < listuserconfig.Count())
                return UnSuccessful("操作失败", "TransferDataGameDetailsUsersConfigList");
            return Success("TransferDataGameDetailsUsersConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="Id">要查看的Id</param>
        /// <returns></returns>
        public ActionResult EditTransferDataGameDetailsUsersConfig(long Id)
        {
            TransferData_GameDetails_UsersConfig gameDetails = CharmEventsBll.TransferDataGameDetailsUsersConfigGetById(new TransferData_GameDetails_UsersConfig { Id = Id });

            //记录日志
            Log(string.Format("查看[GameDetails]]编辑页面 数据:{0}", Id));

            return View("AddTransferDataGameDetailsUsersConfig", gameDetails);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="gameDetails">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTransferDataGameDetailsUsersConfig(TransferData_GameDetails_UsersConfig gameDetails)
        {
            int rs = CharmEventsBll.TransferDataGameDetailsUsersConfigUpdate(gameDetails);

            //记录日志
            Log(string.Format("编辑[GameDetails]数据:{0}", gameDetails.ToString()));

            return EditResult(rs, "操作失败", "TransferDataGameDetailsUsersConfigList");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gameDetails">要删除的 实际使用Id删除</param>
        /// <returns></returns>
        public ActionResult DelTransferDataGameDetailsUsersConfig(TransferData_GameDetails_UsersConfig gameDetails)
        {
            bool rs = CharmEventsBll.TransferDataGameDetailsUsersConfigDel(gameDetails);

            //记录日志
            Log(string.Format("删除[GameDetails]数据:{0}", gameDetails.ToString()));

            return DelResult(rs, "TransferDataGameDetailsUsersConfigList");
        }

        #endregion

        #region 代码生成器生成|TransferData_ItemConsume_ItemConfig
        public ActionResult TransferDataItemConsumeItemConfigList(DataPage dp, TransferData_ItemConsume_ItemConfig model)
        {
            List<TransferData_ItemConsume_ItemConfig> lists = new List<TransferData_ItemConsume_ItemConfig>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = CharmEventsBll.TransferDataItemConsumeItemConfigGetList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = CharmEventsBll.TransferDataItemConsumeItemConfigGetList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "TransferData_ItemConsume_ItemConfigList" + lists.Count() + "_Item";
                Dictionary<string, Func<TransferData_ItemConsume_ItemConfig, string>> showFields = new Dictionary<string, Func<TransferData_ItemConsume_ItemConfig, string>>();
                showFields.Add(TransferData_ItemConsume_ItemConfig.IdField, z => "'" + z.Id.ToString());
                showFields.Add(TransferData_ItemConsume_ItemConfig.ItemIdField, z => "'" + z.ItemId.ToString());
                showFields.Add(TransferData_ItemConsume_ItemConfig.ItemNameField, z => "'" + z.ItemName.ToString());
                showFields.Add(TransferData_ItemConsume_ItemConfig.ShowNameField, z => "'" + z.ShowName.ToString());
                showFields.Add(TransferData_ItemConsume_ItemConfig.StatusField, z => "'" + z.Status.ToString());
                ExcelHelper2<TransferData_ItemConsume_ItemConfig> elh = new ExcelHelper2<TransferData_ItemConsume_ItemConfig>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            return View(lists);

        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTransferDataItemConsumeItemConfig()
        {
            TransferData_ItemConsume_ItemConfig itemConsume = new TransferData_ItemConsume_ItemConfig();

            //记录日志
            Log(string.Format("查看[ItemConsume]新增页面"));

            return View(itemConsume);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="itemConsume">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTransferDataItemConsumeItemConfig(TransferData_ItemConsume_ItemConfig itemConsume)
        {
            int rs = CharmEventsBll.TransferDataItemConsumeItemConfigAdd(itemConsume);

            //记录日志
            Log(string.Format("新增ItemConsume 数据:{0}", itemConsume.ToString()));

            return EditResult(rs, "操作失败", "TransferDataItemConsumeItemConfigList");
        }

        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="ItemId">要查看的ItemId</param>
        /// <returns></returns>
        public ActionResult EditTransferDataItemConsumeItemConfig(int ItemId)
        {
            TransferData_ItemConsume_ItemConfig itemConsume = CharmEventsBll.TransferDataItemConsumeItemConfigGetByItemId(new TransferData_ItemConsume_ItemConfig { ItemId = ItemId });

            //记录日志
            Log(string.Format("查看[ItemConsume]]编辑页面 数据:{0}", ItemId));

            return View("AddTransferDataItemConsumeItemConfig", itemConsume);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="itemConsume">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTransferDataItemConsumeItemConfig(TransferData_ItemConsume_ItemConfig itemConsume)
        {
            int rs = CharmEventsBll.TransferDataItemConsumeItemConfigUpdate(itemConsume);

            //记录日志
            Log(string.Format("编辑[ItemConsume]数据:{0}", itemConsume.ToString()));

            return EditResult(rs, "操作失败", "TransferDataItemConsumeItemConfigList");
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="itemConsume">要删除的 实际使用ItemId删除</param>
        /// <returns></returns>
        public ActionResult DelTransferDataItemConsumeItemConfig(TransferData_ItemConsume_ItemConfig itemConsume)
        {
            bool rs = CharmEventsBll.TransferDataItemConsumeItemConfigDel(itemConsume);

            //记录日志
            Log(string.Format("删除[ItemConsume]数据:{0}", itemConsume.ToString()));

            return DelResult(rs, "TransferDataItemConsumeItemConfigList");
        }

        [HttpPost]
        public ActionResult SynchroniseConsumeItemConfig(List<string> ItemSelect)
        {
            int rs = 0;
            if (ItemSelect.Count() < 1)
            { return UnSuccessful( "操作失败", "TransferDataItemConsumeItemConfigList"); }
            foreach (string item in ItemSelect)
            {
                TransferData_ItemConsume_ItemConfig consumeitem = CharmEventsBll.TransferDataItemConsumeItemConfigGetByItemId(new TransferData_ItemConsume_ItemConfig() { ItemId = Convert.ToInt32(item) });

                Mapper.CreateMap<TransferData_ItemConsume_ItemConfig, TransferData_GameDetails_ItemConfig>();
                TransferData_GameDetails_ItemConfig gameitem = Mapper.Map<TransferData_GameDetails_ItemConfig>(consumeitem);
                rs = CharmEventsBll.TransferDataGameDetailsItemConfigAdd(gameitem);
            }
            if (rs < ItemSelect.Count())
                return UnSuccessful("部分数据操作失败", "TransferDataGameDetailsItemConfigList");
            else
                return Success("TransferDataGameDetailsItemConfigList");
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

        private SelectList GetExchangeTypeList(int? ExchangeTypeId)
        {
            int TypeId = ExchangeTypeId ?? -1;
            List<ExchangePacketTypeConfig> enumItem = new List<ExchangePacketTypeConfig>();
            enumItem.Add(new ExchangePacketTypeConfig { ExchangeTypeId = -1, ExchangeTypeName = "请选择" });
            DataPage dp = new DataPage() { PageIndex = 1, PageSize = 0 };
            enumItem.AddRange(CharmEventsBll.GetExchangePacketTypeConfigList(ref dp));
            var list = new SelectList(enumItem, ExchangePacketTypeConfig.ExchangeTypeIdField, ExchangePacketTypeConfig.ExchangeTypeNameField, TypeId);
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

        #region ImportCSV
        public ActionResult ImportExcel()
        {

            ViewBag.Typeid = ImportType();
            return View();

        }
        [HttpPost]
        public ActionResult ImportExcel(string Typeid, HttpPostedFileBase file)
        {
            ViewBag.Typeid = ImportType();
            string fileEx = System.IO.Path.GetExtension(file.FileName);
            if (!fileEx.ToLower().Equals(".csv"))
            {
                return UnSuccessful("导入文件格式不正确", "ImportExcel");
            }
            DataTable dt = new DataTable();
            dt = importCSV(file);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            int rs = CharmEventsBll.importCSVtoDB(ds, Typeid);
            if (rs == 1)
            {
                return Success("ImportExcel");
            }

            return UnSuccessful("导入失败", "ImportExcel");
        }



        private SelectList ImportType(string typeid = "-1")
        {
            var enumItem = new List<ObjectUtil.Common.EnumItem>();
            enumItem.Insert(0, new ObjectUtil.Common.EnumItem { ItemValue = "-1", ItemDescription = "请选择" });
            enumItem.Insert(1, new ObjectUtil.Common.EnumItem { ItemValue = "DrawPacketConfig", ItemDescription = "抽奖礼包及概率表" });
            enumItem.Insert(2, new ObjectUtil.Common.EnumItem { ItemValue = "ExchangePacketConfig", ItemDescription = "阶梯礼包" });
            var list = new SelectList(enumItem, ObjectUtil.Common.EnumItem.ItemValueField, ObjectUtil.Common.EnumItem.ItemDescriptionField, typeid);
            return list;
        }

        public DataTable importCSV(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();
            StreamReader sr = new StreamReader(file.InputStream, System.Text.Encoding.Default);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)
                {

                    columnCount = aryLine.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        dt.Columns.Add(dc);
                    }
                    IsFirst = false;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            sr.Close();
            //fs.Close();
            return dt;
        }
        #endregion
    }
}

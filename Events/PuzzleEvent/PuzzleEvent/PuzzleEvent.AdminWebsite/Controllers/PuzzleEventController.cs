using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPage.BaseController;
using PuzzleEvent.Database.Database;

namespace PuzzleEvent.AdminWebsite.Controllers
{
    public class PuzzleEventController : SupervisorController
    {
        private PuzzleEvent.DAL.AdminWCF.Client.PuzzleEventAdminServiceClient _adminBLL = new DAL.AdminWCF.Client.PuzzleEventAdminServiceClient();

        private readonly PuzzleEvent.DAL.Admin.PuzzleEventAdmin dal = new DAL.Admin.PuzzleEventAdmin();

        private DateTime StartTime = AppSetting.GetDateTime("StartTime");
        private DateTime EndTime = AppSetting.GetDateTime("EndTime");

        //
        // GET: /PuzzleEvent/


        public ActionResult Index()
        {
            return View();
        }

        #region 添加积分

        public ActionResult WalletList(DataPage dp, Wallet model)
        {
            List<Wallet> lists = new List<Wallet>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetWalletList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetWalletList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "WalletList" + lists.Count() + "_Item";
                Dictionary<string, Func<Wallet, string>> showFields = new Dictionary<string, Func<Wallet, string>>();
                showFields.Add(Wallet.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(Wallet.LoginNameField, z => "'" + z.LoginName.ToString());
                showFields.Add(Wallet.GameAreaIdField, z => "'" + z.GameAreaId.ToString());
                showFields.Add(Wallet.TotalPointsField, z => "'" + z.TotalPoints.ToString());
                showFields.Add(Wallet.BalancePointsField, z => "'" + z.BalancePoints.ToString());
                showFields.Add(Wallet.NoteField, z => "'" + z.Note.ToString());
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
            Wallet wallet = new Wallet();
            ViewBag.GameAreaId = GetGameAreaList();
            //记录日志
            Log(string.Format("查看[Wallet]新增页面"));

            return View(wallet);
        }

        /// <summary>
        /// 增加 数据提交
        /// </summary>
        /// <param name="wallet">要增加的实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddWallet(Wallet wallet)
        {
            wallet.LoginName = "后台增加（测试）";
            wallet.TotalPoints = wallet.BalancePoints;
            //wallet.Note = "后台增加";
            wallet.CreateTime = DateTime.Now;
            long rs = _adminBLL.AddWallet(wallet);

            //记录日志
            Log(string.Format("新增Wallet 数据:{0}", wallet.ToString()));

            return EditResult(rs, "名称不能重复", "WalletList");
        }
        #endregion

        #region 明细列表
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzleReceiveDetailsList(DataPage dp, PuzzleReceiveDetails model, int? AreaID)
        {

            model.AreaID = AreaID ?? -1;
            ViewBag.AreaID = GetGameAreaList(model.AreaID);
            ViewBag.PuzzleTypeId = GetPuzzleTypeId(model.PuzzleTypeId);
            List<PuzzleReceiveDetails> lists = new List<PuzzleReceiveDetails>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzleReceiveDetailsList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzleReceiveDetailsList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzleReceiveDetailsList" + lists.Count() + "_Item";
                Dictionary<string, Func<PuzzleReceiveDetails, string>> showFields = new Dictionary<string, Func<PuzzleReceiveDetails, string>>();

                showFields.Add(PuzzleReceiveDetails.ReceivePuzzleIDField, z => "'" + z.ReceivePuzzleID.ToString());
                showFields.Add(PuzzleReceiveDetails.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(PuzzleReceiveDetails.AreaIDField, z => "'" + z.AreaID.ToString());
                showFields.Add(PuzzleReceiveDetails.AvatarIDField, z => "'" + z.AvatarID.ToString());
                showFields.Add(PuzzleReceiveDetails.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(PuzzleReceiveDetails.PuzzleIDField, z => "'" + z.PuzzleID.ToString());
                showFields.Add(PuzzleReceiveDetails.PuzzleTypeIdField, z => "'" + z.PuzzleTypeId.ToString());

                ObjectUtil.Common.ExcelHelper2<PuzzleReceiveDetails> elh = new ObjectUtil.Common.ExcelHelper2<PuzzleReceiveDetails>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PuzzleReceiveDetails]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult UserPiecesTotalList(DataPage dp, UserPiecesTotal model, int? AreaID, int? PuzzleTypeID)
        {

            model.AreaID = AreaID ?? -1;
            model.PuzzleTypeID = PuzzleTypeID ?? -1;
            ViewBag.AreaID = GetGameAreaList(model.AreaID);
            ViewBag.PuzzleTypeId = GetPuzzleTypeId(model.PuzzleTypeID);
            List<UserPiecesTotal> lists = new List<UserPiecesTotal>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetUserPiecesTotalList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetUserPiecesTotalList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "UserPiecesTotalList" + lists.Count() + "_Item";
                Dictionary<string, Func<UserPiecesTotal, string>> showFields = new Dictionary<string, Func<UserPiecesTotal, string>>();

                showFields.Add(UserPiecesTotal.RecordIDField, z => "'" + z.RecordID.ToString());
                showFields.Add(UserPiecesTotal.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(UserPiecesTotal.AreaIDField, z => "'" + z.AreaID.ToString());
                showFields.Add(UserPiecesTotal.PiecesTotalField, z => "'" + z.PiecesTotal.ToString());
                showFields.Add(UserPiecesTotal.PiecesConsumeField, z => "'" + z.PiecesConsume.ToString());
                showFields.Add(UserPiecesTotal.PiecesBalanceField, z => "'" + z.PiecesBalance.ToString());
                showFields.Add(UserPiecesTotal.PiecesOccupiedField, z => "'" + z.PiecesOccupied.ToString());
                showFields.Add(UserPiecesTotal.PuzzleTypeIDField, z => "'" + z.PuzzleTypeID.ToString());

                ObjectUtil.Common.ExcelHelper2<UserPiecesTotal> elh = new ObjectUtil.Common.ExcelHelper2<UserPiecesTotal>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[UserPiecesTotal]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzleDrawDetailsList(DataPage dp, PuzzleDrawDetails model, int? AreaID)
        {
            model.AreaID = AreaID ?? -1;
            ViewBag.AreaID = GetGameAreaList(model.AreaID);
            ViewBag.PuzzleTypeId = GetPuzzleTypeId(model.PuzzleTypeId);
            ViewBag.DrawCount = GetDrawCount(model.DrawCount);
            List<PuzzleDrawDetails> lists = new List<PuzzleDrawDetails>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzleDrawDetailsList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzleDrawDetailsList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzleDrawDetailsList" + lists.Count() + "_Item";
                Dictionary<string, Func<PuzzleDrawDetails, string>> showFields = new Dictionary<string, Func<PuzzleDrawDetails, string>>();

                showFields.Add(PuzzleDrawDetails.PuzzleDrawIDField, z => "'" + z.PuzzleDrawID.ToString());
                showFields.Add(PuzzleDrawDetails.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(PuzzleDrawDetails.AreaIDField, z => "'" + z.AreaID.ToString());
                showFields.Add(PuzzleDrawDetails.AvatarIDField, z => "'" + z.AvatarID.ToString());
                showFields.Add(PuzzleDrawDetails.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(PuzzleDrawDetails.DrawCountField, z => "'" + z.DrawCount.ToString());
                showFields.Add(PuzzleDrawDetails.ActualCountField, z => "'" + z.ActualCount.ToString());
                showFields.Add(PuzzleDrawDetails.PuzzleTypeIdField, z => "'" + z.PuzzleTypeId.ToString());
                showFields.Add(PuzzleDrawDetails.PointsField, z => "'" + z.Points.ToString());
                showFields.Add(PuzzleDrawDetails.AvatarNameField, z => "'" + z.AvatarName.ToString());
                showFields.Add(PuzzleDrawDetails.LoginNameField, z => "'" + z.LoginName.ToString());

                ObjectUtil.Common.ExcelHelper2<PuzzleDrawDetails> elh = new ObjectUtil.Common.ExcelHelper2<PuzzleDrawDetails>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PuzzleDrawDetails]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PacketQueueLogList(DataPage dp, PacketQueueLog model, int? AreaID)
        {
            model.GameArea = AreaID ?? -1;
            ViewBag.AreaID = GetGameAreaList(model.GameArea);
            ViewBag.Source = GetSource(model.Source);
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPacketQueueLogList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPacketQueueLogList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PacketQueueLogList" + lists.Count() + "_Item";
                Dictionary<string, Func<PacketQueueLog, string>> showFields = new Dictionary<string, Func<PacketQueueLog, string>>();

                showFields.Add(PacketQueueLog.LogIdField, z => "'" + z.LogId.ToString());
                showFields.Add(PacketQueueLog.IdField, z => "'" + z.Id.ToString());
                showFields.Add(PacketQueueLog.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(PacketQueueLog.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(PacketQueueLog.SexField, z => "'" + z.Sex.ToString());
                showFields.Add(PacketQueueLog.GameAreaField, z => "'" + z.GameArea.ToString());
                showFields.Add(PacketQueueLog.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(PacketQueueLog.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(PacketQueueLog.SourceField, z => "'" + z.Source.ToString());

                ObjectUtil.Common.ExcelHelper2<PacketQueueLog> elh = new ObjectUtil.Common.ExcelHelper2<PacketQueueLog>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PacketQueueLog]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PiecesPacketDetailsList(DataPage dp, PiecesPacketDetails model, int? AreaID, int? IsPuzzle)
        {
            model.AreaID = AreaID ?? -1;
            model.IsPuzzle = IsPuzzle ?? -1;
            ViewBag.AreaID = GetGameAreaList(model.AreaID);
            ViewBag.IsPuzzle = GetIsPuzzle(model.IsPuzzle);
            List<PiecesPacketDetails> lists = new List<PiecesPacketDetails>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPiecesPacketDetailsList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPiecesPacketDetailsList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PiecesPacketDetailsList" + lists.Count() + "_Item";
                Dictionary<string, Func<PiecesPacketDetails, string>> showFields = new Dictionary<string, Func<PiecesPacketDetails, string>>();

                showFields.Add(PiecesPacketDetails.ReceiveIDField, z => "'" + z.ReceiveID.ToString());
                showFields.Add(PiecesPacketDetails.UserIDField, z => "'" + z.UserID.ToString());
                showFields.Add(PiecesPacketDetails.AreaIDField, z => "'" + z.AreaID.ToString());
                showFields.Add(PiecesPacketDetails.AvatarIDField, z => "'" + z.AvatarID.ToString());
                showFields.Add(PiecesPacketDetails.CreateTSField, z => "'" + z.CreateTS.ToString());
                showFields.Add(PiecesPacketDetails.PointsField, z => "'" + z.Points.ToString());
                showFields.Add(PiecesPacketDetails.IsPuzzleField, z => "'" + z.IsPuzzle.ToString());
                showFields.Add(PiecesPacketDetails.PuzzlePacketIDField, z => "'" + z.PuzzlePacketID.ToString());
                showFields.Add(PiecesPacketDetails.PuzzlePieceIdField, z => "'" + z.PuzzlePieceId.ToString());
                showFields.Add(PiecesPacketDetails.PuzzleDrawIDField, z => "'" + z.PuzzleDrawID.ToString());

                ObjectUtil.Common.ExcelHelper2<PiecesPacketDetails> elh = new ObjectUtil.Common.ExcelHelper2<PiecesPacketDetails>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PiecesPacketDetails]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>





        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult ExchangePacketReceiveList(DataPage dp, ExchangePacketReceive model, int? GameArea)
        {
            model.GameArea = GameArea ?? -1;
            ViewBag.PuzzleTypeID = GetPuzzleTypeId(model.PuzzleTypeID);
            ViewBag.GameArea = GetGameAreaList(model.GameArea);
            List<ExchangePacketReceive> lists = new List<ExchangePacketReceive>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetExchangePacketReceiveList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetExchangePacketReceiveList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "ExchangePacketReceiveList" + lists.Count() + "_Item";
                Dictionary<string, Func<ExchangePacketReceive, string>> showFields = new Dictionary<string, Func<ExchangePacketReceive, string>>();

                showFields.Add(ExchangePacketReceive.ExchangeIdField, z => "'" + z.ExchangeId.ToString());
                showFields.Add(ExchangePacketReceive.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(ExchangePacketReceive.AvatarIdField, z => "'" + z.AvatarId.ToString());
                showFields.Add(ExchangePacketReceive.SexField, z => "'" + z.Sex.ToString());
                showFields.Add(ExchangePacketReceive.GameAreaField, z => "'" + z.GameArea.ToString());
                showFields.Add(ExchangePacketReceive.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(ExchangePacketReceive.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(ExchangePacketReceive.PiecesCountField, z => "'" + z.PiecesCount.ToString());
                showFields.Add(ExchangePacketReceive.PuzzleTypeIDField, z => "'" + z.PuzzleTypeID.ToString());

                ObjectUtil.Common.ExcelHelper2<ExchangePacketReceive> elh = new ObjectUtil.Common.ExcelHelper2<ExchangePacketReceive>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[ExchangePacketReceive]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }





        #endregion

        #region 后台配置
        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PacketId">要查看的PacketId</param>
        /// <returns></returns>
        public ActionResult EditExchangePacket(int PacketId, int PuzzleTypeID)
        {
            ExchangePacket exchange = new ExchangePacket();
            exchange.PacketId = PacketId;
            exchange.PuzzleTypeID = PuzzleTypeID;
            ExchangePacket exchangePacket = _adminBLL.GetExchangePacket(exchange);

            //记录日志
            Log(string.Format("查看[ExchangePacket]]编辑页面 数据:{0}", PacketId));

            return View("EditExchangePacket", exchangePacket);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="exchangePacket">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditExchangePacket(ExchangePacket exchangePacket)
        {
            long rs = _adminBLL.UpdateExchangePacket(exchangePacket);

            //记录日志
            Log(string.Format("编辑[ExchangePacket]数据:{0}", exchangePacket.ToString()));

            return EditResult(rs, "名称不能重复", "ExchangePacketList");
        }




        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PuzzleId">要查看的PuzzleId</param>
        /// <returns></returns>
        public ActionResult EditPuzzle(int PuzzleId)
        {
            Puzzle puz = new Puzzle();
            puz.PuzzleId = PuzzleId;
            Puzzle puzzle = _adminBLL.GetPuzzle(puz);

            //记录日志
            Log(string.Format("查看[Puzzle]]编辑页面 数据:{0}", PuzzleId));

            return View("EditPuzzle", puzzle);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="puzzle">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPuzzle(Puzzle puzzle)
        {
            int rs = _adminBLL.UpdatePuzzle(puzzle);

            //记录日志
            Log(string.Format("编辑[Puzzle]数据:{0}", puzzle.ToString()));

            return EditResult(rs, "名称不能重复", "PuzzleList");
        }



        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PuzzlePacketId">要查看的PuzzlePacketId</param>
        /// <returns></returns>
        public ActionResult EditPuzzlePacket(int PuzzlePacketId)
        {
            PuzzlePacket puzpacket = new PuzzlePacket();
            puzpacket.PuzzlePacketId = PuzzlePacketId;
            PuzzlePacket puzzlePacket = _adminBLL.GetPuzzlePacket(puzpacket);

            //记录日志
            Log(string.Format("查看[PuzzlePacket]]编辑页面 数据:{0}", PuzzlePacketId));

            return View("EditPuzzlePacket", puzzlePacket);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="puzzlePacket">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPuzzlePacket(PuzzlePacket puzzlePacket)
        {
            int rs = _adminBLL.UpdatePuzzlePacket(puzzlePacket);

            //记录日志
            Log(string.Format("编辑[PuzzlePacket]数据:{0}", puzzlePacket.ToString()));

            return EditResult(rs, "名称不能重复", "PuzzlePacketList");
        }



        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PuzzlePieceId">要查看的PuzzlePieceId</param>
        /// <returns></returns>
        public ActionResult EditPuzzlePieces(int PuzzlePieceId)
        {
            PuzzlePieces puzpieces = new PuzzlePieces();
            puzpieces.PuzzlePieceId = PuzzlePieceId;
            PuzzlePieces puzzlePieces = _adminBLL.GetPuzzlePieces(puzpieces);

            //记录日志
            Log(string.Format("查看[PuzzlePieces]]编辑页面 数据:{0}", PuzzlePieceId));

            return View("EditPuzzlePieces", puzzlePieces);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="puzzlePieces">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPuzzlePieces(PuzzlePieces puzzlePieces)
        {
            int rs = _adminBLL.UpdatePuzzlePieces(puzzlePieces);

            //记录日志
            Log(string.Format("编辑[PuzzlePieces]数据:{0}", puzzlePieces.ToString()));

            return EditResult(rs, "名称不能重复", "PuzzlePiecesList");
        }


        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="PuzzleTypeId">要查看的PuzzleTypeId</param>
        /// <returns></returns>
        public ActionResult EditPuzzleRate(int PuzzleTypeId, int PuzzleRateTypeID, int PuzzlePiecesCount)
        {
            PuzzleRate puzrate = new PuzzleRate();
            puzrate.PuzzleTypeId = PuzzleTypeId;
            puzrate.PuzzleRateTypeID = PuzzleRateTypeID;
            puzrate.PuzzlePiecesCount = PuzzlePiecesCount;
            PuzzleRate puzzleRate = _adminBLL.GetPuzzleRate(puzrate);

            //记录日志
            Log(string.Format("查看[PuzzleRate]]编辑页面 数据:{0}", PuzzleTypeId));

            return View("EditPuzzleRate", puzzleRate);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="puzzleRate">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPuzzleRate(PuzzleRate puzzleRate)
        {
            int rs = _adminBLL.UpdatePuzzleRate(puzzleRate);

            //记录日志
            Log(string.Format("编辑[PuzzleRate]数据:{0}", puzzleRate.ToString()));

            return EditResult(rs, "名称不能重复", "PuzzleRateList");
        }



        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult ExchangePacketList(DataPage dp, ExchangePacket model)
        {
            List<ExchangePacket> lists = new List<ExchangePacket>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetExchangePacketList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetExchangePacketList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "ExchangePacketList" + lists.Count() + "_Item";
                Dictionary<string, Func<ExchangePacket, string>> showFields = new Dictionary<string, Func<ExchangePacket, string>>();
                showFields.Add(ExchangePacket.PacketIdField, z => "'" + z.PacketId.ToString());
                showFields.Add(ExchangePacket.PacketNameField, z => "'" + z.PacketName.ToString());
                showFields.Add(ExchangePacket.PacketDescField, z => "'" + z.PacketDesc.ToString());
                showFields.Add(ExchangePacket.PuzzleTypeIDField, z => "'" + z.PuzzleTypeID.ToString());
                showFields.Add(ExchangePacket.NeedPointsField, z => "'" + z.NeedPoints.ToString());
                showFields.Add(ExchangePacket.IsNoticeField, z => "'" + z.IsNotice.ToString());
                showFields.Add(ExchangePacket.IsLimitField, z => "'" + z.IsLimit.ToString());
                showFields.Add(ExchangePacket.LimitCountField, z => "'" + z.LimitCount.ToString());
                showFields.Add(ExchangePacket.IsDeleteField, z => "'" + z.IsDelete.ToString());
                showFields.Add(ExchangePacket.CreateTimeField, z => "'" + z.CreateTime.ToString());
                showFields.Add(ExchangePacket.TotalCountField, z => "'" + z.CreateTime.ToString());
                ObjectUtil.Common.ExcelHelper2<ExchangePacket> elh = new ObjectUtil.Common.ExcelHelper2<ExchangePacket>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[ExchangePacket]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }



        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzleList(DataPage dp, Puzzle model)
        {
            List<Puzzle> lists = new List<Puzzle>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzleList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzleList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzleList" + lists.Count() + "_Item";
                Dictionary<string, Func<Puzzle, string>> showFields = new Dictionary<string, Func<Puzzle, string>>();
                showFields.Add(Puzzle.PuzzleIdField, z => "'" + z.PuzzleId.ToString());
                showFields.Add(Puzzle.PuzzleNameField, z => "'" + z.PuzzleName.ToString());
                showFields.Add(Puzzle.PuzzleDescField, z => "'" + z.PuzzleDesc.ToString());
                showFields.Add(Puzzle.PuzzleNodeField, z => "'" + z.PuzzleNode.ToString());
                showFields.Add(Puzzle.PuzzleTypeIDField, z => "'" + z.PuzzleTypeID.ToString());
                showFields.Add(Puzzle.PuzzlePacketTypeIDField, z => "'" + z.PuzzlePacketTypeID.ToString());
                showFields.Add(Puzzle.RateBeginField, z => "'" + z.RateBegin.ToString());
                showFields.Add(Puzzle.RateEndField, z => "'" + z.RateEnd.ToString());
                showFields.Add(Puzzle.PacketIDField, z => "'" + z.PacketID.ToString());
                showFields.Add(Puzzle.NodeTypeField, z => "'" + z.NodeType.ToString());
                ObjectUtil.Common.ExcelHelper2<Puzzle> elh = new ObjectUtil.Common.ExcelHelper2<Puzzle>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[Puzzle]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }




        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzlePiecesList(DataPage dp, PuzzlePieces model)
        {
            List<PuzzlePieces> lists = new List<PuzzlePieces>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzlePiecesList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzlePiecesList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzlePiecesList" + lists.Count() + "_Item";
                Dictionary<string, Func<PuzzlePieces, string>> showFields = new Dictionary<string, Func<PuzzlePieces, string>>();
                showFields.Add(PuzzlePieces.PuzzlePieceIdField, z => "'" + z.PuzzlePieceId.ToString());
                showFields.Add(PuzzlePieces.PuzzlePieceNameField, z => "'" + z.PuzzlePieceName.ToString());
                showFields.Add(PuzzlePieces.PuzzlePieceDescField, z => "'" + z.PuzzlePieceDesc.ToString());
                showFields.Add(PuzzlePieces.PuzzleIDField, z => "'" + z.PuzzleID.ToString());
                showFields.Add(PuzzlePieces.PieceOrderField, z => "'" + z.PieceOrder.ToString());
                ObjectUtil.Common.ExcelHelper2<PuzzlePieces> elh = new ObjectUtil.Common.ExcelHelper2<PuzzlePieces>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PuzzlePieces]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }





        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzlePacketList(DataPage dp, PuzzlePacket model)
        {
            ViewBag.PuzzlePacketTypeId = GetPuzzlePacketTypeId();
            List<PuzzlePacket> lists = new List<PuzzlePacket>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzlePacketList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzlePacketList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzlePacketList" + lists.Count() + "_Item";
                Dictionary<string, Func<PuzzlePacket, string>> showFields = new Dictionary<string, Func<PuzzlePacket, string>>();
                showFields.Add(PuzzlePacket.PuzzlePacketIdField, z => "'" + z.PuzzlePacketId.ToString());
                showFields.Add(PuzzlePacket.PuzzlePacketNameField, z => "'" + z.PuzzlePacketName.ToString());
                showFields.Add(PuzzlePacket.PuzzlePacketDescField, z => "'" + z.PuzzlePacketDesc.ToString());
                showFields.Add(PuzzlePacket.PuzzlePacketTypeIDField, z => "'" + z.PuzzlePacketTypeID.ToString());
                showFields.Add(PuzzlePacket.RateField, z => "'" + z.Rate.ToString());
                showFields.Add(PuzzlePacket.RateBeginField, z => "'" + z.RateBegin.ToString());
                showFields.Add(PuzzlePacket.RateEndField, z => "'" + z.RateEnd.ToString());
                showFields.Add(PuzzlePacket.IsNoticeField, z => "'" + z.IsNotice.ToString());
                ObjectUtil.Common.ExcelHelper2<PuzzlePacket> elh = new ObjectUtil.Common.ExcelHelper2<PuzzlePacket>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PuzzlePacket]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }

        public ActionResult SubmitPuzzlePacketRate(int PuzzlePacketTypeID)
        {
            int rs = _adminBLL.SubmitPuzzlePacketRate(PuzzlePacketTypeID);

            //记录日志
            Log(string.Format("新增SubmitPuzzleRate 数据:{0}", PuzzlePacketTypeID.ToString()));

            return EditResult(rs, "拼图概率提交失败", "PuzzlePacketList");


        }





        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult PuzzleRateList(DataPage dp, PuzzleRate model)
        {
            ViewBag.PuzzleTypeId = GetPuzzleTypeId();
            List<PuzzleRate> lists = new List<PuzzleRate>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetPuzzleRateList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetPuzzleRateList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "PuzzleRateList" + lists.Count() + "_Item";
                Dictionary<string, Func<PuzzleRate, string>> showFields = new Dictionary<string, Func<PuzzleRate, string>>();
                showFields.Add(PuzzleRate.PuzzleTypeIdField, z => "'" + z.PuzzleTypeId.ToString());
                showFields.Add(PuzzleRate.PuzzlePiecesCountField, z => "'" + z.PuzzlePiecesCount.ToString());
                showFields.Add(PuzzleRate.PuzzleRateTypeIDField, z => "'" + z.PuzzleRateTypeID.ToString());
                showFields.Add(PuzzleRate.RateField, z => "'" + z.Rate.ToString());
                showFields.Add(PuzzleRate.RateBeginField, z => "'" + z.RateBegin.ToString());
                showFields.Add(PuzzleRate.RateEndField, z => "'" + z.RateEnd.ToString());
                ObjectUtil.Common.ExcelHelper2<PuzzleRate> elh = new ObjectUtil.Common.ExcelHelper2<PuzzleRate>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[PuzzleRate]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }


        public ActionResult SubmitPuzzleRate(int PuzzleTypeId)
        {

            int rs = _adminBLL.SubmitPuzzleRate(PuzzleTypeId);

            //记录日志
            Log(string.Format("新增SubmitPuzzleRate 数据:{0}", PuzzleTypeId.ToString()));

            return EditResult(rs, "拼图概率提交失败", "PuzzleRateList");


        }
        #endregion


        #region 个人结点
        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>




        /// <summary>
        ///  列表
        /// </summary>
        /// <param name="searchSort">用来搜索的实例</param>
        /// <returns></returns>
        public ActionResult UserPuzzleNodeList(DataPage dp, UserPuzzleNode model)
        {
            List<UserPuzzleNode> lists = new List<UserPuzzleNode>();
            if (Request["btnExportExcel"] == null)//导出Excel
            {
                lists = _adminBLL.GetUserPuzzleNodeList(ref dp, model);
                GetDataPage(dp);
            }
            else
            {
                dp.PageSize = 0;
                lists = _adminBLL.GetUserPuzzleNodeList(ref dp, model);
                string fileName = "nothing";
                if (lists.Count() > 0) fileName = "UserPuzzleNodeList" + lists.Count() + "_Item";
                Dictionary<string, Func<UserPuzzleNode, string>> showFields = new Dictionary<string, Func<UserPuzzleNode, string>>();

                showFields.Add(UserPuzzleNode.NodeIDField, z => "'" + z.NodeID.ToString());
                showFields.Add(UserPuzzleNode.UserIdField, z => "'" + z.UserId.ToString());
                showFields.Add(UserPuzzleNode.AreaIDField, z => "'" + z.AreaID.ToString());
                showFields.Add(UserPuzzleNode.NodeCurrentField, z => "'" + z.NodeCurrent.ToString());
                showFields.Add(UserPuzzleNode.NodeTotalField, z => "'" + z.NodeTotal.ToString());
                showFields.Add(UserPuzzleNode.PuzzleTypeIDField, z => "'" + z.PuzzleTypeID.ToString());
                showFields.Add(UserPuzzleNode.PuzzleIDField, z => "'" + z.PuzzleID.ToString());

                ObjectUtil.Common.ExcelHelper2<UserPuzzleNode> elh = new ObjectUtil.Common.ExcelHelper2<UserPuzzleNode>(lists, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            //记录日志
            Log(string.Format("查看[UserPuzzleNode]列表页面 搜索数据:{0}", model.ToString()));

            return View(lists);
        }



        /// <summary>
        /// 查看 ] 编辑页面
        /// </summary>
        /// <param name="NodeID">要查看的NodeID</param>
        /// <returns></returns>
        public ActionResult EditUserPuzzleNode(int nodeid)
        {
            UserPuzzleNode puzzlenode = new UserPuzzleNode();
            puzzlenode.NodeID = nodeid;
            UserPuzzleNode userPuzzleNode = _adminBLL.GetUserPuzzleNode(puzzlenode);

            //记录日志
            Log(string.Format("查看[UserPuzzleNode]]编辑页面 数据:{0}", puzzlenode.ToString()));

            return View("EditUserPuzzleNode", userPuzzleNode);
        }

        /// <summary>
        /// 编辑 ] 数据提交
        /// </summary>
        /// <param name="userPuzzleNode">要编辑的]实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditUserPuzzleNode(UserPuzzleNode userPuzzleNode)
        {
            long rs = _adminBLL.UpdateUserPuzzleNode(userPuzzleNode);

            //记录日志
            Log(string.Format("编辑[UserPuzzleNode]数据:{0}", userPuzzleNode.ToString()));

            return EditResult(rs, "名称不能重复", "UserPuzzleNodeList");
        }
        #endregion


        #region 公用
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
            int rs = _adminBLL.importCSVtoDB(ds, Typeid);
            if (rs == 1)
            {
                return Success("ImportExcel");
            }

            return UnSuccessful("导入失败", "ImportExcel");
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

        private SelectList ImportType(string typeid = "-1")
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "请选择" });
            enumItem.Insert(1, new EnumItem { ItemValue = "ExchangePacket", ItemDescription = "拼图碎片兑换礼包" });
            enumItem.Insert(2, new EnumItem { ItemValue = "PuzzlePacket", ItemDescription = "拼图及道具礼包概率表" });
            enumItem.Insert(3, new EnumItem { ItemValue = "PuzzlePieces", ItemDescription = "拼图碎片列表" });
            enumItem.Insert(4, new EnumItem { ItemValue = "PuzzleRate", ItemDescription = "碎片和道具概率表" });
            var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, typeid);
            return list;
        }

        private SelectList GetGameAreaList(int gameAreaId = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--全部--" });
            enumItem.Insert(1, new EnumItem { ItemValue = "0", ItemDescription = "电信1" });
            enumItem.Insert(2, new EnumItem { ItemValue = "2", ItemDescription = "电信2" });
            enumItem.Insert(3, new EnumItem { ItemValue = "1", ItemDescription = "网通1" });

            var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, gameAreaId);
            return list;
        }

        private SelectList GetPuzzleTypeId(int PuzzleTypeId = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--请选择--" });
            enumItem.Insert(1, new EnumItem { ItemValue = "1", ItemDescription = "暴君" });
            enumItem.Insert(2, new EnumItem { ItemValue = "2", ItemDescription = "超能" });
            enumItem.Insert(3, new EnumItem { ItemValue = "3", ItemDescription = "极品" });

            SelectList list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, PuzzleTypeId);
            return list;
        }

        private SelectList GetPuzzlePacketTypeId(int PuzzlePacketTypeId = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "--请选择--" });
            enumItem.Insert(1, new EnumItem { ItemValue = "1", ItemDescription = "武器拼图" });
            enumItem.Insert(2, new EnumItem { ItemValue = "2", ItemDescription = "装置拼图" });
            enumItem.Insert(3, new EnumItem { ItemValue = "3", ItemDescription = "挂件拼图" });
            enumItem.Insert(4, new EnumItem { ItemValue = "4", ItemDescription = "通用道具" });
            enumItem.Insert(5, new EnumItem { ItemValue = "5", ItemDescription = "拼图礼包" });

            SelectList list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, PuzzlePacketTypeId);
            return list;
        }

        private SelectList GetDrawCount(int DrawCount = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "全部" });
            enumItem.Insert(1, new EnumItem { ItemValue = "1", ItemDescription = "1次" });
            enumItem.Insert(2, new EnumItem { ItemValue = "10", ItemDescription = "10次" });

            SelectList list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, DrawCount);
            return list;
        }

        private SelectList GetIsPuzzle(int IsPuzzle = -1)
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "全部" });
            enumItem.Insert(1, new EnumItem { ItemValue = "0", ItemDescription = "否" });
            enumItem.Insert(2, new EnumItem { ItemValue = "1", ItemDescription = "是" });

            SelectList list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, IsPuzzle);
            return list;
        }

        private SelectList GetSource(string Source = "-1")
        {
            var enumItem = new List<EnumItem>();
            enumItem.Insert(0, new EnumItem { ItemValue = "-1", ItemDescription = "请选择" });
            enumItem.Insert(1, new EnumItem { ItemValue = "Ordinary", ItemDescription = "回馈礼包" });
            enumItem.Insert(2, new EnumItem { ItemValue = "TenDraws", ItemDescription = "购买十次礼包" });
            enumItem.Insert(3, new EnumItem { ItemValue = "PuzzlePacket", ItemDescription = "拼图道具" });
            enumItem.Insert(4, new EnumItem { ItemValue = "ExchangePacket", ItemDescription = "碎片兑换礼包" });
            enumItem.Insert(5, new EnumItem { ItemValue = "CompletePuzzle", ItemDescription = "拼图礼包" });

            var list = new SelectList(enumItem, EnumItem.ItemValueField, EnumItem.ItemDescriptionField, Source);
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

        public static string GetNodeName(int id)
        {
            if (id == 1)
            { return "总结点"; }
            else
            { return "个人结点"; }
        }

        public static string GetPuzzleTypeName(int? puzzletypeid)
        {
            puzzletypeid = puzzletypeid ?? 4;
            if (puzzletypeid == 1)
            { return "暴君"; }
            else if (puzzletypeid == 2)
            { return "超能"; }
            else if (puzzletypeid == 3)
            { return "极品"; }
            else
            { return null; }
        }
        #endregion


        #region 统计



        public ActionResult AllAnalyze()
        {
            List<Analyze> list = new List<Analyze>();
            while (true)
            {
                if (StartTime <= EndTime)
                {
                    List<Packet> pList = new List<Packet>();
                    DataTableCollection dts = dal.AllAnalyze(StartTime);
                    Analyze model = new Analyze();
                    if (dts[0].Rows.Count > 0)
                    {
                        model.Date = StartTime;
                        model.PayPoint = Convert.ToInt32(dts[0].Rows[0][Analyze.PayPointField]);
                        model.OtherPoint = Convert.ToInt32(dts[0].Rows[0][Analyze.OtherPointField]);
                        model.BillPoint = Convert.ToInt32(dts[0].Rows[0][Analyze.BillPointField]);
                        model.Persons = Convert.ToInt32(dts[0].Rows[0][Analyze.PersonsField]);
                        model.BJNum = Convert.ToInt32(dts[0].Rows[0][Analyze.BJNumField]);
                        model.CNNum = Convert.ToInt32(dts[0].Rows[0][Analyze.CNNumField]);
                        model.JPNum = Convert.ToInt32(dts[0].Rows[0][Analyze.JPNumField]);
                        model.RedNum = Convert.ToInt32(dts[0].Rows[0][Analyze.RedNumField]);
                        model.XNNum = Convert.ToInt32(dts[0].Rows[0][Analyze.XNNumField]);
                    }
                    if (dts[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < dts[1].Rows.Count; i++)
                        {
                            Packet packet = new Packet();
                            packet.PacketID = Convert.ToInt32(dts[1].Rows[i][Packet.PacketIDField]);
                            packet.PacketName = Convert.ToString(dts[1].Rows[i][Packet.PacketNameField]);
                            packet.ExchangeNum = Convert.ToInt32(dts[1].Rows[i][Packet.ExchangeNumField]);
                            pList.Add(packet);
                        }
                    }
                    model.ListPacket = pList;
                    list.Add(model);
                    StartTime = StartTime.AddDays(1);
                }
                else
                    break;
            }

            if (Request["btnExportExcel"] != null)//导出Excel
            {
                string fileName = "nothing";
                if (list.Count() > 0) fileName = "AllAnalyze" + list.Count() + "_Item";
                Dictionary<string, Func<Analyze, string>> showFields = new Dictionary<string, Func<Analyze, string>>();
                showFields.Add("日期", z => "'" + z.Date.ToString("yyyy-MM-dd"));
                showFields.Add("充值积分", z => "'" + z.PayPoint.ToString());
                showFields.Add("其他途径获得的积分", z => "'" + z.OtherPoint.ToString());
                showFields.Add("消耗总积分", z => "'" + z.BillPoint.ToString());
                showFields.Add("活动参与人数", z => "'" + z.Persons.ToString());
                showFields.Add("暴君礼盒兑换数量", z => "'" + z.BJNum.ToString());
                showFields.Add("超能礼盒兑换数量", z => "'" + z.CNNum.ToString());
                showFields.Add("极品道具礼盒兑换数量", z => "'" + z.JPNum.ToString());
                showFields.Add("红包领取数量", z => "'" + z.RedNum.ToString());
                showFields.Add("新年礼物领取数量", z => "'" + z.XNNum.ToString());
                ObjectUtil.Common.ExcelHelper2<Analyze> elh = new ObjectUtil.Common.ExcelHelper2<Analyze>(list, null, showFields);
                elh.FileWebSaveAs(Response, fileName);
            }
            if (Request["btnExportExcel2"] != null)//导出Excel
            {
                string fileName = "nothing";
                if (list.Count() > 0) fileName = "AllAnalyze" + "_礼包兑换_" + "_Item";
                CreateExcel(list,fileName);
            }


            return View(list);
        }

        #endregion


        public void CreateExcel(List<Analyze> list, string FileName)
        {
            string shtnl = "";
            shtnl = "<table border='1' cellspacing='1' cellpadding='1'>";
            shtnl = shtnl + "<thead>";
            shtnl += "<th>日期</th>";
            for (int i = 0; i < list[0].ListPacket.Count; i++)
            {
                shtnl +="<th>"+ list[0].ListPacket[i].PacketName+"</th>";
            }
            shtnl = shtnl + "</thead><tbody>";
            for (int i = 0; i < list.Count; i++)
            {
                shtnl =shtnl+"<tr><td>"+list[i].Date.ToString("yyyy-MM-dd") + "</td>";
                for (int j = 0; j < list[i].ListPacket.Count; j++)
                {
                    shtnl = shtnl + "<td>" + list[i].ListPacket[j].ExchangeNum + "</td>";
                }
                shtnl = shtnl + "</tr>";
            }
            shtnl = shtnl + "</tbody></table>";
            ExportToExcel("application/ms-excel", FileName+".xls", shtnl);
        }

        public void ExportToExcel(string FieldType, string FileName, string dt)
        {
            System.Web.HttpContext.Current.Response.Charset = "utf-8";
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            System.Web.HttpContext.Current.Response.ContentType = FieldType;
            StringWriter tw = new StringWriter();
            System.Web.HttpContext.Current.Response.Output.Write(dt);
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
    }
}

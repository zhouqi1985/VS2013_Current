using CommonLibs.Common;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LogBLLV2;

namespace PuzzleEvent.DAL.AdminWCF.Client
{
    public class PuzzleEventAdminServiceClient
    {
        private PuzzleEventAdminService.PuzzleEventAdminServiceClient _admin;

        public long AddWallet(Wallet wallet)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            return LogBLLV2.CallWCF.InvokeAndClose(_admin, a => a.AddWallet(wallet));
        }

        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchWallet)
        {
            List<Wallet> list = new List<Wallet>();
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                list = _admin.GetWalletList(ref dp, searchWallet);
                _admin.Close();
                return list;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetWalletList 失败");
                return list;
            }
        }
        public Int64 UpdateExchangePacket(ExchangePacket exchangePacket)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                long rs = _admin.UpdateExchangePacket(exchangePacket);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdateExchangePacket 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public ExchangePacket GetExchangePacket(ExchangePacket searchExchangePacket)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            ExchangePacket lists = new ExchangePacket();
            try
            {
                lists = _admin.GetExchangePacket(searchExchangePacket);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacket 获取拼图列表失败");
                return lists;
            }


        }
        public Int32 UpdatePuzzle(Puzzle puzzle)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.UpdatePuzzle(puzzle);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdatePuzzle 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public Puzzle GetPuzzle(Puzzle searchPuzzle)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            Puzzle lists = new Puzzle();
            try
            {
                lists = _admin.GetPuzzle(searchPuzzle);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzle 获取拼图列表失败");
                return lists;
            }


        }
        public Int32 UpdatePuzzlePieces(PuzzlePieces puzzlePieces)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.UpdatePuzzlePieces(puzzlePieces);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdatePuzzlePieces 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public PuzzlePieces GetPuzzlePieces(PuzzlePieces searchPuzzlePieces)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            PuzzlePieces lists = new PuzzlePieces();
            try
            {
                lists = _admin.GetPuzzlePieces(searchPuzzlePieces);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzlePieces 获取拼图列表失败");
                return lists;
            }


        }
        public Int32 UpdatePuzzlePacket(PuzzlePacket puzzlePacket)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.UpdatePuzzlePacket(puzzlePacket);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdatePuzzlePacket 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public PuzzlePacket GetPuzzlePacket(PuzzlePacket searchPuzzlePacket)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            PuzzlePacket lists = new PuzzlePacket();
            try
            {
                lists = _admin.GetPuzzlePacket(searchPuzzlePacket);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzlePacket 获取拼图列表失败");
                return lists;
            }


        }
        public Int32 UpdatePuzzleRate(PuzzleRate puzzleRate)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.UpdatePuzzleRate(puzzleRate);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdatePuzzleRate 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public PuzzleRate GetPuzzleRate(PuzzleRate searchPuzzleRate)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            PuzzleRate lists = new PuzzleRate();
            try
            {
                lists = _admin.GetPuzzleRate(searchPuzzleRate);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzleRate 获取拼图列表失败");
                return lists;
            }


        }


        public List<ExchangePacket> GetExchangePacketList(ref DataPage dp, ExchangePacket searchExchangePacket)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<ExchangePacket> lists = new List<ExchangePacket>();
            try
            {
                lists = _admin.GetExchangePacketList(ref dp, searchExchangePacket);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketList 获取拼图碎片礼包列表失败");
                return lists;
            }
        }
        public List<PuzzlePieces> GetPuzzlePiecesList(ref DataPage dp, PuzzlePieces searchPuzzlePieces)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PuzzlePieces> lists = new List<PuzzlePieces>();
            try
            {
                lists = _admin.GetPuzzlePiecesList(ref dp, searchPuzzlePieces);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzlePiecesList 获取拼图碎片列表失败");
                return lists;
            }
        }
        public List<PuzzlePacket> GetPuzzlePacketList(ref DataPage dp, PuzzlePacket searchPuzzlePacket)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PuzzlePacket> lists = new List<PuzzlePacket>();
            try
            {
                lists = _admin.GetPuzzlePacketList(ref dp, searchPuzzlePacket);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzlePacketList 获取拼图道具列表失败");
                return lists;
            }
        }
        public List<PuzzleRate> GetPuzzleRateList(ref DataPage dp, PuzzleRate searchPuzzleRate)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PuzzleRate> lists = new List<PuzzleRate>();
            try
            {
                lists = _admin.GetPuzzleRateList(ref dp, searchPuzzleRate);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzleRateList 获取拼图概率列表失败");
                return lists;
            }
        }
        public List<Puzzle> GetPuzzleList(ref DataPage dp, Puzzle searchPuzzle)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<Puzzle> lists = new List<Puzzle>();
            try
            {
                lists = _admin.GetPuzzleList(ref dp, searchPuzzle);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzleList 获取拼图列表失败");
                return lists;
            }
        }

        public List<UserPuzzleNode> GetUserPuzzleNodeList(ref DataPage dp, UserPuzzleNode searchUserPuzzleNode)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<UserPuzzleNode> lists = new List<UserPuzzleNode>();
            try
            {
                lists = _admin.GetUserPuzzleNodeList(ref dp, searchUserPuzzleNode);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetUserPuzzleNodeList 获取拼图列表失败");
                return lists;
            }
        }

        public UserPuzzleNode GetUserPuzzleNode(UserPuzzleNode searchUserPuzzleNode)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            UserPuzzleNode lists = new UserPuzzleNode();
            try
            {
                lists = _admin.GetUserPuzzleNode(searchUserPuzzleNode);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetUserPuzzleNode 获取拼图列表失败");
                return lists;
            }


        }
        public Int64 UpdateUserPuzzleNode(UserPuzzleNode userPuzzleNode)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                long rs = _admin.UpdateUserPuzzleNode(userPuzzleNode);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdateUserPuzzleNode 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public Int32 SubmitPuzzleRate(int PuzzleTypeId)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.SubmitPuzzleRate(PuzzleTypeId);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "SubmitPuzzlePacketRate 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public Int32 SubmitPuzzlePacketRate(int PuzzlePacketTypeID)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.SubmitPuzzlePacketRate(PuzzlePacketTypeID);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "SubmitPuzzlePacketRate 更新宝箱礼包信息失败");
                return 0;
            }
        }
        public Int32 importCSVtoDB(DataSet ds, string TableName)
        {
            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            try
            {
                int rs = _admin.importCSVtoDB(ds, TableName);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "importCSVtoDB导入失败");
                return -1;
            }
        }

        public List<PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref DataPage dp, PuzzleReceiveDetails searchPuzzleReceiveDetails)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PuzzleReceiveDetails> lists = new List<PuzzleReceiveDetails>();
            try
            {
                lists = _admin.GetPuzzleReceiveDetailsList(ref dp,searchPuzzleReceiveDetails);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzleReceiveDetailsList 获取拼图列表失败");
                return lists;
            }
        }
        public List<UserPiecesTotal> GetUserPiecesTotalList(ref DataPage dp, UserPiecesTotal searchUserPiecesTotal)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<UserPiecesTotal> lists = new List<UserPiecesTotal>();
            try
            {
                lists = _admin.GetUserPiecesTotalList(ref dp, searchUserPiecesTotal);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetUserPiecesTotalList 获取拼图列表失败");
                return lists;
            }
        }
        public List<PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref DataPage dp, PuzzleDrawDetails searchPuzzleDrawDetails)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PuzzleDrawDetails> lists = new List<PuzzleDrawDetails>();
            try
            {
                lists = _admin.GetPuzzleDrawDetailsList(ref dp, searchPuzzleDrawDetails);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPuzzleDrawDetailsList 获取拼图列表失败");
                return lists;
            }
        }
        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            try
            {
                lists = _admin.GetPacketQueueLogList(ref dp, searchPacketQueueLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPacketQueueLogList 获取拼图列表失败");
                return lists;
            }
        }
        public List<PiecesPacketDetails> GetPiecesPacketDetailsList(ref DataPage dp, PiecesPacketDetails searchPiecesPacketDetails)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<PiecesPacketDetails> lists = new List<PiecesPacketDetails>();
            try
            {
                lists = _admin.GetPiecesPacketDetailsList(ref dp, searchPiecesPacketDetails);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPiecesPacketDetailsList 获取拼图列表失败");
                return lists;
            }
        }

        public List<ExchangePacketReceive> GetExchangePacketReceiveList(ref DataPage dp, ExchangePacketReceive searchExchangePacketReceive)
        {

            _admin = new PuzzleEventAdminService.PuzzleEventAdminServiceClient();
            List<ExchangePacketReceive> lists = new List<ExchangePacketReceive>();
            try
            {
                lists = _admin.GetExchangePacketReceiveList(ref dp, searchExchangePacketReceive);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketReceiveList 获取拼图列表失败");
                return lists;
            }
        }
    }
}

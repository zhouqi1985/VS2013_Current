using CommonLibs.Common;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PuzzleEvent.DAL.AdminWCF
{
    public class PuzzleEventAdminService : IPuzzleEventAdminService
    {
        private readonly PuzzleEvent.DAL.Admin.IPuzzleEventAdmin _dal = new PuzzleEvent.DAL.Admin.PuzzleEventAdmin();
        public long AddWallet(Wallet wallet)
        {
            return _dal.AddWallet(wallet);
        }
        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchWallet)
        {
            return _dal.GetWalletList(ref dp, searchWallet);
        }

        public Int64 UpdateExchangePacket(ExchangePacket exchangePacket)
        {
            return _dal.UpdateExchangePacket(exchangePacket);
        }
        public ExchangePacket GetExchangePacket(ExchangePacket searchExchangePacket)
        {
            return _dal.GetExchangePacket(searchExchangePacket);
        }
        public Int32 UpdatePuzzle(Puzzle puzzle)
        {
            return _dal.UpdatePuzzle(puzzle);
        }
        public Puzzle GetPuzzle(Puzzle searchPuzzle)
        {
            return _dal.GetPuzzle(searchPuzzle);
        }
        public Int32 UpdatePuzzlePieces(PuzzlePieces puzzlePieces)
        {
            return _dal.UpdatePuzzlePieces(puzzlePieces);
        }
        public PuzzlePieces GetPuzzlePieces(PuzzlePieces searchPuzzlePieces)
        {
            return _dal.GetPuzzlePieces(searchPuzzlePieces);
        }
        public Int32 UpdatePuzzlePacket(PuzzlePacket puzzlePacket)
        {
            return _dal.UpdatePuzzlePacket(puzzlePacket);
        }
        public PuzzlePacket GetPuzzlePacket(PuzzlePacket searchPuzzlePacket)
        {
            return _dal.GetPuzzlePacket(searchPuzzlePacket);
        }
        public Int32 UpdatePuzzleRate(PuzzleRate puzzleRate)
        {
            return _dal.UpdatePuzzleRate(puzzleRate);
        }
        public PuzzleRate GetPuzzleRate(PuzzleRate searchPuzzleRate)
        {
            return _dal.GetPuzzleRate(searchPuzzleRate);
        }

        public List<ExchangePacket> GetExchangePacketList(ref DataPage dp, ExchangePacket searchExchangePacket)
        {

            return _dal.GetExchangePacketList(ref  dp, searchExchangePacket);
        }
        public List<PuzzlePieces> GetPuzzlePiecesList(ref DataPage dp, PuzzlePieces searchPuzzlePieces)
        {

            return _dal.GetPuzzlePiecesList(ref  dp, searchPuzzlePieces);
        }
        public List<PuzzlePacket> GetPuzzlePacketList(ref DataPage dp, PuzzlePacket searchPuzzlePacket)
        {

            return _dal.GetPuzzlePacketList(ref  dp, searchPuzzlePacket);
        }
        public List<PuzzleRate> GetPuzzleRateList(ref DataPage dp, PuzzleRate searchPuzzleRate)
        {

            return _dal.GetPuzzleRateList(ref  dp, searchPuzzleRate);
        }
        public List<Puzzle> GetPuzzleList(ref DataPage dp, Puzzle searchPuzzle)
        {

            return _dal.GetPuzzleList(ref  dp, searchPuzzle);
        }
        public Int32 importCSVtoDB(DataSet ds, string TableName)
        {

            return _dal.importCSVtoDB(ds, TableName);
        }
        public List<UserPuzzleNode> GetUserPuzzleNodeList(ref DataPage dp, UserPuzzleNode searchUserPuzzleNode)
        {

            return _dal.GetUserPuzzleNodeList(ref dp, searchUserPuzzleNode);
        }
        public UserPuzzleNode GetUserPuzzleNode(UserPuzzleNode searchUserPuzzleNode)
        {
            return _dal.GetUserPuzzleNode(searchUserPuzzleNode);
        }
        public Int64 UpdateUserPuzzleNode(UserPuzzleNode userPuzzleNode)
        {

            return _dal.UpdateUserPuzzleNode(userPuzzleNode);
        }
        public Int32 SubmitPuzzleRate(int PuzzleTypeId)
        {

            return _dal.SubmitPuzzleRate(PuzzleTypeId);
        }
        public Int32 SubmitPuzzlePacketRate(int PuzzlePacketTypeID)
        {

            return _dal.SubmitPuzzlePacketRate(PuzzlePacketTypeID);
        }
        public List<PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref DataPage dp, PuzzleReceiveDetails searchPuzzleReceiveDetails)
        {

            return _dal.GetPuzzleReceiveDetailsList(ref  dp, searchPuzzleReceiveDetails);
        }
        public List<UserPiecesTotal> GetUserPiecesTotalList(ref DataPage dp, UserPiecesTotal searchUserPiecesTotal)
        {

            return _dal.GetUserPiecesTotalList(ref  dp, searchUserPiecesTotal);
        }
        public List<PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref DataPage dp, PuzzleDrawDetails searchPuzzleDrawDetails)
        {

            return _dal.GetPuzzleDrawDetailsList(ref  dp, searchPuzzleDrawDetails);
        }
        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog)
        {

            return _dal.GetPacketQueueLogList(ref  dp, searchPacketQueueLog);
        }
        public List<PiecesPacketDetails> GetPiecesPacketDetailsList(ref DataPage dp, PiecesPacketDetails searchPiecesPacketDetails)
        {

            return _dal.GetPiecesPacketDetailsList(ref  dp, searchPiecesPacketDetails);
        }
        public List<ExchangePacketReceive> GetExchangePacketReceiveList(ref DataPage dp, ExchangePacketReceive searchExchangePacketReceive)
        {

            return _dal.GetExchangePacketReceiveList(ref  dp, searchExchangePacketReceive);
        }

    }
}

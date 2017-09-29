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
    [ServiceContract]
    public interface IPuzzleEventAdminService
    {
        [OperationContract]
        Int64 AddWallet(Wallet wallet);
        [OperationContract]
        List<Wallet> GetWalletList(ref DataPage dp, Wallet searchWallet);
        [OperationContract]
        Int64 UpdateExchangePacket(ExchangePacket exchangePacket);
        [OperationContract]
        ExchangePacket GetExchangePacket(ExchangePacket searchExchangePacket);
        [OperationContract]
        Int32 UpdatePuzzle(Puzzle puzzle);
        [OperationContract]
        Puzzle GetPuzzle(Puzzle searchPuzzle);
        [OperationContract]
        Int32 UpdatePuzzlePieces(PuzzlePieces puzzlePieces);
        [OperationContract]
        PuzzlePieces GetPuzzlePieces(PuzzlePieces searchPuzzlePieces);
        [OperationContract]
        Int32 UpdatePuzzlePacket(PuzzlePacket puzzlePacket);
        [OperationContract]
        PuzzlePacket GetPuzzlePacket(PuzzlePacket searchPuzzlePacket);
        [OperationContract]
        Int32 UpdatePuzzleRate(PuzzleRate puzzleRate);
        [OperationContract]
        PuzzleRate GetPuzzleRate(PuzzleRate searchPuzzleRate);
        [OperationContract]
        List<ExchangePacket> GetExchangePacketList(ref DataPage dp, ExchangePacket searchExchangePacket);
        [OperationContract]
        List<PuzzlePieces> GetPuzzlePiecesList(ref DataPage dp, PuzzlePieces searchPuzzlePieces);
        [OperationContract]
        List<PuzzlePacket> GetPuzzlePacketList(ref DataPage dp, PuzzlePacket searchPuzzlePacket);
        [OperationContract]
        List<PuzzleRate> GetPuzzleRateList(ref DataPage dp, PuzzleRate searchPuzzleRate);
        [OperationContract]
        List<Puzzle> GetPuzzleList(ref DataPage dp, Puzzle searchPuzzle);
        [OperationContract]
        List<UserPuzzleNode> GetUserPuzzleNodeList(ref DataPage dp, UserPuzzleNode searchUserPuzzleNode);
        [OperationContract]
        UserPuzzleNode GetUserPuzzleNode(UserPuzzleNode searchUserPuzzleNode);
        [OperationContract]
        Int64 UpdateUserPuzzleNode(UserPuzzleNode userPuzzleNode);
        [OperationContract]
        Int32 SubmitPuzzleRate(int PuzzleTypeId);
        [OperationContract]
        Int32 SubmitPuzzlePacketRate(int PuzzlePacketTypeID);
        [OperationContract]
        List<PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref DataPage dp, PuzzleReceiveDetails searchPuzzleReceiveDetails);
        [OperationContract]
        List<UserPiecesTotal> GetUserPiecesTotalList(ref DataPage dp, UserPiecesTotal searchUserPiecesTotal);
        [OperationContract]
        List<PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref DataPage dp, PuzzleDrawDetails searchPuzzleDrawDetails);
        [OperationContract]
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog);
        [OperationContract]
        List<PiecesPacketDetails> GetPiecesPacketDetailsList(ref DataPage dp, PiecesPacketDetails searchPiecesPacketDetails);
        [OperationContract]
        List<ExchangePacketReceive> GetExchangePacketReceiveList(ref DataPage dp, ExchangePacketReceive searchExchangePacketReceive);
        [OperationContract]
        Int32 importCSVtoDB(DataSet ds, string TableName);

    }

}

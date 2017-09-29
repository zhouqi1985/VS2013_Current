using CommonLibs.Common;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PuzzleEvent.DAL.Admin
{
    public interface IPuzzleEventAdmin
    {

        Int64 AddWallet(Wallet wallet);

        List<Wallet> GetWalletList(ref DataPage dp, Wallet searchWallet);
        Int64 UpdateExchangePacket(ExchangePacket exchangePacket);
        ExchangePacket GetExchangePacket(ExchangePacket searchExchangePacket);
        Int32 UpdatePuzzle(Puzzle puzzle);
        Puzzle GetPuzzle(Puzzle searchPuzzle);
        Int32 UpdatePuzzlePieces(PuzzlePieces puzzlePieces);
        PuzzlePieces GetPuzzlePieces(PuzzlePieces searchPuzzlePieces);
        Int32 UpdatePuzzlePacket(PuzzlePacket puzzlePacket);
        PuzzlePacket GetPuzzlePacket(PuzzlePacket searchPuzzlePacket);
        Int32 UpdatePuzzleRate(PuzzleRate puzzleRate);
        PuzzleRate GetPuzzleRate(PuzzleRate searchPuzzleRate);

        List<ExchangePacket> GetExchangePacketList(ref DataPage dp, ExchangePacket searchExchangePacket);

        List<PuzzlePieces> GetPuzzlePiecesList(ref DataPage dp, PuzzlePieces searchPuzzlePieces);

        List<PuzzlePacket> GetPuzzlePacketList(ref DataPage dp, PuzzlePacket searchPuzzlePacket);

        List<PuzzleRate> GetPuzzleRateList(ref DataPage dp, PuzzleRate searchPuzzleRate);

        List<Puzzle> GetPuzzleList(ref DataPage dp, Puzzle searchPuzzle);

        List<UserPuzzleNode> GetUserPuzzleNodeList(ref DataPage dp, UserPuzzleNode searchUserPuzzleNode);

        UserPuzzleNode GetUserPuzzleNode(UserPuzzleNode searchUserPuzzleNode);
        Int64 UpdateUserPuzzleNode(UserPuzzleNode userPuzzleNode);
        Int32 SubmitPuzzleRate(int PuzzleTypeId);
        Int32 SubmitPuzzlePacketRate(int PuzzlePacketTypeID);
        List<PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref DataPage dp, PuzzleReceiveDetails searchPuzzleReceiveDetails);
        List<UserPiecesTotal> GetUserPiecesTotalList(ref DataPage dp, UserPiecesTotal searchUserPiecesTotal);
        List<PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref DataPage dp, PuzzleDrawDetails searchPuzzleDrawDetails);
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog);
        List<PiecesPacketDetails> GetPiecesPacketDetailsList(ref DataPage dp, PiecesPacketDetails searchPiecesPacketDetails);
        List<ExchangePacketReceive> GetExchangePacketReceiveList(ref DataPage dp, ExchangePacketReceive searchExchangePacketReceive);
        Int32 importCSVtoDB(DataSet ds, string TableName);


        DataTableCollection AllAnalyze(DateTime Date);

    }
}

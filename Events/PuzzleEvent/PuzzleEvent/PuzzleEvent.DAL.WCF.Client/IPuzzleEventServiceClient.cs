using CommonLibs.Common;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.DAL.WCF.Client
{
    public interface IPuzzleEventServiceClient
    {
        List<UserPiecesTotal> GetUserPiecesTotalAll(UserPiecesTotal userpiecestotal);

        Int32 AddOrdinaryPacketReceive(UserSearch ordinaryPacketReceive);
        Int32 AddExchangePacketReceive(UserSearch exchangePacketReceive, ref bool IsNotice, ref string PacketName);
        List<PuzzlePieces> GetPiecesReceive(UserSearch searchPiecesReceive);
        Int32 AddPuzzleDrawDetails(PuzzleDrawDetails puzzleDrawDetails);
        PuzzleDrawDetails AddPiecesPacketDetails(PuzzleDrawDetails piecesPacketDetails);
        List<PuzzleDrawDetails> PuzzleDraw(PuzzleDrawDetails piecesPacketDetails);
        List<RankList> GetRankListList(ref DataPage dp, RankList searchRankList);

        PuzzleDrawDetails PuzzleReceive(PuzzleDrawDetails PuzzleDrawDetails);

    }
}

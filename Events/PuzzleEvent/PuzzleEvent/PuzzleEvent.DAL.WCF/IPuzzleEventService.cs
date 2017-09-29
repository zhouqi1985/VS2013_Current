using CommonLibs.Common;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PuzzleEvent.DAL.WCF
{
    [ServiceContract]
    public interface IPuzzleEventService
    {
        [OperationContract]
        List<UserPiecesTotal> GetUserPiecesTotalAll(UserPiecesTotal userpiecestotal);
        [OperationContract]
        Int32 AddOrdinaryPacketReceive(UserSearch ordinaryPacketReceive);
        [OperationContract]
        Int32 AddExchangePacketReceive(UserSearch exchangePacketReceive, ref bool IsNotice, ref string PacketName);
        [OperationContract]
        List<PuzzlePieces> GetPiecesReceive(UserSearch searchPiecesReceive);
        [OperationContract]
        Int32 AddPuzzleDrawDetails(PuzzleDrawDetails puzzleDrawDetails);
        [OperationContract]
        PuzzleDrawDetails AddPiecesPacketDetails(PuzzleDrawDetails piecesPacketDetails);
        [OperationContract]
        List<PuzzleDrawDetails> PuzzleDraw(PuzzleDrawDetails piecesPacketDetails);
        [OperationContract]
        List<RankList> GetRankListList(ref DataPage dp, RankList searchRankList);

          [OperationContract]
        int GetRedPacket(long userid, int areaId);

         [OperationContract]
          PuzzleDrawDetails PuzzleReceive(PuzzleDrawDetails PuzzleDrawDetails);

    }
}

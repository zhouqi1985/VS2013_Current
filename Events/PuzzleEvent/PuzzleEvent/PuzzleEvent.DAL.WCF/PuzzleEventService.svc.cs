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
    public class PuzzleEventService : IPuzzleEventService
    {
        private readonly PuzzleEvent.DAL.PuzzleEventDAL _dal = new PuzzleEventDAL();
        public List<UserPiecesTotal> GetUserPiecesTotalAll(UserPiecesTotal userpiecestotal)
        {
            return _dal.GetUserPiecesTotalAll(userpiecestotal);
        }
        public Int32 AddOrdinaryPacketReceive(UserSearch ordinaryPacketReceive)
        {

            return _dal.AddOrdinaryPacketReceive(ordinaryPacketReceive);
        }
        public Int32 AddExchangePacketReceive(UserSearch exchangePacketReceive, ref bool IsNotice, ref string PacketName)
        {
            return _dal.AddExchangePacketReceive(exchangePacketReceive, ref IsNotice,ref PacketName);

        }
        public List<PuzzlePieces> GetPiecesReceive(UserSearch searchPiecesReceive)
        {
            return _dal.GetPiecesReceive(searchPiecesReceive);

        }
        public Int32 AddPuzzleDrawDetails(PuzzleDrawDetails puzzleDrawDetails)
        {
            return _dal.AddPuzzleDrawDetails(puzzleDrawDetails);

        }
        public PuzzleDrawDetails AddPiecesPacketDetails(PuzzleDrawDetails piecesPacketDetails)
        {
            return _dal.AddPiecesPacketDetails(piecesPacketDetails);

        }
        public List<PuzzleDrawDetails> PuzzleDraw(PuzzleDrawDetails piecesPacketDetails)
        {
            return _dal.PuzzleDraw(piecesPacketDetails);

        }
        public List<RankList> GetRankListList(ref DataPage dp, RankList searchRankList)
        {
            return _dal.GetRankListList(ref dp,searchRankList);

        }

        public int GetRedPacket(long userid, int areaId)
        {
            return _dal.GetRedPacket(userid, areaId);
        }

        public PuzzleDrawDetails PuzzleReceive(PuzzleDrawDetails PuzzleDrawDetails)
        {
            return _dal.PuzzleReceive(PuzzleDrawDetails);
        }
    }
}

using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using CommonLibs.Common;

namespace PuzzleEvent.DAL.WCF.Client
{
    public class PuzzleEventServiceClient : IPuzzleEventServiceClient
    {
        private PuzzleEventService.PuzzleEventServiceClient _client;

        public List<UserPiecesTotal> GetUserPiecesTotalAll(UserPiecesTotal userpiecestotal)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            List<UserPiecesTotal> lists = new List<UserPiecesTotal>();
            try
            {
                lists = _client.GetUserPiecesTotalAll(userpiecestotal);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetUserPiecesTotalAll 获取指定用户信息失败");
                return lists;
            }

        }


        public Int32 AddOrdinaryPacketReceive(UserSearch ordinaryPacketReceive)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            try
            {
                int rs = _client.AddOrdinaryPacketReceive(ordinaryPacketReceive);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "AddOrdinaryPacketReceive 获取回馈礼包失败");
                return 0;
            }

        }
        public Int32 AddExchangePacketReceive(UserSearch exchangePacketReceive, ref bool IsNotice, ref string PacketName)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            try
            {
                int rs = _client.AddExchangePacketReceive(exchangePacketReceive, ref IsNotice,ref PacketName);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "AddExchangePacketReceive 获取拼图碎片礼包失败");
                return 0;
            }

        }
        public List<PuzzlePieces> GetPiecesReceive(UserSearch searchPiecesReceive)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            List<PuzzlePieces> lists = new List<PuzzlePieces>();
            try
            {
                lists = _client.GetPiecesReceive(searchPiecesReceive);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetUserPiecesTotalAll 获取指定用户信息失败");
                return lists;
            }

        }
        public Int32 AddPuzzleDrawDetails(PuzzleDrawDetails puzzleDrawDetails)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            try
            {
                int rs = _client.AddPuzzleDrawDetails(puzzleDrawDetails);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "AddPuzzleDrawDetails 兑换积分失败");
                return 0;
            }

        }
        public PuzzleDrawDetails AddPiecesPacketDetails(PuzzleDrawDetails piecesPacketDetails)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            PuzzleDrawDetails lists = new PuzzleDrawDetails();
            try
            {
                lists = _client.AddPiecesPacketDetails(piecesPacketDetails);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetUserPiecesTotalAll 获取指定用户信息失败");
                return lists;
            }

        }
        public List<PuzzleDrawDetails> PuzzleDraw(PuzzleDrawDetails piecesPacketDetails)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            List<PuzzleDrawDetails> lists = new List<PuzzleDrawDetails>();
            try
            {
                lists = _client.PuzzleDraw(piecesPacketDetails);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "PuzzleDraw 购买拼图礼包失败");
                return lists;
            }

        }

        public List<RankList> GetRankListList(ref DataPage dp, RankList searchRankList)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            List<RankList> lists = new List<RankList>();
            try
            {
                lists = _client.GetRankListList(ref dp, searchRankList);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetRankListList 获取排行榜失败");
                return lists;
            }
        
        }

        public int GetRedPacket(long userid, int areaId)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            try
            {
                int rs = _client.GetRedPacket(userid, areaId);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetRedPacket 领取红包失败");
                return 0;
            }
 
        }

        public PuzzleDrawDetails PuzzleReceive(PuzzleDrawDetails PuzzleDrawDetails)
        {
            _client = new PuzzleEventService.PuzzleEventServiceClient();
            PuzzleDrawDetails lists = new PuzzleDrawDetails();
            try
            {
                lists = _client.PuzzleReceive(PuzzleDrawDetails);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "PuzzleReceive 失败");
                return lists;
            }
        }
    }
}

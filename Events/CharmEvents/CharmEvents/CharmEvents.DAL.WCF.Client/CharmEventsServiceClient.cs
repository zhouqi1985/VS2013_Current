
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using CharmEvents.Database.Database;

namespace CharmEvents.DAL.WCF.Client
{
    public class CharmEventsServiceClient : ICharmEventsServiceClient
    {
        private CharmEventsService.CharmEventsServiceClient _client;

        public List<ResultInfo> GetUserInfo(UserInfo userinfo)
        {
            _client = new CharmEventsService.CharmEventsServiceClient();
            List<ResultInfo> lists = new List<ResultInfo>();
            try
            {
                lists = _client.GetUserInfo(userinfo);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "GetUserInfo failed");
                return lists;
            }
        }
        public ResultInfo UsersExchangePackets(UserInfo userinfo)
        {
            _client = new CharmEventsService.CharmEventsServiceClient();
            ResultInfo lists = new ResultInfo();
            try
            {
                lists = _client.UsersExchangePackets(userinfo);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "UsersExchangePackets failed");
                return lists;
            }
        }
        public ResultInfo UsersDrawPackets(UserInfo userinfo)
        {
            _client = new CharmEventsService.CharmEventsServiceClient();
            ResultInfo lists = new ResultInfo();
            try
            {
                lists = _client.UsersDrawPackets(userinfo);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "UsersDrawPackets failed");
                return lists;
            }
        }
        public ResultInfo UsersLoginPacket(UserInfo userinfo)
        {
            _client = new CharmEventsService.CharmEventsServiceClient();
            ResultInfo lists = new ResultInfo();
            try
            {
                lists = _client.UsersLoginPacket(userinfo);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "UsersLoginPacket failed");
                return lists;
            }
        }
        public List<RankList> GetRankListList(ref DataPage dp)
        {
            _client = new CharmEventsService.CharmEventsServiceClient();
            List<RankList> lists = new List<RankList>();
            try
            {
                lists = _client.GetRankListList(ref dp);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "GetRankListList failed");
                return lists;
            }
        }
    }
}

using CampEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using CampEvents.Database.Enums;

namespace CampEvents.DAL.WCF.Client
{
    public class CampEventsServiceClient : ICampEventsServiceClient
    {
        private CampEventsService.CampEventsServiceClient _client;
        public ResultInfo UserChooseCamp(UserInfo userinfo)
        {
            _client = new CampEventsService.CampEventsServiceClient();
            ResultInfo result = new ResultInfo() { Result=ErrorCode.UnSuccessful};
            try
            {
                result = _client.UserChooseCamp(userinfo);
                _client.Close();
                return result;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "UserChooseCamp Failed");
                return result;
            }
        }


        public List<RankListTop20> GetRankListTop20(UserInfo userinfo)
        {
            _client = new CampEventsService.CampEventsServiceClient();
            List<RankListTop20> result = new List<RankListTop20>();
            try
            {
                result = _client.GetRankListTop20(userinfo);
                _client.Close();
                return result;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetRankListTop20 Failed");
                return result;
            }
        }

        public ResultInfo ExchangePointPacket(UserInfo userinfo)
        {
            _client = new CampEventsService.CampEventsServiceClient();
            ResultInfo result = new ResultInfo() { Result = ErrorCode.UnSuccessful };
            try
            {
                result = _client.ExchangePointPacket(userinfo);
                _client.Close();
                return result;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "ExchangePointPacket Failed");
                return result;
            }
        }

        public ResultInfo GetUserInfo(UserInfo userinfo)
        {
            _client = new CampEventsService.CampEventsServiceClient();
            ResultInfo result = new ResultInfo() { Result = ErrorCode.UnSuccessful };
            try
            {
                result = _client.GetUserInfo(userinfo);
                _client.Close();
                return result;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetUserInfo Failed");
                return result;
            }
        }

        public List<CampConfig> GetCampInfo()
        {
            _client = new CampEventsService.CampEventsServiceClient();
            List<CampConfig> result = new List<CampConfig>();
            try
            {
                result = _client.GetCampInfo();
                _client.Close();
                return result;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetCampInfo Failed");
                return result;
            }
        }
    }
}

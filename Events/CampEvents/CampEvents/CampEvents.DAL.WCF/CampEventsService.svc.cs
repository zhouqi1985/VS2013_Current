using CampEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CampEvents.DAL.WCF
{
    public class CampEventsService : ICampEventsService
    {
        private readonly CampEvents.DAL.ICampEventsDAL _dal = new CampEvents.DAL.CampEventsDAL();
        public ResultInfo UserChooseCamp(UserInfo userinfo)
        {
           return _dal.UserChooseCamp(userinfo);
        }

        public List<RankListTop20> GetRankListTop20(UserInfo userinfo)
        {
            return _dal.GetRankListTop20(userinfo);
        }
        public ResultInfo ExchangePointPacket(UserInfo userinfo)
        {
            return _dal.ExchangePointPacket(userinfo);
        }
        public ResultInfo GetUserInfo(UserInfo userinfo)
        {
            return _dal.GetUserInfo(userinfo);
        }
        public List<CampConfig> GetCampInfo()
        {
            return _dal.GetCampInfo();
        }

    }
}

using CampEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampEvents.DAL.WCF.Client
{
    public interface ICampEventsServiceClient
    {
        ResultInfo UserChooseCamp(UserInfo userinfo);
        List<RankListTop20> GetRankListTop20(UserInfo userinfo);
        ResultInfo ExchangePointPacket(UserInfo userinfo);
        ResultInfo GetUserInfo(UserInfo userinfo);
        List<CampConfig> GetCampInfo();
    }
}

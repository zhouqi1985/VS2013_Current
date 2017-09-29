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
    [ServiceContract]
    public interface ICampEventsService
    {
        [OperationContract]
        ResultInfo UserChooseCamp(UserInfo userinfo);
        [OperationContract]
        List<RankListTop20> GetRankListTop20(UserInfo userinfo);
        [OperationContract]
        ResultInfo ExchangePointPacket(UserInfo userinfo);
        [OperationContract]
        ResultInfo GetUserInfo(UserInfo userinfo);
        [OperationContract]
        List<CampConfig> GetCampInfo();

    }
}

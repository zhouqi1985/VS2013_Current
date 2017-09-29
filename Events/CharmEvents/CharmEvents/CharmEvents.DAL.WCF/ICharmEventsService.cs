using CharmEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CharmEvents.DAL.WCF
{
    [ServiceContract]
    public interface ICharmEventsService
    {
        [OperationContract]
        List<ResultInfo> GetUserInfo(UserInfo userinfo);
        [OperationContract]
        ResultInfo UsersExchangePackets(UserInfo userinfo);
        [OperationContract]
        ResultInfo UsersDrawPackets(UserInfo userinfo);
        [OperationContract]
        ResultInfo UsersLoginPacket(UserInfo userinfo);
        [OperationContract]
        List<RankList> GetRankListList(ref DataPage dp);

    }
}

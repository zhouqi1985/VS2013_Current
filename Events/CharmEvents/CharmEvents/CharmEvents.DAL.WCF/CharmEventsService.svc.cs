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
    public class CharmEventsService : ICharmEventsService
    {
        private readonly CharmEvents.DAL.ICharmEventsDAL _dal = new CharmEvents.DAL.CharmEventsDAL();
        public List<ResultInfo> GetUserInfo(UserInfo userinfo)
        {
            return _dal.GetUserInfo(userinfo);
        }
        public ResultInfo UsersExchangePackets(UserInfo userinfo)
        {
            return _dal.UsersExchangePackets(userinfo);
        }
        public ResultInfo UsersDrawPackets(UserInfo userinfo)
        {
            return _dal.UsersDrawPackets(userinfo);
        }
        public ResultInfo UsersLoginPacket(UserInfo userinfo)
        {
            return _dal.UsersLoginPacket(userinfo);
        }
        public List<RankList> GetRankListList(ref DataPage dp)
        {
            return _dal.GetRankListList(ref dp);
        }

    }
}

﻿using CharmEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.DAL
{
    public interface ICharmEventsDAL
    {
        List<ResultInfo> GetUserInfo(UserInfo userinfo);
        ResultInfo UsersExchangePackets(UserInfo userinfo);
        ResultInfo UsersDrawPackets(UserInfo userinfo);
        ResultInfo UsersLoginPacket(UserInfo userinfo);
        List<RankList> GetRankListList(ref DataPage dp);
    }
}

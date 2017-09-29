using CampEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampEvents.DAL.AdminWCF.Client
{
    public interface ICampEventsAdminServiceClient
    {
        Int32 UpdateBasicConfig(BasicConfig basicConfig);
        List<BasicConfig> GetBasicConfigList();
        List<CampConfig> GetCampConfigList();
        int InsertDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        int UpdateDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        int DeleteDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        List<DailyTaskConfig> GetDailyTaskConfigList();
        List<GameDailyLogHistory> GetGameDailyLogHistoryList(ref DataPage dp, GameDailyLogHistory searchGameDailyLogHistory);
        List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog);
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchpacketqueuelog);
        int InsertPacketQueue(PacketQueue packetqueue);
        int DeletePacketQueue(PacketQueue packetqueue);
        List<PacketQueue> GetPacketQueueList(ref DataPage dp, PacketQueue searchPacketQueue);
        int CalculateFinalPackets();
        int InsertPointPacketConfig(PointPacketConfig pointpacketconfig);
        int UpdatePointPacketConfig(PointPacketConfig pointpacketconfig);
        int DeletePointPacketConfig(PointPacketConfig pointpacketconfig);
        List<PointPacketConfig> GetPointPacketConfigsList(ref DataPage dp);
        List<PointPacketExchangeLog> GetPointPacketExchangeLogList(ref DataPage dp, PointPacketExchangeLog searchPointPacketExchangeLog);
        int InsertRankListTop20(RankListTop20 ranklisttop20);
        int DeleteRankListTop20(RankListTop20 ranklisttop20);
        List<RankListTop20> GetRankListTop20List(ref DataPage dp, RankListTop20 searchRankListTop20);
        int CalculateRankPacket(RankListTop20 rankinfo, int packetid);
        List<UserCampLog> GetUserCampLogList(ref DataPage dp, UserCampLog searchUserCampLog);
        int InsertWallet(Wallet wallet);
        int DeleteWallet(Wallet wallet);
        List<Wallet> GetWalletList(ref DataPage dp, Wallet searchwallet);
    }
}

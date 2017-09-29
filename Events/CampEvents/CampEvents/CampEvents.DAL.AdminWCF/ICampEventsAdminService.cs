using CampEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CampEvents.DAL.AdminWCF
{
    [ServiceContract]
    public interface ICampEventsAdminService
    {
        [OperationContract]
        Int32 UpdateBasicConfig(BasicConfig basicConfig);
        [OperationContract]
        List<BasicConfig> GetBasicConfigList();
        [OperationContract]
        List<CampConfig> GetCampConfigList();
        [OperationContract]
        int InsertDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        [OperationContract]
        int UpdateDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        [OperationContract]
        int DeleteDailyTaskConfig(DailyTaskConfig dailytaskconfig);
        [OperationContract]
        List<DailyTaskConfig> GetDailyTaskConfigList();
        [OperationContract]
        List<GameDailyLogHistory> GetGameDailyLogHistoryList(ref DataPage dp, GameDailyLogHistory searchGameDailyLogHistory);
        [OperationContract]
        List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog);
        [OperationContract]
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchpacketqueuelog);
        [OperationContract]
        int InsertPacketQueue(PacketQueue packetqueue);
        [OperationContract]
        int DeletePacketQueue(PacketQueue packetqueue);
        [OperationContract]
        List<PacketQueue> GetPacketQueueList(ref DataPage dp, PacketQueue searchPacketQueue);
        [OperationContract]
        int CalculateFinalPackets();
        [OperationContract]
        int InsertPointPacketConfig(PointPacketConfig pointpacketconfig);
        [OperationContract]
        int UpdatePointPacketConfig(PointPacketConfig pointpacketconfig);
        [OperationContract]
        int DeletePointPacketConfig(PointPacketConfig pointpacketconfig);
        [OperationContract]
        List<PointPacketConfig> GetPointPacketConfigsList(ref DataPage dp);
        [OperationContract]
        List<PointPacketExchangeLog> GetPointPacketExchangeLogList(ref DataPage dp, PointPacketExchangeLog searchPointPacketExchangeLog);
        [OperationContract]
        int InsertRankListTop20(RankListTop20 ranklisttop20);
        [OperationContract]
        int DeleteRankListTop20(RankListTop20 ranklisttop20);
        [OperationContract]
        List<RankListTop20> GetRankListTop20List(ref DataPage dp, RankListTop20 searchRankListTop20);
        [OperationContract]
        int CalculateRankPacket(RankListTop20 rankinfo, int packetid);
        [OperationContract]
        List<UserCampLog> GetUserCampLogList(ref DataPage dp, UserCampLog searchUserCampLog);
        [OperationContract]
        int InsertWallet(Wallet wallet);
        [OperationContract]
        int DeleteWallet(Wallet wallet);
        [OperationContract]
        List<Wallet> GetWalletList(ref DataPage dp, Wallet searchwallet);
    }

}

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
    public class CampEventsAdminService : ICampEventsAdminService
    {
        private readonly CampEvents.DAL.Admin.ICampEventsAdmin _dal = new CampEvents.DAL.Admin.CampEventsAdmin();
        public int UpdateBasicConfig(BasicConfig basicConfig)
        {
            return _dal.UpdateBasicConfig(basicConfig);
        }

        public List<BasicConfig> GetBasicConfigList()
        {
            return _dal.GetBasicConfigList();
        }

        public List<CampConfig> GetCampConfigList()
        {
            return _dal.GetCampConfigList();
        }

        public int InsertDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            return _dal.InsertDailyTaskConfig(dailytaskconfig);
        }

        public int UpdateDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            return _dal.UpdateDailyTaskConfig(dailytaskconfig);
        }

        public int DeleteDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            return _dal.DeleteDailyTaskConfig(dailytaskconfig);
        }

        public List<DailyTaskConfig> GetDailyTaskConfigList()
        {
            return _dal.GetDailyTaskConfigList();
        }

        public List<GameDailyLogHistory> GetGameDailyLogHistoryList(ref DataPage dp, GameDailyLogHistory searchGameDailyLogHistory)
        {
            return _dal.GetGameDailyLogHistoryList(ref  dp, searchGameDailyLogHistory);
        }

        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {
            return _dal.GetGameDailyLogList(ref  dp, searchGameDailyLog);
        }

        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchpacketqueuelog)
        {
            return _dal.GetPacketQueueLogList(ref  dp, searchpacketqueuelog);
        }

        public int InsertPacketQueue(PacketQueue packetqueue)
        {
            return _dal.InsertPacketQueue(packetqueue);
        }

        public int DeletePacketQueue(PacketQueue packetqueue)
        {
            return _dal.DeletePacketQueue(packetqueue);
        }

        public List<PacketQueue> GetPacketQueueList(ref DataPage dp, PacketQueue searchPacketQueue)
        {
            return _dal.GetPacketQueueList(ref  dp, searchPacketQueue);
        }

        public int CalculateFinalPackets()
        {
            return _dal.CalculateFinalPackets();
        }

        public int InsertPointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            return _dal.InsertPointPacketConfig(pointpacketconfig);
        }

        public int UpdatePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            return _dal.UpdatePointPacketConfig(pointpacketconfig);
        }

        public int DeletePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            return _dal.DeletePointPacketConfig(pointpacketconfig);
        }

        public List<PointPacketConfig> GetPointPacketConfigsList(ref DataPage dp)
        {
            return _dal.GetPointPacketConfigsList(ref  dp);
        }

        public List<PointPacketExchangeLog> GetPointPacketExchangeLogList(ref DataPage dp, PointPacketExchangeLog searchPointPacketExchangeLog)
        {
            return _dal.GetPointPacketExchangeLogList(ref  dp, searchPointPacketExchangeLog);
        }

        public int InsertRankListTop20(RankListTop20 ranklisttop20)
        {
            return _dal.InsertRankListTop20(ranklisttop20);
        }

        public int DeleteRankListTop20(RankListTop20 ranklisttop20)
        {
            return _dal.DeleteRankListTop20(ranklisttop20);
        }

        public List<RankListTop20> GetRankListTop20List(ref DataPage dp, RankListTop20 searchRankListTop20)
        {
            return _dal.GetRankListTop20List(ref  dp, searchRankListTop20);
        }

        public int CalculateRankPacket(RankListTop20 rankinfo, int packetid)
        {
            return _dal.CalculateRankPacket(rankinfo, packetid);
        }

        public List<UserCampLog> GetUserCampLogList(ref DataPage dp, UserCampLog searchUserCampLog)
        {
            return _dal.GetUserCampLogList(ref  dp, searchUserCampLog);
        }

        public int InsertWallet(Wallet wallet)
        {
            return _dal.InsertWallet(wallet);
        }

        public int DeleteWallet(Wallet wallet)
        {
            return _dal.DeleteWallet(wallet);
        }

        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchwallet)
        {
            List<Wallet> wallet = new List<Wallet>();
            wallet= _dal.GetWalletList(ref  dp, searchwallet);
            return wallet;
        }
    }
}

using CampEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using CommonLibs.Common;

namespace CampEvents.DAL.AdminWCF.Client
{
    public class CampEventsAdminServiceClient : ICampEventsAdminServiceClient
    {
        private CampEventsAdminService.CampEventsAdminServiceClient _admin;
        public int UpdateBasicConfig(BasicConfig basicConfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdateBasicConfig(basicConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateBasicConfig failed");
                return 0;
            }
        }

        public List<BasicConfig> GetBasicConfigList()
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<BasicConfig> lists = new List<BasicConfig>();
            try
            {
                lists = _admin.GetBasicConfigList();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetBasicConfigList failed");
                return lists;
            }

        }

        public List<CampConfig> GetCampConfigList()
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<CampConfig> lists = new List<CampConfig>();
            try
            {
                lists = _admin.GetCampConfigList();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetCampConfigList failed");
                return lists;
            }
        }

        public int InsertDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.InsertDailyTaskConfig(dailytaskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertDailyTaskConfig failed");
                return 0;
            }
        }

        public int UpdateDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdateDailyTaskConfig(dailytaskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateDailyTaskConfig failed");
                return 0;
            }
        }

        public int DeleteDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.DeleteDailyTaskConfig(dailytaskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeleteDailyTaskConfig failed");
                return 0;
            }
        }

        public List<DailyTaskConfig> GetDailyTaskConfigList()
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<DailyTaskConfig> lists = new List<DailyTaskConfig>();
            try
            {
                lists = _admin.GetDailyTaskConfigList();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetDailyTaskConfigList failed");
                return lists;
            }
        }

        public List<GameDailyLogHistory> GetGameDailyLogHistoryList(ref DataPage dp, GameDailyLogHistory searchGameDailyLogHistory)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<GameDailyLogHistory> lists = new List<GameDailyLogHistory>();
            try
            {
                lists = _admin.GetGameDailyLogHistoryList(ref dp, searchGameDailyLogHistory);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetGameDailyLogHistoryList failed");
                return lists;
            }
        }

        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<GameDailyLog> lists = new List<GameDailyLog>();
            try
            {
                lists = _admin.GetGameDailyLogList(ref dp, searchGameDailyLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetGameDailyLogList failed");
                return lists;
            }
        }

        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchpacketqueuelog)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            try
            {
                lists = _admin.GetPacketQueueLogList(ref dp,searchpacketqueuelog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetPacketQueueLogList failed");
                return lists;
            }
        }

        public int InsertPacketQueue(PacketQueue packetqueue)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.InsertPacketQueue(packetqueue);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertPacketQueue failed");
                return 0;
            }
        }

        public int DeletePacketQueue(PacketQueue packetqueue)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.DeletePacketQueue(packetqueue);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeletePacketQueue failed");
                return 0;
            }
        }

        public List<PacketQueue> GetPacketQueueList(ref DataPage dp, PacketQueue searchPacketQueue)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<PacketQueue> lists = new List<PacketQueue>();
            try
            {
                lists = _admin.GetPacketQueueList(ref dp, searchPacketQueue);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetPacketQueueList failed");
                return lists;
            }
        }

        public int CalculateFinalPackets()
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.CalculateFinalPackets();
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "CalculateFinalPackets failed");
                return 0;
            }
        }

        public int InsertPointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.InsertPointPacketConfig(pointpacketconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertPointPacketConfig failed");
                return 0;
            }
        }

        public int UpdatePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdatePointPacketConfig(pointpacketconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdatePointPacketConfig failed");
                return 0;
            }
        }

        public int DeletePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.DeletePointPacketConfig(pointpacketconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeletePointPacketConfig failed");
                return 0;
            }
        }

        public List<PointPacketConfig> GetPointPacketConfigsList(ref DataPage dp)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<PointPacketConfig> lists = new List<PointPacketConfig>();
            try
            {
                lists = _admin.GetPointPacketConfigsList(ref dp);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetPointPacketConfigsList failed");
                return lists;
            }
        }

        public List<PointPacketExchangeLog> GetPointPacketExchangeLogList(ref DataPage dp, PointPacketExchangeLog searchPointPacketExchangeLog)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<PointPacketExchangeLog> lists = new List<PointPacketExchangeLog>();
            try
            {
                lists = _admin.GetPointPacketExchangeLogList(ref dp,searchPointPacketExchangeLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetPointPacketExchangeLogList failed");
                return lists;
            }
        }

        public int InsertRankListTop20(RankListTop20 ranklisttop20)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.InsertRankListTop20(ranklisttop20);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertRankListTop20 failed");
                return 0;
            }
        }

        public int DeleteRankListTop20(RankListTop20 ranklisttop20)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.DeleteRankListTop20(ranklisttop20);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeleteRankListTop20 failed");
                return 0;
            }
        }

        public List<RankListTop20> GetRankListTop20List(ref DataPage dp, RankListTop20 searchRankListTop20)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<RankListTop20> lists = new List<RankListTop20>();
            try
            {
                lists = _admin.GetRankListTop20List(ref dp, searchRankListTop20);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetRankListTop20List failed");
                return lists;
            }
        }

        public int CalculateRankPacket(RankListTop20 rankinfo, int packetid)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.CalculateRankPacket(rankinfo, packetid);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "CalculateRankPacket failed");
                return 0;
            }
        }

        public List<UserCampLog> GetUserCampLogList(ref DataPage dp, UserCampLog searchUserCampLog)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<UserCampLog> lists = new List<UserCampLog>();
            try
            {
                lists = _admin.GetUserCampLogList(ref dp, searchUserCampLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetUserCampLogList failed");
                return lists;
            }
        }

        public int InsertWallet(Wallet wallet)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.InsertWallet(wallet);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertWallet failed");
                return 0;
            }
        }

        public int DeleteWallet(Wallet wallet)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            try
            {
                int rs = _admin.DeleteWallet(wallet);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeleteWallet failed");
                return 0;
            }
        }

        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchwallet)
        {
            _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
            List<Wallet> lists = new List<Wallet>();
            try
            {
                lists = _admin.GetWalletList(ref dp, searchwallet);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetWalletList failed");
                return lists;
            }
        }
    }
}

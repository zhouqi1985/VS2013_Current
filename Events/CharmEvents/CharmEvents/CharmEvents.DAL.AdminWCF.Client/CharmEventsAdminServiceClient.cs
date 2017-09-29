using CharmEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using System.Data;

namespace CharmEvents.DAL.AdminWCF.Client
{
    public class CharmEventsAdminServiceClient : ICharmEventsAdminServiceClient
    {
        private CharmEventsAdminService.CharmEventsAdminServiceClient _admin;
        public List<ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref DataPage dp, ExchangeAndDrawLog searchExchangeAndDrawLog)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<ExchangeAndDrawLog> lists = new List<ExchangeAndDrawLog>();
            try
            {
                lists = _admin.GetExchangeAndDrawLogList(ref dp, searchExchangeAndDrawLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangeAndDrawLogList failed");
                return lists;
            }

        }
        public List<LoginPacketLog> GetLoginPacketLogList(ref DataPage dp, LoginPacketLog searchLoginPacketLog)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<LoginPacketLog> lists = new List<LoginPacketLog>();
            try
            {
                lists = _admin.GetLoginPacketLogList(ref dp, searchLoginPacketLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetLoginPacketLogList failed");
                return lists;
            }

        }
        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<PacketQueueLog> lists = new List<PacketQueueLog>();
            try
            {
                lists = _admin.GetPacketQueueLogList(ref dp, searchPacketQueueLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPacketQueueLogList failed");
                return lists;
            }

        }
        public List<Wallets> GetWalletsList(ref DataPage dp, Wallets searchWallets)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<Wallets> lists = new List<Wallets>();
            try
            {
                lists = _admin.GetWalletsList(ref dp, searchWallets);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetWalletsList failed");
                return lists;
            }

        }
        public Int64 AddWallets(Wallets wallets)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                long rs = _admin.AddWallets(wallets);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "AddWallets failed");
                return 0;
            }
        }
        public int AddDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.AddDrawPacketConfig(drawPacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "AddDrawPacketConfig failed");
                return 0;
            }
        }
        public int UpdateDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdateDrawPacketConfig(drawPacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateDrawPacketConfig failed");
                return 0;
            }
        }
        public bool DelDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                bool rs = _admin.DelDrawPacketConfig(drawPacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DelDrawPacketConfig failed");
                return false;
            }
        }
        public DrawPacketConfig GetDrawPacketConfig(DrawPacketConfig searchDrawPacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            DrawPacketConfig lists = new DrawPacketConfig();
            try
            {
                lists = _admin.GetDrawPacketConfig(searchDrawPacketConfig);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetDrawPacketConfig failed");
                return lists;
            }

        }
        public List<DrawPacketConfig> GetDrawPacketConfigList(ref DataPage dp)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<DrawPacketConfig> lists = new List<DrawPacketConfig>();
            try
            {
                lists = _admin.GetDrawPacketConfigList(ref  dp);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetDrawPacketConfigList failed");
                return lists;
            }

        }
        public int SubmitDrawPacketConfigRate()
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.SubmitDrawPacketConfigRate();
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "SubmitDrawPacketConfigRate failed");
                return 0;
            }
        }
        public Int32 AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.AddExchangePacketTypeConfig(exchangePacketTypeConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "AddExchangePacketTypeConfig failed");
                return 0;
            }
        }
        public Int32 UpdateExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdateExchangePacketTypeConfig(exchangePacketTypeConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateExchangePacketTypeConfig failed");
                return 0;
            }
        }
        public bool DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                bool rs = _admin.DelExchangePacketTypeConfig(exchangePacketTypeConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DelExchangePacketTypeConfig failed");
                return false;
            }
        }
        public ExchangePacketTypeConfig GetExchangePacketTypeConfig(ExchangePacketTypeConfig searchExchangePacketTypeConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            ExchangePacketTypeConfig lists = new ExchangePacketTypeConfig();
            try
            {
                lists = _admin.GetExchangePacketTypeConfig(searchExchangePacketTypeConfig);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketTypeConfig failed");
                return lists;
            }

        }
        public List<ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref DataPage dp)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<ExchangePacketTypeConfig> lists = new List<ExchangePacketTypeConfig>();
            try
            {
                lists = _admin.GetExchangePacketTypeConfigList(ref  dp);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketTypeConfigList failed");
                return lists;
            }

        }
        public Int32 AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.AddExchangePacketConfig(exchangePacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "AddExchangePacketConfig failed");
                return 0;
            }
        }
        public Int32 UpdateExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.UpdateExchangePacketConfig(exchangePacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateExchangePacketConfig failed");
                return 0;
            }
        }

        public bool DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                bool rs = _admin.DelExchangePacketConfig(exchangePacketConfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DelExchangePacketConfig failed");
                return false;
            }
        }
        public ExchangePacketConfig GetExchangePacketConfig(ExchangePacketConfig searchExchangePacketConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            ExchangePacketConfig lists = new ExchangePacketConfig();
            try
            {
                lists = _admin.GetExchangePacketConfig(searchExchangePacketConfig);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketConfig failed");
                return lists;
            }

        }

        public List<ExchangePacketConfig> GetExchangePacketConfigList(ref DataPage dp)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<ExchangePacketConfig> lists = new List<ExchangePacketConfig>();
            try
            {
                lists = _admin.GetExchangePacketConfigList(ref dp);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetExchangePacketConfigList failed");
                return lists;
            }

        }
        public Int32 UpdateBasicConfig(BasicConfig basicConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
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
        public List<BasicConfig> GetBasicConfigAll()
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<BasicConfig> lists = new List<BasicConfig>();
            try
            {
                lists = _admin.GetBasicConfigAll();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetBasicConfigAll failed");
                return lists;
            }

        }
        public BasicConfig GetBasicConfig(BasicConfig searchBasicConfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            BasicConfig lists = new BasicConfig();
            try
            {
                lists = _admin.GetBasicConfig(searchBasicConfig);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetBasicConfig failed");
                return lists;
            }

        }

        public Int32 importCSVtoDB(DataSet ds, string TableName)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.importCSVtoDB(ds, TableName);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "importCSVtoDB failed");
                return 0;
            }
        }

        public Int32 AddDailyReportTotalPeople(DailyReportTotalPeople dailyReportTotalPeople)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            try
            {
                int rs = _admin.AddDailyReportTotalPeople(dailyReportTotalPeople);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "AddDailyReportTotalPeople failed");
                return 0;
            }

        }
        public List<DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref DataPage dp, DailyReportTotalPeople searchDailyReportTotalPeople)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<DailyReportTotalPeople> lists = new List<DailyReportTotalPeople>();
            try
            {
                lists = _admin.GetDailyReportTotalPeopleList(ref dp, searchDailyReportTotalPeople);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetDailyReportTotalPeopleList failed");
                return lists;
            }

        }
        public List<DailyReportItemConsume> GetDailyReportItemConsumeAll()
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<DailyReportItemConsume> lists = new List<DailyReportItemConsume>();
            try
            {
                lists = _admin.GetDailyReportItemConsumeAll();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetDailyReportItemConsumeAll failed");
                return lists;
            }

        }
        public List<DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll()
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<DailyReportGameDetailsPerUser> lists = new List<DailyReportGameDetailsPerUser>();
            try
            {
                lists = _admin.GetDailyReportGameDetailsPerUserAll();
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetDailyReportGameDetailsPerUserAll failed");
                return lists;
            }

        }
        public Int32 TransferDataAllReportDateConfigAdd(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataAllReportDateConfigAdd(searchTransferData_All_ReportDateConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataAllReportDateConfigAdd failed");
                return result;
            }
        }
        public bool TransferDataAllReportDateConfigDel(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            bool result = false;

            try
            {
                result = _admin.TransferDataAllReportDateConfigDel(searchTransferData_All_ReportDateConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataAllReportDateConfigDel failed");
                return false;
            }
        }
        public Int32 TransferDataAllReportDateConfigUpdate(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataAllReportDateConfigUpdate(searchTransferData_All_ReportDateConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataAllReportDateConfigUpdate failed");
                return result;
            }
        }
        public Int32 TransferDataGameDetailsItemConfigAdd(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataGameDetailsItemConfigAdd(searchTransferData_GameDetails_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsItemConfigAdd failed");
                return result;
            }
        }
        public bool TransferDataGameDetailsItemConfigDel(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            bool result = false;

            try
            {
                result = _admin.TransferDataGameDetailsItemConfigDel(searchTransferData_GameDetails_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsItemConfigDel failed");
                return result;
            }
        }
        public Int32 TransferDataGameDetailsItemConfigUpdate(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataGameDetailsItemConfigUpdate(searchTransferData_GameDetails_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsItemConfigUpdate failed");
                return result;
            }
        }

        public Int32 TransferDataGameDetailsUsersConfigAdd(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigAdd(searchTransferData_GameDetails_UsersConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigAdd failed");
                return result;
            }
        }
        public bool TransferDataGameDetailsUsersConfigDel(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            bool result = false;

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigDel(searchTransferData_GameDetails_UsersConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigDel failed");
                return result;
            }
        }
        public Int32 TransferDataGameDetailsUsersConfigUpdate(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigUpdate(searchTransferData_GameDetails_UsersConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigUpdate failed");
                return result;
            }
        }
        public Int32 TransferDataItemConsumeItemConfigAdd(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataItemConsumeItemConfigAdd(searchTransferData_ItemConsume_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataItemConsumeItemConfigAdd failed");
                return result;
            }
        }
        public bool TransferDataItemConsumeItemConfigDel(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            bool result = false;

            try
            {
                result = _admin.TransferDataItemConsumeItemConfigDel(searchTransferData_ItemConsume_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataItemConsumeItemConfigDel failed");
                return result;
            }
        }
        public Int32 TransferDataItemConsumeItemConfigUpdate(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataItemConsumeItemConfigUpdate(searchTransferData_ItemConsume_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataItemConsumeItemConfigUpdate failed");
                return result;
            }
        }
        public TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            TransferData_All_ReportDateConfig result = new TransferData_All_ReportDateConfig();

            try
            {
                result = _admin.TransferDataAllReportDateConfigGetByConfigId(searchTransferData_All_ReportDateConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataAllReportDateConfigGetByConfigId failed");
                return result;
            }
        }
        public List<TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref DataPage dp, TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<TransferData_All_ReportDateConfig> result = new List<TransferData_All_ReportDateConfig>();

            try
            {
                result = _admin.TransferDataAllReportDateConfigGetList(ref dp, searchTransferData_All_ReportDateConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataAllReportDateConfigGetList failed");
                return result;
            }
        }
        public TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            TransferData_GameDetails_ItemConfig result = new TransferData_GameDetails_ItemConfig();

            try
            {
                result = _admin.TransferDataGameDetailsItemConfigGetByItemId(searchTransferData_GameDetails_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsItemConfigGetByItemId failed");
                return result;
            }
        }
        public List<TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref DataPage dp, TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<TransferData_GameDetails_ItemConfig> result = new List<TransferData_GameDetails_ItemConfig>();

            try
            {
                result = _admin.TransferDataGameDetailsItemConfigGetList(ref dp, searchTransferData_GameDetails_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsItemConfigGetList failed");
                return result;
            }
        }
        public TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            TransferData_GameDetails_UsersConfig result = new TransferData_GameDetails_UsersConfig();

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigGetById(searchTransferData_GameDetails_UsersConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigGetById failed");
                return result;
            }
        }
        public List<TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref DataPage dp, TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<TransferData_GameDetails_UsersConfig> result = new List<TransferData_GameDetails_UsersConfig>();

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigGetList(ref dp, searchTransferData_GameDetails_UsersConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigGetList failed");
                return result;
            }
        }
        public TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            TransferData_ItemConsume_ItemConfig result = new TransferData_ItemConsume_ItemConfig();

            try
            {
                result = _admin.TransferDataItemConsumeItemConfigGetByItemId(searchTransferData_ItemConsume_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataItemConsumeItemConfigGetByItemId failed");
                return result;
            }
        }
        public List<TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref DataPage dp, TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<TransferData_ItemConsume_ItemConfig> result = new List<TransferData_ItemConsume_ItemConfig>();

            try
            {
                result = _admin.TransferDataItemConsumeItemConfigGetList(ref dp, searchTransferData_ItemConsume_ItemConfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataItemConsumeItemConfigGetList failed");
                return result;
            }
        }
        public List<RankList_TopN> GetRankListTopNList(ref DataPage dp, RankList_TopN searchRankListTopN)
        {

            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            List<RankList_TopN> result = new List<RankList_TopN>();

            try
            {
                result = _admin.GetRankListTopNList(ref dp, searchRankListTopN);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetRankListTopNList failed");
                return result;
            }
        }
        public int RefreshTopNList()
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.RefreshTopNList();
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "RefreshTopNList failed");
                return result;
            }
        }
        public Int32 TransferDataGameDetailsUsersConfigBatchAdd(List<TransferData_GameDetails_UsersConfig> listuserconfig)
        {
            _admin = new CharmEventsAdminService.CharmEventsAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.TransferDataGameDetailsUsersConfigBatchAdd(listuserconfig);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "TransferDataGameDetailsUsersConfigBatchAdd failed");
                return result;
            }
        }

    }
}

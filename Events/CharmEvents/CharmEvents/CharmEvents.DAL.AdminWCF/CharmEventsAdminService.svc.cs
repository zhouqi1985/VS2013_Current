using CharmEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CharmEvents.DAL.AdminWCF
{
    public class CharmEventsAdminService : ICharmEventsAdminService
    {
        private readonly CharmEvents.DAL.Admin.ICharmEventsAdmin _dal = new CharmEvents.DAL.Admin.CharmEventsAdmin();
        public List<ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref DataPage dp, ExchangeAndDrawLog searchExchangeAndDrawLog)
        {
            return _dal.GetExchangeAndDrawLogList(ref dp, searchExchangeAndDrawLog);
        }
        public List<LoginPacketLog> GetLoginPacketLogList(ref DataPage dp, LoginPacketLog searchLoginPacketLog)
        {
            return _dal.GetLoginPacketLogList(ref dp, searchLoginPacketLog);
        }
        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog)
        {
            return _dal.GetPacketQueueLogList(ref dp, searchPacketQueueLog);
        }
        public List<Wallets> GetWalletsList(ref DataPage dp, Wallets searchWallets)
        {
            return _dal.GetWalletsList(ref dp, searchWallets);
        }
        public Int64 AddWallets(Wallets wallets)
        {
            return _dal.AddWallets(wallets);
        }
        public int AddDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            return _dal.AddDrawPacketConfig(drawPacketConfig);
        }
        public int UpdateDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            return _dal.UpdateDrawPacketConfig(drawPacketConfig);
        }
        public bool DelDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            return _dal.DelDrawPacketConfig(drawPacketConfig);
        }
        public DrawPacketConfig GetDrawPacketConfig(DrawPacketConfig searchDrawPacketConfig)
        {
            return _dal.GetDrawPacketConfig(searchDrawPacketConfig);
        }
        public List<DrawPacketConfig> GetDrawPacketConfigList(ref DataPage dp)
        {
            return _dal.GetDrawPacketConfigList(ref dp);
        }
        public int SubmitDrawPacketConfigRate()
        {
            return _dal.SubmitDrawPacketConfigRate();
        }
        public Int32 AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            return _dal.AddExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        public Int32 UpdateExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            return _dal.UpdateExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        public bool DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            return _dal.DelExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        public ExchangePacketTypeConfig GetExchangePacketTypeConfig(ExchangePacketTypeConfig searchExchangePacketTypeConfig)
        {
            return _dal.GetExchangePacketTypeConfig(searchExchangePacketTypeConfig);
        }
        public List<ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref DataPage dp)
        {
            return _dal.GetExchangePacketTypeConfigList(ref  dp);
        }
        public Int32 AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            return _dal.AddExchangePacketConfig(exchangePacketConfig);
        }
        public Int32 UpdateExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            return _dal.UpdateExchangePacketConfig(exchangePacketConfig);
        }
        public bool DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            return _dal.DelExchangePacketConfig(exchangePacketConfig);
        }
        public ExchangePacketConfig GetExchangePacketConfig(ExchangePacketConfig searchExchangePacketConfig)
        {
            return _dal.GetExchangePacketConfig(searchExchangePacketConfig);
        }
        public List<ExchangePacketConfig> GetExchangePacketConfigList(ref DataPage dp)
        {
            return _dal.GetExchangePacketConfigList(ref  dp);
        }
        public Int32 UpdateBasicConfig(BasicConfig basicConfig)
        {
            return _dal.UpdateBasicConfig(basicConfig);
        }
        public List<BasicConfig> GetBasicConfigAll()
        {
            return _dal.GetBasicConfigAll();
        }
        public BasicConfig GetBasicConfig(BasicConfig searchBasicConfig)
        {
            return _dal.GetBasicConfig(searchBasicConfig);
        }
        public Int32 importCSVtoDB(DataSet ds, string TableName)
        {
            return _dal.importCSVtoDB(ds, TableName);
        }

        public Int32 AddDailyReportTotalPeople(DailyReportTotalPeople dailyReportTotalPeople)
        {
            return _dal.AddDailyReportTotalPeople(dailyReportTotalPeople);
        }
        public List<DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref DataPage dp, DailyReportTotalPeople searchDailyReportTotalPeople)
        {
            return _dal.GetDailyReportTotalPeopleList(ref dp, searchDailyReportTotalPeople);
        }
        public List<DailyReportItemConsume> GetDailyReportItemConsumeAll()
        {
            return _dal.GetDailyReportItemConsumeAll();
        }

        public List<DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll()
        {
            return _dal.GetDailyReportGameDetailsPerUserAll();
        }

        public Int32 TransferDataAllReportDateConfigAdd(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {
            return _dal.TransferDataAllReportDateConfigAdd(searchTransferData_All_ReportDateConfig);
        }

        public bool TransferDataAllReportDateConfigDel(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {
            return _dal.TransferDataAllReportDateConfigDel(searchTransferData_All_ReportDateConfig);
        }

        public Int32 TransferDataAllReportDateConfigUpdate(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {
            return _dal.TransferDataAllReportDateConfigUpdate(searchTransferData_All_ReportDateConfig);
        }

        public TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {
            return _dal.TransferDataAllReportDateConfigGetByConfigId(searchTransferData_All_ReportDateConfig);
        }

        public List<TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref DataPage dp, TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig)
        {
            return _dal.TransferDataAllReportDateConfigGetList(ref dp, searchTransferData_All_ReportDateConfig);
        }

        public Int32 TransferDataGameDetailsItemConfigAdd(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {
            return _dal.TransferDataGameDetailsItemConfigAdd(searchTransferData_GameDetails_ItemConfig);
        }

        public bool TransferDataGameDetailsItemConfigDel(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {
            return _dal.TransferDataGameDetailsItemConfigDel(searchTransferData_GameDetails_ItemConfig);
        }

        public Int32 TransferDataGameDetailsItemConfigUpdate(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {
            return _dal.TransferDataGameDetailsItemConfigUpdate(searchTransferData_GameDetails_ItemConfig);
        }
        public TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {
            return _dal.TransferDataGameDetailsItemConfigGetByItemId(searchTransferData_GameDetails_ItemConfig);
        }
        public List<TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref DataPage dp, TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig)
        {
            return _dal.TransferDataGameDetailsItemConfigGetList(ref dp, searchTransferData_GameDetails_ItemConfig);
        }

        public Int32 TransferDataGameDetailsUsersConfigAdd(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigAdd(searchTransferData_GameDetails_UsersConfig);
        }

        public bool TransferDataGameDetailsUsersConfigDel(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigDel(searchTransferData_GameDetails_UsersConfig);
        }

        public Int32 TransferDataGameDetailsUsersConfigUpdate(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigUpdate(searchTransferData_GameDetails_UsersConfig);
        }
        public TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigGetById(searchTransferData_GameDetails_UsersConfig);
        }
        public List<TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref DataPage dp, TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigGetList(ref dp, searchTransferData_GameDetails_UsersConfig);
        }

        public Int32 TransferDataItemConsumeItemConfigAdd(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {
            return _dal.TransferDataItemConsumeItemConfigAdd(searchTransferData_ItemConsume_ItemConfig);
        }

        public bool TransferDataItemConsumeItemConfigDel(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {
            return _dal.TransferDataItemConsumeItemConfigDel(searchTransferData_ItemConsume_ItemConfig);
        }

        public Int32 TransferDataItemConsumeItemConfigUpdate(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {
            return _dal.TransferDataItemConsumeItemConfigUpdate(searchTransferData_ItemConsume_ItemConfig);
        }
        public TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {
            return _dal.TransferDataItemConsumeItemConfigGetByItemId(searchTransferData_ItemConsume_ItemConfig);
        }
        public List<TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref DataPage dp, TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig)
        {
            return _dal.TransferDataItemConsumeItemConfigGetList(ref dp, searchTransferData_ItemConsume_ItemConfig);
        }
        public List<RankList_TopN> GetRankListTopNList(ref DataPage dp, RankList_TopN searchRankListTopN)
        {
            return _dal.GetRankListTopNList(ref dp,searchRankListTopN);
        }
        public int RefreshTopNList()
        {
            return _dal.RefreshTopNList();
        }
        public Int32 TransferDataGameDetailsUsersConfigBatchAdd(List<TransferData_GameDetails_UsersConfig> listuserconfig)
        {
            return _dal.TransferDataGameDetailsUsersConfigBatchAdd(listuserconfig);
        }
    }
}

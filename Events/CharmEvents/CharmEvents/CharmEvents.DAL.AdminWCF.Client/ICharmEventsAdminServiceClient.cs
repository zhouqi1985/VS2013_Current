using CharmEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CharmEvents.DAL.AdminWCF.Client
{
    public interface ICharmEventsAdminServiceClient
    {
        List<ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref DataPage dp, ExchangeAndDrawLog searchExchangeAndDrawLog);
        List<LoginPacketLog> GetLoginPacketLogList(ref DataPage dp, LoginPacketLog searchLoginPacketLog);
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog);
        List<Wallets> GetWalletsList(ref DataPage dp, Wallets searchWallets);
        Int64 AddWallets(Wallets wallets);
        int AddDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        int UpdateDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        bool DelDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        DrawPacketConfig GetDrawPacketConfig(DrawPacketConfig searchDrawPacketConfig);
        List<DrawPacketConfig> GetDrawPacketConfigList(ref DataPage dp);
        int SubmitDrawPacketConfigRate();
        Int32 AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        Int32 UpdateExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        bool DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        ExchangePacketTypeConfig GetExchangePacketTypeConfig(ExchangePacketTypeConfig searchExchangePacketTypeConfig);
        List<ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref DataPage dp);
        Int32 AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        Int32 UpdateExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        bool DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        ExchangePacketConfig GetExchangePacketConfig(ExchangePacketConfig searchExchangePacketConfig);
        List<ExchangePacketConfig> GetExchangePacketConfigList(ref DataPage dp);
        Int32 UpdateBasicConfig(BasicConfig basicConfig);
        List<BasicConfig> GetBasicConfigAll();
        BasicConfig GetBasicConfig(BasicConfig searchBasicConfig);
        Int32 importCSVtoDB(DataSet ds, string TableName);
        Int32 AddDailyReportTotalPeople(DailyReportTotalPeople dailyReportTotalPeople);
        List<DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref DataPage dp, DailyReportTotalPeople searchDailyReportTotalPeople);
        List<DailyReportItemConsume> GetDailyReportItemConsumeAll();
        List<DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll();
        Int32 TransferDataAllReportDateConfigAdd(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);

        bool TransferDataAllReportDateConfigDel(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);

        List<TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref DataPage dp, TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);

        Int32 TransferDataAllReportDateConfigUpdate(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);

        Int32 TransferDataGameDetailsItemConfigAdd(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);

        bool TransferDataGameDetailsItemConfigDel(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);

        TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);

        List<TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref DataPage dp, TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);

        Int32 TransferDataGameDetailsItemConfigUpdate(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);

        Int32 TransferDataGameDetailsUsersConfigAdd(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);

        bool TransferDataGameDetailsUsersConfigDel(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);

        TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);

        List<TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref DataPage dp, TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);

        Int32 TransferDataGameDetailsUsersConfigUpdate(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);

        Int32 TransferDataItemConsumeItemConfigAdd(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        bool TransferDataItemConsumeItemConfigDel(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);

        TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);

        List<TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref DataPage dp, TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);

        Int32 TransferDataItemConsumeItemConfigUpdate(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        List<RankList_TopN> GetRankListTopNList(ref DataPage dp, RankList_TopN searchRankListTopN);
        int RefreshTopNList();
        Int32 TransferDataGameDetailsUsersConfigBatchAdd(List<TransferData_GameDetails_UsersConfig> listuserconfig);



    }
}

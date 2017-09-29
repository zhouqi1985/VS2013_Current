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
    [ServiceContract]
    public interface ICharmEventsAdminService
    {
        [OperationContract]
        List<ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref DataPage dp, ExchangeAndDrawLog searchExchangeAndDrawLog);
        [OperationContract]
        List<LoginPacketLog> GetLoginPacketLogList(ref DataPage dp, LoginPacketLog searchLoginPacketLog);
        [OperationContract]
        List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog);
        [OperationContract]
        List<Wallets> GetWalletsList(ref DataPage dp, Wallets searchWallets);
        [OperationContract]
        Int64 AddWallets(Wallets wallets);
        [OperationContract]
        int AddDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        [OperationContract]
        int UpdateDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        [OperationContract]
        bool DelDrawPacketConfig(DrawPacketConfig drawPacketConfig);
        [OperationContract]
        DrawPacketConfig GetDrawPacketConfig(DrawPacketConfig searchDrawPacketConfig);
        [OperationContract]
        List<DrawPacketConfig> GetDrawPacketConfigList(ref DataPage dp);
        [OperationContract]
        int SubmitDrawPacketConfigRate();
        [OperationContract]
        Int32 AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        [OperationContract]
        Int32 UpdateExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        [OperationContract]
        bool DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig);
        [OperationContract]
        ExchangePacketTypeConfig GetExchangePacketTypeConfig(ExchangePacketTypeConfig searchExchangePacketTypeConfig);
        [OperationContract]
        List<ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref DataPage dp);
        [OperationContract]
        Int32 AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        [OperationContract]
        Int32 UpdateExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        [OperationContract]
        bool DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig);
        [OperationContract]
        ExchangePacketConfig GetExchangePacketConfig(ExchangePacketConfig searchExchangePacketConfig);
        [OperationContract]
        List<ExchangePacketConfig> GetExchangePacketConfigList(ref DataPage dp);
        [OperationContract]
        Int32 UpdateBasicConfig(BasicConfig basicConfig);
        [OperationContract]
        List<BasicConfig> GetBasicConfigAll();
        [OperationContract]
        BasicConfig GetBasicConfig(BasicConfig searchBasicConfig);
        [OperationContract]
        Int32 importCSVtoDB(DataSet ds, string TableName);
        [OperationContract]
        Int32 AddDailyReportTotalPeople(DailyReportTotalPeople dailyReportTotalPeople);
        [OperationContract]
        List<DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref DataPage dp, DailyReportTotalPeople searchDailyReportTotalPeople);
        [OperationContract]
        List<DailyReportItemConsume> GetDailyReportItemConsumeAll();
        [OperationContract]
        List<DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll();
        [OperationContract]
        Int32 TransferDataAllReportDateConfigAdd(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        [OperationContract]

        bool TransferDataAllReportDateConfigDel(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        [OperationContract]

        TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        [OperationContract]

        List<TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref DataPage dp, TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        [OperationContract]

        Int32 TransferDataAllReportDateConfigUpdate(TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        [OperationContract]
        Int32 TransferDataGameDetailsItemConfigAdd(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        [OperationContract]

        bool TransferDataGameDetailsItemConfigDel(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        [OperationContract]

        TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        [OperationContract]

        List<TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref DataPage dp, TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        [OperationContract]

        Int32 TransferDataGameDetailsItemConfigUpdate(TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        [OperationContract]
        Int32 TransferDataGameDetailsUsersConfigAdd(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        [OperationContract]

        bool TransferDataGameDetailsUsersConfigDel(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        [OperationContract]

        TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        [OperationContract]

        List<TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref DataPage dp, TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        [OperationContract]

        Int32 TransferDataGameDetailsUsersConfigUpdate(TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        [OperationContract]
        Int32 TransferDataItemConsumeItemConfigAdd(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        [OperationContract]

        bool TransferDataItemConsumeItemConfigDel(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        [OperationContract]

        TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        [OperationContract]

        List<TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref DataPage dp, TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        [OperationContract]

        Int32 TransferDataItemConsumeItemConfigUpdate(TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        [OperationContract]
        List<RankList_TopN> GetRankListTopNList(ref DataPage dp, RankList_TopN searchRankListTopN);
        [OperationContract]
        int RefreshTopNList();
        [OperationContract]
        Int32 TransferDataGameDetailsUsersConfigBatchAdd(List<TransferData_GameDetails_UsersConfig> listuserconfig);

    }

}

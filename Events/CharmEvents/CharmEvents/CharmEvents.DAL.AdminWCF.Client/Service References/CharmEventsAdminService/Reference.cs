﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CharmEvents.DAL.AdminWCF.Client.CharmEventsAdminService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CharmEventsAdminService.ICharmEventsAdminService")]
    public interface ICharmEventsAdminService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetExchangeAndDrawLogList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetExchangeAndDrawLogListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.ExchangeAndDrawLog searchExchangeAndDrawLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetLoginPacketLogList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetLoginPacketLogListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.LoginPacketLog> GetLoginPacketLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.LoginPacketLog searchLoginPacketLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetPacketQueueLogList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetPacketQueueLogListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.PacketQueueLog> GetPacketQueueLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.PacketQueueLog searchPacketQueueLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetWalletsList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetWalletsListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.Wallets> GetWalletsList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.Wallets searchWallets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/AddWallets", ReplyAction="http://tempuri.org/ICharmEventsAdminService/AddWalletsResponse")]
        long AddWallets(CharmEvents.Database.Database.Wallets wallets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/AddDrawPacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/AddDrawPacketConfigResponse")]
        int AddDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/UpdateDrawPacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/UpdateDrawPacketConfigResponse")]
        int UpdateDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/DelDrawPacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/DelDrawPacketConfigResponse")]
        bool DelDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetDrawPacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetDrawPacketConfigResponse")]
        CharmEvents.Database.Database.DrawPacketConfig GetDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig searchDrawPacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetDrawPacketConfigList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetDrawPacketConfigListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.DrawPacketConfig> GetDrawPacketConfigList(ref CommonLibs.Common.DataPage dp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/SubmitDrawPacketConfigRate", ReplyAction="http://tempuri.org/ICharmEventsAdminService/SubmitDrawPacketConfigRateResponse")]
        int SubmitDrawPacketConfigRate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/AddExchangePacketTypeConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/AddExchangePacketTypeConfigResponse")]
        int AddExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/UpdateExchangePacketTypeConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/UpdateExchangePacketTypeConfigRespons" +
            "e")]
        int UpdateExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/DelExchangePacketTypeConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/DelExchangePacketTypeConfigResponse")]
        bool DelExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketTypeConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketTypeConfigResponse")]
        CharmEvents.Database.Database.ExchangePacketTypeConfig GetExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig searchExchangePacketTypeConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketTypeConfigList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketTypeConfigListRespon" +
            "se")]
        System.Collections.Generic.List<CharmEvents.Database.Database.ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref CommonLibs.Common.DataPage dp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/AddExchangePacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/AddExchangePacketConfigResponse")]
        int AddExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/UpdateExchangePacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/UpdateExchangePacketConfigResponse")]
        int UpdateExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/DelExchangePacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/DelExchangePacketConfigResponse")]
        bool DelExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketConfigResponse")]
        CharmEvents.Database.Database.ExchangePacketConfig GetExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig searchExchangePacketConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketConfigList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetExchangePacketConfigListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.ExchangePacketConfig> GetExchangePacketConfigList(ref CommonLibs.Common.DataPage dp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/UpdateBasicConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/UpdateBasicConfigResponse")]
        int UpdateBasicConfig(CharmEvents.Database.Database.BasicConfig basicConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetBasicConfigAll", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetBasicConfigAllResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.BasicConfig> GetBasicConfigAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetBasicConfig", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetBasicConfigResponse")]
        CharmEvents.Database.Database.BasicConfig GetBasicConfig(CharmEvents.Database.Database.BasicConfig searchBasicConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/importCSVtoDB", ReplyAction="http://tempuri.org/ICharmEventsAdminService/importCSVtoDBResponse")]
        int importCSVtoDB(System.Data.DataSet ds, string TableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/AddDailyReportTotalPeople", ReplyAction="http://tempuri.org/ICharmEventsAdminService/AddDailyReportTotalPeopleResponse")]
        int AddDailyReportTotalPeople(CharmEvents.Database.Database.DailyReportTotalPeople dailyReportTotalPeople);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetDailyReportTotalPeopleList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetDailyReportTotalPeopleListResponse" +
            "")]
        System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.DailyReportTotalPeople searchDailyReportTotalPeople);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetDailyReportItemConsumeAll", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetDailyReportItemConsumeAllResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportItemConsume> GetDailyReportItemConsumeAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetDailyReportGameDetailsPerUserAll", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetDailyReportGameDetailsPerUserAllRe" +
            "sponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigAdd", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigAddRes" +
            "ponse")]
        int TransferDataAllReportDateConfigAdd(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigDel", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigDelRes" +
            "ponse")]
        bool TransferDataAllReportDateConfigDel(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigGetByC" +
            "onfigId", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigGetByC" +
            "onfigIdResponse")]
        CharmEvents.Database.Database.TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigGetLis" +
            "t", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigGetLis" +
            "tResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigUpdate" +
            "", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataAllReportDateConfigUpdate" +
            "Response")]
        int TransferDataAllReportDateConfigUpdate(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigAdd", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigAddR" +
            "esponse")]
        int TransferDataGameDetailsItemConfigAdd(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigDel", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigDelR" +
            "esponse")]
        bool TransferDataGameDetailsItemConfigDel(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigGetB" +
            "yItemId", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigGetB" +
            "yItemIdResponse")]
        CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigGetL" +
            "ist", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigGetL" +
            "istResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigUpda" +
            "te", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsItemConfigUpda" +
            "teResponse")]
        int TransferDataGameDetailsItemConfigUpdate(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigAdd" +
            "", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigAdd" +
            "Response")]
        int TransferDataGameDetailsUsersConfigAdd(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigDel" +
            "", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigDel" +
            "Response")]
        bool TransferDataGameDetailsUsersConfigDel(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigGet" +
            "ById", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigGet" +
            "ByIdResponse")]
        CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigGet" +
            "List", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigGet" +
            "ListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigUpd" +
            "ate", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigUpd" +
            "ateResponse")]
        int TransferDataGameDetailsUsersConfigUpdate(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigAdd", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigAddR" +
            "esponse")]
        int TransferDataItemConsumeItemConfigAdd(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigDel", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigDelR" +
            "esponse")]
        bool TransferDataItemConsumeItemConfigDel(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigGetB" +
            "yItemId", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigGetB" +
            "yItemIdResponse")]
        CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigGetL" +
            "ist", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigGetL" +
            "istResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigUpda" +
            "te", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataItemConsumeItemConfigUpda" +
            "teResponse")]
        int TransferDataItemConsumeItemConfigUpdate(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/GetRankListTopNList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/GetRankListTopNListResponse")]
        System.Collections.Generic.List<CharmEvents.Database.Database.RankList_TopN> GetRankListTopNList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.RankList_TopN searchRankListTopN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/RefreshTopNList", ReplyAction="http://tempuri.org/ICharmEventsAdminService/RefreshTopNListResponse")]
        int RefreshTopNList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigBat" +
            "chAdd", ReplyAction="http://tempuri.org/ICharmEventsAdminService/TransferDataGameDetailsUsersConfigBat" +
            "chAddResponse")]
        int TransferDataGameDetailsUsersConfigBatchAdd(System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig> listuserconfig);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICharmEventsAdminServiceChannel : CharmEvents.DAL.AdminWCF.Client.CharmEventsAdminService.ICharmEventsAdminService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CharmEventsAdminServiceClient : System.ServiceModel.ClientBase<CharmEvents.DAL.AdminWCF.Client.CharmEventsAdminService.ICharmEventsAdminService>, CharmEvents.DAL.AdminWCF.Client.CharmEventsAdminService.ICharmEventsAdminService {
        
        public CharmEventsAdminServiceClient() {
        }
        
        public CharmEventsAdminServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CharmEventsAdminServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CharmEventsAdminServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CharmEventsAdminServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.ExchangeAndDrawLog searchExchangeAndDrawLog) {
            return base.Channel.GetExchangeAndDrawLogList(ref dp, searchExchangeAndDrawLog);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.LoginPacketLog> GetLoginPacketLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.LoginPacketLog searchLoginPacketLog) {
            return base.Channel.GetLoginPacketLogList(ref dp, searchLoginPacketLog);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.PacketQueueLog> GetPacketQueueLogList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.PacketQueueLog searchPacketQueueLog) {
            return base.Channel.GetPacketQueueLogList(ref dp, searchPacketQueueLog);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.Wallets> GetWalletsList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.Wallets searchWallets) {
            return base.Channel.GetWalletsList(ref dp, searchWallets);
        }
        
        public long AddWallets(CharmEvents.Database.Database.Wallets wallets) {
            return base.Channel.AddWallets(wallets);
        }
        
        public int AddDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig) {
            return base.Channel.AddDrawPacketConfig(drawPacketConfig);
        }
        
        public int UpdateDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig) {
            return base.Channel.UpdateDrawPacketConfig(drawPacketConfig);
        }
        
        public bool DelDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig drawPacketConfig) {
            return base.Channel.DelDrawPacketConfig(drawPacketConfig);
        }
        
        public CharmEvents.Database.Database.DrawPacketConfig GetDrawPacketConfig(CharmEvents.Database.Database.DrawPacketConfig searchDrawPacketConfig) {
            return base.Channel.GetDrawPacketConfig(searchDrawPacketConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.DrawPacketConfig> GetDrawPacketConfigList(ref CommonLibs.Common.DataPage dp) {
            return base.Channel.GetDrawPacketConfigList(ref dp);
        }
        
        public int SubmitDrawPacketConfigRate() {
            return base.Channel.SubmitDrawPacketConfigRate();
        }
        
        public int AddExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig) {
            return base.Channel.AddExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        
        public int UpdateExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig) {
            return base.Channel.UpdateExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        
        public bool DelExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig exchangePacketTypeConfig) {
            return base.Channel.DelExchangePacketTypeConfig(exchangePacketTypeConfig);
        }
        
        public CharmEvents.Database.Database.ExchangePacketTypeConfig GetExchangePacketTypeConfig(CharmEvents.Database.Database.ExchangePacketTypeConfig searchExchangePacketTypeConfig) {
            return base.Channel.GetExchangePacketTypeConfig(searchExchangePacketTypeConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref CommonLibs.Common.DataPage dp) {
            return base.Channel.GetExchangePacketTypeConfigList(ref dp);
        }
        
        public int AddExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig) {
            return base.Channel.AddExchangePacketConfig(exchangePacketConfig);
        }
        
        public int UpdateExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig) {
            return base.Channel.UpdateExchangePacketConfig(exchangePacketConfig);
        }
        
        public bool DelExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig exchangePacketConfig) {
            return base.Channel.DelExchangePacketConfig(exchangePacketConfig);
        }
        
        public CharmEvents.Database.Database.ExchangePacketConfig GetExchangePacketConfig(CharmEvents.Database.Database.ExchangePacketConfig searchExchangePacketConfig) {
            return base.Channel.GetExchangePacketConfig(searchExchangePacketConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.ExchangePacketConfig> GetExchangePacketConfigList(ref CommonLibs.Common.DataPage dp) {
            return base.Channel.GetExchangePacketConfigList(ref dp);
        }
        
        public int UpdateBasicConfig(CharmEvents.Database.Database.BasicConfig basicConfig) {
            return base.Channel.UpdateBasicConfig(basicConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.BasicConfig> GetBasicConfigAll() {
            return base.Channel.GetBasicConfigAll();
        }
        
        public CharmEvents.Database.Database.BasicConfig GetBasicConfig(CharmEvents.Database.Database.BasicConfig searchBasicConfig) {
            return base.Channel.GetBasicConfig(searchBasicConfig);
        }
        
        public int importCSVtoDB(System.Data.DataSet ds, string TableName) {
            return base.Channel.importCSVtoDB(ds, TableName);
        }
        
        public int AddDailyReportTotalPeople(CharmEvents.Database.Database.DailyReportTotalPeople dailyReportTotalPeople) {
            return base.Channel.AddDailyReportTotalPeople(dailyReportTotalPeople);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.DailyReportTotalPeople searchDailyReportTotalPeople) {
            return base.Channel.GetDailyReportTotalPeopleList(ref dp, searchDailyReportTotalPeople);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportItemConsume> GetDailyReportItemConsumeAll() {
            return base.Channel.GetDailyReportItemConsumeAll();
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll() {
            return base.Channel.GetDailyReportGameDetailsPerUserAll();
        }
        
        public int TransferDataAllReportDateConfigAdd(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig) {
            return base.Channel.TransferDataAllReportDateConfigAdd(searchTransferData_All_ReportDateConfig);
        }
        
        public bool TransferDataAllReportDateConfigDel(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig) {
            return base.Channel.TransferDataAllReportDateConfigDel(searchTransferData_All_ReportDateConfig);
        }
        
        public CharmEvents.Database.Database.TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig) {
            return base.Channel.TransferDataAllReportDateConfigGetByConfigId(searchTransferData_All_ReportDateConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig) {
            return base.Channel.TransferDataAllReportDateConfigGetList(ref dp, searchTransferData_All_ReportDateConfig);
        }
        
        public int TransferDataAllReportDateConfigUpdate(CharmEvents.Database.Database.TransferData_All_ReportDateConfig searchTransferData_All_ReportDateConfig) {
            return base.Channel.TransferDataAllReportDateConfigUpdate(searchTransferData_All_ReportDateConfig);
        }
        
        public int TransferDataGameDetailsItemConfigAdd(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig) {
            return base.Channel.TransferDataGameDetailsItemConfigAdd(searchTransferData_GameDetails_ItemConfig);
        }
        
        public bool TransferDataGameDetailsItemConfigDel(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig) {
            return base.Channel.TransferDataGameDetailsItemConfigDel(searchTransferData_GameDetails_ItemConfig);
        }
        
        public CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig) {
            return base.Channel.TransferDataGameDetailsItemConfigGetByItemId(searchTransferData_GameDetails_ItemConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig) {
            return base.Channel.TransferDataGameDetailsItemConfigGetList(ref dp, searchTransferData_GameDetails_ItemConfig);
        }
        
        public int TransferDataGameDetailsItemConfigUpdate(CharmEvents.Database.Database.TransferData_GameDetails_ItemConfig searchTransferData_GameDetails_ItemConfig) {
            return base.Channel.TransferDataGameDetailsItemConfigUpdate(searchTransferData_GameDetails_ItemConfig);
        }
        
        public int TransferDataGameDetailsUsersConfigAdd(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigAdd(searchTransferData_GameDetails_UsersConfig);
        }
        
        public bool TransferDataGameDetailsUsersConfigDel(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigDel(searchTransferData_GameDetails_UsersConfig);
        }
        
        public CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigGetById(searchTransferData_GameDetails_UsersConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigGetList(ref dp, searchTransferData_GameDetails_UsersConfig);
        }
        
        public int TransferDataGameDetailsUsersConfigUpdate(CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig searchTransferData_GameDetails_UsersConfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigUpdate(searchTransferData_GameDetails_UsersConfig);
        }
        
        public int TransferDataItemConsumeItemConfigAdd(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig) {
            return base.Channel.TransferDataItemConsumeItemConfigAdd(searchTransferData_ItemConsume_ItemConfig);
        }
        
        public bool TransferDataItemConsumeItemConfigDel(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig) {
            return base.Channel.TransferDataItemConsumeItemConfigDel(searchTransferData_ItemConsume_ItemConfig);
        }
        
        public CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig) {
            return base.Channel.TransferDataItemConsumeItemConfigGetByItemId(searchTransferData_ItemConsume_ItemConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig) {
            return base.Channel.TransferDataItemConsumeItemConfigGetList(ref dp, searchTransferData_ItemConsume_ItemConfig);
        }
        
        public int TransferDataItemConsumeItemConfigUpdate(CharmEvents.Database.Database.TransferData_ItemConsume_ItemConfig searchTransferData_ItemConsume_ItemConfig) {
            return base.Channel.TransferDataItemConsumeItemConfigUpdate(searchTransferData_ItemConsume_ItemConfig);
        }
        
        public System.Collections.Generic.List<CharmEvents.Database.Database.RankList_TopN> GetRankListTopNList(ref CommonLibs.Common.DataPage dp, CharmEvents.Database.Database.RankList_TopN searchRankListTopN) {
            return base.Channel.GetRankListTopNList(ref dp, searchRankListTopN);
        }
        
        public int RefreshTopNList() {
            return base.Channel.RefreshTopNList();
        }
        
        public int TransferDataGameDetailsUsersConfigBatchAdd(System.Collections.Generic.List<CharmEvents.Database.Database.TransferData_GameDetails_UsersConfig> listuserconfig) {
            return base.Channel.TransferDataGameDetailsUsersConfigBatchAdd(listuserconfig);
        }
    }
}
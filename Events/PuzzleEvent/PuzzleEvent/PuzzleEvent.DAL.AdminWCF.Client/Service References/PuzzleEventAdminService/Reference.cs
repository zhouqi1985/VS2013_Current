﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuzzleEvent.DAL.AdminWCF.Client.PuzzleEventAdminService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PuzzleEventAdminService.IPuzzleEventAdminService")]
    public interface IPuzzleEventAdminService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/AddWallet", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/AddWalletResponse")]
        long AddWallet(PuzzleEvent.Database.Database.Wallet wallet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetWalletList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetWalletListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.Wallet> GetWalletList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.Wallet searchWallet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdateExchangePacket", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdateExchangePacketResponse")]
        long UpdateExchangePacket(PuzzleEvent.Database.Database.ExchangePacket exchangePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacket", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacketResponse")]
        PuzzleEvent.Database.Database.ExchangePacket GetExchangePacket(PuzzleEvent.Database.Database.ExchangePacket searchExchangePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzle", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzleResponse")]
        int UpdatePuzzle(PuzzleEvent.Database.Database.Puzzle puzzle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzle", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleResponse")]
        PuzzleEvent.Database.Database.Puzzle GetPuzzle(PuzzleEvent.Database.Database.Puzzle searchPuzzle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzlePieces", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzlePiecesResponse")]
        int UpdatePuzzlePieces(PuzzleEvent.Database.Database.PuzzlePieces puzzlePieces);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePieces", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePiecesResponse")]
        PuzzleEvent.Database.Database.PuzzlePieces GetPuzzlePieces(PuzzleEvent.Database.Database.PuzzlePieces searchPuzzlePieces);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzlePacket", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzlePacketResponse")]
        int UpdatePuzzlePacket(PuzzleEvent.Database.Database.PuzzlePacket puzzlePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePacket", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePacketResponse")]
        PuzzleEvent.Database.Database.PuzzlePacket GetPuzzlePacket(PuzzleEvent.Database.Database.PuzzlePacket searchPuzzlePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzleRate", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdatePuzzleRateResponse")]
        int UpdatePuzzleRate(PuzzleEvent.Database.Database.PuzzleRate puzzleRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleRate", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleRateResponse")]
        PuzzleEvent.Database.Database.PuzzleRate GetPuzzleRate(PuzzleEvent.Database.Database.PuzzleRate searchPuzzleRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacketList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacketListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.ExchangePacket> GetExchangePacketList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.ExchangePacket searchExchangePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePiecesList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePiecesListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzlePieces> GetPuzzlePiecesList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzlePieces searchPuzzlePieces);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePacketList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzlePacketListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzlePacket> GetPuzzlePacketList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzlePacket searchPuzzlePacket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleRateList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleRateListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleRate> GetPuzzleRateList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleRate searchPuzzleRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.Puzzle> GetPuzzleList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.Puzzle searchPuzzle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetUserPuzzleNodeList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetUserPuzzleNodeListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.UserPuzzleNode> GetUserPuzzleNodeList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.UserPuzzleNode searchUserPuzzleNode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetUserPuzzleNode", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetUserPuzzleNodeResponse")]
        PuzzleEvent.Database.Database.UserPuzzleNode GetUserPuzzleNode(PuzzleEvent.Database.Database.UserPuzzleNode searchUserPuzzleNode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/UpdateUserPuzzleNode", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/UpdateUserPuzzleNodeResponse")]
        long UpdateUserPuzzleNode(PuzzleEvent.Database.Database.UserPuzzleNode userPuzzleNode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/SubmitPuzzleRate", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/SubmitPuzzleRateResponse")]
        int SubmitPuzzleRate(int PuzzleTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/SubmitPuzzlePacketRate", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/SubmitPuzzlePacketRateResponse")]
        int SubmitPuzzlePacketRate(int PuzzlePacketTypeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleReceiveDetailsList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleReceiveDetailsListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleReceiveDetails searchPuzzleReceiveDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetUserPiecesTotalList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetUserPiecesTotalListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.UserPiecesTotal> GetUserPiecesTotalList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.UserPiecesTotal searchUserPiecesTotal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleDrawDetailsList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPuzzleDrawDetailsListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleDrawDetails searchPuzzleDrawDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPacketQueueLogList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPacketQueueLogListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PacketQueueLog> GetPacketQueueLogList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PacketQueueLog searchPacketQueueLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetPiecesPacketDetailsList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetPiecesPacketDetailsListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.PiecesPacketDetails> GetPiecesPacketDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PiecesPacketDetails searchPiecesPacketDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacketReceiveList", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/GetExchangePacketReceiveListResponse")]
        System.Collections.Generic.List<PuzzleEvent.Database.Database.ExchangePacketReceive> GetExchangePacketReceiveList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.ExchangePacketReceive searchExchangePacketReceive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPuzzleEventAdminService/importCSVtoDB", ReplyAction="http://tempuri.org/IPuzzleEventAdminService/importCSVtoDBResponse")]
        int importCSVtoDB(System.Data.DataSet ds, string TableName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPuzzleEventAdminServiceChannel : PuzzleEvent.DAL.AdminWCF.Client.PuzzleEventAdminService.IPuzzleEventAdminService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PuzzleEventAdminServiceClient : System.ServiceModel.ClientBase<PuzzleEvent.DAL.AdminWCF.Client.PuzzleEventAdminService.IPuzzleEventAdminService>, PuzzleEvent.DAL.AdminWCF.Client.PuzzleEventAdminService.IPuzzleEventAdminService {
        
        public PuzzleEventAdminServiceClient() {
        }
        
        public PuzzleEventAdminServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PuzzleEventAdminServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PuzzleEventAdminServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PuzzleEventAdminServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public long AddWallet(PuzzleEvent.Database.Database.Wallet wallet) {
            return base.Channel.AddWallet(wallet);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.Wallet> GetWalletList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.Wallet searchWallet) {
            return base.Channel.GetWalletList(ref dp, searchWallet);
        }
        
        public long UpdateExchangePacket(PuzzleEvent.Database.Database.ExchangePacket exchangePacket) {
            return base.Channel.UpdateExchangePacket(exchangePacket);
        }
        
        public PuzzleEvent.Database.Database.ExchangePacket GetExchangePacket(PuzzleEvent.Database.Database.ExchangePacket searchExchangePacket) {
            return base.Channel.GetExchangePacket(searchExchangePacket);
        }
        
        public int UpdatePuzzle(PuzzleEvent.Database.Database.Puzzle puzzle) {
            return base.Channel.UpdatePuzzle(puzzle);
        }
        
        public PuzzleEvent.Database.Database.Puzzle GetPuzzle(PuzzleEvent.Database.Database.Puzzle searchPuzzle) {
            return base.Channel.GetPuzzle(searchPuzzle);
        }
        
        public int UpdatePuzzlePieces(PuzzleEvent.Database.Database.PuzzlePieces puzzlePieces) {
            return base.Channel.UpdatePuzzlePieces(puzzlePieces);
        }
        
        public PuzzleEvent.Database.Database.PuzzlePieces GetPuzzlePieces(PuzzleEvent.Database.Database.PuzzlePieces searchPuzzlePieces) {
            return base.Channel.GetPuzzlePieces(searchPuzzlePieces);
        }
        
        public int UpdatePuzzlePacket(PuzzleEvent.Database.Database.PuzzlePacket puzzlePacket) {
            return base.Channel.UpdatePuzzlePacket(puzzlePacket);
        }
        
        public PuzzleEvent.Database.Database.PuzzlePacket GetPuzzlePacket(PuzzleEvent.Database.Database.PuzzlePacket searchPuzzlePacket) {
            return base.Channel.GetPuzzlePacket(searchPuzzlePacket);
        }
        
        public int UpdatePuzzleRate(PuzzleEvent.Database.Database.PuzzleRate puzzleRate) {
            return base.Channel.UpdatePuzzleRate(puzzleRate);
        }
        
        public PuzzleEvent.Database.Database.PuzzleRate GetPuzzleRate(PuzzleEvent.Database.Database.PuzzleRate searchPuzzleRate) {
            return base.Channel.GetPuzzleRate(searchPuzzleRate);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.ExchangePacket> GetExchangePacketList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.ExchangePacket searchExchangePacket) {
            return base.Channel.GetExchangePacketList(ref dp, searchExchangePacket);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzlePieces> GetPuzzlePiecesList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzlePieces searchPuzzlePieces) {
            return base.Channel.GetPuzzlePiecesList(ref dp, searchPuzzlePieces);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzlePacket> GetPuzzlePacketList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzlePacket searchPuzzlePacket) {
            return base.Channel.GetPuzzlePacketList(ref dp, searchPuzzlePacket);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleRate> GetPuzzleRateList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleRate searchPuzzleRate) {
            return base.Channel.GetPuzzleRateList(ref dp, searchPuzzleRate);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.Puzzle> GetPuzzleList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.Puzzle searchPuzzle) {
            return base.Channel.GetPuzzleList(ref dp, searchPuzzle);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.UserPuzzleNode> GetUserPuzzleNodeList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.UserPuzzleNode searchUserPuzzleNode) {
            return base.Channel.GetUserPuzzleNodeList(ref dp, searchUserPuzzleNode);
        }
        
        public PuzzleEvent.Database.Database.UserPuzzleNode GetUserPuzzleNode(PuzzleEvent.Database.Database.UserPuzzleNode searchUserPuzzleNode) {
            return base.Channel.GetUserPuzzleNode(searchUserPuzzleNode);
        }
        
        public long UpdateUserPuzzleNode(PuzzleEvent.Database.Database.UserPuzzleNode userPuzzleNode) {
            return base.Channel.UpdateUserPuzzleNode(userPuzzleNode);
        }
        
        public int SubmitPuzzleRate(int PuzzleTypeId) {
            return base.Channel.SubmitPuzzleRate(PuzzleTypeId);
        }
        
        public int SubmitPuzzlePacketRate(int PuzzlePacketTypeID) {
            return base.Channel.SubmitPuzzlePacketRate(PuzzlePacketTypeID);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleReceiveDetails searchPuzzleReceiveDetails) {
            return base.Channel.GetPuzzleReceiveDetailsList(ref dp, searchPuzzleReceiveDetails);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.UserPiecesTotal> GetUserPiecesTotalList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.UserPiecesTotal searchUserPiecesTotal) {
            return base.Channel.GetUserPiecesTotalList(ref dp, searchUserPiecesTotal);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PuzzleDrawDetails searchPuzzleDrawDetails) {
            return base.Channel.GetPuzzleDrawDetailsList(ref dp, searchPuzzleDrawDetails);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PacketQueueLog> GetPacketQueueLogList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PacketQueueLog searchPacketQueueLog) {
            return base.Channel.GetPacketQueueLogList(ref dp, searchPacketQueueLog);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.PiecesPacketDetails> GetPiecesPacketDetailsList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.PiecesPacketDetails searchPiecesPacketDetails) {
            return base.Channel.GetPiecesPacketDetailsList(ref dp, searchPiecesPacketDetails);
        }
        
        public System.Collections.Generic.List<PuzzleEvent.Database.Database.ExchangePacketReceive> GetExchangePacketReceiveList(ref CommonLibs.Common.DataPage dp, PuzzleEvent.Database.Database.ExchangePacketReceive searchExchangePacketReceive) {
            return base.Channel.GetExchangePacketReceiveList(ref dp, searchExchangePacketReceive);
        }
        
        public int importCSVtoDB(System.Data.DataSet ds, string TableName) {
            return base.Channel.importCSVtoDB(ds, TableName);
        }
    }
}

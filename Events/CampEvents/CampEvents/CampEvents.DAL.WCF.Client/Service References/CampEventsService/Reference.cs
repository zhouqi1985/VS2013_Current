﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampEvents.DAL.WCF.Client.CampEventsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CampEventsService.ICampEventsService")]
    public interface ICampEventsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICampEventsService/UserChooseCamp", ReplyAction="http://tempuri.org/ICampEventsService/UserChooseCampResponse")]
        CampEvents.Database.Database.ResultInfo UserChooseCamp(CampEvents.Database.Database.UserInfo userinfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICampEventsService/GetRankListTop20", ReplyAction="http://tempuri.org/ICampEventsService/GetRankListTop20Response")]
        System.Collections.Generic.List<CampEvents.Database.Database.RankListTop20> GetRankListTop20(CampEvents.Database.Database.UserInfo userinfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICampEventsService/ExchangePointPacket", ReplyAction="http://tempuri.org/ICampEventsService/ExchangePointPacketResponse")]
        CampEvents.Database.Database.ResultInfo ExchangePointPacket(CampEvents.Database.Database.UserInfo userinfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICampEventsService/GetUserInfo", ReplyAction="http://tempuri.org/ICampEventsService/GetUserInfoResponse")]
        CampEvents.Database.Database.ResultInfo GetUserInfo(CampEvents.Database.Database.UserInfo userinfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICampEventsService/GetCampInfo", ReplyAction="http://tempuri.org/ICampEventsService/GetCampInfoResponse")]
        System.Collections.Generic.List<CampEvents.Database.Database.CampConfig> GetCampInfo();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICampEventsServiceChannel : CampEvents.DAL.WCF.Client.CampEventsService.ICampEventsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CampEventsServiceClient : System.ServiceModel.ClientBase<CampEvents.DAL.WCF.Client.CampEventsService.ICampEventsService>, CampEvents.DAL.WCF.Client.CampEventsService.ICampEventsService {
        
        public CampEventsServiceClient() {
        }
        
        public CampEventsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CampEventsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CampEventsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CampEventsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CampEvents.Database.Database.ResultInfo UserChooseCamp(CampEvents.Database.Database.UserInfo userinfo) {
            return base.Channel.UserChooseCamp(userinfo);
        }
        
        public System.Collections.Generic.List<CampEvents.Database.Database.RankListTop20> GetRankListTop20(CampEvents.Database.Database.UserInfo userinfo) {
            return base.Channel.GetRankListTop20(userinfo);
        }
        
        public CampEvents.Database.Database.ResultInfo ExchangePointPacket(CampEvents.Database.Database.UserInfo userinfo) {
            return base.Channel.ExchangePointPacket(userinfo);
        }
        
        public CampEvents.Database.Database.ResultInfo GetUserInfo(CampEvents.Database.Database.UserInfo userinfo) {
            return base.Channel.GetUserInfo(userinfo);
        }
        
        public System.Collections.Generic.List<CampEvents.Database.Database.CampConfig> GetCampInfo() {
            return base.Channel.GetCampInfo();
        }
    }
}

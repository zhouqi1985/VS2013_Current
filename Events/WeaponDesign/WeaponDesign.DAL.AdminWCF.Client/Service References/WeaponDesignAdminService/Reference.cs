﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeaponDesign.DAL.AdminWCF.Client.WeaponDesignAdminService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WeaponDesignAdminService.IWeaponDesignAdminService")]
    public interface IWeaponDesignAdminService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/GetWeaponList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/GetWeaponListResponse")]
        WeaponDesign.Database.Database.WeaponList GetWeaponList(WeaponDesign.Database.Database.WeaponList searchWeaponList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/GetWeaponAllUserList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/GetWeaponAllUserListResponse")]
        System.Collections.Generic.List<WeaponDesign.Database.Database.WeaponUserList> GetWeaponAllUserList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.WeaponUserList weaponuserlist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/UpdateWeaponStatus", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/UpdateWeaponStatusResponse")]
        int UpdateWeaponStatus(WeaponDesign.Database.Database.WeaponList weaponList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/AddPraiseLog", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/AddPraiseLogResponse")]
        int AddPraiseLog(WeaponDesign.Database.Database.PraiseLog praiseLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/GetPraiseLogList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/GetPraiseLogListResponse")]
        System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseLog> GetPraiseLogList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.PraiseLog searchPraiseLog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/GetCommentsListList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/GetCommentsListListResponse")]
        System.Collections.Generic.List<WeaponDesign.Database.Database.CommentsList> GetCommentsListList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.CommentsList searchCommentsList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/DelComment", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/DelCommentResponse")]
        int DelComment(int iD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/UpdatePraiseNumber", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/UpdatePraiseNumberResponse")]
        int UpdatePraiseNumber(WeaponDesign.Database.Database.PraiseNumber praiseNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/GetPraiseNumberList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/GetPraiseNumberListResponse")]
        System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseNumber> GetPraiseNumberList(ref CommonLibs.Common.DataPage dp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleAdd", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleAddResponse")]
        int PraiseScheduleAdd(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleDel", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleDelResponse")]
        bool PraiseScheduleDel(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleGetByID", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleGetByIDResponse")]
        WeaponDesign.Database.Database.PraiseSchedule PraiseScheduleGetByID(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleGetList", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleGetListResponse")]
        System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseSchedule> PraiseScheduleGetList(ref CommonLibs.Common.DataPage dp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleUpdate", ReplyAction="http://tempuri.org/IWeaponDesignAdminService/PraiseScheduleUpdateResponse")]
        int PraiseScheduleUpdate(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWeaponDesignAdminServiceChannel : WeaponDesign.DAL.AdminWCF.Client.WeaponDesignAdminService.IWeaponDesignAdminService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeaponDesignAdminServiceClient : System.ServiceModel.ClientBase<WeaponDesign.DAL.AdminWCF.Client.WeaponDesignAdminService.IWeaponDesignAdminService>, WeaponDesign.DAL.AdminWCF.Client.WeaponDesignAdminService.IWeaponDesignAdminService {
        
        public WeaponDesignAdminServiceClient() {
        }
        
        public WeaponDesignAdminServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeaponDesignAdminServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeaponDesignAdminServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeaponDesignAdminServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WeaponDesign.Database.Database.WeaponList GetWeaponList(WeaponDesign.Database.Database.WeaponList searchWeaponList) {
            return base.Channel.GetWeaponList(searchWeaponList);
        }
        
        public System.Collections.Generic.List<WeaponDesign.Database.Database.WeaponUserList> GetWeaponAllUserList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.WeaponUserList weaponuserlist) {
            return base.Channel.GetWeaponAllUserList(ref dp, weaponuserlist);
        }
        
        public int UpdateWeaponStatus(WeaponDesign.Database.Database.WeaponList weaponList) {
            return base.Channel.UpdateWeaponStatus(weaponList);
        }
        
        public int AddPraiseLog(WeaponDesign.Database.Database.PraiseLog praiseLog) {
            return base.Channel.AddPraiseLog(praiseLog);
        }
        
        public System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseLog> GetPraiseLogList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.PraiseLog searchPraiseLog) {
            return base.Channel.GetPraiseLogList(ref dp, searchPraiseLog);
        }
        
        public System.Collections.Generic.List<WeaponDesign.Database.Database.CommentsList> GetCommentsListList(ref CommonLibs.Common.DataPage dp, WeaponDesign.Database.Database.CommentsList searchCommentsList) {
            return base.Channel.GetCommentsListList(ref dp, searchCommentsList);
        }
        
        public int DelComment(int iD) {
            return base.Channel.DelComment(iD);
        }
        
        public int UpdatePraiseNumber(WeaponDesign.Database.Database.PraiseNumber praiseNumber) {
            return base.Channel.UpdatePraiseNumber(praiseNumber);
        }
        
        public System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseNumber> GetPraiseNumberList(ref CommonLibs.Common.DataPage dp) {
            return base.Channel.GetPraiseNumberList(ref dp);
        }
        
        public int PraiseScheduleAdd(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule) {
            return base.Channel.PraiseScheduleAdd(searchPraiseSchedule);
        }
        
        public bool PraiseScheduleDel(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule) {
            return base.Channel.PraiseScheduleDel(searchPraiseSchedule);
        }
        
        public WeaponDesign.Database.Database.PraiseSchedule PraiseScheduleGetByID(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule) {
            return base.Channel.PraiseScheduleGetByID(searchPraiseSchedule);
        }
        
        public System.Collections.Generic.List<WeaponDesign.Database.Database.PraiseSchedule> PraiseScheduleGetList(ref CommonLibs.Common.DataPage dp) {
            return base.Channel.PraiseScheduleGetList(ref dp);
        }
        
        public int PraiseScheduleUpdate(WeaponDesign.Database.Database.PraiseSchedule searchPraiseSchedule) {
            return base.Channel.PraiseScheduleUpdate(searchPraiseSchedule);
        }
    }
}

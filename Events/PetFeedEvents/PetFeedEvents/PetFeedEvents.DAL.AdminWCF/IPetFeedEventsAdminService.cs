using CommonLibs.Common;
using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PetFeedEvents.DAL.AdminWCF
{
    [ServiceContract]
    public interface IPetFeedEventsAdminService
    {
        [OperationContract]
        int CleanAllData();
        [OperationContract]
        List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog);
        [OperationContract]
        List<DynamicPacketQueue> GetDynamicPacketQueueList(ref DataPage dp, DynamicPacketQueue searchDynamicPacketQueue);
        [OperationContract]
        int InsertGameDailyLog(GameDailyLog gamedailylog);
        [OperationContract]
        List<DynamicPacketQueueLog> GetDynamicPacketQueueLogList(ref DataPage dp, DynamicPacketQueueLog searchDynamicPacketQueueLog);
        [OperationContract]
        List<TaskConfig> GetTaskConfig(ref DataPage dp);
        [OperationContract]
        int InsertTaskConfig(TaskConfig taskconfig);
        [OperationContract]
        int UpdateTaskConfig(TaskConfig taskconfig);
        [OperationContract]
        int DeleteTaskConfig(TaskConfig taskconfig);
    }

}

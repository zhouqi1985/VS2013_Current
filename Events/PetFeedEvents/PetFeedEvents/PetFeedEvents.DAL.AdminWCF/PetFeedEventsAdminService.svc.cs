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
    public class PetFeedEventsAdminService : IPetFeedEventsAdminService
    {
        private PetFeedEvents.DAL.Admin.IPetFeedEventsAdmin _dal = new PetFeedEvents.DAL.Admin.PetFeedEventsAdmin();
        public int CleanAllData()
        {
            return _dal.CleanAllData();
        }
        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {
            return _dal.GetGameDailyLogList(ref  dp, searchGameDailyLog);
        }

        public List<DynamicPacketQueue> GetDynamicPacketQueueList(ref DataPage dp, DynamicPacketQueue searchDynamicPacketQueue)
        {
            return _dal.GetDynamicPacketQueueList(ref  dp, searchDynamicPacketQueue);
        }

        public int InsertGameDailyLog(GameDailyLog gamedailylog)
        {
            return _dal.InsertGameDailyLog(gamedailylog);
        }

        public List<DynamicPacketQueueLog> GetDynamicPacketQueueLogList(ref DataPage dp, DynamicPacketQueueLog searchDynamicPacketQueueLog)
        {
            return _dal.GetDynamicPacketQueueLogList(ref  dp, searchDynamicPacketQueueLog);
        }

        public List<TaskConfig> GetTaskConfig(ref DataPage dp)
        {
            return _dal.GetTaskConfig(ref  dp);
        }

        public int InsertTaskConfig(TaskConfig taskconfig)
        {
            return _dal.InsertTaskConfig(taskconfig);
        }

        public int UpdateTaskConfig(TaskConfig taskconfig)
        {
            return _dal.UpdateTaskConfig(taskconfig);
        }

        public int DeleteTaskConfig(TaskConfig taskconfig)
        {
            return _dal.DeleteTaskConfig(taskconfig);
        }
    }
}

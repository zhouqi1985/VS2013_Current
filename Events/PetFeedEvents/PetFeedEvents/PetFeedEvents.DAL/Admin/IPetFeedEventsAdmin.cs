using CommonLibs.Common;
using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetFeedEvents.DAL.Admin
{
    public interface IPetFeedEventsAdmin
    {
        int CleanAllData();
        List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog);
        List<DynamicPacketQueue> GetDynamicPacketQueueList(ref DataPage dp, DynamicPacketQueue searchDynamicPacketQueue);
        int InsertGameDailyLog(GameDailyLog gamedailylog);
        List<DynamicPacketQueueLog> GetDynamicPacketQueueLogList(ref DataPage dp, DynamicPacketQueueLog searchDynamicPacketQueueLog);
        List<TaskConfig> GetTaskConfig(ref DataPage dp);
        int InsertTaskConfig(TaskConfig taskconfig);
        int UpdateTaskConfig(TaskConfig taskconfig);
        int DeleteTaskConfig(TaskConfig taskconfig);
    }
}

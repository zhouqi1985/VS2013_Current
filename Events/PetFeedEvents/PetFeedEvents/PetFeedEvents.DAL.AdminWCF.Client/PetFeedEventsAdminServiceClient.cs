using CommonLibs.Common;
using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;

namespace PetFeedEvents.DAL.AdminWCF.Client
{
    public class PetFeedEventsAdminServiceClient : IPetFeedEventsAdminServiceClient
    {
        private PetFeedEventsAdminService.PetFeedEventsAdminServiceClient _admin;
        public int CleanAllData()
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            int rs = 0;
            try
            {
                rs = _admin.CleanAllData();
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "CleanAllData Failed");
                return 0;
            }
        
        }
        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {          
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            List<GameDailyLog> lists = new List<GameDailyLog>();
            try
            {
                lists = _admin.GetGameDailyLogList(ref dp, searchGameDailyLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetGameDailyLogList Failed");
                return lists;
            }
        }

        public List<DynamicPacketQueue> GetDynamicPacketQueueList(ref DataPage dp, DynamicPacketQueue searchDynamicPacketQueue)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            List<DynamicPacketQueue> lists = new List<DynamicPacketQueue>();
            try
            {
                lists = _admin.GetDynamicPacketQueueList(ref dp, searchDynamicPacketQueue);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetDynamicPacketQueueList Failed");
                return lists;
            }
        }

        public int InsertGameDailyLog(GameDailyLog gamedailylog)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            int rs = 0;
            try
            {
                rs = _admin.InsertGameDailyLog(gamedailylog);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertGameDailyLog Failed");
                return 0;
            }
        }

        public List<DynamicPacketQueueLog> GetDynamicPacketQueueLogList(ref DataPage dp, DynamicPacketQueueLog searchDynamicPacketQueueLog)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            List<DynamicPacketQueueLog> lists = new List<DynamicPacketQueueLog>();
            try
            {
                lists = _admin.GetDynamicPacketQueueLogList(ref dp, searchDynamicPacketQueueLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetDynamicPacketQueueLogList Failed");
                return lists;
            }
        }

        public List<TaskConfig> GetTaskConfig(ref DataPage dp)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            List<TaskConfig> lists = new List<TaskConfig>();
            try
            {
                lists = _admin.GetTaskConfig(ref dp);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetTaskConfig Failed");
                return lists;
            }
        }

        public int InsertTaskConfig(TaskConfig taskconfig)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            int rs = 0;
            try
            {
                rs = _admin.InsertTaskConfig(taskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "InsertTaskConfig Failed");
                return 0;
            }
        }

        public int UpdateTaskConfig(TaskConfig taskconfig)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            int rs = 0;
            try
            {
                rs = _admin.UpdateTaskConfig(taskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdateTaskConfig Failed");
                return 0;
            }
        }

        public int DeleteTaskConfig(TaskConfig taskconfig)
        {
            _admin = new PetFeedEventsAdminService.PetFeedEventsAdminServiceClient();
            int rs = 0;
            try
            {
                rs = _admin.DeleteTaskConfig(taskconfig);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "DeleteTaskConfig Failed");
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibs.Common;
using PetFeedEvents.Database.Database;
using System.Linq.Expressions;
using DataTableOperator;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace PetFeedEvents.DAL.Admin
{
    public class PetFeedEventsAdmin : IPetFeedEventsAdmin
    {
        private PetFeedEvents.Database.Context.PetFeedEventsContext ptx = new Database.Context.PetFeedEventsContext();

        public int CleanAllData()
        {
            int rs = 0;
            ptx.DynamicPacketQueue.RemoveRange(ptx.DynamicPacketQueue);
            ptx.DynamicPacketQueueLog.RemoveRange(ptx.DynamicPacketQueueLog);
            ptx.GameDailyLog.RemoveRange(ptx.GameDailyLog);
            ptx.GameDailyLogHistory.RemoveRange(ptx.GameDailyLogHistory);
            rs=ptx.SaveChanges();
            return rs;
        }

        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {
            Expression<Func<GameDailyLog, bool>> exp = EntityQueryOperator.CreateDydaminWhereAndExpression<GameDailyLog>(searchGameDailyLog);
            List<GameDailyLog> resultlist = ptx.GetEntityQueryList(ref dp, exp, p => p.RecordId);
            return resultlist;
        }

        public List<DynamicPacketQueue> GetDynamicPacketQueueList(ref DataPage dp, DynamicPacketQueue searchDynamicPacketQueue)
        {
            Expression<Func<DynamicPacketQueue, bool>> exp = EntityQueryOperator.CreateDydaminWhereAndExpression<DynamicPacketQueue>(searchDynamicPacketQueue);
            List<DynamicPacketQueue> resultlist = ptx.GetEntityQueryList(ref dp, exp, p => p.Id);
            return resultlist;
        }

        public int InsertGameDailyLog(GameDailyLog gamedailylog)
        {
            int rs = 0;
            TaskConfig config = ptx.TaskConfig.Where(p => p.TaskConfigId == gamedailylog.TaskConfigId).Single();
            DynamicPacketQueue packetqueue = new DynamicPacketQueue() { UserId=gamedailylog.UserId,AvatarId=gamedailylog.AvatarId,Sex=gamedailylog.Sex,GUID=gamedailylog.GUID,Site=gamedailylog.AreaId,Source=gamedailylog.Source,PacketId=config.PacketId,ItemCode=config.ItemCode,PacketItemTime=config.ItemTimePerTask,PacketItemCount=config.ItemCountPerTask*gamedailylog.ActualNum,Gold=config.GoldPerTask,BindCash=config.BindCashPerTask};
            ptx.GameDailyLog.Add(gamedailylog);
            ptx.DynamicPacketQueue.Add(packetqueue);
            rs=ptx.SaveChanges();
            return rs;
        }

        public List<DynamicPacketQueueLog> GetDynamicPacketQueueLogList(ref DataPage dp, DynamicPacketQueueLog searchDynamicPacketQueueLog)
        {
            Expression<Func<DynamicPacketQueueLog, bool>> exp = EntityQueryOperator.CreateDydaminWhereAndExpression<DynamicPacketQueueLog>(searchDynamicPacketQueueLog);
            List<DynamicPacketQueueLog> resultlist = ptx.GetEntityQueryList(ref dp, exp, p => p.LogId);
            return resultlist;
        }

        public List<TaskConfig> GetTaskConfig(ref DataPage dp)
        {
            Expression<Func<TaskConfig, bool>> exp = PredicateExtensionses.True<TaskConfig>();
            List<TaskConfig> resultlist2 = ptx.GetEntityQueryList(ref dp, exp, p => p.TaskConfigId);
            return resultlist2;
        }

        public int InsertTaskConfig(TaskConfig taskconfig)
        {
            int rs = 0;
            ptx.TaskConfig.Add(taskconfig);
            rs = ptx.SaveChanges();
            return rs;
        }

        public int UpdateTaskConfig(TaskConfig taskconfig)
        {
            int rs = 0;
            DbEntityEntry<TaskConfig> taskentry = ptx.Entry(taskconfig);
            taskentry.State = EntityState.Modified;
            rs = ptx.SaveChanges();
            return rs;
        }

        public int DeleteTaskConfig(TaskConfig taskconfig)
        {
            int rs = 0;
            TaskConfig taskentry = ptx.TaskConfig.Find(taskconfig.TaskConfigId);
            if (taskentry == null)
                return rs;
            ptx.TaskConfig.Remove(taskentry);
            rs = ptx.SaveChanges();
            return rs;
        }
    }
}

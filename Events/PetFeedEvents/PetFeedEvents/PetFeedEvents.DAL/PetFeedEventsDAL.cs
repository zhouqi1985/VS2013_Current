using AutoMapper;
using PetFeedEvents.Database.Context;
using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Transactions;


namespace PetFeedEvents.DAL
{
    public class PetFeedEventsDAL : IPetFeedEventsDAL
    {
        protected PetFeedEventsContext petctx = new PetFeedEventsContext();
        protected CEQDynamicCouponContext ceqctx = new CEQDynamicCouponContext();
        protected EventSrcContext srcctx = new EventSrcContext();

        public List<int> GameLogTransfer(DateTime? RecordDate)
        {
            List<int> rs = new List<int>() { 0,0,0};
            DateTime Yesterday = DateTime.Parse(System.DateTime.Now.ToShortDateString()).AddDays(-1);
            DateTime StartTime = RecordDate ?? Yesterday;
            IEnumerable<TaskConfig> tasklist = petctx.TaskConfig.AsEnumerable();
            IEnumerable<PetFeedEvents_DailyLog> gamelogsquery = srcctx.PetFeedEvents_DailyLog.Where(p => p.RecordDate == StartTime).AsEnumerable();
            var currenteventlogs = petctx.GameDailyLog.Where(p => p.RecordDate == StartTime).GroupBy(p => new { p.AreaId, p.AvatarId, p.UserId, p.RecordDate,p.TaskConfigId }).Select(p => new  { UserId = p.Key.UserId, AreaId = p.Key.AreaId, AvatarId = p.Key.AvatarId, RecordDate = p.Key.RecordDate,TaskConfigId=p.Key.TaskConfigId, ActualNum = p.Sum(s => s.ActualNum) }).AsEnumerable();
            IEnumerable<GameDailyLog> finallogs2 = gamelogsquery.GroupJoin(currenteventlogs, p => new { p.AreaId, p.AvatarId, p.UserId, p.RecordDate, p.TaskConfigId }, t => new { t.AreaId, t.AvatarId, t.UserId, t.RecordDate, t.TaskConfigId }, (p, t) => new GameDailyLog { UserId = p.UserId, AvatarId = p.AvatarId, AreaId = p.AreaId, RecordDate = p.RecordDate, AvatarName = p.AvatarName, Sex = p.Sex, TaskConfigId = p.TaskConfigId, FinalGetNum = p.DailyTotal, ActualNum = p.DailyTotal - t.Select(q => q.ActualNum).SingleOrDefault(), GUID = Guid.NewGuid(), Source = "Event_Src_DailyLog" }).Where(f => f.ActualNum > 0).AsEnumerable();
            IEnumerable<DynamicPacketQueue> dailylogs = finallogs2.Join(tasklist, p => p.TaskConfigId, t => t.TaskConfigId, (p, t) => new DynamicPacketQueue { UserId = p.UserId, Site = p.AreaId, AvatarId = p.AvatarId, PacketId = t.PacketId, Sex = p.Sex, Source = t.Source, BindCash = t.BindCashPerTask, Gold = t.GoldPerTask, ItemCode = t.ItemCode, PacketItemTime = t.ItemTimePerTask, PacketItemCount = p.ActualNum * t.ItemCountPerTask, GUID = p.GUID }).AsEnumerable<DynamicPacketQueue>();
            rs[1] = finallogs2.Count();
            petctx.GameDailyLog.AddRange(finallogs2);
            petctx.DynamicPacketQueue.AddRange(dailylogs);
            rs[0] = petctx.SaveChanges();
            return rs;
        }

        public int SendDynamicCouponQueue()
        {
            int rs = 0;
            IEnumerable<DynamicPacketQueue> petdynamicqueues = petctx.DynamicPacketQueue.AsEnumerable<DynamicPacketQueue>();

            Mapper.CreateMap<DynamicPacketQueue, CEQ_DynamicCouponQueue>();
            Mapper.CreateMap<DynamicPacketQueue, CEQ_DynamicCouponQueue>().ForMember(d => d.CreateTs, opt => opt.MapFrom(s => s.CreateTime));
            IEnumerable<CEQ_DynamicCouponQueue> ceqqueues = Mapper.Map<IEnumerable<DynamicPacketQueue>, IEnumerable<CEQ_DynamicCouponQueue>>(petdynamicqueues).AsEnumerable();
            Mapper.CreateMap<DynamicPacketQueue, DynamicPacketQueueLog>();
            IEnumerable<DynamicPacketQueueLog> petdynamiclogs = Mapper.Map<IEnumerable<DynamicPacketQueue>, IEnumerable<DynamicPacketQueueLog>>(petdynamicqueues).AsEnumerable();

            using (TransactionScope ts = new TransactionScope())
            {
                ceqctx.CEQ_DynamicCouponQueue.AddRange(ceqqueues);
                rs = ceqctx.SaveChanges();
                if (rs == ceqqueues.Count())
                {
                    int rs1 = 0;
                    petctx.DynamicPacketQueueLog.AddRange(petdynamiclogs);
                    petctx.DynamicPacketQueue.RemoveRange(petdynamicqueues);
                    rs1 = petctx.SaveChanges();
                    if (rs1 == (rs * 2))
                    {
                        ts.Complete();
                        return rs;
                    }
                }
                ts.Dispose();
                return 0;

            }


        }
    }
}

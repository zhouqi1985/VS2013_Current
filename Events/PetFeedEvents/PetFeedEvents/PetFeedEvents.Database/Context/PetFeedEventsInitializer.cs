using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Context
{
    public class PetFeedEventsInitializer : CreateDatabaseIfNotExists<PetFeedEventsContext>
    {
        protected override void Seed(PetFeedEventsContext context)
        {
            List<TaskConfig> TaskList = new List<TaskConfig>
            { 
                new TaskConfig{ TaskConfigId = 1, TaskName = "使用100点券升级一次机友", TaskDesc = "获得2个能量棒",ItemCode="86001",PacketId=1,ItemTimePerTask=-1,ItemCountPerTask=2,Source="Event_Src_DailyLog",GoldPerTask=0,BindCashPerTask=0},
 
            };


            TaskList.ForEach(s => context.TaskConfig.Add(s));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

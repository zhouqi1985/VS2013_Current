namespace PetFeedEvents.Database.Migrations
{
    using PetFeedEvents.Database.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetFeedEvents.Database.Context.PetFeedEventsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PetFeedEvents.Database.Context.PetFeedEventsContext context)
        {
            List<TaskConfig> TaskList = new List<TaskConfig>
            { 
                new TaskConfig{ TaskConfigId = 1, TaskName = "ʹ��100��ȯ����һ�λ���", TaskDesc = "���2��������",ItemCode="86001",PacketId=1,ItemTimePerTask=-1,ItemCountPerTask=2,Source="Event_Src_DailyLog",GoldPerTask=0,BindCashPerTask=0},
 
            };


            TaskList.ForEach(s => context.TaskConfig.Add(s));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

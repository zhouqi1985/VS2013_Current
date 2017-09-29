namespace CampEvents.Database.Migrations
{
    using CampEvents.Database.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CampEvents.Database.Context.CampEventsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CampEvents.Database.Context.CampEventsContext context)
        {
            List<BasicConfig> BasicList = new List<BasicConfig>
            {
                new BasicConfig{BasicId=1,ConfigName="��Ӫ�����������",ConfigValue=5},
                new BasicConfig{BasicId=2,ConfigName="��Ӫ����������ʼֵ",ConfigValue=100}, 
                new BasicConfig{BasicId=3,ConfigName="��ʤ���",ConfigValue=0}, 
                new BasicConfig{BasicId=4,ConfigName="�������",ConfigValue=0}
            };

            List<GameAreaConfig> AreaList = new List<GameAreaConfig>
            {
                new GameAreaConfig { AreaId = 0, AreaName = "����һ��������" },
                new GameAreaConfig { AreaId = 1, AreaName = "��ͨһ��" }

            };

            List<CampConfig> Camplist = new List<CampConfig> 
            {
                new CampConfig{ CampId = 1, CampName = "������Ӫ", CurrentPeople = 0, CurrentPoints = 0 },
                new CampConfig{ CampId = 2, CampName = "������Ӫ", CurrentPeople = 0, CurrentPoints = 0 }
            };

            List<DailyTaskConfig> TaskList = new List<DailyTaskConfig>
            { 
                new DailyTaskConfig{ TaskConfigId = 1, TaskName = "�״ε�¼�ҳ", GetPoints = 20, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1 , TaskDesc = "��1�Σ���ʱ���"},
                new DailyTaskConfig{ TaskConfigId = 2, TaskName = "ͨ��PVE�����ͼ�����Ѽ������Ѷ�һ��", GetPoints = 10, MaxLimit = 8, WeekendDouble = true, NumPerTime = 1, TaskDesc = "ÿ�����ɲ���˴�" },
                new DailyTaskConfig{ TaskConfigId = 3, TaskName = "PVPƥ��ģʽÿɱ��10��", GetPoints = 10, MaxLimit = 8, WeekendDouble = true, NumPerTime = 10 , TaskDesc = "ÿ�����ɲ����ĴΣ�ÿ���������տɵ�˫������"},
                new DailyTaskConfig{ TaskConfigId = 4, TaskName = "ÿ�ս������Ӿ���", GetPoints = 10, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1 , TaskDesc = "ÿ������1��"},
                new DailyTaskConfig{ TaskConfigId = 5, TaskName = "ÿ��ֵ1000��ȯ", GetPoints = 10, MaxLimit = 0, WeekendDouble = false, NumPerTime = 1000 , TaskDesc = "����"},
                new DailyTaskConfig{ TaskConfigId = 6, TaskName = "ÿ�յ�¼��Ϸ", GetPoints = 10, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1, TaskDesc = "ÿ������1��" }
            
            };

            //List<PointPacketConfig> PacketList = new List<PointPacketConfig>
            //{
            //new PointPacketConfig{ConfigContent="10%���",PacketId=1,PacketName="10%���",NeedPoints=1,ShowId=1,CampId=1,IsNotice=false},
            //new PointPacketConfig{ConfigContent="20%���",PacketId=2,PacketName="20%���",NeedPoints=2,ShowId=2,CampId=1,IsNotice=true},
            //new PointPacketConfig{ConfigContent="10%���",PacketId=3,PacketName="10%���",NeedPoints=1,ShowId=1,CampId=2,IsNotice=false},
            //new PointPacketConfig{ConfigContent="20%���",PacketId=4,PacketName="20%���",NeedPoints=2,ShowId=2,CampId=2,IsNotice=true}
            //};


            BasicList.ForEach(s => context.BasicConfigs.Add(s));
            AreaList.ForEach(s => context.GameAreaConfigs.Add(s));
            Camplist.ForEach(s => context.CampConfigs.Add(s));
            TaskList.ForEach(s => context.DailyTaskConfigs.Add(s));
            //PacketList.ForEach(s => context.PointPacketConfigs.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

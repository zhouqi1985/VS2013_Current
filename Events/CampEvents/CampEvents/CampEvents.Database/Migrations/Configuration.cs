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
                new BasicConfig{BasicId=1,ConfigName="阵营相差人数上限",ConfigValue=5},
                new BasicConfig{BasicId=2,ConfigName="阵营人数调整起始值",ConfigValue=100}, 
                new BasicConfig{BasicId=3,ConfigName="获胜礼包",ConfigValue=0}, 
                new BasicConfig{BasicId=4,ConfigName="参与礼包",ConfigValue=0}
            };

            List<GameAreaConfig> AreaList = new List<GameAreaConfig>
            {
                new GameAreaConfig { AreaId = 0, AreaName = "电信一区、二区" },
                new GameAreaConfig { AreaId = 1, AreaName = "网通一区" }

            };

            List<CampConfig> Camplist = new List<CampConfig> 
            {
                new CampConfig{ CampId = 1, CampName = "暴力阵营", CurrentPeople = 0, CurrentPoints = 0 },
                new CampConfig{ CampId = 2, CampName = "混乱阵营", CurrentPeople = 0, CurrentPoints = 0 }
            };

            List<DailyTaskConfig> TaskList = new List<DailyTaskConfig>
            { 
                new DailyTaskConfig{ TaskConfigId = 1, TaskName = "首次登录活动页", GetPoints = 20, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1 , TaskDesc = "限1次，即时获得"},
                new DailyTaskConfig{ TaskConfigId = 2, TaskName = "通关PVE任意地图，困难及以上难度一次", GetPoints = 10, MaxLimit = 8, WeekendDouble = true, NumPerTime = 1, TaskDesc = "每日最多可参与八次" },
                new DailyTaskConfig{ TaskConfigId = 3, TaskName = "PVP匹配模式每杀敌10人", GetPoints = 10, MaxLimit = 8, WeekendDouble = true, NumPerTime = 10 , TaskDesc = "每日最多可参与四次，每周六、周日可得双倍积分"},
                new DailyTaskConfig{ TaskConfigId = 4, TaskName = "每日进入量子竞技", GetPoints = 10, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1 , TaskDesc = "每日上限1次"},
                new DailyTaskConfig{ TaskConfigId = 5, TaskName = "每充值1000点券", GetPoints = 10, MaxLimit = 0, WeekendDouble = false, NumPerTime = 1000 , TaskDesc = "不限"},
                new DailyTaskConfig{ TaskConfigId = 6, TaskName = "每日登录游戏", GetPoints = 10, MaxLimit = 1, WeekendDouble = false, NumPerTime = 1, TaskDesc = "每日上限1次" }
            
            };

            //List<PointPacketConfig> PacketList = new List<PointPacketConfig>
            //{
            //new PointPacketConfig{ConfigContent="10%礼包",PacketId=1,PacketName="10%礼包",NeedPoints=1,ShowId=1,CampId=1,IsNotice=false},
            //new PointPacketConfig{ConfigContent="20%礼包",PacketId=2,PacketName="20%礼包",NeedPoints=2,ShowId=2,CampId=1,IsNotice=true},
            //new PointPacketConfig{ConfigContent="10%礼包",PacketId=3,PacketName="10%礼包",NeedPoints=1,ShowId=1,CampId=2,IsNotice=false},
            //new PointPacketConfig{ConfigContent="20%礼包",PacketId=4,PacketName="20%礼包",NeedPoints=2,ShowId=2,CampId=2,IsNotice=true}
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

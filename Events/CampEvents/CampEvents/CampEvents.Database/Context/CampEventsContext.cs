using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CampEvents.Database.Database;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CampEvents.Database.Context
{
    public class CampEventsContext:DbContext
    {
        public CampEventsContext()
            : base("CampEventsDB")
        {
            //System.Data.Entity.Database.SetInitializer<CampEventsContext>(new CreateDatabaseIfNotExists<CampEventsContext>());
        }

        public DbSet<BasicConfig> BasicConfigs { get; set; }
        public DbSet<CampConfig> CampConfigs { get; set; }
        public DbSet<DailyTaskConfig> DailyTaskConfigs { get; set; }
        public DbSet<GameAreaConfig> GameAreaConfigs { get; set; }
        public DbSet<GameDailyLog> GameDailyLogs { get; set; }
        public DbSet<GameDailyLogHistory> GameDailyLogHistories { get; set; }
        public DbSet<PacketQueue> PacketQueues { get; set; }
        public DbSet<PacketQueueLog> PacketQueueLogs { get; set; }
        public DbSet<PointPacketConfig> PointPacketConfigs { get; set; }
        public DbSet<PointPacketExchangeLog> PointPacketExchangeLogs { get; set; }
        public DbSet<RankListTop20> RankListTop20s { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<UserCampLog> UserCampLogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<CampEventsContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
  
            modelBuilder.Entity<PointPacketExchangeLog>().HasOptional(u => u.PacketQueue).WithOptionalPrincipal();
            modelBuilder.Entity<UserCampLog>().HasOptional(u => u.Wallet).WithOptionalPrincipal();
             
        }
    }
}

using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Context
{
    public class PetFeedEventsContext : BaseContext
    {
        public PetFeedEventsContext()
            : base("PetFeedEventsDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<DynamicPacketQueue> DynamicPacketQueue { get; set; }
        public DbSet<DynamicPacketQueueLog> DynamicPacketQueueLog { get; set; }
        public DbSet<GameDailyLog> GameDailyLog { get; set; }
        public DbSet<GameDailyLogHistory> GameDailyLogHistory { get; set; }
        public DbSet<TaskConfig> TaskConfig { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<PetFeedEventsContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

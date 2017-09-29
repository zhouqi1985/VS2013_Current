using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Context
{
    public class EventSrcContext : BaseContext
    {
        public EventSrcContext()
            : base("Event_Src")
        { }

        public DbSet<PetFeedEvents_DailyLog> PetFeedEvents_DailyLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<EventSrcContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

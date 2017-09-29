using PetFeedEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Context
{
    public class CEQDynamicCouponContext : BaseContext
    {
        public CEQDynamicCouponContext()
            : base("CEQ_DynamicCouponDB")
        { }

        public DbSet<CEQ_DynamicCouponQueue> CEQ_DynamicCouponQueue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<CEQDynamicCouponContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

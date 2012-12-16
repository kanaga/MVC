using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
//using EFCFCMSDomain.MapEntities;

namespace EFCFCMSDomain.DBContext
{
     public class CMSContext:DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
          //  modelBuilder.Configurations.Add(new BlockMap());
           // modelBuilder.Configurations.Add(new SchedulerMap());
          //  System.Data.Entity.Database.CreateDatabaseIfNotExists<CMSContext>(); 
        }
    }
}

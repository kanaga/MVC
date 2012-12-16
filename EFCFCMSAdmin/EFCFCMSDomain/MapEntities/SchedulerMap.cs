using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace EFCFCMSDomain.MapEntities
{
    public class SchedulerMap:EntityTypeConfiguration<Scheduler>
    {
       public SchedulerMap()
       {
           ToTable("Scheduler", "Content");
           HasKey(x => x.SchedulerId)
               .Property(x => x.SchedulerId)
                   .HasColumnName("SchedulerID")
                       .HasDatabaseGenerationOption(DatabaseGenerationOption.Identity);
       }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace EFCFCMSDomain.MapEntities
{
    public class BlockMap:EntityTypeConfiguration<Block>
    {
        public BlockMap()
        {
            ToTable("Block", "Content");
           HasKey(x => x.BlockId)
                .Property(x => x.BlockId)
                    .HasColumnName("BlockID")
                        .HasDatabaseGenerationOption(DatabaseGenerationOption.Identity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Promotion.Repository
{
    public class Promotion:DbContext
    {
        public DbSet<MainPromo> MainPromos { get; set; }
        public DbSet<PromotionRule> PromotionRules { get; set; }
        public DbSet<PromotionType> PromotionTypes { get; set; }
        public DbSet<RotatorBanner> RotatorBanners { get; set; }

       /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromotionRule>().HasRequired(m => m.MainPromo).WithMany(p => p.PromotionRules).HasForeignKey(m => m.Id);
            modelBuilder.Entity<RotatorBanner>().HasRequired(m => m.MainPromo).WithMany(r => r.RotatingBanners).HasForeignKey(m => m.Id);

        }*/

    }
}

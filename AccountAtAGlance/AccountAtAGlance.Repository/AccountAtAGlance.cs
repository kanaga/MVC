using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class AccountAtAGlance:DbContext
    {
        public DbSet<BrokerageAccount> BrokerageAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<MarketIndex> MarketIndexs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<MutualFund> MutualFunds { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Security>().ToTable("Securities");
            modelBuilder.Entity<Stock>().ToTable("Securities_Stock");
            modelBuilder.Entity<MutualFund>().ToTable("Securities_MutualFund");

            modelBuilder.Entity<WatchList>()
                .HasMany(w=>w.Securities).WithMany()
                .Map(map=>map.ToTable("WatchListSecurity")
                .MapRightKey("SecurityID")
                .MapLeftKey("WatchListID"));
        }

    }
}

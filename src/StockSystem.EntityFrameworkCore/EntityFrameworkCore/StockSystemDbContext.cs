using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StockSystem.Authorization.Roles;
using StockSystem.Authorization.Users;
using StockSystem.MultiTenancy;
using StockSystem.StockSystem.Goods;
using StockSystem.StockSystem.Suppliers;
using StockSystem.StockSystem.Customers;
using StockSystem.StockSystem.Stockings;
using StockSystem.StockSystem.InStocks;

namespace StockSystem.EntityFrameworkCore
{
    public class StockSystemDbContext : AbpZeroDbContext<Tenant, Role, User, StockSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public StockSystemDbContext(DbContextOptions<StockSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stocking> Stocking { get; set; }
        public DbSet<InStockDetail> InStockDetail { get; set; }
        public DbSet<InStockSummary> InStockSummary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().ToTable("SS_Goods");//改表名(SS is Stock System)
            modelBuilder.Entity<Supplier>().ToTable("SS_Supplier");//改表名(SS is Stock System)
            modelBuilder.Entity<Customer>().ToTable("SS_Customer");//改表名(SS is Stock System)
            modelBuilder.Entity<Stocking>().ToTable("SS_Stocking");//改表名(SS is Stock System)
            modelBuilder.Entity<InStockDetail>().ToTable("SS_InStockDetail");//改表名(SS is Stock System)
            modelBuilder.Entity<InStockSummary>().ToTable("SS_InStockSummary");//改表名(SS is Stock System)

            /*
            modelBuilder.Entity<Stocking>().HasOne(x => x.Goods).WithOne();

            modelBuilder.Entity<InStockSummary>().HasMany(x => x.InStockDetails).WithOne().HasForeignKey(x => x.InStockSummaryId);
            modelBuilder.Entity<InStockSummary>().HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId);

            //modelBuilder.Entity<InStockDetail>().HasOne(x => x.Goods).WithOne();
            modelBuilder.Entity<InStockDetail>().HasOne(x => x.Goods).WithMany();
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}

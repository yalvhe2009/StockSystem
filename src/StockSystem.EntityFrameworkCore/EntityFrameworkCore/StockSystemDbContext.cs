using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StockSystem.Authorization.Roles;
using StockSystem.Authorization.Users;
using StockSystem.MultiTenancy;
using StockSystem.StockSystem.Goods;
using StockSystem.StockSystem.Suppliers;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().ToTable("SS_Goods");//改表名(SS is Stock System)
            modelBuilder.Entity<Supplier>().ToTable("SS_Supplier");//改表名(SS is Stock System)
            base.OnModelCreating(modelBuilder);
        }
    }
}

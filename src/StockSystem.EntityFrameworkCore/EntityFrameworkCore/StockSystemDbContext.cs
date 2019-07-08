using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StockSystem.Authorization.Roles;
using StockSystem.Authorization.Users;
using StockSystem.MultiTenancy;

namespace StockSystem.EntityFrameworkCore
{
    public class StockSystemDbContext : AbpZeroDbContext<Tenant, Role, User, StockSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public StockSystemDbContext(DbContextOptions<StockSystemDbContext> options)
            : base(options)
        {
        }
    }
}

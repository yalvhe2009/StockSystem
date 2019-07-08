using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace StockSystem.EntityFrameworkCore
{
    public static class StockSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StockSystemDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<StockSystemDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StockSystem.Configuration;
using StockSystem.Web;

namespace StockSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class StockSystemDbContextFactory : IDesignTimeDbContextFactory<StockSystemDbContext>
    {
        public StockSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<StockSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            StockSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(StockSystemConsts.ConnectionStringName));

            return new StockSystemDbContext(builder.Options);
        }
    }
}

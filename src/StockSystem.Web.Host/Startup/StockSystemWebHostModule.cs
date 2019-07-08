using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StockSystem.Configuration;

namespace StockSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(StockSystemWebCoreModule))]
    public class StockSystemWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StockSystemWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StockSystemWebHostModule).GetAssembly());
        }
    }
}

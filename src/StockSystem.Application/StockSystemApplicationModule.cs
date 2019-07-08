using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StockSystem.Authorization;

namespace StockSystem
{
    [DependsOn(
        typeof(StockSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class StockSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<StockSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(StockSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

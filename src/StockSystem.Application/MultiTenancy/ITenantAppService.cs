using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StockSystem.MultiTenancy.Dto;

namespace StockSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


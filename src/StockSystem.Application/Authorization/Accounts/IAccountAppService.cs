using System.Threading.Tasks;
using Abp.Application.Services;
using StockSystem.Authorization.Accounts.Dto;

namespace StockSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using StockSystem.Sessions.Dto;

namespace StockSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

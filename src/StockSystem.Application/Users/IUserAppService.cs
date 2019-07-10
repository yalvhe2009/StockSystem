using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StockSystem.Authorization.Users;
using StockSystem.Roles.Dto;
using StockSystem.Users.Dto;

namespace StockSystem.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<User> GetNowLoginUser();
    }
}

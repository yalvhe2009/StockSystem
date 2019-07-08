using System.Collections.Generic;
using StockSystem.Roles.Dto;
using StockSystem.Users.Dto;

namespace StockSystem.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

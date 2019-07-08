using Abp.Authorization;
using StockSystem.Authorization.Roles;
using StockSystem.Authorization.Users;

namespace StockSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

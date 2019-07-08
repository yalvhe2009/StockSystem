using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace StockSystem.Controllers
{
    public abstract class StockSystemControllerBase: AbpController
    {
        protected StockSystemControllerBase()
        {
            LocalizationSourceName = StockSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

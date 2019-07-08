using Abp.AspNetCore.Mvc.ViewComponents;

namespace StockSystem.Web.Views
{
    public abstract class StockSystemViewComponent : AbpViewComponent
    {
        protected StockSystemViewComponent()
        {
            LocalizationSourceName = StockSystemConsts.LocalizationSourceName;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace StockSystem.Web.Views
{
    public abstract class StockSystemRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected StockSystemRazorPage()
        {
            LocalizationSourceName = StockSystemConsts.LocalizationSourceName;
        }
    }
}

using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using StockSystem.Configuration.Dto;

namespace StockSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : StockSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

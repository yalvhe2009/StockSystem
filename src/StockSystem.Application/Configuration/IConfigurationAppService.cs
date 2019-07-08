using System.Threading.Tasks;
using StockSystem.Configuration.Dto;

namespace StockSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

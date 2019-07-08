using Microsoft.AspNetCore.Antiforgery;
using StockSystem.Controllers;

namespace StockSystem.Web.Host.Controllers
{
    public class AntiForgeryController : StockSystemControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

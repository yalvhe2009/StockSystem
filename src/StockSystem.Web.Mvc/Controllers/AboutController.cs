using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using StockSystem.Controllers;

namespace StockSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : StockSystemControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

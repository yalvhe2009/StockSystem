using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockSystem.Controllers;

namespace StockSystem.Web.Mvc.Controllers
{
    public class StockingsController : StockSystemControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
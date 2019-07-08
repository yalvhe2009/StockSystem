using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StockSystem.Controllers;
using StockSystem.StockSystem.Goods;
using StockSystem.StockSystem.Goods.Dtos;

namespace StockSystem.Web.Mvc.Controllers
{
    public class GoodsController : StockSystemControllerBase
    {
        private readonly IGoodsAppService _goodsAppService;

        public GoodsController(IGoodsAppService goodsAppService)
        {
            this._goodsAppService = goodsAppService;
        }
               
        public async Task<IActionResult> Index()
        {
            //PagedResultDto < GoodsListDto > dtos= await _goodsAppService.GetPagedGoodsAsync(input);            
            //return View(dtos);
            return View();
        }
    }
}
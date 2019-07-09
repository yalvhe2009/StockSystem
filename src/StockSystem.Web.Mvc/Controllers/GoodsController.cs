﻿using System;
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
               
        public IActionResult Index()
        {
            return View();
        }
    }
}
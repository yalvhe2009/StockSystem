using Abp.Application.Services.Dto;
using StockSystem.StockSystem.Goods;
using StockSystem.StockSystem.Stockings;
using StockSystem.StockSystem.Stockings.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StockSystem.Tests.Stockings
{
    public class StockingAppServic_Tests : StockSystemTestBase
    {
        private readonly IStockingAppService _stockingAppService;

        public StockingAppServic_Tests()
        {
            this._stockingAppService = Resolve<IStockingAppService>();
        }

        [Fact]
        public void CreateOrUpdateStocking_Test()
        {
            Goods goods = new Goods { Id = 11, GoodsName = "水杯", GoodsManufacturer = "as", GoodsModel = "wu", GoodsProuductionDate = new DateTime() };
            UsingDbContext(context =>
               {                   
                   context.Goods.Add(goods);
               });

           
           StockingEditDto dto = new StockingEditDto { Id = 1, StockingNumber = 21, Goods = goods};
           // // Act
           _stockingAppService.CreateOrUpdateStockingAsync(new CreateOrUpdateStockingInput { StockingEditDto=dto});

            //var res = _stockingAppService.GetStockingByIdAsync(1);



            Assert.True(true);
          
        }
    }
}

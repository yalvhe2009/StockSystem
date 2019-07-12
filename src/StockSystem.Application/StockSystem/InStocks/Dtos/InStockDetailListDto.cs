using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    [AutoMapTo(typeof(InStockDetail))]
    public class InStockDetailListDto
    {
        //所属于哪个InStockSummary。（即这条明细属于哪个出库订单）
        public int InStockSummaryId { get; set; }//外键

        public StockSystem.Goods.Goods Goods { get; set; }//导航

        //这种货物入库的数量
        public int InStockAmount { get; set; }

        //这种货物入库的价格
        public Decimal InStockPrice { get; set; }

        //总金额
        public Decimal InStockSumPrice { get; set; }
    }
}

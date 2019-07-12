using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    [AutoMapTo(typeof(InStockDetail))]
    public class InStockDetailEditDto
    {
        //所属于哪个InStockSummary。（即这条明细属于哪个出库订单）
        [Required]
        public int InStockSummaryId { get; set; }//外键

        //这条明细的货物
        [Required]
        public int GoodsId { get; set; }//外键

        //这种货物入库的数量
        [Required]
        public int InStockAmount { get; set; }

        //这种货物入库的价格
        [Required]
        public Decimal InStockPrice { get; set; }

        //总金额
        [Required]
        public Decimal InStockSumPrice { get; set; }
    }
}

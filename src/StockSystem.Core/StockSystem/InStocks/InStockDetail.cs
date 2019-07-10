using Abp.Domain.Entities;
using StockSystem.Authorization.Users;
using StockSystem.StockSystem.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.InStocks
{
    public class InStockDetail : Entity<int>
    {
        //所属于哪个InStockSummary。（即这条明细属于哪个出库订单）
        [Required]
        public InStockSummary InStockSummary { get; set; }

        //这条明细的货物
        [Required]
        public StockSystem.Goods.Goods Goods { get; set; }

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

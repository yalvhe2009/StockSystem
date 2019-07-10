using Abp.Domain.Entities;
using StockSystem.Authorization.Users;
using StockSystem.StockSystem.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.InStocks
{
    public class InStockSummary : Entity<int>
    {
        //入库单号(用主键)

        //供应商
        [Required]
        public Supplier Supplier { get; set; }

        //操作人
        [Required]
        public User User { get; set; }
        //操作时间
        [Required]
        public DateTime OperatingTime { get; set; }

        //入库总金额
        [Required]
        public Decimal TotalAmount { get; set; }

    }
}

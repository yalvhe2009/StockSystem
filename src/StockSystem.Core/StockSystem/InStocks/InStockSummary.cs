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
        //入库单号
        [Required]
        public string InStockCode { get; set; }

        //供应商外键id
        [Required]
        public virtual int SupplierId { get; set; }
        //供应商
        [Required]
        public Supplier Supplier { get; set; }

        //操作人
        [Required]
        public string OperatingUser { get; set; }
        //操作时间
        [Required]
        public DateTime OperatingTime { get; set; }

        //入库总金额
        [Required]
        public Decimal TotalAmount { get; set; }

        // 入库单明细
        public ICollection<InStockDetail> InStockDetails { get; set; }
    }
}

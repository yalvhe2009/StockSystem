

using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    [AutoMapTo(typeof(InStockSummary))]
    public class InStockSummaryEditDto
    {
        //入库单号
        [Required]
        public string InStockCode { get; set; }

        //供应商外键id
        [Required]
        public virtual int SupplierId { get; set; }

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
        public List<InStockDetailEditDto> InStockDetails { get; set; }
    }
}

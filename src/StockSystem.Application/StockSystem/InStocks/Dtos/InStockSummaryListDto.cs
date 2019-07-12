using Abp.AutoMapper;
using StockSystem.StockSystem.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    [AutoMapFrom(typeof(InStockSummary))]
    public class InStockSummaryListDto
    {
        public int? Id { get; set; }

        //入库单号
        public string InStockCode { get; set; }

        //供应商
        public Supplier Supplier { get; set; }

        public string SupplierName { get; set; }

        //操作人
        public string OperatingUser { get; set; }
        //操作时间
        public DateTime OperatingTime { get; set; }

        //入库总金额
        public Decimal TotalAmount { get; set; }

        // 入库单明细
        //public List<InStockDetailListDto> InStockDetails { get; set; }
    }
}

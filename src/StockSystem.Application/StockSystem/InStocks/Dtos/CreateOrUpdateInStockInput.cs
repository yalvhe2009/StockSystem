using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    public class CreateOrUpdateInStockInput
    {
        [Required]
        public InStockSummaryEditDto InStockSummaryEditDto { get; set; }
    }
}

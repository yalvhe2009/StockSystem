

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.InStocks;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    public class CreateOrUpdateInStockSummaryInput
    {
        [Required]
        public InStockSummaryEditDto InStockSummaryEditDto { get; set; }

    }
}
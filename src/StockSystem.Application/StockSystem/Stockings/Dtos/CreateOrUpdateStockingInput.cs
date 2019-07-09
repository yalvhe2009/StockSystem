

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Stockings;

namespace StockSystem.StockSystem.Stockings.Dtos
{
    public class CreateOrUpdateStockingInput
    {
        [Required]
        public StockingEditDto StockingEditDto { get; set; }

    }
}
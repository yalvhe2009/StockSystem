

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Suppliers;

namespace StockSystem.StockSystem.Suppliers.Dtos
{
    public class CreateOrUpdateSupplierInput
    {
        [Required]
        public SupplierEditDto SupplierEditDto { get; set; }

    }
}
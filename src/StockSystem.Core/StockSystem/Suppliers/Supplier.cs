using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Suppliers
{
    public class Supplier : Entity<int> { 

        [Required]
        [MaxLength(StockSystemConsts.MaxSupplierNameLength)]
        public string SupplierName { get; set; }
    }
}

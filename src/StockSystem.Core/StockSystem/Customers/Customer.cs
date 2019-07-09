using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Customers
{
    public class Customer : Entity<int>
    {
        [Required]
        [MaxLength(StockSystemConsts.MaxCustomerNameLength)]
        public string CustomerName { get; set; }
    }
}



using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Customers;

namespace StockSystem.StockSystem.Customers.Dtos
{
    public class CreateOrUpdateCustomerInput
    {
        [Required]
        public CustomerEditDto CustomerEditDto { get; set; }

    }
}
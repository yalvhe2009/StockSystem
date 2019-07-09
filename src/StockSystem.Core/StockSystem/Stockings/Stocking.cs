using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Stockings
{
    public class Stocking : Entity<int>
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int StockingNumber { get; set; }

        [Required]
        public StockSystem.Goods.Goods Goods { get; set; }
    }
}

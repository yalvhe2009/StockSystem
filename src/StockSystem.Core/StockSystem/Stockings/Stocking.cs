using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Stockings
{
    public class Stocking : Entity<int>
    {

        //库存数量
        [Required]
        [Range(0, int.MaxValue)]
        public int StockingNumber { get; set; }

        [Required]
        public int GoodsId { get; set; }

        
        public StockSystem.Goods.Goods Goods { get; set; }
    }
}

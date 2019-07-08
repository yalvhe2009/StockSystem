using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Goods.Dtos
{
    public class CreateOrUpdateGoodsInput
    {
        public GoodsEditDto GoodsEditDto { get; set; }
    }
}

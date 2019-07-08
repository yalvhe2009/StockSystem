using Abp.Runtime.Validation;
using StockSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.StockSystem.Goods.Dtos
{
    public class GetGoodsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}

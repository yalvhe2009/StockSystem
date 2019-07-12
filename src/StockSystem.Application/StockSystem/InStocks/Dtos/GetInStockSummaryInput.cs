using Abp.Runtime.Validation;
using StockSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    public class GetInStockSummaryInput : PagedAndSortedInputDto, IShouldNormalize
    {
        // 正常化排序使用
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}

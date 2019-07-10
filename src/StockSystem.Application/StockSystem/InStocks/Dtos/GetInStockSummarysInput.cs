
using Abp.Runtime.Validation;
using StockSystem.Dtos;
using StockSystem.StockSystem.InStocks;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    public class GetInStockSummarysInput : PagedAndSortedInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}

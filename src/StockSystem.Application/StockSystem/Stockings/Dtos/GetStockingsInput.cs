
using Abp.Runtime.Validation;
using StockSystem.Dtos;
using StockSystem.StockSystem.Stockings;

namespace StockSystem.StockSystem.Stockings.Dtos
{
    public class GetStockingsInput : PagedAndSortedInputDto, IShouldNormalize
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

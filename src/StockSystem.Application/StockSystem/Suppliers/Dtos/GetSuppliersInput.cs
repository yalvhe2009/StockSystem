
using Abp.Runtime.Validation;
using StockSystem.Dtos;
using StockSystem.StockSystem.Suppliers;

namespace StockSystem.StockSystem.Suppliers.Dtos
{
    public class GetSuppliersInput : PagedAndSortedInputDto, IShouldNormalize
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

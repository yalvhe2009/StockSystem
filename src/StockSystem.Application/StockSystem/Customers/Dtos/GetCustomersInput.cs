
using Abp.Runtime.Validation;
using StockSystem.Dtos;
using StockSystem.StockSystem.Customers;

namespace StockSystem.StockSystem.Customers.Dtos
{
    public class GetCustomersInput : PagedAndSortedInputDto, IShouldNormalize
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

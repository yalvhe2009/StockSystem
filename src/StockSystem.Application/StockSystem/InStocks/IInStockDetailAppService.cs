using Abp.Application.Services;
using StockSystem.StockSystem.InStocks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockSystem.InStocks
{
    public interface IInStockDetailAppService : IApplicationService
    {
        //通过InStockSummaryId查找InStockDetail列表
        Task<List<InStockDetailListDto>> GetInStockDetailsByInStockSummaryIdAsync(int InStockSummaryId);

    }
}

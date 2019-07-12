using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StockSystem.StockSystem.InStocks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockSystem.InStocks
{
    public interface IInStockSummaryAppService : IApplicationService
    {
        // 完成入库业务
        Task DoInStockAsync(CreateOrUpdateInStockInput input);


        //查询当前所有的入库订单
        Task<PagedResultDto<InStockSummaryListDto>> GetPagedInStockSummaryAsync(GetInStockSummaryInput input);
    }
}

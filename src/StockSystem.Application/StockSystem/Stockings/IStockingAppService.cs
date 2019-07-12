
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using StockSystem.StockSystem.Stockings.Dtos;
using StockSystem.StockSystem.Stockings;

namespace StockSystem.StockSystem.Stockings
{
    /// <summary>
    /// Stocking应用层服务的接口方法
    ///</summary>
    public interface IStockingAppService : IApplicationService
    {
        // 添加库存 或 修改库存
        Task CreateOrUpdateStockingAsync(CreateOrUpdateStockingInput input);

        //删除库存(by Id)
        Task DeleteStockingAsync(EntityDto<int> inputDto);

        //查询库存（分页）
        Task<PagedResultDto<StockingListDto>> GetPagedStockingAsync(GetStockingsInput input);

        //查询库存（by id）
        Task<StockingListDto> GetStockingByIdAsync(NullableIdDto<int> input);
    }
}

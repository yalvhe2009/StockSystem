using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StockSystem.StockSystem.Goods.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockSystem.Goods
{
    public interface IGoodsAppService : IApplicationService
    {
        // 添加货物 或 修改货物
        Task CreateOrUpdateGoodsAsync(CreateOrUpdateGoodsInput input);

        //删除货物(by Id)
        Task DeleteGoodsAsync(EntityDto<int> inputDto);

        //查询货物（分页）
        Task<PagedResultDto<GoodsListDto>> GetPagedGoodsAsync(GetGoodsInput input);

        //查询货物（by id）
        Task<GoodsListDto> GetGoodsByIdAsync(NullableIdDto<int> input);
    }
}

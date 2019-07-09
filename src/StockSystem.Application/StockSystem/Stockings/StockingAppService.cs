
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using StockSystem.StockSystem.Stockings;
using StockSystem.StockSystem.Stockings.Dtos;




namespace StockSystem.StockSystem.Stockings
{
    /// <summary>
    /// Stocking应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class StockingAppService : StockSystemAppServiceBase, IStockingAppService
    {
        private readonly IRepository<Stocking> _stockingRepository;

        
        public StockingAppService(IRepository<Stocking> entityRepository)
        {
            _stockingRepository = entityRepository; 
            
        }

        public async Task CreateOrUpdateStockingAsync(CreateOrUpdateStockingInput input)
        {
            if (input.StockingEditDto.Id.HasValue)
            {
                //update
                await UpdateStockingAsync(input.StockingEditDto);
            }
            else
            {
                //insert
                await CreateStockingAsync(input.StockingEditDto);
            }
        }

        public async Task DeleteStockingAsync(EntityDto<int> inputDto)
        {
            var entity = await _stockingRepository.GetAsync(inputDto.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("数据已经不存在了，无法删除");
            }
            await _stockingRepository.DeleteAsync(inputDto.Id);
        }

        public async Task<PagedResultDto<StockingListDto>> GetPagedStockingAsync(GetStockingsInput input)
        {
            var query = _stockingRepository.GetAllIncluding(a => a.Goods);

            var stockingsCount = await query.CountAsync();

            var stockings = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = stockings.MapTo<List<StockingListDto>>();//把查出来的persons，转换到personListDto去。

            return new PagedResultDto<StockingListDto>(stockingsCount, dtos);
        }

        public async Task<StockingListDto> GetStockingByIdAsync(NullableIdDto<int> input)
        {
            var entity = await _stockingRepository.GetAsync(input.Id.Value);

            return entity.MapTo<StockingListDto>();
        }


        protected async Task UpdateStockingAsync(StockingEditDto input)
        {
            //TODO 能不能获取到 goods呢？
            Stocking entity = await _stockingRepository.GetAsync(input.Id.Value);

            await _stockingRepository.UpdateAsync(input.MapTo(entity));

        }

        protected async Task CreateStockingAsync(StockingEditDto input)
        {
            var entity = input.MapTo<Stocking>();
            await _stockingRepository.InsertAsync(entity);
        }
    }
}



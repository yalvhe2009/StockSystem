using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using StockSystem.StockSystem.Goods.Dtos;

namespace StockSystem.StockSystem.Goods
{
    public class GoodsAppService : StockSystemAppServiceBase,IGoodsAppService
    {
        private readonly IRepository<Goods> _goodsRepository;

        public GoodsAppService(IRepository<Goods> goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }


        public async Task CreateOrUpdateGoodsAsync(CreateOrUpdateGoodsInput input)
        {
            if (input.GoodsEditDto.Id.HasValue)
            {
                //update
                await UpdateGoodsAsync(input.GoodsEditDto);
            }
            else
            {
                //insert
                await CreateGoodsAsync(input.GoodsEditDto);
            }
        }

        public async Task DeleteGoodsAsync(EntityDto<int> inputDto)
        {
            var entity = await _goodsRepository.GetAsync(inputDto.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("这个数据已经不存在了，无法删除");
            }
            await _goodsRepository.DeleteAsync(inputDto.Id);
        }

        public async Task<GoodsListDto> GetGoodsByIdAsync(NullableIdDto<int> input)
        {
            var goods = await _goodsRepository.GetAsync(input.Id.Value);
            return goods.MapTo<GoodsListDto>();
        }

        public async Task<PagedResultDto<GoodsListDto>> GetPagedGoodsAsync(GetGoodsInput input)
        {
            var query = _goodsRepository.GetAll();
            var goodsCount = await query.CountAsync();
            var goods = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = goods.MapTo<List<GoodsListDto>>();
            return new PagedResultDto<GoodsListDto>(goodsCount, dtos);
        }


        //成员方法
        protected async Task CreateGoodsAsync(GoodsEditDto input)
        {
            Goods entity = input.MapTo<Goods>();
            await _goodsRepository.InsertAsync(entity);
        }

        protected async Task UpdateGoodsAsync(GoodsEditDto input)
        {
            Goods entity = await _goodsRepository.GetAsync(input.Id.Value);
            
            await _goodsRepository.UpdateAsync(input.MapTo(entity));
        }
    }
}

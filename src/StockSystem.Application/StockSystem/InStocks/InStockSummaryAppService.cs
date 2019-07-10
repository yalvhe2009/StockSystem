
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


using StockSystem.StockSystem.InStocks;
using StockSystem.StockSystem.InStocks.Dtos;




namespace StockSystem.StockSystem.InStocks
{

    public class InStockSummaryAppService : StockSystemAppServiceBase, IInStockSummaryAppService
    {
        private readonly IRepository<InStockSummary> _entityRepository;

        

        /// <summary>
        /// 构造函数 
        ///</summary>
        public InStockSummaryAppService(
        IRepository<InStockSummary> entityRepository
        
        )
        {
            _entityRepository = entityRepository; 
            
        }


        /// <summary>
        /// 获取InStockSummary的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<InStockSummaryListDto>> GetPaged(GetInStockSummarysInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<InStockSummaryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<InStockSummaryListDto>>();

			return new PagedResultDto<InStockSummaryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取InStockSummaryListDto信息
		/// </summary>
		 
		public async Task<InStockSummaryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<InStockSummaryListDto>();
		}

		/// <summary>
		/// 获取编辑 InStockSummary
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetInStockSummaryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetInStockSummaryForEditOutput();
            InStockSummaryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<InStockSummaryEditDto>();

				//inStockSummaryEditDto = ObjectMapper.Map<List<inStockSummaryEditDto>>(entity);
			}
			else
			{
				editDto = new InStockSummaryEditDto();
			}

			output.InStockSummaryEditDto = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改InStockSummary的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateInStockSummaryInput input)
		{

			if (input.InStockSummaryEditDto.Id.HasValue)
			{
				await Update(input.InStockSummaryEditDto);
			}
			else
			{
				await Create(input.InStockSummaryEditDto);
			}
		}


		/// <summary>
		/// 新增InStockSummary
		/// </summary>
		
		protected virtual async Task<InStockSummaryEditDto> Create(InStockSummaryEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <InStockSummary>(input);
            var entity=input.MapTo<InStockSummary>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<InStockSummaryEditDto>();
		}

		/// <summary>
		/// 编辑InStockSummary
		/// </summary>
		
		protected virtual async Task Update(InStockSummaryEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除InStockSummary信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除InStockSummary的方法
		/// </summary>
		
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}

    }
}



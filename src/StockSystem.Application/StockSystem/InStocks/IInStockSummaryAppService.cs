
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


using StockSystem.StockSystem.InStocks.Dtos;
using StockSystem.StockSystem.InStocks;

namespace StockSystem.StockSystem.InStocks
{
    /// <summary>
    /// InStockSummary应用层服务的接口方法
    ///</summary>
    public interface IInStockSummaryAppService : IApplicationService
    {
        /// <summary>
		/// 获取InStockSummary的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<InStockSummaryListDto>> GetPaged(GetInStockSummarysInput input);


		/// <summary>
		/// 通过指定id获取InStockSummaryListDto信息
		/// </summary>
		Task<InStockSummaryListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetInStockSummaryForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改InStockSummary的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateInStockSummaryInput input);


        /// <summary>
        /// 删除InStockSummary信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除InStockSummary
        /// </summary>
        Task BatchDelete(List<int> input);



    }
}

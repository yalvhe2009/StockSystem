
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


using StockSystem.StockSystem.Customers.Dtos;
using StockSystem.StockSystem.Customers;

namespace StockSystem.StockSystem.Customers
{
    public interface ICustomerAppService : IApplicationService
    {

        // 添加客户 或 修改客户
        Task CreateOrUpdateCustomerAsync(CreateOrUpdateCustomerInput input);

        //删除客户(by Id)
        Task DeleteCustomerAsync(EntityDto<int> inputDto);

        //查询客户（分页）
        Task<PagedResultDto<CustomerListDto>> GetPagedCustomerAsync(GetCustomersInput input);

        //查询客户（by id）
        Task<CustomerListDto> GetCustomerByIdAsync(NullableIdDto<int> input);
    }
}


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


using StockSystem.StockSystem.Suppliers.Dtos;
using StockSystem.StockSystem.Suppliers;

namespace StockSystem.StockSystem.Suppliers
{
    public interface ISupplierAppService : IApplicationService
    {

        // 添加供应商 或 修改供应商
        Task CreateOrUpdateSupplierAsync(CreateOrUpdateSupplierInput input);

        //删除供应商(by Id)
        Task DeleteSupplierAsync(EntityDto<int> inputDto);

        //查询供应商（分页）
        Task<PagedResultDto<SupplierListDto>> GetPagedSupplierAsync(GetSuppliersInput input);

        //查询供应商（by id）
        Task<SupplierListDto> GetSupplierByIdAsync(NullableIdDto<int> input);
    }
}

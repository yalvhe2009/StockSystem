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
using StockSystem.StockSystem.Suppliers.Dtos;

namespace StockSystem.StockSystem.Suppliers
{
    public class SupplierAppService : StockSystemAppServiceBase,ISupplierAppService
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplierAppService(IRepository<Supplier> supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }
        public async Task CreateOrUpdateSupplierAsync(CreateOrUpdateSupplierInput input)
        {
            if (input.SupplierEditDto.Id.HasValue)
            {
                //update
                await UpdateSupplierAsync(input.SupplierEditDto);
            }
            else
            {
                //insert
                await CreateSupplierAsync(input.SupplierEditDto);
            }
        }

        public async Task DeleteSupplierAsync(EntityDto<int> inputDto)
        {
            Supplier entity = await _supplierRepository.GetAsync(inputDto.Id);
            if (entity==null)
            {
                throw new UserFriendlyException("供应商不存在，无法删除");
            }
            await _supplierRepository.DeleteAsync(inputDto.Id);
        }

        public async Task<PagedResultDto<SupplierListDto>> GetPagedSupplierAsync(GetSuppliersInput input)
        {
            var query = _supplierRepository.GetAll();
            var supplierCount = await query.CountAsync();
            var suppliers = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = suppliers.MapTo<List<SupplierListDto>>();
            return new PagedResultDto<SupplierListDto>(supplierCount, dtos);
        }

        public async Task<SupplierListDto> GetSupplierByIdAsync(NullableIdDto<int> input)
        {
            Supplier entity = await _supplierRepository.GetAsync(input.Id.Value);
            return entity.MapTo<SupplierListDto>();
        }
        

        protected async Task CreateSupplierAsync(SupplierEditDto input)
        {
            await _supplierRepository.InsertAsync(input.MapTo<Supplier>());
        }

        protected async Task UpdateSupplierAsync(SupplierEditDto input)
        {
            Supplier entity = await _supplierRepository.GetAsync(input.Id.Value);

            await _supplierRepository.UpdateAsync(input.MapTo(entity));

        }
    }
}

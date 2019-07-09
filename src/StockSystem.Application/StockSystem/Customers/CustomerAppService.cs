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
using StockSystem.StockSystem.Customers.Dtos;

namespace StockSystem.StockSystem.Customers
{
    public class CustomerAppService : StockSystemAppServiceBase,ICustomerAppService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerAppService(IRepository<Customer> supplierRepository)
        {
            this._customerRepository = supplierRepository;
        }
        public async Task CreateOrUpdateCustomerAsync(CreateOrUpdateCustomerInput input)
        {
            if (input.CustomerEditDto.Id.HasValue)
            {
                //update
                await UpdateCustomerAsync(input.CustomerEditDto);
            }
            else
            {
                //insert
                await CreateCustomerAsync(input.CustomerEditDto);
            }
        }

        public async Task DeleteCustomerAsync(EntityDto<int> inputDto)
        {
            Customer entity = await _customerRepository.GetAsync(inputDto.Id);
            if (entity==null)
            {
                throw new UserFriendlyException("供应商不存在，无法删除");
            }
            await _customerRepository.DeleteAsync(inputDto.Id);
        }

        public async Task<PagedResultDto<CustomerListDto>> GetPagedCustomerAsync(GetCustomersInput input)
        {
            var query = _customerRepository.GetAll();
            var supplierCount = await query.CountAsync();
            var suppliers = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = suppliers.MapTo<List<CustomerListDto>>();
            return new PagedResultDto<CustomerListDto>(supplierCount, dtos);
        }

        public async Task<CustomerListDto> GetCustomerByIdAsync(NullableIdDto<int> input)
        {
            Customer entity = await _customerRepository.GetAsync(input.Id.Value);
            return entity.MapTo<CustomerListDto>();
        }
        

        protected async Task CreateCustomerAsync(CustomerEditDto input)
        {
            await _customerRepository.InsertAsync(input.MapTo<Customer>());
        }

        protected async Task UpdateCustomerAsync(CustomerEditDto input)
        {
            Customer entity = await _customerRepository.GetAsync(input.Id.Value);

            await _customerRepository.UpdateAsync(input.MapTo(entity));

        }
    }
}

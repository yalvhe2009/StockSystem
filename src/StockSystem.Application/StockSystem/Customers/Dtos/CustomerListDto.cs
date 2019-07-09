

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Customers;

namespace StockSystem.StockSystem.Customers.Dtos
{
    public class CustomerListDto : EntityDto<int> 
    {

        
		/// <summary>
		/// CustomerName
		/// </summary>
[MaxLength(StockSystemConsts.MaxCustomerNameLength)]
		[Required(ErrorMessage="CustomerName不能为空")]
		public string CustomerName { get; set; }




    }
}
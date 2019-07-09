
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using StockSystem.StockSystem.Customers;

namespace  StockSystem.StockSystem.Customers.Dtos
{
    public class CustomerEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// CustomerName
		/// </summary>
        [MaxLength(StockSystemConsts.MaxCustomerNameLength)]
		[Required(ErrorMessage="CustomerName不能为空")]
		public string CustomerName { get; set; }




    }
}
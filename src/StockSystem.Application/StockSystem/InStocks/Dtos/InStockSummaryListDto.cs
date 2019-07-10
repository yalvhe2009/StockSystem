

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.InStocks;
using StockSystem.StockSystem.Suppliers;
using StockSystem.Authorization.Users;

namespace StockSystem.StockSystem.InStocks.Dtos
{
    public class InStockSummaryListDto : EntityDto<int> 
    {

        
		/// <summary>
		/// InStockNumber
		/// </summary>
		[Required(ErrorMessage="InStockNumber不能为空")]
		public string InStockNumber { get; set; }



		/// <summary>
		/// Supplier
		/// </summary>
		[Required(ErrorMessage="Supplier不能为空")]
		public Supplier Supplier { get; set; }



		/// <summary>
		/// User
		/// </summary>
		[Required(ErrorMessage="User不能为空")]
		public User User { get; set; }



		/// <summary>
		/// OperatingTime
		/// </summary>
		[Required(ErrorMessage="OperatingTime不能为空")]
		public DateTime OperatingTime { get; set; }




    }
}
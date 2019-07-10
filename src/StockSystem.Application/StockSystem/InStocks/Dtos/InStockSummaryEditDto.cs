
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using StockSystem.Authorization.Users;
using StockSystem.StockSystem.InStocks;
using StockSystem.StockSystem.Suppliers;

namespace  StockSystem.StockSystem.InStocks.Dtos
{
    public class InStockSummaryEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
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
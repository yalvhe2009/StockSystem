
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using StockSystem.StockSystem.Suppliers;

namespace  StockSystem.StockSystem.Suppliers.Dtos
{
    public class SupplierEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// SupplierName
		/// </summary>
        [MaxLength(StockSystemConsts.MaxGoodsNameLength)]
		[Required(ErrorMessage="SupplierName不能为空")]
		public string SupplierName { get; set; }




    }
}
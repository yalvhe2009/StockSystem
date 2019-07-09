
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using StockSystem.StockSystem.Stockings;

namespace  StockSystem.StockSystem.Stockings.Dtos
{
    public class StockingEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// StockingNumber
		/// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int StockingNumber { get; set; }



        /// <summary>
        /// Goods
        /// </summary>
        [Required]
        public StockSystem.Goods.Goods Goods { get; set; }




    }
}
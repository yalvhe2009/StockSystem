

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Stockings;

namespace StockSystem.StockSystem.Stockings.Dtos
{
    public class StockingListDto : EntityDto<int> 
    {

        
		/// <summary>
		/// StockingNumber
		/// </summary>
		public int StockingNumber { get; set; }



		/// <summary>
		/// Goods
		/// </summary>
		public StockSystem.Goods.Goods Goods { get; set; }




    }
}
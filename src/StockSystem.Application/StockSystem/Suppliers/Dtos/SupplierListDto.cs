

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using StockSystem.StockSystem.Suppliers;

namespace StockSystem.StockSystem.Suppliers.Dtos
{
    public class SupplierListDto
    {

        public int? Id { get; set; }


        /// 
		public string SupplierName { get; set; }




    }
}
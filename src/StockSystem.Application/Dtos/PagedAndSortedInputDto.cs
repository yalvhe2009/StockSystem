using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.Dtos
{
    public class PagedAndSortedInputDto : IPagedResultRequest, ISortedResultRequest
    {
        [Range(0,int.MaxValue)]
        public int SkipCount { get; set; }
        [Range(1,500)]      
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; }
    }
}

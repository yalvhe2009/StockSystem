using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StockSystem.StockSystem.InStocks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockSystem.InStocks
{
    public class InStockDetailAppService : IInStockDetailAppService
    {
        private readonly IRepository<InStockDetail> _inStockDetailRepository;

        public InStockDetailAppService(IRepository<InStockDetail> inStockDetailRepository)
        {
            this._inStockDetailRepository = inStockDetailRepository;
        }
        public async Task<List<InStockDetailListDto>> GetInStockDetailsByInStockSummaryIdAsync(int InStockSummaryId)
        {
            var entities = await _inStockDetailRepository.GetAll().Where(x => x.InStockSummaryId == InStockSummaryId).ToListAsync();
            var dtos = entities.MapTo<List<InStockDetailListDto>>();
            return dtos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using StockSystem.StockSystem.InStocks.Dtos;
using StockSystem.StockSystem.Stockings;

namespace StockSystem.StockSystem.InStocks
{
    public class InStockSummaryAppService : StockSystemAppServiceBase, IInStockSummaryAppService
    {
        private readonly IRepository<InStockSummary> _inStockSummary;
        private readonly IRepository<Stocking> _stockingRepository;

        public InStockSummaryAppService(IRepository<InStockSummary> inStockSummary, IRepository<Stocking> stockingRepository)
        {
            this._inStockSummary = inStockSummary;
            this._stockingRepository = stockingRepository;
        }
        //执行入库业务
        public async Task DoInStockAsync(CreateOrUpdateInStockInput input)
        {
            var InStockSummaryEditDto = input.InStockSummaryEditDto;
            //判断入库单号是否已经存在
            var o1 = _inStockSummary.GetAll().FirstOrDefault(x => x.InStockCode == InStockSummaryEditDto.InStockCode);
            if(o1 != null)
            {
                throw new UserFriendlyException("您输入的单号已经存在，请重新输入！");
            }

            Decimal totalAmount = 0;//订单总金额
            //计算每条小条目的总金额
            InStockSummaryEditDto.InStockDetails.ForEach(e => {
                e.InStockSumPrice = e.InStockAmount * e.InStockPrice;
                totalAmount += e.InStockSumPrice;//计算订单总金额
            });

            InStockSummaryEditDto.TotalAmount = totalAmount;

            //把InStockSummaryEditDto转换为InStockSummary对象
            InStockSummary inStockSummary = InStockSummaryEditDto.MapTo<InStockSummary>();
            //插入数据
            await _inStockSummary.InsertAsync(inStockSummary);

            //修改库存表-判断某条货物是否在库存表中存在？存在则Update，不存在则insert
            InStockSummaryEditDto.InStockDetails.ForEach(e => {
                var res = _stockingRepository.GetAll().FirstOrDefault(x=>x.GoodsId==e.GoodsId);
                if (res == null)
                {
                    //insert（当前入库数量）
                    var entity = new Stocking {
                        StockingNumber = e.InStockAmount,
                        GoodsId = e.GoodsId
                    };
                    _stockingRepository.Insert(entity);
                }
                else
                {
                    //update(原本数量+当前入库数量)
                    res.StockingNumber += e.InStockAmount;
                    _stockingRepository.Update(res);
                }
            });
            
        }

        // 查询已入库的订单
        public async Task<PagedResultDto<InStockSummaryListDto>> GetPagedInStockSummaryAsync(GetInStockSummaryInput input)
        {
            var query = _inStockSummary.GetAllIncluding(x=>x.Supplier);            
            var inStockSummariesCount = await query.CountAsync();
            var inStockSummaries = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = inStockSummaries.MapTo<List<InStockSummaryListDto>>();
            dtos.ForEach(x=> {
                if(x.Supplier != null)
                {
                    x.SupplierName = x.Supplier.SupplierName;
                }
            });
            return new PagedResultDto<InStockSummaryListDto>(inStockSummariesCount, dtos);
            
        }
    }
}

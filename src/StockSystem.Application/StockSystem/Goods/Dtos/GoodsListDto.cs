using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.StockSystem.Goods.Dtos
{
    public class GoodsListDto
    {
        //货物编码使用主键
        public int? Id { get; set; }

        //货物名称
        public string GoodsName { get; set; }

        //生产厂家

        public string GoodsManufacturer { get; set; }

        //生产日期

        public DateTime GoodsProuductionDate { get; set; }

        //规格型号
        public string GoodsModel { get; set; }
    }
}

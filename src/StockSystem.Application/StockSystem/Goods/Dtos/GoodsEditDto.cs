using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockSystem.StockSystem.Goods.Dtos
{
    public class GoodsEditDto
    {
        //货物编码使用主键
        public int? Id { get; set; }

        //货物名称
        [Required]
        [MaxLength(StockSystemConsts.MaxGoodsNameLength)]
        public string GoodsName { get; set; }

        //生产厂家
        [Required]
        [MaxLength(StockSystemConsts.MaxGoodsManufacturerLength)]
        public string GoodsManufacturer { get; set; }

        //生产日期
        [Required]
        public DateTime GoodsProuductionDate { get; set; }

        //规格型号
        [MaxLength(StockSystemConsts.MaxGoodsModelLength)]
        public string GoodsModel { get; set; }
    }
}

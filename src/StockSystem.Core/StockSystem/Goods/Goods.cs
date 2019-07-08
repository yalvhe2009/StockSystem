using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

//货物名称，货物编码，生产厂家，生产日期，规格型号
namespace StockSystem.StockSystem.Goods
{
    //goods是不可数名词
    public class Goods : Entity<int>
    {

        //货物编码使用主键

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

using Discount.BLL.DTO.Product;
using Discount.Data.ORM.Entities;
using System;
namespace Discount.BLL.DTO.Basket
{
	public class Basket
	{
        public int ID { get; set; }
        public double Amount { get; set; }
        public bool Discount { get; set; }
        public double Price { get; set; }
        public List<Product.Product> Product { get; set; }
    }
}


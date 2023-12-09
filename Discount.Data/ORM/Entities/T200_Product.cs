using Discount.Data.ORM.Base;
using System;
namespace Discount.Data.ORM.Entities
{
	public class T200_Product : BaseEntity
	{
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }

        //List<T211_BasketProduct> BasketProducts { get; set; }
    }
}


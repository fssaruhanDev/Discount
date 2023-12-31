﻿using Discount.Data.ORM.Base;
using System;
namespace Discount.Data.ORM.Entities
{
	public class T200_Product : BaseEntity
	{
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required string ProductCompany { get; set; }
        public required string ProductSize { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }


        public int CompanyID { get; set; }
        public T201_Category Category { get; set; }

        List<T211_BasketProduct>? BasketProducts { get; set; }
    }
}


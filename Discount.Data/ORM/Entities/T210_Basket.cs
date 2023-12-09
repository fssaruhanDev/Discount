using Discount.Data.ORM.Base;
using System;
namespace Discount.Data.ORM.Entities
{
	public class T210_Basket : BaseEntity
	{
        public T211_BasketProduct BasketProduct { get; set; }

        public double Amount { get; set; }
        public double Discount { get; set; }

    }
}


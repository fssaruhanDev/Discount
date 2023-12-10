using Discount.Data.ORM.Base;
using System;
namespace Discount.Data.ORM.Entities
{
	public class T210_Basket : BaseEntity
	{
     

        public double Amount { get; set; }
        public bool Discount { get; set; }

        public int UserID { get; set; }
        public T100_User User { get; set; }

        public List<T211_BasketProduct> BasketProduct { get; set; }

    }
}


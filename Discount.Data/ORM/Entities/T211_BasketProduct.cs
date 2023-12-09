using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Data.ORM.Entities
{
    public class T211_BasketProduct
    {

        public int ID { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        public int BasketID { get; set; }
        public T210_Basket Basket { get; set; }

        public int ProductID { get; set; }
        public T200_Product Product { get; set; }


    }
}
